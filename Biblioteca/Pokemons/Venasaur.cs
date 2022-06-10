using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Pokemons
{
    public sealed class Venasaur : Evolucion2
    {
        public Venasaur(int exp) : base(exp)
        {
            Evoluciones = 3;
            EtapaActual = 3;
            TipoPokemon = Tipo.Planta;
            Exp = exp;
        }

        public Venasaur(string nombre, int exp) : base(nombre, exp)
        {
            Evoluciones = 3;
            EtapaActual = 3;
            TipoPokemon = Tipo.Planta;
            Exp = exp;
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
