using Biblioteca.Pokemons;
using Biblioteca.Exceptions;

namespace Biblioteca
{
    public enum Tipo
    {
        Electrico,
        Agua,
        Fuego,
        Planta
    }

    public abstract class Pokemon
    {
        protected Pokemon()
        {
            NombrePokemon = GetType().Name;
            Familia = GetType().Name;
        }

        protected Pokemon(string entrenador)
        {
            NombrePokemon = GetType().Name;
            Familia = GetType().Name;
            NombreEntrenador = entrenador;
        }

        protected Pokemon(string nombre, string entrenador)
        {
            NombrePokemon = nombre;
            Familia = GetType().Name;
            NombreEntrenador= entrenador;
        }

        public int Id { get; set; }
        public string? NombreEntrenador { get; set; }
        public int EntrenadorId { get; set; }
        public int PokemonBaseId { get; set; }
        public string NombrePokemon { get; set; }
        public int Vida { get; set; }
        public int Exp { get; set; }
        public string Familia { get; set; }
        public bool Is_Aviable { get; set; }
        public bool Is_Active { get; set; }
        protected Tipo TipoPokemon { get; set; }
        protected int Evoluciones { get; set; }
        public int EtapaActual { get; set; }
        public int Golpe { get; set; }


        public void SetVida(int vida) {
            Vida = vida;
        }

        public void SetExp(int exp) {
            Exp += exp;
        }

        /// <summary>
        ///     Crea una nueva instancia del objeto sellado correspondiente al árbol Evolucion/Evolucion2 según la propiedad Familia del objeto Pokemon que ejecuta el Método. Lanza la FamiliaNoEncontradaException en caso de error ejecución.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FamiliaNoEncontradaException"></exception>
        public Pokemon Evolucionar()
        {
            Evolucion pokemon = new(Exp);

            if (Exp >= 50 && Exp > 100)
            {
                switch (Familia)
                {
                    case "Pikachu":
                        if (NombrePokemon == Familia)
                            pokemon = new Raichu(Exp);
                        else
                            pokemon = new Raichu(NombrePokemon, Exp);
                        break;
                    case "Bulbasaur":
                        if (NombrePokemon == Familia)
                            pokemon = new Ivysaur(Exp);
                        else
                            pokemon = new Ivysaur(NombrePokemon, Exp);
                        break;
                    case "Charmander":
                        if (NombrePokemon == Familia)
                            pokemon = new Charmeleon(Exp);
                        else
                            pokemon = new Charmeleon(NombrePokemon, Exp);
                        break;
                    case "Squirtle":
                        if (NombrePokemon == Familia)
                            pokemon = new Wartortle(Exp);
                        else
                            pokemon = new Wartortle(NombrePokemon, Exp);
                        break;
                    default: throw new FamiliaNoEncontradaException("No se encontró Basico");
                }
            }
            else if(Exp >= 100 && Evoluciones == 3)
            {
                switch (Familia)
                {
                    case "Ivysaur":
                        if (NombrePokemon == Familia)
                            pokemon = new Venasaur(Exp);
                        else
                            pokemon = new Venasaur(NombrePokemon, Exp);
                        break;
                    case "Charmeleon":
                        if (NombrePokemon == Familia)
                            pokemon = new Charizard(Exp);
                        else
                            pokemon = new Charizard(NombrePokemon, Exp);
                        break;
                    case "Wartortle":
                        if (NombrePokemon == Familia)
                            pokemon = new Blastoise(Exp);
                        else
                            pokemon = new Blastoise(NombrePokemon, Exp);
                        break;
                    default: throw new FamiliaNoEncontradaException("No se encontró Evolucion");
                }

            }

            return pokemon;

        }

        /// <summary>
        ///     Método que cambia el valor almacenado en Vida del objeto Pokemon recibido por parámetro. Utiliza el cáclculo Vida - Golpe.
        /// </summary>
        /// <param name="pokemon"></param>
        public void AtaqueBasico(Pokemon pokemon)
        {            
            int vida = Vida - Golpe;
            pokemon.SetVida(vida);
            int exp = pokemon.Derrotado();
            if(exp > 0)
                SetExp(exp);
        }

        /// <summary>
        ///     Método que cambia el valor almacenado en Vida del objeto Pokemon recibido por parámetro. Lanza el Método Abstracto RecibirGolpe para obtener el valor para el cáclculo de la nueva Vida.
        /// </summary>
        /// <param name="pokemon"></param>
        public void AtaqueTipo(Pokemon pokemon)
        {
                int vida = pokemon.Vida - pokemon.RecibirGolpe(TipoPokemon, Golpe);
                pokemon.SetVida(vida);
                int exp = pokemon.Derrotado();
                if (exp > 0)
                    SetExp(exp);
        }

        /// <summary>
        ///     Método que calcula la fuerza del golpe teniendo en cuenta la aplicación de la interfaz ITipo y el valor almacenado en el atributo Golpe
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="golpe"></param>
        /// <returns>Interger que representa la fuerza del golpe</returns>
        public abstract int RecibirGolpe(Tipo tipo, int golpe);

        /// <summary>
        ///     Método que calcula la cantidad de Vida restante después de un ataque. Si es 0 o menos retorna expriencia ganada
        /// </summary>
        /// <returns>Interger que representa la experiencia ganada.</returns>
        public int Derrotado()
        {
            int exp = 0;

            if(Vida <= 0)
            {
                if (this is Basico)
                    exp = 20;
                else if (this is Evolucion)
                    exp = 40;
                else
                    exp = 80;

                return exp;
            }

            return exp;
        }

        /// <summary>
        ///     Método que maneja el uso de posiciones restauradoras. Todos los pókemon recibirán la misma cantidad de vida de cada posición. Este método puede ser modificado dependiendo del nivel evolutivo del Pokemon.
        /// </summary>
        public virtual void PocionRestauradora()
        {
            SetVida(Vida + 30);
        }
    }
}
