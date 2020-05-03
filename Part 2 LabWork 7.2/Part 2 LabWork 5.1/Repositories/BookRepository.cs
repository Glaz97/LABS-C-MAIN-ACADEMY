using Part_2_LabWork_7._2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Part_2_LabWork_7._2.Repositories
{


    public class BookRepository : IRepository<BookModel>
    {
        public DBContext db = new DBContext();

        public List<BookModel> GetAll()
        {
            return db.Books.ToList();
        }

        public void UpdateBook(BookModel newBook)
        {
            db.Books.Remove(db.Books.Where(x => x.ID == newBook.ID).First());
            db.Books.Add(newBook);
            db.SaveChanges();
        }

        public void AddBook(BookModel book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }

        public void RemoveBook (BookModel book)
        {
            try
            {
                db.Books.Remove(book);
            }
            catch
            {
                //ошибка
            }
            db.SaveChanges();
        }
    }
}