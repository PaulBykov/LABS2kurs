using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace _4.src.Products
{
    [Serializable]
    public class Products
    {
        private const string _sourcePath = "../../../assets/data/db.xml";
        private ObservableCollection<Sneaker> _db = new ObservableCollection<Sneaker>();

        public Products()
        {
            _db = new ObservableCollection<Sneaker>();
        }

        public Products(ObservableCollection<Sneaker> db)
        {
            _db = db;
        }
        public ObservableCollection<Sneaker> Db { get => _db; set => _db = value; }

        public int Lenght { get => _db.Count(); }
        public void Add(Sneaker sneaker)
        {
            _db.Add(sneaker);
        }

        public void Delete(Sneaker sneaker)
        {
            _db.Remove(sneaker);
        }
        public void Serialize()
        {
            using (FileStream fs = new FileStream(_sourcePath, FileMode.OpenOrCreate))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Products));
                xml.Serialize(fs, this);
            }
        }
        public static Products? Deserialize()
        {
            using (FileStream fs = new FileStream(_sourcePath, FileMode.OpenOrCreate))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Products));
                return (Products?)xml.Deserialize(fs);
            }
        }
    }
}
