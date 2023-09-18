using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _2
{
    partial class Airline
    {
        readonly long uniID = 0;
        const string className = "Airline";
        static int classCount;

        string destination;
        long flightID;
        string aircraftType;
        string flightTime;
        string[] departureDays;

        public string Destination { get => destination; set => destination = value; }
        public long FlightID { get => flightID; set => flightID = value; }
        public string AircraftType { get => aircraftType; set => aircraftType = value; }
        public string FlightTime { get => flightTime; set => flightTime = value; }
        public string[] DepartureDays { get => departureDays; set => departureDays = value; }

        public long UniID => uniID;
        public static string ClassName => className;

        static Airline()
        {
            classCount++;
        }

        public Airline(string dest, long id, string type, string time, string[] departures)
        {
            Destination = dest;
            FlightID = id;
            AircraftType = type;
            FlightTime = time;
            departureDays = departures;

            classCount++;
        }

        private Airline(string dest, long id, string[] departures, string type = "boeng", string time = "12:00")
        {
            Destination = dest;
            FlightID = id;
            AircraftType = type;
            FlightTime = time;
            departureDays = departures;

            classCount++;
        }

        static public void showClassCount()
        {
            Console.WriteLine(classCount);
        }

        public void getFormatedTimeDeparture(ref string time, ref string date, out string result)
        {
            result = date + time;
        }

        public object Clone()
        {
            string[] a = new string[2];
            return new Airline("1", 2, "3", "4", a);
        }
    }
}
