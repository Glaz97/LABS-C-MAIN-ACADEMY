using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hello_Adapter.Earthlings;
using Hello_Adapter.Aliens;

namespace Hello_Adapter
{
    public class EmoInfo
    {
        public EmoInfo(IEarthling human)
        {
            Console.WriteLine("Emotions");
            Console.WriteLine(string.Format("Name: {0}", human.Name));
            Console.WriteLine("Joyous laughter: " + human.Joyous_laughter());
            Console.WriteLine("Surprise: " + human.Surprise());
            Console.WriteLine();
        }
    }
}
