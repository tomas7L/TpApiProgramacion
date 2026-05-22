using Microsoft.EntityFrameworkCore;
using VeterinariaApi.Datos;
using VeterinariaApi.Entidades;

namespace VeterinariaApi.Repositorios;

public class DuenioRepository : IDuenioRepository
{
    private readonly AppDbContext _db;

    public DuenioRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Duenio>> ObtenerTodos()
    {
        return await _db.Duenios.ToListAsync();
    }

    public async Task Agregar(Duenio duenio)
    {
        _db.Duenios.Add(duenio);

        await _db.SaveChangesAsync();
    }

    public async Task Actualizar(Duenio duenio)
    {
        _db.Duenios.Update(duenio);
        await _db.SaveChangesAsync();
    }

    public async Task Eliminar(Duenio duenio)
    {
        _db.Duenios.Remove(duenio);
        await _db.SaveChangesAsync();
    }

    public async Task<Duenio> ObtenerPorId(int id)
    {
        return await _db.Duenios.FindAsync(id);
    }
}