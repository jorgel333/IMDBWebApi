using FluentResults;
using IMDBWebApi.Domain.Interfaces;
using IMDBWebApi.Domain.Interfaces.Repositories;
using MediatR;

namespace IMDBWebApi.Application.Features.Cast.Create;

public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand, Result<CreateCastCommandResponse>>
{
    private readonly ICastRepository _castRespository;
    private readonly IUnityOfWork _unityOfWork;

    public CreateCastCommandHandler(ICastRepository castRespository, IUnityOfWork unityOfWork)
    {
        _castRespository = castRespository;
        _unityOfWork = unityOfWork;
    }

    public Task<Result<CreateCastCommandResponse>> Handle(CreateCastCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
