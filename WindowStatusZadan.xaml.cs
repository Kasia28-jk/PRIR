using System;
using System.Windows;
using WpfApp1.Data;
using WpfApp1.Message;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy WindowStatusZadan.xaml
    /// </summary>
    public partial class WindowStatusZadan : Window
    {
        private readonly DataContext _dataContext;
        private readonly MessageProvider _messageProvider;
        private readonly TaskProvider _taskProvider;
        private readonly DatabaseHelper _databaseHelper;
        private readonly bool _isNewConfiguration;
        private int _idConfiguracji;

        public WindowStatusZadan(DataContext dataContext, bool isNewConfiguration, int idConfiguracji)
        {
            InitializeComponent();
            _dataContext = dataContext;
           _databaseHelper = new DatabaseHelper(_dataContext);
           _taskProvider = new TaskProvider(_dataContext);
            _isNewConfiguration = isNewConfiguration;
            _idConfiguracji = idConfiguracji;
            _messageProvider = new MessageProvider(_isNewConfiguration, _idConfiguracji, _dataContext);
            LoadData();
        }

        private void LoadData()
        {
            _messageProvider.ReadMessage();
            statusZadan.ItemsSource = _taskProvider.ZaladujListe();
        }


        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            int id = 0;
            try
            {
                id = Int32.Parse(txtIdZadania.Text);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            _databaseHelper.UsunZadanie(id);
            LoadData();
            statusZadan.ItemsSource = _taskProvider.ZaladujListe();
        }
    }
}
