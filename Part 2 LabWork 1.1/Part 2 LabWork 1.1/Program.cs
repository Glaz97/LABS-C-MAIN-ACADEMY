using PersonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_2_LabWork_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person student = new Person();

            student.FirstName = "Xep";
            student.LastName = "SGory";
            student.BirthDay = DateTime.Now;
            student.ID = 1;

            Console.WriteLine("Student FirstName " + student.FirstName +
                "Student LastName " + student.LastName + "Student BirthDay " + student.BirthDay);

            Console.ReadKey();
        }
    }
}
