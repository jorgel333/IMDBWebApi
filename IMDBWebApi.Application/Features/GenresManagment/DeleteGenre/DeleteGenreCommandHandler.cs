using FluentResults;
using IMDBWebApi.Domain.Interfaces;
using IMDBWebApi.Domain.Interfaces.Repositories;
using MediatR;

namespace IMDBWebApi.Application.Features.GenresManagment.DeleteGenre;

public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, Result>
{
    private readonly IGenreRepository _genreRepository;
    private readonly IUnityOfWork _unityOfWork;

    public DeleteGenreCommandHandler(IGenreRepository genreRepository, IUnityOfWork unityOfWork)
    {
        _genreRepository = genreRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<Result> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = await _genreRepository.GetById(request.GnereId, cancellationToken);

        if (genre is null)
            return Result.Fail("Genre not found.");

        _genreRepository.Delete(genre);
        await _unityOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
