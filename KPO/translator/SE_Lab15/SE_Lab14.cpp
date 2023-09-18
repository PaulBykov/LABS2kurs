#include "stdafx.h"
#include <iostream>
#include <cwchar>
#include <time.h>


#include "Error.h"		//обработка ошибок
#include "Parm.h"		//обработка параметров
#include "Log.h"		//работа с протоколом
#include "In.h"			//ввод исходного файла

#include "Test.h"		// тестирование кода

#define TEST1 true
#define TEST2 true
#define TEST3 true



using namespace std;


int _tmain(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL, "russian");


#ifdef TEST1
	test::test1(argc, argv);
#endif // TEST1


#ifdef TEST2
	test::test2(argc, argv);
#endif // TEST1


#ifdef TEST3
	test::initLog(argc, argv);
#endif // TEST1



	system("pause");

	return 0;
}
