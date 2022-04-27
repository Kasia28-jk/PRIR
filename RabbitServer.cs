using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace WpfApp1
{
    public class RabbitServer
    {
        private string _queueName = "test1";
        public string QueueName { get => _queueName; set => _queueName = value; }

        public void SendMessage(string message)
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
    }
}
