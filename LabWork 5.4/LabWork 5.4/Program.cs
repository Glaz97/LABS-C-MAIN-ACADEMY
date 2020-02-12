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

namespace LabWork_5._4
{
    public class Common_DB
    {
        public string ConnectionString;

        public Common_DB(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        public SqlDataReader ReadAllFromCustomers(SqlConnection dbconn)
        {
            string querysString = "Select * from Customers";

            SqlCommand command = new SqlCommand(querysString, dbconn);

            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }

        public void WriteAllFromCustomers(SqlConnection dbconn)
        {
            var reader = ReadAllFromCustomers(dbconn);

            try
            {
                while (reader.Read())
                {
                    Console.WriteLine(string.Format("{0} {1} {2} {3} {4} {5}", reader[0],
                    reader[1], reader[2], reader[3], reader[4], reader[5]));
                }
            }
            finally
            {
                reader.Close();
            }
        }

        public void UpdateCustomersTable(SqlConnection dbconn, SqlDataAdapter adapter)
        {
            var reader = ReadAllFromCustomers(dbconn);

            int ID = 0;

            while (reader.Read())
            {
                ID = Convert.ToInt32(reader[0]);
            }

            reader.Close();

            DataSet ds = new DataSet();
            adapter.Fill(ds);

            DataTable dt = ds.Tables[0];
            DataRow newRow = dt.NewRow();
            newRow["CustomerID"] = ID + 1;
            newRow["CustomerName"] = "Alice";
            newRow["CustomerEmail"] = "home9090@meta.ua";
            newRow["CustomerSurname"] = "Pypkina";
            dt.Rows.Add(newRow);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(ds);
        }

        public void DeleteRow(SqlConnection dbconn, SqlDataAdapter adapter)
        {
            var reader = ReadAllFromCustomers(dbconn);

            int ID = 0;

            while (reader.Read())
            {
                ID = Convert.ToInt32(reader[0]);
            }

            reader.Close();

            DataSet ds = new DataSet();
            adapter.Fill(ds);

            ds.Tables[0].Rows.RemoveAt(ID-1);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(ds);
        }

        public void ReadAllCustomers(DbSet<Customers> customers)
        {
            foreach (Customers c in customers)
            {
                Console.WriteLine("{0}.{1}-{2}", c.CustomerID, c.CustomerName, c.CustomerSurname);
            }
        }
    }

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

        public Customers(){}

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
    }

    public class UserContext : DbContext
    {
        public UserContext() : base("CustomerDB") { }

        public DbSet<Customers> Customers { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var Connection = new Common_DB("Server=MY-COMPUDACTER-;Database=LabWork5_3;Trusted_Connection=True;");

            string sql = "SELECT * FROM Customers";

            using (SqlConnection dbconn = new SqlConnection(Connection.ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dbconn);

                dbconn.Open();

                Connection.UpdateCustomersTable(dbconn, adapter);
                Connection.DeleteRow(dbconn, adapter);
                Connection.WriteAllFromCustomers(dbconn);
            }

            //ENTITY FRAMEWORK

            using (UserContext db = new UserContext())
            {
                var customers = db.Customers;

                customers.Add(new Customers("Vasiliy", "Pupkevich", "0442281488", "psyna@mail.ru", "Pferd"));
                db.SaveChanges();

                customers.Remove(new Customers(2," Vasiliy", "Pupkevich", "0442281488", "psyna@mail.ru", "Pferd"));
                db.SaveChanges();

                var FindRowByID = customers.Find(new object[] { 1 });

                Connection.ReadAllCustomers(customers);
            }

            Console.ReadKey();
        }
    }
}
