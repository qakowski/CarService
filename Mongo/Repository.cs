using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SerwisSamochodowy.Mongo
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : IBase
    {
        private readonly IMongoCollection<TEntity> _mongoCollection;

        public Repository(IMongoDatabase mongoDatabase, string collection)
        {
            _mongoCollection = mongoDatabase.GetCollection<TEntity>(collection);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _mongoCollection.InsertOneAsync(entity, new InsertOneOptions());
            return entity;
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression)
             => await _mongoCollection.Find(expression).ToListAsync();

        public async Task<IEnumerable<TEntity>> FindAsync()
            => await _mongoCollection.Find(p => true).ToListAsync();

        public async Task<TEntity> GetAsync(ObjectId id)
            => await _mongoCollection.Find(p => p.Id.Equals(id)).SingleOrDefaultAsync();

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
            => await _mongoCollection.Find(expression).SingleOrDefaultAsync();

        public async Task<TEntity> UpdateAsync(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> updateDefinition)
        {
            await _mongoCollection.UpdateOneAsync(filter, updateDefinition);
            return await _mongoCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<DeleteResult> DeleteAsync(ObjectId id)
            => await _mongoCollection.DeleteOneAsync(p => p.Id == id);

        public async Task UpdateManyAsync(Expression<Func<TEntity, bool>> expression, UpdateDefinition<TEntity> update)
            => await _mongoCollection.UpdateManyAsync(expression, update);
    }
}