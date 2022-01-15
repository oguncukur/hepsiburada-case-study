using AutoMapper;
using CaseStudy.Domain.Entities;
using CaseStudy.Application.Products.Commands.PostProduct;
using CaseStudy.Application.Products.Commands.UpdateProduct;
using CaseStudy.Application.Categories.Commands.PostCategory;
using CaseStudy.Application.Categories.Commands.UpdateCategory;
using CaseStudy.Application.Products.Queries.GetProduct;

namespace CaseStudy.Application.Mappings
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<PostProductCommand, Product>().ReverseMap();
            CreateMap<UpdateProductCommand, Product>().ReverseMap();
            CreateMap<PostCategoryCommand, Category>().ReverseMap();
            CreateMap<UpdateCategoryCommand, Category>().ReverseMap();
        }
    }
}