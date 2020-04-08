using Part_2_LabWork_5._3.DataModels;
using System.Data.Entity;

namespace Part_2_LabWork_5._3
{
    public class DBContext : DbContext
    {
        public DBContext() : base("BookDB") { }
        public DbSet<DbBookModel> Books { get; set; }

        static DBContext()
        {
            Database.SetInitializer(new ContextInitializer());
        }
    }

    class ContextInitializer : DropCreateDatabaseAlways<DBContext>
    {
        protected override void Seed(DBContext db)
        {
            db.Books.Add(new DbBookModel { BookName = "Samsung Galaxy S5", Author = "Vasya", Edition = "XL", Publishing = "1983" });
            db.Books.Add(new DbBookModel { BookName = "Nokia Lumia 630", Author = "Vasya", Edition = "XXL", Publishing = "1984" });
            db.SaveChanges();
        }
    }
}