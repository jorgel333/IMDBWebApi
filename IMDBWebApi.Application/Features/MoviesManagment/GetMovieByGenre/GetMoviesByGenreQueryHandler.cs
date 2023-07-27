using IMDBWebApi.Domain.Interfaces.Repositories;
using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.MoviesManagment.GetMovieByGenre;

public class GetMoviesByGenreQueryHandler : IRequestHandler<GetMoviesByGenreQuery, Result<IEnumerable<GetMoviesByGenreQueryResponse>>>
{
    private readonly IMovieRepository _movieRepository;

    public GetMoviesByGenreQueryHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<Result<IEnumerable<GetMoviesByGenreQueryResponse>>> Handle(GetMoviesByGenreQuery request, CancellationToken cancellationToken)
    {
        var movies = await _movieRepository.GetByGenre(request.GenreId, cancellationToken);

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
