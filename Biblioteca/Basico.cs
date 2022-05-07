using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Interfaces;

namespace Biblioteca
{
    public class Basico : Pokemon, ITipo
    {
        public Basico(string nombre) : base(nombre)
        {
            Vida = 50;
            Golpe = 10;
        }

        public Basico() : base()
        {
            Vida = 50;
            Golpe = 10;
        }

        public int Debilidad(int golpe)
        {
            return golpe + 20;
        }

        public int Resistencia(int golpe)
        {
            return golpe - 20;
        }

        public override int RecibirGolpe(Tipo tipo, int golpe) { return 0; }
    }
}
