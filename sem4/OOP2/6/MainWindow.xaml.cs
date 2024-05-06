using System.Windows;
using System.Windows.Input;
using System.Data;
using _4.src.Products;
using System.Windows.Controls;
using _4.src.Order;
using _4.src.AddProduct;
using _4.src.App.Command;
using System.Globalization;
using _4.src.App;
using System.Windows.Resources;
using _4.src.Database;
using Microsoft.Data.SqlClient;

namespace _4
{
    public partial class MainWindow : Window
    {
        private bool _isMaximized = false;
        private Products _db = new Products();
        private ProductsController _controller;
        private DBController database = new DBController();
        
        public MainWindow()
        {
            InitializeComponent();

            StreamResourceInfo sri = Application.GetResourceStream(new Uri("/assets/AppStarting.ani", UriKind.Relative));
            Cursor custom = new Cursor(sri.Stream);
            this.Cursor = custom;

            ThemeCombobox.SelectionChanged += ThemeChange;

            // test
            //test test = new test();
            //test.Show();

            database.checkAvalibleDB();

            try
            {
                var tempDB = database.getAllProducts();

                if (tempDB is null)
                {
                    throw new NoNullAllowedException("Error during deserialize. Success but null taked");
                }

                _db = tempDB;
            }
            catch (SqlException sqlErr) 
            {
                MessageBox.Show("Ошибка получения данных: " + sqlErr.Message);
            }
            catch (Exception err) 
            {
                MessageBox.Show("NonSQL Ошибка получения данных: " + err.Message);
            }
            finally 
            {
                _controller = new ProductsController(_db, productsDataGrid);
                _controller.UpdateDataGrid(_db);
            }

            //try
            //{
            //    var tempDB = Products.Deserialize();

            //    if (tempDB is null)
            //    {
            //        throw new NoNullAllowedException("Error during deserialize. Success but null taked");
            //    }

            //    _db = tempDB;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);

            //    InserTestValues();
            //    try
            //    {
            //        _db.Serialize();
            //    }
            //    catch (Exception e)
            //    {
            //        MessageBox.Show(e.Message);
            //    }
            //}
            //finally
            //{
            //    _controller = new ProductsController(_db, productsDataGrid);
            //    _controller.UpdateDataGrid(_db);
            //}

        }


        private void ThemeChange(object sender, SelectionChangedEventArgs e) 
        {
            string style = ThemeCombobox.SelectedItem as string;

            var uri = new Uri("assets/resources/" + style + ".xaml", UriKind.Relative);
            // загружаем словарь ресурсов
            ResourceDictionary greenStyle = Application.LoadComponent(new Uri("/assets/resources/green.xaml", UriKind.Relative)) as ResourceDictionary;
            ResourceDictionary purpleStyle = Application.LoadComponent(new Uri("/assets/resources/green.xaml", UriKind.Relative)) as ResourceDictionary;


            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            // очищаем коллекцию ресурсов приложения
            Application.Current.Resources.MergedDictionaries.Remove(greenStyle);
            Application.Current.Resources.MergedDictionaries.Remove(purpleStyle);
            // добавляем загруженный словарь ресурсов
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void InserTestValues() 
        {   
            _db.Add(new Sneaker(1, Sneaker.Brands.Nike, "Air force 1", "Some info1", 40, "белый", 229));
            _db.Add(new Sneaker(2, Sneaker.Brands.Nike, "Jordan 4 Retro", "Some info2", 42, "синий", 279));
            _db.Add(new Sneaker(3, Sneaker.Brands.Puma, "Rebound v6", "Some info3", 44, "черный", 359));
            _db.Add(new Sneaker(4, Sneaker.Brands.Adidas, "YEEZY 500", "Some info4", 46, "серый", 139));
            _db.Add(new Sneaker(5, Sneaker.Brands.Nike, "Air max 95", "Some info5", 42, "черный", 379));
            _db.Add(new Sneaker(6, Sneaker.Brands.Reebok, "Flexagon enegry TR 4", "Some info6", 41, "белый", 329));
            _db.Add(new Sneaker(7, Sneaker.Brands.Puma, "Caven 2.0", "Some info7", 42, "черный", 199));
            _db.Add(new Sneaker(8, Sneaker.Brands.Adidas, "Ultra Boost", "Some info8", 43, "красный", 199));
            _db.Add(new Sneaker(9, Sneaker.Brands.Reebok, "Nano X1", "Some info9", 44, "серый", 299));
            _db.Add(new Sneaker(10, Sneaker.Brands.Nike, "Air Zoom Pegasus 38", "Some info10", 45, "серый", 589));
            _db.Add(new Sneaker(11, Sneaker.Brands.Puma, "Ignite NXT", "Some info11", 46, "желтый", 159));
            _db.Add(new Sneaker(12, Sneaker.Brands.Adidas, "NMD R1", "Some info12", 40, "белый", 229));
            _db.Add(new Sneaker(13, Sneaker.Brands.Reebok, "Zig Kinetica II", "Some info13", 41, "белый", 199));
            _db.Add(new Sneaker(14, Sneaker.Brands.Nike, "Metcon 6", "Some info14", 42, "желтый", 329));
            _db.Add(new Sneaker(15, Sneaker.Brands.Puma, "RS-X3", "Some info15", 43, "серый", 299));
            _db.Add(new Sneaker(16, Sneaker.Brands.Adidas, "Stan Smith", "Some info16", 44, "белый", 439));
            _db.Add(new Sneaker(17, Sneaker.Brands.Reebok, "Club C 85", "Some info17", 45, "белый", 349));

        }


        private void Border_MouseDown(object sender, MouseButtonEventArgs e) 
        {
            if (e.ChangedButton == MouseButton.Left)  
            {
                this.DragMove();   
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is not Grid)
            {
                return;
            }

            if (e.ClickCount == 2) 
            { 
                if(this._isMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 900;
                    this.Height = 600;

                    _isMaximized= false;
                }
                else 
                {
                    this.WindowState = WindowState.Maximized;

                    _isMaximized = true;
                }
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this._db.Serialize();
            this.Close();
        }

        private void PumaButton_Click(object sender, RoutedEventArgs e)
        {
            _controller.Filter(Sneaker.Brands.Puma);
        }

        private void NikeButton_Click(object sender, RoutedEventArgs e)
        {
            _controller.Filter(Sneaker.Brands.Nike);
        }

        private void AdidasButton_Click(object sender, RoutedEventArgs e)
        {
            _controller.Filter(Sneaker.Brands.Adidas);
        }

        private void ReebokButton_Click(object sender, RoutedEventArgs e)
        {
            _controller.Filter(Sneaker.Brands.Reebok);
        }

        private void SizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex == -1)
            {
                return;
            }

            ushort size = Convert.ToUInt16(comboBox.SelectedItem);
            _controller.Filter(size:size);
        }

        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex == -1)
            {
                return;
            }

