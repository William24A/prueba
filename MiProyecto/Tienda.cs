using System;
using System.Collections.Generic;
using Productos;

namespace TiendaNew
{
    public class Tienda
    {
        public List<Producto> ProductosListados {get; private set;}

        public Tienda()
        {
            ProductosListados = new List<Producto>();
        }

        public void AgregarProducto(Producto producto)
        {
            ProductosListados.Add(producto);
        }
        public void AgregarProducto(List<Producto> productos)
        {
            this.ProductosListados = productos;
        }

        public Producto BuscarProductos(string nombre)
        {
            var producto = ProductosListados.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto == null)
            {
                throw new KeyNotFoundException($"No se encontro el producto: '{nombre}'");
            }
            return producto;
    
        }
        
        public bool EliminarProducto(string nombre)
        {
            var productoAEliminar = ProductosListados.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (productoAEliminar != null)
            {
                // Eliminar el producto de la lista
                ProductosListados.Remove(productoAEliminar);
                return true; // Indica que la eliminación fue exitosa
            }else{
                throw new KeyNotFoundException($"El producto con nombre '{nombre}' no se puede eliminar porque no existe");
            }
        }

        public void AplicarDescuento(string nombre, float descuento)
        {
            if (descuento < 0 || descuento > 100)
            {
            throw new ArgumentException("El porcentaje de descuento debe estar entre 0 y 100", nameof(descuento));
            }

            Producto producto = BuscarProductos(nombre);
            float nuevoPrecio = producto.Precio * (1 - (descuento / 100));
            producto.ActualizarPrecio(nuevoPrecio);
        }

        public float Calcular_total_carrito(List<string> carrito)
        {
            float total = 0;
            if(carrito == null)
            {
                return 0;
            }else{
                foreach (var Nombre in carrito)
                {
                    var product = BuscarProductos(Nombre);
                    if(product != null)
                    {
                        total += product.Precio;
                    }
                }
                return total;
            }
        }
    }
}