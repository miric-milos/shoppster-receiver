using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using Shoppster.Receiver.RabbitMQ.Options;

namespace Shoppster.Receiver.RabbitMQ.Ioc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            var model = new ConnectionFactory { HostName = configuration.GetSection($"{nameof(RabbitMQOptions)}:HostName").Value }
                .CreateConnection()
                .CreateModel();

            return services
                .Configure<RabbitMQOptions>(configuration.GetSection(nameof(RabbitMQOptions)))
                .AddSingleton<IRabbitMQOptions>(sp => sp.GetRequiredService<IOptions<RabbitMQOptions>>().Value)
                .AddSingleton(model);
        }
    }
}
