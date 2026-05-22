namespace VeterinariaApi.Repositorios
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using VeterinariaApi.Entidades;
    public interface ITipoAnimalRepository
    {
        Task<IEnumerable<TipoAnimal>> ObtenerTodos();

        Task Agregar(TipoAnimal tipoAnimal);
        Task Actualizar(TipoAnimal tipoAnimal);
        Task Eliminar(TipoAnimal tipoAnimal);
        Task<TipoAnimal> ObtenerPorId(int id);
    }
}