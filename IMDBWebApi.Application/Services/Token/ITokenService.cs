
using IMDBWebApi.Domain.Entities.Abstract;

namespace IMDBWebApi.Application.Services.Token;

public interface ITokenService
{
    string GenerateToken(Account account);
    string GenerateRefreshToken();
}
