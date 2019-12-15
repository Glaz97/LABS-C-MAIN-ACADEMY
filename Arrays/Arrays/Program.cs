using System;

namespace Operators
{
    class Program
    {
        enum TypeOfComputer
        {
            server,
            desktop,
            laptop
        }

        public struct Computer
        {
            public string TypeOfComputer;
            public int AmountOfComputers;
            public int AmountOfCPUCores;
            public float FrequencyOfCPU;
            public int AmountOfOperativeMemory;
            public int AmountOfHDDMemory;

            public Computer(string TypeOfComputer, int AmountOfComputers, int AmountOfCPUCores, float FrequencyOfCPU, int AmountOfOperativeMemory, int AmountOfHDDMemory)
            {
                this.TypeOfComputer = TypeOfComputer;
                this.AmountOfComputers = AmountOfComputers;
                this.AmountOfCPUCores = AmountOfCPUCores;
                this.FrequencyOfCPU = FrequencyOfCPU;
                this.AmountOfOperativeMemory = AmountOfOperativeMemory;
                this.AmountOfHDDMemory = AmountOfHDDMemory;
            }
        }

        public struct Department
        {
            public int DepartmentNumber;
            public Computer Servers;
            public Computer Desktops;
            public Computer Laptops;

            public Department(int DepartmentNumber, Computer Servers, Computer Desktops, Computer Laptops)
            {
                this.DepartmentNumber = DepartmentNumber;
                this.Servers = Servers;
                this.Desktops = Desktops;
                this.Laptops = Laptops;
            }
        }

        static void Main(string[] args)
        {
            Department[] Departments = new Department[4];

            Departments[0] = new Department(1, new Computer(GetName(0),1,8,3,16,2000), new Computer (GetName(1),2,4,2.5F,6,500), new Computer (GetName(2),2,2,1.7F,4,250));
            Departments[1] = new Department(2, new Computer(GetName(0),0,8,3,16,2000), new Computer (GetName(1),0,4,2.5F,6,500), new Computer (GetName(2),3,2,1.7F,4,250));
            Departments[2] = new Department(3, new Computer(GetName(0),0,8,3,16,2000), new Computer (GetName(1),3,4,2.5F,6,500), new Computer (GetName(2),2,2,1.7F,4,250));
            Departments[3] = new Department(4, new Computer(GetName(0),2,8,3,16,2000), new Computer (GetName(1),1,4,2.5F,6,500), new Computer (GetName(2),1,2,1.7F,4,250));

            var exit = 1;
            while (exit == 1)
            {
                int VariantNumber = 0;
                VariantNumber = SelectVariant(VariantNumber);

                //Проверка на неккоректный ввод числа
                if (VariantNumber < 0 || VariantNumber > 4)
                {
                    while (VariantNumber < 0 || VariantNumber > 4)
                    {
                        Console.WriteLine("Введите целое число от 1 до 4" + '\n');
                        VariantNumber = SelectVariant(VariantNumber);
                    }
                }

                //Проверка на выбранные виды алгоритма
                if (VariantNumber == 0)
                {
                    Console.WriteLine("Введите целое число от 1 до 4" + '\n');
                    VariantNumber = SelectVariant(VariantNumber);
                }
                else if (VariantNumber == 1)
                {
                    CountAmountOfComputers(Departments);
                }
                else if (VariantNumber == 2)
                {
                    FindComputerWithBiggestHDD(Departments);
                }
                else if (VariantNumber == 3)
                {
                    FindComputerWithWeakestCPU(Departments);
                }
                else if (VariantNumber == 4)
                {
                    RaiseMemoryOfComputers(Departments);
                }

                Console.WriteLine("Поздравляем! Хотите попробовать что-то еще? 0 - НЕТ, 1 - КОНЕЧНО!");

                try
                {
                    exit = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Вы ввели что-то не то, программа не понимать и выключатся! В следующий раз введите 0 - НЕТ, 1 - КОНЕЧНО!");
                    return;
                }
            }
        }

        public static string GetName (int value)
        {
            return Enum.GetName(typeof(TypeOfComputer), value);
        }

