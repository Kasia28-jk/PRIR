namespace WpfApp1
{
    public class MessageProvider
    {
        public void SendMessage(int id, string name, int value, string queue)
        {
            var message = id + " " + name + value;
            var connection = new RabbitServer();
            if (queue != null)
            {
                connection.QueueName = queue;
            }
            connection.SendMessage(message);
        }
    }
}
