using _4.src.App;
using System.Windows.Media.Imaging;

namespace _4.src.Products
{

    [Serializable]
    public class Sneaker
    {
        public enum Brands { Puma = 0, Nike, Adidas, Reebok };

        private ushort _id;
        private Brands _brand;
        private string _model = "";
        private string _color = "";
        private string _descripcion = "";
        private ushort _size;
        private ushort _price = 0;
        private string _imageSource = "";
        public Sneaker() { }
        public Sneaker(ushort id, Brands brand, string model, string description, ushort size, string color, ushort price, string? imageSource = null)
        {
            _id = id;
            Brand = brand;
            Color = color;
            Size = size;
            Descripcion = description;
            Model = model;
            Price = price;


            if (imageSource == null)
            {
                _imageSource = "../../../assets/images/products/" + this.Id.ToString() + ".jpg";
            }
            else 
            {
                _imageSource = imageSource;
            }
        }

        public string GetBrandName
        {
            get
            {
                if (Brand == Brands.Puma) return "Puma";
                if (Brand == Brands.Nike) return "Nike";
                if (Brand == Brands.Adidas) return "Adidas";
                if (Brand == Brands.Reebok) return "Reebok";

                return "None";
            }
        }
        public static Brands GetBrandByName(string name)
        {
            switch (name) 
            {
                case "Puma":
                    return Brands.Puma;
                case "Nike":
                    return Brands.Nike;
                case "Adidas":
                    return Brands.Adidas;
                case "Reebok":
                    return Brands.Reebok;
                default:
                    return Brands.Nike;
            }
        }
        public static string TranslateColorNameToRus(string color) 
        {
            switch(color) 
            {   
                case "black":
                    return "черный";
                case "white":
                    return "белый";
                case "yellow":
                    return "желтый";
                case "green":
                    return "зеленый";
                case "gray":
                    return "серый";
                case "red":
                    return "красный";
                case "blue":
                    return "синий";
            }

            return color;
        }
        public static string TranslateColorNameToEng(string color) 
        {
            switch(color) 
            {   
                case "черный":
                    return "black";
                case "белый":
                    return "white";
                case "желтый":
                    return "yellow";
                case "зеленый":
                    return "green";
                case "серый":
                    return "gray";
                case "красный":
                    return "red";
                case "синий":
                    return "blue";
            }

            return color;
        }
        public BitmapImage ImageSource { get { return new BitmapImage(new Uri(this.Image, UriKind.RelativeOrAbsolute)); } }
        public ushort Id { get => _id; set => _id = value; }
        public string Model { get => _model; set => _model = value; }
        public Brands Brand { get => _brand; set => _brand = value; }
        public ushort Size { get => _size; set => _size = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string Color { get => _color; set => _color = value; }
        public ushort Price { get => _price; set => _price = value; }
        public string Image { get => _imageSource; set => _imageSource = value; }
        public string GetFormatedColor
        {
            get { return UILang.Language.DisplayName == "English" ? Sneaker.TranslateColorNameToEng(_color) : _color; }
        }
        
    }
}   
