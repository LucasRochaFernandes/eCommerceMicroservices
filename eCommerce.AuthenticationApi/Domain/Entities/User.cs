using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eCommerce.AuthenticationApi.Domain.Entities;

public class User
{
    [BsonId]
    [BsonElement("_id"), BsonRepresentation(BsonType.String)]
    public Guid Id = Guid.NewGuid();
    [BsonElement("email"), BsonRepresentation(BsonType.String)]
    public string Email { get; set; }
    [BsonElement("password"), BsonRepresentation(BsonType.String)]
    public string Password { get; set; }
    [BsonElement("cep"), BsonRepresentation(BsonType.String)]
    public string CEP { get; set; }
    [BsonElement("fullAddress"), BsonRepresentation(BsonType.String)]
    public string FullAddress { get; set; }
    [BsonElement("phoneNumber"), BsonRepresentation(BsonType.String)]
    public string PhoneNumber { get; set; }
}
