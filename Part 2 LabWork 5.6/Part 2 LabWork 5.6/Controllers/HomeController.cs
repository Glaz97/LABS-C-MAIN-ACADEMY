using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Part_2_LabWork_5._6.Controllers
{
    public class HomeController : Controller
    {
        ServiceReference1.IService1 d = new ServiceReference1.Service1Client();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            var test = d.Addition(1, 2);

            return View();
        }
    }
}
