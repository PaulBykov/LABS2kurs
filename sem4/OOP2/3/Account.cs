using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace _2
{

    [Serializable]
    public class Account
    {
        public enum InvestType { credit, debet };

        
        private long number;
        private InvestType type;
        [Range(0, 1000000, ErrorMessage = "Баланс должен быть в диапазоне от 0 до 1000000.")]
        private long balance;
        private DateTime date;
        private bool enableSms;

        User owner;

        public Account() { }
        public Account(long number = 0, InvestType type = InvestType.credit, long balance = 0, DateTime? dateTime = null, bool sms = false, User? owner = null)
        {
            this.Number = number;
            this.Type = type;
            this.Balance = balance;
            this.Owner = owner;

            if (dateTime == null)
            {
                this.Date = DateTime.Now;
            }
            else 
            {
                this.Date = (DateTime)dateTime;
            }
                        
            this.EnableSms = sms;
        }

        public long Number { get => number; set => number = value; }
        public long Balance { get => balance; set => balance = value; }
        public DateTime Date { get => date; set => date = value; }
        public bool EnableSms { get => enableSms; set => enableSms = value; }
        internal InvestType Type { get => type; set => type = value; }
        public User Owner { get => owner; set => owner = value; }

        public void Serialize(Form1 f)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Account>));

            using (FileStream fs = new FileStream("AccountData.xml", FileMode.OpenOrCreate))
            {
                f.DB.Add(this);
                xml.Serialize(fs, f.DB);
            }
        }

        public static Account Deserialize()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Account>));

            using (FileStream fs = new FileStream("AccountData.xml", FileMode.OpenOrCreate))
            {
                List<Account> data = (List<Account>) xml.Deserialize(fs);
                return (Account)data[data.Count - 1];
            }
        }


        public override string ToString()
        {
            return (this.number + "    " + this.Type + "    " + this.Owner.FullName + "    " + this.Balance);
        }
    }
}
