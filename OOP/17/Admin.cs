using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17
{
    public class Admin : LoginAccount, IDataController
    {
        public override string GetAccountType()
        {
            return "Admin";
        }
        public Admin(string username, string password) : base(username, password)
        {


        }
    }
}
