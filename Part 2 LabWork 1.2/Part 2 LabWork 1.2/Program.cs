using AirplaneLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_2_LabWork_1._2
{
    public class UniversalAirplane
    {
        public AirplaneTypes Jet = AirplaneTypes.Jet;
        public AirplaneTypes SportPlane = AirplaneTypes.SportPlane;
        public AirplaneTypes TurboProp = AirplaneTypes.TurboProp;

        public UniversalAirplane()
        {
            Console.Write("This is  universal airplane class contains types: " + Jet + " " + SportPlane + " " + TurboProp);
        }
    }

    public class CargoAirplane
    {
        public AirplaneTypes CargoPlane = AirplaneTypes.CargoPlane;

        public CargoAirplane()
        {
            Console.Write("This is  cargo airplane class contains type: " + CargoPlane);
        }
    }

    public class CheckSaveTrace
    {
        public static void CheckClassAtributes(object Class)
        {
            //вывод атрибутов и их значений

            Type myType = Type.GetType(Class.ToString(), false, true);

            foreach (var mi in myType.GetMembers())
            {
                Console.WriteLine($"{mi.DeclaringType} {mi.MemberType} {mi.Name}");
            }
        }

        public static string GetDescriptionOfAttributes(object Class)
        {
            var ReturnString = "";

            Type myType = Type.GetType(Class.ToString(), false, true);

            foreach (var mi in myType.GetMembers())
            {
                ReturnString = ReturnString + $"{mi.DeclaringType} {mi.MemberType} {mi.Name}";
            }

            return ReturnString;
        }

        public static void SaveTrace()
        {
            //сохранение данных в Trace file

            var consoleTracer = new ConsoleTraceListener();

            consoleTracer.Name = "mainConsoleTracer";

            consoleTracer.WriteLine(GetDescriptionOfAttributes(new UniversalAirplane()) + " " + consoleTracer.Name );
        }

        public static void EventLogging()
        {
            //сохранение данных в event log

            var appLog = new EventLog("Application");
            appLog.Source = "MySource";
            appLog.WriteEntry(GetDescriptionOfAttributes(new UniversalAirplane()));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CheckSaveTrace.GetDescriptionOfAttributes(new UniversalAirplane());

            CheckSaveTrace.SaveTrace();

            CheckSaveTrace.EventLogging();

            Console.ReadKey();
        }
    }
}
