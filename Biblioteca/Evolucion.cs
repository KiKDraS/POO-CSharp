using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Interfaces;

namespace Biblioteca
{
    public class Evolucion : Pokemon, ITipo
    {
        public Evolucion(int exp) : base()
        {
            Vida = 100;
            Golpe = 20;
            Exp = exp;
        }

        public Evolucion(string nombre, int exp) : base(nombre)
        {
            Vida = 100;
            Golpe = 20;
            Exp = exp;
        }


        public int Debilidad(int golpe)
        {
            return golpe + 15;
        }

        public int Resistencia(int golpe)
        {
            return golpe - 25;
        }

        public override int RecibirGolpe(Tipo tipo, int golpe) { return 0; }
    }
}
