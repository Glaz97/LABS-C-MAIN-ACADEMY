using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hello_Facade.Show;

namespace Hello_Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            var choir = new Vocalists();
            var scene = new Hall();
            var orchestra = new Orchestra();
            var prima = new Prima();

            var performance = new Show.Show(prima, orchestra, scene, choir);

            // Musical
            Console.WriteLine("Musical");
            performance.Musical();
            Console.WriteLine();
            
            // Opera
            Console.WriteLine("Opera");
            performance.Opera();

            Console.ReadLine();
        }
    }
}
