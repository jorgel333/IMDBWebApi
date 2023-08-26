using IMDBWebApi.Domain.Interfaces.Repositories;
using IMDBWebApi.Domain.Interfaces;
using IMDBWebApi.Domain.Entities;
using FluentResults;
using MediatR;
using IMDBWebApi.Application.Errors;

namespace IMDBWebApi.Application.Features.MoviesManagment.UpdateMovie.UpdateRegistrationDataMovie;

public class UpdateRegistrationDataMovieCommandHandler : IRequestHandler<UpdateRegistrationDataMovieCommand, Result>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IUnityOfWork _unityOfWork;

    public UpdateRegistrationDataMovieCommandHandler(IMovieRepository movieRepository, IUnityOfWork unityOfWork)
    {
        _movieRepository = movieRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<Result> Handle(UpdateRegistrationDataMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _movieRepository.GetById(request.MovieId, cancellationToken);

        if (movie is null)
            return Result.Fail(new ApplicationNotFoundError("Movie not found."));

        if (await _movieRepository.IsUniqueName(request.Name, cancellationToken) is false)
            return Result.Fail(new ApplicationError("Name is not unique"));

        var genresMovies = request.Genres.Select(genre => new GenreMovies { GenreId = genre }).ToList();

        var actorMovies = request.CastActors.Select(cast => new CastActMovies { CastActId = cast }).ToList();

        var directorMovies = request.CastDirectors.Select(cast => new CastDirectMovies { CastDirectorId = cast }).ToList();

        movie.Update(request.Name, request.Description, request.Duration, request.ReleaseDate,
            genresMovies, actorMovies, directorMovies);

        _movieRepository.Update(movie);
        await _unityOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
