using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventos.Models
{
    public class Patrocinador
    {
        public int PatrocinadorId { get; set; }
        [Display(Name = "Nome da Empresa")]
        public string? Nome_Empresa { get; set; }
        public string? Website { get; set; }

        public ICollection<Evento>? Evento { get; set; }
    }
}
