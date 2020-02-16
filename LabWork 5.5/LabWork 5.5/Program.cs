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

namespace LabWork_5._5
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

        public Orders() {}

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

        public Suppliers( string SupplierName, string SupplierSurname, string SupplierPhone, string SupplierEmail)
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

    class Program
    {
        static void Main(string[] args)
        {
            using (DBContext db = new DBContext())
            {
                var customers = db.Customers;

                customers.Add(new Customers("Vasiliy", "Pupkevich", "0442281481", "psyna@mail.ru", "Vodka"));
                customers.Add(new Customers("Vazgen", "Pupkevidze", "0442281482", "korova@mail.ru", "Shashlyk"));
                customers.Add(new Customers("Lavrentiy", "Pupkevidon", "0442281483", "kot@mail.ru", "Stalin"));
                customers.Add(new Customers("Sin Jian", "Pupke", "0442281484", "krysa@mail.ru", "Rice"));
                customers.Add(new Customers("Ecio", "Pupkevilinio", "0442281485", "mammamia@mail.ru", "Pasta"));
                customers.Add(new Customers("Semion", "Pupkevoyzman", "0442281486", "oyvei@mail.ru", "Sho takoe"));

                db.SaveChanges();

                foreach (var c in customers)
                db.Orders.Add(new Orders(c.CustomerID, c.CustomerID + 1, "Test-" + c.CustomerID, DateTime.Now));

                var Suppliers = db.Suppliers;

                Suppliers.Add(new Suppliers("Vasiliy", "Pupkevich", "0442281481", "psyna@mail.ru"));
                Suppliers.Add(new Suppliers("Vazgen", "Pupkevidze", "0442281482", "korova@mail.ru"));
                Suppliers.Add(new Suppliers("Lavrentiy", "Pupkevidon", "0442281483", "kot@mail.ru"));
                Suppliers.Add(new Suppliers("Sin Jian", "Pupke", "0442281484", "krysa@mail.ru"));
                Suppliers.Add(new Suppliers("Ecio", "Pupkevilinio", "0442281485", "mammamia@mail.ru"));
                Suppliers.Add(new Suppliers("Semion", "Pupkevoyzman", "0442281486", "oyvei@mail.ru"));

                db.SaveChanges();

                foreach (var s in Suppliers)
                db.Products.Add(new Products("A" + s.SupplierID, s.SupplierID, "Product A" + s.SupplierID, 3, s.SupplierID));

                db.SaveChanges();

                var ArrayOfOrderIDs = new List<int>();
                var ArrayOfProductIDs = new List<int>();

                foreach (var order in db.Orders)
                ArrayOfOrderIDs.Add(order.OrderID);

                foreach (var product in db.Products)
                ArrayOfProductIDs.Add(product.ProductID);

                foreach (var element in ArrayOfOrderIDs)
                db.OrderList.Add(new OrderList(element, ArrayOfProductIDs[3], 123));

                db.SaveChanges();

                new Customers().ReadAllCustomers(db.Customers);
            }

            //ADVANCED

            string connectionString = @"Server=MY-COMPUDACTER-;Database=LabWork5_3;Trusted_Connection=True;";
            string sql = "SELECT * FROM Orders";

            //SAVE && READ FROM XML
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                DataSet ds = new DataSet("Orders");
                DataTable dt = new DataTable("Order");
                ds.Tables.Add(dt);
                adapter.Fill(ds.Tables["Order"]);

                ds.WriteXml("Orderdb.xml");
                Console.WriteLine("Данные сохранены в файл");

                ds.ReadXml("Orderdb.xml");
                DataTable dv = ds.Tables[0];

                foreach (DataColumn column in dt.Columns)
                Console.Write("\t{0}", column.ColumnName);
                Console.WriteLine();

                foreach (DataRow row in dt.Rows)
                {
                    var cells = row.ItemArray;
                    foreach (object cell in row.ItemArray)
                    Console.Write("\t{0}", cell);
                    Console.WriteLine();
                }

            }
            //ENF OF SAVE && READ FROM XML

            //READ WRITE FROM JSON
            Orders ssd = new Orders();
            using (DBContext db = new DBContext())
            {
                var FirstOrder = db.Orders.FirstOrDefault();

                string json = JsonConvert.SerializeObject(FirstOrder);

                var DesirializedOrder = JsonConvert.DeserializeObject<Orders>(json);

                db.Orders.Add(DesirializedOrder);

                db.SaveChanges();
            }
            //END OF READ WRITE FROM JSON

            Console.ReadKey();
        }
    }
}
