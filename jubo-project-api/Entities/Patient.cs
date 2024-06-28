using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace jubo_project_api.Entities;

public class Patient
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; set; }
    public string Name { get; set; }
    public string OrderId { get; set; }
}
