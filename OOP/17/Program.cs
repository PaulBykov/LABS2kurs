namespace _17
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Session GlobalSession = Session.GetInstance();
            UsersDatabase db = new UsersDatabase();

            User test = new User("Alex", "321");
            User test2 = (User)test.Clone();

            ConcreteSubject subject = new ConcreteSubject();
            ConcreteObserver observer1 = new ConcreteObserver();
            ConcreteObserver observer2 = new ConcreteObserver();

            // Присоединение наблюдателей к субъекту
            subject.Attach(observer1);
            subject.Attach(observer2);

            // Изменение состояния субъекта и уведомление наблюдателей
            subject.ChangeMessage("Новое сообщение для наблюдателей!");



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