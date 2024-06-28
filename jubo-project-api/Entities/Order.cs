using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace jubo_project_api.Entities;

public class Order
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; set; }
    public string Message { get; set; }
}
