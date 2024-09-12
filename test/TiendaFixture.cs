using System;
using System.Collections.Generic;
using Tiendas;
using Productos;

public class TiendaFixture : IDisposable // Liberar espacio
{
    private Tienda tienda;
    public Tienda Tienda { get => tienda; set => tienda = value; }

    public List<Producto> ProductosEjemplo { get; private set; }

    public TiendaFixture()
    {
        Tienda = new Tienda();
        ProductosEjemplo = new List<Producto>
        {
            new Producto("Laptop", 1000, "Electrónicos"),
            new Producto("Smartphone", 500, "Electrónicos"),
            new Producto("Libro", 20, "Libros"),
            new Producto("Camiseta", 25, "Ropa"),
            new Producto("Campera", 100, "Ropa")
        };

        foreach (var producto in ProductosEjemplo)
        {
            Tienda.AgregarProducto(producto);
        }
    }

    public void Dispose()
    {
    }
}