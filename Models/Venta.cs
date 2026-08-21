namespace tienda_api_efcore.Models;
public class Venta{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public DateTime FechaVenta { get; set; } = DateTime.Now;
    public decimal Total { get; set; }
    public Cliente? Cliente { get; set; }
    public List<DetalleVenta>? VentaDetalles { get; set; }
}