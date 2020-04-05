using System;

namespace ProjectWPFAirline.ViewModels
{
    public class DataGridAirflightsViewModel
    {
        public int AirFlightID { get; set; }
        public int PriceListID { get; set; }
        public string CityArrival { get; set; }
        public string CityDepature { get; set; }
        public string AiroportArrival { get; set; }
        public string AiroportDepature { get; set; }
        public string FlightNumber { get; set; }
        public string Terminal { get; set; }
        public string Gate { get; set; }
        public DateTime TimeExpected { get; set; }
        public DateTime DateAndTimeArival { get; set; }
        public DateTime DateAndTimeDepature { get; set; }
        public int Status { get; set; }
        public bool IsModified { get; set; }

        public DataGridAirflightsViewModel() { }

        public DataGridAirflightsViewModel(int airFlightID, int priceListID, string cityDepature, string cityArrival, string airoportDepature, string airoportArrival, string flightNumber, string terminal, string gate, DateTime timeExpected, DateTime dateAndTimeArival, DateTime dateAndTimeDepature, int status)
        {
            AirFlightID = airFlightID;
            PriceListID = priceListID;
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
        }
    }
}
