using CaseStudy.Application.Products.Queries.GetProduct;
using CaseStudy.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseStudy.Application.Repository
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
        ProductDto GetDetail(string id);
        Task<IEnumerable<Product>> GetProductsByNameAsync(string name);
    }
}