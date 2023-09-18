#pragma once

#define ERROR_THROW(id) Error::geterror(id); // throw ERROR_THROW(id)
#define ERROR_THROW_IN(id, l, c) Error::geterrorin(id, l, c); // throw ERROR_THROW_IN

#define ERROR_ENTRY(id, m) {id, m, {-1, -1}} // error table entry
#define ERROR_MAXSIZE_MESSAGE 200 // maximum error message length
#define ERROR_MAX_ENTRY 1000

#define ERROR_ENTRY_NODEF(id) ERROR_ENTRY(-id, "Undefined error") // 1 undefined error table entry


// ERROR_ENTRY_NODEF10(id) - 10 undefined error table entries
#define ERROR_ENTRY_NODEF10(id) ERROR_ENTRY_NODEF(id+0), ERROR_ENTRY_NODEF(id+1), ERROR_ENTRY_NODEF(id+2), ERROR_ENTRY_NODEF(id+3), \
                                ERROR_ENTRY_NODEF(id+4), ERROR_ENTRY_NODEF(id+5), ERROR_ENTRY_NODEF(id+6), ERROR_ENTRY_NODEF(id+7), \
                                ERROR_ENTRY_NODEF(id+8), ERROR_ENTRY_NODEF(id+9)

// ERROR_ENTRY_NODEF100(id) - 100 undefined error table entries
#define ERROR_ENTRY_NODEF100(id) ERROR_ENTRY_NODEF(id+0), ERROR_ENTRY_NODEF(id+10), ERROR_ENTRY_NODEF(id+20), ERROR_ENTRY_NODEF(id+30), \
                                ERROR_ENTRY_NODEF(id+40), ERROR_ENTRY_NODEF(id+50), ERROR_ENTRY_NODEF(id+60), ERROR_ENTRY_NODEF(id+70), \
                                ERROR_ENTRY_NODEF(id+80), ERROR_ENTRY_NODEF(id+90)


namespace Error
{
	struct ERROR // exception type for throw ERROR_THROW | ERROR_THROW_IN
	{
		int id;
		char message[ERROR_MAXSIZE_MESSAGE];
		struct IN // extensions for errors when processing input data
		{
			short line;
			short col; // position in the line (0, 1, 2, ...)
		} inext;
	};
	ERROR geterror(int id); // form ERROR for ERROR_THROW
	ERROR geterrorin(int id, int line, int col); // form ERROR for ERROR_THROW_IN
};
