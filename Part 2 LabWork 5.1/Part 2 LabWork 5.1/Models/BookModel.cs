using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Part_2_LabWork_5._1.Models
{
    public class BookModel
    {
        public int BookID { get; set; }
        public string Author { get; set; }
        public string Edition { get; set; }
        public string Published { get; set; }

        public BookModel(){}

        public BookModel(int bookID, string author, string edition, string published)
        {
            BookID = bookID;
            Author = author;
            Edition = edition;
            Published = published;
        }
    }
}