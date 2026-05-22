using Microsoft.EntityFrameworkCore;
using VeterinariaApi.Datos;
using VeterinariaApi.Entidades;

namespace VeterinariaApi.Repositorios;

public class RazaRepository : IRazaRepository
{
    private readonly AppDbContext _db;

    public RazaRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Raza>> ObtenerTodos()
    {
        return await _db.Razas.ToListAsync();
    }

    public async Task Agregar(Raza raza)
    {
        _db.Razas.Add(raza);

        await _db.SaveChangesAsync();
    }

    public async Task Actualizar(Raza raza)
    {
        _db.Razas.Update(raza);
        await _db.SaveChangesAsync();
    }

    public async Task Eliminar(Raza raza)
    {
        _db.Razas.Remove(raza);
        await _db.SaveChangesAsync();
    }

    public async Task<Raza> ObtenerPorId(int id)
    {
        return await _db.Razas.FindAsync(id);
    }
}