using System.Collections.Generic;
using System.IO;

namespace WpfApp1
{
    public class QueueProvider
    {
        private List<string> _queues = new List<string>();
        public List<string> Queues { get => _queues; set => _queues = value; }

        public bool AddQueue(string nameOfQueue)
        {
            var list = LoadList();
            var state = true;
            if (list != null)
            {
                foreach (var name in list)
                {
                    if (nameOfQueue.Equals(name))
                    {
                        state = false;
                    }
                }

                if (!state) return false;
                _queues.Add(nameOfQueue);
                SaveInFile();
                return true;

            }

            return false;
        }

        public List<string> LoadList()
        {
            using (var sr = new StreamReader("queues.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    _queues.Add(line);
                }
            }
            return _queues;
        }

        private void SaveInFile()
        {
            using (var sw = new StreamWriter("queues.txt"))
            {
                foreach (var queue in _queues)
                {
                  sw.WriteLine(queue);  
                }
            }
        }
    }
}
