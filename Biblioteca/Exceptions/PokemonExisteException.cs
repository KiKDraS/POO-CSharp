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
