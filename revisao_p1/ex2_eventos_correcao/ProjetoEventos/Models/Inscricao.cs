using System.ComponentModel.DataAnnotations;

namespace ProjetoEventos.Models
{
    public class Inscricao
    {
        public int InscricaoId { get; set; }
        [Display(Name = "Data da Inscrição")]
        public DateOnly Data_inscricao { get; set; }
        
        public int EventoId { get; set; } 

        public Evento? Evento { get; set; }
        public int ParticipanteId { get; set; }

        public Participante? Participante { get; set; }
    }
}
