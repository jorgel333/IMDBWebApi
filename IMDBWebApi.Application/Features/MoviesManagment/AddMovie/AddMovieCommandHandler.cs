using IMDBWebApi.Domain.Interfaces.Repositories;
using IMDBWebApi.Domain.Interfaces;
using IMDBWebApi.Domain.Entities;
using FluentResults;
using MediatR;

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
        if (await _movieRepository.IsUniqueName(request.Name, cancellationToken))
            return Result.Fail("Movie already registred.");

        if (await _genreRepository.IsAlreadyRegistred(request.Genres, cancellationToken) is false)
            return Result.Fail("Some genre is invalid.");

        if (await _castRepository.IsAlreadyRegistred(request.CastActor, cancellationToken) is false)
            return Result.Fail("Some actor doesn't exists.");

        var genresMovies = request.Genres.Select(genre => new GenreMovies { GenreId = genre });

        var actorMovies = request.CastActor.Select(cast => new CastActMovies { CastActId = cast });

        var directorMovies = request.CastActor.Select(cast => new CastDirectMovies { CastDirectorId = cast });

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
