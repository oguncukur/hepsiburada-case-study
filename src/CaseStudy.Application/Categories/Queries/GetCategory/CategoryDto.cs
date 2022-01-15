using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CaseStudy.Application.Categories.Queries.GetCategory
{
    public class CategoryDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}