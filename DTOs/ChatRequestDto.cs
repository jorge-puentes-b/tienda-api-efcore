using System.ComponentModel.DataAnnotations;

namespace tienda_api_efcore.DTOs;

public class ChatRequestDto
{
    [Required]
    public string MensajeUsuario { get; set; } = string.Empty;
}
