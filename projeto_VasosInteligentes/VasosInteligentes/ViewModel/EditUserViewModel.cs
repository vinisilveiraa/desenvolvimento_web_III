using System.ComponentModel.DataAnnotations;

namespace VasosInteligentes.ViewModel
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Username { get; set; }
    }
}