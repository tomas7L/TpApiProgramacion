using VeterinariaApi.Logica;
using VeterinariaApi.Logica.DTOs;
using VeterinariaApi.Entidades;

namespace VeterinariaApi.Endpoints;

public static class TratamientoEndpoints
{
    public static void MapTratamientoEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/tratamientos", async (ITratamientoLogica tratamientoLogica) =>
        {
            var tratamientos = await tratamientoLogica.ObtenerTodos();
            return Results.Ok(tratamientos);
        });

        app.MapGet("/api/tratamientos/{id}", async (int id, ITratamientoLogica tratamientoLogica) =>
        {
            var tratamiento = await tratamientoLogica.ObtenerPorId(id);
            return tratamiento is null ? Results.NotFound() : Results.Ok(tratamiento);
        });

        app.MapPost("/api/tratamientos", async (CrearTratamientoDto tratamientoDTO, ITratamientoLogica tratamientoLogica) =>
        {
            var tratamiento = new Tratamiento
            {
                Nombre = tratamientoDTO.Nombre,
                Descripcion = tratamientoDTO.Descripcion,
                AnimalId = tratamientoDTO.AnimalId
            };

            await tratamientoLogica.Agregar(tratamiento);
            return Results.Created($"/api/tratamientos/{tratamiento.Id}", tratamiento);
        });

        app.MapPut("/api/tratamientos/{id}", async (int id, ActualizarTratamientoDto tratamientoDTO, ITratamientoLogica tratamientoLogica) =>
        {
            var existingTratamiento = await tratamientoLogica.ObtenerPorId(id);
            if (existingTratamiento is null)
            {
                return Results.NotFound();
            }

            existingTratamiento.Nombre = tratamientoDTO.Nombre;
            existingTratamiento.Descripcion = tratamientoDTO.Descripcion;
            existingTratamiento.AnimalId = tratamientoDTO.AnimalId;

            await tratamientoLogica.Actualizar(existingTratamiento);
            return Results.NoContent();
        });

        app.MapDelete("/api/tratamientos/{id}", async (int id, ITratamientoLogica tratamientoLogica) =>
        {
            var existingTratamiento = await tratamientoLogica.ObtenerPorId(id);
            if (existingTratamiento is null)
            {
                return Results.NotFound();
            }

            await tratamientoLogica.Eliminar(existingTratamiento);
            return Results.NoContent();
        });
    }
}
