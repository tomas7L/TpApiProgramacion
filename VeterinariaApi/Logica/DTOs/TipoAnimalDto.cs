namespace VeterinariaApi.Logica.DTOs;

public record TipoAnimalDto
(
    int Id,
    string Descripcion
);

public record CrearTipoAnimalDto
(
    string Descripcion
);

public record ActualizarTipoAnimalDto
(
    string Descripcion
);

public record EliminarTipoAnimalDto
(
    int Id
);