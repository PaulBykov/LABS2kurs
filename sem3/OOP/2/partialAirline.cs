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
            // Возвращаем строку с информацией об объекте
            return $"Airline: {destination}, Flight Number: {flightID}";
        }
    }
}
