using Lab6;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace _6
{
    internal class Program
    {
        static void Main(string[] args)
        {
                int a= 0;
                int b = 0;

                char c = '0';

            try
            {
                if (c is char)
                {
                    throw new Exception();
                }
                else {
                    throw new NameException("Help ", "Name error");
                }
            }
            catch (NameException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch(Exception ex) { 
                Console.WriteLine(ex.ToString());
            }
            finally {
                Console.WriteLine("finaly!");
            }


        }
    }
}