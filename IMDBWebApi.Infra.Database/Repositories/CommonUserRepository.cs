using IMDBWebApi.Domain.Entities;
using IMDBWebApi.Domain.Interfaces.Repositories;
using IMDBWebApi.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace IMDBWebApi.Infra.Database.Repositories
{
    public class CommonUserRepository : ICommonUserRepository
    {
        private readonly AppDbContext _context;
        public CommonUserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(CommonUser user) 
            => _context.CommonUsers.Add(user);

        //public async Task<IEnumerable<Movie>> NextReleases()
        //    => await _context.Movies.Where(mv => mv.ReleaseDate > DateTime.Today)
        //    .GroupBy(mv => mv.ReleaseDate)
        //    .SelectMany(group => new { RealeseDate = group.Key, Movies = group.ToList()});

        public async Task<IEnumerable<CommonUser>> GetAllActive(CancellationToken ct)
            => await _context.CommonUsers.Where(user => user.IsDeleted == false).ToListAsync(ct);

        public async Task<IEnumerable<CommonUser>> GetAllDisable(CancellationToken ct)
            => await _context.CommonUsers.Where(user => user.IsDeleted == true).ToListAsync(ct);
        

        public async Task<CommonUser?> GetByIdAsync(int id, CancellationToken ct)
            => await _context.CommonUsers.SingleOrDefaultAsync(user => user.Id == id, ct);

        public async Task<bool> IsUniqueEmail(string email, CancellationToken ct)
            => await _context.CommonUsers.AnyAsync(user => user.Email!.ToLower() == email.ToLower(), ct) is false;

        public async Task<bool> IsUniqueUserName(string userName, CancellationToken ct)
            => await _context.CommonUsers.AnyAsync(user => user.UserName!.ToLower() == userName.ToLower(), ct) is false;

        public void Update(CommonUser user)
            => _context.CommonUsers.Update(user);
    }
}
