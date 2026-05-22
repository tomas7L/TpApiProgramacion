using VeterinariaApi.Repositorios;
using VeterinariaApi.Entidades;

namespace VeterinariaApi.Logica;

public interface ITipoAnimalLogica
{
    Task<IEnumerable<TipoAnimal>> ObtenerTodos();
    Task Agregar(TipoAnimal tipoAnimal);
    Task Actualizar(TipoAnimal tipoAnimal);
    Task Eliminar(TipoAnimal tipoAnimal);
    Task<TipoAnimal> ObtenerPorId(int id);
}

public class TipoAnimalLogica : ITipoAnimalLogica
{
    private readonly ITipoAnimalRepository _tipoAnimalRepository;

    public TipoAnimalLogica(ITipoAnimalRepository tipoAnimalRepository)
    {
        _tipoAnimalRepository = tipoAnimalRepository;
    }

    public async Task<IEnumerable<TipoAnimal>> ObtenerTodos()
    {
        return await _tipoAnimalRepository.ObtenerTodos();
    }

    public async Task Agregar(TipoAnimal tipoAnimal)
    {
        await _tipoAnimalRepository.Agregar(tipoAnimal);
    }

    public async Task Actualizar(TipoAnimal tipoAnimal)
    {
        await _tipoAnimalRepository.Actualizar(tipoAnimal);
    }

    public async Task Eliminar(TipoAnimal tipoAnimal)
    {
        await _tipoAnimalRepository.Eliminar(tipoAnimal);
    }

    public async Task<TipoAnimal> ObtenerPorId(int id)
    {
        return await _tipoAnimalRepository.ObtenerPorId(id);
    }
}