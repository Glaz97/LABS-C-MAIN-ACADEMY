using System;
using System.Threading;

namespace Part_2_LabWork_2._1
{
    public class ThreadManipulator
    {
        private static readonly ConsoleKey Key;
        private static readonly object block = new object();

        public static void AddingOne(object EnteredNumber)
        {
            lock (block)
            {
                for (int i = 1; i <= 100; i++)
                {
                    if (EnteredNumber.ToString() == "q")
                        break;

                    try
                    {
                        Console.WriteLine(new Random().Next(1000) / Convert.ToInt32(EnteredNumber));
                    }
                    catch
                    {
                        Console.WriteLine("Необходимо вести цифру или ввести Q для выхода!");
                    }
                    Thread.Sleep(1000);
                }
            }
        }

        public static void AddingCustomValue(object EnteredClass)
        {
            Counter c = (Counter)EnteredClass;

            lock (block)
            {
                try
                {
                    for (int i = 1; i <= Convert.ToInt32(c.CountOfLoops); i++)
                    {
                        if (c.EnterNumber.ToString() == "w")
                            break;

                        try
                        {
                            Console.WriteLine(new Random().Next(1000) / Convert.ToInt32(c.EnterNumber));
                        }
                        catch
                        {
                            Console.WriteLine("Необходимо вести цифру или ввести w для выхода!");
                        }
                        Thread.Sleep(1000);
                    }
                }
                catch
                {
                    Console.WriteLine("Ошибка ввода!");
                }
            }
        }

        public static void Stop()
        {
            while (true)
            {
                ConsoleKeyInfo pressed;
                pressed = Console.ReadKey();
                Console.WriteLine("\n" + "Нажата клавиша: " + pressed.KeyChar);
            }
        }
    }

    public class Counter
    {
        public object EnterNumber;
        public object CountOfLoops;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Thread myThread3 = new Thread(new ThreadStart(ThreadManipulator.Stop));
            myThread3.IsBackground = true;
            myThread3.Start();

            //Thread myThread = new Thread(new ParameterizedThreadStart(ThreadManipulator.AddingOne));
            //myThread.Start(Console.ReadLine());
            //Thread myThread1 = new Thread(new ParameterizedThreadStart(ThreadManipulator.AddingOne));
            //myThread1.Start(Console.ReadLine());

            Counter counter = new Counter
            {
                EnterNumber = Console.ReadLine(),
                CountOfLoops = Console.ReadLine()
            };

            Thread myThread2 = new Thread(new ParameterizedThreadStart(ThreadManipulator.AddingCustomValue));
            myThread2.Start(counter);

            Console.ReadKey();
        }
    }
}
