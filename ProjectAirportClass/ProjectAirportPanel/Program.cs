using System;
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

        public static void AddElement(List<Airoport> Flights)
        {
            Console.WriteLine("Введите 11 элементов строки перелета через кому: (части даты разделять точкой (12.12.2019 0:00:00))");
            string StringOfArrayFlight = Console.ReadLine();
            string[] ArrayFlight = StringOfArrayFlight.Split(',');

            int length = Flights.Count;

            string[] TimeExpected = ArrayFlight[6].Split('.');
            string[] TimeArrival = ArrayFlight[7].Split('.');
            string[] TimeDepature = ArrayFlight[8].Split('.');

            Flights.Add(new Airoport(ArrayFlight[0], ArrayFlight[1], ArrayFlight[2], ArrayFlight[3], ArrayFlight[4], ArrayFlight[5],
            ArrayFlight[6], new DateTime(Convert.ToInt32(TimeExpected[2]), Convert.ToInt32(TimeExpected[1]), Convert.ToInt32(TimeExpected[0])),
            new DateTime(Convert.ToInt32(TimeArrival[2]), Convert.ToInt32(TimeArrival[1]), Convert.ToInt32(TimeArrival[0])),
            new DateTime(Convert.ToInt32(TimeDepature[2]), Convert.ToInt32(TimeDepature[1]), Convert.ToInt32(TimeDepature[0])), FlightStatus.InFlight));

            Flights.OrderBy(u => u.DateAndTimeArival);
        }

        public static void ChangeElement(List<Airoport> Flights)
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
            Flights.OrderBy(u => u.DateAndTimeArival);
        }

        public static void DeleteElement(List<Airoport> Flights)
        {
            Console.WriteLine("Введите номер строки для удаления в формате целого числа: ");

            int numberToRemove = 0;

            while (numberToRemove < 1 || numberToRemove > Flights.Count)
            {
                Console.WriteLine("Введите целое число от 1 до " + Flights.Count.ToString() + '\n');
                numberToRemove = Convert.ToInt32(Console.ReadLine());
            }
            if (Flights.Count > 1)
            {
                Flights.RemoveAt(numberToRemove - 1); 
            }
            else if (Flights.Count == 1)
            {
                Flights.RemoveAt(0);
            }

            Flights.OrderBy(u => u.DateAndTimeArival);
        }

        public static void SearchElement(List<Airoport> Flights)
        {
            Console.WriteLine("Введите строку для поиска данных (название аэропорта или номер рейса или время прибытия)");
            string SearchString = Console.ReadLine();
            string numberOfFlight = "";

            foreach (var flight in Flights)
            {
                if (flight.FlightNumber.Trim(' ') == SearchString || flight.DateAndTimeArival.ToString() == SearchString)
                {
                    numberOfFlight = flight.FlightNumber;
                }
                else if (flight.AiroportArrival.Trim(' ') == SearchString || flight.AiroportDepature == SearchString)
                {
                    numberOfFlight = flight.FlightNumber;
                }
            }

            if (numberOfFlight != "")
            {
                Console.WriteLine("Ваша строка с номером рейса № - " + numberOfFlight);
            }
            else
            {
                Console.WriteLine("По вашему запросу ничего небыло найдено! Нажмите enter для продолжения!");
            }

            Flights.OrderBy(u => u.DateAndTimeArival);
            Console.ReadKey();
        }

        public static void SearchFirstToTheCityElement(List<Airoport> Flights)
        {
            Console.WriteLine("Введите название аэропорта для перелета и удобную для вас дату через кому, дата должна быть в формате (12.12.2019 20:02:00)");
            string[] SearchString = Console.ReadLine().Split(',');

            Flights.OrderBy(u => u.DateAndTimeDepature);

            List<Airoport> result = Flights.Where(x => x.DateAndTimeDepature.ToString() == SearchString[1]
            && x.AiroportArrival == SearchString[0]).ToList();

            foreach (var element in result)
            {
                Console.WriteLine("Ваша строка с номером рейса № - " + element.FlightNumber);
            }

            if (result.Count == 0)
            {
                Console.WriteLine("По вашему запросу ничего небыло найдено! Нажмите enter для продолжения!");
            }

            Flights.OrderBy(u => u.DateAndTimeArival);
            Console.ReadKey();
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

        public static void ReWriteFlightStatuses(List<Airoport> Flights)
        {
            Console.Clear();
            Console.WriteLine("Расписание авиаперелетов: ");
            Console.WriteLine("--------------------------------------------------------" +
            "-----------------------------------------------------------------------------");
            Console.WriteLine("| Departure | Arrival | Air. Arriv. | Air. Depar. | Flight № | Terminal | Gate | Time Expected | Time Arival | Time Depature |"
               + "Status|");

            foreach (var flight in Flights)
            {
                if (!string.IsNullOrEmpty(flight.CityArrival))
                {
                    Console.WriteLine("-----------------------------------------------------" +
                    "--------------------------------------------------------------------------------");
                    Console.ForegroundColor = ColorOfText(flight.Status);
                    Console.WriteLine(flight.CityDepature + "|" + flight.CityArrival + "|" + flight.AiroportDepature + "|" +
                    flight.AiroportArrival + "|" + flight.FlightNumber + "|" + flight.Terminal +
                    "|" + flight.TimeExpected + "|" + flight.DateAndTimeArival + "|" + flight.DateAndTimeDepature + "|" + flight.Status);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            Flights.OrderBy(u => u.DateAndTimeArival);
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
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 30;
            Console.WindowWidth = 150;
            Console.ForegroundColor = ConsoleColor.White;

            List<Airoport> Flights = new List<Airoport>
            {
                new Airoport("Zhytomyr", "Kyiv", "Airoport-1", "Boryspil", "UA228-1488", "D", "1D", new DateTime(2019, 12, 15), new DateTime(2019, 12, 15), new DateTime(2019, 12, 14), Airoport.FlightStatus.InFlight),
                new Airoport("Cherkasy", "Kyiv", "Airoport-2", "Boryspil", "UA227-1488", "F", "2D", new DateTime(2019, 12, 17), new DateTime(2019, 12, 17), new DateTime(2019, 12, 12 ,20,30,00), Airoport.FlightStatus.Checkin),
                new Airoport("Lviv", "Kyiv", "Airoport-3", "Boryspil", "UA229-1488", "A", "3D", new DateTime(2019, 12, 16), new DateTime(2019, 12, 16), new DateTime(2019, 12, 13), Airoport.FlightStatus.Delayed),
                new Airoport("Kharjiv", "Kyiv", "Airoport-4", "Boryspil", "UA222-1488", "C", "4D", new DateTime(2019, 12, 16), new DateTime(2019, 12, 16), new DateTime(2019, 12, 13), Airoport.FlightStatus.Canceled),
                new Airoport("Odessa", "Kyiv", "Airoport-5", "Boryspil", "UA221-1488", "B", "5D", new DateTime(2019, 12, 16), new DateTime(2019, 12, 16), new DateTime(2019, 12, 13), Airoport.FlightStatus.Delayed),
                new Airoport("Sumy", "Kyiv", "Airoport-6", "Boryspil", "UA225-1488", "G", "6D", new DateTime(2019, 12, 16), new DateTime(2019, 12, 16), new DateTime(2019, 12, 13), Airoport.FlightStatus.Delayed)
            };

            bool exit = true;

            while (exit)
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

                int option = 0;

                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ошибка при вводе. Выход из программы.");
                    Console.ReadKey();
                }

                if (option >= 0 & option <= 6)
                {
                    int Answer = RunTheVariant(option, Flights);

                    if (Answer == 0)
                    {
                        exit = false;
                    }
                }
            }
        }

        static int RunTheVariant(int option, List<Airoport> Flights)
        {
            int Answer = 1;

            if (option == 0)
            {
                Answer = 0;
            }
            else if (option == 1)
            {
                Airoport.AddElement(Flights);
            }
            else if (option == 2)
            {
                Airoport.ChangeElement(Flights);
            }
            else if (option == 3)
            {
                Airoport.DeleteElement(Flights);
            }
            else if (option == 4)
            {
                Airoport.SearchElement(Flights);
            }
            else if (option == 5)
            {
                Airoport.SearchFirstToTheCityElement(Flights);
            }
            else if (option == 6)
            {
                BaseFunctions.WriteAlarm();
            }

            return Answer;
        }
    }
}