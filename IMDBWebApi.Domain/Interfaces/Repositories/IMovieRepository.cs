using IMDBWebApi.Domain.Entities;

namespace IMDBWebApi.Domain.Interfaces.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetTop250(CancellationToken cancellationToken);
        Task<IEnumerable<Movie>> GetByGenre(int genreId, CancellationToken cancellationToken);
        Task<IEnumerable<Movie>> GetNextReleases(CancellationToken cancellationToken);
        Task<bool> IsUniqueName(string name, CancellationToken cancellatioToken);
        Task<Movie?> GetByIdIncludeAssessment(int id, CancellationToken cancellationToken);
        Task<Movie?> GetDetailsById(int id, CancellationToken cancellationToken);
        Task<Movie?> GetById(int id, CancellationToken cancellationToken);
        void Create(Movie movie);
        void Delete(Movie movie);
        void Update(Movie movie);
        
    }
}
