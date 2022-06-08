using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Pokemons;

namespace Biblioteca
{
    public static class Vistas
    {
        private static readonly List<string> PokemonsIniciales = new()
        {
            "Pikachu",
            "Bulbasaur",
            "Squirtle",
            "Charmander"
        };

        private static readonly List<string> TiposAtaques = new()
        {
            "Ataque Básico",
            "Ataque Especial"
        };

        /// <summary>
        ///     Imprime un título en pantalla
        /// </summary>
        private static void Titulo()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine(".~~~~~~~~~~~~~~~~~~.");
            Console.WriteLine("| Aventura Pokemon |");
            Console.WriteLine("'~~~~~~~~~~~~~~~~~~'\n");

            Console.ResetColor();
        }

        /// <summary>
        ///     Arma la vista para la creación de Objeto Entrenador
        /// </summary>
        /// <returns>Objeto Entrenador</returns>
        public static string NombreEntrenador()
        {
            Titulo();
            Console.WriteLine("Elije un nombre para tu personaje");
            string nombre = Console.ReadLine();
            return nombre;
        }

        /// <summary>
        ///    Imprime en patalla un menú que permite seleccionar el Pokemon inicial. Crea un Objeto Basico de   la clase sellada correpondiente con la selección. Utiliza el método GenerarMenu para la creación del menú a mostrar
        /// </summary>
        /// <returns>Objeto Basico</returns>
        public static int PokemonInicial(){
            Titulo();
            Console.WriteLine("Selecciona un Pokemon para iniciar la Aventura:");
            GenerarMenu(PokemonsIniciales);
            int seleccion = Validaciones.ValidarNumero();
            int pokemonInicial = Validaciones.ValidarOpcionMenu(PokemonsIniciales, seleccion);
            return pokemonInicial;
        }

        /// <summary>
        ///     Crea un menú de selección utilizando los elementos existentes en una Lista.
        /// </summary>
        /// <param name="lista">Lista utilizada para la creación del menú</param>
        private static void GenerarMenu(List<string> lista)
        {
            int loop = 1;
            foreach(string el in lista)
            {
                Console.WriteLine($"{loop}. {el}");
                loop++;
            }
        }

        /// <summary>
        ///     Crea la vista para la explorar en el juego. Explorar implica la creación de un Objeto Pokemon y la inserción del mismo en el atributo PokemonSalvaje del Objeto Entrenador
        /// </summary>
        /// <param name="entrenador">Objeto Entrenador que recibirá al Objeto Pokemon creado</param>
        public static void Explorar(Entrenador entrenador)
        {
            Titulo();
            Console.WriteLine("Con tu nuevo Pokemon te adentras en el bosque en busca de Pokemons Salvajes para ampliar tus conocimientos");
            PuntosSuspensivos();
            Console.WriteLine("\nUn Pokemon Salvaje ha aparecido");
            entrenador.Explorar(new Squirtle());
            Console.WriteLine($"La Pokedex te dice que es un {entrenador.PokemonSalvaje.Nombre}");
            Console.WriteLine("Vamos a enfrentarnos a el");
        }

        /// <summary>
        ///     Crea la vista para el enfrentamiento entre los PokemonActivo y PokemonSalvaje que se encuentran almacenados en el Objeto Entrenador
        /// </summary>
        /// <param name="entrenador">Objeto Entrenador del que se toman los datos PokemonActivo y PokemonSalvaje</param>
        /// <returns></returns>
        public static string Enfrentamiento(Entrenador entrenador)
        {
            string resultado = "";

            while (entrenador.PokemonActivo.Vida > 0 && entrenador.PokemonSalvaje.Vida > 0)
            {
                Titulo();
                Console.WriteLine("Selecciona el tipo de ataque quieres utilizar:");                
                GenerarMenu(TiposAtaques);
                int seleccion = Validaciones.ValidarNumero();
                int tipoAtaque = Validaciones.ValidarOpcionMenu(PokemonsIniciales, seleccion);

                switch (tipoAtaque)
                {
                    case 1:
                        entrenador.AtaqueBasico();
                        break;
                    case 2:
                        entrenador.AtaqueTipo();
                        break;
                }

                if(entrenador.PokemonActivo is null)
                {
                    Console.WriteLine("A tu Pokemon lo han derrotado");
                    resultado = "El Pokemon Salvaje a ganado";
                    break;
                }
                else
                {
                    Console.WriteLine($"A tu Pokemon le quedan {entrenador.PokemonActivo.Vida} puntos de Vida");
                }

                if(entrenador.PokemonSalvaje is null)
                {
                    Console.WriteLine("El Pokemon Salvaje ha sido derrotado");
                    resultado = "Tu Pokemon a ganado";
                    break;
                }
                else
                {
                    Console.WriteLine($"Al Pokemon salvaje le quedan {entrenador.PokemonSalvaje.Vida} puntos de Vida");
                }

                Console.ReadKey();
                Console.Clear();
            }

            return resultado;
        }

        /// <summary>
        ///     Crea la vista para la Evolución del PokemonActivo del Objeto Entrenador
        /// </summary>
        /// <param name="entrenador">Objeto Entrenador del que se toma el dato PokemonActivo</param>
        public static void Evolucion(Entrenador entrenador)
        {
            string actual = entrenador.PokemonActivo.Familia;
            Console.WriteLine($"{actual} está evolucionando!");
            entrenador.Evolucion();
            Console.WriteLine($"Tu {actual} ahora es un {entrenador.PokemonActivo.Familia}");
        }

        /// <summary>
        ///     Crea la vista de la finalización del juego. Muestra una vista distinta dependiendo del resultado del enfrentamientos. Limpia la variable que almacena al Objeto Entrenador para preparar el reinicio del juego. Retorna un bool para manejar el reinicio o cierre del juego
        /// </summary>
        /// <param name="resultado">string con el resultado del enfrentamiento</param>
        /// <param name="entrenador">Objeto Entrenador a ser limpiuado</param>
        /// <returns>bool reiniciar</returns>
        public static bool FinDelJuego(string resultado, Entrenador entrenador)
        {
            bool reiniciar = true;

            if (!string.IsNullOrEmpty(resultado))
            {
                Console.WriteLine("Han derrotado a tu Pokemon y tu aventura llega a su fin");
                reiniciar = Validaciones.ValidarTecla("Presione ENTER para reiniciar o ESC para salir");
            }
            else
            {
                Console.WriteLine("El juego a llegado a su fin");
                reiniciar = Validaciones.ValidarTecla("Presione ENTER para reiniciar o ESC para salir");
            }  

            if (reiniciar)
            {
                Titulo();
                Console.WriteLine("La consola va a reiniciarse");
            }
                
            PuntosSuspensivos();
            entrenador = null;
            return reiniciar;
        }

        /// <summary>
        ///     Crea una vista de puntos suspensivos con delay para simular esperas
        /// </summary>
        private static void PuntosSuspensivos()
        {
            for (int i = 0; i < 3; i++)
            {
                int mydelay = 1000;
                Console.Write(".");
                Thread.Sleep(mydelay);
                Console.Write(".");
            }
        }
    }
}
