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
            return await _dbCollection.FindAsync(entity => entity.Id == id).GetAwaiter().GetResult().FirstOrDefaultAsync();//kategori ile beraber gelmesi lazım
        }

        public async Task UpdateAsync(string id, T entity)
        {
            await _dbCollection.ReplaceOneAsync(entity => entity.Id == id, entity);
        }

        public async Task RemoveAsync(string id)
        {
            await _dbCollection.DeleteOneAsync(entity => entity.Id == id);
        }
    }
}