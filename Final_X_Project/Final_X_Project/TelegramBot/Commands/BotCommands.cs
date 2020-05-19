using Final_X_Project.Models;
using System;
using System.Linq;
using System.Reflection;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Final_X_Project.TelegramBot.Commands
{
    public class BotCommands
    {
        static ITelegramBotClient bot_client;
        public static AppBotSettings botSettings = new AppBotSettings();

        public static DBContext db = new DBContext();

        public void StartReadingUserMessages()
        {
            //bot_client.OnMessage += Bot_OnMessage;
            //bot_client.StartReceiving();
        }

        public void StopReadingUserMessages()
        {
            //bot_client.StartReceiving();
        }

        public void SendTelegramMessage(int userId, Orders order, BotMessageTypes.TypeOfMessage typeOfMessage)
        {
            if (typeOfMessage == BotMessageTypes.TypeOfMessage.Add)
            {
                SendAddMessage(userId, GetPizzaById(order.PizzaID), order);
            }
            else if (typeOfMessage == BotMessageTypes.TypeOfMessage.Edit)
            {
                SendEditMessage(userId, GetPizzaById(order.PizzaID), order);
            }
            else if (typeOfMessage == BotMessageTypes.TypeOfMessage.Custom)
            {
                SendCustomMessage(userId, GetPizzaById(order.PizzaID), order);
            }
        }

        public async void SendAddMessage(int userId, PizzasNomenclature pizza, Orders order)
        {
            bot_client = new TelegramBotClient(botSettings.GetKey());
            var userContactData = db.UsersContactData.Where(x => x.UserID == userId).Select(x => x).FirstOrDefault();

            var mainMessageToUser = "Уважаемый клиент!" + "\n" +
                "Ваш заказ №" + order.OrderID + " от " + order.DataTimeOrder.ToString()
                + " подтвержден и будет доставлен через 30 минут!" + "\n";

            await bot_client.SendTextMessageAsync(chatId: Convert.ToInt32(userContactData.PhoneNumber), text: mainMessageToUser);

            Message message = await bot_client.SendPhotoAsync(
            chatId: Convert.ToInt32(userContactData.PhoneNumber),
            photo: "https://raw.githubusercontent.com/Glaz97/LABS-C-MAIN-ACADEMY/CSharpCourses/Final_X_Project/Final_X_Project/Images/"+ pizza.PizzaID +".png",
            caption: "<b>Ваша пицца</b>!",
            parseMode: ParseMode.Html);

            var additionalMessageToUser = " Состав заказа - пицца " + pizza.NameOfPizza + ", состав: " + pizza.Сompound
                + ", размер-" + pizza.Size + ", стоимость заказа - " + order.Value + "грн."
                + "\n" + " Адрес доставки - " + userContactData.Adress + "\n"
                + "Комментарий к заказу - " + order.Comment + "\n"
                + "Желаем приятного аппетита!" + "\n" + " @X-Pizza Team";

            await bot_client.SendTextMessageAsync(chatId: Convert.ToInt32(userContactData.PhoneNumber), text: additionalMessageToUser);
        }

        public async void SendEditMessage(int userId, PizzasNomenclature pizza, Orders order)
        {
            bot_client = new TelegramBotClient(botSettings.GetKey());
            var userContactData = db.UsersContactData.Where(x => x.UserID == userId).Select(x => x).FirstOrDefault();

            var mainMessageToUser = "Уважаемый клиент!" + "\n" +
                "Ваш заказ №" + order.OrderID + " от " + order.DataTimeOrder.ToString()
                + " был изменен оператором и будет доставлен через 30 минут!" + "\n";

            await bot_client.SendTextMessageAsync(chatId: Convert.ToInt32(userContactData.PhoneNumber), text: mainMessageToUser);
        }

        public async void SendCustomMessage(int userId, PizzasNomenclature pizza, Orders order)
        {
            bot_client = new TelegramBotClient(botSettings.GetKey());
            var userContactData = db.UsersContactData.Where(x => x.UserID == userId).Select(x => x).FirstOrDefault();

            var messageToUser = "Сообщение от телеги";

            await bot_client.SendTextMessageAsync(chatId: Convert.ToInt32(userContactData.PhoneNumber), text: messageToUser);
        }

        public PizzasNomenclature GetPizzaById(int pizzaID)
        {
            return db.PizzasNomenclature.Where(x => x.PizzaID == pizzaID)
                .Select(x => x).FirstOrDefault();
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                await bot_client.SendTextMessageAsync(
                  chatId: e.Message.Chat,
                  text: "You said:\n" + e.Message.Text
                );
            }
        }
    }
}