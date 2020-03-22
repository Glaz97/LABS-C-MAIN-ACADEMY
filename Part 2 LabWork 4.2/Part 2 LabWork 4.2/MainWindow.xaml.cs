using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Part_2_LabWork_4._2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        List<DataGridCustomers> TableDataGridCustomers = new List<DataGridCustomers>();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void OpenNewFormWithPicture()
        {
            ImageBackgroundWindow window = new ImageBackgroundWindow
            {
                Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "/images/Image.jpg"))),
                Top = 0,
                Left = 0,
                Width = 1920,
                Height = 1080
            };
            window.Show();
        }

        private void ButtonNew_MouseMove(object sender, MouseEventArgs e)
        {
            OpenNewFormWithPicture();
        }

        public class DBContext : DbContext
        {
            public DBContext() : base("CustomerDB") { }

            public DbSet<Customers> Customers { get; set; }
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
        }

        public class DataGridCustomers
        {
            public int CustomerID { get; set; }
            public string CustomerName { get; set; }
            public string CustomerSurname { get; set; }
            public string CustomerPhone { get; set; }
            public string CustomerEmail { get; set; }
            public string CustomerDetails { get; set; }
            public bool IsModified { get; set; }

            public DataGridCustomers(int CustomerID, string CustomerName, string CustomerSurname, string CustomerPhone, string CustomerEmail, string CustomerDetails)
            {
                this.CustomerID = CustomerID;
                this.CustomerName = CustomerName;
                this.CustomerSurname = CustomerSurname;
                this.CustomerPhone = CustomerPhone;
                this.CustomerEmail = CustomerEmail;
                this.CustomerDetails = CustomerDetails;
            }
        }

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
        }

        public List<DataGridCustomers> LoadCollectionData(DbSet<Customers> customers)
        {
            foreach (Customers element in customers)
            {
                TableDataGridCustomers.Add(new DataGridCustomers(element.CustomerID, element.CustomerName, element.CustomerSurname, element.CustomerPhone, element.CustomerEmail, element.CustomerDetails));
            }

            return TableDataGridCustomers;
        }

        private void MainWindow1_Loaded(object sender, RoutedEventArgs e)
        {
            var Connection = new Common_DB("Server=MY-COMPUDACTER-;Database=LabWork5_3;Trusted_Connection=True;");

            using (SqlConnection dbconn = new SqlConnection(Connection.ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Customers", dbconn);
                dbconn.Open();
            }

            using (DBContext db = new DBContext())
            {
                DataBaseGrid.ItemsSource = LoadCollectionData(db.Customers);
            }
        }

        private void SaveButton_MouseMove(object sender, MouseEventArgs e)
        {
            using (DBContext db = new DBContext())
            {
                var ModifiedRows = TableDataGridCustomers.Select(x => x).Where(z => z.IsModified == true);

                var weHaveProblem = false;

                foreach (var element in ModifiedRows)
                {
                    try
                    {
                        var customer = db.Customers.Select(x => x).Where(z => z.CustomerID == element.CustomerID).First();
                        customer.CustomerName = element.CustomerName;
                        customer.CustomerSurname = element.CustomerName;
                        customer.CustomerEmail = element.CustomerEmail;
                        customer.CustomerPhone = element.CustomerPhone;
                        customer.CustomerDetails = element.CustomerDetails;
                    }
                    catch
                    {
                        weHaveProblem = true;
                        MessageBox.Show("Ошибка при попытке записи строки с ID № - " + element.CustomerID);
                    }
                }

                if (!weHaveProblem)
                {
                    MessageBox.Show("Модифицированные даные были успешно сохранены!");
                    db.SaveChanges();
                }
            }

            foreach (var element in TableDataGridCustomers)
            {
                element.IsModified = false;
            }

            DataBaseGrid.ItemsSource = null;
            DataBaseGrid.ItemsSource = TableDataGridCustomers;
        }

        private void DataBaseGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var currentrow = (DataGridCustomers)e.Row.Item;
            TableDataGridCustomers.Select(x => x).Where(z => z.CustomerID == currentrow.CustomerID)
                .First().IsModified = true;
            DataBaseGrid.ItemsSource = null;
            DataBaseGrid.ItemsSource = TableDataGridCustomers;
        }
    }
}
