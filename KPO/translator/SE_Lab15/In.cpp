#include "stdafx.h"
#include "In.h"
#include "Error.h"

#define symbolIndex int((unsigned char)str[i])

namespace In
{
	IN getin(wchar_t infile[])
	{
		int lines = 0;
		int cols = 0;
		int ignors = 0;
		int iter = 0;

		char* str = new char[MAX_LEN_LINE];
		unsigned char* code = new unsigned char[IN_MAX_LEN_TEXT];

		IN in;

		std::fstream file(infile, std::fstream::in);

		// ���� ���������� ������� ����
		if (!file.is_open())
		{
			throw ERROR_THROW(110);
		}
		while (!file.eof())
		{
			lines++;
			// ��������� ������ � �����
			file.getline(str, MAX_LEN_LINE, IN_CODE_ENDL);
			for (int i = 0; i < strlen(str); i++)
			{
				cols++;
				in.size++;

				// ���� ����� ����������� ������
				if (in.code[symbolIndex] == IN::F)
				{
					throw ERROR_THROW_IN(111, lines, cols);
				}

				// ���� ����� ������, ������� ����������
				if (in.code[symbolIndex] == IN::I)
				{
					ignors++;
					dell_in(str, i);
					continue;
				}
				
				if (in.code[symbolIndex] != IN::T)
				{
					str[i] = in.code[symbolIndex];
				}
			}

			str[strlen(str) + 1] = '\0';
			str[strlen(str)] = '\n';

			for (int i = 0; i < strlen(str); i++)
			{
				code[iter++] = (unsigned char)str[i];
			}

			cols = 0;
		}
		code[iter] = '\0';
		in.ignore = ignors;
		in.lines = lines;
		in.text = code;
		file.close();
		delete[] str;
		return in;
	}

	void dell_in(char* str, int index)
	{
		for (int i = index; i < strlen(str); i++)
		{
			str[i] = str[i + 1];
		}
	}
}