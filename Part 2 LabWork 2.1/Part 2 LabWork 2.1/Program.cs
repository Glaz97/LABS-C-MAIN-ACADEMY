using System;
using System.Threading;

namespace Part_2_LabWork_2._1
{
    public class ThreadManipulator
    {
        #region ОкоянныйКод
        const System.Runtime.InteropServices.CharSet charSet = System.Runtime.InteropServices.CharSet.Unicode;

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = charSet)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = charSet)]
        static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);
        #endregion ОкоянныйКод

        private static readonly ConsoleKey Key;
        private static readonly object block = new object();
        public static int EnteredNumber;

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
                        break;
                    }
                    Thread.Sleep(500);
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
                            break;
                        }
                        Thread.Sleep(500);
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
                ConsoleKeyInfo EnteredNumber = Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Нажата клавиша: " + EnteredNumber.KeyChar);
                foreach (char sym in EnteredNumber.KeyChar.ToString())
                    SendMessage(FindWindow("ConsoleWindowClass", Console.Title), 0x0102, sym, null);
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
            //Данный поток мониторит ввод символов в консоль на протяжении выполнения главного потока
            Thread myThread3 = new Thread(new ThreadStart(ThreadManipulator.Stop));
            myThread3.IsBackground = true;
            myThread3.Start();

            //Два потока, в которых выполняется деление рандомного числа на введенное число по циклу
            Thread myThread = new Thread(new ParameterizedThreadStart(ThreadManipulator.AddingOne));
            myThread.Start(Console.ReadLine());

            Thread myThread1 = new Thread(new ParameterizedThreadStart(ThreadManipulator.AddingOne));
            myThread1.Start(Console.ReadLine());

            Counter counter = new Counter
            {
                EnterNumber = Console.ReadLine(),
                CountOfLoops = Console.ReadLine()
            };

            //Данный поток, в котором выполняется деление рандомного числа на введенное число по циклу
            //значение введенного числа и количества итераций передаеться в объекте класса counter
            Thread myThread2 = new Thread(new ParameterizedThreadStart(ThreadManipulator.AddingCustomValue));
            myThread2.Start(counter);

            Console.ReadKey();
        }
    }
}
