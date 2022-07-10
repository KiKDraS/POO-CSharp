using Entities;
using DAL;
using System.Collections.Generic;
using System.Linq;

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
        public static void ObtenerEntrenador(int idEntrenador)
        {
            var dalentrenador = new DALEntrenador();
            var entrenador = dalentrenador.ObternerEntrenador(idEntrenador);
            Console.WriteLine(entrenador.Nombre);
        }
        public static void Agregar(Entrenador entrenador)
        {
            var dalentrenador = new DALEntrenador();
            dalentrenador.AgregarEntrenador(entrenador);
        }
    }
}
