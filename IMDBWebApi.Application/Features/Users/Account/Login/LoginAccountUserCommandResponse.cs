namespace IMDBWebApi.Application.Features.Users.Account.Login;

public record LoginAccountUserCommandResponse (string Token, string RefreshToken);