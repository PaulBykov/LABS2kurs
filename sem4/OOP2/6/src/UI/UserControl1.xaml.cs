using System.Windows;
using System.Windows.Controls;


namespace _4.src.UI
{
    public partial class UserControl1 : UserControl
    {
        public static readonly DependencyProperty CountProperty =
        DependencyProperty.Register("Count", typeof(int), typeof(UserControl1), new PropertyMetadata(0, CountPropertyChanged, CountCoerceValue));


        public UserControl1()
        {
            InitializeComponent();
        }


        public int Count
        {
            get { return (int)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }


        private static bool CountValidateValue(object value)
        {
            int val = (int)value;
            return val >= 0; // Простая валидация, считаем что значение не может быть отрицательным
        }

        private static void CountPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl1 userControl = (UserControl1)d;
            userControl.onValueChange();
        }

        private static object CountCoerceValue(DependencyObject d, object baseValue)
        {
            if (!CountValidateValue(baseValue)) { return 0; }

            return (int) baseValue;
        }
        

        private void onValueChange()
        {
            Counter_value.Text = Count.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Count++;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Count--;
        }
    }
}
