using CaseStudy.Domain.Entities;
using CaseStudy.Application.Repository;

namespace CaseStudy.Infrastructure.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IMongoDbContext context) : base(context) { }
    }
}