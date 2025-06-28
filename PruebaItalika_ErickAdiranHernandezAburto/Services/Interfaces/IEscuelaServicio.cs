using PruebaItalika_ErickAdiranHernandezAburto.DTOs;

namespace PruebaItalika_ErickAdiranHernandezAburto.Services.Interfaces
{
    public interface IEscuelaServicio
    {
        /// <summary>
        /// Obtiene la lista de todas las escuelas registradas
        /// </summary>
        /// <returns>List<EscuelaDTO></returns>
        Task<List<EscuelaDTO>> GetAllAsync();

        /// <summary>
        /// Obtiene una escuela mediante su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EscuelaDTO</returns>
        Task<EscuelaDTO> GetByIdAsync(int id);

        /// <summary>
        /// Añade una nueva escuela
        /// </summary>
        /// <param name="escuelaDTO"></param>
        /// <returns></returns>
        Task AddAsync(EscuelaDTO escuelaDTO);
        
        /// <summary>
        /// Actualiza el registro de una escuela
        /// </summary>
        /// <param name="escuelaDTO"></param>
        /// <returns></returns>
        Task UpdateAsync(EscuelaDTO escuelaDTO);

        /// <summary>
        /// Elimina una escuela 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);

    }
}
