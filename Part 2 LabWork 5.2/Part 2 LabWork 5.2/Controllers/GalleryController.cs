using Part_2_LabWork_5._2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Part_2_LabWork_5._2.Controllers
{
    public class GalleryController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ListOfModels = GalleryRepository.GetListOfPictures();
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                string fileName = System.IO.Path.GetFileName(upload.FileName);

                upload.SaveAs(Server.MapPath("~/Images/" + fileName));
            }
            return RedirectToAction("Index");
        }
    }
}