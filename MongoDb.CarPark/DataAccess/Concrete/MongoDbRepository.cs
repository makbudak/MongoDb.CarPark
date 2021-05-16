using Microsoft.Extensions.Options;
using MongoDb.CarPark.DataAccess.Abstract;
using MongoDb.CarPark.Entities.Abstract;
using MongoDb.CarPark.Utilities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MongoDb.CarPark.DataAccess.Concrete
{
    public abstract class MongoDbRepository<T> : IRepository<T, string> where T : MongoDbEntity, new()
    {
        protected readonly IMongoCollection<T> Collection;
        private readonly MongoDbSettings settings;

        protected MongoDbRepository(IOptions<MongoDbSettings> options)
        {
            this.settings = options.Value;
            var client = new MongoClient(this.settings.ConnectionString);
            var db = client.GetDatabase(this.settings.Database);
            this.Collection = db.GetCollection<T>(typeof(T).Name);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null ?
                Collection.AsQueryable() :
                Collection.AsQueryable().Where(predicate);
        }

        public virtual Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return Collection.Find(predicate).FirstOrDefaultAsync();
        }

        public virtual Task<T> GetByIdAsync(string id)
        {
            return Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            await Collection.InsertOneAsync(entity, options);
            return entity;
        }

        public virtual async Task<bool> AddRangeAsync(IEnumerable<T> entities)
        {
            var options = new BulkWriteOptions { BypassDocumentValidation = false, IsOrdered = false };
            var result = await Collection.BulkWriteAsync((IEnumerable<WriteModel<T>>)entities, options);
            return result.IsAcknowledged;
        }

        public Task<T> UpdateAsync(string id, T entity)
        {
            return Collection.FindOneAndReplaceAsync(x => x.Id == id, entity);
        }

        public virtual Task<T> UpdateAsync(T entity, Expression<Func<T, bool>> predicate)
        {
            return Collection.FindOneAndReplaceAsync(predicate, entity);
        }

        public virtual Task<T> DeleteAsync(T entity)
        {
            return Collection.FindOneAndDeleteAsync(x => x.Id == entity.Id);
        }

        public virtual Task<T> DeleteAsync(string id)
        {
            return Collection.FindOneAndDeleteAsync(x => x.Id == id);
        }

        public virtual Task<T> DeleteAsync(Expression<Func<T, bool>> filter)
        {
            return Collection.FindOneAndDeleteAsync(filter);
        }
    }
}
