﻿using IMDBWebApi.Domain.Entities;

namespace IMDBWebApi.Domain.Interfaces.Repositories
{
    public interface IGenreRepository
    {
        void Create(Genre genre);
        void Update(Genre genre);
        void Delete(Genre genre);
        Task<bool> IsAlreadyRegistred(IEnumerable<int> castsId, CancellationToken cancellationToken);
        Task<bool> IsUniqueName(string name, CancellationToken cancellatioToken);
        Task<IEnumerable<Genre>> GetAll(CancellationToken cancellationToken);
        Task<Genre?> GetById(int id, CancellationToken cancellationToken);
    }
}
