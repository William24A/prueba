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
    }/*
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
/*
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

        //Assert.Equal(800, mockProducto.Object.Precio);
        // deberia hacer un test en producto para verificar esto

    }*/
    [Fact]
    public void Calcular_total_carritoTest()
    {
        Tienda tiendaNew = new Tienda();
        List<string> carrito = new List<string> { "Lomo", "Leche", "Manteca"};
        tiendaNew.AgregarProducto(_fixture.ProductosListados);


        var total = tiendaNew.Calcular_total_carrito(carrito);
        Assert.NotNull(total);
        Assert.Equal(total, 3702);
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