using Entities;
using DAL;

namespace BLL
{
    public class BLLEntrenador
    {
        public static List<Entrenador> ObtenerTodos()
        {
            var dalentrenador = new DALEntrenador();
            var lista = dalentrenador.ObtenerTodos();
            return lista;
        }
        public static int ObtenerEntrenador(string nombreEntrenador)
        {
            var dalentrenador = new DALEntrenador();
            var entrenador = dalentrenador.ObternerEntrenador(nombreEntrenador);
            return entrenador.Id;
        }
        public static void Agregar(Entrenador entrenador)
        {
            var dalentrenador = new DALEntrenador();
            dalentrenador.AgregarEntrenador(entrenador);
        }
    }
}
