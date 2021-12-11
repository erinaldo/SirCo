using MySql.Data.MySqlClient;
using System;
using System.Globalization;
using System.Windows.Forms;
//using nmExcel = Microsoft.Office.Interop.Excel;
using System.Drawing;


namespace business_plan
{
    public partial class Cedula3 : Form
    {
        //int Aseleccion_sucursal = -1;
        //int Aseleccion_division = -1;
        //int Aseleccion_depto = -1;
        //int Aseleccion_familia = -1;
        //int Aseleccion_linea = -1;
        //int Aseleccion_l1 = -1;
        //int Aseleccion_l2 = -1;
        //int Aseleccion_l3 = -1;
        //int Aseleccion_l4 = -1;
        //int Aseleccion_l5 = -1;
        //int Aseleccion_l6 = -1;
        //string Aseleccion_marca = "";
        bool generarcedula3 = false;
        #region variables conexion

        private MySqlCommand cmd;
        private string conexion = "SERVER=" + Properties.Settings.Default.server + "; DATABASE=dwh; user=" + Properties.Settings.Default.usuario + "; PASSWORD=" + Properties.Settings.Default.pass + ";";
        //   private string conexion = "SERVER=localhost; DATABASE=dwh; user=root; PASSWORD= ;";
        private MySqlConnection Conn;
        private string query;
        private MySqlDataReader reader;
        #endregion variables conexion
        #region variables_globales

        private string[] idd = new string[1000];

        DateTime FechaAF = DateTime.Now, FechaAI = DateTime.Now;
        DateTime fech1 = DateTime.Now, fech2 = DateTime.Now;

        double[] ventaT=new double[1000];
        double[] costoT=new double[1000];
        double[] gasto = new double[1000];
        double[] rebaja=new double[1000];


        #endregion variables_globales
        #region variables escenario

        string CED1_fechaI = "";
        string CED1_fechaF = "";
        string idsucursalvarios = "(V.IDSUCURSAL= '01' OR V.IDSUCURSAL='02' OR V.IDSUCURSAL='06' OR V.IDSUCURSAL='08')";
        string iddivisionesvarios = " ";
        string iddeptovarios = " ";
        string idfamiliavarios = " ";
        string idlineavarios = " ";
        string idl1varios = " ";
        string idl2varios = " ";
        string idl3varios = " ";
        string idl4varios = " ";
        string idl5varios = " ";
        string idl6varios = " ";
        
        string[] wherequery = new string[1000];
        string division = "", depto = "", fam = "", linea = "";
        string s;
        bool total = true;
        string[] queryguardar = new string[1000];
        string[] querycargar = new string[1000];
        string solocalzadoDropdown = "";
        string solocalzadowhere = " ";
        #endregion
        #region variables datos form     

        bool bandera_sucursal = false; int seleccion_sucursal = -1;
        bool bandera_division = false; int seleccion_division = -1;
        bool bandera_depto = false; int seleccion_depto = -1;
        bool bandera_familia = false; int seleccion_familia = -1;
        bool bandera_linea = false; int seleccion_linea = -1;
        bool bandera_l1 = false; int seleccion_l1 = -1;
        bool bandera_l2 = false; int seleccion_l2 = -1;
        bool bandera_l3 = false; int seleccion_l3 = -1;
        bool bandera_l4 = false; int seleccion_l4 = -1;
        bool bandera_l5 = false; int seleccion_l5 = -1;
        bool bandera_l6 = false; int seleccion_l6 = -1;
        bool bandera_marca = false; string seleccion_marca = "";
        bool valoresform = false;
        #endregion
        int calculos = 1;
        double ced_sumatoria = 0;
        //double ced_gasto = 0;

        public Cedula3()
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
            #endregion
            tabcontrol.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabcontrol.DrawItem += new DrawItemEventHandler(tabcontrol_DrawItem);
        }

        
        public Cedula3(bool band_sucursal, int selecc_sucursal, bool band_division, int selecc_division,
                        bool band_depto, int selecc_depto, bool band_familia, int selecc_familia,
                        bool band_linea, int selecc_linea, bool band_l1, int selecc_l1,
                        bool band_l2, int selecc_l2, bool band_l3, int selecc_l3,
                        bool band_l4, int selecc_l4, bool band_l5, int selecc_l5,
                        bool band_l6, int selecc_l6, bool band_marca, string selecc_marca)
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
            #endregion
            tabcontrol.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabcontrol.DrawItem += new DrawItemEventHandler(tabcontrol_DrawItem);

            #region valoresform
            valoresform = true;
            bandera_sucursal = band_sucursal; seleccion_sucursal = selecc_sucursal;
            bandera_division = band_division; seleccion_division = selecc_division;
            bandera_depto = band_depto; seleccion_depto = selecc_depto;
            bandera_familia = band_familia; seleccion_familia = selecc_familia;
            bandera_linea = band_linea; seleccion_linea = selecc_linea;
            bandera_l1 = band_l1; seleccion_l1 = selecc_l1;
            bandera_l2 = band_l2; seleccion_l2 = selecc_l2;
            bandera_l3 = band_l3; seleccion_l3 = selecc_l3;
            bandera_l4 = band_l4; seleccion_l4 = selecc_l4;
            bandera_l5 = band_l5; seleccion_l5 = selecc_l5;
            bandera_l6 = band_l6; seleccion_l6 = selecc_l6;
            bandera_marca = band_marca; seleccion_marca = selecc_marca;

