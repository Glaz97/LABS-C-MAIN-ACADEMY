using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Part_2_LabWork_5._2.Models
{
    public class GalleryModel
    {
        public string Name;
        public string Path;

        public GalleryModel() { }

        public GalleryModel(string name, string path)
        {
            Name = name;
            Path = path;
        }
    }
}