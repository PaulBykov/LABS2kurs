using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7
{
    interface MyInterface<T>
    {
        public bool printVal(T[] msg) {
            bool status = false;

            try
            {
                foreach(var item in msg)
                {
                    Console.WriteLine(item);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                status = true;
            }
            finally {
                Console.WriteLine("That works any ways");
            }

            return status;
        }

    }
}
