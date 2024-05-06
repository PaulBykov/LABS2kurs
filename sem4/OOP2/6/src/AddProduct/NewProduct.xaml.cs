using Microsoft.Win32;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using _4.src.Products;
using _4.src.App.Command;
using _4.src.App;
using _4.src.Database;


namespace _4.src.AddProduct
{
    /// <summary>
    /// Логика взаимодействия для NewProduct.xaml
    /// </summary>
    public partial class NewProduct : Window
    {
        private const string targetDirectory = "../../../assets/images/products/";

        private Products.ProductsController _db;
        private DBController database;

        public NewProduct(Products.ProductsController DB, DBController dBController)
        {
            InitializeComponent();

            _db = DB;
            database = dBController;
        }

        private void Image_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Image imgPicture = (Image)sender;

            OpenFileDialog ofdPicture = new OpenFileDialog();
            ofdPicture.Filter =
                "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            ofdPicture.FilterIndex = 1;

            if (ofdPicture.ShowDialog() == true) 
            {
                imgPicture.Source = new BitmapImage(new Uri(ofdPicture.FileName));
            }
        }

        private Sneaker CreateSneaker() 
        {
            string img = ChosePic.Source.ToString();
            Sneaker.Brands brand = Sneaker.GetBrandByName(brandName.Text);
            string modelName = ModelText.Text;
            string desc = descriptionText.Text;

            string color = colorComboBox.SelectedItem.ToString();
            if (UILang.Language.DisplayName == "English")
            {
                color = Sneaker.TranslateColorNameToRus(color);
            }

            ushort size = ushort.Parse(sizeComboBox.Text);
            ushort price = ushort.Parse(priceInput.Text);
            ushort id = Convert.ToUInt16(_db.getDB.Lenght + 1);

            Sneaker sneaker = new Sneaker(id, brand, modelName, desc, size, color, price, img);

            return sneaker;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Sneaker sneaker = CreateSneaker();

            Invoker invoker = new Invoker();
            invoker.SetCommand(new App.Command.AddProduct(new Receiver(_db.getDB.Db, database)));
            invoker.Run(sneaker);


            this.Close();
        }
    }
}
