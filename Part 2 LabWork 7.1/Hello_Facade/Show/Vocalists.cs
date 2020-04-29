using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hello_Facade.Show
{
    class Vocalists
    {
        public void meetTogether(int choir)
        {
            Console.WriteLine("Meet together: {0} vocalists", choir);
        }

        public void sing(int choir)
        {
            Console.WriteLine("Choir sings: {0} vocalists", choir);
        }
        public void keepSilent()
        {
            Console.WriteLine("Vocalists keep silent");
        }
    }
}
