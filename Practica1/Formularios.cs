using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1
{
    public partial class Formularios : Form
    {
        public Formularios()
        { 
            InitializeComponent();
        }

        private void Formularios_Load(object sender, EventArgs e)
        {

        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productos productos = new Productos();
            productos.Show();
        }

        private void suplidoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Suplidores suplidores = new Suplidores();
            suplidores.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Categorias categorias = new Categorias();
            categorias.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
