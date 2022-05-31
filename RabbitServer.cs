using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using WpfApp1.Data;

namespace WpfApp1
{
    public class RabbitServer
    {
        private readonly bool _isNewConfiguration;
        private int _idConfiguracji;
        private readonly DatabaseHelper _databaseHelper;
        public RabbitServer(bool isNewConfiguration, int idConfiguracji, DatabaseHelper databaseHelper)
        {
            _isNewConfiguration = isNewConfiguration;
            _idConfiguracji = idConfiguracji;
            _databaseHelper = databaseHelper;
        }
        private string _queueName = "test1";
        public string QueueName { get => _queueName; set => _queueName = value; }

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
    }
}
