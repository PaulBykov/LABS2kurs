using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17
{
    public class BankAccount
    {
        private readonly int id;
        public List<CreditCard> creditCards = new List<CreditCard>();

        public BankAccount()
        {
            var rand = new Random();
            this.id = rand.Next(1000).GetHashCode();
            creditCards.Add(new CreditCard(this));
        }
        public int Id => id;
    }
}
