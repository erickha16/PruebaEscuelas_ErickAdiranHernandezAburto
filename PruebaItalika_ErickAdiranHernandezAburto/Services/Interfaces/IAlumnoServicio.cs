using PruebaItalika_ErickAdiranHernandezAburto.DTOs;

namespace PruebaItalika_ErickAdiranHernandezAburto.Services.Interfaces
{
    public interface IAlumnoServicio
    {
        /// <summary>
        /// Obtiene la lista de todas las alumnos registradas
        /// </summary>
        /// <returns>List<AlumnoDTO></returns>
        Task<List<AlumnoDTO>> GetAllAsync();

        /// <summary>
        /// Obtiene una alumno mediante su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>AlumnoDTO</returns>
        Task<AlumnoDTO> GetByIdAsync(int id);

        /// <summary>
        /// Añade una nueva alumno
        /// </summary>
        /// <param name="alumnoDTO"></param>
        /// <returns></returns>
        Task AddAsync(AlumnoDTO alumnoDTO);

        /// <summary>
        /// Actualiza el registro de una alumno
        /// </summary>
        /// <param name="alumnoDTO"></param>
        /// <returns></returns>
        Task UpdateAsync(AlumnoDTO alumnoDTO);

        /// <summary>
        /// Elimina una alumno
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);
    }
}
