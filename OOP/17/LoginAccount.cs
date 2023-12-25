using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17
{
    public abstract class LoginAccount
    {
        private readonly string username;
        private string password;


        public LoginAccount(string username, string password)
        {
            this.username = username;
            this.password = password;

            //ILoginAccountFactory userFactory = new UserFactory();
            //AccountBuilder accountBuilder = new AccountBuilder(userFactory);
            //Session session = Session.GetInstance();
            //session.users.Add((User)accountBuilder.BuildAccount(username, password));
        }

        public string Username => username;

        public override bool Equals(object? obj)
        {
            return obj is LoginAccount account &&
                   username == account.username;
        }

        public bool checkPassword(string pass)
        {
            return this.password.GetHashCode() == pass.GetHashCode();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(password);
        }

        public virtual void ShowControlPanel()
        {
            Console.WriteLine("Displaying control panel");
        }

        public abstract string GetAccountType();
    }
}
