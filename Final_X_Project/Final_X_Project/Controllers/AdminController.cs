using Final_X_Project.Models;
using Final_X_Project.Repositories;
using Final_X_Project.TelegramBot;
using Final_X_Project.TelegramBot.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Final_X_Project.Controllers
{
    public class AdminController : Controller
    {
        private AdminRepository repository = new AdminRepository();

        public ActionResult Index()
        {
            var ActualOrders = repository.GetOrders(1, false, 5);
            var OldOrders = repository.GetOrders(1, true, 5);

            ViewBag.ActualOrders = ActualOrders.Value;
            ViewBag.OldOrders = OldOrders.Value;
            ViewBag.PagesForActualOrders = ActualOrders.Key;
            ViewBag.PagesForOldOrders = OldOrders.Key;

            return View();
        }

        public ActionResult RenderIndex(int elementsPerPage)
        {
            var ActualOrders = repository.GetOrders(1, false, elementsPerPage);
            var OldOrders = repository.GetOrders(1, true, elementsPerPage);

            ViewBag.ActualOrders = ActualOrders.Value;
            ViewBag.OldOrders = OldOrders.Value;
            ViewBag.PagesForActualOrders = ActualOrders.Key;
            ViewBag.PagesForOldOrders = OldOrders.Key;

            return PartialView("Index");
        }

        public async Task<ActionResult> Add(Orders order)
        {
            return Json(await repository.Add(order));
        }

        public ActionResult Edit(int id)
        {
            return PartialView("_AddEdit", repository.FindElementToEdit(id));
        }

        public async Task<ActionResult> EditConfirm(Orders order)
        {          
            return Json( await repository.SaveChangedElement(order));
        }

        public ActionResult PaginationLoad(int pageNumber, int elementsPerPage, bool isFinished)
        {          
            return isFinished ? RenderOldOrdersPartial(elementsPerPage, pageNumber) 
                : RenderActualOrdersPartial(elementsPerPage, pageNumber);
        }

        public ActionResult Delete(int id, int elementsPerPage)
        {
            try
            {
                repository.DeleteOrder(id);
                var ActualOrders = repository.GetOrders(1, false , elementsPerPage);
                ViewBag.ActualOrders = ActualOrders.Value;
                ViewBag.PagesForActualOrders = ActualOrders.Key;
                return Json("OK");
            }
            catch
            {
                return null;
            }
        }

        public ActionResult RenderActualOrdersPartial(int elementsPerPage, int pageNumber)
        {
            var ActualOrders = repository.GetOrders(pageNumber != 0 ? pageNumber : 1, false, elementsPerPage);
            ViewBag.ActualOrders = ActualOrders.Value;
            ViewBag.PagesForActualOrders = ActualOrders.Key;

            return PartialView("_ActualOrders", new List<Orders>());
        }

        public ActionResult RenderOldOrdersPartial(int elementsPerPage, int pageNumber)
        {
            var OldOrders = repository.GetOrders(pageNumber != 0 ? pageNumber : 1, true, elementsPerPage);
            ViewBag.OldOrders = OldOrders.Value;
            ViewBag.PagesForOldOrders = OldOrders.Key;

            return PartialView("_OldOrders", new List<Orders>());
        }

        public ActionResult Search(string searchString, bool finishedOrNot)
        {
            var SearchedOrders = repository.SearchOrders(searchString, finishedOrNot);

            if (finishedOrNot)
            {
                ViewBag.OldOrders = SearchedOrders.Value;
                ViewBag.PagesForOldOrders = SearchedOrders.Key;
                return PartialView("_OldOrders", new List<Orders>());
            }
            else
            {
                ViewBag.ActualOrders = SearchedOrders.Value;
                ViewBag.PagesForActualOrders = SearchedOrders.Key;
                return PartialView("_ActualOrders", new List<Orders>());
            }
        }

        public ActionResult СlearPartialAddEdit(int id)
        {
            return PartialView("_AddEdit", new Orders());
        }
    }
}