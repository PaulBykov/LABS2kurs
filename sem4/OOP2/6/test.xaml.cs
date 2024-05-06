using _4.src.UI;
using System.Windows;
using System.Windows.Input;

namespace _4
{
    /// <summary>
    /// Логика взаимодействия для test.xaml
    /// </summary>
    public partial class test : Window
    {
        public test()
        {
            InitializeComponent();

            CommandBindings.Add(new CommandBinding(CustomCommands.MyCustomCommand, MyCustomCommand_Executed, MyCustomCommand_CanExecute));
        }

        private void MyCustomCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Здесь вы определяете, может ли команда выполняться в текущем контексте
            e.CanExecute = true; // В данном случае всегда разрешаем выполнение команды
        }

        private void MyCustomCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Здесь вы определяете логику выполнения команды
            MessageBox.Show("My Custom Command Executed!");
        }
    }
}
