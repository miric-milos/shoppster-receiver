using Microsoft.Extensions.DependencyInjection;
using Shoppster.Receiver.Services.Deserializer;

namespace Shoppster.Receiver.Services.Ioc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<IMessageDeserializer, MessageDeserializer>();
        }
    }
}