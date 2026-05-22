namespace VeterinariaApi.Repositorios
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using VeterinariaApi.Entidades;
    public interface IAnimalRepository
    {
        Task<IEnumerable<Animal>> ObtenerTodos();
        Task<Animal> ObtenerPorId(int id);
        Task Agregar(Animal animal);
        Task Actualizar(Animal animal);
        Task Eliminar(Animal animal);
    }
}