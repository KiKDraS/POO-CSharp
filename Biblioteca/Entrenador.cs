using Biblioteca.Exceptions;

namespace Biblioteca
{
    public class Entrenador
    {
        public Entrenador(string nombre)
        {
            Nombre = nombre;
            Pokedex = new Pokedex();
        }

        public Entrenador(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
            Pokedex = new Pokedex();
        }

        public  int Id { get; set; } 
        public string Nombre { get; set; }
        public Pokedex Pokedex { get; set; }
        public Pokemon? PokemonActivo { get; set; }
        public Pokemon? PokemonSalvaje { get; set; }

        private Random rand = new();

        /// <summary>
        ///     Método para limpiar el dato PokemonActivo/PokemonSalvaje. Si se limpia PokemonSalvaje, además lo agrega a Pokedex en caso de que no exista otro Pokemon de la misma Familia
        /// </summary>
        public void BorrarPokemon(Pokemon pokemon)
        {

            if (PokemonActivo.Familia == pokemon.Familia && PokemonActivo.NombrePokemon == pokemon.NombrePokemon)
            {
                PokemonActivo.Is_Active = false;
                PokemonActivo = null;
            }
            else
            {
                bool existe = false;
                foreach (var poke in Pokedex.GetPokemons())
                {
                    if (PokemonSalvaje.Familia == poke.Familia)
                        existe = true;
                }

                if (existe)
                    PokemonSalvaje = null;
                else
                {
                    switch (PokemonSalvaje.Familia)
                    {
                        case "Pikachu":
                            PokemonSalvaje.EntrenadorId = Id;
                            PokemonSalvaje.PokemonBaseId = 1;
                            break;
                        case "Raichu":
                            PokemonSalvaje.EntrenadorId = Id;
                            PokemonSalvaje.PokemonBaseId = 2;
                            break;
                        case "Bulbasaur":
                            PokemonSalvaje.EntrenadorId = Id;
                            PokemonSalvaje.PokemonBaseId = 3;
                            break;
                        case "Ivysaur":
                            PokemonSalvaje.EntrenadorId = Id;
                            PokemonSalvaje.PokemonBaseId = 4;
                            break;
                        case "Venasaur":
                            PokemonSalvaje.EntrenadorId = Id;
                            PokemonSalvaje.PokemonBaseId = 5;
                            break;
                        case "Squirtle":
                            PokemonSalvaje.EntrenadorId = Id;
                            PokemonSalvaje.PokemonBaseId = 6;
                            break;
                        case "Wratortle":
                            PokemonSalvaje.EntrenadorId = Id;
                            PokemonSalvaje.PokemonBaseId = 7;
                            break;
                        case "Blastoise":
                            PokemonSalvaje.EntrenadorId = Id;
                            PokemonSalvaje.PokemonBaseId = 8;
                            break;
                        case "Charmander":
                            PokemonSalvaje.EntrenadorId = Id;
                            PokemonSalvaje.PokemonBaseId = 9;
                            break;
                        case "Charmeleon":
                            PokemonSalvaje.EntrenadorId = Id;
                            PokemonSalvaje.PokemonBaseId = 10;
                            break;
                        case "Charizard":
                            PokemonSalvaje.EntrenadorId = Id;
                            PokemonSalvaje.PokemonBaseId = 11;
                            break;
                    }
                    AgregarPokemonPokedex(PokemonSalvaje);
                    PokemonSalvaje = null;
                }
                
                
            }
        }

        /// <summary>
        ///     Devuelve un string con el nombre del PokemonActivo
        /// </summary>
        /// <returns></returns>
        public string GetPokemonActivo()
        {
            string str = "";

            if(PokemonActivo.NombrePokemon == PokemonActivo.Familia)
                return PokemonActivo.NombrePokemon;
            else
                str = $"{PokemonActivo.NombrePokemon}({PokemonActivo.Familia})";
            
            return str;
        }

        /// <summary>
        ///     Actualiza la Pokedex con un nuevo Pokemon
        /// </summary>
        /// <param name="pokemon"></param>
        public void AgregarPokemonPokedex(Pokemon pokemon)
        {
            try
            {
                Pokedex.ActualizarPokedex(pokemon);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Error null exception: {ex.Message}");
            }
            catch(PokemonExisteException ex)
            {
                Console.WriteLine($"Error Pkemon Existe exception: {ex.Message}");
            }
        }

        /// <summary>
        ///     Método que permite la selección manual de un Pokemon que se encuentre en la Lista Pokemons
        /// </summary>
        /// <param name="i"></param>
        public void SeleccionarPokemonActivo(int i)
        {
            PokemonActivo = Pokedex.GetPokemon(i);
            PokemonActivo.Is_Active = true;
            foreach (var poke in Pokedex.GetPokemons())
            {
                if(poke.NombrePokemon != PokemonActivo.NombrePokemon)
                {
                    PokemonActivo.Is_Active = false;
                }
            }
        }

