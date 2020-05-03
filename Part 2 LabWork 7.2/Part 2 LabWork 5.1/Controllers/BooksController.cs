using Part_2_LabWork_7._2.Models;
using Part_2_LabWork_7._2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Part_2_LabWork_7._2.Controllers
{
    public class BooksController : Controller
    {
        BookRepository BookRepository = new BookRepository();

        public ActionResult Index()
        {
            var test = BookRepository.GetAll();
            return View(BookRepository.GetAll());
        }

        [HttpGet]
        public ActionResult Add(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(BookModel bookElement)
        {
            bookElement.ID = BookRepository.GetAll().LastOrDefault().ID + 1;
            BookRepository.AddBook(bookElement);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            BookRepository.RemoveBook(BookRepository.GetAll().Where(x => x.ID == id).First());
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(BookRepository.GetAll().Where(x => x.ID == id).First());
        }

        [HttpPost]
        public ActionResult Edit(BookModel bookElement)
        {
            BookRepository.RemoveBook(BookRepository.GetAll().Where(x => x.ID == bookElement.ID).First());
            BookRepository.AddBook(bookElement);
            return RedirectToAction("Index");
        }
    }
}