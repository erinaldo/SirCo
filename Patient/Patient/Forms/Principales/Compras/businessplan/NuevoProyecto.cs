using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Globalization;

namespace business_plan
{
    public partial class NuevoProyecto : Form
    {
        #region variables conexion

        private MySqlConnection Conn;
        private string query;
        private MySqlCommand cmd;
        private MySqlDataReader reader;
        private string conexion = "SERVER=" + Properties.Settings.Default.server + "; DATABASE=dwh; user=" + Properties.Settings.Default.usuario + "; PASSWORD=" + Properties.Settings.Default.pass + ";"; 
        //private string conexion2 = "SERVER=10.10.1.76; DATABASE=cipsis; user=root; PASSWORD=zaptorre;";
        //private string conexion = "SERVER=localhost; DATABASE=cipsis; user=root; PASSWORD=;";
      // private string conexion = "SERVER=localhost; DATABASE=dwh; user=root; PASSWORD= ;";

        #endregion variables conexion
        string[] idsucursal=new string[1000];
        public NuevoProyecto()
        {
            #region Abrir conexion dwh

            Conn = new MySqlConnection(conexion);
            try
            {
                Conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            #endregion Abrir conexion dwh

            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //m_verificarComponentes();
            double rebaja = 0;
            rebaja = double.Parse(tbRebajas.Text);
            DateTime f1 = DateTime.Now, f2 = DateTime.Now;
            
                int solocalzado = 1;
                if(checkBox1.Checked==true)
                {
                    solocalzado = 1;
                }
                else
                {
                    solocalzado = 0;
                }
                
                f1 = DateTime.Parse(dtpFechainicial.Text);
                f2 = DateTime.Parse(dtpFechafinal.Text);
                int meses = -1 * ((f1.Month - f2.Month) + 12 * (f1.Year - f2.Year));
                if(meses>=1)
                {
                    f1 = f1.AddYears(-1);
                    f2 = f2.AddYears(-1);
                    //MessageBox.Show(f1.ToString("yyyy-MM-dd"));
                    //MessageBox.Show(f2.ToString("yyyy-MM-dd"));
                    query = "INSERT INTO escenarios (nombre,fechainicial,fechainicialA,fechafinal,fechafinalA,solocalzado,rebajas) VALUES ('" + tbNombre.Text + "','" + dtpFechainicial.Text + "','" + f1.ToString("yyyy-MM-dd") + "','" + dtpFechafinal.Text + "','" + f2.ToString("yyyy-MM-dd") + "'," + solocalzado.ToString() + "," + rebaja.ToString() + ")";
                    cmd = new MySqlCommand(query, Conn);
                    cmd.ExecuteNonQuery();
                    Properties.Settings.Default.escenario = tbNombre.Text;
                    //Properties.Settings.Default.usuario = false;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("guardado");
                    Cedula1 c1 = new Cedula1();
                    c1.Show();
                    this.Hide();
                }
            else
                {
                    MessageBox.Show("Selecciona un periodo de tiempo mayor");
                    dtpFechafinal.Focus();
                }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Opciones o = new Opciones();
            this.Hide();
            o.ShowDialog();
            this.Close();
        }

        private void NuevoProyecto_Load(object sender, EventArgs e)
        {
        }

        private void cbSucursalAsignar_DropDown(object sender, EventArgs e)
        {
            cbSucursalAsignar.Items.Clear();
            int i = 0;
            string q = "SELECT descrip,idsucursal from sucursal ";
            cmd = new MySqlCommand(q, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbSucursalAsignar.Items.Add(reader["descrip"].ToString());
                idsucursal[i]=reader["idsucursal"].ToString();
                i++;
            }
            reader.Close();
        }

        private void m_formar_gridGasto()
        {
            DateTime fi=DateTime.Now,ff=DateTime.Now;
            fi = DateTime.Parse(dtpFechainicial.Text);
            ff = DateTime.Parse(dtpFechafinal.Text);
            //int dias1 = 0; int dias2 = 0; int mes1 = 0; int mes2 = 0; int anio1 = 0; int anio2=0;
            if(fi==ff)
            {

            }
            else
            {
                int meses= -1*((fi.Month - ff.Month) + 12 * (fi.Year - ff.Year));
                for(int i=1;i<=meses+1;i++)
                {
                    //dataGridView1.Rows.Add();
                    //dataGridView1.Rows[(i-1)].Cells[0].Value=fi.ToString("MMMM");
                    //dataGridView1.Rows[(i-1)].Cells[2].Value=fi.ToString("MM");
                    //dataGridView1.Rows[(i-1)].Cells[3].Value=fi.ToString("yyyy");
                    //fi = fi.AddMonths(1);
                    //#region cargar guardado
                    //if (tbNombre.Text != "")
                    //{
                    //    string q = "SELECT * FROM gastobp where Escenario='" + tbNombre.Text + "' and mes=" + dataGridView1.Rows[(i - 1)].Cells[2].Value.ToString() + " and anio=" + dataGridView1.Rows[(i - 1)].Cells[3].Value.ToString();
                    //    cmd = new MySqlCommand(q, Conn);
                    //    reader = cmd.ExecuteReader();
                    //    while (reader.Read())
                    //    {
                    //        dataGridView1.Rows[(i-1)].Cells[1].Value=reader["gasto"].ToString();
                    //    }
                    //    reader.Close();
                    //}
                    //#endregion
                    //MessageBox.Show(fi.ToString());
                    //MessageBox.Show(dataGridView1.Rows[(i-1)].Cells[2].Value.ToString());
                }
            }
        }
        private void m_verificarGrid()
        {
            //if (dataGridView1.Rows.Count >= 1)
            //{
            //    for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            //    {
            //        if(dataGridView1.Rows[i].Cells[1].Value.ToString()!="")
            //        {
                        
            //        }
            //        else
            //        {
            //            MessageBox.Show("Ingresa el gasto");
            //            dataGridView1.Rows[i].Cells[1].Selected=true;
            //        }
            //    }
            //}
        }
        private void m_verificarComponentesEscenario()
        {
            if(tbNombre.Text=="")
            {
                MessageBox.Show("Ingresa un nombre");
                tbNombre.Clear();
                tbNombre.Focus();
            }
            //if(dateTimePicker1.Text==dateTimePicker2.Text)
            //{
            //    MessageBox.Show("Ingresa una fecha correcta");
            //    dateTimePicker2.Focus();
            
            if(tbRebajas.Text=="")
            {
                MessageBox.Show("Ingresa una cantidad");
                tbRebajas.Clear();
                tbRebajas.Focus();
            }
        }

        private void keypressparse(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                        && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            base.OnKeyPress(e);
        }

        #region dgv evitar letras
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                        && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            base.OnKeyPress(e);
        }


        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
        }
        #endregion

