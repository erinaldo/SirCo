using System;
using System.Windows.Forms;

namespace business_plan
{
    public partial class Opciones : Form
    {
        public Opciones()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NuevoProyecto np = new NuevoProyecto();
            this.Hide();
            np.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu me = new Menu();
            this.Hide();
            me.ShowDialog();
            this.Close();
        }

        
        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log_in log = new Log_in();
            this.Hide();
            log.ShowDialog();
            this.Close();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log_in log = new Log_in();
            this.Hide();
            log.ShowDialog();
            this.Close();
        }

        private void Opciones_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            eliminar eliminar = new eliminar();
            this.Hide();
            eliminar.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reportes r = new reportes();
            this.Hide();
            r.ShowDialog();
            this.Close();
        }
    }
}