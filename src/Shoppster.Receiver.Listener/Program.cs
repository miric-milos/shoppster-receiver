using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shoppster.Receiver.RabbitMQ.Ioc;
using Shoppster.Receiver.Services.Ioc;
using System;
using System.IO;

namespace Shoppster.Receiver.Listener
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var serviceProvider = new ServiceCollection()
                .AddSingleton(configuration)
                .AddRabbitMQ(configuration)
                .AddServices()
                .BuildServiceProvider();

            new ProductQueueListener(serviceProvider);

            Console.WriteLine($"[{DateTime.Now}] Receiver started");
            Console.ReadLine();
        }
    }
}
