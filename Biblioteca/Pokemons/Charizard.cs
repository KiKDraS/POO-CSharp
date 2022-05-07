﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Pokemons
{
    public sealed class Charizard : Evolucion2
    {
        public Charizard(int exp) : base(exp)
        {
            Evoluciones = 3;
            EtapaActual = 3;
            TipoPokemon = Tipo.Fuego;
            Exp = exp;
        }
        public Charizard(string nombre, int exp) : base(nombre, exp)
        {
            Evoluciones = 3;
            EtapaActual = 3;
            TipoPokemon = Tipo.Fuego;
            Exp = exp;
        }

        public override int RecibirGolpe(Tipo tipo, int golpe)
        {
            if (tipo == Tipo.Agua)
                golpe = Debilidad(golpe);
            else if (tipo == Tipo.Planta)
                golpe = Resistencia(golpe);

            return golpe;
        }
    }
}