using System.Collections.Generic;
using Productos;

namespace TiendaNew
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
            var product = ProductosListados.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (product == null)
            {
                throw new ArgumentException("No se encontro el producto");
            }
            return product;
    
        }

        public bool EliminarProducto(string nombre)
        {
            IProducto productoAEliminar = ProductosListados.Find(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (productoAEliminar != null)
            {
                // Eliminar el producto de la lista
                ProductosListados.Remove(productoAEliminar);
                return true; // Indica que la eliminación fue exitosa
            }else{
                throw new ArgumentException("No se puede eliminar productos que no exiten");
            }
        }
    }
}