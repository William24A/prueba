using Xunit;
using TiendaNew;
using Productos;
using Moq;

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
        // Arrange
        Tienda tiendaPrueba = new Tienda();
        string nombre = "Res";
        float precio = 1223;
        string categoria = "carnes";

        Producto produ = new Producto(nombre, precio, categoria); 
        tiendaPrueba.AgregarProducto(produ);

        // Act
        var producto = tiendaPrueba.BuscarProductos(nombre);
        
        // Assert
        Assert.NotNull(producto);
        Assert.Equal(nombre,producto.Nombre);
        Assert.Equal(precio,producto.Precio);
        Assert.Equal(categoria,producto.Categoria);
    }
/*
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
    }*/

    [Fact]
    public void EliminarProductoTest()
    {
        // Arrange
        Tienda tiendaPrueba = new Tienda();
        string nombre = "Res";
        float precio = 1223;
        string categoria = "carnes";

        Producto produ = new Producto(nombre, precio, categoria); 
        tiendaPrueba.AgregarProducto(produ);

        // Act
        bool seElimino = tiendaPrueba.EliminarProducto(nombre);

        // Assert
        Assert.True(seElimino);
    } 

    [Fact]
    public void BuscarProducto_ProductoInexistente_DeberiaLanzarExcepcion()
    {
        // Arrange
        Tienda tiendaPrueba = new Tienda();
        string nombre = "Res";

        // Act - Assert
        Assert.Throws<KeyNotFoundException>(() => tiendaPrueba.BuscarProductos(nombre));
    }

    [Fact]
    public void EliminarProducto_ProductoInexistente_DeberiaLanzarExcepcion()
    {
        // Arrange
        Tienda tiendaPrueba = new Tienda();
        string nombre = "Res";
        
        // Act - Assert
        Assert.Throws<KeyNotFoundException>(() => tiendaPrueba.EliminarProducto(nombre));
    }

    [Fact]
    public void AplicarDescuento_DeberiaActualizarPrecioCorrectamente()
    {
        // Arrange
        string nombre = "Res";
        float precio = 1000;
        string categoria = "carnes";
        
        var mockProducto = new Mock<IProducto>();
        mockProducto.Setup(p => p.Nombre).Returns(nombre);
        mockProducto.Setup(p => p.Precio).Returns(precio);
        mockProducto.Setup(p => p.Categoria).Returns(categoria);


        Tienda tienda = new Tienda();
        tienda.AgregarProducto(mockProducto.Object);

        // Act
        tienda.AplicarDescuento(nombre, 20); // descuento del 20% -> me tendria que dar 800

        // Assert
        mockProducto.Verify(p => p.ActualizarPrecio(800), Times.Once);
        // verifica que el metodo ActualizarPrecio fue llamado una vez (Times.Once) con el valor 800

    }


//     [Fact]
// public void AplicarDescuento_DeberiaActualizarPrecioCorrectamente()
// {
//     // Arrange
//     var tienda = new Tienda();


//     string nombre = "Res";
//     float precio = 1000;
//     string categoria = "carnes";
    
//     var mockProducto = new Mock<IProducto>();
//     mockProducto.Setup(p => p.Nombre).Returns(nombre);
//     mockProducto.Setup(p => p.Precio).Returns(precio);
//     mockProducto.Setup(p => p.Categoria).Returns(categoria);
    
//     // Setup para aceptar cualquier valor en ActualizarPrecio
//     mockProducto.Setup(p => p.ActualizarPrecio(It.IsAny<float>())).Verifiable();
    
//     tienda.AgregarProducto(mockProducto.Object);

//     // Act
//     tienda.AplicarDescuento(nombre, 20);

//     // Assert
//     mockProducto.Verify(p => p.ActualizarPrecio(800), Times.Once);
// }



    
}