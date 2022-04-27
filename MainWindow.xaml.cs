using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var win = new WindowFibonacci();
            win.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var win = new WindowIsPrime();
            win.Show();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            var win = new WindowAddToListQueues();
            win.Show();
        }

        private void Button_Click_Config(object sender, RoutedEventArgs e)
        {
            var win = new WindowConfiguration();
            win.Show();
        }
    }
}
