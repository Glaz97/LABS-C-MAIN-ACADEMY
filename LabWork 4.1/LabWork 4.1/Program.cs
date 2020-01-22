using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork_4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var Customer1 = new Customer("Petya");
            var Customer2 = new Customer("Vasya");
            var Customer3 = new Customer("Kolya");

            var NewGoods1 = new GoodsInfoEventsArgs("ball");
            var NewGoods2 = new GoodsInfoEventsArgs("doll");
            var NewGoods3 = new GoodsInfoEventsArgs("pen");

            Customer1.GotNewGoods("Big", NewGoods1);
            Customer2.GotNewGoods("Big", NewGoods1);
            Customer3.GotNewGoods("Big", NewGoods1);

        }
    }

    public class GoodsInfoEventsArgs : EventArgs
    {
        public string GoodsName;

        public GoodsInfoEventsArgs (string GoodName)
        {
            GoodsName = GoodName;
        }
    }

    class OnlineShop
    {
        public event EventHandler<GoodsInfoEventsArgs> NewEvent;

        public GoodsInfoEventsArgs Event;

        public void NewGoods(string GoodsName)
        {
            Event = new GoodsInfoEventsArgs(GoodsName);
        }
    }

    class Customer
    {
        private string NameOfCustomer;

        public Customer (string Name)
        {
            NameOfCustomer = Name;
        }

        public void GotNewGoods(object parametr, GoodsInfoEventsArgs secondparametr)
        {
            Console.WriteLine("GotNewGoods");
        }
    }
}
