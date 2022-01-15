using CaseStudy.Domain.Common;

namespace CaseStudy.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public string CategoryId { get; set; }
        public string Description { get; set; }
    }
}