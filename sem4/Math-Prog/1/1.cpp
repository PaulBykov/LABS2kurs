#include "main.hpp"


const int TEST_LEN = 20000;

using namespace std;

void start() {
    srand(time(NULL));
}

// Дробное от l до r (включительно)
double dget(double l, double r) {
    return (double)(rand()) / RAND_MAX * (r - l) + l;
}

// Целое от l до r (включительно)
int iget(int l, int r) {
    return l + rand() % (r - l + 1);
}


unsigned long long fact(int n) {
    if (n == 0 || n == 1) {
        return 1;
    }
    else {
        unsigned long long result = 1;
        for (int i = 2; i <= n; ++i) {
            result *= i;
        }
        return result;
    }
}


int main()
{
    setlocale(LC_ALL, "Rus");
    start();
    double sum1 = 0, sum2 = 0;

    double startTime = clock();

    for (int i = 0; i < TEST_LEN; ++i) {
        sum1 += dget(-100, 100);
    }


    for (int i = 0; i < TEST_LEN; ++i) {
        sum2 += iget(-100, 100);
    }

    double endTime = clock();

    cout << "Количетсво циклов: " << TEST_LEN << endl;
    cout << "AVG int          : " << sum1 / TEST_LEN << endl;
    cout << "AVG double       : " << sum2 / TEST_LEN << endl;
    cout << "Потраченое время : " << (endTime - startTime) << endl;
    cout << "Потраченые секун : " << (double)(endTime - startTime) / CLOCKS_PER_SEC << endl;

    cout << "-----------------------------------------------------------------\n";

    auto t1 = std::chrono::high_resolution_clock::now();
    for (int j = 0; j < TEST_LEN; j++) {
        fact(j);    
    }
    auto t2 = std::chrono::high_resolution_clock::now();
    chrono::duration<double> elapsed = t2 - t1;
    cout << "t2-t1: " << elapsed.count() << endl;



    return 0;
}
