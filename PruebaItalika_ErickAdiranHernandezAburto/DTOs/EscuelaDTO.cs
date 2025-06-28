using System.ComponentModel.DataAnnotations;

namespace PruebaItalika_ErickAdiranHernandezAburto.DTOs
{
    public class EscuelaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Se requiere asignar un código único")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Se requiere asignar el nombre de la escuela")]
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
    }
}
