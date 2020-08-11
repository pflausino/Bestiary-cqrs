using System.Linq;
using System.Threading.Tasks;
using BestiaryCQRS.Domain.Core.Entities;

namespace BestiaryCQRS.Domain.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<object> AddAsync(TEntity entity);
        void Add(TEntity entity);

        Task<TEntity> GetByIdAsync(object id);

        IQueryable<TEntity> GetAll();

        Task UpdateAsync(TEntity entity);
        Task UpdateAsync(object id, TEntity entity);

        Task RemoveAsync(object id);
    }

}