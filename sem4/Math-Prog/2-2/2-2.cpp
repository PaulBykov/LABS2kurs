#include "D:/help/feat.hpp"
#include "chrono"

using namespace std;

typedef vector<int> subset;



vector<subset> generateSubsets(const vector<int>& set) {
    int n = set.size();
    vector<vector<int>> subsets;
    // от 0 до 2^n - 1
    for (int i = 0; i < (1 << n); ++i) {
        vector<int> subset;
        // Для каждого бита в числе
        for (int j = 0; j < n; ++j) {
            // Если j-й бит установлен в 1, то
            if (i & (1 << j)) {
                subset.push_back(set[j]);
            }
        }
        subsets.push_back(subset);
    }
    return subsets;
}

void generate_permutations(vector<int>& vec) {
    cout << "\nPERMUTATIONS: \n";
    sort(vec.begin(), vec.end());

    // Генерируем и выводим все перестановки
    do {
        for (int i : vec) {
            cout << i << " ";
        }
        cout << endl;
    } while (next_permutation(vec.begin(), vec.end()));

    cout << "---------------------------------------------------------------\n";
}


void generate_combinations(std::vector<int>& vec, int r) {
    cout << "\COMBINATIONS: \n";
    std::vector<int> bitmask(r, 1);
    bitmask.resize(vec.size(), 0);

    // Генерируем и выводим все сочетания
    do {
        for (int i = 0; i < vec.size(); ++i) {
            if (bitmask[i]) {
                std::cout << vec[i] << " ";
            }
        }
        std::cout << std::endl;
    } while (std::prev_permutation(bitmask.begin(), bitmask.end()));
    cout << "---------------------------------------------------------------\n";
}

void generate_locations(std::vector<int>& vec) {
    cout << "\nLOCATIONS: \n";
    std::sort(vec.begin(), vec.end());

    // Генерируем и выводим все размещения
    do {
        for (int i : vec) {
            std::cout << i << " ";
        }
        std::cout << std::endl;
    } while (std::next_permutation(vec.begin(), vec.end()));
    cout << "---------------------------------------------------------------\n";
}


int solveBackpuck(vector<subset> set, subset weights, subset prices, int maxW) {
    int bestInd = 0;
    int bestRes = 0;

    for (int i = 0; i < set.size(); i++) {
        int sumW = 0;
        int sumP = 0;

        for (int j = 0; j < set[i].size(); j++) {
            sumW += weights[set[i][j]];
            sumP += weights[set[i][j]] * prices[set[i][j]];
        }

        if (sumW >= maxW) continue;

        if (bestRes <= sumP) {
            bestRes = sumP;
            bestInd = i;
        }
    }


    cout << "Best variant #" << bestInd << "\n";
    cout << "Its value: " << bestRes << "\n";

    return bestInd;
};

void task1(vector<vector<int>> subs) {
    for (int i = 0; i < subs.size(); i++) {
        generate_permutations(subs[i]);
        generate_locations(subs[i]);
        generate_combinations(subs[i], 2);
    }
}


int main() {
    RU;
    includeFastIO();

    int n;
    int V;

    cout << "Введите количетсво предметов: ";
    cin >> n;

    vector<int> weights(n);
    vector<int> prices(n);
    vector<int> set(n);
    for (int i = 1; i < n; i++) {
        set[i] = set[i - 1] + 1;
    }

    cout << "Введите вектор весов: ";
    cinVector(weights);

    cout << "Введите вектор цен: ";
    cinVector(prices);

    cout << "Максимальный вес: ";
    cin >> V;

    vector<vector<int>> subsets = generateSubsets(set);

    printMatrix(subsets);

    cout << "-------------------------------------\n";
    auto start = chrono::high_resolution_clock::now();
    int var = solveBackpuck(subsets, weights, prices, V);
    auto stop = chrono::high_resolution_clock::now();

    chrono::duration<double> elapsed = stop - start;
    cout << "Time spendet: " << elapsed.count() << "\n";
    return 0;
}