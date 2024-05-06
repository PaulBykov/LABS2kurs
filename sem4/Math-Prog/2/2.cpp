#include "Set.hpp"


int main()
{
	RU;
	includeFastIO();


	try {
		auto vec = vector<int>{0, 1, 2, 3};
		auto set = new SET::Set(4, vec);
		
		auto subs = set->generateAllSubSets();
		for (auto iter : subs) {
			printVector(iter.value);
		}
	}
	catch (exception err) {
		cout << err.what() << "\n";
	}
}
