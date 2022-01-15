using MongoDB.Driver;
using System.Threading.Tasks;
using CaseStudy.Domain.Entities;
using System.Collections.Generic;
using CaseStudy.Application.Repository;
using CaseStudy.Application.Products.Queries.GetProduct;
using System.Linq;

namespace CaseStudy.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IMongoDbContext context) : base(context) { }

        public async Task<ProductDto> GetWithCategoryAsync(string id)
        {
            var result = await _dbCollection.Aggregate().Match(x => x.Id == id)
                .Lookup("Category", "CategoryId", "_id", @as: "Category")
                .As<ProductDto>()
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            return await _dbCollection.FindAsync(Builders<Product>.Filter.Eq("Name", name)).GetAwaiter().GetResult().ToListAsync();
        }
    }
}