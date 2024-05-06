#include "Set.hpp";

namespace SET 
{
	Set::Set(int n, vector<int> a) {
		this->len = n;
		value.resize(this->len);
		this->value = a;
	};	

	vector<SubSet> Set::generateAllSubSets() {
		int n = this->Lenght();

		if (n < 1) { throw exception("Множество пусто"); };

		vector<SubSet> ans(pow(2, n), SubSet(n));
		vector<int> lastItem(n);

		short currentNumber = 1;
		char buff[33];

		for (int i = 0; i < n; i++, currentNumber++) {
			string mask = _itoa(currentNumber, buff, 2);
			ans.push_back(SubSet(mask, *this));
		}

		return ans;
	}

	SubSet::SubSet(string mask, SET::Set set) {
		int n = set.Lenght();

		value.resize(n, 0);

		for (int i = mask.size() - 1; i > -1; i--) {
			if (mask[i] != '1') {
				continue;
			}

			this->value[i] = set.value[i];
		}
	}
}