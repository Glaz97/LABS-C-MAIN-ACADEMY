using Final_X_Project.Models;
using Final_X_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_X_Project.Controllers
{
    public class HomeController : Controller
    {
        private HomeRepository repository = new HomeRepository();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            return Json(Url.Action("Index",repository.Autorize(login, password)));
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(PizzaUsers pizzaUser,string phoneNumber, string adress)
        {
            return Json(Url.Action("Index", repository.Registrate(pizzaUser,phoneNumber,adress)));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}