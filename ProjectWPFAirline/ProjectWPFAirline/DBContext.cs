using System.Data.Entity;

namespace ProjectWPFAirline
{
    public class DBContext : DbContext
    {
        public DBContext() : base("AiroportDB") { }

        public DbSet<AirflightsModel> Airflights { get; set; }
        public DbSet<PassengerModel> Passengers { get; set; }
        public DbSet<PriceListModel> PriceList { get; set; }
    }
}
