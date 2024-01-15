using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17
{
    interface IObserver
    {
        void Update(string message);
    }

    // Интерфейс субъекта
    interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    // Конкретный субъект
    class ConcreteSubject : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        private string message;

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update(message);
            }
        }

        public void ChangeMessage(string newMessage)
        {
            message = newMessage;
            Notify();
        }
    }

    // Конкретный наблюдатель
    class ConcreteObserver : IObserver
    {
        private string observerState;

        public void Update(string message)
        {
            observerState = message;
            Console.WriteLine($"Received message: {observerState}");
        }
    }
}
