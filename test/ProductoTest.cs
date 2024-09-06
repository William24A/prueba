using Xunit;
using Productos;

public class PoductoTest
{
    [Fact]
    public void Constructor_ValoresValidos_DeberiaInicializarCorrectamente()
    {
        // Arrange - Act
        String nombre = "Lomo";
        float precio = 123;
        String categoria = "Carnes";
        
        Producto producto = new Producto(nombre, precio, categoria);

        // Assert
        Assert.Equal(nombre, producto.Nombre);
        Assert.Equal(precio, producto.Precio);
        Assert.Equal(categoria, producto.Categoria);
    }

    [Fact]
    public void ActualizarPrecio_PrecioNegativo_DeberiaLanzarExcepcion()
    {
        // Arrange
        String nombre = "Lomo";
        float precio = 123;
        String categoria = "Carnes";
        Producto productoPrueba = new Producto(nombre, precio, categoria);


        // Act - Assert
        Assert.Throws<ArgumentException>(() => productoPrueba.ActualizarPrecio(-99));
    }
    
}