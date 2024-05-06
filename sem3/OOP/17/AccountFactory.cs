using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17
{

    public class UserFactory : ILoginAccountFactory
    {
        public LoginAccount CreateAccount(string username, string password)
        {
            return new User(username, password);
        }
    }

    // Фабрика для создания Admin
    public class AdminFactory : ILoginAccountFactory
    {
        public LoginAccount CreateAccount(string username, string password)
        {
            return new Admin(username, password);
        }
    }

}
