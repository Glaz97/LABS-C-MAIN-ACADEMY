using ProjectAiroportASP_NET.Models;
using ProjectAiroportASP_NET.Repository;
using System.Linq;
using System.Web.Mvc;

namespace ProjectAiroportASP_NET.Controllers
{
    public class AiroportController : Controller
    {
        public DBContext db = new DBContext();

        public ActionResult Index()
        {
            return View(db.Airflights);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new Airflights());
        }

        [HttpPost]
        public ActionResult Add(Airflights airflight)
        {
            if (BaseRepository.CanAddAirflight(airflight))
            {
                db.Airflights.Add(airflight);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var elementToEdit = db.Airflights.Where(x => x.AirFlightID == id).FirstOrDefault();

            if (elementToEdit != new Airflights())
            {
                return View(elementToEdit);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Airflights airflight)
        {
            try
            {
                db.Airflights.Remove(db.Airflights.Where(x => x.AirFlightID == airflight.AirFlightID).First());
            }
            catch
            {
               //Ошибка
            }
            db.Airflights.Add(airflight);
            db.SaveChanges();
        
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var elementToDelete = db.Airflights.Where(x => x.AirFlightID == id).FirstOrDefault();

            if (elementToDelete != new Airflights())
            {
                db.Airflights.Remove(elementToDelete);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string searchString)
        {
            return View(BaseRepository.FindAiroportInfoElements(searchString));
        }
    }
}