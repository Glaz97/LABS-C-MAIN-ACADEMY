

using System.ComponentModel.DataAnnotations;

namespace Part_2_LabWork_5._5.Models
{
    public class BookModel
    {
        [Key]
        public int ID { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Edition { get; set; }
        public string Publishing { get; set; }

        public BookModel() { }

        public BookModel(int id, string bookName, string author, string edition, string published)
        {
            ID = id;
            BookName = bookName;
            Author = author;
            Edition = edition;
            Publishing = published;
        }
    }
}