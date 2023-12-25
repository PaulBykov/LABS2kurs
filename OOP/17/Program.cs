namespace _17
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Session GlobalSession = Session.GetInstance();


            try
            {
                Console.WriteLine("Добро пожаловать!");

                // Auth
                bool AuthStatus;
                do
                {
                    AuthStatus = Auth.ShowLoginMenu();
                } while (!AuthStatus);

                var user = GlobalSession.LoggedInUser;

                if (user is not Admin && user is not User)
                {
                    throw new Exception();
                }

                // Menu
                while (true)
                {
                    user.ShowControlPanel();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



        }
    }
}