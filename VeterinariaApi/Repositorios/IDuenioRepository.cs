namespace VeterinariaApi.Repositorios
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using VeterinariaApi.Entidades;

    public interface IDuenioRepository
    {
        Task<IEnumerable<Duenio>> ObtenerTodos();
        Task Agregar(Duenio duenio);
        Task Actualizar(Duenio duenio);
        Task Eliminar(Duenio duenio);
        Task<Duenio> ObtenerPorId(int id);
    }
}