using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAiroportASP_NET.Models
{
    [Table("Airflights")]
    public class Airflights
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

        public Airflights () { }
    }
}