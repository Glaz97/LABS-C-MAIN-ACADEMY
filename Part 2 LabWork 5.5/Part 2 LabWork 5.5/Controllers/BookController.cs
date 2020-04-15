using System.Linq;
using System.Web.Mvc;

namespace Part_2_LabWork_5._5.Controllers
{
    public class BookController : Controller
    {
        readonly DBContext db = new DBContext();

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // ХЗ что в задании делать - ничего не понятно, добавить методы, а что с ними делать и что должна делать прога ты угадай//
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestHtmlView()
        {
            ViewBag.Message = "А шо такое html?";
            return View();
        }

        [HttpPost]
        public ActionResult BookSearch(string name)
        {
            foreach (var element in db.Books)
            {
                var test = 1;
            }

            var allbooks = db.Books.Where(a => a.BookName.Contains(name)).ToList();
            if (allbooks.Count <= 0)
            {
                return HttpNotFound();
            }
            return PartialView(allbooks);
        }

        public ActionResult TestAjaxView()
        {
            ViewBag.Message = "А шо такое ajax?";
            return View();
        }

        public ActionResult HtmlViewModel()
        {
            return View();
        }

        public ActionResult AjaxViewModel()
        {
            return View(db.Books);
        }
    }
}