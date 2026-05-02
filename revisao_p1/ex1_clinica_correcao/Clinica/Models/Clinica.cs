using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ProjetoClinica.Models
{
    public class Clinica
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        [Required]
        [Display(Name = "Clínica")]
        public string? Nome { get; set; }
        [Required]
        public Boolean Alarme { get; set; }
    }
}
