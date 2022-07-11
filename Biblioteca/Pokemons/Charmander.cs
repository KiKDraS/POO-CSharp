namespace Biblioteca.Pokemons
{
    public sealed class Charmander : Basico
    {
        public Charmander(string nombre) : base(nombre)
        {
            Evoluciones = 3;
            EtapaActual = 1;
            TipoPokemon = Tipo.Fuego;
        }

        public Charmander() : base()
        {
            Evoluciones = 3;
            EtapaActual = 1;
            TipoPokemon = Tipo.Fuego;
        }

        public override int RecibirGolpe(Tipo tipo, int golpe)
        {
            if (tipo == Tipo.Agua)
                golpe = Debilidad(golpe);
            else if (tipo == Tipo.Planta)
                golpe = Resistencia(golpe);

            if (golpe < 0) golpe = 0;

            return golpe;
        }
    }
}
