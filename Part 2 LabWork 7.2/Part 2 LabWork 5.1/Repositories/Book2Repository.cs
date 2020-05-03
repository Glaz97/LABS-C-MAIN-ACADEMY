using Part_2_LabWork_7._2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Part_2_LabWork_7._2.Repositories
{
    interface IRepository<T> where T : class
    {
        List<T> GetAll();
        void AddBook(T item);
        void UpdateBook(T item);
        void RemoveBook(T item);
    }

    public class Book2Repository : IRepository<BookModel>
    {
        private DBContext db;

        public Book2Repository(DBContext context)
        {
            db = context;
        }

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