using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Pokemons
{
    public  sealed class Squirtle : Basico
    {
        public Squirtle(string nombre) : base(nombre)
        {
            Evoluciones = 3;
            EtapaActual = 1;
            TipoPokemon = Tipo.Agua;
        }

        public Squirtle() : base()
        {
            Evoluciones = 3;
            EtapaActual = 1;
            TipoPokemon = Tipo.Agua;
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
