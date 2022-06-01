using System.Windows;
using WpfApp1.Data;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private readonly DataContext _context;
        private bool _isNewConfiguration;
        private int _idConfiguracji;
        private WindowConfiguration _windowConfiguration;
        public MainWindow()
        {
            InitializeComponent();
            _context = new DataContext();
            _windowConfiguration = new WindowConfiguration(_context);
            _isNewConfiguration = _windowConfiguration.IsNewKonfiguration();
            _idConfiguracji = _windowConfiguration.idOfConfiguration();
        }
       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _isNewConfiguration = _windowConfiguration.IsNewKonfiguration();
            _idConfiguracji = _windowConfiguration.idOfConfiguration();
            var win = new WindowFibonacci(_context, _isNewConfiguration, _idConfiguracji);
            win.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
             _isNewConfiguration = _windowConfiguration.IsNewKonfiguration();
            _idConfiguracji = _windowConfiguration.idOfConfiguration();
            var win = new WindowIsPrime(_context, _isNewConfiguration, _idConfiguracji);
            win.Show();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            var win = new WindowAddToListQueues(_context);
            win.Show();
        }

        private void Button_Click_Config(object sender, RoutedEventArgs e)
        {
            var win = new WindowConfiguration(_context);
            win.Show();
        }

        private void Button_Click_StatusZadan(object sender, RoutedEventArgs e)
        {
            var win = new WindowStatusZadan(_context, _isNewConfiguration, _idConfiguracji);
            win.Show();
        }
    }
}
