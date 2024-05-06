using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17
{
    public class Admin : LoginAccount, IDataController
    {
        public override string GetAccountType()
        {
            return "Admin";
        }

        public static void getAllCardsInfo()
        {
            foreach (var user in UsersDatabase.UsersObjects)
            {
                foreach (var account in user.Value.accounts)
                {
                    foreach (var card in account.creditCards)
                    {
                        UsersDatabase.creditCards.Append(card);
                    }
                }
            }

            string[] headers = { "Blocked?", "SerialNumber", "Balance" };
            Console.WriteLine($"{headers[0],-10} {headers[1],-25} {headers[2],-10}");


            for (var i = 0; i < UsersDatabase.creditCards.Count; i++)
            {
                Console.Write(i + 1 + ") ");
                Console.WriteLine($"{UsersDatabase.creditCards[i].blocked,-10} {UsersDatabase.creditCards[i].SerialNumber,-25} {UsersDatabase.creditCards[i].Balance,-10}");
            }



            int choice = Convert.ToInt32(Console.ReadLine()) - 1;

            Console.WriteLine("1) Заблокировать карту\n" +
                              "2) Разблокировать карту\n");

            int choice2 = Convert.ToInt32(Console.ReadLine());

            if (choice2 == 1)
            {
                UsersDatabase.creditCards[choice].blocked = true;
                Console.WriteLine("Заблокирована!");
            }
            else
            {
                UsersDatabase.creditCards[choice].blocked = false;
                Console.WriteLine("Разблокирована!");
            }


        }

        public override void ShowControlPanel()
        {
            while (true)
            {
                getAllCardsInfo();
            }

        }


        public Admin(string username, string password) : base(username, password)
        {


        }
    }
}
