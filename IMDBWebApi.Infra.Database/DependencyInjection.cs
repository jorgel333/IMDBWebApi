using IMDBWebApi.Domain.Interfaces;
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
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IAssessmentRecordRepository, AssessmentRecordRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<ICastRepository, CastRepository>();
            return services;
        }

        public static IServiceCollection AddUnityOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            return services;
        }
    }
}
