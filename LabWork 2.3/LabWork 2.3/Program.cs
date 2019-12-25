using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork_2._3
{
    enum CurrencyTypes
    {
        UAH,
        USD,
        EU
    }

    class Money
    {
        public int Amount;
        public CurrencyTypes Currency;

        public static Money operator +(Money c1, Money c2)
        {
            return new Money { Amount = c1.Amount - c2.Amount };
        }

        public static Money operator --(Money c1)
        {
            return new Money { Amount = c1.Amount -= 3 };
        }

        public static Money operator ++(Money c1)
        {
            return new Money { Amount = c1.Amount -= 1 };
        }

        public static Money operator *(Money c1, int multiply)
        {
            return new Money { Amount = c1.Amount * 3 };
        }

        public static Money operator <(Money c1, Money c2)
        {
            if (c1.Amount < c2.Amount)
            {
                return c1;
            }
            else if (c2.Amount < c1.Amount)
            {
                return c2;
            }
            return c1;
        }

        public static Money operator >(Money c1, Money c2)
        {
            if (c1.Amount > c2.Amount)
            {
                return c1;
            }
            else if (c2.Amount > c1.Amount)
            {
                return c2;
            }
            return c1;
        }

        public static Money operator <(Money c1, string c2)
        {
            if (c1.Amount < Convert.ToInt32(c2))
            {
                return c1;
            }
            else if (Convert.ToInt32(c2) < c1.Amount)
            {
                return new Money { Amount = Convert.ToInt32(c2) };
            }
            return c1;
        }

        public static Money operator >(Money c1, string c2)
        {
            if (c1.Amount > Convert.ToInt32(c2))
            {
                return c1;
            }
            else if (Convert.ToInt32(c2) > c1.Amount)
            {
                return new Money { Amount = Convert.ToInt32(c2) };
            }
            return c1;
        }

        public static bool operator true(Money c1)
        {
            return c1.Amount != 0;
        }
        public static bool operator false(Money c1)
        {
            return c1.Amount == 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Money Money_1 = new Money { Amount = 23, Currency = CurrencyTypes.UAH };
            Money Money_2 = new Money { Amount = 21, Currency = CurrencyTypes.USD };

            Money c3 = Money_1 + Money_2;
            Console.WriteLine("Result of operator + :" + c3.Amount.ToString());

            Money_2--;
            Console.WriteLine("Result of operator -- :" + Money_2.Amount.ToString());

            Money_1++;
            Console.WriteLine("Result of operator ++ :" + Money_1.Amount.ToString());

            Money c4 = Money_1 < Money_2;
            Console.WriteLine("Result of operator < :" + c4.Amount.ToString());

            Money c5 = Money_1 < "2";
            Console.WriteLine("Result of compare object with string :" + c5.Amount);

            Console.WriteLine("Result checking currencies : " + Money_1.Currency + " " + Money_2.Currency );

            var CountOfUah = Money_1. Currency == CurrencyTypes.UAH ? 1: 0;
            var CountOfUsd = Money_1.Currency == CurrencyTypes.USD ? 1 : 0;
            var CountOfEU = Money_1.Currency == CurrencyTypes.EU ? 1 : 0;

            CountOfUah = Money_2.Currency == CurrencyTypes.UAH ? CountOfUah + 1 : CountOfUah;
            CountOfUsd = Money_2.Currency == CurrencyTypes.USD ? CountOfUsd + 1 : CountOfUsd;
            CountOfEU = Money_2.Currency == CurrencyTypes.EU ? CountOfEU + 1: CountOfEU;

            Console.WriteLine("Amount of same courencies UAH|USD|EU : " + CountOfUah + " " + CountOfUsd + " " + CountOfEU);

            Console.WriteLine("");

            var test = Money_1.ToString();
            Console.WriteLine("Object 1 to string : " + test);
  
            Console.ReadKey();
        }
    }
}
