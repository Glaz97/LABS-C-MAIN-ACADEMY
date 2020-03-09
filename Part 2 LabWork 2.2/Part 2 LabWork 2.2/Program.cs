using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Part_2_LabWork_2._2
{
    class Program
    {
        static void FactThreadStart(int number)
        {
            CancellationTokenSource CancelTokenSource = new CancellationTokenSource();
            CancellationToken Token = CancelTokenSource.Token;

            Task Task = new Task(() => FactorialCancellationToken(number, Token));

            Task Task2 = Task.ContinueWith(Display);

            Task.Start();

            Console.WriteLine("Нажмитe кнопку ESC для остановки цикла:");

            if (ConsoleKey.Escape == Console.ReadKey().Key)
            {
                Console.WriteLine("\n" + "Цикл обработки остановлен");
                CancelTokenSource.Cancel();
            }

            Console.ReadLine();
        }

        static async void FactAsyncAwait(int number)
        {
            await Task.Run(() => Factorial(number));
        }

        static void FactorialCancellationToken(int number, CancellationToken Token)
        {
            int result = 1;
            for (int i = 1; i <= number; i++)
            {
                if (Token.IsCancellationRequested)
                {
                    Console.WriteLine("Операция прервана токеном");
                    return;
                }

                result *= i;
                Console.WriteLine($"Факториал числа {number} равен {result}");
                Thread.Sleep(500);
            }
        }

        static void Factorial(int number)
        {
            int result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
                Console.WriteLine($"Факториал равен {result}");
            }
            Thread.Sleep(8000);
            Console.WriteLine($"Факториал равен {result}");
        }

        static void Display(Task t)
        {
            Console.WriteLine($"Id задачи: {Task.CurrentId}");
            Console.WriteLine($"Id предыдущей задачи: {t.Id}");
            Thread.Sleep(500);
        }

        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    //Using async await
                    FactAsyncAwait(int.Parse(Console.ReadLine()));

                    //CancellationToken + TaskContinue
                    FactThreadStart(int.Parse(Console.ReadLine()));

                    return;
                }
                catch
                {
                    Console.WriteLine("Ошибка при вводе, повторите ввод");
                }
            }
        }
    }
}
