using Part_2_LabWork_5._2.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace Part_2_LabWork_5._2.Repositories
{
    public class GalleryRepository
    {
        public static List<GalleryModel> GetListOfPictures()
        {
            List<GalleryModel> GalleryDictionary = new List<GalleryModel>();

            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            foreach (var item in dir.GetDirectories())
            {
                if (item.Name == "Images")
                {
                    foreach (var item2 in item.GetFiles())
                    {
                        GalleryDictionary.Add(new GalleryModel(item2.Name, "/" + item.Name + "/" + item2.Name));
                    }
                }
            }

            return GalleryDictionary;
        }
    }
}