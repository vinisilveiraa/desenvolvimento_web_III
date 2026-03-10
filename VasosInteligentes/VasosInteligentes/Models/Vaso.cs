using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace VasosInteligentes.Models
{
    public class Vaso
    {

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Nome { get; set; }

        public string? PlantaId { get; set; }

        [Display(Name = "Localização")]
        public string? Localizacao { get; set; }

        public List<Planta> PlantaList { get; set; } = new List<Planta>();
    }
}
