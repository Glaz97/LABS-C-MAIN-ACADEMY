using ProjectAiroportASP_NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectAiroportASP_NET.Repository
{
    public class BaseRepository
    {
        public static DBContext db = new DBContext();

        #region AddDBElement
        public static bool CanAddAirflight(Airflights Element)
        {
            if (Element.AiroportArrival != "" && Element.AiroportDepature != "" && Element.CityArrival != ""
                && Element.CityDepature != "" && Element.DateAndTimeArival != DateTime.MinValue
                && Element.DateAndTimeDepature != DateTime.MinValue && Element.FlightNumber != ""
                && Element.Gate != "" && Element.PriceListID != 0 && Element.Status != 0
                && Element.Terminal != "" && Element.TimeExpected != DateTime.MinValue)
            {
                return true;
            }
            return false;
        }

        public static bool CanAddPassengers(AirflightPassenger Element)
        {
            if (Element.AirFlightID != 0 && Element.DateOfBirth != DateTime.MinValue &&
                Element.FirstName != "" && Element.FlightClass != 0 && Element.Nationality != ""
                && Element.PassportNumber != "" && Element.SecondName != "" && Element.Sex != 0)
            {
                return true;
            }
            return false;
        }

        public static bool CanAddPriceList(AirflightPriceList Element)
        {
            if (Element.AirFlightID != 0 && Element.Business != 0 && Element.BusinessPlus != 0 && Element.Econom != 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region SeacrhDBElement
        public static IEnumerable<Airflights> FindAiroportInfoElements(string askString)
        {
            return db.Airflights.Where(x => x.FlightNumber == askString
            || x.AiroportArrival == askString || x.AiroportDepature == askString).ToList();
        }

        public static IEnumerable<AirflightPassenger> FindPassengersInfoElements(string askString)
        {
            return db.Passengers.Where(x => x.FirstName == askString ||
            x.Nationality == askString || x.SecondName == askString || x.PassportNumber == askString).ToList();
        }

        public static IEnumerable<Airflights> FindPriceListInfoElements(string askString)
        {
            int.TryParse(askString, out int price);

            var priceLists = db.PriceList.Where(x => x.Business == price || x.BusinessPlus == price || x.Econom == price).ToList();

            List<Airflights> listOfAirflights = new List<Airflights>();

            foreach (var element in priceLists)
            {
                foreach (var airflight in db.Airflights.Where(z => z.AirFlightID == element.AirFlightID))
                {
                    listOfAirflights.Add(airflight);
                }
            }

            return listOfAirflights;
        }
        #endregion
    }
}