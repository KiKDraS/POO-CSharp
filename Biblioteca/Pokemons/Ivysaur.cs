namespace Biblioteca.Pokemons
{
    public sealed class Ivysaur : Evolucion
    {
        public Ivysaur() : base()
        {
            Evoluciones = 3;
            EtapaActual = 2;
            TipoPokemon = Tipo.Planta;
        }

        public Ivysaur(int exp) : base(exp)
        {
            Evoluciones = 3;
            EtapaActual = 2;
            TipoPokemon = Tipo.Planta;
            Exp = exp;
        }

        public Ivysaur(string nombre, int exp) : base(nombre, exp)
        {
            Evoluciones = 3;
            EtapaActual = 2;
            TipoPokemon = Tipo.Planta;
            Exp = exp;
        }



        public override int RecibirGolpe(Tipo tipo, int golpe)
        {
            if (tipo == Tipo.Fuego)
                golpe = Debilidad(golpe);
            else if (tipo == Tipo.Planta)
                golpe = Resistencia(golpe);

            if (golpe < 0) golpe = 0;

            return golpe;
        }
    }
}