        public static void CountAmountOfComputers(Department[] Departments)
        {
            int CountOfComputers = 0;

            foreach (var department in Departments) {
                CountOfComputers += department.Desktops.AmountOfComputers + department.Servers.AmountOfComputers + department.Laptops.AmountOfComputers;
            }

            Console.WriteLine("Всего компьютеров - " + CountOfComputers);
        }

        public static void FindComputerWithBiggestHDD(Department[] Departments)
        {
            string NameOfPCAndDepartament = "";

            var tempDesktop = 0;
            var tempServer = 0;
            var tempLaptop = 0;

            foreach (var department in Departments)
            {
                if (department.Desktops.AmountOfHDDMemory > tempDesktop)
                {
                    tempDesktop = department.Desktops.AmountOfHDDMemory; 
                }

                if (department.Servers.AmountOfHDDMemory > tempServer)
                {
                    tempServer = department.Servers.AmountOfHDDMemory;
                }

                if (department.Laptops.AmountOfHDDMemory > tempLaptop)
                {
                    tempLaptop = department.Laptops.AmountOfHDDMemory;
                }

                if (tempDesktop > tempServer & tempDesktop > tempLaptop)
                {
                    NameOfPCAndDepartament = "Desktop " + tempDesktop + " GB";
                }
                else if (tempServer > tempLaptop & tempServer > tempDesktop)
                {
                    NameOfPCAndDepartament = "Server " + tempServer + " GB";
                }
                else if (tempLaptop > tempServer & tempLaptop > tempDesktop)
                {
                    NameOfPCAndDepartament = "Laptop " + tempLaptop + " GB";
                }
            }

            Console.WriteLine("Больше всего памяти у пк - " + NameOfPCAndDepartament);
        }

        public static void FindComputerWithWeakestCPU(Department[] Departments)
        {
            string NameOfPCAndDepartament = "";

            var tempDesktop = 0;
            var tempServer = 0;
            var tempLaptop = 0;

            foreach (var department in Departments)
            {
                if (department.Desktops.AmountOfHDDMemory > tempDesktop)
                {
                    tempDesktop = department.Desktops.AmountOfCPUCores;
                }

                if (department.Servers.AmountOfHDDMemory > tempServer)
                {
                    tempServer = department.Servers.AmountOfCPUCores;
                }

                if (department.Laptops.AmountOfHDDMemory > tempLaptop)
                {
                    tempLaptop = department.Laptops.AmountOfCPUCores;
                }

                if (tempDesktop < tempServer & tempDesktop < tempLaptop)
                {
                    NameOfPCAndDepartament = "Desktop " + tempDesktop + " HGz";
                }
                else if (tempServer < tempLaptop & tempServer < tempDesktop)
                {
                    NameOfPCAndDepartament = "Server " + tempServer + " HGz";
                }
                else if (tempLaptop < tempServer & tempLaptop < tempDesktop)
                {
                    NameOfPCAndDepartament = "Laptop " + tempLaptop + " HGz";
                }
            }

            Console.WriteLine("Меньше всего частота CPU у пк - " + NameOfPCAndDepartament);
        }

        public static void RaiseMemoryOfComputers(Department[] Departments)
        {
            for(int i = 0; i < Departments.Length; i++) 
            {
                Departments[i].Desktops.AmountOfOperativeMemory = 8;
            }

            Console.WriteLine("Оперативная память у всех компьютеров Desktop увеличена до 8 GB");
        }

        public static int SelectVariant(int VariantNumber)
        {
            Console.WriteLine("Укажите номер алгоритма для запуска" + '\n');
            Console.WriteLine("1 - Количество компьютеров" + '\n' + "2 - Компьютер с самым большим HDD" + '\n' + "3 - Компьютер с самым слабым CPU" +
            "" + '\n' + "4 - Увеличить память компудактеров на 8 GB" + '\n');
            try
            {
                VariantNumber = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ошибка! Необходимо ввести целое число от 1 до 4!" + '\n');
            }
            return VariantNumber;
        }
    }
}
