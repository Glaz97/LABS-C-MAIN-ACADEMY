using System;

namespace Hello_Facade.Show
{
    class Prima
    {
        public void sing(int seconds, int volume)
        {
            Console.WriteLine("Aria {0} seconds with volume {1} db", seconds, volume);
        }
    }
}
