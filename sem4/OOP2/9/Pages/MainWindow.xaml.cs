using _9.Model.Interfaces;
using _9.Model.Repository;
using System.Collections.ObjectModel;
using System.Windows;


namespace _9
{
    public partial class MainWindow : Window
    {
        private readonly IComputerRepository computerRepository;
        private readonly IRateRepository rateRepository;

        public MainWindow()
        {
            InitializeComponent();

            this.computerRepository = new ComputerRepository(new ClubContext());
            this.rateRepository = new RateRepository(new ClubContext());

            RefreshData();
        }

        private void RefreshData()
        {
            dataGrid.ItemsSource = new ObservableCollection<Computer>(computerRepository.GetAll());
            dataGridRates.ItemsSource = new ObservableCollection<Rate>(rateRepository.GetAll());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddComputer addComputer = new AddComputer(computerRepository, rateRepository);
            addComputer.Show();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            AddRate addRate = new AddRate(rateRepository);
            addRate.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Computer selectedComputer = (Computer)dataGrid.SelectedItem;
            if (selectedComputer != null)
            {
                computerRepository.Delete(selectedComputer);
                RefreshData();
            }
            else
            {
                MessageBox.Show("Выберите компьютер для удаления.");
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Computer selectedComputer = (Computer)dataGrid.SelectedItem;

            if (selectedComputer != null)
            {
                AddComputer editWindow = new AddComputer(computerRepository, rateRepository, selectedComputer);
                editWindow.ShowDialog();
                RefreshData();
            }
            else
            {
                MessageBox.Show("Выберите компьютер для изменения.");
            }
        }

        private void DeleteButtonRate_Click(object sender, RoutedEventArgs e)
        {
            Rate selectedRate = (Rate)dataGridRates.SelectedItem;
            if (selectedRate != null)
            {
                rateRepository.Delete(selectedRate);
                RefreshData();
            }
            else
            {
                MessageBox.Show("Выберите тариф для удаления.");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Rate selectedRate = (Rate)dataGridRates.SelectedItem;
            if (selectedRate != null)
            {
                rateRepository.Delete(selectedRate);
                AddRate editWindow = new AddRate(rateRepository, selectedRate);
                editWindow.ShowDialog();
                RefreshData();
            }
            else
            {
                MessageBox.Show("Выберите тариф для изменения.");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var service = new RentalService(new ClubContext());
            Computer computer = (Computer) dataGrid.SelectedItem;
            service.RentComputer(computer);
            RefreshData();
        }
    }
}
