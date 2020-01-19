using System;
using System.IO;

namespace CSharp_Net_module1_3_1_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            CatchExceptionClass cec = new CatchExceptionClass();
            cec.CatchExceptionMethod();

            // 11) Make some unhandled exception and study Visual Studio debugger report – 
            // read description and find the reason of exception

            File.Create(@"D:\Games\numbers.txt");

            for (int i = 0; i < 501; i++)
            {
                if (i % 200 == 0)
                {
                    File.WriteAllText(@"D:\Games\numbers.txt", "," + i); 
                }
                else
                {
                    File.WriteAllText(@"D:\Games\numbers.txt", "," + i);
                }
            }

            //Ошибка возникает потому что я не закрываю поток записи файла, после каждой итерации

            Console.ReadKey();
        }
    }
}
