using System.ComponentModel.DataAnnotations;

namespace ProjetoEventos.Models
{
    public class Certificado
    {
        public int CertificadoId { get; set; }
        [Display(Name = "Data da Emissão")]
        public DateOnly Data_emissao { get; set; }
        public string? Link { get; set; }
        public int InscricaoId { get; set; }
        public Inscricao? Inscricao { get; set; }
    }
}
