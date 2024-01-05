using Application.Messaging.Consumers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

internal static class ConfigureRabbitMQOverMassTransit
{
    internal static IServiceCollection ConfigureBus(this IServiceCollection services, IConfiguration config)
    {
        var username = config["RabbitMQ:Username"];
        var password = config["RabbitMQ:Password"];
        var url = config["RabbitMQ:Url"];

        services.AddMassTransit(x =>
        {
            x.AddConsumer<AddEventConsumer>();


            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost", "/", h =>
                {
                    h.Username(username);
                    h.Password(password);
                });

                cfg.ReceiveEndpoint("", e =>
                {

                });
            });
        });

       

        return services;

    }
}
