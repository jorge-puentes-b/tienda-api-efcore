using System.ComponentModel.DataAnnotations;
namespace tienda_api_efcore.DTOs
{
    public class ActualizarStockDto{
    //Anotaciones con Data Annotation
    [Required]
    public int Id { get; set; }
    
    [Required]
    public int ProductoId { get; set; }
    
    [Required]
    public int Cantidad { get; set; }
    }
}   