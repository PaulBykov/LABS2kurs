#include "D:/help/feat.hpp"
#include "Error.hpp"

typedef unsigned long address;

inline bool isDigit(char symbol) {
    return '0' <= symbol <= '9';
}

vector<address> getAddressByString(string ip) {
    vector<address> IP(4);
    char separator = '.';

    string octet;
    int octetNum = 0;

        for (int i = 0; i < ip.size(); i++) {
            if (ip[i] != separator) {
                if (!isDigit(ip[i])) {
                    throw Error::Error(4);
                }

                octet += ip[i];
            }
            else {
                IP[octetNum] = stoi(octet);

                octet = "";
                octetNum++;
            }
        }
        IP[octetNum] = stoi(octet);

        return IP;
    
}

void lookForErrors(vector<address> stuff) {
        for (auto oct : stuff) {
            if (oct > 255 || oct < 0) {
                 throw Error::Error(3);
            }
        }
}


void checkForOctCount(string str) {
    int count = 0;
    for (auto s : str) {
        if (s == '.') {
            count++;
        }
    }
    if (count > 3) {
            throw Error::Error(3);
  }
}

address calculateBroadcast(address networkID, address subnetMask) {
    return networkID | (1);
}

void checkMask(address maskOct) {
    if ((maskOct & (~maskOct)) != 0) {
        throw Error::Error(4);
    }
}

int main()
{
    setlocale(LC_ALL, "Rus");

    string ip;
    string mask;

    cout << "Введите IP: " << endl;
    cin >> ip;

    cout << "Введите маску: " << endl;
    cin >> mask;

    string NID = "";
    string HID = "";
    string broadcast = ""; 

    try {
        checkForOctCount(ip);
        checkForOctCount(mask);

        auto ipOct = getAddressByString(ip);
        auto maskOct = getAddressByString(mask);
        
        lookForErrors(ipOct);
        lookForErrors(maskOct);
        

        string ans;
        for (int i = 0; i < ipOct.size(); i++) {
            if (i != ipOct.size() - 1) {
                ans = to_string(ipOct[i] & maskOct[i]) + ".";
            }
            else {
                ans = to_string(ipOct[i] & maskOct[i]);
            }

            NID += ans;
        }

        for (int i = 0; i < ipOct.size(); i++) {
            if (i != ipOct.size() - 1) {
                ans = to_string(ipOct[i] & ~maskOct[i]) + ".";
            }
            else {
                ans = to_string(ipOct[i] & ~maskOct[i]);
            }

            HID += ans;
        }

        cout << "NetworkID = " << NID << "\nHostID = " << HID << "\n";

        cout << "broadcast = ";
        for (int i = 0; i < 4; i++) {
            cout << calculateBroadcast(getAddressByString(NID)[i], maskOct[i]) << " ";
        }
    }
    catch (Error::Error e) {
        cout << "Ошибка! " << e.message << "\n";
    }

    return 0;
}
