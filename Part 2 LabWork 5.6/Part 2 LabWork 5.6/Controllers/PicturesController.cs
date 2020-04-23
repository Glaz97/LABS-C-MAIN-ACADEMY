using Part_2_LabWork_5._6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Part_2_LabWork_5._6.Controllers
{
    public class PicturesController : ApiController
    {
        readonly List<Picture> Pictures = new List<Picture>
        {
            new Picture {ID = 1, Author = "Vasya", Price = 200 ,Title= "HelloWorld"},
            new Picture {ID = 2, Author = "Viktor", Price = 400 ,Title= "HelloWorld"},
            new Picture {ID = 3, Author = "Petya", Price = 500 ,Title= "HelloWorld"},
            new Picture {ID = 4, Author = "Benya", Price = 600 ,Title= "HelloWorld"},
        };

        ServiceReference1.IService1 d = new ServiceReference1.Service1Client();
        

        public IEnumerable<Picture> GetAllPictures()
        {
            var test = d.Addition(1, 2);
            return Pictures;
        }
        public IHttpActionResult GetPicture (int id)
        {
            var test = Pictures.FirstOrDefault(p => p.ID == id);

            if (test == null)
            {
                return NotFound();
            }
            return Ok(test);
        }

        public HttpResponseMessage PostPicture (Picture picture)
        {
            try
            {
                Pictures.Add(picture);
                //Debug_write();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public HttpResponseMessage PutPicture (int id, Picture picture)
        {
            try
            {
                Picture found_pict = Pictures.SingleOrDefault(x => x.ID == id);

                if (found_pict != null)
                {
                    found_pict.Title = picture.Title;
                    found_pict.Author = picture.Author;
                    found_pict.Price = picture.Price;
                    //Debug_write();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Picture found_pict = Pictures.SingleOrDefault(x => x.ID == id);

                if (found_pict != null)
                {
                    Pictures.Remove(found_pict);
                    //Debug_write();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
