using System.IO;

namespace WpfApp1
{
    public class ConfigServer
    {
        private string _rabitMQ_UserName;
        private string _rabitMQ_Password;
        private string _rabitMQ_VirualHost;
        private string _rabitMQ_HostName;
        private int _rabitMQ_Port = 0;
        private string _rabitMQ_QueueRecive;

        public string UserName { get => _rabitMQ_UserName; set => _rabitMQ_UserName = value; }
        public string Password { get => _rabitMQ_Password; set => _rabitMQ_Password = value; }
        public string VirualHost { get => _rabitMQ_VirualHost; set => _rabitMQ_VirualHost = value; }
        public string HostName { get => _rabitMQ_HostName; set => _rabitMQ_HostName = value; }
        public string QueueRecive { get => _rabitMQ_QueueRecive; set => _rabitMQ_QueueRecive = value; }
        public int Port { get => _rabitMQ_Port; set => _rabitMQ_Port = value; }

        public void SaveConfiguration()
        {
            using var sw = new StreamWriter("config.cfg");
            sw.WriteLine("RabitMQ UserName= " + UserName);
            sw.WriteLine("RabitMQ Password= " + Password);
            sw.WriteLine("RabitMQ VHostName= " + VirualHost);
            sw.WriteLine("RabitMQ HostName= " + HostName);
            sw.WriteLine("RabitMQ Port= " + Port);
            sw.WriteLine("Nazwa kolejki z zadaniami= " + QueueRecive);
        }
    }
}
