using System.ComponentModel.DataAnnotations;

namespace ClientesApp.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Nombres { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Celular { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Rnc { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Direccion { get; set; }
        
    }
}
