namespace Biblioteca.Exceptions
{
    /// <summary>
    ///     Exception lanzada cuando el dato Familia es "" o null
    /// </summary>
    public  sealed class FamiliaNoEncontradaException : Exception
    {
        public FamiliaNoEncontradaException() : base()  
        {

        }

        public FamiliaNoEncontradaException(string Message) : base(Message)
        {

        }

        public FamiliaNoEncontradaException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
