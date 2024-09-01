using System;
using MisPruebas;

namespace MisPruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese un nombre: ");
            string nombre = Console.ReadLine();
            Pruebas objeto1 = new Pruebas(nombre);
            Console.WriteLine("Mi nombre es: "+ objeto1.RetornaNombre());

            objeto1.CambiarNombre("marta");
            Console.WriteLine("Mi nombre es: "+ objeto1.RetornaNombre());
   
        }
    }
}
