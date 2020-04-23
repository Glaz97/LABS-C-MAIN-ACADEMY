using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.ServiceModel;
using System.Xml.Linq;
using System.Configuration;

using System.IO;
using System.Runtime.Serialization.Json;

using WSF_SimpleRESTClient_1.FlightsReference;

namespace WSF_SimpleRESTClient_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string restResponse = UseRest();
            Console.WriteLine("REST: {0}", restResponse);
            GetFlightDetails("21248");
            GetFlightTotal("21248");
            PlaceFlight();
            Console.ReadKey(true);
        }

        private static string UseRest()
        {
            string url = ConfigurationManager.AppSettings["rest"];
            var client = new WebClient { BaseAddress = GetAddress(url) };
            string responseString = client.DownloadString("?msg=REST");
            XElement responseXml = XElement.Parse(responseString);
            return responseXml.Value;
        }

        private static string GetAddress(string address)
        {
            bool useFiddler;
            if (bool.TryParse(ConfigurationManager.AppSettings["useFiddler"], out useFiddler)
                && useFiddler)
            {
                return address.Replace("localhost", "localhost.");
            }
            return address;
        }
        // FlightsService
        private static void GetFlightDetails(string FlightID)
        {
            WebClient proxy = new WebClient();
            string url = ConfigurationManager.AppSettings["restFlights"];
            string serviceURL = string.Format(url, FlightID);
            byte[] data = proxy.DownloadData(serviceURL);
            Stream stream = new MemoryStream(data);
            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(Flight));
            Flight _flight = obj.ReadObject(stream) as Flight;
            Console.WriteLine("Flight ID : " + _flight.FlightID);
            Console.WriteLine("Flight Date : " + _flight.FlightDate);
            Console.WriteLine("Flight Delivery Date : " + _flight.DeliveryDate);
            Console.WriteLine("Flight Ship Country : " + _flight.ShipCountry);
            Console.WriteLine("Flight Total : " + _flight.FlightTotal);
        }

        private static void GetFlightTotal(string FlightID)
        {
            Console.WriteLine();
            Console.WriteLine("GetFlightTotal output");
            WebClient proxy = new WebClient();
            string url = ConfigurationManager.AppSettings["restFlights_2"];
            string serviceURL = string.Format(url, FlightID);
            byte[] data = proxy.DownloadData(serviceURL);
            Stream stream = new MemoryStream(data);
            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(string));
            string Flight = Convert.ToString(obj.ReadObject(stream));
            Console.WriteLine(Flight);
        }

        private static void PlaceFlight()
        {
            Flight Flight = new Flight
            {
                FlightID = "21550",
                FlightDate = DateTime.Now.ToString(),
                DeliveryDate = DateTime.Now.AddDays(10).ToString(),
                ShipCountry = "Germany",
                FlightTotal = "562"
            };

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Flight));
            MemoryStream mem = new MemoryStream();
            ser.WriteObject(mem, Flight);
            string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
            WebClient webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            string url = ConfigurationManager.AppSettings["restFlights_1"];
            webClient.UploadString(url, "POST", data);
            Console.WriteLine("Flight placed successfully...");
        }

    }

}
