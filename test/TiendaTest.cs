using Xunit;
using Tiendas;
using Productos;
using Moq;

public class TiendaTest : IClassFixture<TiendaFixture>
{
    private readonly TiendaFixture _fixture;

    public TiendaTest(TiendaFixture fixture)
    {
        _fixture = fixture;
    }
    
    [Fact]
    public void AgregarProducto_DebeAgregarProductoAlInventario()
    {
        // Arrange
        string nombre = "Res";
        float precio = 1223;
        string categoria = "carnes";
        
        Producto producto = new Producto(nombre, precio, categoria); 

        // Act
        _fixture.Tienda.AgregarProducto(producto);

        // Assert
        var productoEncontrado = _fixture.Tienda.ProductosListados.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        Assert.NotNull(productoEncontrado);
        Assert.Equal(nombre,productoEncontrado.Nombre); 
        Assert.Equal(precio,productoEncontrado.Precio);
        Assert.Equal(categoria,productoEncontrado.Categoria);
    }

    [Fact]
    public void BuscarProducto_ProductoExistente_DeberiaRetornarProducto()
    {
        // Arrange
        string nombre = "Libro"; // es uno de los producto que hay en el Fixture

        // Act
        var productoEncontrado = _fixture.Tienda.BuscarProductos(nombre);
        
        // Assert
        Assert.NotNull(productoEncontrado);
        Assert.Equal(nombre,productoEncontrado.Nombre);
    }

    [Fact]
    public void BuscarProducto_ProductoInexistente_DeberiaLanzarExcepcion()
    {
        // Arrange
        string nombre = "aslkdfkhasof";

        // Act - Assert
        Assert.Throws<KeyNotFoundException>(() => _fixture.Tienda.BuscarProductos(nombre));
    }


    [Fact]
    public void EliminarProducto_ProductoExistente_DeberiaEliminarlo()
    {
        // Arrange
        string nombre = "Campera"; // cambia el esto del fixture

        // Act
        bool seElimino = _fixture.Tienda.EliminarProducto(nombre);

        // Assert
        Assert.True(seElimino);
    } 

    
    [Fact]
    public void EliminarProducto_ProductoInexistente_DeberiaLanzarExcepcion()
    {
        // Arrange
        string nombre = "Resasdfhas";
        
        // Act - Assert
        Assert.Throws<KeyNotFoundException>(() => _fixture.Tienda.EliminarProducto(nombre));
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

        //Assert.Equal(800, mockProducto.Object.Precio);
        // deberia hacer un test en producto para verificar esto

    }


    [Fact]
    public void CalcularTotalCarrito_DeberiaRetornarElPrecioTotal_SinDescuento()
    {
        // Arrange
        var nombresProductos = new List<string> { "Laptop", "Smartphone" };

        // Act
        var total = _fixture.Tienda.CalcularTotalCarrito(nombresProductos);

        // Assert
        Assert.Equal(1500, total);  // 1000 + 500  = 1500
    }

    [Fact]
    public void CalcularTotalCarrito_DeberiaRetornarElPrecioTotal_ConDescuento()
    {
        // Arrange
        var nombresProductos = new List<string> { "Laptop", "Smartphone", "Campera" };

        _fixture.Tienda.AplicarDescuento("Campera", 10);  //  100 - 10% = 90

        // Act
        var total = _fixture.Tienda.CalcularTotalCarrito(nombresProductos);

        // Assert
        Assert.Equal(1590, total);  // 1000 (Laptop) + 500 (Smartphone) + 90 = 1590
    }

    
}