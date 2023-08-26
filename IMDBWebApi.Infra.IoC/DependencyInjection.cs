using IMDBWebApi.Application;
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
            b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
            .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

            services.AddRepositories();
            services.AddUnityOfWork();
            services.AddApplication();
            return services;
        }
    }
}
