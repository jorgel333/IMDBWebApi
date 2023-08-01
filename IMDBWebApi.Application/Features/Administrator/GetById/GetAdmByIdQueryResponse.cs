namespace IMDBWebApi.Application.Features.Administrator.GetById;

public record GetAdmByIdQueryResponse (int Id, string Name, string UserName, bool IsDeleted);    