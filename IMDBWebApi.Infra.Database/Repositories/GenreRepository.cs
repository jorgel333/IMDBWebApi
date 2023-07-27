using IMDBWebApi.Domain.Entities;
using IMDBWebApi.Domain.Interfaces.Repositories;
using IMDBWebApi.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace IMDBWebApi.Infra.Database.Repositories
{
    
    public class GenreRepository : IGenreRepository
    {
        private readonly AppDbContext _context;
        public GenreRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Create(Genre genre)
            => _context.Genres.Add(genre);

        public void Update(Genre genre)
            => _context.Genres.Update(genre);
        public void Delete(Genre genre)
            => _context.Genres.Remove(genre);

        public async Task<IEnumerable<Genre>> GetAll(CancellationToken cancellationToken)
            => await _context.Genres.OrderBy(g => g.Name).ToListAsync(cancellationToken);

        public Task<Genre?> GetById(int id, CancellationToken cancellationToken)
            => _context.Genres.SingleOrDefaultAsync(g => g.Id == id, cancellationToken);

        public async Task<bool> IsAlreadyRegistred(IEnumerable<int> genresId, CancellationToken cancellationToken)
        {
            var existingGenresIds = await _context.Genres.Select(c => c.Id).ToListAsync(cancellationToken);
            return genresId.ToHashSet().IsSubsetOf(existingGenresIds);
        }

        public async Task<bool> IsUniqueName(string genreName, CancellationToken cancellatioToken)
            => await _context.Genres.AnyAsync(g => g.Name!.ToLower() == genreName.ToLower(), cancellatioToken) is false;
    }
}
