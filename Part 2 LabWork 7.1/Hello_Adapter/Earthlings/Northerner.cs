using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Adapter.Earthlings
{
    public class Northerner:IEarthling
    {
        public string Name { get; set; }
        public string Joyous_laughter()
        {
            return "Hi-hi"; 
        }
        public string Surprise()
        {
            return "JI_JU_JA";  
        }
    }
}
