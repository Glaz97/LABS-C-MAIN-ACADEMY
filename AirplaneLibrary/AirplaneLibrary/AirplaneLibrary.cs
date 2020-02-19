using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneLibrary
{
    public enum AirplaneTypes
    {
        SportPlane,
        CargoPlane,
        TurboProp,
        Jet
    }

    public class AirplaneTypeAttribute
    {
        public AirplaneTypes Type;

        public AirplaneTypeAttribute()
        {
            Type = AirplaneTypes.TurboProp;
        }

        public AirplaneTypeAttribute(AirplaneTypes Type)
        {
            this.Type = Type;
        }
    }

    public class AirplaneLibrary
    {

    }
}
