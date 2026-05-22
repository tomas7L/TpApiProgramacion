namespace VeterinariaApi.Logica.DTOs;

public record RazaDto
(
    int Id,
    string Descripcion,
    int TipoAnimalId
);

public record CrearRazaDto
(
    string Descripcion,
    int TipoAnimalId
);

public record ActualizarRazaDto
(
    string Descripcion,
    int TipoAnimalId
);

public record EliminarRazaDto
(
    int Id
);