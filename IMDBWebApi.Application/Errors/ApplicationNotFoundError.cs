using FluentResults;

namespace IMDBWebApi.Application.Errors;

public class ApplicationNotFoundError : Error
{
    public ApplicationNotFoundError(string error) : base(error)
    {
    }
}
