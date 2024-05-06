using _4.src.App;
using _4.src.Products;
using System.Windows;
using System.Windows.Media.Imaging;


namespace _4.src.EditProduct
{
    /// <summary>
    /// Логика взаимодействия для EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        private const int _tempId = 1000;
        private Sneaker _savedSneaker;
        public EditProduct(Sneaker sneaker)
        {
            InitializeComponent();

            _savedSneaker = sneaker;

            SetFields(_savedSneaker);
        }

        private void SetFields(Sneaker sneaker) 
        {
            ChosePic.Source = sneaker.ImageSource;
            brandName.Text = sneaker.GetBrandName;
            ModelText.Text = sneaker.Model;
            descriptionText.Text = sneaker.Descripcion;
            colorComboBox.SelectedIndex = colorComboBox.Items.IndexOf(sneaker.GetFormatedColor);
            sizeComboBox.SelectedIndex = sizeComboBox.Items.IndexOf(sneaker.Size);
            priceInput.Text = sneaker.Price.ToString();
        }

        private Sneaker CreateSneaker()
        {
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

            Sneaker sneaker = new Sneaker(_tempId, brand, modelName, desc, size, color, price);

            return sneaker;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Sneaker editedSneaker = CreateSneaker();

            _savedSneaker.Brand = editedSneaker.Brand;
            _savedSneaker.Descripcion = editedSneaker.Descripcion;
            _savedSneaker.Price = editedSneaker.Price;
            _savedSneaker.Size = editedSneaker.Size;
            _savedSneaker.Color = editedSneaker.Color;
            _savedSneaker.Model = editedSneaker.Model;
        }
    }
}
