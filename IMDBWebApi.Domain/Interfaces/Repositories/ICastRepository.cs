
namespace IMDBWebApi.Domain.Interfaces.Repositories
{
    public interface ICastRepository
    {
        Task<bool> IsAlreadyRegistred(IEnumerable<int> castsId, CancellationToken cancellationToken);
    }
}
