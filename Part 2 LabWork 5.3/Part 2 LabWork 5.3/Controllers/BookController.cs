using Part_2_LabWork_5._3.Models;
using Part_2_LabWork_5._3.Repositories;
using System.Data.Entity;
using System.Web.Mvc;

namespace Part_2_LabWork_5._3.Controllers
{
    public class BookController : Controller
    {
        public BookRepository BookRepository = new BookRepository();

        public ActionResult Index()
        {
            return View(BookRepository.GetBookDetails());
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult AddBook(BookModel book)
        {
            BookRepository.InsertBookDetails(book);
            return RedirectToAction("Index");
        }
    }
}