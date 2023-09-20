using IMDBWebApi.Domain.Entities;
using IMDBWebApi.Domain.Interfaces.Repositories;
using IMDBWebApi.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading;

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

        public void Update(User user)
            => _context.CommonUsers.Update(user);

        public async Task<IEnumerable<User>> GetAllActive(CancellationToken cancellationToken)
            => await _context.CommonUsers.Where(user => user.IsDeleted == false).ToListAsync(cancellationToken);

        public async Task<IEnumerable<User>> GetAllDisable(CancellationToken cancellationToken)
            => await _context.CommonUsers.Where(user => user.IsDeleted == true).ToListAsync(cancellationToken);

        public async Task<User?> GetByEmail(string email, CancellationToken cancellationToken)
            => await _context.CommonUsers.SingleOrDefaultAsync(user => user.Email == email, cancellationToken);
        

        public async Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken)
            => await _context.CommonUsers.SingleOrDefaultAsync(user => user.Id == id, cancellationToken);

        public async Task<bool> IsUniqueEmail(string email, CancellationToken cancellationToken)
            => await _context.CommonUsers.AnyAsync(user => user.Email!.ToLower() == email.ToLower(), cancellationToken) is false;

        public async Task<bool> IsUniqueUserName(string userName, CancellationToken cancellationToken)
            => await _context.CommonUsers.AnyAsync(user => user.UserName!.ToLower() == userName.ToLower(), cancellationToken) is false;

    }
}
