using Final_X_Project.Models;
using System.Data.Entity;

namespace Final_X_Project
{
    public class DBContext : DbContext
    {
        public DBContext() : base("XDatabase") { }

        public DbSet<Orders> Orders { get; set; }
        public DbSet<PizzaRestaurants> PizzaRestaurants { get; set; }
        public DbSet<PizzasNomenclature> PizzasNomenclature { get; set; }
        public DbSet<PizzaUsers> PizzaUsers { get; set; }
        public DbSet<UsersContactData> UsersContactData { get; set; }
        public DbSet<UsersVacancies> UsersVacancies { get; set; }
    }
}