using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMessagingBus(this IServiceCollection services)
    {

        return services;
    }

    private static void ConfigureBus(this IServiceCollection services)
    {
        var dictionary = new Dictionary<string, Func<IServiceCollection, IConfiguration, IServiceCollection>>
        {
            {Environments.Development,  ConfigureRabbitMQOverMassTransit.ConfigureBus}
        };
    }
}
