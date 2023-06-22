using IMDBWebApi.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace IMDBWebApi.Infra.Database
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAdministratorRepository, IAdministratorRepository>();

            return services;
        }
    }
}
