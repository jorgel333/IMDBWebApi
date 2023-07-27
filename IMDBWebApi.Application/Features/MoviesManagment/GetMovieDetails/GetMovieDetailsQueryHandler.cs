using IMDBWebApi.Domain.Interfaces.Repositories;
using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.MoviesManagment.GetMovieDetails;

public class GetMovieDetailsQueryHandler : IRequestHandler<GetMovieDetailsQuery, Result<GetMovieDetailsQueryResponse>>
{
    private readonly IMovieRepository _movieRepository;

    public GetMovieDetailsQueryHandler(IMovieRepository repository)
    {
        _movieRepository = repository;
    }

    public async Task<Result<GetMovieDetailsQueryResponse>> Handle(GetMovieDetailsQuery request, CancellationToken cancellationToken)
    {
        var movie = await _movieRepository.GetDetailsById(request.MovieId, cancellationToken);

        if (movie is null)
            return Result.Fail("Movie not found.");

        var result = new GetMovieDetailsQueryResponse(
            movie.Id, 
            movie.Name!,
            movie.Description!,
            movie.Duration,
            movie.TotalVotes,
            movie.RatingAverage,
            movie.Image!,
            movie.ActorMovies!.Select(a => a.CastAct!.Name!),
            movie.DirectorMovies!.Select(d => d.CastDirector!.Name!),
            movie.GenresMovies!.Select(g => g.Genre!.Name!));

        return Result.Ok(result);
    }
}
