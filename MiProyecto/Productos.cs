namespace Productos 
{
    public interface IProducto
    {
        string Nombre { get;}
        float Precio { get;}
        string Categoria { get;}
        public void ActualizarPrecio(float nuevoPrecio);
    }

    public interface IDisposable
    {
        void Dispo();
    }
    public class ProductoFixture: IDisposable
    {
        public List<Producto> ProductosListados { get; private set;}
        public ProductoFixture()
        {
            ProductosListados = new List<Producto>();
            
            ProductosListados.Add(new Producto("Lomo", 1234, "Carne"));
            ProductosListados.Add(new Producto("Leche", 1234, "Lacteos"));
            ProductosListados.Add(new Producto("Manteca",1234, "Lacteos"));
            ProductosListados.Add(new Producto("Leche en polvo", 1234, "Lacteos"));
            ProductosListados.Add(new Producto("Jamon", 1234, "Embutidos"));
        }
        public void Dispo()
        {
            this.ProductosListados.Clear();
        }
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
