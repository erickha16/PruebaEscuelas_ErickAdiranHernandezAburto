using PruebaItalika_ErickAdiranHernandezAburto.Data;
using PruebaItalika_ErickAdiranHernandezAburto.DTOs;
using PruebaItalika_ErickAdiranHernandezAburto.Services.Interfaces;

namespace PruebaItalika_ErickAdiranHernandezAburto.Services.Implementations
{
    public class ProfesorServicio : IProfesorServicio
    {
        //DI
        private readonly AppDbContext _context;

        public ProfesorServicio(AppDbContext context)
        {
            _context = context;
        }

        //Implementación de Servicios
        public async Task<List<ProfesorDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ProfesorDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(ProfesorDTO profesorDTO)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(ProfesorDTO profesorDTO)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }


    }
}
