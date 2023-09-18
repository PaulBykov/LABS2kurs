#include "out.hpp"

using namespace std;

namespace out {
	void infoToConsole(In::IN &in) {
		cout << in.text << endl;
		cout << "Symbols count: " << in.size << endl;
		cout << "Line count: " << in.lines << endl;
		cout << "Ignored: " << in.ignore << endl;
	}


	void infoToFile(In::IN& in, wchar_t fileName[]) {
		fstream file(fileName, fstream::out);

		if (!file.is_open())
		{
			throw ERROR_THROW(110);
		}


		file << in.text << "\n";
		file << "Symbols count: " << in.size << "\n";
		file << "Line count: " << in.lines << "\n";
		file << "Ignored: " << in.ignore << "\n";

		file.close();
	}

	void errorInformationToConsole(Error::ERROR e) {
		cout << "ID: " << e.id << " Message: " << e.message << " Line: " << e.inext.line << " Position:" << e.inext.col << endl;
	}


	void errorInformationToFile(Error::ERROR e, wchar_t fileName[]) {
		fstream file(fileName, fstream::out);

		if (!file.is_open())
		{
			throw ERROR_THROW(110);
		}

		file << "ID: " << e.id << " Message: " << e.message << " Line: " << e.inext.line << " Position:" << e.inext.col << endl;
	}


	void paramToConsole(Parm::PARM parm) {
		wcout << "-in:" << parm.in << ", -out:" << parm.out << ", -log:" << parm.log << endl << endl;
	}
}