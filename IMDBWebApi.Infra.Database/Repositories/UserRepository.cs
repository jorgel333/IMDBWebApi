using IMDBWebApi.Domain.Entities;
using IMDBWebApi.Domain.Interfaces.Repositories;
using IMDBWebApi.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace IMDBWebApi.Infra.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(User user) 
            => _context.CommonUsers.Add(user);


        public async Task<IEnumerable<User>> GetAllActive(CancellationToken ct)
            => await _context.CommonUsers.Where(user => user.IsDeleted == false).ToListAsync(ct);

        public async Task<IEnumerable<User>> GetAllDisable(CancellationToken ct)
            => await _context.CommonUsers.Where(user => user.IsDeleted == true).ToListAsync(ct);

        public async Task<User?> GetByEmail(string email, CancellationToken ct)
            => await _context.CommonUsers.SingleOrDefaultAsync(user => user.Email == email, ct);
        

        public async Task<User?> GetByIdAsync(int id, CancellationToken ct)
            => await _context.CommonUsers.SingleOrDefaultAsync(user => user.Id == id, ct);

        public async Task<bool> IsUniqueEmail(string email, CancellationToken ct)
            => await _context.CommonUsers.AnyAsync(user => user.Email!.ToLower() == email.ToLower(), ct) is false;

        public async Task<bool> IsUniqueUserName(string userName, CancellationToken ct)
            => await _context.CommonUsers.AnyAsync(user => user.UserName!.ToLower() == userName.ToLower(), ct) is false;

        public void Update(User user)
            => _context.CommonUsers.Update(user);
    }
}
