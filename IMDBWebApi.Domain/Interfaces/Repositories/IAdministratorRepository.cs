using IMDBWebApi.Domain.Entities;

namespace IMDBWebApi.Domain.Interfaces.Repositories
{
    public interface IAdministratorRepository
    {
        IQueryable<Administrator> GetAllAdm();
        void Update(Administrator admin);
        void CreateAdm(Administrator admin);
        Task<Administrator?> GetByIdAsync(int id, CancellationToken ct);
        Task<bool> IsUniqueEmail(string email, CancellationToken ct);
        Task<bool> IsUniqueUserName(string name, CancellationToken ct);

    }
}
