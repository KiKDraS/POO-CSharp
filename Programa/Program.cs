using Biblioteca;
using Biblioteca.Pokemons;

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
                string nombreEntrenador = Vistas.NombreEntrenador();

                //Crear entrenador
                Entrenador entrenador = new(nombreEntrenador);
                Console.Clear();

                //Selección de Pokemon Inicial
                int pokemonInicial = Vistas.PokemonInicial();

                //Cargar Pokemon Inicial en la Pokedex del Entrenador y configurarlo como Pokemon Activo
                switch (pokemonInicial)
                {
                    case 1:
                        entrenador.AgregarPokemonPokedex(new Pikachu());
                        break;
                    case 2:
                        entrenador.AgregarPokemonPokedex(new Bulbasaur());
                        break;
                    case 3:
                        entrenador.AgregarPokemonPokedex(new Squirtle());
                        break;
                    case 4:
                        entrenador.AgregarPokemonPokedex(new Charmander());
                        break;
                }
                entrenador.SeleccionarPokemonActivo(0);
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

            //Excepciones
            //ash.PokemonActivo.Familia = "";
            //ash.Evolucion();
            //ash.PokemonActivo = null;
            //ash.Evolucion();
            //ash.AgregarPokemonPokedex(new Pikachu());

        }

    }
}