using System.Windows;
using System.Windows.Controls;

namespace _4.src.UI
{
    public partial class UserControl2 : UserControl
    {
        public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(int), typeof(UserControl2), new PropertyMetadata(0, ValuePropertyChanged, ValueCoerceValue));

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly RoutedEvent DirectEvent = EventManager.RegisterRoutedEvent(
            "DirectClick", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(UserControl2));

        public static readonly RoutedEvent TunnelingEvent = EventManager.RegisterRoutedEvent(
            "TunnelingClick", RoutingStrategy.Tunnel, typeof(RoutedEventHandler), typeof(UserControl2));

        public static readonly RoutedEvent BubblingEvent = EventManager.RegisterRoutedEvent(
            "BubblingClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UserControl2));

        public event RoutedEventHandler DirectClick
        {
            add { AddHandler(DirectEvent, value); }
            remove { RemoveHandler(DirectEvent, value); }
        }

        public event RoutedEventHandler TunnelingClick
        {
            add { AddHandler(TunnelingEvent, value); }
            remove { RemoveHandler(TunnelingEvent, value); }
        }

        public event RoutedEventHandler BubblingClick
        {
            add { AddHandler(BubblingEvent, value); }
            remove { RemoveHandler(BubblingEvent, value); }
        }

        public UserControl2()
        {
            InitializeComponent();
        }

        private static bool ValueValidateValue(object value)
        {
            int val = (int)value;
            return val >= 0; // Простая валидация, считаем что значение не может быть отрицательным
        }

        private static void ValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl2 userControl = (UserControl2)d;
            userControl.onValueChange();
        }

        private static object ValueCoerceValue(DependencyObject d, object baseValue)
        {
            if (!ValueValidateValue(baseValue)) { return 0; }
            
            return (int)baseValue;
        }

        private void onValueChange()
        {
            Counter_value.Text = Value.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Value++;

            // Генерация событий разных типов маршрутизации
            RoutedEventArgs args = new RoutedEventArgs(DirectEvent);
            RaiseEvent(args);

            args = new RoutedEventArgs(TunnelingEvent);
            RaiseEvent(args); // Происходит туннелирование события

            args = new RoutedEventArgs(BubblingEvent);
            RaiseEvent(args); // Происходит всплытие события
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Value--;

            // Генерация событий разных типов маршрутизации
            RoutedEventArgs args = new RoutedEventArgs(DirectEvent);
            RaiseEvent(args);

            args = new RoutedEventArgs(TunnelingEvent);
            RaiseEvent(args); // Происходит туннелирование события

            args = new RoutedEventArgs(BubblingEvent);
            RaiseEvent(args); // Происходит всплытие события
        }
    }
}
