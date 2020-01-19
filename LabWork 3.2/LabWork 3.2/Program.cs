using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork_3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Bird PtichkaPetuh = new Bird();

            Console.WriteLine("1 - Array overflow exception");
            Console.WriteLine("2 - System exception");
            Console.WriteLine("3 - Incrementing exception");
            Console.WriteLine("4 - FlyAway function");

            var option = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (option == 1)
                {
                    var array = new int?[2];
                    array[3] = PtichkaPetuh.Age;
                }
                else if (option == 2)
                {
                    var test = PtichkaPetuh.Age / 0;
                }
                else if (option == 3)
                {
                    for (int i = 0; i < int.MaxValue; i++)
                    {
                        PtichkaPetuh.SpeedOfBird += PtichkaPetuh.SpeedOfBird;
                        if (PtichkaPetuh.SpeedOfBird < 0 )
                        {
                            throw new NotImplementedException();
                        }
                    }
                    Console.WriteLine(PtichkaPetuh.Age);
                }
                else if (option == 4)
                {
                    PtichkaPetuh.FlyAway(0);
                }
            }
            catch
            {
                if (option == 1)
                {
                    Console.WriteLine("Array overflow exception");
                }
                else if (option == 2)
                {
                    Console.WriteLine("System exception");
                }
                else if (option == 3)
                {
                    Console.WriteLine("Incrementing exception");
                }
                else if (option == 4)
                {
                    Console.WriteLine("FlyAway function");
                }
            }
            Console.ReadKey();
        }
    }

    public class Bird
    {
        public string Type;
        public int? Age;
        public int SpeedOfBird;

        public Bird()
        {
            Type = "Piven'";
            Age = 228;
            SpeedOfBird = 1488;
        }

        public void FlyAway (int incrmnt)
        {
            try
            {
                Age = Age / incrmnt;
            }
            catch
            {
                BirdFlewAwayException ptichka = new BirdFlewAwayException();
            }
        }
    }

    public class BirdFlewAwayException
    {
        public BirdFlewAwayException()
        {
            throw new NotImplementedException();
        }
    }
}
