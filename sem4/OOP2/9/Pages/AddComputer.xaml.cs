using _9.Model.Interfaces;
using System.Collections.Generic;
using System.Windows;


namespace _9
{
    public partial class AddComputer : Window
    {
        IComputerRepository repository;
        IRateRepository rateRepository;

        public AddComputer(IComputerRepository context, IRateRepository rateRepository, Computer computer = null)
        {
            InitializeComponent();

            this.rateRepository = rateRepository;
            repository = context;


            var list = getHashSet();
            ratesCombobox.ItemsSource = list;

            if(computer != null)
            {
                IsFreeCheckBox.IsChecked = computer.IsFree;
                ratesCombobox.SelectedIndex = computer.RateId - 1;
            }
        }

        private Rate rateByID(int id) 
        {
            foreach (Rate rate in ratesCombobox.ItemsSource) 
            {
                if(rate.RateId == id)
                {
                    return rate;
                }

            }

            return null;
        }

        private HashSet<string> getHashSet() 
        {
            HashSet<string> list = new HashSet<string>();
            foreach (var rate in rateRepository.GetAll())
            {
                list.Add(rate.RateName);
            }

            return list;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isChecked = (bool)IsFreeCheckBox.IsChecked;
            var rate = ratesCombobox.SelectedItem as string;


            Rate oldRate = null;
            try
            {
                var List = rateRepository.GetAll();
                
                foreach(var elem in List)
                {
                    if(elem.RateName == rate) 
                    {
                        oldRate = elem;
                    }
                }
            }
            catch {
                MessageBox.Show("No such rate!"); return;
            }

            if(rate == null) { MessageBox.Show("No such rate!"); return; }

            Computer c = new Computer(){ ComputerId = 1, IsFree=isChecked, Rate = oldRate, RateId = oldRate.RateId};
            repository.Add(c);

            this.Close();
        }
    }
}
