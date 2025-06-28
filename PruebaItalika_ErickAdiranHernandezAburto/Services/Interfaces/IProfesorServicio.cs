using PruebaItalika_ErickAdiranHernandezAburto.DTOs;

namespace PruebaItalika_ErickAdiranHernandezAburto.Services.Interfaces
{
    public interface IProfesorServicio
    {
        /// <summary>
        /// Obtiene la lista de todas las profesors registradas
        /// </summary>
        /// <returns>List<ProfesorDTO></returns>
        Task<List<ProfesorDTO>> GetAllAsync();

        /// <summary>
        /// Obtiene una profesor mediante su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ProfesorDTO</returns>
        Task<ProfesorDTO> GetByIdAsync(int id);

        /// <summary>
        /// Añade una nueva profesor
        /// </summary>
        /// <param name="profesorDTO"></param>
        /// <returns></returns>
        Task AddAsync(ProfesorDTO profesorDTO);

        /// <summary>
        /// Actualiza el registro de una profesor
        /// </summary>
        /// <param name="profesorDTO"></param>
        /// <returns></returns>
        Task UpdateAsync(ProfesorDTO profesorDTO);

        /// <summary>
        /// Elimina una profesor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);
    }
}
