using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;


namespace WcfSimpleService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFlightsService" in both code and config file together.
    [ServiceContract]

    public interface IFlightsService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/GetFlightTotal/{FlightID}",
            ResponseFormat = WebMessageFormat.Json)]

        string GetFlightTotal(string FlightID);

        [OperationContract]
        [WebGet(UriTemplate = "/GetFlightDetails/{FlightID}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        Flight GetFlightDetails(string FlightID);

        [OperationContract]
        [WebInvoke(UriTemplate = "/PlaceFlight",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        bool PlaceFlight(Flight _flight);
    }
}
