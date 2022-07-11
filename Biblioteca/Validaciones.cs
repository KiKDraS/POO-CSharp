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
            while (lista.Count < seleccion || seleccion < 1)
            {
                Console.WriteLine("Opción inválida");
                seleccion = ValidarNumero();
            }

            return seleccion;
        }

        /// <summary>
        ///     Método que evita que el nombre del entrenador quede vacío
        /// </summary>
        /// <param name="existentes"></param>
        /// <returns>Nombre listo para la creación del Objeto Entrenador</returns>
        public static string ValidarNombreVacio(List<string> existentes)
        {
            string nombre = Console.ReadLine();

            while (string.IsNullOrEmpty(nombre.Trim()) || nombre.Trim().Length == 0)
            {
                Console.WriteLine("Debes elegir un nombre");
                nombre = Console.ReadLine();
            }
            bool isUnique = ValidarNombreUnico(nombre, existentes);
            while (isUnique)
            {
                Console.WriteLine("El nombre ya existe. Prueba otro");
                nombre = Console.ReadLine();
                isUnique = ValidarNombreUnico(nombre, existentes);
            }
            return nombre.Trim();
        }

        /// <summary>
        ///     Método que analiza el nombre elegido para evitar que haya dos cuentas con el mismo nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="existentes"></param>
        /// <returns>Nombre validado</returns>
        public static bool ValidarNombreUnico(string nombre, List<string> existentes)
        {
            bool isUnique = false;
            foreach (var nombreExistente in existentes)
            {
                if(nombreExistente.ToLower() == nombre.ToLower()) { isUnique = true; break; }
            }

            return isUnique;
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
