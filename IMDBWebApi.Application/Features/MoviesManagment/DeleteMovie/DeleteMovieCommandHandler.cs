using FluentResults;
using IMDBWebApi.Domain.Interfaces;
using IMDBWebApi.Domain.Interfaces.Repositories;
using MediatR;

namespace IMDBWebApi.Application.Features.MoviesManagment.DeleteMovie;

public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, Result>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IUnityOfWork _unityOfWork;

    public DeleteMovieCommandHandler(IMovieRepository movieRepository, IUnityOfWork unityOfWork)
    {
        _movieRepository = movieRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<Result> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _movieRepository.GetById(request.Id, cancellationToken);

        if (movie is null)
            return Result.Fail("Movie not found.");

        _movieRepository.Delete(movie);
        await _unityOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
