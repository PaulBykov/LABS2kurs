using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17
{
    public class CreditCard
    {
        BankAccount bankAccount;
        private readonly string serialNumber;
        private readonly int CVV;
        private long balance;
        public bool blocked = false;

        public long Balance { get => balance; set => balance = value; }

        public int CVV1 => CVV;

        public string SerialNumber => serialNumber;

        public int BankAccount { get => bankAccount.Id; }

        public CreditCard(BankAccount acc)
        {
            this.bankAccount = acc;
            this.balance = 0;

            var rand = new Random();
            this.serialNumber = rand.Next(1000, 9999 + 1) + " "
                                + rand.Next(1000, 9999 + 1) + " "
                                + rand.Next(1000, 9999 + 1) + " "
                                + rand.Next(1000, 9999 + 1);

            this.CVV = rand.Next(100, 999 + 1);
        }

    }
}
