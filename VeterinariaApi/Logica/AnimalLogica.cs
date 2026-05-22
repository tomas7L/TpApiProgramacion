using VeterinariaApi.Entidades;
using VeterinariaApi.Logica.DTOs;
using VeterinariaApi.Repositorios;

namespace VeterinariaApi.Logica;

public interface IAnimalLogica
{
    Task<IEnumerable<Animal>> ObtenerTodos();
    Task<Animal> ObtenerPorId(int id);
    Task Agregar(Animal animal);
    Task Actualizar(Animal animal);
    Task Eliminar(Animal animal);
}

public class AnimalLogica : IAnimalLogica
{
    private readonly IAnimalRepository _animalRepository;

    public AnimalLogica(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public async Task<IEnumerable<Animal>> ObtenerTodos()
    {
        return await _animalRepository.ObtenerTodos();
    }

    public async Task Agregar(Animal animal)
    {
        await _animalRepository.Agregar(animal);
    }

    public async Task Actualizar(Animal animal)
    {
        await _animalRepository.Actualizar(animal);
    }

    public async Task Eliminar(Animal animal)
    {
        await _animalRepository.Eliminar(animal);
    }

    public async Task<Animal> ObtenerPorId(int id)
    {
        return await _animalRepository.ObtenerPorId(id);
    }
}