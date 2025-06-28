using Microsoft.EntityFrameworkCore;
using PruebaItalika_ErickAdiranHernandezAburto.Data;
using PruebaItalika_ErickAdiranHernandezAburto.DTOs;
using PruebaItalika_ErickAdiranHernandezAburto.Services.Interfaces;

namespace PruebaItalika_ErickAdiranHernandezAburto.Services.Implementations
{
    public class EscuelaServicio : IEscuelaServicio
    {
        //DI
        private readonly AppDbContext _context;

        public EscuelaServicio(AppDbContext context)
        {
            _context = context;
        }

        //Implementación de servicios

        public async Task<List<EscuelaDTO>> GetAllAsync()
        {
            var escuelas = await _context.Escuelas
                .FromSqlRaw("EXEC dbo.Escuelas_Listar").ToListAsync();

            return escuelas;
        }

        public async Task<EscuelaDTO> GetByIdAsync(int id)
        {
            var escuelas = await _context.Escuelas
             .FromSqlRaw("EXEC dbo.Escuelas_PorId @Id = {0}", id)
             .ToListAsync();

            var escuela = escuelas.FirstOrDefault();

            if (escuela == null)
                throw new KeyNotFoundException($"No se encontró la escuela con el ID {id}.");

            return escuela;

        }

        

        public async Task AddAsync(EscuelaDTO escuelaDTO)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.Escuelas_Crear @Codigo = {0}, @Nombre = {1}, @Descripcion = {2}",
                escuelaDTO.Codigo,
                escuelaDTO.Nombre,
                escuelaDTO.Descripcion
            );
        }
        public async Task UpdateAsync(EscuelaDTO escuelaDTO)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.Escuelas_Actualizar @Id = {0}, @Codigo = {1}, @Nombre = {2}, @Descripcion = {3}",
                escuelaDTO.Id,
                escuelaDTO.Codigo,
                escuelaDTO.Nombre,
                escuelaDTO.Descripcion
            );
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.Escuelas_Eliminar @Id = {0}",
                id
            );
        }

    }
}
