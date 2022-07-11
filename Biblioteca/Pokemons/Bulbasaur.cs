namespace Biblioteca.Pokemons
{
    public sealed class Bulbasaur : Basico
    {
        public Bulbasaur(string nombre) : base(nombre)
        {
            Evoluciones = 3;
            EtapaActual = 1;
            TipoPokemon = Tipo.Planta;
        }

        public Bulbasaur() : base()
        {
            Evoluciones = 3;
            EtapaActual = 1;
            TipoPokemon = Tipo.Planta;
        }

        public override int RecibirGolpe(Tipo tipo, int golpe)
        {
            if (tipo == Tipo.Fuego)
                golpe = Debilidad(golpe);
            else if (tipo == Tipo.Agua)
                golpe = Resistencia(golpe);

            if (golpe < 0) golpe = 0;

            return golpe;
        }
    }
}
