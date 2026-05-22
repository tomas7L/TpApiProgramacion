using Scalar.AspNetCore;
using VeterinariaApi.Datos;
using Microsoft.EntityFrameworkCore;

using VeterinariaApi.Repositorios;
using VeterinariaApi.Logica;
using VeterinariaApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// OpenApi
builder.Services.AddOpenApi();

// DbContext
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);


builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();

builder.Services.AddScoped<IAtencionRepository, AtencionRepository>();

builder.Services.AddScoped<IDuenioRepository, DuenioRepository>();

builder.Services.AddScoped<ITipoAnimalRepository, TipoAnimalRepository>();

builder.Services.AddScoped<IRazaRepository, RazaRepository>();

builder.Services.AddScoped<ITratamientoRepository, TratamientoRepository>();


builder.Services.AddScoped<IAnimalLogica, AnimalLogica>();

builder.Services.AddScoped<IAtencionLogica, AtencionLogica>();

builder.Services.AddScoped<IDuenioLogica, DuenioLogica>();

builder.Services.AddScoped<ITipoAnimalLogica, TipoAnimalLogica>();

builder.Services.AddScoped<IRazaLogica, RazaLogica>();

builder.Services.AddScoped<ITratamientoLogica, TratamientoLogica>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapScalarApiReference();


app.MapAnimalEndpoints();

app.MapAtencionEndpoints();

app.MapDuenioEndpoints();

app.MapTipoAnimalEndpoints();

app.MapRazaEndpoints();

app.MapTratamientoEndpoints();

app.Run();


