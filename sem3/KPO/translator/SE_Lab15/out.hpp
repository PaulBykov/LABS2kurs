#include "iostream"
#include "fstream"

#include "Parm.h"
#include "Error.h"
#include "In.h"


namespace out {
	void infoToConsole(In::IN& in);
	void infoToFile(In::IN& in, wchar_t fileName[]);
	void errorInformationToConsole(Error::ERROR e);
	void errorInformationToFile(Error::ERROR e, wchar_t fileName[]);
	void paramToConsole(Parm::PARM parm);
}