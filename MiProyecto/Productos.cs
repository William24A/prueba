namespace Productos 
{
    public interface IProducto
    {
        string Nombre { get;}
        float Precio { get;}
        string Categoria { get;}
        public void ActualizarPrecio(float nuevoPrecio);
    }
    
    public class Producto: IProducto
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


        public void ActualizarPrecio(float nuevoPrecio)
        {
            if(nuevoPrecio < 0)
            {
                throw new ArgumentException("El precio no puede ser negativo");
            }

            this.Precio = nuevoPrecio;
        }

    }
}
