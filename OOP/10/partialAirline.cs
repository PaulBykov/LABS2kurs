using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _2
{
    public partial class Airline
    {

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Airline otherAirline = (Airline)obj;

            // Сравниваем объекты по имени и номеру рейса
            return flightID == otherAirline.flightID;
        }

        public override int GetHashCode()
        {
            // Используем XOR (^) для комбинирования хэшей полей объекта
            return destination.GetHashCode() ^ flightID.GetHashCode();
        }

        public override string ToString()
        {
            string days = "";

            foreach (var day in DepartureDays){
                days += day + ", ";
            }

            if (Destination.Length > 5) {
                return $"{FlightID} \t {destination} \t {FlightTime} on {days}";
            }
            
            return $"{FlightID} \t {destination} \t \t {FlightTime} on {days}";
        }
    }
}
