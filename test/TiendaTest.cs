using Xunit;
using TiendaNew;

public class TiendaTest
{
    [Fact]
    public void AgregarProductoTest()
    {
        Tienda tiendaPrueba = new Tienda();
        string nombre = "Res";
        float precio = 1223;
        string categoria = "carnes";

        tiendaPrueba.AgregarProducto(nombre, precio,categoria);

        var producto = tiendaPrueba.ProductosListados.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        Assert.NotNull(producto);
        Assert.Equal(nombre,producto.Nombre);
        Assert.Equal(precio,producto.Precio);
        Assert.Equal(categoria,producto.Categoria);
    } 
    [Fact]
    public void BuscarProductosTest()
    {
        // Given
        Tienda tiendaPrueba = new Tienda();
        string nombre = "Res";
        float precio = 1223;
        string categoria = "carnes";
        tiendaPrueba.AgregarProducto(nombre, precio,categoria);
        // When
        var producto = tiendaPrueba.BuscarProductos(nombre);
        // Then
        Assert.NotNull(producto);
        Assert.Equal(nombre,producto.Nombre);
        Assert.Equal(precio,producto.Precio);
        Assert.Equal(categoria,producto.Categoria);
    }

    [Fact]
    public void EliminarProductoTest()
    {
        Tienda tiendaPrueba = new Tienda();
        string nombre = "Res";
        float precio = 1223;
        string categoria = "carnes";

        tiendaPrueba.AgregarProducto(nombre, precio,categoria);

        var producto = tiendaPrueba.EliminarProducto(nombre);

        Assert.True(producto);
    } 

}