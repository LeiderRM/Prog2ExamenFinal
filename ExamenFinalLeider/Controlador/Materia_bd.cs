using ExamenFinalLeider.Modelo;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ExamenFinalLeider.Controlador
{
    public class Materia_bd
    {
        private Conexion c;

        public Materia_bd()
        {
            c = new Conexion();
        }

        public DataTable Select()
        {
            string textoCmd = "select * from materia;";
            DataTable datos = new DataTable();
            SqlCommand cmd = new SqlCommand(textoCmd, c.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(datos);
            return datos;
        }
        public DataTable SelectCombo()
        {
            string textoCmd = "select nombre from materia;";
            DataTable datos = new DataTable();
            SqlCommand cmd = new SqlCommand(textoCmd, c.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(datos);
            return datos;
        }

        public void Insert(Materia m)
        {
            c.getConnection().Open();
            string textoCmd = "insert into materia values("
                + m.id_materia + "," +
                "'" + m.nombre + "'," +
                + m.id_profesor + ");";
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

        public void Update(Materia m)
        {
            c.getConnection().Open();
            string textoCmd = "update materia set " +
                "nombre='" + m.nombre + "'," +
                "id_profesor=" + m.id_profesor + " where id_materia=" + m.id_materia;
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
            string textoCmd = "delete materia where id_materia=" + id + ";";
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
