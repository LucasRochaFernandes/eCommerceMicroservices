using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eCommerce.ProductApi.Domain.Entities;
public class Product
{
    [BsonId]
    [BsonElement("_id"), BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; } = Guid.NewGuid();
    [BsonElement("name"), BsonRepresentation(BsonType.String)]
    public string Name { get; set; }
    [BsonElement("price"), BsonRepresentation(BsonType.Decimal128)]
    public decimal Price { get; set; }
    [BsonElement("stock"), BsonRepresentation(BsonType.Int64)]
    public int Stock { get; set; } = 0;
}
