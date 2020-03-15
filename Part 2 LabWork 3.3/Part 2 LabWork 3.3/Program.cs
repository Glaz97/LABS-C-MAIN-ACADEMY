using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Part_2_LabWork_3._3
{
    public class Crypto
    {
        private static RSAParameters publicKey;
        private static RSAParameters privateKey;

        public static void Crypting(string data)
        {
            byte[] encodedBytes;

            using (var md5 = new MD5CryptoServiceProvider())
            {
                var originalBytes = Encoding.Default.GetBytes(data);
                encodedBytes = md5.ComputeHash(originalBytes);
            }

            string FilePath = @"D:\C# Courses\Arrays\Part 2 LabWork 3.2\Password.txt";

            if (!Check(FilePath, Convert.ToBase64String(encodedBytes)))
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(FilePath, false, Encoding.Default))
                    {
                        sw.WriteLineAsync(Convert.ToBase64String(encodedBytes));
                    }
                    Console.WriteLine("Запись выполнена");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Ваша шифрованная строка - " + Convert.ToBase64String(encodedBytes));
            }
            else
            {
                Console.WriteLine("Данный пароль уже создан");
            }
        }

        public static bool Check(string filePath, string stringToCheckEqual)
        {
            bool answer = false;

            using (StreamReader sr = new StreamReader(filePath))
            {
                var test = sr.ReadToEnd();

                if ((stringToCheckEqual + "\r\n") == test)
                {
                    answer = true;
                }
            }

            return answer;
        }

        public static void AssignNewKey()
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                publicKey = rsa.ExportParameters(false);
                privateKey = rsa.ExportParameters(true);
            }
        }

        public static byte[] Signature(byte[] hashOfDataToSign)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(privateKey);

                var rsaFormatter = new RSAPKCS1SignatureFormatter(rsa);
                rsaFormatter.SetHashAlgorithm("SHA256");

                return rsaFormatter.CreateSignature(hashOfDataToSign);
            }
        }

        public static bool VerifySignature(byte[] hashOfDataToSign, byte[] signature)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.ImportParameters(publicKey);

                var rsaDeformatter = new RSAPKCS1SignatureDeformatter(rsa);
                rsaDeformatter.SetHashAlgorithm("SHA256");

                return rsaDeformatter.VerifySignature(hashOfDataToSign, signature);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your string:");
            Crypto.Crypting(Console.ReadLine());

            var document = Encoding.UTF8.GetBytes("Document to Sign");
            byte[] hashedDocument;

            using (var sha256 = SHA256.Create())
            {
                hashedDocument = sha256.ComputeHash(document);
            }

            Crypto.AssignNewKey();

            var signature = Crypto.Signature(hashedDocument);
            var verified = Crypto.VerifySignature(hashedDocument, signature);

            Console.WriteLine("Digital Signature Demonstration in .NET");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Original Text = " + Encoding.Default.GetString(document));
            Console.WriteLine("Digital Signature = " + Convert.ToBase64String(signature));


            if (verified)
            {
                Console.WriteLine("The digital signature has been correctly verified.");
            }
            else
            {
                Console.WriteLine("The digital signature has NOT been correctly verified.");
            }

            Console.ReadKey();
        }
    }
}
