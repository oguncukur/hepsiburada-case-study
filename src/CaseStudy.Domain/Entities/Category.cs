using CaseStudy.Domain.Common;

namespace CaseStudy.Domain.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}