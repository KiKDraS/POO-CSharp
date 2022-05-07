using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Exceptions
{
    internal class PokemonExisteException : Exception
    {
        public PokemonExisteException() : base()
        {

        }

        public PokemonExisteException(string Message) : base(Message)
        {

        }

        public PokemonExisteException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
