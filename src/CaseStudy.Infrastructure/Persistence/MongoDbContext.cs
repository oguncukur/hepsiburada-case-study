using MongoDB.Driver;
using Microsoft.Extensions.Options;
using CaseStudy.Application.Repository;

namespace CaseStudy.Infrastructure.Persistence
{
    public class MongoDbContext : IMongoDbContext
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }

        public MongoDbContext(IOptions<MongoDbSettings> configuration)
        {
            _mongoClient = new MongoClient(configuration.Value.ConnectionString);
            _db = _mongoClient.GetDatabase(configuration.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }
    }
}