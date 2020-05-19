using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_X_Project.Models
{
    [Table("PizzaRestaurants")]
    public class PizzaRestaurants
    {
        [Key]
        public int RestaurantID { get; set; }
        public int UserID { get; set; }
        public string RestaurantName { get; set; }
        public string Adress { get; set; }
        public string GoogleCoordinates { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public PizzaRestaurants() { }

        public PizzaRestaurants(int userID, string restaurantName, string adress, 
            string googleCoordinates, string email, string phoneNumber)
        {
            UserID = userID;
            RestaurantName = restaurantName;
            Adress = adress;
            GoogleCoordinates = googleCoordinates;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}