using System.Collections.Generic;
using System.Linq;
using WpfApp1.Data;
using WpfApp1.Models;

namespace WpfApp1
{
    public class TaskProvider
    {
        private readonly DataContext _dataContext;
        public TaskProvider(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Zadanie> ZaladujListe()
        {
            var zadania = _dataContext.Zadanies.Select(x=>x).ToList();
            return zadania;
        }
    }
}