            #endregion

        }

        public Cedula3(int selecc_sucursal, int selecc_division, int selecc_depto, int selecc_familia,
                          int selecc_linea, int selecc_l1, int selecc_l2, int selecc_l3, int selecc_l4,
                          int selecc_l5, int selecc_l6, string selecc_marca)
        {
            InitializeComponent();
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
            #region Abrir conexion cipsis

            //ConnCipsis = new MySqlConnection(conexion2);
            //try
            //{
            //    ConnCipsis.Open();
            //}
            //catch (MySqlException ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}

            #endregion Abrir conexion cipsis

            #region valoresform
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
            #endregion
        }

        private void Cedula3_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            m_ESCENARIO(Properties.Settings.Default.escenario);
            #region color
            for (int i = 0; i < 11; i++)
            {
                dataGridView1.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B4FF8F");
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");
                dataGridView2.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B4FF8F");
                dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");
                dataGridView3.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B4FF8F");
                dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");
                dataGridView4.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B4FF8F");
                dataGridView4.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");
                dataGridView5.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B4FF8F");
                dataGridView5.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");
                dataGridView6.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B4FF8F");
                dataGridView6.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");
                dataGridView7.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B4FF8F");
                dataGridView7.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");
                dataGridView8.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B4FF8F");
                dataGridView8.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");
                dataGridView9.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B4FF8F");
                dataGridView9.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");
                dataGridView10.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B4FF8F");
                dataGridView10.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");
                dataGridView11.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B4FF8F");
                dataGridView11.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");
                dataGridView12.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B4FF8F");
                dataGridView12.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");
            }
            #endregion
            this.Refresh();
            toolStripMenuItem1.PerformClick();
            if(generarcedula3==true)
            {
                m_DIASMESESANOS_guardar(CED1_fechaI, CED1_fechaF);
                PanelCedulafinalizada.Visible = true;
                this.Refresh();
                bgw_Pasarcedula.RunWorkerAsync();
            }
        }

        #region botones navegacion
        private void button3_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            Cedula3 cn = new Cedula3();
            this.Hide();
            cn.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
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
            cedula4 c4 = new cedula4();
            this.Hide();
            c4.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
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

        private void button7_Click(object sender, EventArgs e)
        {
            if (bandera_sucursal == true)
            {

                cedula6 c6 = new cedula6(seleccion_sucursal, seleccion_division, seleccion_depto, seleccion_familia, seleccion_linea, seleccion_l1, seleccion_l2, seleccion_l3, seleccion_l4, seleccion_l5, seleccion_l6, seleccion_marca);
                this.Hide();
                c6.ShowDialog();
                this.Close();
            }
            else
            {
                cedula6 c6 = new cedula6();
                this.Hide();
                c6.ShowDialog();
                this.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (bandera_sucursal == true)
            {
                Cedula7 c7 = new Cedula7(bandera_sucursal, seleccion_sucursal, bandera_division, seleccion_division, bandera_depto, seleccion_depto, bandera_familia, seleccion_familia, bandera_linea, seleccion_linea, bandera_l1, seleccion_l1, bandera_l2, seleccion_l2, bandera_l3, seleccion_l3, bandera_l4, seleccion_l4, bandera_l5, seleccion_l5, bandera_l6, seleccion_l6, bandera_marca, seleccion_marca);
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
            Cedula8 c8 = new Cedula8();
            this.Hide();
            c8.ShowDialog();
            this.Close();
        }

        #endregion

       
        private void button1_Click(object sender, EventArgs e)
        {

            tabcontrol.SelectedIndex = 0;
            m_CLEAR_DGV();
            m_ESTRUCTURA();
            //m_DIASMESESANOS(CED1_fechaI, CED1_fechaF);
            //m_TOTALES();
            tabcontrol.SelectedIndex = 0;
        }

        private void m_ESCENARIO(string escenario)
        {
            DateTime a = DateTime.Now, f = DateTime.Now;
            string ESC = "SELECT fechainicialA, fechafinalA,fechainicial,fechafinal,solocalzado FROM escenarios WHERE nombre='" + Properties.Settings.Default.escenario + "' LIMIT 1";
            cmd = new MySqlCommand(ESC, Conn);
            cmd.CommandTimeout = 0;//pos solucion
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                fech1 = a = DateTime.Parse(reader["fechainicial"].ToString());
                fech2 = f = DateTime.Parse(reader["fechafinal"].ToString());
                CED1_fechaI = reader["fechainicial"].ToString();
                CED1_fechaF = reader["fechafinal"].ToString();
                // CED1_estruct = reader["sucursal"].ToString();
                // CED1_estruct2 = reader["estructura"].ToString();
                FechaAI = DateTime.Parse(reader["fechainicialA"].ToString());
                FechaAF = DateTime.Parse(reader["fechafinalA"].ToString());
                label9.Text = "Escenario: " + escenario;
                label10.Text = "Fecha inicial " + a.ToString("yyyy-MM-dd");
                label11.Text = "Fecha final  " + f.ToString("yyyy-MM-dd");
                if (reader["solocalzado"].ToString() == "True")
                {
                    solocalzadoDropdown = " and iddivisiones=1";
                    solocalzadowhere = "and V.iddivisiones=1";
                }
                else
                {
                    solocalzadoDropdown = " ";
                    solocalzadowhere = " ";
                }
            }
            reader.Close();
        }

        public void m_ESTRUCTURA()
        {
            #region cargar estructura
            int i = 1;
            m_CLEAR_DGV();//dataGridView1.Rows.Clear();// 
            m_ADD_ROWS_DGV();
            m_PASS_VALUES_DGV("Total", 0);
            dataGridView1.Rows[0].Cells[0].Value = "Total";
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                m_REFRESH_DGV();//dataGridView1.Refresh();  
                m_ADD_ROWS_DGV(); //dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = reader["descrip"].ToString();
                m_PASS_VALUES_DGV(dataGridView1.Rows[i].Cells[0].Value.ToString(), i);//pasa el valor a otros dgvs
                i++;
            }
            reader.Close();
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

        //************************************************************REGION PASAR VALORES DGV1 A LAS DEMAS 
        public void m_CLEAR_DGV()
        {
            dataGridView1.Rows.Clear(); dataGridView2.Rows.Clear(); dataGridView3.Rows.Clear(); dataGridView4.Rows.Clear();
            dataGridView5.Rows.Clear(); dataGridView6.Rows.Clear(); dataGridView7.Rows.Clear(); dataGridView8.Rows.Clear();
            dataGridView9.Rows.Clear(); dataGridView10.Rows.Clear(); dataGridView11.Rows.Clear(); dataGridView12.Rows.Clear();
        }
        public void m_REFRESH_DGV()
        {
            dataGridView1.Refresh(); dataGridView2.Refresh(); dataGridView3.Refresh(); dataGridView4.Refresh();
            dataGridView5.Refresh(); dataGridView6.Refresh(); dataGridView7.Refresh(); dataGridView8.Refresh();
            dataGridView9.Refresh(); dataGridView10.Refresh(); dataGridView11.Refresh(); dataGridView12.Refresh();

        }
        public void m_ADD_ROWS_DGV()
        {
            dataGridView1.Rows.Add(); dataGridView2.Rows.Add(); dataGridView3.Rows.Add(); dataGridView4.Rows.Add();
            dataGridView5.Rows.Add(); dataGridView6.Rows.Add(); dataGridView7.Rows.Add(); dataGridView8.Rows.Add();
            dataGridView9.Rows.Add(); dataGridView10.Rows.Add(); dataGridView11.Rows.Add(); dataGridView12.Rows.Add();
        }
        public void m_PASS_VALUES_DGV(string val, int renglon)
        {
            dataGridView2.Rows[renglon].Cells[0].Value = val; dataGridView3.Rows[renglon].Cells[0].Value = val;
            dataGridView4.Rows[renglon].Cells[0].Value = val; dataGridView5.Rows[renglon].Cells[0].Value = val;
            dataGridView6.Rows[renglon].Cells[0].Value = val; dataGridView7.Rows[renglon].Cells[0].Value = val;
            dataGridView8.Rows[renglon].Cells[0].Value = val; dataGridView9.Rows[renglon].Cells[0].Value = val;
            dataGridView10.Rows[renglon].Cells[0].Value = val; dataGridView11.Rows[renglon].Cells[0].Value = val;
            dataGridView12.Rows[renglon].Cells[0].Value = val;
        }
        ///******************************************************************************

        public void m_CALCULOS(int x)
        {
            #region antiguo
            //string valorNaN = "";
            //double C_MARGENINICIAL_POR = 0, C_MARGENINICIAL = 0, C_REBAJAS = 0, C_REBAJAS_POR = 0, C_MARGENFINAL_POR = 0, C_MARGENFINAL = 0,
            //C_GASTO_POR = 0, C_GASTO = 0, C_DPP_POR = 0, C_DPP = 0;
            ////*************************************************
            //C_MARGENINICIAL_POR = (1 - (costo / venta)) * 100;
            //valorNaN = Convert.ToString(C_MARGENINICIAL_POR);
            //if (valorNaN == "NaN" || valorNaN == "Infinito" || valorNaN == "-Infinito" || valorNaN == "NeuN") { C_MARGENINICIAL_POR = 0; }

            //C_MARGENINICIAL = (C_MARGENINICIAL_POR / 100) * venta;
            //valorNaN = Convert.ToString(C_MARGENINICIAL);
            //if (valorNaN == "NaN" || valorNaN == "Infinito" || valorNaN == "-Infinito" || valorNaN == "NeuN") { C_MARGENINICIAL = 0; }
            ////************************************************
            //C_REBAJAS = rebajas;
            //valorNaN = Convert.ToString(C_REBAJAS);
            //if (valorNaN == "NaN" || valorNaN == "Infinito" || valorNaN == "-Infinito" || valorNaN == "NeuN") { C_REBAJAS = 0; }

            //C_REBAJAS_POR = (rebajas / venta) * 100;
            //valorNaN = Convert.ToString(C_REBAJAS_POR);
            //if (valorNaN == "NaN" || valorNaN == "Infinito" || valorNaN == "-Infinito" || valorNaN == "NeuN") { C_REBAJAS_POR = 0; }
            ////************************************************
            //C_MARGENFINAL_POR = (1 - (costo / (venta - rebajas))) * 100;
            //valorNaN = Convert.ToString(C_MARGENFINAL_POR);
            //if (valorNaN == "NaN" || valorNaN == "Infinito" || valorNaN == "-Infinito" || valorNaN == "NeuN") { C_MARGENFINAL_POR = 0; }

            //C_MARGENFINAL = (C_MARGENFINAL_POR / 100) * venta;
            //valorNaN = Convert.ToString(C_MARGENFINAL);
            //if (valorNaN == "NaN" || valorNaN == "Infinito" || valorNaN == "-Infinito" || valorNaN == "NeuN") { C_MARGENFINAL = 0; }
            ////************************************************
            //C_GASTO_POR = (venta / ced_sumatoria) * 100;
            //valorNaN = Convert.ToString(C_GASTO_POR);
            //if (valorNaN == "NaN" || valorNaN == "Infinito" || valorNaN == "-Infinito" || valorNaN == "NeuN") { C_GASTO_POR = 0; }

            ////C_GASTO = (C_GASTO_POR / 100) * ced_gasto;
            ////C_GASTO = gasto[x] * C_GASTO_POR;
            //C_GASTO = (C_GASTO_POR / 100) * ced_gasto;
            //valorNaN = Convert.ToString(C_GASTO);
            //if (valorNaN == "NaN" || valorNaN == "Infinito" || valorNaN == "-Infinito" || valorNaN == "NeuN") { C_GASTO = 0; }
            ////************************************************
            //C_DPP_POR = (1 - (costo / (venta - rebajas))) * 100;
            //valorNaN = Convert.ToString(C_DPP_POR);
            //if (valorNaN == "NaN" || valorNaN == "Infinito" || valorNaN == "-Infinito" || valorNaN == "NeuN") { C_DPP_POR = 0; }

            //C_DPP = (C_DPP_POR / 100) * venta;
            //valorNaN = Convert.ToString(C_DPP);
            //if (valorNaN == "NaN" || valorNaN == "Infinito" || valorNaN == "-Infinito" || valorNaN == "NeuN") { C_DPP = 0; }
            ////************************************************
#endregion
            double margenInicialP = 0;
            double margenInicialI = 0;
            double margenFinalP = 0;
            double margenFinalI = 0;
            double dppP = 0;
            double dppI = 0;
            double rebajasP = 0;
            double rebajasI = 0;
            double gastoP = 0;
            double gastoI = 0;
            
            ///////////////// margen inicial porcentaje
            //if (costoT[0] != 0 && ventaT[0] != 0)
            //{
            //    margenInicialI = ventaT[0]*(1 - (costoT[0] / ventaT[0]));
            //    margenInicialP=(1-(costoT[0]/ventaT[0]))*100;
            //}
            //else
            //{
            //    margenInicialP = 0;
            //    margenInicialI = 0;
            //}
            ///////////////// margen final porcentaje
            //if (costoT[0] != 0 && ventaT[0] != 0)
            //{
            //    margenFinalI = ventaT[0]*(1 - (costoT[0] / (ventaT[0] - rebaja[0])));
            //    margenFinalP = (1 - (costoT[0] / (ventaT[0] - rebaja[0]))) * 100;
            //}
            //else
            //{
            //    margenFinalP = 0;
            //    margenFinalI = 0;
            //}
            //////////////// dpp importe
            //if (costoT[0] != 0 && ventaT[0] != 0)
            //{
            //    dppI = ventaT[0]*(1-(costoT[0]+gasto[0])/(ventaT[0]-rebaja[0]));
            //    dppP = (1 - (costoT[0] + gasto[0]) / (ventaT[0] - rebaja[0]))*100;
            //}
            //else
            //{
            //    dppI = 0;
            //    dppP = 0;
            //}
            ////////////// rebaja importe
            if (costoT[0] != 0 && ventaT[0] != 0)
            {
                rebajasI = ventaT[0] * (rebaja[0] / ventaT[0]);
                rebajasP = (rebaja[0] / ventaT[0]) * 100;
            }
            else
            {
                rebajasI = 0;
                rebajasP = 0;
            }
            m_LLENAR_DGV(x, 0, 3, rebajasP.ToString("N2"));
            m_LLENAR_DGV(x, 0, 4, rebajasI.ToString("N2"));

            //////////// gasto porcentaje
            //if (gasto[0]!=0&&ventaT[0]!=0)
            //{
            //    gastoI = gasto[0];
            //    gastoP = (gasto[0] / ventaT[0]) * 100;
            //}
            //else
            //{
            //    gastoP = 0;
            //    gastoI = 0;
            //}
            //m_DATAGRIDVIEW(x,margenInicialI,margenInicialP,margenFinalI,margenFinalP,dppI,dppP,rebajasI,rebajasP,gastoI,gastoP);
        }

        public void m_DATAGRIDVIEW(int dgrid, double margeniI,double margeniP,double margenfI,double margenfP,double dppI,double dppP,double rebajaI,double rebajaP,double gastoI,double gastoP)
        {
            switch (dgrid)
            {
                case 1:
                    #region dgv1
                    dataGridView1.Rows[0].Cells[1].Value = margeniP.ToString("n0");
                    dataGridView1.Rows[0].Cells[2].Value = margeniI.ToString("C2");
                    dataGridView1.Rows[0].Cells[3].Value = rebajaP.ToString("N2");
                    dataGridView1.Rows[0].Cells[4].Value = rebajaI.ToString("C2");
                    dataGridView1.Rows[0].Cells[5].Value = margenfP.ToString("N2");
                    dataGridView1.Rows[0].Cells[6].Value = margenfI.ToString("C2");
                    dataGridView1.Rows[0].Cells[7].Value = gastoP.ToString("N2");
                    dataGridView1.Rows[0].Cells[8].Value = gastoI.ToString("C2");
                    dataGridView1.Rows[0].Cells[9].Value = dppP.ToString("N2");
                    dataGridView1.Rows[0].Cells[10].Value = dppI.ToString("C2");
                    #endregion
                    break;
                case 2:
                    #region dgv1
                    dataGridView2.Rows[0].Cells[1].Value = margeniP.ToString("n0");
                    dataGridView2.Rows[0].Cells[2].Value = margeniI.ToString("C2");
                    dataGridView2.Rows[0].Cells[3].Value = rebajaP.ToString("N2");
                    dataGridView2.Rows[0].Cells[4].Value = rebajaI.ToString("C2");
                    dataGridView2.Rows[0].Cells[5].Value = margenfP.ToString("N2");
                    dataGridView2.Rows[0].Cells[6].Value = margenfI.ToString("C2");
                    dataGridView2.Rows[0].Cells[7].Value = gastoP.ToString("N2");
                    dataGridView2.Rows[0].Cells[8].Value = gastoI.ToString("C2");
                    dataGridView2.Rows[0].Cells[9].Value = dppP.ToString("N2");
                    dataGridView2.Rows[0].Cells[10].Value = dppI.ToString("C2");
                    #endregion
                    break;
                case 3:
                    #region dgv1
                    dataGridView3.Rows[0].Cells[1].Value = margeniP.ToString("n0");
                    dataGridView3.Rows[0].Cells[2].Value = margeniI.ToString("C2");
                    dataGridView3.Rows[0].Cells[3].Value = rebajaP.ToString("N2");
                    dataGridView3.Rows[0].Cells[4].Value = rebajaI.ToString("C2");
                    dataGridView3.Rows[0].Cells[5].Value = margenfP.ToString("N2");
                    dataGridView3.Rows[0].Cells[6].Value = margenfI.ToString("C2");
                    dataGridView3.Rows[0].Cells[7].Value = gastoP.ToString("N2");
                    dataGridView3.Rows[0].Cells[8].Value = gastoI.ToString("C2");
                    dataGridView3.Rows[0].Cells[9].Value = dppP.ToString("N2");
                    dataGridView3.Rows[0].Cells[10].Value = dppI.ToString("C2");
                    #endregion
                    break;
                case 4:
                    #region dgv1
                    dataGridView4.Rows[0].Cells[1].Value = margeniP.ToString("n0");
                    dataGridView4.Rows[0].Cells[2].Value = margeniI.ToString("C2");
                    dataGridView4.Rows[0].Cells[3].Value = rebajaP.ToString("N2");
                    dataGridView4.Rows[0].Cells[4].Value = rebajaI.ToString("C2");
                    dataGridView4.Rows[0].Cells[5].Value = margenfP.ToString("N2");
                    dataGridView4.Rows[0].Cells[6].Value = margenfI.ToString("C2");
                    dataGridView4.Rows[0].Cells[7].Value = gastoP.ToString("N2");
                    dataGridView4.Rows[0].Cells[8].Value = gastoI.ToString("C2");
                    dataGridView4.Rows[0].Cells[9].Value = dppP.ToString("N2");
                    dataGridView4.Rows[0].Cells[10].Value = dppI.ToString("C2");
                    #endregion
                    break;
                case 5:
                    #region dgv1
                    dataGridView5.Rows[0].Cells[1].Value = margeniP.ToString("n0");
                    dataGridView5.Rows[0].Cells[2].Value = margeniI.ToString("C2");
                    dataGridView5.Rows[0].Cells[3].Value = rebajaP.ToString("N2");
                    dataGridView5.Rows[0].Cells[4].Value = rebajaI.ToString("C2");
                    dataGridView5.Rows[0].Cells[5].Value = margenfP.ToString("N2");
                    dataGridView5.Rows[0].Cells[6].Value = margenfI.ToString("C2");
                    dataGridView5.Rows[0].Cells[7].Value = gastoP.ToString("N2");
                    dataGridView5.Rows[0].Cells[8].Value = gastoI.ToString("C2");
                    dataGridView5.Rows[0].Cells[9].Value = dppP.ToString("N2");
                    dataGridView5.Rows[0].Cells[10].Value = dppI.ToString("C2");
                    #endregion
                    break;
                case 6:
                    #region dgv1
                    dataGridView6.Rows[0].Cells[1].Value = margeniP.ToString("n0");
                    dataGridView6.Rows[0].Cells[2].Value = margeniI.ToString("C2");
                    dataGridView6.Rows[0].Cells[3].Value = rebajaP.ToString("N2");
                    dataGridView6.Rows[0].Cells[4].Value = rebajaI.ToString("C2");
                    dataGridView6.Rows[0].Cells[5].Value = margenfP.ToString("N2");
                    dataGridView6.Rows[0].Cells[6].Value = margenfI.ToString("C2");
                    dataGridView6.Rows[0].Cells[7].Value = gastoP.ToString("N2");
                    dataGridView6.Rows[0].Cells[8].Value = gastoI.ToString("C2");
                    dataGridView6.Rows[0].Cells[9].Value = dppP.ToString("N2");
                    dataGridView6.Rows[0].Cells[10].Value = dppI.ToString("C2");
                    #endregion
                    break;
                case 7:
                    #region dgv1
                    dataGridView7.Rows[0].Cells[1].Value = margeniP.ToString("n0");
                    dataGridView7.Rows[0].Cells[2].Value = margeniI.ToString("C2");
                    dataGridView7.Rows[0].Cells[3].Value = rebajaP.ToString("N2");
                    dataGridView7.Rows[0].Cells[4].Value = rebajaI.ToString("C2");
                    dataGridView7.Rows[0].Cells[5].Value = margenfP.ToString("N2");
                    dataGridView7.Rows[0].Cells[6].Value = margenfI.ToString("C2");
                    dataGridView7.Rows[0].Cells[7].Value = gastoP.ToString("N2");
                    dataGridView7.Rows[0].Cells[8].Value = gastoI.ToString("C2");
                    dataGridView7.Rows[0].Cells[9].Value = dppP.ToString("N2");
                    dataGridView7.Rows[0].Cells[10].Value = dppI.ToString("C2");
                    #endregion
                    break;
                case 8:
                    #region dgv1
                    dataGridView8.Rows[0].Cells[1].Value = margeniP.ToString("n0");
                    dataGridView8.Rows[0].Cells[2].Value = margeniI.ToString("C2");
                    dataGridView8.Rows[0].Cells[3].Value = rebajaP.ToString("N2");
                    dataGridView8.Rows[0].Cells[4].Value = rebajaI.ToString("C2");
                    dataGridView8.Rows[0].Cells[5].Value = margenfP.ToString("N2");
                    dataGridView8.Rows[0].Cells[6].Value = margenfI.ToString("C2");
                    dataGridView8.Rows[0].Cells[7].Value = gastoP.ToString("N2");
                    dataGridView8.Rows[0].Cells[8].Value = gastoI.ToString("C2");
                    dataGridView8.Rows[0].Cells[9].Value = dppP.ToString("N2");
                    dataGridView8.Rows[0].Cells[10].Value = dppI.ToString("C2");
                    #endregion
                    break;
                case 9:
                    #region dgv1
                    dataGridView9.Rows[0].Cells[1].Value = margeniP.ToString("n0");
                    dataGridView9.Rows[0].Cells[2].Value = margeniI.ToString("C2");
                    dataGridView9.Rows[0].Cells[3].Value = rebajaP.ToString("N2");
                    dataGridView9.Rows[0].Cells[4].Value = rebajaI.ToString("C2");
                    dataGridView9.Rows[0].Cells[5].Value = margenfP.ToString("N2");
                    dataGridView9.Rows[0].Cells[6].Value = margenfI.ToString("C2");
                    dataGridView9.Rows[0].Cells[7].Value = gastoP.ToString("N2");
                    dataGridView9.Rows[0].Cells[8].Value = gastoI.ToString("C2");
                    dataGridView9.Rows[0].Cells[9].Value = dppP.ToString("N2");
                    dataGridView9.Rows[0].Cells[10].Value = dppI.ToString("C2");
                    #endregion
                    break;
                case 10:
                    #region dgv1
                    dataGridView10.Rows[0].Cells[1].Value = margeniP.ToString("n0");
                    dataGridView10.Rows[0].Cells[2].Value = margeniI.ToString("C2");
                    dataGridView10.Rows[0].Cells[3].Value = rebajaP.ToString("N2");
                    dataGridView10.Rows[0].Cells[4].Value = rebajaI.ToString("C2");
                    dataGridView10.Rows[0].Cells[5].Value = margenfP.ToString("N2");
                    dataGridView10.Rows[0].Cells[6].Value = margenfI.ToString("C2");
                    dataGridView10.Rows[0].Cells[7].Value = gastoP.ToString("N2");
                    dataGridView10.Rows[0].Cells[8].Value = gastoI.ToString("C2");
                    dataGridView10.Rows[0].Cells[9].Value = dppP.ToString("N2");
                    dataGridView10.Rows[0].Cells[10].Value = dppI.ToString("C2");
                    #endregion
                    break;
                case 11:
                    #region dgv1
                    dataGridView11.Rows[0].Cells[1].Value = margeniP.ToString("n0");
                    dataGridView11.Rows[0].Cells[2].Value = margeniI.ToString("C2");
                    dataGridView11.Rows[0].Cells[3].Value = rebajaP.ToString("N2");
                    dataGridView11.Rows[0].Cells[4].Value = rebajaI.ToString("C2");
                    dataGridView11.Rows[0].Cells[5].Value = margenfP.ToString("N2");
                    dataGridView11.Rows[0].Cells[6].Value = margenfI.ToString("C2");
                    dataGridView11.Rows[0].Cells[7].Value = gastoP.ToString("N2");
                    dataGridView11.Rows[0].Cells[8].Value = gastoI.ToString("C2");
                    dataGridView11.Rows[0].Cells[9].Value = dppP.ToString("N2");
                    dataGridView11.Rows[0].Cells[10].Value = dppI.ToString("C2");
                    #endregion
                    break;
                case 12:
                    #region dgv1
                    dataGridView12.Rows[0].Cells[1].Value = margeniP.ToString("n0");
                    dataGridView12.Rows[0].Cells[2].Value = margeniI.ToString("C2");
                    dataGridView12.Rows[0].Cells[3].Value = rebajaP.ToString("N2");
                    dataGridView12.Rows[0].Cells[4].Value = rebajaI.ToString("C2");
                    dataGridView12.Rows[0].Cells[5].Value = margenfP.ToString("N2");
                    dataGridView12.Rows[0].Cells[6].Value = margenfI.ToString("C2");
                    dataGridView12.Rows[0].Cells[7].Value = gastoP.ToString("N2");
                    dataGridView12.Rows[0].Cells[8].Value = gastoI.ToString("C2");
                    dataGridView12.Rows[0].Cells[9].Value = dppP.ToString("N2");
                    dataGridView12.Rows[0].Cells[10].Value = dppI.ToString("C2");
                    #endregion
                    break;
            }

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

        private void button10_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Desea borrar valores cedula actual y crear nueva", "Advertencia! ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                Cedula3 cn = new Cedula3();
                cn.Show(); this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            m_DIASMESESANOS_guardar(CED1_fechaI, CED1_fechaF);
            MessageBox.Show("Guardado");
        }
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
            int i = 1; calculos = 1;
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
            for (int x = 0; x <= dataGridView1.Rows.Count - 1; x++)
            {
                string s = "SELECT * FROM cedula4 where Escenario='" + Properties.Settings.Default.escenario + "' and anio=" + año + " and mes=" + mes;
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
                    insertar(año, mes, i, 0);
                }
                else
                {
                    update(año, mes, i, 0);
                }
            }
            return true;
        }
        public void insertar(int año, int mes, int grid, int renglon)
        {
            double c1, c2, c3, c4, c5, c6, c7, c8, c9, c10;
            checaConexion();
            switch (grid)
            {
                case 1:
                    #region insertar cedula1
                    c1 = double.Parse(dataGridView1.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dataGridView1.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dataGridView1.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dataGridView1.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dataGridView1.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dataGridView1.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dataGridView1.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dataGridView1.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dataGridView1.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dataGridView1.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    string s = "insert into cedula4(Escenario,margeniniPor,margeniniImp,rebajasPor,rebajasImp,margenfinPor,margenfinImp,utilidadPor,utilidadImp,dppPor,dppImp,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + ", " + mes.ToString() + "," + año.ToString() + ",-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,'-1')";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 2:
                    #region insertar cedula1
                    c1 = double.Parse(dataGridView2.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dataGridView2.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dataGridView2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dataGridView2.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dataGridView2.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dataGridView2.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dataGridView2.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dataGridView2.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dataGridView2.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dataGridView2.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula4(Escenario,margeniniPor,margeniniImp,rebajasPor,rebajasImp,margenfinPor,margenfinImp,utilidadPor,utilidadImp,dppPor,dppImp,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + ", " + mes.ToString() + "," + año.ToString() + ",-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,'-1')";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 3:
                    #region insertar cedula1
                    c1 = double.Parse(dataGridView3.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dataGridView3.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dataGridView3.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dataGridView3.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dataGridView3.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dataGridView3.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dataGridView3.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dataGridView3.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dataGridView3.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dataGridView3.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula4(Escenario,margeniniPor,margeniniImp,rebajasPor,rebajasImp,margenfinPor,margenfinImp,utilidadPor,utilidadImp,dppPor,dppImp,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + ", " + mes.ToString() + "," + año.ToString() + ",-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,'-1')";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 4:
                    #region insertar cedula1
                    c1 = double.Parse(dataGridView4.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dataGridView4.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dataGridView4.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dataGridView4.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dataGridView4.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dataGridView4.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dataGridView4.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dataGridView4.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dataGridView4.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dataGridView4.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula4(Escenario,margeniniPor,margeniniImp,rebajasPor,rebajasImp,margenfinPor,margenfinImp,utilidadPor,utilidadImp,dppPor,dppImp,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + ", " + mes.ToString() + "," + año.ToString() + ",-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,'-1')";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 5:
                    #region insertar cedula1
                    c1 = double.Parse(dataGridView5.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dataGridView5.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dataGridView5.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dataGridView5.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dataGridView5.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dataGridView5.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dataGridView5.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dataGridView5.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dataGridView5.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dataGridView5.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula4(Escenario,margeniniPor,margeniniImp,rebajasPor,rebajasImp,margenfinPor,margenfinImp,utilidadPor,utilidadImp,dppPor,dppImp,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + ", " + mes.ToString() + "," + año.ToString() + ",-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,'-1')";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 6:
                    #region insertar cedula1
                    c1 = double.Parse(dataGridView6.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dataGridView6.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dataGridView6.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dataGridView6.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dataGridView6.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dataGridView6.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dataGridView6.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dataGridView6.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dataGridView6.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dataGridView6.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula4(Escenario,margeniniPor,margeniniImp,rebajasPor,rebajasImp,margenfinPor,margenfinImp,utilidadPor,utilidadImp,dppPor,dppImp,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + ", " + mes.ToString() + "," + año.ToString() + ",-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,'-1')";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 7:
                    #region insertar cedula1
                    c1 = double.Parse(dataGridView7.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dataGridView7.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dataGridView7.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dataGridView7.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dataGridView7.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dataGridView7.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dataGridView7.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dataGridView7.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dataGridView7.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dataGridView7.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula4(Escenario,margeniniPor,margeniniImp,rebajasPor,rebajasImp,margenfinPor,margenfinImp,utilidadPor,utilidadImp,dppPor,dppImp,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + ", " + mes.ToString() + "," + año.ToString() + ",-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,'-1')";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 8:
                    #region insertar cedula1
                    c1 = double.Parse(dataGridView8.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dataGridView8.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dataGridView8.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dataGridView8.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dataGridView8.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dataGridView8.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dataGridView8.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dataGridView8.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dataGridView8.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dataGridView8.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula4(Escenario,margeniniPor,margeniniImp,rebajasPor,rebajasImp,margenfinPor,margenfinImp,utilidadPor,utilidadImp,dppPor,dppImp,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + ", " + mes.ToString() + "," + año.ToString() + ",-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,'-1')";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 9:
                    #region insertar cedula1
                    c1 = double.Parse(dataGridView9.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dataGridView9.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dataGridView9.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dataGridView9.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dataGridView9.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dataGridView9.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dataGridView9.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dataGridView9.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dataGridView9.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dataGridView9.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula4(Escenario,margeniniPor,margeniniImp,rebajasPor,rebajasImp,margenfinPor,margenfinImp,utilidadPor,utilidadImp,dppPor,dppImp,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + ", " + mes.ToString() + "," + año.ToString() + ",-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,'-1')";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 10:
                    #region insertar cedula1
                    c1 = double.Parse(dataGridView10.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dataGridView10.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dataGridView10.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dataGridView10.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dataGridView10.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dataGridView10.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dataGridView10.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dataGridView10.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dataGridView10.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dataGridView10.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula4(Escenario,margeniniPor,margeniniImp,rebajasPor,rebajasImp,margenfinPor,margenfinImp,utilidadPor,utilidadImp,dppPor,dppImp,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + ", " + mes.ToString() + "," + año.ToString() + ",-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,'-1')";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 11:
                    #region insertar cedula1
                    c1 = double.Parse(dataGridView11.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dataGridView11.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dataGridView11.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dataGridView11.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dataGridView11.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dataGridView11.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dataGridView11.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dataGridView11.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dataGridView11.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dataGridView11.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula4(Escenario,margeniniPor,margeniniImp,rebajasPor,rebajasImp,margenfinPor,margenfinImp,utilidadPor,utilidadImp,dppPor,dppImp,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + ", " + mes.ToString() + "," + año.ToString() + ",-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,'-1')";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 12:
                    #region insertar cedula1
                    c1 = double.Parse(dataGridView12.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dataGridView12.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dataGridView12.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dataGridView12.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dataGridView12.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dataGridView12.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dataGridView12.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dataGridView12.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dataGridView12.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dataGridView12.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula4(Escenario,margeniniPor,margeniniImp,rebajasPor,rebajasImp,margenfinPor,margenfinImp,utilidadPor,utilidadImp,dppPor,dppImp,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + ", " + mes.ToString() + "," + año.ToString() + ",-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,'-1')";
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
                    c1 = double.Parse(dataGridView1.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dataGridView1.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dataGridView1.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dataGridView1.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dataGridView1.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dataGridView1.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dataGridView1.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dataGridView1.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dataGridView1.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dataGridView1.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    string s = "update cedula4 set margeniniPor=" + c1.ToString() + ",margeniniImp=" + c2.ToString() + ",rebajasPor=" + c3.ToString() + ",rebajasImp=" + c4.ToString() + ",margenfinPor=" + c5.ToString() + ",margenfinImp=" + c6.ToString() + ",utilidadPor=" + c7.ToString() + ",utilidadImp=" + c8.ToString() + ",dppPor=" + c9.ToString() + ",dppImp=" + c10.ToString() + " where Escenario='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " ";
                    
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 2:
                    #region insertar cedula1
                    c1 = double.Parse(dataGridView2.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dataGridView2.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dataGridView2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dataGridView2.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dataGridView2.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dataGridView2.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dataGridView2.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dataGridView2.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dataGridView2.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dataGridView2.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    s = "update cedula4 set margeniniPor=" + c1.ToString() + ",margeniniImp=" + c2.ToString() + ",rebajasPor=" + c3.ToString() + ",rebajasImp=" + c4.ToString() + ",margenfinPor=" + c5.ToString() + ",margenfinImp=" + c6.ToString() + ",utilidadPor=" + c7.ToString() + ",utilidadImp=" + c8.ToString() + ",dppPor=" + c9.ToString() + ",dppImp=" + c10.ToString() + " where Escenario='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " ";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 3:
                    #region insertar cedula1
                    c1 = double.Parse(dataGridView3.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dataGridView3.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dataGridView3.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dataGridView3.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dataGridView3.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dataGridView3.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dataGridView3.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dataGridView3.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dataGridView3.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dataGridView3.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    s = "update cedula4 set margeniniPor=" + c1.ToString() + ",margeniniImp=" + c2.ToString() + ",rebajasPor=" + c3.ToString() + ",rebajasImp=" + c4.ToString() + ",margenfinPor=" + c5.ToString() + ",margenfinImp=" + c6.ToString() + ",utilidadPor=" + c7.ToString() + ",utilidadImp=" + c8.ToString() + ",dppPor=" + c9.ToString() + ",dppImp=" + c10.ToString() + " where Escenario='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " ";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 4:
                    #region insertar cedula1
                    c1 = double.Parse(dataGridView4.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dataGridView4.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dataGridView4.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dataGridView4.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dataGridView4.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dataGridView4.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dataGridView4.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dataGridView4.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dataGridView4.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dataGridView4.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    s = "update cedula4 set margeniniPor=" + c1.ToString() + ",margeniniImp=" + c2.ToString() + ",rebajasPor=" + c3.ToString() + ",rebajasImp=" + c4.ToString() + ",margenfinPor=" + c5.ToString() + ",margenfinImp=" + c6.ToString() + ",utilidadPor=" + c7.ToString() + ",utilidadImp=" + c8.ToString() + ",dppPor=" + c9.ToString() + ",dppImp=" + c10.ToString() + " where Escenario='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " ";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 5:
                    #region insertar cedula1
                    c1 = double.Parse(dataGridView5.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dataGridView5.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dataGridView5.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dataGridView5.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dataGridView5.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dataGridView5.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dataGridView5.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dataGridView5.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dataGridView5.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dataGridView5.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    s = "update cedula4 set margeniniPor=" + c1.ToString() + ",margeniniImp=" + c2.ToString() + ",rebajasPor=" + c3.ToString() + ",rebajasImp=" + c4.ToString() + ",margenfinPor=" + c5.ToString() + ",margenfinImp=" + c6.ToString() + ",utilidadPor=" + c7.ToString() + ",utilidadImp=" + c8.ToString() + ",dppPor=" + c9.ToString() + ",dppImp=" + c10.ToString() + " where Escenario='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " ";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 6:
                    #region insertar cedula1
                    c1 = double.Parse(dataGridView6.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dataGridView6.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dataGridView6.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dataGridView6.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dataGridView6.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dataGridView6.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dataGridView6.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dataGridView6.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dataGridView6.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dataGridView6.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    s = "update cedula4 set margeniniPor=" + c1.ToString() + ",margeniniImp=" + c2.ToString() + ",rebajasPor=" + c3.ToString() + ",rebajasImp=" + c4.ToString() + ",margenfinPor=" + c5.ToString() + ",margenfinImp=" + c6.ToString() + ",utilidadPor=" + c7.ToString() + ",utilidadImp=" + c8.ToString() + ",dppPor=" + c9.ToString() + ",dppImp=" + c10.ToString() + " where Escenario='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " ";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 7:
                    #region insertar cedula1
                    c1 = double.Parse(dataGridView7.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dataGridView7.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dataGridView7.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dataGridView7.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dataGridView7.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dataGridView7.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dataGridView7.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dataGridView7.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dataGridView7.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dataGridView7.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    s = "update cedula4 set margeniniPor=" + c1.ToString() + ",margeniniImp=" + c2.ToString() + ",rebajasPor=" + c3.ToString() + ",rebajasImp=" + c4.ToString() + ",margenfinPor=" + c5.ToString() + ",margenfinImp=" + c6.ToString() + ",utilidadPor=" + c7.ToString() + ",utilidadImp=" + c8.ToString() + ",dppPor=" + c9.ToString() + ",dppImp=" + c10.ToString() + " where Escenario='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " ";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 8:
                    #region insertar cedula1
                    c1 = double.Parse(dataGridView8.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dataGridView8.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dataGridView8.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dataGridView8.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dataGridView8.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dataGridView8.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dataGridView8.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dataGridView8.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dataGridView8.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dataGridView8.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    s = "update cedula4 set margeniniPor=" + c1.ToString() + ",margeniniImp=" + c2.ToString() + ",rebajasPor=" + c3.ToString() + ",rebajasImp=" + c4.ToString() + ",margenfinPor=" + c5.ToString() + ",margenfinImp=" + c6.ToString() + ",utilidadPor=" + c7.ToString() + ",utilidadImp=" + c8.ToString() + ",dppPor=" + c9.ToString() + ",dppImp=" + c10.ToString() + " where Escenario='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " ";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 9:
                    #region insertar cedula1
                    c1 = double.Parse(dataGridView9.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dataGridView9.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dataGridView9.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dataGridView9.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dataGridView9.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dataGridView9.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dataGridView9.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dataGridView9.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dataGridView9.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dataGridView9.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    s = "update cedula4 set margeniniPor=" + c1.ToString() + ",margeniniImp=" + c2.ToString() + ",rebajasPor=" + c3.ToString() + ",rebajasImp=" + c4.ToString() + ",margenfinPor=" + c5.ToString() + ",margenfinImp=" + c6.ToString() + ",utilidadPor=" + c7.ToString() + ",utilidadImp=" + c8.ToString() + ",dppPor=" + c9.ToString() + ",dppImp=" + c10.ToString() + " where Escenario='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " ";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 10:
                    #region insertar cedula1
                    c1 = double.Parse(dataGridView10.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dataGridView10.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dataGridView10.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dataGridView10.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dataGridView10.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dataGridView10.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dataGridView10.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dataGridView10.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dataGridView10.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dataGridView10.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    s = "update cedula4 set margeniniPor=" + c1.ToString() + ",margeniniImp=" + c2.ToString() + ",rebajasPor=" + c3.ToString() + ",rebajasImp=" + c4.ToString() + ",margenfinPor=" + c5.ToString() + ",margenfinImp=" + c6.ToString() + ",utilidadPor=" + c7.ToString() + ",utilidadImp=" + c8.ToString() + ",dppPor=" + c9.ToString() + ",dppImp=" + c10.ToString() + " where Escenario='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " ";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 11:
                    #region insertar cedula1
                    c1 = double.Parse(dataGridView11.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dataGridView11.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dataGridView11.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dataGridView11.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dataGridView11.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dataGridView11.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dataGridView11.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dataGridView11.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dataGridView11.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dataGridView11.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    s = "update cedula4 set margeniniPor=" + c1.ToString() + ",margeniniImp=" + c2.ToString() + ",rebajasPor=" + c3.ToString() + ",rebajasImp=" + c4.ToString() + ",margenfinPor=" + c5.ToString() + ",margenfinImp=" + c6.ToString() + ",utilidadPor=" + c7.ToString() + ",utilidadImp=" + c8.ToString() + ",dppPor=" + c9.ToString() + ",dppImp=" + c10.ToString() + " where Escenario='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " ";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 12:
                    #region insertar cedula1
                    c1 = double.Parse(dataGridView12.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dataGridView12.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dataGridView12.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dataGridView12.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dataGridView12.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dataGridView12.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dataGridView12.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dataGridView12.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dataGridView12.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dataGridView12.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    s = "update cedula4 set margeniniPor=" + c1.ToString() + ",margeniniImp=" + c2.ToString() + ",rebajasPor=" + c3.ToString() + ",rebajasImp=" + c4.ToString() + ",margenfinPor=" + c5.ToString() + ",margenfinImp=" + c6.ToString() + ",utilidadPor=" + c7.ToString() + ",utilidadImp=" + c8.ToString() + ",dppPor=" + c9.ToString() + ",dppImp=" + c10.ToString() + " where Escenario='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " ";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
            }
        }
        private bool comprobarCargar(int año, int mes, int i)
        {
            bool comprobar = true;
            string s = "SELECT * FROM cedula4 where Escenario='" + Properties.Settings.Default.escenario + "' and anio=" + año + " and mes=" + mes ;
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

                    for (int x = 0; x <= dataGridView1.Rows.Count - 1; x++)
                    {
                        string s = "SELECT * FROM cedula4 where Escenario='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString();
                        checaConexion();
                        cmd = new MySqlCommand(s, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["margeniniPor"].ToString());
                            c2 = double.Parse(reader["margeniniImp"].ToString());
                            c3 = double.Parse(reader["rebajasPor"].ToString());
                            c4 = double.Parse(reader["rebajasImp"].ToString());
                            c5 = double.Parse(reader["margenfinPor"].ToString());
                            c6 = double.Parse(reader["margenfinImp"].ToString());
                            c7 = double.Parse(reader["utilidadPor"].ToString());
                            c8 = double.Parse(reader["utilidadImp"].ToString());
                            c9 = double.Parse(reader["dppPor"].ToString());
                            c10 = double.Parse(reader["dppImp"].ToString());
                            dataGridView1.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dataGridView1.Rows[x].Cells[2].Value = c2.ToString("C2");
                            dataGridView1.Rows[x].Cells[3].Value = c3.ToString("n0");
                            dataGridView1.Rows[x].Cells[4].Value = c4.ToString("C2");
                            dataGridView1.Rows[x].Cells[5].Value = c5.ToString("n0");
                            dataGridView1.Rows[x].Cells[6].Value = c6.ToString("C2");
                            dataGridView1.Rows[x].Cells[7].Value = c7.ToString("n0");
                            dataGridView1.Rows[x].Cells[8].Value = c8.ToString("C2");
                            dataGridView1.Rows[x].Cells[9].Value = c9.ToString("n0");
                            dataGridView1.Rows[x].Cells[10].Value = c10.ToString("C2");
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 2:
                    #region cargar grid1
                    for (int x = 0; x <= dataGridView1.Rows.Count - 1; x++)
                    {
                        s = "SELECT * FROM cedula4 where Escenario='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString();
                        checaConexion();
                        cmd = new MySqlCommand(s, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["margeniniPor"].ToString());
                            c2 = double.Parse(reader["margeniniImp"].ToString());
                            c3 = double.Parse(reader["rebajasPor"].ToString());
                            c4 = double.Parse(reader["rebajasImp"].ToString());
                            c5 = double.Parse(reader["margenfinPor"].ToString());
                            c6 = double.Parse(reader["margenfinImp"].ToString());
                            c7 = double.Parse(reader["utilidadPor"].ToString());
                            c8 = double.Parse(reader["utilidadImp"].ToString());
                            c9 = double.Parse(reader["dppPor"].ToString());
                            c10 = double.Parse(reader["dppImp"].ToString());
                            dataGridView2.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dataGridView2.Rows[x].Cells[2].Value = c2.ToString("C2");
                            dataGridView2.Rows[x].Cells[3].Value = c3.ToString("n0");
                            dataGridView2.Rows[x].Cells[4].Value = c4.ToString("C2");
                            dataGridView2.Rows[x].Cells[5].Value = c5.ToString("n0");
                            dataGridView2.Rows[x].Cells[6].Value = c6.ToString("C2");
                            dataGridView2.Rows[x].Cells[7].Value = c7.ToString("n0");
                            dataGridView2.Rows[x].Cells[8].Value = c8.ToString("C2");
                            dataGridView2.Rows[x].Cells[9].Value = c9.ToString("n0");
                            dataGridView2.Rows[x].Cells[10].Value = c10.ToString("C2");
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 3:
                    #region cargar grid1
                    for (int x = 0; x <= dataGridView1.Rows.Count - 1; x++)
                    {
                        s = "SELECT * FROM cedula4 where Escenario='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString();
                        checaConexion();
                        cmd = new MySqlCommand(s, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["margeniniPor"].ToString());
                            c2 = double.Parse(reader["margeniniImp"].ToString());
                            c3 = double.Parse(reader["rebajasPor"].ToString());
                            c4 = double.Parse(reader["rebajasImp"].ToString());
                            c5 = double.Parse(reader["margenfinPor"].ToString());
                            c6 = double.Parse(reader["margenfinImp"].ToString());
                            c7 = double.Parse(reader["utilidadPor"].ToString());
                            c8 = double.Parse(reader["utilidadImp"].ToString());
                            c9 = double.Parse(reader["dppPor"].ToString());
                            c10 = double.Parse(reader["dppImp"].ToString());
                            dataGridView3.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dataGridView3.Rows[x].Cells[2].Value = c2.ToString("C2");
                            dataGridView3.Rows[x].Cells[3].Value = c3.ToString("n0");
                            dataGridView3.Rows[x].Cells[4].Value = c4.ToString("C2");
                            dataGridView3.Rows[x].Cells[5].Value = c5.ToString("n0");
                            dataGridView3.Rows[x].Cells[6].Value = c6.ToString("C2");
                            dataGridView3.Rows[x].Cells[7].Value = c7.ToString("n0");
                            dataGridView3.Rows[x].Cells[8].Value = c8.ToString("C2");
                            dataGridView3.Rows[x].Cells[9].Value = c9.ToString("n0");
                            dataGridView3.Rows[x].Cells[10].Value = c10.ToString("C2");
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 4:
                    #region cargar grid1
                    for (int x = 0; x <= dataGridView1.Rows.Count - 1; x++)
                    {
                        s = "SELECT * FROM cedula4 where Escenario='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString();
                        checaConexion();
                        cmd = new MySqlCommand(s, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["margeniniPor"].ToString());
                            c2 = double.Parse(reader["margeniniImp"].ToString());
                            c3 = double.Parse(reader["rebajasPor"].ToString());
                            c4 = double.Parse(reader["rebajasImp"].ToString());
                            c5 = double.Parse(reader["margenfinPor"].ToString());
                            c6 = double.Parse(reader["margenfinImp"].ToString());
                            c7 = double.Parse(reader["utilidadPor"].ToString());
                            c8 = double.Parse(reader["utilidadImp"].ToString());
                            c9 = double.Parse(reader["dppPor"].ToString());
                            c10 = double.Parse(reader["dppImp"].ToString());
                            dataGridView4.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dataGridView4.Rows[x].Cells[2].Value = c2.ToString("C2");
                            dataGridView4.Rows[x].Cells[3].Value = c3.ToString("n0");
                            dataGridView4.Rows[x].Cells[4].Value = c4.ToString("C2");
                            dataGridView4.Rows[x].Cells[5].Value = c5.ToString("n0");
                            dataGridView4.Rows[x].Cells[6].Value = c6.ToString("C2");
                            dataGridView4.Rows[x].Cells[7].Value = c7.ToString("n0");
                            dataGridView4.Rows[x].Cells[8].Value = c8.ToString("C2");
                            dataGridView4.Rows[x].Cells[9].Value = c9.ToString("n0");
                            dataGridView4.Rows[x].Cells[10].Value = c10.ToString("C2");
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 5:
                    #region cargar grid1
                    for (int x = 0; x <= dataGridView1.Rows.Count - 1; x++)
                    {
                        s = "SELECT * FROM cedula4 where Escenario='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString();
                        checaConexion();
                        cmd = new MySqlCommand(s, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["margeniniPor"].ToString());
                            c2 = double.Parse(reader["margeniniImp"].ToString());
                            c3 = double.Parse(reader["rebajasPor"].ToString());
                            c4 = double.Parse(reader["rebajasImp"].ToString());
                            c5 = double.Parse(reader["margenfinPor"].ToString());
                            c6 = double.Parse(reader["margenfinImp"].ToString());
                            c7 = double.Parse(reader["utilidadPor"].ToString());
                            c8 = double.Parse(reader["utilidadImp"].ToString());
                            c9 = double.Parse(reader["dppPor"].ToString());
                            c10 = double.Parse(reader["dppImp"].ToString());
                            dataGridView5.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dataGridView5.Rows[x].Cells[2].Value = c2.ToString("C2");
                            dataGridView5.Rows[x].Cells[3].Value = c3.ToString("n0");
                            dataGridView5.Rows[x].Cells[4].Value = c4.ToString("C2");
                            dataGridView5.Rows[x].Cells[5].Value = c5.ToString("n0");
                            dataGridView5.Rows[x].Cells[6].Value = c6.ToString("C2");
                            dataGridView5.Rows[x].Cells[7].Value = c7.ToString("n0");
                            dataGridView5.Rows[x].Cells[8].Value = c8.ToString("C2");
                            dataGridView5.Rows[x].Cells[9].Value = c9.ToString("n0");
                            dataGridView5.Rows[x].Cells[10].Value = c10.ToString("C2");
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 6:
                    #region cargar grid1
                    for (int x = 0; x <= dataGridView1.Rows.Count - 1; x++)
                    {
                        s = "SELECT * FROM cedula4 where Escenario='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString();
                        checaConexion();
                        cmd = new MySqlCommand(s, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["margeniniPor"].ToString());
                            c2 = double.Parse(reader["margeniniImp"].ToString());
                            c3 = double.Parse(reader["rebajasPor"].ToString());
                            c4 = double.Parse(reader["rebajasImp"].ToString());
                            c5 = double.Parse(reader["margenfinPor"].ToString());
                            c6 = double.Parse(reader["margenfinImp"].ToString());
                            c7 = double.Parse(reader["utilidadPor"].ToString());
                            c8 = double.Parse(reader["utilidadImp"].ToString());
                            c9 = double.Parse(reader["dppPor"].ToString());
                            c10 = double.Parse(reader["dppImp"].ToString());
                            dataGridView6.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dataGridView6.Rows[x].Cells[2].Value = c2.ToString("C2");
                            dataGridView6.Rows[x].Cells[3].Value = c3.ToString("n0");
                            dataGridView6.Rows[x].Cells[4].Value = c4.ToString("C2");
                            dataGridView6.Rows[x].Cells[5].Value = c5.ToString("n0");
                            dataGridView6.Rows[x].Cells[6].Value = c6.ToString("C2");
                            dataGridView6.Rows[x].Cells[7].Value = c7.ToString("n0");
                            dataGridView6.Rows[x].Cells[8].Value = c8.ToString("C2");
                            dataGridView6.Rows[x].Cells[9].Value = c9.ToString("n0");
                            dataGridView6.Rows[x].Cells[10].Value = c10.ToString("C2");
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 7:
                    #region cargar grid1
                    for (int x = 0; x <= dataGridView1.Rows.Count - 1; x++)
                    {
                        s = "SELECT * FROM cedula4 where Escenario='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString();
                        checaConexion();
                        cmd = new MySqlCommand(s, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["margeniniPor"].ToString());
                            c2 = double.Parse(reader["margeniniImp"].ToString());
                            c3 = double.Parse(reader["rebajasPor"].ToString());
                            c4 = double.Parse(reader["rebajasImp"].ToString());
                            c5 = double.Parse(reader["margenfinPor"].ToString());
                            c6 = double.Parse(reader["margenfinImp"].ToString());
                            c7 = double.Parse(reader["utilidadPor"].ToString());
                            c8 = double.Parse(reader["utilidadImp"].ToString());
                            c9 = double.Parse(reader["dppPor"].ToString());
                            c10 = double.Parse(reader["dppImp"].ToString());
                            dataGridView7.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dataGridView7.Rows[x].Cells[2].Value = c2.ToString("C2");
                            dataGridView7.Rows[x].Cells[3].Value = c3.ToString("n0");
                            dataGridView7.Rows[x].Cells[4].Value = c4.ToString("C2");
                            dataGridView7.Rows[x].Cells[5].Value = c5.ToString("n0");
                            dataGridView7.Rows[x].Cells[6].Value = c6.ToString("C2");
                            dataGridView7.Rows[x].Cells[7].Value = c7.ToString("n0");
                            dataGridView7.Rows[x].Cells[8].Value = c8.ToString("C2");
                            dataGridView7.Rows[x].Cells[9].Value = c9.ToString("n0");
                            dataGridView7.Rows[x].Cells[10].Value = c10.ToString("C2");
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 8:
                    #region cargar grid1
                    for (int x = 0; x <= dataGridView1.Rows.Count - 1; x++)
                    {
                        s = "SELECT * FROM cedula4 where Escenario='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString();
                        checaConexion();
                        cmd = new MySqlCommand(s, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["margeniniPor"].ToString());
                            c2 = double.Parse(reader["margeniniImp"].ToString());
                            c3 = double.Parse(reader["rebajasPor"].ToString());
                            c4 = double.Parse(reader["rebajasImp"].ToString());
                            c5 = double.Parse(reader["margenfinPor"].ToString());
                            c6 = double.Parse(reader["margenfinImp"].ToString());
                            c7 = double.Parse(reader["utilidadPor"].ToString());
                            c8 = double.Parse(reader["utilidadImp"].ToString());
                            c9 = double.Parse(reader["dppPor"].ToString());
                            c10 = double.Parse(reader["dppImp"].ToString());
                            dataGridView8.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dataGridView8.Rows[x].Cells[2].Value = c2.ToString("C2");
                            dataGridView8.Rows[x].Cells[3].Value = c3.ToString("n0");
                            dataGridView8.Rows[x].Cells[4].Value = c4.ToString("C2");
                            dataGridView8.Rows[x].Cells[5].Value = c5.ToString("n0");
                            dataGridView8.Rows[x].Cells[6].Value = c6.ToString("C2");
                            dataGridView8.Rows[x].Cells[7].Value = c7.ToString("n0");
                            dataGridView8.Rows[x].Cells[8].Value = c8.ToString("C2");
                            dataGridView8.Rows[x].Cells[9].Value = c9.ToString("n0");
                            dataGridView8.Rows[x].Cells[10].Value = c10.ToString("C2");
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 9:
                    #region cargar grid1
                    for (int x = 0; x <= dataGridView1.Rows.Count - 1; x++)
                    {
                        s = "SELECT * FROM cedula4 where Escenario='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString();
                        checaConexion();
                        cmd = new MySqlCommand(s, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["margeniniPor"].ToString());
                            c2 = double.Parse(reader["margeniniImp"].ToString());
                            c3 = double.Parse(reader["rebajasPor"].ToString());
                            c4 = double.Parse(reader["rebajasImp"].ToString());
                            c5 = double.Parse(reader["margenfinPor"].ToString());
                            c6 = double.Parse(reader["margenfinImp"].ToString());
                            c7 = double.Parse(reader["utilidadPor"].ToString());
                            c8 = double.Parse(reader["utilidadImp"].ToString());
                            c9 = double.Parse(reader["dppPor"].ToString());
                            c10 = double.Parse(reader["dppImp"].ToString());
                            dataGridView9.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dataGridView9.Rows[x].Cells[2].Value = c2.ToString("C2");
                            dataGridView9.Rows[x].Cells[3].Value = c3.ToString("n0");
                            dataGridView9.Rows[x].Cells[4].Value = c4.ToString("C2");
                            dataGridView9.Rows[x].Cells[5].Value = c5.ToString("n0");
                            dataGridView9.Rows[x].Cells[6].Value = c6.ToString("C2");
                            dataGridView9.Rows[x].Cells[7].Value = c7.ToString("n0");
                            dataGridView9.Rows[x].Cells[8].Value = c8.ToString("C2");
                            dataGridView9.Rows[x].Cells[9].Value = c9.ToString("n0");
                            dataGridView9.Rows[x].Cells[10].Value = c10.ToString("C2");
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 10:
                    #region cargar grid1
                    for (int x = 0; x <= dataGridView1.Rows.Count - 1; x++)
                    {
                        s = "SELECT * FROM cedula4 where Escenario='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString();
                        checaConexion();
                        cmd = new MySqlCommand(s, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["margeniniPor"].ToString());
                            c2 = double.Parse(reader["margeniniImp"].ToString());
                            c3 = double.Parse(reader["rebajasPor"].ToString());
                            c4 = double.Parse(reader["rebajasImp"].ToString());
                            c5 = double.Parse(reader["margenfinPor"].ToString());
                            c6 = double.Parse(reader["margenfinImp"].ToString());
                            c7 = double.Parse(reader["utilidadPor"].ToString());
                            c8 = double.Parse(reader["utilidadImp"].ToString());
                            c9 = double.Parse(reader["dppPor"].ToString());
                            c10 = double.Parse(reader["dppImp"].ToString());
                            dataGridView10.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dataGridView10.Rows[x].Cells[2].Value = c2.ToString("C2");
                            dataGridView10.Rows[x].Cells[3].Value = c3.ToString("n0");
                            dataGridView10.Rows[x].Cells[4].Value = c4.ToString("C2");
                            dataGridView10.Rows[x].Cells[5].Value = c5.ToString("n0");
                            dataGridView10.Rows[x].Cells[6].Value = c6.ToString("C2");
                            dataGridView10.Rows[x].Cells[7].Value = c7.ToString("n0");
                            dataGridView10.Rows[x].Cells[8].Value = c8.ToString("C2");
                            dataGridView10.Rows[x].Cells[9].Value = c9.ToString("n0");
                            dataGridView10.Rows[x].Cells[10].Value = c10.ToString("C2");
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 11:
                    #region cargar grid1
                    for (int x = 0; x <= dataGridView1.Rows.Count - 1; x++)
                    {
                        s = "SELECT * FROM cedula4 where Escenario='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString();
                        checaConexion();
                        cmd = new MySqlCommand(s, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["margeniniPor"].ToString());
                            c2 = double.Parse(reader["margeniniImp"].ToString());
                            c3 = double.Parse(reader["rebajasPor"].ToString());
                            c4 = double.Parse(reader["rebajasImp"].ToString());
                            c5 = double.Parse(reader["margenfinPor"].ToString());
                            c6 = double.Parse(reader["margenfinImp"].ToString());
                            c7 = double.Parse(reader["utilidadPor"].ToString());
                            c8 = double.Parse(reader["utilidadImp"].ToString());
                            c9 = double.Parse(reader["dppPor"].ToString());
                            c10 = double.Parse(reader["dppImp"].ToString());
                            dataGridView11.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dataGridView11.Rows[x].Cells[2].Value = c2.ToString("C2");
                            dataGridView11.Rows[x].Cells[3].Value = c3.ToString("n0");
                            dataGridView11.Rows[x].Cells[4].Value = c4.ToString("C2");
                            dataGridView11.Rows[x].Cells[5].Value = c5.ToString("n0");
                            dataGridView11.Rows[x].Cells[6].Value = c6.ToString("C2");
                            dataGridView11.Rows[x].Cells[7].Value = c7.ToString("n0");
                            dataGridView11.Rows[x].Cells[8].Value = c8.ToString("C2");
                            dataGridView11.Rows[x].Cells[9].Value = c9.ToString("n0");
                            dataGridView11.Rows[x].Cells[10].Value = c10.ToString("C2");
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 12:
                    #region cargar grid1
                    for (int x = 0; x <= dataGridView1.Rows.Count - 1; x++)
                    {
                        s = "SELECT * FROM cedula4 where Escenario='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString();
                        checaConexion();
                        cmd = new MySqlCommand(s, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["margeniniPor"].ToString());
                            c2 = double.Parse(reader["margeniniImp"].ToString());
                            c3 = double.Parse(reader["rebajasPor"].ToString());
                            c4 = double.Parse(reader["rebajasImp"].ToString());
                            c5 = double.Parse(reader["margenfinPor"].ToString());
                            c6 = double.Parse(reader["margenfinImp"].ToString());
                            c7 = double.Parse(reader["utilidadPor"].ToString());
                            c8 = double.Parse(reader["utilidadImp"].ToString());
                            c9 = double.Parse(reader["dppPor"].ToString());
                            c10 = double.Parse(reader["dppImp"].ToString());
                            dataGridView12.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dataGridView12.Rows[x].Cells[2].Value = c2.ToString("C2");
                            dataGridView12.Rows[x].Cells[3].Value = c3.ToString("n0");
                            dataGridView12.Rows[x].Cells[4].Value = c4.ToString("C2");
                            dataGridView12.Rows[x].Cells[5].Value = c5.ToString("n0");
                            dataGridView12.Rows[x].Cells[6].Value = c6.ToString("C2");
                            dataGridView12.Rows[x].Cells[7].Value = c7.ToString("n0");
                            dataGridView12.Rows[x].Cells[8].Value = c8.ToString("C2");
                            dataGridView12.Rows[x].Cells[9].Value = c9.ToString("n0");
                            dataGridView12.Rows[x].Cells[10].Value = c10.ToString("C2");
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
            }
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabcontrol.SelectedIndex = 0;
            m_CLEAR_DGV();
            m_REFRESH_DGV();//dataGridView1.Refresh();  
            m_ADD_ROWS_DGV(); //dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[0].Value = "Total";
            m_PASS_VALUES_DGV(dataGridView1.Rows[0].Cells[0].Value.ToString(), 0);//pasa el valor a otros dgvs
            m_DIASMESESANOST(CED1_fechaI, CED1_fechaF);
            //m_TOTALES();
            tabcontrol.SelectedIndex = 0;
        }
        public void m_DIASMESESANOST(string fecha_inicio, string fecha_final) /////////////////////////////se usa en todos 
        {
            #region separar fechas
            int fecha_inicio_dia = Convert.ToInt32(fecha_inicio.Substring(0, 2));
            int fecha_inicio_mes = Convert.ToInt32(fecha_inicio.Substring(3, 2));
            int fecha_inicio_ano = Convert.ToInt32(fecha_inicio.Substring(6, 4));

            int fecha_final_dia = Convert.ToInt32(fecha_final.Substring(0, 2));
            int fecha_final_mes = Convert.ToInt32(fecha_final.Substring(3, 2));
            int fecha_final_ano = Convert.ToInt32(fecha_final.Substring(6, 4));
            #endregion
            waitingbar.Visible = true;
            waitingbar.StartWaiting();
            #region añomes
            int i = 1; calculos = 1;
            for (; fecha_inicio_ano <= fecha_final_ano; fecha_inicio_ano++)
            {
                if (fecha_inicio_mes <= fecha_final_mes)
                {
                    for (; fecha_inicio_mes <= fecha_final_mes; fecha_inicio_mes++, i++)
                        try
                        {
                            m_TABS(fecha_inicio_mes, fecha_inicio_ano);/////////////////////se usa en todos
                            if (comprobarCargar(fecha_inicio_ano, fecha_inicio_mes, i) == true)
                            {
                                cargar(fecha_inicio_mes, fecha_inicio_ano, i);
                            }
                            else
                            {
                                m_VENTATOTALT(fecha_inicio_mes, fecha_inicio_ano);
                                m_GASTOTOTAL(fecha_inicio_mes, fecha_inicio_ano,i);
                                m_QUERYS_DGVT(fecha_inicio_mes, fecha_inicio_ano, i);
                                //m_CALCULOS(i);
                                m_rebajas(fecha_inicio_mes, fecha_inicio_ano, i);
                                m_CALCULOS(i);
                                m_margenIimporte(fecha_inicio_mes, fecha_inicio_ano, i);
                                m_margenFimporte(fecha_inicio_mes, fecha_inicio_ano, i);
                                m_dpp(fecha_inicio_mes, fecha_inicio_ano, i);

                            }
                            tabcontrol.Visible = true;
                            tabcontrol.SelectedIndex = tabcontrol.SelectedIndex + 1;
                        }
                        catch (Exception x)
                        { MessageBox.Show("Error con las fechas " + x); }
                }
                if (fecha_final_mes < fecha_inicio_mes && fecha_inicio_ano != fecha_final_ano)
                {
                    for (; fecha_inicio_mes <= 12; fecha_inicio_mes++, i++)
                        try
                        {
                            m_TABS(fecha_inicio_mes, fecha_inicio_ano);

                            if (comprobarCargar(fecha_inicio_ano, fecha_inicio_mes, i) == true)
                            {
                                cargar(fecha_inicio_mes, fecha_inicio_ano, i);
                            }
                            else
                            {
                                //m_VENTATOTALT(fecha_inicio_mes, fecha_inicio_ano);
                                //m_GASTOTOTAL(fecha_inicio_mes, fecha_inicio_ano,i);
                                //m_QUERYS_DGVT(fecha_inicio_mes, fecha_inicio_ano, i);
                                //m_CALCULOS(i);
                                m_VENTATOTALT(fecha_inicio_mes, fecha_inicio_ano);
                                m_GASTOTOTAL(fecha_inicio_mes, fecha_inicio_ano, i);
                                m_QUERYS_DGVT(fecha_inicio_mes, fecha_inicio_ano, i);
                                m_margenIimporte(fecha_inicio_mes, fecha_inicio_ano, i);
                                m_margenFimporte(fecha_inicio_mes, fecha_inicio_ano, i);
                                m_CALCULOS(i);
                                m_dpp(fecha_inicio_mes, fecha_inicio_ano, i);

                            }
                            tabcontrol.Visible = true;
                            tabcontrol.SelectedIndex = tabcontrol.SelectedIndex + 1;
                        }
                        catch (Exception x)
                        { MessageBox.Show("Error con las fechas " + x); }
                }
                fecha_inicio_mes = 1;
            }
            #endregion
            waitingbar.StopWaiting();
            waitingbar.Visible = false;
        }
        public void m_VENTATOTALT(int mes, int ano) // ejemplo query 
        {
            double prom = 0; ced_sumatoria = 0;
            string q = "";
            if (solocalzadowhere == "")
            {
                q = "SELECT SUM(impllenototal) AS importe FROM VENTASBASE AS V INNER JOIN fecha AS F ON F.`idFecha` = V.`IDFECHA` WHERE  F.mes = " + mes + " AND F.anio = '" + (ano-1) + "' ;";
            }
            else
            {
                q = "SELECT SUM(impllenototal) AS importe FROM VENTASBASE AS V INNER JOIN fecha AS F ON F.`idFecha` = V.`IDFECHA` WHERE  F.mes = " + mes + " AND F.anio = '" + (ano-1) + "' and V.iddivisiones=1;";
            }
           
                #region CONSULTA CORRECTA AÑO ACTUAL
            checaConexion();
                cmd = new MySqlCommand(q, Conn); cmd.CommandTimeout = 0;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if(reader["importe"].ToString()=="")
                    {
                        ventaT[0]=0;
                    }
                    else
                    {
                        ventaT[0] = double.Parse(reader["importe"].ToString());
                    }
                }
                reader.Close();
                #endregion
        }
        public void m_QUERYS_DGVT(int mes, int ano, int dgv) //////////falta editar y pasar valores a otro metodo
        {

            double ced_costo = 0; double ced_venta = 0; double ced_rebajas = 0;

            double prom = 0;
                m_REFRESH_DGV(); int difcero1 = 1; int difcero2 = 1; int difcero3 = 1;

                #region CONSULTA CORRECTA AÑO ACTUAL
                query = "SELECT SUM(costomargenneto) AS costo ,SUM(impllenototal) AS venta,(SUM(rebajaregsiva)+SUM(rebajapromsiva)+SUM(rebajanormalsiva)+SUM(rebajadesctosiva))AS rebajas FROM VENTASBASE AS V INNER JOIN fecha AS F ON F.`idFecha` = V.`IDFECHA` WHERE F.mes = " + mes + " AND F.anio = '" + (ano-1) + "'  ;";
                checaConexion();
                cmd = new MySqlCommand(query, Conn); cmd.CommandTimeout = 0;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["costo"].ToString() == "")
                    { costoT[0] = 0;}
                    else
                    {
                        costoT[0] = double.Parse(reader["costo"].ToString());
                    }
                    if (reader["venta"].ToString() == "") { ced_venta = 0; difcero2 = 0; }
                    else
                    {
                        string val = reader["venta"].ToString(); ced_venta = Convert.ToDouble(val);
                    }
                    if (reader["rebajas"].ToString() == "") { rebaja[0] = 0;}
                    else
                    {
                        rebaja[0] = double.Parse(reader["rebajas"].ToString());
                    }

                }
                reader.Close();
                #endregion
        }
        public void m_GASTOTOTAL(int mes, int ano,int i) // ejemplo query 
        {
            double impgasto = 0;
            #region CONSULTA CORRECTA AÑO ACTUAL
            query = "SELECT gasto FROM gasto WHERE MONTH = " + mes + " AND YEAR = '" + (ano - 1) + "'";
            checaConexion();
            cmd = new MySqlCommand(query, Conn); cmd.CommandTimeout = 0;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["gasto"].ToString() == "")
                {
                    gasto[0] = 0;
                }
                else
                {
                    gasto[0] = double.Parse(reader["gasto"].ToString());
                }
                m_LLENAR_DGV(i, 0, 8, gasto[0].ToString("N2"));
                impgasto = ( gasto[0]/ventaT[0]) * 100;
                m_LLENAR_DGV(i, 0, 7, impgasto.ToString("N2"));


            }
            reader.Close();
            #endregion
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

        private void m_margenIimporte(int mes, int año, int i)
        {
            año--;
            DateTime fmi = DateTime.Now;
            DateTime fmf = DateTime.Now;
            ////////////////////////////
            fmi = DateTime.Parse(año + "-" + mes + "-1");
            fmf = fmi.AddMonths(+1);
            double margeni = 0;
            double margen = 0;
            string q = "";
            if (solocalzadowhere == "")
            {
                q = "SELECT  (1-(SUM(costo)/SUM(precio)))*100 AS margen FROM margeninicialfecrecibo WHERE fecha BETWEEN '"+fmi.ToString("yyyy-MM-dd")+"' AND '"+fmf.ToString("yyyy-MM-dd")+"'";
            }
            else
            {
                q = "SELECT  (1-(SUM(costo)/SUM(precio)))*100 AS margen FROM margeninicialfecrecibo WHERE fecha BETWEEN '" + fmi.ToString("yyyy-MM-dd") + "' AND '" + fmf.ToString("yyyy-MM-dd") + "'";
            }
            checaConexion();
            cmd = new MySqlCommand(q, Conn); 
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if(reader["margen"].ToString() != "")
                {
                    margen = double.Parse(reader["margen"].ToString());
                }
                else { margen = 0; }
                margeni = (margen/100) * ventaT[0];
                m_LLENAR_DGV(i,0,1,margen.ToString("N2"));
                m_LLENAR_DGV(i, 0, 2, margeni.ToString("N2"));
            }
            reader.Close();
        }
        private void m_margenFimporte(int mes, int año, int i)
        {
            año--;
            DateTime fmi = DateTime.Now;
            DateTime fmf = DateTime.Now;
            ////////////////////////////
            fmi = DateTime.Parse(año + "-" + mes + "-1");
            fmf = fmi.AddMonths(+1);
            double margeni = 0;
            double margen = 0;
            string q = "";
            if (solocalzadowhere == "")
            {
                q = "SELECT  (1-(SUM(costo)/SUM(precio)))*100 AS margen, sum(costo) as costo FROM margenfinalfecventa WHERE fecha BETWEEN '" + fmi.ToString("yyyy-MM-dd") + "' AND '" + fmf.ToString("yyyy-MM-dd") + "'";
            }
            else
            {
                q = "SELECT  (1-(SUM(costo)/SUM(precio)))*100 AS margen, sum(costo) as costo FROM margenfinalfecventa WHERE fecha BETWEEN '" + fmi.ToString("yyyy-MM-dd") + "' AND '" + fmf.ToString("yyyy-MM-dd") + "'";
            }
            checaConexion();
            cmd = new MySqlCommand(q, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["margen"].ToString() != "")
                {
                    margen = double.Parse(reader["margen"].ToString());
                }
                else { margen = 0; }

                if (reader["costo"].ToString() != "")
                {
                    costoT[0] = double.Parse(reader["costo"].ToString());
                }
                else { costoT[0] = 0; }
                margeni = (margen/100) * ventaT[0];
                m_LLENAR_DGV(i, 0, 5, margen.ToString("N2"));
                m_LLENAR_DGV(i, 0, 6, margeni.ToString("N2"));
            }
            reader.Close();
        }

        private void m_LLENAR_DGV(int m, int renglon, int columna, string val)
        {
            //           dgvCed9.Rows[0].Cells[i].Value = val;
            //renglon++;
            switch (m)
            {
                case 1: dataGridView1.Rows[renglon].Cells[columna].Value = val;
                    break;
                case 2: dataGridView2.Rows[renglon].Cells[columna].Value = val;
                    break;
                case 3: dataGridView3.Rows[renglon].Cells[columna].Value = val;
                    break;
                case 4: dataGridView4.Rows[renglon].Cells[columna].Value = val;
                    break;
                case 5: dataGridView5.Rows[renglon].Cells[columna].Value = val;
                    break;
                case 6: dataGridView6.Rows[renglon].Cells[columna].Value = val;
                    break;
                case 7: dataGridView7.Rows[renglon].Cells[columna].Value = val;
                    break;
                case 8: dataGridView8.Rows[renglon].Cells[columna].Value = val;
                    break;
                case 9: dataGridView9.Rows[renglon].Cells[columna].Value = val;
                    break;
                case 10: dataGridView10.Rows[renglon].Cells[columna].Value = val;
                    break;
                case 11: dataGridView11.Rows[renglon].Cells[columna].Value = val;
                    break;
                case 12: dataGridView12.Rows[renglon].Cells[columna].Value = val;
                    break;
                //  case 13: dgvProf13.Rows[columna].Cells[1].Value = val; 
                //    break;

            }

        }

        private void m_rebajas(int mes, int año, int i)
        {
            double rebajaP = 0;
            query = "SELECT (SUM(rebajaregsiva)+SUM(rebajapromsiva)+SUM(rebajanormalsiva)+SUM(rebajadesctosiva))AS rebajas FROM VENTASBASE AS V INNER JOIN fecha AS F ON F.`idFecha` = V.`IDFECHA` WHERE F.mes = " + mes + " AND F.anio = '" + (año - 1) + "'  ;";
            checaConexion();
            cmd = new MySqlCommand(query, Conn); cmd.CommandTimeout = 0;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["rebajas"].ToString() == "") { rebaja[0] = 0; }
                else
                {
                    rebaja[0] = double.Parse(reader["rebajas"].ToString());
                }
                rebajaP = (100 / rebaja[0]) * ventaT[0];
                m_LLENAR_DGV(i, 0, 4, rebaja[0].ToString("N2"));
                m_LLENAR_DGV(i, 0, 3, rebajaP.ToString("N2"));
            }
            reader.Close();
        }
        private void m_dpp(int mes, int año, int i)
        {
            double dppi = 0;
            double dpp = 0;

            dppi = (1 - (costoT[0] + gasto[0]) / ventaT[0] )* 100;
            m_LLENAR_DGV(i, 0, 9, dppi.ToString("N2"));
            dpp=(dppi/100)*ventaT[0];
            m_LLENAR_DGV(i, 0, 10, dpp.ToString("N2"));
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tabcontrol.SelectedIndex = 0;
            m_CLEAR_DGV();
            m_REFRESH_DGV();//dataGridView1.Refresh();  
            m_ADD_ROWS_DGV(); //dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[0].Value = "Total";
            m_PASS_VALUES_DGV(dataGridView1.Rows[0].Cells[0].Value.ToString(), 0);//pasa el valor a otros dgvs
            m_DIASMESESANOST_Refresh(CED1_fechaI, CED1_fechaF);
            //m_TOTALES();
            tabcontrol.SelectedIndex = 0;
        }
        public void m_DIASMESESANOST_Refresh(string fecha_inicio, string fecha_final) /////////////////////////////se usa en todos 
        {
            #region separar fechas
            int fecha_inicio_dia = Convert.ToInt32(fecha_inicio.Substring(0, 2));
            int fecha_inicio_mes = Convert.ToInt32(fecha_inicio.Substring(3, 2));
            int fecha_inicio_ano = Convert.ToInt32(fecha_inicio.Substring(6, 4));

            int fecha_final_dia = Convert.ToInt32(fecha_final.Substring(0, 2));
            int fecha_final_mes = Convert.ToInt32(fecha_final.Substring(3, 2));
            int fecha_final_ano = Convert.ToInt32(fecha_final.Substring(6, 4));
            #endregion

            #region añomes
            int i = 1; calculos = 1;
            for (; fecha_inicio_ano <= fecha_final_ano; fecha_inicio_ano++)
            {
                if (fecha_inicio_mes <= fecha_final_mes)
                {
                    for (; fecha_inicio_mes <= fecha_final_mes; fecha_inicio_mes++, i++)
                        try
                        {
                            m_TABS(fecha_inicio_mes, fecha_inicio_ano);/////////////////////se usa en todos
                            
                            m_VENTATOTALT(fecha_inicio_mes, fecha_inicio_ano);
                            m_GASTOTOTAL(fecha_inicio_mes, fecha_inicio_ano, i);
                            m_QUERYS_DGVT(fecha_inicio_mes, fecha_inicio_ano, i);
                            //m_CALCULOS(i);
                            m_rebajas(fecha_inicio_mes, fecha_inicio_ano, i);
                            m_CALCULOS(i);
                            m_margenIimporte(fecha_inicio_mes, fecha_inicio_ano, i);
                            m_margenFimporte(fecha_inicio_mes, fecha_inicio_ano, i);
                            m_dpp(fecha_inicio_mes, fecha_inicio_ano, i);
						
                            tabcontrol.Visible = true;
                            tabcontrol.SelectedIndex = tabcontrol.SelectedIndex + 1;
                        }
                        catch (Exception x)
                        { MessageBox.Show("Error con las fechas " + x); }
                }
                if (fecha_final_mes < fecha_inicio_mes && fecha_inicio_ano != fecha_final_ano)
                {
                    for (; fecha_inicio_mes <= 12; fecha_inicio_mes++, i++)
                        try
                        {
                            m_TABS(fecha_inicio_mes, fecha_inicio_ano);
                            //m_VENTATOTALT(fecha_inicio_mes, fecha_inicio_ano);
                            //m_GASTOTOTAL(fecha_inicio_mes, fecha_inicio_ano,i);
                            //m_QUERYS_DGVT(fecha_inicio_mes, fecha_inicio_ano, i);
                            //m_CALCULOS(i);
                            m_VENTATOTALT(fecha_inicio_mes, fecha_inicio_ano);
                            m_GASTOTOTAL(fecha_inicio_mes, fecha_inicio_ano, i);
                            m_QUERYS_DGVT(fecha_inicio_mes, fecha_inicio_ano, i);
                            m_margenIimporte(fecha_inicio_mes, fecha_inicio_ano, i);
                            m_margenFimporte(fecha_inicio_mes, fecha_inicio_ano, i);
                            m_CALCULOS(i);
                            m_dpp(fecha_inicio_mes, fecha_inicio_ano, i);

                            tabcontrol.Visible = true;
                            tabcontrol.SelectedIndex = tabcontrol.SelectedIndex + 1;
                        }
                        catch (Exception x)
                        { MessageBox.Show("Error con las fechas " + x); }
                }
                fecha_inicio_mes = 1;
            }
            #endregion
        }
        public Cedula3(bool genera)
        {
            generarcedula3 = genera;
            InitializeComponent();
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
        }
        private void checaConexion()
        {
            if (Conn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    Conn.Open();
                }
                catch (MySqlException ex)
                {
                    if (ex.ErrorCode == -2147467259)
                    {
                        while (Conn.State != System.Data.ConnectionState.Open)
                        {
                            try
                            {
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

        private void bgw_Pasarcedula_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {

                Cedula7 c7 = new Cedula7(true);
                c7.ShowDialog();
                //c7.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}