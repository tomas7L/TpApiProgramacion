using VeterinariaApi.Logica;
using VeterinariaApi.Logica.DTOs;
using VeterinariaApi.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace VeterinariaApi.Endpoints;

public static class AnimalEndpoints
{
    public static void MapAnimalEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/animales", async (IAnimalLogica animalLogica) =>
        {
            var animales = await animalLogica.ObtenerTodos();
            return Results.Ok(animales);
        });

        app.MapGet("/api/animales/{id}", async (int id, IAnimalLogica animalLogica) =>
        {
            var animal = await animalLogica.ObtenerPorId(id);
            return animal is null ? Results.NotFound() : Results.Ok(animal);
        });

        app.MapPost("/api/animales", async (CrearAnimalDto animalDTO, IAnimalLogica animalLogica) =>
        {
            var animal = new Animal
            {
                Nombre = animalDTO.Nombre,
                Especie = animalDTO.Especie,
                Raza = animalDTO.Raza,
                Edad = animalDTO.Edad,
                Propietario = animalDTO.Propietario,
                TipoAnimalId = animalDTO.TipoAnimalId,
                DuenioId = animalDTO.DuenioId
            };

            await animalLogica.Agregar(animal);
            return Results.Created($"/api/animales/{animal.Id}", animal);
        });

        app.MapPut("/api/animales/{id}", async (int id, ActualizarAnimalDto animalDTO, IAnimalLogica animalLogica) =>
        {
            var existingAnimal = await animalLogica.ObtenerPorId(id);
            if (existingAnimal is null)
            {
                return Results.NotFound();
            }

            existingAnimal.Nombre = animalDTO.Nombre;
            existingAnimal.Especie = animalDTO.Especie;
            existingAnimal.Raza = animalDTO.Raza;
            existingAnimal.Edad = animalDTO.Edad;
            existingAnimal.Propietario = animalDTO.Propietario;
            existingAnimal.TipoAnimalId = animalDTO.TipoAnimalId;
            existingAnimal.DuenioId = animalDTO.DuenioId;

            await animalLogica.Actualizar(existingAnimal);
            return Results.NoContent();
        });

        app.MapDelete("/api/animales/{id}", async (int id, IAnimalLogica animalLogica) =>
        {
            var existingAnimal = await animalLogica.ObtenerPorId(id);
            if (existingAnimal is null)
            {
                return Results.NotFound();
            }

            await animalLogica.Eliminar(existingAnimal);
            return Results.NoContent();
        });
    }

}
