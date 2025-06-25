using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Boitoan.DAL.Entities;

public class Base
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
