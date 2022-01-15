using System.Threading.Tasks;
using CaseStudy.Domain.Entities;
using System.Collections.Generic;
using CaseStudy.Application.Products.Queries.GetProduct;

namespace CaseStudy.Application.Repository
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
        Task<ProductDto> GetWithCategoryAsync(string id);
        Task<IEnumerable<Product>> GetProductsByNameAsync(string name);
    }
}