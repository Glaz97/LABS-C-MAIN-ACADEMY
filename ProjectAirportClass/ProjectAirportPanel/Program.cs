using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAirportClass
{
    public class Airoport
    {
        public string CityArrival;
        public string CityDepature;
        public string AiroportArrival;
        public string AiroportDepature;
        public string FlightNumber;
        public string Terminal;
        public string Gate;
        public DateTime TimeExpected;
        public DateTime DateAndTimeArival;
        public DateTime DateAndTimeDepature;
        public FlightStatus Status;
        public SortedList<string, Passenger> ListOfPassengers;

        public Airoport(string CityDepature, string CityArrival, string AiroportDepature, string AiroportArrival, string FlightNumber, string Terminal, string Gate, DateTime TimeExpected, DateTime DateAndTimeArival, DateTime DateAndTimeDepature, FlightStatus Status, SortedList<string, Passenger> ListOfPassengers)
        {
            this.CityArrival = CityArrival;
            this.CityDepature = CityDepature;
            this.AiroportArrival = AiroportArrival;
            this.AiroportDepature = AiroportDepature;
            this.FlightNumber = FlightNumber;
            this.Terminal = Terminal;
            this.Gate = Gate;
            this.TimeExpected = TimeExpected;
            this.DateAndTimeArival = DateAndTimeArival;
            this.DateAndTimeDepature = DateAndTimeDepature;
            this.Status = Status;
            this.ListOfPassengers = ListOfPassengers;
        }

        public enum FlightStatus
        {
            Checkin,
            GateClosed,
            Arrived,
            Unknow,
            Canceled,
            ExpectedAt,
            Delayed,
            InFlight
        }
    }

    public class BaseFunctions
    {
        public static void WriteAlarm()
        {
            Console.WriteLine("Введите любую строку для срочного оповещения!");
            string AlarmString = Console.ReadLine();

            Console.WriteLine(AlarmString);
            for (int i = 0; i < 2; i++)
            {
                Console.Beep(300, 500);
                Console.Beep(200, 600);
                Console.Beep(100, 700);
                Console.Beep(400, 800);
            }
            Console.ReadKey();
        }

        public static void ReWriteFlightStatuses(SortedList<string, Airoport> Flights)
        {
            Console.Clear();
            Console.WriteLine("Расписание авиаперелетов: ");
            Console.WriteLine("--------------------------------------------------------" +
            "-----------------------------------------------------------------------------");
            Console.WriteLine(string.Join(" | ", "Departure", "Arrival", "Air. Arriv.", "Air. Depar.", "Flight №", "Terminal", "Gate",
            "Time Expected", "Time Arival", "Time Depature", "Status"));

            foreach (var flight in Flights)
            {
                Console.WriteLine("-----------------------------------------------------" +
                "--------------------------------------------------------------------------------");
                Console.ForegroundColor = ColorOfText(flight.Value.Status);

                var elem = Flights.Values.Select(x => x).Where(x => x.FlightNumber == flight.Value.FlightNumber).FirstOrDefault();

                Console.WriteLine(string.Join("|", elem.CityDepature, elem.CityArrival, elem.AiroportDepature, elem.AiroportArrival,
                elem.FlightNumber, elem.Terminal, elem.TimeExpected, elem.DateAndTimeArival, elem.DateAndTimeDepature, flight.Value.Status));

                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static ConsoleColor ColorOfText(Airoport.FlightStatus status)
        {
            ConsoleColor Color = ConsoleColor.White;

            if (status == Airoport.FlightStatus.Delayed)
            {
                Color = ConsoleColor.Yellow;
            }
            else if (status == Airoport.FlightStatus.Checkin)
            {
                Color = ConsoleColor.Green;
            }
            else if (status == Airoport.FlightStatus.Canceled)
            {
                Color = ConsoleColor.Red;
            }

            return Color;
        }

        public static int RunTheVariant(FlightsActions.NameOfActions option, SortedList<string, Airoport> Flights)
        {
            if (option == FlightsActions.NameOfActions.Exit)
            {
                return 0;
            }
            else if (option == FlightsActions.NameOfActions.AddElement)
            {
                FlightsActions.AddElement(Flights);
            }
            else if (option == FlightsActions.NameOfActions.ChangeElement)
            {
                FlightsActions.ChangeElement(Flights);
            }
            else if (option == FlightsActions.NameOfActions.DeleteElement)
            {
                FlightsActions.DeleteElement(Flights);
            }
            else if (option == FlightsActions.NameOfActions.SearchElement)
            {
                FlightsActions.SearchElement(Flights);
            }
            else if (option == FlightsActions.NameOfActions.SearchFirstToTheCityElement)
            {
                FlightsActions.SearchFirstToTheCityElement(Flights);
            }
            else if (option == FlightsActions.NameOfActions.WriteAlarm)
            {
                WriteAlarm();
            }
            else if (option == FlightsActions.NameOfActions.AddPassengerToTheFlight)
            {
                WriteAlarm();
            }
            else if (option == FlightsActions.NameOfActions.SearchPassenger)
            {
                FlightsActions.SearchForPassenger(Flights);
            }
            else if (option == FlightsActions.NameOfActions.WatchTheClassPriceList)
            {
                WriteAlarm();
            }
            else if (option == FlightsActions.NameOfActions.WatchThePassengerList)
            {
                WriteAlarm();
            }

            return 1;
        }
    }

    public class FlightsActions
    {
        public enum NameOfActions
        {
            Exit = 0,
            AddElement = 1,
            ChangeElement = 2,
            DeleteElement = 3,
            SearchElement = 4,
            SearchFirstToTheCityElement = 5,
            WriteAlarm = 6,
            AddPassengerToTheFlight = 7,
            SearchPassenger = 8,
            WatchTheClassPriceList = 9,
            WatchThePassengerList = 10
        }

        public static SortedList<string, Airoport> RemoveFlightsFromList(SortedList<string, Airoport> Flights, int numberToRemove)
        {
            while (numberToRemove < 1 || numberToRemove > Flights.Count)
            {
                Console.WriteLine("Введите целое число от 1 до " + Flights.Count.ToString() + '\n');
                numberToRemove = Convert.ToInt32(Console.ReadLine());
            }

            Flights.RemoveAt(numberToRemove - 1);

            return Flights;
        }

        public static void AddElement(SortedList<string, Airoport> Flights)
        {
            Console.WriteLine("Введите 11 элементов строки перелета: ");

            var ArrayOfFields = new string[]{ "город прибытия", "город вылета", "город вылета", "аэропорт  вылета", "номер рейса",
            "наименование терминала", "наименование ворот", "дату и время ожидаемого прилета", "дату и время прилета",
            "дату и время вылета", "Номер статуса полета" };

            var AiroportArray = new ArrayList();

            foreach (var explanation in ArrayOfFields)
            {
                BaseFunctions.ReWriteFlightStatuses(Flights);
                Console.WriteLine("\n" + "Введите " + explanation);
                AiroportArray.Add(Console.ReadLine());
            }

            try
            {
                Console.WriteLine("Добавить пассажиров к рейсу - нажмите 1");

                int.TryParse(Console.ReadLine(), out int option);
                var PassengersList = new SortedList<string, Passenger>();

                if (option == 1)
                {
                    PassengersList = AddPassengers(Flights, PassengersList);
                }
                else
                {
                    Console.WriteLine("Список пассажиров будет пустым");
                }

                var Status = Airoport.FlightStatus.Unknow;
                Enum.TryParse(AiroportArray[10].ToString(), out Status);

                Flights.Add(AiroportArray[4].ToString(), new Airoport(
                AiroportArray[0].ToString(), AiroportArray[1].ToString(), AiroportArray[2].ToString(),
                AiroportArray[3].ToString(), AiroportArray[4].ToString(), AiroportArray[5].ToString(),
                AiroportArray[6].ToString(), DateTime.Parse(AiroportArray[7].ToString()),
                DateTime.Parse(AiroportArray[8].ToString()), DateTime.Parse(AiroportArray[9].ToString()), Status, PassengersList));
            }
            catch
            {
                Console.WriteLine("Возникла ошибка при попытке обработки ваших данных! Повторите ввод заново!");
                Console.ReadKey();
            }
        }

        public static void ChangeElement(SortedList<string, Airoport> Flights)
        {
            Console.WriteLine("Введите номер строки для изменения в формате целого числа: ");

            int.TryParse(Console.ReadLine(), out int StringNumber);

            Flights = RemoveFlightsFromList(Flights, StringNumber);
            AddElement(Flights);
        }

        public static void DeleteElement(SortedList<string, Airoport> Flights)
        {
            Console.WriteLine("Введите номер строки для удаления в формате целого числа: ");

            int.TryParse(Console.ReadLine(), out int StringNumber);

            Flights = RemoveFlightsFromList(Flights, StringNumber);
        }

        public static void SearchElement(SortedList<string, Airoport> Flights)
        {
            Console.WriteLine("Введите строку для поиска данных (название аэропорта или номер рейса или время прибытия)");
            string SearchString = Console.ReadLine();

            var Array = Flights.Values.Where(x => x.FlightNumber == SearchString || x.DateAndTimeArival.ToString() == SearchString ||
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

        public static void SearchFirstToTheCityElement(SortedList<string, Airoport> Flights)
        {
            Console.WriteLine("Введите название аэропорта для перелета");
            var AiroportArrival = Console.ReadLine();

            Console.WriteLine("Введите дату и время перелета");
            var Date = DateTime.Parse(Console.ReadLine());

            var result = Flights.Values.Where(x => x.DateAndTimeDepature == Date
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

        public static void SearchForPassenger (SortedList<string, Airoport> Flights)
        {
            Console.WriteLine("Введите строку для поиска данных (номер рейса или другое ключевое поле)");
            string SearchString = Console.ReadLine();

            var Array = Flights.Values.Where(g => g.FlightNumber == SearchString.ToString()).Select(x => x.ListOfPassengers).Select(c => c.Values);

            foreach (var element in Array)
            {
                var test = element;
            }

            if (Array.Count() > 0)
            {
               //Console.WriteLine("Ваша строка с номером рейса № - " + Array.First().FlightNumber);
            }
            else
            {
                Console.WriteLine("По вашему запросу ничего небыло найдено! Нажмите enter для продолжения!");
            }
        }

        public static SortedList<string, Passenger> AddPassengers(SortedList<string, Airoport> Flights, SortedList<string, Passenger> Passangers)
        {
            Console.WriteLine("Введите 8 элементов строки перелета: ");

            var ArrayOfFields = new string[]{ "имя", "фамилию", "национальность", "серия и номер пасспорта", "дата рождения",
            "пол (0 - женщина, 1 - мужчина)", "номер класса рейса", "номер рейса"};

            var PassengersArray = new ArrayList();

            foreach (var explanation in ArrayOfFields)
            {
                BaseFunctions.ReWriteFlightStatuses(Flights);
                Console.WriteLine("\n" + "Введите " + explanation);
                PassengersArray.Add(Console.ReadLine());
            }

            try
            {
                if (Flights.Values.Where(x => x.FlightNumber == PassengersArray[7].ToString()).Count() == 0)
                {
                    Console.WriteLine("Ошибка, не найден рейс с указанным вами номером рейса");
                    throw new NotImplementedException();
                }

                var ClassOfFlight = Passenger.ClassOfFlight.Econom;
                Enum.TryParse(PassengersArray[6].ToString(), out ClassOfFlight);

                var Sex = Passenger.SexValue.Women;
                Enum.TryParse(PassengersArray[5].ToString(), out Sex);

                Passangers.Add(PassengersArray[7].ToString(), new Passenger(
                PassengersArray[0].ToString(), PassengersArray[1].ToString(), PassengersArray[2].ToString(),
                PassengersArray[3].ToString(), DateTime.Parse(PassengersArray[4].ToString()), Sex,
                ClassOfFlight));
            }
            catch
            {
                Console.WriteLine("Возникла ошибка при попытке обработки ваших данных! Повторите ввод заново!");
                Console.ReadKey();
            }

            return Passangers;
        }
    }

    public class Passenger
    {
        public string FirstName;
        public string SecondName;
        public string Nationality;
        public string PassportNumber;
        public DateTime DateOfBirth;
        public SexValue Sex;
        public ClassOfFlight FlightClass;
        public string FlightNumber;

        public enum SexValue
        {
            Women,
            Man
        }
        public enum ClassOfFlight
        {
            Econom,
            Business,
            BusinessPlus
        }

        public Passenger(string FirstName, string SecondName, string Nationality, string PassportNumber, DateTime DateOfBirth, SexValue Sex, ClassOfFlight FlightClass)
        {
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.Nationality = Nationality;
            this.PassportNumber = PassportNumber;
            this.Sex = Sex;
            this.FlightClass = FlightClass;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 30;
            Console.WindowWidth = 150;
            Console.ForegroundColor = ConsoleColor.White;

            var ListOfPassengers = new List<Passenger>
            {
                new Passenger("Vasya", "Pupkin", "Russia", "FG2281488", new DateTime(29081977), Passenger.SexValue.Man, Passenger.ClassOfFlight.Business),
                new Passenger("Maria", "Pupkina", "Russia", "FG2291488", new DateTime(29081977), Passenger.SexValue.Women, Passenger.ClassOfFlight.Business),
                new Passenger("Feodisyu", "Pupkin", "Russia", "FG2301488", new DateTime(29081977), Passenger.SexValue.Man, Passenger.ClassOfFlight.Business)
            };

            Random rnd = new Random();

            var Flights = new SortedList<string, Airoport>
            {
                {"UA228-1488", new Airoport("Zhytomyr", "Kyiv", "Airoport-1", "Boryspil", "UA228-1488", "D", "1D", new DateTime(2019, 12, 15), new DateTime(2019, 12, 15), new DateTime(2019, 12, 14), Airoport.FlightStatus.InFlight,new SortedList<string, Passenger>{ { "UA228-1488", ListOfPassengers[rnd.Next(0, ListOfPassengers.Count)] } }) },
                {"UA229-1488", new Airoport("Lviv", "Kyiv", "Airoport-3", "Boryspil", "UA229-1488", "A", "3D", new DateTime(2019, 12, 16), new DateTime(2019, 12, 16), new DateTime(2019, 12, 13), Airoport.FlightStatus.Delayed,new SortedList<string, Passenger>{ { "UA229-1488", ListOfPassengers[rnd.Next(0, ListOfPassengers.Count)] } }) },
                {"UA222-1488", new Airoport("Kharjiv", "Kyiv", "Airoport-4", "Boryspil", "UA222-1488", "C", "4D", new DateTime(2019, 12, 16), new DateTime(2019, 12, 16), new DateTime(2019, 12, 13), Airoport.FlightStatus.Canceled,new SortedList<string, Passenger>{ { "UA222-1488", ListOfPassengers[rnd.Next(0, ListOfPassengers.Count)] } }) },
                {"UA221-1488", new Airoport("Odessa", "Kyiv", "Airoport-5", "Boryspil", "UA221-1488", "B", "5D", new DateTime(2019, 12, 16), new DateTime(2019, 12, 16), new DateTime(2019, 12, 13), Airoport.FlightStatus.Delayed,new SortedList<string, Passenger>{ { "UA221-1488", ListOfPassengers[rnd.Next(0, ListOfPassengers.Count)] } })},
                {"UA225-1488", new Airoport("Sumy", "Kyiv", "Airoport-6", "Boryspil", "UA225-1488", "G", "6D", new DateTime(2019, 12, 16), new DateTime(2019, 12, 16), new DateTime(2019, 12, 13), Airoport.FlightStatus.Delayed,new SortedList<string, Passenger>{ { "UA225-1488", ListOfPassengers[rnd.Next(0, ListOfPassengers.Count)] } })}
            };

            while (true)
            {
                BaseFunctions.ReWriteFlightStatuses(Flights);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n" + string.Join("\n", "Меню действий:", "Введите 1 - Добавить элемент перелета;",
                    "Введите 2 - Изменить элемент перелета;", "Введите 3 - Удалить элемент перелета;",
                    "Введите 4 - Поиск по элементу строки перелета;", "Введите 5 - Поиск ближайшего перелета в определенный Город;",
                    "Введите 6 - Вывод срочной информации на панель!;", "Введите 7 - Добавить пассажира на рейс;",
                    "Введите 8 - Поиск пассажира по ключевым значениям;", "Введите 9 - Вывод информации о ценах классов перелетов;",
                    "Введите 10 - Вывод списка пассажиров по номеру рейса;", "Введите 0 - Для выхода из программы."));

                int.TryParse(Console.ReadLine(), out int option);

                FlightsActions.NameOfActions EnteredEnum = (FlightsActions.NameOfActions)Enum.Parse(typeof(FlightsActions.NameOfActions), option.ToString());

                if (EnteredEnum == FlightsActions.NameOfActions.Exit)
                {
                    break;
                }
                else if (EnteredEnum >= 0 && Convert.ToInt32(Enum.GetNames(typeof(FlightsActions.NameOfActions)).Length) - 1 >= (int)EnteredEnum)
                {
                    BaseFunctions.RunTheVariant(EnteredEnum, Flights);
                }
                else
                {
                    Console.WriteLine("Ошибка при вводе, повторите ввод номера действия!");
                    Console.ReadKey();
                }
            }
        }
    }
}