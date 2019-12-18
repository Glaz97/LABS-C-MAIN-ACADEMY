using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork_2._1_OOP
{
    interface ILibraryUser
    {
        void AddBook(string NameOfBook, int year, string Author);
        void RemoveBook(int Index);
        string BookInfo();
        string BooksCount();
    }

    class LibraryUser : ILibraryUser
    {
        public readonly int ID;
        public readonly int BookLimit;
        public readonly string FirstName;
        public readonly string LastName;
        public int Index = 0;
        public int Phone { get; set; }
        private string[] BookList;

        public LibraryUser(int ID, int BookLimit, string FirstName, string LastName, int Phone, string[] BookList)
        {
            this.ID = ID;
            this.BookLimit = BookLimit;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Phone = Phone;
            this.BookList = BookList;
        }

        public void AddBook(string NameOfBook, int Year, string Author)
        {
            BookList[Index] = NameOfBook + "," + Year + "," + Author;
            Index += 1;
        }

        public void RemoveBook(int Index)
        {
            BookList[Index].Remove(Index);
            Index -= 1;
        }

        public string BookInfo()
        {
            string AllBookInfo = "";

            Console.WriteLine("Enter the number of book!");
            var NumberOfBook = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < BookList.Count(); i++)
            {
                if (BookList[i] != null && i == NumberOfBook)
                {
                    var information = BookList[i].Split(',');

                    foreach (var element in information)
                    {
                        AllBookInfo += element + " ";
                    }

                    AllBookInfo += "\n";
                }
            }

            return AllBookInfo;
        }

        public string BooksCount()
        {
            int CountOfBooks = 0;
            foreach (var book in BookList)
            {
                if (book != null)
                {
                    CountOfBooks += 1;
                }
            }
            return "Count of books of user " + FirstName + " " + LastName + " = " + CountOfBooks;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int exit = 1;

            List<LibraryUser> LibraryUser = new List<LibraryUser>();

            LibraryUser.Add(new LibraryUser(0, 5, "Ludolf", "von Pupkevello", 992045674, new string[10]));
            LibraryUser.Add(new LibraryUser(1, 5, "Sigizmund", "de Zalupono", 999876542, new string[10]));

            while (exit == 1)
            {
                ShowTheListOfUsers(LibraryUser);

                string[] Action = new string[2];
                int NumberOfAction = 0;
                int? NumberOfUser = null;

                try
                {
                    Console.WriteLine("");
                    Action = Console.ReadLine().Split(',');
                    NumberOfAction = Convert.ToInt32(Action[0]);
                    NumberOfUser = Convert.ToInt32(Action[1]);
                }
                catch
                {
                    exit = 0;
                    Console.WriteLine("Eror, the programm is shutting down!");
                    Console.ReadKey();
                }

                if (NumberOfAction >= 0 & NumberOfAction <= 4)
                {
                    int Answer = 1;

                    if (NumberOfUser == null || NumberOfUser > LibraryUser.Count)
                    {
                        exit = 0;
                        Console.WriteLine("Eror, the programm is shutting down!");
                        Console.ReadKey();
                    }
                    else
                    {
                        Answer = RunTheVariant(NumberOfAction, LibraryUser.Where(x => x.ID == NumberOfUser).ToList());
                    }

                    if (Answer == 0)
                    {
                        exit = 0;
                    }
                }
            }
        }

        public static int RunTheVariant(int NumberOfAction, List<LibraryUser> LibraryUser)
        {
            int Answer = 1;
            var user = LibraryUser.FirstOrDefault();

            if (NumberOfAction == 1)
            {
                Console.WriteLine("Enter the name of book, year of book, and the name of author separated by coma!");
                string[] EnteredString = Console.ReadLine().Split(',');

                try
                {
                    user.AddBook(EnteredString[0], Convert.ToInt32(EnteredString[1]), EnteredString[2]);
                }
                catch
                {
                    Answer = 0;
                    Console.WriteLine("Eror, the programm is shutting down!");
                }
                Console.WriteLine("The book has been added!");
                Console.ReadKey();
            }
            else if (NumberOfAction == 2)
            {
                Console.WriteLine("Enter number of book, which you prefer to remove!");
                string EnteredString = Console.ReadLine();

                try
                {
                    user.RemoveBook(Convert.ToInt32(EnteredString));
                }
                catch
                {
                    Answer = 0;
                    Console.WriteLine("Eror, the programm is shutting down!");
                }
                Console.WriteLine("The book has been removed!");
                Console.ReadKey();
            }
            else if (NumberOfAction == 3)
            {
                Console.WriteLine(user.BookInfo());
                Console.ReadKey();
            }
            else if (NumberOfAction == 4)
            {
                Console.WriteLine(user.BooksCount());
                Console.ReadKey();
            }
            else if (NumberOfAction == 0)
            {
                Answer = 0;
            }
            return Answer;
        }

        public static void ShowTheListOfUsers(List<LibraryUser> LibraryUser)
        {
            Console.Clear();
            Console.WriteLine("Hello my dear friend! You have " + LibraryUser.Count + " user's of library!" + "\n");
            Console.WriteLine("List of users:");

            foreach (var user in LibraryUser)
            {
                Console.WriteLine("|" + user.ID + "| " + user.FirstName + " " + user.LastName);
            }

            Console.WriteLine("\n");
            Console.WriteLine("You can try to do some action with them:");
            Console.WriteLine("Enter the number of action and number of user separated by coma:" + "\n");

            Console.WriteLine("1,№ - Add book to user booklist");
            Console.WriteLine("2,№ - Remove book from user booklist");
            Console.WriteLine("3,№ - Watch a short info from some book of user");
            Console.WriteLine("4,№ - How much books does the user have?");
            Console.WriteLine("0,0 - Exit from programm?");
        }
    }
}
