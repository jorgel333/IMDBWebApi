﻿using Microsoft.Extensions.DependencyInjection;
using IMDBWebApi.Application.Behaviours;
using MediatR;

namespace IMDBWebApi.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(SetUserInfoBehaviour<,>));
        return services;
    }
}
