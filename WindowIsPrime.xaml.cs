using System;
using System.Windows;

namespace WpfApp1
{
    public partial class WindowIsPrime : Window
    {
        public WindowIsPrime()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
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
            connection.SendMessage(message);
        }
    }
}
