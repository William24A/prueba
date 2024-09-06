using Xunit;
using TiendaNew;
using Productos;
using Moq;

public class TiendaTest: IClassFixture<TiendaFixture>
{
    private readonly TiendaFixture _fixture;
    public TiendaTest(TiendaFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void AgregarProductoTest()
    {
        // Act
        var nombre = "Res";
        var precio = 1223;
        var categoria = "Carne";
        var produc = new Producto(nombre, precio, categoria);
        _fixture.TiendaNew.AgregarProducto(produc);

        // Assert
        var producto = _fixture.TiendaNew.ProductosListados.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        Assert.NotNull(producto);
        Assert.Equal(nombre,producto.Nombre); 
        Assert.Equal(precio,producto.Precio);
        Assert.Equal(categoria,producto.Categoria);
    }

    [Fact]
    public void BuscarProductosTestTrue()
    {
        // Arrange
        string nombre = "Queso";
        float precio = 2000;
        string categoria = "Lacteo";
        var produ = new Producto(nombre, precio, categoria); 
        _fixture.TiendaNew.AgregarProducto(produ);

        // Act
        var producto = _fixture.TiendaNew.BuscarProductos(nombre);
        
        // Assert
        Assert.NotNull(producto);
        Assert.Equal(nombre,producto.Nombre);
        Assert.Equal(precio,producto.Precio);
        Assert.Equal(categoria,producto.Categoria);
    }
}