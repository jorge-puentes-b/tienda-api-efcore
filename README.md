# 🛒 Tienda API - ASP.NET Core & EF Core con Asistente Virtual AI 🤖

![.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-12.0-239120?logo=csharp&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-14%2B-4169E1?logo=postgresql&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/EF%20Core-8.0-512BD4?logo=nuget&logoColor=white)
![Groq AI](https://img.shields.io/badge/Groq%20AI-Llama%203.3%20%2F%20GPT--OSS-orange?logo=openai&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-OpenAPI%203.0-85EA2D?logo=swagger&logoColor=black)

API RESTful profesional construida con **ASP.NET Core Web API**, **Entity Framework Core**, **PostgreSQL** y un módulo inteligente de **Asistente Virtual con IA (RAG)** integrado con **Groq Cloud / OpenAI SDK**.

---

## 🏛️ Arquitectura del Proyecto

El proyecto implementa una **arquitectura desacoplada en 3 capas** con estricto apego al principio de **Inversión de Dependencias (DIP)**:

```
┌────────────────────────────────────────────────────────┐
│                      Controllers                       │  (Manejo HTTP, Routing, Status Codes)
└───────────────────────────┬────────────────────────────┘
                            │ (Usa DTOs de Entrada y Salida)
┌───────────────────────────▼────────────────────────────┐
│                  Services / Interfaces                 │  (Reglas de negocio y Mapeo)
└─────────────┬────────────────────────────┬─────────────┘
              │ (Usa Models / Entidades)   │ (SDK Inferencia)
┌─────────────▼─────────────┐ ┌────────────▼─────────────┐
│      Data / DbContext     │ │    Groq Cloud / OpenAI    │
│   (Entity Framework Core) │ │  (Asistente Inteligente) │
└─────────────┬─────────────┘ └──────────────────────────┘
              │ (Npgsql Driver)
┌─────────────▼─────────────┐
│    PostgreSQL Database    │
└───────────────────────────┘
```

---

## ✨ Características Principales

- **Arquitectura Limpia:** Separación estricta entre Controladores, Interfaces, Servicios, Modelos y DTOs.
- **Seguridad en Datos (DTOs):** Aislamiento de la base de datos mediante DTOs de entrada (`Crear...Dto`, `Actualizar...Dto`) y DTOs de salida (`...ResponseDto`).
- **Entity Framework Core 8:** 
  - Consultas optimizadas de solo lectura con `.AsNoTracking()`.
  - Proyección eficiente de campos a nivel SQL con `.Select()`.
  - Migraciones y *Seed Data* automático.
- **Inyección de Dependencias (DI):** Ciclos de vida `Scoped` con `Microsoft.Extensions.DependencyInjection` para evitar problemas de concurrencia (*Thread-Safety* en DbContext).
- **Asincronía Total:** Operaciones no bloqueantes de principio a fin con `async / await` y `Task<T>`.
- **Validaciones Declarativas:** Uso de *Data Annotations* (`[Required]`, `[StringLength]`, `[Range]`, `[EmailAddress]`).
- **Asistente Virtual con IA (RAG):** El endpoint `/api/Chat` consulta el catálogo en tiempo real desde PostgreSQL y alimenta el contexto del modelo de lenguaje para dar recomendaciones precisas con precios y stock actualizado.

---

## 🤖 Integración de IA & Métricas de Rendimiento (Groq Cloud)

El asistente inteligente utiliza la infraestructura de **Groq Cloud** para inferencia ultrarrápida en tiempo real con modelos LLM de última generación.

### 📊 Métricas de Inferencia en Producción:

#### 1. Consumo de Tokens (Input vs Output)
El sistema optimiza el envío de tokens serializando únicamente los campos esenciales del catálogo:

![Groq Total Tokens Metrics](docs/images/groq-total-tokens.png)
*(Gráfico de consumo: Monitoreo de Tokens de Entrada y Salida en el Dashboard de Groq)*

#### 2. Tasa de Éxito HTTP (Status Code 200 OK)
Respuestas estables con tiempos de respuesta de milisegundos gracias a la arquitectura asíncrona:

![Groq HTTP Status 200](docs/images/groq-http-status.png)
*(Monitoreo de peticiones exitosas HTTP 200 procesadas por la API)*

---

## 📋 Catálogo de Endpoints RESTful

### 🤖 Asistente Virtual AI
| Método | Endpoint | Descripción | Body JSON |
| :--- | :--- | :--- | :--- |
| **POST** | `/api/Chat` | Preguntar al asistente de compras en lenguaje natural | `{ "mensajeUsuario": "¿Qué laptop me recomiendas?" }` |

### 📦 Productos
| Método | Endpoint | Descripción |
| :--- | :--- | :--- |
| **GET** | `/api/Productos` | Obtiene todos los productos (`ProductoResponseDto`) |
| **GET** | `/api/Productos/{id}` | Obtiene un producto por su ID |
| **POST** | `/api/Productos` | Crea un producto nuevo (`CrearProductosDto`) |
| **PUT** | `/api/Productos/{id}` | Actualiza un producto existente (`ActualizarProductoDto`) |
| **DELETE**| `/api/Productos/{id}` | Elimina un producto |

### 🏷️ Categorías
| Método | Endpoint | Descripción |
| :--- | :--- | :--- |
| **GET** | `/api/Categoria` | Obtiene todas las categorías |
| **GET** | `/api/Categoria/{id}` | Obtiene categoría por ID |
| **POST** | `/api/Categoria` | Crea una categoría (`CrearCategoriaDto`) |
| **PUT** | `/api/Categoria/{id}` | Actualiza una categoría (`ActualizarCategoriaDto`) |
| **DELETE**| `/api/Categoria/{id}` | Elimina una categoría |

### 👤 Clientes
| Método | Endpoint | Descripción |
| :--- | :--- | :--- |
| **GET** | `/api/Cliente` | Lista de clientes registrados |
| **GET** | `/api/Cliente/{id}` | Cliente por ID |
| **POST** | `/api/Cliente` | Registro de nuevo cliente (`CrearClienteDto`) |
| **PUT** | `/api/Cliente/{id}` | Actualización de cliente (`ActualizarClienteDto`) |
| **DELETE**| `/api/Cliente/{id}` | Eliminación de cliente |

---

## 🚀 Instalación y Puesta en Marcha

### Prerrequisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/) (o vía Docker / Laragon)
- Clave de API de [Groq Cloud](https://console.groq.com/) o [Azure AI Foundry](https://ai.azure.com/)

### 1. Clonar el repositorio
```bash
git clone https://github.com/tu-usuario/tienda-api-efcore.git
cd tienda-api-efcore
```

### 2. Configurar `appsettings.json`
Actualiza tu cadena de conexión y credenciales de IA:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=TiendaDb;Username=postgres;Password=tu_password"
  },
  "OpenAI": {
    "Endpoint": "https://api.groq.com/openai/v1",
    "ApiKey": "TU_API_KEY_DE_GROQ",
    "Model": "openai/gpt-oss-20b"
  }
}
```

> 🔒 **Buenas prácticas:** Para desarrollo local puedes usar .NET User Secrets:
> ```bash
> dotnet user-secrets set "OpenAI:ApiKey" "tu_api_key"
> ```

### 3. Aplicar Migraciones en PostgreSQL
```bash
dotnet ef database update
```

### 4. Ejecutar la Aplicación
```bash
dotnet run
```

La API estará disponible en:
- **Swagger UI:** `http://localhost:5134/swagger`
- **Peticiones HTTP directas:** Consulta el archivo [`tienda-api-efcore.http`](./tienda-api-efcore.http).

---

## 🧪 Ejemplo de Consulta al Asistente IA

**Petición:**
```http
POST /api/Chat
Content-Type: application/json

{
  "mensajeUsuario": "¿Qué productos tienes para oficina y cuáles son sus precios?"
}
```

**Respuesta (200 OK):**
```json
{
  "respuestaIA": "¡Hola! En nuestro catálogo actual contamos con los siguientes productos ideales para oficina:\n- Silla de oficina: $50.00 (50 unidades en stock)\n- Mesa de comedor/trabajo: $100.00 (60 unidades en stock)\n- Laptop Gamer Pro: $1,250.00 (8 unidades en stock)\n\n¿Te gustaría más detalles sobre alguno de ellos?"
}
```

---

## 🛠️ Tecnologías y Librerías

- **ASP.NET Core 8 Web API**
- **Entity Framework Core 8** + **Npgsql.EntityFrameworkCore.PostgreSQL**
- **OpenAI .NET SDK 2.x** (Inferencia LLM)
- **Swashbuckle / Swagger** (Documentación OpenAPI interactiva)
- **System.ComponentModel.DataAnnotations** (Validación declarativa)
