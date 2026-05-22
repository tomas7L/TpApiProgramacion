using VeterinariaApi.Logica;
using VeterinariaApi.Logica.DTOs;
using VeterinariaApi.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace VeterinariaApi.Endpoints;

public static class RazaEndpoints
{
    public static void MapRazaEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/razas", async (IRazaLogica razaLogica) =>
        {
            var razas = await razaLogica.ObtenerTodos();
            return Results.Ok(razas);
        });

        app.MapGet("/api/razas/{id}", async (int id, IRazaLogica razaLogica) =>
        {
            var raza = await razaLogica.ObtenerPorId(id);
            return raza is null ? Results.NotFound() : Results.Ok(raza);
        });

        app.MapPost("/api/razas", async (CrearRazaDto razaDTO, IRazaLogica razaLogica) =>
        {
            var raza = new Raza
            {
                Descripcion = razaDTO.Descripcion,
                TipoAnimalId = razaDTO.TipoAnimalId
            };

            await razaLogica.Agregar(raza);
            return Results.Created($"/api/razas/{raza.Id}", raza);
        });

        app.MapPut("/api/razas/{id}", async (int id, ActualizarRazaDto razaDTO, IRazaLogica razaLogica) =>
        {
            var existingRaza = await razaLogica.ObtenerPorId(id);
            if (existingRaza is null)
            {
                return Results.NotFound();
            }

            existingRaza.Descripcion = razaDTO.Descripcion;
            existingRaza.TipoAnimalId = razaDTO.TipoAnimalId;

            await razaLogica.Actualizar(existingRaza);
            return Results.NoContent();
        });

        app.MapDelete("/api/razas/{id}", async (int id, IRazaLogica razaLogica) =>
        {
            var existingRaza = await razaLogica.ObtenerPorId(id);
            if (existingRaza is null)
            {
                return Results.NotFound();
            }

            await razaLogica.Eliminar(existingRaza);
            return Results.NoContent();
        });
    }
}