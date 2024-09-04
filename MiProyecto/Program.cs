using System;
using TiendaNew;
using Productos;

namespace MisPruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola");
            Tienda tiendaRosa = new Tienda();

            //tiendaRosa.AgregarProducto("Res", 2400, "Carne");
            IProducto produ = tiendaRosa.BuscarProductos("Res");
            Console.WriteLine(produ.NombrarProducto());
        }
    }
}
