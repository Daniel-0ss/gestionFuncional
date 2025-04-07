using System.Data.Entity;
using RecetasService.Domain.Entities;

public class AppDbContext : DbContext
{
    public AppDbContext() : base("DefaultConnection") { }

    public DbSet<Receta> Recetas { get; set; }
}

