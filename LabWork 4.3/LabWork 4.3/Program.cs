using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork_4._3
{
    class Program
    {
        static void Main(string[] args)
        {
            var animals = new Animals(new Animal[] { new Animal { Genus = "Синичка", Weight = 2 }, new Animal { Genus = "Лисичка", Weight = 5 }, new Animal { Genus = "Птичка", Weight = 1 }, new Animal { Genus = "Кот", Weight = 6 } });

            Animal[] AnimalsArray = animals.GetAnimalsArray();

            Console.WriteLine("Unsorted animals");

            foreach (var animal in AnimalsArray)
            {
                Console.WriteLine(animal.Genus + " " + animal.Weight);
            }

            Console.WriteLine("Sorted by Weight");

            var AnimalsList =  AnimalsArray.ToList();

            var orderedList = from i in AnimalsList
                                 orderby i.Weight
                                 select i;

            foreach (var animal in orderedList)
            {
                Console.WriteLine(animal.Genus + " " + animal.Weight);
            }

            Console.WriteLine("Sorted by Genus");

            var orderedList2 = from i in AnimalsList
                              orderby i.Genus
                              select i;

            foreach (var animal in orderedList2)
            {
                Console.WriteLine(animal.Genus + " " + animal.Weight);
            }

            Console.ReadKey();
        }
    }

    public class Animal : IComparable
    {

        public string Genus { get; set; }
        public int Weight { get; set; }
        public int Position { get; set; }

        public Animal()
        {
            Genus = "2";
            Weight = 3;
        }

        public int CompareTo(object o)
        {
            Animal p = o as Animal;
            if (p != null)
                return this.Genus.CompareTo(p.Genus);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }

        private class SortWeightAscendingHelper : IComparer
        {
            public int Compare(object a, object b)
            {
                Animal c1 = (Animal)a; Animal c2 = (Animal)b; if (c1.Weight > c2.Weight) return 1; if (c1.Weight < c2.Weight) return -1; else return 0;
            }
        }

        private class SortGenusDescendingHelper : IComparer
        {
            public int Compare(object a, object b)
            {
                Animal c1 = (Animal)a; Animal c2 = (Animal)b; if (Convert.ToInt32(c1.Genus) > Convert.ToInt32(c2.Genus)) return 1; if (Convert.ToInt32(c1.Genus) < Convert.ToInt32(c2.Genus)) return -1; else return 0;
            }
        }
    }

    public class CompInv : IComparer
    {
        public int Compare(object x, object y)
        {
            Animal a, b;
            a = (Animal)x;
            b = (Animal)y;
            return string.Compare(a.Genus, b.Genus, StringComparison.Ordinal);
        }
    }

    public class Animals : IEnumerable
    {
        private Animal[] ArrayAnimals;

        public Animals(Animal[] animals)
        {
            ArrayAnimals = animals;
        }

        public Animal[] GetAnimalsArray()
        {
            return ArrayAnimals;
        }

        public IEnumerator GetEnumerator()
        {
            return ArrayAnimals.GetEnumerator();
        }
    }

    public class AnimalsEnumerator : IEnumerator
    {
        Animal[] animals;

        int position = -1;
        public AnimalsEnumerator(Animal[] animals)
        {
            this.animals = animals;
        }
        public object Current
        {
            get
            {
                if (position == -1 || position >= animals.Length)
                    throw new InvalidOperationException();
                return animals[position];
            }
        }

        public bool MoveNext()
        {
            if (position < animals.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
