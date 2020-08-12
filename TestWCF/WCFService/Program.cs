using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text.RegularExpressions;

namespace SelfHost
{
    [ServiceContract]
    public interface IHelloWorldService
    {
        [OperationContract]
        bool ValidateTheData(string login, string password);
    }

    public class HelloWorldService : IHelloWorldService
    {
        public bool ValidateTheData(string login, string password)
        {
            Regex rgLog = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Regex rgPass = new Regex(@"^(?=[a-z]*[0-9][a-z]*[0-9])^(?=[0-9]*[a-z][0-9]*[a-z])[a-z0-9]{4,}$");

            return rgLog.Match(login).Success && rgPass.Match(password).Success ? true : false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(HelloWorldService), new Uri("http://localhost:37964/TestService")))
            {
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior
                {
                    HttpGetEnabled = true
                };
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);

                try
                {
                    host.Open();

                    Console.WriteLine("Нажмите <Enter> чтобы закрыть сервис.");
                    Console.ReadLine();

                    host.Close();
                }
                catch
                {
                    Console.WriteLine("Ошибка при попытке открытия/закрытия хоста сервиса!");
                }
            }
        }
    }
}