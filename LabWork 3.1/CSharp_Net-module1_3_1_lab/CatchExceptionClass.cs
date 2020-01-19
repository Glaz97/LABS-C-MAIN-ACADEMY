using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_3_1_lab
{
    class CatchExceptionClass
    {
        public void CatchExceptionMethod()
        {
            try
            {
                MyArray ma = new MyArray();

                // 3) replace second elevent of array by 0

                int[] arr = new int[4] { 1, 4, 8, 5 };

                arr[1] = 0;

                ma.Assign(arr, 4);

            }
           
                // 8) catch all other exceptions here
            catch
            {
                // 9) print System.Exception properties:
                // HelpLink, Message, Source, StackTrace, TargetSite

                //Gets or sets a link to the help file associated with this exception.
                //public virtual string HelpLink { get; set; }

                //Gets a message that describes the current exception.
                //public virtual string Message { get; }

                //Gets or sets the name of the application or the object that causes the error.
                //public virtual string Source { get; set; }

                //Gets a string representation of the immediate frames on the call stack.
                //public virtual string StackTrace { get; }

                //Gets the method that throws the current exception.
                //public System.Reflection.MethodBase TargetSite { get; }
    }

            // 10) add finally block, print some message
            // explain features of block finally
            finally
            {
                //Данный блок вызывается в любом случаем после блока try или после блоков try и catch
                //Он используется например для того чтобы не обрабатывать исключение
                Console.WriteLine("Kto-to gde-to nabakaporyl");
            }
        }
    }
}
