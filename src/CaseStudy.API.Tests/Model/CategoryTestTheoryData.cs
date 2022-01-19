using Xunit;
using CaseStudy.Application.Categories.Commands.PostCategory;
using CaseStudy.Application.Categories.Commands.UpdateCategory;

namespace CaseStudy.API.Tests.Model
{
    public class PostCategoryTestTheoryData : TheoryData<PostCategoryCommand>
    {
        public PostCategoryTestTheoryData()
        {
            Add(new PostCategoryCommand
            {
                Name = "Türk Mutfağı",
                Description = "Türk mutfağına ait lezzetler",
            });

            Add(new PostCategoryCommand
            {
                Name = "İtalyan Mutfağı",
                Description = "İtalyan mutfağına ait lezzetler",
            });
        }
    }

    public class UpdateCategoryTestTheoryData : TheoryData<UpdateCategoryCommand>
    {
        public UpdateCategoryTestTheoryData()
        {
            Add(new UpdateCategoryCommand
            {
                Id = "61e7df9f19009511be6677a2",
                Name = "Meksika Mutfağı",
                Description = "Meksika mutfağına ait lezzetler",
            });
        }
    }
}