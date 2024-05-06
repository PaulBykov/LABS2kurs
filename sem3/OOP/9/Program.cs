using System.Collections.ObjectModel;

namespace _9
{
    class Program
    {
        static void Main()  
        {
            List<int> firstCollection = new List<int>();
            for (int i = 1; i <= 10; i++) firstCollection.Add(i);

            Console.WriteLine("Первая коллекция:");
            foreach (int item in firstCollection) Console.Write(item + " ");

            Console.WriteLine();
            int n = 3;

            firstCollection.RemoveRange(0, n);
            firstCollection.Insert(0, 100);
            firstCollection.Add(200);
            firstCollection.InsertRange(2, new List<int> { 300, 400 });

            HashSet<int> secondCollection = new HashSet<int>(firstCollection);

            Console.WriteLine("Вторая коллекция:");
            foreach (int item in secondCollection) Console.Write(item + " ");
            Console.WriteLine();

            int valueToFind = 300;
            if (secondCollection.Contains(valueToFind)) Console.WriteLine("Заданное значение найдено во второй коллекции.");
            else Console.WriteLine("Заданное значение не найдено во второй коллекции.");

            ObservableCollection<int> observableCollection = new ObservableCollection<int>();
            observableCollection.CollectionChanged += CollectionChangedHandler;
            observableCollection.Add(1);
            observableCollection.Add(2);
            observableCollection.Add(3);
            observableCollection.Remove(2);
        }

        static void CollectionChangedHandler(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Коллекция была изменена!");
        }
    }
}