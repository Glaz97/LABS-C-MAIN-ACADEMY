using ProjectAiroportASP_NET.Models;
using System.Data.Entity;

namespace ProjectAiroportASP_NET
{
    public class DBContext : DbContext
    {
        public DBContext() : base("AiroportDB") { }

        public DbSet<Airflights> Airflights { get; set; }
        public DbSet<AirflightPassenger> Passengers { get; set; }
        public DbSet<AirflightPriceList> PriceList { get; set; }
    }
}