            string color = comboBox.SelectedItem.ToString();

            if (UILang.Language.DisplayName == "English")
            {
                color = Sneaker.TranslateColorNameToRus(color);
            }
                        
            
            _controller.Filter(color:color);
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            _controller.ResetFilterSettings();
            ColorComboBox.SelectedIndex = -1;
            PriceSlider.Value = PriceSlider.Maximum;
            SizeComboBox.SelectedIndex = -1;
        }

        private void PriceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider)sender;
            if (slider.Value == slider.Maximum)
            {
                return;
            }

            ushort value = Convert.ToUInt16(slider.Value);
            _controller.Filter(maxPrice: value);
        }

        private void productsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try 
            {
                Sneaker sneaker = (Sneaker)((TextBlock)e.OriginalSource).DataContext;
                OrderPage page = new OrderPage(sneaker);
                page.Show();
            } catch (Exception err) 
            {
                Console.WriteLine(err.Message);
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NewProduct newProduct = new NewProduct(_controller, database);
            newProduct.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Sneaker sneaker = (Sneaker)((Button)sender).DataContext;

            Invoker invoker = new Invoker();
            invoker.SetCommand(new ChangeProduct(new Receiver(_db.Db, database)));
            invoker.Run(sneaker);
            _controller.UpdateDataGrid(_controller.getDB);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Sneaker sneaker = (Sneaker)((Button)sender).DataContext;

            Invoker invoker = new Invoker();
            invoker.SetCommand(new RemoveProduct(new Receiver(_db.Db, database)));
            invoker.Run(sneaker);

            _controller.UpdateDataGrid(_db);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox) sender;

            CultureInfo info = new CultureInfo (comboBox.SelectedValue.ToString());
            UILang.Language = info;

            if (_controller != null) 
            {
                _controller.UpdateDataGrid(_db);
            }

        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            string value = textBox.Text;

            _controller.Filter(name:value);

        }

        private Invoker getLastInvoker() 
        {
            Invoker inv;
            Memory.lastCommand.TryPeek(out inv);

            return inv;
        }


        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try 
            {
                Invoker invoker = getLastInvoker();

                invoker.Cancel();
            } 
            catch { }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                Invoker invoker = getLastInvoker();

                invoker.Run(Memory.lastSneaker.Pop());
            } 
            catch { }

        }
    }
}