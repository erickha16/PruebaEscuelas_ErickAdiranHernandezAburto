using System.ComponentModel.DataAnnotations;

namespace PruebaItalika_ErickAdiranHernandezAburto.DTOs
{
    public class AlumnoDTO : DatosUsuariosDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "la fecha de nacimiento del alumno es requerida")]
        public DateTime FechaNacimiento { get; set; }
    }
}
