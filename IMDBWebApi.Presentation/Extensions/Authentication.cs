using Microsoft.AspNetCore.Authentication.JwtBearer;
using IMDBWebApi.Application.Services.Token;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace IMDBWebApi.Presentation.Extensions
{
    public static class Authentication
    {
        public static IServiceCollection AddAuth(this IServiceCollection services)
        {
            var key = Encoding.UTF8.GetBytes("m430f8$dao9o12usako0dj4a103@sa4$sakf093na234vwz6sdf");
            services.Configure<TokenServiceOptions>(opt =>
            {
                opt.Key = key;
            });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }
    }
}
