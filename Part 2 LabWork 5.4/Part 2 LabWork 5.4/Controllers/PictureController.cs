using Part_2_LabWork_5._4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Part_2_LabWork_5._4.Controllers
{
    public class PictureController : Controller
    {
        DBContext db = new DBContext();

        public ActionResult Index()
        {
            return View(db.Pictures);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PictureModel pic, HttpPostedFileBase uploadImage, string descriptionText)
        {
            if (ModelState.IsValid && uploadImage != null)
            {
                byte[] imageData = null;

                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }

                pic.Image = imageData;

                db.Pictures.Add(pic);
            }

            //Сделал разбивку на 2 таблицы, потому что такая великолепная задача
            db.Descriptions.Add(new DescriptionModel(db.Pictures.ToList().OrderByDescending(x => x.PictureID).First().PictureID + 1, descriptionText));

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var Picture = db.Pictures.Where(x => x.PictureID == id).FirstOrDefault();

            var descText = db.Descriptions.Where(x => x.PictureID == Picture.PictureID).FirstOrDefault();

            if (descText != null)
            {
                ViewBag.DescriptionText = descText.DescriptionText;
            }
            else
            {
                ViewBag.DescriptionText = "";
            }
            return View(Picture);
        }

        [HttpPost]
        public ActionResult Edit(PictureModel pic, HttpPostedFileBase uploadImage, string descriptionText)
        {
            var oldImage = db.Pictures.Where(x => x.PictureID == pic.PictureID).First().Image;

            db.Pictures.Remove(db.Pictures.Where(x => x.PictureID == pic.PictureID).First());
            if (ModelState.IsValid && uploadImage != null)
            {
                byte[] imageData = null;

                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }

                pic.Image = imageData;
            }

            if (uploadImage == null)
            {
                pic.Image = oldImage;
            }

            db.Pictures.Add(pic);

            var DescriptionToChange = db.Descriptions.Where(x => x.PictureID == pic.PictureID).FirstOrDefault();

            if (DescriptionToChange != null)
            {
                DescriptionToChange.DescriptionText = descriptionText;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                db.Pictures.Remove(db.Pictures.Where(x => x.PictureID == id).First());
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}