using IMDBWebApi.Application.Extension;
using Microsoft.Extensions.Logging;
using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Behaviours;

public class ErrorHandlingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TResponse : ResultBase, new()
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<ErrorHandlingBehaviour<TRequest, TResponse>> _logger;

    public ErrorHandlingBehaviour(ILogger<ErrorHandlingBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }

        catch(Exception ex)
        {
            _logger.LogError(ex, "Unknow Error");
            return Result.Fail(new Error("Unknow Error")).To<TResponse>();
        }
    }
}
