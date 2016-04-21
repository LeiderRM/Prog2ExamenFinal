using ExamenFinalLeider.Controlador;
using ExamenFinalLeider.Modelo;
using System;
using System.Windows.Forms;

namespace ExamenFinalLeider.Vista
{
    public partial class iuProfesor : Form
    {
        public iuProfesor()
        {
            InitializeComponent();
        }
        private void cargarDataGrid()
        {
            // Carga Datagridview con la tabla de estudiante
            Profesor_bd ebd = new Profesor_bd();
            dataGridView1.DataSource = ebd.Select();
        }

        private void Limpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }
        private void iuProfesor_Load(object sender, EventArgs e)
        {

            cargarDataGrid();
            Profesor_bd pbd = new Profesor_bd();
            comboBox1.DataSource = pbd.SelectCombo();
            comboBox1.DisplayMember = "nombreCompleto";
            comboBox1.ValueMember = "id_profesor";
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Profesor prof = new Profesor();
            prof.id_profesor = Int32.Parse(textBox1.Text);
            prof.nombre = textBox2.Text;
            prof.apellido = textBox3.Text;
            //est.direccion = textBox4.Text;
            //est.edad = Int32.Parse(textBox5.Text);
            //est.id_materia = Int32.Parse(comboBox1.SelectedValue.ToString()); // Ese 1 debe de existir en la tabla de Materias y profesot hay que hacer uno... la relacion.. yo hice el insert a pie
            Profesor_bd ebd = new Profesor_bd();
            ebd.Insert(prof);
            cargarDataGrid();
            Limpiar();
        }
    }
}
