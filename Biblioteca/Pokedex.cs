using Biblioteca.Exceptions;

namespace Biblioteca
{
    public class Pokedex
    {
        private readonly List<Pokemon>Pokemons = new() { 
            
        };

        public  List<Pokemon> GetPokemons()
        {
            return Pokemons;
        }

        public  Pokemon GetPokemon(int i)
        {
            return Pokemons[i];
        }

        public void InsertPokemon(Pokemon pokemon)
        {
            Pokemons.Add(pokemon);
        }

        /// <summary>
        ///     Actualiza las listas de Pokemon según corresponda. Maneja errores con la excepcion ArgumentNullException
        /// </summary>
        /// <param name="pokemon">Objeto Pkemon utilzado en la actualización</param>
        public void ActualizarPokedex(Pokemon pokemon)
        {
            if (pokemon == null)
                throw new NullReferenceException("No pudimos actualizar la Pokedex. Tenemos problemas para encontrar la información del Pokemon");

            var existe = Pokemons.Find(poke => poke.Familia == pokemon.Familia && poke.NombrePokemon == poke.NombrePokemon);
            if (existe != null)
                throw new PokemonExisteException("No pudimos actualizar la Pokedex. El Pokemon ya existe.");
            else
                Pokemons.Add(pokemon);
        }

        /// <summary>
        ///     Actualiza la Pokedex cuando un Pokemon evoluciona. Maneja errores con la excepcion ArgumentNullException
        /// </summary>
        /// <param name="evolucionando"></param>
        /// <param name="evolucion"></param>
        public void ActualizarPokedexEvolucion(Pokemon evolucionando, Pokemon evolucion)
        {
            if (evolucionando == null || evolucion == null)
                throw new NullReferenceException("No pudimos actualizar la Pokedex. Tenemos problemas para encontrar la información del Pokemon");
            var evol = Pokemons.Find(poke => poke.Familia == evolucionando.Familia && poke.NombrePokemon == evolucionando.NombrePokemon);
            if (evol != null)
            {
                Pokemons.Remove(evol);
                evol.Is_Active = false;
                evol.Is_Aviable = false;
                Pokemons.Add(evol);
            }

            Pokemons.Add(evolucion);
        }

    }
}
