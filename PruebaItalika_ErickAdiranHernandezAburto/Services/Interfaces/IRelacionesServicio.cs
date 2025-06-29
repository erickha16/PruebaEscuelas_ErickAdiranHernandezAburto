using PruebaItalika_ErickAdiranHernandezAburto.DTOs.Relaciones;

namespace PruebaItalika_ErickAdiranHernandezAburto.Services.Interfaces
{
    public interface IRelacionesServicio
    {
        /// <summary>
        /// Inscribir un alumno a una escuela
        /// </summary>
        /// <param name="inscripcionDTO"></param>
        /// <returns></returns>
        Task InscribirAlumnoAsync(InscripcionDTO inscripcionDTO);

        /// <summary>
        /// Asignar alumno a un profesor
        /// </summary>
        /// <param name="asignacionAlumnoProfesorDTO"></param>
        /// <returns></returns>
        Task AsignarAlumnoAProfesorAsync(AsignacionAlumnoProfesorDTO asignacionAlumnoProfesorDTO);


        /// <summary>
        /// Alumnos asignados a un presosr y a su respectivas escuelas 
        /// </summary>
        /// <param name="profesorId"></param>
        /// <returns></returns>
        Task<List<EscuelaYAlumnosDTO>> ObtenerEscuelasYAlumnosPorProfesorAsync(int profesorId);
    }
}
