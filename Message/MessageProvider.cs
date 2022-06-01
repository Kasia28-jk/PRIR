using System.Threading;
using WpfApp1.Data;

namespace WpfApp1.Message
{
    public class MessageProvider
    {
        private readonly bool _isNewConfiguration;
        private int _idConfiguracji;
        private readonly DatabaseHelper _databaseHelper;
        private readonly DataContext _dataContext;

        public MessageProvider(bool isNewConfiguration, int idConfiguracji, DataContext dataContext)
        {
            _isNewConfiguration = isNewConfiguration;
            _idConfiguracji = idConfiguracji;
            _dataContext = dataContext;
            _databaseHelper = new DatabaseHelper(_dataContext);

        }

        public void SendMessage(int id, string name, int value, string queue)
        {
            var message = id + " " + name + value;
            var connection = new RabbitServer(_isNewConfiguration, _idConfiguracji, _dataContext);
            if (queue != null)
            {
                connection.QueueName = queue;
            }
            connection.SendMessage(message);
        }

        public void ReadMessage()
        {
            var connection = new RabbitServer(_isNewConfiguration, _idConfiguracji, _dataContext);
            var thread = new Thread(() => connection.GetMessages());
            thread.Start();
        }
    }
}
