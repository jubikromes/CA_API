using Infrastructure;
using Application;
using Application.Extensions;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {   
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            //if (env == "local" || env == "Development")
            services.AddSwagger();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")
            .AddOpenIdConnect("oidc", options =>
            {
                options.Authority = "http://localhost:5017";

                options.ClientId = "mvc";
                options.ClientSecret = "secret";
                options.ResponseType = "code";

                options.SaveTokens = true;
            });
            services.ConfigureApplication();
            services.ConfigureInfrastructure(Configuration);

            services.AddControllers();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var environmentName = env.EnvironmentName;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler();

            if (environmentName == "local" || environmentName == "Development")
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Equity Bank Bank Transfer API v1");
                    c.RoutePrefix = string.Empty;
                });
                // making sure command keys are correct in build time

                app.UseHttpsRedirection();
                app.UseCors(x => x
                 .SetIsOriginAllowed(origin => true)
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .AllowCredentials());

                app.UseRouting();
              

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapDefaultControllerRoute()
                        .RequireAuthorization();
                    //endpoints.MapControllers();
                });
            }
        }

    }
}
