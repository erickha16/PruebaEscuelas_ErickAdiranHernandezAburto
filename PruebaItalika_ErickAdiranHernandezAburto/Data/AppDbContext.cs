using Microsoft.EntityFrameworkCore;

namespace PruebaItalika_ErickAdiranHernandezAburto.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
