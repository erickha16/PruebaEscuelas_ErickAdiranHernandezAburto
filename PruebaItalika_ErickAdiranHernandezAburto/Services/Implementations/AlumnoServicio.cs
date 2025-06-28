using Microsoft.EntityFrameworkCore;
using PruebaItalika_ErickAdiranHernandezAburto.Data;
using PruebaItalika_ErickAdiranHernandezAburto.DTOs;
using PruebaItalika_ErickAdiranHernandezAburto.Services.Interfaces;

namespace PruebaItalika_ErickAdiranHernandezAburto.Services.Implementations
{
    public class AlumnoServicio : IAlumnoServicio
    {
        private readonly AppDbContext _context;

        public AlumnoServicio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AlumnoDTO>> GetAllAsync()
        {
            return await _context.Alumnos
                .FromSqlRaw("EXEC dbo.Alumnos_Listar")
                .ToListAsync();
        }

        public async Task<AlumnoDTO> GetByIdAsync(int id)
        {
            var alumnos = await _context.Alumnos
                .FromSqlRaw("EXEC dbo.Alumnos_PorId @Id = {0}", id)
                .ToListAsync();

            var alumno = alumnos.FirstOrDefault();

            if (alumno == null)
                throw new KeyNotFoundException($"No se encontró un alumno con Id = {id}.");

            return alumno;
        }

        public async Task AddAsync(AlumnoDTO alumnoDto)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.Alumnos_Crear @Nombre = {0}, @Apellido = {1}, @FechaNacimiento = {2}, @NumeroIdentificacion = {3}",
                alumnoDto.Nombre,
                alumnoDto.Apellido,
                alumnoDto.FechaNacimiento,
                alumnoDto.NumeroIdentificacion
            );
        }

        public async Task UpdateAsync(AlumnoDTO alumnoDto)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.Alumnos_Actualizar @Id = {0}, @Nombre = {1}, @Apellido = {2}, @FechaNacimiento = {3}, @NumeroIdentificacion = {4}",
                alumnoDto.Id,
                alumnoDto.Nombre,
                alumnoDto.Apellido,
                alumnoDto.FechaNacimiento,
                alumnoDto.NumeroIdentificacion
            );
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.Alumnos_Eliminar @Id = {0}",
                id
            );
        }
    }
}
