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
                CategoryId = "",
                Currency = "TL",
                Price = 25.90m
            });

            Add(new PostProductCommand
            {
                Name = "Kebap",
                Description = "Türk Mutfağı",
                CategoryId = "",
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
                Id = "",
                Name = "Döner",
                Description = "Türk Mutfağı",
                CategoryId = "",
                Currency = "TL",
                Price = 25.90m
            });
        }
    }
}