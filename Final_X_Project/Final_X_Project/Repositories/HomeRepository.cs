using Final_X_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_X_Project.Repositories
{
    public class HomeRepository
    {
        public static DBContext db = new DBContext();

        public string Autorize(string login, string password)
        {
            try
            {
                var User = db.PizzaUsers.Where(x => x.UserLogin == login && x.Password == password).FirstOrDefault();
                return User != null ? User.IsAnEmployee ? "Admin" : throw new Exception("попробуй ввести IgorKolo 123") : throw new Exception("Неправильный логин или пароль!");
            }
            catch
            {
                throw new Exception("Неправильный логин или пароль!");
            }
        }

        public string Registrate(PizzaUsers pizzaUzer, string phoneNumber, string adress)
        {
            try
            {
                pizzaUzer.DateOfRegistration = DateTime.Now;
                db.PizzaUsers.Add(pizzaUzer);
                db.SaveChanges();
                return "Admin";
            }
            catch
            {
                throw new Exception("Пользователь с таким ником уже существует");
            }
        }

    }
}