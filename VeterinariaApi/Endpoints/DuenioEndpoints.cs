using VeterinariaApi.Logica;
using VeterinariaApi.Logica.DTOs;
using VeterinariaApi.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace VeterinariaApi.Endpoints;

public static class DuenioEndpoints
{
    public static void MapDuenioEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/duenios", async (IDuenioLogica duenioLogica) =>
        {
            var duenios = await duenioLogica.ObtenerTodos();
            return Results.Ok(duenios);
        });

        app.MapGet("/api/duenios/{id}", async (int id, IDuenioLogica duenioLogica) =>
        {
            var duenio = await duenioLogica.ObtenerPorId(id);
            return duenio is null ? Results.NotFound() : Results.Ok(duenio);
        });

        app.MapPost("/api/duenios", async (CrearDuenioDto duenioDTO, IDuenioLogica duenioLogica) =>
        {
            var duenio = new Duenio
            {
                Nombre = duenioDTO.Nombre,
                Telefono = duenioDTO.Telefono,
                Apellido = duenioDTO.Apellido
            };

            await duenioLogica.Agregar(duenio);
            return Results.Created($"/api/duenios/{duenio.Id}", duenio);
        });

        app.MapPut("/api/duenios/{id}", async (int id, ActualizarDuenioDto duenioDTO, IDuenioLogica duenioLogica) =>
        {
            var existingDuenio = await duenioLogica.ObtenerPorId(id);
            if (existingDuenio is null)
            {
                return Results.NotFound();
            }

            existingDuenio.Nombre = duenioDTO.Nombre;
            existingDuenio.Telefono = duenioDTO.Telefono;
            existingDuenio.Apellido = duenioDTO.Apellido;

            await duenioLogica.Actualizar(existingDuenio);
            return Results.NoContent();
        });

        app.MapDelete("/api/duenios/{id}", async (int id, IDuenioLogica duenioLogica) =>
        {
            var existingDuenio = await duenioLogica.ObtenerPorId(id);
            if (existingDuenio is null)
            {
                return Results.NotFound();
            }

            await duenioLogica.Eliminar(existingDuenio);
            return Results.NoContent();
        });
    }
}