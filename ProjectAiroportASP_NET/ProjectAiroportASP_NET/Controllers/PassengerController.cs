using ProjectAiroportASP_NET.Models;
using ProjectAiroportASP_NET.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectAiroportASP_NET.Controllers
{
    public class PassengerController : Controller
    {
        public DBContext db = new DBContext();

        public ActionResult Index()
        {
            return View(db.Passengers);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new AirflightPassenger());
        }

        [HttpPost]
        public ActionResult Add(AirflightPassenger passenger)
        {
            if (BaseRepository.CanAddPassengers(passenger))
            {
                db.Passengers.Add(passenger);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var elementToEdit = db.Passengers.Where(x => x.PassengerID == id).FirstOrDefault();

            if (elementToEdit != new AirflightPassenger())
            {
                return View(elementToEdit);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(AirflightPassenger passenger)
        {
            try
            {
                db.Passengers.Remove(db.Passengers.Where(x => x.PassengerID == passenger.PassengerID).First());
            }
            catch
            {
                //Ошибка
            }
            db.Passengers.Add(passenger);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var elementToDelete = db.Passengers.Where(x => x.PassengerID == id).FirstOrDefault();

            if (elementToDelete != new AirflightPassenger())
            {
                db.Passengers.Remove(elementToDelete);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string searchString)
        {
            return View(BaseRepository.FindPassengersInfoElements(searchString));
        }
    }
}