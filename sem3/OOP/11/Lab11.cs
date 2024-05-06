
namespace Lab11;

public static class Lab11
{
    public static void Main()
    {
        Reflector.GetNameOfTheAssembly("Lab11.Airline");
        Reflector.WriteAllFieldsAndProperties("Lab11.Airline");
        Reflector.WriteAllInterfaces("Lab11.Airline");
        Reflector.WriteAllClassMethodsWithParameter("Lab11.Airline", "amount");
        Reflector.Invoke("Lab11.Airline", "Fly");


        Reflector.GetNameOfTheAssembly("System.String");
        Reflector.IsTherePublicConstructor("System.String");
        Reflector.WritePublicMethods("System.String");

        // 2 zadanie
        var belavia = Reflector.Create("Lab11.Airline");
        
        if (belavia is Airline)
        {
            Console.WriteLine("\nЭто объект типа Airline");
            return;
        }
        
        Console.WriteLine("\nЭтот объект не типа Airline");
        
    }
}