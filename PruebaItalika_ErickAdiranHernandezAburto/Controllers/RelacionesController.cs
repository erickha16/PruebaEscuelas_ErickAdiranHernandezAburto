using Microsoft.AspNetCore.Mvc;
using PruebaItalika_ErickAdiranHernandezAburto.DTOs;
using PruebaItalika_ErickAdiranHernandezAburto.DTOs.Relaciones;
using PruebaItalika_ErickAdiranHernandezAburto.Services.Interfaces;

namespace PruebaItalika_ErickAdiranHernandezAburto.Controllers
{
    [Route("api/v1/relaciones")]
    [ApiController]
    public class RelacionesController : ControllerBase
    {
        private readonly IRelacionesServicio _relacionesServicio;

        public RelacionesController(IRelacionesServicio relacionesServicio)
        {
            _relacionesServicio = relacionesServicio;
        }

        // POST: api/v1/relaciones/inscribir
        [HttpPost("inscribir")]
        public async Task<IActionResult> InscribirAlumno([FromBody] InscripcionDTO dto)
        {
            try
            {
                await _relacionesServicio.InscribirAlumnoAsync(dto);
                return Ok("Alumno inscrito correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al inscribir alumno: {ex.Message}");
            }
        }

        // POST: api/v1/relaciones/asignar
        [HttpPost("asignar")]
        public async Task<IActionResult> AsignarAlumno([FromBody] AsignacionAlumnoProfesorDTO dto)
        {
            try
            {
                await _relacionesServicio.AsignarAlumnoAProfesorAsync(dto);
                return Ok("Alumno asignado al profesor correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al asignar alumno al profesor: {ex.Message}");
            }
        }

        //Obtener alumnos por profesor y el nombre de su respectiva escuela
        [HttpGet("escuelas-y-alumnos-por-profesor/{profesorId:int}")]
        public async Task<IActionResult> GetEscuelasYAlumnosPorProfesor(int profesorId)
        {
            try
            {
                var resultado = await _relacionesServicio.ObtenerEscuelasYAlumnosPorProfesorAsync(profesorId);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener escuelas y alumnos: {ex.Message}");
            }
        }
    }
}
