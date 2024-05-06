#include <iostream>
#include <vector>

using namespace std;

int n;
vector< vector<int> > a;
vector<int> b;

const int INF = 1000000;

/*
    0 7 10 0 0 0 0 0 0
    7 0 0 0 0 9 27 0 0
    10 0 0 0 31 8 0 0 0
    0 0 0 0 32 0 0 17 21
    0 0 31 32 0 0 0 0 0
    0 9 8 0 0 0 0 11 0
    0 27 0 0 0 0 0 0 15
    0 0 0 17 0 11 0 0 15
    0 0 0 21 0 0 15 15 0
*/
int start;

void changeValue(int i, int currWay) {
	for (int j = 0; j < n; j++) {
        if (i == j || j == start) {
            continue; // ignore petli and start point
        }

		if (a[i][j] > 0 && b[j] > currWay + a[i][j]) {
			b[j] = currWay + a[i][j];
			changeValue(j, currWay + a[i][j]);
		}
	}
}

int main()
{

    cout << "Input n: ";
    cin >> n;
    a.resize(n);

    cout << "Input the matrix: ";
    for (int i = 0; i < n; i++) {
        a[i].resize(n);
        for (int j = 0; j < n; j++) {
            cin >> a[i][j];
        }
    }

    b.resize(n, INF);


    cout << "Input start point: ";
    cin >> start;

    changeValue(start, 0);

    b[start] = 0;

    for (auto i = 0; i < n; i++) {
        cout << char(65 + i) << " : " << b[i] << "\n";
    }
}
