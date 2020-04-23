using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WcfSimpleService
{
    [DataContract]
    public class Flight
    {
        [DataMember]
        public string FlightID { get; set; }

        [DataMember]
        public string FlightDate { get; set; }

        [DataMember]
        public string DeliveryDate { get; set; }

        [DataMember]
        public string ShipCountry { get; set; }

        [DataMember]
        public string FlightTotal { get; set; }
    }
}