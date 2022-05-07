using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Pokemons
{
    public sealed class Pikachu : Basico
    {
        public Pikachu(string nombre) : base(nombre)
        {
            Evoluciones = 2;
            EtapaActual = 1;
            TipoPokemon = Tipo.Electrico;
        }

        public Pikachu() : base()
        {
            Evoluciones = 2;
            EtapaActual = 1;
            TipoPokemon= Tipo.Electrico;
        }


        public override int RecibirGolpe(Tipo tipo, int golpe)
        {
            if(tipo == Tipo.Agua)
                golpe = Debilidad(golpe);
            else if(tipo == Tipo.Planta)
                golpe = Resistencia(golpe);

            return golpe;
        }
    }
}
