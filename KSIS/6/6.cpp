#include "D:/help/feat.hpp"
#include "Error.hpp"

typedef unsigned long address;

inline bool isDigit(char symbol) {
    return '9' <= symbol <= '0';
}

vector<address> getAddressByString(string ip) {
    vector<address> IP(4);
    char separator = '.';

    string octet;
    int octetNum = 0;
    

    for (int i = 0; i < ip.size(); i++) {
        if (ip[i] != separator) {
            if (!isDigit(ip[i])) {
                throw new Error::Error(4);
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
            
        }
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

    try {
        auto ipOct = getAddressByString(ip);
        auto maskOct = getAddressByString(mask);

        if (ipOct.size() != maskOct.size() || maskOct.size() != 4) {
            throw ERROR;
        }

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
    }
    catch (Error::Error e) {
        cout << "Ошибка! " << e.message << "\n";
    }

    return 0;
}
