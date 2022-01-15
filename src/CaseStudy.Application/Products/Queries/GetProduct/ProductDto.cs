using CaseStudy.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace CaseStudy.Application.Products.Queries.GetProduct
{
    public class ProductDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        [BsonElement("Category")]
        public List<Category> Category { get; set; }
    }
}