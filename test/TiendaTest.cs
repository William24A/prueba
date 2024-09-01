using Xunit;
using TiendaNew;
using Productos;

public class TiendaTest
{
    [Fact]
    public void AgregarProductoTest()
    {
        // Arrange
        Tienda tiendaPrueba = new Tienda();
        string nombre = "Res";
        float precio = 1223;
        string categoria = "carnes";
        
        Producto produ = new Producto(nombre, precio, categoria); 

        // Act
        tiendaPrueba.AgregarProducto(produ);

        // Assert
        var producto = tiendaPrueba.ProductosListados.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        Assert.NotNull(producto);
        Assert.Equal(nombre,producto.Nombre); 
        Assert.Equal(precio,producto.Precio);
        Assert.Equal(categoria,producto.Categoria);
    }

    [Fact]
    public void BuscarProductosTestTrue()
    {
        // Given
        Tienda tiendaPrueba = new Tienda();
        string nombre = "Res";
        float precio = 1223;
        string categoria = "carnes";

        Producto produ = new Producto(nombre, precio, categoria); 
        tiendaPrueba.AgregarProducto(produ);
        // When
        var producto = tiendaPrueba.BuscarProductos(nombre);
        // Then
        Assert.NotNull(producto);
        Assert.Equal(nombre,producto.Nombre);
        Assert.Equal(precio,producto.Precio);
        Assert.Equal(categoria,producto.Categoria);
    }

    [Fact]
    public void BuscarProductosTestFalse()
    {
        // Given
        Tienda tiendaPrueba = new Tienda();
        string nombre = "Res";

        // When
        var producto = tiendaPrueba.BuscarProductos(nombre);

        // Then
        Assert.Null(producto);
    }

    [Fact]
    public void EliminarProductoTest()
    {
        Tienda tiendaPrueba = new Tienda();
        string nombre = "Res";
        float precio = 1223;
        string categoria = "carnes";

        Producto produ = new Producto(nombre, precio, categoria); 

        tiendaPrueba.AgregarProducto(produ);

        var producto = tiendaPrueba.EliminarProducto(nombre);

        Assert.True(producto);
    } 

}