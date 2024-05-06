using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    internal class CustomException : Exception
    {
        private readonly string message;
        private readonly int id;

        public CustomException(string msg, int ID = 0) {
            message = msg;
            id = ID;
        }

        public string Message1 => message;
    }
}
