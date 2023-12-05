#include <iostream>
#include <fstream>
#include <vector>


struct SerializedData {
    bool boolData;
    int16_t int16Data;

};

int main() {
    setlocale(LC_ALL, "Rus");

    SerializedData dataToSerialize = { true, 1234 }; // Пример данных для сериализации

    // План памяти с мета-информацией - представление данных в виде байтового потока
    std::vector<unsigned char> serializedBytes(
        reinterpret_cast<unsigned char*>(&dataToSerialize),
        reinterpret_cast<unsigned char*>(&dataToSerialize + 1)
    );

    std::ofstream outFile("serialized_data.bin", std::ios::out | std::ios::binary);
    if (outFile.is_open()) {
        outFile.write(reinterpret_cast<const char*>(serializedBytes.data()), serializedBytes.size());
        outFile.close();
        std::cout << "Данные успешно сериализованы в файл 'serialized_data.bin'\n";
    }
    else {
        std::cerr << "Невозможно открыть файл для записи\n";
    }

    return 0;
}
