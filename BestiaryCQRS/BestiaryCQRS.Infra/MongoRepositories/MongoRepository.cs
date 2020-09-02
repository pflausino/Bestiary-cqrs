using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BestiaryCQRS.Domain.Core.Interfaces;
using MongoDB.Driver;

namespace BestiaryCQRS.Infra.MongoRepositories
{
    public abstract class MongoRepository<T> : IMongoRepository<T> where T : class
    {
        protected readonly IMongoContext Context;
        protected IMongoCollection<T> DbSet;
        public MongoRepository(IMongoContext context)
        {
            Context = context;
        }
        public virtual void Add(T obj)
        {
            ConfigDbSet();
            Context.AddCommand(() => DbSet.InsertOneAsync(obj));
        }

        private void ConfigDbSet()
        {
            DbSet = Context.GetCollection<T>(typeof(T).Name);
        }

        public virtual async Task<T> GetById(Guid id)
        {
            ConfigDbSet();
            var data = await DbSet.FindAsync(Builders<T>.Filter.Eq("_id", id));
            return data.SingleOrDefault();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            ConfigDbSet();
            var all = await DbSet.FindAsync(Builders<T>.Filter.Empty);
            return all.ToList();
        }

        public virtual void Update(T obj, object id)
        {
            ConfigDbSet();
            Context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", id), obj));
        }

        public virtual void Remove(Guid id)
        {
            ConfigDbSet();
            Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id)));
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }

}