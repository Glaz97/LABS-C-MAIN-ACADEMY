using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labwork_2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool StayInProgram = true;

            while (StayInProgram)
            {
                int option = 0;

                Console.WriteLine("1 - Paint a cube with a message:");
                Console.WriteLine("2 - Calculate a recursive factorial:");
                Console.WriteLine("3 - Exit the programm:" + "\n");

                Console.WriteLine("Select the number of algorithm:");

                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Eror in input string. Exiting the programm.");
                    Console.ReadKey();
                    StayInProgram = false;
                }
                if (option >= 1 & option <= 2)
                {
                    SelectTheFunction(option);
                }
                else
                {
                    Console.WriteLine("Eror in input string. Exiting the programm.");
                    Console.ReadKey();
                    StayInProgram = false;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        static void SelectTheFunction(int option)
        {
            if (option == 1)
            {
                DrawCubeWithMessage();
            }
            else if (option == 2)
            {
                Console.WriteLine("Введите ваше число для вычисления факториала");
                int number = Convert.ToInt32(CheckForEnterMistake(0));

                Console.WriteLine("Факториал числа " + number.ToString() + " равен - " + CalculateRecursiveFactorial(number));
            }
        }

        private static void DrawCubeWithMessage()
        {
            Console.WriteLine("Enter coordinate of left position: (integer number)");
            int Left = Convert.ToInt32(CheckForEnterMistake(0));
            Console.WriteLine("Enter coordinate of top position: (integer number)");
            int Top = Convert.ToInt32(CheckForEnterMistake(0));

            Console.WriteLine("Enter width of cube: (integer number)");
            int Width = Convert.ToInt32(CheckForEnterMistake(0));
            Console.WriteLine("Enter height of cube: (integer number)");
            int Height = Convert.ToInt32(CheckForEnterMistake(0));

            Console.WriteLine("Enter 1 symbol for the border of the cube");
            char Edge = Convert.ToChar(CheckForEnterMistake(1));

            Console.WriteLine("Enter message to write in cube");
            string Message = Console.ReadLine();

            DrawABox(Left, Top, Width, Height, Edge, Message);
        }

        static long CalculateRecursiveFactorial(int n)
        {
            if (n == 0 || n == 1)
            return 1;
            else return n * CalculateRecursiveFactorial(n - 1);
        }

        static string CheckForEnterMistake(int option)
        {
            string ReturnResult = "-1";

            if (option == 0)
            {
                int result = Convert.ToInt32(ReturnResult);

                while (result < 0)
                {
                    try
                    {
                        result = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Enter the integer number!");
                    }
                }
                return Convert.ToString(result);
            }
            else
            {
                string result = "";

                while (result.Length > 1 || result.Length == 0)
                {
                    result = Console.ReadLine();
                }
                return result;
            }
        }

        private static void DrawABox(int Left, int Top, int Width, int Height, char Edge, string Message)
        {
            int LastLeft = Left + 1;
            int LastTop = Top + 1;
            var Temp = Message.ToArray();
            int OutSymbols = 0;
            int PrintedSymbols = 0;
            var Maxlenght = Message.Length;

            Console.SetCursorPosition(Left, Top);

            for (int h_i = 0; h_i <= Height; h_i++)
            {
                if (LastTop < Height + Top)
                {
                    OutSymbols = 0;

                    Console.SetCursorPosition(LastLeft, LastTop);
                    var OutString = "";

                    var index = 0;

                    foreach (var s in Temp)
                    {
                        if (OutSymbols >= Width - 1)
                        {
                            continue;
                        }
                        else if (OutString.Length <= Width - 1 & index > PrintedSymbols) {
                            OutString += s;
                            OutSymbols += 1;
                            PrintedSymbols +=1;
                        }
                        index += 1;
                    }
                    Console.Write(OutString);
                    LastTop += 1;
                }
                for (int w_i = 0; w_i <= Width; w_i++)
                {
                    if (h_i % Height == 0 || w_i % Width == 0)
                    {
                        Console.SetCursorPosition(Left + w_i, Top + h_i);
                        Console.Write(Edge);
                    }
                }
            }
        }
    }
}
