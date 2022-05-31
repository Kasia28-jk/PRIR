using System.Linq;
using WpfApp1.Models;

namespace WpfApp1.Data
{
    public class DatabaseHelper
    {
        private readonly DataContext _dataContext;

        public DatabaseHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AddToDataBase(Zadanie zadanie)
        {
            _dataContext.Zadanies.Add(zadanie);
            _dataContext.SaveChanges();
        }

        public int CheckIdForZadanias(Zadanie zadanie)
        {
            var zadForId = _dataContext.Zadanies.FirstOrDefault(x => x.NazwaZadania.Equals(zadanie.NazwaZadania)
                                                                     && x.WartośćDoPoliczenia.Equals(zadanie.WartośćDoPoliczenia)
                                                                     && x.status.Equals(false));
            return zadForId.ZadanieId;
        }

        public void AddConfiguration(Konfiguracja konfiguracja)
        {
            _dataContext.Konfiguracjas.Add(konfiguracja);
            _dataContext.SaveChanges();
        }

        public int CheckIdForKonfiguracjas(Konfiguracja konfiguracja)
        {
            var zadForId = _dataContext.Konfiguracjas.FirstOrDefault(x => x.NazwaKolejki.Equals(konfiguracja.NazwaKolejki)
            && x.Hasło.Equals(konfiguracja.Hasło) && x.HostName.Equals(konfiguracja.HostName)
            && x.NazwaUzytkownika.Equals(konfiguracja.NazwaUzytkownika) && x.Port.Equals(konfiguracja.Port)
            && x.VHostName.Equals(konfiguracja.VHostName));
            return zadForId.KonfiguracjaId;
        }

        public Konfiguracja FindConfiguration(int id)
        {
            var konfiguracja = _dataContext.Konfiguracjas.FirstOrDefault(x => x.KonfiguracjaId.Equals(id));
            return konfiguracja;
        }
    }
}
