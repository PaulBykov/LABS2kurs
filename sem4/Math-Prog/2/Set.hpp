#include "D:/help/feat.hpp"

namespace SET {
	class SubSet;

	class Set {
	private:
		short len;

	public:
		vector<int> value;

		Set(int n, vector<int> a = vector<int>());

		short Lenght() { return this->len; }

		vector<SubSet> generateAllSubSets();
	};

	class SubSet {
	public:
		vector<int> value;

		SubSet() {};
		~SubSet() {};

		SubSet(int n) { value.resize(n); }

		SubSet(string mask, SET::Set set);
	};

}