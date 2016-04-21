using System.Data.SqlClient;

namespace ExamenFinalLeider.Controlador
{
    public class Conexion
    {
        private SqlConnection con;
        private string datosConexion;

        public Conexion()
        {
            datosConexion = "Data Source = localhost; Initial Catalog = bd_colegio ; Integrated Security = true;";
            con = new SqlConnection(datosConexion);
        }

        public SqlConnection getConnection()
        {
            return con;
        }
    }
}
