using VeterinariaApi.Entidades;
using VeterinariaApi.Logica.DTOs;
using VeterinariaApi.Repositorios;

namespace VeterinariaApi.Logica;

public interface IDuenioLogica
{
    Task<IEnumerable<Duenio>> ObtenerTodos();
    Task Agregar(Duenio duenio);
    Task Actualizar(Duenio duenio);
    Task Eliminar(Duenio duenio);
    Task<Duenio> ObtenerPorId(int id);
}

public class DuenioLogica : IDuenioLogica
{
    private readonly IDuenioRepository _duenioRepository;

    public DuenioLogica(IDuenioRepository duenioRepository)
    {
        _duenioRepository = duenioRepository;
    }

    public async Task<IEnumerable<Duenio>> ObtenerTodos()
    {
        return await _duenioRepository.ObtenerTodos();
    }

    public async Task Agregar(Duenio duenio)
    {
        await _duenioRepository.Agregar(duenio);
    }

    public async Task Actualizar(Duenio duenio)
    {
        await _duenioRepository.Actualizar(duenio);
    }

    public async Task Eliminar(Duenio duenio)
    {
        await _duenioRepository.Eliminar(duenio);
    }

    public async Task<Duenio> ObtenerPorId(int id)
    {
        return await _duenioRepository.ObtenerPorId(id);
    }
}