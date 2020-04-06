using Part_2_LabWork_5._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Part_2_LabWork_5._1.Repositories
{
    public class BookRepository
    {
        public static List<BookModel> BookList = new List<BookModel>
        {
            new BookModel(1,"Vasya","L","1982"),
            new BookModel(2,"Petya","XXL","1876"),
            new BookModel(3,"Kolomoysky","XXXXL","1488"),
            new BookModel(4,"Kolya","S","1982"),
            new BookModel(5,"Stepa","M","1897"),
            new BookModel(6,"Igor","XXL","1577")
        };

        public void AddBook(BookModel newBook)
        {
            BookList.Add(newBook);
        }

        public void UpdateBook(BookModel newBook)
        {
            BookList.Remove(BookList.Where(x => x.BookID == newBook.BookID).First());
            BookList.Add(newBook);
        }
    }
}