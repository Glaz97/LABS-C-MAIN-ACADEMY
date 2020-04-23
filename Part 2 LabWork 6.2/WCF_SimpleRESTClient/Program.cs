using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_SimpleRESTClient
{
    class Program
    {
        static void Main(string[] args)
        {
            WcfSimpleServiceReference.EchoClient proxy = new WcfSimpleServiceReference.EchoClient();
            var r = proxy.GetData("Hello SOAP!");
            Console.WriteLine(r.ToString());
            Console.ReadLine();
        }
    }
}
