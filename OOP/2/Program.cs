


namespace _2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Airline[] airlines = new Airline[]
            {
                new Airline("New York", 1, "Boeing 737", "08:00", new string[] { "Monday", "Wednesday", "Friday" }),
                new Airline("Paris", 2, "Airbus A320", "14:30", new string[] { "Tuesday", "Thursday" }),
                new Airline("London", 3, "Boeing 777", "10:45", new string[] { "Monday", "Wednesday", "Saturday" }),
                new Airline("Tokyo", 4, "Airbus A350", "16:15", new string[] { "Tuesday", "Friday", "Sunday" }),
            };


            string destinationToSearch = "Paris";
            Console.WriteLine($"Список рейсов для пункта назначения '{destinationToSearch}':");
            foreach (var airline in airlines)
            {
                if (airline.Destination == destinationToSearch)
                {
                    Console.WriteLine($"Рейс {airline.FlightID}: {airline.AircraftType}, Время вылета: {airline.FlightTime}");
                }
            }

            // Вывод списка рейсов для заданного дня недели (например, "Tuesday")
            string dayOfWeekToSearch = "Tuesday";
            Console.WriteLine($"\nСписок рейсов для дня недели '{dayOfWeekToSearch}':");
            foreach (var airline in airlines)
            {
                if (Array.Exists(airline.DepartureDays, day => day == dayOfWeekToSearch))
                {
                    Console.WriteLine($"Рейс {airline.FlightID}: {airline.AircraftType}, Время вылета: {airline.FlightTime}");
                }
            }

        }
    }
}