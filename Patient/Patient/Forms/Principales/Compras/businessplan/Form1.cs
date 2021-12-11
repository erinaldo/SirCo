using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace business_plan
{
    public partial class Log_in : Form
    {
        #region variables de conexion


        #endregion variables de conexion

        public Log_in()
        {
            InitializeComponent();
            //#region abrir conexion
            //try
            //{
            //    con.Open();
            //}
            //catch (Exception x)
            //{
            //    Console.WriteLine(x.ToString());
            //}
            //#endregion
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String usr = "";
            string pswd = "";
            //string usrx = "";
            //string pswdx = "";
            usr = tbUser.Text;
            pswd = tbPwd.Text;
            //try
            //{
            //    SqlDataReader reader = null;
            //    SqlCommand cmd = new SqlCommand("select [user],[password] from [Prueba].[dbo].[Log_in] where [user] ='" + usr + "' and [password] = '" + pswd + "';", con);
            //    reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        usrx=reader["user"].ToString();
            //        pswdx=reader["password"].ToString();
            //    }
            //    if(usr==usrx)
            //    {
            /*
             *
             *
            Menu m = new Menu();
            m.Show();
            this.Hide();
             */

            Opciones m = new Opciones();
            this.Hide();
            m.ShowDialog();
            this.Close();

            //    }
            //    else
            //    {
            //        MessageBox.Show("Usuario o contraseña incorrectos");
            //        tbPwd.Clear();
            //        tbUser.Clear();
            //        tbUser.Focus();
            //    }
            //    reader.Close();
            //}
            //catch (Exception x)
            //{
            //    MessageBox.Show("Error "+x.ToString());
            //}
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Configconexion c = new Configconexion();
            this.Hide();
            c.ShowDialog();
            this.Close();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            lbversion.Text = "Version: "+business_plan.Properties.Settings.Default.GetType().Assembly.GetName().Version.ToString();
           // lbversion.Text = Application.ProductVersion.ToString();
        }
    }
}