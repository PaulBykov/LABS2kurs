using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _2
{
    [Serializable]
    public class User
    {
        [Required(AllowEmptyStrings=false, ErrorMessage="fullName is't valid!"), RegularExpression(@"\d+")]
        String fullName;

        bool flagInternet;
        bool flagFriends;
        bool flagOther;

        DateTime birthDate;

        public User() { }

        public User(String name = "", bool internet = false, bool other = false, bool friends = false)
        {
            this.FullName = name;
            this.FlagOther = other;
            this.FlagInternet = internet;
            this.FlagFriends = friends;
        }

        public string FullName { get => fullName; set => fullName = value; }
        public bool FlagInternet { get => flagInternet; set => flagInternet = value; }
        public bool FlagFriends { get => flagFriends; set => flagFriends = value; }
        public bool FlagOther { get => flagOther; set => flagOther = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }

        public void Serialize() 
        {
            XmlSerializer xml = new XmlSerializer(typeof(User));

            using (FileStream fs = new FileStream("UserData.xml", FileMode.OpenOrCreate)) 
            {
                xml.Serialize(fs, this);
            }
        }

        public static User Deserialize() 
        {
            XmlSerializer xml = new XmlSerializer(typeof(User));

            using (FileStream fs = new FileStream("UserData.xml", FileMode.OpenOrCreate)) 
            { 
                return (User) xml.Deserialize(fs);
            }
        }
    }
}
