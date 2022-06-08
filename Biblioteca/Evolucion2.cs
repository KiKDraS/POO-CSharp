using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Interfaces;

namespace Biblioteca
{
    public class Evolucion2 : Evolucion, ITipo
    {
        public Evolucion2(int exp) : base(exp)
        {
            Vida = 150;
            Golpe = 30;
            Exp = exp;
        }

        public Evolucion2(string nombre, int exp) : base(nombre, exp)
        {
            Vida = 150;
            Golpe = 30;
            Exp = exp;
        }

        public new int Debilidad(int golpe)
        {
            return golpe + 10;
        }

        public new int Resistencia(int golpe)
        {
            return golpe - 30;
        }

        public override int RecibirGolpe(Tipo tipo, int golpe) { return 0; }

        public new void PosionRestauradora()
        {
            SetVida(Vida + 50);
        }
    }
}
