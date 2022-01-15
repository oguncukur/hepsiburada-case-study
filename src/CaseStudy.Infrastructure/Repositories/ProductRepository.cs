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

        public ProductDto GetDetail(string id)
        {
            var product = _mongoContext.GetCollection<Product>("Product");
            var category = _mongoContext.GetCollection<Category>("Category");

            var result = (from p in product.AsQueryable()
                          join c in category.AsQueryable()
                          on p.CategoryId equals c.Id into joined
                          where p.Id == id
                          select new ProductDto
                          {
                              Id = p.Id,
                              Name = p.Name,
                              Description = p.Description,
                              CategoryId = joined,
                              Currency = p.Currency,
                              Price = p.Price
                          }).FirstOrDefault();

            return result;
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            return await _dbCollection.FindAsync(Builders<Product>.Filter.Eq("Name", name)).GetAwaiter().GetResult().ToListAsync();
        }
    }
}