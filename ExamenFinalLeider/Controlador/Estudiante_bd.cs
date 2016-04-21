using ExamenFinalLeider.Modelo;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ExamenFinalLeider.Controlador
{
    public class Estudiante_bd
    {
        private Conexion c;

        public Estudiante_bd()
        {
            c = new Conexion();
        }

        public DataTable Select()
        {
            string textoCmd = "select * from estudiante;";
            DataTable datos = new DataTable();
            SqlCommand cmd = new SqlCommand(textoCmd, c.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(datos);
            return datos;
        }
        //public DataTable SelectCombo()
        //{
        //    string textoCmd = "select nombre from materia;";
        //    DataTable datos = new DataTable();
        //    SqlCommand cmd = new SqlCommand(textoCmd, c.getConnection());
        //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //    adapter.Fill(datos);
        //    return datos;
        //}
        public void Insert(Estudiante e)
        {
            c.getConnection().Open();
            string textoCmd = "insert into estudiante values(" 
                + e.id_estudiante + "," +
                "'" + e.nombre + "'," +
                "'" + e.apellido + "'," +
                "'" + e.direccion + "'," +
                + e.edad + "," +
                + e.id_materia + ");";
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

        public void Update(Estudiante e)
        {
            c.getConnection().Open();
            string textoCmd = "update estudiante set " +
                "nombre='" + e.nombre + "'," +
                "apellido='" + e.apellido + "'," +
                "direccion='" + e.direccion + "'," +
                "edad=" + e.edad + "," +
                "id_materia=" + e.id_materia + " where id_estudiante=" + e.id_estudiante;
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

        public void Delete(int id)
        {
            c.getConnection().Open();
            string textoCmd = "delete estudiante where id_estudiante=" + id + ";";
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
