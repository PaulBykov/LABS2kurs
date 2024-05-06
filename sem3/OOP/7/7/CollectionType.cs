using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace _7
{
    [Serializable]
    internal class CollectionType<T>
    {
        public void saveToFile(T[] arr)
        {

            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(T));

            using (FileStream fs = new FileStream("data.json", FileMode.OpenOrCreate))


                foreach (T item in arr)
                {
                    formatter.WriteObject(fs, item);
                }


        }


        public void WriteFromFile(string filePath)
        {
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(T));

            using (FileStream fs = new FileStream("data.json", FileMode.OpenOrCreate))


                Console.WriteLine( formatter.ReadObject(fs).ToString() );

        }

    }
}
