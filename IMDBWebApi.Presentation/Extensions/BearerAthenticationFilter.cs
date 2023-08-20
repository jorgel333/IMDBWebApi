using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;

namespace IMDBWebApi.Presentation.Extensions;

public class BearerAthenticationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var allowAnonymous = context.ApiDescription.CustomAttributes().Any(atrib => atrib.GetType() == typeof(AllowAnonymousAttribute));
        var authorize = context.ApiDescription.CustomAttributes().Any(atrib => atrib.GetType() == typeof(AuthorizeAttribute));

        if (allowAnonymous || !authorize)
            return;

        operation.Security = new List<OpenApiSecurityRequirement>()
        {
            new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new List<string>()
                }
            }
        };
    }
}
        