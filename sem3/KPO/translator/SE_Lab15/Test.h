#pragma once

#include "stdafx.h"
#include <iostream>
#include <cwchar>
#include <time.h>

#include "Error.h"		//��������� ������
#include "Parm.h"		//��������� ����������
#include "Log.h"		//������ � ����������
#include "In.h"			//���� ��������� �����
#include "out.hpp"      //����� � ����/�������

namespace test {
	void test1(int argc, _TCHAR* argv[]);
	void test2(int argc, _TCHAR* argv[]);
	void initLog(int argc, _TCHAR* argv[]);
};