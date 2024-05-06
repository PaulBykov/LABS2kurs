using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
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

        long number;
        InvestType type;
        long balance;
        DateTime date;
        bool enableSms;

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

        public void Serialize()
        {
            XmlSerializer xml = new XmlSerializer(typeof(Account));

            using (FileStream fs = new FileStream("AccountData.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, this);
            }
        }

        public static Account Deserialize()
        {
            XmlSerializer xml = new XmlSerializer(typeof(Account));

            using (FileStream fs = new FileStream("AccountData.xml", FileMode.OpenOrCreate))
            {
                return (Account) xml.Deserialize(fs);
            }
        }

    }
}
