using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public static class Validaciones
    {
        /// <summary>
        ///     Método creado para la validación de la selección de un elemento de menú. Trabaja con tipos génericos para permitir su utilización sin importar el tipo de lista usada para la creación del menú.
        /// </summary>
        /// <param name="lista">Lista usada para la validación de la selección</param>
        /// <param name="seleccion">int que contiene la selección realizada por el usuario</param>
        /// <returns>int seleccion con una seleción válida para la Lista analizada</returns>
        public static int ValidarOpcionMenu<T>(List<T> lista, int seleccion)
        {
            while (lista.Count < seleccion && seleccion < 1)
            {
                Console.WriteLine("Opción inválida");
                seleccion = ValidarNumero();
            }

            return seleccion;
        }

        /// <summary>
        ///     Método creado para la validar que el usuario ingrese un número por consola
        /// </summary>
        /// <returns>int seleccion que representa el número seleccionado</returns>
        public static int ValidarNumero()
        {
            int seleccion;
            while (!int.TryParse(Console.ReadLine(), out seleccion))
            {
                Console.WriteLine("Ingrese un número");
            }

            return seleccion;
        }

        /// <summary>
        ///     Método creado para validar que el usuario presione las teclas ESC o ENTER para la selección de una opción
        /// </summary>
        /// <param name="mensaje">string con el mensaje que se muestra en pantalla durante la validación</param>
        /// <returns>bool reiniciar que representa la selección del usuario</returns>
        public static bool ValidarTecla(string mensaje)
        {
            Console.WriteLine(mensaje);
            bool reiniciar = true;
            ConsoleKey salir = Console.ReadKey(true).Key;

            while (salir != ConsoleKey.Escape && salir != ConsoleKey.Enter)
            {
                Console.WriteLine(mensaje);
                salir = Console.ReadKey(true).Key;
            }

            switch (salir)
            {
                case ConsoleKey.Escape:
                    Console.Clear();
                    reiniciar = false;
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    reiniciar = true;
                    break;

            }

            return reiniciar;
        }
    }
}
