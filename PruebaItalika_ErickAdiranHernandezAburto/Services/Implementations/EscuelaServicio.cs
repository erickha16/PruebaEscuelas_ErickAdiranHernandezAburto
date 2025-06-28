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

        public Task<List<EscuelaDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EscuelaDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(EscuelaDTO escuelaDTO)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync(EscuelaDTO escuelaDTO)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}
