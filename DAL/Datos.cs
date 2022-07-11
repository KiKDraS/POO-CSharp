using System.Data.SqlClient;

namespace DAL
{
    public class Datos
    {
        private readonly SqlConnection cnx;
        public Datos()
        {
            cnx = new()
            {
                ConnectionString = "Server=DESKTOP-O531LQK;database=pokemon;user=ana;password=Password_123;"
            };
        }

        public int EjecutarConsultaSinResultado(string consulta, SqlParameter[] parametros)
        {
            int cantidadFilasAfectadas = 0;
            using (var comando = new SqlCommand(consulta, cnx))
            {
                if (parametros != null && parametros.Length > 0)
                    comando.Parameters.AddRange(parametros);
                cnx.Open();
                cantidadFilasAfectadas = comando.ExecuteNonQuery();
                cnx.Close();
            }
            return cantidadFilasAfectadas;
        }

    }
}
