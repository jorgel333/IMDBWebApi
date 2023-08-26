using IMDBWebApi.Domain.Entities;
using IMDBWebApi.Domain.Interfaces.Repositories;
using IMDBWebApi.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace IMDBWebApi.Infra.Database.Repositories
{
    public class CastRepository : ICastRepository
    {
        private readonly AppDbContext _context;

        public CastRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddCast(Casts cast)
        {
            _context.Add(cast);
        }

        public async Task<bool> IsAlreadyRegistred(IEnumerable<int> castsId, CancellationToken cancellationToken)
        {
            var existingCastIds = await _context.Casts.Select(c => c.Id).ToListAsync(cancellationToken);
            return castsId.ToHashSet().IsSubsetOf(existingCastIds);
        }
        public async Task<bool> IsUniqueName(string name, CancellationToken cancellatioToken)
            => await _context.Casts.AnyAsync(adm => adm.Name!.ToLower() == name.ToLower(),
                cancellatioToken) is false;
    }
}
