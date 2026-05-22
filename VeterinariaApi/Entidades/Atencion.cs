namespace VeterinariaApi.Entidades;

public class Atencion
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public string Descripcion { get; set; }
    public int AnimalId { get; set; }
    public Animal? Animal { get; set; }
    public int TratamientoId { get; set; }
    public Tratamiento? Tratamiento { get; set; }
}