using IMDBWebApi.Application;
using IMDBWebApi.Application.Services.Cryptography;
using IMDBWebApi.Infra.Database;
using IMDBWebApi.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IMDBWebApi.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraStructure(this IServiceCollection services, 
             IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DbConnection"),
            b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.AddRepositories();
            services.AddUnityOfWork();
            services.AddServices();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICryptography, Cryptography>();
            return services;
        }
    }
}
