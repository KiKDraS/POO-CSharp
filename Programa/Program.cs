using Biblioteca;
using Biblioteca.Pokemons;

namespace Programa
{
    public static class Program
    {
        static void Main(string[] args)
        {
            //Crear entrenador
            Entrenador ash = new("Ash");

            //Cargar Pokemon en la Pokedex
            ash.AgregarPokemonPokedex(new Pikachu());
            ash.AgregarPokemonPokedex(new Bulbasaur());
            ash.AgregarPokemonPokedex(new Squirtle());
            ash.AgregarPokemonPokedex(new Charmander());

            //Seleccionar PokemonActivo
            ash.SeleccionarPokemonActivo(0);

            //Mostrar Pokemons de Ash
            Console.WriteLine("Pokemons de Ash:");
            ash.GetPokemons();

            //Crear un PokemonSalvaje
            ash.Explorar(new Squirtle());

            //Mostramos vida PokemonActivo y PokemonSalvaje (Deben ser privadas)
            Console.WriteLine($"Pokemon Activo: { ash.PokemonActivo.Nombre } - Vida: {ash.PokemonActivo.Vida}");
            Console.WriteLine($"Pokemon Salvaje: { ash.PokemonSalvaje.Nombre } - Vida: {ash.PokemonSalvaje.Vida}");

            //Enfrentamiento
            ash.AtaqueBasico();
            Console.WriteLine($"Pokemon Activo: { ash.PokemonActivo.Nombre } - Vida: {ash.PokemonActivo.Vida}");
            Console.WriteLine($"Pokemon Salvaje: { ash.PokemonSalvaje.Nombre } - Vida: {ash.PokemonSalvaje.Vida}");

            ash.AtaqueTipo();
            Console.WriteLine($"Pokemon Activo: { ash.PokemonActivo.Nombre } - Vida: {ash.PokemonActivo.Vida}");
            Console.WriteLine($"Pokemon Salvaje: { ash.PokemonSalvaje.Nombre } - Vida: {ash.PokemonSalvaje.Vida}");

            //Evolucion
            Console.WriteLine($"Pokemon Activo: { ash.PokemonActivo.Nombre }");
            ash.PokemonActivo.SetExp(50);
            ash.Evolucion();
            Console.WriteLine($"Pokemon Activo: { ash.PokemonActivo.Nombre }");

            //Evolucion2
            ash.SeleccionarPokemonActivo(1);
            Console.WriteLine($"Pokemon Activo: { ash.PokemonActivo.Nombre }");
            ash.PokemonActivo.SetExp(50);
            ash.Evolucion();
            Console.WriteLine($"Pokemon Activo: { ash.PokemonActivo.Nombre }");
            ash.PokemonActivo.SetExp(100);
            ash.Evolucion();
            Console.WriteLine($"Pokemon Activo: { ash.PokemonActivo.Nombre }");


            //Excepciones
            //ash.PokemonActivo.Familia = "";
            //ash.Evolucion();
            //ash.PokemonActivo = null;
            //ash.Evolucion();
            //ash.AgregarPokemonPokedex(new Pikachu());

        }

    }
}