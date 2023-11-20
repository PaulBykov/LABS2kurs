namespace _8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var user1 = new User(0);
            user1.MoveEvent += (coords) => Console.WriteLine($"User1 moved to coords: {coords}");
            user1.CompressEvent += (coords) => Console.WriteLine($"User1 compressed to coords: {coords}");

            var user2 = new User(10);
            user2.MoveEvent += (coords) => Console.WriteLine($"User2 moved to coords: {coords}");


            var user3 = new User(1000);

            user1.Move(10);
            user1.Move(10);
            user1.Compress(0.42);

            user2.Move(20);

            Console.Read();
        }
    }
}