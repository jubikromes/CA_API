using Application.Interfaces.Repository;
using Application.Interfaces.Repository.Event;
using Infrastructure.Persistence;
using Infrastructure.Persistence.DbConfiguration;
using Infrastructure.Persistence.Repository.Event;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        var connectionString = configuration.GetConnectionString("ConfamAppDb");

        services.AddTransient<IEventRepository, EventRepository>();

        services.AddDbContext<ConfamAppDbContext>(options =>
        {

            options.UseSqlServer(connectionString, x => x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));

        });

        return services;
    }
}
