using System.Data.Entity;
using PersonasService.Domain.Entities;

namespace PersonasService.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection") { }

        public DbSet<Persona> Personas { get; set; }
    }
}
