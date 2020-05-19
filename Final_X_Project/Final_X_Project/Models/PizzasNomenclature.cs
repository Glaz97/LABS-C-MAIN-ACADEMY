using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_X_Project.Models
{
    [Table("PizzasNomenclature")]
    public class PizzasNomenclature
    {
        [Key]
        public int PizzaID { get; set; }
        public string NameOfPizza { get; set; }
        public string Сompound { get; set; }
        public double Price { get; set; }
        public string Size { get; set; }
        public double Weight { get; set; }

        public PizzasNomenclature() { }

        public PizzasNomenclature(string nameOfPizza, string compound, float price, string size, float weight)
        {
            NameOfPizza = nameOfPizza;
            Сompound = compound;
            Price = price;
            Size = size;
            Weight = weight;
        }
    }
}