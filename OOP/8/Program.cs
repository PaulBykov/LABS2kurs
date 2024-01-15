namespace _8
{


    public class Program
    {
        private static void Display(int x)
        {
            Console.WriteLine($"Новое значение coord = {x}");
        }

        private static void Output(int x)
        {
            Console.WriteLine($"Новое значение size = {x}");
        }

        public static void Main(string[] args)
        {
            User user1 = new User();
            User user2 = new User();
            User user3 = new User();

            user1.Move += Display;
            user1.Forward(10);
            user1.Backwards(2);


            user2.Move += Display;
            user2.Compress += Output;
            user2.Forward(30);
            user2.Squeze(2);
            user2.Squeze(5);


            user3.Squeze(2);
        }
    }
}