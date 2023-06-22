using IMDBWebApi.Domain.Entities;
using IMDBWebApi.Domain.Interfaces.Repositories;
using IMDBWebApi.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace IMDBWebApi.Infra.Database.Repositories
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private readonly AppDbContext _context;
        public AdministratorRepository(AppDbContext context)
        {
            _context = context;
        }
        public void CreateAdm(Administrator admin)
            => _context.Administrators.Add(admin);

        public IQueryable<Administrator> GetAllAdm() 
            => _context.Administrators.AsNoTracking();

        public async Task<Administrator?> GetByIdAsync(int id, CancellationToken ct) 
            => await _context.Administrators.SingleOrDefaultAsync(adm => adm.Id == id, ct);

        public async Task<bool> IsUniqueEmail(string email, CancellationToken ct)
            => await _context.Administrators.AnyAsync(adm => adm.Email!.ToLower() == email.ToLower(), ct) is false;

        public async Task<bool> IsUniqueUserName(string userName, CancellationToken ct)
            => await _context.Administrators.AnyAsync(adm => adm.UserName!.ToLower() == userName.ToLower(), ct) is false;

        public void Update(Administrator admin)
            => _context.Administrators.Update(admin);
    }
}
