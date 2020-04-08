using Part_2_LabWork_5._3.DataModels;
using Part_2_LabWork_5._3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Part_2_LabWork_5._3.Repositories
{
    public class BookRepository
    {
        public DBContext db = new DBContext();

        public List<DbBookModel> GetBookDetails()
        {
            return db.Books.ToList();
        }

        public void InsertBookDetails (BookModel book)
        {
            db.Books.Add(new DbBookModel {
                BookName = book.BookName,
                Author = book.Author,
                Edition = book.Edition,
                Publishing = book.Publishing
            });
            db.SaveChanges();
        }
    }
}