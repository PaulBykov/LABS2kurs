using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    public class FlatArray
    {
        private string[] array;
        public int length;
        public void Add(string newStr) {
            array.Append(newStr);
            length++;
        }

        public string Get(int index) {
            return array[index];
        }

        public void Delete(int delIndex)
        {
            ref string[] data = ref array;

            string[] newData = new string[data.Length - 1];
            for (int i = 0; i < delIndex; i++)
            {
                newData[i] = data[i];
            }
            for (int i = delIndex; i < newData.Length; i++)
            {
                newData[i] = data[i + 1];
            }
            data = newData;

            length--;
        }


        public static int operator -(FlatArray lValue, FlatArray rValue) {
            return lValue.length - rValue.length;
        }

        public static bool operator >(FlatArray arr, string element) { 
            if (arr == null) return false;

            foreach (var str in arr.array) { 
                if (str.Equals(element))
                    return true;
            }

            return false;
        }

        public static bool operator <(FlatArray arr, string element) {
            return !(arr>element);
        }


        public static bool operator ==(FlatArray lValue, FlatArray rValue) {

            if (lValue.length != rValue.length) {
                return false;
            }
            

            for (int i = 0; i < lValue.length; i++) {
                if (lValue.Get(i) != rValue.Get(i)) {
                    return false;
                }
            
            }
            
            return true;
        }


        public static bool operator !=(FlatArray lValue, FlatArray rValue) {
            return !(lValue == rValue);
        }

        public static FlatArray operator +(FlatArray lValue, FlatArray rValue) {
            var newContent = lValue.array;

            foreach (var element in rValue.array) { 
                newContent.Append(element);
            }

            var comparedArr = new FlatArray(newContent);

            return comparedArr;
        }


        public FlatArray(string[] array)
        {
            this.array = array;
            length = array.Length;
        }

    }
}
