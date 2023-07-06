using IMDBWebApi.Domain.Entities;

namespace IMDBWebApi.Domain.Interfaces.Repositories
{
    public interface IAdministratorRepository
    {
        IQueryable<Admin> GetAllAdm();
        void Update(Admin admin);
        void CreateAdm(Admin admin);
        Task<Admin?> GetByIdAsync(int id, CancellationToken ct);
        Task<bool> IsUniqueEmail(string email, CancellationToken ct);
        Task<bool> IsUniqueUserName(string name, CancellationToken ct);

    }
}
