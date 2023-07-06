using IMDBWebApi.Application.UserInfo;
using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Behaviours;

public class SetUserInfoBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TResponse : ResultBase, new()
    where TRequest : IRequest<TResponse>, IUserId
{
    private readonly IUserInfo _userInfo;
    public SetUserInfoBehaviour(IUserInfo userInfo)
    {
        _userInfo = userInfo;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        request.UserId = _userInfo.Id;

        return await next();
    }
}
