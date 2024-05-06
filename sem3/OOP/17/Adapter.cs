using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17
{
    interface ITarget
    {
        void Request();
    }

    // Адаптируемый класс
    class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Adaptee: специфический запрос");
        }
    }

    // Адаптер, преобразующий интерфейс Adaptee в интерфейс ITarget
    class Adapter : ITarget
    {
        private Adaptee adaptee;

        public Adapter(Adaptee adaptee)
        {
            this.adaptee = adaptee;
        }

        public void Request()
        {
            adaptee.SpecificRequest();
        }
    }
}
