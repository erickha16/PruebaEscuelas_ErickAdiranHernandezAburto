using Microsoft.EntityFrameworkCore;
using PruebaItalika_ErickAdiranHernandezAburto.Data;
using PruebaItalika_ErickAdiranHernandezAburto.DTOs.Relaciones;
using PruebaItalika_ErickAdiranHernandezAburto.Services.Interfaces;

namespace PruebaItalika_ErickAdiranHernandezAburto.Services.Implementations
{
    public class RelacionesServicio : IRelacionesServicio
    {
        private readonly AppDbContext _context;

        public RelacionesServicio(AppDbContext context)
        {
            _context = context;
        }

        public async Task InscribirAlumnoAsync(InscripcionDTO inscripcionDTO)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.Inscripciones_Inscribir @AlumnoId = {0}, @EscuelaId = {1}",
                inscripcionDTO.AlumnoId,
                inscripcionDTO.EscuelaId
            );
        }

        public async Task AsignarAlumnoAProfesorAsync(AsignacionAlumnoProfesorDTO asignacionAlumnoProfesorDTO)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.AlumnoProfesor_Asignar @AlumnoId = {0}, @ProfesorId = {1}",
                asignacionAlumnoProfesorDTO.AlumnoId,
                asignacionAlumnoProfesorDTO.ProfesorId
            );
        }

        public async Task<List<EscuelaYAlumnosDTO>> ObtenerEscuelasYAlumnosPorProfesorAsync(int profesorId)
        {
            return await _context.Set<EscuelaYAlumnosDTO>()
                .FromSqlRaw("EXEC dbo.Consultar_EscuelasYAlumnosPorProfesor @ProfesorId = {0}", profesorId)
                .ToListAsync();
        }
    }
}
