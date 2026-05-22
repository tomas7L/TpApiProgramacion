namespace VeterinariaApi.Logica.DTOs;

public record AtencionDto
(
    int Id,
    DateTime Fecha,
    string Descripcion,
    int AnimalId,
    int TratamientoId
);

public record CrearAtencionDto
(
    DateTime Fecha,
    string Descripcion,
    int AnimalId,
    int TratamientoId
);

public record ActualizarAtencionDto
(
    DateTime Fecha,
    string Descripcion,
    int AnimalId,
    int TratamientoId
);

public record EliminarAtencionDto
(
    int Id
);