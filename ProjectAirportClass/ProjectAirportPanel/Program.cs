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

        public Airoport(string CityDepature, string CityArrival, string AiroportDepature, string AiroportArrival, string FlightNumber, string Terminal, string Gate, DateTime TimeExpected, DateTime DateAndTimeArival, DateTime DateAndTimeDepature, FlightStatus Status)
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
            Console.WriteLine(string.Join(" | ","Departure","Arrival","Air. Arriv.","Air. Depar.","Flight №","Terminal","Gate",
            "Time Expected","Time Arival","Time Depature","Status"));

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
            int Answer = 1;

            if (option == FlightsActions.NameOfActions.Exit)
            {
                Answer = 0;
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

            return Answer;
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
            WriteAlarm = 6
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
                var Status = Airoport.FlightStatus.Unknow;
                Enum.TryParse(AiroportArray[10].ToString(), out Status);

                Flights.Add(AiroportArray[4].ToString(), new Airoport(
                AiroportArray[0].ToString(), AiroportArray[1].ToString(), AiroportArray[2].ToString(),
                AiroportArray[3].ToString(), AiroportArray[4].ToString(), AiroportArray[5].ToString(),
                AiroportArray[6].ToString(), DateTime.Parse(AiroportArray[7].ToString()),
                DateTime.Parse(AiroportArray[8].ToString()), DateTime.Parse(AiroportArray[9].ToString()), Status));
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
            int numberToRemove = 0;

            while (numberToRemove < 1 || numberToRemove > Flights.Count)
            {
                Console.WriteLine("Введите целое число от 1 до " + Flights.Count.ToString() + '\n');
                numberToRemove = Convert.ToInt32(Console.ReadLine());
            }

            Flights.RemoveAt(numberToRemove - 1);

            AddElement(Flights);
        }

        public static void DeleteElement(SortedList<string, Airoport> Flights)
        {
            Console.WriteLine("Введите номер строки для удаления в формате целого числа: ");

            int numberToRemove = 0;

            while (numberToRemove < 1 || numberToRemove > Flights.Count)
            {
                Console.WriteLine("Введите целое число от 1 до " + Flights.Count.ToString() + '\n');
                numberToRemove = Convert.ToInt32(Console.ReadLine());
            }

            Flights.RemoveAt(numberToRemove - 1);
        }

        public static void SearchElement(SortedList<string, Airoport> Flights)
        {
            Console.WriteLine("Введите строку для поиска данных (название аэропорта или номер рейса или время прибытия)");
            string SearchString = Console.ReadLine();

            var Array1 = Flights.Values.Where(x => x.FlightNumber == SearchString || x.DateAndTimeArival.ToString() == SearchString);
            var Array2 = Flights.Values.Where(x => x.AiroportArrival == SearchString || x.AiroportDepature == SearchString);

            if (Array1.Count() > 0 || Array2.Count() > 0)
            {
                var FlightNumber = Array1.Count() > 0 ? Array1.FirstOrDefault().FlightNumber : Array2.FirstOrDefault().FlightNumber;
                Console.WriteLine("Ваша строка с номером рейса № - " + FlightNumber);
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
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 30;
            Console.WindowWidth = 150;
            Console.ForegroundColor = ConsoleColor.White;

            SortedList<string, Airoport> Flights = new SortedList<string, Airoport>
            {
                {"UA228-1488", new Airoport("Zhytomyr", "Kyiv", "Airoport-1", "Boryspil", "UA228-1488", "D", "1D", new DateTime(2019, 12, 15), new DateTime(2019, 12, 15), new DateTime(2019, 12, 14), Airoport.FlightStatus.InFlight) },
                {"UA229-1488", new Airoport("Lviv", "Kyiv", "Airoport-3", "Boryspil", "UA229-1488", "A", "3D", new DateTime(2019, 12, 16), new DateTime(2019, 12, 16), new DateTime(2019, 12, 13), Airoport.FlightStatus.Delayed) },
                {"UA222-1488", new Airoport("Kharjiv", "Kyiv", "Airoport-4", "Boryspil", "UA222-1488", "C", "4D", new DateTime(2019, 12, 16), new DateTime(2019, 12, 16), new DateTime(2019, 12, 13), Airoport.FlightStatus.Canceled) },
                {"UA221-1488", new Airoport("Odessa", "Kyiv", "Airoport-5", "Boryspil", "UA221-1488", "B", "5D", new DateTime(2019, 12, 16), new DateTime(2019, 12, 16), new DateTime(2019, 12, 13), Airoport.FlightStatus.Delayed)},
                {"UA225-1488", new Airoport("Sumy", "Kyiv", "Airoport-6", "Boryspil", "UA225-1488", "G", "6D", new DateTime(2019, 12, 16), new DateTime(2019, 12, 16), new DateTime(2019, 12, 13), Airoport.FlightStatus.Delayed)}
            };

            while (true)
            {
                BaseFunctions.ReWriteFlightStatuses(Flights);

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\n");
                Console.WriteLine("Меню действий:");
                Console.WriteLine("Введите 1 - Добавить элемент перелета;");
                Console.WriteLine("Введите 2 - Изменить элемент перелета;");
                Console.WriteLine("Введите 3 - Удалить элемент перелета;");
                Console.WriteLine("Введите 4 - Поиск по элементу строки перелета;");
                Console.WriteLine("Введите 5 - Поиск ближайшего перелета в определенный Город;");
                Console.WriteLine("Введите 6 - Вывод срочной информации на панель!;");
                Console.WriteLine("Введите 0 - Для выхода из программы.");

                int.TryParse(Console.ReadLine(), out int option);

                FlightsActions.NameOfActions myEnum = (FlightsActions.NameOfActions)Enum.Parse(typeof(FlightsActions.NameOfActions), option.ToString());

                if (myEnum != FlightsActions.NameOfActions.Exit)
                {
                    int Answer = BaseFunctions.RunTheVariant(myEnum, Flights);

                    if (Answer == (int)FlightsActions.NameOfActions.Exit)
                    {
                        break;
                    }
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