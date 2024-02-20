using EasyCaching.Core;
using Identity.Data;
using Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OpenIddictSetUp.Contract.Abstraction;
using OpenIddictSetUp.Contract.Implementation;
using OpenIddictSetUp.Entities;
using Shared.Handlers;
using System.Reflection;

namespace Identity;

public static partial class Startup
{


    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        //AddSwagger(builder.Services);

        builder.Services.AddControllersWithViews();

        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddProblemDetails();

        var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
        var connectionString = builder.Configuration.GetConnectionString("ConfamAppIdentityDb");

        builder.Services.AddDbContext<ConfamAppIdentityDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("ConfamAppIdentityDb"));
            //options.UseOpenIddict<Guid>();
            options.UseOpenIddict<OpenIddictApplication, OpenIddictAuthorization, OpenIddictScope, OpenIddictToken, Guid>();

        });
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
        });

        builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<ConfamAppIdentityDbContext>()
            .AddDefaultTokenProviders();


        builder.Services.AddEasyCaching(options =>
        {
            //use memory cache

            //options.WithSystemTextJson();
            options.UseInMemory(builder.Configuration, "default", "easycaching:inmemory");
        });

        builder.Services.AddTransient<IMemoryCacheService, MemoryCacheService>();
        builder.Services.AddTransient(typeof(TimeSpan), _ => TimeSpan.FromSeconds(1D));

        builder.Services.AddSingleton<IMemoryCacheService>(provider =>
        {
            return new MemoryCacheService(provider.GetRequiredService<IEasyCachingProvider>(),
                TimeSpan.FromDays(1));
        });

        //configure Auth

    }
    //private void AddSwagger(IServiceCollection services)
    //{
    //    services.AddSwaggerGen(c =>
    //    {
    //        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = $"PWE Autcomplete Engine", Version = "v1" });
    //        //c.IncludeXmlComments(Path.ChangeExtension(Assembly.GetEntryAssembly().Location, "xml"));

    //        c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    //        {
    //            In = Microsoft.OpenApi.Models.ParameterLocation.Header,
    //            Description = "Authorization format : Bearer {token}",
    //            Name = "Authorization",
    //            Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
    //            Scheme = "Bearer"
    //        });

    //        c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement() {
    //        {
    //            new OpenApiSecurityScheme
    //            {
    //                Reference = new OpenApiReference
    //                {
    //                    Type = ReferenceType.SecurityScheme,
    //                    Id = "Bearer"
    //                },
    //                Scheme = "Bearer",
    //                Name = "Bearer",
    //                In = ParameterLocation.Header,

    //            },
    //            new List<string>()
    //        }
    //    });
    //    });
    //}
}
