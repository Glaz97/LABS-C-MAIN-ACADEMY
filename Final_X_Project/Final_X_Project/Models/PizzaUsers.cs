using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_X_Project.Models
{
    [Table("PizzaUsers")]
    public class PizzaUsers
    {
        [Key]
        public int UserID { get; set; }
        public string UserLogin { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public bool IsAnEmployee { get; set; }
        public int RestaurantID { get; set; }
        public bool VacancyPost { get; set; }

        public PizzaUsers() { }

        public PizzaUsers(string userLogin, string password, string name, string surname, string email,
            DateTime dateOfBirth, DateTime dateOfRegistration , bool isAnEmployee, int restaurantID, bool vacancyPost)
        {
            UserLogin = userLogin;
            Password = password;
            Name = name;
            Surname = surname;
            Email = email;
            DateOfBirth = dateOfBirth;
            DateOfRegistration = dateOfRegistration;
            IsAnEmployee = isAnEmployee;
            RestaurantID = restaurantID;
            VacancyPost = vacancyPost;
        }
    }
}