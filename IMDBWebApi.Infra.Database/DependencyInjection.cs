using IMDBWebApi.Domain.Interfaces.Repositories;
using IMDBWebApi.Infra.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace IMDBWebApi.Infra.Database
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAdministratorRepository, AdministratorRepository>();
            services.AddScoped<ICommonUserRepository, CommonUserRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IAssessmentRecordRepository, AssessmentRecordRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<ICastRepository, CastRepository>();
            return services;
        }
    }
}
