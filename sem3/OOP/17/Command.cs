using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17
{
    interface ICommand
    {
        void Execute();
    }

    // Конкретная команда
    class ConcreteCommand : ICommand
    {
        private Receiver receiver;

        public ConcreteCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public void Execute()
        {
            receiver.Action();
        }
    }

    // Получатель команды
    class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Receiver: выполнение действия");
        }
    }

    // Инициатор команды
    class Invoker
    {
        private ICommand command;

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void ExecuteCommand()
        {
            command.Execute();
        }
    }
}
