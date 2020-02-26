using static ProjectAirportPanel.BaseFunctions;
using static ProjectAirportPanel.Airoport;
using static ProjectAirportPanel.Passenger;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProjectAirportPanel
{
    public enum NameOfActions
    {
        Exit,
        AddElement,
        ChangeElement,
        DeleteElement,
        SearchElement,
        SearchFirstToTheCityElement,
        WriteAlarm,
        AddPassengerToTheFlight,
        SearchPassenger,
        EditPassengerInfo,
        EditFlightPriceListInfo,
        DeletePassenger,
        DeleteFlightPrice,
        WatchTheFlightsPriceList,
        WatchThePassengerList
    }

    public class FlightsActions
    {
        public static SortedList<string, Airoport> RemoveFlightsFromList(SortedList<string, Airoport> flights, int numberToRemove)
        {
            while (numberToRemove < 1 || numberToRemove > flights.Count)
            {
                Console.WriteLine("Введите целое число от 1 до " + flights.Count.ToString() + '\n');
                numberToRemove = Convert.ToInt32(Console.ReadLine());
            }

            flights.RemoveAt(numberToRemove - 1);

            return flights;
        }

        public static void AddElement(SortedList<string, Airoport> flights)
        {
            Console.WriteLine("Введите 11 элементов строки перелета: ");

            var ArrayOfFields = new string[]{ "город прибытия", "город вылета", "город вылета", "аэропорт  вылета", "номер рейса",
            "наименование терминала", "наименование ворот", "дату и время ожидаемого прилета", "дату и время прилета",
            "дату и время вылета", "Номер статуса полета" };

            var AiroportArray = new List<string>();

            foreach (var explanation in ArrayOfFields)
            {
                ReWriteFlightStatuses(flights);
                Console.WriteLine("\n" + "Введите " + explanation);
                AiroportArray.Add(Console.ReadLine());
            }

            try
            {
                Console.WriteLine("Добавить пассажиров к рейсу - нажмите 1");

                int.TryParse(Console.ReadLine(), out int option);

                if (option != 1)
                {
                    Console.WriteLine("Список пассажиров будет пустым");
                }

                var passengersList = option == 1 ? AddPassengers(flights, new List<Passenger>()) : new List<Passenger>();

                Enum.TryParse(AiroportArray[10], out FlightStatus Status);

                var input = AiroportArray[10];

                while (Convert.ToInt32(input) < 1 || Convert.ToInt32(input) > Enum.GetNames(typeof(NameOfActions)).Length - 1)
                {
                    Console.WriteLine("Неверный ввод номера статуса полета, повторите ввод");
                    input = Console.ReadLine();
                    Enum.TryParse(input, out Status);
                }

                Random rnd = new Random();

                flights.Add(AiroportArray[4], new Airoport(
                AiroportArray[0], AiroportArray[1], AiroportArray[2],
                AiroportArray[3], AiroportArray[4], AiroportArray[5],
                AiroportArray[6], DateTime.Parse(AiroportArray[7]),
                DateTime.Parse(AiroportArray[8]), DateTime.Parse(AiroportArray[9]),
                Status, passengersList, GetBasePrices(rnd)));
            }
            catch
            {
                Console.WriteLine("Возникла ошибка при попытке обработки ваших данных! Повторите ввод заново!");
                Console.ReadKey();
            }
        }

        public static void ChangeElement(SortedList<string, Airoport> flights)
        {
            int number = ReturnEnteredNumber("Введите номер строки для изменения данных о рейсе: ",
                flights.Count());

            flights = RemoveFlightsFromList(flights, number);
            AddElement(flights);
        }

        public static void DeleteElement(SortedList<string, Airoport> flights)
        {
            int number = ReturnEnteredNumber("Введите номер строки для удаления в формате целого числа: ",
    flights.Count());

            flights = RemoveFlightsFromList(flights, number);
        }

        public static void SearchElement(SortedList<string, Airoport> flights)
        {
            Console.WriteLine("Введите строку для поиска данных (название аэропорта или номер рейса или время прибытия)");
            string SearchString = Console.ReadLine();

            var Array = flights.Values.Where(x => x.FlightNumber == SearchString || x.DateAndTimeArival.ToString() == SearchString ||
                x.AiroportArrival == SearchString || x.AiroportDepature == SearchString);

            if (Array.Count() > 0)
            {
                Console.WriteLine("Ваша строка с номером рейса № - " + Array.First().FlightNumber);
            }
            else
            {
                Console.WriteLine("По вашему запросу ничего небыло найдено! Нажмите enter для продолжения!");
            }

            Console.ReadKey();
        }

        public static void SearchFirstToTheCityElement(SortedList<string, Airoport> flights)
        {
            Console.WriteLine("Введите название аэропорта для перелета");
            var AiroportArrival = Console.ReadLine();

            Console.WriteLine("Введите дату и время перелета");

            var Date = new DateTime();

            try
            {
                Date = DateTime.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Произошла ошибка при вводе даты, дата будет установлена текущим временем");
                Date = DateTime.Now;
                Console.ReadKey();
            }

            var result = flights.Values.Where(x => x.DateAndTimeDepature == Date
                && x.AiroportArrival == AiroportArrival).ToList();

            foreach (var element in result)
            {
                Console.WriteLine("Ваша строка с номером рейса № - " + element.FlightNumber);
            }

            if (result.Count == 0)
            {
                Console.WriteLine("По вашему запросу ничего небыло найдено! Нажмите enter для продолжения!");
            }

            Console.ReadKey();
        }

        public static void SearchForPassenger(SortedList<string, Airoport> flights)
        {
            Console.WriteLine("Введите строку для поиска данных (номер рейса или другое ключевое поле)");
            string SearchString = Console.ReadLine();

            var ArrayByFlightNumber = flights.Values.Where(g => g.FlightNumber == SearchString).Select(x => x.ListOfPassengers);
            var ArrayByPassengerData = flights.Values.Select(x => x.ListOfPassengers.Where(g => g.PassportNumber == SearchString
                || g.FirstName == SearchString | g.SecondName == SearchString).Select(z => z));

            if (ArrayByFlightNumber.Count() > 0)
            {
                foreach (var ListPassanger in ArrayByFlightNumber)
                {
                    foreach (var passanger in ListPassanger)
                    {
                        Console.WriteLine("Ваша пассажир найден - " + passanger.FirstName + " " + passanger.SecondName +
                       " " + passanger.PassportNumber + ", номер рейса - " + SearchString);
                    }
                }

                Console.ReadKey();
            }
            else if (ArrayByPassengerData.Count() > 0)
            {
                foreach (var ListPassanger in ArrayByPassengerData)
                {
                    foreach (var passanger in ListPassanger)
                    {
                        var FlightNumber = flights.Values.Where(x => x.ListOfPassengers.Contains(passanger)).Select(z => z.FlightNumber).First();
                        Console.WriteLine("Ваш пассажир найден - " + passanger.FirstName + " " + passanger.SecondName + " " +
                        passanger.PassportNumber + ", номер рейса - " + FlightNumber);
                    }
                }

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("По вашему запросу ничего небыло найдено! Нажмите enter для продолжения!");
            }
        }

        public static void WatchThePassengerList(SortedList<string, Airoport> flights)
        {
            var ListArrayOfPassengers = flights.Values.Select(z => z.ListOfPassengers).Where(x => x.Count > 0);

            foreach (var ListElement in ListArrayOfPassengers)
            {
                foreach (var passanger in ListElement)
                {
                    var Flight = flights.Values.Select(z => z).Where(z => z.ListOfPassengers.Select(d => d).Where(x => x.PassportNumber == passanger.PassportNumber).Count() > 0).First();
                    Console.WriteLine("Пассажир - " + passanger.FirstName + " " + passanger.SecondName + " "
                    + passanger.PassportNumber + " | " + Flight.FlightNumber + " | ворота - " + Flight.Gate);
                }
            }
            Console.ReadKey();
        }

        public static List<Passenger> AddPassengers(SortedList<string, Airoport> flights, List<Passenger> passangers)
        {
            Console.WriteLine("Введите 8 элементов строки перелета: ");

            var ArrayOfFields = new string[]{ "имя", "фамилию", "национальность", "серия и номер пасспорта", "дата рождения",
            "пол (0 - женщина, 1 - мужчина)", "номер класса рейса", "номер рейса"};

            var PassengersArray = new List<string>();

            foreach (var explanation in ArrayOfFields)
            {
                ReWriteFlightStatuses(flights);
                Console.WriteLine("\n" + "Введите " + explanation);
                PassengersArray.Add(Console.ReadLine());
            }

            try
            {
                if (flights.Values.Where(x => x.FlightNumber == PassengersArray[7]).Count() == 0)
                {
                    Console.WriteLine("Ошибка, не найден рейс с указанным вами номером рейса");
                    throw new NotImplementedException();
                }

                Enum.TryParse(PassengersArray[6], out ClassOfFlight ClassOfFlight);

                var input = PassengersArray[6];

                while (Convert.ToInt32(input) < 0 || Convert.ToInt32(input) > Enum.GetNames(typeof(ClassOfFlight)).Length - 1)
                {
                    Console.WriteLine("Неверный ввод номера класса полета, повторите ввод");
                    input = Console.ReadLine();
                    Enum.TryParse(input, out ClassOfFlight);
                }

                var input2 = PassengersArray[5];

                Enum.TryParse(PassengersArray[5], out SexValue Sex);

                while (Convert.ToInt32(input2) < 0 || Convert.ToInt32(input2) > Enum.GetNames(typeof(SexValue)).Length - 1)
                {
                    Console.WriteLine("Неверный ввод номера пола, повторите ввод");
                    input = Console.ReadLine();
                    Enum.TryParse(input, out Sex);
                }

                var NewPassanger = new Passenger(PassengersArray[0], PassengersArray[1], PassengersArray[2],
                    PassengersArray[3], DateTime.Parse(PassengersArray[4]), Sex, ClassOfFlight);

                var ListOfPassangers = flights.Values.Where(z => z.FlightNumber == PassengersArray[7]).
                    Select(x => x.ListOfPassengers);

                ListOfPassangers.First().Add(NewPassanger);
            }
            catch
            {
                Console.WriteLine("Возникла ошибка при попытке обработки ваших данных! Повторите ввод заново!");
                Console.ReadKey();
            }

            return passangers;
        }

        public static void AddPassengerToTheFlight(SortedList<string, Airoport> flights)
        {
            Console.WriteLine("Введите 8 элементов строки перелета: ");

            var ArrayOfFields = new string[]{ "имя", "фамилию", "национальность", "серия и номер пасспорта", "дата рождения",
            "пол (0 - женщина, 1 - мужчина)", "номер класса рейса", "номер рейса"};

            var PassengersArray = new List<string>();

            foreach (var explanation in ArrayOfFields)
            {
                ReWriteFlightStatuses(flights);
                Console.WriteLine("\n" + "Введите " + explanation);
                PassengersArray.Add(Console.ReadLine());
            }

            try
            {
                if (flights.Values.Where(x => x.FlightNumber == PassengersArray[7].ToString()).Count() == 0)
                {
                    Console.WriteLine("Ошибка, не найден рейс с указанным вами номером рейса");
                    throw new NotImplementedException();
                }

                Enum.TryParse(PassengersArray[6], out ClassOfFlight ClassOfFlight);

                var input = PassengersArray[6];

                while (Convert.ToInt32(input) < 0 || Convert.ToInt32(input) > Enum.GetNames(typeof(ClassOfFlight)).Length - 1)
                {
                    Console.WriteLine("Неверный ввод номера класса полета, повторите ввод");
                    input = Console.ReadLine();
                    Enum.TryParse(input, out ClassOfFlight);
                }

                var input2 = PassengersArray[5];

                Enum.TryParse(PassengersArray[5], out SexValue Sex);

                while (Convert.ToInt32(input2) < 0 || Convert.ToInt32(input2) > Enum.GetNames(typeof(SexValue)).Length - 1)
                {
                    Console.WriteLine("Неверный ввод номера пола, повторите ввод");
                    input = Console.ReadLine();
                    Enum.TryParse(input, out Sex);
                }

                var Passanger = new SortedList<string, Passenger>();

                var NewPassanger = new Passenger(PassengersArray[0], PassengersArray[1], PassengersArray[2],
                PassengersArray[3], DateTime.Parse(PassengersArray[4]), Sex, ClassOfFlight);

                var ListOfPassangers = flights.Values.Where(z => z.FlightNumber == PassengersArray[7]).
                    Select(x => x.ListOfPassengers);

                ListOfPassangers.First().Add(NewPassanger);
            }
            catch
            {
                Console.WriteLine("Возникла ошибка при попытке обработки ваших данных! Повторите ввод заново!");
                Console.ReadKey();
            }
        }

        public static void WatchTheFlightsPriceList(SortedList<string, Airoport> flights)
        {
            foreach (var flight in flights.Values)
            {
                Console.WriteLine("Цены на рейс номер - " + flight.FlightNumber + ":");
                foreach (var price in flight.PriceList)
                {
                    Console.WriteLine("        Цена класса - " + price.Key + " равна " + price.Value + " грЫвень;");
                }
            }
            Console.ReadKey();
        }

        public static List<Passenger> CreateNewListOfPasssangers(Random rnd)
        {
            var ListOfPassengers = new List<Passenger>
            {
                new Passenger("Valentyn", "Pupkin", "Russia", "FG" + rnd.Next(1234,2345), new DateTime(1997,08,29), SexValue.Man, ClassOfFlight.Business),
                new Passenger("Evdokiya", "Pupkina", "Russia", "FG" + rnd.Next(1765,2123), new DateTime(1997,07,29), SexValue.Women, ClassOfFlight.Business),
                new Passenger("Feodisyu", "Pupkin", "Russia", "FG" + rnd.Next(1456,2675), new DateTime(1997,06,29), SexValue.Man, ClassOfFlight.Business)
            };

            return ListOfPassengers;
        }

        public static void EditFlightPriceListInfo(SortedList<string, Airoport> flights)
        {
            Console.WriteLine("Введите номер рейса для редактирования");
            var FlightNumber = Console.ReadLine();

            int NumberOfPriceClass = -1;

            while (NumberOfPriceClass < 0 || NumberOfPriceClass > 2)
            {
                Console.WriteLine("Введите номер класса цен для редактирования (0 - Econom, 1 - Bussines, 2 - BussinesPlus)");
                int.TryParse(Console.ReadLine(), out NumberOfPriceClass);
            }

            Console.WriteLine("Введите новую цену");
            int.TryParse(Console.ReadLine(), out int newPriceOfClass);

            ClassOfFlight enteredEnum = (ClassOfFlight)Enum.Parse(typeof(ClassOfFlight), NumberOfPriceClass.ToString());

            try
            {
                var ArrayFlights = flights.Values.Where(x => x.FlightNumber == FlightNumber).Select(x => x.PriceList).First();

                ArrayFlights.Remove(enteredEnum);
                ArrayFlights.Add(enteredEnum, newPriceOfClass);
            }
            catch
            {
                Console.WriteLine("Ошибка при попытке обработки информации! Попробуйте еще раз!");
                Console.ReadKey();
            }
        }

        public static void EditPassengerInfo(SortedList<string, Airoport> flights)
        {
            DeletePassenger(flights);

            try
            {
                AddPassengerToTheFlight(flights);
            }
            catch
            {
                Console.WriteLine("Ошибка при попытке обработки информации! Попробуйте еще раз!");
                Console.ReadKey();
            }
        }

        public static void DeletePassenger(SortedList<string, Airoport> flights)
        {
            Console.WriteLine("Введите номер рейса для редактирования");
            var FlightNumber = Console.ReadLine();

            Console.WriteLine("Введите номер пасспорта пассажира");
            var PassportNumber = Console.ReadLine();

            try
            {
                var ArrayPassangers = flights.Values.Where(x => x.FlightNumber == FlightNumber).Select(x => x.ListOfPassengers).First();

                ArrayPassangers.Remove(ArrayPassangers.Where(x => x.PassportNumber == PassportNumber).Select(x => x).First());
            }
            catch
            {
                Console.WriteLine("Ошибка при попытке обработки информации! Попробуйте еще раз!");
                Console.ReadKey();
            }
        }

        public static void DeleteFlightPrice(SortedList<string, Airoport> flights)
        {
            Console.WriteLine("Введите номер рейса для редактирования");
            var flightNumber = Console.ReadLine();

            int numberOfPriceClass = -1;

            while (numberOfPriceClass < 0 || numberOfPriceClass > 2)
            {
                Console.WriteLine("Введите номер класса цен для редактирования (0 - Econom, 1 - Bussines, 2 - BussinesPlus)");
                int.TryParse(Console.ReadLine(), out numberOfPriceClass);
            }

            ClassOfFlight enteredEnum = (ClassOfFlight)Enum.Parse(typeof(ClassOfFlight), numberOfPriceClass.ToString());

            try
            {
                var ArrayFlights = flights.Values.Where(x => x.FlightNumber == flightNumber).Select(x => x.PriceList).First();

                ArrayFlights.Remove(enteredEnum);
            }
            catch
            {
                Console.WriteLine("Ошибка при попытке обработки информации! Попробуйте еще раз!");
                Console.ReadKey();
            }
        }
    }
}
