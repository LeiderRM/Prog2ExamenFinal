using ExamenFinalLeider.Controlador;
using ExamenFinalLeider.Modelo;
using ExamenFinalLeider.Vista;
using System;
using System.Windows.Forms;

namespace ExamenFinalLeider
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Estudiante est = new Estudiante();
            est.id_estudiante = Int32.Parse(textBox1.Text);
            est.nombre = textBox2.Text;
            est.apellido = textBox3.Text;
            est.direccion = textBox4.Text;
            est.edad = Int32.Parse(textBox5.Text);
            est.id_materia = Int32.Parse(comboBox1.SelectedValue.ToString()); // Ese 1 debe de existir en la tabla de Materias y profesot hay que hacer uno... la relacion.. yo hice el insert a pie
            Estudiante_bd ebd = new Estudiante_bd();
            ebd.Insert(est);
            cargarDataGrid();
            Limpiar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Estudiante est = new Estudiante();
            est.id_estudiante = 1;
            est.nombre = "Pali2";
            est.apellido = "Robles2";
            est.direccion = "Purral2";
            est.edad = 23;
            est.id_materia = 1;
            Estudiante_bd ebd = new Estudiante_bd();
            ebd.Update(est);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            Estudiante_bd ebd = new Estudiante_bd();
            ebd.Delete(id);
            cargarDataGrid();
        }

        private void cargarDataGrid()
        {
            // Carga Datagridview con la tabla de estudiante
            Estudiante_bd ebd = new Estudiante_bd();
            dataGridView1.DataSource = ebd.Select();
        }

        private void Limpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarDataGrid();
             //Cargando cursos
            //Materia_bd mbd = new Materia_bd();
            //comboBox1.DataSource = mbd.SelectCombo();
            //comboBox1.ValueMember = "id_materia";
            //comboBox1.DisplayMember = "nombre";

            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            new iuProfesor().Visible = true;
        }
    }
}
