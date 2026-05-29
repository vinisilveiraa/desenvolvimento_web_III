using MongoDB.Bson.Serialization.Attributes;

namespace ex1.Models
{
    public class Autor
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
    }
}
