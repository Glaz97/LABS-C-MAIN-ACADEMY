using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_X_Project.TelegramBot
{
    public class AppBotSettings
    {
        private static string Key { get; set; } = "1262062668:AAFkeurbByoiDuzk8z_kDHC4PC1mzEVy7Y8";
        private static string Name { get; set; } = "x_pizza_bot";
        private static string Id { get; set; } = "1262062668";

        public string GetKey()
        {
            return Key;
        }
    }
}