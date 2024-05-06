using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17
{
    interface IStrategy
    {
        void Execute();
    }

    // Конкретные стратегии
    class ConcreteStrategyA : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Выполнение стратегии A");
        }
    }

    class ConcreteStrategyB : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Выполнение стратегии B");
        }
    }

    // Класс контекста, использующий стратегию
    class Context
    {
        private IStrategy strategy;

        public Context(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void ExecuteStrategy()
        {
            strategy.Execute();
        }
    }
}
