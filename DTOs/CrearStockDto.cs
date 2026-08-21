using System.ComponentModel.DataAnnotations;
namespace tienda_api_efcore.DTOs
{
    public class CrearStockDto{
    //Anotaciones con Data Annotation
    [Required]
    public int ProductoId { get; set; }
    
    [Required]
    public int Cantidad { get; set; }
    }
} 