using System;
using System.Windows;

namespace WpfApp1
{
    public partial class WindowFibonacci : Window
    {
        public WindowFibonacci()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int value;
            const string name = "Fibonacci ";
            try
            { 
                value = Convert.ToInt32(txt_NumberOfSequence.Text);
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
