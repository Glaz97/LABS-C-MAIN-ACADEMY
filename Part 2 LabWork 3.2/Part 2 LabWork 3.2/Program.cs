using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Part_2_LabWork_3._2
{
    public class Cll
    {
        [DllImport("kerne132", CharSet = CharSet.Auto)]

        public static extern int GetComputerName(string Buffer, ref int BufferLength);

        public static void GetCompName()
        {
            int bufferLength = 16;

            string comName = new string(' ', bufferLength);

            GetComputerName(comName, ref bufferLength);

            comName = comName.Trim();

            Console.WriteLine("Computer Name:");

            Console.WriteLine(" {2} ({1})", comName, bufferLength);
        }

        public static void GetKeyName()
        {
            Console.WriteLine("Read the registry keys");
            RegistryKey regk = Registry.CurrentConfig;
            string[] nm_strarr = regk.GetSubKeyNames();

            Console.WriteLine("Length of array: " +
            nm_strarr.Length.ToString());
        }

        void D11_in_SndBox()
        {
            GetKeyName();
        }

        public static void Type_Assemblies_info()

        {
            Console.WriteLine("***");

            AppDomain cur_appD = AppDomain.CurrentDomain;

            Console.WriteLine("MAIN domain info. IsFullTrusted: {@}",
           cur_appD.IsFullyTrusted);

            Assembly[] assems = cur_appD.GetAssemblies();
        }
    }

    class Program
    {
        //Сразу говорю, мне лень копировать эту дичЬ (смысл лабы в копировании кода не представляет интереса), так что приношу извинения за внешний вид кода
        static void Main(string[] args)
        {
            try
            {
                //Это гуано-функция не воспроизводит задуманного, ибо у меня нет указанной дллки на моей ЭВМ
                Cll.GetCompName();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Волшебный срамной уд знает где эта функция в примере и чё она должна вытворять, потому в  коммент
            //uint ver = GetVersion();
            //Console.WriteLine("Ver " + ver);

            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);

            string fp1 = @"d:\Test_dir1";
            string fp2 = @"d:\Test_dir2";
            string fn = @"d:\Test_file.txt";

            if (!Directory.Exists(fp1))
                Directory.CreateDirectory(fp1);

            if (!Directory.Exists(fp2))
                Directory.CreateDirectory(fp2);

            Console.WriteLine("2 directories were created");

            try
            {
                if (!File.Exists(fn)) using (FileStream fs =
                File.Create(fn)) { }

                Console.WriteLine("File was created");

                if (!Directory.Exists(fp1)) Directory.CreateDirectory(fp1);
                if (!Directory.Exists(fp2)) Directory.CreateDirectory(fp2);
                Console.WriteLine("2 Folders were created.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //В этом изумительном творении пьяного одноглазого программиста в след. строке кода был пропущен оператор ИФ
            if (Directory.Exists(fp1)) Directory.Delete(fp1);
            if (Directory.Exists(fp2)) Directory.Delete(fp2);
            if (File.Exists(fn)) File.Delete(fn);

            Assembly asm = Assembly.GetExecutingAssembly();

            Zone zn = asm.Evidence.GetHostEvidence<Zone>();
            Console.WriteLine("Zone Evidence: " + zn.SecurityZone.ToString());
            Console.WriteLine("\r\nIsFullyTrusted: {@}", asm.IsFullyTrusted);
            Console.ReadKey();

            Cll.GetKeyName();

            try
            {
                //Type_Assemblies_info();
                AppDomainSetup setup = new AppDomainSetup
                {
                    ApplicationBase =
                   Environment.CurrentDirectory
                };
                PermissionSet prmts = new PermissionSet(null);


                AppDomain appDomain = AppDomain.CreateDomain("SANDBOX domain", null, setup, prmts);

                Program p = (Program)Activator.CreateInstance(appDomain, "Step_5", "Step_5.Program").Unwrap();

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}

