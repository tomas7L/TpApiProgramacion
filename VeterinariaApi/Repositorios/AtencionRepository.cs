using Microsoft.EntityFrameworkCore;
using VeterinariaApi.Datos;
using VeterinariaApi.Entidades;

namespace VeterinariaApi.Repositorios;

public class AtencionRepository : IAtencionRepository
{
    private readonly AppDbContext _db;

    public AtencionRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Atencion>> ObtenerTodos()
    {
        return await _db.Atenciones.ToListAsync();
    }

    public async Task Agregar(Atencion atencion)
    {
        _db.Atenciones.Add(atencion);

        await _db.SaveChangesAsync();
    }

    public async Task Actualizar(Atencion atencion)
    {
        _db.Atenciones.Update(atencion);
        await _db.SaveChangesAsync();
    }

    public async Task Eliminar(Atencion atencion)
    {
        _db.Atenciones.Remove(atencion);
        await _db.SaveChangesAsync();
    }

    public async Task<Atencion> ObtenerPorId(int id)
    {
        return await _db.Atenciones.FindAsync(id);
    }
}