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

        var producto = tiendaPrueba.BuscarProductos(nombre);
        Assert.NotNull(producto);
        Assert.Equal(nombre,producto.Nombre);
        Assert.Equal(precio,producto.Precio);
        Assert.Equal(categoria,producto.Categoria);
    } 

}