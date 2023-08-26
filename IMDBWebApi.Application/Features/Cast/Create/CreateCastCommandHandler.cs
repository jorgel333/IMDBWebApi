using IMDBWebApi.Domain.Interfaces.Repositories;
using IMDBWebApi.Application.Errors;
using IMDBWebApi.Domain.Interfaces;
using FluentResults;
using MediatR;
using IMDBWebApi.Domain.Entities;

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

    public async Task<Result<CreateCastCommandResponse>> Handle(CreateCastCommand request, CancellationToken cancellationToken)
    {
        var uniqueCast = await _castRespository.IsUniqueName(request.Name, cancellationToken);

        if (uniqueCast is false)
            return Result.Fail(new ApplicationError("Artist name is not unique"));

        var newCast = new Casts(request.Name, request.Description, request.Birthday);
        _castRespository.AddCast(newCast);
        await _unityOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(new CreateCastCommandResponse(newCast.Id));
    }
}
