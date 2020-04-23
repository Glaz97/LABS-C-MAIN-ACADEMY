using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Linq;
using System.Collections;
using System.Web;
using System.ServiceModel.Activation;


namespace WcfSimpleService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FlightsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FlightsService.svc or FlightsService.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class FlightsService : IFlightsService
    {
        private readonly string PictDir;
        private XDocument doc = new XDocument();
        private readonly string _path;
        public FlightsService()
        {
             PictDir = HttpContext.Current.Server.MapPath(".");
             _path = PictDir + @"\Flights.xml";
             doc = XDocument.Load(_path);
        }
        public string GetFlightTotal(string FlightID)
        {
            string _flightTotal = string.Empty;

            try
            {

                _flightTotal =
                    (from result in doc.Descendants("DocumentElement")
                    .Descendants("Flight")
                     where result.Element("FlightID").Value == FlightID.ToString()
                     select result.Element("FlightTotal").Value)
                    .FirstOrDefault<string>();

            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                     (ex.Message);
            }
            return _flightTotal;
        }

        public Flight GetFlightDetails(string FlightID)
        {
            Flight _flight = new Flight();

            try
            {

                IEnumerable<XElement> _flights =
                         (from result in doc.Descendants("DocumentElement")
                             .Descendants("Flight")
                          where result.Element("FlightID").Value == FlightID.ToString()
                          select result);

                _flight.FlightID = _flights.ElementAt(0).Element("FlightID").Value;
                _flight.FlightDate = _flights.ElementAt(0).Element("FlightDate").Value;
                _flight.DeliveryDate = _flights.ElementAt(0).Element("DeliveryDate").Value;
                _flight.ShipCountry = _flights.ElementAt(0).Element("ShipCountry").Value;
                _flight.FlightTotal = _flights.ElementAt(0).Element("FlightTotal").Value;
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                     (ex.Message);
            }
            return _flight;
        }

        public bool PlaceFlight(Flight _flight)
        {
            try
            {

                doc.Element("DocumentElement").Add(
                        new XElement("Flight",
                        new XElement("FlightID", _flight.FlightID),
                        new XElement("FlightDate", _flight.FlightDate),
                        new XElement("ShippedDate", _flight.DeliveryDate),
                        new XElement("ShipCountry", _flight.ShipCountry),
                        new XElement("FlightTotal", _flight.FlightTotal)));

                doc.Save(_path);
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                     (ex.Message);
            }
            return true;
        }
    }
}
