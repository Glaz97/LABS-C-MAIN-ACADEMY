using System;
using System.Linq.Expressions;

namespace Part_2_LabWork_3._1
{
    public class PointerOperation
    {
        public static int? NullInt;
        public static int NoNullInt;

        public static byte[] ConvertToByte(int number)
        {
            byte[] intBytes = BitConverter.GetBytes(number);
            Array.Reverse(intBytes);
            byte[] result = intBytes;
            return result;
        }

        public static void Power(int number)
        {
            for (int power = 0; power <= 32; power++)
                Console.WriteLine($"{number}^{power} = {(long)Math.Pow(number, power):N0} (0x{(long)Math.Pow(number, power):X})");
        }

        public static void SetAsNullable()
        {
            var someIntExpr = Expression.Constant(NoNullInt, typeof(int));
            var someNubIntExpr = Expression.Constant(null, typeof(int?));
            var goodEq = Expression.Equal(Expression.Convert(someIntExpr, typeof(int?)), someNubIntExpr);
            Console.WriteLine("Success");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число:");

            try
            {
                int.TryParse(Console.ReadLine(), out int result);
                var BitArray = PointerOperation.ConvertToByte(result);

                foreach (var bit in BitArray)
                    Console.WriteLine(bit);

                PointerOperation.Power(result);

                PointerOperation.NoNullInt = result;
                PointerOperation.SetAsNullable();

                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Error. Please, try to input number again!");
            }
        }
    }
}
