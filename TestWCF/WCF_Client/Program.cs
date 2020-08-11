using System;
using System.ServiceModel;

namespace WCF_Client
{
    [ServiceContract]
    public interface IHelloWorldService
    {
        [OperationContract]
        bool ValidateTheData(string login, string password);
    }

    class Program
    {
        static void Main(string[] args)
        {
            EndpointAddress address = new EndpointAddress(new Uri("http://localhost:37964/TestService"));
            BasicHttpBinding binding = new BasicHttpBinding();

            ChannelFactory<IHelloWorldService> factory = new ChannelFactory<IHelloWorldService>(binding, address);

            IHelloWorldService service = factory.CreateChannel();

            var userUnautorized = true;

            do
            {
                Console.WriteLine("Введите Логин");
                var checkLogin = Console.ReadLine();
                Console.WriteLine("Введите Пароль");
                var checkPassword = Console.ReadLine();

                try
                {
                    if (service.ValidateTheData(checkLogin, checkPassword))
                    {
                        Console.WriteLine("Вы успешно авторизованы!");
                        userUnautorized = false;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода данных, повторите ввод!");
                    }
                }
                catch
                {
                    Console.WriteLine("Ошибка при попытке валидации данных для авторизации!");
                }
            }
            while (userUnautorized);
            Console.ReadLine();
        }
    }
}
