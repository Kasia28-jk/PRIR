using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WpfApp1
{
    internal class DataContext : DbContext
    {
        public DbSet<Zadanie> Zadanies { get; set; }
    }
}
