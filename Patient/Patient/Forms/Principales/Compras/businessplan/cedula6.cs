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
using System.Globalization;


namespace business_plan
{
    public partial class cedula6 : Form
    {
        #region variables conexion

        private MySqlCommand cmd;
        private string conexion = "SERVER=" + Properties.Settings.Default.server + "; DATABASE=dwh; user=" + Properties.Settings.Default.usuario + "; PASSWORD=" + Properties.Settings.Default.pass + ";";
        //private string conexion = "SERVER=localhost; DATABASE=dwh; user=root; PASSWORD= ;";
        private MySqlConnection Conn;
        private string query;
        private MySqlDataReader reader;
        #endregion variables conexion
        #region variables globales
        DateTime FechaAI = DateTime.Now;
        DateTime FechaAF = DateTime.Now;
        string idsucursal = "";
        string iddsucursal = "";
        string CED7_estruct = "";
        string CED7_fechaI = ""; string CED7_fechaF = "";
        string fechainicialsuma = ""; string fechafinalsuma = "";
        string CED7_escenario = "";
        double n1, n2, n3, n4 = 0.0;
        double inc1, inc2, inc3, inc4 = 0.0;

        double numclientes = 0;
        double venta = 0;
        double cantidad = 0;
        string f1 = "";
        string f2 = "";

        double pares = 0;

        double vdias = 0, vcant = 0;
        string sucursalguardar = "";

        /////////////////////////////////////////////////
        //@est@

        bool bandera_sucursal = false; int seleccion_sucursal = -1;
        int seleccion_division = -1;
        int seleccion_depto = -1;
        int seleccion_familia = -1;
        int seleccion_linea = -1;
        int seleccion_l1 = -1;
        int seleccion_l2 = -1;
        int seleccion_l3 = -1;
        int seleccion_l4 = -1;
        int seleccion_l5 = -1;
        int seleccion_l6 = -1;
        string seleccion_marca = "";
        bool valoresform = false;

        int Aseleccion_sucursal = -1;
        int Aseleccion_division = -1;
        int Aseleccion_depto = -1;
        int Aseleccion_familia = -1;
        int Aseleccion_linea = -1;
        int Aseleccion_l1 = -1;
        int Aseleccion_l2 = -1;
        int Aseleccion_l3 = -1;
        int Aseleccion_l4 = -1;
        int Aseleccion_l5 = -1;
        int Aseleccion_l6 = -1;
        string Aseleccion_marca = "";
        private string[] idd = new string[1000];
        #endregion
        public cedula6()
        {
            InitializeComponent();
            #region Abrir conexion
            Conn = new MySqlConnection(conexion);
            try
            {
                Conn.Open();
                //  cmd.CommandType = CommandType.StoredProcedure;
                // cmd.CommandTimeout = 0;
                //   cmd.CommandTimeout(0);
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.ToString());
            }
            #endregion
            tabcontrol.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabcontrol.DrawItem += new DrawItemEventHandler(tabcontrol_DrawItem);
        }

        ////////////////////////////////////////////////////////////////////////////////////
        //@est@
        public cedula6(int selecc_sucursal, int selecc_division, int selecc_depto, int selecc_familia,
                          int selecc_linea, int selecc_l1, int selecc_l2, int selecc_l3, int selecc_l4,
                          int selecc_l5, int selecc_l6, string selecc_marca)
        {
            InitializeComponent();
            #region Abrir conexion
            Conn = new MySqlConnection(conexion);
            try
            {
                Conn.Open();
                //  cmd.CommandType = CommandType.StoredProcedure;
                // cmd.CommandTimeout = 0;
                //   cmd.CommandTimeout(0);
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.ToString());
            }
            #endregion
            tabcontrol.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabcontrol.DrawItem += new DrawItemEventHandler(tabcontrol_DrawItem);


