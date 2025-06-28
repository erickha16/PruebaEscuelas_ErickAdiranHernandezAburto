using Microsoft.AspNetCore.Mvc;
using PruebaItalika_ErickAdiranHernandezAburto.DTOs;
using PruebaItalika_ErickAdiranHernandezAburto.Services.Interfaces;

namespace PruebaItalika_ErickAdiranHernandezAburto.Controllers
{
    [Route("api/v1/alumnos")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        private readonly IAlumnoServicio _alumnoServicio;

        public AlumnosController(IAlumnoServicio alumnoServicio)
        {
            _alumnoServicio = alumnoServicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var alumnos = await _alumnoServicio.GetAllAsync();
            return Ok(alumnos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var alumno = await _alumnoServicio.GetByIdAsync(id);
                if (alumno == null)
                    return NotFound($"No se encontró el alumno con Id = {id}.");

                return Ok(alumno);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el alumno: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AlumnoDTO alumnoDto)
        {
            try
            {
                await _alumnoServicio.AddAsync(alumnoDto);
                return CreatedAtAction(nameof(GetById), new { id = alumnoDto.Id }, alumnoDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el alumno: {ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] AlumnoDTO alumnoDto)
        {
            if (id != alumnoDto.Id)
                return BadRequest("El ID en la ruta no coincide con el del cuerpo.");

            try
            {
                await _alumnoServicio.UpdateAsync(alumnoDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el alumno: {ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _alumnoServicio.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el alumno: {ex.Message}");
            }
        }
    }
}
