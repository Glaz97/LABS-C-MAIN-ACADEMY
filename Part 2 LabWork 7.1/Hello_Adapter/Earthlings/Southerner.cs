using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Adapter.Earthlings
{
    public class Southerner:IEarthling
    {
        public string Name { get; set; }
        public string Joyous_laughter()
        {
            return "333333";
        }
        public string Surprise()
        {
            return "222222";
        }
    }
}
