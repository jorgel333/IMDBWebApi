using FluentResults;

namespace IMDBWebApi.Application.Errors;

public class ApplicationError : Error
{
	public ApplicationError(string error) : base(error)
	{
	}
}
