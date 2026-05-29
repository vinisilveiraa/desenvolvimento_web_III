using System.ComponentModel;
using MongoDB.Bson.Serialization.Attributes;

namespace ex1.Models
{
    public class Trabalho
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Titulo { get; set; }
        public string? Resumo { get; set; }
        public string? AreaTematica { get; set; }
        public DateTime? DataSubmissao { get; set; }

        public string? AutorNome { get; set; }
        public string? AutorEmail { get; set; }
        public List<Avaliacao>? Avaliacoes { get; set; }
    }
}
