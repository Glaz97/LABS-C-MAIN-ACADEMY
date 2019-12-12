using System;

namespace Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            var exit = 1;
            while (exit == 1)
            {
                int VariantNumber = 0;
                VariantNumber = SelectVariant(VariantNumber);

                //Проверка на неккоректный ввод числа
                if (VariantNumber < 0 || VariantNumber > 4)
                {
                    while (VariantNumber < 0 || VariantNumber > 4)
                    {
                        Console.WriteLine("Введите целое число от 1 до 4" + '\n');
                        VariantNumber = SelectVariant(VariantNumber);
                    }
                }

                //Проверка на выбранные виды алгоритма
                if (VariantNumber == 0)
                {
                    Console.WriteLine("Введите целое число от 1 до 4" + '\n');
                    VariantNumber = SelectVariant(VariantNumber);
                }
                else if (VariantNumber == 1)
                {
                    Wolf_Goat_And_Cabbage();
                }
                else if (VariantNumber == 2)
                {
                    Console.WriteLine("Укажите вид операции:" + '\n');
                    Console.WriteLine("1 - Умножение" + '\n' + "2 - Деление" + '\n' + "3 - Сложение" + '\n' + "4 - Вычитание" + '\n' + "5 - Экспонента" + '\n');
                    try
                    {
                        int VariantCalculateNumber = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ответ: " + Calculator(VariantCalculateNumber));
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка! Введите целое число от 1 до 5 и попробуйте снова!");
                    }
                }
                else if (VariantNumber == 3)
                {
                    Factorial();
                }
                else if (VariantNumber == 4)
                {
                    Console.WriteLine("В этой игре вам нужно угадать рандомное ЦЕЛОЕ число от 0 до 10" + '\n');
                    Console.WriteLine("Введите число от 0 до 10" + '\n');

                    int RandomNumber = Convert.ToInt32(Console.ReadLine());

                    Guess_The_Number(RandomNumber);
                }

                Console.WriteLine("Поздравляем! Хотите попробовать что-то еще? 0 - НЕТ, 1 - КОНЕЧНО!");

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

        public static void Wolf_Goat_And_Cabbage()
        {
            Console.WriteLine("Ваша задача перепавить козу, волка и капусту таким образом, чтобы все оказалось на том берегу в целом виде!" + '\n');
            Console.WriteLine("Введите по очереди номера переправ (7 шагов):" + '\n');
            Console.WriteLine("Возможные варианты переправ:" + '\n');

            Console.WriteLine("|Туда| Фермер и волк - 1:" + '\n');
            Console.WriteLine("|Туда| Фермер и капуста - 2:" + '\n');
            Console.WriteLine("|Туда| Фермер и коза - 3:" + '\n');
            Console.WriteLine("|Туда| Фермер - 4:" + '\n');
            Console.WriteLine("|Обратно| Фермер и волк - 5:" + '\n');
            Console.WriteLine("|Обратно| Фермер и капуста - 6:" + '\n');
            Console.WriteLine("|Обратно| Фермер и коза - 7:" + '\n');
            Console.WriteLine("|Обратно| Фермер - 8:" + '\n');

            int[] MassiveOfOptionsVar1 = new int[7] { 3, 8, 1, 7, 2, 8, 3 };
            int[] MassiveOfOptionsVar2 = new int[7] { 3, 8, 2, 7, 1, 8, 3 };

            bool check1;
            bool check2;
            int option = 1;

            for (int i = 0; i < MassiveOfOptionsVar1.Length; i++)
            {
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ошибка! Для ввода допустимы только целые числа от 1 до 8!");
                    return;
                }

                while (option < 1 || option > 8)
                {
                    Console.WriteLine("Ошибка! Для ввода допустимы только целые числа от 1 до 8! Повторите ввод!");
                    option = Convert.ToInt32(Console.ReadLine());
                }

                check1 = option != MassiveOfOptionsVar1[i];
                check2 = option != MassiveOfOptionsVar2[i];

                if (check1 && check2)
                {
                    Console.WriteLine("Ошибка! Ваши действия привели к трагическим последствиям для козы или капусты!!!!!" + '\n');
                    Console.WriteLine("Испытайте удачу в следуйщий раз!" + '\n');
                    return;
                }
            }

            Console.WriteLine("Ура! Коза и капуста целы! Вам удалось!" + '\n');
        }

        public static double Calculator(int VariantCalculateNumber)
        {
            double result = 0, Variable1 = 0, Variable2 = 0;

            Console.WriteLine("Введите два числа" + '\n');
            try
            {
                Console.WriteLine("Введите первое число" + '\n');
                Variable1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите второе число" + '\n');
                Variable2 = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ошибка при вводе одного из аргументов! Необходимо произвести корректный ввод заново!" + '\n');
                return result;
            }

            if (VariantCalculateNumber == 1)
            {
                return result = Variable1 * Variable2;
            }
            else if (VariantCalculateNumber == 2)
            {
                return result = Variable1 / Variable2;
            }
            else if (VariantCalculateNumber == 3)
            {
                return result = Variable1 + Variable2;
            }
            else if (VariantCalculateNumber == 4)
            {
                return result = Variable1 - Variable2;
            }
            else if (VariantCalculateNumber == 5)
            {
                result = Math.Pow(Variable1, Variable2);
                return result;
            }
            else
            {
                Console.WriteLine("Вы ввели невереное число, попробуйте еще раз!" + '\n');
                return result;
            }
        }

        public static void Factorial()
        {
            int Variable1 = 0, Variable2 = 0;
            Console.WriteLine("Введите два числа" + '\n');
            try
            {
                Console.WriteLine("Введите количество циклов в факториале" + '\n');
                Variable1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите значение факториала" + '\n');
                Variable2 = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ошибка при вводе одного из аргументов! Необходимо произвести корректный ввод заново!" + '\n');
                return;
            }

            for (int i = 2; i <= Variable1; i++)
            {
                Variable2 = Variable2 * i;
            }

            Console.WriteLine(Variable2.ToString());
        }

        public static void Guess_The_Number(int Variable)
        {
            Random rand = new Random();
            int number = rand.Next(0, 10);

            if (Variable > number)
            {
                Console.WriteLine("Ваше число больше от случайно сгенерированного!");
            }
            else if (Variable < number)
            {
                Console.WriteLine("Ваше число меньше от случайно сгенерированного!");
            }
            else if (Variable == number)
            {
                Console.WriteLine("ВЫ УГАДАЛИ! ПЕРЕМОГА!");
            }
        }

        public static int SelectVariant(int VariantNumber)
        {
            Console.WriteLine("Укажите номер алгоритма для запуска" + '\n');
            Console.WriteLine("1 - Загадка фермера" + '\n' + "2 - Простой калькулятор" + '\n' + "3 - Расчет факториала" + '\n' + "4 - Игра, угадай номер" + '\n');

            try
            {
                VariantNumber = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ошибка! Необходимо ввести целое число от 1 до 4!" + '\n');
            }
            return VariantNumber;
        }
    }
}
