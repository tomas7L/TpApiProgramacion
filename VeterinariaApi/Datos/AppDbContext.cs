using Microsoft.EntityFrameworkCore;
using VeterinariaApi.Entidades;
namespace VeterinariaApi.Datos;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Animal> Animales => Set<Animal>();
    public DbSet<TipoAnimal> TiposAnimales => Set<TipoAnimal>();
    public DbSet<Tratamiento> Tratamientos => Set<Tratamiento>();
    public DbSet<Duenio> Duenios => Set<Duenio>();
    public DbSet<Raza> Razas => Set<Raza>();
    public DbSet<Atencion> Atenciones => Set<Atencion>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    modelBuilder.Entity<Atencion>()
        .HasOne(a => a.Animal)
        .WithMany()
        .HasForeignKey(a => a.AnimalId)
        .OnDelete(DeleteBehavior.NoAction);

    modelBuilder.Entity<Atencion>()
        .HasOne(a => a.Tratamiento)
        .WithMany()
        .HasForeignKey(a => a.TratamientoId)
        .OnDelete(DeleteBehavior.NoAction);
    }
}