using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyWCFsolution
{
    // NOTE: If you change the class name "Service1" here, you must also update the reference to "Service1" in App.config.
    public class Service1 : IService1
    {

        #region IService1 Members

        int IService1.Add(int a, int b)
        {
            return a + b;
        }

        int IService1.Sub(int a, int b)
        {
            return a - b;
        }

        public int Mul(int a, int b)
        {
            return a * b;
        }

        public int Div(int a, int b)
        {
            try
            {
                return a / b;
            }
            catch
            {
                return 0;
            }
        }

        #endregion
    }
}
