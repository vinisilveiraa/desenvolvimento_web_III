using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventos.Models
{
    public class Evento
    {
        public int EventoId { get; set; }
        [Display(Name = "Título")]
        public string? Titulo { get; set; }
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }
        [Display(Name = "Data do Evento")]
        public DateOnly Data_Evento { get; set; }

        public ICollection<Inscricao>? Inscricao { get; set; }

        public int TipoId { get; set; }
        public Tipo? Tipo { get; set; }

        public int PatrocinadorId { get; set; }
        public Patrocinador? Patrocinador { get; set; }
    }
}
