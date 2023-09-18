
#include "FST.h"

int _tmain(int argc, TCHAR* argv[])
{
	setlocale(LC_ALL, "rus");

	char str1[] = "abcdebf";
	char str2[] = "abcbf";
	char str3[] = "abcbbef";
	char str4[] = "abbcbef";
	char str5[] = "abbdbef";
	char str6[] = "abcbbef";
	char str7[] = "abef";
	char str8[] = "aaaaa";
	char str9[] = "ababababdacedf";

	char* chains[] = { str1, str2, str3, str4, str5, str6, str7, str8, str9 };

	for (int i = 0; i < sizeof(chains) / sizeof(char*); i++)
	{
		FST::FST fst1(chains[i], 4,
			FST::NODE(1, FST::RELATION('a', 1)),
			FST::NODE(1, FST::RELATION('b', 2)),
			FST::NODE(5, FST::RELATION('c', 2), FST::RELATION('d', 2), FST::RELATION('e', 2), FST::RELATION('b', 2), FST::RELATION('f', 3)),
			FST::NODE()
		);


		if (FST::execute(fst1))
		{
			std::cout << fst1.string << " - успех!" << std::endl;
		}
		else
		{
			std::cout << fst1.string << " - НЕ успех!" << std::endl;
		}
	};

	system("pause");
	return 0;
}