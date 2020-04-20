using ProjectAiroportASP_NET.Models;
using ProjectAiroportASP_NET.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectAiroportASP_NET.Controllers
{
    public class PriceListController : Controller
    {
        public DBContext db = new DBContext();

        public ActionResult Index()
        {
            return View(db.PriceList);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new AirflightPriceList());
        }

        [HttpPost]
        public ActionResult Add(AirflightPriceList price)
        {
            if (BaseRepository.CanAddPriceList(price))
            {
                db.PriceList.Add(price);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var elementToEdit = db.PriceList.Where(x => x.PriceListID == id).FirstOrDefault();

            if (elementToEdit != new AirflightPriceList())
            {
                return View(elementToEdit);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(AirflightPriceList price)
        {
            try
            {
                db.PriceList.Remove(db.PriceList.Where(x => x.PriceListID == price.PriceListID).First());
            }
            catch
            {
                //Ошибка
            }
            db.PriceList.Add(price);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var elementToDelete = db.PriceList.Where(x => x.PriceListID == id).FirstOrDefault();

            if (elementToDelete != new AirflightPriceList())
            {
                db.PriceList.Remove(elementToDelete);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string searchString)
        {
            return View(BaseRepository.FindPriceListInfoElements(searchString));
        }
    }
}