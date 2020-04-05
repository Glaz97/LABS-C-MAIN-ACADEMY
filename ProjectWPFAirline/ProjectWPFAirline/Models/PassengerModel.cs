using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectWPFAirline.ViewModels;

namespace ProjectWPFAirline
{
    [Table("AirflightPassenger")]
    public class PassengerModel
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

        public PassengerModel() { }

        public PassengerModel(string firstName, string secondName, string nationality, string passportNumber, DateTime dateOfBirth, int sex, int flightClass)
        {
            FirstName = firstName;
            SecondName = secondName;
            Nationality = nationality;
            PassportNumber = passportNumber;
            Sex = sex;
            DateOfBirth = dateOfBirth;
            FlightClass = flightClass;
        }

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

        public static explicit operator PassengerModel(DataGridPassengersViewModel viewModel)
        {
            PassengerModel passengerModel = new PassengerModel
            {
                PassengerID = viewModel.PassengerID, 
                AirFlightID = viewModel.AirFlightID,
                FirstName = viewModel.FirstName,
                SecondName = viewModel.SecondName,
                Nationality = viewModel.Nationality,
                PassportNumber = viewModel.PassportNumber,
                Sex = viewModel.Sex,
                DateOfBirth = viewModel.DateOfBirth,
                FlightClass = viewModel.FlightClass
            };

            return passengerModel;
        }
    }
}
