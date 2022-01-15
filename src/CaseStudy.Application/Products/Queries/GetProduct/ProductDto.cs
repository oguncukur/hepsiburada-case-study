using MongoDB.Bson;
using CaseStudy.Domain.Entities;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace CaseStudy.Application.Products.Queries.GetProduct
{
    public class ProductDto
    {
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public IEnumerable<Category> CategoryId { get; set; }
    }
}