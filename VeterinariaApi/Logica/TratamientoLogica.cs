using VeterinariaApi.Repositorios;
using VeterinariaApi.Entidades;

namespace VeterinariaApi.Logica;

public interface ITratamientoLogica
{
    Task<IEnumerable<Tratamiento>> ObtenerTodos();
    Task Agregar(Tratamiento tratamiento);
    Task Actualizar(Tratamiento tratamiento);
    Task Eliminar(Tratamiento tratamiento);
    Task<Tratamiento> ObtenerPorId(int id);
}

public class TratamientoLogica : ITratamientoLogica
{
    private readonly ITratamientoRepository _tratamientoRepository;

    public TratamientoLogica(ITratamientoRepository tratamientoRepository)
    {
        _tratamientoRepository = tratamientoRepository;
    }

    public async Task<IEnumerable<Tratamiento>> ObtenerTodos()
    {
        return await _tratamientoRepository.ObtenerTodos();
    }

    public async Task Agregar(Tratamiento tratamiento)
    {
        await _tratamientoRepository.Agregar(tratamiento);
    }

    public async Task Actualizar(Tratamiento tratamiento)
    {
        await _tratamientoRepository.Actualizar(tratamiento);
    }

    public async Task Eliminar(Tratamiento tratamiento)
    {
        await _tratamientoRepository.Eliminar(tratamiento);
    }

    public async Task<Tratamiento> ObtenerPorId(int id)
    {
        return await _tratamientoRepository.ObtenerPorId(id);
    }
}