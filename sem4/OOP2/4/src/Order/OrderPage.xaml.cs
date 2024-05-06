using _4.src.App;
using _4.src.Products;
using System.Windows;
using System.Windows.Media;

namespace _4.src.Order
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Window
    {
        private const string pre = ": ";
        public OrderPage(Sneaker sneaker)
        {
            InitializeComponent();

            //Changing content based on current Sneaker obj
            ModelNameTextBlock.Text = sneaker.GetBrandName + " " + sneaker.Model;
            ColorTextBlock.Text = pre + sneaker.Color;

            if (UILang.Language.DisplayName == "English")
            {
                ColorTextBlock.Text = pre + Sneaker.TranslateColorNameToEng(sneaker.Color);
            }

            SizeValueTextBlock.Text = pre + sneaker.Size.ToString();
            
            DescriptionTextBlock.Text = pre + sneaker.Descripcion;

            img.Stretch = Stretch.Fill;
            img.Source = sneaker.ImageSource;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы успешно заказали товар!");
            this.Close();
        }
    }
}
