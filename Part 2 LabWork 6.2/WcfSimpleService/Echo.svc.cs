using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfSimpleService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Echo" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Echo.svc or Echo.svc.cs at the Solution Explorer and start debugging.
    public class Echo : IEcho
    {
        public string GetData(string msg)
        {
            return "Message text: " + msg;
        }
    }
}
