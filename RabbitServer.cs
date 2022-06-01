using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Diagnostics;
using System.Text;
using System.Threading;
using WpfApp1.Data;

namespace WpfApp1
{
    public class RabbitServer
    {
        private readonly bool _isNewConfiguration;
        private int _idConfiguracji;
        private readonly DatabaseHelper _databaseHelper;
        private readonly DataContext _dataContext;
        protected volatile AutoResetEvent semaphore = new AutoResetEvent(true);
        

        public RabbitServer(bool isNewConfiguration, int idConfiguracji, DataContext dataContext)
        {
            _isNewConfiguration = isNewConfiguration;
            _idConfiguracji = idConfiguracji;
            _dataContext = dataContext;
            _databaseHelper = new DatabaseHelper(_dataContext);
        }

        private string _queueName = "test1";

        public string QueueName
        {
            get => _queueName;
            set => _queueName = value;
        }

        public void SendMessage(string message)
        {
            if (!_isNewConfiguration || _idConfiguracji == 1)
            {
                var factory = new ConnectionFactory()
                {
                    HostName = "localhost"
                };

                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                        channel.BasicPublish("", _queueName, null, body);
                    }
                }
            }
            else
            {
                var konfiguracja = _databaseHelper.FindConfiguration(_idConfiguracji);

                var factory = new ConnectionFactory()
                {
                    HostName = konfiguracja.HostName,
                };

                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                        channel.BasicPublish("", _queueName, null, body);
                    }
                }
            }
        }

        public void GetMessages()
        {
            var flagStop = false;
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //Ustawienie maksymalnej ilości przerabianych wiadomości
                    channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: true);
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += Consumer_Received;
                    channel.BasicConsume(queue: "res", autoAck: true, consumer: consumer);
                    while (!flagStop)
                    {
                        semaphore.WaitOne(-1, true);
                        if (flagStop) break;
                    }
                }
            }
        }

        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            //Powiadomienie, że zaczęto operacje na wiadomości
            //Odbieranie wiadomości
            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            message = message.Trim(new char[] { '"' });
            message = ReadDataFromMessage(message);
            Debug.WriteLine(message);
            semaphore.Set();
        }

        private string ReadDataFromMessage(string message)
        {
            int i;
            bool status;
            if (message.Length != 0)
            {
                i = 0;
                status = false;
                message = message.ToLower();
                foreach (var letter in message)
                {
                    if (letter.ToString() == "n")
                    {
                        status = false;
                        break;
                    }

                    if (letter.ToString() == "p")
                    {
                        status = true;
                        break;
                    }

                    i++;
                }

                var idTaska = message.Substring(0, i - 1); //i - 1 (odcinamy spacje)
                _databaseHelper.UpdateTaskow(idTaska, status);
            }

            return message;
        }
    }
}
