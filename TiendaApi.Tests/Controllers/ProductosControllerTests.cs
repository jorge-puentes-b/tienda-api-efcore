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
    [Fact]
    public async Task Create_ReturnsCreatedAtAction_WhenProductIsCreated()
    {
        // Arrange
        var createDto = new CrearProductosDto { Nombre = "Producto 1", Descripcion = "Desc", Precio = 10, Stock = 5, CategoriaId = 1 };
        var createdProduct = new ProductoResponseDto { Id = 1, Nombre = "Producto 1", Precio = 10 };
        _productoServiceMock.Setup(s => s.CreateAsync(createDto)).ReturnsAsync(createdProduct);

        // Act
        var result = await _controller.Create(createDto);

        // Assert
        var createdAtActionResult = result.Result.Should().BeOfType<CreatedAtActionResult>().Subject;
        createdAtActionResult.Value.Should().BeEquivalentTo(createdProduct);
    }

    [Fact]
    public async Task Update_ReturnsNoContent_WhenProductIsUpdated()
    {
        // Arrange
        var updateDto = new ActualizarProductoDto { Id = 1, Nombre = "Producto 1", Descripcion = "Desc", Precio = 10, Stock = 5, CategoriaId = 1 };
        _productoServiceMock.Setup(s => s.UpdateAsync(1, updateDto)).ReturnsAsync(true);

        // Act
        var result = await _controller.Update(1, updateDto);

        // Assert
        result.Should().BeOfType<NoContentResult>();
    }

    [Fact]
    public async Task Update_ReturnsNotFound_WhenProductDoesNotExist()
    {
        // Arrange
        var updateDto = new ActualizarProductoDto { Id = 1, Nombre = "Producto 1", Descripcion = "Desc", Precio = 10, Stock = 5, CategoriaId = 1 };
        _productoServiceMock.Setup(s => s.UpdateAsync(1, updateDto)).ReturnsAsync(false);

        // Act
        var result = await _controller.Update(1, updateDto);

        // Assert
        result.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public async Task Delete_ReturnsNoContent_WhenProductIsDeleted()
    {
        // Arrange
        _productoServiceMock.Setup(s => s.DeleteAsync(1)).ReturnsAsync(true);

        // Act
        var result = await _controller.Delete(1);

        // Assert
        result.Should().BeOfType<NoContentResult>();
    }

    [Fact]
    public async Task Delete_ReturnsNotFound_WhenProductDoesNotExist()
    {
        // Arrange
        _productoServiceMock.Setup(s => s.DeleteAsync(1)).ReturnsAsync(false);

        // Act
        var result = await _controller.Delete(1);

        // Assert
        result.Should().BeOfType<NotFoundResult>();
    }
}
