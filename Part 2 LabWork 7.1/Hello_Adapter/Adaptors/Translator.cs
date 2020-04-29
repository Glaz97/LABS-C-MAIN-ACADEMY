using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hello_Adapter.Earthlings;
using Hello_Adapter.Aliens;

namespace Hello_Adapter.Adaptors
{
    class Translator:IEarthling
    {
        private IAlien _id;

        public Translator(IAlien id)
        {
            _id = id;
        }

        public string Name
        {
            get { return _id.Identifier; } 
            set { }
        }

        public string Joyous_laughter()
        {
           return _id.Positive_emotion();
        }

        public string Surprise()
        {
            return _id.Undefined_emotion();
        }

    }
}
