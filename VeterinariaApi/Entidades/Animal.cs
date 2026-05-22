namespace VeterinariaApi.Entidades;

public class Animal
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Especie { get; set; }
    public string Raza { get; set; }
    public int Edad { get; set; }
    public string Propietario { get; set; }
    public int TipoAnimalId { get; set; }
    public TipoAnimal? TipoAnimal { get; set; }
    public int DuenioId { get; set; }
    public Duenio? Duenio { get; set; }
}