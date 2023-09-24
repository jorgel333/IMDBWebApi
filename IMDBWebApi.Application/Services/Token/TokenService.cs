using IMDBWebApi.Domain.Entities.Abstract;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace IMDBWebApi.Application.Services.Token;

public class TokenService : ITokenService
{
    private readonly byte[] key;

    public TokenService(IOptions<TokenServiceOptions> options)
    {
        key = options.Value.Key;
        
    }
    public string GenerateToken(Account account)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, account.UserName!),
                new Claim(ClaimTypes.Role, account.GetType().Name.ToLower()),
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),  SecurityAlgorithms.HmacSha256)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    public string GenerateRefreshToken()
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature)
        };

        var refreshToken = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(refreshToken);
    }

}
