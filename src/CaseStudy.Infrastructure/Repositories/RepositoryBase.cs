using System;
using MongoDB.Driver;
using System.Threading.Tasks;
using CaseStudy.Domain.Common;
using CaseStudy.Application.Repository;

namespace CaseStudy.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : EntityBase
    {
        protected readonly IMongoDbContext _mongoContext;
        protected IMongoCollection<T> _dbCollection;

        protected RepositoryBase(IMongoDbContext context)
        {
            _mongoContext = context;
            _dbCollection = _mongoContext.GetCollection<T>(typeof(T).Name);
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbCollection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<T> GetAsync(string id)
        {
            return await _dbCollection.FindAsync(entity => entity.Id == id).GetAwaiter().GetResult().FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(string id, T entity)
        {
            var result = await _dbCollection.ReplaceOneAsync(entity => entity.Id == id, entity);
            if (result.MatchedCount.Equals(0))
            {
                throw new ArgumentException("The object to update was not found.");
            }
        }

        public async Task RemoveAsync(string id)
        {
            var result = await _dbCollection.DeleteOneAsync(entity => entity.Id == id);
            if (result.DeletedCount.Equals(0))
            {
                throw new ArgumentException("The object to delete was not found.");
            }
        }
    }
}