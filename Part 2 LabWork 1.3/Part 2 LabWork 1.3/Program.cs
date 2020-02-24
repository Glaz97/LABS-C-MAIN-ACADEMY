using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_2_LabWork_1._3
{

    public static class StringExtensios
    {
        public static bool IsBaseColor(this string ClsStr)
        {
            bool answer = false;

            Console.Beep(300,10000);

            string[] BaseColor = { "black", "white" };
            foreach (var element in BaseColor)
            {
                if (ClsStr.Equals(element, StringComparison.CurrentCultureIgnoreCase))
                {
                    answer = true;
                }
            }

            return answer;
        }
    }

    public class MorseSymbols
    {
        public char[] characters = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З', 'И',
                                                        'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                                        'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ы', 'Ь',
                                                        'Э', 'Ю', 'Я', '1', '2', '3', '4', '5', '6', '7',
                                                        '8', '9', '0' };

        public string[] codeMorse = new string[] { "*-", "-***", "*--", "--*",
                                                        "-**", "*", "***-", "--**",
                                                        "**", "*---", "-*-", "*-**",
                                                        "--", "-*", "---", "*--*",
                                                        "*-*", "***", "-", "**-",
                                                        "**-*", "****", "-*-*",
                                                        "---*", "----", "--*-",
                                                        "-*--", "-**-", "**-**",
                                                        "**--", "*-*-", "*----",
                                                        "**---", "***--", "****-",
                                                        "*****", "-****", "--***",
                                                        "---**", "----*", "-----" };
    }

    public class CryptedString
    {
        public static void EncryptString(object EnteredString)
        {
            var MorseClass = new MorseSymbols();
            string input;

            if (EnteredString == null)
            {
                Console.WriteLine("Введите ваш текст для шифровки");
                input = Console.ReadLine();
            }
            else
            {
                input = EnteredString.ToString();
            }

            input = input.ToUpper();
            string output = "";
            int index;
            foreach (char c in input)
            {
                if (c != ' ')
                {
                    index = Array.IndexOf(MorseClass.characters, c);
                    output += MorseClass.codeMorse[index] + " ";
                }
            }
            Console.WriteLine(output.Remove(output.Length - 1));
        }

        public static void DecryptString(object EnteredString)
        {
            var MorseClass = new MorseSymbols();

            string input;

            if (EnteredString == null)
            {
                Console.WriteLine("Введите ваш текст для расшифровки");
                input = Console.ReadLine();
            }
            else
            {
                input = EnteredString.ToString();
            }

            string[] split = input.Split(' ');
            string output = "";
            int index;
            foreach (string s in split)
            {
                index = Array.IndexOf(MorseClass.codeMorse, s);
                output += MorseClass.characters[index] + " ";
            }
            Console.WriteLine(output.Remove(output.Length - 1));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер действия: 0 - зашифровать, 1 - расшифровать");

            int option = -1;

            int.TryParse(Console.ReadLine(), out option);

            if (option == 0)
            {
                CryptedString.EncryptString(null);
            }
            else if(option == 1)
            {
                CryptedString.DecryptString(null);
            }

            Console.ReadKey();
        }
    }
}
