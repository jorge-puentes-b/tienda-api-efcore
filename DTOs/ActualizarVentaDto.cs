using System.ComponentModel.DataAnnotations;
namespace tienda_api_efcore.DTOs
{
    public class ActualizarVentaDto{
    //Anotaciones con Data Annotation
    [Required]
    public int Id { get; set; }
    
    [Required]
    public int ClienteId { get; set; }
    
    [Required]
    public DateTime FechaVenta { get; set; }
    
    [Required]
    public decimal Total { get; set; }
    }
}   
