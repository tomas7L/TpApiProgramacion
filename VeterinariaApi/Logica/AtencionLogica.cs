using VeterinariaApi.Entidades;
using VeterinariaApi.Logica.DTOs;
using VeterinariaApi.Repositorios;

namespace VeterinariaApi.Logica;

public interface IAtencionLogica
{
    Task<IEnumerable<Atencion>> ObtenerTodos();
    Task Agregar(Atencion atencion);
    Task Actualizar(Atencion atencion);
    Task Eliminar(Atencion atencion);
    Task<Atencion> ObtenerPorId(int id);
}

public class AtencionLogica : IAtencionLogica
{
    private readonly IAtencionRepository _atencionRepository;

    public AtencionLogica(IAtencionRepository atencionRepository)
    {
        _atencionRepository = atencionRepository;
    }

    public async Task<IEnumerable<Atencion>> ObtenerTodos()
    {
        return await _atencionRepository.ObtenerTodos();
    }

    public async Task Agregar(Atencion atencion)
    {
        await _atencionRepository.Agregar(atencion);
    }

    public async Task Actualizar(Atencion atencion)
    {
        await _atencionRepository.Actualizar(atencion);
    }

    public async Task Eliminar(Atencion atencion)
    {
        await _atencionRepository.Eliminar(atencion);
    }

    public async Task<Atencion> ObtenerPorId(int id)
    {
        return await _atencionRepository.ObtenerPorId(id);
    }
}