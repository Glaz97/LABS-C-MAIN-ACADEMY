using Part_2_LabWork_5._5.Models;
using System.Data.Entity;

namespace Part_2_LabWork_5._5
{
    public class DBContext : DbContext
    {
        public DBContext() : base("BookDB") { }

        public DbSet<BookModel> Books { get; set; }
    }
}