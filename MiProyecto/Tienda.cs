using System.Collections.Generic;
using Productos;

namespace Tiendas
{
    public class Tienda
    {
        public List<IProducto> ProductosListados {get; private set;}

        public Tienda()
        {
            ProductosListados = new List<IProducto>();
        }

        public void AgregarProducto(IProducto producto)
        {
            ProductosListados.Add(producto);
        }

        public IProducto BuscarProductos(string nombre)
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
            IProducto productoAEliminar = ProductosListados.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

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

            IProducto producto = BuscarProductos(nombre);
            float nuevoPrecio = producto.Precio * (1 - (descuento / 100));
            producto.ActualizarPrecio(nuevoPrecio);
        }
    }
}