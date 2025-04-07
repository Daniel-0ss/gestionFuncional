using System.Data.Entity;
using PersonasService.Domain.Entities;


    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection") { }

        public DbSet<Persona> Personas { get; set; }
    }

