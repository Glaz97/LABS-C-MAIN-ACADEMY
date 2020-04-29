using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hello_Adapter.Earthlings;
using Hello_Adapter.Aliens;
using Hello_Adapter.Adaptors;

namespace Hello_Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            IEarthling human_1 = new Northerner
            {
                Name = "Peter"
            };
            EmoInfo inf_1 = new EmoInfo(human_1);

            IEarthling human_2 = new Southerner
            {
                Name = "Hose"
            };
            EmoInfo inf_2 = new EmoInfo(human_2);

            IAlien extraterrestrial = new Alien();
            Translator adapter = new Translator(extraterrestrial);
            EmoInfo inf_3 = new EmoInfo(adapter);

            Console.ReadKey();
        }
    }
}
