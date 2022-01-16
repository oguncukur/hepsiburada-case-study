using CaseStudy.Application.Products.Queries.GetProduct;
using CaseStudy.Domain.Entities;
using System.Collections.Generic;

namespace CaseStudy.Application.Repository
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
        ProductDto Get(string id);
        List<ProductDto> GetProductsByName(string name);
    }
}