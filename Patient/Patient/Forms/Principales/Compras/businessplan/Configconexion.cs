using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace business_plan
{
    public partial class Configconexion : Form
    {
        public Configconexion()
        {
            InitializeComponent();
        }

        private void btnProbar_Click(object sender, EventArgs e)
        {
            MySqlConnection Conn;
            string conexion = "";

            if (txtServer.Text != "" && txtUser.Text != "")
            {
                conexion = "SERVER=" + txtServer.Text + "; DATABASE=DWH; UID=" + txtUser.Text + "; PASSWORD=" + txtPassword.Text + ";";
                Conn = new MySqlConnection(conexion);
                MessageBox.Show("Conexión: " + conexion.ToString());
                try
                {
                    Conn.Open();

                    DialogResult Resp = MessageBox.Show("Conexión exitosa, ¿Desea guardar ésta configuración?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Resp == DialogResult.Yes)
                    {
                        //TimbradoFiscal.Properties.Settings.Default.primerapp= "S".ToString();
                        //con = TimbradoFiscal.Properties.Settings.Default.primerapp.ToString();
                        //TimbradoFiscal.Properties.Settings.Default.Save();
                        Properties.Settings.Default.server = txtServer.Text;
                        Properties.Settings.Default.usuario = txtUser.Text;
                        Properties.Settings.Default.pass = txtPassword.Text;
                        Properties.Settings.Default.Save();
                        MessageBox.Show("Configuración almacenada", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPassword.Clear();
                        txtServer.Clear();
                        txtUser.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Configuración descartada", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("No se puede conectar a la base de datos indicada: \n" + ex.ToString(), "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Debe capturar todos los campos para probar la conexión", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Log_in l = new Log_in();
            this.Hide();
            l.ShowDialog();
            this.Close();
        }
    }
}
