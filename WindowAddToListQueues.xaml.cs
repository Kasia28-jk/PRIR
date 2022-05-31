using System.Windows;
using WpfApp1.Data;

namespace WpfApp1
{
    public partial class WindowAddToListQueues : Window
    {
        private readonly DataContext _dataContext;
        private readonly QueueProvider _queueProvider;
        public WindowAddToListQueues(DataContext dataContext)
        {
            InitializeComponent();
            _dataContext = dataContext;
            _queueProvider = new QueueProvider(_dataContext);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var queueToAdd = txt_NameOfQueue.Text;
            var status = _queueProvider.AddQueue(queueToAdd);

            if (!status)
            {
                MessageBox.Show("Taka nazwa już istnieje!");
            }
            else
            {
                MessageBox.Show("Dodano!");
            }
        }
    }
}
