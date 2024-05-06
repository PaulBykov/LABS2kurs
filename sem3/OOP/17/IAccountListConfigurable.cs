using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17
{
    internal interface IAccountListConfigurable
    {
        public bool AddAccount(List<BankAccount> list, BankAccount newAcc)
        {
            try
            {
                list.Add(newAcc);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

    }
}
