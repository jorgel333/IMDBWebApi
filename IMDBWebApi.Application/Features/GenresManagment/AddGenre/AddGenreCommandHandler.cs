using FluentResults;
using IMDBWebApi.Application.Errors;
using IMDBWebApi.Domain.Entities;
using IMDBWebApi.Domain.Interfaces;
using IMDBWebApi.Domain.Interfaces.Repositories;
using MediatR;

namespace IMDBWebApi.Application.Features.GenresManagment.AddGenre;

public class AddGenreCommandHandler : IRequestHandler<AddGenreCommand, Result<AddGenreCommandResponse>>
{
    private readonly IGenreRepository _genreRepository;
    private readonly IUnityOfWork _unityOfWork;

    public AddGenreCommandHandler(IGenreRepository genreRepository, IUnityOfWork unityOfWork)
    {
        _genreRepository = genreRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<Result<AddGenreCommandResponse>> Handle(AddGenreCommand request, CancellationToken cancellationToken)
    {
        var isUniqueGenre = await _genreRepository.IsUniqueName(request.Name, cancellationToken);

        if (isUniqueGenre is false)
            return Result.Fail(new ApplicationError("Genre name is not unique"));

        var newGenre = new Genre(request.Name);
        _genreRepository.Create(newGenre);
        await _unityOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(new AddGenreCommandResponse(newGenre.Id));
    }
}
