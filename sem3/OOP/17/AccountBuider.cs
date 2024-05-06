using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17
{
    public class AccountBuilder
    {
        private ILoginAccountFactory factory;

        public AccountBuilder(ILoginAccountFactory factory)
        {
            this.factory = factory;
        }

        public LoginAccount BuildAccount(string username, string password)
        {
            var newAccount = (User)factory.CreateAccount(username, password);
            var session = Session.GetInstance();

            UsersDatabase.AllUsers.Add(newAccount);
            return newAccount;
        }
    }
}
