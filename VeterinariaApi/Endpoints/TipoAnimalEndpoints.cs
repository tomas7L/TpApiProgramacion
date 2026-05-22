using VeterinariaApi.Logica;
using VeterinariaApi.Logica.DTOs;
using VeterinariaApi.Entidades;
using System.Net;

namespace VeterinariaApi.Endpoints;

public static class TipoAnimalEndpoints
{
    public static void MapTipoAnimalEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/tipos-animales", async (ITipoAnimalLogica tipoAnimalLogica) =>
        {
            var tiposAnimales = await tipoAnimalLogica.ObtenerTodos();
            return Results.Ok(tiposAnimales);
        });

        app.MapGet("/api/tipos-animales/{id}", async (int id, ITipoAnimalLogica tipoAnimalLogica) =>
        {
            var tipoAnimal = await tipoAnimalLogica.ObtenerPorId(id);
            return tipoAnimal is null ? Results.NotFound() : Results.Ok(tipoAnimal);
        });

        app.MapPost("/api/tipos-animales", async (CrearTipoAnimalDto tipoAnimalDTO, ITipoAnimalLogica tipoAnimalLogica) =>
        {
            var tipoAnimal = new TipoAnimal
            {
                Descripcion = tipoAnimalDTO.Descripcion
            };

            await tipoAnimalLogica.Agregar(tipoAnimal);
            return Results.Created($"/api/tipos-animales/{tipoAnimal.Id}", tipoAnimal);
        });

        app.MapPut("/api/tipos-animales/{id}", async (int id, ActualizarTipoAnimalDto tipoAnimalDTO, ITipoAnimalLogica tipoAnimalLogica) =>
        {
            var existingTipoAnimal = await tipoAnimalLogica.ObtenerPorId(id);
            if (existingTipoAnimal is null)
            {
                return Results.NotFound();
            }

            existingTipoAnimal.Descripcion = tipoAnimalDTO.Descripcion;

            await tipoAnimalLogica.Actualizar(existingTipoAnimal);
            return Results.NoContent();
        });

        app.MapDelete("/api/tipos-animales/{id}", async (int id, ITipoAnimalLogica tipoAnimalLogica) =>
        {
            var existingTipoAnimal = await tipoAnimalLogica.ObtenerPorId(id);
            if (existingTipoAnimal is null)
            {
                return Results.NotFound();
            }

            await tipoAnimalLogica.Eliminar(existingTipoAnimal);
            return Results.NoContent();
        });
    }
}