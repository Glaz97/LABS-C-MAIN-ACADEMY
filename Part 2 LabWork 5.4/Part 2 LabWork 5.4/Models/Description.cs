using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Part_2_LabWork_5._4.Models
{
    public class DescriptionModel
    {
        [Key]
        public int DescriptionID { get; set; }
        public int PictureID { get; set; }
        public string DescriptionText { get; set; }

        public DescriptionModel() { }

        public DescriptionModel(int pictureID, string descriptionText)
        {
            PictureID = pictureID;
            DescriptionText = descriptionText;
        }
    }
}