using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17
{
    public static class Auth
    {

        private static bool tryLogin(string? login, string? password)
        {
            if (login == null || password == null)
            {
                throw new Exception();
            }


            if (UsersDatabase.AdminsPasswords.ContainsKey(login))
            {
                string tempPass;
                UsersDatabase.AdminsPasswords.TryGetValue(login, out tempPass);

                if (tempPass == password)
                {
                    Console.WriteLine("Вы успешно вошли");

                    Session session = Session.GetInstance();
                    session.Login(UsersDatabase.getAdminByUsername(login));
                    return true;
                }
            }


            if (UsersDatabase.UsersPasswords.ContainsKey(login))
            {
                string tempPass;
                UsersDatabase.UsersPasswords.TryGetValue(login, out tempPass);

                if (tempPass == password)
                {
                    Console.WriteLine("Вы успешно вошли");

                    Session session = Session.GetInstance();
                    session.Login(UsersDatabase.getUserByUsername(login));
                    return true;
                }
            }

            return false;
        }




        public static bool ShowLoginMenu()
        {
            Console.Write("login: ");

            string? login;
            login = Console.ReadLine();


            Console.WriteLine("\npassword: ");
            string? password;
            password = Console.ReadLine();

            return tryLogin(login, password);
        }

    }
}