            valoresform = true;
            seleccion_sucursal = selecc_sucursal;
            seleccion_division = selecc_division;
            seleccion_depto = selecc_depto;
            seleccion_familia = selecc_familia;
            seleccion_linea = selecc_linea;
            seleccion_l1 = selecc_l1;
            seleccion_l2 = selecc_l2;
            seleccion_l3 = selecc_l3;
            seleccion_l4 = selecc_l4;
            seleccion_l5 = selecc_l5;
            seleccion_l6 = selecc_l6;
            seleccion_marca = selecc_marca;

        }

        ////////////////////////////////////////////////////////////////////////////////////

        private void cedula6_Load(object sender, EventArgs e)
        {
            #region color
            dgv_captura.RowsDefaultCellStyle.BackColor = dgv_captura2.RowsDefaultCellStyle.BackColor = dgv_captura3.RowsDefaultCellStyle.BackColor =
            dgv_captura4.RowsDefaultCellStyle.BackColor = dgv_captura5.RowsDefaultCellStyle.BackColor = dgv_captura6.RowsDefaultCellStyle.BackColor =
            dgv_captura7.RowsDefaultCellStyle.BackColor = dgv_captura8.RowsDefaultCellStyle.BackColor = dgv_captura9.RowsDefaultCellStyle.BackColor =
            dgv_captura10.RowsDefaultCellStyle.BackColor = dgv_captura11.RowsDefaultCellStyle.BackColor = dgv_captura12.RowsDefaultCellStyle.BackColor =
            System.Drawing.ColorTranslator.FromHtml("#B4FF8F");

            //  dgv_captura.CellBorderStyle = DataGridViewCellBorderStyle.None;


            for (int i = 0; i < 8; i++)
            {
                dgvCed7.Columns[i].DefaultCellStyle.BackColor = dgvCed72.Columns[i].DefaultCellStyle.BackColor = dgvCed73.Columns[i].DefaultCellStyle.BackColor =
                dgvCed74.Columns[i].DefaultCellStyle.BackColor = dgvCed75.Columns[i].DefaultCellStyle.BackColor = dgvCed76.Columns[i].DefaultCellStyle.BackColor =
                dgvCed77.Columns[i].DefaultCellStyle.BackColor = dgvCed78.Columns[i].DefaultCellStyle.BackColor = dgvCed79.Columns[i].DefaultCellStyle.BackColor =
                dgvCed710.Columns[i].DefaultCellStyle.BackColor = dgvCed711.Columns[i].DefaultCellStyle.BackColor = dgvCed712.Columns[i].DefaultCellStyle.BackColor =
                System.Drawing.ColorTranslator.FromHtml("#2ECCFA");
            }
            dgvCed7.Columns[8].DefaultCellStyle.BackColor = dgvCed72.Columns[8].DefaultCellStyle.BackColor = dgvCed73.Columns[8].DefaultCellStyle.BackColor =
            dgvCed74.Columns[8].DefaultCellStyle.BackColor = dgvCed75.Columns[8].DefaultCellStyle.BackColor = dgvCed76.Columns[8].DefaultCellStyle.BackColor =
            dgvCed77.Columns[8].DefaultCellStyle.BackColor = dgvCed78.Columns[8].DefaultCellStyle.BackColor = dgvCed79.Columns[8].DefaultCellStyle.BackColor =
            dgvCed710.Columns[8].DefaultCellStyle.BackColor = dgvCed711.Columns[8].DefaultCellStyle.BackColor = dgvCed712.Columns[8].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#81BEF7");
            //dgvCed7.CellBorderStyle = DataGridViewCellBorderStyle.None;



            #endregion
            #region escenario
            query = "select fechainicialA,fechafinalA,fechainicial,fechafinal from escenarios where nombre='" + Properties.Settings.Default.escenario + "';";
            checaConexion();
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                FechaAI = DateTime.Parse(reader["fechainicialA"].ToString());
                FechaAF = DateTime.Parse(reader["fechafinalA"].ToString());
                f1 = reader["fechainicial"].ToString();
                f2 = reader["fechafinal"].ToString();
                label1.Text = "Fecha inicio: " + f1.Substring(0, 10);
                label11.Text = "Fecha fin: " + f2.Substring(0, 10);
            }
            reader.Close();
            query = "select fechainicialA,fechafinalA,fechainicial,fechafinal from escenarios where nombre='" + Properties.Settings.Default.escenario + "';";
            checaConexion();
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string f1 = reader["fechainicial"].ToString();
                string f2 = reader["fechafinal"].ToString();
                label1.Text = "Fecha inicio: " + f1.Substring(0, 10);
                label11.Text = "Fecha fin: " + f2.Substring(0, 10);
            }
            reader.Close();
            m_ESCENARIO(Properties.Settings.Default.escenario);
            #endregion

            #region @est@
            ///////////////////////////////
            ///////////////////////////////
            //@est@


            if (seleccion_sucursal != -1)
            {
                Aseleccion_sucursal = seleccion_sucursal;
                Aseleccion_division = seleccion_division;
                Aseleccion_depto = seleccion_depto;
                Aseleccion_familia = seleccion_familia;
                Aseleccion_linea = seleccion_linea;
                Aseleccion_l1 = seleccion_l1;
                Aseleccion_l2 = seleccion_l2;
                Aseleccion_l3 = seleccion_l3;
                Aseleccion_l4 = seleccion_l4;
                Aseleccion_l5 = seleccion_l5;
                Aseleccion_l6 = seleccion_l6;
                Aseleccion_marca = seleccion_marca;
            }


            if (seleccion_sucursal >= 0)
                cb_Estructura_DropDown();
            /*
            seleccion_division = Aseleccion_division;
            if (seleccion_division >= 0)
                m_drop_division();

            seleccion_depto = Aseleccion_depto;
            if (seleccion_depto >= 0)
                m_drop_depto();

            seleccion_familia = Aseleccion_familia;
            if (seleccion_familia >= 0)
                m_drop_familia();

            seleccion_linea = Aseleccion_linea;
            if (seleccion_linea >= 0)
                m_drop_linea();

            seleccion_l1 = Aseleccion_l1;
            if (seleccion_l1 >= 0)
                m_drop_l1();

            seleccion_l2 = Aseleccion_l2;
            if (seleccion_l2 >= 0)
                m_drop_l2();

            seleccion_l3 = Aseleccion_l3;
            if (seleccion_l3 >= 0)
                m_drop_l3();

            seleccion_l4 = Aseleccion_l4;
            if (seleccion_l4 >= 0)
                m_drop_l4();

            seleccion_l5 = Aseleccion_l5;
            if (seleccion_l5 >= 0)
                m_drop_l5();

            seleccion_l6 = Aseleccion_l6;
            if (seleccion_l6 >= 0)
                m_drop_l6();

            seleccion_marca = Aseleccion_marca;

            try
            {
                if (seleccion_marca != "")
                    if (Convert.ToInt32(seleccion_marca) >= 0)
                        m_drop_marca();
            }
            catch
            {

                if (seleccion_marca != "")
                    m_drop_marca();
            }
            */

            seleccion_sucursal = Aseleccion_sucursal;
            seleccion_division = Aseleccion_division;
            seleccion_depto = Aseleccion_depto;
            seleccion_familia = Aseleccion_familia;
            seleccion_linea = Aseleccion_linea;
            seleccion_l1 = Aseleccion_l1;
            seleccion_l2 = Aseleccion_l2;
            seleccion_l3 = Aseleccion_l3;
            seleccion_l4 = Aseleccion_l4;
            seleccion_l5 = Aseleccion_l5;
            seleccion_l6 = Aseleccion_l6;
            seleccion_marca = Aseleccion_marca;
            ////////////////////////////////
            #endregion

        }
        #region botones navegacion
        private void button4_Click(object sender, EventArgs e)
        {
            if (bandera_sucursal == true)
            {

                Cedula1 c1 = new Cedula1(seleccion_sucursal, seleccion_division, seleccion_depto, seleccion_familia, seleccion_linea, seleccion_l1, seleccion_l2, seleccion_l3, seleccion_l4, seleccion_l5, seleccion_l6, seleccion_marca);
                this.Hide();
                c1.ShowDialog();
                this.Close();
            }
            else
            {
                Cedula1 c1 = new Cedula1();
                this.Hide();
                c1.ShowDialog();
                this.Close();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (bandera_sucursal == true)
            {

                Cedula2 c2 = new Cedula2(seleccion_sucursal, seleccion_division, seleccion_depto, seleccion_familia, seleccion_linea, seleccion_l1, seleccion_l2, seleccion_l3, seleccion_l4, seleccion_l5, seleccion_l6, seleccion_marca);
                this.Hide();
                c2.ShowDialog();
                this.Close();
            }
            else
            {
                Cedula2 c2 = new Cedula2();
                this.Hide();
                c2.ShowDialog();
                this.Close();
            }
            
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (bandera_sucursal == true)
            {
                Cedula3 c3 = new Cedula3(seleccion_sucursal, seleccion_division, seleccion_depto, seleccion_familia, seleccion_linea, seleccion_l1, seleccion_l2, seleccion_l3, seleccion_l4, seleccion_l5, seleccion_l6, seleccion_marca);
                this.Hide();
                c3.ShowDialog();
                this.Close();
            }
            else
            {
                Cedula3 c3 = new Cedula3();
                this.Hide();
                c3.ShowDialog();
                this.Close();
            }


        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (bandera_sucursal == true)
            {
                /*cedula4 c4 = new cedula4(seleccion_sucursal, seleccion_division, seleccion_depto, seleccion_familia, seleccion_linea, seleccion_l1, seleccion_l2, seleccion_l3, seleccion_l4, seleccion_l5, seleccion_l6, seleccion_marca);
                 c4.Show(); this.Close();*/
                cedula4 c4 = new cedula4();
                this.Hide();
                c4.ShowDialog();
                this.Close();
            }
            else
            {
                cedula4 c4 = new cedula4();
                this.Hide();
                c4.ShowDialog();
                this.Close();
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (bandera_sucursal == true)
            {
                cedula5 c5 = new cedula5(seleccion_sucursal, seleccion_division, seleccion_depto, seleccion_familia, seleccion_linea, seleccion_l1, seleccion_l2, seleccion_l3, seleccion_l4, seleccion_l5, seleccion_l6, seleccion_marca);
                this.Hide();
                c5.ShowDialog();
                this.Close();
            }
            else
            {
                cedula5 c5 = new cedula5();
                this.Hide();
                c5.ShowDialog();
                this.Close();
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (bandera_sucursal == true)
            {
                //Cedula7 c7 = new Cedula7(bandera_sucursal, 0, false, -1, false, -1, false, -1, false, -1, false, -1, false, -1, false, -1, false, -1, false, -1, false, -1, false, "-1");
                Cedula7 c7 = new Cedula7();

                this.Hide();
                c7.ShowDialog();
                this.Close();
            }
            else
            {
                Cedula7 c7 = new Cedula7();
                this.Hide();
                c7.ShowDialog();
                this.Close();
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (bandera_sucursal == true)
            {
                /*Cedula8 c8 = new Cedula8(seleccion_sucursal, seleccion_division, seleccion_depto, seleccion_familia, seleccion_linea, seleccion_l1, seleccion_l2, seleccion_l3, seleccion_l4, seleccion_l5, seleccion_l6, seleccion_marca);
                 c8.Show(); this.Close();*/
                Cedula8 c8 = new Cedula8();
                this.Hide();
                c8.ShowDialog();
                this.Close();
            }
            else
            {
                Cedula8 c8 = new Cedula8();
                this.Hide();
                c8.ShowDialog();
                this.Close();
            }
        }
        #endregion

        private void ts_sucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            // m_Calcular();
            bandera_sucursal = true;
            tabcontrol.SelectedIndex = 0;
            m_ESTRUCTURA(CED7_estruct);

            m_PRECIOPROMEDIO_CEDULA1(Properties.Settings.Default.escenario);
            m_DIASMESESANOS(f1.Substring(0, 10), f2.Substring(0, 10));

            tabcontrol.SelectedIndex = 0;
        }
        private void dgvCed7_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double v1 = Convert.ToDouble(dgv_captura.Rows[0].Cells[0].Value);
            double v2 = Convert.ToDouble(dgv_captura.Rows[0].Cells[1].Value);
            double v3 = double.Parse(dgv_captura.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency);
            double v4 = Convert.ToDouble(dgv_captura.Rows[0].Cells[3].Value);

            if (dgvCed7.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                try
                {
                    int columna = dgvCed7.CurrentCell.ColumnIndex; string cellvalue;

                    if (columna == 0)
                    {
                        cellvalue = dgvCed7.Rows[0].Cells[0].Value.ToString();
                        numclientes = Convert.ToDouble(cellvalue);
                        m_dgv_calcular_0(v1, v2, v3, v4, Convert.ToInt32(tb_PROM.Text));

                    }
                    if (columna == 6)
                    {
                        cellvalue = dgvCed7.Rows[0].Cells[6].Value.ToString();
                        pares = Convert.ToDouble(cellvalue);
                        m_dgv_calcular_6(v1, v2, v3, v4, Convert.ToInt32(tb_PROM.Text));
                    }
                }
                catch { }

            }
        }

        private void m_Calcular(int m, int a)
        {
            Cursor.Current = Cursors.WaitCursor;
            //DateTime month = DateTime.Parse(m.ToString());
            //DateTime year = DateTime.Parse(a.ToString());

            fechainicialsuma = f1;//CED7_fechaI;
            string d1 = fechainicialsuma.Substring(0, 2);
            string m1 = fechainicialsuma.Substring(3, 2);
            string a1 = fechainicialsuma.Substring(6, 4);
            fechainicialsuma = a1 + "-" + m1 + "-" + d1;

            fechafinalsuma = f2;// CED7_fechaF;
            string d2 = fechafinalsuma.Substring(0, 2);
            string m2 = fechafinalsuma.Substring(3, 2);
            string a2 = fechafinalsuma.Substring(6, 4);
            fechafinalsuma = a2 + "-" + m2 + "-" + d2;

            m_clientes(idsucursal, fechainicialsuma, fechafinalsuma, m, a);
            m_clientes_diarios(fechainicialsuma, fechafinalsuma, m, a);
            m_ventascliente_parescliente(iddsucursal, fechainicialsuma, fechafinalsuma, m, a);
            m_LLENAR_DGV(m);
            //tabcontrol.SelectedIndex = tabcontrol.SelectedIndex + 1;
            Cursor.Current = Cursors.Default;
        }
        private void m_ESTRUCTURA(string estructura)
        {
            #region clear add rows
            dgv_captura.Rows.Clear(); dgv_captura2.Rows.Clear(); dgv_captura3.Rows.Clear(); dgv_captura4.Rows.Clear(); dgv_captura5.Rows.Clear();
            dgv_captura6.Rows.Clear(); dgv_captura7.Rows.Clear(); dgv_captura8.Rows.Clear(); dgv_captura9.Rows.Clear(); dgv_captura10.Rows.Clear();
            dgv_captura11.Rows.Clear(); dgv_captura12.Rows.Clear();

            dgv_captura.Rows.Add(); dgv_captura2.Rows.Add(); dgv_captura3.Rows.Add(); dgv_captura4.Rows.Add(); dgv_captura5.Rows.Add();
            dgv_captura6.Rows.Add(); dgv_captura7.Rows.Add(); dgv_captura8.Rows.Add(); dgv_captura9.Rows.Add(); dgv_captura10.Rows.Add();
            dgv_captura11.Rows.Add(); dgv_captura12.Rows.Add();

            dgvCed7.Rows.Clear(); dgvCed72.Rows.Clear(); dgvCed73.Rows.Clear(); dgvCed74.Rows.Clear(); dgvCed75.Rows.Clear();
            dgvCed76.Rows.Clear(); dgvCed77.Rows.Clear(); dgvCed78.Rows.Clear(); dgvCed79.Rows.Clear(); dgvCed710.Rows.Clear();
            dgvCed711.Rows.Clear(); dgvCed712.Rows.Clear();
            dgvCed7.Rows.Add(); dgvCed72.Rows.Add(); dgvCed73.Rows.Add(); dgvCed74.Rows.Add(); dgvCed75.Rows.Add();
            dgvCed76.Rows.Add(); dgvCed77.Rows.Add(); dgvCed78.Rows.Add(); dgvCed79.Rows.Add(); dgvCed710.Rows.Add();
            dgvCed711.Rows.Add(); dgvCed712.Rows.Add();
            #endregion
            string SeleccionActual = cb_Estructura.Text;
            //////////////////////////////////////////////////////
            //@est@

            if (cb_Estructura.Text != "Total")
            {
                idsucursal = "SUCURSAL='" + idd[cb_Estructura.SelectedIndex] + "'";
                iddsucursal = "SUCURSAL='0" + idd[cb_Estructura.SelectedIndex] + "'";
                sucursalguardar = idd[cb_Estructura.SelectedIndex].ToString();

            }
            else
            {
                idsucursal = "(SUCURSAL= '1' OR SUCURSAL='2' OR SUCURSAL='6' OR SUCURSAL='8')";
                iddsucursal = "(SUCURSAL= '01' OR SUCURSAL='02' OR SUCURSAL='06' OR SUCURSAL='08')";
                sucursalguardar = "0";
            }
            //switch (SeleccionActual)
            //{
            //    case "Total":
            //        sucursalguardar = "0";
            //        break;
            //    case "JUAREZ":
            //        sucursalguardar = "1";
            //        break;
            //    case "HIDALGO":
            //        sucursalguardar = "2";
            //        break;
            //    case "TRIANA":
            //        sucursalguardar = "3";
            //        break;
            //    case "MATRIZ":
            //        sucursalguardar = "4";
            //        break;

            //}
            /////////////////////////////////////////////////////////
        }
        private void m_ESCENARIO(string escenario)
        {
            string ESC = "SELECT fechainicialA, fechafinalA,fechainicial,fechafinal,solocalzado FROM escenarios WHERE nombre='" + escenario + "' LIMIT 1";
            checaConexion();
            cmd = new MySqlCommand(ESC, Conn);
            cmd.CommandTimeout = 0;//pos solucion
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //CED7_estruct = reader["estructura"].ToString();
                CED7_fechaI = reader["fechainicial"].ToString();
                CED7_fechaF = reader["fechafinal"].ToString();
                FechaAI = DateTime.Parse(reader["fechafinalA"].ToString());
                CED7_escenario = escenario;
                label2.Text = "Escenario: " + escenario;
            }
            reader.Close();
        }
        public void m_clientes(string idsucursal, string f1, string f2, int m, int a)
        {
            #region año actual
            //query = "SELECT SUM(T.aplicadas) AS NUMEROCLIENTES FROM transacciones AS T INNER JOIN FECHA F ON T.IDFECHA=F.IDFECHA WHERE F.FECHA BETWEEN '" + f1 + "' AND '" + f2 + "' AND " + idsucursal + " AND f.`Mes` = '" + m + "'";
            //cmd = new MySqlCommand(query, Conn);
            //cmd.CommandTimeout = 0;//pos solucion
            //reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    string valor = reader["NUMEROCLIENTES"].ToString();
            //    if (valor == "" || valor == null)
            //    { numclientes = 0; }
            //    else { numclientes = Convert.ToDouble(valor); }

            //    n1 = numclientes;
            //}
            //reader.Close();
            #endregion
            #region año anterior
            //if (numclientes == 0)
            //{
                query = "SELECT SUM(T.aplicadas) AS NUMEROCLIENTES FROM transacciones AS T INNER JOIN FECHA F ON T.IDFECHA=F.IDFECHA WHERE " + idsucursal + " AND f.`Mes` = '" + m + "' AND f.`Anio` = " + (a - 1);
                checaConexion();
                cmd = new MySqlCommand(query, Conn);
                cmd.CommandTimeout = 0;//pos solucion
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string valor = reader["NUMEROCLIENTES"].ToString();
                    if (valor == "" || valor == null)
                    { numclientes = 0; }
                    else { numclientes = Convert.ToDouble(valor); }

                    n1 = numclientes;
                }
                reader.Close();

            //}

            #endregion

        }
        public void m_clientes_diarios(string f1, string f2, int m, int a)
        {
            #region año actual
            //query = "SELECT COUNT(dia) AS dias FROM fecha WHERE FECHA BETWEEN '" + (a - 1) + "' AND '" + f2 + "' AND MES = '" + m + "'";
            //cmd = new MySqlCommand(query, Conn);
            //cmd.CommandTimeout = 0;//pos solucion
            //reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //TimeSpan dias = FechaAF.Subtract(FechaAI);

                //string valor = reader["dias"].ToString();
                //if (valor == "" || valor == null)
                //{ dias = 0; }
            //fanio.AddYears(-1);
            int dias = System.DateTime.DaysInMonth(a-1, m);
                n2 = n1 / dias;
            //}
            //reader.Close();
            #endregion

        }
        public void m_ventascliente_parescliente(string suc, string f1, string f2, int m, int a)
        {
            #region año actual
            //query = "SELECT SUM(impllenototal) AS venta,SUM(ctdneta) AS cantidad FROM VENTASBASE AS V INNER JOIN SUCURSAL AS S ON V.IDSUCURSAL = S.IDSUCURSAL INNER JOIN FECHA AS F ON F.IDFECHA = V.IDFECHA WHERE " + suc + " AND F.FECHA BETWEEN '" + f1 + "' AND '" + f2 + "'  AND f.`Mes` = '" + m + "'";
            //cmd = new MySqlCommand(query, Conn);
            //cmd.CommandTimeout = 0;//pos solucion
            //reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    string valor = reader["venta"].ToString();
            //    if (valor == "" || valor == null)
            //    { venta = 0; }
            //    else { venta = Convert.ToDouble(valor); }

            //    string valor2 = reader["cantidad"].ToString();
            //    if (valor2 == "" || valor2 == null)
            //    { cantidad = 0; }
            //    else { cantidad = Convert.ToDouble(valor2); }
            //    n3 = venta / n1;
            //    n4 = cantidad / n1;
            //}
            //reader.Close();
            #endregion
            #region año anterior
            //if (venta == 0 || cantidad == 0)
            //{
            query = "SELECT SUM(impnetosiva) AS venta,SUM(ctdneta) AS cantidad FROM VENTASBASE AS V INNER JOIN SUCURSAL AS S ON V.IDSUCURSAL = S.IDSUCURSAL INNER JOIN FECHA AS F ON F.IDFECHA = V.IDFECHA WHERE " + suc + " AND f.`Mes` = '" + m + "' AND f.`Anio` = " + (a - 1) + " and v.iddivisiones=1";
            checaConexion();
                cmd = new MySqlCommand(query, Conn);
                cmd.CommandTimeout = 0;//pos solucion
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string valor = reader["venta"].ToString();
                    if (valor == "" || valor == null)
                    { venta = 0; }
                    else { venta = Convert.ToDouble(valor); }

                    string valor2 = reader["cantidad"].ToString();
                    if (valor2 == "" || valor2 == null)
                    { cantidad = 0; }
                    else { cantidad = Convert.ToDouble(valor2); }
                    n3 = venta / n1;
                    n4 = cantidad / n1;
                }
                reader.Close();
            //}
            #endregion

        }

        private void m_dgv_calcular_0(double v_1, double v_2, double v_3, double v_4, double v5)
        {
            //clientes 
            dgvCed7.Rows[0].Cells[0].Value = Convert.ToString(numclientes);

            //dias 
            vdias = v_1 / v_2; n2 = numclientes / vdias; dgvCed7[2, 0].Value = n2.ToString("N0");

            //importe venta por cliente 
            n3 = v_3 / v_1; double nuevo3 = n3 * numclientes;
            dgvCed7[4, 0].Value = nuevo3.ToString("C2");

            //pares x cliente 
            vcant = v_1 * v_4; n4 = vcant / numclientes;
            dgvCed7[6, 0].Value = n4.ToString("N2");

            //incrementos 
            inc1 = 1 - (Convert.ToDouble(dgv_captura.Rows[0].Cells[0].Value) / numclientes);
            inc2 = 1 - (Convert.ToDouble(dgv_captura.Rows[0].Cells[1].Value) / Convert.ToDouble(dgvCed7.Rows[0].Cells[2].Value));
            inc3 = 1 - (double.Parse(dgv_captura.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) /
                        double.Parse(dgvCed7.Rows[0].Cells[4].Value.ToString(), NumberStyles.Currency));
            inc4 = 1 - (Convert.ToDouble(dgv_captura.Rows[0].Cells[3].Value) / Convert.ToDouble(dgvCed7.Rows[0].Cells[6].Value));

            dgvCed7[1, 0].Value = inc1.ToString("n2"); dgvCed7[3, 0].Value = inc2.ToString("n2");
            dgvCed7[5, 0].Value = inc3.ToString("n2"); dgvCed7[7, 0].Value = inc4.ToString("n2");

            double vent = numclientes * Convert.ToDouble(tb_PROM.Text);
            dgvCed7[8, 0].Value = vent;
        }
        private void m_dgv_calcular_6(double v_1, double v_2, double v_3, double v_4, double v5)
        {
            //pares x cliente
            dgvCed7.Rows[0].Cells[6].Value = Convert.ToString(pares);

            numclientes = vcant / pares;

            dgvCed7[0, 0].Value = numclientes.ToString("N0");
            vdias = v_1 / v_2; n2 = numclientes / vdias;
            dgvCed7[2, 0].Value = n2.ToString("N0");

            n3 = v_3 / v_1; double nuevo3 = n3 * numclientes;

            dgvCed7[4, 0].Value = nuevo3.ToString("C2");

            inc1 = 1 - (Convert.ToDouble(dgv_captura.Rows[0].Cells[0].Value) / numclientes);
            inc2 = 1 - (Convert.ToDouble(dgv_captura.Rows[0].Cells[1].Value) / Convert.ToDouble(dgvCed7.Rows[0].Cells[2].Value));

            string val = Convert.ToString(dgv_captura.Rows[0].Cells[2].Value); //val = val.Trim('$');
            string val2 = Convert.ToString(dgvCed7.Rows[0].Cells[4].Value); //val2 = val2.Trim('$');

            inc3 = 1 - (Convert.ToDouble(val) / Convert.ToDouble(val2));
            inc4 = 1 - (Convert.ToDouble(dgv_captura.Rows[0].Cells[3].Value) / Convert.ToDouble(dgvCed7.Rows[0].Cells[6].Value));
            dgvCed7[1, 0].Value = inc1.ToString("n2"); dgvCed7[3, 0].Value = inc2.ToString("n2");
            dgvCed7[5, 0].Value = inc3.ToString("n2"); dgvCed7[7, 0].Value = inc4.ToString("n2");

            double vent = numclientes * Convert.ToDouble(tb_PROM.Text);
            dgvCed7[8, 0].Value = vent;


        }

        public void m_DIASMESESANOS(string fecha_inicio, string fecha_final)//////////////////////////////////////////////////
        {
            int fecha_inicio_dia = Convert.ToInt32(fecha_inicio.Substring(0, 2));
            int fecha_inicio_mes = Convert.ToInt32(fecha_inicio.Substring(3, 2));
            int fecha_inicio_ano = Convert.ToInt32(fecha_inicio.Substring(6, 4));

            int fecha_final_dia = Convert.ToInt32(fecha_final.Substring(0, 2));
            int fecha_final_mes = Convert.ToInt32(fecha_final.Substring(3, 2));
            int fecha_final_ano = Convert.ToInt32(fecha_final.Substring(6, 4));
            //int fechaaño = fecha_inicio_ano + 1;
            tabcontrol.SelectedIndex = 0;
            #region añomes
            for (int i = 1; fecha_inicio_ano <= fecha_final_ano; fecha_inicio_ano++)
            {
                if (fecha_inicio_mes <= fecha_final_mes)
                {
                    for (; fecha_inicio_mes <= fecha_final_mes; fecha_inicio_mes++, i++)
                        try
                        {
                            m_TABS(fecha_inicio_mes, fecha_inicio_ano);
                            if (comprobarCargar(fecha_inicio_ano, fecha_inicio_mes, i) == true)
                            {
                                cargar(fecha_inicio_mes, fecha_inicio_ano, i);
                                m_obtenerVentas(i, fecha_inicio_mes, fecha_inicio_ano);
                            }
                            else
                            {
                                m_Calcular(fecha_inicio_mes, fecha_inicio_ano);
                                m_obtenerVentas(i,fecha_inicio_mes,fecha_inicio_ano);
                            }
                            tabcontrol.SelectedIndex = tabcontrol.SelectedIndex + 1;
                        }
                        catch (Exception x)
                        {
                            MessageBox.Show("Error con las fechas " + x);
                        }
                }
                if ((fecha_final_mes < fecha_inicio_mes) && (fecha_inicio_ano < fecha_final_ano))
                {
                    for (; fecha_inicio_mes <= 12; fecha_inicio_mes++)
                    {
                        try
                        {
                            m_TABS(fecha_inicio_mes, fecha_inicio_ano);
                            if (comprobarCargar(fecha_inicio_ano, fecha_inicio_mes, i) == true)
                            {
                                cargar(fecha_inicio_mes, fecha_inicio_ano, i);
                            }
                            else
                            {
                                m_Calcular(fecha_inicio_mes, fecha_inicio_ano);
                            }
                            tabcontrol.SelectedIndex = tabcontrol.SelectedIndex + 1;
                        }
                        catch (Exception x)
                        {
                            MessageBox.Show("Error con las fechas " + x);
                        }
                    }
                    fecha_inicio_mes = 1;
                }

            }
            #endregion

        }

        public void m_TABS(int mes, int ano)
        {
            string mestab = "";
            switch (mes)
            {
                case 1: mestab = "Enero"; tabcontrol.SelectedTab.Text = mestab + " " + ano + "  ";
                    break;
                case 2: mestab = "Febrero"; tabcontrol.SelectedTab.Text = mestab + " " + ano + "  ";
                    break;
                case 3: mestab = "Marzo"; tabcontrol.SelectedTab.Text = mestab + " " + ano + "  ";
                    break;
                case 4: mestab = "Abril"; tabcontrol.SelectedTab.Text = mestab + " " + ano + "  ";
                    break;
                case 5: mestab = "Mayo"; tabcontrol.SelectedTab.Text = mestab + " " + ano + "  ";
                    break;
                case 6: mestab = "Junio"; tabcontrol.SelectedTab.Text = mestab + " " + ano + "  ";
                    break;
                case 7: mestab = "Julio"; tabcontrol.SelectedTab.Text = mestab + " " + ano + "  ";
                    break;
                case 8: mestab = "Agosto"; tabcontrol.SelectedTab.Text = mestab + " " + ano + "  ";
                    break;
                case 9: mestab = "Septiembre"; tabcontrol.SelectedTab.Text = mestab + " " + ano + "  ";
                    break;
                case 10: mestab = "Octubre"; tabcontrol.SelectedTab.Text = mestab + " " + ano + "  ";
                    break;
                case 11: mestab = "Noviembre"; tabcontrol.SelectedTab.Text = mestab + " " + ano + "  ";
                    break;
                case 12: mestab = "Diciembre"; tabcontrol.SelectedTab.Text = mestab + " " + ano + "  ";
                    break;

            }
        }
        private void m_LLENAR_DGV(int m)
        {
            //           dgvCed9.Rows[0].Cells[i].Value = val;
            switch (m)
            {
                case 1: dgv_captura.Rows[0].Cells[0].Value = n1; dgv_captura.Rows[0].Cells[1].Value = n2.ToString("N0");
                    dgv_captura.Rows[0].Cells[2].Value = n3.ToString("C2"); dgv_captura.Rows[0].Cells[3].Value = n4.ToString("N2");
                    // dgvCed7.Rows[0].Cells[8].Value = venta.ToString("C2");
                    break;
                case 2: dgv_captura2.Rows[0].Cells[0].Value = n1; dgv_captura2.Rows[0].Cells[1].Value = n2.ToString("N0");
                    dgv_captura2.Rows[0].Cells[2].Value = n3.ToString("C2"); dgv_captura2.Rows[0].Cells[3].Value = n4.ToString("N2");
                    //dgvCed72.Rows[0].Cells[8].Value = venta.ToString("C2");
                    break;
                case 3: dgv_captura3.Rows[0].Cells[0].Value = n1; dgv_captura3.Rows[0].Cells[1].Value = n2.ToString("N0");
                    dgv_captura3.Rows[0].Cells[2].Value = n3.ToString("C2"); dgv_captura3.Rows[0].Cells[3].Value = n4.ToString("N2");
                    //dgvCed73.Rows[0].Cells[8].Value = venta.ToString("C2");
                    break;
                case 4: dgv_captura4.Rows[0].Cells[0].Value = n1; dgv_captura4.Rows[0].Cells[1].Value = n2.ToString("N0");
                    dgv_captura4.Rows[0].Cells[2].Value = n3.ToString("C2"); dgv_captura4.Rows[0].Cells[3].Value = n4.ToString("N2");
                    //dgvCed74.Rows[0].Cells[8].Value = venta.ToString("C2");
                    break;
                case 5: dgv_captura5.Rows[0].Cells[0].Value = n1; dgv_captura5.Rows[0].Cells[1].Value = n2.ToString("N0");
                    dgv_captura5.Rows[0].Cells[2].Value = n3.ToString("C2"); dgv_captura5.Rows[0].Cells[3].Value = n4.ToString("N2");
                    // dgvCed75.Rows[0].Cells[8].Value = venta.ToString("C2"); 
                    break;
                case 6: dgv_captura6.Rows[0].Cells[0].Value = n1; dgv_captura6.Rows[0].Cells[1].Value = n2.ToString("N0");
                    dgv_captura6.Rows[0].Cells[2].Value = n3.ToString("C2"); dgv_captura6.Rows[0].Cells[3].Value = n4.ToString("N2");
                    // dgvCed76.Rows[0].Cells[8].Value = venta.ToString("C2");
                    break;
                case 7: dgv_captura7.Rows[0].Cells[0].Value = n1; dgv_captura7.Rows[0].Cells[1].Value = n2.ToString("N0");
                    dgv_captura7.Rows[0].Cells[2].Value = n3.ToString("C2"); dgv_captura7.Rows[0].Cells[3].Value = n4.ToString("N2");
                    //   dgvCed77.Rows[0].Cells[8].Value = venta.ToString("C2");
                    break;
                case 8: dgv_captura8.Rows[0].Cells[0].Value = n1; dgv_captura8.Rows[0].Cells[1].Value = n2.ToString("N0");
                    dgv_captura8.Rows[0].Cells[2].Value = n3.ToString("C2"); dgv_captura8.Rows[0].Cells[3].Value = n4.ToString("N2");
                    //   dgvCed78.Rows[0].Cells[8].Value = venta.ToString("C2");
                    break;
                case 9: dgv_captura9.Rows[0].Cells[0].Value = n1; dgv_captura9.Rows[0].Cells[1].Value = n2.ToString("N0");
                    dgv_captura9.Rows[0].Cells[2].Value = n3.ToString("C2"); dgv_captura9.Rows[0].Cells[3].Value = n4.ToString("N2");
                    //  dgvCed79.Rows[0].Cells[8].Value = venta.ToString("C2");
                    break;
                case 10: dgv_captura10.Rows[0].Cells[0].Value = n1; dgv_captura10.Rows[0].Cells[1].Value = n2.ToString("N0");
                    dgv_captura10.Rows[0].Cells[2].Value = n3.ToString("C2"); dgv_captura10.Rows[0].Cells[3].Value = n4.ToString("N2");
                    //   dgvCed710.Rows[0].Cells[8].Value = venta.ToString("C2");
                    break;
                case 11: dgv_captura11.Rows[0].Cells[0].Value = n1; dgv_captura11.Rows[0].Cells[1].Value = n2.ToString("N0");
                    dgv_captura11.Rows[0].Cells[2].Value = n3.ToString("C2"); dgv_captura11.Rows[0].Cells[3].Value = n4.ToString("N2");
                    //     dgvCed711.Rows[0].Cells[8].Value = venta.ToString("C2");
                    break;
                case 12: dgv_captura12.Rows[0].Cells[0].Value = n1; dgv_captura12.Rows[0].Cells[1].Value = n2.ToString("N0");
                    dgv_captura12.Rows[0].Cells[2].Value = n3.ToString("C2"); dgv_captura12.Rows[0].Cells[3].Value = n4.ToString("N2");
                    //     dgvCed712.Rows[0].Cells[8].Value = venta.ToString("C2");
                    break;

            }

        }

        private void m_PRECIOPROMEDIO_CEDULA1(string esc)
        {
            /////////////

            query = "SELECT DISTINCT(preciopromedioUP) AS p_prom FROM cedula1 WHERE nombre = '" + esc + "';";
            checaConexion();
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["p_prom"].ToString() == "")
                {
                    tb_PROM.Text = "1";
                }
                else
                {
                    double c = double.Parse(reader["p_prom"].ToString());
                    tb_PROM.Text = c.ToString("N0");
                }
            }
            reader.Close();

            ////////
        }

        private void tabcontrol_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == tabcontrol.SelectedIndex)
            {
                e.Graphics.DrawString(tabcontrol.TabPages[e.Index].Text, new Font(tabcontrol.Font, FontStyle.Bold), Brushes.Blue,
                   new PointF(e.Bounds.X + 3, e.Bounds.Y + 3));
            }
            else
            {
                e.Graphics.DrawString(tabcontrol.TabPages[e.Index].Text, tabcontrol.Font, Brushes.Black, new PointF(e.Bounds.X, e.Bounds.Y));
            }
        }

        private void dgvCed72_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void m_dgv_calcular_02(double v_1, double v_2, double v_3, double v_4, double v5)
        {
            //clientes 
            dgvCed72.Rows[0].Cells[0].Value = Convert.ToString(numclientes);

            //dias 
            vdias = v_1 / v_2; n2 = numclientes / vdias; dgvCed72[2, 0].Value = n2.ToString("N0");

            //importe venta por cliente 
            n3 = v_3 / v_1; double nuevo3 = n3 * numclientes;
            dgvCed72[4, 0].Value = nuevo3.ToString("C2");

            //pares x cliente 
            vcant = v_1 * v_4; n4 = vcant / numclientes;
            dgvCed72[6, 0].Value = n4.ToString("N2");

            //incrementos 
            inc1 = 1 - (Convert.ToDouble(dgv_captura2.Rows[0].Cells[0].Value) / numclientes);
            inc2 = 1 - (Convert.ToDouble(dgv_captura2.Rows[0].Cells[1].Value) / Convert.ToDouble(dgvCed72.Rows[0].Cells[2].Value));
            inc3 = 1 - (double.Parse(dgv_captura2.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) /
                        double.Parse(dgvCed72.Rows[0].Cells[4].Value.ToString(), NumberStyles.Currency));
            inc4 = 1 - (Convert.ToDouble(dgv_captura2.Rows[0].Cells[3].Value) / Convert.ToDouble(dgvCed72.Rows[0].Cells[6].Value));

            dgvCed72[1, 0].Value = inc1.ToString("n2"); dgvCed72[3, 0].Value = inc2.ToString("n2");
            dgvCed72[5, 0].Value = inc3.ToString("n2"); dgvCed72[7, 0].Value = inc4.ToString("n2");

            double vent = numclientes * Convert.ToDouble(tb_PROM.Text);
            dgvCed72[8, 0].Value = vent;
        }
        private void m_dgv_calcular_62(double v_1, double v_2, double v_3, double v_4, double v5)
        {
            //pares x cliente
            dgvCed72.Rows[0].Cells[6].Value = Convert.ToString(pares);

            numclientes = vcant / pares;

            dgvCed72[0, 0].Value = numclientes.ToString("N0");
            vdias = v_1 / v_2; n2 = numclientes / vdias;
            dgvCed72[2, 0].Value = n2.ToString("N0");

            n3 = v_3 / v_1; double nuevo3 = n3 * numclientes;

            dgvCed72[4, 0].Value = nuevo3.ToString("C2");

            inc1 = 1 - (Convert.ToDouble(dgv_captura2.Rows[0].Cells[0].Value) / numclientes);
            inc2 = 1 - (Convert.ToDouble(dgv_captura2.Rows[0].Cells[1].Value) / Convert.ToDouble(dgvCed72.Rows[0].Cells[2].Value));

            string val = Convert.ToString(dgv_captura2.Rows[0].Cells[2].Value); //val = val.Trim('$');
            string val2 = Convert.ToString(dgvCed72.Rows[0].Cells[4].Value); //val2 = val2.Trim('$');

            inc3 = 1 - (Convert.ToDouble(val) / Convert.ToDouble(val2));
            inc4 = 1 - (Convert.ToDouble(dgv_captura2.Rows[0].Cells[3].Value) / Convert.ToDouble(dgvCed72.Rows[0].Cells[6].Value));
            dgvCed72[1, 0].Value = inc1.ToString("n2"); dgvCed72[3, 0].Value = inc2.ToString("n2");
            dgvCed72[5, 0].Value = inc3.ToString("n2"); dgvCed72[7, 0].Value = inc4.ToString("n2");

            double vent = numclientes * Convert.ToDouble(tb_PROM.Text);
            dgvCed72[8, 0].Value = vent;


        }

        private void dgvCed73_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void m_dgv_calcular_03(double v_1, double v_2, double v_3, double v_4, double v5)
        {
            //clientes 
            dgvCed73.Rows[0].Cells[0].Value = Convert.ToString(numclientes);

            //dias 
            vdias = v_1 / v_2; n2 = numclientes / vdias; dgvCed73[2, 0].Value = n2.ToString("N0");

            //importe venta por cliente 
            n3 = v_3 / v_1; double nuevo3 = n3 * numclientes;
            dgvCed73[4, 0].Value = nuevo3.ToString("C2");

            //pares x cliente 
            vcant = v_1 * v_4; n4 = vcant / numclientes;
            dgvCed73[6, 0].Value = n4.ToString("N2");

            //incrementos 
            inc1 = 1 - (Convert.ToDouble(dgv_captura3.Rows[0].Cells[0].Value) / numclientes);
            inc2 = 1 - (Convert.ToDouble(dgv_captura3.Rows[0].Cells[1].Value) / Convert.ToDouble(dgvCed73.Rows[0].Cells[2].Value));
            inc3 = 1 - (double.Parse(dgv_captura3.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) /
                        double.Parse(dgvCed73.Rows[0].Cells[4].Value.ToString(), NumberStyles.Currency));
            inc4 = 1 - (Convert.ToDouble(dgv_captura3.Rows[0].Cells[3].Value) / Convert.ToDouble(dgvCed73.Rows[0].Cells[6].Value));

            dgvCed73[1, 0].Value = inc1.ToString("n2"); dgvCed73[3, 0].Value = inc2.ToString("n2");
            dgvCed73[5, 0].Value = inc3.ToString("n2"); dgvCed73[7, 0].Value = inc4.ToString("n2");

            double vent = numclientes * Convert.ToDouble(tb_PROM.Text);
            dgvCed73[8, 0].Value = vent;
        }
        private void m_dgv_calcular_63(double v_1, double v_2, double v_3, double v_4, double v5)
        {
            //pares x cliente
            dgvCed73.Rows[0].Cells[6].Value = Convert.ToString(pares);

            numclientes = vcant / pares;

            dgvCed73[0, 0].Value = numclientes.ToString("N0");
            vdias = v_1 / v_2; n2 = numclientes / vdias;
            dgvCed73[2, 0].Value = n2.ToString("N0");

            n3 = v_3 / v_1; double nuevo3 = n3 * numclientes;

            dgvCed73[4, 0].Value = nuevo3.ToString("C2");

            inc1 = 1 - (Convert.ToDouble(dgv_captura3.Rows[0].Cells[0].Value) / numclientes);
            inc2 = 1 - (Convert.ToDouble(dgv_captura3.Rows[0].Cells[1].Value) / Convert.ToDouble(dgvCed73.Rows[0].Cells[2].Value));

            string val = Convert.ToString(dgv_captura3.Rows[0].Cells[2].Value); //val = val.Trim('$');
            string val2 = Convert.ToString(dgvCed73.Rows[0].Cells[4].Value); //val2 = val2.Trim('$');

            inc3 = 1 - (Convert.ToDouble(val) / Convert.ToDouble(val2));
            inc4 = 1 - (Convert.ToDouble(dgv_captura3.Rows[0].Cells[3].Value) / Convert.ToDouble(dgvCed73.Rows[0].Cells[6].Value));
            dgvCed73[1, 0].Value = inc1.ToString("n2"); dgvCed73[3, 0].Value = inc2.ToString("n2");
            dgvCed73[5, 0].Value = inc3.ToString("n2"); dgvCed73[7, 0].Value = inc4.ToString("n2");

            double vent = numclientes * Convert.ToDouble(tb_PROM.Text);
            dgvCed73[8, 0].Value = vent;


        }

        private void dgvCed74_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void m_dgv_calcular_04(double v_1, double v_2, double v_3, double v_4, double v5)
        {
            //clientes 
            dgvCed74.Rows[0].Cells[0].Value = Convert.ToString(numclientes);

            //dias 
            vdias = v_1 / v_2; n2 = numclientes / vdias; dgvCed74[2, 0].Value = n2.ToString("N0");

            //importe venta por cliente 
            n3 = v_3 / v_1; double nuevo3 = n3 * numclientes;
            dgvCed74[4, 0].Value = nuevo3.ToString("C2");

            //pares x cliente 
            vcant = v_1 * v_4; n4 = vcant / numclientes;
            dgvCed74[6, 0].Value = n4.ToString("N2");

            //incrementos 
            inc1 = 1 - (Convert.ToDouble(dgv_captura4.Rows[0].Cells[0].Value) / numclientes);
            inc2 = 1 - (Convert.ToDouble(dgv_captura4.Rows[0].Cells[1].Value) / Convert.ToDouble(dgvCed74.Rows[0].Cells[2].Value));
            inc3 = 1 - (double.Parse(dgv_captura4.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) /
                        double.Parse(dgvCed74.Rows[0].Cells[4].Value.ToString(), NumberStyles.Currency));
            inc4 = 1 - (Convert.ToDouble(dgv_captura4.Rows[0].Cells[3].Value) / Convert.ToDouble(dgvCed74.Rows[0].Cells[6].Value));

            dgvCed74[1, 0].Value = inc1.ToString("n2"); dgvCed74[3, 0].Value = inc2.ToString("n2");
            dgvCed74[5, 0].Value = inc3.ToString("n2"); dgvCed74[7, 0].Value = inc4.ToString("n2");

            double vent = numclientes * Convert.ToDouble(tb_PROM.Text);
            dgvCed74[8, 0].Value = vent;
        }
        private void m_dgv_calcular_64(double v_1, double v_2, double v_3, double v_4, double v5)
        {
            //pares x cliente
            dgvCed74.Rows[0].Cells[6].Value = Convert.ToString(pares);

            numclientes = vcant / pares;

            dgvCed74[0, 0].Value = numclientes.ToString("N0");
            vdias = v_1 / v_2; n2 = numclientes / vdias;
            dgvCed74[2, 0].Value = n2.ToString("N0");

            n3 = v_3 / v_1; double nuevo3 = n3 * numclientes;

            dgvCed74[4, 0].Value = nuevo3.ToString("C2");

            inc1 = 1 - (Convert.ToDouble(dgv_captura4.Rows[0].Cells[0].Value) / numclientes);
            inc2 = 1 - (Convert.ToDouble(dgv_captura4.Rows[0].Cells[1].Value) / Convert.ToDouble(dgvCed74.Rows[0].Cells[2].Value));

            string val = Convert.ToString(dgv_captura4.Rows[0].Cells[2].Value); //val = val.Trim('$');
            string val2 = Convert.ToString(dgvCed74.Rows[0].Cells[4].Value); //val2 = val2.Trim('$');

            inc3 = 1 - (Convert.ToDouble(val) / Convert.ToDouble(val2));
            inc4 = 1 - (Convert.ToDouble(dgv_captura4.Rows[0].Cells[3].Value) / Convert.ToDouble(dgvCed74.Rows[0].Cells[6].Value));
            dgvCed74[1, 0].Value = inc1.ToString("n2"); dgvCed74[3, 0].Value = inc2.ToString("n2");
            dgvCed74[5, 0].Value = inc3.ToString("n2"); dgvCed74[7, 0].Value = inc4.ToString("n2");

            double vent = numclientes * Convert.ToDouble(tb_PROM.Text);
            dgvCed73[8, 0].Value = vent;


        }

        private void button24_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Desea borrar valores cedula actual y crear nueva", "Advertencia! ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                cedula6 cn = new cedula6();
                cn.Show(); this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            m_DIASMESESANOS_guardar(f1.Substring(0, 10), f2.Substring(0, 10));
            MessageBox.Show("Guardado");
        }
        /////////////////////////////////////////////////////////////////
        //@est@
        private void cb_Estructura_DropDown(object sender, EventArgs e)
        {
            #region reiniciar valores

            idsucursal = " ";
            idsucursal = " ";

            #endregion
            cb_Estructura.Items.Clear();
            cb_Estructura.Items.Add("Total");
            int i = 1;
            query = "SELECT descrip,idsucursal from sucursal where visible='S'";
            checaConexion();
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cb_Estructura.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["idsucursal"].ToString();
                i++;
            }
            reader.Close();
        }



        private void cb_Estructura_DropDown()
        {
            #region reiniciar valores
            ////@est@
            int sucS = -1;

            idsucursal = " ";
            idsucursal = " ";

            #endregion
            cb_Estructura.Items.Clear();
            cb_Estructura.Items.Add("Total");
            int i = 1;
            query = "SELECT descrip,idsucursal from sucursal where visible='S'";
            checaConexion();
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cb_Estructura.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["idsucursal"].ToString();
                ////@est@
                if (seleccion_sucursal == Convert.ToInt32(reader["idsucursal"]))
                    sucS = i;

                i++;
            }
            reader.Close();

            /////////////////////////////////////////////////////////////////
            ////@est@

            if (i == 1)
                cb_Estructura.Items.Clear();
            else
            {
                if (sucS != -1)
                {
                    cb_Estructura.SelectedIndex = sucS;

                }
                else
                    cb_Estructura.SelectedIndex = 0;

            }
            /////////////////////////////////////////////////////////////////




        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        /////////////////////////////////////////////////////////////////////////////
        public void m_DIASMESESANOS_guardar(string fecha_inicio, string fecha_final) /////////////////////////////se usa en todos 
        {
            tabcontrol.SelectedIndex = 0;
            int fecha_inicio_dia = Convert.ToInt32(fecha_inicio.Substring(0, 2));
            int fecha_inicio_mes = Convert.ToInt32(fecha_inicio.Substring(3, 2));
            int fecha_inicio_ano = Convert.ToInt32(fecha_inicio.Substring(6, 4));

            int fecha_final_dia = Convert.ToInt32(fecha_final.Substring(0, 2));
            int fecha_final_mes = Convert.ToInt32(fecha_final.Substring(3, 2));
            int fecha_final_ano = Convert.ToInt32(fecha_final.Substring(6, 4));

            #region añomes
            int i = 1;
            for (; fecha_inicio_ano <= fecha_final_ano; fecha_inicio_ano++)
            {
                if (fecha_inicio_mes <= fecha_final_mes)
                {
                    for (; fecha_inicio_mes <= fecha_final_mes; fecha_inicio_mes++, i++)
                    {
                        try
                        {
                            comprobar_guardar(fecha_inicio_ano, fecha_inicio_mes, i);
                            tabcontrol.SelectedIndex = tabcontrol.SelectedIndex + 1;
                        }
                        catch (Exception x)
                        { MessageBox.Show("Error con las fechas " + x); }
                    }
                }
                if (fecha_final_mes < fecha_inicio_mes && fecha_inicio_ano != fecha_final_ano)
                {
                    for (; fecha_inicio_mes <= 12; fecha_inicio_mes++, i++)
                    {
                        try
                        {
                            comprobar_guardar(fecha_inicio_ano, fecha_inicio_mes, i);
                            tabcontrol.SelectedIndex = tabcontrol.SelectedIndex + 1;
                        }
                        catch (Exception x)
                        { MessageBox.Show("Error con las fechas " + x); }
                    }
                }
                fecha_inicio_mes = 1;
            }
            #endregion
            tabcontrol.SelectedIndex = 0;
        }
        public bool comprobar_guardar(int año, int mes, int i)
        {
            bool comprobar = true;
            for (int x = 0; x <= dgvCed7.Rows.Count - 1; x++)
            {
                string s = "SELECT * FROM cedula7 where nombre='" + Properties.Settings.Default.escenario + "' and anio=" + año + " and mes=" + mes + " and idsucursal="+sucursalguardar;
                checaConexion();
                cmd = new MySqlCommand(s, Conn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows == true)
                {
                    comprobar = true;
                }
                else
                {
                    comprobar = false;
                }
                reader.Close();
                if (comprobar == false)
                {
                    insertar(año, mes, i, x);
                }
                else
                {
                    update(año, mes, i, x);
                }
            }
            return true;
        }
        public void insertar(int año, int mes, int grid, int renglon)
        {
            double c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13,c14;
            checaConexion();
            switch (grid)
            {
                case 1:
                    #region insertar cedula1
                    c1 = double.Parse(dgv_captura.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv_captura.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv_captura.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv_captura.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgvCed7.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgvCed7.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgvCed7.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgvCed7.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgvCed7.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgvCed7.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgvCed7.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgvCed7.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgvCed7.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    string s = "insert into cedula7(nombre,2clientes,2clientes_diarios,2imp_venta_cliente,2pares,clientes,por_clientes,clientes_diarios,por_clientes_diarios,imp_venta_cliente,por_imp_venta_cliente,pares,por_pares,venta,mes,anio,idsucursal) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + ","+c8.ToString()+","+c9.ToString()+","+c10.ToString()+","+c11.ToString()+","+c12.ToString()+","+c13.ToString()+"," + mes.ToString() + "," + año.ToString() + " ," + sucursalguardar + ")";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 2:
                    #region insertar cedula1
                    c1 = double.Parse(dgv_captura2.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv_captura2.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv_captura2.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv_captura2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgvCed72.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgvCed72.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgvCed72.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgvCed72.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgvCed72.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgvCed72.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgvCed72.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgvCed72.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgvCed72.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula7(nombre,2clientes,2clientes_diarios,2imp_venta_cliente,2pares,clientes,por_clientes,clientes_diarios,por_clientes_diarios,imp_venta_cliente,por_imp_venta_cliente,pares,por_pares,venta,mes,anio,idsucursal) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + c13.ToString() + "," + mes.ToString() + "," + año.ToString() + " ," + sucursalguardar + ")";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 3:
                    #region insertar cedula1
                    c1 = double.Parse(dgv_captura3.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv_captura3.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv_captura3.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv_captura3.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgvCed73.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgvCed73.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgvCed73.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgvCed73.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgvCed73.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgvCed73.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgvCed73.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgvCed73.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgvCed73.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                     s = "insert into cedula7(nombre,2clientes,2clientes_diarios,2imp_venta_cliente,2pares,clientes,por_clientes,clientes_diarios,por_clientes_diarios,imp_venta_cliente,por_imp_venta_cliente,pares,por_pares,venta,mes,anio,idsucursal) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + c13.ToString() + "," + mes.ToString() + "," + año.ToString() + " ," + sucursalguardar + ")";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 4:
                    #region insertar cedula1
                    c1 = double.Parse(dgv_captura4.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv_captura4.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv_captura4.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv_captura4.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgvCed74.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgvCed74.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgvCed74.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgvCed74.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgvCed74.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgvCed74.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgvCed74.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgvCed74.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgvCed74.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula7(nombre,2clientes,2clientes_diarios,2imp_venta_cliente,2pares,clientes,por_clientes,clientes_diarios,por_clientes_diarios,imp_venta_cliente,por_imp_venta_cliente,pares,por_pares,venta,mes,anio,idsucursal) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + c13.ToString() + "," + mes.ToString() + "," + año.ToString() + " ," + sucursalguardar + ")";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 5:
                    #region insertar cedula1
                    c1 = double.Parse(dgv_captura5.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv_captura5.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv_captura5.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv_captura5.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgvCed75.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgvCed75.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgvCed75.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgvCed75.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgvCed75.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgvCed75.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgvCed75.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgvCed75.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgvCed75.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula7(nombre,2clientes,2clientes_diarios,2imp_venta_cliente,2pares,clientes,por_clientes,clientes_diarios,por_clientes_diarios,imp_venta_cliente,por_imp_venta_cliente,pares,por_pares,venta,mes,anio,idsucursal) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + c13.ToString() + "," + mes.ToString() + "," + año.ToString() + " ," + sucursalguardar + ")";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 6:
                    #region insertar cedula1
                    c1 = double.Parse(dgv_captura6.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv_captura6.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv_captura6.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv_captura6.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgvCed76.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgvCed76.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgvCed76.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgvCed76.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgvCed76.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgvCed76.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgvCed76.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgvCed76.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgvCed76.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula7(nombre,2clientes,2clientes_diarios,2imp_venta_cliente,2pares,clientes,por_clientes,clientes_diarios,por_clientes_diarios,imp_venta_cliente,por_imp_venta_cliente,pares,por_pares,venta,mes,anio,idsucursal) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + c13.ToString() + "," + mes.ToString() + "," + año.ToString() + " ," + sucursalguardar + ")";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 7:
                    #region insertar cedula1
                    c1 = double.Parse(dgv_captura7.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv_captura7.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv_captura7.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv_captura7.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgvCed77.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgvCed77.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgvCed77.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgvCed77.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgvCed77.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgvCed77.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgvCed77.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgvCed77.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgvCed77.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula7(nombre,2clientes,2clientes_diarios,2imp_venta_cliente,2pares,clientes,por_clientes,clientes_diarios,por_clientes_diarios,imp_venta_cliente,por_imp_venta_cliente,pares,por_pares,venta,mes,anio,idsucursal) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + c13.ToString() + "," + mes.ToString() + "," + año.ToString() + " ," + sucursalguardar + ")";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 8:
                    #region insertar cedula1
                    c1 = double.Parse(dgv_captura8.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv_captura8.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv_captura8.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv_captura8.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgvCed78.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgvCed78.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgvCed78.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgvCed78.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgvCed78.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgvCed78.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgvCed78.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgvCed78.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgvCed78.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula7(nombre,2clientes,2clientes_diarios,2imp_venta_cliente,2pares,clientes,por_clientes,clientes_diarios,por_clientes_diarios,imp_venta_cliente,por_imp_venta_cliente,pares,por_pares,venta,mes,anio,idsucursal) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + c13.ToString() + "," + mes.ToString() + "," + año.ToString() + " ," + sucursalguardar + ")";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 9:
                    #region insertar cedula1
                    c1 = double.Parse(dgv_captura9.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv_captura9.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv_captura9.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv_captura9.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgvCed79.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgvCed79.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgvCed79.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgvCed79.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgvCed79.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgvCed79.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgvCed79.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgvCed79.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgvCed79.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula7(nombre,2clientes,2clientes_diarios,2imp_venta_cliente,2pares,clientes,por_clientes,clientes_diarios,por_clientes_diarios,imp_venta_cliente,por_imp_venta_cliente,pares,por_pares,venta,mes,anio,idsucursal) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + c13.ToString() + "," + mes.ToString() + "," + año.ToString() + " ," + sucursalguardar + ")";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 10:
                    #region insertar cedula1
                    c1 = double.Parse(dgv_captura10.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv_captura10.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv_captura10.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv_captura10.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgvCed710.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgvCed710.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgvCed710.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgvCed710.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgvCed710.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgvCed710.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgvCed710.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgvCed710.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgvCed710.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula7(nombre,2clientes,2clientes_diarios,2imp_venta_cliente,2pares,clientes,por_clientes,clientes_diarios,por_clientes_diarios,imp_venta_cliente,por_imp_venta_cliente,pares,por_pares,venta,mes,anio,idsucursal) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + c13.ToString() + "," + mes.ToString() + "," + año.ToString() + " ," + sucursalguardar + ")";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 11:
                    #region insertar cedula1
                    c1 = double.Parse(dgv_captura11.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv_captura11.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv_captura11.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv_captura11.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgvCed711.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgvCed711.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgvCed711.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgvCed711.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgvCed711.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgvCed711.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgvCed711.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgvCed711.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgvCed711.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula7(nombre,2clientes,2clientes_diarios,2imp_venta_cliente,2pares,clientes,por_clientes,clientes_diarios,por_clientes_diarios,imp_venta_cliente,por_imp_venta_cliente,pares,por_pares,venta,mes,anio,idsucursal) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + c13.ToString() + "," + mes.ToString() + "," + año.ToString() + " ," + sucursalguardar + ")";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 12:
                    #region insertar cedula1
                    c1 = double.Parse(dgv_captura12.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv_captura12.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv_captura12.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv_captura12.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgvCed712.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgvCed712.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgvCed712.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgvCed712.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgvCed712.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgvCed712.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgvCed712.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgvCed712.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgvCed712.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                     s = "insert into cedula7(nombre,2clientes,2clientes_diarios,2imp_venta_cliente,2pares,clientes,por_clientes,clientes_diarios,por_clientes_diarios,imp_venta_cliente,por_imp_venta_cliente,pares,por_pares,venta,mes,anio,idsucursal) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + c13.ToString() + "," + mes.ToString() + "," + año.ToString() + " ," + sucursalguardar + ")";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
            }
        }
        public void update(int año, int mes, int grid, int renglon)
        {
            double c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15;
            checaConexion();
            switch (grid)
            {
                case 1:
                    #region insertar cedula1
                    c1 = double.Parse(dgv_captura.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv_captura.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv_captura.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv_captura.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgvCed7.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgvCed7.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgvCed7.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgvCed7.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgvCed7.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgvCed7.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgvCed7.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgvCed7.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgvCed7.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    string q = "update cedula7  set 2clientes=" + c1.ToString() + ",2clientes_diarios=" + c2.ToString() + ",2imp_venta_cliente=" + c3.ToString() + ",2pares=" + c4.ToString() + ",clientes=" + c5.ToString() + ",por_clientes=" + c6.ToString() + ",clientes_diarios=" + c7.ToString() + ",por_clientes_diarios="+c8.ToString()+",imp_venta_cliente="+c9.ToString()+",por_imp_venta_cliente="+c10.ToString()+",pares="+c11.ToString()+",por_pares="+c12.ToString()+",venta="+c13.ToString()+" "+"where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and idsucursal="+sucursalguardar+"";
                    cmd = new MySqlCommand(q, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 2:
                    #region insertar cedula1
                    c1 = double.Parse(dgv_captura2.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv_captura2.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv_captura2.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv_captura2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgvCed72.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgvCed72.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgvCed72.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgvCed72.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgvCed72.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgvCed72.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgvCed72.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgvCed72.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgvCed72.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                     q = "update cedula7  set 2clientes=" + c1.ToString() + ",2clientes_diarios=" + c2.ToString() + ",2imp_venta_cliente=" + c3.ToString() + ",2pares=" + c4.ToString() + ",clientes=" + c5.ToString() + ",por_clientes=" + c6.ToString() + ",clientes_diarios=" + c7.ToString() + ",por_clientes_diarios=" + c8.ToString() + ",imp_venta_cliente=" + c9.ToString() + ",por_imp_venta_cliente=" + c10.ToString() + ",pares=" + c11.ToString() + ",por_pares=" + c12.ToString() + ",venta=" + c13.ToString() + " " + "where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and idsucursal=" + sucursalguardar + "";
                    cmd = new MySqlCommand(q, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 3:
                    #region insertar cedula1
                    c1 = double.Parse(dgv_captura3.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv_captura3.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv_captura3.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv_captura3.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgvCed73.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgvCed73.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgvCed73.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgvCed73.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgvCed73.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgvCed73.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgvCed73.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgvCed73.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgvCed73.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                     q = "update cedula7  set 2clientes=" + c1.ToString() + ",2clientes_diarios=" + c2.ToString() + ",2imp_venta_cliente=" + c3.ToString() + ",2pares=" + c4.ToString() + ",clientes=" + c5.ToString() + ",por_clientes=" + c6.ToString() + ",clientes_diarios=" + c7.ToString() + ",por_clientes_diarios=" + c8.ToString() + ",imp_venta_cliente=" + c9.ToString() + ",por_imp_venta_cliente=" + c10.ToString() + ",pares=" + c11.ToString() + ",por_pares=" + c12.ToString() + ",venta=" + c13.ToString() + " " + "where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and idsucursal=" + sucursalguardar + "";
                    cmd = new MySqlCommand(q, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 4:
                    #region insertar cedula1
                    c1 = double.Parse(dgv_captura4.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv_captura4.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv_captura4.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv_captura4.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgvCed74.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgvCed74.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgvCed74.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgvCed74.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgvCed74.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgvCed74.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgvCed74.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgvCed74.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgvCed74.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                     q = "update cedula7  set 2clientes=" + c1.ToString() + ",2clientes_diarios=" + c2.ToString() + ",2imp_venta_cliente=" + c3.ToString() + ",2pares=" + c4.ToString() + ",clientes=" + c5.ToString() + ",por_clientes=" + c6.ToString() + ",clientes_diarios=" + c7.ToString() + ",por_clientes_diarios=" + c8.ToString() + ",imp_venta_cliente=" + c9.ToString() + ",por_imp_venta_cliente=" + c10.ToString() + ",pares=" + c11.ToString() + ",por_pares=" + c12.ToString() + ",venta=" + c13.ToString() + " " + "where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and idsucursal=" + sucursalguardar + "";
                    cmd = new MySqlCommand(q, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 5:
                    #region insertar cedula1
                    c1 = double.Parse(dgv_captura5.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv_captura5.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv_captura5.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv_captura5.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgvCed75.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgvCed75.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgvCed75.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgvCed75.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgvCed75.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgvCed75.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgvCed75.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgvCed75.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgvCed75.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                     q = "update cedula7  set 2clientes=" + c1.ToString() + ",2clientes_diarios=" + c2.ToString() + ",2imp_venta_cliente=" + c3.ToString() + ",2pares=" + c4.ToString() + ",clientes=" + c5.ToString() + ",por_clientes=" + c6.ToString() + ",clientes_diarios=" + c7.ToString() + ",por_clientes_diarios=" + c8.ToString() + ",imp_venta_cliente=" + c9.ToString() + ",por_imp_venta_cliente=" + c10.ToString() + ",pares=" + c11.ToString() + ",por_pares=" + c12.ToString() + ",venta=" + c13.ToString() + " " + "where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and idsucursal=" + sucursalguardar + "";
                    cmd = new MySqlCommand(q, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 6:
                    #region insertar cedula1
                    c1 = double.Parse(dgv_captura6.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv_captura6.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv_captura6.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv_captura6.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgvCed76.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgvCed76.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgvCed76.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgvCed76.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgvCed76.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgvCed76.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgvCed76.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgvCed76.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgvCed76.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                     q = "update cedula7  set 2clientes=" + c1.ToString() + ",2clientes_diarios=" + c2.ToString() + ",2imp_venta_cliente=" + c3.ToString() + ",2pares=" + c4.ToString() + ",clientes=" + c5.ToString() + ",por_clientes=" + c6.ToString() + ",clientes_diarios=" + c7.ToString() + ",por_clientes_diarios=" + c8.ToString() + ",imp_venta_cliente=" + c9.ToString() + ",por_imp_venta_cliente=" + c10.ToString() + ",pares=" + c11.ToString() + ",por_pares=" + c12.ToString() + ",venta=" + c13.ToString() + " " + "where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and idsucursal=" + sucursalguardar + "";
                    cmd = new MySqlCommand(q, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 7:
                    #region insertar cedula1
                    c1 = double.Parse(dgv_captura7.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv_captura7.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv_captura7.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv_captura7.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgvCed77.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgvCed77.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgvCed77.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgvCed77.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgvCed77.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgvCed77.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgvCed77.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgvCed77.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgvCed77.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                     q = "update cedula7  set 2clientes=" + c1.ToString() + ",2clientes_diarios=" + c2.ToString() + ",2imp_venta_cliente=" + c3.ToString() + ",2pares=" + c4.ToString() + ",clientes=" + c5.ToString() + ",por_clientes=" + c6.ToString() + ",clientes_diarios=" + c7.ToString() + ",por_clientes_diarios=" + c8.ToString() + ",imp_venta_cliente=" + c9.ToString() + ",por_imp_venta_cliente=" + c10.ToString() + ",pares=" + c11.ToString() + ",por_pares=" + c12.ToString() + ",venta=" + c13.ToString() + " " + "where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and idsucursal=" + sucursalguardar + "";
                    cmd = new MySqlCommand(q, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 8:
                    #region insertar cedula1
                    c1 = double.Parse(dgv_captura8.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv_captura8.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv_captura8.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv_captura8.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgvCed78.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgvCed78.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgvCed78.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgvCed78.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgvCed78.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgvCed78.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgvCed78.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgvCed78.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgvCed78.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                     q = "update cedula7  set 2clientes=" + c1.ToString() + ",2clientes_diarios=" + c2.ToString() + ",2imp_venta_cliente=" + c3.ToString() + ",2pares=" + c4.ToString() + ",clientes=" + c5.ToString() + ",por_clientes=" + c6.ToString() + ",clientes_diarios=" + c7.ToString() + ",por_clientes_diarios=" + c8.ToString() + ",imp_venta_cliente=" + c9.ToString() + ",por_imp_venta_cliente=" + c10.ToString() + ",pares=" + c11.ToString() + ",por_pares=" + c12.ToString() + ",venta=" + c13.ToString() + " " + "where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and idsucursal=" + sucursalguardar + "";
                    cmd = new MySqlCommand(q, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 9:
                    #region insertar cedula1
                    c1 = double.Parse(dgv_captura9.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv_captura9.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv_captura9.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv_captura9.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgvCed79.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgvCed79.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgvCed79.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgvCed79.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgvCed79.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgvCed79.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgvCed79.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgvCed79.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgvCed79.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                     q = "update cedula7  set 2clientes=" + c1.ToString() + ",2clientes_diarios=" + c2.ToString() + ",2imp_venta_cliente=" + c3.ToString() + ",2pares=" + c4.ToString() + ",clientes=" + c5.ToString() + ",por_clientes=" + c6.ToString() + ",clientes_diarios=" + c7.ToString() + ",por_clientes_diarios=" + c8.ToString() + ",imp_venta_cliente=" + c9.ToString() + ",por_imp_venta_cliente=" + c10.ToString() + ",pares=" + c11.ToString() + ",por_pares=" + c12.ToString() + ",venta=" + c13.ToString() + " " + "where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and idsucursal=" + sucursalguardar + "";
                    cmd = new MySqlCommand(q, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 10:
                    #region insertar cedula1
                    c1 = double.Parse(dgv_captura10.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv_captura10.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv_captura10.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv_captura10.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgvCed710.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgvCed710.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgvCed710.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgvCed710.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgvCed710.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgvCed710.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgvCed710.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgvCed710.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgvCed710.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                     q = "update cedula7  set 2clientes=" + c1.ToString() + ",2clientes_diarios=" + c2.ToString() + ",2imp_venta_cliente=" + c3.ToString() + ",2pares=" + c4.ToString() + ",clientes=" + c5.ToString() + ",por_clientes=" + c6.ToString() + ",clientes_diarios=" + c7.ToString() + ",por_clientes_diarios=" + c8.ToString() + ",imp_venta_cliente=" + c9.ToString() + ",por_imp_venta_cliente=" + c10.ToString() + ",pares=" + c11.ToString() + ",por_pares=" + c12.ToString() + ",venta=" + c13.ToString() + " " + "where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and idsucursal=" + sucursalguardar + "";
                    cmd = new MySqlCommand(q, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 11:
                    #region insertar cedula1
                    c1 = double.Parse(dgv_captura11.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv_captura11.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv_captura11.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv_captura11.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgvCed711.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgvCed711.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgvCed711.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgvCed711.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgvCed711.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgvCed711.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgvCed711.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgvCed711.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgvCed711.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                     q = "update cedula7  set 2clientes=" + c1.ToString() + ",2clientes_diarios=" + c2.ToString() + ",2imp_venta_cliente=" + c3.ToString() + ",2pares=" + c4.ToString() + ",clientes=" + c5.ToString() + ",por_clientes=" + c6.ToString() + ",clientes_diarios=" + c7.ToString() + ",por_clientes_diarios=" + c8.ToString() + ",imp_venta_cliente=" + c9.ToString() + ",por_imp_venta_cliente=" + c10.ToString() + ",pares=" + c11.ToString() + ",por_pares=" + c12.ToString() + ",venta=" + c13.ToString() + " " + "where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and idsucursal=" + sucursalguardar + "";
                    cmd = new MySqlCommand(q, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 12:
                    #region insertar cedula1
                    c1 = double.Parse(dgv_captura12.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv_captura12.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv_captura12.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv_captura12.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgvCed712.Rows[renglon].Cells[0].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgvCed712.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgvCed712.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgvCed712.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgvCed712.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgvCed712.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgvCed712.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgvCed712.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgvCed712.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                     q = "update cedula7  set 2clientes=" + c1.ToString() + ",2clientes_diarios=" + c2.ToString() + ",2imp_venta_cliente=" + c3.ToString() + ",2pares=" + c4.ToString() + ",clientes=" + c5.ToString() + ",por_clientes=" + c6.ToString() + ",clientes_diarios=" + c7.ToString() + ",por_clientes_diarios=" + c8.ToString() + ",imp_venta_cliente=" + c9.ToString() + ",por_imp_venta_cliente=" + c10.ToString() + ",pares=" + c11.ToString() + ",por_pares=" + c12.ToString() + ",venta=" + c13.ToString() + " " + "where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and idsucursal=" + sucursalguardar + "";
                    cmd = new MySqlCommand(q, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
            }
        }

        private void dgvCed75_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void m_dgv_calcular_05(double v_1, double v_2, double v_3, double v_4, double v5)
        {
            //clientes 
            dgvCed75.Rows[0].Cells[0].Value = Convert.ToString(numclientes);

            //dias 
            vdias = v_1 / v_2; n2 = numclientes / vdias; dgvCed75[2, 0].Value = n2.ToString("N0");

            //importe venta por cliente 
            n3 = v_3 / v_1; double nuevo3 = n3 * numclientes;
            dgvCed75[4, 0].Value = nuevo3.ToString("C2");

            //pares x cliente 
            vcant = v_1 * v_4; n4 = vcant / numclientes;
            dgvCed75[6, 0].Value = n4.ToString("N2");

            //incrementos 
            inc1 = 1 - (Convert.ToDouble(dgv_captura5.Rows[0].Cells[0].Value) / numclientes);
            inc2 = 1 - (Convert.ToDouble(dgv_captura5.Rows[0].Cells[1].Value) / Convert.ToDouble(dgvCed75.Rows[0].Cells[2].Value));
            inc3 = 1 - (double.Parse(dgv_captura5.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) /
                        double.Parse(dgvCed75.Rows[0].Cells[4].Value.ToString(), NumberStyles.Currency));
            inc4 = 1 - (Convert.ToDouble(dgv_captura5.Rows[0].Cells[3].Value) / Convert.ToDouble(dgvCed75.Rows[0].Cells[6].Value));

            dgvCed75[1, 0].Value = inc1.ToString("n2"); dgvCed75[3, 0].Value = inc2.ToString("n2");
            dgvCed75[5, 0].Value = inc3.ToString("n2"); dgvCed75[7, 0].Value = inc4.ToString("n2");

            double vent = numclientes * Convert.ToDouble(tb_PROM.Text);
            dgvCed75[8, 0].Value = vent;
        }
        private void m_dgv_calcular_65(double v_1, double v_2, double v_3, double v_4, double v5)
        {
            //pares x cliente
            dgvCed75.Rows[0].Cells[6].Value = Convert.ToString(pares);

            numclientes = vcant / pares;

            dgvCed75[0, 0].Value = numclientes.ToString("N0");
            vdias = v_1 / v_2; n2 = numclientes / vdias;
            dgvCed75[2, 0].Value = n2.ToString("N0");

            n3 = v_3 / v_1; double nuevo3 = n3 * numclientes;

            dgvCed75[4, 0].Value = nuevo3.ToString("C2");

            inc1 = 1 - (Convert.ToDouble(dgv_captura5.Rows[0].Cells[0].Value) / numclientes);
            inc2 = 1 - (Convert.ToDouble(dgv_captura5.Rows[0].Cells[1].Value) / Convert.ToDouble(dgvCed75.Rows[0].Cells[2].Value));

            string val = Convert.ToString(dgv_captura5.Rows[0].Cells[2].Value); //val = val.Trim('$');
            string val2 = Convert.ToString(dgvCed75.Rows[0].Cells[4].Value); //val2 = val2.Trim('$');

            inc3 = 1 - (Convert.ToDouble(val) / Convert.ToDouble(val2));
            inc4 = 1 - (Convert.ToDouble(dgv_captura5.Rows[0].Cells[3].Value) / Convert.ToDouble(dgvCed75.Rows[0].Cells[6].Value));
            dgvCed75[1, 0].Value = inc1.ToString("n2"); dgvCed75[3, 0].Value = inc2.ToString("n2");
            dgvCed75[5, 0].Value = inc3.ToString("n2"); dgvCed75[7, 0].Value = inc4.ToString("n2");

            double vent = numclientes * Convert.ToDouble(tb_PROM.Text);
            dgvCed75[8, 0].Value = vent;


        }

        private void dgvCed76_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void m_dgv_calcular_06(double v_1, double v_2, double v_3, double v_4, double v5)
        {
            //clientes 
            dgvCed76.Rows[0].Cells[0].Value = Convert.ToString(numclientes);

            //dias 
            vdias = v_1 / v_2; n2 = numclientes / vdias; dgvCed76[2, 0].Value = n2.ToString("N0");

            //importe venta por cliente 
            n3 = v_3 / v_1; double nuevo3 = n3 * numclientes;
            dgvCed76[4, 0].Value = nuevo3.ToString("C2");

            //pares x cliente 
            vcant = v_1 * v_4; n4 = vcant / numclientes;
            dgvCed76[6, 0].Value = n4.ToString("N2");

            //incrementos 
            inc1 = 1 - (Convert.ToDouble(dgv_captura6.Rows[0].Cells[0].Value) / numclientes);
            inc2 = 1 - (Convert.ToDouble(dgv_captura6.Rows[0].Cells[1].Value) / Convert.ToDouble(dgvCed76.Rows[0].Cells[2].Value));
            inc3 = 1 - (double.Parse(dgv_captura6.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) /
                        double.Parse(dgvCed76.Rows[0].Cells[4].Value.ToString(), NumberStyles.Currency));
            inc4 = 1 - (Convert.ToDouble(dgv_captura6.Rows[0].Cells[3].Value) / Convert.ToDouble(dgvCed76.Rows[0].Cells[6].Value));

            dgvCed76[1, 0].Value = inc1.ToString("n2"); dgvCed76[3, 0].Value = inc2.ToString("n2");
            dgvCed76[5, 0].Value = inc3.ToString("n2"); dgvCed76[7, 0].Value = inc4.ToString("n2");

            double vent = numclientes * Convert.ToDouble(tb_PROM.Text);
            dgvCed76[8, 0].Value = vent;
        }
        private void m_dgv_calcular_66(double v_1, double v_2, double v_3, double v_4, double v5)
        {
            //pares x cliente
            dgvCed76.Rows[0].Cells[6].Value = Convert.ToString(pares);

            numclientes = vcant / pares;

            dgvCed76[0, 0].Value = numclientes.ToString("N0");
            vdias = v_1 / v_2; n2 = numclientes / vdias;
            dgvCed76[2, 0].Value = n2.ToString("N0");

            n3 = v_3 / v_1; double nuevo3 = n3 * numclientes;

            dgvCed76[4, 0].Value = nuevo3.ToString("C2");

            inc1 = 1 - (Convert.ToDouble(dgv_captura6.Rows[0].Cells[0].Value) / numclientes);
            inc2 = 1 - (Convert.ToDouble(dgv_captura6.Rows[0].Cells[1].Value) / Convert.ToDouble(dgvCed76.Rows[0].Cells[2].Value));

            string val = Convert.ToString(dgv_captura6.Rows[0].Cells[2].Value); //val = val.Trim('$');
            string val2 = Convert.ToString(dgvCed76.Rows[0].Cells[4].Value); //val2 = val2.Trim('$');

            inc3 = 1 - (Convert.ToDouble(val) / Convert.ToDouble(val2));
            inc4 = 1 - (Convert.ToDouble(dgv_captura6.Rows[0].Cells[3].Value) / Convert.ToDouble(dgvCed76.Rows[0].Cells[6].Value));
            dgvCed76[1, 0].Value = inc1.ToString("n2"); dgvCed76[3, 0].Value = inc2.ToString("n2");
            dgvCed76[5, 0].Value = inc3.ToString("n2"); dgvCed76[7, 0].Value = inc4.ToString("n2");

            double vent = numclientes * Convert.ToDouble(tb_PROM.Text);
            dgvCed76[8, 0].Value = vent;


        }

        private void dgvCed77_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void m_dgv_calcular_07(double v_1, double v_2, double v_3, double v_4, double v5)
        {
            //clientes 
            dgvCed77.Rows[0].Cells[0].Value = Convert.ToString(numclientes);

            //dias 
            vdias = v_1 / v_2; n2 = numclientes / vdias; dgvCed77[2, 0].Value = n2.ToString("N0");

            //importe venta por cliente 
            n3 = v_3 / v_1; double nuevo3 = n3 * numclientes;
            dgvCed77[4, 0].Value = nuevo3.ToString("C2");

            //pares x cliente 
            vcant = v_1 * v_4; n4 = vcant / numclientes;
            dgvCed77[6, 0].Value = n4.ToString("N2");

            //incrementos 
            inc1 = 1 - (Convert.ToDouble(dgv_captura7.Rows[0].Cells[0].Value) / numclientes);
            inc2 = 1 - (Convert.ToDouble(dgv_captura7.Rows[0].Cells[1].Value) / Convert.ToDouble(dgvCed77.Rows[0].Cells[2].Value));
            inc3 = 1 - (double.Parse(dgv_captura7.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) /
                        double.Parse(dgvCed77.Rows[0].Cells[4].Value.ToString(), NumberStyles.Currency));
            inc4 = 1 - (Convert.ToDouble(dgv_captura7.Rows[0].Cells[3].Value) / Convert.ToDouble(dgvCed77.Rows[0].Cells[6].Value));

            dgvCed77[1, 0].Value = inc1.ToString("n2"); dgvCed77[3, 0].Value = inc2.ToString("n2");
            dgvCed77[5, 0].Value = inc3.ToString("n2"); dgvCed77[7, 0].Value = inc4.ToString("n2");

            double vent = numclientes * Convert.ToDouble(tb_PROM.Text);
            dgvCed77[8, 0].Value = vent;
        }
        private void m_dgv_calcular_67(double v_1, double v_2, double v_3, double v_4, double v5)
        {
            //pares x cliente
            dgvCed77.Rows[0].Cells[6].Value = Convert.ToString(pares);

            numclientes = vcant / pares;

            dgvCed77[0, 0].Value = numclientes.ToString("N0");
            vdias = v_1 / v_2; n2 = numclientes / vdias;
            dgvCed77[2, 0].Value = n2.ToString("N0");

            n3 = v_3 / v_1; double nuevo3 = n3 * numclientes;

            dgvCed77[4, 0].Value = nuevo3.ToString("C2");

            inc1 = 1 - (Convert.ToDouble(dgv_captura7.Rows[0].Cells[0].Value) / numclientes);
            inc2 = 1 - (Convert.ToDouble(dgv_captura7.Rows[0].Cells[1].Value) / Convert.ToDouble(dgvCed77.Rows[0].Cells[2].Value));

            string val = Convert.ToString(dgv_captura7.Rows[0].Cells[2].Value); //val = val.Trim('$');
            string val2 = Convert.ToString(dgvCed77.Rows[0].Cells[4].Value); //val2 = val2.Trim('$');

            inc3 = 1 - (Convert.ToDouble(val) / Convert.ToDouble(val2));
            inc4 = 1 - (Convert.ToDouble(dgv_captura7.Rows[0].Cells[3].Value) / Convert.ToDouble(dgvCed77.Rows[0].Cells[6].Value));
            dgvCed77[1, 0].Value = inc1.ToString("n2"); dgvCed77[3, 0].Value = inc2.ToString("n2");
            dgvCed77[5, 0].Value = inc3.ToString("n2"); dgvCed77[7, 0].Value = inc4.ToString("n2");

            double vent = numclientes * Convert.ToDouble(tb_PROM.Text);
            dgvCed77[8, 0].Value = vent;


        }

        private void dgvCed78_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void m_dgv_calcular_08(double v_1, double v_2, double v_3, double v_4, double v5)
        {
            //clientes 
            dgvCed78.Rows[0].Cells[0].Value = Convert.ToString(numclientes);

            //dias 
            vdias = v_1 / v_2; n2 = numclientes / vdias; dgvCed78[2, 0].Value = n2.ToString("N0");

            //importe venta por cliente 
            n3 = v_3 / v_1; double nuevo3 = n3 * numclientes;
            dgvCed78[4, 0].Value = nuevo3.ToString("C2");

            //pares x cliente 
            vcant = v_1 * v_4; n4 = vcant / numclientes;
            dgvCed78[6, 0].Value = n4.ToString("N2");

            //incrementos 
            inc1 = 1 - (Convert.ToDouble(dgv_captura8.Rows[0].Cells[0].Value) / numclientes);
            inc2 = 1 - (Convert.ToDouble(dgv_captura8.Rows[0].Cells[1].Value) / Convert.ToDouble(dgvCed78.Rows[0].Cells[2].Value));
            inc3 = 1 - (double.Parse(dgv_captura8.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) /
                        double.Parse(dgvCed78.Rows[0].Cells[4].Value.ToString(), NumberStyles.Currency));
            inc4 = 1 - (Convert.ToDouble(dgv_captura8.Rows[0].Cells[3].Value) / Convert.ToDouble(dgvCed78.Rows[0].Cells[6].Value));

            dgvCed78[1, 0].Value = inc1.ToString("n2"); dgvCed78[3, 0].Value = inc2.ToString("n2");
            dgvCed78[5, 0].Value = inc3.ToString("n2"); dgvCed78[7, 0].Value = inc4.ToString("n2");

            double vent = numclientes * Convert.ToDouble(tb_PROM.Text);
            dgvCed78[8, 0].Value = vent;
        }
        private void m_dgv_calcular_68(double v_1, double v_2, double v_3, double v_4, double v5)
        {
            //pares x cliente
            dgvCed78.Rows[0].Cells[6].Value = Convert.ToString(pares);

            numclientes = vcant / pares;

            dgvCed78[0, 0].Value = numclientes.ToString("N0");
            vdias = v_1 / v_2; n2 = numclientes / vdias;
            dgvCed78[2, 0].Value = n2.ToString("N0");

            n3 = v_3 / v_1; double nuevo3 = n3 * numclientes;

            dgvCed78[4, 0].Value = nuevo3.ToString("C2");

            inc1 = 1 - (Convert.ToDouble(dgv_captura8.Rows[0].Cells[0].Value) / numclientes);
            inc2 = 1 - (Convert.ToDouble(dgv_captura8.Rows[0].Cells[1].Value) / Convert.ToDouble(dgvCed78.Rows[0].Cells[2].Value));

            string val = Convert.ToString(dgv_captura8.Rows[0].Cells[2].Value); //val = val.Trim('$');
            string val2 = Convert.ToString(dgvCed78.Rows[0].Cells[4].Value); //val2 = val2.Trim('$');

            inc3 = 1 - (Convert.ToDouble(val) / Convert.ToDouble(val2));
            inc4 = 1 - (Convert.ToDouble(dgv_captura8.Rows[0].Cells[3].Value) / Convert.ToDouble(dgvCed78.Rows[0].Cells[6].Value));
            dgvCed78[1, 0].Value = inc1.ToString("n2"); dgvCed78[3, 0].Value = inc2.ToString("n2");
            dgvCed78[5, 0].Value = inc3.ToString("n2"); dgvCed78[7, 0].Value = inc4.ToString("n2");

            double vent = numclientes * Convert.ToDouble(tb_PROM.Text);
            dgvCed78[8, 0].Value = vent;


        }

        private void dgvCed79_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void m_dgv_calcular_09(double v_1, double v_2, double v_3, double v_4, double v5)
        {
            //clientes 
            dgvCed79.Rows[0].Cells[0].Value = Convert.ToString(numclientes);

            //dias 
            vdias = v_1 / v_2; n2 = numclientes / vdias; dgvCed79[2, 0].Value = n2.ToString("N0");

            //importe venta por cliente 
            n3 = v_3 / v_1; double nuevo3 = n3 * numclientes;
            dgvCed79[4, 0].Value = nuevo3.ToString("C2");

            //pares x cliente 
            vcant = v_1 * v_4; n4 = vcant / numclientes;
            dgvCed79[6, 0].Value = n4.ToString("N2");

            //incrementos 
            inc1 = 1 - (Convert.ToDouble(dgv_captura9.Rows[0].Cells[0].Value) / numclientes);
            inc2 = 1 - (Convert.ToDouble(dgv_captura9.Rows[0].Cells[1].Value) / Convert.ToDouble(dgvCed79.Rows[0].Cells[2].Value));
            inc3 = 1 - (double.Parse(dgv_captura9.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) /
                        double.Parse(dgvCed79.Rows[0].Cells[4].Value.ToString(), NumberStyles.Currency));
            inc4 = 1 - (Convert.ToDouble(dgv_captura9.Rows[0].Cells[3].Value) / Convert.ToDouble(dgvCed79.Rows[0].Cells[6].Value));

            dgvCed79[1, 0].Value = inc1.ToString("n2"); dgvCed79[3, 0].Value = inc2.ToString("n2");
            dgvCed79[5, 0].Value = inc3.ToString("n2"); dgvCed79[7, 0].Value = inc4.ToString("n2");

            double vent = numclientes * Convert.ToDouble(tb_PROM.Text);
            dgvCed79[8, 0].Value = vent;
        }
        private void m_dgv_calcular_69(double v_1, double v_2, double v_3, double v_4, double v5)
        {
            //pares x cliente
            dgvCed79.Rows[0].Cells[6].Value = Convert.ToString(pares);

            numclientes = vcant / pares;

            dgvCed79[0, 0].Value = numclientes.ToString("N0");
            vdias = v_1 / v_2; n2 = numclientes / vdias;
            dgvCed79[2, 0].Value = n2.ToString("N0");

            n3 = v_3 / v_1; double nuevo3 = n3 * numclientes;

            dgvCed79[4, 0].Value = nuevo3.ToString("C2");

            inc1 = 1 - (Convert.ToDouble(dgv_captura9.Rows[0].Cells[0].Value) / numclientes);
            inc2 = 1 - (Convert.ToDouble(dgv_captura9.Rows[0].Cells[1].Value) / Convert.ToDouble(dgvCed79.Rows[0].Cells[2].Value));

            string val = Convert.ToString(dgv_captura9.Rows[0].Cells[2].Value); //val = val.Trim('$');
            string val2 = Convert.ToString(dgvCed79.Rows[0].Cells[4].Value); //val2 = val2.Trim('$');

            inc3 = 1 - (Convert.ToDouble(val) / Convert.ToDouble(val2));
            inc4 = 1 - (Convert.ToDouble(dgv_captura9.Rows[0].Cells[3].Value) / Convert.ToDouble(dgvCed79.Rows[0].Cells[6].Value));
            dgvCed79[1, 0].Value = inc1.ToString("n2"); dgvCed79[3, 0].Value = inc2.ToString("n2");
            dgvCed79[5, 0].Value = inc3.ToString("n2"); dgvCed79[7, 0].Value = inc4.ToString("n2");

            double vent = numclientes * Convert.ToDouble(tb_PROM.Text);
            dgvCed79[8, 0].Value = vent;


        }

        private void dgvCed710_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void m_dgv_calcular_010(double v_1, double v_2, double v_3, double v_4, double v5)
        {
            //clientes 
            dgvCed710.Rows[0].Cells[0].Value = Convert.ToString(numclientes);

            //dias 
            vdias = v_1 / v_2; n2 = numclientes / vdias; dgvCed710[2, 0].Value = n2.ToString("N0");

            //importe venta por cliente 
            n3 = v_3 / v_1; double nuevo3 = n3 * numclientes;
            dgvCed710[4, 0].Value = nuevo3.ToString("C2");

            //pares x cliente 
            vcant = v_1 * v_4; n4 = vcant / numclientes;
            dgvCed710[6, 0].Value = n4.ToString("N2");

            //incrementos 
            inc1 = 1 - (Convert.ToDouble(dgv_captura10.Rows[0].Cells[0].Value) / numclientes);
            inc2 = 1 - (Convert.ToDouble(dgv_captura10.Rows[0].Cells[1].Value) / Convert.ToDouble(dgvCed710.Rows[0].Cells[2].Value));
            inc3 = 1 - (double.Parse(dgv_captura10.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) /
                        double.Parse(dgvCed710.Rows[0].Cells[4].Value.ToString(), NumberStyles.Currency));
            inc4 = 1 - (Convert.ToDouble(dgv_captura10.Rows[0].Cells[3].Value) / Convert.ToDouble(dgvCed710.Rows[0].Cells[6].Value));

            dgvCed710[1, 0].Value = inc1.ToString("n2"); dgvCed710[3, 0].Value = inc2.ToString("n2");
            dgvCed710[5, 0].Value = inc3.ToString("n2"); dgvCed710[7, 0].Value = inc4.ToString("n2");

            double vent = numclientes * Convert.ToDouble(tb_PROM.Text);
            dgvCed710[8, 0].Value = vent;
        }
        private void m_dgv_calcular_610(double v_1, double v_2, double v_3, double v_4, double v5)
        {
            //pares x cliente
            dgvCed710.Rows[0].Cells[6].Value = Convert.ToString(pares);

            numclientes = vcant / pares;

            dgvCed710[0, 0].Value = numclientes.ToString("N0");
            vdias = v_1 / v_2; n2 = numclientes / vdias;
            dgvCed710[2, 0].Value = n2.ToString("N0");

            n3 = v_3 / v_1; double nuevo3 = n3 * numclientes;

            dgvCed710[4, 0].Value = nuevo3.ToString("C2");

            inc1 = 1 - (Convert.ToDouble(dgv_captura10.Rows[0].Cells[0].Value) / numclientes);
            inc2 = 1 - (Convert.ToDouble(dgv_captura10.Rows[0].Cells[1].Value) / Convert.ToDouble(dgvCed710.Rows[0].Cells[2].Value));

            string val = Convert.ToString(dgv_captura10.Rows[0].Cells[2].Value); //val = val.Trim('$');
            string val2 = Convert.ToString(dgvCed710.Rows[0].Cells[4].Value); //val2 = val2.Trim('$');

            inc3 = 1 - (Convert.ToDouble(val) / Convert.ToDouble(val2));
            inc4 = 1 - (Convert.ToDouble(dgv_captura10.Rows[0].Cells[3].Value) / Convert.ToDouble(dgvCed710.Rows[0].Cells[6].Value));
            dgvCed710[1, 0].Value = inc1.ToString("n2"); dgvCed710[3, 0].Value = inc2.ToString("n2");
            dgvCed710[5, 0].Value = inc3.ToString("n2"); dgvCed710[7, 0].Value = inc4.ToString("n2");

            double vent = numclientes * Convert.ToDouble(tb_PROM.Text);
            dgvCed710[8, 0].Value = vent;


        }

        private void dgvCed711_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void m_dgv_calcular_011(double v_1, double v_2, double v_3, double v_4, double v5)
        {
            //clientes 
            dgvCed711.Rows[0].Cells[0].Value = Convert.ToString(numclientes);

            //dias 
            vdias = v_1 / v_2; n2 = numclientes / vdias; dgvCed711[2, 0].Value = n2.ToString("N0");

            //importe venta por cliente 
            n3 = v_3 / v_1; double nuevo3 = n3 * numclientes;
            dgvCed711[4, 0].Value = nuevo3.ToString("C2");

            //pares x cliente 
            vcant = v_1 * v_4; n4 = vcant / numclientes;
            dgvCed711[6, 0].Value = n4.ToString("N2");

            //incrementos 
            inc1 = 1 - (Convert.ToDouble(dgv_captura11.Rows[0].Cells[0].Value) / numclientes);
            inc2 = 1 - (Convert.ToDouble(dgv_captura11.Rows[0].Cells[1].Value) / Convert.ToDouble(dgvCed711.Rows[0].Cells[2].Value));
            inc3 = 1 - (double.Parse(dgv_captura11.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) /
                        double.Parse(dgvCed711.Rows[0].Cells[4].Value.ToString(), NumberStyles.Currency));
            inc4 = 1 - (Convert.ToDouble(dgv_captura11.Rows[0].Cells[3].Value) / Convert.ToDouble(dgvCed711.Rows[0].Cells[6].Value));

            dgvCed711[1, 0].Value = inc1.ToString("n2"); dgvCed711[3, 0].Value = inc2.ToString("n2");
            dgvCed711[5, 0].Value = inc3.ToString("n2"); dgvCed711[7, 0].Value = inc4.ToString("n2");

            double vent = numclientes * Convert.ToDouble(tb_PROM.Text);
            dgvCed711[8, 0].Value = vent;
        }
        private void m_dgv_calcular_611(double v_1, double v_2, double v_3, double v_4, double v5)
        {
            //pares x cliente
            dgvCed711.Rows[0].Cells[6].Value = Convert.ToString(pares);

            numclientes = vcant / pares;

            dgvCed711[0, 0].Value = numclientes.ToString("N0");
            vdias = v_1 / v_2; n2 = numclientes / vdias;
            dgvCed711[2, 0].Value = n2.ToString("N0");

            n3 = v_3 / v_1; double nuevo3 = n3 * numclientes;

            dgvCed711[4, 0].Value = nuevo3.ToString("C2");

            inc1 = 1 - (Convert.ToDouble(dgv_captura11.Rows[0].Cells[0].Value) / numclientes);
            inc2 = 1 - (Convert.ToDouble(dgv_captura11.Rows[0].Cells[1].Value) / Convert.ToDouble(dgvCed711.Rows[0].Cells[2].Value));

            string val = Convert.ToString(dgv_captura11.Rows[0].Cells[2].Value); //val = val.Trim('$');
            string val2 = Convert.ToString(dgvCed711.Rows[0].Cells[4].Value); //val2 = val2.Trim('$');

            inc3 = 1 - (Convert.ToDouble(val) / Convert.ToDouble(val2));
            inc4 = 1 - (Convert.ToDouble(dgv_captura11.Rows[0].Cells[3].Value) / Convert.ToDouble(dgvCed711.Rows[0].Cells[6].Value));
            dgvCed711[1, 0].Value = inc1.ToString("n2"); dgvCed711[3, 0].Value = inc2.ToString("n2");
            dgvCed711[5, 0].Value = inc3.ToString("n2"); dgvCed711[7, 0].Value = inc4.ToString("n2");

            double vent = numclientes * Convert.ToDouble(tb_PROM.Text);
            dgvCed711[8, 0].Value = vent;


        }

        private void dgvCed712_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void m_dgv_calcular_012(double v_1, double v_2, double v_3, double v_4, double v5)
        {
            //clientes 
            dgvCed712.Rows[0].Cells[0].Value = Convert.ToString(numclientes);

            //dias 
            vdias = v_1 / v_2; n2 = numclientes / vdias; dgvCed712[2, 0].Value = n2.ToString("N0");

            //importe venta por cliente 
            n3 = v_3 / v_1; double nuevo3 = n3 * numclientes;
            dgvCed712[4, 0].Value = nuevo3.ToString("C2");

            //pares x cliente 
            vcant = v_1 * v_4; n4 = vcant / numclientes;
            dgvCed712[6, 0].Value = n4.ToString("N2");

            //incrementos 
            inc1 = 1 - (Convert.ToDouble(dgv_captura12.Rows[0].Cells[0].Value) / numclientes);
            inc2 = 1 - (Convert.ToDouble(dgv_captura12.Rows[0].Cells[1].Value) / Convert.ToDouble(dgvCed712.Rows[0].Cells[2].Value));
            inc3 = 1 - (double.Parse(dgv_captura12.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) /
                        double.Parse(dgvCed712.Rows[0].Cells[4].Value.ToString(), NumberStyles.Currency));
            inc4 = 1 - (Convert.ToDouble(dgv_captura12.Rows[0].Cells[3].Value) / Convert.ToDouble(dgvCed712.Rows[0].Cells[6].Value));

            dgvCed712[1, 0].Value = inc1.ToString("n2"); dgvCed712[3, 0].Value = inc2.ToString("n2");
            dgvCed712[5, 0].Value = inc3.ToString("n2"); dgvCed712[7, 0].Value = inc4.ToString("n2");

            double vent = numclientes * Convert.ToDouble(tb_PROM.Text);
            dgvCed712[8, 0].Value = vent;
        }
        private void m_dgv_calcular_612(double v_1, double v_2, double v_3, double v_4, double v5)
        {
            //pares x cliente
            dgvCed712.Rows[0].Cells[6].Value = Convert.ToString(pares);

            numclientes = vcant / pares;

            dgvCed712[0, 0].Value = numclientes.ToString("N0");
            vdias = v_1 / v_2; n2 = numclientes / vdias;
            dgvCed712[2, 0].Value = n2.ToString("N0");

            n3 = v_3 / v_1; double nuevo3 = n3 * numclientes;

            dgvCed712[4, 0].Value = nuevo3.ToString("C2");

            inc1 = 1 - (Convert.ToDouble(dgv_captura12.Rows[0].Cells[0].Value) / numclientes);
            inc2 = 1 - (Convert.ToDouble(dgv_captura12.Rows[0].Cells[1].Value) / Convert.ToDouble(dgvCed712.Rows[0].Cells[2].Value));

            string val = Convert.ToString(dgv_captura12.Rows[0].Cells[2].Value); //val = val.Trim('$');
            string val2 = Convert.ToString(dgvCed712.Rows[0].Cells[4].Value); //val2 = val2.Trim('$');

            inc3 = 1 - (Convert.ToDouble(val) / Convert.ToDouble(val2));
            inc4 = 1 - (Convert.ToDouble(dgv_captura12.Rows[0].Cells[3].Value) / Convert.ToDouble(dgvCed712.Rows[0].Cells[6].Value));
            dgvCed712[1, 0].Value = inc1.ToString("n2"); dgvCed712[3, 0].Value = inc2.ToString("n2");
            dgvCed712[5, 0].Value = inc3.ToString("n2"); dgvCed712[7, 0].Value = inc4.ToString("n2");

            double vent = numclientes * Convert.ToDouble(tb_PROM.Text);
            dgvCed712[8, 0].Value = vent;


        }
        private bool comprobarCargar(int año, int mes, int i)
        {
            bool comprobar = true;
            string s = "SELECT * FROM cedula7 where nombre='" + Properties.Settings.Default.escenario + "' and anio=" + año + " and mes=" + mes + " and idsucursal="+sucursalguardar;
            checaConexion();
            cmd = new MySqlCommand(s, Conn);
            reader = cmd.ExecuteReader();
            if (reader.HasRows == true)
            {
                comprobar = true;
            }
            else
            {
                comprobar = false;
            }
            reader.Close();
            return comprobar;
        }
        private void cargar(int mes, int año, int g)
        {

            double c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15;
            switch (g)
            {
                case 1:
                    #region cargar grid1
                    for (int x = 0; x <= dgv_captura.Rows.Count - 1; x++)
                    {
                        string s = "SELECT * FROM cedula7 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and idsucursal="+sucursalguardar;
                        checaConexion();
                        cmd = new MySqlCommand(s, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["2clientes"].ToString());
                            c2 = double.Parse(reader["2clientes_diarios"].ToString());
                            c3 = double.Parse(reader["2imp_venta_cliente"].ToString());
                            c4 = double.Parse(reader["2pares"].ToString());
                            c5 = double.Parse(reader["clientes"].ToString());
                            c6 = double.Parse(reader["por_clientes"].ToString());
                            c7 = double.Parse(reader["clientes_diarios"].ToString());
                            c8 = double.Parse(reader["por_clientes_diarios"].ToString());
                            c9 = double.Parse(reader["imp_venta_cliente"].ToString());
                            c10 = double.Parse(reader["por_imp_venta_cliente"].ToString());
                            c11 = double.Parse(reader["pares"].ToString());
                            c12 = double.Parse(reader["por_pares"].ToString());
                            c13 = double.Parse(reader["venta"].ToString());
                            
                            dgv_captura.Rows[x].Cells[0].Value = c1.ToString("n0");
                            dgv_captura.Rows[x].Cells[1].Value = c2.ToString("N2");
                            dgv_captura.Rows[x].Cells[2].Value = c3.ToString("N2");
                            dgv_captura.Rows[x].Cells[3].Value = c4.ToString("n0");
                            dgvCed7.Rows[x].Cells[0].Value = c5.ToString("n0");
                            dgvCed7.Rows[x].Cells[1].Value = c6.ToString("N2");
                            dgvCed7.Rows[x].Cells[2].Value = c7.ToString("n0");
                            dgvCed7.Rows[x].Cells[3].Value = c8.ToString("N2");
                            dgvCed7.Rows[x].Cells[4].Value = c9.ToString("N2");
                            dgvCed7.Rows[x].Cells[5].Value = c10.ToString("n0");
                            dgvCed7.Rows[x].Cells[6].Value = c11.ToString("N2");
                            dgvCed7.Rows[x].Cells[7].Value = c12.ToString("n0");
                            dgvCed7.Rows[x].Cells[8].Value = c13.ToString("N2");
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 2:
                    #region cargar grid1
                    for (int x = 0; x <= dgv_captura.Rows.Count - 1; x++)
                    {
                        string s = "SELECT * FROM cedula7 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and idsucursal=" + sucursalguardar;
                        checaConexion();
                        cmd = new MySqlCommand(s, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["2clientes"].ToString());
                            c2 = double.Parse(reader["2clientes_diarios"].ToString());
                            c3 = double.Parse(reader["2imp_venta_cliente"].ToString());
                            c4 = double.Parse(reader["2pares"].ToString());
                            c5 = double.Parse(reader["clientes"].ToString());
                            c6 = double.Parse(reader["por_clientes"].ToString());
                            c7 = double.Parse(reader["clientes_diarios"].ToString());
                            c8 = double.Parse(reader["por_clientes_diarios"].ToString());
                            c9 = double.Parse(reader["imp_venta_cliente"].ToString());
                            c10 = double.Parse(reader["por_imp_venta_cliente"].ToString());
                            c11 = double.Parse(reader["pares"].ToString());
                            c12 = double.Parse(reader["por_pares"].ToString());
                            c13 = double.Parse(reader["venta"].ToString());

                            dgv_captura2.Rows[x].Cells[0].Value = c1.ToString("n0");
                            dgv_captura2.Rows[x].Cells[1].Value = c2.ToString("N2");
                            dgv_captura2.Rows[x].Cells[2].Value = c3.ToString("N2");
                            dgv_captura2.Rows[x].Cells[3].Value = c4.ToString("n0");
                            dgvCed72.Rows[x].Cells[0].Value = c5.ToString("n0");
                            dgvCed72.Rows[x].Cells[1].Value = c6.ToString("N2");
                            dgvCed72.Rows[x].Cells[2].Value = c7.ToString("n0");
                            dgvCed72.Rows[x].Cells[3].Value = c8.ToString("N2");
                            dgvCed72.Rows[x].Cells[4].Value = c9.ToString("N2");
                            dgvCed72.Rows[x].Cells[5].Value = c10.ToString("n0");
                            dgvCed72.Rows[x].Cells[6].Value = c11.ToString("N2");
                            dgvCed72.Rows[x].Cells[7].Value = c12.ToString("n0");
                            dgvCed72.Rows[x].Cells[8].Value = c13.ToString("N2");
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 3:
                    #region cargar grid1
                    for (int x = 0; x <= dgv_captura.Rows.Count - 1; x++)
                    {
                        string s = "SELECT * FROM cedula7 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and idsucursal=" + sucursalguardar;
                        checaConexion();
                        cmd = new MySqlCommand(s, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["2clientes"].ToString());
                            c2 = double.Parse(reader["2clientes_diarios"].ToString());
                            c3 = double.Parse(reader["2imp_venta_cliente"].ToString());
                            c4 = double.Parse(reader["2pares"].ToString());
                            c5 = double.Parse(reader["clientes"].ToString());
                            c6 = double.Parse(reader["por_clientes"].ToString());
                            c7 = double.Parse(reader["clientes_diarios"].ToString());
                            c8 = double.Parse(reader["por_clientes_diarios"].ToString());
                            c9 = double.Parse(reader["imp_venta_cliente"].ToString());
                            c10 = double.Parse(reader["por_imp_venta_cliente"].ToString());
                            c11 = double.Parse(reader["pares"].ToString());
                            c12 = double.Parse(reader["por_pares"].ToString());
                            c13 = double.Parse(reader["venta"].ToString());

                            dgv_captura3.Rows[x].Cells[0].Value = c1.ToString("n0");
                            dgv_captura3.Rows[x].Cells[1].Value = c2.ToString("N2");
                            dgv_captura3.Rows[x].Cells[2].Value = c3.ToString("N2");
                            dgv_captura3.Rows[x].Cells[3].Value = c4.ToString("n0");
                            dgvCed73.Rows[x].Cells[0].Value = c5.ToString("n0");
                            dgvCed73.Rows[x].Cells[1].Value = c6.ToString("N2");
                            dgvCed73.Rows[x].Cells[2].Value = c7.ToString("n0");
                            dgvCed73.Rows[x].Cells[3].Value = c8.ToString("N2");
                            dgvCed73.Rows[x].Cells[4].Value = c9.ToString("N2");
                            dgvCed73.Rows[x].Cells[5].Value = c10.ToString("n0");
                            dgvCed73.Rows[x].Cells[6].Value = c11.ToString("N2");
                            dgvCed73.Rows[x].Cells[7].Value = c12.ToString("n0");
                            dgvCed73.Rows[x].Cells[8].Value = c13.ToString("N2");
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 4:
                    #region cargar grid1
                    for (int x = 0; x <= dgv_captura.Rows.Count - 1; x++)
                    {
                        string s = "SELECT * FROM cedula7 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and idsucursal=" + sucursalguardar;
                        checaConexion();
                        cmd = new MySqlCommand(s, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["2clientes"].ToString());
                            c2 = double.Parse(reader["2clientes_diarios"].ToString());
                            c3 = double.Parse(reader["2imp_venta_cliente"].ToString());
                            c4 = double.Parse(reader["2pares"].ToString());
                            c5 = double.Parse(reader["clientes"].ToString());
                            c6 = double.Parse(reader["por_clientes"].ToString());
                            c7 = double.Parse(reader["clientes_diarios"].ToString());
                            c8 = double.Parse(reader["por_clientes_diarios"].ToString());
                            c9 = double.Parse(reader["imp_venta_cliente"].ToString());
                            c10 = double.Parse(reader["por_imp_venta_cliente"].ToString());
                            c11 = double.Parse(reader["pares"].ToString());
                            c12 = double.Parse(reader["por_pares"].ToString());
                            c13 = double.Parse(reader["venta"].ToString());

                            dgv_captura4.Rows[x].Cells[0].Value = c1.ToString("n0");
                            dgv_captura4.Rows[x].Cells[1].Value = c2.ToString("N2");
                            dgv_captura4.Rows[x].Cells[2].Value = c3.ToString("N2");
                            dgv_captura4.Rows[x].Cells[3].Value = c4.ToString("n0");
                            dgvCed74.Rows[x].Cells[0].Value = c5.ToString("n0");
                            dgvCed74.Rows[x].Cells[1].Value = c6.ToString("N2");
                            dgvCed74.Rows[x].Cells[2].Value = c7.ToString("n0");
                            dgvCed74.Rows[x].Cells[3].Value = c8.ToString("N2");
                            dgvCed74.Rows[x].Cells[4].Value = c9.ToString("N2");
                            dgvCed74.Rows[x].Cells[5].Value = c10.ToString("n0");
                            dgvCed74.Rows[x].Cells[6].Value = c11.ToString("N2");
                            dgvCed74.Rows[x].Cells[7].Value = c12.ToString("n0");
                            dgvCed74.Rows[x].Cells[8].Value = c13.ToString("N2");
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 5:
                    #region cargar grid1
                    for (int x = 0; x <= dgv_captura.Rows.Count - 1; x++)
                    {
                        string s = "SELECT * FROM cedula7 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and idsucursal=" + sucursalguardar;
                        checaConexion();
                        cmd = new MySqlCommand(s, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["2clientes"].ToString());
                            c2 = double.Parse(reader["2clientes_diarios"].ToString());
                            c3 = double.Parse(reader["2imp_venta_cliente"].ToString());
                            c4 = double.Parse(reader["2pares"].ToString());
                            c5 = double.Parse(reader["clientes"].ToString());
                            c6 = double.Parse(reader["por_clientes"].ToString());
                            c7 = double.Parse(reader["clientes_diarios"].ToString());
                            c8 = double.Parse(reader["por_clientes_diarios"].ToString());
                            c9 = double.Parse(reader["imp_venta_cliente"].ToString());
                            c10 = double.Parse(reader["por_imp_venta_cliente"].ToString());
                            c11 = double.Parse(reader["pares"].ToString());
                            c12 = double.Parse(reader["por_pares"].ToString());
                            c13 = double.Parse(reader["venta"].ToString());

                            dgv_captura5.Rows[x].Cells[0].Value = c1.ToString("n0");
                            dgv_captura5.Rows[x].Cells[1].Value = c2.ToString("N2");
                            dgv_captura5.Rows[x].Cells[2].Value = c3.ToString("N2");
                            dgv_captura5.Rows[x].Cells[3].Value = c4.ToString("n0");
                            dgvCed75.Rows[x].Cells[0].Value = c5.ToString("n0");
                            dgvCed75.Rows[x].Cells[1].Value = c6.ToString("N2");
                            dgvCed75.Rows[x].Cells[2].Value = c7.ToString("n0");
                            dgvCed75.Rows[x].Cells[3].Value = c8.ToString("N2");
                            dgvCed75.Rows[x].Cells[4].Value = c9.ToString("N2");
                            dgvCed75.Rows[x].Cells[5].Value = c10.ToString("n0");
                            dgvCed75.Rows[x].Cells[6].Value = c11.ToString("N2");
                            dgvCed75.Rows[x].Cells[7].Value = c12.ToString("n0");
                            dgvCed75.Rows[x].Cells[8].Value = c13.ToString("N2");
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 6:
                    #region cargar grid1
                    for (int x = 0; x <= dgv_captura.Rows.Count - 1; x++)
                    {
                        string s = "SELECT * FROM cedula7 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and idsucursal=" + sucursalguardar;
                        checaConexion();
                        cmd = new MySqlCommand(s, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["2clientes"].ToString());
                            c2 = double.Parse(reader["2clientes_diarios"].ToString());
                            c3 = double.Parse(reader["2imp_venta_cliente"].ToString());
                            c4 = double.Parse(reader["2pares"].ToString());
                            c5 = double.Parse(reader["clientes"].ToString());
                            c6 = double.Parse(reader["por_clientes"].ToString());
                            c7 = double.Parse(reader["clientes_diarios"].ToString());
                            c8 = double.Parse(reader["por_clientes_diarios"].ToString());
                            c9 = double.Parse(reader["imp_venta_cliente"].ToString());
                            c10 = double.Parse(reader["por_imp_venta_cliente"].ToString());
                            c11 = double.Parse(reader["pares"].ToString());
                            c12 = double.Parse(reader["por_pares"].ToString());
                            c13 = double.Parse(reader["venta"].ToString());

                            dgv_captura6.Rows[x].Cells[0].Value = c1.ToString("n0");
                            dgv_captura6.Rows[x].Cells[1].Value = c2.ToString("N2");
                            dgv_captura6.Rows[x].Cells[2].Value = c3.ToString("N2");
                            dgv_captura6.Rows[x].Cells[3].Value = c4.ToString("n0");
                            dgvCed76.Rows[x].Cells[0].Value = c5.ToString("n0");
                            dgvCed76.Rows[x].Cells[1].Value = c6.ToString("N2");
                            dgvCed76.Rows[x].Cells[2].Value = c7.ToString("n0");
                            dgvCed76.Rows[x].Cells[3].Value = c8.ToString("N2");
                            dgvCed76.Rows[x].Cells[4].Value = c9.ToString("N2");
                            dgvCed76.Rows[x].Cells[5].Value = c10.ToString("n0");
                            dgvCed76.Rows[x].Cells[6].Value = c11.ToString("N2");
                            dgvCed76.Rows[x].Cells[7].Value = c12.ToString("n0");
                            dgvCed76.Rows[x].Cells[8].Value = c13.ToString("N2");
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 7:
                    #region cargar grid1
                    for (int x = 0; x <= dgv_captura.Rows.Count - 1; x++)
                    {
                        string s = "SELECT * FROM cedula7 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and idsucursal=" + sucursalguardar;
                        checaConexion();
                        cmd = new MySqlCommand(s, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["2clientes"].ToString());
                            c2 = double.Parse(reader["2clientes_diarios"].ToString());
                            c3 = double.Parse(reader["2imp_venta_cliente"].ToString());
                            c4 = double.Parse(reader["2pares"].ToString());
                            c5 = double.Parse(reader["clientes"].ToString());
                            c6 = double.Parse(reader["por_clientes"].ToString());
                            c7 = double.Parse(reader["clientes_diarios"].ToString());
                            c8 = double.Parse(reader["por_clientes_diarios"].ToString());
                            c9 = double.Parse(reader["imp_venta_cliente"].ToString());
                            c10 = double.Parse(reader["por_imp_venta_cliente"].ToString());
                            c11 = double.Parse(reader["pares"].ToString());
                            c12 = double.Parse(reader["por_pares"].ToString());
                            c13 = double.Parse(reader["venta"].ToString());

                            dgv_captura7.Rows[x].Cells[0].Value = c1.ToString("n0");
                            dgv_captura7.Rows[x].Cells[1].Value = c2.ToString("N2");
                            dgv_captura7.Rows[x].Cells[2].Value = c3.ToString("N2");
                            dgv_captura7.Rows[x].Cells[3].Value = c4.ToString("n0");
                            dgvCed77.Rows[x].Cells[0].Value = c5.ToString("n0");
                            dgvCed77.Rows[x].Cells[1].Value = c6.ToString("N2");
                            dgvCed77.Rows[x].Cells[2].Value = c7.ToString("n0");
                            dgvCed77.Rows[x].Cells[3].Value = c8.ToString("N2");
                            dgvCed77.Rows[x].Cells[4].Value = c9.ToString("N2");
                            dgvCed77.Rows[x].Cells[5].Value = c10.ToString("n0");
                            dgvCed77.Rows[x].Cells[6].Value = c11.ToString("N2");
                            dgvCed77.Rows[x].Cells[7].Value = c12.ToString("n0");
                            dgvCed77.Rows[x].Cells[8].Value = c13.ToString("N2");
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 8:
                    #region cargar grid1
                    for (int x = 0; x <= dgv_captura.Rows.Count - 1; x++)
                    {
                        string s = "SELECT * FROM cedula7 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and idsucursal=" + sucursalguardar;
                        checaConexion();
                        cmd = new MySqlCommand(s, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["2clientes"].ToString());
                            c2 = double.Parse(reader["2clientes_diarios"].ToString());
                            c3 = double.Parse(reader["2imp_venta_cliente"].ToString());
                            c4 = double.Parse(reader["2pares"].ToString());
                            c5 = double.Parse(reader["clientes"].ToString());
                            c6 = double.Parse(reader["por_clientes"].ToString());
                            c7 = double.Parse(reader["clientes_diarios"].ToString());
                            c8 = double.Parse(reader["por_clientes_diarios"].ToString());
                            c9 = double.Parse(reader["imp_venta_cliente"].ToString());
                            c10 = double.Parse(reader["por_imp_venta_cliente"].ToString());
                            c11 = double.Parse(reader["pares"].ToString());
                            c12 = double.Parse(reader["por_pares"].ToString());
                            c13 = double.Parse(reader["venta"].ToString());

                            dgv_captura8.Rows[x].Cells[0].Value = c1.ToString("n0");
                            dgv_captura8.Rows[x].Cells[1].Value = c2.ToString("N2");
                            dgv_captura8.Rows[x].Cells[2].Value = c3.ToString("N2");
                            dgv_captura8.Rows[x].Cells[3].Value = c4.ToString("n0");
                            dgvCed78.Rows[x].Cells[0].Value = c5.ToString("n0");
                            dgvCed78.Rows[x].Cells[1].Value = c6.ToString("N2");
                            dgvCed78.Rows[x].Cells[2].Value = c7.ToString("n0");
                            dgvCed78.Rows[x].Cells[3].Value = c8.ToString("N2");
                            dgvCed78.Rows[x].Cells[4].Value = c9.ToString("N2");
                            dgvCed78.Rows[x].Cells[5].Value = c10.ToString("n0");
                            dgvCed78.Rows[x].Cells[6].Value = c11.ToString("N2");
                            dgvCed78.Rows[x].Cells[7].Value = c12.ToString("n0");
                            dgvCed78.Rows[x].Cells[8].Value = c13.ToString("N2");
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 9:
                    #region cargar grid1
                    for (int x = 0; x <= dgv_captura.Rows.Count - 1; x++)
                    {
                        string s = "SELECT * FROM cedula7 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and idsucursal=" + sucursalguardar;
                        checaConexion();
                        cmd = new MySqlCommand(s, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["2clientes"].ToString());
                            c2 = double.Parse(reader["2clientes_diarios"].ToString());
                            c3 = double.Parse(reader["2imp_venta_cliente"].ToString());
                            c4 = double.Parse(reader["2pares"].ToString());
                            c5 = double.Parse(reader["clientes"].ToString());
                            c6 = double.Parse(reader["por_clientes"].ToString());
                            c7 = double.Parse(reader["clientes_diarios"].ToString());
                            c8 = double.Parse(reader["por_clientes_diarios"].ToString());
                            c9 = double.Parse(reader["imp_venta_cliente"].ToString());
                            c10 = double.Parse(reader["por_imp_venta_cliente"].ToString());
                            c11 = double.Parse(reader["pares"].ToString());
                            c12 = double.Parse(reader["por_pares"].ToString());
                            c13 = double.Parse(reader["venta"].ToString());

                            dgv_captura9.Rows[x].Cells[0].Value = c1.ToString("n0");
                            dgv_captura9.Rows[x].Cells[1].Value = c2.ToString("N2");
                            dgv_captura9.Rows[x].Cells[2].Value = c3.ToString("N2");
                            dgv_captura9.Rows[x].Cells[3].Value = c4.ToString("n0");
                            dgvCed79.Rows[x].Cells[0].Value = c5.ToString("n0");
                            dgvCed79.Rows[x].Cells[1].Value = c6.ToString("N2");
                            dgvCed79.Rows[x].Cells[2].Value = c7.ToString("n0");
                            dgvCed79.Rows[x].Cells[3].Value = c8.ToString("N2");
                            dgvCed79.Rows[x].Cells[4].Value = c9.ToString("N2");
                            dgvCed79.Rows[x].Cells[5].Value = c10.ToString("n0");
                            dgvCed79.Rows[x].Cells[6].Value = c11.ToString("N2");
                            dgvCed79.Rows[x].Cells[7].Value = c12.ToString("n0");
                            dgvCed79.Rows[x].Cells[8].Value = c13.ToString("N2");
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 10:
                    #region cargar grid1
                    for (int x = 0; x <= dgv_captura.Rows.Count - 1; x++)
                    {
                        string s = "SELECT * FROM cedula7 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and idsucursal=" + sucursalguardar;
                        checaConexion();
                        cmd = new MySqlCommand(s, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["2clientes"].ToString());
                            c2 = double.Parse(reader["2clientes_diarios"].ToString());
                            c3 = double.Parse(reader["2imp_venta_cliente"].ToString());
                            c4 = double.Parse(reader["2pares"].ToString());
                            c5 = double.Parse(reader["clientes"].ToString());
                            c6 = double.Parse(reader["por_clientes"].ToString());
                            c7 = double.Parse(reader["clientes_diarios"].ToString());
                            c8 = double.Parse(reader["por_clientes_diarios"].ToString());
                            c9 = double.Parse(reader["imp_venta_cliente"].ToString());
                            c10 = double.Parse(reader["por_imp_venta_cliente"].ToString());
                            c11 = double.Parse(reader["pares"].ToString());
                            c12 = double.Parse(reader["por_pares"].ToString());
                            c13 = double.Parse(reader["venta"].ToString());

                            dgv_captura10.Rows[x].Cells[0].Value = c1.ToString("n0");
                            dgv_captura10.Rows[x].Cells[1].Value = c2.ToString("N2");
                            dgv_captura10.Rows[x].Cells[2].Value = c3.ToString("N2");
                            dgv_captura10.Rows[x].Cells[3].Value = c4.ToString("n0");
                            dgvCed710.Rows[x].Cells[0].Value = c5.ToString("n0");
                            dgvCed710.Rows[x].Cells[1].Value = c6.ToString("N2");
                            dgvCed710.Rows[x].Cells[2].Value = c7.ToString("n0");
                            dgvCed710.Rows[x].Cells[3].Value = c8.ToString("N2");
                            dgvCed710.Rows[x].Cells[4].Value = c9.ToString("N2");
                            dgvCed710.Rows[x].Cells[5].Value = c10.ToString("n0");
                            dgvCed710.Rows[x].Cells[6].Value = c11.ToString("N2");
                            dgvCed710.Rows[x].Cells[7].Value = c12.ToString("n0");
                            dgvCed710.Rows[x].Cells[8].Value = c13.ToString("N2");
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 11:
                    #region cargar grid1
                    for (int x = 0; x <= dgv_captura.Rows.Count - 1; x++)
                    {
                        string s = "SELECT * FROM cedula7 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and idsucursal=" + sucursalguardar;
                        checaConexion();
                        cmd = new MySqlCommand(s, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["2clientes"].ToString());
                            c2 = double.Parse(reader["2clientes_diarios"].ToString());
                            c3 = double.Parse(reader["2imp_venta_cliente"].ToString());
                            c4 = double.Parse(reader["2pares"].ToString());
                            c5 = double.Parse(reader["clientes"].ToString());
                            c6 = double.Parse(reader["por_clientes"].ToString());
                            c7 = double.Parse(reader["clientes_diarios"].ToString());
                            c8 = double.Parse(reader["por_clientes_diarios"].ToString());
                            c9 = double.Parse(reader["imp_venta_cliente"].ToString());
                            c10 = double.Parse(reader["por_imp_venta_cliente"].ToString());
                            c11 = double.Parse(reader["pares"].ToString());
                            c12 = double.Parse(reader["por_pares"].ToString());
                            c13 = double.Parse(reader["venta"].ToString());

                            dgv_captura11.Rows[x].Cells[0].Value = c1.ToString("n0");
                            dgv_captura11.Rows[x].Cells[1].Value = c2.ToString("N2");
                            dgv_captura11.Rows[x].Cells[2].Value = c3.ToString("N2");
                            dgv_captura11.Rows[x].Cells[3].Value = c4.ToString("n0");
                            dgvCed711.Rows[x].Cells[0].Value = c5.ToString("n0");
                            dgvCed711.Rows[x].Cells[1].Value = c6.ToString("N2");
                            dgvCed711.Rows[x].Cells[2].Value = c7.ToString("n0");
                            dgvCed711.Rows[x].Cells[3].Value = c8.ToString("N2");
                            dgvCed711.Rows[x].Cells[4].Value = c9.ToString("N2");
                            dgvCed711.Rows[x].Cells[5].Value = c10.ToString("n0");
                            dgvCed711.Rows[x].Cells[6].Value = c11.ToString("N2");
                            dgvCed711.Rows[x].Cells[7].Value = c12.ToString("n0");
                            dgvCed711.Rows[x].Cells[8].Value = c13.ToString("N2");
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 12:
                    #region cargar grid1
                    for (int x = 0; x <= dgv_captura.Rows.Count - 1; x++)
                    {
                        string s = "SELECT * FROM cedula7 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and idsucursal=" + sucursalguardar;
                        checaConexion();
                        cmd = new MySqlCommand(s, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["2clientes"].ToString());
                            c2 = double.Parse(reader["2clientes_diarios"].ToString());
                            c3 = double.Parse(reader["2imp_venta_cliente"].ToString());
                            c4 = double.Parse(reader["2pares"].ToString());
                            c5 = double.Parse(reader["clientes"].ToString());
                            c6 = double.Parse(reader["por_clientes"].ToString());
                            c7 = double.Parse(reader["clientes_diarios"].ToString());
                            c8 = double.Parse(reader["por_clientes_diarios"].ToString());
                            c9 = double.Parse(reader["imp_venta_cliente"].ToString());
                            c10 = double.Parse(reader["por_imp_venta_cliente"].ToString());
                            c11 = double.Parse(reader["pares"].ToString());
                            c12 = double.Parse(reader["por_pares"].ToString());
                            c13 = double.Parse(reader["venta"].ToString());

                            dgv_captura12.Rows[x].Cells[0].Value = c1.ToString("n0");
                            dgv_captura12.Rows[x].Cells[1].Value = c2.ToString("N2");
                            dgv_captura12.Rows[x].Cells[2].Value = c3.ToString("N2");
                            dgv_captura12.Rows[x].Cells[3].Value = c4.ToString("n0");
                            dgvCed712.Rows[x].Cells[0].Value = c5.ToString("n0");
                            dgvCed712.Rows[x].Cells[1].Value = c6.ToString("N2");
                            dgvCed712.Rows[x].Cells[2].Value = c7.ToString("n0");
                            dgvCed712.Rows[x].Cells[3].Value = c8.ToString("N2");
                            dgvCed712.Rows[x].Cells[4].Value = c9.ToString("N2");
                            dgvCed712.Rows[x].Cells[5].Value = c10.ToString("n0");
                            dgvCed712.Rows[x].Cells[6].Value = c11.ToString("N2");
                            dgvCed712.Rows[x].Cells[7].Value = c12.ToString("n0");
                            dgvCed712.Rows[x].Cells[8].Value = c13.ToString("N2");
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
            }
        }

        private void menuPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opciones op = new Opciones();
            this.Hide();
            op.ShowDialog();
            this.Close();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log_in l = new Log_in();
            this.Hide();
            l.ShowDialog();
            this.Close();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_obtenerVentas(int i,int mes, int anio)
        {
            string q = "";
            double v = 0;
            switch(i)
            {
                case 1:
                    #region mes 1
                    if (cb_Estructura.Text == "Total")
                    {
                        q = "SELECT VentasUnidades from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and  ZapateriasTorreon=1 and mes=" + mes + " and anio=" + anio;
                    }
                    else
                    {
                        q = "SELECT VentasUnidades from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + sucursalguardar + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1' and mes=" + mes + " and anio=" + anio;
                    }
                    cmd = new MySqlCommand(q, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader["VentasUnidades"].ToString() == "")
                        {
                            v = 0;
                        }
                        else
                        {
                            v = double.Parse(reader["VentasUnidades"].ToString());
                        }
					
                        //dgvCed7.Rows[0].Cells[dgvCed7.ColumnCount-2].Value=reader["VentasUnidades"].ToString();
                        dgvCed7.Rows[0].Cells[dgvCed7.ColumnCount - 2].Value = v.ToString("N0");
                    }
                    reader.Close();
                    if (cb_Estructura.Text == "Total")
                    {
                        q = "SELECT Ventasimporte from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1 and mes=" + mes + " and anio=" + anio;
                    }
                    else
                    {
                        q = "SELECT Ventasimporte from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + sucursalguardar + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1' and mes=" + mes + " and anio=" + anio;
                    }
                    cmd = new MySqlCommand(q, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dgvCed7.Rows[0].Cells[dgvCed7.ColumnCount - 1].Value = reader["Ventasimporte"].ToString();
                    }
                    reader.Close();
                    #endregion
                    break;
                case 2:
                    #region mes 
                    if (cb_Estructura.Text == "Total")
                    {
                        q = "SELECT VentasUnidades from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1 and mes=" + mes + " and anio=" + anio;
                    }
                    else
                    {
                        q = "SELECT VentasUnidades from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + sucursalguardar + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1' and mes=" + mes + " and anio=" + anio;
                    }
                    cmd = new MySqlCommand(q, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader["VentasUnidades"].ToString() == "")
                        {
                            v = 0;
                        }
                        else
                        {
                            v = double.Parse(reader["VentasUnidades"].ToString());
                        }
                        //dgvCed7.Rows[0].Cells[dgvCed7.ColumnCount-2].Value=reader["VentasUnidades"].ToString();
                        //dgvCed7.Rows[0].Cells[dgvCed7.ColumnCount - 2].Value = v.ToString("N0");
                        dgvCed72.Rows[0].Cells[dgvCed7.ColumnCount - 2].Value = v.ToString("N0");
                    }
                    reader.Close();
                    if (cb_Estructura.Text == "Total")
                    {
                        q = "SELECT Ventasimporte from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1 and mes=" + mes + " and anio=" + anio;
                    }
                    else
                    {
                        q = "SELECT Ventasimporte from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + sucursalguardar + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1' and mes=" + mes + " and anio=" + anio;
                    }
                    cmd = new MySqlCommand(q, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dgvCed72.Rows[0].Cells[dgvCed7.ColumnCount - 1].Value = reader["Ventasimporte"].ToString();
                    }
                    reader.Close();
                    #endregion
                    break;
                case 3:
                    #region mes 3
                    if (cb_Estructura.Text == "Total")
                    {
                        q = "SELECT VentasUnidades from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1 and mes=" + mes + " and anio=" + anio;
                    }
                    else
                    {
                        q = "SELECT VentasUnidades from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + sucursalguardar + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1' and mes=" + mes + " and anio=" + anio;
                    }
                    cmd = new MySqlCommand(q, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader["VentasUnidades"].ToString() == "")
                        {
                            v = 0;
                        }
                        else
                        {
                            v = double.Parse(reader["VentasUnidades"].ToString());
                        }
                        //dgvCed7.Rows[0].Cells[dgvCed7.ColumnCount-2].Value=reader["VentasUnidades"].ToString();
                        //dgvCed7.Rows[0].Cells[dgvCed7.ColumnCount - 2].Value = v.ToString("N0");
                        //dgvCed72.Rows[0].Cells[dgvCed7.ColumnCount - 2].Value = 
                        dgvCed73.Rows[0].Cells[dgvCed7.ColumnCount - 2].Value =v.ToString("N0");
                    }
                    reader.Close();
                    if (cb_Estructura.Text == "Total")
                    {
                        q = "SELECT Ventasimporte from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1 and mes=" + mes + " and anio=" + anio;
                    }
                    else
                    {
                        q = "SELECT Ventasimporte from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + sucursalguardar + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1' and mes=" + mes + " and anio=" + anio;
                    }
                    cmd = new MySqlCommand(q, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dgvCed73.Rows[0].Cells[dgvCed7.ColumnCount - 1].Value = reader["Ventasimporte"].ToString();
                    }
                    reader.Close();
                    #endregion
                    break;
                case 4:
                    #region mes 4
                    if (cb_Estructura.Text == "Total")
                    {
                        q = "SELECT VentasUnidades from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1 and mes=" + mes + " and anio=" + anio;
                    }
                    else
                    {
                        q = "SELECT VentasUnidades from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + sucursalguardar + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1' and mes=" + mes + " and anio=" + anio;
                    }
                    cmd = new MySqlCommand(q, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader["VentasUnidades"].ToString() == "")
                        {
                            v = 0;
                        }
                        else
                        {
                            v = double.Parse(reader["VentasUnidades"].ToString());
                        }
                        //dgvCed7.Rows[0].Cells[dgvCed7.ColumnCount-2].Value=reader["VentasUnidades"].ToString();
                        //dgvCed7.Rows[0].Cells[dgvCed7.ColumnCount - 2].Value = v.ToString("N0");
                        //dgvCed72.Rows[0].Cells[dgvCed7.ColumnCount - 2].Value = 
                        dgvCed74.Rows[0].Cells[dgvCed7.ColumnCount - 2].Value = v.ToString("N0");
                    }
                    reader.Close();
                    if (cb_Estructura.Text == "Total")
                    {
                        q = "SELECT Ventasimporte from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1 and mes=" + mes + " and anio=" + anio;
                    }
                    else
                    {
                        q = "SELECT Ventasimporte from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + sucursalguardar + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1' and mes=" + mes + " and anio=" + anio;
                    }
                    cmd = new MySqlCommand(q, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dgvCed74.Rows[0].Cells[dgvCed74.ColumnCount - 1].Value = reader["Ventasimporte"].ToString();
                    }
                    reader.Close();
                    #endregion
                    break;
                case 5:
                    #region mes 5
                    if (cb_Estructura.Text == "Total")
                    {
                        q = "SELECT VentasUnidades from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1 and mes=" + mes + " and anio=" + anio;
                    }
                    else
                    {
                        q = "SELECT VentasUnidades from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + sucursalguardar + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1' and mes=" + mes + " and anio=" + anio;
                    }
                    cmd = new MySqlCommand(q, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader["VentasUnidades"].ToString() == "")
                        {
                            v = 0;
                        }
                        else
                        {
                            v = double.Parse(reader["VentasUnidades"].ToString());
                        }
                        //dgvCed7.Rows[0].Cells[dgvCed7.ColumnCount-2].Value=reader["VentasUnidades"].ToString();
                        //dgvCed7.Rows[0].Cells[dgvCed7.ColumnCount - 2].Value = v.ToString("N0");
                        //dgvCed72.Rows[0].Cells[dgvCed7.ColumnCount - 2].Value = 
                        dgvCed75.Rows[0].Cells[dgvCed7.ColumnCount - 2].Value = v.ToString("N0");
                    }
                    reader.Close();
                    if (cb_Estructura.Text == "Total")
                    {
                        q = "SELECT Ventasimporte from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1 and mes=" + mes + " and anio=" + anio;
                    }
                    else
                    {
                        q = "SELECT Ventasimporte from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + sucursalguardar + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1' and mes=" + mes + " and anio=" + anio;
                    }
                    cmd = new MySqlCommand(q, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dgvCed75.Rows[0].Cells[dgvCed7.ColumnCount - 1].Value = reader["Ventasimporte"].ToString();
                    }
                    reader.Close();
                    #endregion
                    break;
                case 6:
                    #region mes 6
                    if (cb_Estructura.Text == "Total")
                    {
                        q = "SELECT VentasUnidades from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1 and mes=" + mes + " and anio=" + anio;
                    }
                    else
                    {
                        q = "SELECT VentasUnidades from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + sucursalguardar + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1' and mes=" + mes + " and anio=" + anio;
                    }
                    cmd = new MySqlCommand(q, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dgvCed76.Rows[0].Cells[dgvCed7.ColumnCount - 2].Value = reader["VentasUnidades"].ToString();
                    }
                    reader.Close();
                    if (cb_Estructura.Text == "Total")
                    {
                        q = "SELECT Ventasimporte from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1 and mes=" + mes + " and anio=" + anio;
                    }
                    else
                    {
                        q = "SELECT Ventasimporte from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + sucursalguardar + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1' and mes=" + mes + " and anio=" + anio;
                    }
                    cmd = new MySqlCommand(q, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dgvCed76.Rows[0].Cells[dgvCed7.ColumnCount - 1].Value = reader["Ventasimporte"].ToString();
                    }
                    reader.Close();
                    #endregion
                    break;
                case 7:
                    #region mes 7
                    if (cb_Estructura.Text == "Total")
                    {
                        q = "SELECT VentasUnidades from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1 and mes=" + mes + " and anio=" + anio;
                    }
                    else
                    {
                        q = "SELECT VentasUnidades from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + sucursalguardar + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1' and mes=" + mes + " and anio=" + anio;
                    }
                    cmd = new MySqlCommand(q, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dgvCed77.Rows[0].Cells[dgvCed7.ColumnCount - 2].Value = reader["VentasUnidades"].ToString();
                    }
                    reader.Close();
                    if (cb_Estructura.Text == "Total")
                    {
                        q = "SELECT Ventasimporte from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1 and mes=" + mes + " and anio=" + anio;
                    }
                    else
                    {
                        q = "SELECT Ventasimporte from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + sucursalguardar + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1' and mes=" + mes + " and anio=" + anio;
                    }
                    cmd = new MySqlCommand(q, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dgvCed77.Rows[0].Cells[dgvCed7.ColumnCount - 1].Value = reader["Ventasimporte"].ToString();
                    }
                    reader.Close();
                    #endregion
                    break;
                case 8:
                    #region mes 8
                    if (cb_Estructura.Text == "Total")
                    {
                        q = "SELECT VentasUnidades from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1 and mes=" + mes + " and anio=" + anio;
                    }
                    else
                    {
                        q = "SELECT VentasUnidades from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + sucursalguardar + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1' and mes=" + mes + " and anio=" + anio;
                    }
                    cmd = new MySqlCommand(q, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dgvCed78.Rows[0].Cells[dgvCed7.ColumnCount - 2].Value = reader["VentasUnidades"].ToString();
                    }
                    reader.Close();
                    if (cb_Estructura.Text == "Total")
                    {
                        q = "SELECT Ventasimporte from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1 and mes=" + mes + " and anio=" + anio;
                    }
                    else
                    {
                        q = "SELECT Ventasimporte from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + sucursalguardar + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1' and mes=" + mes + " and anio=" + anio;
                    }
                    cmd = new MySqlCommand(q, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dgvCed78.Rows[0].Cells[dgvCed7.ColumnCount - 1].Value = reader["Ventasimporte"].ToString();
                    }
                    reader.Close();
                    #endregion
                    break;
                case 9:
                    #region mes 9
                    if (cb_Estructura.Text == "Total")
                    {
                        q = "SELECT VentasUnidades from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1 and mes=" + mes + " and anio=" + anio;
                    }
                    else
                    {
                        q = "SELECT VentasUnidades from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + sucursalguardar + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1' and mes=" + mes + " and anio=" + anio;
                    }
                    cmd = new MySqlCommand(q, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dgvCed79.Rows[0].Cells[dgvCed7.ColumnCount - 2].Value = reader["VentasUnidades"].ToString();
                    }
                    reader.Close();
                    if (cb_Estructura.Text == "Total")
                    {
                        q = "SELECT Ventasimporte from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1 and mes=" + mes + " and anio=" + anio;
                    }
                    else
                    {
                        q = "SELECT Ventasimporte from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + sucursalguardar + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1' and mes=" + mes + " and anio=" + anio;
                    }
                    cmd = new MySqlCommand(q, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dgvCed79.Rows[0].Cells[dgvCed7.ColumnCount - 1].Value = reader["Ventasimporte"].ToString();
                    }
                    reader.Close();
                    #endregion
                    break;
                case 10:
                    #region mes 10
                    if (cb_Estructura.Text == "Total")
                    {
                        q = "SELECT VentasUnidades from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1 and mes=" + mes + " and anio=" + anio;
                    }
                    else
                    {
                        q = "SELECT VentasUnidades from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + sucursalguardar + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1' and mes=" + mes + " and anio=" + anio;
                    }
                    cmd = new MySqlCommand(q, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dgvCed710.Rows[0].Cells[dgvCed7.ColumnCount - 2].Value = reader["VentasUnidades"].ToString();
                    }
                    reader.Close();
                    if (cb_Estructura.Text == "Total")
                    {
                        q = "SELECT Ventasimporte from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1 and mes=" + mes + " and anio=" + anio;
                    }
                    else
                    {
                        q = "SELECT Ventasimporte from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + sucursalguardar + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1' and mes=" + mes + " and anio=" + anio;
                    }
                    cmd = new MySqlCommand(q, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dgvCed710.Rows[0].Cells[dgvCed7.ColumnCount - 1].Value = reader["Ventasimporte"].ToString();
                    }
                    reader.Close();
                    #endregion
                    break;
                case 11:
                    #region mes 11
                    if (cb_Estructura.Text == "Total")
                    {
                        q = "SELECT VentasUnidades from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1 and mes=" + mes + " and anio=" + anio;
                    }
                    else
                    {
                        q = "SELECT VentasUnidades from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + sucursalguardar + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1' and mes=" + mes + " and anio=" + anio;
                    }
                    cmd = new MySqlCommand(q, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dgvCed711.Rows[0].Cells[dgvCed7.ColumnCount - 2].Value = reader["VentasUnidades"].ToString();
                    }
                    reader.Close();
                    if (cb_Estructura.Text == "Total")
                    {
                        q = "SELECT Ventasimporte from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1 and mes=" + mes + " and anio=" + anio;
                    }
                    else
                    {
                        q = "SELECT Ventasimporte from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + sucursalguardar + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1' and mes=" + mes + " and anio=" + anio;
                    }
                    cmd = new MySqlCommand(q, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dgvCed711.Rows[0].Cells[dgvCed7.ColumnCount - 1].Value = reader["Ventasimporte"].ToString();
                    }
                    reader.Close();
                    #endregion
                    break;
                case 12:
                    #region mes 12
                    if (cb_Estructura.Text == "Total")
                    {
                        q = "SELECT VentasUnidades from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1 and mes=" + mes + " and anio=" + anio;
                    }
                    else
                    {
                        q = "SELECT VentasUnidades from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + sucursalguardar + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1' and mes=" + mes + " and anio=" + anio;
                    }
                    cmd = new MySqlCommand(q, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dgvCed712.Rows[0].Cells[dgvCed7.ColumnCount - 2].Value = reader["VentasUnidades"].ToString();
                    }
                    reader.Close();
                    if (cb_Estructura.Text == "Total")
                    {
                        q = "SELECT Ventasimporte from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1 and mes=" + mes + " and anio=" + anio;
                    }
                    else
                    {
                        q = "SELECT Ventasimporte from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + sucursalguardar + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1' and mes=" + mes + " and anio=" + anio;
                    }
                    cmd = new MySqlCommand(q, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dgvCed712.Rows[0].Cells[dgvCed7.ColumnCount - 1].Value = reader["Ventasimporte"].ToString();
                    }
                    reader.Close();
                    #endregion
                    break;
            }
        }

        private void m_dgvcellendedit(object sender, DataGridViewCellEventArgs e)
        {
            int dgv = 0;
            #region comprobar cual dgv se modifico
            if (tabcontrol.SelectedIndex == 0 && e.ColumnIndex >= 0 && dgvCed7.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 1;
            }
            if (tabcontrol.SelectedIndex == 1 && e.ColumnIndex >= 0 && dgvCed72.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 2;
            }
            if (tabcontrol.SelectedIndex == 2 && e.ColumnIndex >= 0 && dgvCed73.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 3;
            }
            if (tabcontrol.SelectedIndex == 3 && e.ColumnIndex >= 0 && dgvCed74.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 4;
            }
            if (tabcontrol.SelectedIndex == 4 && e.ColumnIndex >= 0 && dgvCed75.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 5;
            }
            if (tabcontrol.SelectedIndex == 5 && e.ColumnIndex >= 0 && dgvCed76.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 6;
            }
            if (tabcontrol.SelectedIndex == 6 && e.ColumnIndex >= 0 && dgvCed77.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 7;
            }
            if (tabcontrol.SelectedIndex == 7 && e.ColumnIndex >= 0 && dgvCed78.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 8;
            }
            if (tabcontrol.SelectedIndex == 8 && e.ColumnIndex >= 0 && dgvCed79.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 9;
            }
            if (tabcontrol.SelectedIndex == 9 && e.ColumnIndex >= 0 && dgvCed710.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 10;
            }
            if (tabcontrol.SelectedIndex == 10 && e.ColumnIndex >= 0 && dgvCed711.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 11;
            }
            if (tabcontrol.SelectedIndex == 11 && e.ColumnIndex >= 0 && dgvCed712.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 12;
            }
            #endregion
            switch (dgv)
            {
                case 1:
                    #region Comprobar que columna se modifico
                    switch(e.ColumnIndex)
                    {
                        case 0:
                            M_clientesTotales(dgv);
                            break;
                        case 2:
                            M_clientesDiarios(dgv);
                            break;
                        case 6:
                            M_paresCliente(dgv);
                            break;
                    }
                    #endregion
                    break;
                case 2:
                    #region Comprobar que columna se modifico
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            M_clientesTotales(dgv);
                            break;
                        case 2:
                            M_clientesDiarios(dgv);
                            break;
                        case 6:
                            M_paresCliente(dgv);
                            break;
                    }
                    #endregion
                    break;
                case 3:
                    #region Comprobar que columna se modifico
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            M_clientesTotales(dgv);
                            break;
                        case 2:
                            M_clientesDiarios(dgv);
                            break;
                        case 6:
                            M_paresCliente(dgv);
                            break;
                    }
                    #endregion
                    break;
                case 4:
                    #region Comprobar que columna se modifico
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            M_clientesTotales(dgv);
                            break;
                        case 2:
                            M_clientesDiarios(dgv);
                            break;
                        case 6:
                            M_paresCliente(dgv);
                            break;
                    }
                    #endregion
                    break;
                case 5:
                    #region Comprobar que columna se modifico
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            M_clientesTotales(dgv);
                            break;
                        case 2:
                            M_clientesDiarios(dgv);
                            break;
                        case 6:
                            M_paresCliente(dgv);
                            break;
                    }
                    #endregion
                    break;
                case 6:
                    #region Comprobar que columna se modifico
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            M_clientesTotales(dgv);
                            break;
                        case 2:
                            M_clientesDiarios(dgv);
                            break;
                        case 6:
                            M_paresCliente(dgv);
                            break;
                    }
                    #endregion
                    break;
                case 7:
                    #region Comprobar que columna se modifico
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            M_clientesTotales(dgv);
                            break;
                        case 2:
                            M_clientesDiarios(dgv);
                            break;
                        case 6:
                            M_paresCliente(dgv);
                            break;
                    }
                    #endregion
                    break;
                case 8:
                    #region Comprobar que columna se modifico
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            M_clientesTotales(dgv);
                            break;
                        case 2:
                            M_clientesDiarios(dgv);
                            break;
                        case 6:
                            M_paresCliente(dgv);
                            break;
                    }
                    #endregion
                    break;
                case 9:
                    #region Comprobar que columna se modifico
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            M_clientesTotales(dgv);
                            break;
                        case 2:
                            M_clientesDiarios(dgv);
                            break;
                        case 6:
                            M_paresCliente(dgv);
                            break;
                    }
                    #endregion
                    break;
                case 10:
                    #region Comprobar que columna se modifico
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            M_clientesTotales(dgv);
                            break;
                        case 2:
                            M_clientesDiarios(dgv);
                            break;
                        case 6:
                            M_paresCliente(dgv);
                            break;
                    }
                    #endregion
                    break;
                case 11:
                    #region Comprobar que columna se modifico
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            M_clientesTotales(dgv);
                            break;
                        case 2:
                            M_clientesDiarios(dgv);
                            break;
                        case 6:
                            M_paresCliente(dgv);
                            break;
                    }
                    #endregion
                    break;
                case 12:
                    #region Comprobar que columna se modifico
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            M_clientesTotales(dgv);
                            break;
                        case 2:
                            M_clientesDiarios(dgv);
                            break;
                        case 6:
                            M_paresCliente(dgv);
                            break;
                    }
                    #endregion
                    break;
            }
        }
        private void M_clientesTotales(int i)
        {
            double clientesT = 0;
            double clientesP = 0;
            double clientesD = 0;
            double clientesDp = 0;
            double ventasI = 0;
            double ventasIp = 0;
            double paresPc = 0;
            double paresPcp = 0;

            switch(i)
            {
                case 1:
                    #region mes1
                    clientesT = double.Parse(dgvCed7.Rows[0].Cells[0].Value.ToString());
                    if (double.Parse(dgv_captura.Rows[0].Cells[0].Value.ToString())<=1||clientesT<=1)
                    {
                        clientesP = 0;
                    }
				else
                    {
                        clientesP = (1 - (double.Parse(dgv_captura.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    }
                    //////////
				if(clientesT<=1)
                    {
                        clientesD = 0;
                    }
				    else
                    {
                        clientesD = clientesT / 30.4;
                    }
				if(double.Parse(dgv_captura.Rows[0].Cells[1].Value.ToString())<=1||clientesD<=1)
                    {
                        clientesDp = 0;
                    }
				    else
                    {
                        clientesDp = (1 - (double.Parse(dgv_captura.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    }
                    //////////
                if (double.Parse(dgvCed7.Rows[0].Cells[dgvCed7.ColumnCount - 1].Value.ToString()) <= 1 || clientesT<=1)
                {
                    ventasI = 0;
                    ventasIp = 0;
                }
				else
                {
                    ventasI = double.Parse(dgvCed7.Rows[0].Cells[dgvCed7.ColumnCount - 1].Value.ToString()) / clientesT;
                    ventasIp = (1 - (double.Parse(dgv_captura.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) / ventasI)) * 100;
                }
                    //////////
                if (double.Parse(dgvCed7.Rows[0].Cells[dgvCed7.ColumnCount - 2].Value.ToString()) <= 1 || clientesT<=1)
                {
                    paresPc = 0;
                    paresPcp = 0;
                }
				else
                {
                    paresPc = double.Parse(dgvCed7.Rows[0].Cells[dgvCed7.ColumnCount - 2].Value.ToString()) / clientesT;
                    paresPcp = (1 - (double.Parse(dgv_captura.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;
                }
                    
                    dgvCed7.Rows[0].Cells[1].Value=clientesP.ToString("N2");
                    dgvCed7.Rows[0].Cells[2].Value=clientesD.ToString("N2");
                    dgvCed7.Rows[0].Cells[3].Value=clientesDp.ToString("N2");
                    dgvCed7.Rows[0].Cells[4].Value=ventasI.ToString("C2");
                    dgvCed7.Rows[0].Cells[5].Value=ventasIp.ToString("N2");
                    dgvCed7.Rows[0].Cells[6].Value=paresPc.ToString("N2");
                    dgvCed7.Rows[0].Cells[7].Value=paresPcp.ToString("N2");
#endregion
                    break;
                case 2:
                    #region mes1
                    clientesT = double.Parse(dgvCed72.Rows[0].Cells[0].Value.ToString());
                    if (double.Parse(dgv_captura2.Rows[0].Cells[0].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        clientesP = 0;
                    }
                    else
                    {
                        clientesP = (1 - (double.Parse(dgv_captura2.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    }
                    //////////
                    if (clientesT <= 1)
                    {
                        clientesD = 0;
                    }
                    else
                    {
                        clientesD = clientesT / 30.4;
                    }
                    if (double.Parse(dgv_captura2.Rows[0].Cells[1].Value.ToString()) <= 1 || clientesD <= 1)
                    {
                        clientesDp = 0;
                    }
                    else
                    {
                        clientesDp = (1 - (double.Parse(dgv_captura2.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    }
                    //////////
                    if (double.Parse(dgvCed72.Rows[0].Cells[dgvCed72.ColumnCount - 1].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        ventasI = 0;
                        ventasIp = 0;
                    }
                    else
                    {
                        ventasI = double.Parse(dgvCed72.Rows[0].Cells[dgvCed72.ColumnCount - 1].Value.ToString()) / clientesT;
                        ventasIp = (1 - (double.Parse(dgv_captura2.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) / ventasI)) * 100;
                    }
                    //////////
                    if (double.Parse(dgvCed72.Rows[0].Cells[dgvCed72.ColumnCount - 2].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        paresPc = 0;
                        paresPcp = 0;
                    }
                    else
                    {
                        paresPc = double.Parse(dgvCed72.Rows[0].Cells[dgvCed72.ColumnCount - 2].Value.ToString()) / clientesT;
                        paresPcp = (1 - (double.Parse(dgv_captura2.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;
                    }

                    dgvCed72.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed72.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed72.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed72.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed72.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed72.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed72.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 3:
                    #region mes1
                    clientesT = double.Parse(dgvCed73.Rows[0].Cells[0].Value.ToString());
                    if (double.Parse(dgv_captura3.Rows[0].Cells[0].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        clientesP = 0;
                    }
                    else
                    {
                        clientesP = (1 - (double.Parse(dgv_captura3.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    }
                    //////////
                    if (clientesT <= 1)
                    {
                        clientesD = 0;
                    }
                    else
                    {
                        clientesD = clientesT / 30.4;
                    }
                    if (double.Parse(dgv_captura3.Rows[0].Cells[1].Value.ToString()) <= 1 || clientesD <= 1)
                    {
                        clientesDp = 0;
                    }
                    else
                    {
                        clientesDp = (1 - (double.Parse(dgv_captura3.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    }
                    //////////
                    if (double.Parse(dgvCed73.Rows[0].Cells[dgvCed73.ColumnCount - 1].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        ventasI = 0;
                        ventasIp = 0;
                    }
                    else
                    {
                        ventasI = double.Parse(dgvCed73.Rows[0].Cells[dgvCed73.ColumnCount - 1].Value.ToString()) / clientesT;
                        ventasIp = (1 - (double.Parse(dgv_captura3.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) / ventasI)) * 100;
                    }
                    //////////
                    if (double.Parse(dgvCed73.Rows[0].Cells[dgvCed73.ColumnCount - 2].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        paresPc = 0;
                        paresPcp = 0;
                    }
                    else
                    {
                        paresPc = double.Parse(dgvCed73.Rows[0].Cells[dgvCed73.ColumnCount - 2].Value.ToString()) / clientesT;
                        paresPcp = (1 - (double.Parse(dgv_captura3.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;
                    }

                    dgvCed73.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed73.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed73.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed73.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed73.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed73.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed73.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 4:
                    #region mes1
                    clientesT = double.Parse(dgvCed74.Rows[0].Cells[0].Value.ToString());
                    if (double.Parse(dgv_captura4.Rows[0].Cells[0].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        clientesP = 0;
                    }
                    else
                    {
                        clientesP = (1 - (double.Parse(dgv_captura4.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    }
                    //////////
                    if (clientesT <= 1)
                    {
                        clientesD = 0;
                    }
                    else
                    {
                        clientesD = clientesT / 30.4;
                    }
                    if (double.Parse(dgv_captura4.Rows[0].Cells[1].Value.ToString()) <= 1 || clientesD <= 1)
                    {
                        clientesDp = 0;
                    }
                    else
                    {
                        clientesDp = (1 - (double.Parse(dgv_captura4.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    }
                    //////////
                    if (double.Parse(dgvCed74.Rows[0].Cells[dgvCed74.ColumnCount - 1].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        ventasI = 0;
                        ventasIp = 0;
                    }
                    else
                    {
                        ventasI = double.Parse(dgvCed74.Rows[0].Cells[dgvCed74.ColumnCount - 1].Value.ToString()) / clientesT;
                        ventasIp = (1 - (double.Parse(dgv_captura4.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) / ventasI)) * 100;
                    }
                    //////////
                    if (double.Parse(dgvCed74.Rows[0].Cells[dgvCed74.ColumnCount - 2].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        paresPc = 0;
                        paresPcp = 0;
                    }
                    else
                    {
                        paresPc = double.Parse(dgvCed74.Rows[0].Cells[dgvCed74.ColumnCount - 2].Value.ToString()) / clientesT;
                        paresPcp = (1 - (double.Parse(dgv_captura4.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;
                    }

                    dgvCed74.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed74.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed74.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed74.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed74.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed74.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed74.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 5:
                    #region mes1
                    clientesT = double.Parse(dgvCed75.Rows[0].Cells[0].Value.ToString());
                    if (double.Parse(dgv_captura5.Rows[0].Cells[0].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        clientesP = 0;
                    }
                    else
                    {
                        clientesP = (1 - (double.Parse(dgv_captura5.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    }
                    //////////
                    if (clientesT <= 1)
                    {
                        clientesD = 0;
                    }
                    else
                    {
                        clientesD = clientesT / 30.4;
                    }
                    if (double.Parse(dgv_captura5.Rows[0].Cells[1].Value.ToString()) <= 1 || clientesD <= 1)
                    {
                        clientesDp = 0;
                    }
                    else
                    {
                        clientesDp = (1 - (double.Parse(dgv_captura5.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    }
                    //////////
                    if (double.Parse(dgvCed75.Rows[0].Cells[dgvCed75.ColumnCount - 1].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        ventasI = 0;
                        ventasIp = 0;
                    }
                    else
                    {
                        ventasI = double.Parse(dgvCed75.Rows[0].Cells[dgvCed75.ColumnCount - 1].Value.ToString()) / clientesT;
                        ventasIp = (1 - (double.Parse(dgv_captura5.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) / ventasI)) * 100;
                    }
                    //////////
                    if (double.Parse(dgvCed75.Rows[0].Cells[dgvCed75.ColumnCount - 2].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        paresPc = 0;
                        paresPcp = 0;
                    }
                    else
                    {
                        paresPc = double.Parse(dgvCed75.Rows[0].Cells[dgvCed75.ColumnCount - 2].Value.ToString()) / clientesT;
                        paresPcp = (1 - (double.Parse(dgv_captura5.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;
                    }

                    dgvCed75.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed75.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed75.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed75.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed75.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed75.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed75.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 6:
                    #region mes1
                    clientesT = double.Parse(dgvCed76.Rows[0].Cells[0].Value.ToString());
                    if (double.Parse(dgv_captura6.Rows[0].Cells[0].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        clientesP = 0;
                    }
                    else
                    {
                        clientesP = (1 - (double.Parse(dgv_captura6.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    }
                    //////////
                    if (clientesT <= 1)
                    {
                        clientesD = 0;
                    }
                    else
                    {
                        clientesD = clientesT / 30.4;
                    }
                    if (double.Parse(dgv_captura6.Rows[0].Cells[1].Value.ToString()) <= 1 || clientesD <= 1)
                    {
                        clientesDp = 0;
                    }
                    else
                    {
                        clientesDp = (1 - (double.Parse(dgv_captura6.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    }
                    //////////
                    if (double.Parse(dgvCed76.Rows[0].Cells[dgvCed76.ColumnCount - 1].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        ventasI = 0;
                        ventasIp = 0;
                    }
                    else
                    {
                        ventasI = double.Parse(dgvCed76.Rows[0].Cells[dgvCed76.ColumnCount - 1].Value.ToString()) / clientesT;
                        ventasIp = (1 - (double.Parse(dgv_captura6.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) / ventasI)) * 100;
                    }
                    //////////
                    if (double.Parse(dgvCed76.Rows[0].Cells[dgvCed76.ColumnCount - 2].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        paresPc = 0;
                        paresPcp = 0;
                    }
                    else
                    {
                        paresPc = double.Parse(dgvCed76.Rows[0].Cells[dgvCed76.ColumnCount - 2].Value.ToString()) / clientesT;
                        paresPcp = (1 - (double.Parse(dgv_captura6.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;
                    }

                    dgvCed76.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed76.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed76.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed76.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed76.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed76.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed76.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 7:
                    #region mes1
                    clientesT = double.Parse(dgvCed77.Rows[0].Cells[0].Value.ToString());
                    if (double.Parse(dgv_captura7.Rows[0].Cells[0].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        clientesP = 0;
                    }
                    else
                    {
                        clientesP = (1 - (double.Parse(dgv_captura7.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    }
                    //////////
                    if (clientesT <= 1)
                    {
                        clientesD = 0;
                    }
                    else
                    {
                        clientesD = clientesT / 30.4;
                    }
                    if (double.Parse(dgv_captura7.Rows[0].Cells[1].Value.ToString()) <= 1 || clientesD <= 1)
                    {
                        clientesDp = 0;
                    }
                    else
                    {
                        clientesDp = (1 - (double.Parse(dgv_captura7.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    }
                    //////////
                    if (double.Parse(dgvCed77.Rows[0].Cells[dgvCed77.ColumnCount - 1].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        ventasI = 0;
                        ventasIp = 0;
                    }
                    else
                    {
                        ventasI = double.Parse(dgvCed77.Rows[0].Cells[dgvCed77.ColumnCount - 1].Value.ToString()) / clientesT;
                        ventasIp = (1 - (double.Parse(dgv_captura7.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) / ventasI)) * 100;
                    }
                    //////////
                    if (double.Parse(dgvCed77.Rows[0].Cells[dgvCed77.ColumnCount - 2].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        paresPc = 0;
                        paresPcp = 0;
                    }
                    else
                    {
                        paresPc = double.Parse(dgvCed77.Rows[0].Cells[dgvCed77.ColumnCount - 2].Value.ToString()) / clientesT;
                        paresPcp = (1 - (double.Parse(dgv_captura7.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;
                    }

                    dgvCed77.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed77.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed77.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed77.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed77.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed77.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed77.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 8:
                    #region mes1
                    clientesT = double.Parse(dgvCed78.Rows[0].Cells[0].Value.ToString());
                    if (double.Parse(dgv_captura8.Rows[0].Cells[0].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        clientesP = 0;
                    }
                    else
                    {
                        clientesP = (1 - (double.Parse(dgv_captura8.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    }
                    //////////
                    if (clientesT <= 1)
                    {
                        clientesD = 0;
                    }
                    else
                    {
                        clientesD = clientesT / 30.4;
                    }
                    if (double.Parse(dgv_captura8.Rows[0].Cells[1].Value.ToString()) <= 1 || clientesD <= 1)
                    {
                        clientesDp = 0;
                    }
                    else
                    {
                        clientesDp = (1 - (double.Parse(dgv_captura8.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    }
                    //////////
                    if (double.Parse(dgvCed78.Rows[0].Cells[dgvCed78.ColumnCount - 1].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        ventasI = 0;
                        ventasIp = 0;
                    }
                    else
                    {
                        ventasI = double.Parse(dgvCed78.Rows[0].Cells[dgvCed78.ColumnCount - 1].Value.ToString()) / clientesT;
                        ventasIp = (1 - (double.Parse(dgv_captura8.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) / ventasI)) * 100;
                    }
                    //////////
                    if (double.Parse(dgvCed78.Rows[0].Cells[dgvCed78.ColumnCount - 2].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        paresPc = 0;
                        paresPcp = 0;
                    }
                    else
                    {
                        paresPc = double.Parse(dgvCed78.Rows[0].Cells[dgvCed78.ColumnCount - 2].Value.ToString()) / clientesT;
                        paresPcp = (1 - (double.Parse(dgv_captura8.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;
                    }

                    dgvCed78.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed78.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed78.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed78.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed78.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed78.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed78.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 9:
                    #region mes1
                    clientesT = double.Parse(dgvCed79.Rows[0].Cells[0].Value.ToString());
                    if (double.Parse(dgv_captura9.Rows[0].Cells[0].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        clientesP = 0;
                    }
                    else
                    {
                        clientesP = (1 - (double.Parse(dgv_captura9.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    }
                    //////////
                    if (clientesT <= 1)
                    {
                        clientesD = 0;
                    }
                    else
                    {
                        clientesD = clientesT / 30.4;
                    }
                    if (double.Parse(dgv_captura9.Rows[0].Cells[1].Value.ToString()) <= 1 || clientesD <= 1)
                    {
                        clientesDp = 0;
                    }
                    else
                    {
                        clientesDp = (1 - (double.Parse(dgv_captura9.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    }
                    //////////
                    if (double.Parse(dgvCed79.Rows[0].Cells[dgvCed79.ColumnCount - 1].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        ventasI = 0;
                        ventasIp = 0;
                    }
                    else
                    {
                        ventasI = double.Parse(dgvCed79.Rows[0].Cells[dgvCed79.ColumnCount - 1].Value.ToString()) / clientesT;
                        ventasIp = (1 - (double.Parse(dgv_captura9.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) / ventasI)) * 100;
                    }
                    //////////
                    if (double.Parse(dgvCed79.Rows[0].Cells[dgvCed79.ColumnCount - 2].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        paresPc = 0;
                        paresPcp = 0;
                    }
                    else
                    {
                        paresPc = double.Parse(dgvCed79.Rows[0].Cells[dgvCed79.ColumnCount - 2].Value.ToString()) / clientesT;
                        paresPcp = (1 - (double.Parse(dgv_captura9.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;
                    }

                    dgvCed79.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed79.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed79.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed79.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed79.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed79.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed79.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 10:
                    #region mes1
                    clientesT = double.Parse(dgvCed710.Rows[0].Cells[0].Value.ToString());
                    if (double.Parse(dgv_captura10.Rows[0].Cells[0].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        clientesP = 0;
                    }
                    else
                    {
                        clientesP = (1 - (double.Parse(dgv_captura10.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    }
                    //////////
                    if (clientesT <= 1)
                    {
                        clientesD = 0;
                    }
                    else
                    {
                        clientesD = clientesT / 30.4;
                    }
                    if (double.Parse(dgv_captura10.Rows[0].Cells[1].Value.ToString()) <= 1 || clientesD <= 1)
                    {
                        clientesDp = 0;
                    }
                    else
                    {
                        clientesDp = (1 - (double.Parse(dgv_captura10.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    }
                    //////////
                    if (double.Parse(dgvCed710.Rows[0].Cells[dgvCed710.ColumnCount - 1].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        ventasI = 0;
                        ventasIp = 0;
                    }
                    else
                    {
                        ventasI = double.Parse(dgvCed710.Rows[0].Cells[dgvCed710.ColumnCount - 1].Value.ToString()) / clientesT;
                        ventasIp = (1 - (double.Parse(dgv_captura10.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) / ventasI)) * 100;
                    }
                    //////////
                    if (double.Parse(dgvCed710.Rows[0].Cells[dgvCed710.ColumnCount - 2].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        paresPc = 0;
                        paresPcp = 0;
                    }
                    else
                    {
                        paresPc = double.Parse(dgvCed710.Rows[0].Cells[dgvCed710.ColumnCount - 2].Value.ToString()) / clientesT;
                        paresPcp = (1 - (double.Parse(dgv_captura10.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;
                    }

                    dgvCed710.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed710.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed710.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed710.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed710.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed710.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed710.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 11:
                    #region mes1
                    clientesT = double.Parse(dgvCed711.Rows[0].Cells[0].Value.ToString());
                    if (double.Parse(dgv_captura11.Rows[0].Cells[0].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        clientesP = 0;
                    }
                    else
                    {
                        clientesP = (1 - (double.Parse(dgv_captura11.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    }
                    //////////
                    if (clientesT <= 1)
                    {
                        clientesD = 0;
                    }
                    else
                    {
                        clientesD = clientesT / 30.4;
                    }
                    if (double.Parse(dgv_captura11.Rows[0].Cells[1].Value.ToString()) <= 1 || clientesD <= 1)
                    {
                        clientesDp = 0;
                    }
                    else
                    {
                        clientesDp = (1 - (double.Parse(dgv_captura11.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    }
                    //////////
                    if (double.Parse(dgvCed711.Rows[0].Cells[dgvCed711.ColumnCount - 1].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        ventasI = 0;
                        ventasIp = 0;
                    }
                    else
                    {
                        ventasI = double.Parse(dgvCed711.Rows[0].Cells[dgvCed711.ColumnCount - 1].Value.ToString()) / clientesT;
                        ventasIp = (1 - (double.Parse(dgv_captura11.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) / ventasI)) * 100;
                    }
                    //////////
                    if (double.Parse(dgvCed711.Rows[0].Cells[dgvCed711.ColumnCount - 2].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        paresPc = 0;
                        paresPcp = 0;
                    }
                    else
                    {
                        paresPc = double.Parse(dgvCed711.Rows[0].Cells[dgvCed711.ColumnCount - 2].Value.ToString()) / clientesT;
                        paresPcp = (1 - (double.Parse(dgv_captura11.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;
                    }

                    dgvCed711.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed711.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed711.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed711.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed711.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed711.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed711.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 12:
                    #region mes1
                    clientesT = double.Parse(dgvCed712.Rows[0].Cells[0].Value.ToString());
                    if (double.Parse(dgv_captura12.Rows[0].Cells[0].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        clientesP = 0;
                    }
                    else
                    {
                        clientesP = (1 - (double.Parse(dgv_captura12.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    }
                    //////////
                    if (clientesT <= 1)
                    {
                        clientesD = 0;
                    }
                    else
                    {
                        clientesD = clientesT / 30.4;
                    }
                    if (double.Parse(dgv_captura12.Rows[0].Cells[1].Value.ToString()) <= 1 || clientesD <= 1)
                    {
                        clientesDp = 0;
                    }
                    else
                    {
                        clientesDp = (1 - (double.Parse(dgv_captura12.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    }
                    //////////
                    if (double.Parse(dgvCed712.Rows[0].Cells[dgvCed712.ColumnCount - 1].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        ventasI = 0;
                        ventasIp = 0;
                    }
                    else
                    {
                        ventasI = double.Parse(dgvCed712.Rows[0].Cells[dgvCed712.ColumnCount - 1].Value.ToString()) / clientesT;
                        ventasIp = (1 - (double.Parse(dgv_captura12.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) / ventasI)) * 100;
                    }
                    //////////
                    if (double.Parse(dgvCed712.Rows[0].Cells[dgvCed712.ColumnCount - 2].Value.ToString()) <= 1 || clientesT <= 1)
                    {
                        paresPc = 0;
                        paresPcp = 0;
                    }
                    else
                    {
                        paresPc = double.Parse(dgvCed712.Rows[0].Cells[dgvCed712.ColumnCount - 2].Value.ToString()) / clientesT;
                        paresPcp = (1 - (double.Parse(dgv_captura12.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;
                    }

                    dgvCed712.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed712.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed712.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed712.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed712.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed712.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed712.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
            }
        }
        private void M_clientesDiarios(int i)
        {
            double clientesT = 0;
            double clientesP = 0;
            double clientesD = 0;
            double clientesDp = 0;
            double ventasI = 0;
            double ventasIp = 0;
            double paresPc = 0;
            double paresPcp = 0;

            switch (i)
            {
                case 1:
                    #region mes1
                    clientesT = double.Parse(dgvCed7.Rows[0].Cells[2].Value.ToString())*30.4;
                    clientesP = (1-(double.Parse(dgv_captura.Rows[0].Cells[0].Value.ToString())/clientesT))*100;
                    //////////
                    clientesD = double.Parse(dgvCed7.Rows[0].Cells[2].Value.ToString());
                    clientesDp = (1-(double.Parse(dgv_captura.Rows[0].Cells[1].Value.ToString())/clientesD))*100;
                    //////////
                    ventasI = double.Parse(dgvCed7.Rows[0].Cells[dgvCed7.ColumnCount - 1].Value.ToString()) / clientesT;
                    ventasIp = (1-(double.Parse(dgv_captura.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency)/ventasI))*100;
                    //////////
                    paresPc = double.Parse(dgvCed7.Rows[0].Cells[dgvCed7.ColumnCount - 2].Value.ToString()) / clientesT;
                    paresPcp =  (1-(double.Parse(dgv_captura.Rows[0].Cells[3].Value.ToString())/paresPc))*100;

                    dgvCed7.Rows[0].Cells[0].Value=clientesT.ToString("N0");
                    dgvCed7.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed7.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed7.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed7.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed7.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed7.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed7.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 2:
                    #region mes1
                    clientesT = double.Parse(dgvCed72.Rows[0].Cells[2].Value.ToString()) * 30.4;
                    clientesP = (1 - (double.Parse(dgv_captura2.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    //////////
                    clientesD = double.Parse(dgvCed72.Rows[0].Cells[2].Value.ToString());
                    clientesDp = (1 - (double.Parse(dgv_captura2.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    //////////
                    ventasI = double.Parse(dgvCed72.Rows[0].Cells[dgvCed72.ColumnCount - 1].Value.ToString()) / clientesT;
                    ventasIp = (1 - (double.Parse(dgv_captura2.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) / ventasI)) * 100;
                    //////////
                    paresPc = double.Parse(dgvCed72.Rows[0].Cells[dgvCed72.ColumnCount - 2].Value.ToString()) / clientesT;
                    paresPcp = (1 - (double.Parse(dgv_captura2.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;

                    dgvCed72.Rows[0].Cells[0].Value = clientesT.ToString("N0");
                    dgvCed72.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed72.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed72.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed72.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed72.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed72.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed72.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 3:
                    #region mes1
                    clientesT = double.Parse(dgvCed73.Rows[0].Cells[2].Value.ToString()) * 30.4;
                    clientesP = (1 - (double.Parse(dgv_captura3.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    //////////
                    clientesD = double.Parse(dgvCed73.Rows[0].Cells[2].Value.ToString());
                    clientesDp = (1 - (double.Parse(dgv_captura3.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    //////////
                    ventasI = double.Parse(dgvCed73.Rows[0].Cells[dgvCed73.ColumnCount - 1].Value.ToString()) / clientesT;
                    ventasIp = (1 - (double.Parse(dgv_captura3.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) / ventasI)) * 100;
                    //////////
                    paresPc = double.Parse(dgvCed73.Rows[0].Cells[dgvCed73.ColumnCount - 2].Value.ToString()) / clientesT;
                    paresPcp = (1 - (double.Parse(dgv_captura3.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;

                    dgvCed73.Rows[0].Cells[0].Value = clientesT.ToString("N0");
                    dgvCed73.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed73.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed73.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed73.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed73.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed73.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed73.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 4:
                    #region mes1
                    clientesT = double.Parse(dgvCed74.Rows[0].Cells[2].Value.ToString()) * 30.4;
                    clientesP = (1 - (double.Parse(dgv_captura4.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    //////////
                    clientesD = double.Parse(dgvCed74.Rows[0].Cells[2].Value.ToString());
                    clientesDp = (1 - (double.Parse(dgv_captura4.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    //////////
                    ventasI = double.Parse(dgvCed74.Rows[0].Cells[dgvCed74.ColumnCount - 1].Value.ToString()) / clientesT;
                    ventasIp = (1 - (double.Parse(dgv_captura4.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) / ventasI)) * 100;
                    //////////
                    paresPc = double.Parse(dgvCed74.Rows[0].Cells[dgvCed74.ColumnCount - 2].Value.ToString()) / clientesT;
                    paresPcp = (1 - (double.Parse(dgv_captura4.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;

                    dgvCed74.Rows[0].Cells[0].Value = clientesT.ToString("N0");
                    dgvCed74.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed74.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed74.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed74.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed74.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed74.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed74.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 5:
                    #region mes1
                    clientesT = double.Parse(dgvCed75.Rows[0].Cells[2].Value.ToString()) * 30.4;
                    clientesP = (1 - (double.Parse(dgv_captura5.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    //////////
                    clientesD = double.Parse(dgvCed75.Rows[0].Cells[2].Value.ToString());
                    clientesDp = (1 - (double.Parse(dgv_captura5.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    //////////
                    ventasI = double.Parse(dgvCed75.Rows[0].Cells[dgvCed75.ColumnCount - 1].Value.ToString()) / clientesT;
                    ventasIp = (1 - (double.Parse(dgv_captura5.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) / ventasI)) * 100;
                    //////////
                    paresPc = double.Parse(dgvCed75.Rows[0].Cells[dgvCed75.ColumnCount - 2].Value.ToString()) / clientesT;
                    paresPcp = (1 - (double.Parse(dgv_captura5.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;

                    dgvCed75.Rows[0].Cells[0].Value = clientesT.ToString("N0");
                    dgvCed75.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed75.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed75.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed75.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed75.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed75.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed75.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 6:
                    #region mes1
                    clientesT = double.Parse(dgvCed76.Rows[0].Cells[2].Value.ToString()) * 30.4;
                    clientesP = (1 - (double.Parse(dgv_captura6.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    //////////
                    clientesD = double.Parse(dgvCed76.Rows[0].Cells[2].Value.ToString());
                    clientesDp = (1 - (double.Parse(dgv_captura6.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    //////////
                    ventasI = double.Parse(dgvCed76.Rows[0].Cells[dgvCed76.ColumnCount - 1].Value.ToString()) / clientesT;
                    ventasIp = (1 - (double.Parse(dgv_captura6.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) / ventasI)) * 100;
                    //////////
                    paresPc = double.Parse(dgvCed76.Rows[0].Cells[dgvCed76.ColumnCount - 2].Value.ToString()) / clientesT;
                    paresPcp = (1 - (double.Parse(dgv_captura6.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;

                    dgvCed76.Rows[0].Cells[0].Value = clientesT.ToString("N0");
                    dgvCed76.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed76.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed76.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed76.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed76.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed76.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed76.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 7:
                    #region mes1
                    clientesT = double.Parse(dgvCed77.Rows[0].Cells[2].Value.ToString()) * 30.4;
                    clientesP = (1 - (double.Parse(dgv_captura7.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    //////////
                    clientesD = double.Parse(dgvCed77.Rows[0].Cells[2].Value.ToString());
                    clientesDp = (1 - (double.Parse(dgv_captura7.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    //////////
                    ventasI = double.Parse(dgvCed77.Rows[0].Cells[dgvCed77.ColumnCount - 1].Value.ToString()) / clientesT;
                    ventasIp = (1 - (double.Parse(dgv_captura7.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) / ventasI)) * 100;
                    //////////
                    paresPc = double.Parse(dgvCed77.Rows[0].Cells[dgvCed77.ColumnCount - 2].Value.ToString()) / clientesT;
                    paresPcp = (1 - (double.Parse(dgv_captura7.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;

                    dgvCed77.Rows[0].Cells[0].Value = clientesT.ToString("N0");
                    dgvCed77.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed77.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed77.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed77.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed77.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed77.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed77.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 8:
                    #region mes1
                    clientesT = double.Parse(dgvCed78.Rows[0].Cells[2].Value.ToString()) * 30.4;
                    clientesP = (1 - (double.Parse(dgv_captura8.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    //////////
                    clientesD = double.Parse(dgvCed78.Rows[0].Cells[2].Value.ToString());
                    clientesDp = (1 - (double.Parse(dgv_captura8.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    //////////
                    ventasI = double.Parse(dgvCed78.Rows[0].Cells[dgvCed78.ColumnCount - 1].Value.ToString()) / clientesT;
                    ventasIp = (1 - (double.Parse(dgv_captura8.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) / ventasI)) * 100;
                    //////////
                    paresPc = double.Parse(dgvCed78.Rows[0].Cells[dgvCed78.ColumnCount - 2].Value.ToString()) / clientesT;
                    paresPcp = (1 - (double.Parse(dgv_captura8.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;

                    dgvCed78.Rows[0].Cells[0].Value = clientesT.ToString("N0");
                    dgvCed78.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed78.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed78.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed78.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed78.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed78.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed78.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 9:
                    #region mes1
                    clientesT = double.Parse(dgvCed79.Rows[0].Cells[2].Value.ToString()) * 30.4;
                    clientesP = (1 - (double.Parse(dgv_captura9.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    //////////
                    clientesD = double.Parse(dgvCed79.Rows[0].Cells[2].Value.ToString());
                    clientesDp = (1 - (double.Parse(dgv_captura9.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    //////////
                    ventasI = double.Parse(dgvCed79.Rows[0].Cells[dgvCed79.ColumnCount - 1].Value.ToString()) / clientesT;
                    ventasIp = (1 - (double.Parse(dgv_captura9.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) / ventasI)) * 100;
                    //////////
                    paresPc = double.Parse(dgvCed79.Rows[0].Cells[dgvCed79.ColumnCount - 2].Value.ToString()) / clientesT;
                    paresPcp = (1 - (double.Parse(dgv_captura9.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;

                    dgvCed79.Rows[0].Cells[0].Value = clientesT.ToString("N0");
                    dgvCed79.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed79.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed79.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed79.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed79.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed79.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed79.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 10:
                    #region mes1
                    clientesT = double.Parse(dgvCed710.Rows[0].Cells[2].Value.ToString()) * 30.4;
                    clientesP = (1 - (double.Parse(dgv_captura10.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    //////////
                    clientesD = double.Parse(dgvCed710.Rows[0].Cells[2].Value.ToString());
                    clientesDp = (1 - (double.Parse(dgv_captura10.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    //////////
                    ventasI = double.Parse(dgvCed710.Rows[0].Cells[dgvCed710.ColumnCount - 1].Value.ToString()) / clientesT;
                    ventasIp = (1 - (double.Parse(dgv_captura10.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) / ventasI)) * 100;
                    //////////
                    paresPc = double.Parse(dgvCed710.Rows[0].Cells[dgvCed710.ColumnCount - 2].Value.ToString()) / clientesT;
                    paresPcp = (1 - (double.Parse(dgv_captura10.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;

                    dgvCed710.Rows[0].Cells[0].Value = clientesT.ToString("N0");
                    dgvCed710.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed710.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed710.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed710.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed710.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed710.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed710.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 11:
                    #region mes1
                    clientesT = double.Parse(dgvCed711.Rows[0].Cells[2].Value.ToString()) * 30.4;
                    clientesP = (1 - (double.Parse(dgv_captura11.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    //////////
                    clientesD = double.Parse(dgvCed711.Rows[0].Cells[2].Value.ToString());
                    clientesDp = (1 - (double.Parse(dgv_captura11.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    //////////
                    ventasI = double.Parse(dgvCed711.Rows[0].Cells[dgvCed711.ColumnCount - 1].Value.ToString()) / clientesT;
                    ventasIp = (1 - (double.Parse(dgv_captura11.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) / ventasI)) * 100;
                    //////////
                    paresPc = double.Parse(dgvCed711.Rows[0].Cells[dgvCed711.ColumnCount - 2].Value.ToString()) / clientesT;
                    paresPcp = (1 - (double.Parse(dgv_captura11.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;

                    dgvCed711.Rows[0].Cells[0].Value = clientesT.ToString("N0");
                    dgvCed711.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed711.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed711.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed711.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed711.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed711.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed711.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 12:
                    #region mes1
                    clientesT = double.Parse(dgvCed712.Rows[0].Cells[2].Value.ToString()) * 30.4;
                    clientesP = (1 - (double.Parse(dgv_captura12.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    //////////
                    clientesD = double.Parse(dgvCed712.Rows[0].Cells[2].Value.ToString());
                    clientesDp = (1 - (double.Parse(dgv_captura12.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    //////////
                    ventasI = double.Parse(dgvCed712.Rows[0].Cells[dgvCed712.ColumnCount - 1].Value.ToString()) / clientesT;
                    ventasIp = (1 - (double.Parse(dgv_captura12.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency) / ventasI)) * 100;
                    //////////
                    paresPc = double.Parse(dgvCed712.Rows[0].Cells[dgvCed712.ColumnCount - 2].Value.ToString()) / clientesT;
                    paresPcp = (1 - (double.Parse(dgv_captura12.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;

                    dgvCed712.Rows[0].Cells[0].Value = clientesT.ToString("N0");
                    dgvCed712.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed712.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed712.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed712.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed712.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed712.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed712.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
            }
        }
        private void M_paresCliente(int i)
        {
            double clientesT = 0;
            double clientesP = 0;
            double clientesD = 0;
            double clientesDp = 0;
            double ventasI = 0;
            double ventasIp = 0;
            double paresPc = 0;
            double paresPcp = 0;

            switch (i)
            {
                case 1:
                    #region mes1
                    paresPc = double.Parse(dgvCed7.Rows[0].Cells[6].Value.ToString());
                    paresPcp = (1-( double.Parse(dgv_captura.Rows[0].Cells[3].Value.ToString())/paresPc))*100;

                    clientesT = double.Parse(dgvCed7.Rows[0].Cells[dgvCed7.ColumnCount-2].Value.ToString())/paresPc;
                    clientesP = (1-(double.Parse(dgv_captura.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    //////////
                    clientesD = double.Parse(dgvCed7.Rows[0].Cells[2].Value.ToString());
                    clientesDp = (1-(double.Parse(dgv_captura.Rows[0].Cells[1].Value.ToString()) / clientesD)) *100;
                    //////////
                    ventasI = double.Parse(dgvCed7.Rows[0].Cells[dgvCed7.ColumnCount - 1].Value.ToString()) / clientesT;
                    ventasIp = (1-(double.Parse(dgv_captura.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency))/ventasI)* 100;
                    //////////
                    
                    dgvCed7.Rows[0].Cells[0].Value = clientesT.ToString("N0");
                    dgvCed7.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed7.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed7.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed7.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed7.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed7.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed7.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 2:
                    #region mes1
                    paresPc = double.Parse(dgvCed72.Rows[0].Cells[6].Value.ToString());
                    paresPcp = (1 - (double.Parse(dgv_captura2.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;

                    clientesT = double.Parse(dgvCed72.Rows[0].Cells[dgvCed72.ColumnCount - 2].Value.ToString()) / paresPc;
                    clientesP = (1 - (double.Parse(dgv_captura2.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    //////////
                    clientesD = double.Parse(dgvCed72.Rows[0].Cells[2].Value.ToString());
                    clientesDp = (1 - (double.Parse(dgv_captura2.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    //////////
                    ventasI = double.Parse(dgvCed72.Rows[0].Cells[dgvCed72.ColumnCount - 1].Value.ToString()) / clientesT;
                    ventasIp = (1 - (double.Parse(dgv_captura2.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency)) / ventasI) * 100;
                    //////////

                    dgvCed72.Rows[0].Cells[0].Value = clientesT.ToString("N0");
                    dgvCed72.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed72.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed72.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed72.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed72.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed72.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed72.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 3:
                    #region mes1
                    paresPc = double.Parse(dgvCed73.Rows[0].Cells[6].Value.ToString());
                    paresPcp = (1 - (double.Parse(dgv_captura3.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;

                    clientesT = double.Parse(dgvCed73.Rows[0].Cells[dgvCed73.ColumnCount - 2].Value.ToString()) / paresPc;
                    clientesP = (1 - (double.Parse(dgv_captura3.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    //////////
                    clientesD = double.Parse(dgvCed73.Rows[0].Cells[2].Value.ToString());
                    clientesDp = (1 - (double.Parse(dgv_captura3.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    //////////
                    ventasI = double.Parse(dgvCed73.Rows[0].Cells[dgvCed73.ColumnCount - 1].Value.ToString()) / clientesT;
                    ventasIp = (1 - (double.Parse(dgv_captura3.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency)) / ventasI) * 100;
                    //////////

                    dgvCed73.Rows[0].Cells[0].Value = clientesT.ToString("N0");
                    dgvCed73.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed73.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed73.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed73.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed73.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed73.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed73.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 4:
                    #region mes1
                    paresPc = double.Parse(dgvCed74.Rows[0].Cells[6].Value.ToString());
                    paresPcp = (1 - (double.Parse(dgv_captura4.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;

                    clientesT = double.Parse(dgvCed74.Rows[0].Cells[dgvCed74.ColumnCount - 2].Value.ToString()) / paresPc;
                    clientesP = (1 - (double.Parse(dgv_captura4.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    //////////
                    clientesD = double.Parse(dgvCed74.Rows[0].Cells[2].Value.ToString());
                    clientesDp = (1 - (double.Parse(dgv_captura4.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    //////////
                    ventasI = double.Parse(dgvCed74.Rows[0].Cells[dgvCed74.ColumnCount - 1].Value.ToString()) / clientesT;
                    ventasIp = (1 - (double.Parse(dgv_captura4.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency)) / ventasI) * 100;
                    //////////

                    dgvCed74.Rows[0].Cells[0].Value = clientesT.ToString("N0");
                    dgvCed74.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed74.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed74.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed74.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed74.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed74.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed74.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 5:
                    #region mes1
                    paresPc = double.Parse(dgvCed75.Rows[0].Cells[6].Value.ToString());
                    paresPcp = (1 - (double.Parse(dgv_captura5.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;

                    clientesT = double.Parse(dgvCed75.Rows[0].Cells[dgvCed75.ColumnCount - 2].Value.ToString()) / paresPc;
                    clientesP = (1 - (double.Parse(dgv_captura5.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    //////////
                    clientesD = double.Parse(dgvCed75.Rows[0].Cells[2].Value.ToString());
                    clientesDp = (1 - (double.Parse(dgv_captura5.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    //////////
                    ventasI = double.Parse(dgvCed75.Rows[0].Cells[dgvCed75.ColumnCount - 1].Value.ToString()) / clientesT;
                    ventasIp = (1 - (double.Parse(dgv_captura5.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency)) / ventasI) * 100;
                    //////////

                    dgvCed75.Rows[0].Cells[0].Value = clientesT.ToString("N0");
                    dgvCed75.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed75.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed75.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed75.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed75.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed75.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed75.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 6:
                    #region mes1
                    paresPc = double.Parse(dgvCed76.Rows[0].Cells[6].Value.ToString());
                    paresPcp = (1 - (double.Parse(dgv_captura6.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;

                    clientesT = double.Parse(dgvCed76.Rows[0].Cells[dgvCed76.ColumnCount - 2].Value.ToString()) / paresPc;
                    clientesP = (1 - (double.Parse(dgv_captura6.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    //////////
                    clientesD = double.Parse(dgvCed76.Rows[0].Cells[2].Value.ToString());
                    clientesDp = (1 - (double.Parse(dgv_captura6.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    //////////
                    ventasI = double.Parse(dgvCed76.Rows[0].Cells[dgvCed76.ColumnCount - 1].Value.ToString()) / clientesT;
                    ventasIp = (1 - (double.Parse(dgv_captura6.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency)) / ventasI) * 100;
                    //////////

                    dgvCed76.Rows[0].Cells[0].Value = clientesT.ToString("N0");
                    dgvCed76.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed76.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed76.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed76.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed76.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed76.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed76.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 7:
                    #region mes1
                    paresPc = double.Parse(dgvCed77.Rows[0].Cells[6].Value.ToString());
                    paresPcp = (1 - (double.Parse(dgv_captura7.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;

                    clientesT = double.Parse(dgvCed77.Rows[0].Cells[dgvCed77.ColumnCount - 2].Value.ToString()) / paresPc;
                    clientesP = (1 - (double.Parse(dgv_captura7.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    //////////
                    clientesD = double.Parse(dgvCed77.Rows[0].Cells[2].Value.ToString());
                    clientesDp = (1 - (double.Parse(dgv_captura7.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    //////////
                    ventasI = double.Parse(dgvCed77.Rows[0].Cells[dgvCed77.ColumnCount - 1].Value.ToString()) / clientesT;
                    ventasIp = (1 - (double.Parse(dgv_captura7.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency)) / ventasI) * 100;
                    //////////

                    dgvCed77.Rows[0].Cells[0].Value = clientesT.ToString("N0");
                    dgvCed77.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed77.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed77.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed77.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed77.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed77.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed77.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 8:
                    #region mes1
                    paresPc = double.Parse(dgvCed78.Rows[0].Cells[6].Value.ToString());
                    paresPcp = (1 - (double.Parse(dgv_captura8.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;

                    clientesT = double.Parse(dgvCed78.Rows[0].Cells[dgvCed78.ColumnCount - 2].Value.ToString()) / paresPc;
                    clientesP = (1 - (double.Parse(dgv_captura8.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    //////////
                    clientesD = double.Parse(dgvCed78.Rows[0].Cells[2].Value.ToString());
                    clientesDp = (1 - (double.Parse(dgv_captura8.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    //////////
                    ventasI = double.Parse(dgvCed78.Rows[0].Cells[dgvCed78.ColumnCount - 1].Value.ToString()) / clientesT;
                    ventasIp = (1 - (double.Parse(dgv_captura8.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency)) / ventasI) * 100;
                    //////////

                    dgvCed78.Rows[0].Cells[0].Value = clientesT.ToString("N0");
                    dgvCed78.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed78.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed78.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed78.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed78.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed78.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed78.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 9:
                    #region mes1
                    paresPc = double.Parse(dgvCed79.Rows[0].Cells[6].Value.ToString());
                    paresPcp = (1 - (double.Parse(dgv_captura9.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;

                    clientesT = double.Parse(dgvCed79.Rows[0].Cells[dgvCed79.ColumnCount - 2].Value.ToString()) / paresPc;
                    clientesP = (1 - (double.Parse(dgv_captura9.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    //////////
                    clientesD = double.Parse(dgvCed79.Rows[0].Cells[2].Value.ToString());
                    clientesDp = (1 - (double.Parse(dgv_captura9.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    //////////
                    ventasI = double.Parse(dgvCed79.Rows[0].Cells[dgvCed79.ColumnCount - 1].Value.ToString()) / clientesT;
                    ventasIp = (1 - (double.Parse(dgv_captura9.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency)) / ventasI) * 100;
                    //////////

                    dgvCed79.Rows[0].Cells[0].Value = clientesT.ToString("N0");
                    dgvCed79.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed79.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed79.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed79.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed79.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed79.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed79.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 10:
                    #region mes1
                    paresPc = double.Parse(dgvCed710.Rows[0].Cells[6].Value.ToString());
                    paresPcp = (1 - (double.Parse(dgv_captura10.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;

                    clientesT = double.Parse(dgvCed710.Rows[0].Cells[dgvCed710.ColumnCount - 2].Value.ToString()) / paresPc;
                    clientesP = (1 - (double.Parse(dgv_captura10.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    //////////
                    clientesD = double.Parse(dgvCed710.Rows[0].Cells[2].Value.ToString());
                    clientesDp = (1 - (double.Parse(dgv_captura10.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    //////////
                    ventasI = double.Parse(dgvCed710.Rows[0].Cells[dgvCed710.ColumnCount - 1].Value.ToString()) / clientesT;
                    ventasIp = (1 - (double.Parse(dgv_captura10.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency)) / ventasI) * 100;
                    //////////

                    dgvCed710.Rows[0].Cells[0].Value = clientesT.ToString("N0");
                    dgvCed710.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed710.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed710.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed710.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed710.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed710.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed710.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 11:
                    #region mes1
                    paresPc = double.Parse(dgvCed711.Rows[0].Cells[6].Value.ToString());
                    paresPcp = (1 - (double.Parse(dgv_captura11.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;

                    clientesT = double.Parse(dgvCed711.Rows[0].Cells[dgvCed711.ColumnCount - 2].Value.ToString()) / paresPc;
                    clientesP = (1 - (double.Parse(dgv_captura11.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    //////////
                    clientesD = double.Parse(dgvCed711.Rows[0].Cells[2].Value.ToString());
                    clientesDp = (1 - (double.Parse(dgv_captura11.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    //////////
                    ventasI = double.Parse(dgvCed711.Rows[0].Cells[dgvCed711.ColumnCount - 1].Value.ToString()) / clientesT;
                    ventasIp = (1 - (double.Parse(dgv_captura11.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency)) / ventasI) * 100;
                    //////////

                    dgvCed711.Rows[0].Cells[0].Value = clientesT.ToString("N0");
                    dgvCed711.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed711.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed711.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed711.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed711.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed711.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed711.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
                case 12:
                    #region mes1
                    paresPc = double.Parse(dgvCed712.Rows[0].Cells[6].Value.ToString());
                    paresPcp = (1 - (double.Parse(dgv_captura12.Rows[0].Cells[3].Value.ToString()) / paresPc)) * 100;

                    clientesT = double.Parse(dgvCed712.Rows[0].Cells[dgvCed712.ColumnCount - 2].Value.ToString()) / paresPc;
                    clientesP = (1 - (double.Parse(dgv_captura12.Rows[0].Cells[0].Value.ToString()) / clientesT)) * 100;
                    //////////
                    clientesD = double.Parse(dgvCed712.Rows[0].Cells[2].Value.ToString());
                    clientesDp = (1 - (double.Parse(dgv_captura12.Rows[0].Cells[1].Value.ToString()) / clientesD)) * 100;
                    //////////
                    ventasI = double.Parse(dgvCed712.Rows[0].Cells[dgvCed712.ColumnCount - 1].Value.ToString()) / clientesT;
                    ventasIp = (1 - (double.Parse(dgv_captura12.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency)) / ventasI) * 100;
                    //////////

                    dgvCed712.Rows[0].Cells[0].Value = clientesT.ToString("N0");
                    dgvCed712.Rows[0].Cells[1].Value = clientesP.ToString("N2");
                    dgvCed712.Rows[0].Cells[2].Value = clientesD.ToString("N2");
                    dgvCed712.Rows[0].Cells[3].Value = clientesDp.ToString("N2");
                    dgvCed712.Rows[0].Cells[4].Value = ventasI.ToString("C2");
                    dgvCed712.Rows[0].Cells[5].Value = ventasIp.ToString("N2");
                    dgvCed712.Rows[0].Cells[6].Value = paresPc.ToString("N2");
                    dgvCed712.Rows[0].Cells[7].Value = paresPcp.ToString("N2");
                    #endregion
                    break;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            m_limpiarGrids();
            bandera_sucursal = true;
            tabcontrol.SelectedIndex = 0;
            m_ESTRUCTURA(CED7_estruct);
            m_PRECIOPROMEDIO_CEDULA1(Properties.Settings.Default.escenario);
            m_DIASMESESANOS_Refresh(f1.Substring(0, 10), f2.Substring(0, 10));
        }
        public void m_DIASMESESANOS_Refresh(string fecha_inicio, string fecha_final)//////////////////////////////////////////////////
        {
            int fecha_inicio_dia = Convert.ToInt32(fecha_inicio.Substring(0, 2));
            int fecha_inicio_mes = Convert.ToInt32(fecha_inicio.Substring(3, 2));
            int fecha_inicio_ano = Convert.ToInt32(fecha_inicio.Substring(6, 4));

            int fecha_final_dia = Convert.ToInt32(fecha_final.Substring(0, 2));
            int fecha_final_mes = Convert.ToInt32(fecha_final.Substring(3, 2));
            int fecha_final_ano = Convert.ToInt32(fecha_final.Substring(6, 4));
            //int fechaaño = fecha_inicio_ano + 1;
            tabcontrol.SelectedIndex = 0;
            #region añomes
            for (int i = 1; fecha_inicio_ano <= fecha_final_ano; fecha_inicio_ano++)
            {
                if (fecha_inicio_mes <= fecha_final_mes)
                {
                    for (; fecha_inicio_mes <= fecha_final_mes; fecha_inicio_mes++, i++)
                        try
                        {
                            m_TABS(fecha_inicio_mes, fecha_inicio_ano);
                           
                                m_obtenerVentas(i, fecha_inicio_mes, fecha_inicio_ano);
                            
                                m_Calcular(fecha_inicio_mes, fecha_inicio_ano);
                                m_obtenerVentas(i, fecha_inicio_mes, fecha_inicio_ano);
                            tabcontrol.SelectedIndex = tabcontrol.SelectedIndex + 1;
                        }
                        catch (Exception x)
                        {
                            MessageBox.Show("Error con las fechas " + x);
                        }
                }
                if ((fecha_final_mes < fecha_inicio_mes) && (fecha_inicio_ano < fecha_final_ano))
                {
                    for (; fecha_inicio_mes <= 12; fecha_inicio_mes++)
                    {
                        try
                        {
                            m_TABS(fecha_inicio_mes, fecha_inicio_ano);

                            m_obtenerVentas(i, fecha_inicio_mes, fecha_inicio_ano);

                            m_Calcular(fecha_inicio_mes, fecha_inicio_ano);
                            m_obtenerVentas(i, fecha_inicio_mes, fecha_inicio_ano);
                            tabcontrol.SelectedIndex = tabcontrol.SelectedIndex + 1;
                        }
                        catch (Exception x)
                        {
                            MessageBox.Show("Error con las fechas " + x);
                        }
                    }
                    fecha_inicio_mes = 1;
                }

            }
            #endregion

        }
        public void m_limpiarGrids()
        {
		dgv_captura.Rows.Clear();
         dgvCed7.Rows.Clear();
         dgv_captura2.Rows.Clear();
         dgvCed72.Rows.Clear();
         dgv_captura3.Rows.Clear();
         dgvCed73.Rows.Clear();
         dgv_captura4.Rows.Clear();
         dgvCed74.Rows.Clear();
         dgv_captura5.Rows.Clear();
         dgvCed75.Rows.Clear();
         dgv_captura6.Rows.Clear();
         dgvCed76.Rows.Clear();
         dgv_captura7.Rows.Clear();
         dgvCed77.Rows.Clear();
         dgv_captura8.Rows.Clear();
         dgvCed78.Rows.Clear();
         dgv_captura9.Rows.Clear();
         dgvCed79.Rows.Clear();
         dgv_captura10.Rows.Clear();
         dgvCed710.Rows.Clear();
         dgv_captura11.Rows.Clear();
         dgvCed711.Rows.Clear();
         dgv_captura12.Rows.Clear();
         dgvCed712.Rows.Clear();
        }
        private void checaConexion()
        {
            if (Conn.Ping() == false)
            {
                while (Conn.Ping() == false)
                {
                    try
                    {
                        Conn.Close();
                        Conn.Open();
                    }
                    catch (MySqlException exx)
                    {

                    }
                }
            }
        }
    }
}
