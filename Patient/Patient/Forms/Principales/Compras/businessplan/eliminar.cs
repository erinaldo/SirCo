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
    public partial class eliminar : Form
    {
        #region variables conexion

        private MySqlCommand cmd;
        private string conexion = "SERVER=10.10.1.76; DATABASE=dwh; user=root; PASSWORD=zaptorre;";
        //private string conexion = "SERVER=localhost; DATABASE=dwh; user=root; PASSWORD= ;";
        private MySqlConnection Conn;
        private string query;
        private MySqlDataReader reader;
        #endregion variables conexion

        public eliminar()
        {
            InitializeComponent();
            #region Abrir conexion

            Conn = new MySqlConnection(conexion);
            try
            {
                Conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            #endregion Abrir conexion
        }

        private void eliminar_Load(object sender, EventArgs e)
        {

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                DialogResult Respuesta = MessageBox.Show("Desea eliminar permanentemente el escenario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Respuesta == DialogResult.Yes)
                {
                    try
                    {
                        query = "DELETE FROM escenarios WHERE nombre='"+comboBox1.Text+"';";
                        cmd = new MySqlCommand(query, Conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Eliminado");
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show("Error al guardar " + x.ToString());
                    }
                }
                else
                {

                }
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            query = "SELECT nombre FROM escenarios";
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["nombre"].ToString());
            }
            reader.Close();
        }

        private void menuPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opciones o = new Opciones();
            o.Show();
            this.Close();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log_in l = new Log_in();
            l.Show();
            this.Close();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
