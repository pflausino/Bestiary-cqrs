

using System.Linq;
using System.Threading.Tasks;
using BestiaryCQRS.Domain.Core.Entities;
using BestiaryCQRS.Domain.Core.Interfaces;
using NHibernate;

namespace BestiaryCQRS.Infra.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly ISession Session;

        public Repository(ISession session)
        {
            Session = session;
        }
        public Task AddAsync(TEntity entity)
        {
            return Session.SaveAsync(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Session.Query<TEntity>();
        }

        public Task<TEntity> GetByIdAsync(object id)
        {
            return Session.GetAsync<TEntity>(id);
        }

        public Task RemoveAsync(object id)
        {
            return Session.DeleteAsync(id);
        }

        public Task UpdateAsync(TEntity entity)
        {
            return Session.UpdateAsync(entity);
        }
    }

}