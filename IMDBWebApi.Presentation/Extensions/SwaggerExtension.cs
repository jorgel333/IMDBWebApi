using Microsoft.OpenApi.Models;

namespace IMDBWebApi.Presentation.Extensions;

public static class SwaggerExtension
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "IMDBWebApi",
                Version = "v1",
                Contact = new OpenApiContact
                {
                    Name = "Jorge Leonardo",
                    Email = "exemplodeemail@mail.com"
                }
            });
            
            var xmlFile = "IMDBWebApi.Presentation.xml";
            var xmlPatch = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPatch);

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Informe seu Token."
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    }, new string []{}
                }
            });
        });

        return services;
    }
}

