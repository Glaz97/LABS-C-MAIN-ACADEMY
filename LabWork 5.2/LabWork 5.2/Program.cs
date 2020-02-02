using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Xml.Serialization;

namespace LabWork_5._2
{
    [Serializable]
    public class Student
    {
        public string FirstName;
        public string LastName;

        public string Address;
        public string PostCode;

        [NonSerialized]
        public string Nationality;

        public Student()
        {
        }

        public Student (string FirstName, string LastName, string Nationality, string Address, string PostCode)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Nationality = Nationality;
            this.Address = Address;
            this.PostCode = PostCode;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student("Petya", "Yanukovych", "Donetskiy", "DNR", "03987");
            Student student2 = new Student("Vanya", "Judonovych", "Jude", "OyVei", "98765");

            Student[] students = new Student[] { student1, student2 };

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("students.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, students);
            }

            using (FileStream fs = new FileStream("students.dat", FileMode.OpenOrCreate))
            {
                Student[] deserilizeStudents = (Student[])formatter.Deserialize(fs);

                foreach (Student p in deserilizeStudents)
                {
                    Console.WriteLine($"Имя: {p.FirstName} --- Фамилия: {p.LastName} --- Национальнсть: {p.Nationality} --- Адрес: {p.Address}" +
                    $" --- Код: {p.PostCode}");
                }
            }

            XmlSerializer formatter2 = new XmlSerializer(typeof(Student[]));

            using (FileStream fs2 = new FileStream("students.xml", FileMode.OpenOrCreate))
            {
                formatter2.Serialize(fs2, students);
            }

            using (FileStream fs2 = new FileStream("students.xml", FileMode.OpenOrCreate))
            {
                Student[] newStudents = (Student[])formatter2.Deserialize(fs2);

                foreach (Student p in newStudents)
                {
                    Console.WriteLine($"Имя: {p.FirstName} --- Фамилия: {p.LastName} --- Национальнсть: {p.Nationality} --- Адрес: {p.Address}" +
                $" --- Код: {p.PostCode}");
                }
            }

            SoapFormatter formatter3 = new SoapFormatter();

            using (FileStream fs3 = new FileStream("students.soap", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs3, students);
            }

            using (FileStream fs3 = new FileStream("students.soap", FileMode.OpenOrCreate))
            {
                Student[] newStudents = (Student[])formatter.Deserialize(fs3);

                foreach (Student p in newStudents)
                {
                    Console.WriteLine($"Имя: {p.FirstName} --- Фамилия: {p.LastName} --- Национальнсть: {p.Nationality} --- Адрес: {p.Address}" +
                    $" --- Код: {p.PostCode}");
                }
            }

            Console.ReadKey();
        }
    }
}
