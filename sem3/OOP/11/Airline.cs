namespace Lab11;

public class Airline
{
    public string? Engine { get; set; }
    public int Fuel { get; set; }


    public Airline()
    {
        
    }
    public Airline(string videoCard, string processor, int amountOfRam, int amountOfStorage)
    {
        Engine = videoCard;
        Fuel = amountOfRam;
    }

    public void IsWorking()
    {
        Console.WriteLine("Airline is working.\n");
    }

    public void AddingRam(int amount)
    {
        Console.WriteLine("Adding " + amount + "GB of RAN to your system.\n");
        Fuel += amount;
    }

    public void AddingStorage(int amountOfStorage)
    {
        Console.WriteLine("Adding " + amountOfStorage + "GB of SSD to your system.\n");
    }

    public void Fly(List<string> nameOfVideoCard)
    {
        foreach (var name in nameOfVideoCard)
        {
            Console.WriteLine($"Вы летите на {name}");
        }
    }
}