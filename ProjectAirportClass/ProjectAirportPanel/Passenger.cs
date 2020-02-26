using System;

namespace ProjectAirportPanel
{
    public class Passenger
    {
        public string FirstName;
        public string SecondName;
        public string Nationality;
        public string PassportNumber;
        public DateTime DateOfBirth;
        public SexValue Sex;
        public ClassOfFlight FlightClass;

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

        public Passenger(string firstName, string secondName, string nationality, string passportNumber, DateTime dateOfBirth, SexValue sex, ClassOfFlight flightClass)
        {
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
