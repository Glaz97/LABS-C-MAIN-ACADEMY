using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectAirportPanel
{
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

        public static void ReWriteFlightStatuses(SortedList<string, Airoport> flights)
        {
            Console.Clear();
            Console.WriteLine("Расписание авиаперелетов: ");
            Console.WriteLine("--------------------------------------------------------" +
            "-----------------------------------------------------------------------------");
            Console.WriteLine(string.Join(" | ", "Departure", "Arrival", "Air. Arriv.", "Air. Depar.", "Flight №", "Terminal", "Gate",
            "Time Expected", "Time Arival", "Time Depature", "Status"));

            foreach (var flight in flights)
            {
                Console.WriteLine("-----------------------------------------------------" +
                "--------------------------------------------------------------------------------");
                Console.ForegroundColor = ColorOfText(flight.Value.Status);

                var elem = flights.Values.Select(x => x).Where(x => x.FlightNumber == flight.Value.FlightNumber).FirstOrDefault();

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
                return ConsoleColor.Yellow;
            }
            else if (status == Airoport.FlightStatus.Checkin)
            {
                return ConsoleColor.Green;
            }
            else if (status == Airoport.FlightStatus.Canceled)
            {
                return ConsoleColor.Red;
            }

            return Color;
        }

        public static int RunTheVariant(NameOfActions option, SortedList<string, Airoport> flights)
        {
            if (option == NameOfActions.Exit)
            {
                return 0;
            }
            else if (option == NameOfActions.AddElement)
            {
                FlightsActions.AddElement(flights);
            }
            else if (option == NameOfActions.ChangeElement)
            {
                FlightsActions.ChangeElement(flights);
            }
            else if (option == NameOfActions.DeleteElement)
            {
                FlightsActions.DeleteElement(flights);
            }
            else if (option == NameOfActions.SearchElement)
            {
                FlightsActions.SearchElement(flights);
            }
            else if (option == NameOfActions.SearchFirstToTheCityElement)
            {
                FlightsActions.SearchFirstToTheCityElement(flights);
            }
            else if (option == NameOfActions.WriteAlarm)
            {
                WriteAlarm();
            }
            else if (option == NameOfActions.AddPassengerToTheFlight)
            {
                FlightsActions.AddPassengerToTheFlight(flights);
            }
            else if (option == NameOfActions.SearchPassenger)
            {
                FlightsActions.SearchForPassenger(flights);
            }
            else if (option == NameOfActions.WatchTheFlightsPriceList)
            {
                FlightsActions.WatchTheFlightsPriceList(flights);
            }
            else if (option == NameOfActions.EditFlightPriceListInfo)
            {
                FlightsActions.EditFlightPriceListInfo(flights);
            }
            else if (option == NameOfActions.EditPassengerInfo)
            {
                FlightsActions.EditPassengerInfo(flights);
            }
            else if (option == NameOfActions.DeletePassenger)
            {
                FlightsActions.DeletePassenger(flights);
            }
            else if (option == NameOfActions.DeleteFlightPrice)
            {
                FlightsActions.DeleteFlightPrice(flights);
            }
            else if (option == NameOfActions.WatchThePassengerList)
            {
                FlightsActions.WatchThePassengerList(flights);
            }

            return 1;
        }

        public static Dictionary<Passenger.ClassOfFlight, int> GetBasePrices(Random rnd)
        {
            var ArrayOfPrices = new Dictionary<Passenger.ClassOfFlight, int>();

            foreach (var element in Enum.GetValues(typeof(Passenger.ClassOfFlight)))
            {
                ArrayOfPrices.Add((Passenger.ClassOfFlight)element, rnd.Next(0, 1000));
            }

            return ArrayOfPrices;
        }

        public static int ReturnEnteredNumber(string stringToWrite, int countOfFlights)
        {
            int number = 0;

             while (number <= 0 || number > countOfFlights)
            {
                Console.WriteLine(stringToWrite);

                int.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }
    }
}
