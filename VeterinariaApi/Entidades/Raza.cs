namespace VeterinariaApi.Entidades;

public class Raza
{
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public int TipoAnimalId { get; set; }
    public TipoAnimal? TipoAnimal { get; set; }
}