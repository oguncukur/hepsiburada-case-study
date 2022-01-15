using MongoDB.Bson.Serialization.Attributes;

namespace CaseStudy.Domain.Common
{
    public abstract class EntityBase
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; protected set; }

        //public string CreatedBy { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string LastModifiedBy { get; set; }
        //public DateTime? LastModifiedDate { get; set; }
    }
}