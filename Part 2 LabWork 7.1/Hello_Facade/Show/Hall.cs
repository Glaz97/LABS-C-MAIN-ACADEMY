using System;

namespace Hello_Facade.Show
{
    class Hall
    {
        public DateTime GetScene()
        {
            return DateTime.Now;
        }

        public void Applauds(int seconds, int volume)
        {
            Console.WriteLine("Hall applauds {0} seconds with volume {1} db", seconds, volume);
        }
        public void ShowBegin()
        {
            Console.WriteLine("Show begin");
        }
        public void DateUp(int diff)
        {
            DateTime today = DateTime.Now;
            DateTime answer = today.AddDays(diff);
            Console.WriteLine("Show date set for {0} ", answer);
        }
    }
}
