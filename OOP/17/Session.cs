using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17
{
    public sealed class Session     // Singleton
    {
        private bool isLogined = false;
        public LoginAccount LoggedInUser { get; private set; }

        public void Login(LoginAccount user)
        {
            isLogined = true;
            LoggedInUser = user;
        }



        private Session() { }

        private static Session _instance;

        public static Session GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Session();
            }

            return _instance;
        }
    }
}
