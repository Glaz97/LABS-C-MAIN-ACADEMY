using Final_X_Project.Models;
using Final_X_Project.TelegramBot;
using Final_X_Project.TelegramBot.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_X_Project.Repositories
{
    public class AdminRepository
    {
        public static DBContext db = new DBContext();
        private BotCommands telegramBot = new BotCommands();

        public async Task<bool> Add(Orders order)
        {
            try
            {
                order.DataTimeOrder = Convert.ToDateTime(order.DataTimeOrder);

                if (order.DataTimeOrder == DateTime.MinValue)
                {
                    order.DataTimeOrder = DateTime.Now;
                }
            }
            catch
            {
                order.DataTimeOrder = DateTime.Now;
            }

            db.Orders.Add(order);
            db.SaveChanges();

            if (!order.IsFinished)
            {
                try
                {
                    await Task.Run(() => telegramBot.SendTelegramMessage(order.UserID, order, BotMessageTypes.TypeOfMessage.Add));
                }
                catch
                {
                    //не найдена картинка или не указан ID телеграм
                }
            }

            return order.IsFinished;
        }

        public Orders FindElementToEdit(int id)
        {
            return db.Orders.Where(x => x.OrderID == id).Select(x => x).FirstOrDefault();
        }

        public async Task<bool> SaveChangedElement(Orders order)
        {
            db.Orders.Remove(db.Orders.Where(x => x.OrderID == order.OrderID).First());
            db.Orders.Add(order);
            db.SaveChanges();

            if (!order.IsFinished)
            {
                try
                {
                    await Task.Run(() => telegramBot.SendTelegramMessage(order.UserID, order, BotMessageTypes.TypeOfMessage.Edit));
                }
                catch
                {
                    //не найдена картинка или не указан ID телеграм
                }
            }

            return order.IsFinished;
        }

        public KeyValuePair<int, List<Orders>> GetOrders(int pageNumber, bool IsFinished, int elementsPerPage)
        {
            var Dictionary = new Dictionary<int, List<Orders>>();
            if (elementsPerPage == 0)
            {
                elementsPerPage = 5;
            }
            var SelectedOrders = db.Orders.Select(x => x).Where(x => x.IsFinished == IsFinished).OrderBy(x => x.OrderID);

            Dictionary.Add(Convert.ToInt32(Math.Ceiling(Convert.ToDouble(SelectedOrders.Count() / elementsPerPage)) + 1), SelectedOrders.Skip(elementsPerPage * (pageNumber - 1)).Take(elementsPerPage).ToList());

            return Dictionary.FirstOrDefault();
        }

        public void DeleteOrder(int id)
        {
            db.Orders.Remove(db.Orders.Where(x => x.OrderID == id).Select(x => x).FirstOrDefault());
            db.SaveChanges();
        }

        public KeyValuePair<int, List<Orders>> SearchOrders(string searchString, bool finishedOrNot)
        {
            var Dictionary = new Dictionary<int, List<Orders>>();

            DateTime DateTimeOrder;

            try
            { DateTimeOrder = Convert.ToDateTime(searchString); }
            catch
            { DateTimeOrder = DateTime.MinValue; }

            int OrderID, PizzaID, RestaurantID, UserID, EmployeeID;
            double Value;

            try
            {
                OrderID = Convert.ToInt32(searchString);
                PizzaID = Convert.ToInt32(searchString);
                RestaurantID = Convert.ToInt32(searchString);
                UserID = Convert.ToInt32(searchString);
                Value = Convert.ToDouble(searchString);
                EmployeeID = Convert.ToInt32(searchString);
            }
            catch
            {
                OrderID = -1;
                PizzaID = -1;
                RestaurantID = -1;
                UserID = -1;
                Value = -1;
                EmployeeID = -1;
            }

            var SearchedOrders = db.Orders.AsEnumerable().Select(x => x).Where(x => x.IsFinished == finishedOrNot &&
            (x.OrderID == OrderID || x.PizzaID == PizzaID || x.RestaurantID == RestaurantID || x.UserID == UserID
            || x.Value == Value || x.DataTimeOrder == DateTimeOrder || x.Comment == searchString
            || x.EmployeeID == EmployeeID)).OrderBy(x => x.OrderID);

            var test = SearchedOrders.Count();

            if (SearchedOrders.Count() == 0)
            {
                throw new Exception("Ничего не было найдено!");
            }

            Dictionary.Add(Convert.ToInt32(Math.Ceiling(Convert.ToDouble(SearchedOrders.Count() / 5)) + 1), SearchedOrders.Take(5).ToList());

            return Dictionary.FirstOrDefault();
        }
    }
}