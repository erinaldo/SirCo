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
    public partial class Cedula7 : Form
    {
        double ponderacion80 = 80; double ponderacion20 = 20;
        //double asignacion20 = 20; double asignacion80 = 80;
        //double prof20 = 20; double prof80 = 80;
        int calculos = 1;
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
        string[] queryCapacidad=new string[10000];
        string Aseleccion_marca = "";
        bool proyectar = false;
        bool generarcedula7 = false;

        #region variables conexion

        private MySqlCommand cmd;
        private string conexion = "SERVER=" + Properties.Settings.Default.server + "; DATABASE=dwh; user=" + Properties.Settings.Default.usuario + "; PASSWORD=" + Properties.Settings.Default.pass + ";";
        private string conexion2 = "SERVER=" + Properties.Settings.Default.server + "; DATABASE=cipsis; user=" + Properties.Settings.Default.usuario + "; PASSWORD=" + Properties.Settings.Default.pass + ";";
        // private string conexion = "SERVER=localhost; DATABASE=dwh; user=root; PASSWORD= ;";
        private MySqlConnection Conn;
        private MySqlConnection ConnCipsis;
        private string query;
        private MySqlDataReader reader;
        #endregion variables conexion
        #region variables_globales

        private string[] idd = new string[1000];
        DateTime FechaAF = DateTime.Now, FechaAI = DateTime.Now;
        DateTime fech1 = DateTime.Now, fech2 = DateTime.Now;
        double[] compras=new double[1000];

        #endregion variables_globales
        #region variables escenario

        string CED1_fechaI = "";
        string CED1_fechaF = "";
        string idsucursalvarios = "(E.idsucursal= '01' OR E.idsucursal='02' OR E.idsucursal='06' OR E.idsucursal='08')";
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
        bool total = true;
        string solocalzadoDropdown = "";
        string solocalzadowhere = " ";
        string[] queryguardar = new string[1000];
        string[] querycargar = new string[1000];
        string[] queryplazo = new string[1000];
        string[] queryExist = new string[1000];
        bool solototal;
        string sucursalcargar, divisioncargar, departamentocargar, familiacargar, lineacargar, l1cargar, l2cargar, l3cargar, l4cargar, l5cargar, l6cargar;
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


        public Cedula7()
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
            #region Abrir conexion cipsis

            ConnCipsis = new MySqlConnection(conexion2);
            try
            {
                ConnCipsis.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            #endregion Abrir conexion cipsis

            tabcontrol.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabcontrol.DrawItem += new DrawItemEventHandler(tabcontrol_DrawItem);
        }

        public Cedula7(bool band_sucursal, int selecc_sucursal, bool band_division, int selecc_division,
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
            Cedula3 c3 = new Cedula3();
            this.Hide();
            c3.ShowDialog();
            this.Close();

        }
        private void button7_Click(object sender, EventArgs e)
        {
            cedula4 c4 = new cedula4();
            this.Hide();
            c4.ShowDialog();
            this.Close();
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
        private void button10_Click(object sender, EventArgs e)
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
        private void button9_Click(object sender, EventArgs e)
        {
            if (bandera_sucursal == true)
            {
                Cedula8 c8 = new Cedula8(seleccion_sucursal, seleccion_division, seleccion_depto, seleccion_familia, seleccion_linea, seleccion_l1, seleccion_l2, seleccion_l3, seleccion_l4, seleccion_l5, seleccion_l6, seleccion_marca);
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

        private void Cedula7_Load(object sender, EventArgs e) ////////////////////////////////////////////////////////lol
        {
            #region Abrir conexion cipsis

            ConnCipsis = new MySqlConnection(conexion2);
            try
            {
                ConnCipsis.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            #endregion Abrir conexion cipsis
            m_ESCENARIO(Properties.Settings.Default.escenario); // m_ESCENARIO("miercoles");
            M_pintarcolumnas();
            this.Refresh();
            #region valores cedula anterior PABLO
            //if (bandera_sucursal == true)
            //{ m_drop_sucursales(); cbSucursales.SelectedIndex = seleccion_sucursal; }
            //if (bandera_division == true)
            //{ m_drop_division(); cbDivisiones.SelectedIndex = seleccion_division; }
            //if (bandera_depto == true)
            //{ m_drop_depto(); cbDepto.SelectedIndex = seleccion_depto; }
            //if (bandera_familia == true)
            //{ m_drop_familia(); cbFamilia.SelectedIndex = seleccion_familia; }
            //if (bandera_linea == true)
            //{ m_drop_linea(); cbLinea.SelectedIndex = seleccion_linea; }
            //if (bandera_l1 == true)
            //{ m_drop_l1(); cbL1.SelectedIndex = seleccion_l1; }
            //if (bandera_l2 == true)
            //{ m_drop_l2(); cbL2.SelectedIndex = seleccion_l2; }
            //if (bandera_l3 == true)
            //{ m_drop_l3(); cbL3.SelectedIndex = seleccion_l3; }
            //if (bandera_l4 == true)
            //{ m_drop_l4(); cbL4.SelectedIndex = seleccion_l4; }
            //if (bandera_l5 == true)
            //{ m_drop_l5(); cbL5.SelectedIndex = seleccion_l5; }
            //if (bandera_l6 == true)
            //{ m_drop_l6(); cbL3.SelectedIndex = seleccion_l6; }
            //if (bandera_marca == true)
            //{ m_drop_marca(); cbMarca.SelectedIndex = int.Parse(seleccion_marca.ToString()); }
            /*      
        bool bandera_l1 = false; int seleccion_l1 = 0;
        bool bandera_l2 = false; int seleccion_l2 = 0;
        bool bandera_l3 = false; int seleccion_l3 = 0;
        bool bandera_l4 = false; int seleccion_l4 = 0;
        bool bandera_l5 = false; int seleccion_l5 = 0;
        bool bandera_l6 = false; int seleccion_l6 = 0;
        bool bandera_marca = false; int seleccion_marca = 0; */

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
                m_drop_sucursales();

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
            this.Refresh();
            #endregion


            #region si hay valores cedula anterior 
            if (valoresform == true)
            {
                tabcontrol.SelectedIndex = 0;
                m_ESTRUCTURA();
                m_DIASMESESANOS(CED1_fechaI, CED1_fechaF);
                //for (int i = 1; i < calculos; i++)
                //{ m_CALCULOS(i); }
                tabcontrol.SelectedIndex = 0;
            }
            #endregion
            if(generarcedula7==true)
            {
                generar_cedula7Automatico(sender,e);
            }
        }


        #region combos
        private void cbSucursales_DropDown(object sender, EventArgs e)
        {

            #region reiniciar valores
            lbsucursal.Text = "Sucursal";
            lbDivision.Text = "Division";
            lbdepartamento.Text = "Departamento";
            lbfamilia.Text = "Familia";
            lblinea.Text = "Linea";
            lbl1.Text = "L1";
            lbL2.Text = "L2";
            lbL3.Text = "L3";
            lbL4.Text = "L4";
            lbL5.Text = "L5";
            lbL6.Text = "L6";
            lbMarca.Text = "Marca";
            idsucursal = " ";
            idsucursal = " ";
            iddivision = " ";
            iddepto = " ";
            idfamilia = " ";
            idlinea = " ";
            idl1 = " ";
            idl2 = " ";
            idl3 = " ";
            idl4 = " ";
            idl5 = " ";
            idl6 = " ";
            marca = " ";
            #endregion
            cbSucursales.Items.Clear();
            cbSucursales.Items.Add("Total");
            int i = 1;
            query = "SELECT descrip,idsucursal from sucursal where visible='S'";
            checaConexion();
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
        private void cbSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            bandera_sucursal = true;/////pablo 
            #region banderas
            bandera_division = false;
            bandera_depto = false;
            bandera_familia = false;
            bandera_linea = false;
            bandera_l1 = false;
            bandera_l2 = false;
            bandera_l3 = false;
            bandera_l4 = false;
            bandera_l5 = false;
            bandera_l6 = false;
            bandera_marca = false;
            seleccion_division = -1;
            seleccion_depto = -1;
            seleccion_familia = -1;
            seleccion_linea = -1;
            seleccion_l1 = -1;
            seleccion_l2 = -1;
            seleccion_l3 = -1;
            seleccion_l4 = -1;
            seleccion_l5 = -1;
            seleccion_l6 = -1;
            seleccion_marca = "";
            #endregion
            #region reiniciar valores
            lbDivision.Text = "Division";
            lbdepartamento.Text = "Departamento";
            lbfamilia.Text = "Familia";
            lblinea.Text = "Linea";
            lbl1.Text = "L1";
            lbL2.Text = "L2";
            lbL3.Text = "L3";
            lbL4.Text = "L4";
            lbL5.Text = "L5";
            lbL6.Text = "L6";
            lbMarca.Text = "Marca";
            idsucursal = " ";
            iddivision = " ";
            iddepto = " ";
            idfamilia = " ";
            idlinea = " ";
            idl1 = " ";
            idl2 = " ";
            idl3 = " ";
            idl4 = " ";
            idl5 = " ";
            idl6 = " ";
            marca = " ";
            s = ",-1"; d = ",-1"; dd = ",-1"; f = ",-1"; l = ",-1"; l1 = ",-1"; l2 = ",-1"; l3 = ",-1"; l4 = ",-1"; l5 = ",-1"; l6 = ",-1"; m = ",'-1'";
            #endregion

            if (cbSucursales.Text != "Total")
            {
                seleccion_sucursal = int.Parse(idd[cbSucursales.SelectedIndex].ToString());

                idsucursal = " and V.idsucursal=" + idd[cbSucursales.SelectedIndex];
                wherequery[0] = "and V.idsucursal=" + idd[cbSucursales.SelectedIndex] + " " + solocalzadowhere;
                total = false;
                string[] texto = cbSucursales.Text.Split('=');
                lbsucursal.Text = "Sucursal=" + texto[0];
                query = "SELECT descrip,idsucursal from sucursal where visible='S' and idsucursal=" + idd[cbSucursales.SelectedIndex] + "";
                queryguardar[0] = "," + idd[cbSucursales.SelectedIndex] + ",-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,'-1'";
                idsucursalvarios = "and V.idsucursal=" + idd[cbSucursales.SelectedIndex];
                s = "," + idd[cbSucursales.SelectedIndex];
                querycargar[0] = "and idsucursal=" + idd[cbSucursales.SelectedIndex] + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'";
                queryplazo[0] = " ";
                queryExist[0] = "and V.idsucursal=" + idd[cbSucursales.SelectedIndex];
                sucursalcargar = "and idsucursal=" + idd[cbSucursales.SelectedIndex] + "";
                queryCapacidad[0] = "and v.sucursal="+idd[cbSucursales.SelectedIndex]+" "+solocalzadowhere;
            }
            else
            {
                idsucursalvarios = "and (V.IDSUCURSAL= '01' OR V.IDSUCURSAL='02' OR V.IDSUCURSAL='06' OR V.IDSUCURSAL='08')";
                for (int i = 0; i <= cbSucursales.Items.Count - 1; i++)
                {
                    querycargar[i] = "and idsucursal=" + idd[(i + 1)] + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                    idsucursal = "and V.idsucursal= " + idd[(i + 1)];
                    wherequery[i] = "and V.idsucursal=" + idd[(i + 1)] + " " + solocalzadowhere;
                    queryguardar[i] = "," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,'-1'";
                    queryplazo[i] = " ";
                    queryExist[i] = "and V.idsucursal=" + idd[(i + 1)];
                    queryCapacidad[i] = "and v.sucursal=" + idd[i] + " " + solocalzadowhere;
                }
                lbsucursal.Text = "Sucursal=Total";
                query = "SELECT descrip,idsucursal from sucursal where visible='S'";
                total = true;
                s = ",0";
                sucursalcargar = "and idsucursal=0";
                seleccion_sucursal = 0;
            }
            if (!valoresform)
                M_cargargrid(total); solototal = false;
        }
        private void cbDivision_DropDown(object sender, EventArgs e)
        {
            //int i = 0;

            int i = 1;

            cbDivisiones.Items.Clear();
            cbDivisiones.Items.Add("Total");


            //cbDivisiones.Items.Clear();
            /* if (solocalzadoDropdown == " and iddivisiones=1")
             {
                 i = 0;
             }
             else
             {
                 i = 1;
                 cbDivisiones.Items.Add("Total");
             }*/
            query = "SELECT descrip,iddivisiones from estdivisiones where visiblebp='1' and iddivisiones=1 " + solocalzadoDropdown;
            checaConexion();
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbDivisiones.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["iddivisiones"].ToString();
                i++;
            }
            reader.Close();
        }
        private void cbDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            bandera_division = true; //pablo  
            #region banderas
            bandera_depto = false;
            bandera_familia = false;
            bandera_linea = false;
            bandera_l1 = false;
            bandera_l2 = false;
            bandera_l3 = false;
            bandera_l4 = false;
            bandera_l5 = false;
            bandera_l6 = false;
            bandera_marca = false;
            seleccion_depto = -1;
            seleccion_familia = -1;
            seleccion_linea = -1;
            seleccion_l1 = -1;
            seleccion_l2 = -1;
            seleccion_l3 = -1;
            seleccion_l4 = -1;
            seleccion_l5 = -1;
            seleccion_l6 = -1;
            seleccion_marca = "";
            #endregion
            #region reiniciar valores
            lbdepartamento.Text = "Departamento";
            lbfamilia.Text = "Familia";
            lblinea.Text = "Linea";
            lbl1.Text = "L1";
            lbL2.Text = "L2";
            lbL3.Text = "L3";
            lbL4.Text = "L4";
            lbL5.Text = "L5";
            lbL6.Text = "L6";
            lbMarca.Text = "Marca";
            iddivision = " ";
            iddepto = " ";
            idfamilia = " ";
            idlinea = " ";
            idl1 = " ";
            idl2 = " ";
            idl3 = " ";
            idl4 = " ";
            idl5 = " ";
            idl6 = " ";
            marca = " ";
            d = ",-1"; dd = ",-1"; f = ",-1"; l = ",-1"; l1 = ",-1"; l2 = ",-1"; l3 = ",-1"; l4 = ",-1"; l5 = ",-1"; l6 = ",-1"; m = ",'-1'";
            #endregion
            if (cbDivisiones.Text != "Total")
            {
                seleccion_division = int.Parse(idd[cbDivisiones.SelectedIndex].ToString());

                iddivision = "and V.iddivisiones=" + idd[cbDivisiones.SelectedIndex];
                total = false;
                string[] texto = cbDivisiones.Text.Split('=');
                lbDivision.Text = "Division=" + texto[0];
                query = "SELECT descrip,iddivisiones from estdivisiones where visiblebp='1' and iddivisiones=" + idd[cbDivisiones.SelectedIndex];
                wherequery[0] = idsucursalvarios + " " + iddivision;
                iddivisionesvarios = iddivision;
                division = "and iddivisiones=" + idd[cbDivisiones.SelectedIndex];
                queryguardar[0] = s + "," + idd[cbDivisiones.SelectedIndex] + ",-1,-1,-1,-1,-1,-1,-1,-1,-1,'-1'";
                querycargar[0] = sucursalcargar + " and iddivisiones=" + idd[cbDivisiones.SelectedIndex] + " and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                d = "," + idd[cbDivisiones.SelectedIndex];
                queryplazo[0] = "Where V.iddivisiones=" + idd[cbDivisiones.SelectedIndex];
                queryExist[0] = idsucursalvarios.Replace("V", "E") + " " + iddivision;
                divisioncargar = "and iddivisiones=" + idd[cbDivisiones.SelectedIndex] + "";
                queryCapacidad[0] = "and v.sucursal=" + idd[cbSucursales.SelectedIndex] + " " + solocalzadowhere;
            }
            else
            {
                iddivision = " ";
                iddivisionesvarios = " ";
                division = " ";
                for (int i = 0; i <= cbDivisiones.Items.Count - 1; i++)
                {
                    querycargar[i] = sucursalcargar + " and iddivisiones=" + idd[(i + 1)] + " and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                    iddivision = "and V.iddivisiones=" + idd[(i + 1)];
                    wherequery[i] = idsucursalvarios + " " + iddivision;
                    queryguardar[i] = s + "," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,-1,-1,-1,'-1'";
                    queryplazo[i] = "Where V.iddivisiones=" + idd[(i + 1)];
                    queryExist[i] = idsucursalvarios.Replace("V", "E") + " " + iddivision;
                }
                lbDivision.Text = "Division=Total";
                total = true;
                d = ",0";
                divisioncargar = "and iddivisiones=0";
                seleccion_division = 0;
            }
            if (!valoresform)
                M_cargargrid(total);
            solototal = false;
        }
        private void cbDepto_DropDown(object sender, EventArgs e)
        {
            cbDepto.Items.Clear();
            cbDepto.Items.Add("Total");
            string[] texto = iddivision.Split('.');
            int i = 1;

            query = "SELECT descrip,iddepto from estdepartamento where visiblebp='1' " + division + "";
            checaConexion();
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbDepto.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["iddepto"].ToString();
                i++;
            }
            reader.Close();

        }
        private void cbDepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            bandera_depto = true;/////pablo
            #region banderas
            bandera_familia = false;
            bandera_linea = false;
            bandera_l1 = false;
            bandera_l2 = false;
            bandera_l3 = false;
            bandera_l4 = false;
            bandera_l5 = false;
            bandera_l6 = false;
            bandera_marca = false;
            seleccion_familia = -1;
            seleccion_linea = -1;
            seleccion_l1 = -1;
            seleccion_l2 = -1;
            seleccion_l3 = -1;
            seleccion_l4 = -1;
            seleccion_l5 = -1;
            seleccion_l6 = -1;
            seleccion_marca = "";
            #endregion
            #region reiniciar valores
            lbfamilia.Text = "Familia";
            lblinea.Text = "Linea";
            lbl1.Text = "L1";
            lbL2.Text = "L2";
            lbL3.Text = "L3";
            lbL4.Text = "L4";
            lbL5.Text = "L5";
            lbL6.Text = "L6";
            lbMarca.Text = "Marca";
            iddepto = " ";
            idfamilia = " ";
            idlinea = " ";
            idl1 = " ";
            idl2 = " ";
            idl3 = " ";
            idl4 = " ";
            idl5 = " ";
            idl6 = " ";
            marca = " ";
            #endregion
            if (cbDepto.Text != "Total")
            {
                seleccion_depto = int.Parse(idd[cbDepto.SelectedIndex].ToString());

                iddepto = "and V.iddepto=" + idd[cbDepto.SelectedIndex];
                wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddepto;
                iddeptovarios = iddepto;
                total = false;
                string[] texto = cbDepto.Text.Split('=');
                lbdepartamento.Text = "Departamento=" + texto[0];
                query = "SELECT descrip,iddepto from estdepartamento where visiblebp='1' and iddepto=" + idd[cbDepto.SelectedIndex];
                depto = "and iddepto=" + idd[cbDepto.SelectedIndex];
                queryguardar[0] = s + " " + d + "," + idd[cbDepto.SelectedIndex] + ",-1,-1,-1,-1,-1,-1,-1,-1,'-1'";
                dd = "," + idd[cbDepto.SelectedIndex];
                querycargar[0] = sucursalcargar + " " + divisioncargar + " and iddepto=" + idd[cbDepto.SelectedIndex] + " and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                queryplazo[0] = "Where V.iddivisiones=" + d.Substring(1, d.Length - 1) + " " + iddepto;
                queryExist[0] = idsucursalvarios.Replace("V", "E") + " " + iddivisionesvarios + " " + iddepto;
                departamentocargar = "and iddepto=" + idd[cbDepto.SelectedIndex];
            }
            else
            {
                iddepto = " ";
                iddeptovarios = " ";
                for (int i = 0; i <= cbDepto.Items.Count - 1; i++)
                {
                    querycargar[i] = sucursalcargar + " " + divisioncargar + " and iddepto=" + idd[(i + 1)] + " and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                    iddepto = "and V.iddepto=" + idd[(i + 1)];
                    wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + " " + iddepto;
                    queryguardar[i] = s + " " + d + " ," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,-1,-1,'-1'";
                    queryplazo[i] = "Where V.iddivisiones=" + d.Substring(1, d.Length - 1) + " " + iddepto;
                    queryExist[i] = idsucursalvarios.Replace("V", "E") + " " + iddivisionesvarios + " " + iddepto;
                }
                total = true;
                query = "SELECT descrip,iddepto from estdepartamento where visiblebp='1' " + division;
                lbdepartamento.Text = "Departamento=Total";
                depto = " ";
                dd = ",0";
                departamentocargar = "and iddepto=0";
                seleccion_depto = 0;
            }
            if (!valoresform)
                M_cargargrid(total);
            solototal = false;
        }
        private void cbFamilia_DropDown(object sender, EventArgs e)
        {
            cbFamilia.Items.Clear();
            cbFamilia.Items.Add("Total");
            int i = 1;

            query = "SELECT descrip,idfamilia from estfamilia where visiblebp='1' " + division + " " + depto + "";
            checaConexion();
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbFamilia.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["idfamilia"].ToString();
                i++;
            }
            reader.Close();
        }
        private void cbFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {
            bandera_familia = true; /////pablo
            #region banderas
            bandera_linea = false;
            bandera_l1 = false;
            bandera_l2 = false;
            bandera_l3 = false;
            bandera_l4 = false;
            bandera_l5 = false;
            bandera_l6 = false;
            bandera_marca = false;
            seleccion_linea = -1;
            seleccion_l1 = -1;
            seleccion_l2 = -1;
            seleccion_l3 = -1;
            seleccion_l4 = -1;
            seleccion_l5 = -1;
            seleccion_l6 = -1;
            seleccion_marca = "";
            #endregion
            #region reiniciar valores
            lbfamilia.Text = "Familia";
            lblinea.Text = "Linea";
            lbl1.Text = "L1";
            lbL2.Text = "L2";
            lbL3.Text = "L3";
            lbL4.Text = "L4";
            lbL5.Text = "L5";
            lbL6.Text = "L6";
            lbMarca.Text = "Marca";
            idfamilia = " ";
            idlinea = " ";
            idl1 = " ";
            idl2 = " ";
            idl3 = " ";
            idl4 = " ";
            idl5 = " ";
            idl6 = " ";
            marca = " ";
            #endregion
            if (cbFamilia.Text != "Total")
            {
                seleccion_familia = int.Parse(idd[cbFamilia.SelectedIndex].ToString());

                idfamilia = "and V.idfamilia=" + idd[cbFamilia.SelectedIndex];
                idfamiliavarios = idfamilia;
                total = false;
                wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamilia;
                string[] texto = cbFamilia.Text.Split('=');
                lbfamilia.Text = "Familia=" + texto[0].ToString();
                query = "SELECT descrip,idfamilia from estfamilia where visiblebp='1' and idfamilia=" + idd[cbFamilia.SelectedIndex] + "";
                fam = "and idfamilia=" + idd[cbFamilia.SelectedIndex];
                queryguardar[0] = s + " " + d + " " + dd + "," + idd[cbFamilia.SelectedIndex] + ",-1,-1,-1,-1,-1,-1,-1,'-1'";
                f = "," + idd[cbFamilia.SelectedIndex];
                querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " and idfamilia=" + idd[cbFamilia.SelectedIndex] + " and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                queryplazo[0] = "Where V.iddivisiones=" + d.Substring(1, d.Length - 1) + " " + iddeptovarios + " " + idfamilia;
                queryExist[0] = idsucursalvarios.Replace("V", "E") + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamilia;
                familiacargar = "and idfamilia=" + idd[cbFamilia.SelectedIndex];
            }
            else
            {
                idfamiliavarios = " ";
                for (int i = 0; i <= cbFamilia.Items.Count - 1; i++)
                {
                    idfamilia = "and V.idfamilia=" + idd[(i + 1)];
                    wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamilia;
                    queryguardar[i] = s + " " + d + " " + dd + "," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,-1,'-1'";
                    querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " and idfamilia=" + idd[(i + 1)] + " and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                    queryplazo[i] = "Where V.iddivisiones=" + d.Substring(1, d.Length - 1) + " " + iddeptovarios + " " + idfamilia;
                    queryExist[i] = idsucursalvarios.Replace("V", "E") + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamilia;
                }
                total = true;
                query = "SELECT descrip,idfamilia from estfamilia where visiblebp='1' " + division + " " + depto;
                lbfamilia.Text = "Familia=Total";
                fam = " ";
                f = ",0";
                familiacargar = "and idfamilia=0";
                seleccion_familia = 0;
            }
            if (!valoresform)
                M_cargargrid(total);
            solototal = false;
        }
        private void cbLinea_DropDown(object sender, EventArgs e)
        {
            cbLinea.Items.Clear();
            cbLinea.Items.Add("Total");
            int i = 1;

            query = "SELECT descrip,idlinea from estlinea where visiblebp='1' " + division + " " + depto + "" + " " + fam;
            checaConexion();
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbLinea.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["idlinea"].ToString();
                i++;
            }
            reader.Close();
        }
        private void cbLinea_SelectedIndexChanged(object sender, EventArgs e)
        {
            bandera_linea = true;/////pablo
            #region banderas
            bandera_l1 = false;
            bandera_l2 = false;
            bandera_l3 = false;
            bandera_l4 = false;
            bandera_l5 = false;
            bandera_l6 = false;
            bandera_marca = false;
            seleccion_l1 = -1;
            seleccion_l2 = -1;
            seleccion_l3 = -1;
            seleccion_l4 = -1;
            seleccion_l5 = -1;
            seleccion_l6 = -1;
            seleccion_marca = "";
            #endregion
            #region reiniciar valores
            lblinea.Text = "Linea";
            lbl1.Text = "L1";
            lbL2.Text = "L2";
            lbL3.Text = "L3";
            lbL4.Text = "L4";
            lbL5.Text = "L5";
            lbL6.Text = "L6";
            lbMarca.Text = "Marca";
            idlinea = " ";
            idl1 = " ";
            idl2 = " ";
            idl3 = " ";
            idl4 = " ";
            idl5 = " ";
            idl6 = " ";
            marca = " ";
            #endregion
            if (cbLinea.Text != "Total")
            {
                seleccion_linea = int.Parse(idd[cbLinea.SelectedIndex].ToString());

                querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " and idlinea=" + idd[cbLinea.SelectedIndex] + " and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                idlinea = "and V.idlinea=" + idd[cbLinea.SelectedIndex];
                idlineavarios = idlinea;
                total = false;
                string[] texto = cbLinea.Text.Split('=');
                wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlinea;
                query = "SELECT descrip,idlinea from estlinea where visiblebp='1' and idlinea=" + idd[cbLinea.SelectedIndex] + "";
                linea = "and idlinea=" + idd[cbLinea.SelectedIndex];
                queryguardar[0] = s + " " + d + " " + dd + " " + f + "," + idd[cbLinea.SelectedIndex] + ",-1,-1,-1,-1,-1,-1,'-1'";
                l = "," + idd[cbLinea.SelectedIndex];
                queryplazo[0] = "Where V.iddivisiones=" + d.Substring(1, d.Length - 1) + " " + iddeptovarios + " " + idfamiliavarios + " " + idlinea;
                queryExist[0] = idsucursalvarios.Replace("V", "E") + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlinea; lineacargar = "and idlinea=" + idd[cbLinea.SelectedIndex];
            }
            else
            {
                idlineavarios = " ";
                for (int i = 0; i <= cbLinea.Items.Count - 1; i++)
                {
                    querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " and idlinea=" + idd[(i + 1)] + " and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                    idlinea = "and V.idlinea=" + idd[(i + 1)];
                    wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlinea;
                    queryguardar[i] = s + "  " + d + " " + dd + " " + f + "," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,'-1'";
                    queryplazo[i] = "Where V.iddivisiones=" + d.Substring(1, d.Length - 1) + " " + iddeptovarios + " " + idfamiliavarios + " " + idlinea;
                    queryExist[i] = idsucursalvarios.Replace("V", "E") + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlinea;
                }
                query = "SELECT descrip,idlinea from estlinea where visiblebp='1' " + division + " " + depto + "" + " " + fam;
                total = true;
                linea = " ";
                l = ",0";
                lineacargar = "and idlinea=0";
                seleccion_linea = 0;
            }
            lblinea.Text = "Linea=" + cbLinea.Text;
            if (!valoresform)
                M_cargargrid(total);
            solototal = false;
        }
        private void cbL1_DropDown(object sender, EventArgs e)
        {
            cbL1.Items.Clear();
            cbL1.Items.Add("Total");
            int i = 1;

            query = "SELECT descrip,idl1 from estl1 where visiblebp='1'" + division + " " + depto + " " + fam + " " + linea;
            checaConexion();
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbL1.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["idl1"].ToString();
                i++;
            }
            reader.Close();
        }
        private void cbL1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bandera_l1 = true; //pablo 
            #region banderas
            bandera_l2 = false;
            bandera_l3 = false;
            bandera_l4 = false;
            bandera_l5 = false;
            bandera_l6 = false;
            bandera_marca = false;
            seleccion_l2 = -1;
            seleccion_l3 = -1;
            seleccion_l4 = -1;
            seleccion_l5 = -1;
            seleccion_l6 = -1;
            seleccion_marca = "";
            #endregion
            #region reiniciar valores
            lbl1.Text = "L1";
            lbL2.Text = "L2";
            lbL3.Text = "L3";
            lbL4.Text = "L4";
            lbL5.Text = "L5";
            lbL6.Text = "L6";
            lbMarca.Text = "Marca";
            idl1 = " ";
            idl2 = " ";
            idl3 = " ";
            idl4 = " ";
            idl5 = " ";
            idl6 = " ";
            marca = " ";
            #endregion
            if (cbL1.Text != "Total")
            {
                seleccion_l1 = int.Parse(idd[cbL1.SelectedIndex].ToString());
                querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " and idl1=" + idd[cbL1.SelectedIndex] + " and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                idl1 = "and V.idl1=" + idd[cbL1.SelectedIndex];
                idl1varios = idl1;
                string[] texto = cbL1.Text.Split('=');
                total = false;
                lbl1.Text = "L1=" + texto[0].ToString();
                query = "SELECT descrip,idl1 from estl1 where visiblebp='1' and idl1=" + idd[cbL1.SelectedIndex];
                wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1;
                subl1 = "and idl1=" + idd[cbL1.SelectedIndex];
                queryguardar[0] = s + " " + d + " " + dd + " " + f + " " + l + "," + idd[cbL1.SelectedIndex] + ",-1,-1,-1,-1,-1,'-1'";
                l1 = "," + idd[cbL1.SelectedIndex];
                queryplazo[0] = " where V.iddivisiones= " + d.Substring(1, d.Length - 1) + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1;
                queryExist[0] = idsucursalvarios.Replace("V", "E") + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1;
                l1cargar = "and idl1=" + idd[cbL1.SelectedIndex];
            }
            else
            {
                for (int i = 0; i <= cbL1.Items.Count - 1; i++)
                {
                    querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " and idl1=" + idd[(i + 1)] + " and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                    idl1 = "and V.idl1=" + idd[(i + 1)];
                    wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1;
                    queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + "," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,'-1'";
                    queryplazo[i] = " where V.iddivisiones= " + d.Substring(1, d.Length - 1) + "  " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1;
                    queryExist[i] = idsucursalvarios.Replace("V", "E") + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1;
                }
                subl1 = " ";
                lbl1.Text = "L1=Total";
                total = true;
                query = "SELECT descrip,idl1 from estl1 where visiblebp='1' " + division + " " + depto + " " + fam + " " + linea;
                l = ",0";
                l1cargar = "and idl1=0";
                seleccion_l1 = 0;
            }
            lbl1.Text = "L1=" + cbL1.Text;
            if (!valoresform)
                M_cargargrid(total);
            solototal = false;
        }
        private void cbL2_DropDown(object sender, EventArgs e)
        {
            cbL2.Items.Clear();
            cbL2.Items.Add("Total");
            int i = 1;

            query = "SELECT descrip,idl2 from estl2 where visiblebp='1' " + division + " " + depto + " " + fam + " " + linea + " " + subl1;
            checaConexion();
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbL2.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["idl2"].ToString();
                i++;
            }
            reader.Close();
        }
        private void cbL2_SelectedIndexChanged(object sender, EventArgs e)
        {

            bandera_l2 = true; //pablo
            #region banderas
            bandera_l3 = false;
            bandera_l4 = false;
            bandera_l5 = false;
            bandera_l6 = false;
            bandera_marca = false;
            seleccion_l3 = -1;
            seleccion_l4 = -1;
            seleccion_l5 = -1;
            seleccion_l6 = -1;
            seleccion_marca = "";
            #endregion
            #region reiniciar valores
            lbL2.Text = "L2";
            lbL3.Text = "L3";
            lbL4.Text = "L4";
            lbL5.Text = "L5";
            lbL6.Text = "L6";
            lbMarca.Text = "Marca";
            idl2 = " ";
            idl3 = " ";
            idl4 = " ";
            idl5 = " ";
            idl6 = " ";
            marca = " ";
            #endregion
            if (cbL2.Text != "Total")
            {
                seleccion_l2 = int.Parse(idd[cbL2.SelectedIndex].ToString());

                querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " and idl2=" + idd[cbL2.SelectedIndex] + " and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                idl2 = "and V.idl2=" + idd[cbL2.SelectedIndex];
                idl2varios = idl2;
                total = false;
                query = "SELECT descrip,idl2 from estl2 where visiblebp='1' and idl2=" + idd[cbL2.SelectedIndex];
                wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2;
                subl2 = "and idl2=" + idd[cbL2.SelectedIndex];
                queryguardar[0] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + "," + idd[cbL2.SelectedIndex] + ",-1,-1,-1,-1,'-1'";
                l2 = "," + idd[cbL2.SelectedIndex];
                queryplazo[0] = " where V.iddivisiones= " + d.Substring(1, d.Length - 1) + "  " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2;
                queryExist[0] = idsucursalvarios.Replace("V", "E") + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2;
                l2cargar = "and idl2=" + idd[cbL2.SelectedIndex];
            }
            else
            {
                idl2varios = " ";
                subl2 = " ";
                for (int i = 0; i <= cbL2.Items.Count - 1; i++)
                {
                    querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " and idl2=" + idd[(i + 1)] + " and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                    idl2 = "and V.idl2=" + idd[(i + 1)];
                    wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2;
                    queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + idd[(i + 1)] + ",-1,-1,-1,-1,'-1'";
                    queryplazo[i] = "where V.iddivisiones= " + d.Substring(1, d.Length - 1) + "  " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2;
                    queryExist[i] = idsucursalvarios.Replace("V", "E") + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2;

                }
                l2 = ",0";
                l2cargar = "and idl2=0";
                total = true;
                query = "SELECT descrip,idl2 from estl2 where visiblebp='1' " + division + " " + depto + " " + fam + " " + linea + " " + subl1;
                seleccion_l2 = 0;
            }
            lbL2.Text = "L2=" + cbL2.Text;
            if (!valoresform)
                M_cargargrid(total);
            solototal = false;
        }
        private void cbL3_DropDown(object sender, EventArgs e)
        {
            cbL3.Items.Clear();
            cbL3.Items.Add("Total");
            int i = 1;

            query = "SELECT descrip,idl3 from estl3 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2;
            checaConexion();
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbL3.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["idl3"].ToString();
                i++;
            }
            reader.Close();
        }
        private void cbL3_SelectedIndexChanged(object sender, EventArgs e)
        {
            bandera_l3 = true;//pablo 
            #region banderas
            bandera_l4 = false;
            bandera_l5 = false;
            bandera_l6 = false;
            bandera_marca = false;
            seleccion_l4 = -1;
            seleccion_l5 = -1;
            seleccion_l6 = -1;
            seleccion_marca = "";
            #endregion
            #region reiniciar valores
            lbL3.Text = "L3";
            lbL4.Text = "L4";
            lbL5.Text = "L5";
            lbL6.Text = "L6";
            lbMarca.Text = "Marca";
            idl4 = " ";
            idl5 = " ";
            idl6 = " ";
            marca = " ";
            #endregion
            if (cbL3.Text != "Total")
            {
                seleccion_l3 = int.Parse(idd[cbL3.SelectedIndex].ToString());

                querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " and idl3=" + idd[cbL3.SelectedIndex] + " and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                idl3 = "and V.idl3=" + idd[cbL3.SelectedIndex];
                idl3varios = idl3;
                total = false;
                query = "SELECT descrip,idl3 from estl3 where visiblebp='1' and idl3=" + idd[cbL3.SelectedIndex];
                wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3;
                subl3 = "and idl3=" + idd[cbL3.SelectedIndex];
                queryguardar[0] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + "," + idd[cbL3.SelectedIndex] + ",-1,-1,-1,'-1'";
                l3 = "," + idd[cbL3.SelectedIndex];
                queryplazo[0] = " where V.iddivisiones= " + d.Substring(1, d.Length - 1) + "  " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3;
                queryExist[0] = idsucursalvarios.Replace("V", "E") + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3;
                l3cargar = "and idl3=" + idd[cbL3.SelectedIndex];

            }
            else
            {
                idl3varios = " ";
                subl3 = " ";
                for (int i = 0; i <= cbL3.Items.Count - 1; i++)
                {
                    querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " and idl3=" + idd[(i + 1)] + " and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                    idl3 = "and V.idl3=" + idd[(i + 1)];
                    wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3;
                    queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + "," + idd[(i + 1)] + ",-1,-1,-1,'-1'";
                    queryplazo[i] = " where V.iddivisiones= " + d.Substring(1, d.Length - 1) + "  " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3;
                    queryExist[i] = idsucursalvarios.Replace("V", "E") + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3;
                }
                total = true;
                query = "SELECT descrip,idl3 from estl3 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2;
                l3 = ",0";
                l3cargar = "and idl3=0";
                seleccion_l3 = 0;
            }
            lbL3.Text = "L3=" + cbL3.Text;
            if (!valoresform)
                M_cargargrid(total);
            solototal = false;
        }
        private void cbL4_DropDown(object sender, EventArgs e)
        {
            cbL4.Items.Clear();
            cbL4.Items.Add("Total");
            int i = 1;

            query = "SELECT descrip,idl4 from estl4 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2 + " " + subl3;
            checaConexion();
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbL4.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["idl4"].ToString();
                i++;
            }
            reader.Close();
        }
        private void cbL4_SelectedIndexChanged(object sender, EventArgs e)
        {
            bandera_l4 = true; //pablo
            #region banderas
            bandera_l5 = false;
            bandera_l6 = false;
            bandera_marca = false;
            seleccion_l5 = -1;
            seleccion_l6 = -1;
            seleccion_marca = "";
            #endregion
            #region reiniciar valores
            lbL4.Text = "L4";
            lbL5.Text = "L5";
            lbL6.Text = "L6";
            lbMarca.Text = "Marca";
            idl4 = " ";
            idl5 = " ";
            idl6 = " ";
            marca = " ";
            #endregion
            if (cbL4.Text != "Total")
            {
                seleccion_l4 = int.Parse(idd[cbL4.SelectedIndex].ToString());

                querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " and idl4=" + idd[cbL4.SelectedIndex] + " and idl5=-1 and idl6=-1 and marca='-1'  ";
                idl4 = "and V.idl4=" + idd[cbL4.SelectedIndex];
                idl4varios = idl4;
                total = false;
                query = "SELECT descrip,idl4 from estl4 where visiblebp='1' and idl4=" + idd[cbL4.SelectedIndex];
                wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4;
                subl4 = "and idl4=" + idd[cbL4.SelectedIndex];
                queryguardar[0] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + "," + idd[cbL4.SelectedIndex] + ",-1,-1,'-1'";
                l4 = "," + idd[cbL4.SelectedIndex];
                queryplazo[0] = " where V.iddivisiones= " + d.Substring(1, d.Length - 1) + "  " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4;
                queryExist[0] = idsucursalvarios.Replace("V", "E") + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4;
                l4cargar = "and idl4=" + idd[cbL4.SelectedIndex];
            }
            else
            {
                idl4varios = " ";
                subl4 = " ";
                for (int i = 0; i <= cbL4.Items.Count - 1; i++)
                {
                    querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " and idl4=" + idd[(i + 1)] + " and idl5=-1 and idl6=-1 and marca='-1'  ";
                    idl4 = "and V.idl4=" + idd[(i + 1)];
                    wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4;
                    queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + "," + idd[(i + 1)] + ",-1,-1,'-1'";
                    queryplazo[i] = " where V.iddivisiones= " + d.Substring(1, d.Length - 1) + "  " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4;
                    queryExist[i] = idsucursalvarios.Replace("V", "E") + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4;
                }
                total = true;
                query = "SELECT descrip,idl4 from estl4 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2 + " " + subl3;
                l4 = ",0";
                l4cargar = "and idl4=0";
                seleccion_l4 = 0;
            }
            lbL4.Text = "L4=" + cbL4.Text;
            if (!valoresform)
                M_cargargrid(total);
            solototal = false;
        }
        private void cbL5_DropDown(object sender, EventArgs e)
        {
            cbL5.Items.Clear();
            cbL5.Items.Add("Total");
            int i = 1;

            query = "SELECT descrip,idl5 from estl5 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2 + " " + subl3 + " " + subl4;
            checaConexion();
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbL5.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["idl5"].ToString();
                i++;
            }
            reader.Close();
        }
        private void cbL5_SelectedIndexChanged(object sender, EventArgs e)
        {
            bandera_l5 = true;//pablo
            #region banderas
            bandera_l6 = false;
            bandera_marca = false;
            seleccion_l6 = -1;
            seleccion_marca = "";
            #endregion
            #region reiniciar valores
            lbL5.Text = "L5";
            lbL6.Text = "L6";
            lbMarca.Text = "Marca";
            idl5 = " ";
            idl6 = " ";
            marca = " ";
            #endregion
            if (cbL5.Text != "Total")
            {
                seleccion_l5 = int.Parse(idd[cbL5.SelectedIndex].ToString());

                querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " and idl5=" + idd[cbL5.SelectedIndex] + " and idl6=-1 and marca='-1'  ";
                idl5 = "and V.idl5=" + idd[cbL5.SelectedIndex];
                idl5varios = idl5;
                total = false;
                query = "SELECT descrip,idl5 from estl5 where visiblebp='1' and idl5=" + idd[cbL5.SelectedIndex];
                wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5;
                subl5 = "and idl5=" + idd[cbL5.SelectedIndex];
                queryguardar[0] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + " " + l4 + "," + idd[cbL5.SelectedIndex] + ",-1,'-1'";
                l5 = "," + idd[cbL5.SelectedIndex];
                queryplazo[0] = " where V.iddivisiones= " + d.Substring(1, d.Length - 1) + "  " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5;
                queryExist[0] = idsucursalvarios.Replace("V", "E") + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5;
                l5cargar = "and idl5=" + idd[cbL5.SelectedIndex];
            }
            else
            {
                idl5varios = " ";
                subl5 = " ";
                for (int i = 0; i <= cbL5.Items.Count - 1; i++)
                {
                    querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " and idl5=" + idd[(i + 1)] + " and idl6=-1 and marca='-1'  ";
                    idl5 = "and V.idl5=" + idd[(i + 1)];
                    wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5;
                    queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + " " + l4 + "," + idd[(i + 1)] + ",-1,'-1'";
                    queryplazo[i] = " where V.iddivisiones= " + d.Substring(1, d.Length - 1) + "  " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5;
                    queryExist[i] = idsucursalvarios.Replace("V", "E") + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5;
                }
                total = true;
                query = "SELECT descrip,idl5 from estl5 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2 + " " + subl3 + " " + subl4;
                l5 = ",0";
                l5cargar = "and idl5=0";
                seleccion_l5 = 0;
            }
            lbL5.Text = "L5=" + cbL5.Text;
            if (!valoresform)
                M_cargargrid(total);
            solototal = false;
        }
        private void cbL6_DropDown(object sender, EventArgs e)
        {
            cbL6.Items.Clear();
            cbL6.Items.Add("Total");
            int i = 1;

            query = "SELECT descrip,idl6 from estl6 where visiblebp='1'" + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2 + " " + subl3 + " " + subl4 + " " + subl5;
            checaConexion();
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbL6.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["idl6"].ToString();
                i++;
            }
            reader.Close();
        }
        private void cbL6_SelectedIndexChanged(object sender, EventArgs e)
        {
            bandera_l6 = true; // pablo  
            #region banderas
            bandera_marca = false;
            seleccion_marca = "";
            #endregion
            #region reiniciar valores
            lbL6.Text = "L6";
            lbMarca.Text = "Marca";
            idl6 = " ";
            marca = " ";
            #endregion

            if (cbL6.Text != "Total")
            {
                seleccion_l6 = int.Parse(idd[cbL6.SelectedIndex].ToString());

                querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " and idl6=" + idd[cbL6.SelectedIndex] + " and marca='-1'  ";
                idl6 = "and V.idl6=" + idd[cbL6.SelectedIndex];
                idl6varios = idl6;
                total = false;
                query = "SELECT descrip,idl6 from estl6 where visiblebp='1' and idl6=" + idd[cbL6.SelectedIndex];
                wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6;
                subl6 = "and idl6=" + idd[cbL6.SelectedIndex];
                queryguardar[0] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + " " + l4 + " " + l5 + "," + idd[cbL6.SelectedIndex] + ",'-1'";
                l6 = "," + idd[cbL6.SelectedIndex];
                queryplazo[0] = " where V.iddivisiones= " + d.Substring(1, d.Length - 1) + "  " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6;
                queryExist[0] = idsucursalvarios.Replace("V", "E") + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6;
                l6cargar = "and idl6=" + idd[cbL6.SelectedIndex];
            }
            else
            {
                subl6 = " ";
                idl6 = " ";
                for (int i = 0; i <= cbL6.Items.Count - 1; i++)
                {
                    querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " and idl6=" + idd[(i + 1)] + " and marca='-1'  ";
                    idl6 = "and V.idl6=" + idd[(i + 1)];
                    wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6;
                    queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + " " + l4 + " " + l5 + "," + idd[(i + 1)] + ",'-1'";
                    queryplazo[i] = " where V.iddivisiones= " + d.Substring(1, d.Length - 1) + "  " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6;
                    queryExist[i] = idsucursalvarios.Replace("V", "E") + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6;
                }
                total = true;
                query = "SELECT descrip,idl6 from estl6 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2 + " " + subl3 + " " + subl4 + " " + subl5;
                l6 = ",0";
                l6cargar = "and idl6=0";
                seleccion_l6 = 0;
            }
            lbL6.Text = "L6=" + cbL6.Text;
            if (!valoresform)
                M_cargargrid(total);
            solototal = false;
        }
        private void cbMarca_DropDown(object sender, EventArgs e)
        {
            cbMarca.Items.Clear();
            cbMarca.Items.Add("Total");
            int i = 1;
            query = "SELECT distinct m.descrip,m.marca from marca as m inner join estarticulo as V on V.marca=m.marca where visiblebp=1 " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6varios;
            checaConexion();
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbMarca.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["marca"].ToString();
                i++;
            }
            reader.Close();
        }
        private void cbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            bandera_marca = true;//pablo
            seleccion_marca = cbMarca.SelectedText;
            if (cbMarca.Text == "Total")
            {
                for (int i = 0; i <= cbMarca.Items.Count - 1; i++)
                {
                    marca = " and V.marca='" + idd[(i + 1)] + "'";
                    //    wherequery[i] = idsucursalvarios + " " + marca;
                    wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6 + " " + marca;

                    queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + " " + l4 + " " + l5 + " " + l6 + ",'" + idd[(i + 1)] + "'";
                    querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " " + l6cargar + " and marca='" + idd[(i + 1)] + "'  ";
                    queryplazo[i] = " where V.iddivisiones= " + d.Substring(1, d.Length - 1) + "  " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6 + " " + marca;
                    queryExist[i] = idsucursalvarios.Replace("V", "E") + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6 + " " + "and V.marca='" + idd[(i + 1)] + "'";
                }
                total = true;
                seleccion_marca = "0";
            }
            else
            {
                queryguardar[0] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + " " + l4 + " " + l5 + " " + l6 + ",'" + idd[cbMarca.SelectedIndex] + "'";
                querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " " + l6cargar + " and marca='" + idd[cbMarca.SelectedIndex] + "'  ";
                query = query + " and M.marca='" + idd[cbMarca.SelectedIndex] + "'";
                marca = " and V.marca='" + idd[cbMarca.SelectedIndex] + "'";
                // wherequery[0] = idsucursalvarios + marca;
                wherequery[0] = idsucursalvarios + " " + idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6 + " " + marca;
                total = false;
                queryplazo[0] = " where V.iddivisiones= " + d.Substring(1, d.Length - 1) + "  " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6 + " " + marca;
                queryExist[0] = idsucursalvarios.Replace("V", "E") + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6 + " " + "and V.marca='" + idd[cbMarca.SelectedIndex] + "'";

            }
            lbMarca.Text = "Marca=" + cbMarca.Text;
            if (!valoresform)
                M_cargargrid(total);
            solototal = false;
        }
        #endregion

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


        private void M_cargargrid(bool Total)
        {
            m_ESTRUCTURA();
        }
        private void m_ESCENARIO(string escenario)
        {
            DateTime a = DateTime.Now, f = DateTime.Now;
            string ESC = "SELECT fechainicialA, fechafinalA,fechainicial,fechafinal,solocalzado FROM escenarios WHERE nombre='" + Properties.Settings.Default.escenario + "' LIMIT 1";
            checaConexion();
            cmd = new MySqlCommand(ESC, Conn);
            cmd.CommandTimeout = 0;//pos solucion
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                fech1 = a = DateTime.Parse(reader["fechainicial"].ToString());
                fech2 = f = DateTime.Parse(reader["fechafinal"].ToString());
                CED1_fechaI = reader["fechainicialA"].ToString();
                CED1_fechaF = reader["fechafinalA"].ToString();
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
            int i = 0;
            m_CLEAR_DGV();
            if(solototal==false)
            {
                m_ADD_ROWS_DGV();
                dgv1.Rows[0].Cells[0].Value = "Total";
                m_PASS_VALUES_DGV(dgv1.Rows[0].Cells[0].Value.ToString(), 0);
                i = 1;
            }
            checaConexion();
            cmd = new MySqlCommand(query, Conn);
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
        }

        public void m_RECIBOBASE(int mes, int ano, int i) // ejemplo query modificar a 3 tablas 
        {
            double prom = 0;
            for (int x = 0; x <= dgv1.Rows.Count - 1; x++)
            {
                m_REFRESH_DGV(); int difcero = 1;
                if (total != true)
                {
                    #region CONSULTA CORRECTA AÑO ACTUAL
                    query = "SELECT SUM(e.ctd)AS articulo FROM recibobase AS E INNER JOIN estarticulo AS V ON V.`idarticulo` = E.`idarticulo` INNER JOIN fecha AS F ON F.`idFecha` = E.`idfecha` WHERE  F.FECHA BETWEEN '" + fech1.ToString("yyyy-MM-dd") + "' AND '" + fech2.ToString("yyyy-MM-dd") + "' AND F.mes = '" + mes + "' AND F.anio = '" + ano + "'  " + wherequery[0] + ";";
                    /*query = "SELECT SUM(v.`CTD_RECIB`) AS articulo FROM recibo_base AS V INNER JOIN fecha AS F ON F.`idFecha` = V.`IDFECHA` WHERE  F.FECHA BETWEEN '" +  fech1.ToString("yyyy-MM-dd") + "' AND '" + fech2.ToString("yyyy-MM-dd") + "' AND F.mes = '" + mes + "' AND F.anio = '" + ano + "'  " + wherequery[0] + ";";*/
                    cmd = new MySqlCommand(query, Conn); cmd.CommandTimeout = 0;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //m_REFRESH_DGV();
                        //if (reader["articulo"].ToString() == "")
                        //{ m_LLENAR_DGV(i, x, "0"); difcero = 0; }
                        //else
                        //{
                        //    string val = reader["articulo"].ToString();
                        //    m_LLENAR_DGV(i, x, val);
                        //}
                    }
                    reader.Close();
                    #endregion
                    #region CONSULTA AÑO ANTERIOR
                    if (difcero == 0)
                    {
                        query = "SELECT SUM(e.ctd)AS articulo FROM recibobase AS E INNER JOIN estarticulo AS V ON V.`idarticulo` = E.`idarticulo` INNER JOIN fecha AS F ON F.`idFecha` = E.`idfecha` WHERE  F.mes = '" + mes + "' AND F.anio = '" + (ano - 1) + "'  " + wherequery[0] + ";";
                        /* query = "SELECT SUM(v.`CTD_RECIB`) AS articulo FROM recibo_base AS V INNER JOIN fecha AS F ON F.`idFecha` = V.`IDFECHA` WHERE  F.mes = '" + mes + "' AND F.anio = '" + (ano-1) + "'  " + wherequery[0] + ";";*/
                        cmd = new MySqlCommand(query, Conn); cmd.CommandTimeout = 0;
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            //m_REFRESH_DGV();
                            //if (reader["articulo"].ToString() == "")
                            //{ m_LLENAR_DGV(i, x, "0"); }
                            //else
                            //{
                            //    string val = reader["articulo"].ToString();
                            //    m_LLENAR_DGV(i, x, val);
                            //}
                        }
                        reader.Close();
                    }
                    #endregion
                }

                else
                {
                    #region CONSULTA CORRECTA AÑO ACTUAL

                    /*  query = "SELECT SUM(v.`CTD_RECIB`) AS articulo FROM recibo_base AS V INNER JOIN fecha AS F ON F.`idFecha` = V.`IDFECHA` WHERE  F.FECHA BETWEEN '" + fech1.ToString("yyyy-MM-dd") + "' AND '" + fech2.ToString("yyyy-MM-dd") + "' AND F.mes = '" + mes + "' AND F.anio = '" + ano + "'  " + wherequery[(x + 1)] + ";";*/
                    query = "SELECT SUM(e.ctd)AS articulo FROM recibobase AS E INNER JOIN estarticulo AS V ON V.`idarticulo` = E.`idarticulo` INNER JOIN fecha AS F ON F.`idFecha` = E.`idfecha` WHERE  F.FECHA BETWEEN '" + fech1.ToString("yyyy-MM-dd") + "' AND '" + fech2.ToString("yyyy-MM-dd") + "' AND F.mes = '" + mes + "' AND F.anio = '" + ano + "'  " + wherequery[x] + ";";
                    cmd = new MySqlCommand(query, Conn); cmd.CommandTimeout = 0;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        m_REFRESH_DGV();
                    //    if (reader["articulo"].ToString() == "")
                    //    {
                    //        m_LLENAR_DGV(i, x, "0"); difcero = 0;
                    //    }
                    //    else
                    //    {
                    //        string val = reader["articulo"].ToString();
                    //        m_LLENAR_DGV(i, x, val);
                    //    }
                    }
                    reader.Close();
                    #endregion
                    #region CONSULTA AÑO ANTERIOR
                    if (difcero == 0)
                    {
                        /*query = "SELECT SUM(v.`CTD_RECIB`) AS articulo FROM recibo_base AS V INNER JOIN fecha AS F ON F.`idFecha` = V.`IDFECHA` WHERE F.mes = '" + mes + "' AND F.anio = '" +( ano-1) + "'  " + wherequery[(x + 1)] + ";";*/
                        query = "SELECT SUM(e.ctd)AS articulo FROM recibobase AS E INNER JOIN estarticulo AS V ON V.`idarticulo` = E.`idarticulo` INNER JOIN fecha AS F ON F.`idFecha` = E.`idfecha` WHERE F.mes = '" + mes + "' AND F.anio = '" + (ano - 1) + "'  " + wherequery[x] + ";";
                        cmd = new MySqlCommand(query, Conn); cmd.CommandTimeout = 0;
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            //m_REFRESH_DGV();
                            //if (reader["articulo"].ToString() == "")
                            //{
                            //    m_LLENAR_DGV(i, x, "0"); difcero = 0;
                            //}
                            //else
                            //{
                            //    string val = reader["articulo"].ToString();
                            //    m_LLENAR_DGV(i, x, val);
                            //}
                        }
                        reader.Close();
                    }
                    #endregion
                }
            }
        }

        public void m_NUM_MOD(int mes, int ano, int i) // ejemplo query modificar a 3 
        {
            double prom = 0; int difcero = 1;
            for (int x = 0; x <= dgv1.Rows.Count - 1; x++)
            {
                dgv1.Refresh();
                if (total != true)
                {
                    #region consulta año actual
                    //
                    query = "SELECT COUNT(modelo) AS modelo FROM recibobase AS E INNER JOIN estarticulo AS V ON V.`idarticulo` = E.`idarticulo` INNER JOIN fecha AS F ON F.`idFecha` = E.`idfecha` WHERE  F.FECHA BETWEEN '" + fech1.ToString("yyyy-MM-dd") + "' AND '" + fech2.ToString("yyyy-MM-dd") + "' AND F.mes = '" + mes + "' AND F.anio = '" + ano + "' " + wherequery[0] + ";";
                    /*query = "SELECT COUNT(DISTINCT MODELO)AS modelo FROM recibo_base AS V INNER JOIN fecha AS F ON F.`idFecha` = V.`IDFECHA` WHERE  F.FECHA BETWEEN '" + fech1.ToString("yyyy-MM-dd") + "' AND '" + fech2.ToString("yyyy-MM-dd") + "' AND F.mes = '" + mes + "' AND F.anio = '" + ano + "' " + wherequery[0] + ";";*/
                    cmd = new MySqlCommand(query, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dgv1.Refresh();
                        if (reader["modelo"].ToString() == "")
                        {
                            m_LLENAR_DGV2(i, x, "0"); difcero = 0;
                        }
                        else
                        {
                            string val = reader["modelo"].ToString();
                            m_LLENAR_DGV2(i, x, val);
                        }
                    }
                    reader.Close();
                    #endregion
                    #region consulta año anterior
                    if (difcero == 0)
                    {
                        query = "SELECT COUNT(modelo) AS modelo FROM recibobase AS E INNER JOIN estarticulo AS V ON V.`idarticulo` = E.`idarticulo`INNER JOIN fecha AS F ON F.`idFecha` = E.`idfecha` WHERE  F.FECHA BETWEEN '" + FechaAI.ToString("yyyy-MM-dd") + "' AND '" + FechaAF.ToString("yyyy-MM-dd") + "' AND F.mes = '" + mes + "' AND F.anio = '" + (ano - 1) + "'  " + wherequery[0] + ";";
                        /*query = "SELECT COUNT(DISTINCT MODELO)AS modelo FROM recibo_base AS V INNER JOIN fecha AS F ON F.`idFecha` = V.`IDFECHA` WHERE  F.FECHA BETWEEN '" + FechaAI.ToString("yyyy-MM-dd") + "' AND '" + FechaAF.ToString("yyyy-MM-dd") + "' AND F.mes = '" + mes + "' AND F.anio = '" + (ano - 1) + "'  " + wherequery[0] + ";";*/
                        cmd = new MySqlCommand(query, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            dgv1.Refresh();
                            if (reader["modelo"].ToString() == "")
                            {
                                m_LLENAR_DGV2(i, x, "0");
                            }
                            else
                            {
                                string val = reader["modelo"].ToString();
                                m_LLENAR_DGV2(i, x, val);
                            }
                        }
                        reader.Close();
                    }
                    #endregion
                }
                else
                {
                    #region consulta año actual

                    query = "SELECT COUNT(modelo) AS modelo FROM recibobase AS E INNER JOIN estarticulo AS V ON V.`idarticulo` = E.`idarticulo`INNER JOIN fecha AS F ON F.`idFecha` = E.`idfecha` WHERE F.FECHA BETWEEN '" + fech1.ToString("yyyy-MM-dd") + "' AND '" + fech2.ToString("yyyy-MM-dd") + "' AND F.mes = '" + mes + "' AND F.anio = '" + ano + "'  " + wherequery[x] + ";";
                    /* query = "SELECT COUNT(DISTINCT MODELO)AS modelo FROM recibo_base AS V INNER JOIN fecha AS F ON F.`idFecha` = V.`IDFECHA` WHERE F.FECHA BETWEEN '" + fech1.ToString("yyyy-MM-dd") + "' AND '" + fech2.ToString("yyyy-MM-dd") + "' AND F.mes = '" + mes + "' AND F.anio = '" + ano + "'  " + wherequery[(x + 1)] + ";";*/
                    cmd = new MySqlCommand(query, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dgv1.Refresh();
                        if (reader["modelo"].ToString() == "")
                        {
                            m_LLENAR_DGV2(i, x, "0"); difcero = 0;
                        }
                        else
                        {
                            string val = reader["modelo"].ToString();
                            m_LLENAR_DGV2(i, x, val);
                        }
                    }
                    reader.Close();
                    #endregion
                    #region consulta año anterior
                    if (difcero == 0)
                    {
                        query = "SELECT COUNT(modelo) AS modelo FROM recibobase AS E INNER JOIN estarticulo AS V ON V.`idarticulo` = E.`idarticulo`INNER JOIN fecha AS F ON F.`idFecha` = E.`idfecha` WHERE F.FECHA BETWEEN '" + FechaAI.ToString("yyyy-MM-dd") + "' AND '" + FechaAF.ToString("yyyy-MM-dd") + "' AND F.mes = '" + mes + "' AND F.anio = '" + (ano - 1) + "'  " + wherequery[x] + ";";
                        /* query = "SELECT COUNT(DISTINCT MODELO)AS modelo FROM recibo_base AS V INNER JOIN fecha AS F ON F.`idFecha` = V.`IDFECHA` WHERE F.FECHA BETWEEN '" + FechaAI.ToString("yyyy-MM-dd") + "' AND '" + FechaAF.ToString("yyyy-MM-dd") + "' AND F.mes = '" + mes + "' AND F.anio = '" + (ano - 1) + "'  " + wherequery[(x + 1)] + ";";*/
                        cmd = new MySqlCommand(query, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            dgv1.Refresh();
                            if (reader["modelo"].ToString() == "")
                            {
                                m_LLENAR_DGV2(i, x, "0");
                            }
                            else
                            {
                                string val = reader["modelo"].ToString();
                                m_LLENAR_DGV2(i, x, val);
                            }
                        }
                        reader.Close();
                    }
                    #endregion
                }
            }
        }
        private void tb_ponderacion_80_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    ponderacion80 = Convert.ToDouble(tb_ponderacion_80.Text);
                    ponderacion20 = 100 - ponderacion80;
                    tb_ponderacion_20.Text = Convert.ToString(ponderacion20);
                }
                catch { MessageBox.Show("Asigne ponderacion correcta"); tb_ponderacion_20.Text = "20"; tb_ponderacion_80.Text = "80"; }

            }
        }
        private void tb_ponderacion_20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    ponderacion20 = Convert.ToDouble(tb_ponderacion_20.Text);
                    ponderacion80 = 100 - ponderacion20;
                    tb_ponderacion_80.Text = Convert.ToString(ponderacion80);
                }
                catch { MessageBox.Show("Asigne ponderacion correcta"); tb_ponderacion_20.Text = "20"; tb_ponderacion_80.Text = "80"; }

            }
        }

        public void m_DIASMESESANOS(string fecha_inicio, string fecha_final) /////////////////////////////se usa en todos 
        {
            Cursor.Current = Cursors.WaitCursor;

            int fecha_inicio_dia = Convert.ToInt32(fecha_inicio.Substring(0, 2));
            int fecha_inicio_mes = Convert.ToInt32(fecha_inicio.Substring(3, 2));
            int fecha_inicio_ano = Convert.ToInt32(fecha_inicio.Substring(6, 4));

            int fecha_final_dia = Convert.ToInt32(fecha_final.Substring(0, 2));
            int fecha_final_mes = Convert.ToInt32(fecha_final.Substring(3, 2));
            int fecha_final_ano = Convert.ToInt32(fecha_final.Substring(6, 4));
            int mes = 1;
            bool carga = false;
            #region añomes
            int i = 1; calculos = 1;
            for (; fecha_inicio_ano <= fecha_final_ano; fecha_inicio_ano++)
            {
                if (fecha_inicio_mes <= fecha_final_mes)
                {
                    for (; fecha_inicio_mes <= fecha_final_mes; fecha_inicio_mes++, i++)
                        try
                        {
                            m_TABS(fecha_inicio_mes, fecha_inicio_ano+1);/////////////////////se usa en todos 
                            m_capacidadPies(i);
                            if (comprobarCargar(fecha_inicio_ano, fecha_inicio_mes, i) == true)
                            {
                                cargar(fecha_inicio_mes, fecha_inicio_ano, i);
                                carga = true;
                            }
                            else
                            {
                                //m_RECIBOBASE(fecha_inicio_mes, fecha_inicio_ano, i);  ///////////////////////////////
                                //m_NUM_MOD(fecha_inicio_mes, fecha_inicio_ano, i);   //////////////////////////////// 
                                //comprasP(fecha_inicio_mes,fecha_inicio_ano,i);
                                //comprasH(fecha_inicio_mes, fecha_inicio_ano, i);
                                //modelajeHU(fecha_inicio_mes,fecha_inicio_ano,i);
                                //modelajeHP(i);
                                //modelajePU(i);
                                //modelajePP(i);
                                //participacionHU(i);
                                //ponderacion(i);
                                //asignacionModelos(i);
                                //profundidad(i);
                                modelajeHU(fecha_inicio_mes, fecha_inicio_ano, i);
                                modelajeHP(i);
                                m_capacidadAparador(i);
                                M_unidades_vendidas(fecha_final_mes,fecha_inicio_ano,i);
                                comprasP(fecha_inicio_mes, fecha_inicio_ano, i);
                                modelos_CompraP(fecha_inicio_mes, fecha_inicio_ano, i);
                                modelajePP(i);
                                Pares_aComprar(i);
                                asignacionModelos(i);
                                profundidad(i);
                                m_REFRESH_DGV();
                            }
                            m_calcularRenglonTotal(i);
                            tabcontrol.SelectedIndex = tabcontrol.SelectedIndex + 1;
                            mes++;

                        }
                        catch (Exception x)
                        { MessageBox.Show("Error con las fechas " + x); }
                }
                if (fecha_final_mes < fecha_inicio_mes && fecha_inicio_ano != fecha_final_ano)
                {
                    for (; fecha_inicio_mes <= 12; fecha_inicio_mes++, i++)
                        try
                        {
                            m_TABS(fecha_inicio_mes, fecha_inicio_ano+1);/////////////////////se usa en todos 
                            if (comprobarCargar(fecha_inicio_ano, fecha_inicio_mes, i) == true)
                            {
                                cargar(fecha_inicio_mes, fecha_inicio_ano, i);
                                carga=true;
                            }
                            else
                            {
                                //m_RECIBOBASE(fecha_inicio_mes, fecha_inicio_ano, i);  ///////////////////////////////
                                //m_NUM_MOD(fecha_inicio_mes, fecha_inicio_ano, i);   ////////////////////////////////
                                //comprasH(fecha_inicio_mes, fecha_inicio_ano, i);
                                //
                                //modelajePU(i);

                                //m_calcularRenglonTotal(i);
                                modelajeHU(fecha_inicio_mes, fecha_inicio_ano, i);
                                modelajeHP(i);
                                M_unidades_vendidas(fecha_final_mes, fecha_inicio_ano, i);
                                comprasP(fecha_inicio_mes, fecha_inicio_ano, i);
                                modelos_CompraP(fecha_inicio_mes, fecha_inicio_ano, i);
                                modelajePP(i);
                                Pares_aComprar(i);
                                asignacionModelos(i);
                                profundidad(i);
                                m_capacidadAparador(i);
                                m_REFRESH_DGV();
                            }
                            m_calcularRenglonTotal(i);
                            tabcontrol.SelectedIndex = tabcontrol.SelectedIndex + 1;
                            mes++;
                        }
                        catch (Exception x)
                        { MessageBox.Show("Error con las fechas " + x); }
                }
                fecha_inicio_mes = 1;
            }
            #endregion
            Cursor.Current = Cursors.Default;
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

        //////////////*********************REGION PASAR VALORES DGV1 A LAS DEMAS 
        public void m_CLEAR_DGV()
        {
            dgv1.Rows.Clear(); dgv2.Rows.Clear(); dgv3.Rows.Clear(); dgv4.Rows.Clear(); dgv5.Rows.Clear();
            dgv6.Rows.Clear(); dgv7.Rows.Clear(); dgv8.Rows.Clear(); dgv9.Rows.Clear(); dgv10.Rows.Clear();
            dgv11.Rows.Clear(); dgv12.Rows.Clear();
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
        ///******************************************************************************
        private void m_LLENAR_DGV(int m, int columna,int cell, string val)
        {
            //           dgvCed9.Rows[0].Cells[i].Value = val;
            switch (m)
            {
                case 1: dgv1.Rows[columna].Cells[cell].Value = val;
                    break;
                case 2: dgv2.Rows[columna].Cells[cell].Value = val;
                    break;
                case 3: dgv3.Rows[columna].Cells[cell].Value = val;
                    break;
                case 4: dgv4.Rows[columna].Cells[cell].Value = val;
                    break;
                case 5: dgv5.Rows[columna].Cells[cell].Value = val;
                    break;
                case 6: dgv6.Rows[columna].Cells[cell].Value = val;
                    break;
                case 7: dgv7.Rows[columna].Cells[cell].Value = val;
                    break;
                case 8: dgv8.Rows[columna].Cells[cell].Value = val;
                    break;
                case 9: dgv9.Rows[columna].Cells[cell].Value = val;
                    break;
                case 10: dgv10.Rows[columna].Cells[cell].Value = val;
                    break;
                case 11: dgv11.Rows[columna].Cells[cell].Value = val;
                    break;
                case 12: dgv12.Rows[columna].Cells[cell].Value = val;
                    break;
                //  case 13: dgvProf13.Rows[columna].Cells[1].Value = val; 
                //    break;

            }

        }
        private void m_LLENAR_DGV2(int m, int columna, string val)
        {
            //           dgvCed9.Rows[0].Cells[i].Value = val;
            if (dgv1.Rows.Count != 1)
            {
                switch (m)
                {
                    case 1: dgv1.Rows[columna].Cells[2].Value = val; calculos++;
                        break;
                    case 2: dgv2.Rows[columna].Cells[2].Value = val; calculos++;
                        break;
                    case 3: dgv3.Rows[columna].Cells[2].Value = val; calculos++;
                        break;
                    case 4: dgv4.Rows[columna].Cells[2].Value = val; calculos++;
                        break;
                    case 5: dgv5.Rows[columna].Cells[2].Value = val; calculos++;
                        break;
                    case 6: dgv6.Rows[columna].Cells[2].Value = val; calculos++;
                        break;
                    case 7: dgv7.Rows[columna].Cells[2].Value = val; calculos++;
                        break;
                    case 8: dgv8.Rows[columna].Cells[2].Value = val; calculos++;
                        break;
                    case 9: dgv9.Rows[columna].Cells[2].Value = val; calculos++;
                        break;
                    case 10: dgv10.Rows[columna].Cells[2].Value = val; calculos++;
                        break;
                    case 11: dgv11.Rows[columna].Cells[2].Value = val; calculos++;
                        break;
                    case 12: dgv12.Rows[columna].Cells[2].Value = val; calculos++;
                        break;
                    // case 13: dgvProf13.Rows[columna].Cells[2].Value = val; calculos++; 
                    //   break;

                }
            }
            else
            {
                switch (m)
                {
                    case 1: dgv1.Rows[0].Cells[2].Value = val; calculos++;
                        break;
                    case 2: dgv2.Rows[0].Cells[2].Value = val; calculos++;
                        break;
                    case 3: dgv3.Rows[0].Cells[2].Value = val; calculos++;
                        break;
                    case 4: dgv4.Rows[0].Cells[2].Value = val; calculos++;
                        break;
                    case 5: dgv5.Rows[0].Cells[2].Value = val; calculos++;
                        break;
                    case 6: dgv6.Rows[0].Cells[2].Value = val; calculos++;
                        break;
                    case 7: dgv7.Rows[0].Cells[2].Value = val; calculos++;
                        break;
                    case 8: dgv8.Rows[0].Cells[2].Value = val; calculos++;
                        break;
                    case 9: dgv9.Rows[0].Cells[2].Value = val; calculos++;
                        break;
                    case 10: dgv10.Rows[0].Cells[2].Value = val; calculos++;
                        break;
                    case 11: dgv11.Rows[0].Cells[2].Value = val; calculos++;
                        break;
                    case 12: dgv12.Rows[0].Cells[2].Value = val; calculos++;
                        break;
                    // case 13: dgvProf13.Rows[0].Cells[2].Value = val; calculos++; 
                    //   break;

                }
            }

        }

        private void m_CALCULOS(int m)
        {
            //double sumatoria = 0; double porcentaje = 0; int suma_modelaje = 0; int suma_asignacion = 0;

            //switch (m)
            //{
            //    case 1:
            //        #region calculos dgv1
            //        #region calculos
            //        dgv1.Rows.Add();
            //        dgv1.Rows[dgv1.RowCount - 1].Cells[0].Value = "TOTALES";
            //        for (int n = 0; n < dgv1.RowCount - 1; n++)
            //        {
            //            sumatoria = sumatoria + Convert.ToDouble(dgv1.Rows[n].Cells[1].Value);
            //            if(dgv1.Rows[n].Cells[2].Value!=null)
            //            {
            //              suma_modelaje = suma_modelaje + Convert.ToInt32(dgv1.Rows[n].Cells[2].Value);
            //            }
            //            else
            //            {
            //                suma_modelaje = suma_modelaje+0;
            //            }
            //        }

            //        dgv1.Rows[dgv1.RowCount - 1].Cells[1].Value = (sumatoria / sumatoria) * 100;
            //        dgv1.Rows[dgv1.RowCount - 1].Cells[2].Value = suma_modelaje;


            //        for (int n = 0; n < dgv1.RowCount - 1; n++)
            //        {
            //            porcentaje = Convert.ToDouble(dgv1.Rows[n].Cells[1].Value) / sumatoria;
            //            dgv1.Rows[n].Cells[1].Value = (porcentaje * 100).ToString("N2");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN
            //        for (int n = 0; n < dgv1.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv1.Rows[n].Cells[1].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null)
            //            { dgv1.Rows[n].Cells[1].Value = 0.00; }
            //        }
            //        #endregion
            //        #region asignacion
            //        for (int n = 0; n < dgv1.RowCount - 1; n++)
            //        {
            //            double asignacion = 0;
            //            asignacion = (compras[n] * (0.01 * (Convert.ToDouble(dgv1.Rows[n].Cells[1].Value))));
            //            dgv1.Rows[n].Cells[3].Value = asignacion.ToString("N0");
            //        }
            //        #endregion
            //        #region ponderacion
            //        for (int n = 0; n < dgv1.RowCount - 1; n++)
            //        {
            //            string pond = Convert.ToString(dgv1.Rows[n].Cells[3].Value);
            //            pond = pond.Trim(',');
            //            double pond_tod = Convert.ToDouble(pond);
            //            double pond1 = 0, pond2 = 0;
            //            pond1 = (ponderacion80 * 0.01) * (pond_tod);
            //            pond2 = (ponderacion20 * 0.01) * (pond_tod);


            //            dgv1.Rows[n].Cells[4].Value = pond1.ToString("N0");
            //            dgv1.Rows[n].Cells[5].Value = pond2.ToString("N0");
            //        }
            //        #endregion
            //        #region asignacion modelos
            //        for (int n = 0; n < dgv1.RowCount - 1; n++)
            //        {
            //            int unid = Convert.ToInt32(dgv1.Rows[n].Cells[2].Value);

            //            double asig_mod1 = 0, asig_mod2 = 0;
            //            asig_mod1 = (asignacion20 * 0.01) * (unid);
            //            asig_mod2 = (asignacion80 * 0.01) * (unid);


            //            dgv1.Rows[n].Cells[6].Value = asig_mod1.ToString("N0");
            //            dgv1.Rows[n].Cells[7].Value = asig_mod2.ToString("N0");
            //        }
            //        #endregion
            //        #region profundidad
            //        for (int n = 0; n < dgv1.RowCount - 1; n++)
            //        {

            //            string ren4 = Convert.ToString(dgv1.Rows[n].Cells[4].Value);
            //            string ren5 = Convert.ToString(dgv1.Rows[n].Cells[5].Value);
            //            string ren6 = Convert.ToString(dgv1.Rows[n].Cells[6].Value);
            //            string ren7 = Convert.ToString(dgv1.Rows[n].Cells[7].Value);
            //            ren4 = ren4.Replace(",", ""); ren5 = ren5.Replace(",", ""); ren6 = ren6.Replace(",", ""); ren7 = ren7.Replace(",", "");
            //            double v1, v2, v3, v4 = 0;
            //            v1 = Convert.ToDouble(ren4); v2 = Convert.ToDouble(ren5); v3 = Convert.ToDouble(ren6); v4 = Convert.ToDouble(ren7);
            //            prof20 = v1 / v3;
            //            prof80 = v2 / v4;

            //            dgv1.Rows[n].Cells[8].Value = prof20.ToString("N0");
            //            dgv1.Rows[n].Cells[9].Value = prof80.ToString("N0");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 8
            //        for (int n = 0; n < dgv1.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv1.Rows[n].Cells[8].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv1.Rows[n].Cells[8].Value = 0; }
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 9
            //        for (int n = 0; n < dgv1.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv1.Rows[n].Cells[9].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv1.Rows[n].Cells[9].Value = 0.00; }
            //        }
            //        #endregion
            //        #endregion
            //        break;
            //    case 2:
            //        #region calculos dgv2
            //        #region calculos
            //        dgv2.Rows.Add();
            //        dgv2.Rows[dgv2.RowCount - 1].Cells[0].Value = "TOTALES";
            //        for (int n = 0; n < dgv2.RowCount - 1; n++)
            //        {
            //            sumatoria = sumatoria + Convert.ToDouble(dgv2.Rows[n].Cells[1].Value);
            //            suma_modelaje = suma_modelaje + Convert.ToInt32(dgv2.Rows[n].Cells[2].Value);
            //        }

            //        dgv2.Rows[dgv2.RowCount - 1].Cells[1].Value = (sumatoria / sumatoria) * 100;
            //        dgv2.Rows[dgv2.RowCount - 1].Cells[2].Value = suma_modelaje;


            //        for (int n = 0; n < dgv2.RowCount - 1; n++)
            //        {
            //            porcentaje = Convert.ToDouble(dgv2.Rows[n].Cells[1].Value) / sumatoria;
            //            dgv2.Rows[n].Cells[1].Value = (porcentaje * 100).ToString("N2");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN
            //        for (int n = 0; n < dgv2.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv2.Rows[n].Cells[1].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null)
            //            { dgv2.Rows[n].Cells[1].Value = 0.00; }
            //        }
            //        #endregion
            //        #region asignacion
            //        for (int n = 0; n < dgv2.RowCount - 1; n++)
            //        {
            //            double asignacion = 0;
            //            asignacion = (Convert.ToDouble(tb_UnidCompr.Text) * (0.01 * (Convert.ToDouble(dgv2.Rows[n].Cells[1].Value))));
            //            dgv2.Rows[n].Cells[3].Value = asignacion.ToString("N0");
            //        }
            //        #endregion
            //        #region ponderacion
            //        for (int n = 0; n < dgv2.RowCount - 1; n++)
            //        {
            //            string pond = Convert.ToString(dgv2.Rows[n].Cells[3].Value);
            //            pond = pond.Trim(',');
            //            double pond_tod = Convert.ToDouble(pond);
            //            double pond1 = 0, pond2 = 0;
            //            pond1 = (ponderacion80 * 0.01) * (pond_tod);
            //            pond2 = (ponderacion20 * 0.01) * (pond_tod);


            //            dgv2.Rows[n].Cells[4].Value = pond1.ToString("N0");
            //            dgv2.Rows[n].Cells[5].Value = pond2.ToString("N0");
            //        }
            //        #endregion
            //        #region asignacion modelos
            //        for (int n = 0; n < dgv2.RowCount - 1; n++)
            //        {
            //            int unid = Convert.ToInt32(dgv2.Rows[n].Cells[2].Value);

            //            double asig_mod1 = 0, asig_mod2 = 0;
            //            asig_mod1 = (asignacion20 * 0.01) * (unid);
            //            asig_mod2 = (asignacion80 * 0.01) * (unid);


            //            dgv2.Rows[n].Cells[6].Value = asig_mod1.ToString("N0");
            //            dgv2.Rows[n].Cells[7].Value = asig_mod2.ToString("N0");
            //        }
            //        #endregion
            //        #region profundidad
            //        for (int n = 0; n < dgv2.RowCount - 1; n++)
            //        {

            //            string ren4 = Convert.ToString(dgv2.Rows[n].Cells[4].Value);
            //            string ren5 = Convert.ToString(dgv2.Rows[n].Cells[5].Value);
            //            string ren6 = Convert.ToString(dgv2.Rows[n].Cells[6].Value);
            //            string ren7 = Convert.ToString(dgv2.Rows[n].Cells[7].Value);
            //            ren4 = ren4.Replace(",", ""); ren5 = ren5.Replace(",", ""); ren6 = ren6.Replace(",", ""); ren7 = ren7.Replace(",", "");
            //            double v1, v2, v3, v4 = 0;
            //            v1 = Convert.ToDouble(ren4); v2 = Convert.ToDouble(ren5); v3 = Convert.ToDouble(ren6); v4 = Convert.ToDouble(ren7);
            //            prof20 = v1 / v3;
            //            prof80 = v2 / v4;

            //            dgv2.Rows[n].Cells[8].Value = prof20.ToString("N0");
            //            dgv2.Rows[n].Cells[9].Value = prof80.ToString("N0");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 8
            //        for (int n = 0; n < dgv2.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv2.Rows[n].Cells[8].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv2.Rows[n].Cells[8].Value = 0; }
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 9
            //        for (int n = 0; n < dgv2.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv2.Rows[n].Cells[9].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv2.Rows[n].Cells[9].Value = 0.00; }
            //        }
            //        #endregion
            //        #endregion
            //        break;
            //    case 3:
            //        #region calculos dgv3
            //        #region calculos
            //        dgv3.Rows.Add();
            //        dgv3.Rows[dgv3.RowCount - 1].Cells[0].Value = "TOTALES";
            //        for (int n = 0; n < dgv3.RowCount - 1; n++)
            //        {
            //            sumatoria = sumatoria + Convert.ToDouble(dgv3.Rows[n].Cells[1].Value);
            //            suma_modelaje = suma_modelaje + Convert.ToInt32(dgv3.Rows[n].Cells[2].Value);
            //        }

            //        dgv3.Rows[dgv3.RowCount - 1].Cells[1].Value = (sumatoria / sumatoria) * 100;
            //        dgv3.Rows[dgv3.RowCount - 1].Cells[2].Value = suma_modelaje;


            //        for (int n = 0; n < dgv3.RowCount - 1; n++)
            //        {
            //            porcentaje = Convert.ToDouble(dgv3.Rows[n].Cells[1].Value) / sumatoria;
            //            dgv3.Rows[n].Cells[1].Value = (porcentaje * 100).ToString("N2");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN
            //        for (int n = 0; n < dgv3.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv3.Rows[n].Cells[1].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null)
            //            { dgv3.Rows[n].Cells[1].Value = 0.00; }
            //        }
            //        #endregion
            //        #region asignacion
            //        for (int n = 0; n < dgv3.RowCount - 1; n++)
            //        {
            //            double asignacion = 0;
            //            asignacion = (Convert.ToDouble(tb_UnidCompr.Text) * (0.01 * (Convert.ToDouble(dgv3.Rows[n].Cells[1].Value))));
            //            dgv3.Rows[n].Cells[3].Value = asignacion.ToString("N0");
            //        }
            //        #endregion
            //        #region ponderacion
            //        for (int n = 0; n < dgv3.RowCount - 1; n++)
            //        {
            //            string pond = Convert.ToString(dgv3.Rows[n].Cells[3].Value);
            //            pond = pond.Trim(',');
            //            double pond_tod = Convert.ToDouble(pond);
            //            double pond1 = 0, pond2 = 0;
            //            pond1 = (ponderacion80 * 0.01) * (pond_tod);
            //            pond2 = (ponderacion20 * 0.01) * (pond_tod);


            //            dgv3.Rows[n].Cells[4].Value = pond1.ToString("N0");
            //            dgv3.Rows[n].Cells[5].Value = pond2.ToString("N0");
            //        }
            //        #endregion
            //        #region asignacion modelos
            //        for (int n = 0; n < dgv3.RowCount - 1; n++)
            //        {
            //            int unid = Convert.ToInt32(dgv3.Rows[n].Cells[2].Value);

            //            double asig_mod1 = 0, asig_mod2 = 0;
            //            asig_mod1 = (asignacion20 * 0.01) * (unid);
            //            asig_mod2 = (asignacion80 * 0.01) * (unid);


            //            dgv3.Rows[n].Cells[6].Value = asig_mod1.ToString("N0");
            //            dgv3.Rows[n].Cells[7].Value = asig_mod2.ToString("N0");
            //        }
            //        #endregion
            //        #region profundidad
            //        for (int n = 0; n < dgv3.RowCount - 1; n++)
            //        {

            //            string ren4 = Convert.ToString(dgv3.Rows[n].Cells[4].Value);
            //            string ren5 = Convert.ToString(dgv3.Rows[n].Cells[5].Value);
            //            string ren6 = Convert.ToString(dgv3.Rows[n].Cells[6].Value);
            //            string ren7 = Convert.ToString(dgv3.Rows[n].Cells[7].Value);
            //            ren4 = ren4.Replace(",", ""); ren5 = ren5.Replace(",", ""); ren6 = ren6.Replace(",", ""); ren7 = ren7.Replace(",", "");
            //            double v1, v2, v3, v4 = 0;
            //            v1 = Convert.ToDouble(ren4); v2 = Convert.ToDouble(ren5); v3 = Convert.ToDouble(ren6); v4 = Convert.ToDouble(ren7);
            //            prof20 = v1 / v3;
            //            prof80 = v2 / v4;

            //            dgv3.Rows[n].Cells[8].Value = prof20.ToString("N0");
            //            dgv3.Rows[n].Cells[9].Value = prof80.ToString("N0");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 8
            //        for (int n = 0; n < dgv3.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv3.Rows[n].Cells[8].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv3.Rows[n].Cells[8].Value = 0; }
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 9
            //        for (int n = 0; n < dgv3.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv3.Rows[n].Cells[9].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv3.Rows[n].Cells[9].Value = 0.00; }
            //        }
            //        #endregion
            //        #endregion
            //        break;
            //    case 4:
            //        #region calculos dgv4
            //        #region calculos
            //        dgv4.Rows.Add();
            //        dgv4.Rows[dgv4.RowCount - 1].Cells[0].Value = "TOTALES";
            //        for (int n = 0; n < dgv4.RowCount - 1; n++)
            //        {
            //            sumatoria = sumatoria + Convert.ToDouble(dgv4.Rows[n].Cells[1].Value);
            //            suma_modelaje = suma_modelaje + Convert.ToInt32(dgv4.Rows[n].Cells[2].Value);
            //        }

            //        dgv4.Rows[dgv4.RowCount - 1].Cells[1].Value = (sumatoria / sumatoria) * 100;
            //        dgv4.Rows[dgv4.RowCount - 1].Cells[2].Value = suma_modelaje;


            //        for (int n = 0; n < dgv4.RowCount - 1; n++)
            //        {
            //            porcentaje = Convert.ToDouble(dgv4.Rows[n].Cells[1].Value) / sumatoria;
            //            dgv4.Rows[n].Cells[1].Value = (porcentaje * 100).ToString("N2");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN
            //        for (int n = 0; n < dgv4.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv4.Rows[n].Cells[1].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null)
            //            { dgv4.Rows[n].Cells[1].Value = 0.00; }
            //        }
            //        #endregion
            //        #region asignacion
            //        for (int n = 0; n < dgv4.RowCount - 1; n++)
            //        {
            //            double asignacion = 0;
            //            asignacion = (Convert.ToDouble(tb_UnidCompr.Text) * (0.01 * (Convert.ToDouble(dgv4.Rows[n].Cells[1].Value))));
            //            dgv4.Rows[n].Cells[3].Value = asignacion.ToString("N0");
            //        }
            //        #endregion
            //        #region ponderacion
            //        for (int n = 0; n < dgv4.RowCount - 1; n++)
            //        {
            //            string pond = Convert.ToString(dgv4.Rows[n].Cells[3].Value);
            //            pond = pond.Trim(',');
            //            double pond_tod = Convert.ToDouble(pond);
            //            double pond1 = 0, pond2 = 0;
            //            pond1 = (ponderacion80 * 0.01) * (pond_tod);
            //            pond2 = (ponderacion20 * 0.01) * (pond_tod);


            //            dgv4.Rows[n].Cells[4].Value = pond1.ToString("N0");
            //            dgv4.Rows[n].Cells[5].Value = pond2.ToString("N0");
            //        }
            //        #endregion
            //        #region asignacion modelos
            //        for (int n = 0; n < dgv4.RowCount - 1; n++)
            //        {
            //            int unid = Convert.ToInt32(dgv4.Rows[n].Cells[2].Value);

            //            double asig_mod1 = 0, asig_mod2 = 0;
            //            asig_mod1 = (asignacion20 * 0.01) * (unid);
            //            asig_mod2 = (asignacion80 * 0.01) * (unid);


            //            dgv4.Rows[n].Cells[6].Value = asig_mod1.ToString("N0");
            //            dgv4.Rows[n].Cells[7].Value = asig_mod2.ToString("N0");
            //        }
            //        #endregion
            //        #region profundidad
            //        for (int n = 0; n < dgv4.RowCount - 1; n++)
            //        {

            //            string ren4 = Convert.ToString(dgv4.Rows[n].Cells[4].Value);
            //            string ren5 = Convert.ToString(dgv4.Rows[n].Cells[5].Value);
            //            string ren6 = Convert.ToString(dgv4.Rows[n].Cells[6].Value);
            //            string ren7 = Convert.ToString(dgv4.Rows[n].Cells[7].Value);
            //            ren4 = ren4.Replace(",", ""); ren5 = ren5.Replace(",", ""); ren6 = ren6.Replace(",", ""); ren7 = ren7.Replace(",", "");
            //            double v1, v2, v3, v4 = 0;
            //            v1 = Convert.ToDouble(ren4); v2 = Convert.ToDouble(ren5); v3 = Convert.ToDouble(ren6); v4 = Convert.ToDouble(ren7);
            //            prof20 = v1 / v3;
            //            prof80 = v2 / v4;

            //            dgv4.Rows[n].Cells[8].Value = prof20.ToString("N0");
            //            dgv4.Rows[n].Cells[9].Value = prof80.ToString("N0");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 8
            //        for (int n = 0; n < dgv4.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv4.Rows[n].Cells[8].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv4.Rows[n].Cells[8].Value = 0; }
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 9
            //        for (int n = 0; n < dgv4.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv4.Rows[n].Cells[9].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv4.Rows[n].Cells[9].Value = 0.00; }
            //        }
            //        #endregion
            //        #endregion
            //        break;
            //    case 5:
            //        #region calculos dgv5
            //        #region calculos
            //        dgv5.Rows.Add();
            //        dgv5.Rows[dgv5.RowCount - 1].Cells[0].Value = "TOTALES";
            //        for (int n = 0; n < dgv5.RowCount - 1; n++)
            //        {
            //            sumatoria = sumatoria + Convert.ToDouble(dgv5.Rows[n].Cells[1].Value);
            //            suma_modelaje = suma_modelaje + Convert.ToInt32(dgv5.Rows[n].Cells[2].Value);
            //        }

            //        dgv5.Rows[dgv5.RowCount - 1].Cells[1].Value = (sumatoria / sumatoria) * 100;
            //        dgv5.Rows[dgv5.RowCount - 1].Cells[2].Value = suma_modelaje;


            //        for (int n = 0; n < dgv5.RowCount - 1; n++)
            //        {
            //            porcentaje = Convert.ToDouble(dgv5.Rows[n].Cells[1].Value) / sumatoria;
            //            dgv5.Rows[n].Cells[1].Value = (porcentaje * 100).ToString("N2");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN
            //        for (int n = 0; n < dgv5.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv5.Rows[n].Cells[1].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null)
            //            { dgv5.Rows[n].Cells[1].Value = 0.00; }
            //        }
            //        #endregion
            //        #region asignacion
            //        for (int n = 0; n < dgv5.RowCount - 1; n++)
            //        {
            //            double asignacion = 0;
            //            asignacion = (Convert.ToDouble(tb_UnidCompr.Text) * (0.01 * (Convert.ToDouble(dgv5.Rows[n].Cells[1].Value))));
            //            dgv5.Rows[n].Cells[3].Value = asignacion.ToString("N0");
            //        }
            //        #endregion
            //        #region ponderacion
            //        for (int n = 0; n < dgv5.RowCount - 1; n++)
            //        {
            //            string pond = Convert.ToString(dgv5.Rows[n].Cells[3].Value);
            //            pond = pond.Trim(',');
            //            double pond_tod = Convert.ToDouble(pond);
            //            double pond1 = 0, pond2 = 0;
            //            pond1 = (ponderacion80 * 0.01) * (pond_tod);
            //            pond2 = (ponderacion20 * 0.01) * (pond_tod);


            //            dgv5.Rows[n].Cells[4].Value = pond1.ToString("N0");
            //            dgv5.Rows[n].Cells[5].Value = pond2.ToString("N0");
            //        }
            //        #endregion
            //        #region asignacion modelos
            //        for (int n = 0; n < dgv5.RowCount - 1; n++)
            //        {
            //            int unid = Convert.ToInt32(dgv5.Rows[n].Cells[2].Value);

            //            double asig_mod1 = 0, asig_mod2 = 0;
            //            asig_mod1 = (asignacion20 * 0.01) * (unid);
            //            asig_mod2 = (asignacion80 * 0.01) * (unid);


            //            dgv5.Rows[n].Cells[6].Value = asig_mod1.ToString("N0");
            //            dgv5.Rows[n].Cells[7].Value = asig_mod2.ToString("N0");
            //        }
            //        #endregion
            //        #region profundidad
            //        for (int n = 0; n < dgv5.RowCount - 1; n++)
            //        {

            //            string ren4 = Convert.ToString(dgv5.Rows[n].Cells[4].Value);
            //            string ren5 = Convert.ToString(dgv5.Rows[n].Cells[5].Value);
            //            string ren6 = Convert.ToString(dgv5.Rows[n].Cells[6].Value);
            //            string ren7 = Convert.ToString(dgv5.Rows[n].Cells[7].Value);
            //            ren4 = ren4.Replace(",", ""); ren5 = ren5.Replace(",", ""); ren6 = ren6.Replace(",", ""); ren7 = ren7.Replace(",", "");
            //            double v1, v2, v3, v4 = 0;
            //            v1 = Convert.ToDouble(ren4); v2 = Convert.ToDouble(ren5); v3 = Convert.ToDouble(ren6); v4 = Convert.ToDouble(ren7);
            //            prof20 = v1 / v3;
            //            prof80 = v2 / v4;

            //            dgv5.Rows[n].Cells[8].Value = prof20.ToString("N0");
            //            dgv5.Rows[n].Cells[9].Value = prof80.ToString("N0");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 8
            //        for (int n = 0; n < dgv5.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv5.Rows[n].Cells[8].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv5.Rows[n].Cells[8].Value = 0; }
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 9
            //        for (int n = 0; n < dgv5.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv5.Rows[n].Cells[9].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv5.Rows[n].Cells[9].Value = 0.00; }
            //        }
            //        #endregion
            //        #endregion
            //        break;
            //    case 6:
            //        #region calculos dgv6
            //        #region calculos
            //        dgv6.Rows.Add();
            //        dgv6.Rows[dgv6.RowCount - 1].Cells[0].Value = "TOTALES";
            //        for (int n = 0; n < dgv6.RowCount - 1; n++)
            //        {
            //            sumatoria = sumatoria + Convert.ToDouble(dgv6.Rows[n].Cells[1].Value);
            //            suma_modelaje = suma_modelaje + Convert.ToInt32(dgv6.Rows[n].Cells[2].Value);
            //        }

            //        dgv6.Rows[dgv6.RowCount - 1].Cells[1].Value = (sumatoria / sumatoria) * 100;
            //        dgv6.Rows[dgv6.RowCount - 1].Cells[2].Value = suma_modelaje;


            //        for (int n = 0; n < dgv6.RowCount - 1; n++)
            //        {
            //            porcentaje = Convert.ToDouble(dgv6.Rows[n].Cells[1].Value) / sumatoria;
            //            dgv6.Rows[n].Cells[1].Value = (porcentaje * 100).ToString("N2");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN
            //        for (int n = 0; n < dgv6.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv6.Rows[n].Cells[1].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null)
            //            { dgv6.Rows[n].Cells[1].Value = 0.00; }
            //        }
            //        #endregion
            //        #region asignacion
            //        for (int n = 0; n < dgv6.RowCount - 1; n++)
            //        {
            //            double asignacion = 0;
            //            asignacion = (Convert.ToDouble(tb_UnidCompr.Text) * (0.01 * (Convert.ToDouble(dgv6.Rows[n].Cells[1].Value))));
            //            dgv6.Rows[n].Cells[3].Value = asignacion.ToString("N0");
            //        }
            //        #endregion
            //        #region ponderacion
            //        for (int n = 0; n < dgv6.RowCount - 1; n++)
            //        {
            //            string pond = Convert.ToString(dgv6.Rows[n].Cells[3].Value);
            //            pond = pond.Trim(',');
            //            double pond_tod = Convert.ToDouble(pond);
            //            double pond1 = 0, pond2 = 0;
            //            pond1 = (ponderacion80 * 0.01) * (pond_tod);
            //            pond2 = (ponderacion20 * 0.01) * (pond_tod);


            //            dgv6.Rows[n].Cells[4].Value = pond1.ToString("N0");
            //            dgv6.Rows[n].Cells[5].Value = pond2.ToString("N0");
            //        }
            //        #endregion
            //        #region asignacion modelos
            //        for (int n = 0; n < dgv6.RowCount - 1; n++)
            //        {
            //            int unid = Convert.ToInt32(dgv6.Rows[n].Cells[2].Value);

            //            double asig_mod1 = 0, asig_mod2 = 0;
            //            asig_mod1 = (asignacion20 * 0.01) * (unid);
            //            asig_mod2 = (asignacion80 * 0.01) * (unid);


            //            dgv6.Rows[n].Cells[6].Value = asig_mod1.ToString("N0");
            //            dgv6.Rows[n].Cells[7].Value = asig_mod2.ToString("N0");
            //        }
            //        #endregion
            //        #region profundidad
            //        for (int n = 0; n < dgv6.RowCount - 1; n++)
            //        {

            //            string ren4 = Convert.ToString(dgv6.Rows[n].Cells[4].Value);
            //            string ren5 = Convert.ToString(dgv6.Rows[n].Cells[5].Value);
            //            string ren6 = Convert.ToString(dgv6.Rows[n].Cells[6].Value);
            //            string ren7 = Convert.ToString(dgv6.Rows[n].Cells[7].Value);
            //            ren4 = ren4.Replace(",", ""); ren5 = ren5.Replace(",", ""); ren6 = ren6.Replace(",", ""); ren7 = ren7.Replace(",", "");
            //            double v1, v2, v3, v4 = 0;
            //            v1 = Convert.ToDouble(ren4); v2 = Convert.ToDouble(ren5); v3 = Convert.ToDouble(ren6); v4 = Convert.ToDouble(ren7);
            //            prof20 = v1 / v3;
            //            prof80 = v2 / v4;

            //            dgv6.Rows[n].Cells[8].Value = prof20.ToString("N0");
            //            dgv6.Rows[n].Cells[9].Value = prof80.ToString("N0");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 8
            //        for (int n = 0; n < dgv6.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv6.Rows[n].Cells[8].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv6.Rows[n].Cells[8].Value = 0; }
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 9
            //        for (int n = 0; n < dgv6.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv6.Rows[n].Cells[9].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv6.Rows[n].Cells[9].Value = 0.00; }
            //        }
            //        #endregion
            //        #endregion
            //        break;
            //    case 7:
            //        #region calculos dgv7
            //        #region calculos
            //        dgv7.Rows.Add();
            //        dgv7.Rows[dgv7.RowCount - 1].Cells[0].Value = "TOTALES";
            //        for (int n = 0; n < dgv7.RowCount - 1; n++)
            //        {
            //            sumatoria = sumatoria + Convert.ToDouble(dgv7.Rows[n].Cells[1].Value);
            //            suma_modelaje = suma_modelaje + Convert.ToInt32(dgv7.Rows[n].Cells[2].Value);
            //        }

            //        dgv7.Rows[dgv7.RowCount - 1].Cells[1].Value = (sumatoria / sumatoria) * 100;
            //        dgv7.Rows[dgv7.RowCount - 1].Cells[2].Value = suma_modelaje;


            //        for (int n = 0; n < dgv7.RowCount - 1; n++)
            //        {
            //            porcentaje = Convert.ToDouble(dgv7.Rows[n].Cells[1].Value) / sumatoria;
            //            dgv7.Rows[n].Cells[1].Value = (porcentaje * 100).ToString("N2");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN
            //        for (int n = 0; n < dgv7.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv7.Rows[n].Cells[1].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null)
            //            { dgv7.Rows[n].Cells[1].Value = 0.00; }
            //        }
            //        #endregion
            //        #region asignacion
            //        for (int n = 0; n < dgv7.RowCount - 1; n++)
            //        {
            //            double asignacion = 0;
            //            asignacion = (Convert.ToDouble(tb_UnidCompr.Text) * (0.01 * (Convert.ToDouble(dgv7.Rows[n].Cells[1].Value))));
            //            dgv7.Rows[n].Cells[3].Value = asignacion.ToString("N0");
            //        }
            //        #endregion
            //        #region ponderacion
            //        for (int n = 0; n < dgv7.RowCount - 1; n++)
            //        {
            //            string pond = Convert.ToString(dgv7.Rows[n].Cells[3].Value);
            //            pond = pond.Trim(',');
            //            double pond_tod = Convert.ToDouble(pond);
            //            double pond1 = 0, pond2 = 0;
            //            pond1 = (ponderacion80 * 0.01) * (pond_tod);
            //            pond2 = (ponderacion20 * 0.01) * (pond_tod);


            //            dgv7.Rows[n].Cells[4].Value = pond1.ToString("N0");
            //            dgv7.Rows[n].Cells[5].Value = pond2.ToString("N0");
            //        }
            //        #endregion
            //        #region asignacion modelos
            //        for (int n = 0; n < dgv7.RowCount - 1; n++)
            //        {
            //            int unid = Convert.ToInt32(dgv7.Rows[n].Cells[2].Value);

            //            double asig_mod1 = 0, asig_mod2 = 0;
            //            asig_mod1 = (asignacion20 * 0.01) * (unid);
            //            asig_mod2 = (asignacion80 * 0.01) * (unid);


            //            dgv7.Rows[n].Cells[6].Value = asig_mod1.ToString("N0");
            //            dgv7.Rows[n].Cells[7].Value = asig_mod2.ToString("N0");
            //        }
            //        #endregion
            //        #region profundidad
            //        for (int n = 0; n < dgv7.RowCount - 1; n++)
            //        {

            //            string ren4 = Convert.ToString(dgv7.Rows[n].Cells[4].Value);
            //            string ren5 = Convert.ToString(dgv7.Rows[n].Cells[5].Value);
            //            string ren6 = Convert.ToString(dgv7.Rows[n].Cells[6].Value);
            //            string ren7 = Convert.ToString(dgv7.Rows[n].Cells[7].Value);
            //            ren4 = ren4.Replace(",", ""); ren5 = ren5.Replace(",", ""); ren6 = ren6.Replace(",", ""); ren7 = ren7.Replace(",", "");
            //            double v1, v2, v3, v4 = 0;
            //            v1 = Convert.ToDouble(ren4); v2 = Convert.ToDouble(ren5); v3 = Convert.ToDouble(ren6); v4 = Convert.ToDouble(ren7);
            //            prof20 = v1 / v3;
            //            prof80 = v2 / v4;

            //            dgv7.Rows[n].Cells[8].Value = prof20.ToString("N0");
            //            dgv7.Rows[n].Cells[9].Value = prof80.ToString("N0");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 8
            //        for (int n = 0; n < dgv7.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv7.Rows[n].Cells[8].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv7.Rows[n].Cells[8].Value = 0; }
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 9
            //        for (int n = 0; n < dgv7.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv7.Rows[n].Cells[9].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv7.Rows[n].Cells[9].Value = 0.00; }
            //        }
            //        #endregion
            //        #endregion
            //        break;
            //    case 8:
            //        #region calculos dgv8
            //        #region calculos
            //        dgv8.Rows.Add();
            //        dgv8.Rows[dgv8.RowCount - 1].Cells[0].Value = "TOTALES";
            //        for (int n = 0; n < dgv8.RowCount - 1; n++)
            //        {
            //            sumatoria = sumatoria + Convert.ToDouble(dgv8.Rows[n].Cells[1].Value);
            //            suma_modelaje = suma_modelaje + Convert.ToInt32(dgv8.Rows[n].Cells[2].Value);
            //        }

            //        dgv8.Rows[dgv8.RowCount - 1].Cells[1].Value = (sumatoria / sumatoria) * 100;
            //        dgv8.Rows[dgv8.RowCount - 1].Cells[2].Value = suma_modelaje;


            //        for (int n = 0; n < dgv8.RowCount - 1; n++)
            //        {
            //            porcentaje = Convert.ToDouble(dgv8.Rows[n].Cells[1].Value) / sumatoria;
            //            dgv8.Rows[n].Cells[1].Value = (porcentaje * 100).ToString("N2");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN
            //        for (int n = 0; n < dgv8.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv8.Rows[n].Cells[1].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null)
            //            { dgv8.Rows[n].Cells[1].Value = 0.00; }
            //        }
            //        #endregion
            //        #region asignacion
            //        for (int n = 0; n < dgv8.RowCount - 1; n++)
            //        {
            //            double asignacion = 0;
            //            asignacion = (Convert.ToDouble(tb_UnidCompr.Text) * (0.01 * (Convert.ToDouble(dgv8.Rows[n].Cells[1].Value))));
            //            dgv8.Rows[n].Cells[3].Value = asignacion.ToString("N0");
            //        }
            //        #endregion
            //        #region ponderacion
            //        for (int n = 0; n < dgv8.RowCount - 1; n++)
            //        {
            //            string pond = Convert.ToString(dgv8.Rows[n].Cells[3].Value);
            //            pond = pond.Trim(',');
            //            double pond_tod = Convert.ToDouble(pond);
            //            double pond1 = 0, pond2 = 0;
            //            pond1 = (ponderacion80 * 0.01) * (pond_tod);
            //            pond2 = (ponderacion20 * 0.01) * (pond_tod);


            //            dgv8.Rows[n].Cells[4].Value = pond1.ToString("N0");
            //            dgv8.Rows[n].Cells[5].Value = pond2.ToString("N0");
            //        }
            //        #endregion
            //        #region asignacion modelos
            //        for (int n = 0; n < dgv8.RowCount - 1; n++)
            //        {
            //            int unid = Convert.ToInt32(dgv8.Rows[n].Cells[2].Value);

            //            double asig_mod1 = 0, asig_mod2 = 0;
            //            asig_mod1 = (asignacion20 * 0.01) * (unid);
            //            asig_mod2 = (asignacion80 * 0.01) * (unid);


            //            dgv8.Rows[n].Cells[6].Value = asig_mod1.ToString("N0");
            //            dgv8.Rows[n].Cells[7].Value = asig_mod2.ToString("N0");
            //        }
            //        #endregion
            //        #region profundidad
            //        for (int n = 0; n < dgv8.RowCount - 1; n++)
            //        {

            //            string ren4 = Convert.ToString(dgv8.Rows[n].Cells[4].Value);
            //            string ren5 = Convert.ToString(dgv8.Rows[n].Cells[5].Value);
            //            string ren6 = Convert.ToString(dgv8.Rows[n].Cells[6].Value);
            //            string ren7 = Convert.ToString(dgv8.Rows[n].Cells[7].Value);
            //            ren4 = ren4.Replace(",", ""); ren5 = ren5.Replace(",", ""); ren6 = ren6.Replace(",", ""); ren7 = ren7.Replace(",", "");
            //            double v1, v2, v3, v4 = 0;
            //            v1 = Convert.ToDouble(ren4); v2 = Convert.ToDouble(ren5); v3 = Convert.ToDouble(ren6); v4 = Convert.ToDouble(ren7);
            //            prof20 = v1 / v3;
            //            prof80 = v2 / v4;

            //            dgv8.Rows[n].Cells[8].Value = prof20.ToString("N0");
            //            dgv8.Rows[n].Cells[9].Value = prof80.ToString("N0");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 8
            //        for (int n = 0; n < dgv8.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv8.Rows[n].Cells[8].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv8.Rows[n].Cells[8].Value = 0; }
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 9
            //        for (int n = 0; n < dgv8.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv8.Rows[n].Cells[9].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv8.Rows[n].Cells[9].Value = 0.00; }
            //        }
            //        #endregion
            //        #endregion
            //        break;
            //    case 9:
            //        #region calculos dgv9
            //        #region calculos
            //        dgv9.Rows.Add();
            //        dgv9.Rows[dgv9.RowCount - 1].Cells[0].Value = "TOTALES";
            //        for (int n = 0; n < dgv9.RowCount - 1; n++)
            //        {
            //            sumatoria = sumatoria + Convert.ToDouble(dgv9.Rows[n].Cells[1].Value);
            //            suma_modelaje = suma_modelaje + Convert.ToInt32(dgv9.Rows[n].Cells[2].Value);
            //        }

            //        dgv9.Rows[dgv9.RowCount - 1].Cells[1].Value = (sumatoria / sumatoria) * 100;
            //        dgv9.Rows[dgv9.RowCount - 1].Cells[2].Value = suma_modelaje;


            //        for (int n = 0; n < dgv9.RowCount - 1; n++)
            //        {
            //            porcentaje = Convert.ToDouble(dgv9.Rows[n].Cells[1].Value) / sumatoria;
            //            dgv9.Rows[n].Cells[1].Value = (porcentaje * 100).ToString("N2");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN
            //        for (int n = 0; n < dgv9.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv9.Rows[n].Cells[1].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null)
            //            { dgv9.Rows[n].Cells[1].Value = 0.00; }
            //        }
            //        #endregion
            //        #region asignacion
            //        for (int n = 0; n < dgv9.RowCount - 1; n++)
            //        {
            //            double asignacion = 0;
            //            asignacion = (Convert.ToDouble(tb_UnidCompr.Text) * (0.01 * (Convert.ToDouble(dgv9.Rows[n].Cells[1].Value))));
            //            dgv9.Rows[n].Cells[3].Value = asignacion.ToString("N0");
            //        }
            //        #endregion
            //        #region ponderacion
            //        for (int n = 0; n < dgv9.RowCount - 1; n++)
            //        {
            //            string pond = Convert.ToString(dgv9.Rows[n].Cells[3].Value);
            //            pond = pond.Trim(',');
            //            double pond_tod = Convert.ToDouble(pond);
            //            double pond1 = 0, pond2 = 0;
            //            pond1 = (ponderacion80 * 0.01) * (pond_tod);
            //            pond2 = (ponderacion20 * 0.01) * (pond_tod);


            //            dgv9.Rows[n].Cells[4].Value = pond1.ToString("N0");
            //            dgv9.Rows[n].Cells[5].Value = pond2.ToString("N0");
            //        }
            //        #endregion
            //        #region asignacion modelos
            //        for (int n = 0; n < dgv9.RowCount - 1; n++)
            //        {
            //            int unid = Convert.ToInt32(dgv9.Rows[n].Cells[2].Value);

            //            double asig_mod1 = 0, asig_mod2 = 0;
            //            asig_mod1 = (asignacion20 * 0.01) * (unid);
            //            asig_mod2 = (asignacion80 * 0.01) * (unid);


            //            dgv9.Rows[n].Cells[6].Value = asig_mod1.ToString("N0");
            //            dgv9.Rows[n].Cells[7].Value = asig_mod2.ToString("N0");
            //        }
            //        #endregion
            //        #region profundidad
            //        for (int n = 0; n < dgv9.RowCount - 1; n++)
            //        {

            //            string ren4 = Convert.ToString(dgv9.Rows[n].Cells[4].Value);
            //            string ren5 = Convert.ToString(dgv9.Rows[n].Cells[5].Value);
            //            string ren6 = Convert.ToString(dgv9.Rows[n].Cells[6].Value);
            //            string ren7 = Convert.ToString(dgv9.Rows[n].Cells[7].Value);
            //            ren4 = ren4.Replace(",", ""); ren5 = ren5.Replace(",", ""); ren6 = ren6.Replace(",", ""); ren7 = ren7.Replace(",", "");
            //            double v1, v2, v3, v4 = 0;
            //            v1 = Convert.ToDouble(ren4); v2 = Convert.ToDouble(ren5); v3 = Convert.ToDouble(ren6); v4 = Convert.ToDouble(ren7);
            //            prof20 = v1 / v3;
            //            prof80 = v2 / v4;

            //            dgv9.Rows[n].Cells[8].Value = prof20.ToString("N0");
            //            dgv9.Rows[n].Cells[9].Value = prof80.ToString("N0");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 8
            //        for (int n = 0; n < dgv9.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv9.Rows[n].Cells[8].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv9.Rows[n].Cells[8].Value = 0; }
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 9
            //        for (int n = 0; n < dgv9.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv9.Rows[n].Cells[9].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv9.Rows[n].Cells[9].Value = 0.00; }
            //        }
            //        #endregion
            //        #endregion
            //        break;
            //    case 10:
            //        #region calculos dgv10
            //        #region calculos
            //        dgv10.Rows.Add();
            //        dgv10.Rows[dgv10.RowCount - 1].Cells[0].Value = "TOTALES";
            //        for (int n = 0; n < dgv10.RowCount - 1; n++)
            //        {
            //            sumatoria = sumatoria + Convert.ToDouble(dgv10.Rows[n].Cells[1].Value);
            //            suma_modelaje = suma_modelaje + Convert.ToInt32(dgv10.Rows[n].Cells[2].Value);
            //        }

            //        dgv10.Rows[dgv10.RowCount - 1].Cells[1].Value = (sumatoria / sumatoria) * 100;
            //        dgv10.Rows[dgv10.RowCount - 1].Cells[2].Value = suma_modelaje;


            //        for (int n = 0; n < dgv10.RowCount - 1; n++)
            //        {
            //            porcentaje = Convert.ToDouble(dgv10.Rows[n].Cells[1].Value) / sumatoria;
            //            dgv10.Rows[n].Cells[1].Value = (porcentaje * 100).ToString("N2");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN
            //        for (int n = 0; n < dgv10.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv10.Rows[n].Cells[1].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null)
            //            { dgv10.Rows[n].Cells[1].Value = 0.00; }
            //        }
            //        #endregion
            //        #region asignacion
            //        for (int n = 0; n < dgv10.RowCount - 1; n++)
            //        {
            //            double asignacion = 0;
            //            asignacion = (Convert.ToDouble(tb_UnidCompr.Text) * (0.01 * (Convert.ToDouble(dgv10.Rows[n].Cells[1].Value))));
            //            dgv10.Rows[n].Cells[3].Value = asignacion.ToString("N0");
            //        }
            //        #endregion
            //        #region ponderacion
            //        for (int n = 0; n < dgv10.RowCount - 1; n++)
            //        {
            //            string pond = Convert.ToString(dgv10.Rows[n].Cells[3].Value);
            //            pond = pond.Trim(',');
            //            double pond_tod = Convert.ToDouble(pond);
            //            double pond1 = 0, pond2 = 0;
            //            pond1 = (ponderacion80 * 0.01) * (pond_tod);
            //            pond2 = (ponderacion20 * 0.01) * (pond_tod);


            //            dgv10.Rows[n].Cells[4].Value = pond1.ToString("N0");
            //            dgv10.Rows[n].Cells[5].Value = pond2.ToString("N0");
            //        }
            //        #endregion
            //        #region asignacion modelos
            //        for (int n = 0; n < dgv10.RowCount - 1; n++)
            //        {
            //            int unid = Convert.ToInt32(dgv10.Rows[n].Cells[2].Value);

            //            double asig_mod1 = 0, asig_mod2 = 0;
            //            asig_mod1 = (asignacion20 * 0.01) * (unid);
            //            asig_mod2 = (asignacion80 * 0.01) * (unid);


            //            dgv10.Rows[n].Cells[6].Value = asig_mod1.ToString("N0");
            //            dgv10.Rows[n].Cells[7].Value = asig_mod2.ToString("N0");
            //        }
            //        #endregion
            //        #region profundidad
            //        for (int n = 0; n < dgv10.RowCount - 1; n++)
            //        {

            //            string ren4 = Convert.ToString(dgv10.Rows[n].Cells[4].Value);
            //            string ren5 = Convert.ToString(dgv10.Rows[n].Cells[5].Value);
            //            string ren6 = Convert.ToString(dgv10.Rows[n].Cells[6].Value);
            //            string ren7 = Convert.ToString(dgv10.Rows[n].Cells[7].Value);
            //            ren4 = ren4.Replace(",", ""); ren5 = ren5.Replace(",", ""); ren6 = ren6.Replace(",", ""); ren7 = ren7.Replace(",", "");
            //            double v1, v2, v3, v4 = 0;
            //            v1 = Convert.ToDouble(ren4); v2 = Convert.ToDouble(ren5); v3 = Convert.ToDouble(ren6); v4 = Convert.ToDouble(ren7);
            //            prof20 = v1 / v3;
            //            prof80 = v2 / v4;

            //            dgv10.Rows[n].Cells[8].Value = prof20.ToString("N0");
            //            dgv10.Rows[n].Cells[9].Value = prof80.ToString("N0");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 8
            //        for (int n = 0; n < dgv10.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv10.Rows[n].Cells[8].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv10.Rows[n].Cells[8].Value = 0; }
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 9
            //        for (int n = 0; n < dgv10.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv10.Rows[n].Cells[9].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv10.Rows[n].Cells[9].Value = 0.00; }
            //        }
            //        #endregion
            //        #endregion
            //        break;
            //    case 11:
            //        #region calculos dgv11
            //        #region calculos
            //        dgv11.Rows.Add();
            //        dgv11.Rows[dgv11.RowCount - 1].Cells[0].Value = "TOTALES";
            //        for (int n = 0; n < dgv11.RowCount - 1; n++)
            //        {
            //            sumatoria = sumatoria + Convert.ToDouble(dgv11.Rows[n].Cells[1].Value);
            //            suma_modelaje = suma_modelaje + Convert.ToInt32(dgv11.Rows[n].Cells[2].Value);
            //        }

            //        dgv11.Rows[dgv11.RowCount - 1].Cells[1].Value = (sumatoria / sumatoria) * 100;
            //        dgv11.Rows[dgv11.RowCount - 1].Cells[2].Value = suma_modelaje;


            //        for (int n = 0; n < dgv11.RowCount - 1; n++)
            //        {
            //            porcentaje = Convert.ToDouble(dgv11.Rows[n].Cells[1].Value) / sumatoria;
            //            dgv11.Rows[n].Cells[1].Value = (porcentaje * 100).ToString("N2");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN
            //        for (int n = 0; n < dgv11.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv11.Rows[n].Cells[1].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null)
            //            { dgv11.Rows[n].Cells[1].Value = 0.00; }
            //        }
            //        #endregion
            //        #region asignacion
            //        for (int n = 0; n < dgv11.RowCount - 1; n++)
            //        {
            //            double asignacion = 0;
            //            asignacion = (Convert.ToDouble(tb_UnidCompr.Text) * (0.01 * (Convert.ToDouble(dgv11.Rows[n].Cells[1].Value))));
            //            dgv11.Rows[n].Cells[3].Value = asignacion.ToString("N0");
            //        }
            //        #endregion
            //        #region ponderacion
            //        for (int n = 0; n < dgv11.RowCount - 1; n++)
            //        {
            //            string pond = Convert.ToString(dgv11.Rows[n].Cells[3].Value);
            //            pond = pond.Trim(',');
            //            double pond_tod = Convert.ToDouble(pond);
            //            double pond1 = 0, pond2 = 0;
            //            pond1 = (ponderacion80 * 0.01) * (pond_tod);
            //            pond2 = (ponderacion20 * 0.01) * (pond_tod);


            //            dgv11.Rows[n].Cells[4].Value = pond1.ToString("N0");
            //            dgv11.Rows[n].Cells[5].Value = pond2.ToString("N0");
            //        }
            //        #endregion
            //        #region asignacion modelos
            //        for (int n = 0; n < dgv11.RowCount - 1; n++)
            //        {
            //            int unid = Convert.ToInt32(dgv11.Rows[n].Cells[2].Value);

            //            double asig_mod1 = 0, asig_mod2 = 0;
            //            asig_mod1 = (asignacion20 * 0.01) * (unid);
            //            asig_mod2 = (asignacion80 * 0.01) * (unid);


            //            dgv11.Rows[n].Cells[6].Value = asig_mod1.ToString("N0");
            //            dgv11.Rows[n].Cells[7].Value = asig_mod2.ToString("N0");
            //        }
            //        #endregion
            //        #region profundidad
            //        for (int n = 0; n < dgv11.RowCount - 1; n++)
            //        {

            //            string ren4 = Convert.ToString(dgv11.Rows[n].Cells[4].Value);
            //            string ren5 = Convert.ToString(dgv11.Rows[n].Cells[5].Value);
            //            string ren6 = Convert.ToString(dgv11.Rows[n].Cells[6].Value);
            //            string ren7 = Convert.ToString(dgv11.Rows[n].Cells[7].Value);
            //            ren4 = ren4.Replace(",", ""); ren5 = ren5.Replace(",", ""); ren6 = ren6.Replace(",", ""); ren7 = ren7.Replace(",", "");
            //            double v1, v2, v3, v4 = 0;
            //            v1 = Convert.ToDouble(ren4); v2 = Convert.ToDouble(ren5); v3 = Convert.ToDouble(ren6); v4 = Convert.ToDouble(ren7);
            //            prof20 = v1 / v3;
            //            prof80 = v2 / v4;

            //            dgv11.Rows[n].Cells[8].Value = prof20.ToString("N0");
            //            dgv11.Rows[n].Cells[9].Value = prof80.ToString("N0");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 8
            //        for (int n = 0; n < dgv11.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv11.Rows[n].Cells[8].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv11.Rows[n].Cells[8].Value = 0; }
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 9
            //        for (int n = 0; n < dgv11.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv11.Rows[n].Cells[9].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv11.Rows[n].Cells[9].Value = 0.00; }
            //        }
            //        #endregion
            //        #endregion
            //        break;
            //    case 12:
            //        #region calculos dgv12
            //        #region calculos
            //        dgv12.Rows.Add();
            //        dgv12.Rows[dgv12.RowCount - 1].Cells[0].Value = "TOTALES";
            //        for (int n = 0; n < dgv12.RowCount - 1; n++)
            //        {
            //            sumatoria = sumatoria + Convert.ToDouble(dgv12.Rows[n].Cells[1].Value);
            //            suma_modelaje = suma_modelaje + Convert.ToInt32(dgv12.Rows[n].Cells[2].Value);
            //        }

            //        dgv12.Rows[dgv12.RowCount - 1].Cells[1].Value = (sumatoria / sumatoria) * 100;
            //        dgv12.Rows[dgv12.RowCount - 1].Cells[2].Value = suma_modelaje;


            //        for (int n = 0; n < dgv12.RowCount - 1; n++)
            //        {
            //            porcentaje = Convert.ToDouble(dgv12.Rows[n].Cells[1].Value) / sumatoria;
            //            dgv12.Rows[n].Cells[1].Value = (porcentaje * 100).ToString("N2");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN
            //        for (int n = 0; n < dgv12.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv12.Rows[n].Cells[1].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null)
            //            { dgv12.Rows[n].Cells[1].Value = 0.00; }
            //        }
            //        #endregion
            //        #region asignacion
            //        for (int n = 0; n < dgv12.RowCount - 1; n++)
            //        {
            //            double asignacion = 0;
            //            asignacion = (Convert.ToDouble(tb_UnidCompr.Text) * (0.01 * (Convert.ToDouble(dgv12.Rows[n].Cells[1].Value))));
            //            dgv12.Rows[n].Cells[3].Value = asignacion.ToString("N0");
            //        }
            //        #endregion
            //        #region ponderacion
            //        for (int n = 0; n < dgv12.RowCount - 1; n++)
            //        {
            //            string pond = Convert.ToString(dgv12.Rows[n].Cells[3].Value);
            //            pond = pond.Trim(',');
            //            double pond_tod = Convert.ToDouble(pond);
            //            double pond1 = 0, pond2 = 0;
            //            pond1 = (ponderacion80 * 0.01) * (pond_tod);
            //            pond2 = (ponderacion20 * 0.01) * (pond_tod);


            //            dgv12.Rows[n].Cells[4].Value = pond1.ToString("N0");
            //            dgv12.Rows[n].Cells[5].Value = pond2.ToString("N0");
            //        }
            //        #endregion
            //        #region asignacion modelos
            //        for (int n = 0; n < dgv12.RowCount - 1; n++)
            //        {
            //            int unid = Convert.ToInt32(dgv12.Rows[n].Cells[2].Value);

            //            double asig_mod1 = 0, asig_mod2 = 0;
            //            asig_mod1 = (asignacion20 * 0.01) * (unid);
            //            asig_mod2 = (asignacion80 * 0.01) * (unid);


            //            dgv12.Rows[n].Cells[6].Value = asig_mod1.ToString("N0");
            //            dgv12.Rows[n].Cells[7].Value = asig_mod2.ToString("N0");
            //        }
            //        #endregion
            //        #region profundidad
            //        for (int n = 0; n < dgv12.RowCount - 1; n++)
            //        {

            //            string ren4 = Convert.ToString(dgv12.Rows[n].Cells[4].Value);
            //            string ren5 = Convert.ToString(dgv12.Rows[n].Cells[5].Value);
            //            string ren6 = Convert.ToString(dgv12.Rows[n].Cells[6].Value);
            //            string ren7 = Convert.ToString(dgv12.Rows[n].Cells[7].Value);
            //            ren4 = ren4.Replace(",", ""); ren5 = ren5.Replace(",", ""); ren6 = ren6.Replace(",", ""); ren7 = ren7.Replace(",", "");
            //            double v1, v2, v3, v4 = 0;
            //            v1 = Convert.ToDouble(ren4); v2 = Convert.ToDouble(ren5); v3 = Convert.ToDouble(ren6); v4 = Convert.ToDouble(ren7);
            //            prof20 = v1 / v3;
            //            prof80 = v2 / v4;

            //            dgv12.Rows[n].Cells[8].Value = prof20.ToString("N0");
            //            dgv12.Rows[n].Cells[9].Value = prof80.ToString("N0");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 8
            //        for (int n = 0; n < dgv12.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv12.Rows[n].Cells[8].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv12.Rows[n].Cells[8].Value = 0; }
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 9
            //        for (int n = 0; n < dgv12.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv12.Rows[n].Cells[9].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv12.Rows[n].Cells[9].Value = 0.00; }
            //        }
            //        #endregion
            //        #endregion
            //        break;
            //    case 13: break;

            //}


        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabcontrol.SelectedIndex = 0;
           // m_ESTRUCTURA();
            m_DIASMESESANOS(CED1_fechaI, CED1_fechaF);
            tabcontrol.SelectedIndex = 0;
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

        private void dgvProf1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int dgv = 0;
            dgv = tabcontrol.SelectedIndex;
            double modelajeP = 0;
            double modelosA = 0;
            double modelosB = 0;
            double profundidadA = 0;
            double profundidadB = 0;
            switch(dgv)
            {
                case 0:
                    #region dgv1
                    //modelajeP = double.Parse(dgv1.Rows[e.RowIndex].Cells[4].Value.ToString());
                    ////////////////////////////
                    //modelosA = modelajeP * 80;
                    //modelosB = modelajeP * 20;
                    ////////////////////////////
                    //profundidadA = double.Parse(dgv1.Rows[e.RowIndex].Cells[7].Value.ToString());
                    //profundidadB = double.Parse(dgv1.Rows[e.RowIndex].Cells[8].Value.ToString());
                    ////////////////////////////
                    //dgv1.Rows[e.RowIndex].Cells[9].Value=modelosA.ToString("N0");
                    //dgv1.Rows[e.RowIndex].Cells[10].Value=modelosB.ToString("N0");
                    //dgv1.Rows[e.RowIndex].Cells[11].Value=profundidadA.ToString("N2");
                    //dgv1.Rows[e.RowIndex].Cells[12].Value=profundidadB.ToString("N2");
				asignacionModelos(1);
                  profundidad(1);
#endregion
                    break;
                case 1:
                    #region dgv2
                    //modelajeP = double.Parse(dgv2.Rows[e.RowIndex].Cells[4].Value.ToString());
                    ////////////////////////////
                    //modelosA = modelajeP * 80;
                    //modelosB = modelajeP * 20;
                    ////////////////////////////
                    //profundidadA = double.Parse(dgv2.Rows[e.RowIndex].Cells[7].Value.ToString());
                    //profundidadB = double.Parse(dgv2.Rows[e.RowIndex].Cells[8].Value.ToString());
                    ////////////////////////////
                    //dgv2.Rows[e.RowIndex].Cells[9].Value = modelosA.ToString("N0");
                    //dgv2.Rows[e.RowIndex].Cells[10].Value = modelosB.ToString("N0");
                    //dgv2.Rows[e.RowIndex].Cells[11].Value = profundidadA.ToString("N2");
                    //dgv2.Rows[e.RowIndex].Cells[12].Value = profundidadB.ToString("N2");
				asignacionModelos(2);
                  profundidad(2);
                    #endregion
                    break;
                case 2:
                    #region dgv3
                    //modelajeP = double.Parse(dgv3.Rows[e.RowIndex].Cells[4].Value.ToString());
                    ////////////////////////////
                    //modelosA = modelajeP * 80;
                    //modelosB = modelajeP * 20;
                    ////////////////////////////
                    //profundidadA = double.Parse(dgv3.Rows[e.RowIndex].Cells[7].Value.ToString());
                    //profundidadB = double.Parse(dgv3.Rows[e.RowIndex].Cells[8].Value.ToString());
                    ////////////////////////////
                    //dgv3.Rows[e.RowIndex].Cells[9].Value = modelosA.ToString("N0");
                    //dgv3.Rows[e.RowIndex].Cells[10].Value = modelosB.ToString("N0");
                    //dgv3.Rows[e.RowIndex].Cells[11].Value = profundidadA.ToString("N2");
                    //dgv3.Rows[e.RowIndex].Cells[12].Value = profundidadB.ToString("N2");
				asignacionModelos(3);
                  profundidad(3);
                    #endregion
                    break;
                case 3:
                    #region dgv4
                    //modelajeP = double.Parse(dgv4.Rows[e.RowIndex].Cells[4].Value.ToString());
                    ////////////////////////////
                    //modelosA = modelajeP * 80;
                    //modelosB = modelajeP * 20;
                    ////////////////////////////
                    //profundidadA = double.Parse(dgv4.Rows[e.RowIndex].Cells[7].Value.ToString());
                    //profundidadB = double.Parse(dgv4.Rows[e.RowIndex].Cells[8].Value.ToString());
                    ////////////////////////////
                    //dgv4.Rows[e.RowIndex].Cells[9].Value = modelosA.ToString("N0");
                    //dgv4.Rows[e.RowIndex].Cells[10].Value = modelosB.ToString("N0");
                    //dgv4.Rows[e.RowIndex].Cells[11].Value = profundidadA.ToString("N2");
                    //dgv4.Rows[e.RowIndex].Cells[12].Value = profundidadB.ToString("N2");
				asignacionModelos(4);
                  profundidad(4);
                    #endregion
                    break;
                case 4:
                    #region dgv5
                    //modelajeP = double.Parse(dgv5.Rows[e.RowIndex].Cells[4].Value.ToString());
                    ////////////////////////////
                    //modelosA = modelajeP * 80;
                    //modelosB = modelajeP * 20;
                    ////////////////////////////
                    //profundidadA = double.Parse(dgv5.Rows[e.RowIndex].Cells[7].Value.ToString());
                    //profundidadB = double.Parse(dgv5.Rows[e.RowIndex].Cells[8].Value.ToString());
                    ////////////////////////////
                    //dgv5.Rows[e.RowIndex].Cells[9].Value = modelosA.ToString("N0");
                    //dgv5.Rows[e.RowIndex].Cells[10].Value = modelosB.ToString("N0");
                    //dgv5.Rows[e.RowIndex].Cells[11].Value = profundidadA.ToString("N2");
                    //dgv5.Rows[e.RowIndex].Cells[12].Value = profundidadB.ToString("N2");
				asignacionModelos(5);
                  profundidad(5);
                    #endregion
                    break;
                case 5:
                    #region dgv6
                    //modelajeP = double.Parse(dgv6.Rows[e.RowIndex].Cells[4].Value.ToString());
                    ////////////////////////////
                    //modelosA = modelajeP * 80;
                    //modelosB = modelajeP * 20;
                    ////////////////////////////
                    //profundidadA = double.Parse(dgv6.Rows[e.RowIndex].Cells[7].Value.ToString());
                    //profundidadB = double.Parse(dgv6.Rows[e.RowIndex].Cells[8].Value.ToString());
                    ////////////////////////////
                    //dgv6.Rows[e.RowIndex].Cells[9].Value = modelosA.ToString("N0");
                    //dgv6.Rows[e.RowIndex].Cells[10].Value = modelosB.ToString("N0");
                    //dgv6.Rows[e.RowIndex].Cells[11].Value = profundidadA.ToString("N2");
                    //dgv6.Rows[e.RowIndex].Cells[12].Value = profundidadB.ToString("N2");
				asignacionModelos(6);
                  profundidad(6);
                    #endregion
                    break;
                case 6:
                    #region dgv7
                    //modelajeP = double.Parse(dgv7.Rows[e.RowIndex].Cells[4].Value.ToString());
                    ////////////////////////////
                    //modelosA = modelajeP * 80;
                    //modelosB = modelajeP * 20;
                    ////////////////////////////
                    //profundidadA = double.Parse(dgv7.Rows[e.RowIndex].Cells[7].Value.ToString());
                    //profundidadB = double.Parse(dgv7.Rows[e.RowIndex].Cells[8].Value.ToString());
                    ////////////////////////////
                    //dgv7.Rows[e.RowIndex].Cells[9].Value = modelosA.ToString("N0");
                    //dgv7.Rows[e.RowIndex].Cells[10].Value = modelosB.ToString("N0");
                    //dgv7.Rows[e.RowIndex].Cells[11].Value = profundidadA.ToString("N2");
                    //dgv7.Rows[e.RowIndex].Cells[12].Value = profundidadB.ToString("N2");
				asignacionModelos(7);
                  profundidad(7);
                    #endregion
                    break;
                case 7:
                    #region dgv8
                    //modelajeP = double.Parse(dgv8.Rows[e.RowIndex].Cells[4].Value.ToString());
                    ////////////////////////////
                    //modelosA = modelajeP * 80;
                    //modelosB = modelajeP * 20;
                    ////////////////////////////
                    //profundidadA = double.Parse(dgv8.Rows[e.RowIndex].Cells[7].Value.ToString());
                    //profundidadB = double.Parse(dgv8.Rows[e.RowIndex].Cells[8].Value.ToString());
                    ////////////////////////////
                    //dgv8.Rows[e.RowIndex].Cells[9].Value = modelosA.ToString("N0");
                    //dgv8.Rows[e.RowIndex].Cells[10].Value = modelosB.ToString("N0");
                    //dgv8.Rows[e.RowIndex].Cells[11].Value = profundidadA.ToString("N2");
                    //dgv8.Rows[e.RowIndex].Cells[12].Value = profundidadB.ToString("N2");
				asignacionModelos(8);
                  profundidad(8);
                    #endregion
                    break;
                case 8:
                    #region dgv9
                    //modelajeP = double.Parse(dgv9.Rows[e.RowIndex].Cells[4].Value.ToString());
                    ////////////////////////////
                    //modelosA = modelajeP * 80;
                    //modelosB = modelajeP * 20;
                    ////////////////////////////
                    //profundidadA = double.Parse(dgv9.Rows[e.RowIndex].Cells[7].Value.ToString());
                    //profundidadB = double.Parse(dgv9.Rows[e.RowIndex].Cells[8].Value.ToString());
                    ////////////////////////////
                    //dgv9.Rows[e.RowIndex].Cells[9].Value = modelosA.ToString("N0");
                    //dgv9.Rows[e.RowIndex].Cells[10].Value = modelosB.ToString("N0");
                    //dgv9.Rows[e.RowIndex].Cells[11].Value = profundidadA.ToString("N2");
                    //dgv9.Rows[e.RowIndex].Cells[12].Value = profundidadB.ToString("N2");
				asignacionModelos(9);
                  profundidad(8);
                    #endregion
                    break;
                case 9:
                    #region dgv10
                    //modelajeP = double.Parse(dgv10.Rows[e.RowIndex].Cells[4].Value.ToString());
                    ////////////////////////////
                    //modelosA = modelajeP * 80;
                    //modelosB = modelajeP * 20;
                    ////////////////////////////
                    //profundidadA = double.Parse(dgv10.Rows[e.RowIndex].Cells[7].Value.ToString());
                    //profundidadB = double.Parse(dgv10.Rows[e.RowIndex].Cells[8].Value.ToString());
                    ////////////////////////////
                    //dgv10.Rows[e.RowIndex].Cells[9].Value = modelosA.ToString("N0");
                    //dgv10.Rows[e.RowIndex].Cells[10].Value = modelosB.ToString("N0");
                    //dgv10.Rows[e.RowIndex].Cells[11].Value = profundidadA.ToString("N2");
                    //dgv10.Rows[e.RowIndex].Cells[12].Value = profundidadB.ToString("N2");
				asignacionModelos(10);
                  profundidad(10);
                    #endregion
                    break;
                case 10:
                    #region dgv11
                    //modelajeP = double.Parse(dgv11.Rows[e.RowIndex].Cells[4].Value.ToString());
                    ////////////////////////////
                    //modelosA = modelajeP * 80;
                    //modelosB = modelajeP * 20;
                    ////////////////////////////
                    //profundidadA = double.Parse(dgv11.Rows[e.RowIndex].Cells[7].Value.ToString());
                    //profundidadB = double.Parse(dgv11.Rows[e.RowIndex].Cells[8].Value.ToString());
                    ////////////////////////////
                    //dgv11.Rows[e.RowIndex].Cells[9].Value = modelosA.ToString("N0");
                    //dgv11.Rows[e.RowIndex].Cells[10].Value = modelosB.ToString("N0");
                    //dgv11.Rows[e.RowIndex].Cells[11].Value = profundidadA.ToString("N2");
                    //dgv11.Rows[e.RowIndex].Cells[12].Value = profundidadB.ToString("N2");
				asignacionModelos(11);
                  profundidad(11);
                    #endregion
                    break;
                case 11:
                    #region dgv12
                    //modelajeP = double.Parse(dgv12.Rows[e.RowIndex].Cells[4].Value.ToString());
                    ////////////////////////////
                    //modelosA = modelajeP * 80;
                    //modelosB = modelajeP * 20;
                    ////////////////////////////
                    //profundidadA = double.Parse(dgv12.Rows[e.RowIndex].Cells[7].Value.ToString());
                    //profundidadB = double.Parse(dgv12.Rows[e.RowIndex].Cells[8].Value.ToString());
                    ////////////////////////////
                    //dgv12.Rows[e.RowIndex].Cells[9].Value = modelosA.ToString("N0");
                    //dgv12.Rows[e.RowIndex].Cells[10].Value = modelosB.ToString("N0");
                    //dgv12.Rows[e.RowIndex].Cells[11].Value = profundidadA.ToString("N2");
                    //dgv12.Rows[e.RowIndex].Cells[12].Value = profundidadB.ToString("N2");
				asignacionModelos(12);
                  profundidad(12);
                    #endregion
                    break;
            }
            m_calcularRenglonTotal((dgv + 1));
        }

        private void dgvProf2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            m_REMOVE_TOTAL();
            if (dgv1.Rows.Count != 1)
            {
                for (int i = 1; i < calculos; i++)
                {
                    m_CALCULOS(i);
                }
            }
            {
                for (int i = 1; i < calculos; i++)
                {
                    m_CALCULOST(i);
                }
            }
        }

        public void m_REMOVE_TOTAL()//////////////////////////////
        {
            if (dgv1.Rows.Count != 1)
            {
                dgv1.Rows.RemoveAt(dgv1.Rows[dgv1.RowCount - 1].Index);
                dgv2.Rows.RemoveAt(dgv2.Rows[dgv2.RowCount - 1].Index);
                dgv3.Rows.RemoveAt(dgv3.Rows[dgv3.RowCount - 1].Index);
                dgv4.Rows.RemoveAt(dgv4.Rows[dgv4.RowCount - 1].Index);
                dgv5.Rows.RemoveAt(dgv5.Rows[dgv5.RowCount - 1].Index);
                dgv6.Rows.RemoveAt(dgv6.Rows[dgv6.RowCount - 1].Index);
                dgv7.Rows.RemoveAt(dgv7.Rows[dgv7.RowCount - 1].Index);
                dgv8.Rows.RemoveAt(dgv8.Rows[dgv8.RowCount - 1].Index);
                dgv9.Rows.RemoveAt(dgv9.Rows[dgv9.RowCount - 1].Index);
                dgv10.Rows.RemoveAt(dgv10.Rows[dgv10.RowCount - 1].Index);
                dgv11.Rows.RemoveAt(dgv11.Rows[dgv11.RowCount - 1].Index);
                dgv12.Rows.RemoveAt(dgv12.Rows[dgv11.RowCount - 1].Index);
            }
            else
            { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Desea borrar valores cedula actual y crear nueva", "Advertencia! ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                Cedula7 cn = new Cedula7();
                cn.Show(); this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void m_comprasxmes(int mes, int año)
        {
            for(int x=0;x<=dgv1.Rows.Count-2;x++)
            {
                query = "SELECT unidadesrecibo from cedula3 where nombre='"+Properties.Settings.Default.escenario+"' and mes="+mes.ToString()+" and anio="+año.ToString()+" "+querycargar[x];
                cmd = new MySqlCommand(query, Conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   compras[x]=double.Parse(reader["unidadesrecibo"].ToString());
                }
                reader.Close();
            }
        }

        #region metodos dropdown 
        private void m_drop_sucursales()
        {
            #region reiniciar valores
            lbsucursal.Text = "Sucursal";
            lbDivision.Text = "Division";
            lbdepartamento.Text = "Departamento";
            lbfamilia.Text = "Familia";
            lblinea.Text = "Linea";
            lbl1.Text = "L1";
            lbL2.Text = "L2";
            lbL3.Text = "L3";
            lbL4.Text = "L4";
            lbL5.Text = "L5";
            lbL6.Text = "L6";
            lbMarca.Text = "Marca";
            idsucursal = " ";
            idsucursal = " ";
            iddivision = " ";
            iddepto = " ";
            idfamilia = " ";
            idlinea = " ";
            idl1 = " ";
            idl2 = " ";
            idl3 = " ";
            idl4 = " ";
            idl5 = " ";
            idl6 = " ";
            marca = " ";
            #endregion
            ////@est@
            int sucS = -1;

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

                ////@est@
                if (seleccion_sucursal == Convert.ToInt32(reader["idsucursal"]))
                    sucS = i;

                i++;
            }
            reader.Close();
            /////////////////////////////////////////////////////////////////
            ////@est@

            if (i == 1)
                cbSucursales.Items.Clear();
            else
            {
                if (sucS != -1)
                {
                    cbSucursales.SelectedIndex = sucS;

                }
                else
                    cbSucursales.SelectedIndex = 0;

            }
            /////////////////////////////////////////////////////////////////

        }
        private void m_drop_division()
        {
            ////@est@
            int divS = -1;

            int i = 1;

            cbDivisiones.Items.Clear();
            cbDivisiones.Items.Add("Total");
            //@est@
            /*if (solocalzadoDropdown == " and iddivisiones=1")
            {
                i = 0;
            }
            else
            {
                i = 1;
                cbDivisiones.Items.Add("Total");
            }*/
            query = "SELECT descrip,iddivisiones from estdivisiones where visiblebp='1' " + solocalzadoDropdown;
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbDivisiones.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["iddivisiones"].ToString();

                ////@est@
                if (seleccion_division == Convert.ToInt32(reader["iddivisiones"]))
                    divS = i;

                i++;
            }
            reader.Close();
            /////////////////////////////////////////////////////////////////
            ////@est@

            if (i == 1)
                cbDivisiones.Items.Clear();
            else
            {
                if (divS != -1)
                {
                    cbDivisiones.SelectedIndex = divS;

                }
                else
                    cbDivisiones.SelectedIndex = 0;

            }
            /////////////////////////////////////////////////////////////////
        }
        private void m_drop_depto()
        {
            ////@est@
            int depS = -1;

            cbDepto.Items.Clear();
            cbDepto.Items.Add("Total");
            string[] texto = iddivision.Split('.');
            int i = 1;

            query = "SELECT descrip,iddepto from estdepartamento where visiblebp='1' " + division + "";
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbDepto.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["iddepto"].ToString();

                ////@est@
                if (seleccion_depto == Convert.ToInt32(reader["iddepto"]))
                    depS = i;

                i++;
            }
            reader.Close();
            /////////////////////////////////////////////////////////////////
            ////@est@

            if (i == 1)
                cbDepto.Items.Clear();
            else
            {
                if (depS != -1)
                {
                    cbDepto.SelectedIndex = depS;

                }
                else
                    cbDepto.SelectedIndex = 0;

            }
            /////////////////////////////////////////////////////////////////

        }
        private void m_drop_familia()
        {
            ////@est@
            int famS = -1;

            cbFamilia.Items.Clear();
            cbFamilia.Items.Add("Total");
            int i = 1;

            query = "SELECT descrip,idfamilia from estfamilia where visiblebp='1' " + division + " " + depto + "";
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbFamilia.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["idfamilia"].ToString();

                ////@est@
                if (seleccion_familia == Convert.ToInt32(reader["idfamilia"]))
                    famS = i;

                i++;
            }
            reader.Close();
            /////////////////////////////////////////////////////////////////
            ////@est@

            if (i == 1)
                cbFamilia.Items.Clear();
            else
            {
                if (famS != -1)
                {
                    cbFamilia.SelectedIndex = famS;

                }
                else
                    cbFamilia.SelectedIndex = 0;

            }
            /////////////////////////////////////////////////////////////////

        }
        private void m_drop_linea()
        {
            ////@est@
            int linS = -1;

            cbLinea.Items.Clear();
            cbLinea.Items.Add("Total");
            int i = 1;

            query = "SELECT descrip,idlinea from estlinea where visiblebp='1' " + division + " " + depto + "" + " " + fam;
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbLinea.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["idlinea"].ToString();

                ////@est@
                if (seleccion_linea == Convert.ToInt32(reader["idlinea"]))
                    linS = i;

                i++;
            }
            reader.Close();
            /////////////////////////////////////////////////////////////////
            ////@est@

            if (i == 1)
                cbLinea.Items.Clear();
            else
            {
                if (linS != -1)
                {
                    cbLinea.SelectedIndex = linS;

                }
                else
                    cbLinea.SelectedIndex = 0;

            }
            /////////////////////////////////////////////////////////////////

        }
        private void m_drop_l1()
        {
            ////@est@
            int l1S = -1;

            cbL1.Items.Clear();
            cbL1.Items.Add("Total");
            int i = 1;

            query = "SELECT descrip,idl1 from estl1 where visiblebp='1'" + division + " " + depto + " " + fam + " " + linea;
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbL1.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["idl1"].ToString();

                ////@est@
                if (seleccion_l1 == Convert.ToInt32(reader["idl1"]))
                    l1S = i;

                i++;
            }
            reader.Close();
            /////////////////////////////////////////////////////////////////
            ////@est@

            if (i == 1)
                cbL1.Items.Clear();
            else
            {
                if (l1S != -1)
                {
                    cbL1.SelectedIndex = l1S;

                }
                else
                    cbL1.SelectedIndex = 0;

            }
            /////////////////////////////////////////////////////////////////
        }
        private void m_drop_l2()
        {
            ////@est@
            int l2S = -1;
            cbL2.Items.Clear();
            cbL2.Items.Add("Total");
            int i = 1;

            query = "SELECT descrip,idl2 from estl2 where visiblebp='1' " + division + " " + depto + " " + fam + " " + linea + " " + subl1;
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbL2.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["idl2"].ToString();
                ////@est@
                if (seleccion_l2 == Convert.ToInt32(reader["idl2"]))
                    l2S = i;
                i++;
            }
            reader.Close();
            /////////////////////////////////////////////////////////////////
            ////@est@

            if (i == 1)
                cbL2.Items.Clear();
            else
            {
                if (l2S != -1)
                {
                    cbL2.SelectedIndex = l2S;

                }
                else
                    cbL2.SelectedIndex = 0;

            }
            /////////////////////////////////////////////////////////////////
        }
        private void m_drop_l3()
        {
            ////@est@
            int l3S = -1;

            cbL3.Items.Clear();
            cbL3.Items.Add("Total");
            int i = 1;

            query = "SELECT descrip,idl3 from estl3 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2;
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbL3.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["idl3"].ToString();
                ////@est@
                if (seleccion_l3 == Convert.ToInt32(reader["idl3"]))
                    l3S = i;
                i++;
            }
            reader.Close();
            /////////////////////////////////////////////////////////////////
            ////@est@

            if (i == 1)
                cbL3.Items.Clear();
            else
            {
                if (l3S != -1)
                {
                    cbL3.SelectedIndex = l3S;

                }
                else
                    cbL3.SelectedIndex = 0;

            }
            /////////////////////////////////////////////////////////////////
        }
        private void m_drop_l4()
        {
            ////@est@
            int l4S = -1;

            cbL4.Items.Clear();
            cbL4.Items.Add("Total");
            int i = 1;

            query = "SELECT descrip,idl4 from estl4 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2 + " " + subl3;
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbL4.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["idl4"].ToString();
                ////@est@
                if (seleccion_l4 == Convert.ToInt32(reader["idl4"]))
                    l4S = i;
                i++;
            }
            reader.Close();
            /////////////////////////////////////////////////////////////////
            ////@est@

            if (i == 1)
                cbL4.Items.Clear();
            else
            {
                if (l4S != -1)
                {
                    cbL4.SelectedIndex = l4S;

                }
                else
                    cbL4.SelectedIndex = 0;

            }
            /////////////////////////////////////////////////////////////////
        }
        private void m_drop_l5()
        {
            ////@est@
            int l5S = -1;

            cbL5.Items.Clear();
            cbL5.Items.Add("Total");
            int i = 1;

            query = "SELECT descrip,idl5 from estl5 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2 + " " + subl3 + " " + subl4;
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbL5.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["idl5"].ToString();
                ////@est@
                if (seleccion_l5 == Convert.ToInt32(reader["idl5"]))
                    l5S = i;
                i++;
            }
            reader.Close();
            /////////////////////////////////////////////////////////////////
            ////@est@

            if (i == 1)
                cbL5.Items.Clear();
            else
            {
                if (l5S != -1)
                {
                    cbL5.SelectedIndex = l5S;

                }
                else
                    cbL5.SelectedIndex = 0;

            }
            /////////////////////////////////////////////////////////////////
        }
        private void m_drop_l6()
        {
            ////@est@
            int l6S = -1;

            cbL6.Items.Clear();
            cbL6.Items.Add("Total");
            int i = 1;

            query = "SELECT descrip,idl6 from estl6 where visiblebp='1'" + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2 + " " + subl3 + " " + subl4 + " " + subl5;
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbL6.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["idl6"].ToString();
                ////@est@
                if (seleccion_l6 == Convert.ToInt32(reader["idl6"]))
                    l6S = i;
                i++;
            }
            reader.Close();
            /////////////////////////////////////////////////////////////////
            ////@est@

            if (i == 1)
                cbL6.Items.Clear();
            else
            {
                if (l6S != -1)
                {
                    cbL6.SelectedIndex = l6S;

                }
                else
                    cbL6.SelectedIndex = 0;

            }
            /////////////////////////////////////////////////////////////////
        }
        private void m_drop_marca()
        {
            ////@est@
            int marcaS = -1;

            cbMarca.Items.Clear();
            cbMarca.Items.Add("Total");
            int i = 1;

            //query = "SELECT descrip,marca from marca where visiblebp=1";
            query = "SELECT distinct m.descrip,m.marca from marca as m inner join estarticulo as v on v.marca = m.marca where visiblebp =1 " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6varios;
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbMarca.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["marca"].ToString();
                ////@est@
                if (seleccion_marca == reader["marca"].ToString())
                    marcaS = i;

                i++;
            }
            reader.Close();
            /////////////////////////////////////////////////////////////////
            ////@est@

            if (i == 1)
                cbMarca.Items.Clear();
            else
            {
                if (marcaS != -1)
                {
                    cbMarca.SelectedIndex = marcaS;

                }
                else
                    cbMarca.SelectedIndex = 0;

            }
            /////////////////////////////////////////////////////////////////

        }
        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if(solototal==false)
            { 
             m_DIASMESESANOS_guardar(CED1_fechaI, CED1_fechaF);
            } 
            else
            {
                m_DIASMESESANOS_guardarT(CED1_fechaI, CED1_fechaF);
            }
            MessageBox.Show("Guardado");
            Cursor.Current = Cursors.Default;

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
            año++;
            bool comprobar = true;
            for (int x = 0; x <= dgv1.Rows.Count-2; x++)
            {
                string s = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and anio=" + año + " and mes=" + mes + " " + querycargar[x];
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
                    insertar(año, mes, i, (x+1));
                }
                else
                {
                    update(año, mes, i, (x + 1));
                }
            }
            return true;
        }
        public void insertar(int año, int mes, int grid, int renglon)
        {
            double c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15;
            año++;
            switch (grid)
            {
                case 1:
                    #region insertar dgv1
                    c1 = double.Parse(dgv1.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv1.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv1.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv1.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv1.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv1.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv1.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv1.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv1.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv1.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv1.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgv1.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgv1.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgv1.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgv1.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    string qinsert = "insert into cedula8 (nombre,ModelosvendidosH,PorcentajeMH,ParesvendidosH,capacidad,ModeloscompraP,PorcentajeMP,paresCompraP,Parescompra80,Parescompra20,modelosCompraA,modelosCompraB,profundidadA,profundidadB,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + c13.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[(renglon - 1)] + ")";
                    cmd = new MySqlCommand(qinsert ,Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 2:
                    #region insertar dgv2
                    c1 = double.Parse(dgv2.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv2.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv2.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv2.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv2.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv2.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv2.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv2.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv2.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv2.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgv2.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgv2.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgv2.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgv2.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                     qinsert = "insert into cedula8 (nombre,ModelosvendidosH,PorcentajeMH,ParesvendidosH,capacidad,ModeloscompraP,PorcentajeMP,paresCompraP,Parescompra80,Parescompra20,modelosCompraA,modelosCompraB,profundidadA,profundidadB,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + c13.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[(renglon - 1)] + ")";
                    cmd = new MySqlCommand(qinsert, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 3:
                    #region insertar dgv3
                    c1 = double.Parse(dgv3.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv3.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv3.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv3.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv3.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv3.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv3.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv3.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv3.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv3.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv3.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgv3.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgv3.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgv3.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgv3.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                     qinsert = "insert into cedula8 (nombre,ModelosvendidosH,PorcentajeMH,ParesvendidosH,capacidad,ModeloscompraP,PorcentajeMP,paresCompraP,Parescompra80,Parescompra20,modelosCompraA,modelosCompraB,profundidadA,profundidadB,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + c13.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[(renglon - 1)] + ")";
                    cmd = new MySqlCommand(qinsert, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 4:
                    #region insertar dgv4
                    c1 = double.Parse(dgv4.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv4.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv4.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv4.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv4.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv4.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv4.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv4.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv4.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv4.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv4.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgv4.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgv4.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgv4.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgv4.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qinsert = "insert into cedula8 (nombre,ModelosvendidosH,PorcentajeMH,ParesvendidosH,capacidad,ModeloscompraP,PorcentajeMP,paresCompraP,Parescompra80,Parescompra20,modelosCompraA,modelosCompraB,profundidadA,profundidadB,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + c13.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[(renglon - 1)] + ")";
                    cmd = new MySqlCommand(qinsert, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 5:
                    #region insertar dgv5
                    c1 = double.Parse(dgv5.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv5.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv5.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv5.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv5.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv5.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv5.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv5.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv5.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv5.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv5.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgv5.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgv5.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgv5.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgv5.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qinsert = "insert into cedula8 (nombre,ModelosvendidosH,PorcentajeMH,ParesvendidosH,capacidad,ModeloscompraP,PorcentajeMP,paresCompraP,Parescompra80,Parescompra20,modelosCompraA,modelosCompraB,profundidadA,profundidadB,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + c13.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[(renglon - 1)] + ")";
                    cmd = new MySqlCommand(qinsert, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 6:
                    #region insertar dgv6
                    c1 = double.Parse(dgv6.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv6.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv6.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv6.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv6.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv6.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv6.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv6.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv6.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv6.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv6.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgv6.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgv6.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgv6.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgv6.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qinsert = "insert into cedula8 (nombre,ModelosvendidosH,PorcentajeMH,ParesvendidosH,capacidad,ModeloscompraP,PorcentajeMP,paresCompraP,Parescompra80,Parescompra20,modelosCompraA,modelosCompraB,profundidadA,profundidadB,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + c13.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[(renglon - 1)] + ")";
                    cmd = new MySqlCommand(qinsert, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 7:
                    #region insertar dgv7
                    c1 = double.Parse(dgv7.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv7.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv7.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv7.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv7.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv7.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv7.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv7.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv7.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv7.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv7.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgv7.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgv7.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgv7.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgv7.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qinsert = "insert into cedula8 (nombre,ModelosvendidosH,PorcentajeMH,ParesvendidosH,capacidad,ModeloscompraP,PorcentajeMP,paresCompraP,Parescompra80,Parescompra20,modelosCompraA,modelosCompraB,profundidadA,profundidadB,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + c13.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[(renglon - 1)] + ")";
                    cmd = new MySqlCommand(qinsert, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 8:
                    #region insertar dgv8
                    c1 = double.Parse(dgv8.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv8.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv8.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv8.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv8.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv8.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv8.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv8.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv8.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv8.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv8.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgv8.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgv8.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgv8.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgv8.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qinsert = "insert into cedula8 (nombre,ModelosvendidosH,PorcentajeMH,ParesvendidosH,capacidad,ModeloscompraP,PorcentajeMP,paresCompraP,Parescompra80,Parescompra20,modelosCompraA,modelosCompraB,profundidadA,profundidadB,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + c13.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[(renglon - 1)] + ")";
                    cmd = new MySqlCommand(qinsert, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 9:
                    #region insertar dgv9
                    c1 = double.Parse(dgv9.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv9.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv9.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv9.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv9.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv9.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv9.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv9.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv9.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv9.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv9.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgv9.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgv9.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgv9.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgv9.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qinsert = "insert into cedula8 (nombre,ModelosvendidosH,PorcentajeMH,ParesvendidosH,capacidad,ModeloscompraP,PorcentajeMP,paresCompraP,Parescompra80,Parescompra20,modelosCompraA,modelosCompraB,profundidadA,profundidadB,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + c13.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[(renglon - 1)] + ")";
                    cmd = new MySqlCommand(qinsert, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 10:
                    #region insertar dgv10
                    c1 = double.Parse(dgv10.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv10.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv10.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv10.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv10.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv10.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv10.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv10.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv10.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv10.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv10.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgv10.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgv10.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgv10.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgv10.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qinsert = "insert into cedula8 (nombre,ModelosvendidosH,PorcentajeMH,ParesvendidosH,capacidad,ModeloscompraP,PorcentajeMP,paresCompraP,Parescompra80,Parescompra20,modelosCompraA,modelosCompraB,profundidadA,profundidadB,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + c13.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[(renglon - 1)] + ")";
                    cmd = new MySqlCommand(qinsert, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 11:
                    #region insertar dgv11
                    c1 = double.Parse(dgv11.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv11.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv11.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv11.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv11.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv11.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv11.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv11.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv11.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv11.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv11.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgv11.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgv11.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgv11.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgv11.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qinsert = "insert into cedula8 (nombre,ModelosvendidosH,PorcentajeMH,ParesvendidosH,capacidad,ModeloscompraP,PorcentajeMP,paresCompraP,Parescompra80,Parescompra20,modelosCompraA,modelosCompraB,profundidadA,profundidadB,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + c13.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[(renglon - 1)] + ")";
                    cmd = new MySqlCommand(qinsert, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 12:
                    #region insertar dgv12
                    c1 = double.Parse(dgv12.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv12.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv12.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv12.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv12.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv12.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv12.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv12.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv12.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv12.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv12.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgv12.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    c13 = double.Parse(dgv12.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgv12.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgv12.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qinsert = "insert into cedula8 (nombre,ModelosvendidosH,PorcentajeMH,ParesvendidosH,capacidad,ModeloscompraP,PorcentajeMP,paresCompraP,Parescompra80,Parescompra20,modelosCompraA,modelosCompraB,profundidadA,profundidadB,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + c13.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[(renglon - 1)] + ")";
                    cmd = new MySqlCommand(qinsert, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
            }
        }
        public void update(int año, int mes, int grid, int renglon)
        {
            double c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15;
            año++;
            switch (grid)
            {
                case 1:
                    #region insertar dgv1
                    c1 = double.Parse(dgv1.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv1.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv1.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv1.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv1.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv1.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv1.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv1.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv1.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv1.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv1.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    //c12 = double.Parse(dgv1.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgvProf1.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgvProf1.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgvProf1.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                     string qupdate = "update cedula8 set ModelosvendidosH=" + c1.ToString() + ",PorcentajeMH=" + c2.ToString() + ",ModeloscompraP=" + c3.ToString() + ",PorcentajeMP=" + c4.ToString() + ",paresCompraP=" + c5.ToString() + ",Parescompra80=" + c6.ToString() + ",Parescompra20=" + c7.ToString() + ",modeloscompraA=" + c8.ToString() + ",modeloscompraB=" + c9.ToString() + ",profundidadA="+c10.ToString()+",profundidadB="+c11.ToString()+" where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[(renglon-1)];
                    cmd = new MySqlCommand(qupdate, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 2:
                    #region insertar dgv2
                    c1 = double.Parse(dgv2.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv2.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv2.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv2.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv2.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv2.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv2.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv2.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv2.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv2.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    //c12 = double.Parse(dgv2.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgvProf1.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgvProf1.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgvProf1.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                     qupdate = "update cedula8 set ModelosvendidosH=" + c1.ToString() + ",PorcentajeMH=" + c2.ToString() + ",ModeloscompraP=" + c3.ToString() + ",PorcentajeMP=" + c4.ToString() + ",paresCompraP=" + c5.ToString() + ",Parescompra80=" + c6.ToString() + ",Parescompra20=" + c7.ToString() + ",modeloscompraA=" + c8.ToString() + ",modeloscompraB=" + c9.ToString() + ",profundidadA=" + c10.ToString() + ",profundidadB=" + c11.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[(renglon - 1)];
                    cmd = new MySqlCommand(qupdate, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 3:
                    #region insertar dgv3
                    c1 = double.Parse(dgv3.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv3.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv3.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv3.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv3.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv3.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv3.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv3.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv3.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv3.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv3.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    //c12 = double.Parse(dgv3.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgvProf1.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgvProf1.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgvProf1.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qupdate = "update cedula8 set ModelosvendidosH=" + c1.ToString() + ",PorcentajeMH=" + c2.ToString() + ",ModeloscompraP=" + c3.ToString() + ",PorcentajeMP=" + c4.ToString() + ",paresCompraP=" + c5.ToString() + ",Parescompra80=" + c6.ToString() + ",Parescompra20=" + c7.ToString() + ",modeloscompraA=" + c8.ToString() + ",modeloscompraB=" + c9.ToString() + ",profundidadA=" + c10.ToString() + ",profundidadB=" + c11.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[(renglon - 1)];
                    cmd = new MySqlCommand(qupdate, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 4:
                    #region insertar dgv4
                    c1 = double.Parse(dgv4.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv4.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv4.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv4.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv4.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv4.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv4.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv4.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv4.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv4.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv4.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    //c12 = double.Parse(dgv4.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgvProf1.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgvProf1.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgvProf1.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qupdate = "update cedula8 set ModelosvendidosH=" + c1.ToString() + ",PorcentajeMH=" + c2.ToString() + ",ModeloscompraP=" + c3.ToString() + ",PorcentajeMP=" + c4.ToString() + ",paresCompraP=" + c5.ToString() + ",Parescompra80=" + c6.ToString() + ",Parescompra20=" + c7.ToString() + ",modeloscompraA=" + c8.ToString() + ",modeloscompraB=" + c9.ToString() + ",profundidadA=" + c10.ToString() + ",profundidadB=" + c11.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[(renglon - 1)];
                    cmd = new MySqlCommand(qupdate, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 5:
                    #region insertar dgv5
                    c1 = double.Parse(dgv5.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv5.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv5.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv5.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv5.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv5.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv5.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv5.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv5.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv5.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv5.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    //c12 = double.Parse(dgv5.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgvProf1.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgvProf1.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgvProf1.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qupdate = "update cedula8 set ModelosvendidosH=" + c1.ToString() + ",PorcentajeMH=" + c2.ToString() + ",ModeloscompraP=" + c3.ToString() + ",PorcentajeMP=" + c4.ToString() + ",paresCompraP=" + c5.ToString() + ",Parescompra80=" + c6.ToString() + ",Parescompra20=" + c7.ToString() + ",modeloscompraA=" + c8.ToString() + ",modeloscompraB=" + c9.ToString() + ",profundidadA=" + c10.ToString() + ",profundidadB=" + c11.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[(renglon - 1)];
                    cmd = new MySqlCommand(qupdate, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 6:
                    #region insertar dgv6
                    c1 = double.Parse(dgv6.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv6.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv6.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv6.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv6.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv6.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv6.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv6.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv6.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv6.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv6.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    //c12 = double.Parse(dgv6.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgvProf1.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgvProf1.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgvProf1.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qupdate = "update cedula8 set ModelosvendidosH=" + c1.ToString() + ",PorcentajeMH=" + c2.ToString() + ",ModeloscompraP=" + c3.ToString() + ",PorcentajeMP=" + c4.ToString() + ",paresCompraP=" + c5.ToString() + ",Parescompra80=" + c6.ToString() + ",Parescompra20=" + c7.ToString() + ",modeloscompraA=" + c8.ToString() + ",modeloscompraB=" + c9.ToString() + ",profundidadA=" + c10.ToString() + ",profundidadB=" + c11.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[(renglon - 1)];
                    cmd = new MySqlCommand(qupdate, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 7:
                    #region insertar dgv7
                    c1 = double.Parse(dgv7.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv7.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv7.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv7.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv7.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv7.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv7.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv7.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv7.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv7.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv7.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    //c12 = double.Parse(dgv7.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgvProf1.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgvProf1.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgvProf1.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qupdate = "update cedula8 set ModelosvendidosH=" + c1.ToString() + ",PorcentajeMH=" + c2.ToString() + ",ModeloscompraP=" + c3.ToString() + ",PorcentajeMP=" + c4.ToString() + ",paresCompraP=" + c5.ToString() + ",Parescompra80=" + c6.ToString() + ",Parescompra20=" + c7.ToString() + ",modeloscompraA=" + c8.ToString() + ",modeloscompraB=" + c9.ToString() + ",profundidadA=" + c10.ToString() + ",profundidadB=" + c11.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[(renglon - 1)];
                    cmd = new MySqlCommand(qupdate, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 8:
                    #region insertar dgv8
                    c1 = double.Parse(dgv8.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv8.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv8.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv8.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv8.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv8.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv8.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv8.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv8.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv8.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv8.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    //c12 = double.Parse(dgv8.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgvProf1.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgvProf1.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgvProf1.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qupdate = "update cedula8 set ModelosvendidosH=" + c1.ToString() + ",PorcentajeMH=" + c2.ToString() + ",ModeloscompraP=" + c3.ToString() + ",PorcentajeMP=" + c4.ToString() + ",paresCompraP=" + c5.ToString() + ",Parescompra80=" + c6.ToString() + ",Parescompra20=" + c7.ToString() + ",modeloscompraA=" + c8.ToString() + ",modeloscompraB=" + c9.ToString() + ",profundidadA=" + c10.ToString() + ",profundidadB=" + c11.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[(renglon - 1)];
                    cmd = new MySqlCommand(qupdate, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 9:
                    #region insertar dgv9
                    c1 = double.Parse(dgv9.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv9.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv9.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv9.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv9.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv9.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv9.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv9.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv9.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv9.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv9.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    //c12 = double.Parse(dgv9.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgvProf1.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgvProf1.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgvProf1.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qupdate = "update cedula8 set ModelosvendidosH=" + c1.ToString() + ",PorcentajeMH=" + c2.ToString() + ",ModeloscompraP=" + c3.ToString() + ",PorcentajeMP=" + c4.ToString() + ",paresCompraP=" + c5.ToString() + ",Parescompra80=" + c6.ToString() + ",Parescompra20=" + c7.ToString() + ",modeloscompraA=" + c8.ToString() + ",modeloscompraB=" + c9.ToString() + ",profundidadA=" + c10.ToString() + ",profundidadB=" + c11.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[(renglon - 1)];
                    cmd = new MySqlCommand(qupdate, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 10:
                    #region insertar dgv10
                    c1 = double.Parse(dgv10.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv10.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv10.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv10.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv10.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv10.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv10.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv10.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv10.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv10.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv10.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    //c12 = double.Parse(dgv10.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgvProf1.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgvProf1.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgvProf1.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qupdate = "update cedula8 set ModelosvendidosH=" + c1.ToString() + ",PorcentajeMH=" + c2.ToString() + ",ModeloscompraP=" + c3.ToString() + ",PorcentajeMP=" + c4.ToString() + ",paresCompraP=" + c5.ToString() + ",Parescompra80=" + c6.ToString() + ",Parescompra20=" + c7.ToString() + ",modeloscompraA=" + c8.ToString() + ",modeloscompraB=" + c9.ToString() + ",profundidadA=" + c10.ToString() + ",profundidadB=" + c11.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[(renglon - 1)];
                    cmd = new MySqlCommand(qupdate, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 11:
                    #region insertar dgv11
                    c1 = double.Parse(dgv11.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv11.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv11.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv11.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv11.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv11.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv11.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv11.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv11.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv11.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv11.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    //c12 = double.Parse(dgv11.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgvProf1.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgvProf1.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgvProf1.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qupdate = "update cedula8 set ModelosvendidosH=" + c1.ToString() + ",PorcentajeMH=" + c2.ToString() + ",ModeloscompraP=" + c3.ToString() + ",PorcentajeMP=" + c4.ToString() + ",paresCompraP=" + c5.ToString() + ",Parescompra80=" + c6.ToString() + ",Parescompra20=" + c7.ToString() + ",modeloscompraA=" + c8.ToString() + ",modeloscompraB=" + c9.ToString() + ",profundidadA=" + c10.ToString() + ",profundidadB=" + c11.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[(renglon - 1)];
                    cmd = new MySqlCommand(qupdate, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 12:
                    #region insertar dgv12
                    c1 = double.Parse(dgv12.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv12.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv12.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv12.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv12.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv12.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv12.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv12.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv12.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv12.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv12.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    //c12 = double.Parse(dgv12.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgvProf1.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgvProf1.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgvProf1.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qupdate = "update cedula8 set ModelosvendidosH=" + c1.ToString() + ",PorcentajeMH=" + c2.ToString() + ",ModeloscompraP=" + c3.ToString() + ",PorcentajeMP=" + c4.ToString() + ",paresCompraP=" + c5.ToString() + ",Parescompra80=" + c6.ToString() + ",Parescompra20=" + c7.ToString() + ",modeloscompraA=" + c8.ToString() + ",modeloscompraB=" + c9.ToString() + ",profundidadA=" + c10.ToString() + ",profundidadB=" + c11.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[(renglon - 1)];
                    cmd = new MySqlCommand(qupdate, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
            }
        }
        private bool comprobarCargar(int año, int mes, int i)
        {
            bool comprobar = true;
            string ql = "";
            año++;
            if (solototal != true)
            {
                ql = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and anio=" + año + " and mes=" + mes + " " + querycargar[0];
            }
            else
            {
                ql = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and anio=" + año + " and mes=" + mes + " and ZapateriasTorreon=1";
            }
            cmd = new MySqlCommand(ql, Conn);
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
            int x = 1;
            int i = 0;
            año++;
            double c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15;
            switch (g)
            {
                case 1:
                    #region cargar dgv1
                    for ( ; x <= dgv1.Rows.Count - 1; x++)
                    {
                        string qload = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[i];
                        cmd = new MySqlCommand(qload, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["ModelosvendidosH"].ToString());
                            c2 = double.Parse(reader["PorcentajeMH"].ToString());
                            c3 = double.Parse(reader["ParesvendidosH"].ToString());
                            c4 = double.Parse(reader["ModeloscompraP"].ToString());
                            c5 = double.Parse(reader["PorcentajeMP"].ToString());
                            c6 = double.Parse(reader["paresCompraP"].ToString());
                            c7 = double.Parse(reader["Parescompra80"].ToString());
                            c8 = double.Parse(reader["Parescompra20"].ToString());
                            c9 = double.Parse(reader["modeloscompraA"].ToString());
                            c10 = double.Parse(reader["modeloscompraB"].ToString());
                            c11 = double.Parse(reader["profundidadA"].ToString());
                            c12 = double.Parse(reader["profundidadB"].ToString());
                            c13 = double.Parse(reader["capacidad"].ToString());
                            
                            dgv1.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv1.Rows[x].Cells[2].Value = c2.ToString("N2");
                            dgv1.Rows[x].Cells[3].Value = c3.ToString("N2");
                            dgv1.Rows[x].Cells[6].Value = c4.ToString("N0");
                            dgv1.Rows[x].Cells[7].Value = c5.ToString("N0");
                            dgv1.Rows[x].Cells[8].Value = c6.ToString("N2");
                            dgv1.Rows[x].Cells[9].Value = c7.ToString("N0");
                            dgv1.Rows[x].Cells[10].Value = c8.ToString("N2");
                            dgv1.Rows[x].Cells[11].Value = c9.ToString("N2");
                            dgv1.Rows[x].Cells[12].Value = c10.ToString("N2");
                            dgv1.Rows[x].Cells[13].Value = c11.ToString("N2");
                            dgv1.Rows[x].Cells[14].Value = c12.ToString("N2");
                            dgv1.Rows[x].Cells[5].Value=c13.ToString("N0");
                        }
                        reader.Close();
                        i++;
                    }
                    #endregion
                    break;
                case 2:
                    #region cargar dgv1
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        string qload = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[i];
                        cmd = new MySqlCommand(qload, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["ModelosvendidosH"].ToString());
                            c2 = double.Parse(reader["PorcentajeMH"].ToString());
                            c3 = double.Parse(reader["ParesvendidosH"].ToString());
                            c4 = double.Parse(reader["ModeloscompraP"].ToString());
                            c5 = double.Parse(reader["PorcentajeMP"].ToString());
                            c6 = double.Parse(reader["paresCompraP"].ToString());
                            c7 = double.Parse(reader["Parescompra80"].ToString());
                            c8 = double.Parse(reader["Parescompra20"].ToString());
                            c9 = double.Parse(reader["modeloscompraA"].ToString());
                            c10 = double.Parse(reader["modeloscompraB"].ToString());
                            c11 = double.Parse(reader["profundidadA"].ToString());
                            c12 = double.Parse(reader["profundidadB"].ToString());
                            c13 = double.Parse(reader["capacidad"].ToString());

                            dgv2.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv2.Rows[x].Cells[2].Value = c2.ToString("N2");
                            dgv2.Rows[x].Cells[3].Value = c3.ToString("N2");
                            dgv2.Rows[x].Cells[6].Value = c4.ToString("N0");
                            dgv2.Rows[x].Cells[7].Value = c5.ToString("N0");
                            dgv2.Rows[x].Cells[8].Value = c6.ToString("N2");
                            dgv2.Rows[x].Cells[9].Value = c7.ToString("N0");
                            dgv2.Rows[x].Cells[10].Value = c8.ToString("N2");
                            dgv2.Rows[x].Cells[11].Value = c9.ToString("N2");
                            dgv2.Rows[x].Cells[12].Value = c10.ToString("N2");
                            dgv2.Rows[x].Cells[13].Value = c11.ToString("N2");
                            dgv2.Rows[x].Cells[14].Value = c12.ToString("N2");
                            dgv2.Rows[x].Cells[5].Value = c13.ToString("N0");
                        }
                        reader.Close();
                        i++;
                    }
                    #endregion
                    break;
                case 3:
                    #region cargar dgv1
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        string qload = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[i];
                        cmd = new MySqlCommand(qload, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["ModelosvendidosH"].ToString());
                            c2 = double.Parse(reader["PorcentajeMH"].ToString());
                            c3 = double.Parse(reader["ParesvendidosH"].ToString());
                            c4 = double.Parse(reader["ModeloscompraP"].ToString());
                            c5 = double.Parse(reader["PorcentajeMP"].ToString());
                            c6 = double.Parse(reader["paresCompraP"].ToString());
                            c7 = double.Parse(reader["Parescompra80"].ToString());
                            c8 = double.Parse(reader["Parescompra20"].ToString());
                            c9 = double.Parse(reader["modeloscompraA"].ToString());
                            c10 = double.Parse(reader["modeloscompraB"].ToString());
                            c11 = double.Parse(reader["profundidadA"].ToString());
                            c12 = double.Parse(reader["profundidadB"].ToString());
                            c13 = double.Parse(reader["capacidad"].ToString());

                            dgv3.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv3.Rows[x].Cells[2].Value = c2.ToString("N2");
                            dgv3.Rows[x].Cells[3].Value = c3.ToString("N2");
                            dgv3.Rows[x].Cells[6].Value = c4.ToString("N0");
                            dgv3.Rows[x].Cells[7].Value = c5.ToString("N0");
                            dgv3.Rows[x].Cells[8].Value = c6.ToString("N2");
                            dgv3.Rows[x].Cells[9].Value = c7.ToString("N0");
                            dgv3.Rows[x].Cells[10].Value = c8.ToString("N2");
                            dgv3.Rows[x].Cells[11].Value = c9.ToString("N2");
                            dgv3.Rows[x].Cells[12].Value = c10.ToString("N2");
                            dgv3.Rows[x].Cells[13].Value = c11.ToString("N2");
                            dgv3.Rows[x].Cells[14].Value = c12.ToString("N2");
                            dgv3.Rows[x].Cells[5].Value = c13.ToString("N0");
                        }
                        reader.Close();
                        i++;
                    }
                    #endregion
                    break;
                case 4:
                    #region cargar dgv4
                    for (; x <= dgv4.Rows.Count - 1; x++)
                    {
                        string qload = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[i];
                        cmd = new MySqlCommand(qload, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["ModelosvendidosH"].ToString());
                            c2 = double.Parse(reader["PorcentajeMH"].ToString());
                            c3 = double.Parse(reader["ParesvendidosH"].ToString());
                            c4 = double.Parse(reader["ModeloscompraP"].ToString());
                            c5 = double.Parse(reader["PorcentajeMP"].ToString());
                            c6 = double.Parse(reader["paresCompraP"].ToString());
                            c7 = double.Parse(reader["Parescompra80"].ToString());
                            c8 = double.Parse(reader["Parescompra20"].ToString());
                            c9 = double.Parse(reader["modeloscompraA"].ToString());
                            c10 = double.Parse(reader["modeloscompraB"].ToString());
                            c11 = double.Parse(reader["profundidadA"].ToString());
                            c12 = double.Parse(reader["profundidadB"].ToString());
                            c13 = double.Parse(reader["capacidad"].ToString());

                            dgv4.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv4.Rows[x].Cells[2].Value = c2.ToString("N2");
                            dgv4.Rows[x].Cells[3].Value = c3.ToString("N2");
                            dgv4.Rows[x].Cells[6].Value = c4.ToString("N0");
                            dgv4.Rows[x].Cells[7].Value = c5.ToString("N0");
                            dgv4.Rows[x].Cells[8].Value = c6.ToString("N2");
                            dgv4.Rows[x].Cells[9].Value = c7.ToString("N0");
                            dgv4.Rows[x].Cells[10].Value = c8.ToString("N2");
                            dgv4.Rows[x].Cells[11].Value = c9.ToString("N2");
                            dgv4.Rows[x].Cells[12].Value = c10.ToString("N2");
                            dgv4.Rows[x].Cells[13].Value = c11.ToString("N2");
                            dgv4.Rows[x].Cells[14].Value = c12.ToString("N2");
                            dgv4.Rows[x].Cells[5].Value = c13.ToString("N0");
                        }
                        reader.Close();
                        i++;
                    }
                    #endregion
                    break;
                case 5:
                    #region cargar dgv5
                    for (; x <= dgv5.Rows.Count - 1; x++)
                    {
                        string qload = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[i];
                        cmd = new MySqlCommand(qload, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["ModelosvendidosH"].ToString());
                            c2 = double.Parse(reader["PorcentajeMH"].ToString());
                            c3 = double.Parse(reader["ParesvendidosH"].ToString());
                            c4 = double.Parse(reader["ModeloscompraP"].ToString());
                            c5 = double.Parse(reader["PorcentajeMP"].ToString());
                            c6 = double.Parse(reader["paresCompraP"].ToString());
                            c7 = double.Parse(reader["Parescompra80"].ToString());
                            c8 = double.Parse(reader["Parescompra20"].ToString());
                            c9 = double.Parse(reader["modeloscompraA"].ToString());
                            c10 = double.Parse(reader["modeloscompraB"].ToString());
                            c11 = double.Parse(reader["profundidadA"].ToString());
                            c12 = double.Parse(reader["profundidadB"].ToString());
                            c13 = double.Parse(reader["capacidad"].ToString());

                            dgv5.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv5.Rows[x].Cells[2].Value = c2.ToString("N2");
                            dgv5.Rows[x].Cells[3].Value = c3.ToString("N2");
                            dgv5.Rows[x].Cells[6].Value = c4.ToString("N0");
                            dgv5.Rows[x].Cells[7].Value = c5.ToString("N0");
                            dgv5.Rows[x].Cells[8].Value = c6.ToString("N2");
                            dgv5.Rows[x].Cells[9].Value = c7.ToString("N0");
                            dgv5.Rows[x].Cells[10].Value = c8.ToString("N2");
                            dgv5.Rows[x].Cells[11].Value = c9.ToString("N2");
                            dgv5.Rows[x].Cells[12].Value = c10.ToString("N2");
                            dgv5.Rows[x].Cells[13].Value = c11.ToString("N2");
                            dgv5.Rows[x].Cells[14].Value = c12.ToString("N2");
                            dgv5.Rows[x].Cells[5].Value = c13.ToString("N0");
                        }
                        reader.Close();
                        i++;
                    }
                    #endregion
                    break;
                case 6:
                    #region cargar dgv6
                    for (; x <= dgv6.Rows.Count - 1; x++)
                    {
                        string qload = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[i];
                        cmd = new MySqlCommand(qload, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["ModelosvendidosH"].ToString());
                            c2 = double.Parse(reader["PorcentajeMH"].ToString());
                            c3 = double.Parse(reader["ParesvendidosH"].ToString());
                            c4 = double.Parse(reader["ModeloscompraP"].ToString());
                            c5 = double.Parse(reader["PorcentajeMP"].ToString());
                            c6 = double.Parse(reader["paresCompraP"].ToString());
                            c7 = double.Parse(reader["Parescompra80"].ToString());
                            c8 = double.Parse(reader["Parescompra20"].ToString());
                            c9 = double.Parse(reader["modeloscompraA"].ToString());
                            c10 = double.Parse(reader["modeloscompraB"].ToString());
                            c11 = double.Parse(reader["profundidadA"].ToString());
                            c12 = double.Parse(reader["profundidadB"].ToString());
                            c13 = double.Parse(reader["capacidad"].ToString());

                            dgv6.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv6.Rows[x].Cells[2].Value = c2.ToString("N2");
                            dgv6.Rows[x].Cells[3].Value = c3.ToString("N2");
                            dgv6.Rows[x].Cells[6].Value = c4.ToString("N0");
                            dgv6.Rows[x].Cells[7].Value = c5.ToString("N0");
                            dgv6.Rows[x].Cells[8].Value = c6.ToString("N2");
                            dgv6.Rows[x].Cells[9].Value = c7.ToString("N0");
                            dgv6.Rows[x].Cells[10].Value = c8.ToString("N2");
                            dgv6.Rows[x].Cells[11].Value = c9.ToString("N2");
                            dgv6.Rows[x].Cells[12].Value = c10.ToString("N2");
                            dgv6.Rows[x].Cells[13].Value = c11.ToString("N2");
                            dgv6.Rows[x].Cells[14].Value = c12.ToString("N2");
                            dgv6.Rows[x].Cells[5].Value = c13.ToString("N0");
                        }
                        reader.Close();
                        i++;
                    }
                    #endregion
                    break;
                case 7:
                    #region cargar dgv7
                    for (; x <= dgv7.Rows.Count - 1; x++)
                    {
                        string qload = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[i];
                        cmd = new MySqlCommand(qload, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["ModelosvendidosH"].ToString());
                            c2 = double.Parse(reader["PorcentajeMH"].ToString());
                            c3 = double.Parse(reader["ParesvendidosH"].ToString());
                            c4 = double.Parse(reader["ModeloscompraP"].ToString());
                            c5 = double.Parse(reader["PorcentajeMP"].ToString());
                            c6 = double.Parse(reader["paresCompraP"].ToString());
                            c7 = double.Parse(reader["Parescompra80"].ToString());
                            c8 = double.Parse(reader["Parescompra20"].ToString());
                            c9 = double.Parse(reader["modeloscompraA"].ToString());
                            c10 = double.Parse(reader["modeloscompraB"].ToString());
                            c11 = double.Parse(reader["profundidadA"].ToString());
                            c12 = double.Parse(reader["profundidadB"].ToString());
                            c13 = double.Parse(reader["capacidad"].ToString());

                            dgv7.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv7.Rows[x].Cells[2].Value = c2.ToString("N2");
                            dgv7.Rows[x].Cells[3].Value = c3.ToString("N2");
                            dgv7.Rows[x].Cells[6].Value = c4.ToString("N0");
                            dgv7.Rows[x].Cells[7].Value = c5.ToString("N0");
                            dgv7.Rows[x].Cells[8].Value = c6.ToString("N2");
                            dgv7.Rows[x].Cells[9].Value = c7.ToString("N0");
                            dgv7.Rows[x].Cells[10].Value = c8.ToString("N2");
                            dgv7.Rows[x].Cells[11].Value = c9.ToString("N2");
                            dgv7.Rows[x].Cells[12].Value = c10.ToString("N2");
                            dgv7.Rows[x].Cells[13].Value = c11.ToString("N2");
                            dgv7.Rows[x].Cells[14].Value = c12.ToString("N2");
                            dgv7.Rows[x].Cells[5].Value = c13.ToString("N0");
                        }
                        reader.Close();
                        i++;
                    }
                    #endregion
                    break;
                case 8:
                    #region cargar dgv8
                    for (; x <= dgv8.Rows.Count - 1; x++)
                    {
                        string qload = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[i];
                        cmd = new MySqlCommand(qload, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["ModelosvendidosH"].ToString());
                            c2 = double.Parse(reader["PorcentajeMH"].ToString());
                            c3 = double.Parse(reader["ParesvendidosH"].ToString());
                            c4 = double.Parse(reader["ModeloscompraP"].ToString());
                            c5 = double.Parse(reader["PorcentajeMP"].ToString());
                            c6 = double.Parse(reader["paresCompraP"].ToString());
                            c7 = double.Parse(reader["Parescompra80"].ToString());
                            c8 = double.Parse(reader["Parescompra20"].ToString());
                            c9 = double.Parse(reader["modeloscompraA"].ToString());
                            c10 = double.Parse(reader["modeloscompraB"].ToString());
                            c11 = double.Parse(reader["profundidadA"].ToString());
                            c12 = double.Parse(reader["profundidadB"].ToString());
                            c13 = double.Parse(reader["capacidad"].ToString());

                            dgv8.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv8.Rows[x].Cells[2].Value = c2.ToString("N2");
                            dgv8.Rows[x].Cells[3].Value = c3.ToString("N2");
                            dgv8.Rows[x].Cells[6].Value = c4.ToString("N0");
                            dgv8.Rows[x].Cells[7].Value = c5.ToString("N0");
                            dgv8.Rows[x].Cells[8].Value = c6.ToString("N2");
                            dgv8.Rows[x].Cells[9].Value = c7.ToString("N0");
                            dgv8.Rows[x].Cells[10].Value = c8.ToString("N2");
                            dgv8.Rows[x].Cells[11].Value = c9.ToString("N2");
                            dgv8.Rows[x].Cells[12].Value = c10.ToString("N2");
                            dgv8.Rows[x].Cells[13].Value = c11.ToString("N2");
                            dgv8.Rows[x].Cells[14].Value = c12.ToString("N2");
                            dgv8.Rows[x].Cells[5].Value = c13.ToString("N0");
                        }
                        reader.Close();
                        i++;
                    }
                    #endregion
                    break;
                case 9:
                    #region cargar dgv9
                    for (; x <= dgv9.Rows.Count - 1; x++)
                    {
                        string qload = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[i];
                        cmd = new MySqlCommand(qload, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["ModelosvendidosH"].ToString());
                            c2 = double.Parse(reader["PorcentajeMH"].ToString());
                            c3 = double.Parse(reader["ParesvendidosH"].ToString());
                            c4 = double.Parse(reader["ModeloscompraP"].ToString());
                            c5 = double.Parse(reader["PorcentajeMP"].ToString());
                            c6 = double.Parse(reader["paresCompraP"].ToString());
                            c7 = double.Parse(reader["Parescompra80"].ToString());
                            c8 = double.Parse(reader["Parescompra20"].ToString());
                            c9 = double.Parse(reader["modeloscompraA"].ToString());
                            c10 = double.Parse(reader["modeloscompraB"].ToString());
                            c11 = double.Parse(reader["profundidadA"].ToString());
                            c12 = double.Parse(reader["profundidadB"].ToString());
                            c13 = double.Parse(reader["capacidad"].ToString());

                            dgv9.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv9.Rows[x].Cells[2].Value = c2.ToString("N2");
                            dgv9.Rows[x].Cells[3].Value = c3.ToString("N2");
                            dgv9.Rows[x].Cells[6].Value = c4.ToString("N0");
                            dgv9.Rows[x].Cells[7].Value = c5.ToString("N0");
                            dgv9.Rows[x].Cells[8].Value = c6.ToString("N2");
                            dgv9.Rows[x].Cells[9].Value = c7.ToString("N0");
                            dgv9.Rows[x].Cells[10].Value = c8.ToString("N2");
                            dgv9.Rows[x].Cells[11].Value = c9.ToString("N2");
                            dgv9.Rows[x].Cells[12].Value = c10.ToString("N2");
                            dgv9.Rows[x].Cells[13].Value = c11.ToString("N2");
                            dgv9.Rows[x].Cells[14].Value = c12.ToString("N2");
                            dgv9.Rows[x].Cells[5].Value = c13.ToString("N0");
                        }
                        reader.Close();
                        i++;
                    }
                    #endregion
                    break;
                case 10:
                    #region cargar dgv10
                    for (; x <= dgv10.Rows.Count - 1; x++)
                    {
                        string qload = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[i];
                        cmd = new MySqlCommand(qload, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["ModelosvendidosH"].ToString());
                            c2 = double.Parse(reader["PorcentajeMH"].ToString());
                            c3 = double.Parse(reader["ParesvendidosH"].ToString());
                            c4 = double.Parse(reader["ModeloscompraP"].ToString());
                            c5 = double.Parse(reader["PorcentajeMP"].ToString());
                            c6 = double.Parse(reader["paresCompraP"].ToString());
                            c7 = double.Parse(reader["Parescompra80"].ToString());
                            c8 = double.Parse(reader["Parescompra20"].ToString());
                            c9 = double.Parse(reader["modeloscompraA"].ToString());
                            c10 = double.Parse(reader["modeloscompraB"].ToString());
                            c11 = double.Parse(reader["profundidadA"].ToString());
                            c12 = double.Parse(reader["profundidadB"].ToString());
                            c13 = double.Parse(reader["capacidad"].ToString());

                            dgv10.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv10.Rows[x].Cells[2].Value = c2.ToString("N2");
                            dgv10.Rows[x].Cells[3].Value = c3.ToString("N2");
                            dgv10.Rows[x].Cells[6].Value = c4.ToString("N0");
                            dgv10.Rows[x].Cells[7].Value = c5.ToString("N0");
                            dgv10.Rows[x].Cells[8].Value = c6.ToString("N2");
                            dgv10.Rows[x].Cells[9].Value = c7.ToString("N0");
                            dgv10.Rows[x].Cells[10].Value = c8.ToString("N2");
                            dgv10.Rows[x].Cells[11].Value = c9.ToString("N2");
                            dgv10.Rows[x].Cells[12].Value = c10.ToString("N2");
                            dgv10.Rows[x].Cells[13].Value = c11.ToString("N2");
                            dgv10.Rows[x].Cells[14].Value = c12.ToString("N2");
                            dgv10.Rows[x].Cells[5].Value = c13.ToString("N0");
                        }
                        reader.Close();
                        i++;
                    }
                    #endregion
                    break;
                case 11:
                    #region cargar dgv11
                    for (; x <= dgv11.Rows.Count - 1; x++)
                    {
                        string qload = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[i];
                        cmd = new MySqlCommand(qload, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["ModelosvendidosH"].ToString());
                            c2 = double.Parse(reader["PorcentajeMH"].ToString());
                            c3 = double.Parse(reader["ParesvendidosH"].ToString());
                            c4 = double.Parse(reader["ModeloscompraP"].ToString());
                            c5 = double.Parse(reader["PorcentajeMP"].ToString());
                            c6 = double.Parse(reader["paresCompraP"].ToString());
                            c7 = double.Parse(reader["Parescompra80"].ToString());
                            c8 = double.Parse(reader["Parescompra20"].ToString());
                            c9 = double.Parse(reader["modeloscompraA"].ToString());
                            c10 = double.Parse(reader["modeloscompraB"].ToString());
                            c11 = double.Parse(reader["profundidadA"].ToString());
                            c12 = double.Parse(reader["profundidadB"].ToString());
                            c13 = double.Parse(reader["capacidad"].ToString());

                            dgv11.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv11.Rows[x].Cells[2].Value = c2.ToString("N2");
                            dgv11.Rows[x].Cells[3].Value = c3.ToString("N2");
                            dgv11.Rows[x].Cells[6].Value = c4.ToString("N0");
                            dgv11.Rows[x].Cells[7].Value = c5.ToString("N0");
                            dgv11.Rows[x].Cells[8].Value = c6.ToString("N2");
                            dgv11.Rows[x].Cells[9].Value = c7.ToString("N0");
                            dgv11.Rows[x].Cells[10].Value = c8.ToString("N2");
                            dgv11.Rows[x].Cells[11].Value = c9.ToString("N2");
                            dgv11.Rows[x].Cells[12].Value = c10.ToString("N2");
                            dgv11.Rows[x].Cells[13].Value = c11.ToString("N2");
                            dgv11.Rows[x].Cells[14].Value = c12.ToString("N2");
                            dgv11.Rows[x].Cells[5].Value = c13.ToString("N0");
                        }
                        reader.Close();
                        i++;
                    }
                    #endregion
                    break;
                case 12:
                    #region cargar dgv12
                    for (; x <= dgv12.Rows.Count - 1; x++)
                    {
                        string qload = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[i];
                        cmd = new MySqlCommand(qload, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["ModelosvendidosH"].ToString());
                            c2 = double.Parse(reader["PorcentajeMH"].ToString());
                            c3 = double.Parse(reader["ParesvendidosH"].ToString());
                            c4 = double.Parse(reader["ModeloscompraP"].ToString());
                            c5 = double.Parse(reader["PorcentajeMP"].ToString());
                            c6 = double.Parse(reader["paresCompraP"].ToString());
                            c7 = double.Parse(reader["Parescompra80"].ToString());
                            c8 = double.Parse(reader["Parescompra20"].ToString());
                            c9 = double.Parse(reader["modeloscompraA"].ToString());
                            c10 = double.Parse(reader["modeloscompraB"].ToString());
                            c11 = double.Parse(reader["profundidadA"].ToString());
                            c12 = double.Parse(reader["profundidadB"].ToString());
                            c13 = double.Parse(reader["capacidad"].ToString());

                            dgv12.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv12.Rows[x].Cells[2].Value = c2.ToString("N2");
                            dgv12.Rows[x].Cells[3].Value = c3.ToString("N2");
                            dgv12.Rows[x].Cells[6].Value = c4.ToString("N0");
                            dgv12.Rows[x].Cells[7].Value = c5.ToString("N0");
                            dgv12.Rows[x].Cells[8].Value = c6.ToString("N2");
                            dgv12.Rows[x].Cells[9].Value = c7.ToString("N0");
                            dgv12.Rows[x].Cells[10].Value = c8.ToString("N2");
                            dgv12.Rows[x].Cells[11].Value = c9.ToString("N2");
                            dgv12.Rows[x].Cells[12].Value = c10.ToString("N2");
                            dgv12.Rows[x].Cells[13].Value = c11.ToString("N2");
                            dgv12.Rows[x].Cells[14].Value = c12.ToString("N2");
                            dgv12.Rows[x].Cells[5].Value = c13.ToString("N0");
                        }
                        reader.Close();
                        i++;

                    }
                    #endregion
                    break;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            #region banderas
            bandera_sucursal = false;
            bandera_division = false;
            bandera_depto = false;
            bandera_familia = false;
            bandera_linea = false;
            bandera_l1 = false;
            bandera_l2 = false;
            bandera_l3 = false;
            bandera_l4 = false;
            bandera_l5 = false;
            bandera_l6 = false;
            bandera_marca = false;
            seleccion_sucursal = -1;
            seleccion_division = -1;
            seleccion_depto = -1;
            seleccion_familia = -1;
            seleccion_linea = -1;
            seleccion_l1 = -1;
            seleccion_l2 = -1;
            seleccion_l3 = -1;
            seleccion_l4 = -1;
            seleccion_l5 = -1;
            seleccion_l6 = -1;
            seleccion_marca = "";
            s = ",-1"; d = ",-1"; dd = ",-1"; f = ",-1"; l = ",-1"; l1 = ",-1"; l2 = ",-1"; l3 = ",-1"; l4 = ",-1"; l5 = ",-1"; l6 = ",-1"; m = ",'-1'";
            #endregion
            solototal = true;
            m_CLEAR_DGV();
            m_ADD_ROWS_DGV();
            m_PASS_VALUES_DGV("Total", 0);
            dgv1.Rows[0].Cells[0].Value = "Total";
            //m_DIASMESESANOS(CED1_fechaI, CED1_fechaF);
            m_DIASMESESANOST(CED1_fechaI, CED1_fechaF);
            tabcontrol.SelectedIndex = 0;
            //m_DIASMESESANOS_guardarT(CED1_fechaI, CED1_fechaF);
        }
        public void m_DIASMESESANOST(string fecha_inicio, string fecha_final) /////////////////////////////se usa en todos 
        {

            int fecha_inicio_dia = Convert.ToInt32(fecha_inicio.Substring(0, 2));
            int fecha_inicio_mes = Convert.ToInt32(fecha_inicio.Substring(3, 2));
            int fecha_inicio_ano = Convert.ToInt32(fecha_inicio.Substring(6, 4));

            int fecha_final_dia = Convert.ToInt32(fecha_final.Substring(0, 2));
            int fecha_final_mes = Convert.ToInt32(fecha_final.Substring(3, 2));
            int fecha_final_ano = Convert.ToInt32(fecha_final.Substring(6, 4));
            bool carga=false;
            int mes = 1;
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
                            if (comprobarCargarT(fecha_inicio_ano, fecha_inicio_mes, i) == true)
                            {
                                cargarT(fecha_inicio_mes, fecha_inicio_ano, i);
                                carga=true;
                            }
                            else
                            {
                                modelajeHU(fecha_inicio_mes, fecha_inicio_ano, i);
                                modelajeHP(i);
                                M_unidades_vendidas(fecha_final_mes, fecha_inicio_ano, i);
                                comprasP(fecha_inicio_mes, fecha_inicio_ano, i);
                                //modelos_CompraP(i);
                                modelajePP(i);
                                Pares_aComprar(i);
                                asignacionModelos(i);
                                profundidad(i);
                                m_REFRESH_DGV();
                            }
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
                            m_TABS(fecha_inicio_mes, fecha_inicio_ano);/////////////////////se usa en todos 
                            if (comprobarCargarT(fecha_inicio_ano, fecha_inicio_mes, i) == true)
                            {
                                cargarT(fecha_inicio_mes, fecha_inicio_ano, i);
                                carga=true;
                            }
                            else
                            {
                                modelajeHU(fecha_inicio_mes, fecha_inicio_ano, i);
                                modelajeHP(i);
                                M_unidades_vendidas(fecha_final_mes, fecha_inicio_ano, i);
                                comprasP(fecha_inicio_mes, fecha_inicio_ano, i);
                               // modelos_CompraP(i);
                                modelajePP(i);
                                Pares_aComprar(i);
                                asignacionModelos(i);
                                profundidad(i);
                                m_REFRESH_DGV();
                            }
                            tabcontrol.SelectedIndex = tabcontrol.SelectedIndex + 1;
                        }
                        catch (Exception x)
                        { MessageBox.Show("Error con las fechas " + x); }
                }
                fecha_inicio_mes = 1;
            }
            #endregion
            
            tabcontrol.SelectedIndex = 0;
        }
        public void m_RECIBOBASET(int mes, int ano, int i) // ejemplo query modificar a 3 tablas 
        {
            double prom = 0;
            int x=0;
                m_REFRESH_DGV(); int difcero = 1;
                
                    #region CONSULTA CORRECTA AÑO ACTUAL
                    query = "SELECT SUM(e.ctd)AS articulo FROM recibobase AS E INNER JOIN estarticulo AS V ON V.`idarticulo` = E.`idarticulo` INNER JOIN fecha AS F ON F.`idFecha` = E.`idfecha` WHERE  F.mes = '" + mes + "' AND F.anio = '" + (ano-1) + "' "+solocalzadowhere;
                    /*query = "SELECT SUM(v.`CTD_RECIB`) AS articulo FROM recibo_base AS V INNER JOIN fecha AS F ON F.`idFecha` = V.`IDFECHA` WHERE  F.FECHA BETWEEN '" +  fech1.ToString("yyyy-MM-dd") + "' AND '" + fech2.ToString("yyyy-MM-dd") + "' AND F.mes = '" + mes + "' AND F.anio = '" + ano + "'  " + wherequery[0] + ";";*/
                    cmd = new MySqlCommand(query, Conn); cmd.CommandTimeout = 0;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //m_REFRESH_DGV();
                        //if (reader["articulo"].ToString() == "")
                        //{ m_LLENAR_DGV(i, x, "0"); difcero = 0; }
                        //else
                        //{
                        //    string val = reader["articulo"].ToString();
                        //    m_LLENAR_DGV(i, x, val);
                        //}
                    }
                    reader.Close();
                    #endregion
              
        }
        public void m_NUM_MODT(int mes, int ano, int i) // ejemplo query modificar a 3 
        {
            double prom = 0; int difcero = 1;
                dgv1.Refresh();
                
                    #region consulta año actual
                    //
                    query = "SELECT COUNT(modelo) AS modelo FROM recibobase AS E INNER JOIN estarticulo AS V ON V.`idarticulo` = E.`idarticulo` INNER JOIN fecha AS F ON F.`idFecha` = E.`idfecha` WHERE   F.mes = '" + mes + "' AND F.anio = '" + (ano-1) + "' " + solocalzadowhere + ";";
                    /*query = "SELECT COUNT(DISTINCT MODELO)AS modelo FROM recibo_base AS V INNER JOIN fecha AS F ON F.`idFecha` = V.`IDFECHA` WHERE  F.FECHA BETWEEN '" + fech1.ToString("yyyy-MM-dd") + "' AND '" + fech2.ToString("yyyy-MM-dd") + "' AND F.mes = '" + mes + "' AND F.anio = '" + ano + "' " + wherequery[0] + ";";*/
                    cmd = new MySqlCommand(query, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dgv1.Refresh();
                        if (reader["modelo"].ToString() == "")
                        {
                            m_LLENAR_DGV2(i, 0, "0"); difcero = 0;
                        }
                        else
                        {
                            string val = reader["modelo"].ToString();
                            m_LLENAR_DGV2(i, 0, val);
                        }
                    }
                    reader.Close();
                    #endregion
  
           
        }

        private void m_CALCULOST(int m)
        {
            //double sumatoria = 0; double porcentaje = 0; int suma_modelaje = 0; int suma_asignacion = 0;
            //m = m - 1;
            //switch (m)
            //{
            //    case 1:
            //        #region calculos dgv1
            //        for (int n = 0; n < dgv1.RowCount - 1; n++)
            //        {
            //            sumatoria = sumatoria + Convert.ToDouble(dgv1.Rows[n].Cells[1].Value);
            //            if(dgv1.Rows[n].Cells[2].Value!=null)
            //            {
            //              suma_modelaje = suma_modelaje + Convert.ToInt32(dgv1.Rows[n].Cells[2].Value);
            //            }
            //            else
            //            {
            //                suma_modelaje = suma_modelaje+0;
            //            }
            //        }
            //        for (int n = 0; n < dgv1.RowCount - 1; n++)
            //        {
            //            porcentaje = Convert.ToDouble(dgv1.Rows[n].Cells[1].Value) / sumatoria;
            //            dgv1.Rows[n].Cells[1].Value = (porcentaje * 100).ToString("N2");
            //        }
            //        #region eliminar Nan NeuN
            //        for (int n = 0; n < dgv1.RowCount-1; n++)
            //        {
            //            string valor = Convert.ToString(dgv1.Rows[n].Cells[1].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null)
            //            { dgv1.Rows[n].Cells[1].Value = 0.00; }
            //        }
            //        #endregion
            //        #region asignacion
            //        for (int n = 0; n < dgv1.RowCount-1; n++)
            //        {
            //            double asignacion = 0;
            //            asignacion = (compras[n] * (0.01 * (Convert.ToDouble(dgv1.Rows[n].Cells[1].Value))));
            //            dgv1.Rows[n].Cells[3].Value = asignacion.ToString("N0");
            //        }
            //        #endregion
            //        #region ponderacion
            //        for (int n = 0; n < dgv1.RowCount-1; n++)
            //        {
            //            string pond = Convert.ToString(dgv1.Rows[n].Cells[3].Value);
            //            pond = pond.Trim(',');
            //            double pond_tod = Convert.ToDouble(pond);
            //            double pond1 = 0, pond2 = 0;
            //            pond1 = (ponderacion80 * 0.01) * (pond_tod);
            //            pond2 = (ponderacion20 * 0.01) * (pond_tod);


            //            dgv1.Rows[n].Cells[4].Value = pond1.ToString("N0");
            //            dgv1.Rows[n].Cells[5].Value = pond2.ToString("N0");
            //        }
            //        #endregion
            //        #region asignacion modelos
            //        for (int n = 0; n < dgv1.RowCount-1; n++)
            //        {
            //            int unid = Convert.ToInt32(dgv1.Rows[n].Cells[2].Value);

            //            double asig_mod1 = 0, asig_mod2 = 0;
            //            asig_mod1 = (asignacion20 * 0.01) * (unid);
            //            asig_mod2 = (asignacion80 * 0.01) * (unid);


            //            dgv1.Rows[n].Cells[6].Value = asig_mod1.ToString("N0");
            //            dgv1.Rows[n].Cells[7].Value = asig_mod2.ToString("N0");
            //        }
            //        #endregion
            //        #region profundidad
            //        for (int n = 0; n < dgv1.RowCount-1; n++)
            //        {

            //            string ren4 = Convert.ToString(dgv1.Rows[n].Cells[4].Value);
            //            string ren5 = Convert.ToString(dgv1.Rows[n].Cells[5].Value);
            //            string ren6 = Convert.ToString(dgv1.Rows[n].Cells[6].Value);
            //            string ren7 = Convert.ToString(dgv1.Rows[n].Cells[7].Value);
            //            ren4 = ren4.Replace(",", ""); ren5 = ren5.Replace(",", ""); ren6 = ren6.Replace(",", ""); ren7 = ren7.Replace(",", "");
            //            double v1, v2, v3, v4 = 0;
            //            v1 = Convert.ToDouble(ren4); v2 = Convert.ToDouble(ren5); v3 = Convert.ToDouble(ren6); v4 = Convert.ToDouble(ren7);
            //            prof20 = v1 / v3;
            //            prof80 = v2 / v4;

            //            dgv1.Rows[n].Cells[8].Value = prof20.ToString("N0");
            //            dgv1.Rows[n].Cells[9].Value = prof80.ToString("N0");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 8
            //        for (int n = 0; n < dgv1.RowCount-1; n++)
            //        {
            //            string valor = Convert.ToString(dgv1.Rows[n].Cells[8].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv1.Rows[n].Cells[8].Value = 0; }
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 9
            //        for (int n = 0; n < dgv1.RowCount-1; n++)
            //        {
            //            string valor = Convert.ToString(dgv1.Rows[n].Cells[9].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv1.Rows[n].Cells[9].Value = 0.00; }
            //        }
            //        #endregion
            //        #endregion
            //        break;
            //    case 2:
            //        #region calculos dgv2
            //        #region eliminar Nan NeuN
            //        for (int n = 0; n < dgv2.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv2.Rows[n].Cells[1].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null)
            //            { dgv2.Rows[n].Cells[1].Value = 0.00; }
            //        }
            //        #endregion
            //        #region asignacion
            //        for (int n = 0; n < dgv2.RowCount; n++)
            //        {
            //            double asignacion = 0;
            //            asignacion = (Convert.ToDouble(tb_UnidCompr.Text) * (0.01 * (Convert.ToDouble(dgv2.Rows[n].Cells[1].Value))));
            //            dgv2.Rows[n].Cells[3].Value = asignacion.ToString("N0");
            //        }
            //        #endregion
            //        #region ponderacion
            //        for (int n = 0; n < dgv2.RowCount; n++)
            //        {
            //            string pond = Convert.ToString(dgv2.Rows[n].Cells[3].Value);
            //            pond = pond.Trim(',');
            //            double pond_tod = Convert.ToDouble(pond);
            //            double pond1 = 0, pond2 = 0;
            //            pond1 = (ponderacion80 * 0.01) * (pond_tod);
            //            pond2 = (ponderacion20 * 0.01) * (pond_tod);


            //            dgv2.Rows[n].Cells[4].Value = pond1.ToString("N0");
            //            dgv2.Rows[n].Cells[5].Value = pond2.ToString("N0");
            //        }
            //        #endregion
            //        #region asignacion modelos
            //        for (int n = 0; n < dgv2.RowCount; n++)
            //        {
            //            int unid = Convert.ToInt32(dgv2.Rows[n].Cells[2].Value);

            //            double asig_mod1 = 0, asig_mod2 = 0;
            //            asig_mod1 = (asignacion20 * 0.01) * (unid);
            //            asig_mod2 = (asignacion80 * 0.01) * (unid);


            //            dgv2.Rows[n].Cells[6].Value = asig_mod1.ToString("N0");
            //            dgv2.Rows[n].Cells[7].Value = asig_mod2.ToString("N0");
            //        }
            //        #endregion
            //        #region profundidad
            //        for (int n = 0; n < dgv2.RowCount; n++)
            //        {

            //            string ren4 = Convert.ToString(dgv2.Rows[n].Cells[4].Value);
            //            string ren5 = Convert.ToString(dgv2.Rows[n].Cells[5].Value);
            //            string ren6 = Convert.ToString(dgv2.Rows[n].Cells[6].Value);
            //            string ren7 = Convert.ToString(dgv2.Rows[n].Cells[7].Value);
            //            ren4 = ren4.Replace(",", ""); ren5 = ren5.Replace(",", ""); ren6 = ren6.Replace(",", ""); ren7 = ren7.Replace(",", "");
            //            double v1, v2, v3, v4 = 0;
            //            v1 = Convert.ToDouble(ren4); v2 = Convert.ToDouble(ren5); v3 = Convert.ToDouble(ren6); v4 = Convert.ToDouble(ren7);
            //            prof20 = v1 / v3;
            //            prof80 = v2 / v4;

            //            dgv2.Rows[n].Cells[8].Value = prof20.ToString("N0");
            //            dgv2.Rows[n].Cells[9].Value = prof80.ToString("N0");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 8
            //        for (int n = 0; n < dgv2.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv2.Rows[n].Cells[8].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv2.Rows[n].Cells[8].Value = 0; }
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 9
            //        for (int n = 0; n < dgv2.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv2.Rows[n].Cells[9].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv2.Rows[n].Cells[9].Value = 0.00; }
            //        }
            //        #endregion
            //        #endregion
            //        break;
            //    case 3:
            //        #region calculos dgv3
            //        #region eliminar Nan NeuN
            //        for (int n = 0; n < dgv3.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv3.Rows[n].Cells[1].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null)
            //            { dgv3.Rows[n].Cells[1].Value = 0.00; }
            //        }
            //        #endregion
            //        #region asignacion
            //        for (int n = 0; n < dgv3.RowCount; n++)
            //        {
            //            double asignacion = 0;
            //            asignacion = (Convert.ToDouble(tb_UnidCompr.Text) * (0.01 * (Convert.ToDouble(dgv3.Rows[n].Cells[1].Value))));
            //            dgv3.Rows[n].Cells[3].Value = asignacion.ToString("N0");
            //        }
            //        #endregion
            //        #region ponderacion
            //        for (int n = 0; n < dgv3.RowCount; n++)
            //        {
            //            string pond = Convert.ToString(dgv3.Rows[n].Cells[3].Value);
            //            pond = pond.Trim(',');
            //            double pond_tod = Convert.ToDouble(pond);
            //            double pond1 = 0, pond2 = 0;
            //            pond1 = (ponderacion80 * 0.01) * (pond_tod);
            //            pond2 = (ponderacion20 * 0.01) * (pond_tod);


            //            dgv3.Rows[n].Cells[4].Value = pond1.ToString("N0");
            //            dgv3.Rows[n].Cells[5].Value = pond2.ToString("N0");
            //        }
            //        #endregion
            //        #region asignacion modelos
            //        for (int n = 0; n < dgv3.RowCount; n++)
            //        {
            //            int unid = Convert.ToInt32(dgv3.Rows[n].Cells[2].Value);

            //            double asig_mod1 = 0, asig_mod2 = 0;
            //            asig_mod1 = (asignacion20 * 0.01) * (unid);
            //            asig_mod2 = (asignacion80 * 0.01) * (unid);


            //            dgv3.Rows[n].Cells[6].Value = asig_mod1.ToString("N0");
            //            dgv3.Rows[n].Cells[7].Value = asig_mod2.ToString("N0");
            //        }
            //        #endregion
            //        #region profundidad
            //        for (int n = 0; n < dgv3.RowCount; n++)
            //        {

            //            string ren4 = Convert.ToString(dgv3.Rows[n].Cells[4].Value);
            //            string ren5 = Convert.ToString(dgv3.Rows[n].Cells[5].Value);
            //            string ren6 = Convert.ToString(dgv3.Rows[n].Cells[6].Value);
            //            string ren7 = Convert.ToString(dgv3.Rows[n].Cells[7].Value);
            //            ren4 = ren4.Replace(",", ""); ren5 = ren5.Replace(",", ""); ren6 = ren6.Replace(",", ""); ren7 = ren7.Replace(",", "");
            //            double v1, v2, v3, v4 = 0;
            //            v1 = Convert.ToDouble(ren4); v2 = Convert.ToDouble(ren5); v3 = Convert.ToDouble(ren6); v4 = Convert.ToDouble(ren7);
            //            prof20 = v1 / v3;
            //            prof80 = v2 / v4;

            //            dgv3.Rows[n].Cells[8].Value = prof20.ToString("N0");
            //            dgv3.Rows[n].Cells[9].Value = prof80.ToString("N0");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 8
            //        for (int n = 0; n < dgv3.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv3.Rows[n].Cells[8].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv3.Rows[n].Cells[8].Value = 0; }
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 9
            //        for (int n = 0; n < dgv3.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv3.Rows[n].Cells[9].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv3.Rows[n].Cells[9].Value = 0.00; }
            //        }
            //        #endregion
            //        #endregion
            //        break;
            //    case 4:
            //        #region calculos dgv4
            //        #region eliminar Nan NeuN
            //        for (int n = 0; n < dgv4.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv4.Rows[n].Cells[1].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null)
            //            { dgv4.Rows[n].Cells[1].Value = 0.00; }
            //        }
            //        #endregion
            //        #region asignacion
            //        for (int n = 0; n < dgv4.RowCount; n++)
            //        {
            //            double asignacion = 0;
            //            asignacion = (Convert.ToDouble(tb_UnidCompr.Text) * (0.01 * (Convert.ToDouble(dgv4.Rows[n].Cells[1].Value))));
            //            dgv4.Rows[n].Cells[3].Value = asignacion.ToString("N0");
            //        }
            //        #endregion
            //        #region ponderacion
            //        for (int n = 0; n < dgv4.RowCount; n++)
            //        {
            //            string pond = Convert.ToString(dgv4.Rows[n].Cells[3].Value);
            //            pond = pond.Trim(',');
            //            double pond_tod = Convert.ToDouble(pond);
            //            double pond1 = 0, pond2 = 0;
            //            pond1 = (ponderacion80 * 0.01) * (pond_tod);
            //            pond2 = (ponderacion20 * 0.01) * (pond_tod);


            //            dgv4.Rows[n].Cells[4].Value = pond1.ToString("N0");
            //            dgv4.Rows[n].Cells[5].Value = pond2.ToString("N0");
            //        }
            //        #endregion
            //        #region asignacion modelos
            //        for (int n = 0; n < dgv4.RowCount; n++)
            //        {
            //            int unid = Convert.ToInt32(dgv4.Rows[n].Cells[2].Value);

            //            double asig_mod1 = 0, asig_mod2 = 0;
            //            asig_mod1 = (asignacion20 * 0.01) * (unid);
            //            asig_mod2 = (asignacion80 * 0.01) * (unid);


            //            dgv4.Rows[n].Cells[6].Value = asig_mod1.ToString("N0");
            //            dgv4.Rows[n].Cells[7].Value = asig_mod2.ToString("N0");
            //        }
            //        #endregion
            //        #region profundidad
            //        for (int n = 0; n < dgv4.RowCount; n++)
            //        {

            //            string ren4 = Convert.ToString(dgv4.Rows[n].Cells[4].Value);
            //            string ren5 = Convert.ToString(dgv4.Rows[n].Cells[5].Value);
            //            string ren6 = Convert.ToString(dgv4.Rows[n].Cells[6].Value);
            //            string ren7 = Convert.ToString(dgv4.Rows[n].Cells[7].Value);
            //            ren4 = ren4.Replace(",", ""); ren5 = ren5.Replace(",", ""); ren6 = ren6.Replace(",", ""); ren7 = ren7.Replace(",", "");
            //            double v1, v2, v3, v4 = 0;
            //            v1 = Convert.ToDouble(ren4); v2 = Convert.ToDouble(ren5); v3 = Convert.ToDouble(ren6); v4 = Convert.ToDouble(ren7);
            //            prof20 = v1 / v3;
            //            prof80 = v2 / v4;

            //            dgv4.Rows[n].Cells[8].Value = prof20.ToString("N0");
            //            dgv4.Rows[n].Cells[9].Value = prof80.ToString("N0");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 8
            //        for (int n = 0; n < dgv4.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv4.Rows[n].Cells[8].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv4.Rows[n].Cells[8].Value = 0; }
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 9
            //        for (int n = 0; n < dgv4.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv4.Rows[n].Cells[9].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv4.Rows[n].Cells[9].Value = 0.00; }
            //        }
            //        #endregion
            //        #endregion
            //        break;
            //    case 5:
            //        #region calculos dgv5
            //        #region eliminar Nan NeuN
            //        for (int n = 0; n < dgv5.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv5.Rows[n].Cells[1].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null)
            //            { dgv5.Rows[n].Cells[1].Value = 0.00; }
            //        }
            //        #endregion
            //        #region asignacion
            //        for (int n = 0; n < dgv5.RowCount; n++)
            //        {
            //            double asignacion = 0;
            //            asignacion = (Convert.ToDouble(tb_UnidCompr.Text) * (0.01 * (Convert.ToDouble(dgv5.Rows[n].Cells[1].Value))));
            //            dgv5.Rows[n].Cells[3].Value = asignacion.ToString("N0");
            //        }
            //        #endregion
            //        #region ponderacion
            //        for (int n = 0; n < dgv5.RowCount; n++)
            //        {
            //            string pond = Convert.ToString(dgv5.Rows[n].Cells[3].Value);
            //            pond = pond.Trim(',');
            //            double pond_tod = Convert.ToDouble(pond);
            //            double pond1 = 0, pond2 = 0;
            //            pond1 = (ponderacion80 * 0.01) * (pond_tod);
            //            pond2 = (ponderacion20 * 0.01) * (pond_tod);


            //            dgv5.Rows[n].Cells[4].Value = pond1.ToString("N0");
            //            dgv5.Rows[n].Cells[5].Value = pond2.ToString("N0");
            //        }
            //        #endregion
            //        #region asignacion modelos
            //        for (int n = 0; n < dgv5.RowCount; n++)
            //        {
            //            int unid = Convert.ToInt32(dgv5.Rows[n].Cells[2].Value);

            //            double asig_mod1 = 0, asig_mod2 = 0;
            //            asig_mod1 = (asignacion20 * 0.01) * (unid);
            //            asig_mod2 = (asignacion80 * 0.01) * (unid);


            //            dgv5.Rows[n].Cells[6].Value = asig_mod1.ToString("N0");
            //            dgv5.Rows[n].Cells[7].Value = asig_mod2.ToString("N0");
            //        }
            //        #endregion
            //        #region profundidad
            //        for (int n = 0; n < dgv5.RowCount; n++)
            //        {

            //            string ren4 = Convert.ToString(dgv5.Rows[n].Cells[4].Value);
            //            string ren5 = Convert.ToString(dgv5.Rows[n].Cells[5].Value);
            //            string ren6 = Convert.ToString(dgv5.Rows[n].Cells[6].Value);
            //            string ren7 = Convert.ToString(dgv5.Rows[n].Cells[7].Value);
            //            ren4 = ren4.Replace(",", ""); ren5 = ren5.Replace(",", ""); ren6 = ren6.Replace(",", ""); ren7 = ren7.Replace(",", "");
            //            double v1, v2, v3, v4 = 0;
            //            v1 = Convert.ToDouble(ren4); v2 = Convert.ToDouble(ren5); v3 = Convert.ToDouble(ren6); v4 = Convert.ToDouble(ren7);
            //            prof20 = v1 / v3;
            //            prof80 = v2 / v4;

            //            dgv5.Rows[n].Cells[8].Value = prof20.ToString("N0");
            //            dgv5.Rows[n].Cells[9].Value = prof80.ToString("N0");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 8
            //        for (int n = 0; n < dgv5.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv5.Rows[n].Cells[8].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv5.Rows[n].Cells[8].Value = 0; }
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 9
            //        for (int n = 0; n < dgv5.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv5.Rows[n].Cells[9].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv5.Rows[n].Cells[9].Value = 0.00; }
            //        }
            //        #endregion
            //        #endregion
            //        break;
            //    case 6:
            //        #region calculos dgv6
            //        #region eliminar Nan NeuN
            //        for (int n = 0; n < dgv6.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv6.Rows[n].Cells[1].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null)
            //            { dgv6.Rows[n].Cells[1].Value = 0.00; }
            //        }
            //        #endregion
            //        #region asignacion
            //        for (int n = 0; n < dgv6.RowCount; n++)
            //        {
            //            double asignacion = 0;
            //            asignacion = (Convert.ToDouble(tb_UnidCompr.Text) * (0.01 * (Convert.ToDouble(dgv6.Rows[n].Cells[1].Value))));
            //            dgv6.Rows[n].Cells[3].Value = asignacion.ToString("N0");
            //        }
            //        #endregion
            //        #region ponderacion
            //        for (int n = 0; n < dgv6.RowCount; n++)
            //        {
            //            string pond = Convert.ToString(dgv6.Rows[n].Cells[3].Value);
            //            pond = pond.Trim(',');
            //            double pond_tod = Convert.ToDouble(pond);
            //            double pond1 = 0, pond2 = 0;
            //            pond1 = (ponderacion80 * 0.01) * (pond_tod);
            //            pond2 = (ponderacion20 * 0.01) * (pond_tod);


            //            dgv6.Rows[n].Cells[4].Value = pond1.ToString("N0");
            //            dgv6.Rows[n].Cells[5].Value = pond2.ToString("N0");
            //        }
            //        #endregion
            //        #region asignacion modelos
            //        for (int n = 0; n < dgv6.RowCount; n++)
            //        {
            //            int unid = Convert.ToInt32(dgv6.Rows[n].Cells[2].Value);

            //            double asig_mod1 = 0, asig_mod2 = 0;
            //            asig_mod1 = (asignacion20 * 0.01) * (unid);
            //            asig_mod2 = (asignacion80 * 0.01) * (unid);


            //            dgv6.Rows[n].Cells[6].Value = asig_mod1.ToString("N0");
            //            dgv6.Rows[n].Cells[7].Value = asig_mod2.ToString("N0");
            //        }
            //        #endregion
            //        #region profundidad
            //        for (int n = 0; n < dgv6.RowCount; n++)
            //        {

            //            string ren4 = Convert.ToString(dgv6.Rows[n].Cells[4].Value);
            //            string ren5 = Convert.ToString(dgv6.Rows[n].Cells[5].Value);
            //            string ren6 = Convert.ToString(dgv6.Rows[n].Cells[6].Value);
            //            string ren7 = Convert.ToString(dgv6.Rows[n].Cells[7].Value);
            //            ren4 = ren4.Replace(",", ""); ren5 = ren5.Replace(",", ""); ren6 = ren6.Replace(",", ""); ren7 = ren7.Replace(",", "");
            //            double v1, v2, v3, v4 = 0;
            //            v1 = Convert.ToDouble(ren4); v2 = Convert.ToDouble(ren5); v3 = Convert.ToDouble(ren6); v4 = Convert.ToDouble(ren7);
            //            prof20 = v1 / v3;
            //            prof80 = v2 / v4;

            //            dgv6.Rows[n].Cells[8].Value = prof20.ToString("N0");
            //            dgv6.Rows[n].Cells[9].Value = prof80.ToString("N0");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 8
            //        for (int n = 0; n < dgv6.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv6.Rows[n].Cells[8].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv6.Rows[n].Cells[8].Value = 0; }
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 9
            //        for (int n = 0; n < dgv6.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv6.Rows[n].Cells[9].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv6.Rows[n].Cells[9].Value = 0.00; }
            //        }
            //        #endregion
            //        #endregion
            //        break;
            //    case 7:
            //        #region calculos dgv7
            //        #region eliminar Nan NeuN
            //        for (int n = 0; n < dgv7.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv7.Rows[n].Cells[1].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null)
            //            { dgv7.Rows[n].Cells[1].Value = 0.00; }
            //        }
            //        #endregion
            //        #region asignacion
            //        for (int n = 0; n < dgv7.RowCount; n++)
            //        {
            //            double asignacion = 0;
            //            asignacion = (Convert.ToDouble(tb_UnidCompr.Text) * (0.01 * (Convert.ToDouble(dgv7.Rows[n].Cells[1].Value))));
            //            dgv7.Rows[n].Cells[3].Value = asignacion.ToString("N0");
            //        }
            //        #endregion
            //        #region ponderacion
            //        for (int n = 0; n < dgv7.RowCount; n++)
            //        {
            //            string pond = Convert.ToString(dgv7.Rows[n].Cells[3].Value);
            //            pond = pond.Trim(',');
            //            double pond_tod = Convert.ToDouble(pond);
            //            double pond1 = 0, pond2 = 0;
            //            pond1 = (ponderacion80 * 0.01) * (pond_tod);
            //            pond2 = (ponderacion20 * 0.01) * (pond_tod);


            //            dgv7.Rows[n].Cells[4].Value = pond1.ToString("N0");
            //            dgv7.Rows[n].Cells[5].Value = pond2.ToString("N0");
            //        }
            //        #endregion
            //        #region asignacion modelos
            //        for (int n = 0; n < dgv7.RowCount; n++)
            //        {
            //            int unid = Convert.ToInt32(dgv7.Rows[n].Cells[2].Value);

            //            double asig_mod1 = 0, asig_mod2 = 0;
            //            asig_mod1 = (asignacion20 * 0.01) * (unid);
            //            asig_mod2 = (asignacion80 * 0.01) * (unid);


            //            dgv7.Rows[n].Cells[6].Value = asig_mod1.ToString("N0");
            //            dgv7.Rows[n].Cells[7].Value = asig_mod2.ToString("N0");
            //        }
            //        #endregion
            //        #region profundidad
            //        for (int n = 0; n < dgv7.RowCount; n++)
            //        {

            //            string ren4 = Convert.ToString(dgv7.Rows[n].Cells[4].Value);
            //            string ren5 = Convert.ToString(dgv7.Rows[n].Cells[5].Value);
            //            string ren6 = Convert.ToString(dgv7.Rows[n].Cells[6].Value);
            //            string ren7 = Convert.ToString(dgv7.Rows[n].Cells[7].Value);
            //            ren4 = ren4.Replace(",", ""); ren5 = ren5.Replace(",", ""); ren6 = ren6.Replace(",", ""); ren7 = ren7.Replace(",", "");
            //            double v1, v2, v3, v4 = 0;
            //            v1 = Convert.ToDouble(ren4); v2 = Convert.ToDouble(ren5); v3 = Convert.ToDouble(ren6); v4 = Convert.ToDouble(ren7);
            //            prof20 = v1 / v3;
            //            prof80 = v2 / v4;

            //            dgv7.Rows[n].Cells[8].Value = prof20.ToString("N0");
            //            dgv7.Rows[n].Cells[9].Value = prof80.ToString("N0");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 8
            //        for (int n = 0; n < dgv7.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv7.Rows[n].Cells[8].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv7.Rows[n].Cells[8].Value = 0; }
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 9
            //        for (int n = 0; n < dgv7.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv7.Rows[n].Cells[9].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv7.Rows[n].Cells[9].Value = 0.00; }
            //        }
            //        #endregion
            //        #endregion
            //        break;
            //    case 8:
            //        #region calculos dgv8
            //        #region eliminar Nan NeuN
            //        for (int n = 0; n < dgv8.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv8.Rows[n].Cells[1].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null)
            //            { dgv8.Rows[n].Cells[1].Value = 0.00; }
            //        }
            //        #endregion
            //        #region asignacion
            //        for (int n = 0; n < dgv8.RowCount; n++)
            //        {
            //            double asignacion = 0;
            //            asignacion = (Convert.ToDouble(tb_UnidCompr.Text) * (0.01 * (Convert.ToDouble(dgv8.Rows[n].Cells[1].Value))));
            //            dgv8.Rows[n].Cells[3].Value = asignacion.ToString("N0");
            //        }
            //        #endregion
            //        #region ponderacion
            //        for (int n = 0; n < dgv8.RowCount; n++)
            //        {
            //            string pond = Convert.ToString(dgv8.Rows[n].Cells[3].Value);
            //            pond = pond.Trim(',');
            //            double pond_tod = Convert.ToDouble(pond);
            //            double pond1 = 0, pond2 = 0;
            //            pond1 = (ponderacion80 * 0.01) * (pond_tod);
            //            pond2 = (ponderacion20 * 0.01) * (pond_tod);


            //            dgv8.Rows[n].Cells[4].Value = pond1.ToString("N0");
            //            dgv8.Rows[n].Cells[5].Value = pond2.ToString("N0");
            //        }
            //        #endregion
            //        #region asignacion modelos
            //        for (int n = 0; n < dgv8.RowCount; n++)
            //        {
            //            int unid = Convert.ToInt32(dgv8.Rows[n].Cells[2].Value);

            //            double asig_mod1 = 0, asig_mod2 = 0;
            //            asig_mod1 = (asignacion20 * 0.01) * (unid);
            //            asig_mod2 = (asignacion80 * 0.01) * (unid);


            //            dgv8.Rows[n].Cells[6].Value = asig_mod1.ToString("N0");
            //            dgv8.Rows[n].Cells[7].Value = asig_mod2.ToString("N0");
            //        }
            //        #endregion
            //        #region profundidad
            //        for (int n = 0; n < dgv8.RowCount; n++)
            //        {

            //            string ren4 = Convert.ToString(dgv8.Rows[n].Cells[4].Value);
            //            string ren5 = Convert.ToString(dgv8.Rows[n].Cells[5].Value);
            //            string ren6 = Convert.ToString(dgv8.Rows[n].Cells[6].Value);
            //            string ren7 = Convert.ToString(dgv8.Rows[n].Cells[7].Value);
            //            ren4 = ren4.Replace(",", ""); ren5 = ren5.Replace(",", ""); ren6 = ren6.Replace(",", ""); ren7 = ren7.Replace(",", "");
            //            double v1, v2, v3, v4 = 0;
            //            v1 = Convert.ToDouble(ren4); v2 = Convert.ToDouble(ren5); v3 = Convert.ToDouble(ren6); v4 = Convert.ToDouble(ren7);
            //            prof20 = v1 / v3;
            //            prof80 = v2 / v4;

            //            dgv8.Rows[n].Cells[8].Value = prof20.ToString("N0");
            //            dgv8.Rows[n].Cells[9].Value = prof80.ToString("N0");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 8
            //        for (int n = 0; n < dgv8.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv8.Rows[n].Cells[8].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv8.Rows[n].Cells[8].Value = 0; }
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 9
            //        for (int n = 0; n < dgv8.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv8.Rows[n].Cells[9].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv8.Rows[n].Cells[9].Value = 0.00; }
            //        }
            //        #endregion
            //        #endregion
            //        break;
            //    case 9:
            //        #region calculos dgv9
            //        #region eliminar Nan NeuN
            //        for (int n = 0; n < dgv9.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv9.Rows[n].Cells[1].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null)
            //            { dgv9.Rows[n].Cells[1].Value = 0.00; }
            //        }
            //        #endregion
            //        #region asignacion
            //        for (int n = 0; n < dgv9.RowCount; n++)
            //        {
            //            double asignacion = 0;
            //            asignacion = (Convert.ToDouble(tb_UnidCompr.Text) * (0.01 * (Convert.ToDouble(dgv9.Rows[n].Cells[1].Value))));
            //            dgv9.Rows[n].Cells[3].Value = asignacion.ToString("N0");
            //        }
            //        #endregion
            //        #region ponderacion
            //        for (int n = 0; n < dgv9.RowCount; n++)
            //        {
            //            string pond = Convert.ToString(dgv9.Rows[n].Cells[3].Value);
            //            pond = pond.Trim(',');
            //            double pond_tod = Convert.ToDouble(pond);
            //            double pond1 = 0, pond2 = 0;
            //            pond1 = (ponderacion80 * 0.01) * (pond_tod);
            //            pond2 = (ponderacion20 * 0.01) * (pond_tod);


            //            dgv9.Rows[n].Cells[4].Value = pond1.ToString("N0");
            //            dgv9.Rows[n].Cells[5].Value = pond2.ToString("N0");
            //        }
            //        #endregion
            //        #region asignacion modelos
            //        for (int n = 0; n < dgv9.RowCount; n++)
            //        {
            //            int unid = Convert.ToInt32(dgv9.Rows[n].Cells[2].Value);

            //            double asig_mod1 = 0, asig_mod2 = 0;
            //            asig_mod1 = (asignacion20 * 0.01) * (unid);
            //            asig_mod2 = (asignacion80 * 0.01) * (unid);


            //            dgv9.Rows[n].Cells[6].Value = asig_mod1.ToString("N0");
            //            dgv9.Rows[n].Cells[7].Value = asig_mod2.ToString("N0");
            //        }
            //        #endregion
            //        #region profundidad
            //        for (int n = 0; n < dgv9.RowCount; n++)
            //        {

            //            string ren4 = Convert.ToString(dgv9.Rows[n].Cells[4].Value);
            //            string ren5 = Convert.ToString(dgv9.Rows[n].Cells[5].Value);
            //            string ren6 = Convert.ToString(dgv9.Rows[n].Cells[6].Value);
            //            string ren7 = Convert.ToString(dgv9.Rows[n].Cells[7].Value);
            //            ren4 = ren4.Replace(",", ""); ren5 = ren5.Replace(",", ""); ren6 = ren6.Replace(",", ""); ren7 = ren7.Replace(",", "");
            //            double v1, v2, v3, v4 = 0;
            //            v1 = Convert.ToDouble(ren4); v2 = Convert.ToDouble(ren5); v3 = Convert.ToDouble(ren6); v4 = Convert.ToDouble(ren7);
            //            prof20 = v1 / v3;
            //            prof80 = v2 / v4;

            //            dgv9.Rows[n].Cells[8].Value = prof20.ToString("N0");
            //            dgv9.Rows[n].Cells[9].Value = prof80.ToString("N0");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 8
            //        for (int n = 0; n < dgv9.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv9.Rows[n].Cells[8].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv9.Rows[n].Cells[8].Value = 0; }
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 9
            //        for (int n = 0; n < dgv9.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv9.Rows[n].Cells[9].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv9.Rows[n].Cells[9].Value = 0.00; }
            //        }
            //        #endregion
            //        #endregion
            //        break;
            //    case 10:
            //        #region calculos dgv10
            //        #region eliminar Nan NeuN
            //        for (int n = 0; n < dgv10.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv10.Rows[n].Cells[1].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null)
            //            { dgv10.Rows[n].Cells[1].Value = 0.00; }
            //        }
            //        #endregion
            //        #region asignacion
            //        for (int n = 0; n < dgv10.RowCount; n++)
            //        {
            //            double asignacion = 0;
            //            asignacion = (Convert.ToDouble(tb_UnidCompr.Text) * (0.01 * (Convert.ToDouble(dgv10.Rows[n].Cells[1].Value))));
            //            dgv10.Rows[n].Cells[3].Value = asignacion.ToString("N0");
            //        }
            //        #endregion
            //        #region ponderacion
            //        for (int n = 0; n < dgv10.RowCount; n++)
            //        {
            //            string pond = Convert.ToString(dgv10.Rows[n].Cells[3].Value);
            //            pond = pond.Trim(',');
            //            double pond_tod = Convert.ToDouble(pond);
            //            double pond1 = 0, pond2 = 0;
            //            pond1 = (ponderacion80 * 0.01) * (pond_tod);
            //            pond2 = (ponderacion20 * 0.01) * (pond_tod);


            //            dgv10.Rows[n].Cells[4].Value = pond1.ToString("N0");
            //            dgv10.Rows[n].Cells[5].Value = pond2.ToString("N0");
            //        }
            //        #endregion
            //        #region asignacion modelos
            //        for (int n = 0; n < dgv10.RowCount; n++)
            //        {
            //            int unid = Convert.ToInt32(dgv10.Rows[n].Cells[2].Value);

            //            double asig_mod1 = 0, asig_mod2 = 0;
            //            asig_mod1 = (asignacion20 * 0.01) * (unid);
            //            asig_mod2 = (asignacion80 * 0.01) * (unid);


            //            dgv10.Rows[n].Cells[6].Value = asig_mod1.ToString("N0");
            //            dgv10.Rows[n].Cells[7].Value = asig_mod2.ToString("N0");
            //        }
            //        #endregion
            //        #region profundidad
            //        for (int n = 0; n < dgv10.RowCount; n++)
            //        {

            //            string ren4 = Convert.ToString(dgv10.Rows[n].Cells[4].Value);
            //            string ren5 = Convert.ToString(dgv10.Rows[n].Cells[5].Value);
            //            string ren6 = Convert.ToString(dgv10.Rows[n].Cells[6].Value);
            //            string ren7 = Convert.ToString(dgv10.Rows[n].Cells[7].Value);
            //            ren4 = ren4.Replace(",", ""); ren5 = ren5.Replace(",", ""); ren6 = ren6.Replace(",", ""); ren7 = ren7.Replace(",", "");
            //            double v1, v2, v3, v4 = 0;
            //            v1 = Convert.ToDouble(ren4); v2 = Convert.ToDouble(ren5); v3 = Convert.ToDouble(ren6); v4 = Convert.ToDouble(ren7);
            //            prof20 = v1 / v3;
            //            prof80 = v2 / v4;

            //            dgv10.Rows[n].Cells[8].Value = prof20.ToString("N0");
            //            dgv10.Rows[n].Cells[9].Value = prof80.ToString("N0");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 8
            //        for (int n = 0; n < dgv10.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv10.Rows[n].Cells[8].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv10.Rows[n].Cells[8].Value = 0; }
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 9
            //        for (int n = 0; n < dgv10.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv10.Rows[n].Cells[9].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv10.Rows[n].Cells[9].Value = 0.00; }
            //        }
            //        #endregion
            //        #endregion
            //        break;
            //    case 11:
            //        #region calculos dgv11
            //        #region eliminar Nan NeuN
            //        for (int n = 0; n < dgv11.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv11.Rows[n].Cells[1].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null)
            //            { dgv11.Rows[n].Cells[1].Value = 0.00; }
            //        }
            //        #endregion
            //        #region asignacion
            //        for (int n = 0; n < dgv11.RowCount; n++)
            //        {
            //            double asignacion = 0;
            //            asignacion = (Convert.ToDouble(tb_UnidCompr.Text) * (0.01 * (Convert.ToDouble(dgv11.Rows[n].Cells[1].Value))));
            //            dgv11.Rows[n].Cells[3].Value = asignacion.ToString("N0");
            //        }
            //        #endregion
            //        #region ponderacion
            //        for (int n = 0; n < dgv11.RowCount; n++)
            //        {
            //            string pond = Convert.ToString(dgv11.Rows[n].Cells[3].Value);
            //            pond = pond.Trim(',');
            //            double pond_tod = Convert.ToDouble(pond);
            //            double pond1 = 0, pond2 = 0;
            //            pond1 = (ponderacion80 * 0.01) * (pond_tod);
            //            pond2 = (ponderacion20 * 0.01) * (pond_tod);


            //            dgv11.Rows[n].Cells[4].Value = pond1.ToString("N0");
            //            dgv11.Rows[n].Cells[5].Value = pond2.ToString("N0");
            //        }
            //        #endregion
            //        #region asignacion modelos
            //        for (int n = 0; n < dgv11.RowCount; n++)
            //        {
            //            int unid = Convert.ToInt32(dgv11.Rows[n].Cells[2].Value);

            //            double asig_mod1 = 0, asig_mod2 = 0;
            //            asig_mod1 = (asignacion20 * 0.01) * (unid);
            //            asig_mod2 = (asignacion80 * 0.01) * (unid);


            //            dgv11.Rows[n].Cells[6].Value = asig_mod1.ToString("N0");
            //            dgv11.Rows[n].Cells[7].Value = asig_mod2.ToString("N0");
            //        }
            //        #endregion
            //        #region profundidad
            //        for (int n = 0; n < dgv11.RowCount; n++)
            //        {

            //            string ren4 = Convert.ToString(dgv11.Rows[n].Cells[4].Value);
            //            string ren5 = Convert.ToString(dgv11.Rows[n].Cells[5].Value);
            //            string ren6 = Convert.ToString(dgv11.Rows[n].Cells[6].Value);
            //            string ren7 = Convert.ToString(dgv11.Rows[n].Cells[7].Value);
            //            ren4 = ren4.Replace(",", ""); ren5 = ren5.Replace(",", ""); ren6 = ren6.Replace(",", ""); ren7 = ren7.Replace(",", "");
            //            double v1, v2, v3, v4 = 0;
            //            v1 = Convert.ToDouble(ren4); v2 = Convert.ToDouble(ren5); v3 = Convert.ToDouble(ren6); v4 = Convert.ToDouble(ren7);
            //            prof20 = v1 / v3;
            //            prof80 = v2 / v4;

            //            dgv11.Rows[n].Cells[8].Value = prof20.ToString("N0");
            //            dgv11.Rows[n].Cells[9].Value = prof80.ToString("N0");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 8
            //        for (int n = 0; n < dgv11.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv11.Rows[n].Cells[8].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv11.Rows[n].Cells[8].Value = 0; }
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 9
            //        for (int n = 0; n < dgv11.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv11.Rows[n].Cells[9].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv11.Rows[n].Cells[9].Value = 0.00; }
            //        }
            //        #endregion
            //        #endregion
            //        break;
            //    case 12:
            //        #region calculos dgv12
            //        #region eliminar Nan NeuN
            //        for (int n = 0; n < dgv12.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv12.Rows[n].Cells[1].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null)
            //            { dgv12.Rows[n].Cells[1].Value = 0.00; }
            //        }
            //        #endregion
            //        #region asignacion
            //        for (int n = 0; n < dgv12.RowCount; n++)
            //        {
            //            double asignacion = 0;
            //            asignacion = (Convert.ToDouble(tb_UnidCompr.Text) * (0.01 * (Convert.ToDouble(dgv12.Rows[n].Cells[1].Value))));
            //            dgv12.Rows[n].Cells[3].Value = asignacion.ToString("N0");
            //        }
            //        #endregion
            //        #region ponderacion
            //        for (int n = 0; n < dgv12.RowCount; n++)
            //        {
            //            string pond = Convert.ToString(dgv12.Rows[n].Cells[3].Value);
            //            pond = pond.Trim(',');
            //            double pond_tod = Convert.ToDouble(pond);
            //            double pond1 = 0, pond2 = 0;
            //            pond1 = (ponderacion80 * 0.01) * (pond_tod);
            //            pond2 = (ponderacion20 * 0.01) * (pond_tod);


            //            dgv12.Rows[n].Cells[4].Value = pond1.ToString("N0");
            //            dgv12.Rows[n].Cells[5].Value = pond2.ToString("N0");
            //        }
            //        #endregion
            //        #region asignacion modelos
            //        for (int n = 0; n < dgv12.RowCount; n++)
            //        {
            //            int unid = Convert.ToInt32(dgv12.Rows[n].Cells[2].Value);

            //            double asig_mod1 = 0, asig_mod2 = 0;
            //            asig_mod1 = (asignacion20 * 0.01) * (unid);
            //            asig_mod2 = (asignacion80 * 0.01) * (unid);


            //            dgv12.Rows[n].Cells[6].Value = asig_mod1.ToString("N0");
            //            dgv12.Rows[n].Cells[7].Value = asig_mod2.ToString("N0");
            //        }
            //        #endregion
            //        #region profundidad
            //        for (int n = 0; n < dgv12.RowCount; n++)
            //        {

            //            string ren4 = Convert.ToString(dgv12.Rows[n].Cells[4].Value);
            //            string ren5 = Convert.ToString(dgv12.Rows[n].Cells[5].Value);
            //            string ren6 = Convert.ToString(dgv12.Rows[n].Cells[6].Value);
            //            string ren7 = Convert.ToString(dgv12.Rows[n].Cells[7].Value);
            //            ren4 = ren4.Replace(",", ""); ren5 = ren5.Replace(",", ""); ren6 = ren6.Replace(",", ""); ren7 = ren7.Replace(",", "");
            //            double v1, v2, v3, v4 = 0;
            //            v1 = Convert.ToDouble(ren4); v2 = Convert.ToDouble(ren5); v3 = Convert.ToDouble(ren6); v4 = Convert.ToDouble(ren7);
            //            prof20 = v1 / v3;
            //            prof80 = v2 / v4;

            //            dgv12.Rows[n].Cells[8].Value = prof20.ToString("N0");
            //            dgv12.Rows[n].Cells[9].Value = prof80.ToString("N0");
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 8
            //        for (int n = 0; n < dgv12.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv12.Rows[n].Cells[8].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv12.Rows[n].Cells[8].Value = 0; }
            //        }
            //        #endregion
            //        #region eliminar Nan NeuN 9
            //        for (int n = 0; n < dgv12.RowCount; n++)
            //        {
            //            string valor = Convert.ToString(dgv12.Rows[n].Cells[9].Value);
            //            if (valor == "NaN" || valor == "NeuN" || valor == null || valor == "Infinito")
            //            { dgv12.Rows[n].Cells[9].Value = 0.00; }
            //        }
            //        #endregion
            //        #endregion
            //        break;
            //    case 13: break;

            //}


        }
        public void m_DIASMESESANOS_guardarT(string fecha_inicio, string fecha_final) /////////////////////////////se usa en todos 
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
                            comprobar_guardarT(fecha_inicio_ano, fecha_inicio_mes, i);
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
                            comprobar_guardarT(fecha_inicio_ano, fecha_inicio_mes, i);
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
        public bool comprobar_guardarT(int año, int mes, int i)
        {
            bool comprobar = true;
                string s = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and anio=" + año + " and mes=" + mes + " and ZapateriasTorreon=1";
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
                    insertarT(año, mes, i, 0);
                }
                else
                {
                    updateT(año, mes, i, 0);
                }
            return true;
        }
        public void insertarT(int año, int mes, int grid, int renglon)
        {
            double c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15;
            switch (grid)
            {
                case 1:
                    #region insertar dgv1
                    c1 = double.Parse(dgv1.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv1.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv1.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv1.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv1.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv1.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv1.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv1.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv1.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv1.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv1.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgv1.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgv1.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgv1.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgv1.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    string qinsert = "insert into cedula8 (nombre,ModelosvendidosH,PorcentajeMH,ParesvendidosH,ModeloscompraP,PorcentajeMP,paresCompraP,Parescompra80,Parescompra20,modelosCompraA,modelosCompraB,profundidadA,profundidadB,mes,anio,ZapateriasTorreon) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + mes.ToString() + "," + año.ToString() + ",1)";
                    cmd = new MySqlCommand(qinsert, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 2:
                    #region insertar dgv1
                    c1 = double.Parse(dgv2.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv2.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv2.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv2.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv2.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv2.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv2.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv2.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv2.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv2.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgv2.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgv2.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgv2.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgv2.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qinsert = "insert into cedula8 (nombre,ModelosvendidosH,PorcentajeMH,ParesvendidosH,ModeloscompraP,PorcentajeMP,paresCompraP,Parescompra80,Parescompra20,modelosCompraA,modelosCompraB,profundidadA,profundidadB,mes,anio,ZapateriasTorreon) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + mes.ToString() + "," + año.ToString() + ",1)";
                    cmd = new MySqlCommand(qinsert, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 3:
                    #region insertar dgv3
                    c1 = double.Parse(dgv3.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv3.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv3.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv3.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv3.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv3.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv3.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv3.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv3.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv3.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv3.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgv3.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgv3.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgv3.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgv3.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qinsert = "insert into cedula8 (nombre,ModelosvendidosH,PorcentajeMH,ParesvendidosH,ModeloscompraP,PorcentajeMP,paresCompraP,Parescompra80,Parescompra20,modelosCompraA,modelosCompraB,profundidadA,profundidadB,mes,anio,ZapateriasTorreon) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + mes.ToString() + "," + año.ToString() + ",1)";
                    cmd = new MySqlCommand(qinsert, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 4:
                    #region insertar dgv1
                    c1 = double.Parse(dgv4.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv4.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv4.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv4.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv4.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv4.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv4.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv4.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv4.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv4.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv4.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgv4.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgv4.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgv4.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgv4.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qinsert = "insert into cedula8 (nombre,ModelosvendidosH,PorcentajeMH,ParesvendidosH,ModeloscompraP,PorcentajeMP,paresCompraP,Parescompra80,Parescompra20,modelosCompraA,modelosCompraB,profundidadA,profundidadB,mes,anio,ZapateriasTorreon) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + mes.ToString() + "," + año.ToString() + ",1)";
                    cmd = new MySqlCommand(qinsert, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 5:
                    #region insertar dgv5
                    c1 = double.Parse(dgv5.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv5.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv5.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv5.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv5.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv5.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv5.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv5.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv5.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv5.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv5.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgv5.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgv5.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgv5.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgv5.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                   qinsert = "insert into cedula8 (nombre,ModelosvendidosH,PorcentajeMH,ParesvendidosH,ModeloscompraP,PorcentajeMP,paresCompraP,Parescompra80,Parescompra20,modelosCompraA,modelosCompraB,profundidadA,profundidadB,mes,anio,ZapateriasTorreon) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + mes.ToString() + "," + año.ToString() + ",1)";
                    cmd = new MySqlCommand(qinsert, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 6:
                    #region insertar dgv6
                    c1 = double.Parse(dgv6.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv6.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv6.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv6.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv6.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv6.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv6.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv6.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv6.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv6.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv6.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgv6.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgv6.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgv6.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgv6.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qinsert = "insert into cedula8 (nombre,ModelosvendidosH,PorcentajeMH,ParesvendidosH,ModeloscompraP,PorcentajeMP,paresCompraP,Parescompra80,Parescompra20,modelosCompraA,modelosCompraB,profundidadA,profundidadB,mes,anio,ZapateriasTorreon) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + mes.ToString() + "," + año.ToString() + ",1)";
                    cmd = new MySqlCommand(qinsert, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 7:
                    #region insertar dgv7
                    c1 = double.Parse(dgv7.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv7.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv7.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv7.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv7.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv7.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv7.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv7.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv7.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv7.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv7.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgv7.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgv7.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgv7.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgv7.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qinsert = "insert into cedula8 (nombre,ModelosvendidosH,PorcentajeMH,ParesvendidosH,ModeloscompraP,PorcentajeMP,paresCompraP,Parescompra80,Parescompra20,modelosCompraA,modelosCompraB,profundidadA,profundidadB,mes,anio,ZapateriasTorreon) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + mes.ToString() + "," + año.ToString() + ",1)";
                    cmd = new MySqlCommand(qinsert, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 8:
                    #region insertar dgv8
                    c1 = double.Parse(dgv8.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv8.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv8.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv8.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv8.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv8.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv8.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv8.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv8.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv8.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv8.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgv8.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgv8.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgv8.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgv8.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qinsert = "insert into cedula8 (nombre,ModelosvendidosH,PorcentajeMH,ParesvendidosH,ModeloscompraP,PorcentajeMP,paresCompraP,Parescompra80,Parescompra20,modelosCompraA,modelosCompraB,profundidadA,profundidadB,mes,anio,ZapateriasTorreon) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + mes.ToString() + "," + año.ToString() + ",1)";
                    cmd = new MySqlCommand(qinsert, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 9:
                    #region insertar dgv9
                    c1 = double.Parse(dgv9.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv9.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv9.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv9.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv9.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv9.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv9.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv9.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv9.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv9.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv9.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgv9.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgv9.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgv9.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgv9.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qinsert = "insert into cedula8 (nombre,ModelosvendidosH,PorcentajeMH,ParesvendidosH,ModeloscompraP,PorcentajeMP,paresCompraP,Parescompra80,Parescompra20,modelosCompraA,modelosCompraB,profundidadA,profundidadB,mes,anio,ZapateriasTorreon) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + mes.ToString() + "," + año.ToString() + ",1)";
                    cmd = new MySqlCommand(qinsert, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 10:
                    #region insertar dgv1
                    c1 = double.Parse(dgv10.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv10.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv10.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv10.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv10.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv10.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv10.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv10.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv10.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv10.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv10.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgv10.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgv10.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgv10.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgv10.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qinsert = "insert into cedula8 (nombre,ModelosvendidosH,PorcentajeMH,ParesvendidosH,ModeloscompraP,PorcentajeMP,paresCompraP,Parescompra80,Parescompra20,modelosCompraA,modelosCompraB,profundidadA,profundidadB,mes,anio,ZapateriasTorreon) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + mes.ToString() + "," + año.ToString() + ",1)";
                    cmd = new MySqlCommand(qinsert, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 11:
                    #region insertar dgv11
                    c1 = double.Parse(dgv11.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv11.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv11.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv11.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv11.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv11.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv11.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv11.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv11.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv11.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv11.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgv11.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgv11.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgv11.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgv11.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qinsert = "insert into cedula8 (nombre,ModelosvendidosH,PorcentajeMH,ParesvendidosH,ModeloscompraP,PorcentajeMP,paresCompraP,Parescompra80,Parescompra20,modelosCompraA,modelosCompraB,profundidadA,profundidadB,mes,anio,ZapateriasTorreon) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + mes.ToString() + "," + año.ToString() + ",1)";
                    cmd = new MySqlCommand(qinsert, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 12:
                    #region insertar dgv12
                    c1 = double.Parse(dgv12.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv12.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv12.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv12.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv12.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv12.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv12.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv12.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv12.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv12.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv12.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    c12 = double.Parse(dgv12.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgv12.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgv12.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgv12.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qinsert = "insert into cedula8 (nombre,ModelosvendidosH,PorcentajeMH,ParesvendidosH,ModeloscompraP,PorcentajeMP,paresCompraP,Parescompra80,Parescompra20,modelosCompraA,modelosCompraB,profundidadA,profundidadB,mes,anio,ZapateriasTorreon) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + "," + c9.ToString() + "," + c10.ToString() + "," + c11.ToString() + "," + c12.ToString() + "," + mes.ToString() + "," + año.ToString() + ",1)";
                    cmd = new MySqlCommand(qinsert, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
            }
        }
        public void updateT(int año, int mes, int grid, int renglon)
        {
            double c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15;
            switch (grid)
            {
                case 1:
                    #region insertar dgv1
                    c1 = double.Parse(dgv1.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv1.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv1.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv1.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv1.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv1.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv1.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv1.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv1.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv1.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv1.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    //c12 = double.Parse(dgv1.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgvProf1.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgvProf1.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgvProf1.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    string qupdate = "update cedula8 set ModelosvendidosH=" + c1.ToString() + ",PorcentajeMH=" + c2.ToString() + ",ModeloscompraP=" + c3.ToString() + ",PorcentajeMP=" + c4.ToString() + ",paresCompraP=" + c5.ToString() + ",Parescompra80=" + c6.ToString() + ",Parescompra20=" + c7.ToString() + ",modeloscompraA=" + c8.ToString() + ",modeloscompraB=" + c9.ToString() + ",profundidadA=" + c10.ToString() + ",profundidadB=" + c11.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " and ZapateriasTorreon=1" ;
                    cmd = new MySqlCommand(qupdate, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 2:
                    #region insertar dgv2
                    c1 = double.Parse(dgv2.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv2.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv2.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv2.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv2.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv2.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv2.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv2.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv2.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv2.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    //c12 = double.Parse(dgv2.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgvProf1.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgvProf1.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgvProf1.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                     qupdate = "update cedula8 set ModelosvendidosH=" + c1.ToString() + ",PorcentajeMH=" + c2.ToString() + ",ModeloscompraP=" + c3.ToString() + ",PorcentajeMP=" + c4.ToString() + ",paresCompraP=" + c5.ToString() + ",Parescompra80=" + c6.ToString() + ",Parescompra20=" + c7.ToString() + ",modeloscompraA=" + c8.ToString() + ",modeloscompraB=" + c9.ToString() + ",profundidadA=" + c10.ToString() + ",profundidadB=" + c11.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " and ZapateriasTorreon=1" ;
                    cmd = new MySqlCommand(qupdate, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 3:
                    #region insertar dgv3
                    c1 = double.Parse(dgv3.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv3.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv3.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv3.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv3.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv3.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv3.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv3.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv3.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv3.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv3.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    //c12 = double.Parse(dgv3.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgvProf1.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgvProf1.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgvProf1.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                     qupdate = "update cedula8 set ModelosvendidosH=" + c1.ToString() + ",PorcentajeMH=" + c2.ToString() + ",ModeloscompraP=" + c3.ToString() + ",PorcentajeMP=" + c4.ToString() + ",paresCompraP=" + c5.ToString() + ",Parescompra80=" + c6.ToString() + ",Parescompra20=" + c7.ToString() + ",modeloscompraA=" + c8.ToString() + ",modeloscompraB=" + c9.ToString() + ",profundidadA=" + c10.ToString() + ",profundidadB=" + c11.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " and ZapateriasTorreon=1" ;
                    cmd = new MySqlCommand(qupdate, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 4:
                    #region insertar dgv4
                    c1 = double.Parse(dgv4.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv4.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv4.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv4.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv4.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv4.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv4.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv4.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv4.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv4.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv4.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    //c12 = double.Parse(dgv4.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgvProf1.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgvProf1.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgvProf1.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                     qupdate = "update cedula8 set ModelosvendidosH=" + c1.ToString() + ",PorcentajeMH=" + c2.ToString() + ",ModeloscompraP=" + c3.ToString() + ",PorcentajeMP=" + c4.ToString() + ",paresCompraP=" + c5.ToString() + ",Parescompra80=" + c6.ToString() + ",Parescompra20=" + c7.ToString() + ",modeloscompraA=" + c8.ToString() + ",modeloscompraB=" + c9.ToString() + ",profundidadA=" + c10.ToString() + ",profundidadB=" + c11.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " and ZapateriasTorreon=1" ;
                    cmd = new MySqlCommand(qupdate, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 5:
                    #region insertar dgv5
                    c1 = double.Parse(dgv5.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv5.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv5.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv5.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv5.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv5.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv5.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv5.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv5.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv5.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv5.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    //c12 = double.Parse(dgv5.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgvProf1.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgvProf1.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgvProf1.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qupdate = "update cedula8 set ModelosvendidosH=" + c1.ToString() + ",PorcentajeMH=" + c2.ToString() + ",ModeloscompraP=" + c3.ToString() + ",PorcentajeMP=" + c4.ToString() + ",paresCompraP=" + c5.ToString() + ",Parescompra80=" + c6.ToString() + ",Parescompra20=" + c7.ToString() + ",modeloscompraA=" + c8.ToString() + ",modeloscompraB=" + c9.ToString() + ",profundidadA=" + c10.ToString() + ",profundidadB=" + c11.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " and ZapateriasTorreon=1" ;
                    cmd = new MySqlCommand(qupdate, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 6:
                    #region insertar dgv6
                    c1 = double.Parse(dgv6.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv6.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv6.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv6.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv6.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv6.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv6.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv6.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv6.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv6.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv6.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    //c12 = double.Parse(dgv6.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgvProf1.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgvProf1.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgvProf1.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                     qupdate = "update cedula8 set ModelosvendidosH=" + c1.ToString() + ",PorcentajeMH=" + c2.ToString() + ",ModeloscompraP=" + c3.ToString() + ",PorcentajeMP=" + c4.ToString() + ",paresCompraP=" + c5.ToString() + ",Parescompra80=" + c6.ToString() + ",Parescompra20=" + c7.ToString() + ",modeloscompraA=" + c8.ToString() + ",modeloscompraB=" + c9.ToString() + ",profundidadA=" + c10.ToString() + ",profundidadB=" + c11.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " and ZapateriasTorreon=1" ;
                    cmd = new MySqlCommand(qupdate, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 7:
                    #region insertar dgv7
                    c1 = double.Parse(dgv7.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv7.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv7.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv7.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv7.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv7.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv7.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv7.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv7.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv7.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv7.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    //c12 = double.Parse(dgv7.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgvProf1.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgvProf1.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgvProf1.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                     qupdate = "update cedula8 set ModelosvendidosH=" + c1.ToString() + ",PorcentajeMH=" + c2.ToString() + ",ModeloscompraP=" + c3.ToString() + ",PorcentajeMP=" + c4.ToString() + ",paresCompraP=" + c5.ToString() + ",Parescompra80=" + c6.ToString() + ",Parescompra20=" + c7.ToString() + ",modeloscompraA=" + c8.ToString() + ",modeloscompraB=" + c9.ToString() + ",profundidadA=" + c10.ToString() + ",profundidadB=" + c11.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " and ZapateriasTorreon=1" ;
                    cmd = new MySqlCommand(qupdate, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 8:
                    #region insertar dgv8
                    c1 = double.Parse(dgv8.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv8.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv8.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv8.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv8.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv8.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv8.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv8.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv8.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv8.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv8.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    //c12 = double.Parse(dgv8.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgvProf1.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgvProf1.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgvProf1.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                     qupdate = "update cedula8 set ModelosvendidosH=" + c1.ToString() + ",PorcentajeMH=" + c2.ToString() + ",ModeloscompraP=" + c3.ToString() + ",PorcentajeMP=" + c4.ToString() + ",paresCompraP=" + c5.ToString() + ",Parescompra80=" + c6.ToString() + ",Parescompra20=" + c7.ToString() + ",modeloscompraA=" + c8.ToString() + ",modeloscompraB=" + c9.ToString() + ",profundidadA=" + c10.ToString() + ",profundidadB=" + c11.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " and ZapateriasTorreon=1" ;
                    cmd = new MySqlCommand(qupdate, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 9:
                    #region insertar dgv9
                    c1 = double.Parse(dgv9.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv9.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv9.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv9.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv9.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv9.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv9.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv9.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv9.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv9.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv9.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    //c12 = double.Parse(dgv9.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgvProf1.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgvProf1.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgvProf1.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                     qupdate = "update cedula8 set ModelosvendidosH=" + c1.ToString() + ",PorcentajeMH=" + c2.ToString() + ",ModeloscompraP=" + c3.ToString() + ",PorcentajeMP=" + c4.ToString() + ",paresCompraP=" + c5.ToString() + ",Parescompra80=" + c6.ToString() + ",Parescompra20=" + c7.ToString() + ",modeloscompraA=" + c8.ToString() + ",modeloscompraB=" + c9.ToString() + ",profundidadA=" + c10.ToString() + ",profundidadB=" + c11.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " and ZapateriasTorreon=1" ;
                    cmd = new MySqlCommand(qupdate, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 10:
                    #region insertar dgv10
                    c1 = double.Parse(dgv10.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv10.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv10.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv10.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv10.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv10.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv10.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv10.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv10.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv10.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv10.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    //c12 = double.Parse(dgv10.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgvProf1.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgvProf1.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgvProf1.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                     qupdate = "update cedula8 set ModelosvendidosH=" + c1.ToString() + ",PorcentajeMH=" + c2.ToString() + ",ModeloscompraP=" + c3.ToString() + ",PorcentajeMP=" + c4.ToString() + ",paresCompraP=" + c5.ToString() + ",Parescompra80=" + c6.ToString() + ",Parescompra20=" + c7.ToString() + ",modeloscompraA=" + c8.ToString() + ",modeloscompraB=" + c9.ToString() + ",profundidadA=" + c10.ToString() + ",profundidadB=" + c11.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " and ZapateriasTorreon=1" ;
                    cmd = new MySqlCommand(qupdate, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 11:
                    #region insertar dgv11
                    c1 = double.Parse(dgv11.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv11.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv11.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv11.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv11.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv11.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv11.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv11.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv11.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv11.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv11.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    //c12 = double.Parse(dgv11.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgvProf1.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgvProf1.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgvProf1.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                    qupdate = "update cedula8 set ModelosvendidosH=" + c1.ToString() + ",PorcentajeMH=" + c2.ToString() + ",ModeloscompraP=" + c3.ToString() + ",PorcentajeMP=" + c4.ToString() + ",paresCompraP=" + c5.ToString() + ",Parescompra80=" + c6.ToString() + ",Parescompra20=" + c7.ToString() + ",modeloscompraA=" + c8.ToString() + ",modeloscompraB=" + c9.ToString() + ",profundidadA=" + c10.ToString() + ",profundidadB=" + c11.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " and ZapateriasTorreon=1" ;
                    cmd = new MySqlCommand(qupdate, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
                case 12:
                    #region insertar dgv12
                    c1 = double.Parse(dgv12.Rows[renglon].Cells[1].Value.ToString(), NumberStyles.Currency);
                    c2 = double.Parse(dgv12.Rows[renglon].Cells[2].Value.ToString(), NumberStyles.Currency);
                    c3 = double.Parse(dgv12.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
                    c4 = double.Parse(dgv12.Rows[renglon].Cells[4].Value.ToString(), NumberStyles.Currency);
                    c5 = double.Parse(dgv12.Rows[renglon].Cells[5].Value.ToString(), NumberStyles.Currency);
                    c6 = double.Parse(dgv12.Rows[renglon].Cells[6].Value.ToString(), NumberStyles.Currency);
                    c7 = double.Parse(dgv12.Rows[renglon].Cells[7].Value.ToString(), NumberStyles.Currency);
                    c8 = double.Parse(dgv12.Rows[renglon].Cells[8].Value.ToString(), NumberStyles.Currency);
                    c9 = double.Parse(dgv12.Rows[renglon].Cells[9].Value.ToString(), NumberStyles.Currency);
                    c10 = double.Parse(dgv12.Rows[renglon].Cells[10].Value.ToString(), NumberStyles.Currency);
                    c11 = double.Parse(dgv12.Rows[renglon].Cells[11].Value.ToString(), NumberStyles.Currency);
                    //c12 = double.Parse(dgv12.Rows[renglon].Cells[12].Value.ToString(), NumberStyles.Currency);
                    //c13 = double.Parse(dgvProf1.Rows[renglon].Cells[13].Value.ToString(), NumberStyles.Currency);
                    //c14 = double.Parse(dgvProf1.Rows[renglon].Cells[14].Value.ToString(), NumberStyles.Currency);
                    //c15 = double.Parse(dgvProf1.Rows[renglon].Cells[15].Value.ToString(), NumberStyles.Currency);
                     qupdate = "update cedula8 set ModelosvendidosH=" + c1.ToString() + ",PorcentajeMH=" + c2.ToString() + ",ModeloscompraP=" + c3.ToString() + ",PorcentajeMP=" + c4.ToString() + ",paresCompraP=" + c5.ToString() + ",Parescompra80=" + c6.ToString() + ",Parescompra20=" + c7.ToString() + ",modeloscompraA=" + c8.ToString() + ",modeloscompraB=" + c9.ToString() + ",profundidadA=" + c10.ToString() + ",profundidadB=" + c11.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " and ZapateriasTorreon=1" ;
                    cmd = new MySqlCommand(qupdate, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
            }
        }
        private bool comprobarCargarT(int año, int mes, int i)
        {
            bool comprobar = true;
            string s = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and anio=" + año + " and mes=" + mes + " and ZapateriasTorreon=1";
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
        private void cargarT(int mes, int año, int g)
        {

            double c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15;
            switch (g)
            {
                case 1:
                    #region cargar grid1
                    for (int x = 0; x <= dgv1.Rows.Count-1; x++)
                    {
                        string sqload = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and ZapateriasTorreon=1";
                        cmd = new MySqlCommand(sqload, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["ModelosvendidosH"].ToString());
                            c2 = double.Parse(reader["PorcentajeMH"].ToString());
                            c3 = double.Parse(reader["ParesvendidosH"].ToString());
                            c4 = double.Parse(reader["ModeloscompraP"].ToString());
                            c5 = double.Parse(reader["PorcentajeMP"].ToString());
                            c6 = double.Parse(reader["paresCompraP"].ToString());
                            c7 = double.Parse(reader["Parescompra80"].ToString());
                            c8 = double.Parse(reader["Parescompra20"].ToString());
                            c9 = double.Parse(reader["modeloscompraA"].ToString());
                            c10 = double.Parse(reader["modeloscompraB"].ToString());
                            c11 = double.Parse(reader["profundidadA"].ToString());
                            c12 = double.Parse(reader["profundidadB"].ToString());

                            dgv1.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv1.Rows[x].Cells[2].Value = c2.ToString("N2");
                            dgv1.Rows[x].Cells[3].Value = c3.ToString("N2");
                            dgv1.Rows[x].Cells[4].Value = c4.ToString("N0");
                            dgv1.Rows[x].Cells[5].Value = c5.ToString("N0");
                            dgv1.Rows[x].Cells[6].Value = c6.ToString("N2");
                            dgv1.Rows[x].Cells[7].Value = c7.ToString("N0");
                            dgv1.Rows[x].Cells[8].Value = c8.ToString("N2");
                            dgv1.Rows[x].Cells[9].Value = c9.ToString("N2");
                            dgv1.Rows[x].Cells[10].Value = c10.ToString("N2");
                            dgv1.Rows[x].Cells[11].Value = c11.ToString("N2");
                            dgv1.Rows[x].Cells[12].Value = c12.ToString("N2");

                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 2:
                    #region cargar grid1
                    for (int x = 0; x <= dgv2.Rows.Count - 1; x++)
                    {
                       string qloads = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and ZapateriasTorreon=1";
                        cmd = new MySqlCommand(qloads, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["ModelosvendidosH"].ToString());
                            c2 = double.Parse(reader["PorcentajeMH"].ToString());
                            c3 = double.Parse(reader["ParesvendidosH"].ToString());
                            c4 = double.Parse(reader["ModeloscompraP"].ToString());
                            c5 = double.Parse(reader["PorcentajeMP"].ToString());
                            c6 = double.Parse(reader["paresCompraP"].ToString());
                            c7 = double.Parse(reader["Parescompra80"].ToString());
                            c8 = double.Parse(reader["Parescompra20"].ToString());
                            c9 = double.Parse(reader["modeloscompraA"].ToString());
                            c10 = double.Parse(reader["modeloscompraB"].ToString());
                            c11 = double.Parse(reader["profundidadA"].ToString());
                            c12 = double.Parse(reader["profundidadB"].ToString());

                            dgv2.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv2.Rows[x].Cells[2].Value = c2.ToString("N2");
                            dgv2.Rows[x].Cells[3].Value = c3.ToString("N2");
                            dgv2.Rows[x].Cells[4].Value = c4.ToString("N0");
                            dgv2.Rows[x].Cells[5].Value = c5.ToString("N0");
                            dgv2.Rows[x].Cells[6].Value = c6.ToString("N2");
                            dgv2.Rows[x].Cells[7].Value = c7.ToString("N0");
                            dgv2.Rows[x].Cells[8].Value = c8.ToString("N2");
                            dgv2.Rows[x].Cells[9].Value = c9.ToString("N2");
                            dgv2.Rows[x].Cells[10].Value = c10.ToString("N2");
                            dgv2.Rows[x].Cells[11].Value = c11.ToString("N2");
                            dgv2.Rows[x].Cells[12].Value = c12.ToString("N2");

                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 3:
                    #region cargar grid1
                    for (int x = 0; x <= dgv1.Rows.Count - 1; x++)
                    {
                        string sqload = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and ZapateriasTorreon=1";
                        cmd = new MySqlCommand(sqload, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["ModelosvendidosH"].ToString());
                            c2 = double.Parse(reader["PorcentajeMH"].ToString());
                            c3 = double.Parse(reader["ParesvendidosH"].ToString());
                            c4 = double.Parse(reader["ModeloscompraP"].ToString());
                            c5 = double.Parse(reader["PorcentajeMP"].ToString());
                            c6 = double.Parse(reader["paresCompraP"].ToString());
                            c7 = double.Parse(reader["Parescompra80"].ToString());
                            c8 = double.Parse(reader["Parescompra20"].ToString());
                            c9 = double.Parse(reader["modeloscompraA"].ToString());
                            c10 = double.Parse(reader["modeloscompraB"].ToString());
                            c11 = double.Parse(reader["profundidadA"].ToString());
                            c12 = double.Parse(reader["profundidadB"].ToString());

                            dgv3.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv3.Rows[x].Cells[2].Value = c2.ToString("N2");
                            dgv3.Rows[x].Cells[3].Value = c3.ToString("N2");
                            dgv3.Rows[x].Cells[4].Value = c4.ToString("N0");
                            dgv3.Rows[x].Cells[5].Value = c5.ToString("N0");
                            dgv3.Rows[x].Cells[6].Value = c6.ToString("N2");
                            dgv3.Rows[x].Cells[7].Value = c7.ToString("N0");
                            dgv3.Rows[x].Cells[8].Value = c8.ToString("N2");
                            dgv3.Rows[x].Cells[9].Value = c9.ToString("N2");
                            dgv3.Rows[x].Cells[10].Value = c10.ToString("N2");
                            dgv3.Rows[x].Cells[11].Value = c11.ToString("N2");
                            dgv3.Rows[x].Cells[12].Value = c12.ToString("N2");

                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 4:
                    #region cargar grid1
                    for (int x = 0; x <= dgv1.Rows.Count - 1; x++)
                    {
                        string sqload = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and ZapateriasTorreon=1";
                        cmd = new MySqlCommand(sqload, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["ModelosvendidosH"].ToString());
                            c2 = double.Parse(reader["PorcentajeMH"].ToString());
                            c3 = double.Parse(reader["ParesvendidosH"].ToString());
                            c4 = double.Parse(reader["ModeloscompraP"].ToString());
                            c5 = double.Parse(reader["PorcentajeMP"].ToString());
                            c6 = double.Parse(reader["paresCompraP"].ToString());
                            c7 = double.Parse(reader["Parescompra80"].ToString());
                            c8 = double.Parse(reader["Parescompra20"].ToString());
                            c9 = double.Parse(reader["modeloscompraA"].ToString());
                            c10 = double.Parse(reader["modeloscompraB"].ToString());
                            c11 = double.Parse(reader["profundidadA"].ToString());
                            c12 = double.Parse(reader["profundidadB"].ToString());

                            dgv4.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv4.Rows[x].Cells[2].Value = c2.ToString("N2");
                            dgv4.Rows[x].Cells[3].Value = c3.ToString("N2");
                            dgv4.Rows[x].Cells[4].Value = c4.ToString("N0");
                            dgv4.Rows[x].Cells[5].Value = c5.ToString("N0");
                            dgv4.Rows[x].Cells[6].Value = c6.ToString("N2");
                            dgv4.Rows[x].Cells[7].Value = c7.ToString("N0");
                            dgv4.Rows[x].Cells[8].Value = c8.ToString("N2");
                            dgv4.Rows[x].Cells[9].Value = c9.ToString("N2");
                            dgv4.Rows[x].Cells[10].Value = c10.ToString("N2");
                            dgv4.Rows[x].Cells[11].Value = c11.ToString("N2");
                            dgv4.Rows[x].Cells[12].Value = c12.ToString("N2");

                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 5:
                    #region cargar grid1
                    for (int x = 0; x <= dgv1.Rows.Count - 1; x++)
                    {
                        string sqload = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and ZapateriasTorreon=1";
                        cmd = new MySqlCommand(sqload, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["ModelosvendidosH"].ToString());
                            c2 = double.Parse(reader["PorcentajeMH"].ToString());
                            c3 = double.Parse(reader["ParesvendidosH"].ToString());
                            c4 = double.Parse(reader["ModeloscompraP"].ToString());
                            c5 = double.Parse(reader["PorcentajeMP"].ToString());
                            c6 = double.Parse(reader["paresCompraP"].ToString());
                            c7 = double.Parse(reader["Parescompra80"].ToString());
                            c8 = double.Parse(reader["Parescompra20"].ToString());
                            c9 = double.Parse(reader["modeloscompraA"].ToString());
                            c10 = double.Parse(reader["modeloscompraB"].ToString());
                            c11 = double.Parse(reader["profundidadA"].ToString());
                            c12 = double.Parse(reader["profundidadB"].ToString());

                            dgv5.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv5.Rows[x].Cells[2].Value = c2.ToString("N2");
                            dgv5.Rows[x].Cells[3].Value = c3.ToString("N2");
                            dgv5.Rows[x].Cells[4].Value = c4.ToString("N0");
                            dgv5.Rows[x].Cells[5].Value = c5.ToString("N0");
                            dgv5.Rows[x].Cells[6].Value = c6.ToString("N2");
                            dgv5.Rows[x].Cells[7].Value = c7.ToString("N0");
                            dgv5.Rows[x].Cells[8].Value = c8.ToString("N2");
                            dgv5.Rows[x].Cells[9].Value = c9.ToString("N2");
                            dgv5.Rows[x].Cells[10].Value = c10.ToString("N2");
                            dgv5.Rows[x].Cells[11].Value = c11.ToString("N2");
                            dgv5.Rows[x].Cells[12].Value = c12.ToString("N2");
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 6:
                    #region cargar grid1
                    for (int x = 0; x <= dgv1.Rows.Count - 1; x++)
                    {
                        string sqload = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and ZapateriasTorreon=1";
                        cmd = new MySqlCommand(sqload, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["ModelosvendidosH"].ToString());
                            c2 = double.Parse(reader["PorcentajeMH"].ToString());
                            c3 = double.Parse(reader["ParesvendidosH"].ToString());
                            c4 = double.Parse(reader["ModeloscompraP"].ToString());
                            c5 = double.Parse(reader["PorcentajeMP"].ToString());
                            c6 = double.Parse(reader["paresCompraP"].ToString());
                            c7 = double.Parse(reader["Parescompra80"].ToString());
                            c8 = double.Parse(reader["Parescompra20"].ToString());
                            c9 = double.Parse(reader["modeloscompraA"].ToString());
                            c10 = double.Parse(reader["modeloscompraB"].ToString());
                            c11 = double.Parse(reader["profundidadA"].ToString());
                            c12 = double.Parse(reader["profundidadB"].ToString());

                            dgv6.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv6.Rows[x].Cells[2].Value = c2.ToString("N2");
                            dgv6.Rows[x].Cells[3].Value = c3.ToString("N2");
                            dgv6.Rows[x].Cells[4].Value = c4.ToString("N0");
                            dgv6.Rows[x].Cells[5].Value = c5.ToString("N0");
                            dgv6.Rows[x].Cells[6].Value = c6.ToString("N2");
                            dgv6.Rows[x].Cells[7].Value = c7.ToString("N0");
                            dgv6.Rows[x].Cells[8].Value = c8.ToString("N2");
                            dgv6.Rows[x].Cells[9].Value = c9.ToString("N2");
                            dgv6.Rows[x].Cells[10].Value = c10.ToString("N2");
                            dgv6.Rows[x].Cells[11].Value = c11.ToString("N2");
                            dgv6.Rows[x].Cells[12].Value = c12.ToString("N2");

                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 7:
                    #region cargar grid1
                    for (int x = 0; x <= dgv1.Rows.Count - 1; x++)
                    {
                        string sqload = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and ZapateriasTorreon=1";
                        cmd = new MySqlCommand(sqload, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["ModelosvendidosH"].ToString());
                            c2 = double.Parse(reader["PorcentajeMH"].ToString());
                            c3 = double.Parse(reader["ParesvendidosH"].ToString());
                            c4 = double.Parse(reader["ModeloscompraP"].ToString());
                            c5 = double.Parse(reader["PorcentajeMP"].ToString());
                            c6 = double.Parse(reader["paresCompraP"].ToString());
                            c7 = double.Parse(reader["Parescompra80"].ToString());
                            c8 = double.Parse(reader["Parescompra20"].ToString());
                            c9 = double.Parse(reader["modeloscompraA"].ToString());
                            c10 = double.Parse(reader["modeloscompraB"].ToString());
                            c11 = double.Parse(reader["profundidadA"].ToString());
                            c12 = double.Parse(reader["profundidadB"].ToString());

                            dgv7.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv7.Rows[x].Cells[2].Value = c2.ToString("N2");
                            dgv7.Rows[x].Cells[3].Value = c3.ToString("N2");
                            dgv7.Rows[x].Cells[4].Value = c4.ToString("N0");
                            dgv7.Rows[x].Cells[5].Value = c5.ToString("N0");
                            dgv7.Rows[x].Cells[6].Value = c6.ToString("N2");
                            dgv7.Rows[x].Cells[7].Value = c7.ToString("N0");
                            dgv7.Rows[x].Cells[8].Value = c8.ToString("N2");
                            dgv7.Rows[x].Cells[9].Value = c9.ToString("N2");
                            dgv7.Rows[x].Cells[10].Value = c10.ToString("N2");
                            dgv7.Rows[x].Cells[11].Value = c11.ToString("N2");
                            dgv7.Rows[x].Cells[12].Value = c12.ToString("N2");

                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 8:
                    #region cargar grid1
                    for (int x = 0; x <= dgv1.Rows.Count - 1; x++)
                    {
                        string sqload = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and ZapateriasTorreon=1";
                        cmd = new MySqlCommand(sqload, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["ModelosvendidosH"].ToString());
                            c2 = double.Parse(reader["PorcentajeMH"].ToString());
                            c3 = double.Parse(reader["ParesvendidosH"].ToString());
                            c4 = double.Parse(reader["ModeloscompraP"].ToString());
                            c5 = double.Parse(reader["PorcentajeMP"].ToString());
                            c6 = double.Parse(reader["paresCompraP"].ToString());
                            c7 = double.Parse(reader["Parescompra80"].ToString());
                            c8 = double.Parse(reader["Parescompra20"].ToString());
                            c9 = double.Parse(reader["modeloscompraA"].ToString());
                            c10 = double.Parse(reader["modeloscompraB"].ToString());
                            c11 = double.Parse(reader["profundidadA"].ToString());
                            c12 = double.Parse(reader["profundidadB"].ToString());

                            dgv8.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv8.Rows[x].Cells[2].Value = c2.ToString("N2");
                            dgv8.Rows[x].Cells[3].Value = c3.ToString("N2");
                            dgv8.Rows[x].Cells[4].Value = c4.ToString("N0");
                            dgv8.Rows[x].Cells[5].Value = c5.ToString("N0");
                            dgv8.Rows[x].Cells[6].Value = c6.ToString("N2");
                            dgv8.Rows[x].Cells[7].Value = c7.ToString("N0");
                            dgv8.Rows[x].Cells[8].Value = c8.ToString("N2");
                            dgv8.Rows[x].Cells[9].Value = c9.ToString("N2");
                            dgv8.Rows[x].Cells[10].Value = c10.ToString("N2");
                            dgv8.Rows[x].Cells[11].Value = c11.ToString("N2");
                            dgv8.Rows[x].Cells[12].Value = c12.ToString("N2");

                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 9:
                    #region cargar grid1
                    for (int x = 0; x <= dgv1.Rows.Count - 1; x++)
                    {
                        string sqload = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and ZapateriasTorreon=1";
                        cmd = new MySqlCommand(sqload, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["ModelosvendidosH"].ToString());
                            c2 = double.Parse(reader["PorcentajeMH"].ToString());
                            c3 = double.Parse(reader["ParesvendidosH"].ToString());
                            c4 = double.Parse(reader["ModeloscompraP"].ToString());
                            c5 = double.Parse(reader["PorcentajeMP"].ToString());
                            c6 = double.Parse(reader["paresCompraP"].ToString());
                            c7 = double.Parse(reader["Parescompra80"].ToString());
                            c8 = double.Parse(reader["Parescompra20"].ToString());
                            c9 = double.Parse(reader["modeloscompraA"].ToString());
                            c10 = double.Parse(reader["modeloscompraB"].ToString());
                            c11 = double.Parse(reader["profundidadA"].ToString());
                            c12 = double.Parse(reader["profundidadB"].ToString());

                            dgv9.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv9.Rows[x].Cells[2].Value = c2.ToString("N2");
                            dgv9.Rows[x].Cells[3].Value = c3.ToString("N2");
                            dgv9.Rows[x].Cells[4].Value = c4.ToString("N0");
                            dgv9.Rows[x].Cells[5].Value = c5.ToString("N0");
                            dgv9.Rows[x].Cells[6].Value = c6.ToString("N2");
                            dgv9.Rows[x].Cells[7].Value = c7.ToString("N0");
                            dgv9.Rows[x].Cells[8].Value = c8.ToString("N2");
                            dgv9.Rows[x].Cells[9].Value = c9.ToString("N2");
                            dgv9.Rows[x].Cells[10].Value = c10.ToString("N2");
                            dgv9.Rows[x].Cells[11].Value = c11.ToString("N2");
                            dgv9.Rows[x].Cells[12].Value = c12.ToString("N2");

                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 10:
                    #region cargar grid1
                    for (int x = 0; x <= dgv1.Rows.Count - 1; x++)
                    {
                        string sqload = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and ZapateriasTorreon=1";
                        cmd = new MySqlCommand(sqload, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["ModelosvendidosH"].ToString());
                            c2 = double.Parse(reader["PorcentajeMH"].ToString());
                            c3 = double.Parse(reader["ParesvendidosH"].ToString());
                            c4 = double.Parse(reader["ModeloscompraP"].ToString());
                            c5 = double.Parse(reader["PorcentajeMP"].ToString());
                            c6 = double.Parse(reader["paresCompraP"].ToString());
                            c7 = double.Parse(reader["Parescompra80"].ToString());
                            c8 = double.Parse(reader["Parescompra20"].ToString());
                            c9 = double.Parse(reader["modeloscompraA"].ToString());
                            c10 = double.Parse(reader["modeloscompraB"].ToString());
                            c11 = double.Parse(reader["profundidadA"].ToString());
                            c12 = double.Parse(reader["profundidadB"].ToString());

                            dgv10.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv10.Rows[x].Cells[2].Value = c2.ToString("N2");
                            dgv10.Rows[x].Cells[3].Value = c3.ToString("N2");
                            dgv10.Rows[x].Cells[4].Value = c4.ToString("N0");
                            dgv10.Rows[x].Cells[5].Value = c5.ToString("N0");
                            dgv10.Rows[x].Cells[6].Value = c6.ToString("N2");
                            dgv10.Rows[x].Cells[7].Value = c7.ToString("N0");
                            dgv10.Rows[x].Cells[8].Value = c8.ToString("N2");
                            dgv10.Rows[x].Cells[9].Value = c9.ToString("N2");
                            dgv10.Rows[x].Cells[10].Value = c10.ToString("N2");
                            dgv10.Rows[x].Cells[11].Value = c11.ToString("N2");
                            dgv10.Rows[x].Cells[12].Value = c12.ToString("N2");

                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 11:
                    #region cargar grid1
                    for (int x = 0; x <= dgv1.Rows.Count - 1; x++)
                    {
                        string sqload = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and ZapateriasTorreon=1";
                        cmd = new MySqlCommand(sqload, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["ModelosvendidosH"].ToString());
                            c2 = double.Parse(reader["PorcentajeMH"].ToString());
                            c3 = double.Parse(reader["ParesvendidosH"].ToString());
                            c4 = double.Parse(reader["ModeloscompraP"].ToString());
                            c5 = double.Parse(reader["PorcentajeMP"].ToString());
                            c6 = double.Parse(reader["paresCompraP"].ToString());
                            c7 = double.Parse(reader["Parescompra80"].ToString());
                            c8 = double.Parse(reader["Parescompra20"].ToString());
                            c9 = double.Parse(reader["modeloscompraA"].ToString());
                            c10 = double.Parse(reader["modeloscompraB"].ToString());
                            c11 = double.Parse(reader["profundidadA"].ToString());
                            c12 = double.Parse(reader["profundidadB"].ToString());

                            dgv11.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv11.Rows[x].Cells[2].Value = c2.ToString("N2");
                            dgv11.Rows[x].Cells[3].Value = c3.ToString("N2");
                            dgv11.Rows[x].Cells[4].Value = c4.ToString("N0");
                            dgv11.Rows[x].Cells[5].Value = c5.ToString("N0");
                            dgv11.Rows[x].Cells[6].Value = c6.ToString("N2");
                            dgv11.Rows[x].Cells[7].Value = c7.ToString("N0");
                            dgv11.Rows[x].Cells[8].Value = c8.ToString("N2");
                            dgv11.Rows[x].Cells[9].Value = c9.ToString("N2");
                            dgv11.Rows[x].Cells[10].Value = c10.ToString("N2");
                            dgv11.Rows[x].Cells[11].Value = c11.ToString("N2");
                            dgv11.Rows[x].Cells[12].Value = c12.ToString("N2");

                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 12:
                    #region cargar grid1
                    for (int x = 0; x <= dgv1.Rows.Count - 1; x++)
                    {
                       string sqload = "SELECT * FROM cedula8 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and ZapateriasTorreon=1";
                        cmd = new MySqlCommand(sqload, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["ModelosvendidosH"].ToString());
                            c2 = double.Parse(reader["PorcentajeMH"].ToString());
                            c3 = double.Parse(reader["ParesvendidosH"].ToString());
                            c4 = double.Parse(reader["ModeloscompraP"].ToString());
                            c5 = double.Parse(reader["PorcentajeMP"].ToString());
                            c6 = double.Parse(reader["paresCompraP"].ToString());
                            c7 = double.Parse(reader["Parescompra80"].ToString());
                            c8 = double.Parse(reader["Parescompra20"].ToString());
                            c9 = double.Parse(reader["modeloscompraA"].ToString());
                            c10 = double.Parse(reader["modeloscompraB"].ToString());
                            c11 = double.Parse(reader["profundidadA"].ToString());
                            c12 = double.Parse(reader["profundidadB"].ToString());

                            dgv12.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv12.Rows[x].Cells[2].Value = c2.ToString("N2");
                            dgv12.Rows[x].Cells[3].Value = c3.ToString("N2");
                            dgv12.Rows[x].Cells[4].Value = c4.ToString("N0");
                            dgv12.Rows[x].Cells[5].Value = c5.ToString("N0");
                            dgv12.Rows[x].Cells[6].Value = c6.ToString("N2");
                            dgv12.Rows[x].Cells[7].Value = c7.ToString("N0");
                            dgv12.Rows[x].Cells[8].Value = c8.ToString("N2");
                            dgv12.Rows[x].Cells[9].Value = c9.ToString("N2");
                            dgv12.Rows[x].Cells[10].Value = c10.ToString("N2");
                            dgv12.Rows[x].Cells[11].Value = c11.ToString("N2");
                            dgv12.Rows[x].Cells[12].Value = c12.ToString("N2");

                        }
                        reader.Close();
                    }
                    #endregion
                    break;
            }
        }

        private void comprasH(int mes, int año,int i)
        {
            double unidades = 0;
            int x = 0;
            if (solototal == false)
            {
                x = 1;
            }
            else
            {
                x = 0;
            }
            int y = 0;
            //año = año + 1;
            for (; x <= dgv1.Rows.Count - 1; x++)
            {
                //string q = "Select unidadesrecibo from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and anio=" + año + " and mes=" + mes + " " + querycargar[y];
                //cmd = new MySqlCommand(q, Conn);
                //reader = cmd.ExecuteReader();
                //while (reader.Read())
                //{
                //    if (reader["unidadesrecibo"].ToString() == "")
                //    {
                //        unidades = 0;
                //    }
                //    else
                //    {
                //        unidades = double.Parse(reader["unidadesrecibo"].ToString());
                //        if (unidades <= 0)
                //        {
                //            unidades = 0;
                //        }
                //    }
                //    m_LLENAR_DGV(i, x, 6, unidades.ToString("N0"));
                //}
                string q = "SELECT SUM(V.`CTD_RECIB`) as unidadesrecibo FROM recibo_base AS v INNER JOIN fecha AS f ON f.`idFecha`=v.`IDFECHA` WHERE f.`Anio`="+año+" AND f.`Mes`="+mes+"  "+wherequery[y];
                cmd = new MySqlCommand(q, Conn);
               reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["unidadesrecibo"].ToString() == "")
                    {
                        unidades = 0;
                    }
                    else
                    {
                        unidades = double.Parse(reader["unidadesrecibo"].ToString());
                        if (unidades <= 0)
                        {
                            unidades = 0;
                        }
                    }
                    m_LLENAR_DGV(i, x, 6, unidades.ToString("N0"));
                    if (reader.HasRows == false)
                    {
                        unidades = 0;
                        m_LLENAR_DGV(i, x, 7, unidades.ToString("N0"));
                    }
                }
                y++;
                reader.Close();
                m_REFRESH_DGV();
            }
        }

        private void modelajePU(int i)
        {
            double unidadesCompraH = 0;
            double unidadesCompraP = 0;
            double modelosH = 0;
            double value = 0;
            switch(i)
            {
                case 1:
                    for (int x = 1; x <= dgv1.Rows.Count - 1;x++)
                    {
                        unidadesCompraH=double.Parse(dgv1.Rows[x].Cells[6].Value.ToString());
                        unidadesCompraP=double.Parse(dgv1.Rows[x].Cells[7].Value.ToString());
                        modelosH = double.Parse(dgv1.Rows[x].Cells[2].Value.ToString());
                        if (unidadesCompraH != 0 && unidadesCompraP != 0)
                        {
                            value = (unidadesCompraP / unidadesCompraH) * modelosH;
                        }
                        else
                        {
                            value = 0;
                        }
                        dgv1.Rows[x].Cells[4].Value=value.ToString("N0");
                    }
                        break;
                case 2:
                        for (int x = 1; x <= dgv1.Rows.Count - 1; x++)
                        {
                            unidadesCompraH = double.Parse(dgv2.Rows[x].Cells[6].Value.ToString());
                            unidadesCompraP = double.Parse(dgv2.Rows[x].Cells[7].Value.ToString());
                            modelosH = double.Parse(dgv2.Rows[x].Cells[2].Value.ToString());
                            if (unidadesCompraH != 0 && unidadesCompraP != 0)
                            {
                                value = (unidadesCompraP / unidadesCompraH) * modelosH;
                            }
                            else
                            {
                                value = 0;
                            }
                            dgv2.Rows[x].Cells[4].Value = value.ToString("N0");
                        }
                        break;
                case 3:
                        for (int x = 1; x <= dgv3.Rows.Count - 1; x++)
                        {
                            unidadesCompraH = double.Parse(dgv3.Rows[x].Cells[6].Value.ToString());
                            unidadesCompraP = double.Parse(dgv3.Rows[x].Cells[7].Value.ToString());
                            modelosH = double.Parse(dgv3.Rows[x].Cells[2].Value.ToString());
                            if (unidadesCompraH != 0 && unidadesCompraP != 0)
                            {
                                value = (unidadesCompraP / unidadesCompraH) * modelosH;
                            }
                            else
                            {
                                value = 0;
                            }
                            dgv3.Rows[x].Cells[4].Value = value.ToString("N0");
                        }
                        break;
                case 4:
                        for (int x = 1; x <= dgv4.Rows.Count - 1; x++)
                        {
                            unidadesCompraH = double.Parse(dgv4.Rows[x].Cells[6].Value.ToString());
                            unidadesCompraP = double.Parse(dgv4.Rows[x].Cells[7].Value.ToString());
                            modelosH = double.Parse(dgv4.Rows[x].Cells[2].Value.ToString());
                            if (unidadesCompraH != 0 && unidadesCompraP != 0)
                            {
                                value = (unidadesCompraP / unidadesCompraH) * modelosH;
                            }
                            else
                            {
                                value = 0;
                            }
                            dgv4.Rows[x].Cells[4].Value = value.ToString("N0");
                        }
                        break;
                case 5:
                        for (int x = 1; x <= dgv5.Rows.Count - 1; x++)
                        {
                            unidadesCompraH = double.Parse(dgv5.Rows[x].Cells[6].Value.ToString());
                            unidadesCompraP = double.Parse(dgv5.Rows[x].Cells[7].Value.ToString());
                            modelosH = double.Parse(dgv5.Rows[x].Cells[2].Value.ToString());
                            if (unidadesCompraH != 0 && unidadesCompraP != 0)
                            {
                                value = (unidadesCompraP / unidadesCompraH) * modelosH;
                            }
                            else
                            {
                                value = 0;
                            }
                            dgv5.Rows[x].Cells[4].Value = value.ToString("N0");
                        }
                        break;
                case 6:
                        for (int x = 1; x <= dgv1.Rows.Count - 1; x++)
                        {
                            unidadesCompraH = double.Parse(dgv1.Rows[x].Cells[6].Value.ToString());
                            unidadesCompraP = double.Parse(dgv1.Rows[x].Cells[7].Value.ToString());
                            modelosH = double.Parse(dgv1.Rows[x].Cells[2].Value.ToString());
                            if (unidadesCompraH != 0 && unidadesCompraP != 0)
                            {
                                value = (unidadesCompraP / unidadesCompraH) * modelosH;
                            }
                            else
                            {
                                value = 0;
                            }
                            dgv6.Rows[x].Cells[4].Value = value.ToString("N0");
                        }
                        break;
                case 7:
                        for (int x = 1; x <= dgv7.Rows.Count - 1; x++)
                        {
                            unidadesCompraH = double.Parse(dgv7.Rows[x].Cells[6].Value.ToString());
                            unidadesCompraP = double.Parse(dgv7.Rows[x].Cells[7].Value.ToString());
                            modelosH = double.Parse(dgv7.Rows[x].Cells[2].Value.ToString());
                            if (unidadesCompraH != 0 && unidadesCompraP != 0)
                            {
                                value = (unidadesCompraP / unidadesCompraH) * modelosH;
                            }
                            else
                            {
                                value = 0;
                            }
                            dgv7.Rows[x].Cells[4].Value = value.ToString("N0");
                        }
                        break;
                case 8:
                        for (int x = 1; x <= dgv8.Rows.Count - 1; x++)
                        {
                            unidadesCompraH = double.Parse(dgv8.Rows[x].Cells[6].Value.ToString());
                            unidadesCompraP = double.Parse(dgv8.Rows[x].Cells[7].Value.ToString());
                            modelosH = double.Parse(dgv8.Rows[x].Cells[2].Value.ToString());
                            if (unidadesCompraH != 0 && unidadesCompraP != 0)
                            {
                                value = (unidadesCompraP / unidadesCompraH) * modelosH;
                            }
                            else
                            {
                                value = 0;
                            }
                            dgv8.Rows[x].Cells[4].Value = value.ToString("N0");
                        }
                        break;
                case 9:
                        for (int x = 1; x <= dgv9.Rows.Count - 1; x++)
                        {
                            unidadesCompraH = double.Parse(dgv9.Rows[x].Cells[6].Value.ToString());
                            unidadesCompraP = double.Parse(dgv9.Rows[x].Cells[7].Value.ToString());
                            modelosH = double.Parse(dgv9.Rows[x].Cells[2].Value.ToString());
                            if (unidadesCompraH != 0 && unidadesCompraP != 0)
                            {
                                value = (unidadesCompraP / unidadesCompraH) * modelosH;
                            }
                            else
                            {
                                value = 0;
                            }
                            dgv9.Rows[x].Cells[4].Value = value.ToString("N0");
                        }
                        break;
                case 10:
                        for (int x = 1; x <= dgv10.Rows.Count - 1; x++)
                        {
                            unidadesCompraH = double.Parse(dgv10.Rows[x].Cells[6].Value.ToString());
                            unidadesCompraP = double.Parse(dgv10.Rows[x].Cells[7].Value.ToString());
                            modelosH = double.Parse(dgv10.Rows[x].Cells[2].Value.ToString());
                            if (unidadesCompraH != 0 && unidadesCompraP != 0)
                            {
                                value = (unidadesCompraP / unidadesCompraH) * modelosH;
                            }
                            else
                            {
                                value = 0;
                            }
                            dgv10.Rows[x].Cells[4].Value = value.ToString("N0");
                        }
                        break;
                case 11:
                        for (int x = 1; x <= dgv11.Rows.Count - 1; x++)
                        {
                            unidadesCompraH = double.Parse(dgv11.Rows[x].Cells[6].Value.ToString());
                            unidadesCompraP = double.Parse(dgv11.Rows[x].Cells[7].Value.ToString());
                            modelosH = double.Parse(dgv11.Rows[x].Cells[2].Value.ToString());
                            if (unidadesCompraH != 0 && unidadesCompraP != 0)
                            {
                                value = (unidadesCompraP / unidadesCompraH) * modelosH;
                            }
                            else
                            {
                                value = 0;
                            }
                            dgv11.Rows[x].Cells[4].Value = value.ToString("N0");
                        }
                        break;
                case 12:
                        for (int x = 1; x <= dgv12.Rows.Count - 1; x++)
                        {
                            unidadesCompraH = double.Parse(dgv12.Rows[x].Cells[6].Value.ToString());
                            unidadesCompraP = double.Parse(dgv12.Rows[x].Cells[7].Value.ToString());
                            modelosH = double.Parse(dgv12.Rows[x].Cells[2].Value.ToString());
                            if (unidadesCompraH != 0 && unidadesCompraP != 0)
                            {
                                value = (unidadesCompraP / unidadesCompraH) * modelosH;
                            }
                            else
                            {
                                value = 0;
                            }
                            dgv12.Rows[x].Cells[4].Value = value.ToString("N0");
                        }
                        break;
            }
        }

        private void participacionHU(int i)
        {
            int x = 0;
            int y = 0;
            if (solototal==false)
            {
                x = 1;
                y = 1;
            }
            else { x = 0; y = 0; }
            switch(i)
            {
                case 1:
                    double unidades = 0, Participacion = 0;
                    for ( ; x <= dgv1.Rows.Count - 1;x++)
                    {
                        unidades += double.Parse(dgv1.Rows[x].Cells[6].Value.ToString(),NumberStyles.Currency);
                    }
                    for ( ; y <= dgv1.Rows.Count - 1; y++)
                    {
                        Participacion = double.Parse(dgv1.Rows[y].Cells[6].Value.ToString(),NumberStyles.Currency)/unidades;
                        if (double.Parse(dgv1.Rows[y].Cells[6].Value.ToString(), NumberStyles.Currency) == 0 && unidades == 0)
                        {
                            Participacion = 0;
                        }
                        else { }
                        if (Participacion <= 1)
                        {
                            Participacion = Participacion * 100;
                        }
                        else { }
                        m_LLENAR_DGV(i, y, 1, Participacion.ToString("N0"));
                    }
                        break;
                case 2:
                        unidades = 0; Participacion = 0;
                        for (; x <= dgv2.Rows.Count - 1; x++)
                        {
                            unidades += double.Parse(dgv2.Rows[x].Cells[6].Value.ToString(), NumberStyles.Currency);
                        }
                        for (; y <= dgv2.Rows.Count - 1; y++)
                        {
                            Participacion = double.Parse(dgv2.Rows[y].Cells[6].Value.ToString(), NumberStyles.Currency) / unidades;
                            if (double.Parse(dgv2.Rows[y].Cells[6].Value.ToString(), NumberStyles.Currency) == 0 && unidades == 0)
                            {
                                Participacion = 0;
                            }
                            else { }
                            if (Participacion <= 1)
                            {
                                Participacion = Participacion * 100;
                            }
                            else { }
                            m_LLENAR_DGV(i, y, 1, Participacion.ToString("N0"));
                        }
                        break;
                case 3:
                        unidades = 0; Participacion = 0;
                        for (; x <= dgv3.Rows.Count - 1; x++)
                        {
                            unidades += double.Parse(dgv3.Rows[x].Cells[6].Value.ToString(), NumberStyles.Currency);
                        }
                        for (; y <= dgv3.Rows.Count - 1; y++)
                        {
                            Participacion = double.Parse(dgv3.Rows[y].Cells[6].Value.ToString(), NumberStyles.Currency) / unidades;
                            if (double.Parse(dgv3.Rows[y].Cells[6].Value.ToString(), NumberStyles.Currency) == 0 && unidades == 0)
                            {
                                Participacion = 0;
                            }
                            else { }
                            if (Participacion <= 1)
                            {
                                Participacion = Participacion * 100;
                            }
                            else { }
                            m_LLENAR_DGV(i, y, 1, Participacion.ToString("N0"));
                        }
                        break;
                case 4:
                        unidades = 0; Participacion = 0;
                        for (; x <= dgv4.Rows.Count - 1; x++)
                        {
                            unidades += double.Parse(dgv4.Rows[x].Cells[6].Value.ToString(), NumberStyles.Currency);
                        }
                        for (; y <= dgv4.Rows.Count - 1; y++)
                        {
                            Participacion = double.Parse(dgv4.Rows[y].Cells[6].Value.ToString(), NumberStyles.Currency) / unidades;
                            if (double.Parse(dgv4.Rows[y].Cells[6].Value.ToString(), NumberStyles.Currency) == 0 && unidades == 0)
                            {
                                Participacion = 0;
                            }
                            else { }
                            if (Participacion <= 1)
                            {
                                Participacion = Participacion * 100;
                            }
                            else { }
                            m_LLENAR_DGV(i, y, 1, Participacion.ToString("N0"));
                        }
                        break;
                case 5:
                        unidades = 0; Participacion = 0;
                        for (; x <= dgv5.Rows.Count - 1; x++)
                        {
                            unidades += double.Parse(dgv5.Rows[x].Cells[6].Value.ToString(), NumberStyles.Currency);
                        }
                        for (; y <= dgv5.Rows.Count - 1; y++)
                        {
                            Participacion = double.Parse(dgv5.Rows[y].Cells[6].Value.ToString(), NumberStyles.Currency) / unidades;
                            if (double.Parse(dgv5.Rows[y].Cells[6].Value.ToString(), NumberStyles.Currency) == 0 && unidades == 0)
                            {
                                Participacion = 0;
                            }
                            else { }
                            if (Participacion <= 1)
                            {
                                Participacion = Participacion * 100;
                            }
                            else { }
                            m_LLENAR_DGV(i, y, 1, Participacion.ToString("N0"));
                        }
                        break;
                case 6:
                        unidades = 0; Participacion = 0;
                        for (; x <= dgv6.Rows.Count - 1; x++)
                        {
                            unidades += double.Parse(dgv6.Rows[x].Cells[6].Value.ToString(), NumberStyles.Currency);
                        }
                        for (; y <= dgv6.Rows.Count - 1; y++)
                        {
                            Participacion = double.Parse(dgv6.Rows[y].Cells[6].Value.ToString(), NumberStyles.Currency) / unidades;
                            if (double.Parse(dgv6.Rows[y].Cells[6].Value.ToString(), NumberStyles.Currency) == 0 && unidades == 0)
                            {
                                Participacion = 0;
                            }
                            else { }
                            if (Participacion <= 1)
                            {
                                Participacion = Participacion * 100;
                            }
                            else { }
                            m_LLENAR_DGV(i, y, 1, Participacion.ToString("N0"));
                        }
                        break;
                case 7:
                        unidades = 0; Participacion = 0;
                        for (; x <= dgv7.Rows.Count - 1; x++)
                        {
                            unidades += double.Parse(dgv7.Rows[x].Cells[6].Value.ToString(), NumberStyles.Currency);
                        }
                        for (; y <= dgv7.Rows.Count - 1; y++)
                        {
                            Participacion = double.Parse(dgv7.Rows[y].Cells[6].Value.ToString(), NumberStyles.Currency) / unidades;
                            if (double.Parse(dgv7.Rows[y].Cells[6].Value.ToString(), NumberStyles.Currency) == 0 && unidades == 0)
                            {
                                Participacion = 0;
                            }
                            else { }
                            if (Participacion <= 1)
                            {
                                Participacion = Participacion * 100;
                            }
                            else { }
                            m_LLENAR_DGV(i, y, 1, Participacion.ToString("N0"));
                        }
                        break;
                case 8:
                        unidades = 0; Participacion = 0;
                        for (; x <= dgv8.Rows.Count - 1; x++)
                        {
                            unidades += double.Parse(dgv8.Rows[x].Cells[6].Value.ToString(), NumberStyles.Currency);
                        }
                        for (; y <= dgv8.Rows.Count - 1; y++)
                        {
                            Participacion = double.Parse(dgv8.Rows[y].Cells[6].Value.ToString(), NumberStyles.Currency) / unidades;
                            if (double.Parse(dgv8.Rows[y].Cells[6].Value.ToString(), NumberStyles.Currency) == 0 && unidades == 0)
                            {
                                Participacion = 0;
                            }
                            else { }
                            if (Participacion <= 1)
                            {
                                Participacion = Participacion * 100;
                            }
                            else { }
                            m_LLENAR_DGV(i, y, 1, Participacion.ToString("N0"));
                        }
                        break;
                case 9:
                        unidades = 0; Participacion = 0;
                        for (; x <= dgv9.Rows.Count - 1; x++)
                        {
                            unidades += double.Parse(dgv9.Rows[x].Cells[6].Value.ToString(), NumberStyles.Currency);
                        }
                        for (; y <= dgv9.Rows.Count - 1; y++)
                        {
                            Participacion = double.Parse(dgv9.Rows[y].Cells[6].Value.ToString(), NumberStyles.Currency) / unidades;
                            if (double.Parse(dgv9.Rows[y].Cells[6].Value.ToString(), NumberStyles.Currency) == 0 && unidades == 0)
                            {
                                Participacion = 0;
                            }
                            else { }
                            if (Participacion <= 1)
                            {
                                Participacion = Participacion * 100;
                            }
                            else { }
                            m_LLENAR_DGV(i, y, 1, Participacion.ToString("N0"));
                        }
                        break;
                case 10:
                        unidades = 0; Participacion = 0;
                        for (; x <= dgv10.Rows.Count - 1; x++)
                        {
                            unidades += double.Parse(dgv10.Rows[x].Cells[6].Value.ToString(), NumberStyles.Currency);
                        }
                        for (; y <= dgv10.Rows.Count - 1; y++)
                        {
                            Participacion = double.Parse(dgv10.Rows[y].Cells[6].Value.ToString(), NumberStyles.Currency) / unidades;
                            if (double.Parse(dgv10.Rows[y].Cells[6].Value.ToString(), NumberStyles.Currency) == 0 && unidades == 0)
                            {
                                Participacion = 0;
                            }
                            else { }
                            if (Participacion <= 1)
                            {
                                Participacion = Participacion * 100;
                            }
                            else { }
                            m_LLENAR_DGV(i, y, 1, Participacion.ToString("N0"));
                        }
                        break;
                case 11:
                        unidades = 0; Participacion = 0;
                        for (; x <= dgv11.Rows.Count - 1; x++)
                        {
                            unidades += double.Parse(dgv11.Rows[x].Cells[6].Value.ToString(), NumberStyles.Currency);
                        }
                        for (; y <= dgv11.Rows.Count - 1; y++)
                        {
                            Participacion = double.Parse(dgv11.Rows[y].Cells[6].Value.ToString(), NumberStyles.Currency) / unidades;
                            if (double.Parse(dgv11.Rows[y].Cells[6].Value.ToString(), NumberStyles.Currency) == 0 && unidades == 0)
                            {
                                Participacion = 0;
                            }
                            else { }
                            if (Participacion <= 1)
                            {
                                Participacion = Participacion * 100;
                            }
                            else { }
                            m_LLENAR_DGV(i, y, 1, Participacion.ToString("N0"));
                        }
                        break;
                case 12:
                        unidades = 0; Participacion = 0;
                        for (; x <= dgv12.Rows.Count - 1; x++)
                        {
                            unidades += double.Parse(dgv12.Rows[x].Cells[6].Value.ToString(), NumberStyles.Currency);
                        }
                        for (; y <= dgv12.Rows.Count - 1; y++)
                        {
                            Participacion = double.Parse(dgv12.Rows[y].Cells[6].Value.ToString(), NumberStyles.Currency) / unidades;
                            if (double.Parse(dgv12.Rows[y].Cells[6].Value.ToString(), NumberStyles.Currency) == 0 && unidades == 0)
                            {
                                Participacion = 0;
                            }
                            else { }
                            if (Participacion <= 1)
                            {
                                Participacion = Participacion * 100;
                            }
                            else { }
                            m_LLENAR_DGV(i, y, 1, Participacion.ToString("N0"));
                        }
                        break;
            }
        }

        private void tabcontrol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void m_calcularRenglonTotal(int x)
        {            
            double c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15;
            switch (x)
            {
                case 1:
                    #region renglontotal dgv1
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
                        if (dgv1.Rows[i].Cells[8].Value != null && dgv1.Rows[i].Cells[8].Value.ToString() != " ")
                        {
                            c8 += double.Parse(dgv1.Rows[i].Cells[8].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c8 = c8 + 0;
                        }
                        if (dgv1.Rows[i].Cells[9].Value != null && dgv1.Rows[i].Cells[9].Value.ToString() != " ")
                        {
                            c9 += double.Parse(dgv1.Rows[i].Cells[9].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c9 = c9 + 0;
                        }
                        if (dgv1.Rows[i].Cells[10].Value != null && dgv1.Rows[i].Cells[10].Value.ToString() != " ")
                        {
                            c10 += double.Parse(dgv1.Rows[i].Cells[10].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c10 = c10 + 0;
                        }
                        if (dgv1.Rows[i].Cells[11].Value != null && dgv1.Rows[i].Cells[11].Value.ToString() != " ")
                        {
                            c11 += double.Parse(dgv1.Rows[i].Cells[11].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c11 = c11 + 0;
                        }
                        if (dgv1.Rows[i].Cells[12].Value != null && dgv1.Rows[i].Cells[12].Value.ToString() != " ")
                        {
                            c12 += double.Parse(dgv1.Rows[i].Cells[12].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c12 = c12 + 0;
                        }
                        if (dgv1.Rows[i].Cells[13].Value != null && dgv1.Rows[i].Cells[13].Value.ToString() != " ")
                        {
                            c13 += double.Parse(dgv1.Rows[i].Cells[13].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c13 = c13 + 0;
                        }
                        if (dgv1.Rows[i].Cells[14].Value != null && dgv1.Rows[i].Cells[14].Value.ToString() != " ")
                        {
                            c14 += double.Parse(dgv1.Rows[i].Cells[14].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c14 = c14 + 0;
                        }
                        dgv1.Rows[0].Cells[1].Value = c1.ToString("N2");
                        dgv1.Rows[0].Cells[2].Value = c2.ToString("N2");
                        dgv1.Rows[0].Cells[3].Value = c3.ToString("N2");
                        dgv1.Rows[0].Cells[4].Value = c4.ToString("N2");
                        dgv1.Rows[0].Cells[5].Value = c5.ToString("N2");
                        dgv1.Rows[0].Cells[6].Value = c6.ToString("N2");
                        dgv1.Rows[0].Cells[7].Value = c7.ToString("N2");
                        dgv1.Rows[0].Cells[8].Value = c8.ToString("N2");
                        dgv1.Rows[0].Cells[9].Value = c9.ToString("N2");
                        dgv1.Rows[0].Cells[10].Value = c10.ToString("N2");
                        dgv1.Rows[0].Cells[11].Value = c11.ToString("N2");
                        dgv1.Rows[0].Cells[12].Value = c12.ToString("N2");
                        dgv1.Rows[0].Cells[13].Value = c13.ToString("N2");
					 dgv1.Rows[0].Cells[14].Value=c14.ToString("N2");
                        dgv1.Refresh();
                    }
                    #endregion
                    break;
                case 2:
                    #region renglontotal dgv2
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
                        if (dgv2.Rows[i].Cells[8].Value != null && dgv2.Rows[i].Cells[8].Value.ToString() != " ")
                        {
                            c8 += double.Parse(dgv2.Rows[i].Cells[8].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c8 = c8 + 0;
                        }
                        if (dgv2.Rows[i].Cells[9].Value != null && dgv2.Rows[i].Cells[9].Value.ToString() != " ")
                        {
                            c9 += double.Parse(dgv2.Rows[i].Cells[9].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c9 = c9 + 0;
                        }
                        if (dgv2.Rows[i].Cells[10].Value != null && dgv2.Rows[i].Cells[10].Value.ToString() != " ")
                        {
                            c10 += double.Parse(dgv2.Rows[i].Cells[10].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c10 = c10 + 0;
                        }
                        if (dgv2.Rows[i].Cells[11].Value != null && dgv2.Rows[i].Cells[11].Value.ToString() != " ")
                        {
                            c11 += double.Parse(dgv2.Rows[i].Cells[11].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c11 = c11 + 0;
                        }
                        if (dgv2.Rows[i].Cells[12].Value != null && dgv2.Rows[i].Cells[12].Value.ToString() != " ")
                        {
                            c12 += double.Parse(dgv2.Rows[i].Cells[12].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c12 = c12 + 0;
                        }
                        if (dgv2.Rows[i].Cells[13].Value != null && dgv2.Rows[i].Cells[13].Value.ToString() != " ")
                        {
                            c13 += double.Parse(dgv2.Rows[i].Cells[13].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c13 = c13 + 0;
                        }
                        if (dgv2.Rows[i].Cells[14].Value != null && dgv2.Rows[i].Cells[14].Value.ToString() != " ")
                        {
                            c14 += double.Parse(dgv2.Rows[i].Cells[14].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c14 = c14 + 0;
                        }
                        dgv2.Rows[0].Cells[1].Value = c1.ToString("N2");
                        dgv2.Rows[0].Cells[2].Value = c2.ToString("N2");
                        dgv2.Rows[0].Cells[3].Value = c3.ToString("N2");
                        dgv2.Rows[0].Cells[4].Value = c4.ToString("N2");
                        dgv2.Rows[0].Cells[5].Value = c5.ToString("N2");
                        dgv2.Rows[0].Cells[6].Value = c6.ToString("N2");
                        dgv2.Rows[0].Cells[7].Value = c7.ToString("N2");
                        dgv2.Rows[0].Cells[8].Value = c8.ToString("N2");
                        dgv2.Rows[0].Cells[9].Value = c9.ToString("N2");
                        dgv2.Rows[0].Cells[10].Value = c10.ToString("N2");
                        dgv2.Rows[0].Cells[11].Value = c11.ToString("N2");
                        dgv2.Rows[0].Cells[12].Value = c12.ToString("N2");
                        dgv2.Rows[0].Cells[13].Value = c13.ToString("N2");
                        dgv2.Rows[0].Cells[14].Value = c14.ToString("N2");
                        dgv2.Refresh();
                    }
                    #endregion
                    break;
                case 3:
                    #region renglontotal dgv3
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
                        if (dgv3.Rows[i].Cells[8].Value != null && dgv3.Rows[i].Cells[8].Value.ToString() != " ")
                        {
                            c8 += double.Parse(dgv3.Rows[i].Cells[8].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c8 = c8 + 0;
                        }
                        if (dgv3.Rows[i].Cells[9].Value != null && dgv3.Rows[i].Cells[9].Value.ToString() != " ")
                        {
                            c9 += double.Parse(dgv3.Rows[i].Cells[9].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c9 = c9 + 0;
                        }
                        if (dgv3.Rows[i].Cells[10].Value != null && dgv3.Rows[i].Cells[10].Value.ToString() != " ")
                        {
                            c10 += double.Parse(dgv3.Rows[i].Cells[10].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c10 = c10 + 0;
                        }
                        if (dgv3.Rows[i].Cells[11].Value != null && dgv3.Rows[i].Cells[11].Value.ToString() != " ")
                        {
                            c11 += double.Parse(dgv3.Rows[i].Cells[11].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c11 = c11 + 0;
                        }
                        if (dgv3.Rows[i].Cells[12].Value != null && dgv3.Rows[i].Cells[12].Value.ToString() != " ")
                        {
                            c12 += double.Parse(dgv3.Rows[i].Cells[12].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c12 = c12 + 0;
                        }
                        if (dgv3.Rows[i].Cells[13].Value != null && dgv3.Rows[i].Cells[13].Value.ToString() != " ")
                        {
                            c13 += double.Parse(dgv3.Rows[i].Cells[13].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c13 = c13 + 0;
                        }
                        if (dgv3.Rows[i].Cells[14].Value != null && dgv3.Rows[i].Cells[14].Value.ToString() != " ")
                        {
                            c14 += double.Parse(dgv3.Rows[i].Cells[14].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c14 = c14 + 0;
                        }
                        dgv3.Rows[0].Cells[1].Value = c1.ToString("N2");
                        dgv3.Rows[0].Cells[2].Value = c2.ToString("N2");
                        dgv3.Rows[0].Cells[3].Value = c3.ToString("N2");
                        dgv3.Rows[0].Cells[4].Value = c4.ToString("N2");
                        dgv3.Rows[0].Cells[5].Value = c5.ToString("N2");
                        dgv3.Rows[0].Cells[6].Value = c6.ToString("N2");
                        dgv3.Rows[0].Cells[7].Value = c7.ToString("N2");
                        dgv3.Rows[0].Cells[8].Value = c8.ToString("N2");
                        dgv3.Rows[0].Cells[9].Value = c9.ToString("N2");
                        dgv3.Rows[0].Cells[10].Value = c10.ToString("N2");
                        dgv3.Rows[0].Cells[11].Value = c11.ToString("N2");
                        dgv3.Rows[0].Cells[12].Value = c12.ToString("N2");
                        dgv3.Rows[0].Cells[13].Value = c13.ToString("N2");
                        dgv3.Rows[0].Cells[14].Value = c14.ToString("N2");
                        dgv3.Refresh();
                    }
                    #endregion
                    break;
                case 4:
                    #region renglontotal dgv4
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

                    for (int i = 1; i <= dgv4.Rows.Count - 1; i++)
                    {
                        if (dgv4.Rows[i].Cells[1].Value != null && dgv4.Rows[i].Cells[1].Value.ToString() != " ")
                        {
                            c1 += double.Parse(dgv4.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c1 = c1 + 0;
                        }
                        if (dgv4.Rows[i].Cells[2].Value != null && dgv4.Rows[i].Cells[2].Value.ToString() != " ")
                        {
                            c2 += double.Parse(dgv4.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c2 = c2 + 0;
                        }
                        if (dgv4.Rows[i].Cells[3].Value != null && dgv4.Rows[i].Cells[3].Value.ToString() != " ")
                        {
                            c3 += double.Parse(dgv4.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c3 = c3 + 0;
                        }
                        if (dgv4.Rows[i].Cells[4].Value != null && dgv4.Rows[i].Cells[4].Value.ToString() != " ")
                        {
                            c4 += double.Parse(dgv4.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c4 = c4 + 0;
                        }
                        if (dgv4.Rows[i].Cells[5].Value != null && dgv4.Rows[i].Cells[5].Value.ToString() != " ")
                        {
                            c5 += double.Parse(dgv4.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c5 = c5 + 0;
                        }
                        if (dgv4.Rows[i].Cells[6].Value != null && dgv4.Rows[i].Cells[6].Value.ToString() != " ")
                        {
                            c6 += double.Parse(dgv4.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c6 = c6 + 0;
                        }
                        if (dgv4.Rows[i].Cells[7].Value != null && dgv4.Rows[i].Cells[7].Value.ToString() != " ")
                        {
                            c7 += double.Parse(dgv4.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c7 = c7 + 0;
                        }
                        if (dgv4.Rows[i].Cells[8].Value != null && dgv4.Rows[i].Cells[8].Value.ToString() != " ")
                        {
                            c8 += double.Parse(dgv4.Rows[i].Cells[8].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c8 = c8 + 0;
                        }
                        if (dgv4.Rows[i].Cells[9].Value != null && dgv4.Rows[i].Cells[9].Value.ToString() != " ")
                        {
                            c9 += double.Parse(dgv4.Rows[i].Cells[9].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c9 = c9 + 0;
                        }
                        if (dgv4.Rows[i].Cells[10].Value != null && dgv4.Rows[i].Cells[10].Value.ToString() != " ")
                        {
                            c10 += double.Parse(dgv4.Rows[i].Cells[10].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c10 = c10 + 0;
                        }
                        if (dgv4.Rows[i].Cells[11].Value != null && dgv4.Rows[i].Cells[11].Value.ToString() != " ")
                        {
                            c11 += double.Parse(dgv4.Rows[i].Cells[11].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c11 = c11 + 0;
                        }
                        if (dgv4.Rows[i].Cells[12].Value != null && dgv4.Rows[i].Cells[12].Value.ToString() != " ")
                        {
                            c12 += double.Parse(dgv4.Rows[i].Cells[12].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c12 = c12 + 0;
                        }
                        if (dgv4.Rows[i].Cells[13].Value != null && dgv4.Rows[i].Cells[13].Value.ToString() != " ")
                        {
                            c13 += double.Parse(dgv4.Rows[i].Cells[13].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c13 = c13 + 0;
                        }
                        if (dgv4.Rows[i].Cells[14].Value != null && dgv4.Rows[i].Cells[14].Value.ToString() != " ")
                        {
                            c14 += double.Parse(dgv4.Rows[i].Cells[14].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c14 = c14 + 0;
                        }
                        dgv4.Rows[0].Cells[1].Value = c1.ToString("N2");
                        dgv4.Rows[0].Cells[2].Value = c2.ToString("N2");
                        dgv4.Rows[0].Cells[3].Value = c3.ToString("N2");
                        dgv4.Rows[0].Cells[4].Value = c4.ToString("N2");
                        dgv4.Rows[0].Cells[5].Value = c5.ToString("N2");
                        dgv4.Rows[0].Cells[6].Value = c6.ToString("N2");
                        dgv4.Rows[0].Cells[7].Value = c7.ToString("N2");
                        dgv4.Rows[0].Cells[8].Value = c8.ToString("N2");
                        dgv4.Rows[0].Cells[9].Value = c9.ToString("N2");
                        dgv4.Rows[0].Cells[10].Value = c10.ToString("N2");
                        dgv4.Rows[0].Cells[11].Value = c11.ToString("N2");
                        dgv4.Rows[0].Cells[12].Value = c12.ToString("N2");
                        dgv4.Rows[0].Cells[13].Value = c13.ToString("N2");
                        dgv4.Rows[0].Cells[14].Value = c14.ToString("N2");
                        dgv4.Refresh();
                    }
                    #endregion
                    break;
                case 5:
                    #region renglontotal dgv5
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

                    for (int i = 1; i <= dgv5.Rows.Count - 1; i++)
                    {
                        if (dgv5.Rows[i].Cells[1].Value != null && dgv5.Rows[i].Cells[1].Value.ToString() != " ")
                        {
                            c1 += double.Parse(dgv5.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c1 = c1 + 0;
                        }
                        if (dgv5.Rows[i].Cells[2].Value != null && dgv5.Rows[i].Cells[2].Value.ToString() != " ")
                        {
                            c2 += double.Parse(dgv5.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c2 = c2 + 0;
                        }
                        if (dgv5.Rows[i].Cells[3].Value != null && dgv5.Rows[i].Cells[3].Value.ToString() != " ")
                        {
                            c3 += double.Parse(dgv5.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c3 = c3 + 0;
                        }
                        if (dgv5.Rows[i].Cells[4].Value != null && dgv5.Rows[i].Cells[4].Value.ToString() != " ")
                        {
                            c4 += double.Parse(dgv5.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c4 = c4 + 0;
                        }
                        if (dgv5.Rows[i].Cells[5].Value != null && dgv5.Rows[i].Cells[5].Value.ToString() != " ")
                        {
                            c5 += double.Parse(dgv5.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c5 = c5 + 0;
                        }
                        if (dgv5.Rows[i].Cells[6].Value != null && dgv5.Rows[i].Cells[6].Value.ToString() != " ")
                        {
                            c6 += double.Parse(dgv5.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c6 = c6 + 0;
                        }
                        if (dgv5.Rows[i].Cells[7].Value != null && dgv5.Rows[i].Cells[7].Value.ToString() != " ")
                        {
                            c7 += double.Parse(dgv5.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c7 = c7 + 0;
                        }
                        if (dgv5.Rows[i].Cells[8].Value != null && dgv5.Rows[i].Cells[8].Value.ToString() != " ")
                        {
                            c8 += double.Parse(dgv5.Rows[i].Cells[8].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c8 = c8 + 0;
                        }
                        if (dgv5.Rows[i].Cells[9].Value != null && dgv5.Rows[i].Cells[9].Value.ToString() != " ")
                        {
                            c9 += double.Parse(dgv5.Rows[i].Cells[9].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c9 = c9 + 0;
                        }
                        if (dgv5.Rows[i].Cells[10].Value != null && dgv5.Rows[i].Cells[10].Value.ToString() != " ")
                        {
                            c10 += double.Parse(dgv5.Rows[i].Cells[10].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c10 = c10 + 0;
                        }
                        if (dgv5.Rows[i].Cells[11].Value != null && dgv5.Rows[i].Cells[11].Value.ToString() != " ")
                        {
                            c11 += double.Parse(dgv5.Rows[i].Cells[11].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c11 = c11 + 0;
                        }
                        if (dgv5.Rows[i].Cells[12].Value != null && dgv5.Rows[i].Cells[12].Value.ToString() != " ")
                        {
                            c12 += double.Parse(dgv5.Rows[i].Cells[12].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c12 = c12 + 0;
                        }
                        if (dgv5.Rows[i].Cells[13].Value != null && dgv5.Rows[i].Cells[13].Value.ToString() != " ")
                        {
                            c13 += double.Parse(dgv5.Rows[i].Cells[13].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c13 = c13 + 0;
                        }
                        if (dgv5.Rows[i].Cells[14].Value != null && dgv5.Rows[i].Cells[14].Value.ToString() != " ")
                        {
                            c14 += double.Parse(dgv5.Rows[i].Cells[14].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c14 = c14 + 0;
                        }
                        dgv5.Rows[0].Cells[1].Value = c1.ToString("N2");
                        dgv5.Rows[0].Cells[2].Value = c2.ToString("N2");
                        dgv5.Rows[0].Cells[3].Value = c3.ToString("N2");
                        dgv5.Rows[0].Cells[4].Value = c4.ToString("N2");
                        dgv5.Rows[0].Cells[5].Value = c5.ToString("N2");
                        dgv5.Rows[0].Cells[6].Value = c6.ToString("N2");
                        dgv5.Rows[0].Cells[7].Value = c7.ToString("N2");
                        dgv5.Rows[0].Cells[8].Value = c8.ToString("N2");
                        dgv5.Rows[0].Cells[9].Value = c9.ToString("N2");
                        dgv5.Rows[0].Cells[10].Value = c10.ToString("N2");
                        dgv5.Rows[0].Cells[11].Value = c11.ToString("N2");
                        dgv5.Rows[0].Cells[12].Value = c12.ToString("N2");
                        dgv5.Rows[0].Cells[13].Value = c13.ToString("N2");
                        dgv5.Rows[0].Cells[14].Value = c14.ToString("N2");
                        dgv5.Refresh();
                    }
                    #endregion
                    break;
                case 6:
                    #region renglontotal dgv6
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

                    for (int i = 1; i <= dgv6.Rows.Count - 1; i++)
                    {
                        if (dgv6.Rows[i].Cells[1].Value != null && dgv6.Rows[i].Cells[1].Value.ToString() != " ")
                        {
                            c1 += double.Parse(dgv6.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c1 = c1 + 0;
                        }
                        if (dgv6.Rows[i].Cells[2].Value != null && dgv6.Rows[i].Cells[2].Value.ToString() != " ")
                        {
                            c2 += double.Parse(dgv6.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c2 = c2 + 0;
                        }
                        if (dgv6.Rows[i].Cells[3].Value != null && dgv6.Rows[i].Cells[3].Value.ToString() != " ")
                        {
                            c3 += double.Parse(dgv6.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c3 = c3 + 0;
                        }
                        if (dgv6.Rows[i].Cells[4].Value != null && dgv6.Rows[i].Cells[4].Value.ToString() != " ")
                        {
                            c4 += double.Parse(dgv6.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c4 = c4 + 0;
                        }
                        if (dgv6.Rows[i].Cells[5].Value != null && dgv6.Rows[i].Cells[5].Value.ToString() != " ")
                        {
                            c5 += double.Parse(dgv6.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c5 = c5 + 0;
                        }
                        if (dgv6.Rows[i].Cells[6].Value != null && dgv6.Rows[i].Cells[6].Value.ToString() != " ")
                        {
                            c6 += double.Parse(dgv6.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c6 = c6 + 0;
                        }
                        if (dgv6.Rows[i].Cells[7].Value != null && dgv6.Rows[i].Cells[7].Value.ToString() != " ")
                        {
                            c7 += double.Parse(dgv6.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c7 = c7 + 0;
                        }
                        if (dgv6.Rows[i].Cells[8].Value != null && dgv6.Rows[i].Cells[8].Value.ToString() != " ")
                        {
                            c8 += double.Parse(dgv6.Rows[i].Cells[8].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c8 = c8 + 0;
                        }
                        if (dgv6.Rows[i].Cells[9].Value != null && dgv6.Rows[i].Cells[9].Value.ToString() != " ")
                        {
                            c9 += double.Parse(dgv6.Rows[i].Cells[9].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c9 = c9 + 0;
                        }
                        if (dgv6.Rows[i].Cells[10].Value != null && dgv6.Rows[i].Cells[10].Value.ToString() != " ")
                        {
                            c10 += double.Parse(dgv6.Rows[i].Cells[10].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c10 = c10 + 0;
                        }
                        if (dgv6.Rows[i].Cells[11].Value != null && dgv6.Rows[i].Cells[11].Value.ToString() != " ")
                        {
                            c11 += double.Parse(dgv6.Rows[i].Cells[11].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c11 = c11 + 0;
                        }
                        if (dgv6.Rows[i].Cells[12].Value != null && dgv6.Rows[i].Cells[12].Value.ToString() != " ")
                        {
                            c12 += double.Parse(dgv6.Rows[i].Cells[12].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c12 = c12 + 0;
                        }
                        if (dgv6.Rows[i].Cells[13].Value != null && dgv6.Rows[i].Cells[13].Value.ToString() != " ")
                        {
                            c13 += double.Parse(dgv6.Rows[i].Cells[13].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c13 = c13 + 0;
                        }
                        if (dgv6.Rows[i].Cells[14].Value != null && dgv6.Rows[i].Cells[14].Value.ToString() != " ")
                        {
                            c14 += double.Parse(dgv6.Rows[i].Cells[14].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c14 = c14 + 0;
                        }
                        dgv6.Rows[0].Cells[1].Value = c1.ToString("N2");
                        dgv6.Rows[0].Cells[2].Value = c2.ToString("N2");
                        dgv6.Rows[0].Cells[3].Value = c3.ToString("N2");
                        dgv6.Rows[0].Cells[4].Value = c4.ToString("N2");
                        dgv6.Rows[0].Cells[5].Value = c5.ToString("N2");
                        dgv6.Rows[0].Cells[6].Value = c6.ToString("N2");
                        dgv6.Rows[0].Cells[7].Value = c7.ToString("N2");
                        dgv6.Rows[0].Cells[8].Value = c8.ToString("N2");
                        dgv6.Rows[0].Cells[9].Value = c9.ToString("N2");
                        dgv6.Rows[0].Cells[10].Value = c10.ToString("N2");
                        dgv6.Rows[0].Cells[11].Value = c11.ToString("N2");
                        dgv6.Rows[0].Cells[12].Value = c12.ToString("N2");
                        dgv6.Rows[0].Cells[13].Value = c13.ToString("N2");
                        dgv6.Rows[0].Cells[14].Value = c14.ToString("N2");
                        dgv6.Refresh();
                    }
                    #endregion
                    break;
                case 7:
                    #region renglontotal dgv7
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

                    for (int i = 1; i <= dgv7.Rows.Count - 1; i++)
                    {
                        if (dgv7.Rows[i].Cells[1].Value != null && dgv7.Rows[i].Cells[1].Value.ToString() != " ")
                        {
                            c1 += double.Parse(dgv7.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c1 = c1 + 0;
                        }
                        if (dgv7.Rows[i].Cells[2].Value != null && dgv7.Rows[i].Cells[2].Value.ToString() != " ")
                        {
                            c2 += double.Parse(dgv7.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c2 = c2 + 0;
                        }
                        if (dgv7.Rows[i].Cells[3].Value != null && dgv7.Rows[i].Cells[3].Value.ToString() != " ")
                        {
                            c3 += double.Parse(dgv7.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c3 = c3 + 0;
                        }
                        if (dgv7.Rows[i].Cells[4].Value != null && dgv7.Rows[i].Cells[4].Value.ToString() != " ")
                        {
                            c4 += double.Parse(dgv7.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c4 = c4 + 0;
                        }
                        if (dgv7.Rows[i].Cells[5].Value != null && dgv7.Rows[i].Cells[5].Value.ToString() != " ")
                        {
                            c5 += double.Parse(dgv7.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c5 = c5 + 0;
                        }
                        if (dgv7.Rows[i].Cells[6].Value != null && dgv7.Rows[i].Cells[6].Value.ToString() != " ")
                        {
                            c6 += double.Parse(dgv7.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c6 = c6 + 0;
                        }
                        if (dgv7.Rows[i].Cells[7].Value != null && dgv7.Rows[i].Cells[7].Value.ToString() != " ")
                        {
                            c7 += double.Parse(dgv7.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c7 = c7 + 0;
                        }
                        if (dgv7.Rows[i].Cells[8].Value != null && dgv7.Rows[i].Cells[8].Value.ToString() != " ")
                        {
                            c8 += double.Parse(dgv7.Rows[i].Cells[8].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c8 = c8 + 0;
                        }
                        if (dgv7.Rows[i].Cells[9].Value != null && dgv7.Rows[i].Cells[9].Value.ToString() != " ")
                        {
                            c9 += double.Parse(dgv7.Rows[i].Cells[9].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c9 = c9 + 0;
                        }
                        if (dgv7.Rows[i].Cells[10].Value != null && dgv7.Rows[i].Cells[10].Value.ToString() != " ")
                        {
                            c10 += double.Parse(dgv7.Rows[i].Cells[10].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c10 = c10 + 0;
                        }
                        if (dgv7.Rows[i].Cells[11].Value != null && dgv7.Rows[i].Cells[11].Value.ToString() != " ")
                        {
                            c11 += double.Parse(dgv7.Rows[i].Cells[11].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c11 = c11 + 0;
                        }
                        if (dgv7.Rows[i].Cells[12].Value != null && dgv7.Rows[i].Cells[12].Value.ToString() != " ")
                        {
                            c12 += double.Parse(dgv7.Rows[i].Cells[12].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c12 = c12 + 0;
                        }
                        if (dgv7.Rows[i].Cells[13].Value != null && dgv7.Rows[i].Cells[13].Value.ToString() != " ")
                        {
                            c13 += double.Parse(dgv7.Rows[i].Cells[13].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c13 = c13 + 0;
                        }
                        if (dgv7.Rows[i].Cells[14].Value != null && dgv7.Rows[i].Cells[14].Value.ToString() != " ")
                        {
                            c14 += double.Parse(dgv7.Rows[i].Cells[14].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c14 = c14 + 0;
                        }
                        dgv7.Rows[0].Cells[1].Value = c1.ToString("N2");
                        dgv7.Rows[0].Cells[2].Value = c2.ToString("N2");
                        dgv7.Rows[0].Cells[3].Value = c3.ToString("N2");
                        dgv7.Rows[0].Cells[4].Value = c4.ToString("N2");
                        dgv7.Rows[0].Cells[5].Value = c5.ToString("N2");
                        dgv7.Rows[0].Cells[6].Value = c6.ToString("N2");
                        dgv7.Rows[0].Cells[7].Value = c7.ToString("N2");
                        dgv7.Rows[0].Cells[8].Value = c8.ToString("N2");
                        dgv7.Rows[0].Cells[9].Value = c9.ToString("N2");
                        dgv7.Rows[0].Cells[10].Value = c10.ToString("N2");
                        dgv7.Rows[0].Cells[11].Value = c11.ToString("N2");
                        dgv7.Rows[0].Cells[12].Value = c12.ToString("N2");
                        dgv7.Rows[0].Cells[13].Value = c13.ToString("N2");
                        dgv7.Rows[0].Cells[14].Value = c14.ToString("N2");
                        dgv7.Refresh();
                    }
                    #endregion
                    break;
                case 8:
                    #region renglontotal dgv8
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

                    for (int i = 1; i <= dgv8.Rows.Count - 1; i++)
                    {
                        if (dgv8.Rows[i].Cells[1].Value != null && dgv8.Rows[i].Cells[1].Value.ToString() != " ")
                        {
                            c1 += double.Parse(dgv8.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c1 = c1 + 0;
                        }
                        if (dgv8.Rows[i].Cells[2].Value != null && dgv8.Rows[i].Cells[2].Value.ToString() != " ")
                        {
                            c2 += double.Parse(dgv8.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c2 = c2 + 0;
                        }
                        if (dgv8.Rows[i].Cells[3].Value != null && dgv8.Rows[i].Cells[3].Value.ToString() != " ")
                        {
                            c3 += double.Parse(dgv8.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c3 = c3 + 0;
                        }
                        if (dgv8.Rows[i].Cells[4].Value != null && dgv8.Rows[i].Cells[4].Value.ToString() != " ")
                        {
                            c4 += double.Parse(dgv8.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c4 = c4 + 0;
                        }
                        if (dgv8.Rows[i].Cells[5].Value != null && dgv8.Rows[i].Cells[5].Value.ToString() != " ")
                        {
                            c5 += double.Parse(dgv8.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c5 = c5 + 0;
                        }
                        if (dgv8.Rows[i].Cells[6].Value != null && dgv8.Rows[i].Cells[6].Value.ToString() != " ")
                        {
                            c6 += double.Parse(dgv8.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c6 = c6 + 0;
                        }
                        if (dgv8.Rows[i].Cells[7].Value != null && dgv8.Rows[i].Cells[7].Value.ToString() != " ")
                        {
                            c7 += double.Parse(dgv8.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c7 = c7 + 0;
                        }
                        if (dgv8.Rows[i].Cells[8].Value != null && dgv8.Rows[i].Cells[8].Value.ToString() != " ")
                        {
                            c8 += double.Parse(dgv8.Rows[i].Cells[8].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c8 = c8 + 0;
                        }
                        if (dgv8.Rows[i].Cells[9].Value != null && dgv8.Rows[i].Cells[9].Value.ToString() != " ")
                        {
                            c9 += double.Parse(dgv8.Rows[i].Cells[9].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c9 = c9 + 0;
                        }
                        if (dgv8.Rows[i].Cells[10].Value != null && dgv8.Rows[i].Cells[10].Value.ToString() != " ")
                        {
                            c10 += double.Parse(dgv8.Rows[i].Cells[10].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c10 = c10 + 0;
                        }
                        if (dgv8.Rows[i].Cells[11].Value != null && dgv8.Rows[i].Cells[11].Value.ToString() != " ")
                        {
                            c11 += double.Parse(dgv8.Rows[i].Cells[11].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c11 = c11 + 0;
                        }
                        if (dgv8.Rows[i].Cells[12].Value != null && dgv8.Rows[i].Cells[12].Value.ToString() != " ")
                        {
                            c12 += double.Parse(dgv8.Rows[i].Cells[12].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c12 = c12 + 0;
                        }
                        if (dgv8.Rows[i].Cells[13].Value != null && dgv8.Rows[i].Cells[13].Value.ToString() != " ")
                        {
                            c13 += double.Parse(dgv8.Rows[i].Cells[13].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c13 = c13 + 0;
                        }
                        if (dgv8.Rows[i].Cells[14].Value != null && dgv8.Rows[i].Cells[14].Value.ToString() != " ")
                        {
                            c14 += double.Parse(dgv8.Rows[i].Cells[14].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c14 = c14 + 0;
                        }
                        dgv8.Rows[0].Cells[1].Value = c1.ToString("N2");
                        dgv8.Rows[0].Cells[2].Value = c2.ToString("N2");
                        dgv8.Rows[0].Cells[3].Value = c3.ToString("N2");
                        dgv8.Rows[0].Cells[4].Value = c4.ToString("N2");
                        dgv8.Rows[0].Cells[5].Value = c5.ToString("N2");
                        dgv8.Rows[0].Cells[6].Value = c6.ToString("N2");
                        dgv8.Rows[0].Cells[7].Value = c7.ToString("N2");
                        dgv8.Rows[0].Cells[8].Value = c8.ToString("N2");
                        dgv8.Rows[0].Cells[9].Value = c9.ToString("N2");
                        dgv8.Rows[0].Cells[10].Value = c10.ToString("N2");
                        dgv8.Rows[0].Cells[11].Value = c11.ToString("N2");
                        dgv8.Rows[0].Cells[12].Value = c12.ToString("N2");
                        dgv8.Rows[0].Cells[13].Value = c13.ToString("N2");
                        dgv8.Rows[0].Cells[14].Value = c14.ToString("N2");
                        dgv8.Refresh();
                    }
                    #endregion
                    break;
                case 9:
                    #region renglontotal dgv9
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

                    for (int i = 1; i <= dgv9.Rows.Count - 1; i++)
                    {
                        if (dgv9.Rows[i].Cells[1].Value != null && dgv9.Rows[i].Cells[1].Value.ToString() != " ")
                        {
                            c1 += double.Parse(dgv9.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c1 = c1 + 0;
                        }
                        if (dgv9.Rows[i].Cells[2].Value != null && dgv9.Rows[i].Cells[2].Value.ToString() != " ")
                        {
                            c2 += double.Parse(dgv9.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c2 = c2 + 0;
                        }
                        if (dgv9.Rows[i].Cells[3].Value != null && dgv9.Rows[i].Cells[3].Value.ToString() != " ")
                        {
                            c3 += double.Parse(dgv9.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c3 = c3 + 0;
                        }
                        if (dgv9.Rows[i].Cells[4].Value != null && dgv9.Rows[i].Cells[4].Value.ToString() != " ")
                        {
                            c4 += double.Parse(dgv9.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c4 = c4 + 0;
                        }
                        if (dgv9.Rows[i].Cells[5].Value != null && dgv9.Rows[i].Cells[5].Value.ToString() != " ")
                        {
                            c5 += double.Parse(dgv9.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c5 = c5 + 0;
                        }
                        if (dgv9.Rows[i].Cells[6].Value != null && dgv9.Rows[i].Cells[6].Value.ToString() != " ")
                        {
                            c6 += double.Parse(dgv9.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c6 = c6 + 0;
                        }
                        if (dgv9.Rows[i].Cells[7].Value != null && dgv9.Rows[i].Cells[7].Value.ToString() != " ")
                        {
                            c7 += double.Parse(dgv9.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c7 = c7 + 0;
                        }
                        if (dgv9.Rows[i].Cells[8].Value != null && dgv9.Rows[i].Cells[8].Value.ToString() != " ")
                        {
                            c8 += double.Parse(dgv9.Rows[i].Cells[8].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c8 = c8 + 0;
                        }
                        if (dgv9.Rows[i].Cells[9].Value != null && dgv9.Rows[i].Cells[9].Value.ToString() != " ")
                        {
                            c9 += double.Parse(dgv9.Rows[i].Cells[9].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c9 = c9 + 0;
                        }
                        if (dgv9.Rows[i].Cells[10].Value != null && dgv9.Rows[i].Cells[10].Value.ToString() != " ")
                        {
                            c10 += double.Parse(dgv9.Rows[i].Cells[10].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c10 = c10 + 0;
                        }
                        if (dgv9.Rows[i].Cells[11].Value != null && dgv9.Rows[i].Cells[11].Value.ToString() != " ")
                        {
                            c11 += double.Parse(dgv9.Rows[i].Cells[11].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c11 = c11 + 0;
                        }
                        if (dgv9.Rows[i].Cells[12].Value != null && dgv9.Rows[i].Cells[12].Value.ToString() != " ")
                        {
                            c12 += double.Parse(dgv9.Rows[i].Cells[12].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c12 = c12 + 0;
                        }
                        if (dgv9.Rows[i].Cells[13].Value != null && dgv9.Rows[i].Cells[13].Value.ToString() != " ")
                        {
                            c13 += double.Parse(dgv9.Rows[i].Cells[13].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c13 = c13 + 0;
                        }
                        if (dgv9.Rows[i].Cells[14].Value != null && dgv9.Rows[i].Cells[14].Value.ToString() != " ")
                        {
                            c14 += double.Parse(dgv9.Rows[i].Cells[14].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c14 = c14 + 0;
                        }
                        dgv9.Rows[0].Cells[1].Value = c1.ToString("N2");
                        dgv9.Rows[0].Cells[2].Value = c2.ToString("N2");
                        dgv9.Rows[0].Cells[3].Value = c3.ToString("N2");
                        dgv9.Rows[0].Cells[4].Value = c4.ToString("N2");
                        dgv9.Rows[0].Cells[5].Value = c5.ToString("N2");
                        dgv9.Rows[0].Cells[6].Value = c6.ToString("N2");
                        dgv9.Rows[0].Cells[7].Value = c7.ToString("N2");
                        dgv9.Rows[0].Cells[8].Value = c8.ToString("N2");
                        dgv9.Rows[0].Cells[9].Value = c9.ToString("N2");
                        dgv9.Rows[0].Cells[10].Value = c10.ToString("N2");
                        dgv9.Rows[0].Cells[11].Value = c11.ToString("N2");
                        dgv9.Rows[0].Cells[12].Value = c12.ToString("N2");
                        dgv9.Rows[0].Cells[13].Value = c13.ToString("N2");
                        dgv9.Rows[0].Cells[14].Value = c14.ToString("N2");
                        dgv9.Refresh();
                    }
                    #endregion
                    break;
                case 10:
                    #region renglontotal dgv10
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

                    for (int i = 1; i <= dgv10.Rows.Count - 1; i++)
                    {
                        if (dgv10.Rows[i].Cells[1].Value != null && dgv10.Rows[i].Cells[1].Value.ToString() != " ")
                        {
                            c1 += double.Parse(dgv10.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c1 = c1 + 0;
                        }
                        if (dgv10.Rows[i].Cells[2].Value != null && dgv10.Rows[i].Cells[2].Value.ToString() != " ")
                        {
                            c2 += double.Parse(dgv10.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c2 = c2 + 0;
                        }
                        if (dgv10.Rows[i].Cells[3].Value != null && dgv10.Rows[i].Cells[3].Value.ToString() != " ")
                        {
                            c3 += double.Parse(dgv10.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c3 = c3 + 0;
                        }
                        if (dgv10.Rows[i].Cells[4].Value != null && dgv10.Rows[i].Cells[4].Value.ToString() != " ")
                        {
                            c4 += double.Parse(dgv10.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c4 = c4 + 0;
                        }
                        if (dgv10.Rows[i].Cells[5].Value != null && dgv10.Rows[i].Cells[5].Value.ToString() != " ")
                        {
                            c5 += double.Parse(dgv10.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c5 = c5 + 0;
                        }
                        if (dgv10.Rows[i].Cells[6].Value != null && dgv10.Rows[i].Cells[6].Value.ToString() != " ")
                        {
                            c6 += double.Parse(dgv10.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c6 = c6 + 0;
                        }
                        if (dgv10.Rows[i].Cells[7].Value != null && dgv10.Rows[i].Cells[7].Value.ToString() != " ")
                        {
                            c7 += double.Parse(dgv10.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c7 = c7 + 0;
                        }
                        if (dgv10.Rows[i].Cells[8].Value != null && dgv10.Rows[i].Cells[8].Value.ToString() != " ")
                        {
                            c8 += double.Parse(dgv10.Rows[i].Cells[8].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c8 = c8 + 0;
                        }
                        if (dgv10.Rows[i].Cells[9].Value != null && dgv10.Rows[i].Cells[9].Value.ToString() != " ")
                        {
                            c9 += double.Parse(dgv10.Rows[i].Cells[9].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c9 = c9 + 0;
                        }
                        if (dgv10.Rows[i].Cells[10].Value != null && dgv10.Rows[i].Cells[10].Value.ToString() != " ")
                        {
                            c10 += double.Parse(dgv10.Rows[i].Cells[10].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c10 = c10 + 0;
                        }
                        if (dgv10.Rows[i].Cells[11].Value != null && dgv10.Rows[i].Cells[11].Value.ToString() != " ")
                        {
                            c11 += double.Parse(dgv10.Rows[i].Cells[11].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c11 = c11 + 0;
                        }
                        if (dgv10.Rows[i].Cells[12].Value != null && dgv10.Rows[i].Cells[12].Value.ToString() != " ")
                        {
                            c12 += double.Parse(dgv10.Rows[i].Cells[12].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c12 = c12 + 0;
                        }
                        if (dgv10.Rows[i].Cells[13].Value != null && dgv10.Rows[i].Cells[13].Value.ToString() != " ")
                        {
                            c13 += double.Parse(dgv10.Rows[i].Cells[13].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c13 = c13 + 0;
                        }
                        if (dgv10.Rows[i].Cells[14].Value != null && dgv10.Rows[i].Cells[14].Value.ToString() != " ")
                        {
                            c14 += double.Parse(dgv10.Rows[i].Cells[14].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c14 = c14 + 0;
                        }
                        dgv10.Rows[0].Cells[1].Value = c1.ToString("N2");
                        dgv10.Rows[0].Cells[2].Value = c2.ToString("N2");
                        dgv10.Rows[0].Cells[3].Value = c3.ToString("N2");
                        dgv10.Rows[0].Cells[4].Value = c4.ToString("N2");
                        dgv10.Rows[0].Cells[5].Value = c5.ToString("N2");
                        dgv10.Rows[0].Cells[6].Value = c6.ToString("N2");
                        dgv10.Rows[0].Cells[7].Value = c7.ToString("N2");
                        dgv10.Rows[0].Cells[8].Value = c8.ToString("N2");
                        dgv10.Rows[0].Cells[9].Value = c9.ToString("N2");
                        dgv10.Rows[0].Cells[10].Value = c10.ToString("N2");
                        dgv10.Rows[0].Cells[11].Value = c11.ToString("N2");
                        dgv10.Rows[0].Cells[12].Value = c12.ToString("N2");
                        dgv10.Rows[0].Cells[13].Value = c13.ToString("N2");
                        dgv10.Rows[0].Cells[14].Value = c14.ToString("N2");
                        dgv10.Refresh();
                    }
                    #endregion
                    break;
                case 11:
                    #region renglontotal dgv11
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

                    for (int i = 1; i <= dgv11.Rows.Count - 1; i++)
                    {
                        if (dgv11.Rows[i].Cells[1].Value != null && dgv11.Rows[i].Cells[1].Value.ToString() != " ")
                        {
                            c1 += double.Parse(dgv11.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c1 = c1 + 0;
                        }
                        if (dgv11.Rows[i].Cells[2].Value != null && dgv11.Rows[i].Cells[2].Value.ToString() != " ")
                        {
                            c2 += double.Parse(dgv11.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c2 = c2 + 0;
                        }
                        if (dgv11.Rows[i].Cells[3].Value != null && dgv11.Rows[i].Cells[3].Value.ToString() != " ")
                        {
                            c3 += double.Parse(dgv11.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c3 = c3 + 0;
                        }
                        if (dgv11.Rows[i].Cells[4].Value != null && dgv11.Rows[i].Cells[4].Value.ToString() != " ")
                        {
                            c4 += double.Parse(dgv11.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c4 = c4 + 0;
                        }
                        if (dgv11.Rows[i].Cells[5].Value != null && dgv11.Rows[i].Cells[5].Value.ToString() != " ")
                        {
                            c5 += double.Parse(dgv11.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c5 = c5 + 0;
                        }
                        if (dgv11.Rows[i].Cells[6].Value != null && dgv11.Rows[i].Cells[6].Value.ToString() != " ")
                        {
                            c6 += double.Parse(dgv11.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c6 = c6 + 0;
                        }
                        if (dgv11.Rows[i].Cells[7].Value != null && dgv11.Rows[i].Cells[7].Value.ToString() != " ")
                        {
                            c7 += double.Parse(dgv11.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c7 = c7 + 0;
                        }
                        if (dgv11.Rows[i].Cells[8].Value != null && dgv11.Rows[i].Cells[8].Value.ToString() != " ")
                        {
                            c8 += double.Parse(dgv11.Rows[i].Cells[8].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c8 = c8 + 0;
                        }
                        if (dgv11.Rows[i].Cells[9].Value != null && dgv11.Rows[i].Cells[9].Value.ToString() != " ")
                        {
                            c9 += double.Parse(dgv11.Rows[i].Cells[9].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c9 = c9 + 0;
                        }
                        if (dgv11.Rows[i].Cells[10].Value != null && dgv11.Rows[i].Cells[10].Value.ToString() != " ")
                        {
                            c10 += double.Parse(dgv11.Rows[i].Cells[10].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c10 = c10 + 0;
                        }
                        if (dgv11.Rows[i].Cells[11].Value != null && dgv11.Rows[i].Cells[11].Value.ToString() != " ")
                        {
                            c11 += double.Parse(dgv11.Rows[i].Cells[11].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c11 = c11 + 0;
                        }
                        if (dgv11.Rows[i].Cells[12].Value != null && dgv11.Rows[i].Cells[12].Value.ToString() != " ")
                        {
                            c12 += double.Parse(dgv11.Rows[i].Cells[12].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c12 = c12 + 0;
                        }
                        if (dgv11.Rows[i].Cells[13].Value != null && dgv11.Rows[i].Cells[13].Value.ToString() != " ")
                        {
                            c13 += double.Parse(dgv11.Rows[i].Cells[13].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c13 = c13 + 0;
                        }
                        if (dgv11.Rows[i].Cells[14].Value != null && dgv11.Rows[i].Cells[14].Value.ToString() != " ")
                        {
                            c14 += double.Parse(dgv11.Rows[i].Cells[14].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c14 = c14 + 0;
                        }
                        dgv11.Rows[0].Cells[1].Value = c1.ToString("N2");
                        dgv11.Rows[0].Cells[2].Value = c2.ToString("N2");
                        dgv11.Rows[0].Cells[3].Value = c3.ToString("N2");
                        dgv11.Rows[0].Cells[4].Value = c4.ToString("N2");
                        dgv11.Rows[0].Cells[5].Value = c5.ToString("N2");
                        dgv11.Rows[0].Cells[6].Value = c6.ToString("N2");
                        dgv11.Rows[0].Cells[7].Value = c7.ToString("N2");
                        dgv11.Rows[0].Cells[8].Value = c8.ToString("N2");
                        dgv11.Rows[0].Cells[9].Value = c9.ToString("N2");
                        dgv11.Rows[0].Cells[10].Value = c10.ToString("N2");
                        dgv11.Rows[0].Cells[11].Value = c11.ToString("N2");
                        dgv11.Rows[0].Cells[12].Value = c12.ToString("N2");
                        dgv11.Rows[0].Cells[13].Value = c13.ToString("N2");
                        dgv11.Rows[0].Cells[14].Value = c14.ToString("N2");
                        dgv11.Refresh();
                    }
                    #endregion
                    break;
                case 12:
                    #region renglontotal dgv12
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

                    for (int i = 1; i <= dgv12.Rows.Count - 1; i++)
                    {
                        if (dgv12.Rows[i].Cells[1].Value != null && dgv12.Rows[i].Cells[1].Value.ToString() != " ")
                        {
                            c1 += double.Parse(dgv12.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c1 = c1 + 0;
                        }
                        if (dgv12.Rows[i].Cells[2].Value != null && dgv12.Rows[i].Cells[2].Value.ToString() != " ")
                        {
                            c2 += double.Parse(dgv12.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c2 = c2 + 0;
                        }
                        if (dgv12.Rows[i].Cells[3].Value != null && dgv12.Rows[i].Cells[3].Value.ToString() != " ")
                        {
                            c3 += double.Parse(dgv12.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c3 = c3 + 0;
                        }
                        if (dgv12.Rows[i].Cells[4].Value != null && dgv12.Rows[i].Cells[4].Value.ToString() != " ")
                        {
                            c4 += double.Parse(dgv12.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c4 = c4 + 0;
                        }
                        if (dgv12.Rows[i].Cells[5].Value != null && dgv12.Rows[i].Cells[5].Value.ToString() != " ")
                        {
                            c5 += double.Parse(dgv12.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c5 = c5 + 0;
                        }
                        if (dgv12.Rows[i].Cells[6].Value != null && dgv12.Rows[i].Cells[6].Value.ToString() != " ")
                        {
                            c6 += double.Parse(dgv12.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c6 = c6 + 0;
                        }
                        if (dgv12.Rows[i].Cells[7].Value != null && dgv12.Rows[i].Cells[7].Value.ToString() != " ")
                        {
                            c7 += double.Parse(dgv12.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c7 = c7 + 0;
                        }
                        if (dgv12.Rows[i].Cells[8].Value != null && dgv12.Rows[i].Cells[8].Value.ToString() != " ")
                        {
                            c8 += double.Parse(dgv12.Rows[i].Cells[8].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c8 = c8 + 0;
                        }
                        if (dgv12.Rows[i].Cells[9].Value != null && dgv12.Rows[i].Cells[9].Value.ToString() != " ")
                        {
                            c9 += double.Parse(dgv12.Rows[i].Cells[9].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c9 = c9 + 0;
                        }
                        if (dgv12.Rows[i].Cells[10].Value != null && dgv12.Rows[i].Cells[10].Value.ToString() != " ")
                        {
                            c10 += double.Parse(dgv12.Rows[i].Cells[10].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c10 = c10 + 0;
                        }
                        if (dgv12.Rows[i].Cells[11].Value != null && dgv12.Rows[i].Cells[11].Value.ToString() != " ")
                        {
                            c11 += double.Parse(dgv12.Rows[i].Cells[11].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c11 = c11 + 0;
                        }
                        if (dgv12.Rows[i].Cells[12].Value != null && dgv12.Rows[i].Cells[12].Value.ToString() != " ")
                        {
                            c12 += double.Parse(dgv12.Rows[i].Cells[12].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c12 = c12 + 0;
                        }
                        if (dgv12.Rows[i].Cells[13].Value != null && dgv12.Rows[i].Cells[13].Value.ToString() != " ")
                        {
                            c13 += double.Parse(dgv12.Rows[i].Cells[13].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c13 = c13 + 0;
                        }
                        if (dgv12.Rows[i].Cells[14].Value != null && dgv12.Rows[i].Cells[14].Value.ToString() != " ")
                        {
                            c14 += double.Parse(dgv12.Rows[i].Cells[14].Value.ToString(), NumberStyles.Currency);
                        }
                        else
                        {
                            c14 = c14 + 0;
                        }
                        dgv12.Rows[0].Cells[1].Value = c1.ToString("N2");
                        dgv12.Rows[0].Cells[2].Value = c2.ToString("N2");
                        dgv12.Rows[0].Cells[3].Value = c3.ToString("N2");
                        dgv12.Rows[0].Cells[4].Value = c4.ToString("N2");
                        dgv12.Rows[0].Cells[5].Value = c5.ToString("N2");
                        dgv12.Rows[0].Cells[6].Value = c6.ToString("N2");
                        dgv12.Rows[0].Cells[7].Value = c7.ToString("N2");
                        dgv12.Rows[0].Cells[8].Value = c8.ToString("N2");
                        dgv12.Rows[0].Cells[9].Value = c9.ToString("N2");
                        dgv12.Rows[0].Cells[10].Value = c10.ToString("N2");
                        dgv12.Rows[0].Cells[11].Value = c11.ToString("N2");
                        dgv12.Rows[0].Cells[12].Value = c12.ToString("N2");
                        dgv12.Rows[0].Cells[13].Value = c13.ToString("N2");
                        dgv12.Rows[0].Cells[14].Value = c14.ToString("N2");
                        dgv12.Refresh();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mes"></param>
        /// <param name="año"></param>
        /// <param name="i"></param>
        private void M_unidades_vendidas(int mes, int año, int i)
        {
            double ventasH = 0;
            string q = "";
            int x = 0;
            int y = 0;
            if (solototal != true)
            {
                 x = 1;
            }
            else {  q = "SELECT SUM(ctdnormal) as cantidad FROM VENTASBASE AS V INNER JOIN SUCURSAL AS S ON V.IDSUCURSAL = S.IDSUCURSAL INNER JOIN FECHA AS F ON F.IDFECHA = V.IDFECHA WHERE F.Mes='" + mes + "' and f.anio='" + año + "' ";
            x = 0;
            }
            for(;x<=dgv1.Rows.Count-1;x++)
            {
                if (solototal != true)
                {
                    q = "SELECT SUM(ctdnormal) as cantidad FROM VENTASBASE AS V INNER JOIN SUCURSAL AS S ON V.IDSUCURSAL = S.IDSUCURSAL INNER JOIN FECHA AS F ON F.IDFECHA = V.IDFECHA WHERE F.Mes='" + mes + "' and f.anio='" + año+"' "+wherequery[y];
                }
                checaConexion();
                cmd = new MySqlCommand(q, Conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if(reader["cantidad"].ToString()!="")
                    {
                        ventasH = double.Parse(reader["cantidad"].ToString());
                    }
                    else
                    {
                        ventasH = 0;
                    }
                   m_LLENAR_DGV(i, x, 3, ventasH.ToString("N0"));

                }
                reader.Close();
                y++;
            }
        }
        private void comprasP(int mes, int año, int i)
        {
            double unidades = 0;
            int x = 0;
            if (solototal == false)
            {
                x = 1;
            }
            else
            {
                x = 0;
            }
            int y = 0;
            string q = "";
            año = año + 1;
            for (; x <= dgv1.Rows.Count - 1; x++)
            {
                
                if (solototal == false)
                {
                    q = "Select VentasUnidades from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and anio=" + año + " and mes=" + mes + " " + querycargar[y];
                }
                else
                {
                    q = "Select VentasUnidades from cedula3 where nombre='" + Properties.Settings.Default.escenario + "' and anio=" + año + " and mes=" + mes + " and ZapateriasTorreon=1 and idsucursal=-1 and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'";
                }
                checaConexion();
                cmd = new MySqlCommand(q, Conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["VentasUnidades"].ToString() == "")
                    {
                        unidades = 0;
                    }
                    else
                    {
                        unidades = double.Parse(reader["VentasUnidades"].ToString());
                        if (unidades <= 0)
                        {
                            unidades = 0;
                        }
                    }
                    m_LLENAR_DGV(i, x, 8, unidades.ToString("N0"));
                }
                if (reader.HasRows == false)
                {
                    unidades = 0;
                    m_LLENAR_DGV(i, x, 8, unidades.ToString("N0"));
                }
                y++;
                reader.Close();
                m_REFRESH_DGV();
            }
        }
        private void modelajeHU(int mes, int año, int i)
        {
            //año = año - 1;
            double unidades = 0;
            int z = 0;
            string quer = "";
            if (solototal == false)
            {
                z = 1;
            }
            else { z = 0; }
            int y = 0;
            for (; z <= dgv1.Rows.Count - 1; z++)
            {
                if (solototal == false)
                {
                     quer = "SELECT (COUNT(DISTINCT V.MARCA, V.MODELO))AS MODELOSVENTAS FROM ventasbase AS V  INNER JOIN fecha AS F ON F.IDFECHA = V.IDFECHA WHERE  F.`Anio`=" + año + " AND f.`Mes`=" + mes + " AND IDDIVISIONES=1 AND ctdneta>=0 " + wherequery[y];
                }
                else 
                {
                     quer = "SELECT (COUNT(DISTINCT V.MARCA, V.MODELO))AS MODELOSVENTAS FROM ventasbase AS V  INNER JOIN fecha AS F ON F.IDFECHA = V.IDFECHA WHERE  F.`Anio`=" + año + " AND f.`Mes`=" + mes + " AND IDDIVISIONES=1 AND ctdneta>=0 ";
                }
                
                //string quer = "SELECT HIGH_PRIORITY (COUNT(DISTINCT V.MODELO,V.Marca))AS MODELOSVENTAS FROM exist AS E INNER JOIN fecha AS F ON F.IDFECHA = e.IDFECHA INNER JOIN estarticulo AS v ON E.idarticulo=v.idarticulo WHERE  F.Anio=" + año + " AND f.Mes=" + mes + "  AND ctd>=0 " + wherequery[y];
                cmd.CommandTimeout = 1000000;
                checaConexion();
                cmd = new MySqlCommand(quer, Conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["MODELOSVENTAS"].ToString() == "")
                    {
                        unidades = 0;
                    }
                    else
                    {
                        unidades = double.Parse(reader["MODELOSVENTAS"].ToString());
                    }
                    m_LLENAR_DGV(i, z, 1, unidades.ToString("N0"));
                    y++;
                }
                reader.Close();
            }
        }
        private void modelajeHP(int i)
        {
            switch (i)
            {
                case 1:
                    #region dgv1
                    double unidades = 0;
                    double valor = 0;
                    int z = 0;
                    int x = 0;
                    if (solototal == false)
                    {
                        z = 1;
                        x = 1;
                    }
                    else { z = 0; x = 0; }
                    int y = 0;
                    for (; z <= dgv1.Rows.Count - 1; z++)
                    {
                        unidades += double.Parse(dgv1.Rows[z].Cells[1].Value.ToString());
                    }
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (unidades >= 0 && double.Parse(dgv1.Rows[x].Cells[1].Value.ToString()) != 0)
                        {
                            valor = (double.Parse(dgv1.Rows[x].Cells[1].Value.ToString()) / unidades) * 100;
                        }
                        else
                        {
                            valor = 0;
                        }
                        m_LLENAR_DGV(i, x, 2, valor.ToString("N2"));

                    }
                    #endregion
                    break;
                case 2:
                    #region dgv1
                    unidades = 0;
                    valor = 0;
                    z = 0;
                    x = 0;
                    if (solototal == false)
                    {
                        z = 1;
                        x = 1;
                    }
                    else { z = 0; x = 0; }
                    y = 0;
                    for (; z <= dgv1.Rows.Count - 1; z++)
                    {
                        unidades += double.Parse(dgv2.Rows[z].Cells[1].Value.ToString());
                    }
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (unidades != 0 && double.Parse(dgv2.Rows[x].Cells[1].Value.ToString()) != 0)
                        {
                            valor = (double.Parse(dgv2.Rows[x].Cells[1].Value.ToString()) / unidades) * 100;
                        }
                        else
                        {
                            valor = 0;
                        }
                        m_LLENAR_DGV(i, x, 2, valor.ToString("N2"));

                    }
                    #endregion
                    break;
                case 3:
                    #region dgv1
                    unidades = 0;
                    valor = 0;
                    z = 0;
                    x = 0;
                    if (solototal == false)
                    {
                        z = 1;
                        x = 1;
                    }
                    else { z = 0; x = 0; }
                    y = 0;
                    for (; z <= dgv1.Rows.Count - 1; z++)
                    {
                        unidades += double.Parse(dgv3.Rows[z].Cells[1].Value.ToString());
                    }
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (unidades != 0 && double.Parse(dgv3.Rows[x].Cells[1].Value.ToString()) != 0)
                        {
                            valor = (double.Parse(dgv3.Rows[x].Cells[1].Value.ToString()) / unidades) * 100;
                        }
                        else
                        {
                            valor = 0;
                        }
                        m_LLENAR_DGV(i, x, 2, valor.ToString("N2"));

                    }
                    #endregion
                    break;
                case 4:
                    #region dgv1
                    unidades = 0;
                    valor = 0;
                    z = 0;
                    x = 0;
                    if (solototal == false)
                    {
                        z = 1;
                        x = 1;
                    }
                    else { z = 0; x = 0; }
                    y = 0;
                    for (; z <= dgv1.Rows.Count - 1; z++)
                    {
                        unidades += double.Parse(dgv4.Rows[z].Cells[1].Value.ToString());
                    }
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (unidades != 0 && double.Parse(dgv4.Rows[x].Cells[1].Value.ToString()) != 0)
                        {
                            valor = (double.Parse(dgv4.Rows[x].Cells[1].Value.ToString()) / unidades) * 100;
                        }
                        else
                        {
                            valor = 0;
                        }
                        m_LLENAR_DGV(i, x, 2, valor.ToString("N2"));

                    }
                    #endregion
                    break;
                case 5:
                    #region dgv1
                    unidades = 0;
                    valor = 0;
                    z = 0;
                    x = 0;
                    if (solototal == false)
                    {
                        z = 1;
                        x = 1;
                    }
                    else { z = 0; x = 0; }
                    y = 0;
                    for (; z <= dgv5.Rows.Count - 1; z++)
                    {
                        unidades += double.Parse(dgv5.Rows[z].Cells[1].Value.ToString());
                    }
                    for (; x <= dgv5.Rows.Count - 1; x++)
                    {
                        if (unidades != 0 && double.Parse(dgv5.Rows[x].Cells[1].Value.ToString()) != 0)
                        {
                            valor = (double.Parse(dgv5.Rows[x].Cells[1].Value.ToString()) / unidades) * 100;
                        }
                        else
                        {
                            valor = 0;
                        }
                        m_LLENAR_DGV(i, x, 2, valor.ToString("N2"));

                    }
                    #endregion
                    break;
                case 6:
                    #region dgv1
                    unidades = 0;
                    valor = 0;
                    z = 0;
                    x = 0;
                    if (solototal == false)
                    {
                        z = 1;
                        x = 1;
                    }
                    else { z = 0; x = 0; }
                    y = 0;
                    for (; z <= dgv1.Rows.Count - 1; z++)
                    {
                        unidades += double.Parse(dgv6.Rows[z].Cells[1].Value.ToString());
                    }
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (unidades != 0 && double.Parse(dgv6.Rows[x].Cells[1].Value.ToString()) != 0)
                        {
                            valor = (double.Parse(dgv6.Rows[x].Cells[1].Value.ToString()) / unidades) * 100;
                        }
                        else
                        {
                            valor = 0;
                        }
                        m_LLENAR_DGV(i, x, 2, valor.ToString("N2"));

                    }
                    #endregion
                    break;
                case 7:
                    #region dgv1
                    unidades = 0;
                    valor = 0;
                    z = 0;
                    x = 0;
                    if (solototal == false)
                    {
                        z = 1;
                        x = 1;
                    }
                    else { z = 0; x = 0; }
                    y = 0;
                    for (; z <= dgv1.Rows.Count - 1; z++)
                    {
                        unidades += double.Parse(dgv7.Rows[z].Cells[1].Value.ToString());
                    }
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (unidades != 0 && double.Parse(dgv7.Rows[x].Cells[1].Value.ToString()) != 0)
                        {
                            valor = (double.Parse(dgv7.Rows[x].Cells[1].Value.ToString()) / unidades) * 100;
                        }
                        else
                        {
                            valor = 0;
                        }
                        m_LLENAR_DGV(i, x, 2, valor.ToString("N2"));

                    }
                    #endregion
                    break;
                case 8:
                    #region dgv1
                    unidades = 0;
                    valor = 0;
                    z = 0;
                    x = 0;
                    if (solototal == false)
                    {
                        z = 1;
                        x = 1;
                    }
                    else { z = 0; x = 0; }
                    y = 0;
                    for (; z <= dgv1.Rows.Count - 1; z++)
                    {
                        unidades += double.Parse(dgv8.Rows[z].Cells[1].Value.ToString());
                    }
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (unidades != 0 && double.Parse(dgv8.Rows[x].Cells[1].Value.ToString()) != 0)
                        {
                            valor = (double.Parse(dgv8.Rows[x].Cells[1].Value.ToString()) / unidades) * 100;
                        }
                        else
                        {
                            valor = 0;
                        }
                        m_LLENAR_DGV(i, x, 2, valor.ToString("N2"));

                    }
                    #endregion
                    break;
                case 9:
                    #region dgv1
                    unidades = 0;
                    valor = 0;
                    z = 0;
                    x = 0;
                    if (solototal == false)
                    {
                        z = 1;
                        x = 1;
                    }
                    else { z = 0; x = 0; }
                    y = 0;
                    for (; z <= dgv1.Rows.Count - 1; z++)
                    {
                        unidades += double.Parse(dgv9.Rows[z].Cells[1].Value.ToString());
                    }
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (unidades != 0 && double.Parse(dgv9.Rows[x].Cells[1].Value.ToString()) != 0)
                        {
                            valor = (double.Parse(dgv9.Rows[x].Cells[1].Value.ToString()) / unidades) * 100;
                        }
                        else
                        {
                            valor = 0;
                        }
                        m_LLENAR_DGV(i, x, 2, valor.ToString("N2"));

                    }
                    #endregion
                    break;
                case 10:
                    #region dgv1
                    unidades = 0;
                    valor = 0;
                    z = 0;
                    x = 0;
                    if (solototal == false)
                    {
                        z = 1;
                        x = 1;
                    }
                    else { z = 0; x = 0; }
                    y = 0;
                    for (; z <= dgv1.Rows.Count - 1; z++)
                    {
                        unidades += double.Parse(dgv10.Rows[z].Cells[1].Value.ToString());
                    }
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (unidades != 0 && double.Parse(dgv10.Rows[x].Cells[1].Value.ToString()) != 0)
                        {
                            valor = (double.Parse(dgv10.Rows[x].Cells[1].Value.ToString()) / unidades) * 100;
                        }
                        else
                        {
                            valor = 0;
                        }
                        m_LLENAR_DGV(i, x, 2, valor.ToString("N2"));

                    }
                    #endregion
                    break;
                case 11:
                    #region dgv1
                    unidades = 0;
                    valor = 0;
                    z = 0;
                    x = 0;
                    if (solototal == false)
                    {
                        z = 1;
                        x = 1;
                    }
                    else { z = 0; x = 0; }
                    y = 0;
                    for (; z <= dgv1.Rows.Count - 1; z++)
                    {
                        unidades += double.Parse(dgv11.Rows[z].Cells[1].Value.ToString());
                    }
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (unidades != 0 && double.Parse(dgv11.Rows[x].Cells[1].Value.ToString()) != 0)
                        {
                            valor = (double.Parse(dgv11.Rows[x].Cells[1].Value.ToString()) / unidades) * 100;
                        }
                        else
                        {
                            valor = 0;
                        }
                        m_LLENAR_DGV(i, x, 2, valor.ToString("N2"));

                    }
                    #endregion
                    break;
                case 12:
                    #region dgv1
                    unidades = 0;
                    valor = 0;
                    z = 0;
                    x = 0;
                    if (solototal == false)
                    {
                        z = 1;
                        x = 1;
                    }
                    else { z = 0; x = 0; }
                    y = 0;
                    for (; z <= dgv1.Rows.Count - 1; z++)
                    {
                        unidades += double.Parse(dgv12.Rows[z].Cells[1].Value.ToString());
                    }
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (unidades != 0 && double.Parse(dgv12.Rows[x].Cells[1].Value.ToString()) != 0)
                        {
                            valor = (double.Parse(dgv12.Rows[x].Cells[1].Value.ToString()) / unidades) * 100;
                        }
                        else
                        {
                            valor = 0;
                        }
                        m_LLENAR_DGV(i, x, 2, valor.ToString("N2"));

                    }
                    #endregion
                    break;
            }

        }
        private void modelos_CompraP(int mes, int año,int i)
        {
            double modelajeH = 0;
            double modelajeP = 0;
            double diasInv = 0;
            double ventaH = 0;
            double ventaP = 0;
            año++;
            int x=0;
            int y = 0;
            if(solototal==true)
            {
                x = 0;
            }
            else
            {
                x = 1;
            }
            #region calculo antiguo
            //switch (i)
            // {
            //     case 1:
            //         for (; x <= dgv1.Rows.Count - 1; x++)
            //         {
            //             comprasP = double.Parse(dgv1.Rows[x].Cells[6].Value.ToString());
            //             ventasH = double.Parse(dgv1.Rows[x].Cells[3].Value.ToString());
            //             modelajeH = double.Parse(dgv1.Rows[x].Cells[1].Value.ToString());
            //             if (ventasH != 0 && comprasP != 0 && ventasH != 0)
            //             {
            //                 modelajeP = (comprasP * modelajeH) / ventasH;
            //             }
            //             else
            //             {
            //                 modelajeP = 0;
            //             }
            //             m_LLENAR_DGV(i, x, 4, modelajeP.ToString("N0"));
            //         }
            //             break;
            //     case 2:
            //             for (; x <= dgv1.Rows.Count - 1; x++)
            //             {
            //                 comprasP = double.Parse(dgv2.Rows[x].Cells[6].Value.ToString());
            //                 ventasH = double.Parse(dgv2.Rows[x].Cells[3].Value.ToString());
            //                 modelajeH = double.Parse(dgv2.Rows[x].Cells[1].Value.ToString());
            //                 if (ventasH != 0 && comprasP != 0 && ventasH != 0)
            //                 {
            //                     modelajeP = (comprasP * modelajeH) / ventasH;
            //                 }
            //                 else
            //                 {
            //                     modelajeP = 0;
            //                 }
            //                 m_LLENAR_DGV(i, x, 4, modelajeP.ToString("N0"));
            //             }
            //             break;
            //     case 3:
            //             for (; x <= dgv1.Rows.Count - 1; x++)
            //             {
            //                 comprasP = double.Parse(dgv3.Rows[x].Cells[6].Value.ToString());
            //                 ventasH = double.Parse(dgv3.Rows[x].Cells[3].Value.ToString());
            //                 modelajeH = double.Parse(dgv3.Rows[x].Cells[1].Value.ToString());
            //                 if (ventasH != 0 && comprasP != 0 && ventasH != 0)
            //                 {
            //                     modelajeP = (comprasP * modelajeH) / ventasH;
            //                 }
            //                 else
            //                 {
            //                     modelajeP = 0;
            //                 }
            //                 m_LLENAR_DGV(i, x, 4, modelajeP.ToString("N0"));
            //             }
            //             break;
            //     case 4:
            //             for (; x <= dgv1.Rows.Count - 1; x++)
            //             {
            //                 comprasP = double.Parse(dgv4.Rows[x].Cells[6].Value.ToString());
            //                 ventasH = double.Parse(dgv4.Rows[x].Cells[3].Value.ToString());
            //                 modelajeH = double.Parse(dgv4.Rows[x].Cells[1].Value.ToString());
            //                 if (ventasH != 0 && comprasP != 0 && ventasH != 0)
            //                 {
            //                     modelajeP = (comprasP * modelajeH) / ventasH;
            //                 }
            //                 else
            //                 {
            //                     modelajeP = 0;
            //                 }
            //                 m_LLENAR_DGV(i, x, 4, modelajeP.ToString("N0"));
            //             }
            //             break;
            //     case 5:
            //             for (; x <= dgv1.Rows.Count - 1; x++)
            //             {
            //                 comprasP = double.Parse(dgv5.Rows[x].Cells[6].Value.ToString());
            //                 ventasH = double.Parse(dgv5.Rows[x].Cells[3].Value.ToString());
            //                 modelajeH = double.Parse(dgv5.Rows[x].Cells[1].Value.ToString());
            //                 if (ventasH != 0 && comprasP != 0 && ventasH != 0)
            //                 {
            //                     modelajeP = (comprasP * modelajeH) / ventasH;
            //                 }
            //                 else
            //                 {
            //                     modelajeP = 0;
            //                 }
            //                 m_LLENAR_DGV(i, x, 4, modelajeP.ToString("N0"));
            //             }
            //             break;
            //     case 6:
            //             for (; x <= dgv1.Rows.Count - 1; x++)
            //             {
            //                 comprasP = double.Parse(dgv6.Rows[x].Cells[6].Value.ToString());
            //                 ventasH = double.Parse(dgv6.Rows[x].Cells[3].Value.ToString());
            //                 modelajeH = double.Parse(dgv6.Rows[x].Cells[1].Value.ToString());
            //                 if (ventasH != 0 && comprasP != 0 && ventasH != 0)
            //                 {
            //                     modelajeP = (comprasP * modelajeH) / ventasH;
            //                 }
            //                 else
            //                 {
            //                     modelajeP = 0;
            //                 }
            //                 m_LLENAR_DGV(i, x, 4, modelajeP.ToString("N0"));
            //             }
            //             break;
            //     case 7:
            //             for (; x <= dgv1.Rows.Count - 1; x++)
            //             {
            //                 comprasP = double.Parse(dgv7.Rows[x].Cells[6].Value.ToString());
            //                 ventasH = double.Parse(dgv7.Rows[x].Cells[3].Value.ToString());
            //                 modelajeH = double.Parse(dgv7.Rows[x].Cells[1].Value.ToString());
            //                 if (ventasH != 0 && comprasP != 0 && ventasH != 0)
            //                 {
            //                     modelajeP = (comprasP * modelajeH) / ventasH;
            //                 }
            //                 else
            //                 {
            //                     modelajeP = 0;
            //                 }
            //                 m_LLENAR_DGV(i, x, 4, modelajeP.ToString("N0"));
            //             }
            //             break;
            //     case 8:
            //             for (; x <= dgv1.Rows.Count - 1; x++)
            //             {
            //                 comprasP = double.Parse(dgv8.Rows[x].Cells[6].Value.ToString());
            //                 ventasH = double.Parse(dgv8.Rows[x].Cells[3].Value.ToString());
            //                 modelajeH = double.Parse(dgv8.Rows[x].Cells[1].Value.ToString());
            //                 if (ventasH != 0 && comprasP != 0 && ventasH != 0)
            //                 {
            //                     modelajeP = (comprasP * modelajeH) / ventasH;
            //                 }
            //                 else
            //                 {
            //                     modelajeP = 0;
            //                 }
            //                 m_LLENAR_DGV(i, x, 4, modelajeP.ToString("N0"));
            //             }
            //             break;
            //     case 9:
            //             for (; x <= dgv1.Rows.Count - 1; x++)
            //             {
            //                 comprasP = double.Parse(dgv9.Rows[x].Cells[6].Value.ToString());
            //                 ventasH = double.Parse(dgv9.Rows[x].Cells[3].Value.ToString());
            //                 modelajeH = double.Parse(dgv9.Rows[x].Cells[1].Value.ToString());
            //                 if (ventasH != 0 && comprasP != 0 && ventasH != 0)
            //                 {
            //                     modelajeP = (comprasP * modelajeH) / ventasH;
            //                 }
            //                 else
            //                 {
            //                     modelajeP = 0;
            //                 }
            //                 m_LLENAR_DGV(i, x, 4, modelajeP.ToString("N0"));
            //             }
            //             break;
            //     case 10:
            //             for (; x <= dgv1.Rows.Count - 1; x++)
            //             {
            //                 comprasP = double.Parse(dgv10.Rows[x].Cells[6].Value.ToString());
            //                 ventasH = double.Parse(dgv10.Rows[x].Cells[3].Value.ToString());
            //                 modelajeH = double.Parse(dgv10.Rows[x].Cells[1].Value.ToString());
            //                 if (ventasH != 0 && comprasP != 0 && ventasH != 0)
            //                 {
            //                     modelajeP = (comprasP * modelajeH) / ventasH;
            //                 }
            //                 else
            //                 {
            //                     modelajeP = 0;
            //                 }
            //                 m_LLENAR_DGV(i, x, 4, modelajeP.ToString("N0"));
            //             }
            //             break;
            //     case 11:
            //             for (; x <= dgv1.Rows.Count - 1; x++)
            //             {
            //                 comprasP = double.Parse(dgv11.Rows[x].Cells[6].Value.ToString());
            //                 ventasH = double.Parse(dgv11.Rows[x].Cells[3].Value.ToString());
            //                 modelajeH = double.Parse(dgv11.Rows[x].Cells[1].Value.ToString());
            //                 if (ventasH != 0 && comprasP != 0 && ventasH != 0)
            //                 {
            //                     modelajeP = (comprasP * modelajeH) / ventasH;
            //                 }
            //                 else
            //                 {
            //                     modelajeP = 0;
            //                 }
            //                 m_LLENAR_DGV(i, x, 4, modelajeP.ToString("N0"));
            //             }
            //             break;
            //     case 12:
            //             for (; x <= dgv1.Rows.Count - 1; x++)
            //             {
            //                 comprasP = double.Parse(dgv12.Rows[x].Cells[6].Value.ToString());
            //                 ventasH = double.Parse(dgv12.Rows[x].Cells[3].Value.ToString());
            //                 modelajeH = double.Parse(dgv12.Rows[x].Cells[1].Value.ToString());
            //                 if (ventasH != 0 && comprasP != 0 && ventasH != 0)
            //                 {
            //                     modelajeP = (comprasP * modelajeH) / ventasH;
            //                 }
            //                 else
            //                 {
            //                     modelajeP = 0;
            //                 }
            //                 m_LLENAR_DGV(i, x, 4, modelajeP.ToString("N0"));
            //             }
            //             break;
            // }
            #endregion
            #region antiguo 2
            //switch (i)
            //{
            //    case 1:
            //        #region dgv1
            //        for (;x<=dgv1.Rows.Count-1;x++)
            //        {
            //            string q = "SELECT DiasInventario from cedula3  WHERE anio="+año+" and mes="+mes+" and nombre='"+Properties.Settings.Default.escenario+"' "+querycargar[y];
            //            cmd = new MySqlCommand(q, Conn);
            //            reader = cmd.ExecuteReader();
            //            while (reader.Read())
            //            {
            //                if (reader["DiasInventario"].ToString() != "")
            //                {
            //                    diasInv = double.Parse(reader["DiasInventario"].ToString());
            //                }
            //                else
            //                {
            //                    diasInv = 0;
            //                }
            //            }
            //            reader.Close();
            //            #region query capacidad aparador
            //        if(diasInv!=0||dgv1.Rows[x].Cells[5].Value.ToString()!="")
            //        {
            //            modelajeP = (double.Parse(dgv1.Rows[x].Cells[5].Value.ToString())/diasInv)*30.4;
            //        }
            //        else
            //        {
            //          modelajeP=0;
            //           }
            //            #endregion
            //            dgv1.Rows[x].Cells[6].Value=modelajeP.ToString("N2");
            //            y++;
            //        }
            //        break;
            //        #endregion
            //    case 2:
            //        #region dgv2
            //        for (; x <= dgv2.Rows.Count - 1; x++)
            //        {
            //            string q = "SELECT DiasInventario from cedula3  WHERE anio=" + año + " and mes=" + mes + " and nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[y];
            //            cmd = new MySqlCommand(q, Conn);
            //            reader = cmd.ExecuteReader();
            //            while (reader.Read())
            //            {
            //                if (reader["DiasInventario"].ToString() != "")
            //                {
            //                    diasInv = double.Parse(reader["DiasInventario"].ToString());
            //                }
            //                else
            //                {
            //                    diasInv = 0;
            //                }
            //            }
            //            reader.Close();
            //            #region query capacidad aparador
            //               if(diasInv!=0||dgv2.Rows[x].Cells[5].Value.ToString()!="")
            //            {
            //                modelajeP = (double.Parse(dgv2.Rows[x].Cells[5].Value.ToString())/diasInv)*30.4;
            //            }
            //            else
            //            {
            //              modelajeP=0;
            //               }             
            //            #endregion
            //            dgv2.Rows[x].Cells[6].Value = modelajeP.ToString("N2");
            //            y++;
            //        }
            //        break;
            //        #endregion
            //    case 3:
            //        #region dgv3
            //        for (; x <= dgv3.Rows.Count - 1; x++)
            //        {
            //            string q = "SELECT DiasInventario from cedula3  WHERE anio=" + año + " and mes=" + mes + " and nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[y];
            //            cmd = new MySqlCommand(q, Conn);
            //            reader = cmd.ExecuteReader();
            //            while (reader.Read())
            //            {
            //                if (reader["DiasInventario"].ToString() != "")
            //                {
            //                    diasInv = double.Parse(reader["DiasInventario"].ToString());
            //                }
            //                else
            //                {
            //                    diasInv = 0;
            //                }
            //            }
            //            reader.Close();
            //            #region query capacidad aparador
            //            if (diasInv != 0 || dgv3.Rows[x].Cells[5].Value.ToString() != "")
            //            {
            //                modelajeP = (double.Parse(dgv3.Rows[x].Cells[5].Value.ToString()) / diasInv) * 30.4;
            //            }
            //            else
            //            {
            //                modelajeP = 0;
            //            }    
					
            //            #endregion
            //            dgv3.Rows[x].Cells[6].Value = modelajeP.ToString("N2");
            //            y++;
            //        }
            //        break;
            //        #endregion
            //    case 4:
            //        #region dgv4
            //        for (; x <= dgv4.Rows.Count - 1; x++)
            //        {
            //            string q = "SELECT DiasInventario from cedula3  WHERE anio=" + año + " and mes=" + mes + " and nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[y];
            //            cmd = new MySqlCommand(q, Conn);
            //            reader = cmd.ExecuteReader();
            //            while (reader.Read())
            //            {
            //                if (reader["DiasInventario"].ToString() != "")
            //                {
            //                    diasInv = double.Parse(reader["DiasInventario"].ToString());
            //                }
            //                else
            //                {
            //                    diasInv = 0;
            //                }
            //            }
            //            reader.Close();
            //            #region query capacidad aparador

            //            if (diasInv != 0 || dgv4.Rows[x].Cells[5].Value.ToString() != "")
            //            {
            //                modelajeP = (double.Parse(dgv4.Rows[x].Cells[5].Value.ToString()) / diasInv) * 30.4;
            //            }
            //            else
            //            {
            //                modelajeP = 0;
            //            }
            //            #endregion
            //            dgv4.Rows[x].Cells[6].Value = modelajeP.ToString("N2");
            //            y++;
            //        }
            //        break;
            //        #endregion
            //    case 5:
            //        #region dgv5
            //        for (; x <= dgv5.Rows.Count - 1; x++)
            //        {
            //            string q = "SELECT DiasInventario from cedula3  WHERE anio=" + año + " and mes=" + mes + " and nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[y];
            //            cmd = new MySqlCommand(q, Conn);
            //            reader = cmd.ExecuteReader();
            //            while (reader.Read())
            //            {
            //                if (reader["DiasInventario"].ToString() != "")
            //                {
            //                    diasInv = double.Parse(reader["DiasInventario"].ToString());
            //                }
            //                else
            //                {
            //                    diasInv = 0;
            //                }
            //            }
            //            reader.Close();
            //            #region query capacidad aparador

            //            if (diasInv != 0 || dgv5.Rows[x].Cells[5].Value.ToString() != "")
            //            {
            //                modelajeP = (double.Parse(dgv5.Rows[x].Cells[5].Value.ToString()) / diasInv) * 30.4;
            //            }
            //            else
            //            {
            //                modelajeP = 0;
            //            }
            //            #endregion
            //            dgv5.Rows[x].Cells[6].Value = modelajeP.ToString("N2");
            //            y++;
            //        }
            //        break;
            //        #endregion
            //    case 6:
            //        #region dgv6
            //        for (; x <= dgv6.Rows.Count - 1; x++)
            //        {
            //            string q = "SELECT DiasInventario from cedula3  WHERE anio=" + año + " and mes=" + mes + " and nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[y];
            //            cmd = new MySqlCommand(q, Conn);
            //            reader = cmd.ExecuteReader();
            //            while (reader.Read())
            //            {
            //                if (reader["DiasInventario"].ToString() != "")
            //                {
            //                    diasInv = double.Parse(reader["DiasInventario"].ToString());
            //                }
            //                else
            //                {
            //                    diasInv = 0;
            //                }
            //            }
            //            reader.Close();
            //            #region query capacidad aparador

            //            if (diasInv != 0 || dgv6.Rows[x].Cells[5].Value.ToString() != "")
            //            {
            //                modelajeP = (double.Parse(dgv6.Rows[x].Cells[5].Value.ToString()) / diasInv) * 30.4;
            //            }
            //            else
            //            {
            //                modelajeP = 0;
            //            }
            //            #endregion
            //            dgv6.Rows[x].Cells[6].Value = modelajeP.ToString("N2");
            //            y++;
            //        }
            //        break;
            //        #endregion
            //    case 7:
            //        #region dgv7
            //        for (; x <= dgv7.Rows.Count - 1; x++)
            //        {
            //            string q = "SELECT DiasInventario from cedula3  WHERE anio=" + año + " and mes=" + mes + " and nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[y];
            //            cmd = new MySqlCommand(q, Conn);
            //            reader = cmd.ExecuteReader();
            //            while (reader.Read())
            //            {
            //                if (reader["DiasInventario"].ToString() != "")
            //                {
            //                    diasInv = double.Parse(reader["DiasInventario"].ToString());
            //                }
            //                else
            //                {
            //                    diasInv = 0;
            //                }
            //            }
            //            reader.Close();
            //            #region query capacidad aparador

            //            if (diasInv != 0 || dgv7.Rows[x].Cells[5].Value.ToString() != "")
            //            {
            //                modelajeP = (double.Parse(dgv7.Rows[x].Cells[5].Value.ToString()) / diasInv) * 30.4;
            //            }
            //            else
            //            {
            //                modelajeP = 0;
            //            }
            //            #endregion
            //            dgv7.Rows[x].Cells[6].Value = modelajeP.ToString("N2");
            //            y++;
            //        }
            //        break;
            //        #endregion
            //    case 8:
            //        #region dgv8
            //        for (; x <= dgv8.Rows.Count - 1; x++)
            //        {
            //            string q = "SELECT DiasInventario from cedula3  WHERE anio=" + año + " and mes=" + mes + " and nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[y];
            //            cmd = new MySqlCommand(q, Conn);
            //            reader = cmd.ExecuteReader();
            //            while (reader.Read())
            //            {
            //                if (reader["DiasInventario"].ToString() != "")
            //                {
            //                    diasInv = double.Parse(reader["DiasInventario"].ToString());
            //                }
            //                else
            //                {
            //                    diasInv = 0;
            //                }
            //            }
            //            reader.Close();
            //            #region query capacidad aparador

            //            if (diasInv != 0 || dgv8.Rows[x].Cells[5].Value.ToString() != "")
            //            {
            //                modelajeP = (double.Parse(dgv8.Rows[x].Cells[5].Value.ToString()) / diasInv) * 30.4;
            //            }
            //            else
            //            {
            //                modelajeP = 0;
            //            }
            //            #endregion
            //            dgv8.Rows[x].Cells[6].Value = modelajeP.ToString("N2");
            //            y++;
            //        }
            //        break;
            //        #endregion
            //    case 9:
            //        #region dgv9
            //        for (; x <= dgv9.Rows.Count - 1; x++)
            //        {
            //            string q = "SELECT DiasInventario from cedula3  WHERE anio=" + año + " and mes=" + mes + " and nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[y];
            //            cmd = new MySqlCommand(q, Conn);
            //            reader = cmd.ExecuteReader();
            //            while (reader.Read())
            //            {
            //                if (reader["DiasInventario"].ToString() != "")
            //                {
            //                    diasInv = double.Parse(reader["DiasInventario"].ToString());
            //                }
            //                else
            //                {
            //                    diasInv = 0;
            //                }
            //            }
            //            reader.Close();
            //            #region query capacidad aparador

            //            if (diasInv != 0 || dgv9.Rows[x].Cells[5].Value.ToString() != "")
            //            {
            //                modelajeP = (double.Parse(dgv9.Rows[x].Cells[5].Value.ToString()) / diasInv) * 30.4;
            //            }
            //            else
            //            {
            //                modelajeP = 0;
            //            }
            //            #endregion
            //            dgv9.Rows[x].Cells[6].Value = modelajeP.ToString("N2");
            //            y++;
            //        }
            //        break;
            //        #endregion
            //    case 10:
            //        #region dgv10
            //        for (; x <= dgv10.Rows.Count - 1; x++)
            //        {
            //            string q = "SELECT DiasInventario from cedula3  WHERE anio=" + año + " and mes=" + mes + " and nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[y];
            //            cmd = new MySqlCommand(q, Conn);
            //            reader = cmd.ExecuteReader();
            //            while (reader.Read())
            //            {
            //                if (reader["DiasInventario"].ToString() != "")
            //                {
            //                    diasInv = double.Parse(reader["DiasInventario"].ToString());
            //                }
            //                else
            //                {
            //                    diasInv = 0;
            //                }
            //            }
            //            reader.Close();
            //            #region query capacidad aparador

            //            if (diasInv != 0 || dgv10.Rows[x].Cells[5].Value.ToString() != "")
            //            {
            //                modelajeP = (double.Parse(dgv10.Rows[x].Cells[5].Value.ToString()) / diasInv) * 30.4;
            //            }
            //            else
            //            {
            //                modelajeP = 0;
            //            }
            //            #endregion
            //            dgv10.Rows[x].Cells[6].Value = modelajeP.ToString("N2");
            //            y++;
            //        }
            //        break;
            //        #endregion
            //    case 11:
            //        #region dgv11
            //        for (; x <= dgv11.Rows.Count - 1; x++)
            //        {
            //            string q = "SELECT DiasInventario from cedula3  WHERE anio=" + año + " and mes=" + mes + " and nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[y];
            //            cmd = new MySqlCommand(q, Conn);
            //            reader = cmd.ExecuteReader();
            //            while (reader.Read())
            //            {
            //                if (reader["DiasInventario"].ToString() != "")
            //                {
            //                    diasInv = double.Parse(reader["DiasInventario"].ToString());
            //                }
            //                else
            //                {
            //                    diasInv = 0;
            //                }
            //            }
            //            reader.Close();
            //            #region query capacidad aparador

            //            if (diasInv != 0 || dgv11.Rows[x].Cells[5].Value.ToString() != "")
            //            {
            //                modelajeP = (double.Parse(dgv11.Rows[x].Cells[5].Value.ToString()) / diasInv) * 30.4;
            //            }
            //            else
            //            {
            //                modelajeP = 0;
            //            }
            //            #endregion
            //            dgv11.Rows[x].Cells[6].Value = modelajeP.ToString("N2");
            //            y++;
            //        }
            //        break;
            //        #endregion
            //    case 12:
            //        #region dgv12
            //        for (; x <= dgv12.Rows.Count - 1; x++)
            //        {
            //            string q = "SELECT DiasInventario from cedula3  WHERE anio=" + año + " and mes=" + mes + " and nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[y];
            //            cmd = new MySqlCommand(q, Conn);
            //            reader = cmd.ExecuteReader();
            //            while (reader.Read())
            //            {
            //                if (reader["DiasInventario"].ToString() != "")
            //                {
            //                    diasInv = double.Parse(reader["DiasInventario"].ToString());
            //                }
            //                else
            //                {
            //                    diasInv = 0;
            //                }
            //            }
            //            reader.Close();
            //            #region query capacidad aparador

            //            if (diasInv != 0 || dgv12.Rows[x].Cells[5].Value.ToString() != "")
            //            {
            //                modelajeP = (double.Parse(dgv12.Rows[x].Cells[5].Value.ToString()) / diasInv) * 30.4;
            //            }
            //            else
            //            {
            //                modelajeP = 0;
            //            }
            //            #endregion
            //            dgv12.Rows[x].Cells[6].Value = modelajeP.ToString("N2");
            //            y++;
            //        }
            //        break;
            //        #endregion
            //}
            #endregion
            switch (i)
            {
                case 1:
                    #region dgv1
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        modelajeH = double.Parse(dgv1.Rows[x].Cells[1].Value.ToString(),NumberStyles.Currency);
                        ventaH = double.Parse(dgv1.Rows[x].Cells[3].Value.ToString());
					 ventaP=double.Parse(dgv1.Rows[x].Cells[8].Value.ToString());
					if(modelajeH <= 1 || ventaH <= 1 || ventaP <= 1)
                        {
                            modelajeP = 0;
                        }
					else
                        {
                            modelajeP = (modelajeH * ventaP) / ventaH;

                        }
					dgv1.Rows[x].Cells[6].Value=modelajeP.ToString("N2");
                    }
                    break;
                    #endregion
                case 2:
                    #region dgv2
                    for (; x <= dgv2.Rows.Count - 1; x++)
                    {
                        modelajeH = double.Parse(dgv2.Rows[x].Cells[1].Value.ToString(), NumberStyles.Currency);
                        ventaH = double.Parse(dgv2.Rows[x].Cells[3].Value.ToString());
                        ventaP = double.Parse(dgv2.Rows[x].Cells[8].Value.ToString());
                        if (modelajeH<=1||ventaH<=1||ventaP<=1)
                        {
                            modelajeP = 0;
                        }
                        else
                        {
                            modelajeP = (modelajeH * ventaP) / ventaH;

                        } dgv2.Rows[x].Cells[6].Value = modelajeP.ToString("N2");
                    }
                    break;
                    #endregion
                case 3:
                    #region dgv3
                    for (; x <= dgv3.Rows.Count - 1; x++)
                    {
                        modelajeH = double.Parse(dgv3.Rows[x].Cells[1].Value.ToString(), NumberStyles.Currency);
                        ventaH = double.Parse(dgv3.Rows[x].Cells[3].Value.ToString());
                        ventaP = double.Parse(dgv3.Rows[x].Cells[8].Value.ToString());
                        if (modelajeH<=1||ventaH<=1||ventaP<=1)
                        {
                            modelajeP = 0;
                        }
                        else
                        {
                            modelajeP = (modelajeH * ventaP) / ventaH;

                        }
                        dgv3.Rows[x].Cells[6].Value = modelajeP.ToString("N2");
                    }
                    break;
                    #endregion
                case 4:
                    #region dgv4
                    for (; x <= dgv4.Rows.Count - 1; x++)
                    {
                        modelajeH = double.Parse(dgv4.Rows[x].Cells[1].Value.ToString(), NumberStyles.Currency);
                        ventaH = double.Parse(dgv4.Rows[x].Cells[3].Value.ToString());
                        ventaP = double.Parse(dgv4.Rows[x].Cells[8].Value.ToString());
                        if (modelajeH<=1||ventaH<=1||ventaP<=1)
                        {
                            modelajeP = 0;
                        }
                        else
                        {
                            modelajeP = (modelajeH * ventaP) / ventaH;

                        }
                        dgv4.Rows[x].Cells[6].Value = modelajeP.ToString("N2");
                    }
                    break;
                    #endregion
                case 5:
                    #region dgv5
                    for (; x <= dgv5.Rows.Count - 1; x++)
                    {
                        modelajeH = double.Parse(dgv5.Rows[x].Cells[1].Value.ToString(), NumberStyles.Currency);
                        ventaH = double.Parse(dgv5.Rows[x].Cells[3].Value.ToString());
                        ventaP = double.Parse(dgv5.Rows[x].Cells[8].Value.ToString());
                        if (modelajeH<=1||ventaH<=1||ventaP<=1)
                        {
                            modelajeP = 0;
                        }
                        else
                        {
                            modelajeP = (modelajeH * ventaP) / ventaH;

                        } 
                        dgv5.Rows[x].Cells[6].Value = modelajeP.ToString("N2");
                    }
                    break;
                    #endregion
                case 6:
                    #region dgv6
                    for (; x <= dgv6.Rows.Count - 1; x++)
                    {
                        modelajeH = double.Parse(dgv6.Rows[x].Cells[1].Value.ToString(), NumberStyles.Currency);
                        ventaH = double.Parse(dgv6.Rows[x].Cells[3].Value.ToString());
                        ventaP = double.Parse(dgv6.Rows[x].Cells[8].Value.ToString());
                        if (modelajeH<=1||ventaH<=1||ventaP<=1)
                        {
                            modelajeP = 0;
                        }
                        else
                        {
                            modelajeP = (modelajeH * ventaP) / ventaH;

                        } 
                        dgv6.Rows[x].Cells[6].Value = modelajeP.ToString("N2");
                    }
                    break;
                    #endregion
                case 7:
                    #region dgv7
                    for (; x <= dgv7.Rows.Count - 1; x++)
                    {
                        modelajeH = double.Parse(dgv7.Rows[x].Cells[1].Value.ToString(), NumberStyles.Currency);
                        ventaH = double.Parse(dgv7.Rows[x].Cells[3].Value.ToString());
                        ventaP = double.Parse(dgv7.Rows[x].Cells[8].Value.ToString());
                        if (modelajeH<=1||ventaH<=1||ventaP<=1)
                        {
                            modelajeP = 0;
                        }
                        else
                        {
                            modelajeP = (modelajeH * ventaP) / ventaH;

                        } 
                        dgv7.Rows[x].Cells[6].Value = modelajeP.ToString("N2");
                    }
                    break;
                    #endregion
                case 8:
                    #region dgv8
                    for (; x <= dgv8.Rows.Count - 1; x++)
                    {
                        modelajeH = double.Parse(dgv8.Rows[x].Cells[1].Value.ToString(), NumberStyles.Currency);
                        ventaH = double.Parse(dgv8.Rows[x].Cells[3].Value.ToString());
                        ventaP = double.Parse(dgv8.Rows[x].Cells[8].Value.ToString());
                        if (modelajeH<=1||ventaH<=1||ventaP<=1)
                        {
                            modelajeP = 0;
                        }
                        else
                        {
                            modelajeP = (modelajeH * ventaP) / ventaH;

                        } 
                        dgv8.Rows[x].Cells[6].Value = modelajeP.ToString("N2");
                    }
                    break;
                    #endregion
                case 9:
                    #region dgv9
                    for (; x <= dgv9.Rows.Count - 1; x++)
                    {
                        modelajeH = double.Parse(dgv9.Rows[x].Cells[1].Value.ToString(), NumberStyles.Currency);
                        ventaH = double.Parse(dgv9.Rows[x].Cells[3].Value.ToString());
                        ventaP = double.Parse(dgv9.Rows[x].Cells[8].Value.ToString());
                        if (modelajeH<=1||ventaH<=1||ventaP<=1)
                        {
                            modelajeP = 0;
                        }
                        else
                        {
                            modelajeP = (modelajeH * ventaP) / ventaH;

                        } 
                        dgv9.Rows[x].Cells[6].Value = modelajeP.ToString("N2");
                    }
                    break;
                    #endregion
                case 10:
                    #region dgv10
                    for (; x <= dgv10.Rows.Count - 1; x++)
                    {
                        modelajeH = double.Parse(dgv10.Rows[x].Cells[1].Value.ToString(), NumberStyles.Currency);
                        ventaH = double.Parse(dgv10.Rows[x].Cells[3].Value.ToString());
                        ventaP = double.Parse(dgv10.Rows[x].Cells[8].Value.ToString());
                        if (modelajeH<=1||ventaH<=1||ventaP<=1)
                        {
                            modelajeP = 0;
                        }
                        else
                        {
                            modelajeP = (modelajeH * ventaP) / ventaH;

                        } 
                        dgv10.Rows[x].Cells[6].Value = modelajeP.ToString("N2");
                    }
                    break;
                    #endregion
                case 11:
                    #region dgv11
                    for (; x <= dgv11.Rows.Count - 1; x++)
                    {
                        modelajeH = double.Parse(dgv11.Rows[x].Cells[1].Value.ToString(), NumberStyles.Currency);
                        ventaH = double.Parse(dgv11.Rows[x].Cells[3].Value.ToString());
                        ventaP = double.Parse(dgv11.Rows[x].Cells[8].Value.ToString());
                        if (modelajeH<=1||ventaH<=1||ventaP<=1)
                        {
                            modelajeP = 0;
                        }
                        else
                        {
                            modelajeP = (modelajeH * ventaP) / ventaH;

                        } 
                        dgv11.Rows[x].Cells[6].Value = modelajeP.ToString("N2");
                    }
                    break;
                    #endregion
                case 12:
                    #region dgv12
                    for (; x <= dgv12.Rows.Count - 1; x++)
                    {
                        modelajeH = double.Parse(dgv12.Rows[x].Cells[1].Value.ToString(), NumberStyles.Currency);
                        ventaH = double.Parse(dgv12.Rows[x].Cells[3].Value.ToString());
                        ventaP = double.Parse(dgv12.Rows[x].Cells[8].Value.ToString());
                        if (modelajeH<=1||ventaH<=1||ventaP<=1)
                        {
                            modelajeP = 0;
                        }
                        else
                        {
                            modelajeP = (modelajeH * ventaP) / ventaH;

                        } 
                        
                        dgv12.Rows[x].Cells[6].Value = modelajeP.ToString("N2");
                    }
                    break;
                    #endregion
            }
        }
        private void modelajePP(int i)
        {
            double suma = 0;
            double value = 0;
            int y = 0;
            int x = 0;
            if(solototal==true)
            {
                x = 0;
                y = 0;
            }
            else
            {
                x = 1;
                y = 1;
            }
            switch (i)
            {
                case 1:
                    for (; y <= dgv1.Rows.Count - 1; y++)
                    {
                        suma += double.Parse(dgv1.Rows[y].Cells[6].Value.ToString());
                    }
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (suma != 0 && double.Parse(dgv1.Rows[x].Cells[6].Value.ToString())!=0)
                        {
                            value = (double.Parse(dgv1.Rows[x].Cells[6].Value.ToString()) / suma) * 100;
                        }
                        else
                        {
                            value = 0;
                        }

                        dgv1.Rows[x].Cells[7].Value = value.ToString("N0");
                    }
                    break;
                case 2:
                    for (; y <= dgv2.Rows.Count - 1; y++)
                    {
                        suma += double.Parse(dgv2.Rows[y].Cells[6].Value.ToString());
                    }
                    for (; x <= dgv2.Rows.Count - 1; x++)
                    {
                        if (suma != 0 && double.Parse(dgv2.Rows[x].Cells[6].Value.ToString()) != 0)
                        {
                            value = (double.Parse(dgv2.Rows[x].Cells[6].Value.ToString()) / suma) * 100;
                        }
                        else
                        {
                            value = 0;
                        }

                        dgv2.Rows[x].Cells[7].Value = value.ToString("N0");
                    }
                    break;
                case 3:
                    for (; y <= dgv3.Rows.Count - 1; y++)
                    {
                        suma += double.Parse(dgv3.Rows[y].Cells[6].Value.ToString());
                    }
                    for (; x <= dgv3.Rows.Count - 1; x++)
                    {
                        if (suma != 0 && double.Parse(dgv3.Rows[x].Cells[6].Value.ToString()) != 0)
                        {
                            value = (double.Parse(dgv3.Rows[x].Cells[6].Value.ToString()) / suma) * 100;
                        }
                        else
                        {
                            value = 0;
                        }

                        dgv3.Rows[x].Cells[7].Value = value.ToString("N0");
                    }
                    break;
                case 4:
                    for (; y <= dgv4.Rows.Count - 1; y++)
                    {
                        suma += double.Parse(dgv4.Rows[y].Cells[6].Value.ToString());
                    }
                    for (; x <= dgv4.Rows.Count - 1; x++)
                    {
                        if (suma != 0 && double.Parse(dgv4.Rows[x].Cells[6].Value.ToString()) != 0)
                        {
                            value = (double.Parse(dgv4.Rows[x].Cells[6].Value.ToString()) / suma) * 100;
                        }
                        else
                        {
                            value = 0;
                        }

                        dgv4.Rows[x].Cells[7].Value = value.ToString("N0");
                    }
                    break;
                case 5:
                    for (; y <= dgv5.Rows.Count - 1; y++)
                    {
                        suma += double.Parse(dgv5.Rows[y].Cells[6].Value.ToString());
                    }
                    for (; x <= dgv5.Rows.Count - 1; x++)
                    {
                        if (suma != 0 && double.Parse(dgv5.Rows[x].Cells[6].Value.ToString()) != 0)
                        {
                            value = (double.Parse(dgv5.Rows[x].Cells[6].Value.ToString()) / suma) * 100;
                        }
                        else
                        {
                            value = 0;
                        }

                        dgv5.Rows[x].Cells[7].Value = value.ToString("N0");
                    }
                    break;
                case 6:
                    for (; y <= dgv6.Rows.Count - 1; y++)
                    {
                        suma += double.Parse(dgv6.Rows[y].Cells[6].Value.ToString());
                    }
                    for (; x <= dgv6.Rows.Count - 1; x++)
                    {
                        if (suma != 0 && double.Parse(dgv6.Rows[x].Cells[6].Value.ToString()) != 0)
                        {
                            value = (double.Parse(dgv6.Rows[x].Cells[6].Value.ToString()) / suma) * 100;
                        }
                        else
                        {
                            value = 0;
                        }

                        dgv6.Rows[x].Cells[7].Value = value.ToString("N0");
                    }
                    break;
                case 7:
                    for (; y <= dgv7.Rows.Count - 1; y++)
                    {
                        suma += double.Parse(dgv7.Rows[y].Cells[6].Value.ToString());
                    }
                    for (; x <= dgv7.Rows.Count - 1; x++)
                    {
                        if (suma != 0 && double.Parse(dgv7.Rows[x].Cells[6].Value.ToString()) != 0)
                        {
                            value = (double.Parse(dgv7.Rows[x].Cells[6].Value.ToString()) / suma) * 100;
                        }
                        else
                        {
                            value = 0;
                        }

                        dgv7.Rows[x].Cells[7].Value = value.ToString("N0");
                    }
                    break;
                case 8:
                    for (; y <= dgv8.Rows.Count - 1; y++)
                    {
                        suma += double.Parse(dgv8.Rows[y].Cells[6].Value.ToString());
                    }
                    for (; x <= dgv8.Rows.Count - 1; x++)
                    {
                        if (suma != 0 && double.Parse(dgv8.Rows[x].Cells[6].Value.ToString()) != 0)
                        {
                            value = (double.Parse(dgv8.Rows[x].Cells[6].Value.ToString()) / suma) * 100;
                        }
                        else
                        {
                            value = 0;
                        }

                        dgv8.Rows[x].Cells[7].Value = value.ToString("N0");
                    }
                    break;
                case 9:
                    for (; y <= dgv9.Rows.Count - 1; y++)
                    {
                        suma += double.Parse(dgv9.Rows[y].Cells[6].Value.ToString());
                    }
                    for (; x <= dgv9.Rows.Count - 1; x++)
                    {
                        if (suma != 0 && double.Parse(dgv9.Rows[x].Cells[6].Value.ToString()) != 0)
                        {
                            value = (double.Parse(dgv9.Rows[x].Cells[6].Value.ToString()) / suma) * 100;
                        }
                        else
                        {
                            value = 0;
                        }

                        dgv9.Rows[x].Cells[7].Value = value.ToString("N0");
                    }
                    break;
                case 10:
                    for (; y <= dgv10.Rows.Count - 1; y++)
                    {
                        suma += double.Parse(dgv10.Rows[y].Cells[6].Value.ToString());
                    }
                    for (; x <= dgv10.Rows.Count - 1; x++)
                    {
                        if (suma != 0 && double.Parse(dgv10.Rows[x].Cells[6].Value.ToString()) != 0)
                        {
                            value = (double.Parse(dgv10.Rows[x].Cells[6].Value.ToString()) / suma) * 100;
                        }
                        else
                        {
                            value = 0;
                        }

                        dgv10.Rows[x].Cells[7].Value = value.ToString("N0");
                    }
                    break;
                case 11:
                    for (; y <= dgv11.Rows.Count - 1; y++)
                    {
                        suma += double.Parse(dgv11.Rows[y].Cells[6].Value.ToString());
                    }
                    for (; x <= dgv11.Rows.Count - 1; x++)
                    {
                        if (suma != 0 && double.Parse(dgv11.Rows[x].Cells[6].Value.ToString()) != 0)
                        {
                            value = (double.Parse(dgv11.Rows[x].Cells[6].Value.ToString()) / suma) * 100;
                        }
                        else
                        {
                            value = 0;
                        }

                        dgv11.Rows[x].Cells[7].Value = value.ToString("N0");
                    }
                    break;
                case 12:
                    for (; y <= dgv12.Rows.Count - 1; y++)
                    {
                        suma += double.Parse(dgv12.Rows[y].Cells[6].Value.ToString());
                    }
                    for (; x <= dgv12.Rows.Count - 1; x++)
                    {
                        if (suma != 0 && double.Parse(dgv12.Rows[x].Cells[6].Value.ToString()) != 0)
                        {
                            value = (double.Parse(dgv12.Rows[x].Cells[6].Value.ToString()) / suma) * 100;
                        }
                        else
                        {
                            value = 0;
                        }

                        dgv12.Rows[x].Cells[7].Value = value.ToString("N0");
                    }
                    break;
            }
        }
        private void Pares_aComprar(int i)
        {
            int x = 0;
            if (solototal == false)
            {
                x = 1;
            }
            else
            {
                x = 0;
            }
            switch (i)
            {
                case 1:
                    double unidades = 0;
                    double ochenta = 0, veinte = 0;
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        unidades = double.Parse(dgv1.Rows[x].Cells[8].Value.ToString(), NumberStyles.Currency);
                        ochenta = unidades * .80;
                        veinte = unidades * .20;
                        m_LLENAR_DGV(i, x, 9, ochenta.ToString("N0"));
                        m_LLENAR_DGV(i, x, 10, veinte.ToString("N0"));
                    }
                    break;
                case 2:
                    unidades = 0;
                    ochenta = 0; veinte = 0;
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        unidades = double.Parse(dgv2.Rows[x].Cells[8].Value.ToString(), NumberStyles.Currency);
                        ochenta = unidades * .80;
                        veinte = unidades * .20;
                        m_LLENAR_DGV(i, x, 9, ochenta.ToString("N0"));
                        m_LLENAR_DGV(i, x, 10, veinte.ToString("N0"));
                    }
                    break;
                case 3:
                    unidades = 0;
                    ochenta = 0; veinte = 0;
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        unidades = double.Parse(dgv3.Rows[x].Cells[8].Value.ToString(), NumberStyles.Currency);
                        ochenta = unidades * .80;
                        veinte = unidades * .20;
                        m_LLENAR_DGV(i, x, 9, ochenta.ToString("N0"));
                        m_LLENAR_DGV(i, x, 10, veinte.ToString("N0"));
                    }
                    break;
                case 4:
                    unidades = 0;
                    ochenta = 0; veinte = 0;
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        unidades = double.Parse(dgv4.Rows[x].Cells[8].Value.ToString(), NumberStyles.Currency);
                        ochenta = unidades * .80;
                        veinte = unidades * .20;
                        m_LLENAR_DGV(i, x, 9, ochenta.ToString("N0"));
                        m_LLENAR_DGV(i, x, 10, veinte.ToString("N0"));
                    }
                    break;
                case 5:
                    unidades = 0;
                    ochenta = 0; veinte = 0;
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        unidades = double.Parse(dgv5.Rows[x].Cells[8].Value.ToString(), NumberStyles.Currency);
                        ochenta = unidades * .80;
                        veinte = unidades * .20;
                        m_LLENAR_DGV(i, x, 9, ochenta.ToString("N0"));
                        m_LLENAR_DGV(i, x, 10, veinte.ToString("N0"));
                    }
                    break;
                case 6:
                    unidades = 0;
                    ochenta = 0; veinte = 0;
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        unidades = double.Parse(dgv6.Rows[x].Cells[8].Value.ToString(), NumberStyles.Currency);
                        ochenta = unidades * .80;
                        veinte = unidades * .20;
                        m_LLENAR_DGV(i, x, 9, ochenta.ToString("N0"));
                        m_LLENAR_DGV(i, x, 10, veinte.ToString("N0"));
                    }
                    break;
                case 7:
                    unidades = 0;
                    ochenta = 0; veinte = 0;
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        unidades = double.Parse(dgv7.Rows[x].Cells[8].Value.ToString(), NumberStyles.Currency);
                        ochenta = unidades * .80;
                        veinte = unidades * .20;
                        m_LLENAR_DGV(i, x, 9, ochenta.ToString("N0"));
                        m_LLENAR_DGV(i, x, 10, veinte.ToString("N0"));
                    }
                    break;
                case 8:
                    unidades = 0;
                    ochenta = 0; veinte = 0;
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        unidades = double.Parse(dgv8.Rows[x].Cells[8].Value.ToString(), NumberStyles.Currency);
                        ochenta = unidades * .80;
                        veinte = unidades * .20;
                        m_LLENAR_DGV(i, x, 9, ochenta.ToString("N0"));
                        m_LLENAR_DGV(i, x, 10, veinte.ToString("N0"));
                    }
                    break;
                case 9:
                    unidades = 0;
                    ochenta = 0; veinte = 0;
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        unidades = double.Parse(dgv9.Rows[x].Cells[8].Value.ToString(), NumberStyles.Currency);
                        ochenta = unidades * .80;
                        veinte = unidades * .20;
                        m_LLENAR_DGV(i, x, 9, ochenta.ToString("N0"));
                        m_LLENAR_DGV(i, x, 10, veinte.ToString("N0"));
                    }
                    break;
                case 10:
                    unidades = 0;
                    ochenta = 0; veinte = 0;
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        unidades = double.Parse(dgv10.Rows[x].Cells[8].Value.ToString(), NumberStyles.Currency);
                        ochenta = unidades * .80;
                        veinte = unidades * .20;
                        m_LLENAR_DGV(i, x, 9, ochenta.ToString("N0"));
                        m_LLENAR_DGV(i, x, 10, veinte.ToString("N0"));
                    }
                    break;
                case 11:
                    unidades = 0;
                    ochenta = 0; veinte = 0;
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        unidades = double.Parse(dgv11.Rows[x].Cells[8].Value.ToString(), NumberStyles.Currency);
                        ochenta = unidades * .80;
                        veinte = unidades * .20;
                        m_LLENAR_DGV(i, x, 9, ochenta.ToString("N0"));
                        m_LLENAR_DGV(i, x, 10, veinte.ToString("N0"));
                    }
                    break;
                case 12:
                    unidades = 0;
                    ochenta = 0; veinte = 0;
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        unidades = double.Parse(dgv12.Rows[x].Cells[8].Value.ToString(), NumberStyles.Currency);
                        ochenta = unidades * .80;
                        veinte = unidades * .20;
                        m_LLENAR_DGV(i, x, 9, ochenta.ToString("N0"));
                        m_LLENAR_DGV(i, x, 10, veinte.ToString("N0"));
                    }
                    break;
            }
        }

        private void asignacionModelos(int i)
        {
            double modelo = 0;
            double ochenta = 0;
            double veinte = 0;
            int x = 0;
            if (solototal == false)
            {
                x = 1;

            }
            else
            {
                x = 0;
            }
            switch (i)
            {
                case 1:
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        modelo = double.Parse(dgv1.Rows[x].Cells[6].Value.ToString());
                        ochenta = modelo * .80;
                        veinte = modelo * .20;
                        m_LLENAR_DGV(i, x, 11, veinte.ToString("N0"));
                        m_LLENAR_DGV(i, x, 12, ochenta.ToString("N0"));
                    }
                    break;
                case 2:
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        modelo = double.Parse(dgv2.Rows[x].Cells[6].Value.ToString());
                        ochenta = modelo * .80;
                        veinte = modelo * .20;
                        m_LLENAR_DGV(i, x, 11, veinte.ToString("N0"));
                        m_LLENAR_DGV(i, x, 12, ochenta.ToString("N0"));
                    }
                    break;
                case 3:
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        modelo = double.Parse(dgv3.Rows[x].Cells[6].Value.ToString());
                        ochenta = modelo * .80;
                        veinte = modelo * .20;
                        m_LLENAR_DGV(i, x, 11, veinte.ToString("N0"));
                        m_LLENAR_DGV(i, x, 12, ochenta.ToString("N0"));
                    }
                    break;
                case 4:
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        modelo = double.Parse(dgv4.Rows[x].Cells[6].Value.ToString());
                        ochenta = modelo * .80;
                        veinte = modelo * .20;
                        m_LLENAR_DGV(i, x, 11, veinte.ToString("N0"));
                        m_LLENAR_DGV(i, x, 12, ochenta.ToString("N0"));
                    }
                    break;
                case 5:
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        modelo = double.Parse(dgv5.Rows[x].Cells[6].Value.ToString());
                        ochenta = modelo * .80;
                        veinte = modelo * .20;
                        m_LLENAR_DGV(i, x, 11, veinte.ToString("N0"));
                        m_LLENAR_DGV(i, x, 12, ochenta.ToString("N0"));
                    }
                    break;
                case 6:
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        modelo = double.Parse(dgv6.Rows[x].Cells[6].Value.ToString());
                        ochenta = modelo * .80;
                        veinte = modelo * .20;
                        m_LLENAR_DGV(i, x, 11, veinte.ToString("N0"));
                        m_LLENAR_DGV(i, x, 12, ochenta.ToString("N0"));
                    }
                    break;
                case 7:
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        modelo = double.Parse(dgv7.Rows[x].Cells[6].Value.ToString());
                        ochenta = modelo * .80;
                        veinte = modelo * .20;
                        m_LLENAR_DGV(i, x, 11, veinte.ToString("N0"));
                        m_LLENAR_DGV(i, x, 12, ochenta.ToString("N0"));
                    }
                    break;
                case 8:
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        modelo = double.Parse(dgv8.Rows[x].Cells[6].Value.ToString());
                        ochenta = modelo * .80;
                        veinte = modelo * .20;
                        m_LLENAR_DGV(i, x, 11, veinte.ToString("N0"));
                        m_LLENAR_DGV(i, x, 12, ochenta.ToString("N0"));
                    }
                    break;
                case 9:
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        modelo = double.Parse(dgv9.Rows[x].Cells[6].Value.ToString());
                        ochenta = modelo * .80;
                        veinte = modelo * .20;
                        m_LLENAR_DGV(i, x, 11, veinte.ToString("N0"));
                        m_LLENAR_DGV(i, x, 12, ochenta.ToString("N0"));
                    }
                    break;
                case 10:
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        modelo = double.Parse(dgv10.Rows[x].Cells[6].Value.ToString());
                        ochenta = modelo * .80;
                        veinte = modelo * .20;
                        m_LLENAR_DGV(i, x, 11, veinte.ToString("N0"));
                        m_LLENAR_DGV(i, x, 12, ochenta.ToString("N0"));
                    }
                    break;
                case 11:
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        modelo = double.Parse(dgv11.Rows[x].Cells[6].Value.ToString());
                        ochenta = modelo * .80;
                        veinte = modelo * .20;
                        m_LLENAR_DGV(i, x, 11, veinte.ToString("N0"));
                        m_LLENAR_DGV(i, x, 12, ochenta.ToString("N0"));
                    }
                    break;
                case 12:
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        modelo = double.Parse(dgv12.Rows[x].Cells[6].Value.ToString());
                        ochenta = modelo * .80;
                        veinte = modelo * .20;
                        m_LLENAR_DGV(i, x, 11, veinte.ToString("N0"));
                        m_LLENAR_DGV(i, x, 12, ochenta.ToString("N0"));
                    }
                    break;
            }
        }
        private void profundidad(int i)
        {
            double ochenta = 0;
            double veinte = 0;
            double unidadesO = 0;
            double unidadesV = 0;
            double modelosO = 0;
            double modelosV = 0;
            int x = 0;
            if (solototal == false)
            {
                x = 1;
            }
            else
            {
                x = 0;
            }
            switch (i)
            {
                case 1:
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        unidadesO = double.Parse(dgv1.Rows[x].Cells[9].Value.ToString(), NumberStyles.Currency);
                        unidadesV = double.Parse(dgv1.Rows[x].Cells[10].Value.ToString(), NumberStyles.Currency);
                        modelosO = double.Parse(dgv1.Rows[x].Cells[11].Value.ToString(), NumberStyles.Currency);
                        modelosV = double.Parse(dgv1.Rows[x].Cells[12].Value.ToString());
                        if (unidadesO != 0 && modelosO != 0)
                        {
                            ochenta = unidadesO / modelosO;
                        }
                        else { ochenta = 0; }
                        if (unidadesV != 0 && modelosV != 0)
                        {
                            veinte = unidadesV / modelosV;
                        }
                        else { veinte = 0; }
                        m_LLENAR_DGV(i, x, 13, ochenta.ToString("N2"));
                        m_LLENAR_DGV(i, x, 14, veinte.ToString("N2"));
                    }
                    break;
                case 2:
                    for (; x <= dgv2.Rows.Count - 1; x++)
                    {
                        unidadesO = double.Parse(dgv2.Rows[x].Cells[9].Value.ToString(), NumberStyles.Currency);
                        unidadesV = double.Parse(dgv2.Rows[x].Cells[10].Value.ToString(), NumberStyles.Currency);
                        modelosO = double.Parse(dgv2.Rows[x].Cells[11].Value.ToString(), NumberStyles.Currency);
                        modelosV = double.Parse(dgv2.Rows[x].Cells[12].Value.ToString());
                        if (unidadesO != 0 && modelosO != 0)
                        {
                            ochenta = unidadesO / modelosO;
                        }
                        else { ochenta = 0; }
                        if (unidadesV != 0 && modelosV != 0)
                        {
                            veinte = unidadesV / modelosV;
                        }
                        else { veinte = 0; }
                        m_LLENAR_DGV(i, x, 13, ochenta.ToString("N2"));
                        m_LLENAR_DGV(i, x, 14, veinte.ToString("N2"));
                    }
                    break;
                case 3:
                    for (; x <= dgv3.Rows.Count - 1; x++)
                    {
                        unidadesO = double.Parse(dgv3.Rows[x].Cells[9].Value.ToString(), NumberStyles.Currency);
                        unidadesV = double.Parse(dgv3.Rows[x].Cells[10].Value.ToString(), NumberStyles.Currency);
                        modelosO = double.Parse(dgv3.Rows[x].Cells[11].Value.ToString(), NumberStyles.Currency);
                        modelosV = double.Parse(dgv3.Rows[x].Cells[12].Value.ToString());
                        if (unidadesO != 0 && modelosO != 0)
                        {
                            ochenta = unidadesO / modelosO;
                        }
                        else { ochenta = 0; }
                        if (unidadesV != 0 && modelosV != 0)
                        {
                            veinte = unidadesV / modelosV;
                        }
                        else { veinte = 0; }
                        m_LLENAR_DGV(i, x, 13, ochenta.ToString("N2"));
                        m_LLENAR_DGV(i, x, 14, veinte.ToString("N2"));
                    }
                    break;
                case 4:
                    for (; x <= dgv4.Rows.Count - 1; x++)
                    {
                        unidadesO = double.Parse(dgv4.Rows[x].Cells[9].Value.ToString(), NumberStyles.Currency);
                        unidadesV = double.Parse(dgv4.Rows[x].Cells[10].Value.ToString(), NumberStyles.Currency);
                        modelosO = double.Parse(dgv4.Rows[x].Cells[11].Value.ToString(), NumberStyles.Currency);
                        modelosV = double.Parse(dgv4.Rows[x].Cells[12].Value.ToString());
                        if (unidadesO != 0 && modelosO != 0)
                        {
                            ochenta = unidadesO / modelosO;
                        }
                        else { ochenta = 0; }
                        if (unidadesV != 0 && modelosV != 0)
                        {
                            veinte = unidadesV / modelosV;
                        }
                        else { veinte = 0; }
                        m_LLENAR_DGV(i, x, 13, ochenta.ToString("N2"));
                        m_LLENAR_DGV(i, x, 14, veinte.ToString("N2"));
                    }
                    break;
                case 5:
                    for (; x <= dgv5.Rows.Count - 1; x++)
                    {
                        unidadesO = double.Parse(dgv5.Rows[x].Cells[9].Value.ToString(), NumberStyles.Currency);
                        unidadesV = double.Parse(dgv5.Rows[x].Cells[10].Value.ToString(), NumberStyles.Currency);
                        modelosO = double.Parse(dgv5.Rows[x].Cells[11].Value.ToString(), NumberStyles.Currency);
                        modelosV = double.Parse(dgv5.Rows[x].Cells[12].Value.ToString());
                        if (unidadesO != 0 && modelosO != 0)
                        {
                            ochenta = unidadesO / modelosO;
                        }
                        else { ochenta = 0; }
                        if (unidadesV != 0 && modelosV != 0)
                        {
                            veinte = unidadesV / modelosV;
                        }
                        else { veinte = 0; }
                        m_LLENAR_DGV(i, x, 13, ochenta.ToString("N2"));
                        m_LLENAR_DGV(i, x, 14, veinte.ToString("N2"));
                    }
                    break;
                case 6:
                    for (; x <= dgv6.Rows.Count - 1; x++)
                    {
                        unidadesO = double.Parse(dgv6.Rows[x].Cells[9].Value.ToString(), NumberStyles.Currency);
                        unidadesV = double.Parse(dgv6.Rows[x].Cells[10].Value.ToString(), NumberStyles.Currency);
                        modelosO = double.Parse(dgv6.Rows[x].Cells[11].Value.ToString(), NumberStyles.Currency);
                        modelosV = double.Parse(dgv6.Rows[x].Cells[12].Value.ToString());
                        if (unidadesO != 0 && modelosO != 0)
                        {
                            ochenta = unidadesO / modelosO;
                        }
                        else { ochenta = 0; }
                        if (unidadesV != 0 && modelosV != 0)
                        {
                            veinte = unidadesV / modelosV;
                        }
                        else { veinte = 0; }
                        m_LLENAR_DGV(i, x, 13, ochenta.ToString("N2"));
                        m_LLENAR_DGV(i, x, 14, veinte.ToString("N2"));
                    }
                    break;
                case 7:
                    for (; x <= dgv7.Rows.Count - 1; x++)
                    {
                        unidadesO = double.Parse(dgv7.Rows[x].Cells[9].Value.ToString(), NumberStyles.Currency);
                        unidadesV = double.Parse(dgv7.Rows[x].Cells[10].Value.ToString(), NumberStyles.Currency);
                        modelosO = double.Parse(dgv7.Rows[x].Cells[11].Value.ToString(), NumberStyles.Currency);
                        modelosV = double.Parse(dgv7.Rows[x].Cells[12].Value.ToString());
                        if (unidadesO != 0 && modelosO != 0)
                        {
                            ochenta = unidadesO / modelosO;
                        }
                        else { ochenta = 0; }
                        if (unidadesV != 0 && modelosV != 0)
                        {
                            veinte = unidadesV / modelosV;
                        }
                        else { veinte = 0; }
                        m_LLENAR_DGV(i, x, 13, ochenta.ToString("N2"));
                        m_LLENAR_DGV(i, x, 14, veinte.ToString("N2"));
                    }
                    break;
                case 8:
                    for (; x <= dgv8.Rows.Count - 1; x++)
                    {
                        unidadesO = double.Parse(dgv8.Rows[x].Cells[9].Value.ToString(), NumberStyles.Currency);
                        unidadesV = double.Parse(dgv8.Rows[x].Cells[10].Value.ToString(), NumberStyles.Currency);
                        modelosO = double.Parse(dgv8.Rows[x].Cells[11].Value.ToString(), NumberStyles.Currency);
                        modelosV = double.Parse(dgv8.Rows[x].Cells[12].Value.ToString());
                        if (unidadesO != 0 && modelosO != 0)
                        {
                            ochenta = unidadesO / modelosO;
                        }
                        else { ochenta = 0; }
                        if (unidadesV != 0 && modelosV != 0)
                        {
                            veinte = unidadesV / modelosV;
                        }
                        else { veinte = 0; }
                        m_LLENAR_DGV(i, x, 13, ochenta.ToString("N2"));
                        m_LLENAR_DGV(i, x, 14, veinte.ToString("N2"));
                    }
                    break;
                case 9:
                    for (; x <= dgv9.Rows.Count - 1; x++)
                    {
                        unidadesO = double.Parse(dgv9.Rows[x].Cells[9].Value.ToString(), NumberStyles.Currency);
                        unidadesV = double.Parse(dgv9.Rows[x].Cells[10].Value.ToString(), NumberStyles.Currency);
                        modelosO = double.Parse(dgv9.Rows[x].Cells[11].Value.ToString(), NumberStyles.Currency);
                        modelosV = double.Parse(dgv9.Rows[x].Cells[12].Value.ToString());
                        if (unidadesO != 0 && modelosO != 0)
                        {
                            ochenta = unidadesO / modelosO;
                        }
                        else { ochenta = 0; }
                        if (unidadesV != 0 && modelosV != 0)
                        {
                            veinte = unidadesV / modelosV;
                        }
                        else { veinte = 0; }
                        m_LLENAR_DGV(i, x, 13, ochenta.ToString("N2"));
                        m_LLENAR_DGV(i, x, 14, veinte.ToString("N2"));
                    }
                    break;
                case 10:
                    for (; x <= dgv10.Rows.Count - 1; x++)
                    {
                        unidadesO = double.Parse(dgv10.Rows[x].Cells[9].Value.ToString(), NumberStyles.Currency);
                        unidadesV = double.Parse(dgv10.Rows[x].Cells[10].Value.ToString(), NumberStyles.Currency);
                        modelosO = double.Parse(dgv10.Rows[x].Cells[11].Value.ToString(), NumberStyles.Currency);
                        modelosV = double.Parse(dgv10.Rows[x].Cells[12].Value.ToString());
                        if (unidadesO != 0 && modelosO != 0)
                        {
                            ochenta = unidadesO / modelosO;
                        }
                        else { ochenta = 0; }
                        if (unidadesV != 0 && modelosV != 0)
                        {
                            veinte = unidadesV / modelosV;
                        }
                        else { veinte = 0; }
                        m_LLENAR_DGV(i, x, 13, ochenta.ToString("N2"));
                        m_LLENAR_DGV(i, x, 14, veinte.ToString("N2"));
                    }
                    break;
                case 11:
                    for (; x <= dgv11.Rows.Count - 1; x++)
                    {
                        unidadesO = double.Parse(dgv11.Rows[x].Cells[9].Value.ToString(), NumberStyles.Currency);
                        unidadesV = double.Parse(dgv11.Rows[x].Cells[10].Value.ToString(), NumberStyles.Currency);
                        modelosO = double.Parse(dgv11.Rows[x].Cells[11].Value.ToString(), NumberStyles.Currency);
                        modelosV = double.Parse(dgv11.Rows[x].Cells[12].Value.ToString());
                        if (unidadesO != 0 && modelosO != 0)
                        {
                            ochenta = unidadesO / modelosO;
                        }
                        else { ochenta = 0; }
                        if (unidadesV != 0 && modelosV != 0)
                        {
                            veinte = unidadesV / modelosV;
                        }
                        else { veinte = 0; }
                        m_LLENAR_DGV(i, x, 13, ochenta.ToString("N2"));
                        m_LLENAR_DGV(i, x, 14, veinte.ToString("N2"));
                    }
                    break;
                case 12:
                    for (; x <= dgv12.Rows.Count - 1; x++)
                    {
                        unidadesO = double.Parse(dgv12.Rows[x].Cells[9].Value.ToString(), NumberStyles.Currency);
                        unidadesV = double.Parse(dgv12.Rows[x].Cells[10].Value.ToString(), NumberStyles.Currency);
                        modelosO = double.Parse(dgv12.Rows[x].Cells[11].Value.ToString(), NumberStyles.Currency);
                        modelosV = double.Parse(dgv12.Rows[x].Cells[12].Value.ToString());
                        if (unidadesO != 0 && modelosO != 0)
                        {
                            ochenta = unidadesO / modelosO;
                        }
                        else { ochenta = 0; }
                        if (unidadesV != 0 && modelosV != 0)
                        {
                            veinte = unidadesV / modelosV;
                        }
                        else { veinte = 0; }
                        m_LLENAR_DGV(i, x, 13, ochenta.ToString("N2"));
                        m_LLENAR_DGV(i, x, 14, veinte.ToString("N2"));
                    }
                    break;

            }
        }

        private void m_capacidadAparador(int i)
        {
            double capacidad = 0;
            double porcentaje = 0;
            string q = "";
            int x = 0;
            int y = 0;
            string[] qCapacidad = new string[1000];
            if (solototal != true)
            {
                x = 1;
            }
            else
            {
                x = 0;
            }
            switch(i)
            {
                case 1:
                    #region enero
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (solototal != true)
                        {
                            qCapacidad[y] = wherequery[y].Replace("V.idsucursal=", "V.sucursal=");
                            q = "SELECT sum(eneropies) as eneropies ,sum(eneroporc) as eneroporc FROM capacidadaplineasuc AS v WHERE v.sucursal<>0 " + qCapacidad[y];
                        }
                        checaConexion();
                        cmd = new MySqlCommand(q, ConnCipsis);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["eneropies"].ToString() != "")
                            {
                                capacidad = double.Parse(reader["eneropies"].ToString());
                            }
                            else
                            {
                                capacidad = 0;
                            }
                            if (reader["eneroporc"].ToString() != "")
                            {
                                porcentaje = double.Parse(reader["eneroporc"].ToString());
                            }
                            else
                            {
                                porcentaje = 0;
                            }
                        }
                        reader.Close();
                        capacidad = (capacidad * (1-(porcentaje/100)));
                        m_LLENAR_DGV(i, x, 5, capacidad.ToString("N0"));
                        y++;
                    }
#endregion
                    break;
                case 2:
                    #region febrero
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (solototal != true)
                        {
                            qCapacidad[y] = wherequery[y].Replace("V.idsucursal=", "V.sucursal=");
                            q = "SELECT sum(febreropies) as febreropies ,sum(febreroporc) as febreroporc FROM capacidadaplineasuc AS v WHERE v.sucursal<>0 " + qCapacidad[y];
                        }
                        checaConexion();
                        cmd = new MySqlCommand(q, ConnCipsis);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["febreropies"].ToString() != "")
                            {
                                capacidad = double.Parse(reader["febreropies"].ToString());
                            }
                            else
                            {
                                capacidad = 0;
                            }
                            if (reader["febreroporc"].ToString() != "")
                            {
                                porcentaje = double.Parse(reader["febreroporc"].ToString());
                            }
                            else
                            {
                                porcentaje = 0;
                            }
                        }
                        reader.Close();
                        capacidad = (capacidad * (1 - (porcentaje / 100)));
                        m_LLENAR_DGV(i, x, 5, capacidad.ToString("N0"));
                        y++;
                    }
                    #endregion
                    break;
                case 3:
                    #region enero
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (solototal != true)
                        {
                            qCapacidad[y] = wherequery[y].Replace("V.idsucursal=", "V.sucursal=");
                            q = "SELECT sum(marzopies) as marzopies ,sum(marzoporc) as marzoporc FROM capacidadaplineasuc AS v WHERE v.sucursal<>0 " + qCapacidad[y];
                        }
                        checaConexion();
                        cmd = new MySqlCommand(q, ConnCipsis);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["marzopies"].ToString() != "")
                            {
                                capacidad = double.Parse(reader["marzopies"].ToString());
                            }
                            else
                            {
                                capacidad = 0;
                            }
                            if (reader["marzoporc"].ToString() != "")
                            {
                                porcentaje = double.Parse(reader["marzoporc"].ToString());
                            }
                            else
                            {
                                porcentaje = 0;
                            }
                        }
                        reader.Close();
                        capacidad = (capacidad * (1 - (porcentaje / 100)));
                        m_LLENAR_DGV(i, x, 5, capacidad.ToString("N0"));
                        y++;
                    }
                    #endregion
                    break;
                    case 4:
                    #region enero
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (solototal != true)
                        {
                            qCapacidad[y] = wherequery[y].Replace("V.idsucursal=", "V.sucursal=");
                            q = "SELECT sum(abrilpies) as abrilpies ,sum(abrilporc) as abrilporc FROM capacidadaplineasuc AS v WHERE v.sucursal<>0 " + qCapacidad[y];
                        }
                        checaConexion();
                        cmd = new MySqlCommand(q, ConnCipsis);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["abrilpies"].ToString() != "")
                            {
                                capacidad = double.Parse(reader["abrilpies"].ToString());
                            }
                            else
                            {
                                capacidad = 0;
                            }
                            if (reader["abrilporc"].ToString() != "")
                            {
                                porcentaje = double.Parse(reader["abrilporc"].ToString());
                            }
                            else
                            {
                                porcentaje = 0;
                            }
                        }
                        reader.Close();
                        capacidad = (capacidad * (1 - (porcentaje / 100)));
                        m_LLENAR_DGV(i, x, 5, capacidad.ToString("N0"));
                        y++;
                    }
#endregion
                    break;
                    case 5:
                    #region enero
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (solototal != true)
                        {
                            qCapacidad[y] = wherequery[y].Replace("V.idsucursal=", "V.sucursal=");
                            q = "SELECT sum(mayopies) as mayopies ,sum(mayoporc) as mayoporc FROM capacidadaplineasuc AS v WHERE v.sucursal<>0 " + qCapacidad[y];
                        }
                        checaConexion();
                        cmd = new MySqlCommand(q, ConnCipsis);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["mayopies"].ToString() != "")
                            {
                                capacidad = double.Parse(reader["mayopies"].ToString());
                            }
                            else
                            {
                                capacidad = 0;
                            }
                            if (reader["mayoporc"].ToString() != "")
                            {
                                porcentaje = double.Parse(reader["mayoporc"].ToString());
                            }
                            else
                            {
                                porcentaje = 0;
                            }
                        }
                        reader.Close();
                        capacidad = (capacidad * (1 - (porcentaje / 100)));
                        m_LLENAR_DGV(i, x, 5, capacidad.ToString("N0"));
                        y++;
                    }
                    #endregion
                    break;
                    case 6:
                    #region enero
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (solototal != true)
                        {
                            qCapacidad[y] = wherequery[y].Replace("V.idsucursal=", "V.sucursal=");
                            q = "SELECT sum(juniopies) as juniopies, sum(junioporc) as junioporc FROM capacidadaplineasuc AS v WHERE v.sucursal<>0 " + qCapacidad[y];
                        }
                        checaConexion();
                        cmd = new MySqlCommand(q, ConnCipsis);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["juniopies"].ToString() != "")
                            {
                                capacidad = double.Parse(reader["juniopies"].ToString());
                            }
                            else
                            {
                                capacidad = 0;
                            }
                            if (reader["junioporc"].ToString() != "")
                            {
                                porcentaje = double.Parse(reader["junioporc"].ToString());
                            }
                            else
                            {
                                porcentaje = 0;
                            }
                        }
                        reader.Close();
                        capacidad = (capacidad * (1 - (porcentaje / 100)));
                        m_LLENAR_DGV(i, x, 5, capacidad.ToString("N0"));
                        y++;
                    }
                    #endregion
                    break;
                    case 7:
                    #region enero
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (solototal != true)
                        {
                            qCapacidad[y] = wherequery[y].Replace("V.idsucursal=", "V.sucursal=");
                            q = "SELECT sum(juliopies) as juliopies ,sum(julioporc) as julioporc FROM capacidadaplineasuc AS v WHERE v.sucursal<>0 " + qCapacidad[y];
                        }
                        checaConexion();
                        cmd = new MySqlCommand(q, ConnCipsis);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["juliopies"].ToString() != "")
                            {
                                capacidad = double.Parse(reader["juliopies"].ToString());
                            }
                            else
                            {
                                capacidad = 0;
                            }
                            if (reader["julioporc"].ToString() != "")
                            {
                                porcentaje = double.Parse(reader["julioporc"].ToString());
                            }
                            else
                            {
                                porcentaje = 0;
                            }
                        }
                        reader.Close();
                        capacidad = (capacidad * (1 - (porcentaje / 100)));
                        m_LLENAR_DGV(i, x, 5, capacidad.ToString("N0"));
                        y++;
                    }
                    #endregion
                    break;
                    case 8:
                    #region enero
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (solototal != true)
                        {
                            qCapacidad[y] = wherequery[y].Replace("V.idsucursal=", "V.sucursal=");
                            q = "SELECT sum(agostopies) as agostopies ,sum(agostoporc) as agostoporc FROM capacidadaplineasuc AS v WHERE v.sucursal<>0 " + qCapacidad[y];
                        }
                        checaConexion();
                        cmd = new MySqlCommand(q, ConnCipsis);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["agostopies"].ToString() != "")
                            {
                                capacidad = double.Parse(reader["agostopies"].ToString());
                            }
                            else
                            {
                                capacidad = 0;
                            }
                            if (reader["agostoporc"].ToString() != "")
                            {
                                porcentaje = double.Parse(reader["agostoporc"].ToString());
                            }
                            else
                            {
                                porcentaje = 0;
                            }
                        }
                        reader.Close();
                        capacidad = (capacidad * (1 - (porcentaje / 100)));
                        m_LLENAR_DGV(i, x, 5, capacidad.ToString("N0"));
                        y++;
                    }
                    #endregion
                    break;
                    case 9:
                    #region enero
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (solototal != true)
                        {
                            qCapacidad[y] = wherequery[y].Replace("V.idsucursal=", "V.sucursal=");
                            q = "SELECT sum(septiembrepies) as septiembrepies ,sum(septiembreporc) as septiembreporc FROM capacidadaplineasuc AS v WHERE v.sucursal<>0 " + qCapacidad[y];
                        }
                        checaConexion();
                        cmd = new MySqlCommand(q, ConnCipsis);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["septiembrepies"].ToString() != "")
                            {
                                capacidad = double.Parse(reader["septiembrepies"].ToString());
                            }
                            else
                            {
                                capacidad = 0;
                            }
                            if (reader["septiembreporc"].ToString() != "")
                            {
                                porcentaje = double.Parse(reader["septiembreporc"].ToString());
                            }
                            else
                            {
                                porcentaje = 0;
                            }
                        }
                        reader.Close();
                        capacidad = (capacidad * (1 - (porcentaje / 100)));
                        m_LLENAR_DGV(i, x, 5, capacidad.ToString("N0"));
                        y++;
                    }
                    #endregion
                    break;
                    case 10:
                    #region enero
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (solototal != true)
                        {
                            qCapacidad[y] = wherequery[y].Replace("V.idsucursal=", "V.sucursal=");
                            q = "SELECT sum(octubrepies) as octubrepies ,sum(octubreporc) as octubreporc FROM capacidadaplineasuc AS v WHERE v.sucursal<>0 " + qCapacidad[y];
                        }
                        checaConexion();
                        cmd = new MySqlCommand(q, ConnCipsis);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["octubrepies"].ToString() != "")
                            {
                                capacidad = double.Parse(reader["octubrepies"].ToString());
                            }
                            else
                            {
                                capacidad = 0;
                            }
                            if (reader["octubreporc"].ToString() != "")
                            {
                                porcentaje = double.Parse(reader["octubreporc"].ToString());
                            }
                            else
                            {
                                porcentaje = 0;
                            }
                        }
                        reader.Close();
                        capacidad = (capacidad * (1 - (porcentaje / 100)));
                        m_LLENAR_DGV(i, x, 5, capacidad.ToString("N0"));
                        y++;
                    }
                    #endregion
                    break;
                    case 11:
                    #region enero
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (solototal != true)
                        {
                            qCapacidad[y] = wherequery[y].Replace("V.idsucursal=", "V.sucursal=");
                            q = "SELECT sum(noviembrepies) as noviembrepies , sum(noviembreporc) as noviembreporc FROM capacidadaplineasuc AS v WHERE v.sucursal<>0 " + qCapacidad[y];
                        }
                        checaConexion();
                        cmd = new MySqlCommand(q, ConnCipsis);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["noviembrepies"].ToString() != "")
                            {
                                capacidad = double.Parse(reader["noviembrepies"].ToString());
                            }
                            else
                            {
                                capacidad = 0;
                            }
                            if (reader["noviembreporc"].ToString() != "")
                            {
                                porcentaje = double.Parse(reader["noviembreporc"].ToString());
                            }
                            else
                            {
                                porcentaje = 0;
                            }
                        }
                        reader.Close();
                        capacidad = (capacidad * (1 - (porcentaje / 100)));
                        m_LLENAR_DGV(i, x, 5, capacidad.ToString("N0"));
                        y++;
                    }
                    #endregion
                    break;
                    case 12:
                    #region enero
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (solototal != true)
                        {
                            qCapacidad[y] = wherequery[y].Replace("V.idsucursal=", "V.sucursal=");
                            q = "SELECT sum(diciembrepies) as diciembrepies ,sum(diciembreporc) as diciembreporc FROM capacidadaplineasuc AS v WHERE v.sucursal<>0 " + qCapacidad[y];
                        }
                        checaConexion();
                        cmd = new MySqlCommand(q, ConnCipsis);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["diciembrepies"].ToString() != "")
                            {
                                capacidad = double.Parse(reader["diciembrepies"].ToString());
                            }
                            else
                            {
                                capacidad = 0;
                            }
                            if (reader["diciembreporc"].ToString() != "")
                            {
                                porcentaje = double.Parse(reader["diciembreporc"].ToString());
                            }
                            else
                            {
                                porcentaje = 0;
                            }
                        }
                        reader.Close();
                        capacidad = (capacidad * (1 - (porcentaje / 100)));
                        m_LLENAR_DGV(i, x, 5, capacidad.ToString("N0"));
                        y++;
                    }
                    #endregion
                    break;
            }
        }
        private void m_capacidadPies(int i)
        {
            double capacidad = 0;
            double porcentaje = 0;
            string q = "";
            int x = 0;
            int y = 0;
            string[] qCapacidad = new string[1000];
            if (solototal != true)
            {
                x = 1;
            }
            else
            {
                x = 0;
            }
            switch (i)
            {
                case 1:
                    #region enero
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (solototal != true)
                        {
                            qCapacidad[y] = wherequery[y].Replace("V.idsucursal=", "V.sucursal=");
                            q = "SELECT sum(eneropies) as eneropies ,sum(eneroporc) as eneroporc FROM capacidadaplineasuc AS v WHERE v.sucursal<>0 " + qCapacidad[y];
                        }
                        checaConexion();
                        cmd = new MySqlCommand(q, ConnCipsis);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["eneropies"].ToString() != "")
                            {
                                capacidad = double.Parse(reader["eneropies"].ToString());
                            }
                            else
                            {
                                capacidad = 0;
                            }
                            if (reader["eneroporc"].ToString() != "")
                            {
                                porcentaje = double.Parse(reader["eneroporc"].ToString());
                            }
                            else
                            {
                                porcentaje = 0;
                            }
                        }
                        reader.Close();
                        m_LLENAR_DGV(i, x, 4, capacidad.ToString("N0"));
                        y++;
                    }
                    #endregion
                    break;
                case 2:
                    #region febrero
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (solototal != true)
                        {
                            qCapacidad[y] = wherequery[y].Replace("V.idsucursal=", "V.sucursal=");
                            q = "SELECT sum(febreropies) as febreropies ,sum(febreroporc) as febreroporc FROM capacidadaplineasuc AS v WHERE v.sucursal<>0 " + qCapacidad[y];
                        }
                        checaConexion();
                        cmd = new MySqlCommand(q, ConnCipsis);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["febreropies"].ToString() != "")
                            {
                                capacidad = double.Parse(reader["febreropies"].ToString());
                            }
                            else
                            {
                                capacidad = 0;
                            }
                            if (reader["febreroporc"].ToString() != "")
                            {
                                porcentaje = double.Parse(reader["febreroporc"].ToString());
                            }
                            else
                            {
                                porcentaje = 0;
                            }
                        }
                        reader.Close();
                        m_LLENAR_DGV(i, x, 4, capacidad.ToString("N0"));
                        y++;
                    }
                    #endregion
                    break;
                case 3:
                    #region enero
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (solototal != true)
                        {
                            qCapacidad[y] = wherequery[y].Replace("V.idsucursal=", "V.sucursal=");
                            q = "SELECT sum(marzopies) as marzopies ,sum(marzoporc) as marzoporc FROM capacidadaplineasuc AS v WHERE v.sucursal<>0 " + qCapacidad[y];
                        }
                        checaConexion();
                        cmd = new MySqlCommand(q, ConnCipsis);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["marzopies"].ToString() != "")
                            {
                                capacidad = double.Parse(reader["marzopies"].ToString());
                            }
                            else
                            {
                                capacidad = 0;
                            }
                            if (reader["marzoporc"].ToString() != "")
                            {
                                porcentaje = double.Parse(reader["marzoporc"].ToString());
                            }
                            else
                            {
                                porcentaje = 0;
                            }
                        }
                        reader.Close();
                        m_LLENAR_DGV(i, x, 4, capacidad.ToString("N0"));
                        y++;
                    }
                    #endregion
                    break;
                case 4:
                    #region enero
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (solototal != true)
                        {
                            qCapacidad[y] = wherequery[y].Replace("V.idsucursal=", "V.sucursal=");
                            q = "SELECT sum(abrilpies) as abrilpies ,sum(abrilporc) as abrilporc FROM capacidadaplineasuc AS v WHERE v.sucursal<>0 " + qCapacidad[y];
                        }
                        checaConexion();
                        cmd = new MySqlCommand(q, ConnCipsis);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["abrilpies"].ToString() != "")
                            {
                                capacidad = double.Parse(reader["abrilpies"].ToString());
                            }
                            else
                            {
                                capacidad = 0;
                            }
                            if (reader["abrilporc"].ToString() != "")
                            {
                                porcentaje = double.Parse(reader["abrilporc"].ToString());
                            }
                            else
                            {
                                porcentaje = 0;
                            }
                        }
                        reader.Close();
                        m_LLENAR_DGV(i, x, 4, capacidad.ToString("N0"));
                        y++;
                    }
                    #endregion
                    break;
                case 5:
                    #region enero
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (solototal != true)
                        {
                            qCapacidad[y] = wherequery[y].Replace("V.idsucursal=", "V.sucursal=");
                            q = "SELECT sum(mayopies) as mayopies ,sum(mayoporc) as mayoporc FROM capacidadaplineasuc AS v WHERE v.sucursal<>0 " + qCapacidad[y];
                        }
                        checaConexion();
                        cmd = new MySqlCommand(q, ConnCipsis);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["mayopies"].ToString() != "")
                            {
                                capacidad = double.Parse(reader["mayopies"].ToString());
                            }
                            else
                            {
                                capacidad = 0;
                            }
                            if (reader["mayoporc"].ToString() != "")
                            {
                                porcentaje = double.Parse(reader["mayoporc"].ToString());
                            }
                            else
                            {
                                porcentaje = 0;
                            }
                        }
                        reader.Close();
                        m_LLENAR_DGV(i, x, 4, capacidad.ToString("N0"));
                        y++;
                    }
                    #endregion
                    break;
                case 6:
                    #region enero
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (solototal != true)
                        {
                            qCapacidad[y] = wherequery[y].Replace("V.idsucursal=", "V.sucursal=");
                            q = "SELECT sum(juniopies) as juniopies, sum(junioporc) as junioporc FROM capacidadaplineasuc AS v WHERE v.sucursal<>0 " + qCapacidad[y];
                        }
                        checaConexion();
                        cmd = new MySqlCommand(q, ConnCipsis);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["juniopies"].ToString() != "")
                            {
                                capacidad = double.Parse(reader["juniopies"].ToString());
                            }
                            else
                            {
                                capacidad = 0;
                            }
                            if (reader["junioporc"].ToString() != "")
                            {
                                porcentaje = double.Parse(reader["junioporc"].ToString());
                            }
                            else
                            {
                                porcentaje = 0;
                            }
                        }
                        reader.Close();
                        m_LLENAR_DGV(i, x, 4, capacidad.ToString("N0"));
                        y++;
                    }
                    #endregion
                    break;
                case 7:
                    #region enero
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (solototal != true)
                        {
                            qCapacidad[y] = wherequery[y].Replace("V.idsucursal=", "V.sucursal=");
                            q = "SELECT sum(juliopies) as juliopies ,sum(julioporc) as julioporc FROM capacidadaplineasuc AS v WHERE v.sucursal<>0 " + qCapacidad[y];
                        }
                        checaConexion();
                        cmd = new MySqlCommand(q, ConnCipsis);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["juliopies"].ToString() != "")
                            {
                                capacidad = double.Parse(reader["juliopies"].ToString());
                            }
                            else
                            {
                                capacidad = 0;
                            }
                            if (reader["julioporc"].ToString() != "")
                            {
                                porcentaje = double.Parse(reader["julioporc"].ToString());
                            }
                            else
                            {
                                porcentaje = 0;
                            }
                        }
                        reader.Close();
                        m_LLENAR_DGV(i, x, 4, capacidad.ToString("N0"));
                        y++;
                    }
                    #endregion
                    break;
                case 8:
                    #region enero
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (solototal != true)
                        {
                            qCapacidad[y] = wherequery[y].Replace("V.idsucursal=", "V.sucursal=");
                            q = "SELECT sum(agostopies) as agostopies ,sum(agostoporc) as agostoporc FROM capacidadaplineasuc AS v WHERE v.sucursal<>0 " + qCapacidad[y];
                        }
                        checaConexion();
                        cmd = new MySqlCommand(q, ConnCipsis);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["agostopies"].ToString() != "")
                            {
                                capacidad = double.Parse(reader["agostopies"].ToString());
                            }
                            else
                            {
                                capacidad = 0;
                            }
                            if (reader["agostoporc"].ToString() != "")
                            {
                                porcentaje = double.Parse(reader["agostoporc"].ToString());
                            }
                            else
                            {
                                porcentaje = 0;
                            }
                        }
                        reader.Close();
                        m_LLENAR_DGV(i, x, 4, capacidad.ToString("N0"));
                        y++;
                    }
                    #endregion
                    break;
                case 9:
                    #region enero
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (solototal != true)
                        {
                            qCapacidad[y] = wherequery[y].Replace("V.idsucursal=", "V.sucursal=");
                            q = "SELECT sum(septiembrepies) as septiembrepies ,sum(septiembreporc) as septiembreporc FROM capacidadaplineasuc AS v WHERE v.sucursal<>0 " + qCapacidad[y];
                        }
                        checaConexion();
                        cmd = new MySqlCommand(q, ConnCipsis);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["septiembrepies"].ToString() != "")
                            {
                                capacidad = double.Parse(reader["septiembrepies"].ToString());
                            }
                            else
                            {
                                capacidad = 0;
                            }
                            if (reader["septiembreporc"].ToString() != "")
                            {
                                porcentaje = double.Parse(reader["septiembreporc"].ToString());
                            }
                            else
                            {
                                porcentaje = 0;
                            }
                        }
                        reader.Close();
                        m_LLENAR_DGV(i, x, 4, capacidad.ToString("N0"));
                        y++;
                    }
                    #endregion
                    break;
                case 10:
                    #region enero
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (solototal != true)
                        {
                            qCapacidad[y] = wherequery[y].Replace("V.idsucursal=", "V.sucursal=");
                            q = "SELECT sum(octubrepies) as octubrepies ,sum(octubreporc) as octubreporc FROM capacidadaplineasuc AS v WHERE v.sucursal<>0 " + qCapacidad[y];
                        }
                        checaConexion();
                        cmd = new MySqlCommand(q, ConnCipsis);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["octubrepies"].ToString() != "")
                            {
                                capacidad = double.Parse(reader["octubrepies"].ToString());
                            }
                            else
                            {
                                capacidad = 0;
                            }
                            if (reader["octubreporc"].ToString() != "")
                            {
                                porcentaje = double.Parse(reader["octubreporc"].ToString());
                            }
                            else
                            {
                                porcentaje = 0;
                            }
                        }
                        reader.Close();
                        m_LLENAR_DGV(i, x, 4, capacidad.ToString("N0"));
                        y++;
                    }
                    #endregion
                    break;
                case 11:
                    #region enero
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (solototal != true)
                        {
                            qCapacidad[y] = wherequery[y].Replace("V.idsucursal=", "V.sucursal=");
                            q = "SELECT sum(noviembrepies) as noviembrepies , sum(noviembreporc) as noviembreporc FROM capacidadaplineasuc AS v WHERE v.sucursal<>0 " + qCapacidad[y];
                        }
                        checaConexion();
                        cmd = new MySqlCommand(q, ConnCipsis);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["noviembrepies"].ToString() != "")
                            {
                                capacidad = double.Parse(reader["noviembrepies"].ToString());
                            }
                            else
                            {
                                capacidad = 0;
                            }
                            if (reader["noviembreporc"].ToString() != "")
                            {
                                porcentaje = double.Parse(reader["noviembreporc"].ToString());
                            }
                            else
                            {
                                porcentaje = 0;
                            }
                        }
                        reader.Close();
                        m_LLENAR_DGV(i, x, 4, capacidad.ToString("N0"));
                        y++;
                    }
                    #endregion
                    break;
                case 12:
                    #region enero
                    for (; x <= dgv1.Rows.Count - 1; x++)
                    {
                        if (solototal != true)
                        {
                            qCapacidad[y] = wherequery[y].Replace("V.idsucursal=", "V.sucursal=");
                            q = "SELECT sum(diciembrepies) as diciembrepies ,sum(diciembreporc) as diciembreporc FROM capacidadaplineasuc AS v WHERE v.sucursal<>0 " + qCapacidad[y];
                        }
                        checaConexion();
                        cmd = new MySqlCommand(q, ConnCipsis);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["diciembrepies"].ToString() != "")
                            {
                                capacidad = double.Parse(reader["diciembrepies"].ToString());
                            }
                            else
                            {
                                capacidad = 0;
                            }
                            if (reader["diciembreporc"].ToString() != "")
                            {
                                porcentaje = double.Parse(reader["diciembreporc"].ToString());
                            }
                            else
                            {
                                porcentaje = 0;
                            }
                        }
                        reader.Close();
                        m_LLENAR_DGV(i, x, 4, capacidad.ToString("N0"));
                        y++;
                    }
                    #endregion
                    break;
            }
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

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            m_ESTRUCTURA();
            m_DIASMESESANOS_Refresh(CED1_fechaI, CED1_fechaF);

        }
        public void m_DIASMESESANOS_Refresh(string fecha_inicio, string fecha_final) /////////////////////////////se usa en todos 
        {
            Cursor.Current = Cursors.WaitCursor;
		
            int fecha_inicio_dia = Convert.ToInt32(fecha_inicio.Substring(0, 2));
            int fecha_inicio_mes = Convert.ToInt32(fecha_inicio.Substring(3, 2));
            int fecha_inicio_ano = Convert.ToInt32(fecha_inicio.Substring(6, 4));

            int fecha_final_dia = Convert.ToInt32(fecha_final.Substring(0, 2));
            int fecha_final_mes = Convert.ToInt32(fecha_final.Substring(3, 2));
            int fecha_final_ano = Convert.ToInt32(fecha_final.Substring(6, 4));
            int mes = 1;
            bool carga = false;
            #region añomes
            int i = 1; calculos = 1;
            for (; fecha_inicio_ano <= fecha_final_ano; fecha_inicio_ano++)
            {
                if (fecha_inicio_mes <= fecha_final_mes)
                {
                    for (; fecha_inicio_mes <= fecha_final_mes; fecha_inicio_mes++, i++)
                        try
                        {
                            m_TABS(fecha_inicio_mes, fecha_inicio_ano + 1);/////////////////////se usa en todos 
                            m_capacidadPies(i);
                            
                                modelajeHU(fecha_inicio_mes, fecha_inicio_ano, i);
                                modelajeHP(i);
                                m_capacidadAparador(i);
                                M_unidades_vendidas(fecha_final_mes, fecha_inicio_ano, i);
                                comprasP(fecha_inicio_mes, fecha_inicio_ano, i);
                                modelos_CompraP(fecha_inicio_mes, fecha_inicio_ano, i);
                                modelajePP(i);
                                Pares_aComprar(i);
                                asignacionModelos(i);
                                profundidad(i);
                                m_REFRESH_DGV();
                            m_calcularRenglonTotal(i);
                            tabcontrol.SelectedIndex = tabcontrol.SelectedIndex + 1;
                            mes++;

                        }
                        catch (Exception x)
                        { MessageBox.Show("Error con las fechas " + x); }
                }
                if (fecha_final_mes < fecha_inicio_mes && fecha_inicio_ano != fecha_final_ano)
                {
                    for (; fecha_inicio_mes <= 12; fecha_inicio_mes++, i++)
                        try
                        {
                            m_TABS(fecha_inicio_mes, fecha_inicio_ano + 1);/////////////////////se usa en todos 
                            
                                modelajeHU(fecha_inicio_mes, fecha_inicio_ano, i);
                                modelajeHP(i);
                                M_unidades_vendidas(fecha_final_mes, fecha_inicio_ano, i);
                                comprasP(fecha_inicio_mes, fecha_inicio_ano, i);
                                modelos_CompraP(fecha_inicio_mes, fecha_inicio_ano, i);
                                modelajePP(i);
                                Pares_aComprar(i);
                                asignacionModelos(i);
                                profundidad(i);
                                m_capacidadAparador(i);
                                m_REFRESH_DGV();
                            m_calcularRenglonTotal(i);
                            tabcontrol.SelectedIndex = tabcontrol.SelectedIndex + 1;
                            mes++;
                        }
                        catch (Exception x)
                        { MessageBox.Show("Error con las fechas " + x); }
                }
                fecha_inicio_mes = 1;
            }
            #endregion
            Cursor.Current = Cursors.Default;

        }

        public void generar_cedula7Automatico(object sender, EventArgs e)
        {
            proyectar = true;
            
                cbSucursales_DropDown(sender, e);

                pbGenerar.Value = 0;
                bool falso = false;
                if (falso == false)
                {
                    #region
                    if (cbSucursales.Items.Count != -1)
                        for (int ss = 0; ss < cbSucursales.Items.Count; ss++)
                        {

                            cbSucursales_DropDown(sender, e);
                            cbSucursales.SelectedIndex = ss;
                            m_ESTRUCTURA();
                            m_DIASMESESANOS(CED1_fechaI, CED1_fechaF);
                            m_DIASMESESANOS_guardar(CED1_fechaI, CED1_fechaF);
                            //this.Refresh();
                            if (ss != 0)
                            {
                                //divisiones 

                                cbDivision_DropDown(sender, e);
                                if (cbDivisiones.Items.Count >= 2)
                                    for (int dd = 0; dd < cbDivisiones.Items.Count; dd++)
                                    {

                                        cbDivision_DropDown(sender, e);
                                        cbDivisiones.SelectedIndex = dd;

                                        //this.Refresh();

                                        m_DIASMESESANOS(CED1_fechaI, CED1_fechaF);
                                        m_DIASMESESANOS_guardar(CED1_fechaI, CED1_fechaF);
                                        if (dd != 0)
                                        {

                                            //departamento

                                            cbDepto_DropDown(sender, e);
                                            if (cbDepto.Items.Count >= 2)
                                                for (int dp = 0; dp < cbDepto.Items.Count; dp++)
                                                {

                                                    cbDepto_DropDown(sender, e);
                                                    cbDepto.SelectedIndex = dp;


                                                    m_DIASMESESANOS(CED1_fechaI, CED1_fechaF);
                                                    m_DIASMESESANOS_guardar(CED1_fechaI, CED1_fechaF);
                                                    //this.Refresh();
                                                    if (dp != 0)
                                                    {
                                                        //familia  

                                                        cbFamilia_DropDown(sender, e);
                                                        if (cbFamilia.Items.Count >= 2)
                                                            for (int fm = 0; fm < cbFamilia.Items.Count; fm++)
                                                            {

                                                                cbFamilia_DropDown(sender, e);
                                                                cbFamilia.SelectedIndex = fm;

                                                                m_DIASMESESANOS(CED1_fechaI, CED1_fechaF);
                                                                m_DIASMESESANOS_guardar(CED1_fechaI, CED1_fechaF);
                                                                //this.Refresh();
                                                                if (fm != 0)
                                                                {
                                                                    //linea

                                                                    cbLinea_DropDown(sender, e);
                                                                    if (cbLinea.Items.Count >= 2)
                                                                        for (int ln = 0; ln < cbLinea.Items.Count; ln++)
                                                                        {

                                                                            cbLinea_DropDown(sender, e);
                                                                            cbLinea.SelectedIndex = ln;

                                                                            m_DIASMESESANOS(CED1_fechaI, CED1_fechaF);
                                                                            m_DIASMESESANOS_guardar(CED1_fechaI, CED1_fechaF);
                                                                            // this.Refresh();
                                                                            if (ln != 0)
                                                                            {
                                                                                //l1         

                                                                                cbL1_DropDown(sender, e);
                                                                                if (cbL1.Items.Count >= 2)
                                                                                   
                                                                                        cbL1_DropDown(sender, e);
                                                                                        cbL1.SelectedIndex = 0;

                                                                                        m_DIASMESESANOS(CED1_fechaI, CED1_fechaF);
                                                                                        m_DIASMESESANOS_guardar(CED1_fechaI, CED1_fechaF);
                                                                                        //this.Refresh();

                                                                                 //l1
                                                                            }
                                                                        }//linea
                                                                }
                                                            }//familia
                                                    }
                                                }//dep
                                        }
                                    }//div             
                                pbGenerar.Value = ((ss + 1) * (100 / cbSucursales.Items.Count));
                            }

                        }//suc
#endregion
                }
            proyectar = false;
            PanelCedulafinalizada.Visible = true;
            this.Refresh();
            bgw_pasarcedula.RunWorkerAsync();
            //try
            //{
            //    Cedula8 c8 = new Cedula8(true);
            //    c8.ShowDialog();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }
        public Cedula7(bool genera)
        {
            generarcedula7 = genera;
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

            ConnCipsis = new MySqlConnection(conexion2);
            try
            {
                ConnCipsis.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            #endregion Abrir conexion cipsis
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
            if (ConnCipsis.Ping() == false)
            {
                while (ConnCipsis.Ping() == false)
                {
                    try
                    {
                        ConnCipsis.Close();
                        ConnCipsis.Open();
                    }
                    catch (MySqlException exx)
                    {

                    }
                }
            }

        }

        private void bgw_pasarcedula_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                Cedula8 c8 = new Cedula8(true);
                c8.ShowDialog();
                //c7.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}