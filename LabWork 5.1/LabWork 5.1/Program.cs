using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.Threading.Tasks;

namespace LabWork_5._1
{
    public class Computer
    {
        public int Cores { get; set; }
        public double Frequency { get; set; }
        public int Memory { get; set; }
        public int Hdd { get; set; }
    }

    public static class InOutOperation
    {
        public static string CurrentPath = "";
        public static string CurrentDirectory = "";
        public static object CurrentFile;

        public static void ChangeLocation(string NewFilePath)
        {
            try
            {
                File.Move(CurrentPath, NewFilePath);
            }
            catch
            {
                CreateDirectory(NewFilePath);
                File.Move(CurrentPath, NewFilePath);
                CurrentPath = NewFilePath;
            }
        }

        public static void CreateDirectory(string NewFilePath)
        {
            var NewDirectory = Path.GetDirectoryName(NewFilePath);
            Directory.CreateDirectory(NewDirectory);
            CurrentDirectory = NewDirectory;
        }

        public static void SaveData(string CurrentPath, List<Computer> Computers)
        {
            using (StreamWriter sw = new StreamWriter(CurrentPath, true, Encoding.Default))
            {
                foreach (var computer in Computers)
                {
                    sw.WriteLine(computer.Cores + " " + computer.Frequency + " " + computer.Memory + " " + computer.Hdd);
                }
            }

            Console.WriteLine("Запись выполнена");
        }

        public static void ReadData(string CurrentPath)
        {
            using (StreamReader sr = new StreamReader(CurrentPath, Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        public static void WriteZip(string CurrentPath)
        {
            string outputArchive = @"C:\Users\Admin\Desktop\archive.zip";

            using (var outputStream = new FileStream(outputArchive, FileMode.Create, FileAccess.ReadWrite))
            {
                using (var archive = new ZipArchive(outputStream, ZipArchiveMode.Create, true, Encoding.UTF8))
                {
                    using (var entryStream = archive.CreateEntry(Path.GetFileName(CurrentPath)).Open())
                    {
                        using (var inputStream = new FileStream(CurrentPath, FileMode.Open, FileAccess.Read))
                        {
                            inputStream.CopyTo(entryStream);
                        }
                    }
                }
            }
        }

        public static void ReadZip()
        {
            string outputArchive = @"C:\Users\Admin\Desktop\archive.zip";
            string extractPath = @"C:\Users\Admin\Desktop";

            using (ZipArchive archive = ZipFile.OpenRead(outputArchive))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        string destinationPath = Path.GetFullPath(Path.Combine(extractPath, entry.FullName));

                        if (destinationPath.StartsWith(extractPath, StringComparison.Ordinal))
                        {
                            entry.ExtractToFile(destinationPath);
                            ReadData(extractPath + @"\" + entry.Name);
                        }
                    }
                }
            }
        }

        public static void WriteToMemory(MemoryStream stream, List<Computer> Computers)
        {
            using (stream = new MemoryStream())
            {
                var sw = new StreamWriter(stream);
                foreach (var computer in Computers)
                {
                    sw.WriteLine(computer.Cores + " " + computer.Frequency + " " + computer.Memory + " " + computer.Hdd);
                    sw.Flush();
                }
                stream.Position = 0;
                WriteToFileFromMemoryStream(stream);
            }
        }

        public static void WriteToFileFromMemoryStream(MemoryStream stream)
        {
            using (var streamReader = new StreamReader(stream))
            {
                Console.WriteLine("Чтение из потока:");

                using (StreamWriter sw = new StreamWriter(CurrentPath, true, Encoding.Default))
                {
                        sw.WriteLine(streamReader.ReadToEnd());
                }
            }
        }

        public static async void ReadAsync()
        {
            using (StreamReader sr = new StreamReader(CurrentPath))
            {
                Console.WriteLine(await sr.ReadToEndAsync());
                Console.WriteLine("*");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            InOutOperation.CurrentPath = @"C:\Users\Admin\Desktop\Пипка-1\File.txt";
            InOutOperation.CurrentDirectory = @"C:\Users\Admin\Desktop\Пипка-1";

            //SIMPLE TASKS

            var Computers = new List<Computer>()
            {
                new Computer { Cores  = 4, Frequency = 3.4, Memory = 8000, Hdd = 500000},
                new Computer { Cores  = 6, Frequency = 4.4, Memory = 16000, Hdd = 1000000},
                new Computer { Cores  = 8, Frequency = 5.4, Memory = 32000, Hdd = 2000000}
            };

            InOutOperation.SaveData(InOutOperation.CurrentPath, Computers);

            InOutOperation.ReadData(InOutOperation.CurrentPath);

            InOutOperation.WriteZip(InOutOperation.CurrentPath);

            InOutOperation.ReadZip();

            // ADVANCED TASKS

            var stream = new MemoryStream();

            var FileStream = new FileStream(InOutOperation.CurrentPath, FileMode.Open);
            FileStream = null;

            InOutOperation.WriteToMemory(stream, Computers);

            Console.ReadKey();
        }
    }
}
