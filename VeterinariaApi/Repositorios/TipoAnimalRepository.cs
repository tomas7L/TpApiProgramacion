using Microsoft.EntityFrameworkCore;
using VeterinariaApi.Datos;
using VeterinariaApi.Entidades;

namespace VeterinariaApi.Repositorios;

public class TipoAnimalRepository : ITipoAnimalRepository
{
    private readonly AppDbContext _db;

    public TipoAnimalRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<TipoAnimal>> ObtenerTodos()
    {
        return await _db.TiposAnimales.ToListAsync();
    }

    public async Task Agregar(TipoAnimal tipoAnimal)
    {
        _db.TiposAnimales.Add(tipoAnimal);

        await _db.SaveChangesAsync();
    }

    public async Task Actualizar(TipoAnimal tipoAnimal)
    {
        _db.TiposAnimales.Update(tipoAnimal);
        await _db.SaveChangesAsync();
    }

    public async Task Eliminar(TipoAnimal tipoAnimal)
    {
        _db.TiposAnimales.Remove(tipoAnimal);
        await _db.SaveChangesAsync();
    }

    public async Task<TipoAnimal> ObtenerPorId(int id)
    {
        return await _db.TiposAnimales.FindAsync(id);
    }
}