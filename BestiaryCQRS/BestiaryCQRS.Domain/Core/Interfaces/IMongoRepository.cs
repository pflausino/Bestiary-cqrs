using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BestiaryCQRS.Domain.Core.Interfaces
{
    public interface IMongoRepository<T> : IDisposable where T : class
    {
        void Add(T obj);
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        void Update(T obj, object id);
        void Remove(Guid id);

    }
}