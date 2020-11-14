using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CooperlinkLocationWorker.Domain.Collections
{
    public abstract class CollectionModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public ObjectId _id { get; set; }
    }
}
