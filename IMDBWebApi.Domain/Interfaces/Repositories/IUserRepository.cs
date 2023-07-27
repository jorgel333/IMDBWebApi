
using IMDBWebApi.Domain.Entities;

namespace IMDBWebApi.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        void Update(User user);
        void Create(User user);
        Task<IEnumerable<User>> GetAllDisable(CancellationToken ct);
        Task<IEnumerable<User>> GetAllActive(CancellationToken ct);
        Task<User?> GetByIdAsync(int id, CancellationToken ct);
        Task<User?> GetByEmail(string email, CancellationToken ct);
        Task<bool> IsUniqueEmail(string email, CancellationToken ct);
        Task<bool> IsUniqueUserName(string userName, CancellationToken ct);
    }
}
