using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace WcfSimpleService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEcho" in both code and config file together.
    [ServiceContract]
    public interface IEcho
    {

        [OperationContract, WebGet]
        string GetData(string msg);

    }
}
