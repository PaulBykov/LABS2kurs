using System.Collections.ObjectModel;
using _4.src.Products;
using _4.src.EditProduct;



namespace _4.src.App.Command
{
    abstract class Command
    {
        public abstract void Execute(Sneaker sneaker);
        public abstract void Undo();
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
            receiver.Remove(sneaker);
        }

        public override void Undo()
        { }
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
            receiver.Add(sneaker);
        }

        public override void Undo()
        { }
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

        public Receiver(ObservableCollection<Sneaker> sneakers) 
        {
            sneakerCollection = sneakers;
        }

        public void Remove(Sneaker sneaker)
        {
            sneakerCollection.Remove(sneaker);
        }

        public void Add(Sneaker sneaker) 
        {
            sneakerCollection.Add(sneaker);
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
        }
        public void Cancel()
        {
            command.Undo();
        }
    }

}
