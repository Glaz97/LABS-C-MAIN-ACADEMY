using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Part_2_LabWork_5._3.DataModels
{
    [Table("Books")]
    public class DbBookModel
    {
        [Key]
        public int ID { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Edition { get; set; }
        public string Publishing { get; set; }

        public DbBookModel() { }

        public DbBookModel(int id, string bookName, string author, string edition, string publishing)
        {
            ID = id;
            BookName = bookName;
            Author = author;
            Edition = edition;
            Publishing = publishing;
        }
    }
}