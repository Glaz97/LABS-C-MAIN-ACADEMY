using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module3_2_1_lab_Conscl
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Calculator();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        static void Calculator()
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            Console.WriteLine("Console Calculator");
            Console.WriteLine(' ');
            Console.WriteLine(@"Select the arithmetic operation:
                        1. Multiplication 
                        2. Divide 
                        3. Addition 
                        4. Subtraction
                        ");
            string q = Console.ReadLine();
            int a, b;
            Console.WriteLine(' ');
            Console.WriteLine("Type the first value");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Type the second value");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine(' ');
            if (q == "1")
            {
                Console.WriteLine("The result of the multiplication = {0}", proxy.Mul(a, b));
                Console.ReadLine();
            }
            if (q == "2")
            {
                Console.WriteLine("The result of the  division = {0}", proxy.Div(a, b));
                Console.ReadLine();
            }
            if (q == "3")
            {
                Console.WriteLine("The result of the  addition  = {0}", proxy.add(a, b));
                Console.ReadLine();
            }
            if (q == "4")
            {
                Console.WriteLine("The result of the subtraction = {0}", proxy.Sub(a, b));
                Console.ReadLine();
            }

        }
    }
}
