namespace VeterinariaApi.Logica.DTOs;

public record TratamientoDto
(
    int Id,
    string Nombre,
    string Descripcion,
    int AnimalId
);

public record CrearTratamientoDto
(
    string Nombre,
    string Descripcion,
    int AnimalId
);

public record ActualizarTratamientoDto
(
    string Nombre,
    string Descripcion,
    int AnimalId
);

public record EliminarTratamientoDto
(
    int Id
);