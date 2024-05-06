#include <iostream>
#include <fstream>
#include <vector>

struct SerializedData {
    bool boolData;
    int16_t int16Data;
};

int main() {
    setlocale(LC_ALL, "Rus");

    std::ifstream inFile("../asm4/serialized_data.bin", std::ios::in | std::ios::binary);
    if (inFile.is_open()) {
        inFile.seekg(0, std::ios::end);
        std::streampos fileSize = inFile.tellg();
        inFile.seekg(0, std::ios::beg);

        std::vector<unsigned char> fileBuffer(fileSize);
        inFile.read(reinterpret_cast<char*>(fileBuffer.data()), fileSize);
        inFile.close();


        SerializedData deserializedData;
        if (fileBuffer.size() >= sizeof(SerializedData)) {
            std::memcpy(&deserializedData, fileBuffer.data(), sizeof(SerializedData));


            std::ofstream asmFile("deserialized_data.asm", std::ios::out);
            if (asmFile.is_open()) {
                asmFile << "    deserialized_data PROC:\n";
                asmFile << "        db " << deserializedData.boolData << "\n";
                asmFile << "        dw " << deserializedData.int16Data << "\n";
                asmFile << "    deserialized_data ENDP" << "\n";
                asmFile.close();
                std::cout << "Исходный код на языке ассемблера успешно создан в файле 'deserialized_data.asm'\n";
            }
            else {
                std::cerr << "Невозможно открыть файл для записи ассемблерного кода\n";
            }
        }
        else {
            std::cerr << "Файл не содержит достаточно данных для десериализации\n";
        }
    }
    else {
        std::cerr << "Невозможно открыть файл для чтения сериализованных данных\n";
    }

    return 0;
}
