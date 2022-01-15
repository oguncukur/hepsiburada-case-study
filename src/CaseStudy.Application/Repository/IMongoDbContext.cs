using MongoDB.Driver;

namespace CaseStudy.Application.Repository
{
    public interface IMongoDbContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}