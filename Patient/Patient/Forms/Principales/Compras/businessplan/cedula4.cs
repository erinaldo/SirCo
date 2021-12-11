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
//using nmExcel = Microsoft.Office.Interop.Excel;

namespace business_plan
{
    public partial class cedula4 : Form
    {
        #region variables conexion
        MySqlConnection Conn, connCipsis;
        
        string query;
        MySqlCommand cmd;
        MySqlDataReader reader, reader2;

        //private string conexion = "SERVER=localhost; DATABASE=dwh; user=root; PASSWORD= ;";
        //private string conexion2 = "SERVER=localhost; DATABASE=cipsis; user=root; PASSWORD= ;";
        private string conexion = "SERVER=" + Properties.Settings.Default.server + "; DATABASE=dwh; user=" + Properties.Settings.Default.usuario + "; PASSWORD=" + Properties.Settings.Default.pass + ";";
        private string conexion2 = "SERVER=" + Properties.Settings.Default.server + "; DATABASE=cipsis; user=" + Properties.Settings.Default.usuario + "; PASSWORD=" + Properties.Settings.Default.pass + ";";
        #endregion
        #region variables_globales
        private string[] idd = new string[1000];
        private string[] meses = new string[12];
        //private string[] anios = new string[100];
        private string[] pagoMeses, colmeses;
        DateTime FechaAF = DateTime.Now, FechaAI = DateTime.Now;
        DateTime FechaActF = DateTime.Now, FechaActI = DateTime.Now;
        string idproveedor = "", soloCalzado = "";
        double Inventariodeseado = 0, rotacion = 0;
        string[] anios;
        int numMes = 0;
        #endregion variables_globales
        #region variables escenario
        string CED1_estruct = "";
        string CED1_estruct2 = "";
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
        string marcavarios = " ";
        string divisiones = " ";
        string idsucursal = " ";
        string iddivision = " ";
        string iddepto = " ";
        string idfamilia = " ";
        string idlinea = " ";
        string idl1 = " ";
        string idl2 = " ";
        string idl3 = " ";
        string idl4 = " ";
        string idl5 = " ";
        string idl6 = " ";
        string marca = " ";
        string[] wherequery = new string[1000];
        string division = "", depto = "", fam = "", linea = "", subl1, subl2, subl3, subl4, subl5, subl6, mark;
        string s, d, dd, f, l, l1, l2, l3, l4, l5, l6, m;
        bool total = true, editando = false;
        string[] queryguardar = new string[1000];
        string[] querycargar = new string[1000];
        string queryunidadesAsignadas = " ";
        bool cargando = false;
        bool solototal = true;
        string solocalzadoDropdown = "";
        string dropdownmarca = "";
        string solocalzadowhere = " ";
        string whereSQL = "";
        // 8==D
        int seleccion_sucursal = 0; int seleccion_division = 0; int seleccion_proveedor = 0;
        int seleccion_depto = 0; int seleccion_familia = 0;
        int seleccion_linea = 0; int seleccion_l1 = 0;
        int seleccion_l2 = 0; int seleccion_l3 = 0;
        int seleccion_l4 = 0; int seleccion_l5 = 0;
        int seleccion_l6 = 0; int seleccion_marca = 0;
        #endregion
        #region variables cedula carlos
        double[] rebajasI=new double[1000];
        double[] cuentasXpagar=new double[1000];
        double[] cobros=new double[1000];
        double[] importe=new double[1000];
        double[] costo=new double[1000];
        double[] precio=new double[1000];
        double enero2 = 0;
        double febrero2 = 0;
        double marzo2 = 0;
        double abril2 = 0;
        double mayo2 = 0;
        double junio2 = 0;
        double julio2 = 0;
        double agosto2 = 0;
        double septiembre2 = 0;
        double octubre2 = 0;
        double noviembre2 = 0;
        double diciembre2 = 0;
        double dpma = 0;
        double[] comprasN = new double[1000];
        double[] plazomediopagos = new double[1000];
        double plazomedioCobros = 0;
        double[] RCuentasxPagar=new double[1000];
        int[] idsucursales = new int[1000];
        //double rotacion = 0;
        DateTime mes = DateTime.Now;
        string mesNombre = "";
        string[] idprovedores=new string[1000];
        string[] Wherequery = new string[1000];
        double[] importediasFin=new double[1000];
        double[] diasFin = new double[1000];
        double[] utilidadDF=new double[1000];
        int cantidadmes = 0;
        string queryparte2 = "";
        #endregion
        public cedula4()
        {
            InitializeComponent();
            #region Abrir conexion
            Conn = new MySqlConnection(conexion);
            try { Conn.Open(); } catch (MySqlException ex) { MessageBox.Show(ex.ToString()); }
            #endregion
            #region Abrir conexion cipsis
            connCipsis = new MySqlConnection(conexion2);
            try { connCipsis.Open(); } catch (MySqlException ex) { MessageBox.Show(ex.ToString()); }
            #endregion Abrir conexion cipsis
        }
        private void cedula4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void cedula4_Load(object sender, EventArgs e)
        {
            M_pintarcolumnas();
            m_ESCENARIO(Properties.Settings.Default.escenario);

            //string[] colmeses = m_saca_meses(FechaActI, FechaActF).Split('_');
            pagoMeses = m_saca_meses(FechaActI, FechaActF).Split('_');
            colmeses = m_saca_meses(FechaActI, FechaActF).Split('_');
            anios = m_saca_anios(FechaActI, FechaActF).Split('_');
            foreach (string m in pagoMeses) //Recorre los meses encontrados
            {
                // parrilla de pagos
                m_agrega_columna(m.Replace('*', ' '), dgvCed2);             //historico
                m_agrega_columna(m.Replace('*', ' ') + " proy", dgvCed2);   //proyectado
                m_agrega_columna(m.Replace('*', ' ') + " total", dgvCed2);  //total

                //parrilla de porcentaje editable 
                m_agrega_columna(m.Replace('*', ' '), dgvPorEd);
                //MessageBox.Show(m);
            }
            
            //Asignacion de medidas principales
            if (this.Width < 900) cbProveedor.Width = 200; else cbProveedor.Width = 323;
            panBotones.Left = (panBotonesCont.ClientSize.Width - panBotones.Width) / 2;
            int borde = 20;
            botGuardar.Left = this.Width - (botGuardar.Width + borde);

            m_dropdown_sucursales(); //Llena combo sucursales //AB_CAMBIOS_03ENE15
            m_dropdown_proveedores(); //Llena combo proveedores //AB_CAMBIOS_03ENE15

            //if (seleccion_sucursal != -1)  {
            //    cbSucursales.SelectedIndex = m_indexCBsucursal(m_retNomSucursal(seleccion_sucursal.ToString("D2")));
            //}//AB_CAMBIOS_03ENE15

            //if (seleccion_proveedor != -1) {
            //    cbProveedor.SelectedIndex = m_indexCBproveedor(m_retNomProveedor(seleccion_proveedor.ToString("D2")));
            //}//AB_CAMBIOS_03ENE15

            editando = true; //se cambia a true para que el usuario aplique nuevos calculos

            //Llena parrilla de Porcentaje editable
            dgvPorEd.Refresh(); dgvPorEd.Rows.Add(); dgvPorEd.Rows[0].Cells[0].Value = "UNICO";
            dgvPorEd.Refresh(); dgvPorEd.Rows.Add(); dgvPorEd.Rows[1].Cells[0].Value = "DIFERIDO";

            //valores de prueba para Porcentaje editable
            //string[] anios = m_saca_anios(FechaActI, FechaActF).Split('_');   //Calcula años
            //foreach (string anio in anios)
            //{
                foreach (string m in pagoMeses) //Recorre los meses encontrados
                {
                    int col = m_num_col(m, dgvPorEd);
                    dgvPorEd.Rows[0].Cells[col].Value = "50"; //unico
                    dgvPorEd.Rows[1].Cells[col].Value = "50"; //diferido
                }
            //}
        }
     
        public cedula4(int selecc_sucursal, int selecc_division, int selecc_depto, int selecc_familia,
                        int selecc_linea, int selecc_l1, int selecc_l2, int selecc_l3, int selecc_l4,
                        int selecc_l5, int selecc_l6, int selecc_marca)
        {
            InitializeComponent();
            #region Abrir conexion
            Conn = new MySqlConnection(conexion);
            try{ Conn.Open(); } catch (MySqlException ex){ MessageBox.Show(ex.ToString()); }
            #endregion
            #region Abrir conexion cipsis
            connCipsis = new MySqlConnection(conexion2);
            try { connCipsis.Open(); } catch (MySqlException ex) { MessageBox.Show(ex.ToString()); }
            #endregion Abrir conexion cipsis

            #region valoresform
            seleccion_sucursal = -1;//m_seleccion_cedula4(Properties.Settings.Default.escenario); //AB_CAMBIOS_03ENE15
            seleccion_proveedor = -1;
            //MessageBox.Show("seleccionado = " + seleccion_sucursal.ToString());
            //seleccion_sucursal = selecc_sucursal;
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
            #endregion

        }

