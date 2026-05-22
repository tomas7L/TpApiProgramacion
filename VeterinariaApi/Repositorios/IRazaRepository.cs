namespace VeterinariaApi.Repositorios
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using VeterinariaApi.Entidades;

    public interface IRazaRepository
    {
        Task<IEnumerable<Raza>> ObtenerTodos();
        Task Agregar(Raza raza);
        Task Actualizar(Raza raza);
        Task Eliminar(Raza raza);
        Task<Raza> ObtenerPorId(int id);
    }
}