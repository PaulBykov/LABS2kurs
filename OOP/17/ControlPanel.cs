using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17
{
    static class ControlPanel
    {
        public static void getCardsInfo(User user)
        {
            if (user == null)
            {
                return;
            }

            if (user.accounts[0].creditCards == null)
            {
                Console.WriteLine("Нет кредитных карт");
                return;
            }


            string[] headers = { "BankAccount", "SerialNumber", "Balance" };
            Console.WriteLine($"{headers[0],-10} {headers[1],-25} {headers[2],-10}");

            foreach (var account in user.accounts)
            {
                foreach (var card in account.creditCards)
                {
                    Console.WriteLine($"{card.BankAccount,-10} {card.SerialNumber,-25} {card.Balance,-10}");
                }
            }


        }

        public static void addNewCard(User user)
        {
            Console.WriteLine("Выбирите счёт: ");

            byte idx = 1;
            foreach (var acc in user.accounts)
            {
                Console.Write(idx++);
                Console.WriteLine(") " + acc.Id);
            }

            int choice;
            choice = Convert.ToByte(Console.ReadLine()) - 1;

            var newCard = new CreditCard(user.accounts[choice]);
            user.accounts[choice].creditCards.Add(newCard);

        }

        public static void makePayment(string fromAccount, string destAccount, int Sum, User currUsr)
        {
            Session session = Session.GetInstance();

            CreditCard Card1 = currUsr.accounts
                                      .SelectMany(account => account.creditCards) // Объединяем все списки кредитных карт в один список
                                      .FirstOrDefault(card => card.SerialNumber == fromAccount);


            CreditCard Card2 = currUsr.accounts
                                      .SelectMany(account => account.creditCards) // Объединяем все списки кредитных карт в один список
                                      .FirstOrDefault(card => card.SerialNumber == destAccount);

            Card1.Balance -= Sum;
            Card2.Balance += Sum;
            Console.WriteLine("Транзакция произведена успешно!");
        }
    }
}
