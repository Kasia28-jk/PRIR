using WpfApp1.Data;

namespace WpfApp1.Message
{
    public class MessageProvider
    {
        private readonly bool _isNewConfiguration;
        private int _idConfiguracji;
        private readonly DatabaseHelper _databaseHelper;

        public MessageProvider(bool isNewConfiguration, int idConfiguracji, DatabaseHelper databaseHelper)
        {
            _isNewConfiguration = isNewConfiguration;
            _idConfiguracji = idConfiguracji;
            _databaseHelper = databaseHelper;
        }

        public void SendMessage(int id, string name, int value, string queue)
        {
            var message = id + " " + name + value;
            var connection = new RabbitServer(_isNewConfiguration, _idConfiguracji, _databaseHelper);
            if (queue != null)
            {
                connection.QueueName = queue;
            }
            connection.SendMessage(message);
        }
    }
}
