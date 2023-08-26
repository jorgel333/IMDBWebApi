using IMDBWebApi.Domain.Entities;
using IMDBWebApi.Domain.Interfaces.Repositories;
using IMDBWebApi.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace IMDBWebApi.Infra.Database.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;
        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Movie movie)
            => _context.Movies.Add(movie);

        public void Delete(Movie movie)
            => _context.Movies.Remove(movie);

        public void Update(Movie movie)
            => _context.Movies.Update(movie);

        public async Task<IEnumerable<Movie>> GetNextReleases(CancellationToken cancellationToken)
            => await _context.Movies.Where(mv => mv.ReleaseDate > DateTime.Today)
            .Include(g => g.GenresMovies!).ThenInclude(g => g.Genre)
            .Include(a => a.ActorMovies!).ThenInclude(a => a.CastAct)
            .Include(d => d.DirectorMovies!).ThenInclude(d => d.CastDirector)
            .ToListAsync(cancellationToken);

        public IEnumerable<Movie> GetAllFilter(string? name, IEnumerable<int?> actorCast, IEnumerable<int?> directorCast)
        {
            var filters = new List<Func<Movie, bool>>();

            var movies = _context.Movies
                .Include(g => g.GenresMovies!).ThenInclude(g => g.Genre)
                .Include(a => a.ActorMovies!).ThenInclude(a => a.CastAct)
                .Include(d => d.DirectorMovies!).ThenInclude(d => d.CastDirector);

            if (string.IsNullOrWhiteSpace(name) is false)
                filters.Add(m => m.Name!.ToUpper().StartsWith(name.ToUpper()));

            if (actorCast is not null)
                filters.Add(m => m.ActorMovies!.Any(act => actorCast.Contains(act.MovieActId)));

            if (directorCast is not null)
                filters.Add(m => m.DirectorMovies!.Any(dir => directorCast.Contains(dir.MovieDirectId)));

            var filterMovies = filters.Aggregate(movies as IEnumerable<Movie>, (seed, filters) => seed.Where(filters));

            return filterMovies;
        }

        public async Task<Movie?> GetDetailsById(int id, CancellationToken cancellationToken)
            => await _context.Movies.Include(x => x.GenresMovies!).ThenInclude(g => g.Genre!)
            .Include(x => x.ActorMovies!).ThenInclude(a => a.CastAct!)
            .Include(x => x.DirectorMovies!).ThenInclude(d => d.CastDirector!).AsSplitQuery()
            .SingleOrDefaultAsync(m => m.Id == id, cancellationToken);

        public async Task<Movie?> GetById(int id, CancellationToken cancellationToken)
            => await _context.Movies.Include(x => x.GenresMovies).SingleOrDefaultAsync(m => m.Id == id, cancellationToken);

        public async Task<IEnumerable<Movie>> GetTop250(CancellationToken cancellationToken)
             => await _context.Movies
            .Include(g => g.GenresMovies!).ThenInclude(g => g.Genre)
            .Include(a => a.ActorMovies!).ThenInclude(a => a.CastAct)
            .Include(d => d.DirectorMovies!).ThenInclude(d => d.CastDirector)
            .OrderByDescending(mv => mv.RatingAverage).ThenByDescending(mv => mv.TotalVotes)
            .Take(250).ToListAsync(cancellationToken);

        public async Task<IEnumerable<Movie>> GetByGenre(int genreId, CancellationToken cancellationToken)
            => await _context.Movies.Where(g => g.GenresMovies!.Any(g => g.GenreId == genreId))
            .ToListAsync(cancellationToken);
        
        public async Task<bool> IsUniqueName(string name, CancellationToken cancellatioToken)
            => await _context.Movies.AnyAsync(adm => adm.Name!.ToLower() == name.ToLower(), cancellatioToken) is false;
    }
}
