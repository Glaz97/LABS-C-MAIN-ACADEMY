using Part_2_LabWork_7._2.Models;
using Part_2_LabWork_7._2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Part_2_LabWork_7._2.Controllers
{
    public class Books2Controller : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        public ActionResult Index()
        {
            return View(unitOfWork.Books.GetAll());
        }

        [HttpGet]
        public ActionResult Add(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(BookModel bookElement)
        {
            bookElement.ID = unitOfWork.Books.GetAll().LastOrDefault().ID + 1;
            unitOfWork.Books .AddBook(bookElement);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            unitOfWork.Books.RemoveBook(unitOfWork.Books.GetAll().Where(x => x.ID == id).First());
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(unitOfWork.Books.GetAll().Where(x => x.ID == id).First());
        }

        [HttpPost]
        public ActionResult Edit(BookModel bookElement)
        {
            unitOfWork.Books.RemoveBook(unitOfWork.Books.GetAll().Where(x => x.ID == bookElement.ID).First());
            unitOfWork.Books.AddBook(bookElement);
            return RedirectToAction("Index");
        }
    }
}