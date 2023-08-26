using IMDBWebApi.Domain.Interfaces.Repositories;
using FluentResults;
using MediatR;
using IMDBWebApi.Application.Errors;

namespace IMDBWebApi.Application.Features.MoviesManagment.GetMovieByGenre;

public class GetMoviesByGenreQueryHandler : IRequestHandler<GetMoviesByGenreQuery, Result<IEnumerable<GetMoviesByGenreQueryResponse>>>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IGenreRepository _genreRepository;

    public GetMoviesByGenreQueryHandler(IMovieRepository movieRepository, IGenreRepository genreRepository)
    {
        _movieRepository = movieRepository;
        _genreRepository = genreRepository;
    }

    public async Task<Result<IEnumerable<GetMoviesByGenreQueryResponse>>> Handle(GetMoviesByGenreQuery request, CancellationToken cancellationToken)
    {
        var genreExists = _genreRepository.GetById(request.GenreId, cancellationToken);
        var movies = await _movieRepository.GetByGenre(request.GenreId, cancellationToken);

        if (genreExists is null)
            return Result.Fail(new ApplicationNotFoundError("Genre doesn't exist"));

        if(movies.Any() is false)
            return Result.Ok(Enumerable.Empty<GetMoviesByGenreQueryResponse>());

        var result = movies.Select(m => new GetMoviesByGenreQueryResponse(
                m.Id,
                m.Name!,
                m.RatingAverage,
                m.GenresMovies!.Select(g => g.Genre!.Name!).Take(3),
                m.ActorMovies!.Select(a => a.CastAct!.Name!).Take(3),
                m.DirectorMovies!.Select(d => d.CastDirector!.Name!).Take(1)));

        return Result.Ok(result);
    }
}
