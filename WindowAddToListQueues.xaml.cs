using System.Windows;
namespace WpfApp1
{
    public partial class WindowAddToListQueues : Window
    {
        public WindowAddToListQueues()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var queueToAdd = txt_NameOfQueue.Text;
            var queue = new QueueProvider();
            var status = queue.AddQueue(queueToAdd);
            if (!status)
            {
                MessageBox.Show("Taka nazwa już istnieje!");
            }
            MessageBox.Show("Dodano!");
        }
    }
}
