using ProjectAirportPanel;
using System;
using System.Collections.Generic;

namespace ProjectAirportClass
{
    class StartProgram
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 30;
            Console.WindowWidth = 135; 
            Console.ForegroundColor = ConsoleColor.White;

            Random rnd = new Random();

            var flights = new SortedList<string, Airoport>
            {
                {"UA228-1488", new Airoport("Zhytomyr", "Kyiv", "Airoport-1", "Boryspil", "UA228-1488", "D", "1D", new DateTime(2019, 12, 15), new DateTime(2019, 12, 15), new DateTime(2019, 12, 14), Airoport.FlightStatus.InFlight, FlightsActions.CreateNewListOfPasssangers(rnd), BaseFunctions.GetBasePrices(rnd) ) },
                {"UA229-1488", new Airoport("Lviv", "Kyiv", "Airoport-3", "Boryspil", "UA229-1488", "A", "3D", new DateTime(2019, 12, 16), new DateTime(2019, 12, 16), new DateTime(2019, 12, 13), Airoport.FlightStatus.Delayed, FlightsActions.CreateNewListOfPasssangers(rnd), BaseFunctions.GetBasePrices(rnd) ) },
                {"UA222-1488", new Airoport("Kharjiv", "Kyiv", "Airoport-4", "Boryspil", "UA222-1488", "C", "4D", new DateTime(2019, 12, 16), new DateTime(2019, 12, 16), new DateTime(2019, 12, 13), Airoport.FlightStatus.Canceled, FlightsActions.CreateNewListOfPasssangers(rnd), BaseFunctions.GetBasePrices(rnd)  ) },
                {"UA221-1488", new Airoport("Odessa", "Kyiv", "Airoport-5", "Boryspil", "UA221-1488", "B", "5D", new DateTime(2019, 12, 16), new DateTime(2019, 12, 16), new DateTime(2019, 12, 13), Airoport.FlightStatus.Delayed, FlightsActions.CreateNewListOfPasssangers(rnd), BaseFunctions.GetBasePrices(rnd) )}
            };

            while (true)
            {
                BaseFunctions.ReWriteFlightStatuses(flights);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n" + string.Join("\n", "Меню действий:", "Введите 1 - Добавить элемент перелета;",
                    "Введите 2 - Изменить элемент перелета;", "Введите 3 - Удалить элемент перелета;",
                    "Введите 4 - Поиск по элементу строки перелета;", "Введите 5 - Поиск ближайшего перелета в определенный Город;",
                    "Введите 6 - Вывод срочной информации на панель!;", "Введите 7 - Добавить пассажира на рейс;",
                    "Введите 8 - Поиск пассажира по ключевым значениям;", "Введите 9 - Изменить информацию о пасажире;",
                    "Введите 10 - Изменить информацию цен на рейс;", "Введите 11 - Удалить пассажира с рейса;",
                    "Введите 12 - Удалить цену на рейс;", "Введите 13 - Вывод информации о ценах классов перелетов;",
                    "Введите 14 - Вывод списка пассажиров;", "Введите 0 - Для выхода из программы."));

                int.TryParse(Console.ReadLine(), out int option);

                NameOfActions enteredEnum = (NameOfActions)Enum.Parse(typeof(NameOfActions), option.ToString());

                if (enteredEnum == NameOfActions.Exit || option > Enum.GetNames(typeof(NameOfActions)).Length - 1)
                {
                    Console.WriteLine("Ошибка при вводе, повторите ввод номера действия!");
                    Console.ReadKey();
                }
                else if (option >= 0 && Enum.GetNames(typeof(NameOfActions)).Length - 1 >= option)
                {
                    BaseFunctions.RunTheVariant(enteredEnum, flights);
                }
            }
        }
    }
}