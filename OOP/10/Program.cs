using _2;
using System.ComponentModel;

namespace _10
{
    internal class Program
    {
        static void first() {
            string[] months = {"June", "July", "May", "December", "January", "August", "February",
                           "November", "September", "October", "April", "March"};

            int n = 5; // Длина строки

            // Запрос выбирающий последовательность месяцев с длиной строки равной n
            var monthsWithLengthN = months.Where(m => m.Length == n);

            Console.WriteLine("Месяцы с длиной строки {0}:", n);
            foreach (var month in monthsWithLengthN)
            {
                Console.WriteLine(month);
            }
            Console.WriteLine();

            // Запрос возвращающий только летние и зимние месяцы
            var summerAndWinterMonths = months.Where(m => m == "June" || m == "July" ||
                                                          m == "August" || m == "December" ||
                                                          m == "January" || m == "February");

            Console.WriteLine("Летние и зимние месяцы:");
            foreach (var month in summerAndWinterMonths)
            {
                Console.WriteLine(month);
            }
            Console.WriteLine();

            // Запрос вывода месяцев в алфавитном порядке
            var sortedMonths = months.OrderBy(m => m);

            Console.WriteLine("Месяцы в алфавитном порядке:");
            foreach (var month in sortedMonths)
            {
                Console.WriteLine(month);
            }
            Console.WriteLine();

            // Запрос считающий месяцы содержащие букву «u» и длиной имени не менее 4-х
            var monthsWithU = months.Where(m => m.Contains("u") && m.Length >= 4);

            Console.WriteLine("Месяцы содержащие букву 'u' и длиной имени не менее 4-х:");
            foreach (var month in monthsWithU)
            {
                Console.WriteLine(month);
            }
        }

        static void second(String to, String day)
        {
            List<Airline> airlines = new List<Airline>();

            airlines.Add(new Airline("New York", 1, "Boeing 737", "08:00", new string[] { "Friday" }));
            airlines.Add(new Airline("Paris", 2, "Airbus A320", "14:30", new string[] { "Tuesday", "Thursday" }));
            airlines.Add(new Airline("London", 3, "Boeing 777", "10:45", new string[] { "Monday", "Wednesday", "Saturday" }));
            airlines.Add(new Airline("New York", 11, "Boeing 337", "18:30", new string[] { "Wednesday", "Friday" }));
            airlines.Add(new Airline("Sydney", 4, "Boeing 747", "12:15", new string[] { "Monday", "Tuesday", "Thursday" }));
            airlines.Add(new Airline("Moscow", 5, "Airbus A380", "16:20", new string[] { "Tuesday", "Wednesday", "Friday" }));
            airlines.Add(new Airline("Paris", 6, "Boeing 737", "09:30", new string[] { "Monday", "Thursday", "Saturday" }));
            airlines.Add(new Airline("Dubai", 7, "Airbus A320", "17:00", new string[] { "Tuesday", "Friday", "Sunday" }));
            airlines.Add(new Airline("Sydney", 8, "Boeing 777", "07:45", new string[] { "Wednesday", "Friday" }));
            airlines.Add(new Airline("Rome", 9, "Boeing 337", "11:30", new string[] { "Monday", "Wednesday", "Friday", "Saturday" }));
            airlines.Add(new Airline("Sydney", 10, "Airbus A330", "15:25", new string[] { "Tuesday", "Thursday", "Saturday" }));



            var airlinesToEndPoint = from airline in airlines
                                     where airline.Destination == to
                                     select airline;


            int airlinesCountByDay = (from airline in airlines
                                      where airline.DepartureDays.Contains(day)
                                      select airline).Count();

            var mondayAirlines = (from airline in airlines
                                  where airline.DepartureDays.Contains("Monday")
                                  select airline);
            var earlyTimeMondayAirline = mondayAirlines.Where(p => p.FlightTime == mondayAirlines.Min(airline => airline.FlightTime));


            var wedOrFriAirline = (from airline in airlines
                                  where airline.DepartureDays.Contains("Wednesday") || airline.DepartureDays.Contains("Friday")
                                  select airline);
            var lateWedOrFriAirline = wedOrFriAirline.Where(p => p.FlightTime == wedOrFriAirline.Max(airline => airline.FlightTime));




            var AirlinesOrd = from airline in airlines
                              orderby airline.FlightTime
                              select airline;


            var JoinedAirlines = airlines
                .Join(
                    airlines,
                    w => w,
                    q => q,
                    (w, q) => new
                    {
                        id = w,

                    }
                );



            Console.WriteLine("ID: \t Destination: \t When: ");


            Console.WriteLine("\n---------------------------1-------------------------------\n");


            foreach (var airline in airlinesToEndPoint) { 
                Console.WriteLine(airline.ToString());
            }

            Console.WriteLine("\n---------------------------2-------------------------------\n");


            Console.WriteLine(airlinesCountByDay);


            Console.WriteLine("\n---------------------------3-------------------------------\n");

            foreach (var airline in earlyTimeMondayAirline) {
                Console.WriteLine(airline.ToString());
            }

            Console.WriteLine("\n---------------------------4-------------------------------\n");
            foreach (var airline in lateWedOrFriAirline)
            {
                Console.WriteLine(airline.ToString());
            }

            Console.WriteLine("\n---------------------------5-------------------------------\n");

            foreach (var airline in AirlinesOrd)
            {
                Console.WriteLine(airline.ToString());
            }


            Console.WriteLine("\n---------------------------6-------------------------------\n");

            foreach (var airline in JoinedAirlines)
            {
                Console.WriteLine(airline.ToString());
            }

        }



        static void Main(string[] args)
        {
            // first();

            second("New York", "Friday");

        }
    }
}