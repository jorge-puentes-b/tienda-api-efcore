using System.ComponentModel.DataAnnotations;
namespace tienda_api_efcore.DTOs
{
    public class CrearDetalleVentaDto{
    //Anotaciones con Data Annotation
    [Required]
    public int VentaId { get; set; }
    
    [Required]
    public int ProductoId { get; set; }
    
    [Required]
    public int Cantidad { get; set; }
    
    [Required]
    public decimal PrecioUnitario { get; set; }
    }
}   