namespace MisPruebas
{
    public class Pruebas
    {
        public string Nombre;
        public Pruebas()
        {
            Nombre = "";
        }

        public Pruebas(string nombre)
        {
            this.Nombre = nombre;
        }

        public void CambiarNombre(string nombre2)
        {
            this.Nombre = nombre2;
        }

        public string RetornaNombre()
        {
            return Nombre;
        }

        public int Suma(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}
