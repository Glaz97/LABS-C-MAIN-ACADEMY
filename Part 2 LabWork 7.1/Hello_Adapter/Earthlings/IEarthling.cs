using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Adapter.Earthlings
{
    public interface IEarthling
    {
        string Name { get; set; }

        string Joyous_laughter();
        string Surprise();
    }
}