        private void btnPeriodoSucursal_Click(object sender, EventArgs e)
        {
            string nombreNuevo="";
            string nombreEspejo = "";
            double porcentaje = 0;
            DateTime fechainicio = DateTime.Now;

            string plaza = "";
            DateTime fechaapertura = DateTime.Now;
            string periodoIrecibo = "";
            string periodoFrecibo = "";
            double inventarioinicial = 0;
            double renta = 0;
            double guante = 0;
            double gasto = 0;
            double inversionConstruccion = 0;
            double gastoFiscal = 0;
            double gastoPublicidad = 0;
            double gastoApoyo = 0;

            ////////////////////////////////////////////
            #region asignar valores
            nombreNuevo = tbsucursalnueva.Text;
            nombreEspejo = cbSucursalAsignar.Text;
            porcentaje = double.Parse(tbporcentaje.Text);
            fechainicio = DateTime.Parse(dtpfechainicioSucursal.Text);

            plaza = "Torreon";
            fechaapertura = DateTime.Parse(dtpAperturaSucursal.Text);
            periodoFrecibo = periodoReciboF.Text;
            periodoIrecibo = periodoReciboI.Text;
            inventarioinicial = double.Parse(tbInvinicialSucursal.Text,NumberStyles.Currency);
            renta = double.Parse(tbrentasucursal.Text,NumberStyles.Currency);
            guante = double.Parse(tbguantesucursal.Text,NumberStyles.Currency);
            gasto = double.Parse(tbGastotienda.Text,NumberStyles.Currency);
            inversionConstruccion = double.Parse(tbinversionConstruccionsuc.Text,NumberStyles.Currency);
            gastoFiscal = double.Parse(tbFiscales.Text,NumberStyles.Currency);
            gastoPublicidad = double.Parse(tbPublicidad.Text,NumberStyles.Currency);
            gastoApoyo = double.Parse(tbApoyo.Text,NumberStyles.Currency);

            ////////////////////////////////////////////////

            query = "INSERT INTO sucursalesbp (descripbp,descrip,idsucursal,plaza,fechaApertura,periodoreciboI,periodoreciboF,inventarioinicial,renta,guante,gastotienda,inversionconstruccion,gastofiscal,gastopublicidad,gastoapoyo,fechainicioSuc,porcentaje) VALUES ('"+nombreNuevo+"','"+cbSucursalAsignar.Text+"',"+idsucursal[cbSucursalAsignar.SelectedIndex]+",'"+plaza+"','"+fechaapertura.ToString("yyyy-MM-dd")+"','"+periodoIrecibo+"','"+periodoFrecibo+"',"+inventarioinicial+","+renta+","+guante+","+gasto+","+inversionConstruccion+","+gastoFiscal+","+gastoPublicidad+","+gastoApoyo+",'"+fechainicio.ToString("yyyy-MM-dd")+"',"+porcentaje+")";
            cmd = new MySqlCommand(query, Conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Guardado");
            #endregion
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            //m_verificarComponentesEscenario();
            if (tbNombre.Text != ""&&dtpFechainicial!=dtpFechafinal)
            {
                string nombre = "";
                DateTime fechainicio = DateTime.Now;
                DateTime fechafinal = DateTime.Now;
                DateTime fechacreacion = DateTime.Now;
                double rebajas = 0;
                bool solocalzado = true;

                ////////////////////////////////////////////
                nombre = tbNombre.Text;
                fechainicio = DateTime.Parse(dtpFechainicial.Text);
                fechafinal = DateTime.Parse(dtpFechafinal.Text);
                rebajas = double.Parse(tbRebajas.Text);
                solocalzado = checkBox1.Checked;

                //fechafinal.AddYears(-1);
                //////////////////////////////////////////
                bool duplicado = false;
                string q = "Select nombre from escenarios where nombre='"+tbNombre.Text+"'";
                cmd = new MySqlCommand(q, Conn);
                reader = cmd.ExecuteReader();
                if(reader.HasRows==true)
                {
                    duplicado = true;
                }
                else { duplicado = false; } reader.Close();
                if (duplicado == false)
                {
                    query = "INSERT INTO escenarios (nombre,fechainicial,fechainicialA,fechafinal,fechafinalA,solocalzado,rebajas,FechaCreacion) VALUES ('" + tbNombre.Text + "','" + dtpFechainicial.Text + "','" + fechainicio.AddYears(-1).ToString("yyyy-MM-dd") + "','" + dtpFechafinal.Text + "','" + fechafinal.AddYears(-1).ToString("yyyy-MM-dd") + "'," + solocalzado + "," + rebajas + ",'" + fechacreacion.ToString("yyyy-MM-dd") + "')";
                    cmd = new MySqlCommand(query, Conn);
                    cmd.ExecuteNonQuery();
                    Properties.Settings.Default.escenario = tbNombre.Text;
                    //Properties.Settings.Default.usuario = false;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("guardado");
                    Cedula1 c1 = new Cedula1();
                    this.Hide();
                    c1.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El nombre del escenario esta repetido ");
                }
            }
            else
            {
                if(string.IsNullOrEmpty(tbNombre.Text)==true)
                {
                    MessageBox.Show("Ingresa un nombre valido para el escenario");
                }
            }
        }

        private void tabControl2_Selecting(object sender, TabControlCancelEventArgs e)
        {
            dgvSucursal.Rows.Clear();
            string nombreNuevo = "";
            string nombreEspejo = "";
            double porcentaje = 0;
            DateTime fechainicio = DateTime.Now;

            string plaza = "";
            DateTime fechaapertura = DateTime.Now;
            string periodoIrecibo = "";
            string periodoFrecibo = "";
            double inventarioinicial = 0;
            double renta = 0;
            double guante = 0;
            double gasto = 0;
            double inversionConstruccion = 0;
            double gastoFiscal = 0;
            double gastoPublicidad = 0;
            double gastoApoyo = 0;
            bool estado = true;

            int i = 0;
            string q = "SELECT * from sucursalesbp ";
            cmd = new MySqlCommand(q, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dgvSucursal.Rows.Add();
                nombreNuevo=reader["descripbp"].ToString();
                nombreEspejo=reader["descrip"].ToString();
                ///////////////////
                porcentaje = double.Parse(reader["porcentaje"].ToString());
                fechainicio = DateTime.Parse(reader["fechainicioSuc"].ToString());
                plaza =reader["plaza"].ToString();
                fechaapertura = DateTime.Parse(reader["fechaApertura"].ToString());
                periodoIrecibo=reader["periodoreciboI"].ToString();
                periodoFrecibo=reader["periodoreciboF"].ToString();
                inventarioinicial = double.Parse(reader["inventarioinicial"].ToString());
                renta = double.Parse(reader["renta"].ToString());
                guante = double.Parse(reader["guante"].ToString());
                gasto = double.Parse(reader["gastotienda"].ToString());
                inversionConstruccion = double.Parse(reader["inversionconstruccion"].ToString());
                gastoFiscal = double.Parse(reader["gastofiscal"].ToString());
                gastoPublicidad = double.Parse(reader["gastopublicidad"].ToString());
                gastoApoyo = double.Parse(reader["gastoapoyo"].ToString());
                estado = bool.Parse(reader["estado"].ToString());
                dgvSucursal.Rows[i].Cells[1].Value = reader["idsucursalbp"].ToString();
                dgvSucursal.Rows[i].Cells[0].Value = nombreNuevo;
                dgvSucursal.Rows[i].Cells[2].Value = estado;
                dgvSucursal.Rows[i].Cells[3].Value = nombreEspejo;
                dgvSucursal.Rows[i].Cells[4].Value=fechaapertura.ToString("yyyy-MM-dd");
                dgvSucursal.Rows[i].Cells[5].Value=periodoIrecibo+" a "+periodoFrecibo;
                dgvSucursal.Rows[i].Cells[6].Value = plaza;
                dgvSucursal.Rows[i].Cells[7].Value=inventarioinicial.ToString("N0");
                dgvSucursal.Rows[i].Cells[8].Value=renta.ToString("C2");
                dgvSucursal.Rows[i].Cells[9].Value=guante.ToString("C2");
                dgvSucursal.Rows[i].Cells[10].Value=inversionConstruccion.ToString("C2");
                dgvSucursal.Rows[i].Cells[11].Value=gastoFiscal.ToString("C2");
                dgvSucursal.Rows[i].Cells[12].Value=gastoPublicidad.ToString("C2");
                dgvSucursal.Rows[i].Cells[13].Value=gastoApoyo.ToString("C2");
                i++;
            }
            reader.Close();

        }

        private void dgvSucursal_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if(dgvSucursal.Rows[e.RowIndex].Cells[2].Value.ToString()=="True")
                {
                    query = "Update sucursalesbp set estado=1 where idsucursalbp=" + dgvSucursal.Rows[e.RowIndex].Cells[1].Value.ToString() + "";
                    cmd = new MySqlCommand(query, Conn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    query = "Update sucursalesbp set estado=0 where idsucursalbp=" + dgvSucursal.Rows[e.RowIndex].Cells[1].Value.ToString() + "";
                    cmd = new MySqlCommand(query, Conn);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}