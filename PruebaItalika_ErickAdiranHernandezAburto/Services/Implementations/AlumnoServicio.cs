using PruebaItalika_ErickAdiranHernandezAburto.Data;
using PruebaItalika_ErickAdiranHernandezAburto.DTOs;
using PruebaItalika_ErickAdiranHernandezAburto.Services.Interfaces;

namespace PruebaItalika_ErickAdiranHernandezAburto.Services.Implementations
{
    public class AlumnoServicio : IAlumnoServicio
    {
        //DI
        private readonly AppDbContext _context;

        public AlumnoServicio(AppDbContext context)
        {
            _context = context;
        }

        //Implemnetación de Servicios
        public Task<List<AlumnoDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AlumnoDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(AlumnoDTO alumnoDTO)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(AlumnoDTO alumnoDTO)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
        
    }
}