        /// <summary>
        ///     Método que recibe un Objeto Pokemon y agrega como valor del Atributo Pokemon Salvaje
        /// </summary>
        /// <param name="pokemon"></param>
        public void Explorar(Pokemon pokemon)
        {
            PokemonSalvaje = pokemon;
        }

        /// <summary>
        ///     Método para atacar al PokemonSalvaje que utiliza un random para decidir si el ataque se logra (resta Vida a PokemonSalvaje) o es contrarestado (resta Vida a PokemonActivo). Llama al Método AtaqueBásico del Pokemon correspondiente. Llama a los Métodos BorrarPokemon, Evolucion y SeleccionarPokemonActivo según corresponda.
        /// </summary>
        public void AtaqueBasico()
        {
            if (PokemonActivo == null)
                return;

            int golpear = rand.Next(1, 10);

            if (golpear >= 1 && golpear < 6)
            {
                PokemonSalvaje.AtaqueBasico(PokemonActivo); 
                if(PokemonActivo.Vida <= 0)
                {
                    PokemonActivo.Vida = 0;
                    BorrarPokemon(PokemonActivo);
                }
            }
            else
            {
                PokemonActivo.AtaqueBasico(PokemonSalvaje);
                if (PokemonSalvaje.Vida <= 0)
                    BorrarPokemon(PokemonSalvaje);
            }
        }

        /// <summary>
        ///     Método para atacar al PokemonSalvaje que utiliza un random para decidir si el ataque se logra (resta Vida a PokemonSalvaje) o es contrarestado (resta Vida a PokemonActivo). Llama al Método AtaqueTipo del Pokemon correspondiente. Llama a los Métodos BorrarPokemon y Evolucion.
        /// </summary>
        public void AtaqueTipo()
        {
            if (PokemonActivo == null)
                return;

            int golpear = rand.Next(1, 10);

            if (golpear >= 1 && golpear < 6)
            {
                PokemonSalvaje.AtaqueTipo(PokemonActivo);
                if (PokemonActivo.Vida <= 0)
                {
                    PokemonActivo.Vida = 0;
                    BorrarPokemon(PokemonActivo);
                }
            }
            else
            {
                PokemonActivo.AtaqueTipo(PokemonSalvaje);
                if (PokemonSalvaje.Vida <= 0)
                    BorrarPokemon(PokemonSalvaje);
            }
        }

        /// <summary>
        ///     Llama al Método Evolucionar del PokemonActivo. Bloque try/catch para manejar posibles errores en la creación y eliminación de los objetos involucrados en el Método Evolucionar del PokemonActivo. Llama al Método Reset de Vistas en caso de ser necesario.
        /// </summary>
        public void Evolucion()
        {
            try
            {
                PokemonActivo.Is_Aviable = false;
                Pokemon evolucion = PokemonActivo.Evolucionar();
                Pokedex.ActualizarPokedexEvolucion(PokemonActivo, evolucion);
                PokemonActivo = evolucion;
                PokemonActivo.EntrenadorId = Id;
                switch (PokemonActivo.Familia)
                {
                    case "Raichu":
                        PokemonActivo.Is_Aviable = true;
                        PokemonActivo.Is_Active = true;
                        PokemonActivo.PokemonBaseId = 2;
                        break;
                    case "Ivysaur":
                        PokemonActivo.Is_Aviable = true;
                        PokemonActivo.Is_Active = true;
                        PokemonActivo.PokemonBaseId = 4;
                        break;
                    case "Venasaur":
                        PokemonActivo.Is_Aviable = true;
                        PokemonActivo.Is_Active = true;
                        PokemonActivo.PokemonBaseId = 5;
                        break;
                    case "Wartortle":
                        PokemonActivo.Is_Aviable = true;
                        PokemonActivo.Is_Active = true;
                        PokemonActivo.PokemonBaseId = 7;
                        break;
                    case "Blastoise":
                        PokemonActivo.Is_Aviable = true;
                        PokemonActivo.Is_Active = true;
                        PokemonActivo.PokemonBaseId = 8;
                        break;
                    case "Charmeleon":
                        PokemonActivo.Is_Aviable = true;
                        PokemonActivo.Is_Active = true;
                        PokemonActivo.PokemonBaseId = 10;
                        break;
                    case "Charizard":
                        PokemonActivo.Is_Aviable = true;
                        PokemonActivo.Is_Active = true;
                        PokemonActivo.PokemonBaseId = 11;
                        break;
                }
                if (string.IsNullOrEmpty(PokemonActivo.NombrePokemon))
                    PokemonActivo.NombrePokemon = PokemonActivo.Familia;
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"Error null exception: {ex.Message}");
            }
            catch (FamiliaNoEncontradaException ex)
            {
                Console.WriteLine($"Error Familia exception: {ex.Message}");
            }
        }

        /// <summary>
        ///     LLamado al método DarPocion() del Objeto Pokemon
        /// </summary>
        public void DarPocion()
        {
            PokemonActivo.PocionRestauradora();
        }
    }
}