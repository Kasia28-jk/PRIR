using System;
using System.Collections.Generic;
using System.Windows;
using WpfApp1.Data;
using WpfApp1.Message;
using WpfApp1.Models;

namespace WpfApp1
{
    public partial class WindowFibonacci : Window
    {
        private QueueProvider _queueProvider;
        private List<string> _queueToDisplay;
        private readonly DataContext _dataContext;
        private readonly MessageProvider _messageProvider;
        private readonly DatabaseHelper _databaseHelper;

        public WindowFibonacci(DataContext dataContext)
        {
            InitializeComponent();
            _dataContext = dataContext;
            _messageProvider = new MessageProvider();
            _databaseHelper = new DatabaseHelper(_dataContext);
            _queueProvider = new QueueProvider(_dataContext);
            _queueToDisplay = _queueProvider.LoadList();
            cmb_Queues.ItemsSource = _queueToDisplay;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var queue = (string)cmb_Queues.SelectedItem;
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

            var zadanie = new Zadanie()
            {
                NazwaZadania = name,
                WartośćDoPoliczenia = value,
                status = false
            };

            _databaseHelper.AddToDataBase(zadanie);
            var id = _databaseHelper.CheckId(zadanie);
            _messageProvider.SendMessage(id, name, value, queue);

        }
    }
}
