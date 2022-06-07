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

        public static void Titulo()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine(".~~~~~~~~~~~~~~~~~~.");
            Console.WriteLine("| Aventura Pokemon |");
            Console.WriteLine("'~~~~~~~~~~~~~~~~~~'\n");

            Console.ResetColor();
        }

        public static string NombreEntrenador()
        {
            Titulo();
            Console.WriteLine("Elije un nombre para tu personaje");
            string nombre = Console.ReadLine();
            return nombre;
        }

        public static int PokemonInicial(){
            Titulo();
            Console.WriteLine("Selecciona un Pokemon para iniciar la Aventura:");
            GenerarMenu(PokemonsIniciales);
            int seleccion = Validaciones.ValidarNumero();
            int pokemonInicial = Validaciones.ValidarOpcionMenu(PokemonsIniciales, seleccion);
            return pokemonInicial;
        }

        static void GenerarMenu(List<string> lista)
        {
            int loop = 1;
            foreach(string el in lista)
            {
                Console.WriteLine($"{loop}. {el}");
                loop++;
            }
        }

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

        public static void FinDelJuego(string resultado, Entrenador entrenador)
        {
            if (!string.IsNullOrEmpty(resultado))
            {
                Console.WriteLine("Han derrotado a tu Pokemon y tu aventura llega a su fin");
            }
            else
            {
                Console.WriteLine("El juego a llegado a su fin");
            }          
            
            PuntosSuspensivos();
            Console.WriteLine("La consola va a reiniciarse");
            entrenador = null;
            Console.ReadLine();
            Console.Clear();
        }

        static void PuntosSuspensivos()
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
