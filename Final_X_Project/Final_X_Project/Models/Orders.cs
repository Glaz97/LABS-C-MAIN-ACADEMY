using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_X_Project.Models
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int EmployeeID { get; set; }
        public int RestaurantID { get; set; }
        public int PizzaID { get; set; }
        public DateTime DataTimeOrder { get; set; }
        public double Value { get; set; }
        public bool IsFinished { get; set; }
        public string Comment { get; set; }

        public Orders() { }

        public Orders(int userID, int employeeID, int restaurantID, int pizzaID, DateTime dateTimeOrder, double value, bool isFinished, string comment)
        {
            UserID = userID;
            EmployeeID = employeeID;
            RestaurantID = restaurantID;
            PizzaID = pizzaID;
            DataTimeOrder = dateTimeOrder;
            IsFinished = isFinished;
            Value = value;
            Comment = comment;
        }
    }
}