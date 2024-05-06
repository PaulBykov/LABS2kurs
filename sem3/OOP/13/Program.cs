using _13;
using _4;
using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

public class Program
{

    private static void Task1() {
        CustomSerializer serializer = new CustomSerializer();


        Cirle myObject = new Cirle(10, 5, 5);

        // Сериализация объекта в различные форматы
        string binaryData = serializer.SerializeToBinary(myObject);
        string jsonData = serializer.SerializeToJSON(myObject);
        string xmlData = serializer.SerializeToXML(myObject);

        string filePath = "xmlData.xml";
        File.WriteAllText(filePath, xmlData);

        Console.WriteLine("Serialized Data:");
        Console.WriteLine("Binary: " + binaryData);
        Console.WriteLine("JSON: " + jsonData);
        Console.WriteLine("XML: " + xmlData);
        Console.WriteLine();

        // Десериализация данных обратно в объекты
        Cirle deserializedFromBinary = serializer.DeserializeFromBinary<Cirle>(binaryData);
        Cirle deserializedFromJSON = serializer.DeserializeFromJSON<Cirle>(jsonData);
        Cirle deserializedFromXML = serializer.DeserializeFromXML<Cirle>(xmlData);

        Console.WriteLine("Deserialized Objects:");
        Console.WriteLine("From Binary: Radious: " + deserializedFromBinary.Radious + "\t x: " + deserializedFromBinary.X + "\t y: " + deserializedFromBinary.Y);
        Console.WriteLine("From JSON: Radious: " + deserializedFromJSON.Radious + "\t x: " + deserializedFromJSON.X + "\t y: " + deserializedFromJSON.Y);
        Console.WriteLine("From XML: Radious: " + deserializedFromXML.Radious + "\t x: " + deserializedFromXML.X + "\t y: " + deserializedFromXML.Y);

    }

    private static void Task2() {
        List<Cirle> objectList = new List<Cirle>
        {
            new Cirle { X = 1, Y = 5, Radious=3 },
            new Cirle { X = 9, Y = 15, Radious = 11 },
            new Cirle { X = 3, Y = 7, Radious = 1}
        };

        // Путь к файлу, в который мы будем сохранять данные
        string filePath = "objects.json";

        // Сериализация коллекции в JSON и запись в файл
        string jsonData = JsonSerializer.Serialize(objectList);
        File.WriteAllText(filePath, jsonData);

        Console.WriteLine("Data has been saved to file.");

        // Чтение данных из файла и десериализация обратно в коллекцию
        string jsonFromFile = File.ReadAllText(filePath);
        List<Cirle> deserializedList = JsonSerializer.Deserialize<List<Cirle>>(jsonFromFile);

        Console.WriteLine("\nDeserialized Objects:");
        foreach (var obj in deserializedList)
        {
            Console.WriteLine("Radious: " + obj.Radious + "\t x:" + obj.X + "\t y: " + obj.Y);
        }
    }

    private static void Task3() {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("xmlData.xml");

        // Создание XPathNavigator из XmlDocument
        XPathNavigator navigator = xmlDoc.CreateNavigator();

        // Выполнение запроса XPath для task3
        XPathNodeIterator nodes = navigator.Select("//Cirle/X");
        Console.WriteLine("Task 3 Result:");
        while (nodes.MoveNext())
        {
            Console.WriteLine(nodes.Current.Value);
        }


        nodes = navigator.Select("//Cirle/Y");

        while (nodes.MoveNext())
        {
            Console.WriteLine(nodes.Current.Value);
        }
    }

    private static void CreateXmlDocument()
    {
        XDocument xmlDocument = new XDocument(
            new XElement("shapes",
                new XElement("circle",
                    new XElement("radius", 5)
                ),
                new XElement("square",
                    new XElement("side", 10)
                ),
                new XElement("triangle",
                    new XElement("base", 6),
                    new XElement("height", 8)
                )
            )
        );

        xmlDocument.Save("shapes.xml");
        Console.WriteLine("New XML document describing shapes created.");
    }

    private static void QueryXmlDocument()
    {
        XDocument xmlDoc = XDocument.Load("shapes.xml");

        // Запросы LINQ to XML для данных из нового XML-документа
        var circles = xmlDoc.Descendants("circle")
                            .Select(c => new
        {
            Shape = "Circle",
            Radius = (int)c.Element("radius")
        });

        var squares = xmlDoc.Descendants("square").Select(s => new
        {
            Shape = "Square",
            Side = (int)s.Element("side")
        });

        var triangles = xmlDoc.Descendants("triangle")
                              .Select(t => new
        {
            Shape = "Triangle",
            Base = (int) t.Element("base"),
            Height = (int) t.Element("height")
        });

        Console.WriteLine("\nQuery Results:");
        Console.WriteLine("Circles:");
        foreach (var circle in circles)
        {
            Console.WriteLine($"{circle.Shape}, Radius: {circle.Radius}");
        }

        Console.WriteLine("\nSquares:");
        foreach (var square in squares)
        {
            Console.WriteLine($"{square.Shape}, Side: {square.Side}");
        }

        Console.WriteLine("\nTriangles:");
        foreach (var triangle in triangles)
        {
            Console.WriteLine($"{triangle.Shape}, Base: {triangle.Base}, Height: {triangle.Height}");
        }
    }
    private static void Task4()
    {
        CreateXmlDocument();
        QueryXmlDocument();

    }
    public static void Main(string[] args)
    {
        Task1();

    }
}
