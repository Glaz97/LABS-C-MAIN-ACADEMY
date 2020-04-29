using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Adapter.Aliens
{
    interface IAlien
    {
        string Identifier { get;  }

        string Positive_emotion();
        string Undefined_emotion();
    }
}
