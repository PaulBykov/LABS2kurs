#pragma once
#include "D:/help/feat.hpp"


namespace Error {
	struct Error : exception {
		unsigned short code;
		string message;

		map<int, string> ErrorCodes = {
		{1, "Недопустимое значение октета"},
		{2, "Неизвестный символ"},
		{3, "Неверное количество октетов"},
		{4, "Недопустимая маска"}

		};

		Error(unsigned short code) {
			this->code = code;
			this->message = ErrorCodes[code];
		}
	};

}

