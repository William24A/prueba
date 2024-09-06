using Xunit;
using TiendaNew;
using Productos;
using Moq;

public class TiendaTest: IClassFixture<ProductoFixture>
{
    private readonly ProductoFixture _fixture;
    public TiendaTest(ProductoFixture fixture)
    {
        _fixture = fixture;
    }
    public void Dispose()
    {
        _fixture.Dispo();
    }

    [Fact]
    public void AgregarProductoTest()
    {
        // Act
        Tienda tiendaNew = new Tienda();
        var product = _fixture.ProductosListados[0];
        tiendaNew.AgregarProducto(_fixture.ProductosListados);

        // Assert
        var producto = tiendaNew.ProductosListados.FirstOrDefault(p => p.Nombre.Equals(product.Nombre, StringComparison.OrdinalIgnoreCase));
        Assert.NotNull(producto);
        Assert.Equal(product.Nombre,producto.Nombre); 
        Assert.Equal(product.Precio,producto.Precio);
        Assert.Equal(product.Categoria,producto.Categoria);
    }

    [Fact]
    public void BuscarProductosTestTrue()
    {
        // Arrange
        Tienda tiendaNew = new Tienda();
        tiendaNew.AgregarProducto(_fixture.ProductosListados);

        // Act
        var producto = tiendaNew.BuscarProductos(_fixture.ProductosListados[0].Nombre);
        
        // Assert
        Assert.NotNull(producto);
        Assert.Equal(_fixture.ProductosListados[0].Nombre,producto.Nombre);
        Assert.Equal(_fixture.ProductosListados[0].Precio,producto.Precio);
        Assert.Equal(_fixture.ProductosListados[0].Categoria,producto.Categoria);
    }
    [Fact]
    public void Calcular_total_carritoTest()
    {
        Tienda tiendaNew = new Tienda();
        List<string> carrito = new List<string> { "Lomo", "Leche", "Manteca"};
        tiendaNew.AgregarProducto(_fixture.ProductosListados);
        tiendaNew.AplicarDescuento("Lomo", 20);


        var total = tiendaNew.Calcular_total_carrito(carrito);
        Assert.NotNull(total);
        Assert.Equal(total, 3455.199951171875);
    }

}