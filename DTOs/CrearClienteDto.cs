using System.ComponentModel.DataAnnotations;
namespace tienda_api_efcore.DTOs
{
    public class CrearClienteDto{
    //Anotaciones con Data Annotation
    [StringLength(100)]
    [Required]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(150)]
    [EmailAddress]
    [Required]
    public string Email { get; set; } = string.Empty;

    [StringLength(20)]
    public string Telefono { get; set; } = string.Empty;

    [StringLength(200)]
    public string Direccion { get; set; } = string.Empty;

    public bool EstaActivo { get; set; } = true;
    }    
}       