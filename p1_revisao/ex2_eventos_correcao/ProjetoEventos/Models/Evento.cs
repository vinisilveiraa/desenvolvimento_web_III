using System.ComponentModel.DataAnnotations;

namespace ProjetoEventos.Models
{
    public class Evento
    {
        public int EventoId { get; set; }
        [Display(Name = "Título")]
        public string? Titulo { get; set; }
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }
        [Display(Name = "Data do evento")]
        public DateOnly Data_evento { get; set; }

        public ICollection<Inscricao>? Inscricao { get; set; }
        [Display(Name = "Patrocinador")]
        public int PatrocinadorId { get; set; }
        public Patrocinador? Patrocinador { get; set; }
        [Display(Name = "Tipo de Evento")]
        public int TipoId { get; set; }
        public Tipo? Tipo { get; set; }

    }
}
