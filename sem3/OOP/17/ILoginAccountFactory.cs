using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17
{
    public interface ILoginAccountFactory
    {
        public LoginAccount CreateAccount(string username, string password);
    }
}
