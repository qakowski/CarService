using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SerwisSamochodowy.Mongo
{
    public interface IRepository<TEntity> where TEntity : IBase
    {

        Task<TEntity> GetAsync(ObjectId id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> FindAsync();
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<DeleteResult> DeleteAsync(ObjectId id);
        Task UpdateManyAsync(Expression<Func<TEntity, bool>> expression, UpdateDefinition<TEntity> update);
    }
}