using Microsoft.AspNetCore.Mvc;
using tienda_api_efcore.DTOs;
using tienda_api_efcore.Interfaces;

namespace tienda_api_efcore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IAssistantService _assistantService;

    public ChatController(IAssistantService assistantService)
    {
        _assistantService = assistantService;
    }

    [HttpPost]
    public async Task<ActionResult<ChatResponseDto>> Preguntar([FromBody] ChatRequestDto request)
    {
        if (string.IsNullOrWhiteSpace(request.MensajeUsuario))
        {
            return BadRequest("El mensaje no puede estar vacío.");
        }

        var respuesta = await _assistantService.ConsultarAsistenteAsync(request);
        return Ok(respuesta);
    }
}
