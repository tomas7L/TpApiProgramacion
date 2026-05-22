namespace VeterinariaApi.Repositorios
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using VeterinariaApi.Entidades;

    public interface IAtencionRepository
    {
        Task<IEnumerable<Atencion>> ObtenerTodos();
        Task Agregar(Atencion atencion);
        Task Actualizar(Atencion atencion);
        Task Eliminar(Atencion atencion);
        Task<Atencion> ObtenerPorId(int id);
    }
}