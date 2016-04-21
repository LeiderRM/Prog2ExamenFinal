using ExamenFinalLeider.Modelo;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ExamenFinalLeider.Controlador
{
    public class Profesor_bd
    {
        private Conexion c;

        public Profesor_bd()
        {
            c = new Conexion();
        }

        public DataTable Select()
        {
            string textoCmd = "select * from profesor;";
            DataTable datos = new DataTable();
            SqlCommand cmd = new SqlCommand(textoCmd, c.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(datos);
            return datos;
        }

        public DataTable SelectCombo()
        {
            string textoCmd = "select concat(p.nombre,' ', p.apellido) as nombreCompleto, p.id_profesor from profesor p;";
            DataTable datos = new DataTable();
            SqlCommand cmd = new SqlCommand(textoCmd, c.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(datos);
            return datos;
        }

        public void Insert(Profesor p)
        {
            c.getConnection().Open();
            string textoCmd = "insert into profesor values("
                + p.id_profesor + "," +
                "'" + p.nombre + "'," +
                "'" + p.apellido + "');";
            SqlCommand cmd = new SqlCommand(textoCmd, c.getConnection());
            //Paso 4 - Ejecutar el comando
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                c.getConnection().Close();
            }
        }

        public void Update(Profesor p)
        {
            c.getConnection().Open();
            string textoCmd = "update profesor set " +
                "nombre='" + p.nombre + "'," +
                "apellido='" + p.apellido + "' where id_profesor=" + p.id_profesor;
            SqlCommand cmd = new SqlCommand(textoCmd, c.getConnection());
            //Paso 4 - Ejecutar el comando
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                c.getConnection().Close();
            }
        }

        public void Delete(int id)
        {
            c.getConnection().Open();
            string textoCmd = "delete profesor where id_profesor=" + id + ";";
            SqlCommand cmd = new SqlCommand(textoCmd, c.getConnection());
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                c.getConnection().Close();
            }
        }
    }
}
