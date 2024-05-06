using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17
{
    internal class AccountList : IAccountListConfigurable
    {
        private List<BankAccount> bankAccounts;

        AccountList()
        {
            bankAccounts = new List<BankAccount>();
        }
    }
}
