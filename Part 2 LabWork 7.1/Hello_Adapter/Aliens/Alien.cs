using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Adapter.Aliens
{
   public class Alien:IAlien
    {
       public string Identifier { get { return "001"; } }
        public string Positive_emotion()
        {
            return "HOY";
        }
        public string Undefined_emotion()
        {
            return "HIY";
        }
    }
}
