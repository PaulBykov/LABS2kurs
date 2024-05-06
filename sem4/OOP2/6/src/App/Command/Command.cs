using System.Collections.ObjectModel;
using _4.src.Products;
using _4.src.EditProduct;
using System.Security.Cryptography.Pkcs;
using System.Windows.Controls;
using System.Collections.Generic;
using _4.src.Database;



namespace _4.src.App.Command
{
    abstract class Command
    {
        public abstract void Execute(Sneaker sneaker);
        public abstract void Undo();
    }

    static class Memory
    {
       public static Stack<Sneaker> lastSneaker = new Stack<Sneaker>();
       public static Stack<Invoker> lastCommand = new Stack<Invoker>();
    }
    

    class RemoveProduct : Command
    {
        Receiver receiver;
        public RemoveProduct(Receiver r)
        {
            receiver = r;
        }
        public override void Execute(Sneaker sneaker)
        {
            Memory.lastSneaker.Push(sneaker);
            receiver.Remove(sneaker);
        }

        public override void Undo()
        { 
            receiver.Add(Memory.lastSneaker.Pop());
        }
    }


    class AddProduct : Command
    {
        Receiver receiver;
        public AddProduct(Receiver r)
        {
            receiver = r;
        }
        public override void Execute(Sneaker sneaker)
        {
            Memory.lastSneaker.Push(sneaker);
            receiver.Add(sneaker);
        }

        public override void Undo()
        {
            receiver.Remove(Memory.lastSneaker.Pop());
        }
    }


    class ChangeProduct : Command
    {
        Receiver receiver;
        public ChangeProduct(Receiver r)
        {
            receiver = r;
        }
        public override void Execute(Sneaker oldSneaker)
        {
            EditProduct.EditProduct editProduct = new EditProduct.EditProduct(oldSneaker);
            editProduct.Show();
        }

        public override void Undo()
        { }
    }

    // получатель команды
    class Receiver
    {
        private ObservableCollection<Sneaker> sneakerCollection;
        private DBController _DBcontroller;
        public Receiver(ObservableCollection<Sneaker> sneakers, DBController dBController) 
        {
            sneakerCollection = sneakers;
            _DBcontroller = dBController;
        }

        public void Remove(Sneaker sneaker)
        {
            sneakerCollection.Remove(sneaker);
            _DBcontroller.Delete(sneaker);
        }

        public void Add(Sneaker sneaker) 
        {
            sneakerCollection.Add(sneaker);
            _DBcontroller.Insert(sneaker);
        }
    }

    // инициатор команды
    class Invoker
    {
        Command command;
        public void SetCommand(Command c)
        {
            command = c;
        }
        public void Run(Sneaker sneaker)
        {
            command.Execute(sneaker);
            Memory.lastCommand.Push(this);
        }
        public void Cancel()
        {
            command.Undo();
        }
    }

}
