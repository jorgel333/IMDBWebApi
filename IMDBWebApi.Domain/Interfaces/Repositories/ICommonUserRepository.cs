﻿
using IMDBWebApi.Domain.Entities;

namespace IMDBWebApi.Domain.Interfaces.Repositories
{
    public interface ICommonUserRepository
    {
        void Update(CommonUser user);
        void Create(CommonUser user);
        Task<IEnumerable<CommonUser>> GetAllDisable(CancellationToken ct);
        Task<IEnumerable<CommonUser>> GetAllActive(CancellationToken ct);
        Task<CommonUser?> GetByIdAsync(int id, CancellationToken ct);
        Task<bool> IsUniqueEmail(string email, CancellationToken ct);
        Task<bool> IsUniqueUserName(string userName, CancellationToken ct);
    }
}
