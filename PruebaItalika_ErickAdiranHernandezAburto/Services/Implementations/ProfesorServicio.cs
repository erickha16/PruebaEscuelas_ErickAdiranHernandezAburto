using Microsoft.EntityFrameworkCore;
using PruebaItalika_ErickAdiranHernandezAburto.Data;
using PruebaItalika_ErickAdiranHernandezAburto.DTOs;
using PruebaItalika_ErickAdiranHernandezAburto.Services.Interfaces;

namespace PruebaItalika_ErickAdiranHernandezAburto.Services.Implementations
{
    public class ProfesorServicio : IProfesorServicio
    {
        private readonly AppDbContext _context;

        public ProfesorServicio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProfesorDTO>> GetAllAsync()
        {
            return await _context.Profesores
                .FromSqlRaw("EXEC dbo.Profesores_Listar")
                .ToListAsync();
        }

        public async Task<ProfesorDTO> GetByIdAsync(int id)
        {
            var profesores = await _context.Profesores
                .FromSqlRaw("EXEC dbo.Profesores_PorId @Id = {0}", id)
                .ToListAsync();

            var profesor = profesores.FirstOrDefault();

            if (profesor == null)
                throw new KeyNotFoundException($"No se encontró un profesor con Id = {id}.");

            return profesor;
        }

        public async Task AddAsync(ProfesorDTO profesorDto)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.Profesores_Crear @Nombre = {0}, @Apellido = {1}, @NumeroIdentificacion = {2}, @EscuelaId = {3}",
                profesorDto.Nombre,
                profesorDto.Apellido,
                profesorDto.NumeroIdentificacion,
                profesorDto.EscuelaId
            );
        }

        public async Task UpdateAsync(ProfesorDTO profesorDto)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.Profesores_Actualizar @Id = {0}, @Nombre = {1}, @Apellido = {2}, @NumeroIdentificacion = {3}, @EscuelaId = {4}",
                profesorDto.Id,
                profesorDto.Nombre,
                profesorDto.Apellido,
                profesorDto.NumeroIdentificacion,
                profesorDto.EscuelaId
            );
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.Profesores_Eliminar @Id = {0}",
                id
            );
        }
    }
}
