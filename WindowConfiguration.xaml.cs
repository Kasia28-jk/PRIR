using System;
using System.Collections.Generic;
using System.Windows;
using WpfApp1.Data;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy WindowConfiguration.xaml
    /// </summary>
    public partial class WindowConfiguration : Window
    {
        private readonly DataContext _dataContext;
        private readonly DatabaseHelper _databaseHelper;
        private QueueProvider _queueProvider;
        private List<string> _queueToDisplay;
        private bool _IsNewConfiguration;
        private int _idConfiguracji;

        public WindowConfiguration(DataContext dataContext)
        {
            InitializeComponent();
            _dataContext = dataContext;
            _databaseHelper = new DatabaseHelper(_dataContext);
            _queueProvider = new QueueProvider(_dataContext);
            _queueToDisplay = _queueProvider.LoadList();
            cmb_Queues.ItemsSource = _queueToDisplay;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var nazwaUzytkownika = txt_UserName.Text;
            var haslo = txt_Password.Text;
            var hostname = txt_HostName.Text;
            var vhostname= txt_VHostName.Text;
            int port;
            try
            {
                port = Convert.ToInt32(txt_Port.Text);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            var nazwaKolejki = (string)cmb_Queues.SelectedItem;

            var konfiguracja = new Konfiguracja()
            {
                NazwaUzytkownika = nazwaUzytkownika,
                Hasło = haslo,
                HostName = hostname,
                VHostName = vhostname,
                Port = port,
                NazwaKolejki = nazwaKolejki
            };

            _databaseHelper.AddConfiguration(konfiguracja);
            _IsNewConfiguration = true;
            _idConfiguracji = _databaseHelper.CheckIdForKonfiguracjas(konfiguracja);
        }

        public bool IsNewKonfiguration()
        {
            return _IsNewConfiguration;
        }

        public int idOfConfiguration()
        {
            if (_idConfiguracji != null)
            {
                return _idConfiguracji;
            }

            return 1; //domyslne 
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            _IsNewConfiguration = false;
        }
    }
}
