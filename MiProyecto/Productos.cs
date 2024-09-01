namespace Productos 
{
    public class Producto
    {
        public string Nombre{get; set;}
        public float Precio{get; set;}
        public string Categoria{get;set;}
        public Producto() 
        {
            Nombre = "";
            Precio = 0;
            Categoria = "";
        }

        public Producto(string nombre, float precio, string categoria)
        {
            this.Nombre = nombre;
            this.Precio = precio;
            this.Categoria = categoria;
        }

        public string NombrarProducto()
        {
            return "Nombre: "+ Nombre + " Precio: "+ Precio + " Categoria: "+ Categoria;
        }

    }
}
