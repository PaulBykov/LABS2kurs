using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace _13
{
    public class CustomSerializer
    {
        // Метод для сериализации объекта в бинарный формат
        public string SerializeToBinary(object obj)
        {
            byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(obj);
            return Convert.ToBase64String(bytes);
        }

        // Метод для десериализации бинарных данных в объект
        public T DeserializeFromBinary<T>(string data)
        {
            byte[] bytes = Convert.FromBase64String(data);
            return JsonSerializer.Deserialize<T>(bytes);
        }

        // Метод для сериализации объекта в формат JSON
        public string SerializeToJSON(object obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        // Метод для десериализации данных в формате JSON в объект
        public T DeserializeFromJSON<T>(string data)
        {
            return JsonSerializer.Deserialize<T>(data);
        }

        // Метод для сериализации объекта в формат XML
        public string SerializeToXML(object obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
            using (StringWriter stringWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter))
                {
                    xmlSerializer.Serialize(xmlWriter, obj);
                    return stringWriter.ToString();
                }
            }
        }

        // Метод для десериализации данных в формате XML в объект
        public T DeserializeFromXML<T>(string data)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringReader stringReader = new StringReader(data))
            {
                return (T)xmlSerializer.Deserialize(stringReader);
            }
        }
    }

}
