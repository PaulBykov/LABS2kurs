#pragma once
#define IN_MAX_LEN_TEXT 1024*1024 // макс размер исходного кода
#define IN_CODE_ENDL '|'

// таблица проверки входной информации, индекс = код (Windows-1251) символа
// значения IN::F - запрещенный символ, IN::T = разрешенный символ, IN::I - игнорировать (не вводить),
// если 0 <= значение < 256 - то вводится данное значение

#define MAX_LEN_LINE 1000

namespace In
{
	void dell_in(char* str, int index);
	struct IN
	{
		enum
		{
			T = 1024, // допустимый символ
			F = 2048, // недопустимый
			I = 4096 // игнорировать, иначе изменить
		};

		int size,
			lines,
			ignore;

		unsigned char* text; // исходный код;

		int code[256]; // таблица проверки
		

		IN()
		{
			this->size = 0;

			int code[256] =
			{
			// 1       2      3      4      5      6      7      8      9     10 
			  IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 0
			  IN::F, IN::F, IN::I, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 10
			  IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 20
			  IN::F, IN::T, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 30
			  IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 40
			  IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 50
			  IN::F, IN::F, IN::F, IN::F, IN::T, IN::T, IN::F, IN::F, IN::F, IN::F, // 60
			  IN::F, IN::F, IN::F, IN::F, IN::T, IN::T, IN::F, IN::F, IN::T, IN::T, // 70
			  IN::F, IN::F, IN::F, IN::F, IN::T, IN::T, IN::F, IN::I, IN::F, IN::T, // 80
			  IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 90
			  IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 100
			  IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 110
			  IN::F, IN::F, IN::F, IN::T, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 120
			  IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 130
			  IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 140
			  IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 150
			  IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 160
			  IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 170
			  IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 180
			  IN::F, IN::F, IN::T, IN::T, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 190
			  IN::F, IN::T, IN::F, IN::F, IN::F, IN::T, IN::F, IN::F, IN::F, IN::F, // 200
			  IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::T, // 210
			  IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 220
			  IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 230
			  IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, // 240
			  IN::F, IN::F, IN::F, IN::F, IN::F, IN::F                              // 250
			};

		}
	};

	IN getin(wchar_t infile[]);
}