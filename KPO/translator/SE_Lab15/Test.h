#pragma once

#include "stdafx.h"
#include <iostream>
#include <cwchar>
#include <time.h>

#include "Error.h"		//обработка ошибок
#include "Parm.h"		//обработка параметров
#include "Log.h"		//работа с протоколом
#include "In.h"			//ввод исходного файла
#include "out.hpp"      //вывод в файл/консоль

namespace test {
	void test1(int argc, _TCHAR* argv[]);
	void test2(int argc, _TCHAR* argv[]);
	void initLog(int argc, _TCHAR* argv[]);
};