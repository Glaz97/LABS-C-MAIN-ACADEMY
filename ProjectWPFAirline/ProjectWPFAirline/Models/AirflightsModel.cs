using ProjectWPFAirline.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWPFAirline
{
    [Table("Airflights")]
    public class AirflightsModel
    {
        [Key]
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

        public AirflightsModel() { }

        public AirflightsModel(int priceListID, string cityDepature, string cityArrival, string airoportDepature, string airoportArrival, string flightNumber, string terminal, string gate, DateTime timeExpected, DateTime dateAndTimeArival, DateTime dateAndTimeDepature, int status)
        {
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

        public enum FlightStatus
        {
            Checkin = 1,
            GateClosed,
            Arrived,
            Unknow,
            Canceled,
            ExpectedAt,
            Delayed,
            InFlight
        }

        public static explicit operator AirflightsModel(DataGridAirflightsViewModel viewModel)
        {
            AirflightsModel airflightsModel = new AirflightsModel
            {
                AirFlightID = viewModel.AirFlightID,
                PriceListID = viewModel.PriceListID,
                CityArrival = viewModel.CityArrival,
                CityDepature = viewModel.CityDepature,
                AiroportArrival = viewModel.AiroportArrival,
                AiroportDepature = viewModel.AiroportDepature,
                FlightNumber = viewModel.FlightNumber,
                Terminal = viewModel.Terminal,
                Gate = viewModel.Gate,
                TimeExpected = viewModel.TimeExpected,
                DateAndTimeArival = viewModel.DateAndTimeArival,
                DateAndTimeDepature = viewModel.DateAndTimeDepature,
                Status = viewModel.Status
            };

            return airflightsModel;
        }
    }
}
