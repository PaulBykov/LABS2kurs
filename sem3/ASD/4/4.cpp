#include <iostream>
#include <vector>

using namespace std;

int n, start;
vector< vector<int> > a;
vector< vector<int> > s;

const int INF = 1000000;

/*
    6
    0 28 21 59 12 27
    7 0 24 0 21 9
    9 32 0 13 11 0
    8 0 5 0 16 0
    14 13 15 10 0 22
    15 18 0 0 6 0
*/

void printMatrix(vector< vector<int> > a) {
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            if (a[i][j] == INF) {
                cout << "0" << " ";
                continue;
            }

            cout << a[i][j] << " ";
        }
        cout << "\n";
    }
}


int main()
{
    ios_base::sync_with_stdio(false);
    cin.tie(NULL);
    cout.tie(NULL);

    cout << "Input n: ";
    cin >> n;
    a.resize(n);

    cout << "Input the matrix: ";
    for (int i = 0; i < n; i++) {
        a[i].resize(n);
        for (int j = 0; j < n; j++) {
            cin >> a[i][j];
            if (a[i][j] == 0) {
                a[i][j] = INF;
            }
        }
    }

    s.resize(n, vector<int>(n));
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            if (i == j) {
                continue;
            }

            s[i][j] = j + 1;
        }
    }

    cout << "\n \t MATRIX D: \n";
    printMatrix(a);

    cout << "\n \t MATRIX S: \n";
    printMatrix(s);

    cout << "\n-----------------------------------------------------------------\n";

    for (int k = 0; k < n; ++k) {
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                if (a[i][k] < INF && a[k][j] < INF && i != j && a[i][k] + a[k][j] < a[i][j]) {
                    a[i][j] = a[i][k] + a[k][j];
                    s[i][j] = k;
                }
            }
        }
    }

    cout << "\n \t MATRIX D: \n";
    printMatrix(a);
    
    cout << "\n \t MATRIX S: \n";
    printMatrix(s);


    return 0;
}
