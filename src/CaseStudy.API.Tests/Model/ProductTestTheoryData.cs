using Xunit;
using CaseStudy.Application.Products.Commands.PostProduct;
using CaseStudy.Application.Products.Commands.UpdateProduct;

namespace CaseStudy.API.Tests.Model
{
    public class PostProductTestTheoryData : TheoryData<PostProductCommand>
    {
        public PostProductTestTheoryData()
        {
            Add(new PostProductCommand
            {
                Name = "Döner",
                Description = "Türk Mutfağı",
                CategoryId = "61e515a7c823533f38d63d87",
                Currency = "TL",
                Price = 25.90m
            });

            Add(new PostProductCommand
            {
                Name = "Kebap",
                Description = "Türk Mutfağı",
                Currency = "TL",
                Price = 40.50m
            });
        }
    }

    public class UpdateProductTestTheoryData : TheoryData<UpdateProductCommand>
    {
        public UpdateProductTestTheoryData()
        {
            Add(new UpdateProductCommand
            {
                Id = "61e7e0a072535817a8fed13a",
                Name = "Döner",
                Description = "Türk Mutfağı",
                CategoryId = "61e7df9f19009511be6677a2",
                Currency = "TL",
                Price = 25.90m
            });
        }
    }
}