namespace VeterinariaApi.Repositorios
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using VeterinariaApi.Entidades;

    public interface ITratamientoRepository
    {
        Task<IEnumerable<Tratamiento>> ObtenerTodos();
        Task<Tratamiento> ObtenerPorId(int id);
        Task Agregar(Tratamiento tratamiento);
        Task Actualizar(Tratamiento tratamiento);
        Task Eliminar(Tratamiento tratamiento);
    }
}