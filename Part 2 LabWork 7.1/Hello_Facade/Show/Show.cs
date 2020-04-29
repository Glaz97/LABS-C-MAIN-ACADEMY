using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hello_Facade.Show
{
    class Show
    {
        private Prima _prima;
        private Orchestra _orchestra;
        private Hall _hall;
        private Vocalists _vocalists;

        public Show(Prima prima, Orchestra orchestra, Hall hall, Vocalists vocalists)
        {
            _prima = prima;
            _orchestra = orchestra;
            _hall = hall;
            _vocalists = vocalists;
        }

        public DateTime GetScene()
        {
            return _hall.GetScene();
        }

        public void Musical()
        {
            _vocalists.meetTogether(10);
            _hall.DateUp(30);
            _hall.ShowBegin();
            _orchestra.plays();
            _orchestra.plays();
            _orchestra.plays();
            _vocalists.sing(10);           
            _vocalists.keepSilent();
            _prima.sing(30, 30);
            _vocalists.sing(10); 
            _orchestra.plays();
            _orchestra.plays();
            _orchestra.plays();
            _vocalists.keepSilent();
            _prima.sing(60, 25);
            _orchestra.stop();
            _hall.Applauds(500, 40);
        }

        public void Opera()
        {
            _vocalists.meetTogether(30);
            _hall.DateUp(40);
            _hall.ShowBegin();
            _orchestra.plays();
            _orchestra.plays();
            _vocalists.sing(10);
            _vocalists.sing(30);
            _vocalists.keepSilent();
            _prima.sing(60, 40);
            _vocalists.sing(10);
            _vocalists.sing(30);
            _orchestra.plays();
            _vocalists.sing(30);
            _vocalists.keepSilent();
            _prima.sing(60, 15);
            _vocalists.sing(30);
            _orchestra.stop();
            _hall.Applauds(300, 20);
        }
    }
}
