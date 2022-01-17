using MongoDB.Bson;
using CaseStudy.Domain.Common;
using MongoDB.Bson.Serialization.Attributes;

namespace CaseStudy.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        
        [BsonIgnoreIfNull]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }
    }
}