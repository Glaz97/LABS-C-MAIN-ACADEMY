using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variables
{
    class Program
    {
        object budget = 2281488;
        static void Main(string[] args)
        {
            const int tes = 1;
            const double tes2 = 1D;
            const float tes3 = 1F;
            bool CeRozbiynuk = false;
            byte bit12 = 1;
            sbyte bit1 = -101;
            ushort n2 = 102;
            short a = 2;
            int Valuta = 0;
            uint b = 10;
            long c = 4;
            ulong c1 = 10;
            float f = 3.14F;
            double d = 3000D;
            decimal d1 = 1005.8M;

            var h = 2;
            string t = "3";

            sbyte z = 4;
            short x = z;

            int f4 = 4;
            int f5 = 6;
            byte f6 = (byte)(f4 + f5);

            char test = 'R';

            string rozbiynuk = "Rozbiynuk";
            string ZEkonnyk = "ZEkonnyk";

            string success = "Zrobymo ih razom!";
            string failed = "Viydu otsuda rozbiynuk!";
            string failed2 = "Ya skazav viydu otsuda!";

            var zarplataRozbiynuka = 15000;
            var KursZelenogo = 25F;

            Console.Write(ZEkonnyk + ": " + "Skilky wy zarobylu za rik, nazvit cyfru?" + '\n');
            int CountOfMoney = Convert.ToInt32(Console.ReadLine());
            Console.Write(rozbiynuk + ": " + CountOfMoney + '\n');

            Console.Write(ZEkonnyk + ": " + "A ce v yakiy valuti? (1-$, 2-UAH)" + '\n');
            Valuta = Convert.ToInt32(Console.ReadLine());
            var Nazva = Valuta == 1 ? "$":"UAH";
            Console.Write(rozbiynuk + ": " + Nazva + '\n');

            if (Valuta == 1)
            {
                CountOfMoney = CountOfMoney * Convert.ToInt32(KursZelenogo);
            }

            if (CountOfMoney > zarplataRozbiynuka * 12)
            {
                Console.Write(ZEkonnyk + ": " + failed + '\n');
                CeRozbiynuk = true;
            }
            else
            {
                Console.Write(ZEkonnyk + ": " + success);
            }

            if (CeRozbiynuk)
            {
                Console.Write("");
                Console.Write(ZEkonnyk + ": " + failed2 + '\n');
            }

            Console.ReadKey();
        }
    }
}
