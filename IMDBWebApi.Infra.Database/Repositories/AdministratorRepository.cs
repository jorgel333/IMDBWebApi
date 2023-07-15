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

        public async Task<Admin?> GetByEmailAsync(string email, CancellationToken cancellatioToken) 
            => await _context.Administrators.SingleOrDefaultAsync(adm => adm.Email!.ToLower() == email.ToLower(), cancellatioToken);

        public async Task<Admin?> GetByIdAsync(int id, CancellationToken cancellatioToken) 
            => await _context.Administrators.SingleOrDefaultAsync(adm => adm.Id == id, cancellatioToken);

        public async Task<bool> IsUniqueEmail(string email, CancellationToken cancellatioToken)
            => await _context.Administrators.AnyAsync(adm => adm.Email!.ToLower() == email.ToLower(),
                cancellatioToken) is false;

        public async Task<bool> IsUniqueUserName(string userName, CancellationToken cancellatioToken)
            => await _context.Administrators.AnyAsync(adm => adm.UserName!.ToLower() == userName.ToLower(),
                cancellatioToken) is false;

        public void Update(Admin admin)
            => _context.Administrators.Update(admin);
    }
}
