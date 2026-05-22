using Microsoft.EntityFrameworkCore;
using VeterinariaApi.Datos;
using VeterinariaApi.Entidades;

namespace VeterinariaApi.Repositorios;

public class TratamientoRepository : ITratamientoRepository
{
    private readonly AppDbContext _db;

    public TratamientoRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Tratamiento>> ObtenerTodos()
    {
        return await _db.Tratamientos.ToListAsync();
    }

    public async Task Agregar(Tratamiento tratamiento)
    {
        _db.Tratamientos.Add(tratamiento);

        await _db.SaveChangesAsync();
    }

    public async Task Actualizar(Tratamiento tratamiento)
    {
        _db.Tratamientos.Update(tratamiento);
        await _db.SaveChangesAsync();
    }

    public async Task Eliminar(Tratamiento tratamiento)
    {
        _db.Tratamientos.Remove(tratamiento);
        await _db.SaveChangesAsync();
    }

    public async Task<Tratamiento> ObtenerPorId(int id)
    {
        return await _db.Tratamientos.FindAsync(id);
    }
}