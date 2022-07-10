using Entities;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public static class BLLPokemones
    {
        public static List<Pokemon> ObtenerPokemonsIniciales()
        {
            var dalpoke = new DALPokemon();
            var lista = dalpoke.ObtenerPokemonsIniciales();
            return lista;
        }

        public static Pokemon ObtenerUnPokemon(List<Pokemon> listaInicial, string pokemonSeleccionado)
        {
            Pokemon pokemon = null;
            foreach (var item in listaInicial)
            {
                if (item.Familia == pokemonSeleccionado)
                {
                    pokemon = item;
                }
            }
            return pokemon;
        }
        public static List<Pokemon> ObtenerPokemonsEntrenador(int idEntrenador)
        {
            var dalpoke = new DALPokemon();
            var lista = dalpoke.ObtenerPokemonsEntrenador(idEntrenador);
            return lista;
        }
        public static void AgregarAPokedex(Pokemon pokemon)
        {
            var dalpoke = new DALPokemon();
            dalpoke.AgregarPokemonPokedex(pokemon);
        }
        public static void ModificarEnPokedex(Pokemon pokemon)
        {
            var dalpoke = new DALPokemon();
            dalpoke.ModificarPokemonPokedex(pokemon);
        }
    }
}