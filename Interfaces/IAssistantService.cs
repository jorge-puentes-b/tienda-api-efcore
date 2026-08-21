using tienda_api_efcore.DTOs;

namespace tienda_api_efcore.Interfaces;

public interface IAssistantService
{
    Task<ChatResponseDto> ConsultarAsistenteAsync(ChatRequestDto peticion);
}
