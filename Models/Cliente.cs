using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "EL NOMBRE ES OBLIGATORIO")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "LA DIRECCION ES OBLIGATORIA")]
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public int Cuit { get; set; }
    }
}
