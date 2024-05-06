using _9.Model.Interfaces;
using System.Globalization;
using System.Windows;


namespace _9
{
    public partial class AddRate : Window
    {
        IRateRepository repository;

        public AddRate(IRateRepository context, Rate rate = null)
        {
            InitializeComponent();

            repository = context;

            if(rate != null ) 
            {
                nameTextbox.Text = rate.RateName;
                multiTextbox.Text = rate.Multiplier.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            repository.Add(new Rate() { RateId = 1, RateName=nameTextbox.Text, Multiplier=float.Parse(multiTextbox.Text, NumberStyles.Any, CultureInfo.InvariantCulture)});

            this.Close();
        }
    }
}
