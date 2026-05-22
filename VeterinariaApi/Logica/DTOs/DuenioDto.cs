namespace VeterinariaApi.Logica.DTOs;

public record DuenioDto
(
    int Id,
    string Nombre,
    string Telefono,
    string Apellido
);

public record CrearDuenioDto
(
    string Nombre,
    string Telefono,
    string Apellido
);

public record ActualizarDuenioDto
(
    string Nombre,
    string Telefono,
    string Apellido
);

public record EliminarDuenioDto
(
    int Id
);