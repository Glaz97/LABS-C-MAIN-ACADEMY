using System;

namespace ProjectWPFAirline.ViewModels
{
    public class DataGridPassengersViewModel
    {
        public int PassengerID { get; set; }
        public int AirFlightID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Nationality { get; set; }
        public string PassportNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Sex { get; set; }
        public int FlightClass { get; set; }
        public bool IsModified { get; set; }

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

        public DataGridPassengersViewModel(int passengerID, int airFlightID, string firstName, string secondName, string nationality, string passportNumber, DateTime dateOfBirth, int sex, int flightClass)
        {
            PassengerID = passengerID;
            AirFlightID = airFlightID;
            FirstName = firstName;
            SecondName = secondName;
            Nationality = nationality;
            PassportNumber = passportNumber;
            Sex = sex;
            DateOfBirth = dateOfBirth;
            FlightClass = flightClass;
        }
    }
}
