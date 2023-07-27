using IMDBWebApi.Application.Services.Cryptography;
using Microsoft.Extensions.DependencyInjection;
using IMDBWebApi.Application.Services.Token;
using IMDBWebApi.Application.Behaviours;
using MediatR;
using FluentValidation;
using IMDBWebApi.Application.Features.Administrator.Account.Create;

namespace IMDBWebApi.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining(typeof(CreateAccountAdmCommandValidation));
        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationHandlingBehaviour<,>));
        
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ICryptography, Cryptography>();

        return services;
    }

    
}
