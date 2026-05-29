namespace ProjetoEventos.Models
{
    public class Tipo
    {
        public int TipoId { get; set; }
        public string? Descritivo { get; set; }
        public ICollection<Evento>? Evento { get; set; }
    }
}
