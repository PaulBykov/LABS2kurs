using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    public static class FlatArrayExtansion
    {
        private static char[] vowels = { 'a', 'e', 'u', 'i', 'o' };

        private static bool isVowel(char symbol) {
            for(int i = 0; i < vowels.Length; i++) {
                if (symbol != vowels[i]) {
                    return true;
                }
            }

            return false;
        }

        public static void RemoveVowels(this FlatArray arr)
        {
            for (int i = 0; i < arr.length; i++) { 
                var str = arr.Get(i);

                for (int j = 0; j < str.Length; j++) {
                    if (isVowel(str[j])) {
                        arr.Delete(j);
                    }
                }
            }
        }

        public static void RemoveFirstFive(this FlatArray arr) {
            for (var i = 0; i < 5; i++) { 
                arr.Delete(i);
            }
        }

    }
}
