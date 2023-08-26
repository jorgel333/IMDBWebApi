using IMDBWebApi.Domain.Interfaces.Repositories;
using IMDBWebApi.Domain.Interfaces;
using IMDBWebApi.Domain.Entities;
using FluentResults;
using MediatR;
using IMDBWebApi.Application.Errors;

namespace IMDBWebApi.Application.Features.MoviesManagment.AddMovie;

public class AddMovieCommandHandler : IRequestHandler<AddMovieCommand, Result<AddMovieCommandResponse>>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly ICastRepository _castRepository;
    private readonly IUnityOfWork _unityOfWork;

    public AddMovieCommandHandler(IMovieRepository movieRepository, IGenreRepository genreRepository, 
        ICastRepository castRepository, IUnityOfWork unityOfWork)
    {
        _movieRepository = movieRepository;
        _genreRepository = genreRepository;
        _castRepository = castRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<Result<AddMovieCommandResponse>> Handle(AddMovieCommand request, CancellationToken cancellationToken)
    {
        if (await _movieRepository.IsUniqueName(request.Name, cancellationToken) is false)
            return Result.Fail(new ApplicationError("Movie already registred."));

        if (await _genreRepository.IsAlreadyRegistred(request.Genres, cancellationToken) is false)
            return Result.Fail(new ApplicationError("Some genre is invalid."));

        if (await _castRepository.IsAlreadyRegistred(request.CastActor, cancellationToken) is false)
            return Result.Fail(new ApplicationError("Some actor doesn't exists."));

        if (await _castRepository.IsAlreadyRegistred(request.CastDirector, cancellationToken) is false)
            return Result.Fail(new ApplicationError("Some director doesn't exists."));

        var genresMovies = request.Genres.Select(genre => new GenreMovies { GenreId = genre }).ToList();

        var actorMovies = request.CastActor.Select(cast => new CastActMovies { CastActId = cast }).ToList();

        var directorMovies = request.CastDirector.Select(cast => new CastDirectMovies { CastDirectorId = cast }).ToList();

        var newMovie = new Movie(request.Name, request.Description,
            request.Duration, request.Image, request.RealiseDate)
        {
            DirectorMovies = directorMovies, 
            GenresMovies = genresMovies,
            ActorMovies = actorMovies
        };

        _movieRepository.Create(newMovie);
        await _unityOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Ok(new AddMovieCommandResponse(newMovie.Id));
    }
}
