using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Pokemons
{
    public sealed class Raichu : Evolucion
    {
        public Raichu() : base()
        {
            Evoluciones = 2;
            EtapaActual = 2;
            TipoPokemon = Tipo.Electrico;
        }
        public Raichu(int exp) : base(exp)
        {
            Evoluciones = 2;
            EtapaActual = 2;
            TipoPokemon= Tipo.Electrico;
            Exp = exp;
        }

        public Raichu(string nombre, int exp) : base(nombre, exp)
        {
            Evoluciones = 2;
            EtapaActual = 2;
            TipoPokemon = Tipo.Electrico;
            Exp= exp;
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
