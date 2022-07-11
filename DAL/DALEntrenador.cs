using Entities;
using System.Data.SqlClient;

namespace DAL
{
    public class DALEntrenador
    {
        private readonly Datos datos;
        public DALEntrenador()
        {
            datos = new Datos();
        }

        public List<Entrenador> ObtenerTodos()
        {
            var entrenadores = new List<Entrenador>();
            var cnx = new SqlConnection
            {
                ConnectionString = "Server=DESKTOP-O531LQK;database=pokemon;user=ana;password=Password_123;"
            };
            cnx.Open();
            var consulta = "SELECT * FROM dbo.entrenadores";
            var comando = new SqlCommand(consulta, cnx);
            SqlDataReader dr = comando.ExecuteReader();
            while (dr.Read())
            {
                var entrenador = new Entrenador
                {
                    Id = dr.GetInt32(0),
                    Nombre = dr.GetString(1)
                };
                entrenadores.Add(entrenador);
            }
            cnx.Close();
            return entrenadores;
        }
        public Entrenador ObternerEntrenador(string nombreEntrenador)
        {
            Entrenador entrenador = null;
            var cnx = new SqlConnection
            {
                ConnectionString = "Server=DESKTOP-O531LQK;database=pokemon;user=ana;password=Password_123;"
            };
            cnx.Open();
            var consulta = $"SELECT [entrenador_id] FROM dbo.entrenadores WHERE [entrenador_nombre] = '{nombreEntrenador}'";
            var comando = new SqlCommand(consulta, cnx);
            SqlDataReader dr = comando.ExecuteReader();
            while (dr.Read())
            {
                entrenador = new()
                {
                    Id = dr.GetInt32(0)
                };
            }
            cnx.Close();

            return entrenador;
        }
        public void AgregarEntrenador(Entrenador entrenador)
        {
            var consulta = "INSERT INTO [dbo].[entrenadores] ([entrenador_nombre]) VALUES (@nombre)";
            datos.EjecutarConsultaSinResultado(consulta, ParamentrosEntrenador(entrenador, false));
        }
        private SqlParameter[] ParamentrosEntrenador(Entrenador entrenador, bool isObtain)
        {
            var paramId = new SqlParameter("@id", entrenador.Id);
            var paramNomb = new SqlParameter("@nombre", entrenador.Nombre);
            if(isObtain)
                return new SqlParameter[] { paramId };
            return new SqlParameter[] { paramNomb };
        }
    }
}
