using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Part_2_LabWork_7._2.Models
{
    [Table("Books")]
    public class BookModel
    {
        [Key]
        public int ID { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Edition { get; set; }
        public string Publishing { get; set; }

        public BookModel() { }

        public BookModel(int id, string bookName, string author, string edition, string publishing)
        {
            ID = id;
            BookName = bookName;
            Author = author;
            Edition = edition;
            Publishing = publishing;
        }
    }
}