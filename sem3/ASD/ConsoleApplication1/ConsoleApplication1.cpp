#include <iostream>
#include <vector>
#include <queue>


using namespace std;


vector < vector <int> > a;
vector <bool> p, p1;
int n, k = 0, k1 = 0;


void DFS(int x) {
    p[x] = true;
    k++;

    for (int i = 0; i < n; i++)
        if (a[x][i] == 1 && !p[i]) {
            cout << "-> [" << x << "," << i << "]";
            DFS(i);
        }
}


queue <int> q;
void BFS(int s) {
    p1[s] = true;
    q.push(s);

    while (!q.empty()) {
        int x = q.front();
        q.pop();

        for (int i = 0; i < n; i++) {
            if (a[x][i] == 1 && !p1[i]) {
                cout << "-> [" << x << "," << i << "]";

                p1[i] = true; 
                k1++;
                q.push(i);
            }
        }
    }

}


void adjacencyMatrixToEdgeList(vector<vector<int>>& adjacencyMatrix) {
    int n = adjacencyMatrix.size();

    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < n; ++j) {
            if (adjacencyMatrix[i][j] == 1) {
                cout << "[" << i << "," << j << "]" << endl;
            }
        }
    }
}


void printAdjacencyList(const vector<vector<int>>& adjacencyMatrix) {
    int n = adjacencyMatrix.size();


    for (int i = 0; i < n; ++i) {
        cout << "For " << i << ": ";
        for (int j = 0; j < n; ++j) {
            if (adjacencyMatrix[i][j] == 1) {
                cout << j << " ";
            }
        }
        cout << endl;
    }
}


int main()
{
    int s;

    cin >> n >> s; 
    s--;

    a.resize(n, vector <int>(n));
    p.resize(n);
    p1.resize(n);

    for (int i = 0; i < n; i++)
        for (int j = 0; j < n; j++)
            cin >> a[i][j];


    cout << "BFS: \n";
    BFS(s--);
    
    cout << "\nDFS: \n";
    DFS(s--);

    cout << "\nSpisok reber: \n";
    adjacencyMatrixToEdgeList(a);
    
    cout << "\nSpisok smejnosti: \n";
    printAdjacencyList(a);

    return 0;
}
