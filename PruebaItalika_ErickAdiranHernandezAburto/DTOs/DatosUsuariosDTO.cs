using System.ComponentModel.DataAnnotations;

namespace PruebaItalika_ErickAdiranHernandezAburto.DTOs
{
    public class DatosUsuariosDTO
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El numero de identificación es requerido")]
        [Display(Name ="Numero de Identifiación")]
        public string NumeroIdentificacion { get; set; }
    }
}
