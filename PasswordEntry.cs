using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PasswordManager.Models
{
    public class PasswordEntry
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string WebDomain { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
