using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace ex1.Models
{
    public class Avaliacao
    {

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public int Nota { get; set; }
        public string? Comentario { get; set; }
        public DateTime? DataAvaliacao { get; set; }

    }
}
