namespace tienda_api_efcore.Models;

public class Stock{
    public int Id { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    public DateTime FechaActualizacion { get; set; } = DateTime.Now;
    public Producto? Producto { get; set; }
}