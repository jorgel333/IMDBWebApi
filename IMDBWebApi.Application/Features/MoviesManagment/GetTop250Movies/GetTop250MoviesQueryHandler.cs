using FluentResults;
using IMDBWebApi.Application.Features.MoviesManagment.GetMovieByGenre;
using IMDBWebApi.Domain.Interfaces.Repositories;
using MediatR;

namespace IMDBWebApi.Application.Features.MoviesManagment.GetTop250Movies;

public class GetTop250MoviesQueryHandler : IRequestHandler<GetTop250MoviesQuery, Result<IEnumerable<GetTop205MoviesQueryResponse>>>
{
    private readonly IMovieRepository _movieRepository;
    public GetTop250MoviesQueryHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<Result<IEnumerable<GetTop205MoviesQueryResponse>>> Handle(GetTop250MoviesQuery request, CancellationToken cancellationToken)
    {
        var movies = await _movieRepository.GetTop250(cancellationToken);

        if (movies.Any() is false)
            return Result.Ok(Enumerable.Empty<GetTop205MoviesQueryResponse>());

        var result = movies.Select(m => new GetTop205MoviesQueryResponse(
                m.Id,
                m.Name!,
                m.RatingAverage,
                m.GenresMovies!.Select(g => g.Genre!.Name!).Take(3),
                m.ActorMovies!.Select(a => a.CastAct!.Name!).Take(3),
                m.DirectorMovies!.Select(d => d.CastDirector!.Name!).Take(1)));

        return Result.Ok(result);
    }
}
