using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Pokemons
{
    public sealed class Charmeleon : Evolucion
    {
        public Charmeleon() : base()
        {
            Evoluciones = 3;
            EtapaActual = 2;
            TipoPokemon = Tipo.Fuego;

        }

        public Charmeleon(int exp) : base(exp)
        {
            Evoluciones = 3;
            EtapaActual = 2;
            TipoPokemon = Tipo.Fuego;
            Exp = exp;
        }

        public Charmeleon(string nombre, int exp) : base(nombre, exp)
        {
            Evoluciones = 3;
            EtapaActual = 2;
            TipoPokemon = Tipo.Fuego;
            Exp = exp;
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
