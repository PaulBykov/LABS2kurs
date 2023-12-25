using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15
{
    internal class Resheto
    {
        public static bool[] getPrimeNumbersUntill(int n) {
            bool[] prime = new bool[n + 1];
            for (int i = 2; i <= n; i++)
            {
                prime[i] = true;
            }

            for (int p = 2; p * p <= n; p++)
            {
                if (prime[p])
                {
                    Parallel.For(p * p, n + 1, i =>
                    {
                        if (i % p == 0)
                            prime[i] = false;
                    });
                }
            }

            return prime;
        }


    }
}
