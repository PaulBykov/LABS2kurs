#include <iostream>

using namespace std;

unsigned long long P(int x) {
    if (x == 1)
        return 1;
    return 2 * P(x - 1) + 1;
}

void H(int n, int a, int b) {
    if (n > 0) {
        H(n - 1, a, 6 - a - b);
        cout << "Переместить диск " << n << " c " << a << " на " << b << endl;
        H(n - 1, 6 - a - b, b);
    }
}

int main() {
    setlocale(LC_ALL, "Rus");

    int n, i, k;
    cin >> n >> i >> k;

    H(n, i, k);
    cout << P(n); /// / 60 / 60 / 24 / 366;
    return 0;
}
