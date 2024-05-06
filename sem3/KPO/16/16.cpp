
#include "FST.h"


#define FST_CHRLIT 4,	\
	FST::NODE(1, FST::RELATION('\'', 1)),\
	FST::NODE(78, \
		FST::RELATION('A', 2), FST::RELATION('B', 2), FST::RELATION('C', 2), FST::RELATION('D', 2),\
		FST::RELATION('E', 2), FST::RELATION('F', 2), FST::RELATION('G', 2), FST::RELATION('H', 2),\
		FST::RELATION('I', 2), FST::RELATION('J', 2), FST::RELATION('K', 2), FST::RELATION('L', 2),\
		FST::RELATION('M', 2), FST::RELATION('N', 2), FST::RELATION('O', 2), FST::RELATION('P', 2),\
		FST::RELATION('Q', 2), FST::RELATION('R', 2), FST::RELATION('S', 2), FST::RELATION('T', 2),\
		FST::RELATION('U', 2), FST::RELATION('V', 2), FST::RELATION('W', 2), FST::RELATION('X', 2),\
		FST::RELATION('Y', 2), FST::RELATION('Z', 2),\
		FST::RELATION('a', 2), FST::RELATION('b', 2), FST::RELATION('c', 2), FST::RELATION('d', 2),\
		FST::RELATION('e', 2), FST::RELATION('f', 2), FST::RELATION('g', 2), FST::RELATION('h', 2),\
		FST::RELATION('i', 2), FST::RELATION('j', 2), FST::RELATION('k', 2), FST::RELATION('l', 2),\
		FST::RELATION('m', 2), FST::RELATION('n', 2), FST::RELATION('o', 2), FST::RELATION('p', 2),\
		FST::RELATION('q', 2), FST::RELATION('r', 2), FST::RELATION('s', 2), FST::RELATION('t', 2),\
		FST::RELATION('u', 2), FST::RELATION('v', 2), FST::RELATION('w', 2), FST::RELATION('x', 2),\
		FST::RELATION('y', 2), FST::RELATION('z', 2),\
		FST::RELATION('0', 2), FST::RELATION('1', 2), FST::RELATION('2', 2), FST::RELATION('3', 2),\
		FST::RELATION('4', 2), FST::RELATION('5', 2), FST::RELATION('6', 2), FST::RELATION('7', 2),\
		FST::RELATION('8', 2), FST::RELATION('9', 2),\
		FST::RELATION(' ', 2), FST::RELATION(',', 2), FST::RELATION('.', 2), FST::RELATION(';', 2),\
		FST::RELATION('=', 2), FST::RELATION(':', 2), FST::RELATION(')', 2), FST::RELATION('(', 2),\
		FST::RELATION('!', 2), FST::RELATION('?', 2), FST::RELATION('/', 2),FST::RELATION('~', 2),\
		FST::RELATION('<', 2),FST::RELATION('>', 2),FST::RELATION('+', 2),FST::RELATION('-', 2)),\
	FST::NODE(1, FST::RELATION('\'', 3)),\
	FST::NODE()


int _tmain(int argc, TCHAR* argv[])
{
	setlocale(LC_ALL, "rus");

	char str1[] = "'f'";
	char str2[] = "'a'";
	char str3[] = "'b'";
	char str4[] = "''";
	char str5[] = "' '";
	char str6[] = "a";
	char str7[] = "'2'";
	char str8[] = "'d'";
	char str9[] = "'1'";

	char* chains[] = { str1, str2, str3, str4, str5, str6, str7, str8, str9 };

	for (int i = 0; i < sizeof(chains) / sizeof(char*); i++)
	{
		FST::FST fst1(chains[i], FST_CHRLIT);


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