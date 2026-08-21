using System.ComponentModel.DataAnnotations;
namespace tienda_api_efcore.DTOs;

public class ProductoResponseDto
{
    //Anotaciones con Data Annotation
    [Required]
    public int Id { get; set; }
    [Required]
    public string Nombre { get; set; } = string.Empty;
    [Required]
    public string Descripcion { get; set; } = string.Empty;
    [Required]
    public decimal Precio { get; set; }
    [Required]
    public int Stock { get; set; }
    
    // Datos de la categoría que interesan al cliente:
    public int CategoriaId { get; set; }
    public string? CategoriaNombre { get; set; }
}