        #region menu botones
        private void button2_Click_1(object sender, EventArgs e)
        {
            Cedula1 c1 = new Cedula1(seleccion_sucursal, seleccion_division, seleccion_depto, seleccion_familia, seleccion_linea, seleccion_l1, seleccion_l2, seleccion_l3, seleccion_l4, seleccion_l5, seleccion_l6, seleccion_marca.ToString());
            c1.Show(); this.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Cedula2 c2 = new Cedula2(seleccion_sucursal, seleccion_division, seleccion_depto, seleccion_familia, seleccion_linea, seleccion_l1, seleccion_l2, seleccion_l3, seleccion_l4, seleccion_l5, seleccion_l6, seleccion_marca.ToString());
            c2.Show(); this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Cedula3 c3 = new Cedula3(seleccion_sucursal, seleccion_division, seleccion_depto, seleccion_familia, seleccion_linea, seleccion_l1, seleccion_l2, seleccion_l3, seleccion_l4, seleccion_l5, seleccion_l6, seleccion_marca.ToString());
            c3.Show(); this.Close();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            cedula5 c5 = new cedula5(seleccion_sucursal, seleccion_division, seleccion_depto, seleccion_familia, seleccion_linea, seleccion_l1, seleccion_l2, seleccion_l3, seleccion_l4, seleccion_l5, seleccion_l6, seleccion_marca.ToString());
            c5.Show(); this.Hide();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            //cedula6 c6 = new cedula6(seleccion_sucursal, seleccion_division, seleccion_depto, seleccion_familia, seleccion_linea, seleccion_l1, seleccion_l2, seleccion_l3, seleccion_l4, seleccion_l5, seleccion_l6, seleccion_marca.ToString());
            cedula6 c6 = new cedula6();
            c6.Show(); this.Hide();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            //Cedula7 c7 = new Cedula7(seleccion_sucursal, seleccion_division, seleccion_depto, seleccion_familia, seleccion_linea, seleccion_l1, seleccion_l2, seleccion_l3, seleccion_l4, seleccion_l5, seleccion_l6, seleccion_marca.ToString());
            Cedula7 c7 = new Cedula7();
            c7.Show(); this.Close();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            //Cedula8 c8 = new Cedula8(seleccion_sucursal, seleccion_division, seleccion_depto, seleccion_familia, seleccion_linea, seleccion_l1, seleccion_l2, seleccion_l3, seleccion_l4, seleccion_l5, seleccion_l6, seleccion_marca.ToString());
            Cedula8 c8 = new Cedula8();
            c8.Show(); this.Close();
        }
        #endregion menu botones
        #region estructuras_combos
        private void cbSucursales_DropDown(object sender, EventArgs e)
        {            
            m_dropdown_sucursales();
        }
        private void cbSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_selectIndex_sucursales();
        }
        private void cbProveedor_DropDown(object sender, EventArgs e)
        {
            m_dropdown_proveedores();
        }
        private void cbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_selectIndex_proveedores();
        }
        #endregion estructuras_combos
        #region dropdown_combos 
        //AB_CAMBIOS_03ENE15
        private void m_dropdown_sucursales()
        {
            cbSucursales.Items.Clear();
            cbSucursales.Items.Add("Total");
            int i = 1;
            query = "SELECT descrip,idsucursal from sucursal where visible='S'";
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbSucursales.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["idsucursal"].ToString();
                i++;
            }
            reader.Close();
        }
        private void m_dropdown_proveedores()
        {
            int i = 0;
            cbProveedor.Items.Clear();
            cbProveedor.Items.Add("Total");
            query = "SELECT DISTINCT raz_soc,idproveedor FROM proveedo WHERE raz_soc<>'*'";
            cmd = new MySqlCommand(query, connCipsis); reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbProveedor.Items.Add(reader["raz_soc"].ToString());
                idprovedores[i]=reader["idproveedor"].ToString();
            }
            reader.Close();
        }
        #endregion dropdown_combos
        #region select_combos
        private void m_selectIndex_sucursales()
        {
            pagoMeses = m_saca_meses(FechaActI, FechaActF).Split('_');
            if (cbSucursales.Text != "Total")
            {
                total = false;
                query = "SELECT descrip,idsucursal from sucursal where visible='S' and idsucursal=" + idd[cbSucursales.SelectedIndex] + "";
                Wherequery[0] = " V.idsucursal=" + idd[cbSucursales.SelectedIndex];
                idsucursales[0] = int.Parse(idd[cbSucursales.SelectedIndex]);
            }
            else
            {
                for (int i = 0; i <= cbSucursales.Items.Count - 2; i++)
                {
                    Wherequery[i] = " V.idsucursal=" + idd[(i + 1)];
                    idsucursales[i] = int.Parse(idd[(i + 1)]);
                }
                total = true;
                query = "SELECT descrip,idsucursal from sucursal where visible='S'";
            }
            m_cargargrid(total);
        }
        private void m_selectIndex_proveedores()
        {
            pagoMeses = m_saca_meses(FechaActI, FechaActF).Split('_');
            if (cbSucursales.SelectedIndex == -1)
            {
                //MessageBox.Show(cbSucursales.Text);
                cbSucursales.Items.Clear();
                cbSucursales.Items.Add("Total");
                int i = 1;
                string q = "SELECT descrip,idsucursal from sucursal where visible='S'";
                cmd = new MySqlCommand(q, Conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbSucursales.Items.Add(reader["descrip"].ToString());
                    idd[i] = reader["idsucursal"].ToString();
                    i++;
                } //cbSucursales.Text = "Total";
                reader.Close();
            }

            if (cbSucursales.Text != "Total" && cbSucursales.Text != "" && cbSucursales.Text != null)
            {
                total = false;
                query = "SELECT descrip,idsucursal from sucursal where visible='S' and idsucursal=" + idd[cbSucursales.SelectedIndex] + "";
            }
            else
            {
                total = true;
                query = "SELECT descrip,idsucursal from sucursal where visible='S'";
            }

            if (cbProveedor.Text != "Total")
            {
                //total = false;
                idproveedor = " AND s.idproveedor=" + m_ret_idProveedor(cbProveedor.Text);
            }
            else
            {
                //total = true;
                idproveedor = "";
            }
            m_cargargrid(total);
        }
        #endregion select_combos

        private void m_ESCENARIO(string escenario)
        {
            DateTime a = DateTime.Now, f = DateTime.Now;
            string ESC = "SELECT fechainicialA, fechafinalA,fechainicial,fechafinal,solocalzado FROM escenarios WHERE nombre = '" + escenario + "' LIMIT 1";
            cmd = new MySqlCommand(ESC, Conn);
            cmd.CommandTimeout = 0;//pos solucion
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                a = DateTime.Parse(reader["fechainicial"].ToString());
                f = DateTime.Parse(reader["fechafinal"].ToString());
                FechaAI = DateTime.Parse(reader["fechainicialA"].ToString());
                FechaAF = DateTime.Parse(reader["fechafinalA"].ToString());
                FechaActI = a; FechaActF = f;
                label9.Text = "Escenario: " + escenario;
                label10.Text = "Fecha inicial " + a.ToString("yyyy-MM-dd");
                label11.Text = "Fecha final  " + f.ToString("yyyy-MM-dd");
                //string sCalzado = reader["solocalzado"].ToString();
                if (reader["solocalzado"].ToString() == "1") { soloCalzado = "AND v.iddivisiones=1"; } else { soloCalzado = ""; }
                CED1_fechaI = FechaAI.ToString("dd-MM-yyyy");
                CED1_fechaF = FechaAF.AddDays(-1).ToString("dd-MM-yyyy");
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
        private void m_cargargrid(bool Total)
        {
            int i = 0;
            queryparte2 = query;
            dgvCed2.Rows.Clear();
            if (total == true) { dgvCed2.Rows.Add(); dgvCed2.Rows[0].Cells[0].Value = "Total"; i = 1; } //Agrega renglon para total
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dgvCed2.Refresh(); dgvCed2.Rows.Add();
                dgvCed2.Rows[i].Cells[0].Value = reader["descrip"].ToString();
                dgvCed2.Rows[i].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B4FF8F");               //Renglon TOTAL
                if (total == true) //Agrega renglones para los pagos
                {
                    dgvCed2.Rows[0].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7FE2E");
                    dgvCed2.Rows.Add(); dgvCed2.Rows[++i].Cells[0].Value = "Pago Unico";
                    dgvCed2.Rows[i].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");    //Renglon PAGO UNICO
                    dgvCed2.Rows.Add(); dgvCed2.Rows[++i].Cells[0].Value = "Pago Diferido";
                    dgvCed2.Rows[i].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");    //Renglon PAGO DIFERIDO                                                                                                    
                }
                i++;
            }
            dgvCed2.Refresh(); //MessageBox.Show("llena renglones");
            reader.Close();

            if (editando == false)
            {
                //calculos de inicio
                #region comprobar existente
                string q = "SELECT nombre FROM cedula5a WHERE nombre='" + Properties.Settings.Default.escenario + "'";
                bool c = true;
                cmd = new MySqlCommand(q, Conn); reader = cmd.ExecuteReader();
                if (reader.HasRows) { c = true; } else { c = false; }
                reader.Close();
                #endregion comprobar existente
                #region llenaDatos
                if (c == false)
                {
                    #region calculos_anteriores
                    /*if (total == false) //Agrega renglones adicionales cuando no sea total
                    {
                        dgvCed2.Rows.Add(); dgvCed2.Rows[i].Cells[0].Value = "Pago Unico";
                        dgvCed2.Rows[i].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");    //Renglon PAGO UNICO
                        dgvCed2.Rows.Add(); dgvCed2.Rows[++i].Cells[0].Value = "Pago Diferido";
                        dgvCed2.Rows[i].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");    //Renglon PAGO DIFERIDO
                        //dgvCed2.Rows.Add(); dgvCed2.Rows[++i].Cells[0].Value = "Pago Unico C/Factoraje";
                        //dgvCed2.Rows.Add(); dgvCed2.Rows[++i].Cells[0].Value = "Pago Diferido C/Factoraje";

                        m_asignacion_mensual_sucursal(int.Parse(idd[cbSucursales.SelectedIndex]));
                    }
                    else
                    {
                        for (i = 1; i < dgvCed2.Rows.Count; i++)
                        {
                            if (idd[i] != null)
                            {
                                string nombreSuc = m_retNomSucursal(int.Parse(idd[i]).ToString("D2")); //extrae el nombre de la sucursal
                                int renglon = m_sucursal_ren(nombreSuc, dgvCed2); //extrae el renglon donde se localiza la sucursal                            
                                m_asignacion_mensual_total(int.Parse(idd[i]), renglon);
                            }
                        }
                        m_asignacion_mensual_sumaTotal(); //asigna valores totales para todas las sucursales
                    }*/
                    #endregion calculos_anteriores
                    calculos(i);
                }
                else
                {
                    // Consulta cedula4
                    if (total == true)
                    {
                        #region consulta_anterior_total
                        /*int x = 0, ant = 0; double valor = 0;
                        for (i = 1; i <= dgvCed2.Rows.Count - 1; i++)
                        {
                            x = 0; ant = 0; valor = 0;
                            int numsuc = int.Parse(m_retSucursal(dgvCed2.Rows[i].Cells[0].Value.ToString()));
                            //MessageBox.Show(dgvCed2.Rows[i].Cells[0].Value.ToString());
                            q = "SELECT * FROM cedula5a WHERE nombre='" + Properties.Settings.Default.escenario + "' AND idsucursal=" + numsuc.ToString();
                            cmd = new MySqlCommand(q, Conn); reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                for (x = 1; x <= 12; x++) // Recorre los 12 meses del grid
                                {
                                    valor = double.Parse(m_retPagos(reader["mes" + x.ToString()].ToString(), 1));    // total historico
                                    dgvCed2.Rows[i].Cells[x + ant].Value = valor.ToString("C2");
                                    valor = double.Parse(m_retPagos(reader["mes" + x.ToString()].ToString(), 2));           // total proyectado
                                    dgvCed2.Rows[i].Cells[(x + 1) + ant].Value = valor.ToString("C2");
                                    ant = x;
                                }
                            }
                            reader.Close();
                        }

                        // totales de sucursal por mes
                        ant = 0; double valor2 = 0;
                        for (x = 1; x <= 12; x++)
                        {
                            valor = 0; valor2 = 0;
                            for (i = 1; i <= dgvCed2.Rows.Count - 1; i++)
                            {
                                valor += double.Parse(dgvCed2.Rows[i].Cells[x + ant].Value.ToString(), NumberStyles.Currency);
                                valor2 += double.Parse(dgvCed2.Rows[i].Cells[(x + 1) + ant].Value.ToString(), NumberStyles.Currency);
                            }
                            dgvCed2.Rows[0].Cells[x + ant].Value = valor.ToString("C2");            //suma para total historico
                            dgvCed2.Rows[0].Cells[(x + 1) + ant].Value = valor2.ToString("C2");     //suma para total proyectado

                            ant = x;
                        }*/
                        #endregion consulta_anterior_total
                        for (int r = 1; r < cbSucursales.Items.Count; r++) //recorre por mes todos los renglones(sucursales encontradas)
                        {
                            string idsuc = m_retSucursal(cbSucursales.Items[r].ToString()).ToString(), saldos = "";
                            int renglon = m_sucursal_ren(cbSucursales.Items[r].ToString(), dgvCed2);
                            int mes = 0, anio = 0; double valor = 0; double[] porEd = { 0, 0 };

                            foreach (string m in colmeses)
                            {
                                if (anios.Length > 1)
                                {
                                    string[] mesPartes = m.Split(' ');
                                    mes = m_numero_mes(mesPartes[0]);
                                    anio = int.Parse(mesPartes[1]);
                                }
                                else
                                {
                                    mes = m_numero_mes(m);
                                    anio = int.Parse(anios[0]);
                                }

                                int[] cols = { 0, 0, 0, 0 };                    //historico, proyectado, total, PorEditable
                                cols[0] = m_num_col(m, dgvCed2);                //valor historico
                                cols[1] = m_num_col(m + " proy", dgvCed2);      //valor proyectado
                                cols[2] = m_num_col(m + " total", dgvCed2);     //valor total
                                cols[3] = m_num_col(m, dgvPorEd);               //valor PorEditable

                                saldos = m_retDato("SELECT saldos FROM cedula5a WHERE nombre='" + Properties.Settings.Default.escenario + "' AND idsucursal=" + idsuc + " AND mes=" + mes + " AND anio=" + anio, "saldos", conexion);
                                porEd[0] = double.Parse(m_retDato("SELECT PorcEdUni FROM cedula5a WHERE nombre='" + Properties.Settings.Default.escenario + "' AND idsucursal=" + idsuc + " AND mes=" + mes + " AND anio=" + anio, "PorcEdUni", conexion));
                                porEd[1] = double.Parse(m_retDato("SELECT PorcEdDif FROM cedula5a WHERE nombre='" + Properties.Settings.Default.escenario + "' AND idsucursal=" + idsuc + " AND mes=" + mes + " AND anio=" + anio, "PorcEdDif", conexion));

                                valor = double.Parse(m_retPagos(saldos, 1));
                                dgvCed2.Rows[renglon].Cells[cols[0]].Value = valor.ToString("C2");  // total historico
                                valor = double.Parse(m_retPagos(saldos, 2));
                                dgvCed2.Rows[renglon].Cells[cols[1]].Value = valor.ToString("C2");  // total proyectado
                                valor = double.Parse(m_retPagos(saldos, 3));
                                dgvCed2.Rows[renglon].Cells[cols[2]].Value = valor.ToString("C2");  // suma total
                                valor = double.Parse(m_retPagos(saldos, 4));
                                dgvCed2.Rows[renglon + 1].Cells[cols[0]].Value = valor.ToString("C2");  // pago unico historico
                                valor = double.Parse(m_retPagos(saldos, 5));
                                dgvCed2.Rows[renglon + 1].Cells[cols[1]].Value = valor.ToString("C2");  // pago unico proyectado
                                valor = double.Parse(m_retPagos(saldos, 6));
                                dgvCed2.Rows[renglon + 1].Cells[cols[2]].Value = valor.ToString("C2");  // suma pago unico
                                valor = double.Parse(m_retPagos(saldos, 7));
                                dgvCed2.Rows[renglon + 2].Cells[cols[0]].Value = valor.ToString("C2");  // pago diferido historico
                                valor = double.Parse(m_retPagos(saldos, 8));
                                dgvCed2.Rows[renglon + 2].Cells[cols[1]].Value = valor.ToString("C2");  // pago diferido proyectado
                                valor = double.Parse(m_retPagos(saldos, 9));
                                dgvCed2.Rows[renglon + 2].Cells[cols[2]].Value = valor.ToString("C2");  // suma pago diferido

                                dgvPorEd.Rows[0].Cells[cols[3]].Value = porEd[0].ToString();  // asigna porcentaje editable unico de ese mes
                                dgvPorEd.Rows[1].Cells[cols[3]].Value = porEd[1].ToString();  // asigna porcentaje editable diferido de ese mes

                            }

                        }
                        m_asignacion_mensual_sumaTotal();
                    }
                    else
                    {
                        #region consulta_anterior_sucursal
                        /*dgvCed2.Rows.Add(); dgvCed2.Rows[i].Cells[0].Value = "Pago Unico";
                        dgvCed2.Rows.Add(); dgvCed2.Rows[++i].Cells[0].Value = "Pago Diferido";
                        dgvCed2.Rows.Add(); dgvCed2.Rows[++i].Cells[0].Value = "Pago Unico C/Factoraje";
                        dgvCed2.Rows.Add(); dgvCed2.Rows[++i].Cells[0].Value = "Pago Diferido C/Factoraje";

                        int x = 0, ant = 0; double valor = 0;

                        int numsuc = int.Parse(m_retSucursal(dgvCed2.Rows[0].Cells[0].Value.ToString()));
                        //MessageBox.Show(dgvCed2.Rows[i].Cells[0].Value.ToString());
                        q = "SELECT * FROM cedula5a WHERE nombre='" + Properties.Settings.Default.escenario + "' AND idsucursal=" + numsuc.ToString();
                        cmd = new MySqlCommand(q, Conn); reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            for (x = 1; x <= 12; x++) // Recorre los 12 meses del grid
                            {
                                valor = double.Parse(m_retPagos(reader["mes" + x.ToString()].ToString(), 1));    // total historico
                                dgvCed2.Rows[0].Cells[x + ant].Value = valor.ToString("C2");
                                valor = double.Parse(m_retPagos(reader["mes" + x.ToString()].ToString(), 2));    // total proyectado
                                dgvCed2.Rows[0].Cells[(x + 1) + ant].Value = valor.ToString("C2");
                                valor = double.Parse(m_retPagos(reader["mes" + x.ToString()].ToString(), 3));    // pago unico historico
                                dgvCed2.Rows[1].Cells[x + ant].Value = valor.ToString("C2");
                                valor = double.Parse(m_retPagos(reader["mes" + x.ToString()].ToString(), 4));    // pago unico proyectado
                                dgvCed2.Rows[1].Cells[(x + 1) + ant].Value = valor.ToString("C2");
                                valor = double.Parse(m_retPagos(reader["mes" + x.ToString()].ToString(), 5));    // pago diferido historico
                                dgvCed2.Rows[2].Cells[x + ant].Value = valor.ToString("C2");
                                valor = double.Parse(m_retPagos(reader["mes" + x.ToString()].ToString(), 6));    // pago diferido proyectado
                                dgvCed2.Rows[2].Cells[(x + 1) + ant].Value = valor.ToString("C2");
                                valor = double.Parse(m_retPagos(reader["mes" + x.ToString()].ToString(), 7));    // pago unico con factoraje historico
                                dgvCed2.Rows[3].Cells[x + ant].Value = valor.ToString("C2");
                                valor = double.Parse(m_retPagos(reader["mes" + x.ToString()].ToString(), 8));    // pago unico con factoraje proyectado
                                dgvCed2.Rows[3].Cells[(x + 1) + ant].Value = valor.ToString("C2");
                                valor = double.Parse(m_retPagos(reader["mes" + x.ToString()].ToString(), 9));    // pago diferido con factoraje historico
                                dgvCed2.Rows[4].Cells[x + ant].Value = valor.ToString("C2");
                                valor = double.Parse(m_retPagos(reader["mes" + x.ToString()].ToString(), 10));   // pago diferido con factoraje proyectado
                                dgvCed2.Rows[4].Cells[(x + 1) + ant].Value = valor.ToString("C2");
                                ant = x;
                            }
                        }
                        reader.Close();
                        */
                        #endregion consulta_anterior_sucursal

                        dgvCed2.Rows.Add(); dgvCed2.Rows[i].Cells[0].Value = "Pago Unico";
                        dgvCed2.Rows[i].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");    //Renglon PAGO UNICO
                        dgvCed2.Rows.Add(); dgvCed2.Rows[++i].Cells[0].Value = "Pago Diferido";
                        dgvCed2.Rows[i].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");    //Renglon PAGO DIFERIDO

                        string idsuc = m_retSucursal(cbSucursales.Text).ToString(), saldos = "";
                        int renglon = m_sucursal_ren(cbSucursales.Text, dgvCed2);
                        int mes = 0, anio = 0; double valor = 0; double[] porEd = { 0, 0 };

                        foreach (string m in colmeses)
                        {
                            if (anios.Length > 1)
                            {
                                string[] mesPartes = m.Split(' ');
                                mes = m_numero_mes(mesPartes[0]);
                                anio = int.Parse(mesPartes[1]);
                            }
                            else
                            {
                                mes = m_numero_mes(m);
                                anio = int.Parse(anios[0]);
                            }

                            int[] cols = { 0, 0, 0, 0 };                    //historico, proyectado, total, PorEditable
                            cols[0] = m_num_col(m, dgvCed2);                //valor historico
                            cols[1] = m_num_col(m + " proy", dgvCed2);      //valor proyectado
                            cols[2] = m_num_col(m + " total", dgvCed2);     //valor total
                            cols[3] = m_num_col(m, dgvPorEd);               //valor PorEditable

                            saldos = m_retDato("SELECT saldos FROM cedula5a WHERE nombre='" + Properties.Settings.Default.escenario + "' AND idsucursal=" + idsuc + " AND mes=" + mes + " AND anio=" + anio, "saldos", conexion);
                            porEd[0] = double.Parse(m_retDato("SELECT PorcEdUni FROM cedula5a WHERE nombre='" + Properties.Settings.Default.escenario + "' AND idsucursal=" + idsuc + " AND mes=" + mes + " AND anio=" + anio, "PorcEdUni", conexion));
                            porEd[1] = double.Parse(m_retDato("SELECT PorcEdDif FROM cedula5a WHERE nombre='" + Properties.Settings.Default.escenario + "' AND idsucursal=" + idsuc + " AND mes=" + mes + " AND anio=" + anio, "PorcEdDif", conexion));

                            valor = double.Parse(m_retPagos(saldos, 1));
                            dgvCed2.Rows[renglon].Cells[cols[0]].Value = valor.ToString("C2");  // total historico
                            valor = double.Parse(m_retPagos(saldos, 2));
                            dgvCed2.Rows[renglon].Cells[cols[1]].Value = valor.ToString("C2");  // total proyectado
                            valor = double.Parse(m_retPagos(saldos, 3));
                            dgvCed2.Rows[renglon].Cells[cols[2]].Value = valor.ToString("C2");  // suma total
                            valor = double.Parse(m_retPagos(saldos, 4));
                            dgvCed2.Rows[renglon + 1].Cells[cols[0]].Value = valor.ToString("C2");  // pago unico historico
                            valor = double.Parse(m_retPagos(saldos, 5));
                            dgvCed2.Rows[renglon + 1].Cells[cols[1]].Value = valor.ToString("C2");  // pago unico proyectado
                            valor = double.Parse(m_retPagos(saldos, 6));
                            dgvCed2.Rows[renglon + 1].Cells[cols[2]].Value = valor.ToString("C2");  // suma pago unico
                            valor = double.Parse(m_retPagos(saldos, 7));
                            dgvCed2.Rows[renglon + 2].Cells[cols[0]].Value = valor.ToString("C2");  // pago diferido historico
                            valor = double.Parse(m_retPagos(saldos, 8));
                            dgvCed2.Rows[renglon + 2].Cells[cols[1]].Value = valor.ToString("C2");  // pago diferido proyectado
                            valor = double.Parse(m_retPagos(saldos, 9));
                            dgvCed2.Rows[renglon + 2].Cells[cols[2]].Value = valor.ToString("C2");  // suma pago diferido

                            dgvPorEd.Rows[0].Cells[cols[3]].Value = porEd[0].ToString();  // asigna porcentaje editable unico de ese mes
                            dgvPorEd.Rows[1].Cells[cols[3]].Value = porEd[1].ToString();  // asigna porcentaje editable diferido de ese mes
                        }
                    }
                }
                #endregion llenaDatos

            }
            else //si se hace algun cambio hace calculos normales
            {
                calculos(i);
            }
            cargaPartedos();
        }
        public void calculos(int i)
        {
            if (total == false) //Agrega renglones adicionales cuando no sea total
            {
                dgvCed2.Rows.Add(); dgvCed2.Rows[i].Cells[0].Value = "Pago Unico";
                dgvCed2.Rows[i].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");    //Renglon PAGO UNICO
                dgvCed2.Rows.Add(); dgvCed2.Rows[++i].Cells[0].Value = "Pago Diferido";
                dgvCed2.Rows[i].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");    //Renglon PAGO DIFERIDO
                //dgvCed2.Rows.Add(); dgvCed2.Rows[++i].Cells[0].Value = "Pago Unico C/Factoraje";
                //dgvCed2.Rows.Add(); dgvCed2.Rows[++i].Cells[0].Value = "Pago Diferido C/Factoraje";

                m_asignacion_mensual_sucursal(int.Parse(idd[cbSucursales.SelectedIndex]));
            }
            else
            {
                for (i = 1; i < dgvCed2.Rows.Count; i++)
                {
                    if (idd[i] != null)
                    {
                        string nombreSuc = m_retNomSucursal(int.Parse(idd[i]).ToString("D2")); //extrae el nombre de la sucursal
                        int renglon = m_sucursal_ren(nombreSuc, dgvCed2); //extrae el renglon donde se localiza la sucursal                            
                        m_asignacion_mensual_total(int.Parse(idd[i]), renglon);
                    }
                }
                m_asignacion_mensual_sumaTotal(); //asigna valores totales para todas las sucursales
            }
        }

        public void m_asignacion_mensual_sucursal(int i)
        {
            string sucursal = " s.sucursal = '" + i.ToString("D2") + "'";
            m_cedula1_datos(Properties.Settings.Default.escenario.ToString());
            double val = 0;
            //string tmp = ""; foreach (string p in pagoMeses) { tmp += "\n" + p; } MessageBox.Show("ANTES" + tmp);            
            
            foreach (string anio in anios)
            {                
                //PAGO UNICO
                query = "SELECT " + m_query_meses(FechaActI, FechaActF, "s", int.Parse(anio)) + " FROM saldoprovsuc AS s INNER JOIN proveedo AS p ON s.idproveedor = p.idproveedor WHERE p.tipo='PAGOUNICO' AND " + sucursal + " AND s.ejercicio = " + anio + " " + idproveedor + ";";
                cmd = new MySqlCommand(query, connCipsis);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    string[] meses = m_saca_meses_anio(FechaActI, FechaActF,int.Parse(anio)).Split('_');
                    foreach (string m in meses)
                    {                        
                        int[] cols = { 0, 0, 0 , 0}; //historico, proyectado, total, porcEditable
                        if (anios.Length > 1)
                        {
                            cols[0] = m_num_col(m + " " + anio, dgvCed2);
                            cols[1] = m_num_col(m + " " + anio + " proy", dgvCed2);
                            cols[2] = m_num_col(m + " " + anio + " total", dgvCed2);
                            cols[3] = m_num_col(m + " " + anio, dgvPorEd);
                        }
                        else
                        {
                            cols[0] = m_num_col(m, dgvCed2);
                            cols[1] = m_num_col(m + " proy", dgvCed2);
                            cols[2] = m_num_col(m + " total", dgvCed2);
                            cols[3] = m_num_col(m, dgvPorEd);
                        }
                        
                        // asigna valor historico para el mes
                        if (reader[m].ToString() == "" || reader[m] == null) { val = 0; } else { val = double.Parse(reader[m].ToString()); }
                        dgvCed2.Rows[1].Cells[cols[0]].Value = val.ToString("C2");

                        // asigna valor proyectado
                        decimal valunico = 0; double porUni = 0; //valor extraido de la celda "UNICO" por mes(tabla porcentual inferior)
                        if ((string)dgvPorEd.Rows[0].Cells[cols[3]].Value == null) { valunico = 0; }
                        else { valunico = decimal.Parse(dgvPorEd.Rows[0].Cells[cols[3]].Value.ToString(), NumberStyles.Currency); }
                        porUni = double.Parse(valunico.ToString()); 
                        val = m_proyect_mensual(i, m_numero_mes(m), int.Parse(anio), porUni,"unico");
                        dgvCed2.Rows[1].Cells[cols[1]].Value = val.ToString("C2"); //MessageBox.Show("val = " + val.ToString());

                        // asigna valor en celda total
                        if ((string)dgvCed2.Rows[1].Cells[cols[1]].Value == null) { valunico = 0; }
                        else { valunico = decimal.Parse(dgvCed2.Rows[1].Cells[cols[0]].Value.ToString(), NumberStyles.Currency); }
                        //MessageBox.Show(valunico.ToString() + " + " + val.ToString() + " = " + (double.Parse(valunico.ToString()) + val).ToString("C2"));
                        dgvCed2.Rows[1].Cells[cols[2]].Value = (double.Parse(valunico.ToString()) + val).ToString("C2"); //suma total del proyectado + historico

                        
                    }
                }
                reader.Close();

                //PAGO DIFERIDO
                query = "SELECT " + m_query_meses(FechaActI, FechaActF, "s", int.Parse(anio)) + " FROM saldoprovsuc AS s INNER JOIN proveedo AS p ON s.idproveedor = p.idproveedor WHERE p.tipo='PAGODIF' AND " + sucursal + " AND s.ejercicio = " + anio + " " + idproveedor + ";";
                cmd = new MySqlCommand(query, connCipsis);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string[] meses = m_saca_meses_anio(FechaActI, FechaActF, int.Parse(anio)).Split('_');
                    foreach (string m in meses)
                    {
                        int[] cols = { 0, 0, 0, 0 }; //historico, proyectado, total, porcEditable
                        if (anios.Length > 1)
                        {
                            cols[0] = m_num_col(m + " " + anio, dgvCed2);
                            cols[1] = m_num_col(m + " " + anio + " proy", dgvCed2);
                            cols[2] = m_num_col(m + " " + anio + " total", dgvCed2);
                            cols[3] = m_num_col(m + " " + anio, dgvPorEd);
                        }
                        else
                        {
                            cols[0] = m_num_col(m, dgvCed2);
                            cols[1] = m_num_col(m + " proy", dgvCed2);
                            cols[2] = m_num_col(m + " total", dgvCed2);
                            cols[3] = m_num_col(m, dgvPorEd);
                        }
                        // asigna valor historico para el mes
                        if (reader[m].ToString() == "" || reader[m] == null) { val = 0; } else { val = double.Parse(reader[m].ToString()); }
                        dgvCed2.Rows[2].Cells[cols[0]].Value = val.ToString("C2");

                        decimal valunico = 0; double porUni = 0; //valor extraido de la celda "DIFERIDO" por mes(tabla porcentual inferior)

                        //Realiza sumatoria una vez que tiene el unico tambien para la columna HISTORICO
                        if ((string)dgvCed2.Rows[1].Cells[cols[0]].Value == null) { valunico = 0; }
                        else { valunico = decimal.Parse(dgvCed2.Rows[1].Cells[cols[0]].Value.ToString(), NumberStyles.Currency); }
                        dgvCed2.Rows[0].Cells[cols[0]].Value = (double.Parse(valunico.ToString()) + val).ToString("C2"); //suma unico y diferid
                        
                        // asigna valor proyectado                        
                        if ((string)dgvPorEd.Rows[1].Cells[cols[3]].Value == null) { valunico = 0; }
                        else { valunico = decimal.Parse(dgvPorEd.Rows[1].Cells[cols[3]].Value.ToString(), NumberStyles.Currency); }
                        porUni = double.Parse(valunico.ToString());
                        val = m_proyect_mensual(i, m_numero_mes(m), int.Parse(anio), porUni, "diferido");
                        dgvCed2.Rows[2].Cells[cols[1]].Value = val.ToString("C2");

                        // asigna valor en celda total
                        if ((string)dgvCed2.Rows[2].Cells[cols[1]].Value == null) { valunico = 0; }
                        else { valunico = decimal.Parse(dgvCed2.Rows[2].Cells[cols[0]].Value.ToString(), NumberStyles.Currency); }
                        dgvCed2.Rows[2].Cells[cols[2]].Value = (double.Parse(valunico.ToString()) + val).ToString("C2"); //suma total del proyectado + historico

                        // *************************************************************************************************************
                        // RENGLON TOTAL POR SUCURSAL (una vez que tiene todos los datos asigna valores totales)
                        // asigna TOTAL para pagos proyectados
                        decimal valdif = 0;
                        valunico = decimal.Parse(dgvCed2.Rows[1].Cells[cols[1]].Value.ToString(), NumberStyles.Currency);
                        valdif = decimal.Parse(dgvCed2.Rows[2].Cells[cols[1]].Value.ToString(), NumberStyles.Currency);
                        dgvCed2.Rows[0].Cells[cols[1]].Value = (valunico + valdif).ToString("C2");

                        // asigna TOTAL para suma hitorico y proyectado en ambos pagos
                        valunico = decimal.Parse(dgvCed2.Rows[1].Cells[cols[2]].Value.ToString(), NumberStyles.Currency);
                        valdif = decimal.Parse(dgvCed2.Rows[2].Cells[cols[2]].Value.ToString(), NumberStyles.Currency);
                        dgvCed2.Rows[0].Cells[cols[2]].Value = (valunico + valdif).ToString("C2");
                        // *************************************************************************************************************
                                                
                    }
                }
                reader.Close();                

            }
            //MessageBox.Show("numero de meses = " + numMes);
            //tmp = ""; foreach (string p in pagoMeses) { tmp += "\n" + p; } MessageBox.Show("AHORA"+tmp);

            #region calculoAnterior
            /*
            string aniosSQL = m_retAnios(FechaActI, FechaActF);                     // Calcula años
            string pagUni = "p.tipo='PAGOUNICO' AND p.aceptafactoraje=0";           // PAGO UNICO
            string pagDif = "p.tipo='PAGODIF' AND p.aceptafactoraje=0";             // PAGO DIFERIDO
            string pagUniFac = "p.tipo='PAGOUNICO' AND p.aceptafactoraje=1";        // PAGO UNICO CON FACTORAJE
            string pagDifFac = "p.tipo='PAGODIF' AND p.aceptafactoraje=1";          // PAGO DIFERIDO CON FACTORAJE
            int ant = 0, mes = 0, x = 0;  //"ant" usado para sumar el numero de mes anterior para el grid
            string sucursal = " s.sucursal = '" + i.ToString("D2") + "'";
            double Ced1 = m_cedula1_datos(Properties.Settings.Default.escenario.ToString());
            
            //PAGOS DE LA SUCURSAL
            query = "SELECT " + m_query_meses(FechaActI, FechaActF, "s") + " FROM saldoprovsuc AS s INNER JOIN proveedo AS p ON s.idproveedor = p.idproveedor WHERE " + sucursal + " " + aniosSQL + " " + idproveedor + ";";
            cmd = new MySqlCommand(query, connCipsis);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string[] meses = m_saca_meses(FechaActI, FechaActF).Split('_'); double val = 0, valproy = 0;
                for (x = 1; x <= 12; x++) // Recorre los 12 meses del grid
                {
                    dgvCed2.Rows[0].Cells[x + ant].Value = val.ToString("C2"); //reinicia a 0 por si no encuentra dichos meses con valor
                    foreach (string m in meses) //Recorre los meses encontrados
                    {
                        mes = m_numero_mes(m);
                        if (x == mes) //si encuentra el mes comparado al del recorrido le asigna el valor a la celda
                        { 
                            if (reader[m].ToString() == "" || reader[m] == null) { val = 0; } else { val = double.Parse(reader[m].ToString()); }
                            dgvCed2.Rows[0].Cells[x + ant].Value = val.ToString("C2");
                        }
                    }
                    
                    //valor proyectado  
                    //MessageBox.Show("entra a proy mens");     
                    valproy = m_proyect_mensual(i, x, FechaAI.Year, Ced1);
                    dgvCed2.Rows[0].Cells[(x + 1) + ant].Value = valproy.ToString("C2");                        
                    
                    ant = x; val = 0;
                }
            }
            reader.Close();


            // PAGO UNICO
            ant = 0; mes = 0; x = 0;
            query = "SELECT " + m_query_meses(FechaActI, FechaActF, "s") + " FROM saldoprovsuc AS s INNER JOIN proveedo AS p ON s.idproveedor = p.idproveedor WHERE " + pagUni + " AND " + sucursal + " " + aniosSQL + " " + idproveedor + ";";
            cmd = new MySqlCommand(query, connCipsis);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string[] meses = m_saca_meses(FechaActI, FechaActF).Split('_'); double val = 0, valproy=0;
                for (x = 1; x <= 12; x++) // Recorre los 12 meses del grid
                {
                    dgvCed2.Rows[1].Cells[x + ant].Value = val.ToString("C2"); //reinicia a 0 por si no encuentra dichos meses con valor
                    foreach (string m in meses)
                    {
                        mes = m_numero_mes(m);
                        if (x == m_numero_mes(m)) { //si encuentra el mes comparado al del recorrido le asigna el valor a la celda
                            if (reader[m].ToString() == "" || reader[m] == null) { val = 0; } else { val = double.Parse(reader[m].ToString()); }
                            dgvCed2.Rows[1].Cells[x + ant].Value = val.ToString("C2"); 
                        }
                    }

                    //if (x == 1) {                                        
                    decimal pagTotal = decimal.Parse(dgvCed2.Rows[0].Cells[x + ant].Value.ToString(), NumberStyles.Currency); //pago total
                    decimal pagProy = decimal.Parse(dgvCed2.Rows[0].Cells[(x + 1) + ant].Value.ToString(), NumberStyles.Currency); //pago proyectado
                    double valPagUn = 0;
                    if (pagTotal != 0)
                    {
                        valPagUn = (double.Parse(val.ToString()) / double.Parse(pagTotal.ToString())) * double.Parse(pagProy.ToString());
                    }                    
                    dgvCed2.Rows[1].Cells[(x + 1) + ant].Value = valPagUn.ToString("C2");
                    //}

                    ant = x; val = 0;
                }                                
            }
            reader.Close();

            // PAGO DIFERIDO
            ant = 0; mes = 0; x = 0;
            query = "SELECT " + m_query_meses(FechaActI, FechaActF, "s") + " FROM saldoprovsuc AS s INNER JOIN proveedo AS p ON s.idproveedor = p.idproveedor WHERE " + pagDif + " AND " + sucursal + " " + aniosSQL + " " + idproveedor + ";";
            cmd = new MySqlCommand(query, connCipsis);
            reader = cmd.ExecuteReader(); 
            while (reader.Read())
            {
                string[] meses = m_saca_meses(FechaActI, FechaActF).Split('_'); double val = 0;
                for (x = 1; x <= 12; x++) // Recorre los 12 meses del grid
                {
                    dgvCed2.Rows[2].Cells[x + ant].Value = val.ToString("C2"); //reinicia a 0 por si no encuentra dichos meses con valor
                    foreach (string m in meses)
                    {
                        mes = m_numero_mes(m);
                        if (x == m_numero_mes(m)) //si encuentra el mes comparado al del recorrido le asigna el valor a la celda
                        {
                            if (reader[m].ToString() == "" || reader[m] == null) { val = 0; } else { val = double.Parse(reader[m].ToString()); }
                            dgvCed2.Rows[2].Cells[x + ant].Value = val.ToString("C2");
                        }
                    }

                    decimal pagTotal = decimal.Parse(dgvCed2.Rows[0].Cells[x + ant].Value.ToString(), NumberStyles.Currency); //pago total
                    decimal pagProy = decimal.Parse(dgvCed2.Rows[0].Cells[(x + 1) + ant].Value.ToString(), NumberStyles.Currency); //pago proyectado
                    double valPagDif = 0;
                    if (pagTotal != 0)
                    {
                        valPagDif = (double.Parse(val.ToString()) / double.Parse(pagTotal.ToString())) * double.Parse(pagProy.ToString());
                    }
                    dgvCed2.Rows[2].Cells[(x + 1) + ant].Value = valPagDif.ToString("C2");
                    
                    ant = x; val = 0;
                }
            }
            reader.Close();

            // PAGO UNICO CON FACTORAJE
            ant = 0; mes = 0; x = 0;
            query = "SELECT " + m_query_meses(FechaActI, FechaActF, "s") + " FROM saldoprovsuc AS s INNER JOIN proveedo AS p ON s.idproveedor = p.idproveedor WHERE " + pagUniFac + " AND " + sucursal + " " + aniosSQL + " " + idproveedor + ";";
            cmd = new MySqlCommand(query, connCipsis);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string[] meses = m_saca_meses(FechaActI, FechaActF).Split('_'); double val = 0;
                for (x = 1; x <= 12; x++) // Recorre los 12 meses del grid
                {
                    dgvCed2.Rows[3].Cells[x + ant].Value = val.ToString("C2"); //reinicia a 0 por si no encuentra dichos meses con valor
                    foreach (string m in meses)
                    {
                        mes = m_numero_mes(m);
                        if (x == m_numero_mes(m)) //si encuentra el mes comparado al del recorrido le asigna el valor a la celda
                        {
                            if (reader[m].ToString() == "" || reader[m] == null) { val = 0; } else { val = double.Parse(reader[m].ToString()); }
                            dgvCed2.Rows[3].Cells[x + ant].Value = val.ToString("C2");
                        }
                    }

                    decimal pagTotal = decimal.Parse(dgvCed2.Rows[0].Cells[x + ant].Value.ToString(), NumberStyles.Currency); //pago total
                    decimal pagProy = decimal.Parse(dgvCed2.Rows[0].Cells[(x + 1) + ant].Value.ToString(), NumberStyles.Currency); //pago proyectado
                    double valUFac = 0;
                    if (pagTotal != 0)
                    {
                        valUFac = (double.Parse(val.ToString()) / double.Parse(pagTotal.ToString())) * double.Parse(pagProy.ToString());
                    }
                    dgvCed2.Rows[3].Cells[(x + 1) + ant].Value = valUFac.ToString("C2");

                    ant = x; val = 0;
                }
            }
            reader.Close();

            // PAGO DIFERIDO CON FACTORAJE
            ant = 0; mes = 0; x = 0;
            query = "SELECT " + m_query_meses(FechaActI, FechaActF, "s") + " FROM saldoprovsuc AS s INNER JOIN proveedo AS p ON s.idproveedor = p.idproveedor WHERE " + pagDifFac + " AND " + sucursal + " " + aniosSQL + " " + idproveedor + ";";
            cmd = new MySqlCommand(query, connCipsis);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string[] meses = m_saca_meses(FechaActI, FechaActF).Split('_'); double val = 0;
                for (x = 1; x <= 12; x++) // Recorre los 12 meses del grid
                {
                    dgvCed2.Rows[4].Cells[x + ant].Value = val.ToString("C2"); //reinicia a 0 por si no encuentra dichos meses con valor
                    foreach (string m in meses)
                    {
                        mes = m_numero_mes(m);
                        if (x == m_numero_mes(m)) //si encuentra el mes comparado al del recorrido le asigna el valor a la celda
                        {
                            if (reader[m].ToString() == "" || reader[m] == null) { val = 0; } else { val = double.Parse(reader[m].ToString()); }
                            dgvCed2.Rows[4].Cells[x + ant].Value = val.ToString("C2");
                        }
                    }

                    decimal pagTotal = decimal.Parse(dgvCed2.Rows[0].Cells[x + ant].Value.ToString(), NumberStyles.Currency); //pago total
                    decimal pagProy = decimal.Parse(dgvCed2.Rows[0].Cells[(x + 1) + ant].Value.ToString(), NumberStyles.Currency); //pago proyectado
                    double valDFac = 0;
                    if (pagTotal != 0)
                    {
                        valDFac = (double.Parse(val.ToString()) / double.Parse(pagTotal.ToString())) * double.Parse(pagProy.ToString());
                    }
                    dgvCed2.Rows[4].Cells[(x + 1) + ant].Value = valDFac.ToString("C2");

                    ant = x; val = 0;
                }
            }
            reader.Close();            
            */
            #endregion calculoAnterior
        }
        public void m_asignacion_mensual_total(int i, int ren)
        {
            string sucursal = " s.sucursal = '" + i.ToString("D2") + "'";
            m_cedula1_datos(Properties.Settings.Default.escenario.ToString());
            double val = 0;             
            //string tmp = ""; foreach (string p in pagoMeses) { tmp += "\n" + p; } MessageBox.Show("ANTES" + tmp);

            foreach (string anio in anios)
            {
                //PAGO UNICO
                query = "SELECT " + m_query_meses(FechaActI, FechaActF, "s", int.Parse(anio)) + " FROM saldoprovsuc AS s INNER JOIN proveedo AS p ON s.idproveedor = p.idproveedor WHERE p.tipo='PAGOUNICO' AND " + sucursal + " AND s.ejercicio = " + anio + " " + idproveedor + ";";
                cmd = new MySqlCommand(query, connCipsis);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    string[] meses = m_saca_meses_anio(FechaActI, FechaActF, int.Parse(anio)).Split('_');
                    foreach (string m in meses)
                    {
                        int[] cols = { 0, 0, 0, 0 }; //historico, proyectado, total, porcEditable
                        if (anios.Length > 1)
                        {
                            cols[0] = m_num_col(m + " " + anio, dgvCed2);
                            cols[1] = m_num_col(m + " " + anio + " proy", dgvCed2);
                            cols[2] = m_num_col(m + " " + anio + " total", dgvCed2);
                            cols[3] = m_num_col(m + " " + anio, dgvPorEd);
                        }
                        else
                        {
                            cols[0] = m_num_col(m, dgvCed2);
                            cols[1] = m_num_col(m + " proy", dgvCed2);
                            cols[2] = m_num_col(m + " total", dgvCed2);
                            cols[3] = m_num_col(m, dgvPorEd);
                        }

                        // asigna valor historico para el mes
                        if (reader[m].ToString() == "" || reader[m] == null) { val = 0; } else { val = double.Parse(reader[m].ToString()); }
                        dgvCed2.Rows[ren+1].Cells[cols[0]].Value = val.ToString("C2");

                        // asigna valor proyectado
                        decimal valunico = 0; double porUni = 0; //valor extraido de la celda "UNICO" por mes(tabla porcentual inferior)
                        if ((string)dgvPorEd.Rows[0].Cells[cols[3]].Value == null) { valunico = 0; }
                        else { valunico = decimal.Parse(dgvPorEd.Rows[0].Cells[cols[3]].Value.ToString(), NumberStyles.Currency); }
                        porUni = double.Parse(valunico.ToString());
                        val = m_proyect_mensual(i, m_numero_mes(m), int.Parse(anio), porUni, "unico");
                        dgvCed2.Rows[ren + 1].Cells[cols[1]].Value = val.ToString("C2");

                        // asigna valor en celda total
                        if ((string)dgvCed2.Rows[ren + 1].Cells[cols[1]].Value == null) { valunico = 0; }
                        else { valunico = decimal.Parse(dgvCed2.Rows[ren + 1].Cells[cols[0]].Value.ToString(), NumberStyles.Currency); }
                        dgvCed2.Rows[ren + 1].Cells[cols[2]].Value = (double.Parse(valunico.ToString()) + val).ToString("C2"); //suma total del proyectado + historico
                    }
                }
                reader.Close();
                
                //PAGO DIFERIDO
                query = "SELECT " + m_query_meses(FechaActI, FechaActF, "s", int.Parse(anio)) + " FROM saldoprovsuc AS s INNER JOIN proveedo AS p ON s.idproveedor = p.idproveedor WHERE p.tipo='PAGODIF' AND " + sucursal + " AND s.ejercicio = " + anio + " " + idproveedor + ";";
                cmd = new MySqlCommand(query, connCipsis);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string[] meses = m_saca_meses_anio(FechaActI, FechaActF, int.Parse(anio)).Split('_');
                    foreach (string m in meses)
                    {
                        int[] cols = { 0, 0, 0, 0 }; //historico, proyectado, total, porcEditable
                        if (anios.Length > 1)
                        {
                            cols[0] = m_num_col(m + " " + anio, dgvCed2);
                            cols[1] = m_num_col(m + " " + anio + " proy", dgvCed2);
                            cols[2] = m_num_col(m + " " + anio + " total", dgvCed2);
                            cols[3] = m_num_col(m + " " + anio, dgvPorEd);
                        }
                        else
                        {
                            cols[0] = m_num_col(m, dgvCed2);
                            cols[1] = m_num_col(m + " proy", dgvCed2);
                            cols[2] = m_num_col(m + " total", dgvCed2);
                            cols[3] = m_num_col(m, dgvPorEd);
                        }
                        // asigna valor historico para el mes
                        if (reader[m].ToString() == "" || reader[m] == null) { val = 0; } else { val = double.Parse(reader[m].ToString()); }
                        dgvCed2.Rows[ren + 2].Cells[cols[0]].Value = val.ToString("C2");

                        decimal valunico = 0; double porUni = 0; //valor extraido de la celda "DIFERIDO" por mes(tabla porcentual inferior)

                        //Realiza sumatoria una vez que tiene el unico tambien para la columna HISTORICO
                        if ((string)dgvCed2.Rows[ren + 1].Cells[cols[0]].Value == null) { valunico = 0; }
                        else { valunico = decimal.Parse(dgvCed2.Rows[ren + 1].Cells[cols[0]].Value.ToString(), NumberStyles.Currency); }
                        dgvCed2.Rows[ren].Cells[cols[0]].Value = (double.Parse(valunico.ToString()) + val).ToString("C2"); //suma unico y diferid

                        // asigna valor proyectado (renglon DIFERIDO)                        
                        if ((string)dgvPorEd.Rows[1].Cells[cols[3]].Value == null) { valunico = 0; }
                        else { valunico = decimal.Parse(dgvPorEd.Rows[1].Cells[cols[3]].Value.ToString(), NumberStyles.Currency); }
                        porUni = double.Parse(valunico.ToString());
                        val = m_proyect_mensual(i, m_numero_mes(m), int.Parse(anio), porUni, "diferido");
                        dgvCed2.Rows[ren + 2].Cells[cols[1]].Value = val.ToString("C2");

                        // asigna valor en celda total (renglon DIFERIDO)
                        if ((string)dgvCed2.Rows[ren + 2].Cells[cols[1]].Value == null) { valunico = 0; }
                        else { valunico = decimal.Parse(dgvCed2.Rows[ren + 2].Cells[cols[0]].Value.ToString(), NumberStyles.Currency); }
                        dgvCed2.Rows[ren + 2].Cells[cols[2]].Value = (double.Parse(valunico.ToString()) + val).ToString("C2"); //suma total del proyectado + historico

                        // *************************************************************************************************************
                        // RENGLON TOTAL POR SUCURSAL (una vez que tiene todos los datos asigna valores totales)
                        // asigna TOTAL para pagos proyectados por sucursal
                        decimal valdif = 0;
                        valunico = decimal.Parse(dgvCed2.Rows[ren + 1].Cells[cols[1]].Value.ToString(), NumberStyles.Currency);
                        valdif = decimal.Parse(dgvCed2.Rows[ren + 2].Cells[cols[1]].Value.ToString(), NumberStyles.Currency);
                        dgvCed2.Rows[ren].Cells[cols[1]].Value = (valunico + valdif).ToString("C2");

                        // asigna TOTAL para suma historico y proyectado en ambos pagos
                        valunico = decimal.Parse(dgvCed2.Rows[ren + 1].Cells[cols[2]].Value.ToString(), NumberStyles.Currency);
                        valdif = decimal.Parse(dgvCed2.Rows[ren + 2].Cells[cols[2]].Value.ToString(), NumberStyles.Currency);
                        dgvCed2.Rows[ren].Cells[cols[2]].Value = (valunico + valdif).ToString("C2");

                        // *************************************************************************************************************

                        
                    }
                }
                reader.Close();
                
            }

            
        }
        public void m_asignacion_mensual_sumaTotal()
        {
            //REALIZA LA SUMATORIA DE TODAS LAS CELDAS DEL MES Y LO ASIGNA A RENGLON TOTAL
            decimal sumaHist = 0, sumaProy = 0, sumaTotal = 0;
            foreach (string m in colmeses)
            {
                int[] cols = { 0, 0, 0 }; //historico, proyectado, total
                cols[0] = m_num_col(m, dgvCed2);
                cols[1] = m_num_col(m + " proy", dgvCed2);
                cols[2] = m_num_col(m + " total", dgvCed2);


                for (int r = 1; r < cbSucursales.Items.Count; r++) //recorre por mes todos los renglones(sucursales encontradas)
                {
                    int renglon = m_sucursal_ren(cbSucursales.Items[r].ToString(), dgvCed2);
                    sumaHist += decimal.Parse((string)dgvCed2.Rows[renglon].Cells[cols[0]].Value.ToString(), NumberStyles.Currency);
                    sumaProy += decimal.Parse((string)dgvCed2.Rows[renglon].Cells[cols[1]].Value.ToString(), NumberStyles.Currency);
                    sumaTotal += decimal.Parse((string)dgvCed2.Rows[renglon].Cells[cols[2]].Value.ToString(), NumberStyles.Currency);
                }
                dgvCed2.Rows[0].Cells[cols[0]].Value = sumaHist.ToString("C2");
                dgvCed2.Rows[0].Cells[cols[1]].Value = sumaProy.ToString("C2");
                dgvCed2.Rows[0].Cells[cols[2]].Value = sumaTotal.ToString("C2");
            }
            

            #region sumaAnterior
            /*
            //string[] anios = m_saca_anios(FechaActI, FechaActF).Split('_');   //Calcula años
            string sucursal ="(";
            for (int i = 1; i <= dgvCed2.Rows.Count; i++)
            {
                if (i == 1) { if (idd[i] != null) sucursal += " s.sucursal='" + int.Parse(idd[i]).ToString("D2") + "' "; }
                else
                {
                    if (idd[i] != null) sucursal += " OR s.sucursal='" + int.Parse(idd[i]).ToString("D2") + "' ";
                }
            }
            sucursal += ")";

            foreach (string anio in anios)
            {
                query = "SELECT " + m_query_meses(FechaActI, FechaActF, "s", int.Parse(anio)) + " FROM saldoprovsuc AS s INNER JOIN proveedo AS p ON s.idproveedor = p.idproveedor WHERE " + sucursal + " AND s.ejercicio = " + anio + " " + idproveedor + ";";
                cmd = new MySqlCommand(query, connCipsis);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string[] meses = m_saca_meses(FechaActI, FechaActF).Split('_');
                    double suma = 0; 
                    foreach (string m in meses)
                    {
                        int[] cols = { 0, 0, 0 }; //historico, proyectado, total
                        if (anios.Length > 1)
                        {
                            cols[0] = m_num_col(m + " " + anio, dgvCed2);
                            cols[1] = m_num_col(m + " " + anio + " proy", dgvCed2);
                            cols[2] = m_num_col(m + " " + anio + " total", dgvCed2);
                        }
                        else
                        {
                            cols[0] = m_num_col(m, dgvCed2);
                            cols[1] = m_num_col(m + " proy", dgvCed2);
                            cols[2] = m_num_col(m + " total", dgvCed2);
                        }
                        if (reader[m].ToString() == "" || reader[m] == null) { suma = 0; } else { suma = double.Parse(reader[m].ToString()); }
                        dgvCed2.Rows[0].Cells[cols[0]].Value = suma.ToString("C2");

                        for (int i = 0; i < dgvCed2.Rows.Count; i++) //asignacion de suma hist+proy en columna total
                        {
                            decimal hist, proy; double tot;
                            
                            if ((string)dgvCed2.Rows[i].Cells[cols[0]].Value == null) { hist = 0; }
                            else { hist = decimal.Parse(dgvCed2.Rows[i].Cells[cols[0]].Value.ToString(), NumberStyles.Currency); }
                            
                            if ((string)dgvCed2.Rows[i].Cells[cols[1]].Value == null) { proy = 0; }
                            else { proy = decimal.Parse(dgvCed2.Rows[i].Cells[cols[1]].Value.ToString(), NumberStyles.Currency); }
                             
                            tot = double.Parse(hist.ToString()) + double.Parse(proy.ToString());
                            dgvCed2.Rows[i].Cells[cols[2]].Value = tot.ToString("C2");
                        }
                    }

                }
                reader.Close();
            }*/
            #endregion sumaAnterior
        }
        public double m_proyect_mensual(int suc, int mes, int anio, double PorcEd, string origen)
        {
            double compra = 0.0, unidadesrecibo = 0, SIunidades = 0, preciounitario = 0, impcompraMes = 0;
            string q = "SELECT unidadesrecibo, SIunidades, preciounitario FROM cedula3 WHERE nombre='" + Properties.Settings.Default.escenario.ToString() + "' AND mes=" + mes + " AND anio=" + anio + " AND idsucursal=" + suc + "";
            cmd = new MySqlCommand(q, Conn);
            reader2 = cmd.ExecuteReader();
            while (reader2.Read())
            {
                if (reader2["unidadesrecibo"].ToString() == "" || reader2["unidadesrecibo"].ToString() == null) { unidadesrecibo = 0.0; } else { unidadesrecibo = double.Parse(reader2["unidadesrecibo"].ToString()); }
                if (reader2["SIunidades"].ToString() == "" || reader2["SIunidades"].ToString() == null) { SIunidades = 0.0; } else { SIunidades = double.Parse(reader2["SIunidades"].ToString()); }
                if (reader2["preciounitario"].ToString() == "" || reader2["preciounitario"].ToString() == null) { preciounitario = 0.0; } else { preciounitario = double.Parse(reader2["preciounitario"].ToString()); }
            }
            reader2.Close();

            if (rotacion != 0) impcompraMes = 12 / rotacion;
            impcompraMes *= unidadesrecibo;
            impcompraMes += SIunidades;
            impcompraMes *= preciounitario;

            double plazo = 0;
            string valPlazo = m_retDato("SELECT AVG(e.diaspp) AS plazo FROM condicionesp AS e INNER JOIN proveedo AS s ON e.idproveedor=s.idproveedor WHERE e.diaspp<>0 " + idproveedor, "plazo", conexion2);
            if (valPlazo != "") { plazo = double.Parse(valPlazo); }

            double dias = double.Parse(m_retDato("SELECT dias FROM bancofactoraje LIMIT 1", "dias", conexion2));
            double factoraje = double.Parse(m_retDato("SELECT factoraje FROM bancofactoraje LIMIT 1", "factoraje", conexion2));


            compra = (dias + plazo) / 30; double mensualidades = compra;
            if (compra != 0) compra = (impcompraMes * (PorcEd / 100)) / compra; else compra = 0;
            compra *= (1 + (factoraje / 100));

            //si la compra es negativa igualamos a cero
            if (compra < 0) compra = 0;
            /*
            string[] cadmes = m_saca_meses_anio(FechaActI, FechaActF, anio).Split('_');
            if (mes == m_numero_mes(cadmes[0]))
            {
                decimal entero, dec;
                entero = Math.Truncate(decimal.Parse(mensualidades.ToString()));
                dec = decimal.Parse(mensualidades.ToString()) - entero;
                //MessageBox.Show("entero = " + entero + "\ndecimales = " + dec);
            }
            
            string m = m_nombre_mes(mes);
            if (anios.Length > 1) {
                if (pagoMeses[numMes] != m + " " + anio + "___pagos del mes " + m) { pagoMeses[numMes] = m + " " + anio + "___pagos del mes " + m; numMes++; }
            }
            else { if (pagoMeses[numMes] != m + "___pagos del mes " + m) { pagoMeses[numMes] = m + "___pagos del mes " + m; numMes++; } }
            
            decimal entero, dec;
            entero = Math.Truncate(decimal.Parse(mensualidades.ToString()));
            dec = decimal.Parse(mensualidades.ToString()) - entero; 
             */
            //MessageBox.Show("compra del mes de" + m_nombre_mes(mes) + " = " + compra.ToString());
            //sacamos la columna a ingresar los pagos
            int col = 0;
            if (anios.Length > 1) { col = m_num_col(m_nombre_mes(mes) + " " + anio, dgvPorEd); }
            else { col = m_num_col(m_nombre_mes(mes), dgvPorEd); }

            if (origen == "unico")
            {
                pagoMeses[col - 1] = m_cadenaPagos(mensualidades, compra, colmeses.Length, mes); //MessageBox.Show((col - 1).ToString());
                compra = sumatoria_mes(col - 1, col, origen);
            }
            else if (origen == "diferido")
            {
                pagoMeses[col - 1] = m_cadenaPagosDif(pagoMeses[col - 1], mes, mensualidades, compra, colmeses.Length);
                compra = sumatoria_mes(col - 1, col, origen);
            }

            return compra;
        }
        public string m_cadenaPagosDif(string cadOrigen, int mes, double mensualidad, double cantidad, int NoElem)
        {

            //if (mes == 9) { 
            //    MessageBox.Show("Sep"); }
            decimal entero, fraccion;
            entero = Math.Truncate(decimal.Parse(mensualidad.ToString()));
            fraccion = decimal.Parse(mensualidad.ToString()) - entero;


            //introduce cantidad equivalente de la fraccion
            //if (mes <= NoElem) pago += "_" + mes + "*" + (cantidad * double.Parse(fraccion.ToString())).ToString() + "*0";

            string nuevaCadPagos = ""; int i = 1;
            //actualiza un elemento de una cadena
            string[] partesPagosMens = cadOrigen.Split('_');
            foreach (string pagosMens in partesPagosMens)
            {
                string[] partesPagos = pagosMens.Split('*');

                if (mes <= NoElem) //revisa si esta en el rango de elementos
                {
                    if (i != 1) nuevaCadPagos += "_"; //si no es el primer elemento agrega delimitador de pagos "_"
                    if (i <= entero)
                    {

                        nuevaCadPagos += partesPagos[0] + "*" + partesPagos[1] + "*" + cantidad.ToString();
                    }
                    else
                    {
                        nuevaCadPagos += partesPagos[0] + "*" + partesPagos[1] + "*" + (cantidad * double.Parse(fraccion.ToString())).ToString();
                    }
                    i++;
                }
                mes++; //aumenta el mes 

            }
            return nuevaCadPagos;
        }

        public string m_retDato(string SQL, string campo, string datosConexion)
        {
            #region nueva_conexion
            MySqlCommand com;            
            MySqlConnection conector = new MySqlConnection(datosConexion); 
            try { conector.Open(); } catch (MySqlException ex) { MessageBox.Show(ex.ToString()); }
            MySqlDataReader readerLoc;
            #endregion nueva_conexion

            string retcampo = "";
            com = new MySqlCommand(SQL, conector);
            readerLoc = com.ExecuteReader();
            while (readerLoc.Read())
            {
                if (readerLoc[campo].ToString() == "" || readerLoc[campo].ToString() == null) { retcampo = ""; } else { retcampo = readerLoc[campo].ToString(); }                
            }
            readerLoc.Close(); conector.Close();
            return retcampo;
        }
        #region metodosNoUsados
        public double m_importeNetoTotalPorMes(int mes, int anio)
        {
            //Asigna nuevas fechas contando el primer dia del mes en f1 y el ultimo del mes en f2
            DateTime f1 = new DateTime(anio, mes, 1);
            DateTime f2 = new DateTime(anio, mes, DateTime.DaysInMonth(anio, mes));
            double imp = 0.0;
            string q = "SELECT SUM(v.impneto) AS total FROM ventasbase AS v INNER JOIN sucursal AS s ON v.idsucursal = s.idsucursal  INNER JOIN fecha AS f ON f.idfecha = v.idfecha WHERE f.fecha BETWEEN '" + f1.ToString("yyyy-MM-dd") + "'  AND '" + f2.ToString("yyyy-MM-dd") + "' " + soloCalzado + " AND " + m_todas_sucursales("s");
            cmd = new MySqlCommand(q, Conn);
            reader2 = cmd.ExecuteReader();
            while (reader2.Read())
            {
                if (reader2["total"].ToString() == "" || reader2["total"].ToString() == null) { imp = 0.0; }
                else { imp = double.Parse(reader2["total"].ToString()); }
            }
            reader2.Close();
            return imp;
        }        
        public double m_importeNetoSucursalPorMes(int mes, int anio, int suc)
        {
            double imp = 0.0;
            DateTime f1 = new DateTime(anio, mes, 1);
            DateTime f2 = new DateTime(anio, mes, DateTime.DaysInMonth(anio, mes));
            string q = "SELECT SUM(v.impneto) AS impsucursal FROM ventasbase AS v INNER JOIN sucursal AS s ON v.idsucursal = s.idsucursal  INNER JOIN fecha AS f ON f.idfecha = v.idfecha WHERE f.fecha BETWEEN '" + f1.ToString("yyyy-MM-dd") + "'  AND '" + f2.ToString("yyyy-MM-dd") + "' " + soloCalzado + " AND s.sucursal='" + suc.ToString("D2") + "'";
            cmd = new MySqlCommand(q, Conn);
            reader2 = cmd.ExecuteReader();
            while (reader2.Read())
            {
                if (reader2["impsucursal"].ToString() == "" || reader2["impsucursal"].ToString() == null) { imp = 0.0; }
                else { imp = double.Parse(reader2["impsucursal"].ToString()); }
            }
            reader2.Close();
            return imp;
        }
        public string m_retAnios(DateTime f1, DateTime f2)
        {
            string SQLanios = "";
            if (f1.Year != f2.Year)
            {
                SQLanios = " AND (s.ejercicio = " + f1.Year + " OR s.ejercicio = " + f2.Year + ")";
            }
            else
            {
                SQLanios = " AND s.ejercicio = " + f1.Year + "";
            }
            return SQLanios;
        }
        public double m_cedula3_campo(string escenario, int mes, int suc)
        {
            double impInicial = 0.0;
            string q = "SELECT SIimporte AS impInicial FROM cedula3 WHERE nombre='" + escenario + "' and mes=" + mes + " and idsucursal='" + suc.ToString("D2") + "'";
            cmd = new MySqlCommand(q, Conn);
            reader2 = cmd.ExecuteReader();
            while (reader2.Read())
            {
                if (reader2["impInicial"].ToString() == "" || reader2["impInicial"].ToString() == null) { impInicial = 0.0; } else { impInicial = double.Parse(reader2["impInicial"].ToString()); }
            }
            reader2.Close();
            return impInicial;
        }
        #endregion metodosNoUsados
        public void m_cedula1_datos(string escenario)
        {
            //double val = 0.0, preciopromedioUH = 0;
            string q = "SELECT Inventariodeseado, rotacion, preciopromedioUP FROM cedula1 WHERE nombre='" + escenario + "'";
            cmd = new MySqlCommand(q, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //if (reader["Inventariodeseado"].ToString() == "" || reader["Inventariodeseado"].ToString() == null) { Inventariodeseado = 0.0; } else { Inventariodeseado = double.Parse(reader["Inventariodeseado"].ToString()); }
                if (reader["rotacion"].ToString() == "" || reader["rotacion"].ToString() == null) { rotacion = 0.0; } else { rotacion = double.Parse(reader["rotacion"].ToString()); }
                //if (reader["preciopromedioUP"].ToString() == "" || reader["preciopromedioUP"].ToString() == null) { preciopromedioUH = 0.0; } else { preciopromedioUH = double.Parse(reader["preciopromedioUP"].ToString()); }

                /*//CALCULOS
                if (rotacion != 0)
                {
                    //val = (Inventariodeseado / (12 / rotacion)) * preciopromedioUH;
                    //val = 12 / rotacion;
                    val = Inventariodeseado / 12; // val;
                    val = val * preciopromedioUH;
                }
                else { val = 0.0; }*/
            }
            reader.Close();
            
        }        
        public string m_todas_sucursales(string alias)
        {
            string sucursal = "(";
            if (alias != "") { alias = alias + "."; }
            for (int i = 1; i <= dgvCed2.Rows.Count; i++)
            {
                if (i == 1) { if (idd[i] != null) sucursal += " " + alias + "sucursal='" + int.Parse(idd[i]).ToString("D2") + "' "; }
                else
                {
                    if (idd[i] != null) sucursal += " OR " + alias + "sucursal='" + int.Parse(idd[i]).ToString("D2") + "' ";
                }
            }
            sucursal += ")";
            return sucursal;
        }
        public string m_query_meses(DateTime f1, DateTime f2, string alias, int anio)
        {
            string meses = m_saca_meses_anio(f1, f2, anio), SQLmeses = " "; bool existe = false;
            if (alias != "") { alias = alias + "."; }
            existe = meses.Contains("Enero");
            if (existe == true) { SQLmeses += "SUM(" + alias + "enero) AS enero"; } 
            existe = meses.Contains("Febrero");
            if (existe == true) { if (SQLmeses != " ") { SQLmeses += ", "; } SQLmeses += "SUM(" + alias + "febrero) AS febrero"; }
            existe = meses.Contains("Marzo");
            if (existe == true) { if (SQLmeses != " ") { SQLmeses += ", "; } SQLmeses += "SUM(" + alias + "marzo) AS marzo"; }
            existe = meses.Contains("Abril");
            if (existe == true) { if (SQLmeses != " ") { SQLmeses += ", "; } SQLmeses += "SUM(" + alias + "abril) AS abril"; }
            existe = meses.Contains("Mayo");
            if (existe == true) { if (SQLmeses != " ") { SQLmeses += ", "; } SQLmeses += "SUM(" + alias + "mayo) AS mayo"; }
            existe = meses.Contains("Junio");
            if (existe == true) { if (SQLmeses != " ") { SQLmeses += ", "; } SQLmeses += "SUM(" + alias + "junio) AS junio"; }
            existe = meses.Contains("Julio");
            if (existe == true) { if (SQLmeses != "") { SQLmeses += ", "; } SQLmeses += "SUM(" + alias + "julio) AS julio"; }
            existe = meses.Contains("Agosto");
            if (existe == true) { if (SQLmeses != " ") { SQLmeses += ", "; } SQLmeses += "SUM(" + alias + "agosto) AS agosto"; }
            existe = meses.Contains("Septiembre");
            if (existe == true) { if (SQLmeses != " ") { SQLmeses += ", "; } SQLmeses += "SUM(" + alias + "septiembre) AS septiembre"; }
            existe = meses.Contains("Octubre");
            if (existe == true) { if (SQLmeses != " ") { SQLmeses += ", "; } SQLmeses += "SUM(" + alias + "octubre) AS octubre"; }
            existe = meses.Contains("Noviembre");
            if (existe == true) { if (SQLmeses != " ") { SQLmeses += ", "; } SQLmeses += "SUM(" + alias + "noviembre) AS noviembre"; }
            existe = meses.Contains("Diciembre");
            if (existe == true) { if (SQLmeses != " ") { SQLmeses += ", "; } SQLmeses += "SUM(" + alias + "diciembre) AS diciembre"; }

            return SQLmeses;
        }
        public string m_saca_meses(DateTime f1, DateTime f2)
        {
            int i = 1; bool existe = false; string meses = "";

            if (f1.Year != f2.Year)
            {   //Si los años de ambas fechas son diferentes
                //captura los meses de la primera fecha
                for (i = f1.Month; i <= 12; i++)
                {
                    if (i == f1.Month) { meses = m_nombre_mes(i) + " " + f1.Year.ToString(); }
                    else { meses += "_" + m_nombre_mes(i) + " " + f1.Year.ToString(); }
                }
                //captura los meses de la segunda fecha
                for (i = 1; i <= f2.Month; i++)
                {
                    //existe = meses.Contains(nombre_mes(i));
                    //if (existe == false) { meses += "_" + nombre_mes(i); }
                    meses += "_" + m_nombre_mes(i) + " " + f2.Year.ToString();
                }

                return meses;
            }
            else
            {   //si ambas fechas tienen el mismo año                
                if (f1.Month != f2.Month)   //si las fechas no tienen el mismo mes
                {
                    //captura los meses de ambas fechas
                    for (i = f1.Month; i <= f2.Month; i++)
                    {
                        if (i == f1.Month) { meses = m_nombre_mes(i); }
                        else
                        {
                            existe = meses.Contains(m_nombre_mes(i));
                            if (existe == false) { meses += "_" + m_nombre_mes(i); }
                        }
                    }
                }
                else { meses = m_nombre_mes(f1.Month); } //envia el mes de ambas fechas

                return meses;
            }
        }
        public string m_saca_meses_anio(DateTime f1, DateTime f2, int anio) //introduce el año a buscar
        {
            int i = 1; bool existe = false; string meses = ""; int FechaSacarAnio = 0;
            if (f1.Year == anio) { FechaSacarAnio = 1; } else if (f2.Year == anio) { FechaSacarAnio = 2; } //determina 1 para la fecha1 y 2 para la fecha2
            if (f1.Year != f2.Year) //Si los años de ambas fechas son diferentes
            {
                if (FechaSacarAnio == 1) // si desea el año de f1 captura sus meses
                {
                    for (i = f1.Month; i <= 12; i++)
                    {
                        if (i == f1.Month) { meses = m_nombre_mes(i); }
                        else { meses += "_" + m_nombre_mes(i); }
                    }
                }

                if (FechaSacarAnio == 2)  // si desea el año de f1 captura sus meses
                {
                    for (i = 1; i <= f2.Month; i++)
                    {
                        if (i == 1) { meses = m_nombre_mes(i); }
                        else { meses += "_" + m_nombre_mes(i); }
                    }
                }
                return meses;
            }
            else
            {   //si ambas fechas tienen el mismo año
                if (FechaSacarAnio != 0)
                {
                    if (f1.Month != f2.Month)   //si las fechas no tienen el mismo mes
                    {
                        //captura los meses de ambas fechas
                        for (i = f1.Month; i <= f2.Month; i++)
                        {
                            if (i == f1.Month) { meses = m_nombre_mes(i); }
                            else
                            {
                                existe = meses.Contains(m_nombre_mes(i));
                                if (existe == false) { meses += "_" + m_nombre_mes(i); }
                            }
                        }
                    }
                    else { meses = m_nombre_mes(f1.Month); } //envia el mes de ambas fechas
                }
                return meses;
            }
        }
        public string m_nombre_mes(int mes)
        {
            string mescad = "";
            switch (mes)
            {
                case 1: mescad = "Enero"; break;
                case 2: mescad = "Febrero"; break;
                case 3: mescad = "Marzo"; break;
                case 4: mescad = "Abril"; break;
                case 5: mescad = "Mayo"; break;
                case 6: mescad = "Junio"; break;
                case 7: mescad = "Julio"; break;
                case 8: mescad = "Agosto"; break;
                case 9: mescad = "Septiembre"; break;
                case 10: mescad = "Octubre"; break;
                case 11: mescad = "Noviembre"; break;
                case 12: mescad = "Diciembre"; break;

            } return mescad;
        }        
        public int m_numero_mes(string mes)
        {
            int mescad = 0;
            switch (mes)
            {
                case "Enero": mescad = 1; break;
                case "Febrero": mescad = 2 ; break;
                case "Marzo": mescad = 3; break;
                case "Abril": mescad = 4; break;
                case "Mayo": mescad = 5; break;
                case "Junio": mescad = 6; break;
                case "Julio": mescad = 7; break;
                case "Agosto": mescad = 8; break;
                case "Septiembre": mescad = 9; break;
                case "Octubre": mescad = 10; break;
                case "Noviembre": mescad = 11; break;
                case "Diciembre": mescad = 12; break;

            } return mescad;
        }        
        public string m_ret_idProveedor(string nombre) 
        {
            string retNombre = "";
            string queryprov= "SELECT idproveedor FROM proveedo WHERE raz_soc = '" + nombre + "'";
            cmd = new MySqlCommand(queryprov, connCipsis);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["idproveedor"].ToString() == "" || reader["idproveedor"] == null) { retNombre = ""; } else { retNombre = reader["idproveedor"].ToString(); }
                                
            }
            reader.Close();
            return retNombre;
        }        
        public int m_retSucursal(string suc)
        {
            int numSucursal = 0;
            string q = "SELECT idsucursal FROM sucursal WHERE descrip='" + suc + "'";
            cmd = new MySqlCommand(q, Conn); reader2 = cmd.ExecuteReader();
            while (reader2.Read())
            {
                if (reader2["idsucursal"].ToString() == "" || reader2["idsucursal"].ToString() == null) { numSucursal = 0; } else { numSucursal = int.Parse(reader2["idsucursal"].ToString()); }
            }
            reader2.Close();
            return numSucursal;
        }
        public string m_retNomSucursal(string suc)
        {
            string nomSucursal = "Total";
            string q = "SELECT descrip FROM sucursal WHERE idsucursal='" + suc + "' AND visible='S'";
            cmd = new MySqlCommand(q, Conn); reader2 = cmd.ExecuteReader();
            while (reader2.Read())
            {
                if (reader2["descrip"].ToString() == "" || reader2["descrip"].ToString() == null) { nomSucursal = "Total"; } else { nomSucursal = reader2["descrip"].ToString(); }
            }
            reader2.Close();
            return nomSucursal;
        }
        public string m_retNomProveedor(string idProv)
        {
            string nomProv = "Total";
            string q = "SELECT raz_soc FROM proveedo WHERE idproveedor=" + idProv + "";
            cmd = new MySqlCommand(q, connCipsis); reader2 = cmd.ExecuteReader();
            while (reader2.Read())
            {
                if (reader2["raz_soc"].ToString() == "" || reader2["raz_soc"].ToString() == null) { nomProv = "Total"; } else { nomProv = reader2["raz_soc"].ToString(); }
            }
            reader2.Close();
            return nomProv;
        }
        public int m_indexCBsucursal(string nombre_sucursal)
        {
            int index = 0;
            for (int i = 0; i < cbSucursales.Items.Count; i++)
            {
                if (nombre_sucursal == cbSucursales.Items[i].ToString()) { index = i; }
            }
            return index;
        }
        public int m_indexCBproveedor(string nombre_proveedor)
        {
            int index = 0;
            for (int i = 0; i < cbProveedor.Items.Count; i++)
            {
                if (nombre_proveedor == cbProveedor.Items[i].ToString()) { index = i; }
            }
            return index;
        }
        public bool m_existe_sucursal(int sucursal, int mes, int anio)
        {
            bool existe = false;
            string q = "SELECT idsucursal FROM cedula5a WHERE nombre='" + Properties.Settings.Default.escenario + "' AND idsucursal=" + sucursal + " AND mes=" + mes + " AND anio=" + anio;
            cmd = new MySqlCommand(q, Conn); reader2 = cmd.ExecuteReader();
            if (reader2.HasRows) { existe = true; } else { existe = false; }
            reader2.Close();
            return existe;
        }
        public int m_seleccion_cedula4(string escenario)  //revisa el campo "observaciones" en "cedula5a" y decide si es total o por sucursal de acuerdo al escenario
        {
            int i = 0; string val = ""; DateTime mayor = DateTime.Now; string[] res = { "total", "-1", "-1" }; // -1 cuando no encuentre registros
            query = "SELECT idcedula as fila,idsucursal,observaciones as ob FROM cedula5a WHERE nombre='" + escenario + "'";
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["ob"].ToString() != "" && reader["ob"].ToString() != null)
                {
                    val = reader["ob"].ToString();
                    string[] soloFecha = val.Split('_');
                    DateTime fecha = DateTime.Parse(soloFecha[1]);
                    if (i == 0)
                    {  //si es el primer dato mayor le asignamos la primer fecha ..aplica si es un solo resultado
                        mayor = fecha;
                        res[0] = soloFecha[0];                      //asigna si fue total o por sucursal
                        res[1] = reader["idsucursal"].ToString();   //asigna el id de la sucursal
                        res[2] = soloFecha[2];                      //asigna id del proveedor encontro
                    }
                    else
                    {
                        if (fecha > mayor)
                        {
                            mayor = fecha;
                            res[0] = soloFecha[0];                      //asigna si fue total o por sucursal
                            res[1] = reader["idsucursal"].ToString();   //asigna el id de la sucursal
                            res[2] = soloFecha[2];                      //asigna id del proveedor encontro
                        }
                    }
                }
                i++;
            }
            reader.Close();

            if (res[2] == "-1") { seleccion_proveedor = -1; }
            else { seleccion_proveedor = int.Parse(res[2]); ; }
            
            if (res[1] == "-1") { return -1; } //no encontro registros
            else
            {
                // si el ultimo elemento seleccionado es total o si no enviar el numero de sucursal
                if (res[0] == "total") return 0; else return int.Parse(res[1]);
            }
        }        
        public string m_retPagos(string cadPagos, int opcion)
        {
            string pago = "";
            string[] pagos = cadPagos.Split('_');           // Parte los diferentes tipos de pago
            string[] detPagTotal = pagos[0].Split('*');     // Separa valor de los totales historico y proyectado
            string[] detPagUni = pagos[1].Split('*');       // Separa valor de los pago unico historico y proyectado
            string[] detPagDif = pagos[2].Split('*');       // Separa valor de los pago diferico historico y proyectado
            string[] detPagUniFac = pagos[3].Split('*');    // Separa valor de los pago unico con factoraje historico y proyectado
            string[] detPagDifFac = pagos[4].Split('*');    // Separa valor de los pago diferico con factoraje historico y proyectado

            switch (opcion)
            {
                case 1: pago = detPagTotal[0]; break;       // TOTAL HISTORICO  
                case 2: pago = detPagTotal[1]; break;       // TOTAL PROYECTADO    
                case 3: pago = detPagUni[0]; break;         // PAGO UNICO HISTORICO  
                case 4: pago = detPagUni[1]; break;         // PAGO UNICO PROYECTADO  
                case 5: pago = detPagDif[0]; break;         // PAGO DIFERIDO HISTORICO  
                case 6: pago = detPagDif[1]; break;         // PAGO DIFERIDO PROYECTADO 
                case 7: pago = detPagUniFac[0]; break;      // PAGO UNICO CON FACTORAJE HISTORICO  
                case 8: pago = detPagUniFac[1]; break;      // PAGO UNICO CON FACTORAJE PROYECTADO 
                case 9: pago = detPagDifFac[0]; break;      // PAGO DIFERIDO CON FACTORAJE HISTORICO  
                case 10: pago = detPagDifFac[1]; break;     // PAGO DIFERIDO CON FACTORAJE PROYECTADO
            }

            return pago;
        }

        private void menuPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opciones op = new Opciones(); op.Show(); this.Hide();
        }
        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int medida = 10;
            if (tb1.Text != "") medida = int.Parse(tb1.Text);
            cbProveedor.Width = medida;            
        }
        private void botGuardar_Click(object sender, EventArgs e)
        {
            double totalH = 0, totalP = 0;
            int ant = 0, x = 0, suc = 0;
            string qsuc = "", saldos = ""; string[] valSuc = new string[13];
            DateTime time = DateTime.Now;

            if (total == true)
            {
                #region guardar_anterior_total
                /* //recorre las sucursales
                for (suc = 1; suc <= dgvCed2.Rows.Count - 1; suc++)
                {
                    qsuc = ""; ant = 0;
                    for (x = 1; x <= 12; x++) // Recorre los 12 meses del grid por sucursal
                    {
                        totalH = double.Parse(dgvCed2.Rows[suc].Cells[x + ant].Value.ToString(), NumberStyles.Currency);
                        totalP = double.Parse(dgvCed2.Rows[suc].Cells[(x + 1) + ant].Value.ToString(), NumberStyles.Currency);
                        if (x == 12) { qsuc += "'" + totalH + "*" + totalP + "_0*0_0*0_0*0_0*0'";  } //si es el ultimo elemento no incluir la coma
                        else { qsuc += "'" + totalH + "*" + totalP + "_0*0_0*0_0*0_0*0',"; }
                        valSuc[x] = "'" + totalH + "*" + totalP + "_0*0_0*0_0*0_0*0'"; //llena para usar en actualizacion
                        ant = x;
                    }

                    //revisa existencia de la sucursal en ese escenario
                    string idsuc = m_retSucursal(dgvCed2.Rows[suc].Cells[0].Value.ToString());
                    string idprov = m_ret_idProveedor(cbProveedor.Text); if (idprov == "") { idprov = "0"; }
                    if (m_existe_sucursal(int.Parse(idsuc)) == false)
                    {
                        query = "INSERT INTO cedula5a (nombre,mes1,mes2,mes3,mes4,mes5,mes6,mes7,mes8,mes9,mes10,mes11,mes12,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,observaciones) VALUES ";
                        query += "('" + Properties.Settings.Default.escenario + "'," + qsuc + "," + idsuc + "," + seleccion_division + "," + seleccion_depto + "," + seleccion_familia + "," + seleccion_linea + "," + seleccion_l1 + "," + seleccion_l2 + "," + seleccion_l3 + "," + seleccion_l4 + "," + seleccion_l5 + "," + seleccion_l6 + "," + seleccion_marca + ",'total_" + time.ToString("yyyy-MM-dd H:mm:ss") + "_" + idprov + "')";
                    }
                    else
                    {                        
                        query = "UPDATE cedula5a SET  ";
                        query += "mes1=" + valSuc[1] + ",mes2=" + valSuc[2] + ",mes3=" + valSuc[3] + ",mes4=" + valSuc[4] + ",mes5=" + valSuc[5] + ",mes6=" + valSuc[6] + ",mes7=" + valSuc[7] + ",mes8=" + valSuc[8] + ",mes9=" + valSuc[9] + ",mes10=" + valSuc[10] + ",mes11=" + valSuc[11] + ",mes12=" + valSuc[12] + ",";
                        query += "iddivisiones=" + seleccion_division + ",iddepto=" + seleccion_depto + ",idfamilia=" + seleccion_familia + ",idlinea=" + seleccion_linea + ",idl1=" + seleccion_l1 + ",idl2=" + seleccion_l2 + ",idl3=" + seleccion_l3 + ",idl4=" + seleccion_l4 + ",idl5=" + seleccion_l5 + ",idl6=" + seleccion_l6 + ",marca=" + seleccion_marca + ",observaciones='total_" + time.ToString("yyyy-MM-dd H:mm:ss") + "_" + idprov + "' ";
                        query += "WHERE nombre='" + Properties.Settings.Default.escenario + "' AND idsucursal=" + int.Parse(idsuc);
                    }
                    cmd = new MySqlCommand(query, Conn); cmd.ExecuteNonQuery();
                    //MessageBox.Show(query, "informacion");                    
                }*/
                #endregion guardar_anterior_total
                for (int r = 1; r < cbSucursales.Items.Count; r++) //recorre por mes todos los renglones(sucursales encontradas)
                {
                    int renglon = m_sucursal_ren(cbSucursales.Items[r].ToString(), dgvCed2);
                    /*sumaHist += decimal.Parse((string)dgvCed2.Rows[renglon].Cells[cols[0]].Value.ToString(), NumberStyles.Currency);
                    sumaProy += decimal.Parse((string)dgvCed2.Rows[renglon].Cells[cols[1]].Value.ToString(), NumberStyles.Currency);
                    sumaTotal += decimal.Parse((string)dgvCed2.Rows[renglon].Cells[cols[2]].Value.ToString(), NumberStyles.Currency);*/
                    double[] tot = { 0, 0, 0 }, pagUni = { 0, 0, 0 }, pagDif = { 0, 0, 0 }, pagUniFac = { 0, 0, 0 }, pagDifFac = { 0, 0, 0 };
                    foreach (string m in colmeses)
                    {
                        int[] cols = { 0, 0, 0 }; //historico, proyectado, total
                        cols[0] = m_num_col(m, dgvCed2);
                        cols[1] = m_num_col(m + " proy", dgvCed2);
                        cols[2] = m_num_col(m + " total", dgvCed2);

                        tot[0] = double.Parse(dgvCed2.Rows[renglon].Cells[cols[0]].Value.ToString(), NumberStyles.Currency);      //total hist
                        tot[1] = double.Parse(dgvCed2.Rows[renglon].Cells[cols[1]].Value.ToString(), NumberStyles.Currency);      //total proy
                        tot[2] = double.Parse(dgvCed2.Rows[renglon].Cells[cols[2]].Value.ToString(), NumberStyles.Currency);      //total sumaTotal
                        pagUni[0] = double.Parse(dgvCed2.Rows[renglon + 1].Cells[cols[0]].Value.ToString(), NumberStyles.Currency);   //pago unico historico
                        pagUni[1] = double.Parse(dgvCed2.Rows[renglon + 1].Cells[cols[1]].Value.ToString(), NumberStyles.Currency);   //pago unico proyectado
                        pagUni[2] = double.Parse(dgvCed2.Rows[renglon + 1].Cells[cols[2]].Value.ToString(), NumberStyles.Currency);   //pago unico sumaTotal
                        pagDif[0] = double.Parse(dgvCed2.Rows[renglon + 2].Cells[cols[0]].Value.ToString(), NumberStyles.Currency);   //pago diferido historico
                        pagDif[1] = double.Parse(dgvCed2.Rows[renglon + 2].Cells[cols[1]].Value.ToString(), NumberStyles.Currency);   //pago diferido proyectado
                        pagDif[2] = double.Parse(dgvCed2.Rows[renglon + 2].Cells[cols[2]].Value.ToString(), NumberStyles.Currency);   //pago diferido sumaTotal


                    }
                }
            }
            else
            {
                
                double[] tot = { 0, 0, 0 }, pagUni = { 0, 0, 0 }, pagDif = { 0, 0, 0 }, pagUniFac = { 0, 0, 0 }, pagDifFac = { 0, 0, 0 };
                foreach (string m in colmeses)
                {
                    int[] cols = { 0, 0, 0 }; //historico, proyectado, total
                    cols[0] = m_num_col(m, dgvCed2);
                    cols[1] = m_num_col(m + " proy", dgvCed2);
                    cols[2] = m_num_col(m + " total", dgvCed2);

                    tot[0] = double.Parse(dgvCed2.Rows[0].Cells[cols[0]].Value.ToString(), NumberStyles.Currency);      //total hist
                    tot[1] = double.Parse(dgvCed2.Rows[0].Cells[cols[1]].Value.ToString(), NumberStyles.Currency);      //total proy
                    tot[2] = double.Parse(dgvCed2.Rows[0].Cells[cols[2]].Value.ToString(), NumberStyles.Currency);      //total sumaTotal
                    pagUni[0] = double.Parse(dgvCed2.Rows[1].Cells[cols[0]].Value.ToString(), NumberStyles.Currency);   //pago unico historico
                    pagUni[1] = double.Parse(dgvCed2.Rows[1].Cells[cols[1]].Value.ToString(), NumberStyles.Currency);   //pago unico proyectado
                    pagUni[2] = double.Parse(dgvCed2.Rows[1].Cells[cols[2]].Value.ToString(), NumberStyles.Currency);   //pago unico sumaTotal
                    pagDif[0] = double.Parse(dgvCed2.Rows[2].Cells[cols[0]].Value.ToString(), NumberStyles.Currency);   //pago diferido historico
                    pagDif[1] = double.Parse(dgvCed2.Rows[2].Cells[cols[1]].Value.ToString(), NumberStyles.Currency);   //pago diferido proyectado
                    pagDif[2] = double.Parse(dgvCed2.Rows[2].Cells[cols[2]].Value.ToString(), NumberStyles.Currency);   //pago diferido sumaTotal

                    #region guardar_anterior
                    //qsuc = ""; int cont = 0;
                    /*pagUniFac[0] = double.Parse(dgvCed2.Rows[3].Cells[x + ant].Value.ToString(), NumberStyles.Currency);        //historico
                    pagUniFac[1] = double.Parse(dgvCed2.Rows[3].Cells[(x + 1) + ant].Value.ToString(), NumberStyles.Currency);  //proyectado
                    pagDifFac[0] = double.Parse(dgvCed2.Rows[4].Cells[x + ant].Value.ToString(), NumberStyles.Currency);        //historico
                    pagDifFac[1] = double.Parse(dgvCed2.Rows[4].Cells[(x + 1) + ant].Value.ToString(), NumberStyles.Currency);  //proyectado
                    

                    if (x == 12) { qsuc += "'" + totalH + "*" + totalP + "_" + pagUni[0] + "*" + pagUni[1] + "_" + pagDif[0] + "*" + pagDif[1] + "_" + pagUniFac[0] + "*" + pagUniFac[1] + "_" + pagDifFac[0] + "*" + pagDifFac[1] + "'"; } //si es el ultimo elemento no incluir la coma
                    else { qsuc += "'" + totalH + "*" + totalP + "_" + pagUni[0] + "*" + pagUni[1] + "_" + pagDif[0] + "*" + pagDif[1] + "_" + pagUniFac[0] + "*" + pagUniFac[1] + "_" + pagDifFac[0] + "*" + pagDifFac[1] + "',"; }
                    valSuc[x] = "'" + totalH + "*" + totalP + "_" + pagUni[0] + "*" + pagUni[1] + "_" + pagDif[0] + "*" + pagDif[1] + "_" + pagUniFac[0] + "*" + pagUniFac[1] + "_" + pagDifFac[0] + "*" + pagDifFac[1] + "'"; //llena para usar en actualizacion
                    ant = x;*/

                    //if (cont == 12) { saldos += "'" + tot[0] + "*" + tot[1] + "*" + tot[2] + "_" + pagUni[0] + "*" + pagUni[1] + "_" + pagDif[0] + "*" + pagDif[1] + "_" + pagUniFac[0] + "*" + pagUniFac[1] + "_" + pagDifFac[0] + "*" + pagDifFac[1] + "'"; } //si es el ultimo elemento no incluir la coma
                    //else { saldos += "'" + totalH + "*" + totalP + "_" + pagUni[0] + "*" + pagUni[1] + "_" + pagDif[0] + "*" + pagDif[1] + "_" + pagUniFac[0] + "*" + pagUniFac[1] + "_" + pagDifFac[0] + "*" + pagDifFac[1] + "',"; }
                    //valSuc[cont] = "'" + totalH + "*" + totalP + "_" + pagUni[0] + "*" + pagUni[1] + "_" + pagDif[0] + "*" + pagDif[1] + "_" + pagUniFac[0] + "*" + pagUniFac[1] + "_" + pagDifFac[0] + "*" + pagDifFac[1] + "'"; //llena para usar en actualizacion
                    /*
                    //revisa existencia
                    string idsuc = m_retSucursal(dgvCed2.Rows[0].Cells[0].Value.ToString());
                    string idprov = m_ret_idProveedor(cbProveedor.Text); if (idprov == "") { idprov = "0"; }
                    if (m_existe_sucursal(int.Parse(idsuc)) == false)
                    {
                        query = "INSERT INTO cedula5a (nombre,mes1,mes2,mes3,mes4,mes5,mes6,mes7,mes8,mes9,mes10,mes11,mes12,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,observaciones) VALUES ";
                        query += "('" + Properties.Settings.Default.escenario + "'," + qsuc + "," + idsuc + "," + seleccion_division + "," + seleccion_depto + "," + seleccion_familia + "," + seleccion_linea + "," + seleccion_l1 + "," + seleccion_l2 + "," + seleccion_l3 + "," + seleccion_l4 + "," + seleccion_l5 + "," + seleccion_l6 + "," + seleccion_marca + ",'sucursal_" + time.ToString("yyyy-MM-dd H:mm:ss") + "_" + idprov + "')";
                    }
                    else
                    {
                        query = "UPDATE cedula5a SET  ";
                        query += "mes1=" + valSuc[1] + ",mes2=" + valSuc[2] + ",mes3=" + valSuc[3] + ",mes4=" + valSuc[4] + ",mes5=" + valSuc[5] + ",mes6=" + valSuc[6] + ",mes7=" + valSuc[7] + ",mes8=" + valSuc[8] + ",mes9=" + valSuc[9] + ",mes10=" + valSuc[10] + ",mes11=" + valSuc[11] + ",mes12=" + valSuc[12] + ",";
                        query += "iddivisiones=" + seleccion_division + ",iddepto=" + seleccion_depto + ",idfamilia=" + seleccion_familia + ",idlinea=" + seleccion_linea + ",idl1=" + seleccion_l1 + ",idl2=" + seleccion_l2 + ",idl3=" + seleccion_l3 + ",idl4=" + seleccion_l4 + ",idl5=" + seleccion_l5 + ",idl6=" + seleccion_l6 + ",marca=" + seleccion_marca + ",observaciones='sucursal_" + time.ToString("yyyy-MM-dd H:mm:ss") + "_" + idprov + "' ";
                        query += "WHERE nombre='" + Properties.Settings.Default.escenario + "' AND idsucursal=" + int.Parse(idsuc);
                    }

                    //cmd = new MySqlCommand(query, Conn); cmd.ExecuteNonQuery();   
                    */   
                    #endregion guardar_anterior
                    //revisa existencia
                    int mes = 0, anio = 0;
                    if (anios.Length > 1)
                    {
                        string[] mesPartes = m.Split(' ');
                        mes = m_numero_mes(mesPartes[0]);
                        anio = int.Parse(mesPartes[1]);
                    }
                    else 
                    {
                        mes = m_numero_mes(m);
                        anio = int.Parse(anios[0]);
                    }
                    saldos = tot[0] + "*" + tot[1] + "*" + tot[2] + "_" + pagUni[0] + "*" + pagUni[1] + "*" + pagUni[2] + "_" + pagDif[0] + "*" + pagDif[1] + "*" + pagDif[2];
                    string idsuc = m_retSucursal(dgvCed2.Rows[0].Cells[0].Value.ToString()).ToString();
                    string idprov = m_ret_idProveedor(cbProveedor.Text); if (idprov == "") { idprov = "0"; }
                    if (m_existe_sucursal(int.Parse(idsuc), mes, anio) == false)
                    {
                        query = "INSERT INTO cedula5a(nombre,saldos,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,idproveedor) VALUES ";
                        query += "('" + Properties.Settings.Default.escenario + "','" + saldos + "'," + mes + "," + anio + "," + idsuc + "," + seleccion_division + "," + seleccion_depto + "," + seleccion_familia + "," + seleccion_linea + "," + seleccion_l1 + "," + seleccion_l2 + "," + seleccion_l3 + "," + seleccion_l4 + "," + seleccion_l5 + "," + seleccion_l6 + "," + seleccion_marca + ",'" + idprov + "')";
                    }
                    else
                    {
                        query = "UPDATE cedula5a SET saldos='" + saldos + "', idproveedor='" + idprov + "',";
                        query += "iddivisiones=" + seleccion_division + ",iddepto=" + seleccion_depto + ",idfamilia=" + seleccion_familia + ",idlinea=" + seleccion_linea + ",idl1=" + seleccion_l1 + ",idl2=" + seleccion_l2 + ",idl3=" + seleccion_l3 + ",idl4=" + seleccion_l4 + ",idl5=" + seleccion_l5 + ",idl6=" + seleccion_l6 + ",marca=" + seleccion_marca + " ";
                        query += "WHERE nombre='" + Properties.Settings.Default.escenario + "' AND idsucursal=" + int.Parse(idsuc) + " AND mes=" + mes + " AND anio=" + anio;
                    }
                    //MessageBox.Show(query);
                    cmd = new MySqlCommand(query, Conn); cmd.ExecuteNonQuery();                       
                }                            
            }
            m_DIASMESESANOS_guardar(CED1_fechaI, CED1_fechaF);
            MessageBox.Show("Guardado","informacion");
        }

        public void m_agrega_columna(string header, DataGridView dgv)
        {
            int colnum = dgv.ColumnCount + 1;
            string nomcol = "columna" + colnum;
            int col = dgv.Columns.Add(nomcol, header);
        }
        public int m_num_col(string BuscarHeader, DataGridView dgv)
        {
            int col = 0;
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (BuscarHeader == column.HeaderText) { col = column.Index; break; }             
            }

            return col;
        }
        public int m_sucursal_ren(string nombre_sucursal, DataGridView dgv)
        {
            int ren = 0;
            for (int i = 1; i < dgv.Rows.Count; i++)
            {
                if ((string)dgv.Rows[i].Cells[0].Value == nombre_sucursal) { ren = i; break; }                
            }
            return ren;
        }
        public string m_saca_anios(DateTime f1, DateTime f2)
        {
            string anios = ""; int anio = f1.Year;
            for (int i = anio; i <= f2.Year; i++)
            {
                if (i == f1.Year) { anios = anio.ToString(); }
                else { anios += "_" + anio.ToString(); }
                anio++;
            }

            return anios;
        }
        public string m_cadenaPagos(double mensualidad, double cantidad, int NoElem, int mesAct)
        {
            string pago = ""; int mes = mesAct;

            decimal entero, fraccion;
            entero = Math.Truncate(decimal.Parse(mensualidad.ToString()));
            fraccion = decimal.Parse(mensualidad.ToString()) - entero;

            for (int i = 1; i <= entero; i++) //recorre numero de pagos
            {
                if (mes <= NoElem) //revisa si esta en el rango de elementos
                {
                    if (mes == mesAct) { pago += mes + "*" + cantidad + "*0"; }
                    else { pago += "_" + mes + "*" + cantidad + "*0"; }
                    mes++; //aumenta el mes
                }
            }
            //introduce cantidad equivalente de la fraccion
            if (mes <= NoElem) pago += "_" + mes + "*" + (cantidad * double.Parse(fraccion.ToString())).ToString() + "*0";
            return pago;
        }
        public string m_updcadPagos(string cadOrigen, int mesAct, double valor, string tipoPago)
        {
            string nuevaCadPagos = ""; int i = 0;
            //actualiza un elemento de una cadena
            string[] partesPagosMens = cadOrigen.Split('_');
            foreach (string pagosMens in partesPagosMens)
            {
                //MessageBox.Show(pagosMens);
                string[] partePagos = pagosMens.Split('*');
                if (mesAct.ToString() == partePagos[0])
                {
                    if (i != 0) nuevaCadPagos += "_"; //si no es el primer elemento agrega delimitador de pagos "_"
                    switch (tipoPago)
                    {
                        case "unico": nuevaCadPagos += partePagos[0] + "*" + valor.ToString() + "*" + partePagos[2]; break;       //asigna nuevo valor para pago unico en el mes
                        case "diferido": nuevaCadPagos += partePagos[0] + "*" + partePagos[1] + "*" + valor.ToString(); break;    //asigna nuevo diferido para pago unico en el mes
                    }
                }
                else //sino agrega el mes y los pagos tal y como estaban
                {
                    if (i != 0) { nuevaCadPagos += "_"; }  //si no es el primer elemento agrega delimitador de pagos "_"
                    nuevaCadPagos += partePagos[0] + "*" + partePagos[1] + "*" + partePagos[2];
                }

                i++;

            }
            return nuevaCadPagos;
        }
        public string m_extraerPago(string cadOrigen, int mes, string tipoPago)
        {
            string pago = "0";
            string[] partesPagosMens = cadOrigen.Split('_');
            foreach (string pagosMens in partesPagosMens)
            {
                string[] partePagos = pagosMens.Split('*');
                if (mes.ToString() == partePagos[0])
                {
                    switch (tipoPago)
                    {
                        case "unico": pago = partePagos[1]; break;          //Extrae el valor para pago unico
                        case "diferido": pago = partePagos[2]; ; break;     //Extrae el valor para pago diferido
                    }
                    break;
                }
            }
            return pago;
        }
        public double sumatoria_mes(int col, int mes, string tipoPago)
        {
            double suma = 0;
            for (int i = 0; i < mes; i++)
            {
                suma += double.Parse(m_extraerPago(pagoMeses[i], mes, tipoPago));
                //if (tipoPago == "diferido") MessageBox.Show("extrayendo elemento " + i + "( se extrae mes " + mes + " ) limite = " + mes + "\npagoMeses[" + i + "] = " + pagoMeses[i] + "\nvalor extraido =" + m_extraerPago(pagoMeses[i], mes, tipoPago));
            }
            
            return suma;
        }

        private void dgvPorEd_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (cbSucursales.SelectedIndex != -1) //revisa que se haya seleccionado alguna sucursal
            {
                if (dgvPorEd.CurrentCell.RowIndex == 0) //porcentaje UNICO
                {
                    //MessageBox.Show("hiciste cambio para el mes " + dgvPorEd.CurrentCell.ColumnIndex + " en el renglon UNICO \n valor del cbsucursales=" + cbSucursales.SelectedIndex);
                    m_selectIndex_sucursales();
                }
                else if (dgvPorEd.CurrentCell.RowIndex == 1)  //porcentaje DIFERIDO
                {
                    //MessageBox.Show("hiciste cambio para el mes " + dgvPorEd.CurrentCell.ColumnIndex + " en el renglon DIFERIDO \n valor del cbsucursales=" + cbSucursales.SelectedIndex);
                    m_selectIndex_sucursales();
                }
            }
        }
        /// <summary>
        /// ////////////////////////////////////////////////////////////////
        /// 
        /// 
        /// Cedula 4 1/2 Cedula carlos-----------------------------------
        /// 
        /// 
        /// ///////////////////////////////////////////////////////////////
        /// </summary>
        private void cargaPartedos()
        {
            #region cargar estructura
            int i = 0;
            m_CLEAR_DGV();
            //if (total == true)
            //{
                m_ADD_ROWS_DGV();
                m_PASS_VALUES_DGV("Total", 0);
                dgv1.Rows[0].Cells[0].Value = "Total";
                i = 1;
            //}
            cmd = new MySqlCommand(queryparte2, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                m_REFRESH_DGV();
                m_ADD_ROWS_DGV();
                dgv1.Rows[i].Cells[0].Value = reader["descrip"].ToString();
                m_PASS_VALUES_DGV(dgv1.Rows[i].Cells[0].Value.ToString(), i);
                i++;
            }
            reader.Close();
            #endregion
            m_DIASMESESANOS(CED1_fechaI, CED1_fechaF);
        }
        public void m_DIASMESESANOS(string fecha_inicio, string fecha_final) /////////////////////////////se usa en todos 
        {

            int fecha_inicio_dia = Convert.ToInt32(fecha_inicio.Substring(0, 2));
            int fecha_inicio_mes = Convert.ToInt32(fecha_inicio.Substring(3, 2));
            int fecha_inicio_ano = Convert.ToInt32(fecha_inicio.Substring(6, 4));

            int fecha_final_dia = Convert.ToInt32(fecha_final.Substring(0, 2));
            int fecha_final_mes = Convert.ToInt32(fecha_final.Substring(3, 2));
            int fecha_final_ano = Convert.ToInt32(fecha_final.Substring(6, 4));
            tabcontrol.SelectedIndex = 0;
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
                            m_TABS(fecha_inicio_mes, fecha_inicio_ano);/////////////////////se usa en todos
                            //if (comprobarCargar(fecha_inicio_ano + 1, fecha_inicio_mes, i) == true)
                            //{
                            //    cargar(fecha_inicio_mes, fecha_inicio_ano + 1, i);
                            //}
                            //else
                            //{
                            //    
                            m_DPMA();
                            m_rotacionCuentasXpagar(fecha_inicio_mes,fecha_inicio_ano);
                            m_nombremes(fecha_inicio_mes);
                            m_plazo_medio_cobros();
                            m_ImporteDF(fecha_inicio_mes,fecha_inicio_ano);
                            m_obtenerRebajas(fecha_inicio_mes,fecha_inicio_ano);
                            m_utilidadDF(fecha_inicio_mes,fecha_inicio_ano);
                            m_calculos(i);
                            m_cantidadXmes(CED1_fechaI, CED1_fechaF);
                            m_calcularRenglonTotal();
                            //}
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
                            m_TABS(fecha_inicio_mes, fecha_inicio_ano);/////////////////////se usa en todos
                            //if (comprobarCargar(fecha_inicio_ano + 1, fecha_inicio_mes, i) == true)
                            //{
                            //    cargar(fecha_inicio_mes, fecha_inicio_ano + 1, i);
                            //}
                            //else
                            //{
                            m_DPMA();
                            m_rotacionCuentasXpagar(fecha_inicio_mes, fecha_inicio_ano);
                            m_nombremes(fecha_inicio_mes);
                            m_plazo_medio_cobros();
                            m_ImporteDF(fecha_inicio_mes, fecha_inicio_ano);
                            m_obtenerRebajas(fecha_inicio_mes, fecha_inicio_ano);
                            m_utilidadDF(fecha_inicio_mes, fecha_inicio_ano);
                            m_calculos(i);
                            m_cantidadXmes(CED1_fechaI, CED1_fechaF);
                            m_calcularRenglonTotal();
                            //    m_CALCULOS(i, fecha_inicio_mes, fecha_inicio_ano);
                            //}
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
            //m_calcularRenglonTotal();
        }
        public void m_TABS(int mes, int ano)
        {
            ano++;
            string mestab = "";
            switch (mes)
            {
                case 1: mestab = "Enero"; tabcontrol.SelectedTab.Text = mestab + " " + ano;
                    break;
                case 2: mestab = "Febrero"; tabcontrol.SelectedTab.Text = mestab + " " + ano;
                    break;
                case 3: mestab = "Marzo"; tabcontrol.SelectedTab.Text = mestab + " " + ano;
                    break;
                case 4: mestab = "Abril"; tabcontrol.SelectedTab.Text = mestab + " " + ano;
                    break;
                case 5: mestab = "Mayo"; tabcontrol.SelectedTab.Text = mestab + " " + ano;
                    break;
                case 6: mestab = "Junio"; tabcontrol.SelectedTab.Text = mestab + " " + ano;
                    break;
                case 7: mestab = "Julio"; tabcontrol.SelectedTab.Text = mestab + " " + ano;
                    break;
                case 8: mestab = "Agosto"; tabcontrol.SelectedTab.Text = mestab + " " + ano;
                    break;
                case 9: mestab = "Septiembre"; tabcontrol.SelectedTab.Text = mestab + " " + ano;
                    break;
                case 10: mestab = "Octubre"; tabcontrol.SelectedTab.Text = mestab + " " + ano;
                    break;
                case 11: mestab = "Noviembre"; tabcontrol.SelectedTab.Text = mestab + " " + ano;
                    break;
                case 12: mestab = "Diciembre"; tabcontrol.SelectedTab.Text = mestab + " " + ano;
                    break;

            }
        }
        public void m_CLEAR_DGV() //// nuevo limpia los dgvs siempre que se hace algo nuevo
        {
            dgv1.Rows.Clear(); dgv4.Rows.Clear(); dgv7.Rows.Clear(); dgv10.Rows.Clear();
            dgv2.Rows.Clear(); dgv5.Rows.Clear(); dgv8.Rows.Clear(); dgv11.Rows.Clear();
            dgv3.Rows.Clear(); dgv6.Rows.Clear(); dgv9.Rows.Clear(); dgv12.Rows.Clear();
        }
        public void m_REFRESH_DGV()
        {
            dgv1.Refresh(); dgv2.Refresh(); dgv3.Refresh(); dgv4.Refresh(); dgv5.Refresh();
            dgv6.Refresh(); dgv7.Refresh(); dgv8.Refresh(); dgv9.Refresh(); dgv10.Refresh();
            dgv11.Refresh(); dgv12.Refresh();
        }
        public void m_ADD_ROWS_DGV()
        {
            dgv1.Rows.Add(); dgv2.Rows.Add(); dgv3.Rows.Add(); dgv4.Rows.Add(); dgv5.Rows.Add();
            dgv6.Rows.Add(); dgv7.Rows.Add(); dgv8.Rows.Add(); dgv9.Rows.Add(); dgv10.Rows.Add();
            dgv11.Rows.Add(); dgv12.Rows.Add();
        }
        public void m_PASS_VALUES_DGV(string val, int renglon)
        {
            dgv2.Rows[renglon].Cells[0].Value = val; dgv3.Rows[renglon].Cells[0].Value = val;
            dgv4.Rows[renglon].Cells[0].Value = val; dgv5.Rows[renglon].Cells[0].Value = val;
            dgv6.Rows[renglon].Cells[0].Value = val; dgv7.Rows[renglon].Cells[0].Value = val;
            dgv8.Rows[renglon].Cells[0].Value = val; dgv9.Rows[renglon].Cells[0].Value = val;
            dgv10.Rows[renglon].Cells[0].Value = val; dgv11.Rows[renglon].Cells[0].Value = val;
            dgv12.Rows[renglon].Cells[0].Value = val;
        }
        private void M_pintarcolumnas()
        {
            dgv1.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B4FF8F");
            dgv1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");
            dgv2.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B4FF8F");
            dgv2.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");
            dgv3.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B4FF8F");
            dgv3.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");
            dgv4.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B4FF8F");
            dgv4.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");
            dgv5.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B4FF8F");
            dgv5.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");
            dgv6.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B4FF8F");
            dgv6.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");
            dgv7.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B4FF8F");
            dgv7.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");
            dgv8.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B4FF8F");
            dgv8.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");
            dgv9.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B4FF8F");
            dgv9.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");
            dgv10.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B4FF8F");
            dgv10.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");
            dgv11.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B4FF8F");
            dgv11.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");
            dgv12.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B4FF8F");
            dgv12.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#43BF43");
        }

        private void m_obtenerRebajas(int mes,int ano)
        {
            for (int x = 1; x <= dgv1.Rows.Count - 1; x++)
            {
                #region rebajas
                string q = "SELECT (SUM(rebajaregsiva)+SUM(rebajapromsiva)+SUM(rebajanormalsiva)+SUM(rebajadesctosiva)) AS rebajasimp FROM VENTASBASE AS V INNER JOIN SUCURSAL AS S ON V.IDSUCURSAL = S.IDSUCURSAL INNER JOIN FECHA AS F ON F.IDFECHA = V.IDFECHA WHERE   F.Mes='" + mes + "' and f.anio='" + ano + "' and V.iddivisiones=1 and v.idsucursal="+idsucursales[(x-1)];
                cmd = new MySqlCommand(q, Conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["rebajasimp"].ToString() == "")
                    {
                        rebajasI[x] = 0;
                    }
                    else
                    {
                        rebajasI[x] = double.Parse(reader["rebajasimp"].ToString());
                    }
                }
                reader.Close();
                #endregion
            }
        }
        private void importes()
        {
            #region importes
            string queryimporte = "SELECT SUM(s.`enero`) as enero , sum(s.febrero) as febrero, sum(s.marzo) as marzo, sum(s.abril) as abril, sum(s.mayo) as mayo, sum(s.junio) as junio, sum(s.julio) as julio, sum(s.agosto) as agosto, sum(s.septiembre) as septiembre, sum(s.octubre) as octubre, sum(s.noviembre) as noviembre, sum(s.diciembre) as diciembre FROM saldoprov AS s INNER JOIN estarticulo AS e ON s.`marca`=e.`marca` WHERE ";
            #endregion
            cmd = new MySqlCommand(queryimporte, connCipsis);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //if (reader["enero"].ToString() != "")
                //{
                //    importeE = double.Parse(reader["enero"].ToString());
                //}
                //else { importeE = 0; }
                //if (reader["febrero"].ToString() != "")
                //{
                //    importeF = double.Parse(reader["febrero"].ToString());
                //}
                //else { importeF = 0; }
                //if (reader["marzo"].ToString() != "")
                //{
                //    importeM = double.Parse(reader["marzo"].ToString());
                //}
                //else { importeM = 0; }
                //if (reader["mayo"].ToString() != "")
                //{
                //    importeMay = double.Parse(reader["mayo"].ToString());
                //}
                //else { importeMay = 0; }
                //if (reader["abril"].ToString() != "")
                //{
                //    importeA = double.Parse(reader["abril"].ToString());
                //}
                //else { importeA = 0; }
                //if (reader["junio"].ToString() != "")
                //{
                //    importej = double.Parse(reader["junio"].ToString());
                //}
                //else { importej = 0; }
                //if (reader["julio"].ToString() != "")
                //{
                //    importejul = double.Parse(reader["julio"].ToString());
                //}
                //else { importejul = 0; }
                //if (reader["agosto"].ToString() != "")
                //{
                //    importeAgo = double.Parse(reader["agosto"].ToString());
                //}
                //else { importeAgo = 0; }
                //if (reader["septiembre"].ToString() != "")
                //{
                //    importeSep = double.Parse(reader["septiembre"].ToString());
                //}
                //else { importeSep = 0; }
                //if (reader["octubre"].ToString() != "")
                //{
                //    importeOc = double.Parse(reader["octubre"].ToString());
                //}
                //else { importeOc = 0; }
                //if (reader["noviembre"].ToString() != "")
                //{
                //    importenov = double.Parse(reader["noviembre"].ToString());
                //}
                //else { importenov = 0; }
                //if (reader["diciembre"].ToString() != "")
                //{
                //    importeDic = double.Parse(reader["diciembre"].ToString());
                //}
                //else { importeDic = 0; }

            }
            reader.Close();
        }
        private void margen()
        {
            int i=0;
            #region margen
           string querymargen = "SELECT SUM(m.`costo`) AS costo ,SUM(m.`precio`) AS precio FROM margeninicialpon AS V WHERE ";
            #endregion
           cmd = new MySqlCommand(querymargen, Conn);
           reader = cmd.ExecuteReader();
           while (reader.Read())
           {
               if (reader["costo"].ToString() != "")
               {
                   costo[i] = double.Parse(reader["costo"].ToString());
               }
               else { costo[i] = 0; }
               if (reader["precio"].ToString() != "")
               {
                   precio[i] = double.Parse(reader["precio"].ToString());
               }
               else { precio[i] = 0; }
           }
           reader.Close();
        }
        private void m_calculos(int m)
        {

            switch(m)
            {
                case 1:                    
                    #region mostrar
                    for (int i = 1; i <= dgv1.Rows.Count - 1; i++)
                    {
                        //string queryimporte = "SELECT SUM(" + mesNombre + ") AS saldo FROM saldoprovsuc AS v WHERE sucursal=" + idsucursales[i];
                        //cmd = new MySqlCommand(queryimporte, connCipsis);
                        //reader = cmd.ExecuteReader();
                        //while (reader.Read())
                        //{ }
                        //reader.Close();
                        dgv1.Rows[i].Cells[1].Value = dpma.ToString("n0");
                        dgv1.Rows[i].Cells[2].Value = RCuentasxPagar[i].ToString("n0");
                        dgv1.Rows[i].Cells[3].Value=plazomediopagos[i].ToString("n0");
                        dgv1.Rows[i].Cells[4].Value=plazomedioCobros.ToString("n0");
                        dgv1.Rows[i].Cells[5].Value=diasFin[i].ToString("n0");
                        dgv1.Rows[i].Cells[6].Value=importediasFin[i].ToString("C2");
                        dgv1.Rows[i].Cells[7].Value=utilidadDF[i].ToString("C2");
                    }
                    #endregion
                    break;
                case 2:
                    #region mostrar
                    for (int i = 1; i <= dgv1.Rows.Count - 1; i++)
                    {
                        //string queryimporte = "SELECT SUM(" + mesNombre + ") AS saldo FROM saldoprovsuc AS v WHERE sucursal=" + idsucursales[i];
                        //cmd = new MySqlCommand(queryimporte, connCipsis);
                        //reader = cmd.ExecuteReader();
                        //while (reader.Read())
                        //{ }
                        //reader.Close();
                        dgv2.Rows[i].Cells[1].Value = dpma.ToString("n0");
                        dgv2.Rows[i].Cells[2].Value = RCuentasxPagar[i].ToString("n0");
                        dgv2.Rows[i].Cells[3].Value = plazomediopagos[i].ToString("n0");
                        dgv2.Rows[i].Cells[4].Value = plazomedioCobros.ToString("n0");
                        dgv2.Rows[i].Cells[5].Value = diasFin[i].ToString("n0");
                        dgv2.Rows[i].Cells[6].Value = importediasFin[i].ToString("C2");
                        dgv2.Rows[i].Cells[7].Value = utilidadDF[i].ToString("C2");
                    }
                    #endregion
                    break;
                case 3:
                    #region mostrar
                    for (int i = 1; i <= dgv1.Rows.Count - 1; i++)
                    {
                        //string queryimporte = "SELECT SUM(" + mesNombre + ") AS saldo FROM saldoprovsuc AS v WHERE sucursal=" + idsucursales[i];
                        //cmd = new MySqlCommand(queryimporte, connCipsis);
                        //reader = cmd.ExecuteReader();
                        //while (reader.Read())
                        //{ }
                        //reader.Close();
                        dgv3.Rows[i].Cells[1].Value = dpma.ToString("n0");
                        dgv3.Rows[i].Cells[2].Value = RCuentasxPagar[i].ToString("n0");
                        dgv3.Rows[i].Cells[3].Value = plazomediopagos[i].ToString("n0");
                        dgv3.Rows[i].Cells[4].Value = plazomedioCobros.ToString("n0");
                        dgv3.Rows[i].Cells[5].Value = diasFin[i].ToString("n0");
                        dgv3.Rows[i].Cells[6].Value = importediasFin[i].ToString("C2");
                        dgv3.Rows[i].Cells[7].Value = utilidadDF[i].ToString("C2");
                    }
                    #endregion
                    break;
                case 4:
                    #region mostrar
                    for (int i = 1; i <= dgv1.Rows.Count - 1; i++)
                    {
                        //string queryimporte = "SELECT SUM(" + mesNombre + ") AS saldo FROM saldoprovsuc AS v WHERE sucursal=" + idsucursales[i];
                        //cmd = new MySqlCommand(queryimporte, connCipsis);
                        //reader = cmd.ExecuteReader();
                        //while (reader.Read())
                        //{ }
                        //reader.Close();
                        dgv4.Rows[i].Cells[1].Value = dpma.ToString("n0");
                        dgv4.Rows[i].Cells[2].Value = RCuentasxPagar[i].ToString("n0");
                        dgv4.Rows[i].Cells[3].Value = plazomediopagos[i].ToString("n0");
                        dgv4.Rows[i].Cells[4].Value = plazomedioCobros.ToString("n0");
                        dgv4.Rows[i].Cells[5].Value = diasFin[i].ToString("n0");
                        dgv4.Rows[i].Cells[6].Value = importediasFin[i].ToString("C2");
                        dgv4.Rows[i].Cells[7].Value = utilidadDF[i].ToString("C2");
                    }
                    #endregion
                    break;
                case 5:
                    #region mostrar
                    for (int i = 1; i <= dgv1.Rows.Count - 1; i++)
                    {
                        //string queryimporte = "SELECT SUM(" + mesNombre + ") AS saldo FROM saldoprovsuc AS v WHERE sucursal=" + idsucursales[i];
                        //cmd = new MySqlCommand(queryimporte, connCipsis);
                        //reader = cmd.ExecuteReader();
                        //while (reader.Read())
                        //{ }
                        //reader.Close();
                        dgv5.Rows[i].Cells[1].Value = dpma.ToString("n0");
                        dgv5.Rows[i].Cells[2].Value = RCuentasxPagar[i].ToString("n0");
                        dgv5.Rows[i].Cells[3].Value = plazomediopagos[i].ToString("n0");
                        dgv5.Rows[i].Cells[4].Value = plazomedioCobros.ToString("n0");
                        dgv5.Rows[i].Cells[5].Value = diasFin[i].ToString("n0");
                        dgv5.Rows[i].Cells[6].Value = importediasFin[i].ToString("C2");
                        dgv5.Rows[i].Cells[7].Value = utilidadDF[i].ToString("C2");
                    }
                    #endregion
                    break;
                case 6:
                    #region mostrar
                    for (int i = 1; i <= dgv1.Rows.Count - 1; i++)
                    {
                        //string queryimporte = "SELECT SUM(" + mesNombre + ") AS saldo FROM saldoprovsuc AS v WHERE sucursal=" + idsucursales[i];
                        //cmd = new MySqlCommand(queryimporte, connCipsis);
                        //reader = cmd.ExecuteReader();
                        //while (reader.Read())
                        //{ }
                        //reader.Close();
                        dgv6.Rows[i].Cells[1].Value = dpma.ToString("n0");
                        dgv6.Rows[i].Cells[2].Value = RCuentasxPagar[i].ToString("n0");
                        dgv6.Rows[i].Cells[3].Value = plazomediopagos[i].ToString("n0");
                        dgv6.Rows[i].Cells[4].Value = plazomedioCobros.ToString("n0");
                        dgv6.Rows[i].Cells[5].Value = diasFin[i].ToString("n0");
                        dgv6.Rows[i].Cells[6].Value = importediasFin[i].ToString("C2");
                        dgv6.Rows[i].Cells[7].Value = utilidadDF[i].ToString("C2");
                    }
                    #endregion
                    break;
                case 7:
                    #region mostrar
                    for (int i = 1; i <= dgv1.Rows.Count - 1; i++)
                    {
                        //string queryimporte = "SELECT SUM(" + mesNombre + ") AS saldo FROM saldoprovsuc AS v WHERE sucursal=" + idsucursales[i];
                        //cmd = new MySqlCommand(queryimporte, connCipsis);
                        //reader = cmd.ExecuteReader();
                        //while (reader.Read())
                        //{ }
                        //reader.Close();
                        dgv7.Rows[i].Cells[1].Value = dpma.ToString("n0");
                        dgv7.Rows[i].Cells[2].Value = RCuentasxPagar[i].ToString("n0");
                        dgv7.Rows[i].Cells[3].Value = plazomediopagos[i].ToString("n0");
                        dgv7.Rows[i].Cells[4].Value = plazomedioCobros.ToString("n0");
                        dgv7.Rows[i].Cells[5].Value = diasFin[i].ToString("n0");
                        dgv7.Rows[i].Cells[6].Value = importediasFin[i].ToString("C2");
                        dgv7.Rows[i].Cells[7].Value = utilidadDF[i].ToString("C2");
                    }
                    #endregion
                    break;
                case 8:
                    #region mostrar
                    for (int i = 1; i <= dgv1.Rows.Count - 1; i++)
                    {
                        //string queryimporte = "SELECT SUM(" + mesNombre + ") AS saldo FROM saldoprovsuc AS v WHERE sucursal=" + idsucursales[i];
                        //cmd = new MySqlCommand(queryimporte, connCipsis);
                        //reader = cmd.ExecuteReader();
                        //while (reader.Read())
                        //{ }
                        //reader.Close();
                        dgv8.Rows[i].Cells[1].Value = dpma.ToString("n0");
                        dgv8.Rows[i].Cells[2].Value = RCuentasxPagar[i].ToString("n0");
                        dgv8.Rows[i].Cells[3].Value = plazomediopagos[i].ToString("n0");
                        dgv8.Rows[i].Cells[4].Value = plazomedioCobros.ToString("n0");
                        dgv8.Rows[i].Cells[5].Value = diasFin[i].ToString("n0");
                        dgv8.Rows[i].Cells[6].Value = importediasFin[i].ToString("C2");
                        dgv8.Rows[i].Cells[7].Value = utilidadDF[i].ToString("C2");
                    }
                    #endregion
                    break;
                case 9:
                    #region mostrar
                    for (int i = 1; i <= dgv1.Rows.Count - 1; i++)
                    {
                        //string queryimporte = "SELECT SUM(" + mesNombre + ") AS saldo FROM saldoprovsuc AS v WHERE sucursal=" + idsucursales[i];
                        //cmd = new MySqlCommand(queryimporte, connCipsis);
                        //reader = cmd.ExecuteReader();
                        //while (reader.Read())
                        //{ }
                        //reader.Close();
                        dgv9.Rows[i].Cells[1].Value = dpma.ToString("n0");
                        dgv9.Rows[i].Cells[2].Value = RCuentasxPagar[i].ToString("n0");
                        dgv9.Rows[i].Cells[3].Value = plazomediopagos[i].ToString("n0");
                        dgv9.Rows[i].Cells[4].Value = plazomedioCobros.ToString("n0");
                        dgv9.Rows[i].Cells[5].Value = diasFin[i].ToString("n0");
                        dgv9.Rows[i].Cells[6].Value = importediasFin[i].ToString("C2");
                        dgv9.Rows[i].Cells[7].Value = utilidadDF[i].ToString("C2");
                    }
                    #endregion
                    break;
                case 10:
                    #region mostrar
                    for (int i = 1; i <= dgv1.Rows.Count - 1; i++)
                    {
                        //string queryimporte = "SELECT SUM(" + mesNombre + ") AS saldo FROM saldoprovsuc AS v WHERE sucursal=" + idsucursales[i];
                        //cmd = new MySqlCommand(queryimporte, connCipsis);
                        //reader = cmd.ExecuteReader();
                        //while (reader.Read())
                        //{ }
                        //reader.Close();
                        dgv10.Rows[i].Cells[1].Value = dpma.ToString("n0");
                        dgv10.Rows[i].Cells[2].Value = RCuentasxPagar[i].ToString("n0");
                        dgv10.Rows[i].Cells[3].Value = plazomediopagos[i].ToString("n0");
                        dgv10.Rows[i].Cells[4].Value = plazomedioCobros.ToString("n0");
                        dgv10.Rows[i].Cells[5].Value = diasFin[i].ToString("n0");
                        dgv10.Rows[i].Cells[6].Value = importediasFin[i].ToString("C2");
                        dgv10.Rows[i].Cells[7].Value = utilidadDF[i].ToString("C2");
                    }
                    #endregion
                    break;
                case 11:
                    #region mostrar
                    for (int i = 1; i <= dgv1.Rows.Count - 1; i++)
                    {
                        //string queryimporte = "SELECT SUM(" + mesNombre + ") AS saldo FROM saldoprovsuc AS v WHERE sucursal=" + idsucursales[i];
                        //cmd = new MySqlCommand(queryimporte, connCipsis);
                        //reader = cmd.ExecuteReader();
                        //while (reader.Read())
                        //{ }
                        //reader.Close();
                        dgv11.Rows[i].Cells[1].Value = dpma.ToString("n0");
                        dgv11.Rows[i].Cells[2].Value = RCuentasxPagar[i].ToString("n0");
                        dgv11.Rows[i].Cells[3].Value = plazomediopagos[i].ToString("n0");
                        dgv11.Rows[i].Cells[4].Value = plazomedioCobros.ToString("n0");
                        dgv11.Rows[i].Cells[5].Value = diasFin[i].ToString("n0");
                        dgv11.Rows[i].Cells[6].Value = importediasFin[i].ToString("C2");
                        dgv11.Rows[i].Cells[7].Value = utilidadDF[i].ToString("C2");
                    }
                    #endregion
                    break;
                case 12:
                    #region mostrar
                    for (int i = 1; i <= dgv1.Rows.Count - 1; i++)
                    {
                        //string queryimporte = "SELECT SUM(" + mesNombre + ") AS saldo FROM saldoprovsuc AS v WHERE sucursal=" + idsucursales[i];
                        //cmd = new MySqlCommand(queryimporte, connCipsis);
                        //reader = cmd.ExecuteReader();
                        //while (reader.Read())
                        //{ }
                        //reader.Close();
                        dgv12.Rows[i].Cells[1].Value = dpma.ToString("n0");
                        dgv12.Rows[i].Cells[2].Value = RCuentasxPagar[i].ToString("n0");
                        dgv12.Rows[i].Cells[3].Value = plazomediopagos[i].ToString("n0");
                        dgv12.Rows[i].Cells[4].Value = plazomedioCobros.ToString("n0");
                        dgv12.Rows[i].Cells[5].Value = diasFin[i].ToString("n0");
                        dgv12.Rows[i].Cells[6].Value = importediasFin[i].ToString("C2");
                        dgv12.Rows[i].Cells[7].Value = utilidadDF[i].ToString("C2");
                    }
                    #endregion
                    break;
            }
        }
        private void m_DPMA()
        {
            TimeSpan ts = FechaAI - FechaAF;
            int differenceInDays = ts.Days;
            string q = "Select rotacion from cedula1 where nombre='"+Properties.Settings.Default.escenario+"'";
            cmd = new MySqlCommand(q, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["rotacion"].ToString() != "")
                {
                    rotacion = double.Parse(reader["rotacion"].ToString());
                }
                else { rotacion = 0; }
                if (reader["rotacion"].ToString() != "")
                {
                    rotacion = double.Parse(reader["rotacion"].ToString());
                }
                else { rotacion = 0; }
            }
            reader.Close();
            dpma = -1*(differenceInDays / rotacion);
        }
        private void m_rotacionCuentasXpagar(int mes,int año)
        {
            TimeSpan ts = FechaAI - FechaAF;
            int differenceInDays = ts.Days;
            int i = 0;
            for (int x = 1; x <= dgv1.Rows.Count - 1; x++)
            {
                #region Promedio cuentas por pagar
                string querypromedio_ctasXpagar = "SELECT (SUM(saldoact)+SUM(saldoant))/2 AS promedio FROM saldoprovsuc WHERE sucursal="+idsucursales[(x-1)]+ " and ejercicio=" + año.ToString();
                #endregion
                cmd = new MySqlCommand(querypromedio_ctasXpagar, connCipsis);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["promedio"].ToString() == "")
                    {
                        cuentasXpagar[x] = 0;
                    }
                    else
                    {
                        cuentasXpagar[x] = double.Parse(reader["promedio"].ToString());
                    }
                }
                reader.Close();
                string q = "SELECT importerecibo from cedula3 where nombre='"+Properties.Settings.Default.escenario+"' and idsucursal="+idsucursales[(x-1)]+" and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1' and mes="+mes;
                cmd = new MySqlCommand(q, Conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["importerecibo"].ToString() == "")
                    {
                        comprasN[x] = 0;
                    }
                    else
                    {
                        comprasN[x] = double.Parse(reader["importerecibo"].ToString());
                    }
                }
                reader.Close();
                if (comprasN[x] >= 1 && cuentasXpagar[x] >= 1)
                {
                    
                        RCuentasxPagar[x] = comprasN[x] / cuentasXpagar[x];
                        plazomediopagos[x] = -1 * (differenceInDays / RCuentasxPagar[x]);
                }
                else
                {
                    RCuentasxPagar[x] = 0;
                    plazomediopagos[x]=0;
                }
            }
        }
        private void m_plazo_medio_cobros()
        {
            TimeSpan ts = FechaAI - FechaAF;
            int differenceInDays = ts.Days;
            int i = 0;
            double promedio = 0;
            #region Promedio medio de cobros
            string querypromedio_ctasXcobrar = "SELECT (SUM(total)+SUM(apagar))/2 AS promedio FROM factprov AS V WHERE fecha BETWEEN '"+FechaAI.ToString("yyyy-MM-dd")+"' AND '"+FechaAF.ToString("yyyy-MM-dd")+"'";
            #endregion
            cmd = new MySqlCommand(querypromedio_ctasXcobrar, connCipsis);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["promedio"].ToString() == "")
                {
                    cobros[i] = 0;
                    promedio = 0;
                }
                else
                {
                    cobros[i] = double.Parse(reader["promedio"].ToString());
                    promedio = double.Parse(reader["promedio"].ToString());
                }
            }
            reader.Close();
            //if (promedio >= 1)
            //{
            plazomedioCobros = promedio / (-1 * differenceInDays);
            //}
            //else
            //{
            //    plazomedioCobros = 0;
            //}
        }
        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
        }
        private void m_nombremes(int mes)
        {
                switch(mes)
                {
                    case 1:
                        mesNombre = "enero";
                        break;
                    case 2:
                        mesNombre = "febrero";
                        break;
                    case 3:
                        mesNombre = "marzo";
                        break;
                    case 4:
                        mesNombre = "abril";
                        break;
                    case 5:
                        mesNombre = "mayo";
                        break;
                    case 6:
                        mesNombre = "junio";
                        break;
                    case 7:
                        mesNombre="julio";
                        break;
                    case 8:
                        mesNombre = "agosto";
                        break;
                    case 9:
                        mesNombre = "septiembre";
                        break;
                    case 10:
                        mesNombre = "octubre";
                        break;
                    case 11:
                        mesNombre = "noviembre";
                        break;
                    case 12:
                        mesNombre = "diciembre";
                        break;
                }

        }
        private void m_ImporteDF(int mes, int año)
        {
            double[] importeVenta = new double[1000];
            for (int x = 1; x <= dgv1.Rows.Count - 1; x++)
            {

                diasFin[x] = (dpma - plazomediopagos[x]) - plazomedioCobros;
                string q = "SELECT SUM(impllenototal) AS importe FROM VENTASBASE AS V INNER JOIN FECHA AS F ON F.IDFECHA = V.IDFECHA WHERE F.Mes='" + mes + "' and f.anio='" + año + "' and f.Dia=1 and idsucursal=" + idsucursales[(x-1)]+" and v.iddivisiones=1";
                cmd = new MySqlCommand(q, Conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["importe"].ToString() != "")
                    {
                        importeVenta[x] = double.Parse(reader["importe"].ToString());
                    }
                    else
                    {
                        importeVenta[x] = 0;
                    }
                }
                reader.Close();
                if (importeVenta[x] >= 1 && diasFin[x] >= 1)
                {
                    importediasFin[x] = diasFin[x] * importeVenta[x];
                }
                else
                {
                    importediasFin[x] = 0;
                }
            }
        }
        private void m_utilidadDF(int mes, int año)
        {
            double costo=0, precio=0;
            double margen = 0;
            for (int x = 1; x <= dgv1.Rows.Count - 1; x++)
            {
                string q = "SELECT SUM(m.`costo`) AS costo ,SUM(m.`precio`) AS precio FROM margeninicialpon AS m INNER JOIN estarticulo AS e ON m.marca=e.marca INNER JOIN fecha AS f ON e.`fecha`=f.`Fecha` WHERE f.`Mes`='" + mes.ToString() + "' AND f.`Anio`='" + año.ToString() + "' and f.Dia=1 and e.iddivisiones=1";
                cmd = new MySqlCommand(q, Conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["costo"].ToString() != "")
                    {
                        costo = double.Parse(reader["costo"].ToString());
                    }
                    else { costo = 0; }
                    if (reader["precio"].ToString() != "")
                    {
                        precio = double.Parse(reader["precio"].ToString());
                    }
                    else { precio = 0; }
                }
                reader.Close();
                if (costo >= 1 && precio >= 1)
                {
                    margen = (costo * precio) / rebajasI[x];
                }
                else
                {
                    margen = 0;
                }
                if(importediasFin[x]>=1&&margen>=1)
                {
                    utilidadDF[x] = importediasFin[x] * margen;
                }
                else
                {
                    utilidadDF[x]=0;
                }
            }
        }
        public void m_renglonTotal()
        {
            dgv1.Rows[0].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7FE2E");
            dgv2.Rows[0].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7FE2E");
            dgv3.Rows[0].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7FE2E");
            dgv4.Rows[0].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7FE2E");
            dgv5.Rows[0].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7FE2E");
            dgv6.Rows[0].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7FE2E");
            dgv7.Rows[0].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7FE2E");
            dgv8.Rows[0].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7FE2E");
            dgv9.Rows[0].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7FE2E");
            dgv10.Rows[0].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7FE2E");
            dgv11.Rows[0].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7FE2E");
            dgv12.Rows[0].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7FE2E");
        }
        private void m_calcularRenglonTotal()
        {
            m_renglonTotal();
            for (int x = 1; x <= cantidadmes; x++)
            {
                double c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15;
                switch (x)
                {
                    case 1:
                        #region renglontotal
                        c1 = 0;
                        c2 = 0;
                        c3 = 0;
                        c4 = 0;
                        c5 = 0;
                        c6 = 0;
                        c7 = 0;
                        c8 = 0;
                        c9 = 0;
                        c10 = 0;
                        c11 = 0;
                        c12 = 0;
                        c13 = 0;
                        c14 = 0;
                        c15 = 0;
                        for (int i = 1; i <= dgv1.Rows.Count - 1; i++)
                        {
                            if (dgv1.Rows[i].Cells[1].Value != null && dgv1.Rows[i].Cells[1].Value.ToString() != " ")
                            {
                                c1 += double.Parse(dgv1.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c1 = c1 + 0;
                            }
                            if (dgv1.Rows[i].Cells[2].Value != null && dgv1.Rows[i].Cells[2].Value.ToString() != " ")
                            {
                                c2 += double.Parse(dgv1.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c2 = c2 + 0;
                            }
                            if (dgv1.Rows[i].Cells[3].Value != null && dgv1.Rows[i].Cells[3].Value.ToString() != " ")
                            {
                                c3 += double.Parse(dgv1.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c3 = c3 + 0;
                            }
                            if (dgv1.Rows[i].Cells[4].Value != null && dgv1.Rows[i].Cells[4].Value.ToString() != " ")
                            {
                                c4 += double.Parse(dgv1.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c4 = c4 + 0;
                            }
                            if (dgv1.Rows[i].Cells[5].Value != null && dgv1.Rows[i].Cells[5].Value.ToString() != " ")
                            {
                                c5 += double.Parse(dgv1.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c5 = c5 + 0;
                            }
                            if (dgv1.Rows[i].Cells[6].Value != null && dgv1.Rows[i].Cells[6].Value.ToString() != " ")
                            {
                                c6 += double.Parse(dgv1.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c6 = c6 + 0;
                            }
                            if (dgv1.Rows[i].Cells[7].Value != null && dgv1.Rows[i].Cells[7].Value.ToString() != " ")
                            {
                                c7 += double.Parse(dgv1.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c7 = c7 + 0;
                            }
                            
                            dgv1.Rows[0].Cells[1].Value = c1.ToString("n0");
                            dgv1.Rows[0].Cells[2].Value = c2.ToString("n2");
                            dgv1.Rows[0].Cells[3].Value = c3.ToString("n2");
                            dgv1.Rows[0].Cells[4].Value = c4.ToString("n0");
                            dgv1.Rows[0].Cells[5].Value = c5.ToString("n0");
                            dgv1.Rows[0].Cells[6].Value = c6.ToString("C2");
                            dgv1.Rows[0].Cells[7].Value = c7.ToString("n0");
                            dgv1.Refresh();
                        }
                        
                        #endregion
                        break;
                    case 2:
                        #region renglontotal
                        c1 = 0;
                        c2 = 0;
                        c3 = 0;
                        c4 = 0;
                        c5 = 0;
                        c6 = 0;
                        c7 = 0;
                        c8 = 0;
                        c9 = 0;
                        c10 = 0;
                        c11 = 0;
                        c12 = 0;
                        c13 = 0;
                        c14 = 0;
                        c15 = 0;
                        for (int i = 1; i <= dgv2.Rows.Count - 1; i++)
                        {
                            if (dgv2.Rows[i].Cells[1].Value != null && dgv2.Rows[i].Cells[1].Value.ToString() != " ")
                            {
                                c1 += double.Parse(dgv2.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c1 = c1 + 0;
                            }
                            if (dgv2.Rows[i].Cells[2].Value != null && dgv2.Rows[i].Cells[2].Value.ToString() != " ")
                            {
                                c2 += double.Parse(dgv2.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c2 = c2 + 0;
                            }
                            if (dgv2.Rows[i].Cells[3].Value != null && dgv2.Rows[i].Cells[3].Value.ToString() != " ")
                            {
                                c3 += double.Parse(dgv2.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c3 = c3 + 0;
                            }
                            if (dgv2.Rows[i].Cells[4].Value != null && dgv2.Rows[i].Cells[4].Value.ToString() != " ")
                            {
                                c4 += double.Parse(dgv2.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c4 = c4 + 0;
                            }
                            if (dgv2.Rows[i].Cells[5].Value != null && dgv2.Rows[i].Cells[5].Value.ToString() != " ")
                            {
                                c5 += double.Parse(dgv2.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c5 = c5 + 0;
                            }
                            if (dgv2.Rows[i].Cells[6].Value != null && dgv2.Rows[i].Cells[6].Value.ToString() != " ")
                            {
                                c6 += double.Parse(dgv2.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c6 = c6 + 0;
                            }
                            if (dgv2.Rows[i].Cells[7].Value != null && dgv2.Rows[i].Cells[7].Value.ToString() != " ")
                            {
                                c7 += double.Parse(dgv2.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c7 = c7 + 0;
                            }

                            dgv2.Rows[0].Cells[1].Value = c1.ToString("n0");
                            dgv2.Rows[0].Cells[2].Value = c2.ToString("n2");
                            dgv2.Rows[0].Cells[3].Value = c3.ToString("n2");
                            dgv2.Rows[0].Cells[4].Value = c4.ToString("n0");
                            dgv2.Rows[0].Cells[5].Value = c5.ToString("n0");
                            dgv2.Rows[0].Cells[6].Value = c6.ToString("C2");
                            dgv2.Rows[0].Cells[7].Value = c7.ToString("n0");
                            dgv2.Refresh();
                        }

                        #endregion
                        break;
                    case 3:
                        #region renglontotal
                        c1 = 0;
                        c2 = 0;
                        c3 = 0;
                        c4 = 0;
                        c5 = 0;
                        c6 = 0;
                        c7 = 0;
                        c8 = 0;
                        c9 = 0;
                        c10 = 0;
                        c11 = 0;
                        c12 = 0;
                        c13 = 0;
                        c14 = 0;
                        c15 = 0;
                        for (int i = 1; i <= dgv3.Rows.Count - 1; i++)
                        {
                            if (dgv3.Rows[i].Cells[1].Value != null && dgv3.Rows[i].Cells[1].Value.ToString() != " ")
                            {
                                c1 += double.Parse(dgv3.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c1 = c1 + 0;
                            }
                            if (dgv3.Rows[i].Cells[2].Value != null && dgv3.Rows[i].Cells[2].Value.ToString() != " ")
                            {
                                c2 += double.Parse(dgv3.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c2 = c2 + 0;
                            }
                            if (dgv3.Rows[i].Cells[3].Value != null && dgv3.Rows[i].Cells[3].Value.ToString() != " ")
                            {
                                c3 += double.Parse(dgv3.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c3 = c3 + 0;
                            }
                            if (dgv3.Rows[i].Cells[4].Value != null && dgv3.Rows[i].Cells[4].Value.ToString() != " ")
                            {
                                c4 += double.Parse(dgv3.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c4 = c4 + 0;
                            }
                            if (dgv3.Rows[i].Cells[5].Value != null && dgv3.Rows[i].Cells[5].Value.ToString() != " ")
                            {
                                c5 += double.Parse(dgv3.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c5 = c5 + 0;
                            }
                            if (dgv3.Rows[i].Cells[6].Value != null && dgv3.Rows[i].Cells[6].Value.ToString() != " ")
                            {
                                c6 += double.Parse(dgv3.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c6 = c6 + 0;
                            }
                            if (dgv3.Rows[i].Cells[7].Value != null && dgv3.Rows[i].Cells[7].Value.ToString() != " ")
                            {
                                c7 += double.Parse(dgv3.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c7 = c7 + 0;
                            }

                            dgv3.Rows[0].Cells[1].Value = c1.ToString("n0");
                            dgv3.Rows[0].Cells[2].Value = c2.ToString("n2");
                            dgv3.Rows[0].Cells[3].Value = c3.ToString("n2");
                            dgv3.Rows[0].Cells[4].Value = c4.ToString("n0");
                            dgv3.Rows[0].Cells[5].Value = c5.ToString("n0");
                            dgv3.Rows[0].Cells[6].Value = c6.ToString("C2");
                            dgv3.Rows[0].Cells[7].Value = c7.ToString("n0");
                            dgv3.Refresh();
                        }

                        #endregion
                        break;
                }
            }
        }
        public void m_cantidadXmes(string fecha_inicio, string fecha_final) /////////////////////////////se usa en todos 
        {

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
                            cantidadmes++;
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
                            cantidadmes++;
                        }
                        catch (Exception x)
                        { MessageBox.Show("Error con las fechas " + x); }
                    }
                }
                fecha_inicio_mes = 1;
            }
            #endregion
        }
        public void m_DIASMESESANOS_guardar(string fecha_inicio, string fecha_final) /////////////////////////////se usa en todos 
        {
            tabcontrol.SelectedIndex = 0;
            int fecha_inicio_dia = Convert.ToInt32(fecha_inicio.Substring(0, 2));
            int fecha_inicio_mes = Convert.ToInt32(fecha_inicio.Substring(3, 2));
            int fecha_inicio_ano = 1 + (Convert.ToInt32(fecha_inicio.Substring(6, 4)));

            int fecha_final_dia = Convert.ToInt32(fecha_final.Substring(0, 2));
            int fecha_final_mes = Convert.ToInt32(fecha_final.Substring(3, 2));
            int fecha_final_ano = 1 + (Convert.ToInt32(fecha_final.Substring(6, 4)));

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
            for (int x = 1; x <= dgv1.Rows.Count - 1; x++)
            {
                string s = "SELECT * FROM cedula5b where nombre='" + Properties.Settings.Default.escenario + "' and anio=" + año + " and mes=" + mes + " and idsucursal=" + idsucursales[(x - 1)];
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
            double c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15;
            switch (grid)
            {
                case 1:
                    #region insertar cedula1
                    c1 = double.Parse(dgv1.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv1.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv1.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv1.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv1.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv1.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv1.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    string s = "insert into cedula5b (nombre,DPMA,rotacioncuentasxp,plazomediopagos,plazomediocobros,diasfin,diasfinimp,diasfinutil,mes,anio,idsucursal) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + mes.ToString() + "," + año.ToString() + " ,"+idsucursales[(renglon - 1)] + ")";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 2:
                    #region insertar cedula1
                    c1 = double.Parse(dgv2.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv2.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv2.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv2.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv2.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv2.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                     s = "insert into cedula5b (nombre,DPMA,rotacioncuentasxp,plazomediopagos,plazomediocobros,diasfin,diasfinimp,diasfinutil,mes,anio,idsucursal) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + mes.ToString() + "," + año.ToString() + " ," + idsucursales[(renglon - 1)] + ")";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 3:
                    #region insertar cedula1
                    c1 = double.Parse(dgv3.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv3.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv3.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv3.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv3.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv3.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv3.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula5b (nombre,DPMA,rotacioncuentasxp,plazomediopagos,plazomediocobros,diasfin,diasfinimp,diasfinutil,mes,anio,idsucursal) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + mes.ToString() + "," + año.ToString() + " ," + idsucursales[(renglon - 1)] + ")";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 4:
                    #region insertar cedula1
                    c1 = double.Parse(dgv4.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv4.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv4.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv4.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv4.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv4.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv4.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula5b (nombre,DPMA,rotacioncuentasxp,plazomediopagos,plazomediocobros,diasfin,diasfinimp,diasfinutil,mes,anio,idsucursal) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + mes.ToString() + "," + año.ToString() + " ," + idsucursales[(renglon - 1)] + ")";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 5:
                    #region insertar cedula1
                    c1 = double.Parse(dgv5.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv5.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv5.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv5.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv5.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv5.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv5.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula5b (nombre,DPMA,rotacioncuentasxp,plazomediopagos,plazomediocobros,diasfin,diasfinimp,diasfinutil,mes,anio,idsucursal) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + mes.ToString() + "," + año.ToString() + " ," + idsucursales[(renglon - 1)] + ")";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 6:
                    #region insertar cedula1
                    c1 = double.Parse(dgv6.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv6.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv6.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv6.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv6.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv6.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv6.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula5b (nombre,DPMA,rotacioncuentasxp,plazomediopagos,plazomediocobros,diasfin,diasfinimp,diasfinutil,mes,anio,idsucursal) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + mes.ToString() + "," + año.ToString() + " ," + idsucursales[(renglon - 1)] + ")";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 7:
                    #region insertar cedula1
                    c1 = double.Parse(dgv7.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv7.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv7.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv7.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv7.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv7.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv7.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula5b (nombre,DPMA,rotacioncuentasxp,plazomediopagos,plazomediocobros,diasfin,diasfinimp,diasfinutil,mes,anio,idsucursal) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + mes.ToString() + "," + año.ToString() + " ," + idsucursales[(renglon - 1)] + ")";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 8:
                    #region insertar cedula1
                    c1 = double.Parse(dgv8.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv8.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv8.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv8.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv8.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv8.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv8.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula5b (nombre,DPMA,rotacioncuentasxp,plazomediopagos,plazomediocobros,diasfin,diasfinimp,diasfinutil,mes,anio,idsucursal) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + mes.ToString() + "," + año.ToString() + " ," + idsucursales[(renglon - 1)] + ")";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 9:
                    #region insertar cedula1
                    c1 = double.Parse(dgv9.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv9.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv9.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv9.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv9.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv9.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv9.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula5b (nombre,DPMA,rotacioncuentasxp,plazomediopagos,plazomediocobros,diasfin,diasfinimp,diasfinutil,mes,anio,idsucursal) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + mes.ToString() + "," + año.ToString() + " ," + idsucursales[(renglon - 1)] + ")";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 10:
                    #region insertar cedula1
                    c1 = double.Parse(dgv10.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv10.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv10.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv10.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv10.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv10.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv10.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula5b (nombre,DPMA,rotacioncuentasxp,plazomediopagos,plazomediocobros,diasfin,diasfinimp,diasfinutil,mes,anio,idsucursal) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + mes.ToString() + "," + año.ToString() + " ," + idsucursales[(renglon - 1)] + ")";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 11:
                    #region insertar cedula1
                    c1 = double.Parse(dgv11.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv11.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv11.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv11.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv11.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv11.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv11.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula5b (nombre,DPMA,rotacioncuentasxp,plazomediopagos,plazomediocobros,diasfin,diasfinimp,diasfinutil,mes,anio,idsucursal) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + mes.ToString() + "," + año.ToString() + " ," + idsucursales[(renglon - 1)] + ")";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 12:
                    #region insertar cedula1
                    c1 = double.Parse(dgv12.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv12.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv12.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv12.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv12.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv12.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv12.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    s = "insert into cedula5b (nombre,DPMA,rotacioncuentasxp,plazomediopagos,plazomediocobros,diasfin,diasfinimp,diasfinutil,mes,anio,idsucursal) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + mes.ToString() + "," + año.ToString() + " ," + idsucursales[(renglon - 1)] + ")";
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
            }
        }
        public void update(int año, int mes, int grid, int renglon)
        {
            double c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15;
            switch (grid)
            {
                case 1:
                    #region insertar cedula1
                    c1 = double.Parse(dgv1.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv1.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv1.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv1.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv1.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv1.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv1.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                   
                    string s = "update cedula5b set DPMA=" + c1.ToString() + ",rotacioncuentasxp=" + c2.ToString() + ",plazomediopagos=" + c3.ToString() + ",plazomediocobros=" + c4.ToString() + ",diasfin=" + c5.ToString() + ",diasfinimp=" + c6.ToString() + ",diasfinutil=" + c7.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " and idsucursal="+idsucursales[(renglon - 1)];
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 2:
                    #region insertar cedula1
                    c1 = double.Parse(dgv2.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv2.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv2.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv2.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv2.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv2.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);

                     s = "update cedula5b set DPMA=" + c1.ToString() + ",rotacioncuentasxp=" + c2.ToString() + ",plazomediopagos=" + c3.ToString() + ",plazomediocobros=" + c4.ToString() + ",diasfin=" + c5.ToString() + ",diasfinimp=" + c6.ToString() + ",diasfinutil=" + c7.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " and idsucursal=" + idsucursales[(renglon - 1)];
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 3:
                    #region insertar cedula1
                    c1 = double.Parse(dgv3.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv3.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv3.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv3.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv3.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv3.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv3.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);

                    s = "update cedula5b set DPMA=" + c1.ToString() + ",rotacioncuentasxp=" + c2.ToString() + ",plazomediopagos=" + c3.ToString() + ",plazomediocobros=" + c4.ToString() + ",diasfin=" + c5.ToString() + ",diasfinimp=" + c6.ToString() + ",diasfinutil=" + c7.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " and idsucursal=" + idsucursales[(renglon - 1)];
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 4:
                    #region insertar cedula1
                    c1 = double.Parse(dgv4.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv4.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv4.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv4.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv4.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv4.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv4.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);

                    s = "update cedula5b set DPMA=" + c1.ToString() + ",rotacioncuentasxp=" + c2.ToString() + ",plazomediopagos=" + c3.ToString() + ",plazomediocobros=" + c4.ToString() + ",diasfin=" + c5.ToString() + ",diasfinimp=" + c6.ToString() + ",diasfinutil=" + c7.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " and idsucursal=" + idsucursales[(renglon - 1)];
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 5:
                    #region insertar cedula1
                    c1 = double.Parse(dgv5.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv5.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv5.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv5.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv5.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv5.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv5.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);

                    s = "update cedula5b set DPMA=" + c1.ToString() + ",rotacioncuentasxp=" + c2.ToString() + ",plazomediopagos=" + c3.ToString() + ",plazomediocobros=" + c4.ToString() + ",diasfin=" + c5.ToString() + ",diasfinimp=" + c6.ToString() + ",diasfinutil=" + c7.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " and idsucursal=" + idsucursales[(renglon - 1)];
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 6:
                    #region insertar cedula1
                    c1 = double.Parse(dgv6.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv6.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv6.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv6.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv6.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv6.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv6.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);

                    s = "update cedula5b set DPMA=" + c1.ToString() + ",rotacioncuentasxp=" + c2.ToString() + ",plazomediopagos=" + c3.ToString() + ",plazomediocobros=" + c4.ToString() + ",diasfin=" + c5.ToString() + ",diasfinimp=" + c6.ToString() + ",diasfinutil=" + c7.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " and idsucursal=" + idsucursales[(renglon - 1)];
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 7:
                    #region insertar cedula1
                    c1 = double.Parse(dgv7.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv7.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv7.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv7.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv7.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv7.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv7.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);

                    s = "update cedula5b set DPMA=" + c1.ToString() + ",rotacioncuentasxp=" + c2.ToString() + ",plazomediopagos=" + c3.ToString() + ",plazomediocobros=" + c4.ToString() + ",diasfin=" + c5.ToString() + ",diasfinimp=" + c6.ToString() + ",diasfinutil=" + c7.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " and idsucursal=" + idsucursales[(renglon - 1)];
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 8:
                    #region insertar cedula1
                    c1 = double.Parse(dgv8.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv8.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv8.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv8.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv8.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv8.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv8.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);

                    s = "update cedula5b set DPMA=" + c1.ToString() + ",rotacioncuentasxp=" + c2.ToString() + ",plazomediopagos=" + c3.ToString() + ",plazomediocobros=" + c4.ToString() + ",diasfin=" + c5.ToString() + ",diasfinimp=" + c6.ToString() + ",diasfinutil=" + c7.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " and idsucursal=" + idsucursales[(renglon - 1)];
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 9:
                    #region insertar cedula1
                    c1 = double.Parse(dgv9.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv9.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv9.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv9.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv9.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv9.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv9.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);

                    s = "update cedula5b set DPMA=" + c1.ToString() + ",rotacioncuentasxp=" + c2.ToString() + ",plazomediopagos=" + c3.ToString() + ",plazomediocobros=" + c4.ToString() + ",diasfin=" + c5.ToString() + ",diasfinimp=" + c6.ToString() + ",diasfinutil=" + c7.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " and idsucursal=" + idsucursales[(renglon - 1)];
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 10:
                    #region insertar cedula1
                    c1 = double.Parse(dgv10.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv10.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv10.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv10.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv10.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv10.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv10.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);

                    s = "update cedula5b set DPMA=" + c1.ToString() + ",rotacioncuentasxp=" + c2.ToString() + ",plazomediopagos=" + c3.ToString() + ",plazomediocobros=" + c4.ToString() + ",diasfin=" + c5.ToString() + ",diasfinimp=" + c6.ToString() + ",diasfinutil=" + c7.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " and idsucursal=" + idsucursales[(renglon - 1)];
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 11:
                    #region insertar cedula1
                    c1 = double.Parse(dgv11.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv11.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv11.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv11.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv11.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv11.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv11.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);

                    s = "update cedula5b set DPMA=" + c1.ToString() + ",rotacioncuentasxp=" + c2.ToString() + ",plazomediopagos=" + c3.ToString() + ",plazomediocobros=" + c4.ToString() + ",diasfin=" + c5.ToString() + ",diasfinimp=" + c6.ToString() + ",diasfinutil=" + c7.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " and idsucursal=" + idsucursales[(renglon - 1)];
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 12:
                    #region insertar cedula1
                    c1 = double.Parse(dgv12.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv12.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv12.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv12.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv12.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv12.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv12.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);

                    s = "update cedula5b set DPMA=" + c1.ToString() + ",rotacioncuentasxp=" + c2.ToString() + ",plazomediopagos=" + c3.ToString() + ",plazomediocobros=" + c4.ToString() + ",diasfin=" + c5.ToString() + ",diasfinimp=" + c6.ToString() + ",diasfinutil=" + c7.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " and idsucursal=" + idsucursales[(renglon - 1)];
                    cmd = new MySqlCommand(s, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
            }
        }

    }
}
