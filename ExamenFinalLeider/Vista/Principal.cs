using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExamenFinalLeider.Vista
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void estudianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form1().Visible = true;
        }

        private void profesorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new iuProfesor().Visible = true;
        }

        private void materiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Materia().Visible = true;
        }
    }
}
