using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public static class Validaciones
    {
        public static int ValidarOpcionMenu<T>(List<T> lista, int seleccion)
        {
            while (lista.Count < seleccion && seleccion < 1)
            {
                Console.WriteLine("Opción inválida");
                seleccion = ValidarNumero();
            }

            return seleccion;
        }

        public static int ValidarNumero()
        {
            int seleccion;
            while (!int.TryParse(Console.ReadLine(), out seleccion))
            {
                Console.WriteLine("Ingrese un número");
            }

            return seleccion;
        }
    }
}
