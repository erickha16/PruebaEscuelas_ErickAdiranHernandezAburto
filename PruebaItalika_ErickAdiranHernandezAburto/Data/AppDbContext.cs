using Microsoft.EntityFrameworkCore;
using PruebaItalika_ErickAdiranHernandezAburto.DTOs;

namespace PruebaItalika_ErickAdiranHernandezAburto.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AlumnoDTO> Alumnos { get; set; }

        public DbSet<EscuelaDTO> Escuelas { get; set; }

        public DbSet<ProfesorDTO> Profesores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Marcamos todos los DTOs como sin clave porque no representan una tabla real
            modelBuilder.Entity<AlumnoDTO>().HasNoKey();
            modelBuilder.Entity<EscuelaDTO>().HasNoKey();
            modelBuilder.Entity<ProfesorDTO>().HasNoKey();
        }
    }
}
