using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaItalika_ErickAdiranHernandezAburto.DTOs;
using PruebaItalika_ErickAdiranHernandezAburto.Services.Interfaces;

namespace PruebaItalika_ErickAdiranHernandezAburto.Controllers
{
    [Route("api/v1/escuelas")]
    [ApiController]
    public class EscuelasController : ControllerBase
    {
        private readonly IEscuelaServicio _escuelaServicio;

        public EscuelasController(IEscuelaServicio escuelaServicio)
        {
            _escuelaServicio = escuelaServicio;
        }

        //Listar
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var escuelas = await _escuelaServicio.GetAllAsync();
            return Ok(escuelas);
        }

        //Obtener por ID
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var escuela = await _escuelaServicio.GetByIdAsync(id);
                if (escuela == null)
                    return NotFound($"No se encontró la escuela con Id = {id}.");

                return Ok(escuela);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener la escuela: {ex.Message}");
            }
        }

        //Añadir
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EscuelaDTO escuelaDto)
        {
            try
            {
                await _escuelaServicio.AddAsync(escuelaDto);
                return CreatedAtAction(nameof(GetById), new { id = escuelaDto.Id }, escuelaDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la escuela: {ex.Message}");
            }
        }

        //Editar
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] EscuelaDTO escuelaDto)
        {
            if (id != escuelaDto.Id)
                return BadRequest("El ID en la ruta no coincide con el del cuerpo.");

            try
            {
                await _escuelaServicio.UpdateAsync(escuelaDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar la escuela: {ex.Message}");
            }
        }

        //Eliminar
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _escuelaServicio.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar la escuela: {ex.Message}");
            }
        }



    }
}
