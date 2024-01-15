using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _17
{
    public class User : LoginAccount, ICloneable
    {
        public List<BankAccount> accounts;

        public User(string username, string password) : base(username, password)
        {
            this.accounts = new List<BankAccount> { new BankAccount() };
            UsersDatabase.AllUsers.Add(this);
        }

        public override string GetAccountType()
        {
            return "User";
        }
        public override void ShowControlPanel()
        {
            Console.WriteLine("1) Получить информацию по картам\n" +
                              "2) Создать платёж\n" +
                              "3) Добавить карту");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ControlPanel.getCardsInfo(this);
                    break;
                case 2:
                    Console.WriteLine("Введите 2 номера карты: ");

                    string firstCard = Console.ReadLine(),
                        secondCard = Console.ReadLine();

                    Console.WriteLine("Введите сумму: ");
                    int sum = Convert.ToInt32(Console.ReadLine());

                    ControlPanel.makePayment(firstCard, secondCard, sum, this);
                    break;
                case 3:
                    ControlPanel.addNewCard(this);
                    break;
            }

        }


        public object Clone()
        {
            return new User(Username, Password); // Создание нового экземпляра на основе текущего
        }

        public override string ToString()
        {
            return $"Name: {Username}, Pass: {Password}";
        }
    }
}
