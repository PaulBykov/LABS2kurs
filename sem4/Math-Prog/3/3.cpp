#include "D:/help/feat.hpp"

const short n = 2;
const short m = 5;

const vector<vector<int> > costMatrix{ 
	{INF, 2*n, 21+n, INF, n},
	{n, INF, 15+n, 68-n, 84-n},
	{2+n, 3*n, INF, 86, 49+n},
	{17+n, 58-n, 4*n, INF, 3*n},
	{93-n, 66+n, 52, 13+n, INF},
};


int computeCost(const vector<int>& path) {
    int cost = 0;
    int n = path.size();
    for (int i = 0; i < n - 1; ++i) {
        cost += costMatrix[path[i]][path[i + 1]];
    }
    cost += costMatrix[path[n - 1]][path[0]]; // Add cost to return to the starting city
    return cost;
}


vector<int> bestPath;
int minCost = INF;

void tspBranchAndBound(int pos, int cost, vector<int>& path, vector<bool>& visited) {
    if (pos == m) {
        cost += costMatrix[path[pos - 1]][path[0]];
        if (cost < minCost) {
            minCost = cost;
            bestPath = path;
        }
        return;
    }

    for (int k = 0; k < m; ++k) {
        if (costMatrix[path[pos - 1]][k] != INF && !visited[k]) {
            path[pos] = k;
            visited[k] = true;
            tspBranchAndBound(pos + 1, cost + costMatrix[path[pos - 1]][k], path, visited);
            visited[k] = false;
        }
    }
}


int main() {
    RU;
    includeFastIO();

    vector<int> path(m);
    vector<bool> visited(m, false);
    path[0] = 0;
    visited[0] = true;

    printMatrix(costMatrix);

    tspBranchAndBound(1, 0, path, visited);

    cout << "Минимальная стоимость: " << minCost << endl;
    cout << "Оптимальный путь: ";
    printVector(bestPath);


    cout << "----------------------------------------------------\n Permutations:\n";
    
    vector<int> cities(m);
    for (int i = 0; i < m; ++i) {
        cities[i] = i;
    }

    do {
        int cost = computeCost(cities);
        if (cost < minCost) {
            minCost = cost;
            bestPath = cities;
        }
    } while (next_permutation(cities.begin(), cities.end()));

    // Output the best path found by brute force
    cout << "Best path found by brute force: ";
    for (int city : bestPath) {
        cout << city << " ";
    }


    cout << endl;

    return 0;
}
