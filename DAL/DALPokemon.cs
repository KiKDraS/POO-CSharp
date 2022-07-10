using Entities;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALPokemon
    {
        private readonly Datos datos;
        public DALPokemon()
        {
            datos = new Datos();
        }

        public List<Pokemon> ObtenerPokemonsIniciales()
        {
            List<Pokemon> pokemones = new List<Pokemon>();
            var cnx = new SqlConnection
            {
                ConnectionString = "Server=DESKTOP-O531LQK;database=pokemon;user=ana;password=Password_123;"
            };
            cnx.Open();
            var consulta = "SELECT * FROM dbo.pokemons_base	WHERE [etapa_actual] =  1";
            var comando = new SqlCommand(consulta, cnx);
            SqlDataReader dr = comando.ExecuteReader();
            while (dr.Read())
            {
                var poke = new Pokemon
                {
                    PokemonBaseId = dr.GetInt32(0),
                    Familia = dr.GetString(1),
                    Vida = dr.GetInt32(2),
                    Golpe = dr.GetInt32(3)
                };
                pokemones.Add(poke);
            }
            cnx.Close();
            return pokemones;
        }
        public List<Pokemon> ObtenerPokemonsEntrenador(int idEntrenador)
        {
            List<Pokemon> pokemones = new List<Pokemon>();
            var cnx = new SqlConnection
            {
                ConnectionString = "Server=DESKTOP-O531LQK;database=pokemon;user=ana;password=Password_123;"
            };
            cnx.Open();
            var consulta = $"SELECT dbo.pokedex.pokemon_id, dbo.entrenadores.entrenador_nombre, dbo.entrenadores.entrenador_id, dbo.pokemons_base.pokemon_base_id,dbo.pokedex.pokemon_nombre, dbo.pokedex.pokemon_vida, dbo.pokedex.pokemon_exp, dbo.pokemons_base.golpe_base, dbo.pokemons_base.pokemon_familia, dbo.pokedex.is_aviable, dbo.pokedex.is_active FROM dbo.entrenadores INNER JOIN dbo.pokedex ON dbo.entrenadores.entrenador_id = dbo.pokedex.entrenador_id INNER JOIN dbo.pokemons_base ON dbo.pokedex.pokemon_base_id = dbo.pokemons_base.pokemon_base_id WHERE dbo.pokedex.entrenador_id = {idEntrenador}";
            var comando = new SqlCommand(consulta, cnx);
            SqlDataReader dr = comando.ExecuteReader();
            while (dr.Read())
            {
                var poke = new Pokemon
                {
                    Id = dr.GetInt32(0),
                    NombreEntrenador = dr.GetString(1),
                    EntrenadorId = dr.GetInt32(2),
                    PokemonBaseId = dr.GetInt32(3),
                    NombrePokemon = dr.GetString(4),
                    Vida = dr.GetInt32(5),
                    Exp = dr.GetInt32(6),
                    Golpe = dr.GetInt32(7),
                    Familia = dr.GetString(8),
                    Is_Aviable = (bool)dr.GetValue(9),
                    Is_Active = (bool)dr.GetValue(10)
                };
                pokemones.Add(poke);
            }
            cnx.Close();
            return pokemones;
        }
        public void AgregarPokemonPokedex(Pokemon pokemon)
        {
            var consulta = "INSERT INTO [dbo].[pokedex] ([entrenador_id], [pokemon_base_id], [pokemon_nombre], [pokemon_vida], [pokemon_exp], [is_aviable], [is_active]) VALUES (@entrenadorId, @pokeBaseId, @nombre, @vida, @exp, @aviable, @active)";
            datos.EjecutarConsultaSinResultado(consulta, ParametrosPokemon(pokemon, false));
        }
        public void ModificarPokemonPokedex(Pokemon pokemon)
        {
            var consulta = $"UPDATE [dbo].[pokedex] SET [pokemon_vida] = @vida, [pokemon_exp] = @exp, [is_aviable] = @aviable, [is_active] = @active WHERE [pokemon_id] = @id";
            datos.EjecutarConsultaSinResultado(consulta, ParametrosPokemon(pokemon, true));
        }
        private SqlParameter[] ParametrosPokemon(Pokemon pokemon, bool isUpd)
        {
            var paramId = new SqlParameter("@id", pokemon.Id);
            var paramNomb = new SqlParameter("@nombre", pokemon.NombrePokemon);
            var paramVida = new SqlParameter("@vida", pokemon.Vida);
            var paramExp = new SqlParameter("@exp", pokemon.Exp);
            var paramAviable = new SqlParameter("@aviable", pokemon.Is_Aviable);
            var paramActive = new SqlParameter("@active", pokemon.Is_Active);
            var paramEntId = new SqlParameter("@entrenadorId", pokemon.EntrenadorId);
            var paramPokeBaseId = new SqlParameter("@pokeBaseId", pokemon.PokemonBaseId);

            if (isUpd)
                return new SqlParameter[] { paramId, paramVida, paramExp, paramAviable, paramActive };
            
            return new SqlParameter[] { paramEntId, paramPokeBaseId, paramNomb, paramVida, paramExp, paramAviable, paramActive };
        }

    }
}