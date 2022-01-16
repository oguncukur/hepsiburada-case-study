using CaseStudy.Application.Products.Queries.GetProduct;
using CaseStudy.Application.Repository;
using CaseStudy.Domain.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace CaseStudy.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IMongoDbContext context) : base(context) { }

        public ProductDto Get(string id)
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

        public List<ProductDto> GetProductsByName(string name)
        {
            var product = _mongoContext.GetCollection<Product>("Product");
            var category = _mongoContext.GetCollection<Category>("Category");

            var result = (from p in product.AsQueryable()
                          join c in category.AsQueryable()
                          on p.CategoryId equals c.Id into joined
                          where p.Name == name
                          select new ProductDto
                          {
                              Id = p.Id,
                              Name = p.Name,
                              Description = p.Description,
                              CategoryId = joined,
                              Currency = p.Currency,
                              Price = p.Price
                          }).ToList();

            return result;
        }
    }
}