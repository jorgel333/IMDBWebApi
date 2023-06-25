using IMDBWebApi.Domain.Entities;
using IMDBWebApi.Domain.Interfaces.Repositories;
using IMDBWebApi.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

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

        public Task<IEnumerable<Movie>> GetAll(CancellationToken ct)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Movie>> GetByGenre(string genre, CancellationToken ct)
            => await _context.Movies.Join(_context.GenreMovies,
            movie => movie.Id, genreMovie => genreMovie.MovieId,
            (movie, genreMovie) => new { Movie = movie, GenreMovie = genreMovie })
            .Where(x => x.GenreMovie.Genre!.Name!.ToLower() == genre.ToLower())
            .Select(x => x.Movie).ToListAsync(ct);

        public async Task<Movie?> GetById(int id, CancellationToken ct)
            => await _context.Movies.SingleOrDefaultAsync(m => m.Id == id, ct);

        public async Task<IEnumerable<Movie>> GetTop250(CancellationToken ct)
            => await _context.Movies.OrderByDescending(mv => mv.RatingAverage)
                              .ThenByDescending(mv => mv.TotalVotes)
                              .Take(250).ToListAsync(ct);

        public void Update(Movie movie)
            => _context.Movies.Update(movie);
    }
}
