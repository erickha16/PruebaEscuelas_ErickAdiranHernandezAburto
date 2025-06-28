using System.ComponentModel.DataAnnotations;

namespace PruebaItalika_ErickAdiranHernandezAburto.DTOs
{
    public class ProfesorDTO : DatosUsuariosDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Se requiere asignar una escuela al profesor")]
        public int EscuelaId { get; set; }

        public string? Escuela {  get; set; }
    }
}
