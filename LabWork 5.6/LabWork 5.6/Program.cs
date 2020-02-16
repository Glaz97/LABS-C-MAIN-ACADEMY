using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.IO;

namespace LabWork_5._6
{
    [Table("Customers")]
    public class Customers
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerDetails { get; set; }

        public Customers() { }

        public Customers(string CustomerName, string CustomerSurname, string CustomerPhone, string CustomerEmail, string CustomerDetails)
        {
            this.CustomerName = CustomerName;
            this.CustomerSurname = CustomerSurname;
            this.CustomerPhone = CustomerPhone;
            this.CustomerEmail = CustomerEmail;
            this.CustomerDetails = CustomerDetails;
        }

        public Customers(int CustomerID, string CustomerName, string CustomerSurname, string CustomerPhone, string CustomerEmail, string CustomerDetails)
        {
            this.CustomerID = CustomerID;
            this.CustomerName = CustomerName;
            this.CustomerSurname = CustomerSurname;
            this.CustomerPhone = CustomerPhone;
            this.CustomerEmail = CustomerEmail;
            this.CustomerDetails = CustomerDetails;
        }

        public void ReadAllCustomers(DbSet<Customers> customers)
        {
            foreach (Customers c in customers)
            {
                Console.WriteLine("{0}.{1}-{2}", c.CustomerID, c.CustomerName, c.CustomerSurname);
            }
        }
    }

    [Table("Orders")]
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int OrderStatus { get; set; }
        public string OrderDetails { get; set; }
        public DateTime OrderDate { get; set; }

        public Orders() { }

        public Orders(int CustomerID, int OrderStatus, string OrderDetails, DateTime OrderDate)
        {
            this.CustomerID = CustomerID;
            this.OrderStatus = OrderStatus;
            this.OrderDetails = OrderDetails;
            this.OrderDate = OrderDate;
        }
    }

    [Table("OrderList")]
    public class OrderList
    {
        [Key]
        public int OrderListID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int ProductQuantity { get; set; }

        public OrderList() { }

        public OrderList(int OrderID, int ProductID, int ProductQuantity)
        {
            this.OrderID = OrderID;
            this.ProductID = ProductID;
            this.ProductQuantity = ProductQuantity;
        }
    }

    [Table("Products")]
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; } //Ошибка типа данных при проектировании БД
        public string Description { get; set; }
        public int ProdyctType { get; set; } //Ошибка типа данных при проектировании БД
        public int SupplierID { get; set; }

        public Products() { }

        public Products(string Name, int Price, string Description, int ProdyctType, int SupplierID)
        {
            this.Name = Name;
            this.Price = Price;
            this.Description = Description;
            this.ProdyctType = ProdyctType;
            this.SupplierID = SupplierID;
        }
    }

    [Table("Suppliers")]
    public class Suppliers
    {
        [Key]
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string SupplierSurname { get; set; }
        public string SupplierPhone { get; set; }
        public string SupplierEmail { get; set; }

        public Suppliers() { }

        public Suppliers(string SupplierName, string SupplierSurname, string SupplierPhone, string SupplierEmail)
        {
            this.SupplierName = SupplierName;
            this.SupplierSurname = SupplierSurname;
            this.SupplierPhone = SupplierPhone;
            this.SupplierEmail = SupplierEmail;
        }
    }

    public class DBContext : DbContext
    {
        public DBContext() : base("CustomerDB") { }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderList> OrderList { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
    }

    public class DatabaseMethods
    {
        public static void ReadAndExecuteQuery(string sql, SqlConnection connection)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
        }

        public static void DbSetOutputConsole(DbSet<Customers> customers)
        {
            foreach (Customers c in customers)
            {
                Console.WriteLine("{0}.{1}-{2}", c.CustomerID, c.CustomerName, c.CustomerSurname);
            }
        }

        public static void CrudOperation(DBContext db)
        {
            db.Customers.Add(new Customers("Vasiliy", "Pupkevich", "0442281481", "psyna@mail.ru", "Vodka"));
            db.Customers.Add(new Customers("Vazgen", "Pupkevidze", "0442281482", "korova@mail.ru", "Shashlyk"));
            db.Customers.Add(new Customers("Lavrentiy", "Pupkevidon", "0442281483", "kot@mail.ru", "Stalin"));
            db.Customers.Add(new Customers("Sin Jian", "Pupke", "0442281484", "krysa@mail.ru", "Rice"));
            db.Customers.Add(new Customers("Ecio", "Pupkevilinio", "0442281485", "mammamia@mail.ru", "Pasta"));
            db.Customers.Add(new Customers("Semion", "Pupkevoyzman", "0442281486", "oyvei@mail.ru", "Sho takoe"));

            db.SaveChanges();
        }

        public static void SqlFromStreamReader(SqlConnection connection)
        {
            string path = @"C:\SomeDir\hta.txt";

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    DatabaseMethods.ReadAndExecuteQuery(line, connection);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            string connectionString = @"Server=MY-COMPUDACTER-;Database=LabWork5_3;Trusted_Connection=True;";
            string sql = "SELECT * FROM Orders";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DatabaseMethods.ReadAndExecuteQuery(sql, connection);

                DatabaseMethods.SqlFromStreamReader(connection);
            }

            using (DBContext db = new DBContext())
            {
                DatabaseMethods.DbSetOutputConsole(db.Customers);

                DatabaseMethods.CrudOperation(db);

                var Suppliers = db.Suppliers;

                var SupplierByEmail = Suppliers.Where(x => x.SupplierEmail == "psyna@mail.ru").Select(x => x).FirstOrDefault();

                db.Suppliers.Add(SupplierByEmail);

                db.Suppliers.Remove(SupplierByEmail);

                SupplierByEmail = Suppliers.Where(x => x.SupplierEmail == "psyna@mail.ru").Select(x => x).FirstOrDefault();

                SupplierByEmail.SupplierEmail = "konyna@mail.ru";

                db.SaveChanges();
            }

            Console.ReadKey();
        }
    }
}
