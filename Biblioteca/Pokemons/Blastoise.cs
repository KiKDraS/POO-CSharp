using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Pokemons
{
    public sealed class Blastoise : Evolucion2
    {
        public Blastoise() : base()
        {
            Evoluciones = 3;
            EtapaActual = 3;
            TipoPokemon = Tipo.Agua;

        }

        public Blastoise(int exp) : base(exp)
        {
            Evoluciones = 3;
            EtapaActual = 3;
            TipoPokemon = Tipo.Agua;
            Exp = exp;
        }
        public Blastoise(string nombre, int exp) : base(nombre, exp)
        {
            Evoluciones = 3;
            EtapaActual = 3;
            TipoPokemon = Tipo.Agua;
            Exp = exp;
        }


        public override int RecibirGolpe(Tipo tipo, int golpe)
        {
            if (tipo == Tipo.Planta)
                golpe = Debilidad(golpe);
            else if (tipo == Tipo.Fuego)
                golpe = Resistencia(golpe);

            if (golpe < 0) golpe = 0;

            return golpe;
        }
    }
}
