using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SystemConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int exit = 0;
            while (exit == 0)
            {
                int Variant = 0;

                while (Variant < 1 || Variant > 3)
                {
                    Console.WriteLine("Укажите номер алгоритма для запуска:" + '\n');
                    Console.WriteLine("1 - Я хз как это сделать,даже в инете инфы 0" + '\n' + "2 - Номер как бинарная строка" + '\n' + "3 - Код Морзе" + '\n');
                    try
                    {
                        Variant = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка! Введите целое число от 1 до 5 и попробуйте снова!");
                    }
                }

                if (Variant == 1)
                {
                    DiferenceBetweenTwoNumbers();
                }
                else if (Variant == 2)
                {
                    RecordNumberAsABinnaryString();
                }
                else if (Variant == 3)
                {
                    RunMorseCodeAsASound();
                }

                Console.WriteLine("Выйти из программы?: 1 - да, 0 - нет" + '\n');

                try
                {
                    exit = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Вы ввели что-то не то, программа не понимать и выключатся! В следующий раз введите 0 - НЕТ, 1 - КОНЕЧНО!");
                    return;
                }
            }
        }

        static void RunMorseCodeAsASound()
        {
            var sequence = Enumerable.Range(0, 3).ToList();
            int exit = 0;
            while (exit == 0)
            {
                sequence.ForEach(e => Console.Beep(650, 100));
                Thread.Sleep(200);
                sequence.ForEach(e => Console.Beep(650, 400));
                Thread.Sleep(200);
                sequence.ForEach(e => Console.Beep(650, 100));
                Thread.Sleep(500);
                Console.WriteLine("Закончить проигрывание? 1- да, 0 - нет");
                exit = Convert.ToInt32(Console.ReadLine());
            }
        }

        static void RecordNumberAsABinnaryString()
        {
            Console.WriteLine("Введите любое целое число:" + '\n');

            var numberForCalculate = ToBinary(Convert.ToInt32(Console.ReadLine()));
            Console.Write("Результат бинарный формат = " + numberForCalculate + "\n");
            Console.Write("Результат decimal формат = " + Convert.ToInt32(numberForCalculate, 2).ToString() + "\n");
        }

        public static string ToBinary(int n)
        {
            if (n < 2) return n.ToString();

            var divisor = n / 2;
            var remainder = n % 2;

            return ToBinary(divisor) + remainder;
        }

        static void DiferenceBetweenTwoNumbers ()
        {
            Console.WriteLine("Введите любое целое положительное число №1:" );
            int number1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ваше число №1 = " + number1 + '\n');
            Console.WriteLine("Введите любое целое положительное число №2:");
            int number2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ваше число №2 = " + number2 + '\n');

            string binary1, binary2;

            binary1 = ToBinary(number1);
            binary2 = ToBinary(number2);

            Console.Write("Бинарная форма числа №1 = " + binary1 + '\n');
            Console.Write("Бинарная форма числа №2 = " + binary2 + '\n');
        }
    }
}
