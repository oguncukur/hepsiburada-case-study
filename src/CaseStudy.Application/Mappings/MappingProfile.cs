using AutoMapper;
using CaseStudy.Domain.Entities;
using CaseStudy.Application.Products.Commands.PostProduct;
using CaseStudy.Application.Products.Commands.UpdateProduct;
using CaseStudy.Application.Categories.Commands.PostCategory;
using CaseStudy.Application.Categories.Commands.UpdateCategory;
using CaseStudy.Application.Products.Queries.GetProduct;
using MongoDB.Bson;

namespace CaseStudy.Application.Mappings
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<PostProductCommand, Product>().BeforeMap((s, d) => d.Id = ObjectId.GenerateNewId().ToString());
            CreateMap<UpdateProductCommand, Product>().ReverseMap();
            CreateMap<PostCategoryCommand, Category>().ReverseMap();
            CreateMap<UpdateCategoryCommand, Category>().ReverseMap();
        }
    }
}