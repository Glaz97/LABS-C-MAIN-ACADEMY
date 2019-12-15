using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAirportPanel
{
    class Program
    {
        enum FlightStatus
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

        struct Flights
        {
            string CityArrival;
            string CityDepature;
            string AitportArrival;
            string AitportDepature;
            string FlightNumber;
            string Terminal;
            DateTime TimeExpected;
            DateTime DateAndTimeArival;
            DateTime DateAndTimeDepature;
        }

        static void Main(string[] args)
        {

        }
    }
}
