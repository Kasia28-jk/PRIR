using System.Collections.Generic;
using System.Linq;
using WpfApp1.Data;
using WpfApp1.Models;

namespace WpfApp1
{
    public class QueueProvider
    {
        private readonly DataContext _dataContext;
        private List<string> _queues = new List<string>();
        public List<string> Queues { get => _queues; set => _queues = value; }

        public QueueProvider(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool AddQueue(string nameOfQueue)
        {
            var queue = _dataContext.Kolejkas.SingleOrDefault(x => x.NazwaKolejki.Equals(nameOfQueue));
            var state = false;

            if (queue == null)
            {
                var newQueue = new Kolejka()
                {
                    NazwaKolejki = nameOfQueue
                };

                _dataContext.Kolejkas.Add(newQueue);
                _dataContext.SaveChanges();
                state = true;
            }

            return state;
        }

        public List<string> LoadList()
        {
            var kolejki = _dataContext.Kolejkas.Select(x => CreateQueue(x)).ToList();
            _queues = kolejki;
            return _queues;
        }

        private static string CreateQueue(Kolejka x)
        {
            return x.NazwaKolejki;
        }
    }
}
