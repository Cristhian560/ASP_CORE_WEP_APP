using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Personaje
    {
        public int Id { get; set; }

        //[Required(ErrorMessage ="EL NOMBRE ES OBLIGATORIO")]
        [Display(Name ="Nombre del personaje")]
        public string Nombre { get; set; }
        [Display(Name ="Tipo de personaje")]
        public int IdTipo { get; set; }
    }
}
