using System.Data.Entity;
using CitasService.Domain.Entities;

namespace CitasService.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection") { }

        public DbSet<Cita> Citas { get; set; }
    }
}
