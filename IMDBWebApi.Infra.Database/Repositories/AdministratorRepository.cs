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
        public void CreateAdm(Admin admin)
            => _context.Administrators.Add(admin);

        public IQueryable<Admin> GetAllAdm() 
            => _context.Administrators.AsNoTracking();

        public async Task<Admin?> GetByIdAsync(int id, CancellationToken ct) 
            => await _context.Administrators.SingleOrDefaultAsync(adm => adm.Id == id, ct);

        public async Task<bool> IsUniqueEmail(string email, CancellationToken ct)
            => await _context.Administrators.AnyAsync(adm => adm.Email!.ToLower() == email.ToLower(), ct);

        public async Task<bool> IsUniqueUserName(string userName, CancellationToken ct)
            => await _context.Administrators.AnyAsync(adm => adm.UserName!.ToLower() == userName.ToLower(), ct);

        public void Update(Admin admin)
            => _context.Administrators.Update(admin);
    }
}
