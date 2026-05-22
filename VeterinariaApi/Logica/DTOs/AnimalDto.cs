namespace VeterinariaApi.Logica.DTOs;

public record AnimalDto
(
    int Id,
    string Nombre,
    string Especie,
    string Raza,
    int Edad,
    string Propietario,
    int TipoAnimalId,
    int DuenioId
);

public record CrearAnimalDto
(
    string Nombre,
    string Especie,
    string Raza,
    int Edad,
    string Propietario,
    int TipoAnimalId,
    int DuenioId
);

public record ActualizarAnimalDto
(
    string Nombre,
    string Especie,
    string Raza,
    int Edad,
    string Propietario,
    int TipoAnimalId,
    int DuenioId
);

public record EliminarAnimalDto
(
    int Id
);

