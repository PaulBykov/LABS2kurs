using System.Windows.Input;

namespace _4.src.UI
{
    public static class CustomCommands
    {
        public static RoutedUICommand MyCustomCommand { get; } = new RoutedUICommand("My Custom Command", "MyCustomCommand", typeof(CustomCommands));
    }

}
