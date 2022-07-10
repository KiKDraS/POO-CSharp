using Biblioteca;
using Biblioteca.Pokemons;
using System.Data;
using System.Data.SqlClient;

namespace Programa
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Aventura Pokemon";

            bool reiniciar = true;
            do
            {
                //Inicio del juego
                Entrenador entrenador = Vistas.InicioJuego();
                Console.Clear();

                //Explorar
                Vistas.Explorar(entrenador);
                Console.ReadKey();
                Console.Clear();

                //Enfrentamiento
                string resultado = Vistas.Enfrentamiento(entrenador);
                Console.Clear();

                switch (resultado)
                {
                    case "El Pokemon Salvaje a ganado":
                        reiniciar = Vistas.FinDelJuego(resultado, entrenador);
                        Console.Clear();
                        break;
                    case "Tu Pokemon ha ganado":
                        Vistas.Ganador(resultado, entrenador);
                        Console.Clear();
                        reiniciar = Vistas.FinDelJuego("", entrenador);
                        Console.Clear();
                        break;
                }

            } while (reiniciar);

            ////Excepciones
            ////ash.PokemonActivo.Familia = "";
            ////ash.Evolucion();
            ////ash.PokemonActivo = null;
            ////ash.Evolucion();
            ////ash.AgregarPokemonPokedex(new Pikachu());
        }

    }
}