using Microsoft.AspNetCore.Mvc;
using PruebaItalika_ErickAdiranHernandezAburto.DTOs;
using PruebaItalika_ErickAdiranHernandezAburto.Services.Interfaces;

namespace PruebaItalika_ErickAdiranHernandezAburto.Controllers
{
    [Route("api/v1/profesores")]
    [ApiController]
    public class ProfesoresController : ControllerBase
    {
        private readonly IProfesorServicio _profesorServicio;

        public ProfesoresController(IProfesorServicio profesorServicio)
        {
            _profesorServicio = profesorServicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var profesores = await _profesorServicio.GetAllAsync();
            return Ok(profesores);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var profesor = await _profesorServicio.GetByIdAsync(id);
                if (profesor == null)
                    return NotFound($"No se encontró el profesor con Id = {id}.");

                return Ok(profesor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el profesor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProfesorDTO profesorDto)
        {
            try
            {
                await _profesorServicio.AddAsync(profesorDto);
                return CreatedAtAction(nameof(GetById), new { id = profesorDto.Id }, profesorDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el profesor: {ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProfesorDTO profesorDto)
        {
            if (id != profesorDto.Id)
                return BadRequest("El ID en la ruta no coincide con el del cuerpo.");

            try
            {
                await _profesorServicio.UpdateAsync(profesorDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el profesor: {ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _profesorServicio.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el profesor: {ex.Message}");
            }
        }
    }
}
