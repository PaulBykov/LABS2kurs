#include "D:/help/feat.hpp"

vector<int> a;
vector<int> b;
vector<int> c;


int searchLeft(int from) {
	int Elem = a[from];
	int ResultIndex = -1;
	int prevLen = -1;

	for (int i = from - 1; i >= 0; i--) {
		if (a[i] < Elem && prevLen < b[i]) {
			ResultIndex = i;
			prevLen = b[i];
		}
	}

	return ResultIndex;
}

int MaxOnLeft(int from) {
	int Max = b[from];
	int MaxInd = from;

	for (int i = from - 1; i >= 0; i--) {
		if (b[i] > Max) {
			Max = b[i];
			MaxInd = i;
		}
	}

	return MaxInd;
}


int main()
{
	int n;
	cin >> n;

	a.resize(n);
	b.resize(n, 0);


	for (int i = 0; i < n; i++) {
		cin >> a[i];
	}

	for (int i = 0; i < n; i++) {
		int prevMaxInd = searchLeft(i);
		if (prevMaxInd == -1) {
			b[i] = 0;
		}
		else {			
			b[i] = b[prevMaxInd] + 1;
		}
		c.push_back(prevMaxInd);
	}

	int LastElem = b[MaxOnLeft(n - 1)];
	int LastElemInd = MaxOnLeft(n - 1);

	cout << LastElem + 1 << endl;

	vector<int> ans;

	ans.push_back(a[LastElemInd]);
	for (int i = 0; i < c.size(); i++) {
		ans.push_back(a[c[LastElemInd]]);
		LastElemInd = c[LastElemInd];
		if (c[LastElemInd] == -1) {
			break;
		}
	}

	reverse(ans.begin(), ans.end());
	printVector(ans);
}

/*
	8
	5 10 6 12 3 24 7 8
*/