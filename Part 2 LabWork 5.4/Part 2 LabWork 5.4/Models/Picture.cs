using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Part_2_LabWork_5._4.Models
{
    public class PictureModel
    {
        [Key]
        public int PictureID { get; set; }
        public string PictureName { get; set; }
        public string Author { get; set; }
        public byte[] Image { get; set; }

        public PictureModel() { }
    }
}