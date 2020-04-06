using Part_2_LabWork_5._1.Models;
using Part_2_LabWork_5._1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Part_2_LabWork_5._1.Controllers
{
    public class BooksController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Books = BookRepository.BookList;
            return View();
        }

        [HttpGet]
        public ActionResult Add(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(BookModel bookElement)
        {
            bookElement.BookID = BookRepository.BookList.LastOrDefault().BookID + 1;
            BookRepository.BookList.Add(bookElement);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            BookRepository.BookList.Remove(BookRepository.BookList.Where(x=>x.BookID == id).First());
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Book = BookRepository.BookList.Where(x => x.BookID == id).First();
            return View();
        }

        [HttpPost]
        public ActionResult Edit(BookModel bookElement)
        {
            BookRepository.BookList.Remove(BookRepository.BookList.Where(x => x.BookID == bookElement.BookID).First());
            BookRepository.BookList.Add(bookElement);
            return RedirectToAction("Index");
        }
    }
}