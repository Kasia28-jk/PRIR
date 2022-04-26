using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace WpfApp1
{
    public class RabbitServer
    {
        private const string QueueName = "test1";

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

                    channel.BasicPublish("", QueueName, null, body);
                }
            }
        }
    }
}
