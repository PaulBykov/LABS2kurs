#include "Test.h"


using namespace std;

namespace test {
	
	void test1(int argc, _TCHAR* argv[]){
		cout << "\n \t ------- test1 (getparm) -------" << endl;

		try
		{
			Parm::PARM parm = Parm::getparm(argc, argv);
			out::paramToConsole(parm);
		}
		catch (Error::ERROR e)
		{
			out::errorInformationToConsole(e);
		}
	}


	void test2(int argc, _TCHAR* argv[]) {
		cout << "\n \t ------- test2 (getin) -------" << endl;

		try
		{
			Parm::PARM parm = Parm::getparm(argc, argv);
			In::IN in = In::getin(parm.in);

			out::infoToConsole(in);
			out::infoToFile(in, parm.out);
		}
		catch (Error::ERROR e)
		{
			Parm::PARM parm = Parm::getparm(argc, argv);
			out::errorInformationToConsole(e);
			out::errorInformationToFile(e, parm.out);
		}

	}


	void initLog(int argc, _TCHAR* argv[]) {
		Log::LOG log = Log::INITLOG;

		cout << "\n \t ------- test3 (initLog) -------" << endl;

		try
		{
			Parm::PARM parm = Parm::getparm(argc, argv);
			log = Log::getlog(parm.log);
			Log::WriteLine(log, (char*)"Test", (char*)" accepted! \n", "");
			Log::WriteLine(log, (wchar_t*)L"Test", (wchar_t*)L" accepted! \n", L"");
			Log::WriteLog(log);
			Log::WriteParm(log, parm);
			In::IN in = In::getin(parm.in);
			Log::WriteIn(log, in);
			Log::Close(log);
		}
		catch (Error::ERROR e)
		{
			Log::WriteError(log, e);
		};
	}

}