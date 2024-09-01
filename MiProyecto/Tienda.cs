using System.Collections.Generic;
using Productos;

namespace TiendaNew
{
    public class Tienda
    {
        public List<Producto> ProductosListados { get; set; }

        public Tienda()
        {
            ProductosListados = new List<Producto>();
        }

        public void AgregarProducto(Producto producto)
        {
            ProductosListados.Add(producto);
        }

        public Producto BuscarProductos(string nombre)
        {
            return ProductosListados.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
    
        }

        public bool EliminarProducto(string nombre)
        {
            Producto productoAEliminar = ProductosListados.Find(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (productoAEliminar != null)
            {
                // Eliminar el producto de la lista
                ProductosListados.Remove(productoAEliminar);
                return true; // Indica que la eliminación fue exitosa
            }

            return false; // Indica que el producto no fue encontrado
        }
    }
}