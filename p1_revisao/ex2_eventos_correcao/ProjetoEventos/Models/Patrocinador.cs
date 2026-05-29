using System.ComponentModel.DataAnnotations;

namespace ProjetoEventos.Models
{
    public class Patrocinador
    {
        public int PatrocinadorId { get; set; }
        [Display(Name="Nome da Empresa")]
        public string? Nome_empresa { get; set; }
        public string? Website { get; set; }
        public ICollection<Evento>? Evento { get; set; }
    }
}
