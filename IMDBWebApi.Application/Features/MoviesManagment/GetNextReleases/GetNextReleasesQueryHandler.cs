using IMDBWebApi.Domain.Interfaces.Repositories;
using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.MoviesManagment.GetNextReleases
{
    public class GetNextReleasesQueryHandler : IRequestHandler<GetNextReleasesQuery, Result<IEnumerable<IGrouping<DateTime, GetNextReleasesQueryResponse>>>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetNextReleasesQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Result<IEnumerable<IGrouping<DateTime, GetNextReleasesQueryResponse>>>> Handle(GetNextReleasesQuery request, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetNextReleases(cancellationToken);

            if (movies.Any() is false)
                return Result.Ok(Enumerable.Empty<IGrouping<DateTime, GetNextReleasesQueryResponse>>());

            var result = movies.Select(m => new GetNextReleasesQueryResponse(
                m.Id,
                m.Name!,
                m.RatingAverage,
                m.ReleaseDate,
                m.GenresMovies!.Select(g => g.Genre!.Name!).Take(3),
                m.ActorMovies!.Select(a => a.CastAct!.Name!).Take(3),
                m.DirectorMovies!.Select(d => d.CastDirector!.Name!).Take(1))
                ).GroupBy(n => n.ReleaseDate);

            return Result.Ok(result);
        }
    }
}
