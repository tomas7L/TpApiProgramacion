using VeterinariaApi.Entidades;
using VeterinariaApi.Logica.DTOs;
using VeterinariaApi.Repositorios;

namespace VeterinariaApi.Logica;

public interface IRazaLogica
{
    Task<IEnumerable<Raza>> ObtenerTodos();
    Task Agregar(Raza raza);
    Task Actualizar(Raza raza);
    Task Eliminar(Raza raza);
    Task<Raza> ObtenerPorId(int id);
}

public class RazaLogica : IRazaLogica
{
    private readonly IRazaRepository _razaRepository;

    public RazaLogica(IRazaRepository razaRepository)
    {
        _razaRepository = razaRepository;
    }

    public async Task<IEnumerable<Raza>> ObtenerTodos()
    {
        return await _razaRepository.ObtenerTodos();
    }

    public async Task Agregar(Raza raza)
    {
        await _razaRepository.Agregar(raza);
    }

    public async Task Actualizar(Raza raza)
    {
        await _razaRepository.Actualizar(raza);
    }

    public async Task Eliminar(Raza raza)
    {
        await _razaRepository.Eliminar(raza);
    }

    public async Task<Raza> ObtenerPorId(int id)
    {
        return await _razaRepository.ObtenerPorId(id);
    }
}