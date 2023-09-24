namespace IMDBWebApi.Application.Features.Users.GetCommonUsersActive;

public record GetCommonUsersActiveQueryResponse(int Id, string Name,
    string UserName, string Email);
