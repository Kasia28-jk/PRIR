using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class Konfiguracja
    {
        public int KonfiguracjaId { get; set; }
        public string NazwaUzytkownika { get; set; }
        public string Hasło { get; set; }
        public string HostName { get; set; }
        public string VHostName { get; set; }
        public int Port { get; set; }
        public string NazwaKolejki { get; set; }
    }
}
