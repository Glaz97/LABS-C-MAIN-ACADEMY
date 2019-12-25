using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace LabWork_2._4
{
    class CaesarCipher
    {
        const string Alfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private string CodeEncode(string text, int k)
        {
            var fullAlfabet = Alfabet + Alfabet.ToLower();
            var letterQty = fullAlfabet.Length;
            var retVal = "";
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                var index = fullAlfabet.IndexOf(c);
                if (index < 0)
                {
                    retVal += c.ToString();
                }
                else
                {
                    var codeIndex = (letterQty + index + k) % letterQty;
                    retVal += fullAlfabet[codeIndex];
                }
            }

            return retVal;
        }

        public string Encrypt(string plainMessage, int key)
            => CodeEncode(plainMessage, key);

        public string Decrypt(string encryptedMessage, int key)
            => CodeEncode(encryptedMessage, -key);
    }

    class Program
    {
        static void Main(string[] args)
        {
            var cipher = new CaesarCipher();
            Console.Write("Enter text: ");
            var message = Console.ReadLine();
            Console.Write("Enter key: ");
            var secretKey = Convert.ToInt32(Console.ReadLine());
            var encryptedText = cipher.Encrypt(message, secretKey);
            Console.WriteLine("Encrypted message: {0}", encryptedText);
            var DecryptedText = cipher.Decrypt(encryptedText, secretKey);
            Console.WriteLine("Decrypted message: {0}", DecryptedText);

            Dictionary<string, string> Codes = new Dictionary<string, string>
            {
                {"A", ".-   "}, {"B", "-... "}, {"C", "-.-. "}, {"D", "-..  "},
                {"E", ".    "}, {"F", "..-. "}, {"G", "--.  "}, {"H", ".... "},
                {"I", "..   "}, {"J", ".--- "}, {"K", "-.-  "}, {"L", ".-.. "},
                {"M", "--   "}, {"N", "-.   "}, {"O", "---  "}, {"P", ".--. "},
                {"Q", "--.- "}, {"R", ".-.  "}, {"S", "...  "}, {"T", "-    "},
                {"U", "..-  "}, {"V", "...- "}, {"W", ".--  "}, {"X", "-..- "},
                {"Y", "-.-- "}, {"Z", "--.. "}, {"0", "-----"}, {"1", ".----"},
                {"2", "..---"}, {"3", "...--"}, {"4", "....-"}, {"5", "....."},
                {"6", "-...."}, {"7", "--..."}, {"8", "---.."}, {"9", "----."}
            };

            foreach (char c in DecryptedText.ToCharArray())
            {
                string rslt = Codes[c.ToString()].Trim();
                foreach (char c2 in rslt.ToCharArray())
                {
                    if (c2 == '.')
                    {
                        Console.Beep(1000, 250);
                    }
                    else
                    {
                        Console.Beep(1000, 750);
                    }
                }
                System.Threading.Thread.Sleep(50);
            }

            Console.ReadKey();
        }
    }
}
