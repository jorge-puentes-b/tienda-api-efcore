using System.ClientModel;
using System.Text.Json;
using OpenAI;
using OpenAI.Chat;
using tienda_api_efcore.DTOs;
using tienda_api_efcore.Interfaces;

namespace tienda_api_efcore.Services;

public class AssistantService : IAssistantService
{
    private readonly IProductoService _productoService;
    private readonly ChatClient _chatClient;

    public AssistantService(IProductoService productoService, IConfiguration configuration)
    {
        _productoService = productoService;

        var endpoint = new Uri(configuration["OpenAI:Endpoint"] ?? "https://api.groq.com/openai/v1");
        var apiKey = configuration["OpenAI:ApiKey"] ?? string.Empty;
        var model = configuration["OpenAI:Model"] ?? "openai/gpt-oss-20b";

        var credential = new ApiKeyCredential(apiKey);
        var options = new OpenAIClientOptions { Endpoint = endpoint };
        var openAIClient = new OpenAIClient(credential, options);
        _chatClient = openAIClient.GetChatClient(model);
    }

    public async Task<ChatResponseDto> ConsultarAsistenteAsync(ChatRequestDto peticion)
    {
        // 1. Obtenemos el catálogo en tiempo real desde la BD
        var productos = await _productoService.GetAllAsync();
        var productosJson = JsonSerializer.Serialize(productos);

        // 2. Definimos los mensajes del sistema y del usuario
        var systemMessage = new SystemChatMessage(
            $"Eres el asistente virtual inteligente de nuestra tienda online. " +
            $"Aquí tienes nuestro catálogo de productos en tiempo real en formato JSON: {productosJson}. " +
            $"Instrucciones: " +
            $"1. Responde de forma amable, clara y en español. " +
            $"2. Si te preguntan por recomendaciones o productos, menciona el precio, descripción y el stock disponible. " +
            $"3. Si el producto solicitado no existe en el catálogo, indícalo cortésmente."
        );

        var userMessage = new UserChatMessage(peticion.MensajeUsuario);

        // 3. Llamada al modelo de IA
        ChatCompletion completion = await _chatClient.CompleteChatAsync(new ChatMessage[] { systemMessage, userMessage });

        return new ChatResponseDto
        {
            RespuestaIA = completion.Content[0].Text
        };
    }
}
