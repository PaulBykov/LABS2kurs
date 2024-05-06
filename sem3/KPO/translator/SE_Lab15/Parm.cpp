#include "stdafx.h"
#include "Parm.h"
#include "Error.h"


namespace Parm
{
	//Параметры: argc – количество параметров(int, >= 1),
	//argv – массив указателей на нуль - терминальные строки со
	//значениями параметров, (_TCHAR* – указатель на строку wchar_t)

	PARM getparm(int argc, wchar_t* argv[])
	{
		PARM parm;

		// boolean - переменные для поиска -in, -out, -log
		bool in_find = 0, out_find = 0, log_find = 0;

		Parameters parameters[] = {
			   {PARM_IN, parm.in, &in_find},
			   {PARM_OUT, parm.out, &out_find},
			   {PARM_LOG, parm.log, &log_find}
		};


		for (int i = 1; i < argc; i++)
		{ // wcslen - вовзращает длину строки
			if (wcslen(argv[i]) > PARM_MAX_SIZE) { 
				throw ERROR_THROW(104);
			}

			for (const Parameters& param : parameters) {
				if (wcsstr(argv[i], param.name)) {
					wcscpy(param.target, argv[i] + wcslen(param.name));
					*(param.found) = 1;
				}
			}
		}

		// если не нашли -in
		if (!in_find) throw ERROR_THROW(100);

		// -out
		if (!out_find)
		{
			wcscpy_s(parm.out, parm.in);
			wcscat_s(parm.out, PARM_OUT_DEFAULT_EXT);
		}

		// -log
		if (!log_find)
		{
			wcscpy_s(parm.log, parm.in);
			wcscat_s(parm.log, PARM_LOG_DEFAULT_EXT);
		}
		return parm;
	}
}