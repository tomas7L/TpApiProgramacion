using VeterinariaApi.Logica;
using VeterinariaApi.Logica.DTOs;
using VeterinariaApi.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace VeterinariaApi.Endpoints;

public static class AtencionEndpoints
{
    public static void MapAtencionEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/atenciones", async (IAtencionLogica atencionLogica) =>
        {
            var atenciones = await atencionLogica.ObtenerTodos();
            return Results.Ok(atenciones);
        });

        app.MapGet("/api/atenciones/{id}", async (int id, IAtencionLogica atencionLogica) =>
        {
            var atencion = await atencionLogica.ObtenerPorId(id);
            return atencion is null ? Results.NotFound() : Results.Ok(atencion);
        });

        app.MapPost("/api/atenciones", async (CrearAtencionDto atencionDTO, IAtencionLogica atencionLogica) =>
        {
            var atencion = new Atencion
            {
                Fecha = atencionDTO.Fecha,
                Descripcion = atencionDTO.Descripcion,
                AnimalId = atencionDTO.AnimalId,
                TratamientoId = atencionDTO.TratamientoId
            };

            await atencionLogica.Agregar(atencion);
            return Results.Created($"/api/atenciones/{atencion.Id}", atencion);
        });

        app.MapPut("/api/atenciones/{id}", async (int id, ActualizarAtencionDto atencionDTO, IAtencionLogica atencionLogica) =>
        {
            var existingAtencion = await atencionLogica.ObtenerPorId(id);
            if (existingAtencion is null)
            {
                return Results.NotFound();
            }

            existingAtencion.Fecha = atencionDTO.Fecha;
            existingAtencion.Descripcion = atencionDTO.Descripcion;
            existingAtencion.AnimalId = atencionDTO.AnimalId;
            existingAtencion.TratamientoId = atencionDTO.TratamientoId;

            await atencionLogica.Actualizar(existingAtencion);
            return Results.NoContent();
        });

        app.MapDelete("/api/atenciones/{id}", async (int id, IAtencionLogica atencionLogica) =>
        {
            var existingAtencion = await atencionLogica.ObtenerPorId(id);
            if (existingAtencion is null)
            {
                return Results.NotFound();
            }

            await atencionLogica.Eliminar(existingAtencion);
            return Results.NoContent();
        });
    }
}