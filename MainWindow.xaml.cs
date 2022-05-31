using System.Windows;
using WpfApp1.Data;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private readonly DataContext _context;
        public MainWindow()
        {
            InitializeComponent();
            _context = new DataContext();
        }
       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var win = new WindowFibonacci(_context);
            win.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var win = new WindowIsPrime(_context);
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
