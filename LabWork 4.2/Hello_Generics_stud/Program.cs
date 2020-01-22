using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Generics_stud
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;

            MyMethod();

            try
            {
                do
                {
                    Console.WriteLine(@"Please,  type the number:

                        Generics      Class Derived : Base<Derived>
                        1.  Static base constructor
                        2.  Protected base constructor (StackOverflow !)
                        3.  Static base constructor, public field
                        4.  Protected base constructor, static field

                        Generics      Delegats & List
                        5.  Generic delegates, extension methods, List  
                
                        ");
                    try
                    {
                        a = int.Parse(Console.ReadLine());
                        switch (a)
                        {
                            case 1:
                                Swap<Derived>();
                                Console.WriteLine("Create Derived from static base constructor ..." );

                                break;
                            case 2:
                                Swap<DerivedPubl>();
                                Console.WriteLine("Create Derived from static base constructor ...");

                                break;
                            case 3:
                                Swap<DerivedPublicField>();
                                Console.WriteLine("Create Derived from static base constructor ...");

                                break;
                            case 4:
                                Swap<DerivedStaticField>();
                                Console.WriteLine("Create Derived from static base constructor ...");

                                Console.WriteLine("");
                                break;
                            case 5:
                                Console.WriteLine("Create currying ...");

                                Console.WriteLine("");
                                break;

                            default:
                                Console.WriteLine("Exit");
                                break;
                        }

                    }
                    catch (System.Exception e)
                    {
                        Console.WriteLine("Error");
                    }
                    finally
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Press Spacebar to exit; press any key to continue");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                while (Console.ReadKey().Key != ConsoleKey.Spacebar);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static void Swap<T>() where T : new()
        {
            T puzzle = new T();
            Console.WriteLine("");
        }

        public static void MyMethod()
        {
            var source = new List<double> {1.0,2.4,34.9,9.02,7.0};
            var result = new List<double>();

            Func<double, double, double> f = (x, y) => x - y;

            var fBnd = f.Bnd()(2.0);

            Console.WriteLine("Source list");
            foreach (var item in source)
            {
                Console.Write("{0} ; ", item);
                result.Add(fBnd(item));
            }

            Console.WriteLine("");
            Console.WriteLine("Result list");
            foreach (var item2 in result)
            {
                Console.Write("{0} ; ", item2);
            }
            Console.WriteLine("");
        }
    }

    public class Base<T> where T : new()
    {
        public T temp;

        static Base()
        {
            T temp = new T();
            Console.WriteLine("MessageBase");
        }
    }

    public sealed class Derived : Base<Derived>
    {
        public Derived()
        {
            Console.WriteLine("MessageDerived");
        }
    }

    public class BasePublicField<T> where T : new()
    {
        public T temp;
        private T _instance;
        public T instance
        {
            get
            {
                Console.WriteLine("Public field");
                _instance = new T();
                return _instance;
            }
        }

        static BasePublicField()
        {
            T temp = new T();
            Console.WriteLine("MessageBasePublicField");
        }

    }

    public sealed class DerivedPublicField: BasePublicField<DerivedPublicField>
    {
        public DerivedPublicField()
        {
            Console.WriteLine("MessageDerivedPublicField");
        }
    }

    public class BaseStaticField<T> where T : new()
    {
        public static string C;
        public static string D;
        public T temp;

        static BaseStaticField()
        {
            T temp = new T();
            Console.WriteLine("MessageBaseStaticField");
        }
    }

    public sealed class DerivedStaticField : BaseStaticField<DerivedStaticField>
    {
        public DerivedStaticField()
        {
            Console.WriteLine("MessageDerivedStaticField");
        }
    }

    public class BasePubl<T> where T : new()
    {
        public T temp;

        public string C;
        public string D;
        private string E;
        private string F;

        static BasePubl()
        {
            T temp = new T();
            Console.WriteLine("MessageBasePubl");
        }
    }

    public sealed class DerivedPubl : BasePubl<DerivedPubl>
    {
        public DerivedPubl()
        {
            Console.WriteLine("MessageDerivedPubl");
        }
    }

    public static class CurryList
    {
        public static Func<Targ2, Func<Targ1, TResult>> Bnd<Targ1, Targ2, TResult>(this Func<Targ1, Targ2, TResult> f)
        {
            return (y) => ((x) => f(x, y));
        }
    }
}

