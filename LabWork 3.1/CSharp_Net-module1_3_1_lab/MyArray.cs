using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_3_1_lab
{
    class MyArray
    {
        int[] arr;

        public void Assign(int[] arr, int size)
        {
            // 5) add block try (outside of existing block try)
            //try
            try
            {
                int v = 1;
                int zero = 0;

                int result = v / zero;

                try
                {
                    this.arr = new int[size];

                    this.arr[5] = 1000;

                    for (int i = 0; i < arr.Length; i++)
                        this.arr[i] = arr[i] / arr[i + 1];

                    // 7) use unchecked to assign result of operation 1000000000 * 100 
                    // to last cell of array
                    var a = 1000000000;
                    var b = 100;
                    this.arr[5] = a * b;

                    //NullReferenceException

                    try
                    {
                        string foo = null;
                        foo.ToUpper();
                    }
                    catch
                    {
                        Console.WriteLine("Exception NullReferenceException");
                    }

                }
                // 2) catch exception index out of rage
                catch
                {
                    Console.WriteLine("Exception unchecked to assign result of operation");
                    Console.WriteLine("Exception eror out of range");
                }
            }

            catch
            {
                Console.WriteLine("Exception divizion by zero");
            }
            // 4) catch devision by 0 exception
            //catch

            // 6) add catch block for null reference exception of outside block try  
            // change the code to execute this block (any method of any class)
            //catch
            try
            {
                string foo = null;
                foo.ToUpper();
            }
            catch
            {
                Console.WriteLine("Exception NullReferenceException");
            }
        }
    }
}
