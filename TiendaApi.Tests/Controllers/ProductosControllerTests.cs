using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using tienda_api_efcore.Controllers;
using tienda_api_efcore.DTOs;
using tienda_api_efcore.Interfaces;
using Xunit;

namespace TiendaApi.Tests.Controllers;

public class ProductosControllerTests
{
    private readonly Mock<IProductoService> _productoServiceMock;
    private readonly ProductosController _controller;

    public ProductosControllerTests()
    {
        _productoServiceMock = new Mock<IProductoService>();
        _controller = new ProductosController(_productoServiceMock.Object);
    }

    [Fact]
    public async Task GetAll_ReturnsOkWithProducts()
    {
        // Arrange
        var mockProducts = new List<ProductoResponseDto>
        {
            new ProductoResponseDto { Id = 1, Nombre = "Producto 1", Precio = 10 }
        };
        _productoServiceMock.Setup(s => s.GetAllAsync()).ReturnsAsync(mockProducts);

        // Act
        var result = await _controller.GetAll();

        // Assert
        var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
        okResult.Value.Should().BeEquivalentTo(mockProducts);
    }

    [Fact]
    public async Task GetById_ReturnsOk_WhenProductExists()
    {
        // Arrange
        var mockProduct = new ProductoResponseDto { Id = 1, Nombre = "Producto 1", Precio = 10 };
        _productoServiceMock.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(mockProduct);

        // Act
        var result = await _controller.GetById(1);

        // Assert
        var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
        okResult.Value.Should().BeEquivalentTo(mockProduct);
    }

    [Fact]
    public async Task GetById_ReturnsNotFound_WhenProductDoesNotExist()
    {
        // Arrange
        _productoServiceMock.Setup(s => s.GetByIdAsync(1)).ReturnsAsync((ProductoResponseDto?)null);

        // Act
        var result = await _controller.GetById(1);

        // Assert
        result.Result.Should().BeOfType<NotFoundResult>();
    }
    [Theory]
    [InlineData(null)]
    public async Task CreateProducto_ReturnsBadRequest_WhenProductoIsNull(ProductoRequestDto producto)
    {
        // Act
        var result = await _controller.CreateProducto(producto);

        // Assert
        result.Result.Should().BeOfType<BadRequestObjectResult>();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task UpdateProducto_ReturnsBadRequest_WhenProductoIdIsInvalid(int productoId)
    {
        // Act
        var result = await _controller.UpdateProducto(productoId, new ProductoRequestDto());

        // Assert
        result.Result.Should().BeOfType<BadRequestObjectResult>();
    }
}
