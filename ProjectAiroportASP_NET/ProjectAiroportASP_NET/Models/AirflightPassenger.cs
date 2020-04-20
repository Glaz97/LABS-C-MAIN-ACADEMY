using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAiroportASP_NET.Models
{
    [Table("AirflightPassenger")]
    public class AirflightPassenger
    {
        [Key]
        public int PassengerID { get; set; }
        public int AirFlightID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Nationality { get; set; }
        public string PassportNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Sex { get; set; }
        public int FlightClass { get; set; }

        public AirflightPassenger() { }
    }
}