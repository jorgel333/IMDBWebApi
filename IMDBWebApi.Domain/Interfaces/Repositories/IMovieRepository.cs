using IMDBWebApi.Domain.Entities;

namespace IMDBWebApi.Domain.Interfaces.Repositories
{
    public interface IMovieRepository
    {
        Task <IEnumerable<Movie>> GetAll(CancellationToken ct);
        Task<IEnumerable<Movie>> GetTop250(CancellationToken ct);
        Task<IEnumerable<Movie>> GetByGenre(string genre, CancellationToken ct);
        Task<Movie?> GetById(int id, CancellationToken ct);
        void Create(Movie movie);
        void Delete(Movie movie);
        void Update(Movie movie);
        
    }
}
