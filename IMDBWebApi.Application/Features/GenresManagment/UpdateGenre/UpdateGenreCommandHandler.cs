using IMDBWebApi.Domain.Interfaces.Repositories;
using IMDBWebApi.Domain.Interfaces;
using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.GenresManagment.UpdateGenre;

public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, Result>
{
    private readonly IGenreRepository _genreRepository;
    private readonly IUnityOfWork _unityOfWork;

    public UpdateGenreCommandHandler(IGenreRepository genreRepository, IUnityOfWork unityOfWork)
    {
        _genreRepository = genreRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<Result> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = await _genreRepository.GetById(request.GenreId, cancellationToken);
        var isUniqueName = await _genreRepository.IsUniqueName(request.Name, cancellationToken);

        if (genre is null)
            return Result.Fail("Genre not found");

        if (isUniqueName is false)
            return Result.Fail("Genre name is not unique");

        genre.Update(request.Name);
        _genreRepository.Update(genre);
        await _unityOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
