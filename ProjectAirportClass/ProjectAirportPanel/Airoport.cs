using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAirportPanel
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
        public Dictionary<Passenger.ClassOfFlight, int> PriceList;
        public List<Passenger> ListOfPassengers;

        public Airoport(string cityDepature, string cityArrival, string airoportDepature, string airoportArrival, string flightNumber, string terminal, string gate, DateTime timeExpected, DateTime dateAndTimeArival, DateTime dateAndTimeDepature, FlightStatus status, List<Passenger> listOfPassengers, Dictionary<Passenger.ClassOfFlight, int> priceList)
        {
            CityArrival = cityArrival;
            CityDepature = cityDepature;
            AiroportArrival = airoportArrival;
            AiroportDepature = airoportDepature;
            FlightNumber = flightNumber;
            Terminal = terminal;
            Gate = gate;
            TimeExpected = timeExpected;
            DateAndTimeArival = dateAndTimeArival;
            DateAndTimeDepature = dateAndTimeDepature;
            Status = status;
            ListOfPassengers = listOfPassengers;
            PriceList = priceList;
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
}
