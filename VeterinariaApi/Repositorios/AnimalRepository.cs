using Microsoft.EntityFrameworkCore;
using VeterinariaApi.Datos;
using VeterinariaApi.Entidades;

namespace VeterinariaApi.Repositorios;


public class AnimalRepository : IAnimalRepository
{
    private readonly AppDbContext _db;

    public AnimalRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Animal>> ObtenerTodos()
    {
        return await _db.Animales.ToListAsync();
    }

    public async Task Agregar(Animal animal)
    {
        _db.Animales.Add(animal);

        await _db.SaveChangesAsync();
    }

    public async Task Actualizar(Animal animal)
    {
        _db.Animales.Update(animal);
        await _db.SaveChangesAsync();
    }

    public async Task Eliminar(Animal animal)
    {
        _db.Animales.Remove(animal);
        await _db.SaveChangesAsync();
    }

    public async Task<Animal> ObtenerPorId(int id)
    {
        return await _db.Animales.FindAsync(id);
    }
}