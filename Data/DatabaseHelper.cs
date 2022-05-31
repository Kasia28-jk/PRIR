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

        public int CheckId(Zadanie zadanie)
        {
            var zadForId = _dataContext.Zadanies.FirstOrDefault(x => x.NazwaZadania.Equals(zadanie.NazwaZadania)
                                                                     && x.WartośćDoPoliczenia.Equals(zadanie.WartośćDoPoliczenia)
                                                                     && x.status.Equals(false));
            return zadForId.ZadanieId;
        }
    }
}
