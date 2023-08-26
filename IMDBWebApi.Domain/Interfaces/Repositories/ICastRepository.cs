
using IMDBWebApi.Domain.Entities;

namespace IMDBWebApi.Domain.Interfaces.Repositories
{
    public interface ICastRepository
    {
        void AddCast(Casts cast);
        Task<bool> IsAlreadyRegistred(IEnumerable<int> castsId, CancellationToken cancellationToken);
        Task<bool> IsUniqueName(string name, CancellationToken cancellatioToken);
    }
}
