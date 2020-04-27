using ProjectAiroportASP_NET.Models;
using ProjectAiroportASP_NET.Repository;
using System.Linq;
using System.Web.Mvc;
using WcfService;

namespace ProjectAiroportASP_NET.Controllers
{
    public class AiroportController : Controller
    {
        Service1 Service = new Service1();

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

            return RedirectToAction(Service.RedirectToActionIndex());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var elementToEdit = db.Airflights.Where(x => x.AirFlightID == id).FirstOrDefault();

            if (elementToEdit != new Airflights())
            {
                return View(elementToEdit);
            }

            return RedirectToAction(Service.RedirectToActionIndex());
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
        
            return RedirectToAction(Service.RedirectToActionIndex());
        }

        public ActionResult Delete(int id)
        {
            var elementToDelete = db.Airflights.Where(x => x.AirFlightID == id).FirstOrDefault();

            if (elementToDelete != new Airflights())
            {
                db.Airflights.Remove(elementToDelete);
                db.SaveChanges();
            }

            return RedirectToAction(Service.RedirectToActionIndex());
        }

        [HttpPost]
        public ActionResult Search(string searchString)
        {
            return View(BaseRepository.FindAiroportInfoElements(searchString));
        }
    }
}