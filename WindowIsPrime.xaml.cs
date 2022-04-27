using System;
using System.Collections.Generic;
using System.Windows;

namespace WpfApp1
{
    public partial class WindowIsPrime : Window
    {
        private QueueProvider _queueProvider = new();
        private List<string> _queueToDisplay;
        public WindowIsPrime()
        {
            InitializeComponent();
            _queueToDisplay = _queueProvider.LoadList();
            cmb_Queues.ItemsSource = _queueToDisplay;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var queue = (string)cmb_Queues.SelectedItem;
            int value;
            const string name = "Prime ";
            try
            {
                value = Convert.ToInt32(txt_NumberToCheck.Text);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

            var message = name + value;
            var connection = new RabbitServer();
            if (queue != null)
            {
                connection.QueueName = queue;
            }
            connection.SendMessage(message);
        }
    }
}
