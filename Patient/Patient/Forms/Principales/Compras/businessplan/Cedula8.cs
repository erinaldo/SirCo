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
    public partial class Cedula8 : Form
    {
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
        bool proyectar = false;
        bool filtrardpto = false;
        string[] medidas = new string[1000];
        bool generarCedula8 = false;
        #region variables conexion
        MySqlConnection Conn;

        string query;
        MySqlCommand cmd;
        MySqlDataReader reader;

      // private string conexion = "SERVER=localhost; DATABASE=dwh; user=root; PASSWORD= ;";
        private string conexion = "SERVER="+Properties.Settings.Default.server+"; DATABASE=dwh; user="+Properties.Settings.Default.usuario+"; PASSWORD="+Properties.Settings.Default.pass+";";
        #endregion 
        #region variables globaleslol
     /* string CED9_fechaI = "";
      string CED9_fechaF = "";
      string ced9_escenario = "";
      string CED9_estruct = "";
      string CED9_estruct2 = "";
      string CED9_UNID = "";

      string CED9_tabla = "";
      string divisiones = "";
      string idsucursal = "";
      string idsucursal2 = "";

      string f1 = "";
      string f2 = "";
        */

      #endregion                  //por ahora se ocultan
       string f1, f2;
       #region variables_globales

       private int contador = 0;
       private string escenario = "0";
       private string[] idd = new string[1000];
       private double importe = 0.00;
       private double porciento = 0.00;
       private double pp = 0.00;
       private double Vti = 0.00;
       double Ventatotalimporte = 0;
       double pronosticopares = 0;
        double[] arregloP=new double[10000];
        double[] arregloU=new double[10000];
        double unidadesR = 0;
        double porcentajeR = 0;
       DateTime FechaAF = DateTime.Now, FechaAI = DateTime.Now;
       DateTime fech1 = DateTime.Now, fech2 = DateTime.Now;
       string nombre = "", estructura = "";
       bool comprobar;
       double CED9_UNID = 0;

       #endregion variables_globales
       double cedUnid = 0;
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
       bool total = true;
       string[] queryguardar = new string[1000];
       string[] querycargar = new string[1000];
       string solocalzadoDropdown = "";
       string solocalzadowhere = " ";
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
       string where = "";
       bool soloSuc = false;
       string groupby = "";
       string whereLeft = "";
       string numeroMenor = "";
       string numeromayor = "";
        public Cedula8()
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
                if (i == 1)
                {
                    idsucursalvarios = "and (V.idsucursal= " + reader["idsucursal"].ToString();
                }
                else
                {
                    idsucursalvarios += " or V.idsucursal=" + reader["idsucursal"].ToString();
                }
                this.Invoke(new Action(() =>
                {
                    cbSucursales.Items.Add(reader["descrip"].ToString());
                }));
                idd[i] = reader["idsucursal"].ToString();
                i++;
            }
            idsucursalvarios += ")";
            reader.Close();
        }
        private void cbSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            bandera_sucursal = true;
            filtrardpto = false;
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
                s = idd[cbSucursales.SelectedIndex];
                querycargar[0] = "and idsucursal=" + idd[cbSucursales.SelectedIndex] + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'";
                sucursalcargar = "and idsucursal=" + idd[cbSucursales.SelectedIndex] + "";
                groupby = "idsucursal";
                where = "";
                whereLeft = idsucursal;
            }
            else
            {
                where = "";
                groupby = " idsucursal";
                whereLeft = idsucursalvarios;
                idsucursalvarios = "and (V.IDSUCURSAL= '01' OR V.IDSUCURSAL='02' OR V.IDSUCURSAL='06' OR V.IDSUCURSAL='08')";
                for (int i = 0; i <= cbSucursales.Items.Count - 1; i++)
                {
                    querycargar[i] = "and idsucursal=" + idd[(i + 1)] + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                    idsucursal = "and V.idsucursal= " + idd[(i + 1)];
                    wherequery[i] = "and V.idsucursal=" + idd[(i + 1)] + " " + solocalzadowhere;
                    queryguardar[i] = "," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,'-1'";
                }
                lbsucursal.Text = "Sucursal=Total";
                query = "SELECT descrip,idsucursal from sucursal where visible='S'";
                total = true;
                s = "0";
                sucursalcargar = "and idsucursal=0";
                seleccion_sucursal = 0;
            }
            M_cargargrid(total);
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
            query = "SELECT descrip,iddivisiones from estdivisiones where visiblebp='1' " + solocalzadoDropdown;
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
            bandera_division = true; 
            filtrardpto = false;
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
                queryguardar[0] = "," + s + "," + idd[cbDivisiones.SelectedIndex] + ",-1,-1,-1,-1,-1,-1,-1,-1,-1,'-1'";
                querycargar[0] = sucursalcargar + " and iddivisiones=" + idd[cbDivisiones.SelectedIndex] + " and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                d = idd[cbDivisiones.SelectedIndex];
                divisioncargar = "and iddivisiones=" + idd[cbDivisiones.SelectedIndex] + "";
                groupby = "iddivisiones";
                where = " and  e.iddivisiones=1";
                whereLeft = idsucursalvarios;
            }
            else
            {
                groupby = "iddivisiones";
                where = " and  e.iddivisiones=1";
                whereLeft = idsucursalvarios;
                iddivision = " ";
                iddivisionesvarios = " ";
                division = " ";
                for (int i = 0; i <= cbDivisiones.Items.Count - 1; i++)
                {
                    querycargar[i] = sucursalcargar + " and iddivisiones=" + idd[(i + 1)] + " and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                    iddivision = "and V.iddivisiones=" + idd[(i + 1)];
                    wherequery[i] = idsucursalvarios + " " + iddivision;
                    queryguardar[i] = "," + s + "," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,-1,-1,-1,'-1'";
                }
                lbDivision.Text = "Division=Total";
                total = true;
                query = "SELECT descrip,iddivisiones from estdivisiones where visiblebp='1' and iddivisiones=1";
                d = "0";
                divisioncargar = "and iddivisiones=0";
                seleccion_division = 0;
            }
            M_cargargrid(total);
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
                if (i == 1)
                {
                    iddeptovarios = "and (e.iddepto= " + reader["iddepto"].ToString();
                }
                else
                {
                    iddeptovarios += " or e.iddepto=" + reader["iddepto"].ToString();
                }
                cbDepto.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["iddepto"].ToString();
                i++;
            }
            reader.Close();
            iddeptovarios += ")";

        }
        private void cbDepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            bandera_depto = true;
            filtrardpto = true;
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
                queryguardar[0] = "," + s + "," + d + "," + idd[cbDepto.SelectedIndex] + ",-1,-1,-1,-1,-1,-1,-1,-1,'-1'";
                dd = idd[cbDepto.SelectedIndex];
                querycargar[0] = sucursalcargar + " " + divisioncargar + " and iddepto=" + idd[cbDepto.SelectedIndex] + " and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                departamentocargar = "and iddepto=" + idd[cbDepto.SelectedIndex];
                groupby = "iddepto";
                where = " and   e.iddivisiones=1 " + iddepto;
                whereLeft = idsucursalvarios;
            }
            else
            {
                groupby = "iddepto";
                where = " and e.iddivisiones=1";
                whereLeft = idsucursalvarios;
                iddepto = " ";
                iddeptovarios = " ";
                for (int i = 0; i <= cbDepto.Items.Count - 1; i++)
                {
                    querycargar[i] = sucursalcargar + " " + divisioncargar + " and iddepto=" + idd[(i + 1)] + " and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                    iddepto = "and V.iddepto=" + idd[(i + 1)];
                    wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + " " + iddepto;
                    queryguardar[i] = "," + s + "," + d + "," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,-1,-1,'-1'";
                }
                total = true;
                query = "SELECT descrip,iddepto from estdepartamento where visiblebp='1' " + division;
                lbdepartamento.Text = "Departamento=Total";
                depto = " ";
                dd = "0";
                departamentocargar = "and iddepto=0";
                seleccion_depto = 0;
            }
            M_cargargrid(total);
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
                if (i == 1)
                {
                    idfamiliavarios = "and (e.idfamilia= " + reader["idfamilia"].ToString();
                }
                else
                {
                    idfamiliavarios += " or e.idfamilia=" + reader["idfamilia"].ToString();
                }
                cbFamilia.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["idfamilia"].ToString();
                i++;
            }
            reader.Close();
            idfamiliavarios += ")";
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
                queryguardar[0] = "," + s + "," + d + "," + dd + "," + idd[cbFamilia.SelectedIndex] + ",-1,-1,-1,-1,-1,-1,-1,'-1'";
                f = idd[cbFamilia.SelectedIndex];
                querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " and idfamilia=" + idd[cbFamilia.SelectedIndex] + " and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                familiacargar = "and idfamilia=" + idd[cbFamilia.SelectedIndex];
                groupby = "idfamilia";
                where = iddivisionesvarios + " " + iddeptovarios + " " + idfamilia;
                whereLeft = idsucursalvarios;
            }
            else
            {
                groupby = "idfamilia";
                where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios;
                whereLeft = idsucursalvarios;
                idfamiliavarios = " ";
                for (int i = 0; i <= cbFamilia.Items.Count - 1; i++)
                {
                    idfamilia = "and V.idfamilia=" + idd[(i + 1)];
                    wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamilia;
                    queryguardar[i] = "," + s + "," + d + "," + dd + "," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,-1,'-1'";
                    querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " and idfamilia=" + idd[(i + 1)] + " and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                }
                total = true;
                query = "SELECT descrip,idfamilia from estfamilia where visiblebp='1' " + division + " " + depto;
                lbfamilia.Text = "Familia=Total";
                fam = " ";
                f = "0";
                familiacargar = "and idfamilia=0";
                seleccion_familia = 0;
            }
            M_cargargrid(total);
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
                if (i == 1)
                {
                    idlineavarios = "and (e.idlinea= " + reader["idlinea"].ToString();
                }
                else
                {
                    idlineavarios += " or e.idlinea=" + reader["idlinea"].ToString();
                }
                cbLinea.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["idlinea"].ToString();
                i++;
            }
            idlineavarios += ")";

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
                queryguardar[0] = "," + s + "," + d + "," + dd + "," + f + "," + idd[cbLinea.SelectedIndex] + ",-1,-1,-1,-1,-1,-1,'-1'";
                l = idd[cbLinea.SelectedIndex];
                lineacargar = "and idlinea="+idd[cbLinea.SelectedIndex];
                groupby = "idlinea";
                where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlinea;
                whereLeft = idsucursalvarios;
            }
            else
            {
                groupby = "idlinea";
                where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios;
                whereLeft = idsucursalvarios;
                idlineavarios = " ";
                for (int i = 0; i <= cbLinea.Items.Count - 1; i++)
                {
                    querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " and idlinea=" + idd[(i + 1)] + " and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                    idlinea = "and V.idlinea=" + idd[(i + 1)];
                    wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlinea;
                    queryguardar[i] = "," + s + "," + d + "," + dd + "," + f + "," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,'-1'";

                }
                query = "SELECT descrip,idlinea from estlinea where visiblebp='1' " + division + " " + depto + "" + " " + fam;
                total = true;
                linea = " ";
                l = "0";
                lineacargar = "and idlinea=0";
                seleccion_linea = 0;
            }
            lblinea.Text = "Linea=" + cbLinea.Text;
            M_cargargrid(total);
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
                if (i == 1)
                {
                    idl1varios = "and (e.idl1= " + reader["idl1"].ToString();
                }
                else
                {
                    idl1varios += " or e.idl1=" + reader["idl1"].ToString();
                }
                cbL1.Items.Add(reader["descrip"].ToString());
                idd[i] = reader["idl1"].ToString();
                i++;
            }
            idl1varios += ")";
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
                queryguardar[0] = "," + s + "," + d + "," + dd + "," + f + "," + l + "," + idd[cbL1.SelectedIndex] + ",-1,-1,-1,-1,-1,'-1'";
                l1 = idd[cbL1.SelectedIndex];

                l1cargar = "and idl1=" + idd[cbL1.SelectedIndex];
                groupby = "idl1";
                where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1;
                whereLeft = idsucursalvarios;
            }
            else
            {
                groupby = "idl1";
                where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios;
                whereLeft = idsucursalvarios;
                for (int i = 0; i <= cbL1.Items.Count - 1; i++)
                {
                    querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " and idl1=" + idd[(i + 1)] + " and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                    idl1 = "and V.idl1=" + idd[(i + 1)];
                    wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1;
                    queryguardar[i] = "," + s + "," + d + "," + dd + "," + f + "," + l + "," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,'-1'";

                }
                subl1 = " ";
                lbl1.Text = "L1=Total";
                total = true;
                query = "SELECT descrip,idl1 from estl1 where visiblebp='1' " + division + " " + depto + " " + fam + " " + linea;
                l = "0";
                l1cargar = "and idl1=0";
                seleccion_l1 = 0;
            }
            lbl1.Text = "L1=" + cbL1.Text;
            M_cargargrid(total);
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
                queryguardar[0] = "," + s + "," + d + "," + dd + "," + f + "," + l + "," + l1 + "," + idd[cbL2.SelectedIndex] + ",-1,-1,-1,-1,'-1'";
                l2 = idd[cbL2.SelectedIndex];

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
                    queryguardar[i] = "," + s + "," + d + "," + dd + "," + f + "," + l + "," + l1 + "," + idd[(i + 1)] + ",-1,-1,-1,-1,'-1'";


                }
                l2 = "0";
                l2cargar = "and idl2=0";
                total = true;
                query = "SELECT descrip,idl2 from estl2 where visiblebp='1' " + division + " " + depto + " " + fam + " " + linea + " " + subl1;
                seleccion_l2 = 0;
            }
            lbL2.Text = "L2=" + cbL2.Text;
            M_cargargrid(total);
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
                queryguardar[0] = "," + s + "," + d + "," + dd + "," + f + "," + l + "," + l1 + "," + l2 + "," + idd[cbL3.SelectedIndex] + ",-1,-1,-1,'-1'";
                l3 = idd[cbL3.SelectedIndex];

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
                    queryguardar[i] = "," + s + "," + d + "," + dd + "," + f + "," + l + "," + l1 + "," + l2 + "," + idd[(i + 1)] + ",-1,-1,-1,'-1'";

                }
                total = true;
                query = "SELECT descrip,idl3 from estl3 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2;
                l3 = "0";
                l3cargar = "and idl3=0";
                seleccion_l3 = 0;
            }
            lbL3.Text = "L3=" + cbL3.Text;
            M_cargargrid(total);
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
                queryguardar[0] = "," + s + "," + d + "," + dd + "," + f + "," + l + "," + l1 + "," + l2 + "," + l3 + "," + idd[cbL4.SelectedIndex] + ",-1,-1,'-1'";
                l4 = idd[cbL4.SelectedIndex];

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
                    queryguardar[i] = "," + s + "," + d + "," + dd + "," + f + "," + l + "," + l1 + "," + l2 + "," + l3 + "," + idd[(i + 1)] + ",-1,-1,'-1'";

                }
                total = true;
                query = "SELECT descrip,idl4 from estl4 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2 + " " + subl3;
                l4 = "0";
                l4cargar = "and idl4=0";
                seleccion_l4 = 0;
            }
            lbL4.Text = "L4=" + cbL4.Text;
            M_cargargrid(total);
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
                queryguardar[0] = "," + s + "," + d + "," + dd + "," + f + "," + l + "," + l1 + "," + l2 + "," + l3 + "," + l4 + "," + idd[cbL5.SelectedIndex] + ",-1,'-1'";
                l5 = idd[cbL5.SelectedIndex];

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
                    queryguardar[i] = "," + s + "," + d + "," + dd + "," + f + "," + l + "," + l1 + "," + l2 + "," + l3 + "," + l4 + "," + idd[(i + 1)] + ",-1,'-1'";

                }
                total = true;
                query = "SELECT descrip,idl5 from estl5 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2 + " " + subl3 + " " + subl4;
                l5 = "0";
                l5cargar = "and idl5=0";
                seleccion_l5 = 0;
            }
            lbL5.Text = "L5=" + cbL5.Text;
            M_cargargrid(total);
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
                queryguardar[0] = "," + s + "," + d + "," + dd + "," + f + "," + l + "," + l1 + "," + l2 + "," + l3 + "," + l4 + "," + l5 + "," + idd[cbL6.SelectedIndex] + ",'-1'";
                l6 = idd[cbL6.SelectedIndex];

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
                    queryguardar[i] = "," + s + "," + d + "," + dd + "," + f + "," + l + "," + l1 + "," + l2 + "," + l3 + "," + l4 + "," + l5 + "," + idd[(i + 1)] + ",'-1'";

                }
                total = true;
                query = "SELECT descrip,idl6 from estl6 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2 + " " + subl3 + " " + subl4 + " " + subl5;
                l6 = "0";
                l6cargar = "and idl6=0";
                seleccion_l6 = 0;
            }
            lbL6.Text = "L6=" + cbL6.Text;
            M_cargargrid(total);
        }
        private void cbMarca_DropDown(object sender, EventArgs e)
        {

            cbMarca.Items.Clear();
            cbMarca.Items.Add("Total");
            int i = 1;

            //query = "SELECT descrip,marca from marca where visiblebp=1";
            query = "SELECT distinct m.descrip,m.marca from marca as m inner join estarticulo as v on v.marca = m.marca where visiblebp =1 " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6varios;
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
            total = true;
        }
        private void cbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            bandera_marca = true;//pablo
            seleccion_marca = cbMarca.SelectedText;

            #region reiniciar valores
            //lbDivision.Text = "Division";
            //lbdepartamento.Text = "Departamento";
            //lbfamilia.Text = "Familia";
            //lblinea.Text = "Linea";
            //lbl1.Text = "L1";
            //lbL2.Text = "L2";
            //lbL3.Text = "L3";
            //lbL4.Text = "L4";
            //lbL5.Text = "L5";
            //lbL6.Text = "L6";
            //lbMarca.Text = "Marca";
            //iddivision = " ";
            //iddepto = " ";
            //idfamilia = " ";
            //idlinea = " ";
            //idl1 = " ";
            //idl2 = " ";
            //idl3 = " ";
            //idl4 = " ";
            //idl5 = " ";
            //idl6 = " ";
            //marca = " ";
            #endregion
            if (cbMarca.Text == "Total")
            {
                for (int i = 0; i <= cbMarca.Items.Count - 1; i++)
                {
                    marca = " and V.marca='" + idd[(i + 1)] + "'";
                    //    wherequery[i] = idsucursalvarios + " " + marca;
                    wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6 + " " + marca;

                    queryguardar[i] = "," + s + "," + d + "," + dd + "," + f + "," + l + "," + l1 + "," + l2 + "," + l3 + "," + l4 + "," + l5 + "," + l6 + ",'" + idd[(i + 1)] + "'";
                    querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " " + l6cargar + " and marca='" + idd[(i + 1)] + "'  ";

                }
                total = true;
                seleccion_marca = "0";
            }
            else
            {
                queryguardar[0] = "," + s + "," + d + "," + dd + "," + f + "," + l + "," + l1 + "," + l2 + "," + l3 + "," + l4 + "," + l5 + "," + l6 + ",'" + idd[cbMarca.SelectedIndex] + "'";
                querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " " + l6cargar + " and marca='" + idd[cbMarca.SelectedIndex] + "'  ";
                query = query + " and M.marca='" + idd[cbMarca.SelectedIndex] + "'";
                marca = " and V.marca='" + idd[cbMarca.SelectedIndex] + "'";
                // wherequery[0] = idsucursalvarios + marca;
                wherequery[0] = idsucursalvarios + " " + idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6 + " " + marca;
                total = false;

            }
            lbMarca.Text = "Marca=" + cbMarca.Text;
            M_cargargrid(total);
            seleccion_marca =cbMarca.Text;
        }
        #endregion

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

                //Cedula2 c2 = new Cedula2(seleccion_sucursal, seleccion_division, seleccion_depto, seleccion_familia, seleccion_linea, seleccion_l1, seleccion_l2, seleccion_l3, seleccion_l4, seleccion_l5, seleccion_l6, seleccion_marca);

                Cedula2 c2 = new Cedula2(bandera_sucursal, seleccion_sucursal, bandera_division, seleccion_division, bandera_depto, seleccion_depto, bandera_familia, seleccion_familia, bandera_linea, seleccion_linea, bandera_l1, seleccion_l1, bandera_l2, seleccion_l2, bandera_l3, seleccion_l3, bandera_l4, seleccion_l4, bandera_l5, seleccion_l5, bandera_l6, seleccion_l6, bandera_marca, seleccion_marca);
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
        {   cedula4 c4 = new cedula4();
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

        #endregion
        private void Cedula8_Load(object sender, EventArgs e)
        {
            #region color dgvs
            dgvH1.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#00CC66");
            dgvP1A.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF99");
            dgvP1B.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3399FF");

            dgvH2.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#00CC66");
            dgvP2A.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF99");
            dgvP2B.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3399FF");

            dgvH3.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#00CC66");
            dgvP3A.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF99");
            dgvP3B.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3399FF");

            dgvH4.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#00CC66");
            dgvP4A.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF99");
            dgvP4B.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3399FF");

            dgvH5.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#00CC66");
            dgvP5A.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF99");
            dgvP5B.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3399FF");

            dgvH6.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#00CC66");
            dgvP6A.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF99");
            dgvP6B.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3399FF");

            dgvH7.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#00CC66");
            dgvP7A.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF99");
            dgvP7B.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3399FF");

            dgvH8.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#00CC66");
            dgvP8A.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF99");
            dgvP8B.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3399FF");

            dgvH9.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#00CC66");
            dgvP9A.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF99");
            dgvP9B.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3399FF");

            dgvH10.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#00CC66");
            dgvP10A.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF99");
            dgvP10B.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3399FF");

            dgvH11.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#00CC66");
            dgvP11A.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF99");
            dgvP11B.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3399FF");

            dgvH12.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#00CC66");
            dgvP12A.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF99");
            dgvP12B.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3399FF");

            dgvH13.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#00CC66");
            dgvP13A.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF99");
            dgvP13B.RowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3399FF");
               
            #endregion
            #region escenario
            //query = "select fechainicialA,fechafinalA,fechainicial,fechafinal from escenarios where nombre='" + Properties.Settings.Default.escenario + "';";
            //cmd = new MySqlCommand(query, Conn);
            //reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{/*
            //    f1 = reader["fechainicial"].ToString(); f2 = reader["fechafinal"].ToString();
            //    label1.Text = "Fecha inicio: " + f1.Substring(0, 10);label11.Text = "Fecha fin: " + f2.Substring(0, 10);*/
            //    CED1_fechaI = reader["fechainicial"].ToString();
            //    CED1_fechaF = reader["fechafinal"].ToString();
            //    label1.Text = "Fecha inicio: " + CED1_fechaI.Substring(0, 10);
            //    label11.Text = "Fecha fin: " + CED1_fechaF.Substring(0, 10);
               
            //}
            //reader.Close();

            
            m_ESCENARIO(Properties.Settings.Default.escenario);
      
            #endregion

            if(seleccion_sucursal != -1)
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

            ////////////////////////////////
            this.Refresh();
            #region si hay valores cedula anterior 
            if (valoresform == true)
            {
                //m_DIASMESESANOS(CED1_fechaI, CED1_fechaF);
                M_cargargrid(total);
                valoresform = false;
                //m_regleta();
                m_REFRESH_DGVS(1);
                m_DIASMESESANOS(CED1_fechaI, CED1_fechaF);
            }
            #endregion
            this.Refresh();
            if(generarCedula8==true)
            {
                generar_cedula8Automatico(sender,e);
            }
        }
        private void menuPrincipalToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Opciones op = new Opciones();
            this.Hide();
            op.ShowDialog();
            this.Close();
        }
        private void cerrarSesionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Log_in log = new Log_in();
            this.Hide();
            log.ShowDialog();
            this.Close();
        }
        private void cerrarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void m_ESCENARIO(string escenario)
        {  
            string ESC = "SELECT fechainicialA, fechafinalA,fechainicial,fechafinal,solocalzado FROM escenarios WHERE nombre = '" + escenario + "' LIMIT 1";
            checaConexion();
            cmd = new MySqlCommand(ESC, Conn);
            cmd.CommandTimeout = 0;//pos solucion
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CED1_fechaI = reader["fechainicialA"].ToString();
                CED1_fechaF = reader["fechafinalA"].ToString();
                
                label2.Text = "Escenario:" + escenario;
                label1.Text = CED1_fechaI.Substring(0, 10);
                label11.Text = CED1_fechaF.Substring(0, 10);
                label1.Text=reader["fechainicial"].ToString().Substring(0,10);
                label11.Text = reader["fechafinal"].ToString().Substring(0,10);
                f1 = Convert.ToString(CED1_fechaI);
                f2 = Convert.ToString(CED1_fechaF);
                //label10.Text = "Fecha inicial " + f1.ToString("yyyy-MM-dd");
                //label11.Text = "Fecha final  " + f2.ToString("yyyy-MM-dd");
                //CED1_fechaI = FechaAI.ToString("dd-MM-yyyy");
                //CED1_fechaF = FechaAF.AddDays(-1).ToString("dd-MM-yyyy");
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
        private void M_cargargrid(bool Total)
        {  
            m_CLEAR_DGVS();
            m_GENERARDGVS_Estructura();
              
            int i = 0;
            checaConexion();
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dgvH1.Refresh();
                dgvH1.Rows.Add(); 
                dgvH1.Rows[i].Cells[0].Value = reader["descrip"].ToString();
                m_ADDROWS(reader["descrip"].ToString(),i);
                dgvH1.Rows.Add();
                i++;

                dgvH1.Rows[i].Cells[0].Value = "PORCENTAJE";
                m_ADDROWS("PORCENTAJE", i);
                i++;

            }
            reader.Close();
            button1.Enabled = true;
            m_propiedades_grid();
            m_regleta();
        }
        private void m_GENERARDGVS_Estructura()
        {
          //  m_CLEAR_DGVS();
            #region agregar columnas
            dgvH1.Columns.Add("estructura", "estructura");
            dgvP1A.Columns.Add("estructura", "estructura");
            dgvP1B.Columns.Add("estructura", "estructura");
            dgvH2.Columns.Add("estructura", "estructura");
            dgvP2A.Columns.Add("estructura", "estructura");
            dgvP2B.Columns.Add("estructura", "estructura");
            dgvH3.Columns.Add("estructura", "estructura");
            dgvP3A.Columns.Add("estructura", "estructura");
            dgvP3B.Columns.Add("estructura", "estructura");
            dgvH4.Columns.Add("estructura", "estructura");
            dgvP4A.Columns.Add("estructura", "estructura");
            dgvP4B.Columns.Add("estructura", "estructura");
            dgvH5.Columns.Add("estructura", "estructura");
            dgvP5A.Columns.Add("estructura", "estructura");
            dgvP5B.Columns.Add("estructura", "estructura");
            dgvH6.Columns.Add("estructura", "estructura");
            dgvP6A.Columns.Add("estructura", "estructura");
            dgvP6B.Columns.Add("estructura", "estructura");
            dgvH7.Columns.Add("estructura", "estructura");
            dgvP7A.Columns.Add("estructura", "estructura");
            dgvP7B.Columns.Add("estructura", "estructura");
            dgvH8.Columns.Add("estructura", "estructura");
            dgvP8A.Columns.Add("estructura", "estructura");
            dgvP8B.Columns.Add("estructura", "estructura");
            dgvH9.Columns.Add("estructura", "estructura");
            dgvP9A.Columns.Add("estructura", "estructura");
            dgvP9B.Columns.Add("estructura", "estructura");
            dgvH10.Columns.Add("estructura", "estructura");
            dgvP10A.Columns.Add("estructura", "estructura");
            dgvP10B.Columns.Add("estructura", "estructura");
            dgvH11.Columns.Add("estructura", "estructura");
            dgvP11A.Columns.Add("estructura", "estructura");
            dgvP11B.Columns.Add("estructura", "estructura");
            dgvH12.Columns.Add("estructura", "estructura");
            dgvP12A.Columns.Add("estructura", "estructura");
            dgvP12B.Columns.Add("estructura", "estructura");
            dgvH13.Columns.Add("estructura", "estructura");
            dgvP13A.Columns.Add("estructura", "estructura");
            dgvP13B.Columns.Add("estructura", "estructura");
            #endregion
        }
        private void m_CLEAR_DGVS()
        {
            dgvH1.Columns.Clear(); dgvP1A.Columns.Clear(); //dgvE1.Columns.Clear();
            dgvH2.Columns.Clear(); dgvP2A.Columns.Clear(); //dgvE2.Columns.Clear();
            dgvH3.Columns.Clear(); dgvP3A.Columns.Clear(); //dgvE3.Columns.Clear();
            dgvH4.Columns.Clear(); dgvP4A.Columns.Clear(); //dgvE4.Columns.Clear();
            dgvH5.Columns.Clear(); dgvP5A.Columns.Clear(); //dgvE5.Columns.Clear();
            dgvH6.Columns.Clear(); dgvP6A.Columns.Clear(); //dgvE6.Columns.Clear();
            dgvH7.Columns.Clear(); dgvP7A.Columns.Clear(); //dgvE7.Columns.Clear();
            dgvH8.Columns.Clear(); dgvP8A.Columns.Clear(); //dgvE8.Columns.Clear();
            dgvH9.Columns.Clear(); dgvP9A.Columns.Clear(); //dgvE9.Columns.Clear();
            dgvH10.Columns.Clear(); dgvP10A.Columns.Clear(); //dgvE10.Columns.Clear();
            dgvH11.Columns.Clear(); dgvP11A.Columns.Clear(); //dgvE11.Columns.Clear();
            dgvH12.Columns.Clear(); dgvP12A.Columns.Clear(); //dgvE12.Columns.Clear();
            dgvH13.Columns.Clear(); dgvP13A.Columns.Clear(); //dgvE13.Columns.Clear();
            dgvH1.Columns.Clear(); dgvP1B.Columns.Clear(); //dgvE1.Columns.Clear();
            dgvH2.Columns.Clear(); dgvP2B.Columns.Clear(); //dgvE2.Columns.Clear();
            dgvH3.Columns.Clear(); dgvP3B.Columns.Clear(); //dgvE3.Columns.Clear();
            dgvH4.Columns.Clear(); dgvP4B.Columns.Clear(); //dgvE4.Columns.Clear();
            dgvH5.Columns.Clear(); dgvP5B.Columns.Clear(); //dgvE5.Columns.Clear();
            dgvH6.Columns.Clear(); dgvP6B.Columns.Clear(); //dgvE6.Columns.Clear();
            dgvH7.Columns.Clear(); dgvP7B.Columns.Clear(); //dgvE7.Columns.Clear();
            dgvH8.Columns.Clear(); dgvP8B.Columns.Clear(); //dgvE8.Columns.Clear();
            dgvH9.Columns.Clear(); dgvP9B.Columns.Clear(); //dgvE9.Columns.Clear();
            dgvH10.Columns.Clear(); dgvP10B.Columns.Clear(); //dgvE10.Columns.Clear();
            dgvH11.Columns.Clear(); dgvP11B.Columns.Clear(); //dgvE11.Columns.Clear();
            dgvH12.Columns.Clear(); dgvP12B.Columns.Clear(); //dgvE12.Columns.Clear();
            dgvH13.Columns.Clear(); dgvP13B.Columns.Clear(); //dgvE13.Columns.Clear();
        }
        private void m_REFRESH_DGVS(int i)
        {
            switch (i)
            {
                case 1: dgvH1.Refresh(); dgvP1A.Refresh(); dgvP1B.Refresh();//dgvE1.Refresh();
                    break;
                case 2: dgvH2.Refresh(); dgvP2A.Refresh(); dgvP2B.Refresh();//dgvE2.Refresh();
                    break;
                case 3: dgvH3.Refresh(); dgvP3A.Refresh(); dgvP3B.Refresh();//dgvE3.Refresh();
                    break;
                case 4: dgvH4.Refresh(); dgvP4A.Refresh(); dgvP4B.Refresh();//dgvE4.Refresh();
                    break;
                case 5: dgvH5.Refresh(); dgvP5A.Refresh(); dgvP5B.Refresh();//dgvE5.Refresh();
                    break;
                case 6: dgvH6.Refresh(); dgvP6A.Refresh(); dgvP6B.Refresh();//dgvE6.Refresh();
                    break;
                case 7: dgvH7.Refresh(); dgvP7A.Refresh(); dgvP7B.Refresh();//dgvE7.Refresh();
                    break;
                case 8: dgvH8.Refresh(); dgvP8A.Refresh(); dgvP8B.Refresh();//dgvE8.Refresh();
                    break;
                case 9: dgvH9.Refresh(); dgvP9A.Refresh(); dgvP9B.Refresh();//dgvE9.Refresh();
                    break;
                case 10: dgvH10.Refresh(); dgvP10A.Refresh(); dgvP10B.Refresh();//dgvE10.Refresh();
                    break;
                case 11: dgvH11.Refresh(); dgvP11A.Refresh(); dgvP11B.Refresh(); //dgvE11.Refresh();
                    break;
                case 12: dgvH12.Refresh(); dgvP12A.Refresh(); dgvP12B.Refresh(); //dgvE12.Refresh();
                    break;
                case 13: dgvH13.Refresh(); dgvP13A.Refresh(); dgvP13B.Refresh();//dgvE13.Refresh();
                    break;

            }
        }
        private void m_ADDROWS(string n,int i)
        { 
            #region rows add
            try
            {   
                #region agregar renglones 
                dgvP1A.Rows.Add();
                dgvP1B.Rows.Add();
                dgvH2.Rows.Add(); dgvP2A.Rows.Add(); dgvP2B.Rows.Add();
                dgvH3.Rows.Add(); dgvP3A.Rows.Add(); dgvP3B.Rows.Add();
                dgvH4.Rows.Add(); dgvP4A.Rows.Add(); dgvP4B.Rows.Add();
                dgvH5.Rows.Add(); dgvP5A.Rows.Add(); dgvP5B.Rows.Add();
                dgvH6.Rows.Add(); dgvP6A.Rows.Add(); dgvP6B.Rows.Add();
                dgvH7.Rows.Add(); dgvP7A.Rows.Add(); dgvP7B.Rows.Add();
                dgvH8.Rows.Add(); dgvP8A.Rows.Add(); dgvP8B.Rows.Add();
                dgvH9.Rows.Add(); dgvP9A.Rows.Add(); dgvP9B.Rows.Add();
                dgvH10.Rows.Add(); dgvP10A.Rows.Add(); dgvP10B.Rows.Add();
                dgvH11.Rows.Add(); dgvP11A.Rows.Add(); dgvP11B.Rows.Add();
                dgvH12.Rows.Add(); dgvP12A.Rows.Add(); dgvP12B.Rows.Add();
                dgvH13.Rows.Add(); dgvP13A.Rows.Add(); dgvP13B.Rows.Add();
                #endregion
                #region agregar valor N a renglones
                dgvP1A.Rows[i].Cells[0].Value = n; dgvP1B.Rows[i].Cells[0].Value = n;
                dgvH2.Rows[i].Cells[0].Value = n; dgvP2A.Rows[i].Cells[0].Value = n; dgvP2B.Rows[i].Cells[0].Value = n;
                dgvH3.Rows[i].Cells[0].Value = n; dgvP3A.Rows[i].Cells[0].Value = n; dgvP3B.Rows[i].Cells[0].Value = n;
                dgvH4.Rows[i].Cells[0].Value = n; dgvP4A.Rows[i].Cells[0].Value = n; dgvP4B.Rows[i].Cells[0].Value = n;
                dgvH5.Rows[i].Cells[0].Value = n; dgvP5A.Rows[i].Cells[0].Value = n; dgvP5B.Rows[i].Cells[0].Value = n;
                dgvH6.Rows[i].Cells[0].Value = n; dgvP6A.Rows[i].Cells[0].Value = n; dgvP6B.Rows[i].Cells[0].Value = n;
                dgvH7.Rows[i].Cells[0].Value = n; dgvP7A.Rows[i].Cells[0].Value = n; dgvP7B.Rows[i].Cells[0].Value = n;
                dgvH8.Rows[i].Cells[0].Value = n; dgvP8A.Rows[i].Cells[0].Value = n; dgvP8B.Rows[i].Cells[0].Value = n;
                dgvH9.Rows[i].Cells[0].Value = n; dgvP9A.Rows[i].Cells[0].Value = n; dgvP9B.Rows[i].Cells[0].Value = n;
                dgvH10.Rows[i].Cells[0].Value = n; dgvP10A.Rows[i].Cells[0].Value = n; dgvP10B.Rows[i].Cells[0].Value = n;
                dgvH11.Rows[i].Cells[0].Value = n; dgvP11A.Rows[i].Cells[0].Value = n; dgvP11B.Rows[i].Cells[0].Value = n;
                dgvH12.Rows[i].Cells[0].Value = n; dgvP12A.Rows[i].Cells[0].Value = n; dgvP12B.Rows[i].Cells[0].Value = n;
                dgvH13.Rows[i].Cells[0].Value = n; dgvP13A.Rows[i].Cells[0].Value = n; dgvP13B.Rows[i].Cells[0].Value = n;
                #endregion
            }
            catch { }

            #endregion  
        }
        public void m_DIASMESESANOS(string fecha_inicio,string fecha_final) /////////////////////////////se usa en todos 
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
                if (fecha_inicio_mes <= fecha_final_mes )
                {
                    for (; fecha_inicio_mes <= fecha_final_mes; fecha_inicio_mes++,i++)
                        try
                        {
                            m_TABS(fecha_inicio_mes, fecha_inicio_ano+1);/////////////////////se usa en todos 
                            if (comprobarCargar(fecha_inicio_ano + 1, fecha_inicio_mes, i) == true)
                            {
                                cargar(fecha_inicio_mes, fecha_inicio_ano + 1, i);
                            }
                            else
                            {
                                ConsultaProyectado(fecha_inicio_mes, fecha_inicio_ano,i);
                                m_CalcularHistoricoP(i);
                                m_ModelosUA(fecha_inicio_mes, fecha_inicio_ano, i);
                                m_ModelosUB(fecha_inicio_mes, fecha_inicio_ano, i);
                                m_REFRESH_DGVS(i);
                            }
                            tabcontrol.SelectedIndex = tabcontrol.SelectedIndex + 1;
                        }
                        catch (Exception x)
                        {MessageBox.Show("Error con las fechas " + x);}
                }
                  if (fecha_final_mes < fecha_inicio_mes && fecha_inicio_ano != fecha_final_ano)
                {
                    for (; fecha_inicio_mes <= 12; fecha_inicio_mes++,i++)
                        try
                        {
                            m_TABS(fecha_inicio_mes, fecha_inicio_ano+1);
                            if (comprobarCargar(fecha_inicio_ano + 1, fecha_inicio_mes, i) == true)
                            {
                                cargar(fecha_inicio_mes, fecha_inicio_ano + 1, i);
                            }
                            else
                            {
                                m_CalcularHistoricoU(i, fecha_inicio_mes, fecha_inicio_ano);
                                m_CalcularHistoricoP(i);
                                m_calcularProyectadoU(i, fecha_inicio_mes, fecha_inicio_ano);
                                m_REFRESH_DGVS(i);
                                m_calcularProyectadoP(i);
                                m_REFRESH_DGVS(i);
                            }
                            tabcontrol.SelectedIndex = tabcontrol.SelectedIndex + 1;
                        }
                        catch (Exception x)
                        { MessageBox.Show("Error con las fechas " + x);}
                }
                fecha_inicio_mes = 1;
            }
            #endregion

            tabcontrol.SelectedIndex = 0;

            ///////////////////////////////////


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
        private void button1_Click(object sender, EventArgs e)
        {
            //m_CLEAR_DGVS();
          //  m_CLEAR_DGVS();
           // m_GENERARDGVS_Estructura();
           // m_VALORCED2();
            //m_CLEAR_DGVS();
            tabcontrol.SelectedIndex = 0;
            //m_MEDIDAS_NUEVO();
            //m_DIASMESESANOS(f1, f2);
            tabcontrol.SelectedIndex = 0;
            //button1.Enabled = false;
            m_REFRESH_DGVS(1);
            m_DIASMESESANOS(CED1_fechaI, CED1_fechaF);
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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            m_DIASMESESANOS_guardar(f1, f2);
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
            año++;
            bool comprobar = true;
            int indeQ = 0;
            //for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
            //{
                string s = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and anio=" + año + " and mes=" + mes+" "+querycargar[indeQ];
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
                indeQ++;
               // x = x + 2;
           // }
            return true;
        }
        public void insertar(int año, int mes, int grid, int renglon)
        {
            double valor = 0;
            string medida = "";
            double porcentaje = 0;
            int renglonP = 1;
            int qin = 0;
            switch (grid)
            {
                case 1:
                    #region insertar GridHistorico
                    for (int i = 0; i <= dgvH1.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvH1.ColumnCount - 2; x++)
                        {
                            medida = dgvH1.Columns[x].HeaderText;
                            valor = double.Parse(dgvH1.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvH1.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'H')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    #region insertar gridproyectado A
                    renglonP = 1;
                    qin = 0;
                    for (int i = 0; i <= dgvP1A.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1A.ColumnCount - 2; x++)
                        {
                            medida = dgvP1A.Columns[x].HeaderText;
                            valor = double.Parse(dgvP1A.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvP1A.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor.ToString() + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'A')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    #region insertar gridproyectado B
                    renglonP = 1;
                    qin = 0;
                    for (int i = 0; i <= dgvP1B.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1B.ColumnCount - 2; x++)
                        {
                            medida = dgvP1B.Columns[x].HeaderText;
                            valor = double.Parse(dgvP1B.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvP1B.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor.ToString() + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'B')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    break;
                case 2:
                    #region insertar GridHistorico
                    for (int i = 0; i <= dgvH1.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvH1.ColumnCount - 2; x++)
                        {
                            medida = dgvH2.Columns[x].HeaderText;
                            valor = double.Parse(dgvH2.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvH2.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'H')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    #region insertar gridproyectado A
                    renglonP = 1;
                    qin = 0;
                    for (int i = 0; i <= dgvP1A.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1A.ColumnCount - 2; x++)
                        {
                            medida = dgvP2A.Columns[x].HeaderText;
                            valor = double.Parse(dgvP2A.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvP2A.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor.ToString() + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'A')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    #region insertar gridproyectado B
                    renglonP = 1;
                    qin = 0;
                    for (int i = 0; i <= dgvP1B.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1B.ColumnCount - 2; x++)
                        {
                            medida = dgvP2B.Columns[x].HeaderText;
                            valor = double.Parse(dgvP2B.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvP2B.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor.ToString() + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'B')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    break;
                case 3:
                    #region insertar GridHistorico
                    for (int i = 0; i <= dgvH1.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvH1.ColumnCount - 2; x++)
                        {
                            medida = dgvH3.Columns[x].HeaderText;
                            valor = double.Parse(dgvH3.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvH3.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'H')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    #region insertar gridproyectado A
                    renglonP = 1;
                    qin = 0;
                    for (int i = 0; i <= dgvP1A.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1A.ColumnCount - 2; x++)
                        {
                            medida = dgvP3A.Columns[x].HeaderText;
                            valor = double.Parse(dgvP3A.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvP3A.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor.ToString() + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'A')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    #region insertar gridproyectado B
                    renglonP = 1;
                    qin = 0;
                    for (int i = 0; i <= dgvP1B.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1B.ColumnCount - 2; x++)
                        {
                            medida = dgvP3B.Columns[x].HeaderText;
                            valor = double.Parse(dgvP3B.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvP3B.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor.ToString() + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'B')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    break;
                case 4:
                    #region insertar GridHistorico
                    for (int i = 0; i <= dgvH1.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvH1.ColumnCount - 2; x++)
                        {
                            medida = dgvH4.Columns[x].HeaderText;
                            valor = double.Parse(dgvH4.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvH4.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'H')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    #region insertar gridproyectado A
                    renglonP = 1;
                    qin = 0;
                    for (int i = 0; i <= dgvP1A.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1A.ColumnCount - 2; x++)
                        {
                            medida = dgvP4A.Columns[x].HeaderText;
                            valor = double.Parse(dgvP4A.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvP4A.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor.ToString() + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'A')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    #region insertar gridproyectado B
                    renglonP = 1;
                    qin = 0;
                    for (int i = 0; i <= dgvP1B.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1B.ColumnCount - 2; x++)
                        {
                            medida = dgvP4B.Columns[x].HeaderText;
                            valor = double.Parse(dgvP4B.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvP4B.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor.ToString() + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'B')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    break;
                case 5:
                    #region insertar GridHistorico
                    for (int i = 0; i <= dgvH1.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvH1.ColumnCount - 2; x++)
                        {
                            medida = dgvH5.Columns[x].HeaderText;
                            valor = double.Parse(dgvH5.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvH5.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'H')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    #region insertar gridproyectado A
                    renglonP = 1;
                    qin = 0;
                    for (int i = 0; i <= dgvP1B.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1B.ColumnCount - 2; x++)
                        {
                            medida = dgvP5A.Columns[x].HeaderText;
                            valor = double.Parse(dgvP5A.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvP5A.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor.ToString() + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'A')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    #region insertar gridproyectado B
                    renglonP = 1;
                    qin = 0;
                    for (int i = 0; i <= dgvP1B.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1B.ColumnCount - 2; x++)
                        {
                            medida = dgvP5B.Columns[x].HeaderText;
                            valor = double.Parse(dgvP5B.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvP5B.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor.ToString() + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'B')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    break;
                case 6:
                    #region insertar GridHistorico
                    for (int i = 0; i <= dgvH1.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvH1.ColumnCount - 2; x++)
                        {
                            medida = dgvH6.Columns[x].HeaderText;
                            valor = double.Parse(dgvH6.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvH6.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'H')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    #region insertar gridproyectado A
                    renglonP = 1;
                    qin = 0;
                    for (int i = 0; i <= dgvP1A.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1A.ColumnCount - 2; x++)
                        {
                            medida = dgvP6A.Columns[x].HeaderText;
                            valor = double.Parse(dgvP6A.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvP6A.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor.ToString() + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'A')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    #region insertar gridproyectado B
                    renglonP = 1;
                    qin = 0;
                    for (int i = 0; i <= dgvP1B.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1B.ColumnCount - 2; x++)
                        {
                            medida = dgvP6B.Columns[x].HeaderText;
                            valor = double.Parse(dgvP6B.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvP6B.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor.ToString() + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'B')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    break;
                case 7:
                    #region insertar GridHistorico
                    for (int i = 0; i <= dgvH1.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvH1.ColumnCount - 2; x++)
                        {
                            medida = dgvH7.Columns[x].HeaderText;
                            valor = double.Parse(dgvH7.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvH7.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'H')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    #region insertar gridproyectado A
                    renglonP = 1;
                    qin = 0;
                    for (int i = 0; i <= dgvP1A.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1A.ColumnCount - 2; x++)
                        {
                            medida = dgvP7A.Columns[x].HeaderText;
                            valor = double.Parse(dgvP7A.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvP7A.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor.ToString() + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'A')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    #region insertar gridproyectado B
                    renglonP = 1;
                    qin = 0;
                    for (int i = 0; i <= dgvP1B.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1B.ColumnCount - 2; x++)
                        {
                            medida = dgvP7B.Columns[x].HeaderText;
                            valor = double.Parse(dgvP7B.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvP7B.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor.ToString() + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'B')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    break;
                case 8:
                    #region insertar GridHistorico
                    for (int i = 0; i <= dgvH1.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvH1.ColumnCount - 2; x++)
                        {
                            medida = dgvH8.Columns[x].HeaderText;
                            valor = double.Parse(dgvH8.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvH8.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'H')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    #region insertar gridproyectado A
                    renglonP = 1;
                    qin = 0;
                    for (int i = 0; i <= dgvP1A.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1A.ColumnCount - 2; x++)
                        {
                            medida = dgvP8A.Columns[x].HeaderText;
                            valor = double.Parse(dgvP8A.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvP8A.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor.ToString() + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'A')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    #region insertar gridproyectado B
                    renglonP = 1;
                    qin = 0;
                    for (int i = 0; i <= dgvP1B.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1B.ColumnCount - 2; x++)
                        {
                            medida = dgvP8B.Columns[x].HeaderText;
                            valor = double.Parse(dgvP8B.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvP8B.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor.ToString() + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'B')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    break;
                case 9:
                    #region insertar GridHistorico
                    for (int i = 0; i <= dgvH1.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvH1.ColumnCount - 2; x++)
                        {
                            medida = dgvH9.Columns[x].HeaderText;
                            valor = double.Parse(dgvH9.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvH9.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'H')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    #region insertar gridproyectado A
                    renglonP = 1;
                    qin = 0;
                    for (int i = 0; i <= dgvP1A.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1A.ColumnCount - 2; x++)
                        {
                            medida = dgvP9A.Columns[x].HeaderText;
                            valor = double.Parse(dgvP9A.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvP9A.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor.ToString() + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'A')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    #region insertar gridproyectado B
                    renglonP = 1;
                    qin = 0;
                    for (int i = 0; i <= dgvP1B.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1B.ColumnCount - 2; x++)
                        {
                            medida = dgvP9B.Columns[x].HeaderText;
                            valor = double.Parse(dgvP9B.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvP9B.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor.ToString() + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'B')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    break;
                case 10:
                    #region insertar GridHistorico
                    for (int i = 0; i <= dgvH1.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvH1.ColumnCount - 2; x++)
                        {
                            medida = dgvH10.Columns[x].HeaderText;
                            valor = double.Parse(dgvH10.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvH10.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'H')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    #region insertar gridproyectado A
                    renglonP = 1;
                    qin = 0;
                    for (int i = 0; i <= dgvP1A.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1A.ColumnCount - 2; x++)
                        {
                            medida = dgvP10A.Columns[x].HeaderText;
                            valor = double.Parse(dgvP10A.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvP10A.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor.ToString() + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'A')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    #region insertar gridproyectado B
                    renglonP = 1;
                    qin = 0;
                    for (int i = 0; i <= dgvP1B.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1B.ColumnCount - 2; x++)
                        {
                            medida = dgvP10B.Columns[x].HeaderText;
                            valor = double.Parse(dgvP10B.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvP10B.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor.ToString() + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'B')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    break;
                case 11:
                    #region insertar GridHistorico
                    for (int i = 0; i <= dgvH1.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvH1.ColumnCount - 2; x++)
                        {
                            medida = dgvH11.Columns[x].HeaderText;
                            valor = double.Parse(dgvH11.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvH11.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'H')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    #region insertar gridproyectado A
                    renglonP = 1;
                    qin = 0;
                    for (int i = 0; i <= dgvP1A.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1A.ColumnCount - 2; x++)
                        {
                            medida = dgvP11A.Columns[x].HeaderText;
                            valor = double.Parse(dgvP11A.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvP11A.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor.ToString() + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'A')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    #region insertar gridproyectado B
                    renglonP = 1;
                    qin = 0;
                    for (int i = 0; i <= dgvP1B.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1B.ColumnCount - 2; x++)
                        {
                            medida = dgvP11B.Columns[x].HeaderText;
                            valor = double.Parse(dgvP11B.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvP11B.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor.ToString() + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'B')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    break;
                case 12:
                    #region insertar GridHistorico
                    for (int i = 0; i <= dgvH1.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvH1.ColumnCount - 2; x++)
                        {
                            medida = dgvH12.Columns[x].HeaderText;
                            valor = double.Parse(dgvH12.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvH12.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'H')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    #region insertar gridproyectado A
                    renglonP = 1;
                    qin = 0;
                    for (int i = 0; i <= dgvP1A.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1A.ColumnCount - 2; x++)
                        {
                            medida = dgvP12A.Columns[x].HeaderText;
                            valor = double.Parse(dgvP12A.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvP12A.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor.ToString() + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'A')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    #region insertar gridproyectado B
                    renglonP = 1;
                    qin = 0;
                    for (int i = 0; i <= dgvP1B.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1B.ColumnCount - 2; x++)
                        {
                            medida = dgvP12B.Columns[x].HeaderText;
                            valor = double.Parse(dgvP12B.Rows[i].Cells[x].Value.ToString());
                            porcentaje = double.Parse(dgvP12B.Rows[renglonP].Cells[x].Value.ToString());
                            string qinsert = "insert into cedula9(nombre,medida,unidad,porcentaje,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,tipo_dgv) values ('" + Properties.Settings.Default.escenario + "','" + medida + "'," + valor.ToString() + "," + porcentaje.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[qin] + ",'B')";
                            cmd = new MySqlCommand(qinsert, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        i++;
                        renglonP = renglonP + 2;
                        qin++;
                    }
                    #endregion
                    break;
            }
        }
        public void update(int año, int mes, int grid, int renglon)
        {
            double valor = 0;
            string medida = "";
            string porcentaje = "";
            int rowp=1;
            int QueryI = 0;
            switch (grid)
            {
                case 1:
                    #region actualizar GridHistorico
                    for (int i = 0; i <= dgvH1.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvH1.ColumnCount - 2; x++)
                        {
                            medida = dgvH1.Columns[x].HeaderText;
                            porcentaje = dgvH1.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvH1.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='H' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        QueryI++;
                        rowp = rowp + 2;
                        i++;
                    }
                    #endregion
                    #region actualizar grid proyectado A
                    rowp = 1;
                    QueryI = 0;
                    for (int i = 0; i <= dgvP1A.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1A.ColumnCount - 2; x++)
                        {
                            medida = dgvP1A.Columns[x].HeaderText;
                            porcentaje = dgvP1A.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvP1A.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='A' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI = 0;
                    }
                    #endregion
                    #region actualizar grid proyectado B
                    rowp = 1;
                    QueryI = 0;
                    for (int i = 0; i <= dgvP1A.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1B.ColumnCount - 2; x++)
                        {
                            medida = dgvP1B.Columns[x].HeaderText;
                            porcentaje = dgvP1B.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvP1B.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='B' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI = 0;
                    }
                    #endregion
                    break;
                case 2:
                    #region actualizar GridHistorico
                    for (int i = 0; i <= dgvH1.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvH1.ColumnCount - 2; x++)
                        {
                            medida = dgvH2.Columns[x].HeaderText;
                            porcentaje = dgvH2.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvH2.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='H' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI++;
                    }
                    #endregion
                    #region actualizar grid proyectado A
                    rowp = 1;
                    QueryI = 0;
                    for (int i = 0; i <= dgvP1A.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1A.ColumnCount - 2; x++)
                        {
                            medida = dgvP2A.Columns[x].HeaderText;
                            porcentaje = dgvP2A.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvP2A.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='A' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        QueryI++;
                        i++;
                    }
                    #endregion
                    #region actualizar grid proyectado B
                    rowp = 1;
                    QueryI = 0;
                    for (int i = 0; i <= dgvP1A.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1A.ColumnCount - 2; x++)
                        {
                            medida = dgvP1B.Columns[x].HeaderText;
                            porcentaje = dgvP1B.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvP1B.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='B' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI = 0;
                    }
                    #endregion
                    break;
                case 3:
                    #region actualizar GridHistorico
                    for (int i = 0; i <= dgvH1.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvH1.ColumnCount - 2; x++)
                        {
                            medida = dgvH3.Columns[x].HeaderText;
                            porcentaje = dgvH3.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvH3.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='H' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI++;
                    }
                    #endregion
                    #region actualizar grid proyectado A
                    rowp = 1;
                    QueryI = 0;
                    for (int i = 0; i <= dgvP1A.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1A.ColumnCount - 2; x++)
                        {
                            medida = dgvP3A.Columns[x].HeaderText;
                            porcentaje = dgvP3A.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvP3A.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='A' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI = 0;
                    }
                    #endregion
                    #region actualizar grid proyectado B
                    rowp = 1;
                    QueryI = 0;
                    for (int i = 0; i <= dgvP1B.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1B.ColumnCount - 2; x++)
                        {
                            medida = dgvP3B.Columns[x].HeaderText;
                            porcentaje = dgvP3B.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvP3B.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='B' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI = 0;
                    }
                    #endregion
                    break;
                case 4:
                    #region actualizar GridHistorico
                    for (int i = 0; i <= dgvH1.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvH1.ColumnCount - 2; x++)
                        {
                            medida = dgvH4.Columns[x].HeaderText;
                            porcentaje = dgvH4.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvH4.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='H' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI++;
                    }
                    #endregion
                    #region actualizar grid proyectado A
                    rowp = 1;
                    QueryI = 0;
                    for (int i = 0; i <= dgvP1A.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1A.ColumnCount - 2; x++)
                        {
                            medida = dgvP4A.Columns[x].HeaderText;
                            porcentaje = dgvP4A.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvP4A.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='A' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI++;
                    }
                    #endregion
                    #region actualizar grid proyectado B
                    rowp = 1;
                    QueryI = 0;
                    for (int i = 0; i <= dgvP1B.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1B.ColumnCount - 2; x++)
                        {
                            medida = dgvP4B.Columns[x].HeaderText;
                            porcentaje = dgvP4B.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvP4B.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='B' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI++;
                    }
                    #endregion
                    break;
                case 5:
                    #region actualizar GridHistorico
                    for (int i = 0; i <= dgvH1.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvH1.ColumnCount - 2; x++)
                        {
                            medida = dgvH5.Columns[x].HeaderText;
                            porcentaje = dgvH5.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvH5.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='H' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        QueryI++;
                        i++;
                    }
                    #endregion
                    #region actualizar grid proyectado A
                    rowp = 1;
                    QueryI = 0;
                    for (int i = 0; i <= dgvP1A.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1A.ColumnCount - 2; x++)
                        {
                            medida = dgvP5A.Columns[x].HeaderText;
                            porcentaje = dgvP5A.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvP5A.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='A' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI++;
                    }
                    #endregion
                    #region actualizar grid proyectado B
                    rowp = 1;
                    QueryI = 0;
                    for (int i = 0; i <= dgvP1B.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1B.ColumnCount - 2; x++)
                        {
                            medida = dgvP5B.Columns[x].HeaderText;
                            porcentaje = dgvP5B.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvP5B.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='B' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI++;
                    }
                    #endregion
                    break;
                case 6:
                    #region actualizar GridHistorico
                    for (int i = 0; i <= dgvH1.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvH1.ColumnCount - 2; x++)
                        {
                            medida = dgvH6.Columns[x].HeaderText;
                            porcentaje = dgvH6.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvH6.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='H' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        QueryI++;
                        i++;
                    }
                    #endregion
                    #region actualizar grid proyectado A
                    rowp = 1;
                    QueryI = 0;
                    for (int i = 0; i <= dgvP1A.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1A.ColumnCount - 2; x++)
                        {
                            medida = dgvP6A.Columns[x].HeaderText;
                            porcentaje = dgvP6A.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvP6A.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='A' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI++;
                    }
                    #endregion
                    #region actualizar grid proyectado B
                    rowp = 1;
                    QueryI = 0;
                    for (int i = 0; i <= dgvP1B.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1B.ColumnCount - 2; x++)
                        {
                            medida = dgvP6B.Columns[x].HeaderText;
                            porcentaje = dgvP6B.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvP6B.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='B' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI++;
                    }
                    #endregion
                    break;
                case 7:
                    #region actualizar GridHistorico
                    for (int i = 0; i <= dgvH1.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvH1.ColumnCount - 2; x++)
                        {
                            medida = dgvH7.Columns[x].HeaderText;
                            porcentaje = dgvH7.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvH7.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='H' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI++;
                    }
                    #endregion
                    #region actualizar grid proyectado A
                    rowp = 1;
                    QueryI = 0;
                    for (int i = 0; i <= dgvP1A.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1A.ColumnCount - 2; x++)
                        {
                            medida = dgvP7A.Columns[x].HeaderText;
                            porcentaje = dgvP7A.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvP7A.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='A' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI++;
                    }
                    #endregion
                    #region actualizar grid proyectado B
                    rowp = 1;
                    QueryI = 0;
                    for (int i = 0; i <= dgvP1B.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1B.ColumnCount - 2; x++)
                        {
                            medida = dgvP7B.Columns[x].HeaderText;
                            porcentaje = dgvP7B.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvP7B.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='B' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI++;
                    }
                    #endregion
                    break;
                case 8:
                    #region actualizar GridHistorico
                    for (int i = 0; i <= dgvH1.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvH1.ColumnCount - 2; x++)
                        {
                            medida = dgvH8.Columns[x].HeaderText;
                            porcentaje = dgvH8.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvH8.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='H' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI++;
                    }
                    #endregion
                    #region actualizar grid proyectado A
                    rowp = 1;
                    QueryI = 0;
                    for (int i = 0; i <= dgvP1A.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1A.ColumnCount - 2; x++)
                        {
                            medida = dgvP8A.Columns[x].HeaderText;
                            porcentaje = dgvP8A.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvP8A.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='A' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI++;
                    }
                    #endregion
                    #region actualizar grid proyectado B
                    rowp = 1;
                    QueryI = 0;
                    for (int i = 0; i <= dgvP1B.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1B.ColumnCount - 2; x++)
                        {
                            medida = dgvP8B.Columns[x].HeaderText;
                            porcentaje = dgvP8B.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvP8B.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='B' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI++;
                    }
                    #endregion
                    break;
                case 9:
                    #region actualizar GridHistorico
                    for (int i = 0; i <= dgvH1.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvH1.ColumnCount - 2; x++)
                        {
                            medida = dgvH9.Columns[x].HeaderText;
                            porcentaje = dgvH9.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvH9.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='H' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI++;
                    }
                    #endregion
                    #region actualizar grid proyectado A
                    rowp = 1;
                    QueryI = 0;
                    for (int i = 0; i <= dgvP1A.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1A.ColumnCount - 2; x++)
                        {
                            medida = dgvP9A.Columns[x].HeaderText;
                            porcentaje = dgvP9A.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvP9A.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='A' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        QueryI++;
                        i++;
                    }
                    #endregion
                    #region actualizar grid proyectado B
                    rowp = 1;
                    QueryI = 0;
                    for (int i = 0; i <= dgvP1B.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1B.ColumnCount - 2; x++)
                        {
                            medida = dgvP9B.Columns[x].HeaderText;
                            porcentaje = dgvP9B.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvP9B.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='B' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        QueryI++;
                        i++;
                    }
                    #endregion
                    break;
                case 10:
                    #region actualizar GridHistorico
                    for (int i = 0; i <= dgvH1.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvH1.ColumnCount - 2; x++)
                        {
                            medida = dgvH10.Columns[x].HeaderText;
                            porcentaje = dgvH10.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvH10.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='H' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI++;
                    }
                    #endregion
                    #region actualizar grid proyectado A
                    rowp = 1;
                    QueryI = 0;
                    for (int i = 0; i <= dgvP1A.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1A.ColumnCount - 2; x++)
                        {
                            medida = dgvP10A.Columns[x].HeaderText;
                            porcentaje = dgvP10A.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvP10A.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='A' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        QueryI++;
                        i++;
                    }
                    #endregion
                    #region actualizar grid proyectado B
                    rowp = 1;
                    QueryI = 0;
                    for (int i = 0; i <= dgvP1B.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1B.ColumnCount - 2; x++)
                        {
                            medida = dgvP10B.Columns[x].HeaderText;
                            porcentaje = dgvP10B.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvP10B.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='B' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        QueryI++;
                        i++;
                    }
                    #endregion
                    break;
                case 11:
                    #region actualizar GridHistorico
                    for (int i = 0; i <= dgvH1.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvH1.ColumnCount - 2; x++)
                        {
                            medida = dgvH11.Columns[x].HeaderText;
                            porcentaje = dgvH11.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvH11.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='H' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI++;
                    }
                    #endregion
                    #region actualizar grid proyectado A
                    rowp = 1;
                    QueryI = 0;
                    for (int i = 0; i <= dgvP1A.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1A.ColumnCount - 2; x++)
                        {
                            medida = dgvP11A.Columns[x].HeaderText;
                            porcentaje = dgvP11A.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvP11A.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='A' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI++;
                    }
                    #endregion
                    #region actualizar grid proyectado B
                    rowp = 1;
                    QueryI = 0;
                    for (int i = 0; i <= dgvP1B.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1B.ColumnCount - 2; x++)
                        {
                            medida = dgvP11B.Columns[x].HeaderText;
                            porcentaje = dgvP11B.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvP11B.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='B' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI++;
                    }
                    #endregion
                    break;
                case 12:
                    #region actualizar GridHistorico
                    for (int i = 0; i <= dgvH1.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvH1.ColumnCount - 2; x++)
                        {
                            medida = dgvH12.Columns[x].HeaderText;
                            porcentaje = dgvH12.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvH12.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='H' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI++;
                    }
                    #endregion
                    #region actualizar grid proyectado A
                    rowp = 1;
                    QueryI = 0;
                    for (int i = 0; i <= dgvP1A.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1A.ColumnCount - 2; x++)
                        {
                            medida = dgvP12A.Columns[x].HeaderText;
                            porcentaje = dgvP12A.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvP12A.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='A' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI++;
                    }
                    #endregion
                    #region actualizar grid proyectado B
                    rowp = 1;
                    QueryI = 0;
                    for (int i = 0; i <= dgvP1B.Rows.Count - 1; i++)
                    {
                        for (int x = 1; x <= dgvP1B.ColumnCount - 2; x++)
                        {
                            medida = dgvP12B.Columns[x].HeaderText;
                            porcentaje = dgvP12B.Rows[rowp].Cells[x].Value.ToString();
                            valor = double.Parse(dgvP12B.Rows[i].Cells[x].Value.ToString());
                            string s = "update cedula9 set porcentaje='" + porcentaje + "',unidad=" + valor.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes + " and anio=" + año + " " + querycargar[QueryI] + " and tipo_dgv='B' and medida=" + medida + "";
                            cmd = new MySqlCommand(s, Conn);
                            cmd.ExecuteNonQuery();
                        }
                        rowp = rowp + 2;
                        i++;
                        QueryI++;
                    }
                    #endregion
                    break;
            }
        }   
        public void m_regleta()
        {
           if(filtrardpto==true)
           {
               if (cbDepto.Text == "DAMAS" || cbDepto.Text == "CABALLEROS" || cbDepto.Text == "BEBES" || cbDepto.Text == "INFANTIL")
               {
                   m_estructuraDpto();
               }
               else
               {
                   regleta(8,31);
               }
           }
            else
           {
               regleta(8, 31);
           }
        }
        private void m_estructuraDpto()
        {
            string depto = "";
            depto = cbDepto.Text;
            switch(depto)
            {
                case "CABALLEROS":
                    regleta(25,32);
                    break;
                case "DAMAS":
                    regleta(22, 28);
                    break;
                case "BEBES":
                    regleta(8, 15);
                    break;
                case "INFANTIL":
                    regleta(12, 28);
                    break;
            }
        }
        private void regleta(double inicio,double fin)
        {
            numeroMenor = inicio.ToString();
            numeromayor = fin.ToString();
            double medio= .5;
            int i = 1;
            string medida = "";
            bool puntomedio=false;
            double entero = 1;
            entero = inicio;
            while(inicio<=fin-1)
            {
                
                nombre = Convert.ToString(inicio);
                agregarColumna();
                agregarNombre(i,nombre);
                if (inicio <= 10)
                {
                    medida = "0"+entero.ToString();
                    if (puntomedio == false)
                    {
                        medidas[i] = medida.ToString();
                        puntomedio = true;
                    }
                    else
                    {
                        puntomedio = false;
                        medidas[i] = medida.ToString() + "-";
                        entero++;
                    }
                }
                else
                {
                    medida = entero.ToString();
                    if (puntomedio == false)
                    {
                        medidas[i] = medida.ToString();
                        puntomedio = true;
                    }
                    else
                    {
                        puntomedio = false;
                        medidas[i] = medida.ToString() + "-";
                        entero++;
                    }
                }
                inicio = inicio + medio;
                i++;
                
            }
            agregarColumna();
            agregarNombre((dgvH1.ColumnCount-1), "Total");
        }
        private void agregarColumna()
        {
            #region historico
            dgvH1.Columns.Add("",""); dgvH3.Columns.Add("",""); dgvH5.Columns.Add("",""); dgvH7.Columns.Add("",""); dgvH9.Columns.Add("",""); dgvH11.Columns.Add("","");
            dgvH2.Columns.Add("",""); dgvH4.Columns.Add("",""); dgvH6.Columns.Add("",""); dgvH8.Columns.Add("",""); dgvH10.Columns.Add("",""); dgvH12.Columns.Add("","");
            #endregion
            #region editable
            dgvP1B.Columns.Add("", ""); dgvP3B.Columns.Add("", ""); dgvP5B.Columns.Add("", ""); dgvP7B.Columns.Add("", ""); dgvP9B.Columns.Add("", ""); dgvP11B.Columns.Add("", "");
            dgvP2B.Columns.Add("", ""); dgvP4B.Columns.Add("", ""); dgvP6B.Columns.Add("", ""); dgvP8B.Columns.Add("", ""); dgvP10B.Columns.Add("", ""); dgvP12B.Columns.Add("", "");
            #endregion
            #region proyectado
            dgvP1A.Columns.Add("",""); dgvP3A.Columns.Add("",""); dgvP5A.Columns.Add("",""); dgvP7A.Columns.Add("",""); dgvP9A.Columns.Add("",""); dgvP11A.Columns.Add("","");
            dgvP2A.Columns.Add("",""); dgvP4A.Columns.Add("",""); dgvP6A.Columns.Add("",""); dgvP8A.Columns.Add("",""); dgvP10A.Columns.Add("",""); dgvP12A.Columns.Add("","");
            #endregion
        }
        private void agregarNombre(int columna,string nombre)
        {
            #region historico
            dgvH1.Columns[columna].HeaderText = nombre; dgvH5.Columns[columna].HeaderText = nombre; dgvH9.Columns[columna].HeaderText = nombre;
            dgvH2.Columns[columna].HeaderText = nombre; dgvH6.Columns[columna].HeaderText = nombre; dgvH10.Columns[columna].HeaderText = nombre;
            dgvH3.Columns[columna].HeaderText = nombre; dgvH7.Columns[columna].HeaderText = nombre; dgvH11.Columns[columna].HeaderText = nombre;
            dgvH4.Columns[columna].HeaderText = nombre; dgvH8.Columns[columna].HeaderText = nombre; dgvH12.Columns[columna].HeaderText = nombre;
            #endregion
            #region editable
            dgvP1B.Columns[columna].HeaderText = nombre; dgvP5B.Columns[columna].HeaderText = nombre; dgvP9B.Columns[columna].HeaderText = nombre;
            dgvP2B.Columns[columna].HeaderText = nombre; dgvP6B.Columns[columna].HeaderText = nombre; dgvP10B.Columns[columna].HeaderText = nombre;
            dgvP3B.Columns[columna].HeaderText = nombre; dgvP7B.Columns[columna].HeaderText = nombre; dgvP11B.Columns[columna].HeaderText = nombre;
            dgvP4B.Columns[columna].HeaderText = nombre; dgvP8B.Columns[columna].HeaderText = nombre; dgvP12B.Columns[columna].HeaderText = nombre;
            #endregion
            #region Proyectado
            dgvP1A.Columns[columna].HeaderText = nombre; dgvP5A.Columns[columna].HeaderText = nombre; dgvP9A.Columns[columna].HeaderText = nombre;
            dgvP2A.Columns[columna].HeaderText = nombre; dgvP6A.Columns[columna].HeaderText = nombre; dgvP10A.Columns[columna].HeaderText = nombre;
            dgvP3A.Columns[columna].HeaderText = nombre; dgvP7A.Columns[columna].HeaderText = nombre; dgvP11A.Columns[columna].HeaderText = nombre;
            dgvP4A.Columns[columna].HeaderText = nombre; dgvP8A.Columns[columna].HeaderText = nombre; dgvP12A.Columns[columna].HeaderText = nombre;
            #endregion
        }
        private void m_CalcularHistoricoU(int i, int mes,int año)
        {
            
            int x = 0;
            
            switch (i)
            {
                case 1:
                    #region dgv1
                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                    {
                        double[] cantidadHU = new double[1000];
                        double totalHU = 0;
                        for (int c = 1; c <= dgvH1.Columns.Count - 2; c++)
                        {
                            string q = "SELECT HIGH_PRIORITY sum(ctdneta) as cantidad from ventasbase as v inner join fecha as f on v.idfecha=f.idfecha where f.mes=" + mes + " and f.anio=" + año + " and v.medida='" + medidas[c] + "' " + wherequery[x];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                if (reader["cantidad"].ToString() == "")
                                {
                                    cantidadHU[c] = 0;
                                }
                                else
                                {
                                    cantidadHU[c] = double.Parse(reader["cantidad"].ToString());
                                }
                                totalHU += cantidadHU[c];
                            }
                            reader.Close();
                            #region calculos
                            dgvH1.Rows[r].Cells[c].Value = cantidadHU[c].ToString();
                            dgvH1.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalHU;
                            #endregion
                            m_REFRESH_DGVS(i);
                        }
                        r++;
                        x++;
                    }
#endregion
                    break;
                case 2:
                    #region dgv1
                    for (int r = 0; r <= dgvH2.Rows.Count - 1; r++)
                    {
                        double[] cantidadHU = new double[1000];
                        double totalHU = 0;
                        for (int c = 1; c <= dgvH2.Columns.Count - 2; c++)
                        {
                            string q = "SELECT sum(ctdneta) as cantidad from ventasbase as v inner join fecha as f on v.idfecha=f.idfecha where f.mes=" + mes + " and f.anio=" + año + " and v.medida='" + medidas[c] + "' " + wherequery[x];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                if (reader["cantidad"].ToString() == "")
                                {
                                    cantidadHU[c] = 0;
                                }
                                else
                                {
                                    cantidadHU[c] = double.Parse(reader["cantidad"].ToString());
                                }
                                totalHU += cantidadHU[c];
                            }
                            reader.Close();
                            #region calculos
                            dgvH2.Rows[r].Cells[c].Value = cantidadHU[c].ToString();
                            dgvH2.Rows[r].Cells[dgvH2.ColumnCount - 1].Value = totalHU;
                            #endregion
                            m_REFRESH_DGVS(i);
                        }
                        r++;
                        x++;
                    }
                    #endregion
                    break;
                case 3:
                    #region dgv1
                    for (int r = 0; r <= dgvH3.Rows.Count - 1; r++)
                    {
                        double[] cantidadHU = new double[1000];
                        double totalHU = 0;
                        for (int c = 1; c <= dgvH3.Columns.Count - 2; c++)
                        {
                            string q = "SELECT sum(ctdneta) as cantidad from ventasbase as v inner join fecha as f on v.idfecha=f.idfecha where f.mes=" + mes + " and f.anio=" + año + " and v.medida='" + medidas[c] + "' " + wherequery[x];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                if (reader["cantidad"].ToString() == "")
                                {
                                    cantidadHU[c] = 0;
                                }
                                else
                                {
                                    cantidadHU[c] = double.Parse(reader["cantidad"].ToString());
                                }
                                totalHU += cantidadHU[c];
                            }
                            reader.Close();
                            #region calculos
                            dgvH3.Rows[r].Cells[c].Value = cantidadHU[c].ToString();
                            dgvH3.Rows[r].Cells[dgvH3.ColumnCount - 1].Value = totalHU;
                            #endregion
                            m_REFRESH_DGVS(i);
                        }
                        r++;
                        x++;
                    }
                    #endregion
                    break;
                case 4:
                    #region dgv1
                    for (int r = 0; r <= dgvH4.Rows.Count - 1; r++)
                    {
                        double[] cantidadHU = new double[1000];
                        double totalHU = 0;
                        for (int c = 1; c <= dgvH4.Columns.Count - 2; c++)
                        {
                            string q = "SELECT sum(ctdneta) as cantidad from ventasbase as v inner join fecha as f on v.idfecha=f.idfecha where f.mes=" + mes + " and f.anio=" + año + " and v.medida='" + medidas[c] + "' " + wherequery[x];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                if (reader["cantidad"].ToString() == "")
                                {
                                    cantidadHU[c] = 0;
                                }
                                else
                                {
                                    cantidadHU[c] = double.Parse(reader["cantidad"].ToString());
                                }
                                totalHU += cantidadHU[c];
                            }
                            reader.Close();
                            #region calculos
                            dgvH4.Rows[r].Cells[c].Value = cantidadHU[c].ToString();
                            dgvH4.Rows[r].Cells[dgvH4.ColumnCount - 1].Value = totalHU;
                            #endregion
                            m_REFRESH_DGVS(i);
                        }
                        r++;
                        x++;
                    }
                    #endregion
                    break;
                case 5:
                    #region dgv1
                    for (int r = 0; r <= dgvH5.Rows.Count - 1; r++)
                    {
                        double[] cantidadHU = new double[1000];
                        double totalHU = 0;
                        for (int c = 1; c <= dgvH5.Columns.Count - 2; c++)
                        {
                            string q = "SELECT sum(ctdneta) as cantidad from ventasbase as v inner join fecha as f on v.idfecha=f.idfecha where f.mes=" + mes + " and f.anio=" + año + " and v.medida='" + medidas[c] + "' " + wherequery[x];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                if (reader["cantidad"].ToString() == "")
                                {
                                    cantidadHU[c] = 0;
                                }
                                else
                                {
                                    cantidadHU[c] = double.Parse(reader["cantidad"].ToString());
                                }
                                totalHU += cantidadHU[c];
                            }
                            reader.Close();
                            #region calculos
                            dgvH5.Rows[r].Cells[c].Value = cantidadHU[c].ToString();
                            dgvH5.Rows[r].Cells[dgvH5.ColumnCount - 1].Value = totalHU;
                            #endregion
                            m_REFRESH_DGVS(i);
                        }
                        r++;
                        x++;
                    }
                    #endregion
                    break;
                case 6:
                    #region dgv1
                    for (int r = 0; r <= dgvH6.Rows.Count - 1; r++)
                    {
                        double[] cantidadHU = new double[1000];
                        double totalHU = 0;
                        for (int c = 1; c <= dgvH6.Columns.Count - 2; c++)
                        {
                            string q = "SELECT sum(ctdneta) as cantidad from ventasbase as v inner join fecha as f on v.idfecha=f.idfecha where f.mes=" + mes + " and f.anio=" + año + " and v.medida='" + medidas[c] + "' " + wherequery[x];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                if (reader["cantidad"].ToString() == "")
                                {
                                    cantidadHU[c] = 0;
                                }
                                else
                                {
                                    cantidadHU[c] = double.Parse(reader["cantidad"].ToString());
                                }
                                totalHU += cantidadHU[c];
                            }
                            reader.Close();
                            #region calculos
                            dgvH6.Rows[r].Cells[c].Value = cantidadHU[c].ToString();
                            dgvH6.Rows[r].Cells[dgvH6.ColumnCount - 1].Value = totalHU;
                            #endregion
                            m_REFRESH_DGVS(i);
                        }
                        r++;
                        x++;
                    }
                    #endregion
                    break;
                case 7:
                    #region dgv1
                    for (int r = 0; r <= dgvH7.Rows.Count - 1; r++)
                    {
                        double[] cantidadHU = new double[1000];
                        double totalHU = 0;
                        for (int c = 1; c <= dgvH7.Columns.Count - 2; c++)
                        {
                            string q = "SELECT sum(ctdneta) as cantidad from ventasbase as v inner join fecha as f on v.idfecha=f.idfecha where f.mes=" + mes + " and f.anio=" + año + " and v.medida='" + medidas[c] + "' " + wherequery[x];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                if (reader["cantidad"].ToString() == "")
                                {
                                    cantidadHU[c] = 0;
                                }
                                else
                                {
                                    cantidadHU[c] = double.Parse(reader["cantidad"].ToString());
                                }
                                totalHU += cantidadHU[c];
                            }
                            reader.Close();
                            #region calculos
                            dgvH7.Rows[r].Cells[c].Value = cantidadHU[c].ToString();
                            dgvH7.Rows[r].Cells[dgvH7.ColumnCount - 1].Value = totalHU;
                            #endregion
                            m_REFRESH_DGVS(i);
                        }
                        r++;
                        x++;
                    }
                    #endregion
                    break;
                case 8:
                    #region dgv1
                    for (int r = 0; r <= dgvH8.Rows.Count - 1; r++)
                    {
                        double[] cantidadHU = new double[1000];
                        double totalHU = 0;
                        for (int c = 1; c <= dgvH8.Columns.Count - 2; c++)
                        {
                            string q = "SELECT sum(ctdneta) as cantidad from ventasbase as v inner join fecha as f on v.idfecha=f.idfecha where f.mes=" + mes + " and f.anio=" + año + " and v.medida='" + medidas[c] + "' " + wherequery[x];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                if (reader["cantidad"].ToString() == "")
                                {
                                    cantidadHU[c] = 0;
                                }
                                else
                                {
                                    cantidadHU[c] = double.Parse(reader["cantidad"].ToString());
                                }
                                totalHU += cantidadHU[c];
                            }
                            reader.Close();
                            #region calculos
                            dgvH8.Rows[r].Cells[c].Value = cantidadHU[c].ToString();
                            dgvH8.Rows[r].Cells[dgvH8.ColumnCount - 1].Value = totalHU;
                            #endregion
                            m_REFRESH_DGVS(i);
                        }
                        r++;
                        x++;
                    }
                    #endregion
                    break;
                case 9:
                    #region dgv1
                    for (int r = 0; r <= dgvH9.Rows.Count - 1; r++)
                    {
                        double[] cantidadHU = new double[1000];
                        double totalHU = 0;
                        for (int c = 1; c <= dgvH9.Columns.Count - 2; c++)
                        {
                            string q = "SELECT sum(ctdneta) as cantidad from ventasbase as v inner join fecha as f on v.idfecha=f.idfecha where f.mes=" + mes + " and f.anio=" + año + " and v.medida='" + medidas[c] + "' " + wherequery[x];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                if (reader["cantidad"].ToString() == "")
                                {
                                    cantidadHU[c] = 0;
                                }
                                else
                                {
                                    cantidadHU[c] = double.Parse(reader["cantidad"].ToString());
                                }
                                totalHU += cantidadHU[c];
                            }
                            reader.Close();
                            #region calculos
                            dgvH9.Rows[r].Cells[c].Value = cantidadHU[c].ToString();
                            dgvH9.Rows[r].Cells[dgvH9.ColumnCount - 1].Value = totalHU;
                            #endregion
                            m_REFRESH_DGVS(i);
                        }
                        r++;
                        x++;
                    }
                    #endregion
                    break;
                case 10:
                    #region dgv1
                    for (int r = 0; r <= dgvH10.Rows.Count - 1; r++)
                    {
                        double[] cantidadHU = new double[1000];
                        double totalHU = 0;
                        for (int c = 1; c <= dgvH10.Columns.Count - 2; c++)
                        {
                            string q = "SELECT sum(ctdneta) as cantidad from ventasbase as v inner join fecha as f on v.idfecha=f.idfecha where f.mes=" + mes + " and f.anio=" + año + " and v.medida='" + medidas[c] + "' " + wherequery[x];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                if (reader["cantidad"].ToString() == "")
                                {
                                    cantidadHU[c] = 0;
                                }
                                else
                                {
                                    cantidadHU[c] = double.Parse(reader["cantidad"].ToString());
                                }
                                totalHU += cantidadHU[c];
                            }
                            reader.Close();
                            #region calculos
                            dgvH10.Rows[r].Cells[c].Value = cantidadHU[c].ToString();
                            dgvH10.Rows[r].Cells[dgvH10.ColumnCount - 1].Value = totalHU;
                            #endregion
                            m_REFRESH_DGVS(i);
                        }
                        r++;
                        x++;
                    }
                    #endregion
                    break;
                case 11:
                    #region dgv1
                    for (int r = 0; r <= dgvH11.Rows.Count - 1; r++)
                    {
                        double[] cantidadHU = new double[1000];
                        double totalHU = 0;
                        for (int c = 1; c <= dgvH11.Columns.Count - 2; c++)
                        {
                            string q = "SELECT sum(ctdneta) as cantidad from ventasbase as v inner join fecha as f on v.idfecha=f.idfecha where f.mes=" + mes + " and f.anio=" + año + " and v.medida='" + medidas[c] + "' " + wherequery[x];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                if (reader["cantidad"].ToString() == "")
                                {
                                    cantidadHU[c] = 0;
                                }
                                else
                                {
                                    cantidadHU[c] = double.Parse(reader["cantidad"].ToString());
                                }
                                totalHU += cantidadHU[c];
                            }
                            reader.Close();
                            #region calculos
                            dgvH11.Rows[r].Cells[c].Value = cantidadHU[c].ToString();
                            dgvH11.Rows[r].Cells[dgvH11.ColumnCount - 1].Value = totalHU;
                            #endregion
                            m_REFRESH_DGVS(i);
                        }
                        r++;
                        x++;
                    }
                    #endregion
                    break;
                case 12:
                    #region dgv1
                    for (int r = 0; r <= dgvH12.Rows.Count - 1; r++)
                    {
                        double[] cantidadHU = new double[1000];
                        double totalHU = 0;
                        for (int c = 1; c <= dgvH12.Columns.Count - 2; c++)
                        {
                            string q = "SELECT sum(ctdneta) as cantidad from ventasbase as v inner join fecha as f on v.idfecha=f.idfecha where f.mes=" + mes + " and f.anio=" + año + " and v.medida='" + medidas[c] + "' " + wherequery[x];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                if (reader["cantidad"].ToString() == "")
                                {
                                    cantidadHU[c] = 0;
                                }
                                else
                                {
                                    cantidadHU[c] = double.Parse(reader["cantidad"].ToString());
                                }
                                totalHU += cantidadHU[c];
                            }
                            reader.Close();
                            #region calculos
                            dgvH12.Rows[r].Cells[c].Value = cantidadHU[c].ToString();
                            dgvH12.Rows[r].Cells[dgvH12.ColumnCount - 1].Value = totalHU;
                            #endregion
                            m_REFRESH_DGVS(i);
                        }
                        r++;
                        x++;
                    }
                    #endregion
                    break;
            }
        }
        private void m_CalcularHistoricoP(int i)
        {
            double cantidadHP = 0,cantidadTHP=0;
            double totalHP = 0;
            double totalUHP = 0;
            bool bandera = false;
            double cantidadUHP = 0;
            double[] tot=new double[1000];
            int row = 1;
           
            switch (i)
            {
                case 1:
                    #region
                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                    {
                        cantidadHP = 0;
                        cantidadTHP = 0;
                        totalHP = 0;
                        cantidadTHP += double.Parse(dgvH1.Rows[r].Cells[dgvH1.ColumnCount-1].Value.ToString());
                        for (int c = 1; c <= dgvH1.Columns.Count - 2; c++)
                        {
                            nulos(i, c);
                            if (double.Parse(dgvH1.Rows[r].Cells[c].Value.ToString()) != 0 && cantidadTHP != 0)
                            {
                                cantidadHP = (double.Parse(dgvH1.Rows[r].Cells[c].Value.ToString()) * 100) / cantidadTHP;
                            }
                            else { cantidadHP = 0; }
                            dgvH1.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");
                            dgvP1A.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");
                            dgvP1B.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");

                            totalHP += cantidadHP;
                            dgvH1.Rows[row].Cells[dgvH1.ColumnCount - 1].Value = totalHP;
                            dgvP1A.Rows[row].Cells[dgvH1.ColumnCount - 1].Value = totalHP;
                            dgvP1B.Rows[row].Cells[dgvH1.ColumnCount - 1].Value = totalHP;
                        }
                        row = row + 2;
                        r++;
                    }
#endregion
                    break;
                case 2:
                    #region
                    for (int r = 0; r <= dgvH2.Rows.Count - 1; r++)
                    {
                        cantidadHP = 0;
                        cantidadTHP = 0;
                        totalHP = 0;
                        cantidadTHP += double.Parse(dgvH2.Rows[r].Cells[dgvH2.ColumnCount - 1].Value.ToString());
                        for (int c = 1; c <= dgvH2.Columns.Count - 2; c++)
                        {
                            nulos(i, c);
                            if (double.Parse(dgvH2.Rows[r].Cells[c].Value.ToString()) != 0 && cantidadTHP != 0)
                            {
                                cantidadHP = (double.Parse(dgvH2.Rows[r].Cells[c].Value.ToString()) * 100) / cantidadTHP;
                            }
                            else { cantidadHP = 0; }
                            dgvH2.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");
                            dgvP2A.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");
                            dgvP2B.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");
                            totalHP += cantidadHP;
                            dgvH2.Rows[row].Cells[dgvH2.ColumnCount - 1].Value = totalHP;
                            dgvP2A.Rows[row].Cells[dgvH2.ColumnCount - 1].Value = totalHP;
                            dgvP2B.Rows[row].Cells[dgvH2.ColumnCount - 1].Value = totalHP;

                        }
                        row = row + 2;
                        r++;
                    }
                    #endregion
                    break;
                case 3:
                    #region
                    for (int r = 0; r <= dgvH3.Rows.Count - 1; r++)
                    {
                        cantidadHP = 0;
                        cantidadTHP = 0;
                        totalHP = 0;
                        cantidadTHP += double.Parse(dgvH3.Rows[r].Cells[dgvH3.ColumnCount - 1].Value.ToString());
                        for (int c = 1; c <= dgvH3.Columns.Count - 2; c++)
                        {
                            nulos(i, c);
                            if (double.Parse(dgvH3.Rows[r].Cells[c].Value.ToString()) != 0 && cantidadTHP != 0)
                            {
                                cantidadHP = (double.Parse(dgvH3.Rows[r].Cells[c].Value.ToString()) * 100) / cantidadTHP;
                            }
                            else { cantidadHP = 0; }
                            dgvH3.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");
                            dgvP3A.Rows[row].Cells[c].Value=cantidadHP.ToString("N2");
                            dgvP3B.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");

                            totalHP += cantidadHP;
                            dgvH3.Rows[row].Cells[dgvH3.ColumnCount - 1].Value = totalHP;
                            dgvP3A.Rows[row].Cells[dgvH3.ColumnCount - 1].Value = totalHP;
                            dgvP3B.Rows[row].Cells[dgvH3.ColumnCount - 1].Value = totalHP;

                        }
                        row = row + 2;
                        r++;
                    }
                    #endregion
                    break;
                case 4:
                    #region
                    for (int r = 0; r <= dgvH4.Rows.Count - 1; r++)
                    {
                        cantidadHP = 0;
                        cantidadTHP = 0;
                        totalHP = 0;
                        cantidadTHP += double.Parse(dgvH4.Rows[r].Cells[dgvH4.ColumnCount - 1].Value.ToString());
                        for (int c = 1; c <= dgvH4.Columns.Count - 2; c++)
                        {
                            nulos(i, c);
                            if (double.Parse(dgvH4.Rows[r].Cells[c].Value.ToString()) != 0 && cantidadTHP != 0)
                            {
                                cantidadHP = (double.Parse(dgvH4.Rows[r].Cells[c].Value.ToString()) * 100) / cantidadTHP;
                            }
                            else { cantidadHP = 0; }
                            dgvH4.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");
                            dgvP4A.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");
                            dgvP4B.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");

                            totalHP += cantidadHP;
                            dgvH4.Rows[row].Cells[dgvH4.ColumnCount - 1].Value = totalHP;
                            dgvP4A.Rows[row].Cells[dgvH4.ColumnCount - 1].Value = totalHP;
                            dgvP4B.Rows[row].Cells[dgvH4.ColumnCount - 1].Value = totalHP;

                        }
                        row = row + 2;
                        r++;
                    }
                    #endregion
                    break;
                case 5:
                    #region
                    for (int r = 0; r <= dgvH5.Rows.Count - 1; r++)
                    {
                        cantidadHP = 0;
                        cantidadTHP = 0;
                        totalHP = 0;
                        cantidadTHP += double.Parse(dgvH5.Rows[r].Cells[dgvH5.ColumnCount - 1].Value.ToString());
                        for (int c = 1; c <= dgvH5.Columns.Count - 2; c++)
                        {
                            nulos(i, c);
                            if (double.Parse(dgvH5.Rows[r].Cells[c].Value.ToString()) != 0 && cantidadTHP != 0)
                            {
                                cantidadHP = (double.Parse(dgvH5.Rows[r].Cells[c].Value.ToString()) * 100) / cantidadTHP;
                            }
                            else { cantidadHP = 0; }
                            dgvH5.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");
                            dgvP5A.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");
                            dgvP5B.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");

                            totalHP += cantidadHP;
                            dgvH5.Rows[row].Cells[dgvH5.ColumnCount - 1].Value = totalHP;
                            dgvP5A.Rows[row].Cells[dgvH5.ColumnCount - 1].Value = totalHP;
                            dgvP5B.Rows[row].Cells[dgvH5.ColumnCount - 1].Value = totalHP;

                        }
                        row = row + 2;
                        r++;
                    }
                    #endregion
                    break;
                case 6:
                    #region
                    for (int r = 0; r <= dgvH6.Rows.Count - 1; r++)
                    {
                        cantidadHP = 0;
                        cantidadTHP = 0;
                        totalHP = 0;
                        cantidadTHP += double.Parse(dgvH6.Rows[r].Cells[dgvH6.ColumnCount - 1].Value.ToString());
                        for (int c = 1; c <= dgvH6.Columns.Count - 2; c++)
                        {
                            nulos(i, c);
                            if (double.Parse(dgvH6.Rows[r].Cells[c].Value.ToString()) != 0 && cantidadTHP != 0)
                            {
                                cantidadHP = (double.Parse(dgvH6.Rows[r].Cells[c].Value.ToString()) * 100) / cantidadTHP;
                            }
                            else { cantidadHP = 0; }
                            dgvH6.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");
                            dgvP6A.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");
                            dgvP6B.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");

                            totalHP += cantidadHP;
                            dgvH6.Rows[row].Cells[dgvH6.ColumnCount - 1].Value = totalHP;
                            dgvP6A.Rows[row].Cells[dgvH6.ColumnCount - 1].Value = totalHP;
                            dgvP6B.Rows[row].Cells[dgvH6.ColumnCount - 1].Value = totalHP;

                        }
                        row = row + 2;
                        r++;
                    }
                    #endregion
                    break;
                case 7:
                    #region
                    for (int r = 0; r <= dgvH7.Rows.Count - 1; r++)
                    {
                        cantidadHP = 0;
                        cantidadTHP = 0;
                        totalHP = 0;
                        cantidadTHP += double.Parse(dgvH7.Rows[r].Cells[dgvH7.ColumnCount - 1].Value.ToString());
                        for (int c = 1; c <= dgvH7.Columns.Count - 2; c++)
                        {
                            nulos(i, c);
                            if (double.Parse(dgvH7.Rows[r].Cells[c].Value.ToString()) != 0 && cantidadTHP != 0)
                            {
                                cantidadHP = (double.Parse(dgvH7.Rows[r].Cells[c].Value.ToString()) * 100) / cantidadTHP;
                            }
                            else { cantidadHP = 0; }
                            dgvH7.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");
                            dgvP7A.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");
                            dgvP7B.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");

                            totalHP += cantidadHP;
                            dgvH7.Rows[row].Cells[dgvH7.ColumnCount - 1].Value = totalHP;
                            dgvP7A.Rows[row].Cells[dgvH7.ColumnCount - 1].Value = totalHP;
                            dgvP7B.Rows[row].Cells[dgvH7.ColumnCount - 1].Value = totalHP;

                        }
                        row = row + 2;
                        r++;
                    }
                    #endregion
                    break;
                case 8:
                    #region
                    for (int r = 0; r <= dgvH8.Rows.Count - 1; r++)
                    {
                        cantidadHP = 0;
                        cantidadTHP = 0;
                        totalHP = 0;
                        cantidadTHP += double.Parse(dgvH8.Rows[r].Cells[dgvH8.ColumnCount - 1].Value.ToString());
                        for (int c = 1; c <= dgvH8.Columns.Count - 2; c++)
                        {
                            nulos(i, c);
                            if (double.Parse(dgvH8.Rows[r].Cells[c].Value.ToString()) != 0 && cantidadTHP != 0)
                            {
                                cantidadHP = (double.Parse(dgvH8.Rows[r].Cells[c].Value.ToString()) * 100) / cantidadTHP;
                            }
                            else { cantidadHP = 0; }
                            dgvH8.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");
                            dgvP8A.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");
                            dgvP8B.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");

                            totalHP += cantidadHP;
                            dgvH8.Rows[row].Cells[dgvH8.ColumnCount - 1].Value = totalHP;
                            dgvP8A.Rows[row].Cells[dgvH8.ColumnCount - 1].Value = totalHP;
                            dgvP8B.Rows[row].Cells[dgvH8.ColumnCount - 1].Value = totalHP;

                        }
                        row = row + 2;
                        r++;
                    }
                    #endregion
                    break;
                case 9:
                    #region
                    for (int r = 0; r <= dgvH9.Rows.Count - 1; r++)
                    {
                        cantidadHP = 0;
                        cantidadTHP = 0;
                        totalHP = 0;
                        cantidadTHP += double.Parse(dgvH9.Rows[r].Cells[dgvH9.ColumnCount - 1].Value.ToString());
                        for (int c = 1; c <= dgvH9.Columns.Count - 2; c++)
                        {
                            nulos(i, c);
                            if (double.Parse(dgvH9.Rows[r].Cells[c].Value.ToString()) != 0 && cantidadTHP != 0)
                            {
                                cantidadHP = (double.Parse(dgvH9.Rows[r].Cells[c].Value.ToString()) * 100) / cantidadTHP;
                            }
                            else { cantidadHP = 0; }
                            dgvH9.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");
                            dgvP9A.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");
                            dgvP9B.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");

                            totalHP += cantidadHP;
                            dgvH9.Rows[row].Cells[dgvH9.ColumnCount - 1].Value = totalHP;
                            dgvP9A.Rows[row].Cells[dgvH9.ColumnCount - 1].Value = totalHP;
                            dgvP9B.Rows[row].Cells[dgvH9.ColumnCount - 1].Value = totalHP;

                        }
                        row = row + 2;
                        r++;
                    }
                    #endregion
                    break;
                case 10:
                    #region
                    for (int r = 0; r <= dgvH10.Rows.Count - 1; r++)
                    {
                        cantidadHP = 0;
                        cantidadTHP = 0;
                        totalHP = 0;
                        cantidadTHP += double.Parse(dgvH10.Rows[r].Cells[dgvH10.ColumnCount - 1].Value.ToString());
                        for (int c = 1; c <= dgvH10.Columns.Count - 2; c++)
                        {
                            nulos(i, c);
                            if (double.Parse(dgvH10.Rows[r].Cells[c].Value.ToString()) != 0 && cantidadTHP != 0)
                            {
                                cantidadHP = (double.Parse(dgvH10.Rows[r].Cells[c].Value.ToString()) * 100) / cantidadTHP;
                            }
                            else { cantidadHP = 0; }
                            dgvH10.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");
                            dgvP10A.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");
                            dgvP10B.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");

                            totalHP += cantidadHP;
                            dgvH10.Rows[row].Cells[dgvH10.ColumnCount - 1].Value = totalHP;
                            dgvP10A.Rows[row].Cells[dgvH10.ColumnCount - 1].Value = totalHP;
                            dgvP10B.Rows[row].Cells[dgvH10.ColumnCount - 1].Value = totalHP;

                        }
                        row = row + 2;
                        r++;
                    }
                    #endregion
                    break;
                case 11:
                    #region
                    for (int r = 0; r <= dgvH11.Rows.Count - 1; r++)
                    {
                        cantidadHP = 0;
                        cantidadTHP = 0;
                        totalHP = 0;
                        cantidadTHP += double.Parse(dgvH11.Rows[r].Cells[dgvH11.ColumnCount - 1].Value.ToString());
                        for (int c = 1; c <= dgvH11.Columns.Count - 2; c++)
                        {
                            nulos(i, c);
                            if (double.Parse(dgvH11.Rows[r].Cells[c].Value.ToString()) != 0 && cantidadTHP != 0)
                            {
                                cantidadHP = (double.Parse(dgvH11.Rows[r].Cells[c].Value.ToString()) * 100) / cantidadTHP;
                            }
                            else { cantidadHP = 0; }
                            dgvH11.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");
                            dgvP11A.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");
                            dgvP11B.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");

                            totalHP += cantidadHP;
                            dgvH11.Rows[row].Cells[dgvH11.ColumnCount - 1].Value = totalHP;
                            dgvP11A.Rows[row].Cells[dgvH11.ColumnCount - 1].Value = totalHP;
                            dgvP11B.Rows[row].Cells[dgvH11.ColumnCount - 1].Value = totalHP;

                        }
                        row = row + 2;
                        r++;
                    }
                    #endregion
                    break;
                case 12:
                    #region
                    for (int r = 0; r <= dgvH12.Rows.Count - 1; r++)
                    {
                        cantidadHP = 0;
                        cantidadTHP = 0;
                        totalHP = 0;
                        cantidadTHP += double.Parse(dgvH12.Rows[r].Cells[dgvH12.ColumnCount - 1].Value.ToString());
                        for (int c = 1; c <= dgvH12.Columns.Count - 2; c++)
                        {
                            nulos(i, c);

                            if (double.Parse(dgvH12.Rows[r].Cells[c].Value.ToString()) != 0 && cantidadTHP != 0)
                            {
                                cantidadHP = (double.Parse(dgvH12.Rows[r].Cells[c].Value.ToString()) * 100) / cantidadTHP;
                            }
                            else { cantidadHP = 0; }
                            dgvH12.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");
                            dgvP12A.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");
                            dgvP12B.Rows[row].Cells[c].Value = cantidadHP.ToString("N2");

                            totalHP += cantidadHP;
                            dgvH12.Rows[row].Cells[dgvH12.ColumnCount - 1].Value = totalHP;
                            dgvP12A.Rows[row].Cells[dgvH12.ColumnCount - 1].Value = totalHP;
                            dgvP12B.Rows[row].Cells[dgvH12.ColumnCount - 1].Value = totalHP;

                        }
                        row = row + 2;
                        r++;
                    }
                    #endregion
                    break;
            }
        }
        private void m_calcularProyectadoU(int i,int mes,int año)
        {
//            double cantidadPU = 0;
//            double cantidadP = 0;
//            double cantidadPUN = 0;
//            double totalPU = 0;
//            año = año + 1;
//            int x = 0;
//            int row = 0;

//            switch (i)
//            {
//                case 1:
//                    #region
//                    x = 0;
//                    row = 1;
//                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
//                    {
//                        cantidadPUN = 0;
//                        cantidadPU = 0;
//                        totalPU = 0;
//                        string q = "Select VentasUnidades as cantidad from cedula3 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
//                        cmd = new MySqlCommand(q, Conn);
//                        reader = cmd.ExecuteReader();
//                        while (reader.Read())
//                        {
//                            if (reader["cantidad"].ToString() == "")
//                            {
//                                cantidadPUN = 0;
//                            }
//                            else
//                            {
//                                cantidadPUN = double.Parse(reader["cantidad"].ToString());
//                            }
//                        }
//                        reader.Close();
//                        for (int c = 1; c <= dgvP1A.Columns.Count - 2; c++)
//                        {
//                            if (cantidadPUN >= 0)
//                            {
//                                cantidadPU = (cantidadPUN * double.Parse(dgvH1.Rows[row].Cells[c].Value.ToString())) / 100;
//                            }
//                            else { cantidadPU = 0; }
//                            dgvP1A.Rows[r].Cells[c].Value = cantidadPU.ToString("N0");
//                            totalPU += cantidadPU;
//                            dgvP1A.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("N0");
//                        }
//                        row = row + 2;
//                        r++;
//                        x++;
//                    }
//#endregion
//                    break;
//                case 2:
//                    #region
//                    x = 0;
//                    row = 1;
//                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
//                    {
//                        cantidadPUN = 0;
//                        cantidadPU = 0;
//                        totalPU = 0;
//                        string q = "Select VentasUnidades as cantidad from cedula3 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
//                        cmd = new MySqlCommand(q, Conn);
//                        reader = cmd.ExecuteReader();
//                        while (reader.Read())
//                        {
//                            if (reader["cantidad"].ToString() == "")
//                            {
//                                cantidadPUN = 0;
//                            }
//                            else
//                            {
//                                cantidadPUN = double.Parse(reader["cantidad"].ToString());
//                            }
//                        }
//                        reader.Close();
//                        for (int c = 1; c <= dgvP2.Columns.Count - 2; c++)
//                        {

//                            cantidadPU = (cantidadPUN * double.Parse(dgvH2.Rows[row].Cells[c].Value.ToString())) / 100;
//                            dgvP2.Rows[r].Cells[c].Value = cantidadPU.ToString("N0");
//                            totalPU += cantidadPU;
//                            dgvP2.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("N0");
//                        }
//                        row = row + 2;
//                        r++;
//                        x++;
//                    }
//                    #endregion
//                    break;
//                case 3:
//                    #region
//                    x = 0;
//                    row = 1;
//                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
//                    {
//                        cantidadPUN = 0;
//                        cantidadPU = 0;
//                        totalPU = 0;
//                        string q = "Select VentasUnidades as cantidad from cedula3 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
//                        cmd = new MySqlCommand(q, Conn);
//                        reader = cmd.ExecuteReader();
//                        while (reader.Read())
//                        {
//                            if (reader["cantidad"].ToString() == "")
//                            {
//                                cantidadPUN = 0;
//                            }
//                            else
//                            {
//                                cantidadPUN = double.Parse(reader["cantidad"].ToString());
//                            }
//                        }
//                        reader.Close();
//                        for (int c = 1; c <= dgvP3.Columns.Count - 2; c++)
//                        {

//                            cantidadPU = (cantidadPUN * double.Parse(dgvH3.Rows[row].Cells[c].Value.ToString())) / 100;
//                            dgvP3.Rows[r].Cells[c].Value = cantidadPU.ToString("N0");
//                            totalPU += cantidadPU;
//                            dgvP3.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("N0");
//                        }
//                        row = row + 2;
//                        r++;
//                        x++;
//                    }
//                    #endregion
//                    break;
//                case 4:
//                    #region
//                    x = 0;
//                    row = 1;
//                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
//                    {
//                        cantidadPUN = 0;
//                        cantidadPU = 0;
//                        totalPU = 0;
//                        string q = "Select VentasUnidades as cantidad from cedula3 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
//                        cmd = new MySqlCommand(q, Conn);
//                        reader = cmd.ExecuteReader();
//                        while (reader.Read())
//                        {
//                            if (reader["cantidad"].ToString() == "")
//                            {
//                                cantidadPUN = 0;
//                            }
//                            else
//                            {
//                                cantidadPUN = double.Parse(reader["cantidad"].ToString());
//                            }
//                        }
//                        reader.Close();
//                        for (int c = 1; c <= dgvP4.Columns.Count - 2; c++)
//                        {

//                            cantidadPU = (cantidadPUN * double.Parse(dgvH4.Rows[row].Cells[c].Value.ToString())) / 100;
//                            dgvP4.Rows[r].Cells[c].Value = cantidadPU.ToString("N0");
//                            totalPU += cantidadPU;
//                            dgvP4.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("N0");
//                        }
//                        row = row + 2;
//                        r++;
//                        x++;
//                    }
//                    #endregion
//                    break;
//                case 5:
//                    #region
//                    x = 0;
//                    row = 1;
//                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
//                    {
//                        cantidadPUN = 0;
//                        cantidadPU = 0;
//                        totalPU = 0;
//                        string q = "Select VentasUnidades as cantidad from cedula3 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
//                        cmd = new MySqlCommand(q, Conn);
//                        reader = cmd.ExecuteReader();
//                        while (reader.Read())
//                        {
//                            if (reader["cantidad"].ToString() == "")
//                            {
//                                cantidadPUN = 0;
//                            }
//                            else
//                            {
//                                cantidadPUN = double.Parse(reader["cantidad"].ToString());
//                            }
//                        }
//                        reader.Close();
//                        for (int c = 1; c <= dgvP5.Columns.Count - 2; c++)
//                        {

//                            cantidadPU = (cantidadPUN * double.Parse(dgvH5.Rows[row].Cells[c].Value.ToString())) / 100;
//                            dgvP5.Rows[r].Cells[c].Value = cantidadPU.ToString("N0");
//                            totalPU += cantidadPU;
//                            dgvP5.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("N0");
//                        }
//                        row = row + 2;
//                        r++;
//                        x++;
//                    }
//                    #endregion
//                    break;
//                case 6:
//                    #region
//                    x = 0;
//                    row = 1;
//                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
//                    {
//                        cantidadPUN = 0;
//                        cantidadPU = 0;
//                        totalPU = 0;
//                        string q = "Select VentasUnidades as cantidad from cedula3 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
//                        cmd = new MySqlCommand(q, Conn);
//                        reader = cmd.ExecuteReader();
//                        while (reader.Read())
//                        {
//                            if (reader["cantidad"].ToString() == "")
//                            {
//                                cantidadPUN = 0;
//                            }
//                            else
//                            {
//                                cantidadPUN = double.Parse(reader["cantidad"].ToString());
//                            }
//                        }
//                        reader.Close();
//                        for (int c = 1; c <= dgvP6.Columns.Count - 2; c++)
//                        {

//                            cantidadPU = (cantidadPUN * double.Parse(dgvH6.Rows[row].Cells[c].Value.ToString())) / 100;
//                            dgvP6.Rows[r].Cells[c].Value = cantidadPU.ToString("N0");
//                            totalPU += cantidadPU;
//                            dgvP6.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("N0");
//                        }
//                        row = row + 2;
//                        r++;
//                        x++;
//                    }
//                    #endregion
//                    break;
//                case 7:
//                    #region
//                    x = 0;
//                    row = 1;
//                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
//                    {
//                        cantidadPUN = 0;
//                        cantidadPU = 0;
//                        totalPU = 0;
//                        string q = "Select VentasUnidades as cantidad from cedula3 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
//                        cmd = new MySqlCommand(q, Conn);
//                        reader = cmd.ExecuteReader();
//                        while (reader.Read())
//                        {
//                            if (reader["cantidad"].ToString() == "")
//                            {
//                                cantidadPUN = 0;
//                            }
//                            else
//                            {
//                                cantidadPUN = double.Parse(reader["cantidad"].ToString());
//                            }
//                        }
//                        reader.Close();
//                        for (int c = 1; c <= dgvP7.Columns.Count - 2; c++)
//                        {

//                            cantidadPU = (cantidadPUN * double.Parse(dgvH7.Rows[row].Cells[c].Value.ToString())) / 100;
//                            dgvP7.Rows[r].Cells[c].Value = cantidadPU.ToString("N0");
//                            totalPU += cantidadPU;
//                            dgvP7.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("N0");
//                        }
//                        row = row + 2;
//                        r++;
//                        x++;
//                    }
//                    #endregion
//                    break;
//                case 8:
//                    #region
//                    x = 0;
//                    row = 1;
//                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
//                    {
//                        cantidadPUN = 0;
//                        cantidadPU = 0;
//                        totalPU = 0;
//                        string q = "Select VentasUnidades as cantidad from cedula3 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
//                        cmd = new MySqlCommand(q, Conn);
//                        reader = cmd.ExecuteReader();
//                        while (reader.Read())
//                        {
//                            if (reader["cantidad"].ToString() == "")
//                            {
//                                cantidadPUN = 0;
//                            }
//                            else
//                            {
//                                cantidadPUN = double.Parse(reader["cantidad"].ToString());
//                            }
//                        }
//                        reader.Close();
//                        for (int c = 1; c <= dgvP8.Columns.Count - 2; c++)
//                        {

//                            cantidadPU = (cantidadPUN * double.Parse(dgvH8.Rows[row].Cells[c].Value.ToString())) / 100;
//                            dgvP8.Rows[r].Cells[c].Value = cantidadPU.ToString("N0");
//                            totalPU += cantidadPU;
//                            dgvP8.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("N0");
//                        }
//                        row = row + 2;
//                        r++;
//                        x++;
//                    }
//                    #endregion
//                    break;
//                case 9:
//                    #region
//                    x = 0;
//                    row = 1;
//                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
//                    {
//                        cantidadPUN = 0;
//                        cantidadPU = 0;
//                        totalPU = 0;
//                        string q = "Select VentasUnidades as cantidad from cedula3 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
//                        cmd = new MySqlCommand(q, Conn);
//                        reader = cmd.ExecuteReader();
//                        while (reader.Read())
//                        {
//                            if (reader["cantidad"].ToString() == "")
//                            {
//                                cantidadPUN = 0;
//                            }
//                            else
//                            {
//                                cantidadPUN = double.Parse(reader["cantidad"].ToString());
//                            }
//                        }
//                        reader.Close();
//                        for (int c = 1; c <= dgvP9.Columns.Count - 2; c++)
//                        {

//                            cantidadPU = (cantidadPUN * double.Parse(dgvH9.Rows[row].Cells[c].Value.ToString())) / 100;
//                            dgvP9.Rows[r].Cells[c].Value = cantidadPU.ToString("N0");
//                            totalPU += cantidadPU;
//                            dgvP9.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("N0");
//                        }
//                        row = row + 2;
//                        r++;
//                        x++;
//                    }
//                    #endregion
//                    break;
//                case 10:
//                    #region
//                    x = 0;
//                    row = 1;
//                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
//                    {
//                        cantidadPUN = 0;
//                        cantidadPU = 0;
//                        totalPU = 0;
//                        string q = "Select VentasUnidades as cantidad from cedula3 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
//                        cmd = new MySqlCommand(q, Conn);
//                        reader = cmd.ExecuteReader();
//                        while (reader.Read())
//                        {
//                            if (reader["cantidad"].ToString() == "")
//                            {
//                                cantidadPUN = 0;
//                            }
//                            else
//                            {
//                                cantidadPUN = double.Parse(reader["cantidad"].ToString());
//                            }
//                        }
//                        reader.Close();
//                        for (int c = 1; c <= dgvP10.Columns.Count - 2; c++)
//                        {

//                            cantidadPU = (cantidadPUN * double.Parse(dgvH10.Rows[row].Cells[c].Value.ToString())) / 100;
//                            dgvP10.Rows[r].Cells[c].Value = cantidadPU.ToString("N0");
//                            totalPU += cantidadPU;
//                            dgvP10.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("N0");
//                        }
//                        row = row + 2;
//                        r++;
//                        x++;
//                    }
//                    #endregion
//                    break;
//                case 11:
//                    #region
//                    x = 0;
//                    row = 1;
//                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
//                    {
//                        cantidadPUN = 0;
//                        cantidadPU = 0;
//                        totalPU = 0;
//                        string q = "Select VentasUnidades as cantidad from cedula3 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
//                        cmd = new MySqlCommand(q, Conn);
//                        reader = cmd.ExecuteReader();
//                        while (reader.Read())
//                        {
//                            if (reader["cantidad"].ToString() == "")
//                            {
//                                cantidadPUN = 0;
//                            }
//                            else
//                            {
//                                cantidadPUN = double.Parse(reader["cantidad"].ToString());
//                            }
//                        }
//                        reader.Close();
//                        for (int c = 1; c <= dgvP11.Columns.Count - 2; c++)
//                        {

//                            cantidadPU = (cantidadPUN * double.Parse(dgvH11.Rows[row].Cells[c].Value.ToString())) / 100;
//                            dgvP11.Rows[r].Cells[c].Value = cantidadPU.ToString("N0");
//                            totalPU += cantidadPU;
//                            dgvP11.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("N0");
//                        }
//                        row = row + 2;
//                        r++;
//                        x++;
//                    }
//                    #endregion
//                    break;
//                case 12:
//                    #region
//                    x = 0;
//                    row = 1;
//                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
//                    {
//                        cantidadPUN = 0;
//                        cantidadPU = 0;
//                        totalPU = 0;
//                        string q = "Select VentasUnidades as cantidad from cedula3 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
//                        cmd = new MySqlCommand(q, Conn);
//                        reader = cmd.ExecuteReader();
//                        while (reader.Read())
//                        {
//                            if (reader["cantidad"].ToString() == "")
//                            {
//                                cantidadPUN = 0;
//                            }
//                            else
//                            {
//                                cantidadPUN = double.Parse(reader["cantidad"].ToString());
//                            }
//                        }
//                        reader.Close();
//                        for (int c = 1; c <= dgvP12.Columns.Count - 2; c++)
//                        {

//                            cantidadPU = (cantidadPUN * double.Parse(dgvH12.Rows[row].Cells[c].Value.ToString())) / 100;
//                            dgvP12.Rows[r].Cells[c].Value = cantidadPU.ToString("N0");
//                            totalPU += cantidadPU;
//                            dgvP12.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("N0");
//                        }
//                        row = row + 2;
//                        r++;
//                        x++;
//                    }
//                    #endregion
//                    break;
//            }
        }
        private void m_calcularProyectadoP(int i)
        {
//            double cantidadPP = 0;
//            double cantidadPU = 0;
//            double totalPP = 0;
//            int row = 1;
//            switch (i)
//            {
//                case 1:
//                    #region 
//                    row = 1;
//                    for (int rP = 0; rP <= dgvH1.Rows.Count - 1; rP++)
//                    {
//                        cantidadPP = 0;
//                        cantidadPU = 0;
//                        totalPP = 0;
//                        //for (int x = 1; x <= dgvH1.Columns.Count - 2; x++)
//                        //{
//                            cantidadPU += double.Parse(dgvP1A.Rows[rP].Cells[dgvH1.ColumnCount-1].Value.ToString());
//                        //}
//                        for (int c = 1; c <= dgvP1A.Columns.Count - 2; c++)
//                        {
//                            if (cantidadPU != 0)
//                            {
//                                cantidadPP = (double.Parse(dgvP1A.Rows[rP].Cells[c].Value.ToString()) / cantidadPU) * 100;
//                            }
//                            else
//                            {
//                                cantidadPP = 0;
//                            }
//                            totalPP += cantidadPP;
//                            dgvP1A.Rows[row].Cells[c].Value = cantidadPP.ToString("N2");
//                            dgvP1A.Rows[row].Cells[dgvH1.ColumnCount - 1].Value = totalPP.ToString("N2");
//                            //dgvP1.Rows[(r + 1)].Cells[dgvH1.ColumnCount - 1].Value = "100";
//                        }
//                        rP++;
//                        row=row+2;
//                    }
//#endregion
//                    break;
//                case 2:
//                    #region
//                    row = 1;
//                    for (int rP = 0; rP <= dgvH1.Rows.Count - 1; rP++)
//                    {
//                        cantidadPP = 0;
//                        cantidadPU = 0;
//                        totalPP = 0;
//                        //for (int x = 1; x <= dgvH1.Columns.Count - 2; x++)
//                        //{
//                        cantidadPU += double.Parse(dgvP2.Rows[rP].Cells[dgvH1.ColumnCount - 1].Value.ToString());
//                        //}
//                        for (int c = 1; c <= dgvP2.Columns.Count - 2; c++)
//                        {
//                            if (cantidadPU != 0)
//                            {
//                                cantidadPP = (double.Parse(dgvP2.Rows[rP].Cells[c].Value.ToString()) / cantidadPU) * 100;
//                            }
//                            else
//                            {
//                                cantidadPP = 0;
//                            }
//                            //cantidadPP = (double.Parse(dgvP2.Rows[rP].Cells[c].Value.ToString()) / cantidadPU) * 100;
//                            totalPP += cantidadPP;
//                            dgvP2.Rows[row].Cells[c].Value = cantidadPP.ToString("N2");
//                            dgvP2.Rows[row].Cells[dgvH1.ColumnCount - 1].Value = totalPP.ToString("N2");
//                            //dgvP2.Rows[(r + 1)].Cells[dgvH1.ColumnCount - 1].Value = "100";
//                        }
//                        rP++;
//                        row = row + 2;
//                    }
//                    #endregion
//                    break;
//                case 3:
//                    #region
//                    row = 1;
//                    for (int rP = 0; rP <= dgvH1.Rows.Count - 1; rP++)
//                    {
//                        cantidadPP = 0;
//                        cantidadPU = 0;
//                        totalPP = 0;
//                        //for (int x = 1; x <= dgvH1.Columns.Count - 2; x++)
//                        //{
//                        cantidadPU += double.Parse(dgvP3.Rows[rP].Cells[dgvH1.ColumnCount - 1].Value.ToString());
//                        //}
//                        for (int c = 1; c <= dgvP3.Columns.Count - 2; c++)
//                        {
//                            if (cantidadPU != 0)
//                            {
//                                cantidadPP = (double.Parse(dgvP3.Rows[rP].Cells[c].Value.ToString()) / cantidadPU) * 100;
//                            }
//                            else
//                            {
//                                cantidadPP = 0;
//                            }
//                            //cantidadPP = (double.Parse(dgvP3.Rows[rP].Cells[c].Value.ToString()) / cantidadPU) * 100;
//                            totalPP += cantidadPP;
//                            dgvP3.Rows[row].Cells[c].Value = cantidadPP.ToString("N2");
//                            dgvP3.Rows[row].Cells[dgvH1.ColumnCount - 1].Value = totalPP.ToString("N2");
//                            //dgvP3.Rows[(r + 1)].Cells[dgvH1.ColumnCount - 1].Value = "100";
//                        }
//                        rP++;
//                        row = row + 2;
//                    }
//                    #endregion
//                    break;
//                case 4:
//                    #region
//                    row = 1;
//                    for (int rP = 0; rP <= dgvH1.Rows.Count - 1; rP++)
//                    {
//                        cantidadPP = 0;
//                        cantidadPU = 0;
//                        totalPP = 0;
//                        //for (int x = 1; x <= dgvH1.Columns.Count - 2; x++)
//                        //{
//                        cantidadPU += double.Parse(dgvP4.Rows[rP].Cells[dgvH1.ColumnCount - 1].Value.ToString());
//                        //}
//                        for (int c = 1; c <= dgvP4.Columns.Count - 2; c++)
//                        {
//                            if (cantidadPU != 0)
//                            {
//                                cantidadPP = (double.Parse(dgvP4.Rows[rP].Cells[c].Value.ToString()) / cantidadPU) * 100;
//                            }
//                            else
//                            {
//                                cantidadPP = 0;
//                            }
//                            //cantidadPP = (double.Parse(dgvP4.Rows[rP].Cells[c].Value.ToString()) / cantidadPU) * 100;
//                            totalPP += cantidadPP;
//                            dgvP4.Rows[row].Cells[c].Value = cantidadPP.ToString("N2");
//                            dgvP4.Rows[row].Cells[dgvH1.ColumnCount - 1].Value = totalPP.ToString("N2");
//                            //dgvP4.Rows[(r + 1)].Cells[dgvH1.ColumnCount - 1].Value = "100";
//                        }
//                        rP++;
//                        row = row + 2;
//                    }
//                    #endregion
//                    break;
//                case 5:
//                    #region
//                    row = 1;
//                    for (int rP = 0; rP <= dgvH1.Rows.Count - 1; rP++)
//                    {
//                        cantidadPP = 0;
//                        cantidadPU = 0;
//                        totalPP = 0;
//                        //for (int x = 1; x <= dgvH1.Columns.Count - 2; x++)
//                        //{
//                        cantidadPU += double.Parse(dgvP5.Rows[rP].Cells[dgvH1.ColumnCount - 1].Value.ToString());
//                        //}
//                        for (int c = 1; c <= dgvP5.Columns.Count - 2; c++)
//                        {
//                            if (cantidadPU != 0)
//                            {
//                                cantidadPP = (double.Parse(dgvP5.Rows[rP].Cells[c].Value.ToString()) / cantidadPU) * 100;
//                            }
//                            else
//                            {
//                                cantidadPP = 0;
//                            }
//                            //cantidadPP = (double.Parse(dgvP5.Rows[rP].Cells[c].Value.ToString()) / cantidadPU) * 100;
//                            totalPP += cantidadPP;
//                            dgvP5.Rows[row].Cells[c].Value = cantidadPP.ToString("N2");
//                            dgvP5.Rows[row].Cells[dgvH1.ColumnCount - 1].Value = totalPP.ToString("N2");
//                            //dgvP5.Rows[(r + 1)].Cells[dgvH1.ColumnCount - 1].Value = "100";
//                        }
//                        rP++;
//                        row = row + 2;
//                    }
//                    #endregion
//                    break;
//                case 6:
//                    #region
//                    row = 1;
//                    for (int rP = 0; rP <= dgvH1.Rows.Count - 1; rP++)
//                    {
//                        cantidadPP = 0;
//                        cantidadPU = 0;
//                        totalPP = 0;
//                        //for (int x = 1; x <= dgvH1.Columns.Count - 2; x++)
//                        //{
//                        cantidadPU += double.Parse(dgvP6.Rows[rP].Cells[dgvH1.ColumnCount - 1].Value.ToString());
//                        //}
//                        for (int c = 1; c <= dgvP6.Columns.Count - 2; c++)
//                        {
//                            if (cantidadPU != 0)
//                            {
//                                cantidadPP = (double.Parse(dgvP6.Rows[rP].Cells[c].Value.ToString()) / cantidadPU) * 100;
//                            }
//                            else
//                            {
//                                cantidadPP = 0;
//                            }
//                           // cantidadPP = (double.Parse(dgvP6.Rows[rP].Cells[c].Value.ToString()) / cantidadPU) * 100;
//                            totalPP += cantidadPP;
//                            dgvP6.Rows[row].Cells[c].Value = cantidadPP.ToString("N2");
//                            dgvP6.Rows[row].Cells[dgvH1.ColumnCount - 1].Value = totalPP.ToString("N2");
//                            //dgvP6.Rows[(r + 1)].Cells[dgvH1.ColumnCount - 1].Value = "100";
//                        }
//                        rP++;
//                        row = row + 2;
//                    }
//                    #endregion
//                    break;
//                case 7:
//                    #region
//                    row = 1;
//                    for (int rP = 0; rP <= dgvH1.Rows.Count - 1; rP++)
//                    {
//                        cantidadPP = 0;
//                        cantidadPU = 0;
//                        totalPP = 0;
//                        //for (int x = 1; x <= dgvH1.Columns.Count - 2; x++)
//                        //{
//                        cantidadPU += double.Parse(dgvP7.Rows[rP].Cells[dgvH1.ColumnCount - 1].Value.ToString());
//                        //}
//                        for (int c = 1; c <= dgvP7.Columns.Count - 2; c++)
//                        {
//                            if (cantidadPU != 0)
//                            {
//                                cantidadPP = (double.Parse(dgvP7.Rows[rP].Cells[c].Value.ToString()) / cantidadPU) * 100;
//                            }
//                            else
//                            {
//                                cantidadPP = 0;
//                            }
//                            //cantidadPP = (double.Parse(dgvP7.Rows[rP].Cells[c].Value.ToString()) / cantidadPU) * 100;
//                            totalPP += cantidadPP;
//                            dgvP7.Rows[row].Cells[c].Value = cantidadPP.ToString("N2");
//                            dgvP7.Rows[row].Cells[dgvH1.ColumnCount - 1].Value = totalPP.ToString("N2");
//                            //dgvP7.Rows[(r + 1)].Cells[dgvH1.ColumnCount - 1].Value = "100";
//                        }
//                        rP++;
//                        row = row + 2;
//                    }
//                    #endregion
//                    break;
//                case 8:
//                    #region
//                    row = 1;
//                    for (int rP = 0; rP <= dgvH1.Rows.Count - 1; rP++)
//                    {
//                        cantidadPP = 0;
//                        cantidadPU = 0;
//                        totalPP = 0;
//                        //for (int x = 1; x <= dgvH1.Columns.Count - 2; x++)
//                        //{
//                        cantidadPU += double.Parse(dgvP8.Rows[rP].Cells[dgvH1.ColumnCount - 1].Value.ToString());
//                        //}
//                        for (int c = 1; c <= dgvP8.Columns.Count - 2; c++)
//                        {
//                            if (cantidadPU != 0)
//                            {
//                                cantidadPP = (double.Parse(dgvP8.Rows[rP].Cells[c].Value.ToString()) / cantidadPU) * 100;
//                            }
//                            else
//                            {
//                                cantidadPP = 0;
//                            }
//                            //cantidadPP = (double.Parse(dgvP8.Rows[rP].Cells[c].Value.ToString()) / cantidadPU) * 100;
//                            totalPP += cantidadPP;
//                            dgvP8.Rows[row].Cells[c].Value = cantidadPP.ToString("N2");
//                            dgvP8.Rows[row].Cells[dgvH1.ColumnCount - 1].Value = totalPP.ToString("N2");
//                            //dgvP8.Rows[(r + 1)].Cells[dgvH1.ColumnCount - 1].Value = "100";
//                        }
//                        rP++;
//                        row = row + 2;
//                    }
//                    #endregion
//                    break;
//                case 9:
//                    #region
//                    row = 1;
//                    for (int rP = 0; rP <= dgvH1.Rows.Count - 1; rP++)
//                    {
//                        cantidadPP = 0;
//                        cantidadPU = 0;
//                        totalPP = 0;
//                        //for (int x = 1; x <= dgvH1.Columns.Count - 2; x++)
//                        //{
//                        cantidadPU += double.Parse(dgvP9.Rows[rP].Cells[dgvH1.ColumnCount - 1].Value.ToString());
//                        //}
//                        for (int c = 1; c <= dgvP9.Columns.Count - 2; c++)
//                        {
//                            if (cantidadPU != 0)
//                            {
//                                cantidadPP = (double.Parse(dgvP9.Rows[rP].Cells[c].Value.ToString()) / cantidadPU) * 100;
//                            }
//                            else
//                            {
//                                cantidadPP = 0;
//                            }
//                            //cantidadPP = (double.Parse(dgvP9.Rows[rP].Cells[c].Value.ToString()) / cantidadPU) * 100;
//                            totalPP += cantidadPP;
//                            dgvP9.Rows[row].Cells[c].Value = cantidadPP.ToString("N2");
//                            dgvP9.Rows[row].Cells[dgvH1.ColumnCount - 1].Value = totalPP.ToString("N2");
//                            //dgvP9.Rows[(r + 1)].Cells[dgvH1.ColumnCount - 1].Value = "100";
//                        }
//                        rP++;
//                        row = row + 2;
//                    }
//                    #endregion
//                    break;
//                case 10:
//                    #region
//                    row = 1;
//                    for (int rP = 0; rP <= dgvH1.Rows.Count - 1; rP++)
//                    {
//                        cantidadPP = 0;
//                        cantidadPU = 0;
//                        totalPP = 0;
//                        //for (int x = 1; x <= dgvH1.Columns.Count - 2; x++)
//                        //{
//                        cantidadPU += double.Parse(dgvP10.Rows[rP].Cells[dgvH1.ColumnCount - 1].Value.ToString());
//                        //}
//                        for (int c = 1; c <= dgvP10.Columns.Count - 2; c++)
//                        {
//                            if (cantidadPU != 0)
//                            {
//                                cantidadPP = (double.Parse(dgvP10.Rows[rP].Cells[c].Value.ToString()) / cantidadPU) * 100;
//                            }
//                            else
//                            {
//                                cantidadPP = 0;
//                            }
//                            //cantidadPP = (double.Parse(dgvP10.Rows[rP].Cells[c].Value.ToString()) / cantidadPU) * 100;
//                            totalPP += cantidadPP;
//                            dgvP10.Rows[row].Cells[c].Value = cantidadPP.ToString("N2");
//                            dgvP10.Rows[row].Cells[dgvH1.ColumnCount - 1].Value = totalPP.ToString("N2");
//                            //dgvP10.Rows[(r + 1)].Cells[dgvH1.ColumnCount - 1].Value = "100";
//                        }
//                        rP++;
//                        row = row + 2;
//                    }
//                    #endregion
//                    break;
//                case 11:
//                    #region
//                    row = 1;
//                    for (int rP = 0; rP <= dgvH1.Rows.Count - 1; rP++)
//                    {
//                        cantidadPP = 0;
//                        cantidadPU = 0;
//                        totalPP = 0;
//                        //for (int x = 1; x <= dgvH1.Columns.Count - 2; x++)
//                        //{
//                        cantidadPU += double.Parse(dgvP11.Rows[rP].Cells[dgvH1.ColumnCount - 1].Value.ToString());
//                        //}
//                        for (int c = 1; c <= dgvP11.Columns.Count - 2; c++)
//                        {
//                            if (cantidadPU != 0)
//                            {
//                                cantidadPP = (double.Parse(dgvP11.Rows[rP].Cells[c].Value.ToString()) / cantidadPU) * 100;
//                            }
//                            else
//                            {
//                                cantidadPP = 0;
//                            }
//                           // cantidadPP = (double.Parse(dgvP11.Rows[rP].Cells[c].Value.ToString()) / cantidadPU) * 100;
//                            totalPP += cantidadPP;
//                            dgvP11.Rows[row].Cells[c].Value = cantidadPP.ToString("N2");
//                            dgvP11.Rows[row].Cells[dgvH1.ColumnCount - 1].Value = totalPP.ToString("N2");
//                            //dgvP11.Rows[(r + 1)].Cells[dgvH1.ColumnCount - 1].Value = "100";
//                        }
//                        rP++;
//                        row = row + 2;
//                    }
//                    #endregion
//                    break;
//                case 12:
//                    #region
//                    row = 1;
//                    for (int rP = 0; rP <= dgvH1.Rows.Count - 1; rP++)
//                    {
//                        cantidadPP = 0;
//                        cantidadPU = 0;
//                        totalPP = 0;
//                        //for (int x = 1; x <= dgvH1.Columns.Count - 2; x++)
//                        //{
//                        cantidadPU += double.Parse(dgvP12.Rows[rP].Cells[dgvH1.ColumnCount - 1].Value.ToString());
//                        //}
//                        for (int c = 1; c <= dgvP12.Columns.Count - 2; c++)
//                        {
//                            if (cantidadPU != 0)
//                            {
//                                cantidadPP = (double.Parse(dgvP12.Rows[rP].Cells[c].Value.ToString()) / cantidadPU) * 100;
//                            }
//                            else
//                            {
//                                cantidadPP = 0;
//                            }
//                            //cantidadPP = (double.Parse(dgvP12.Rows[rP].Cells[c].Value.ToString()) / cantidadPU) * 100;
//                            totalPP += cantidadPP;
//                            dgvP12.Rows[row].Cells[c].Value = cantidadPP.ToString("N2");
//                            dgvP12.Rows[row].Cells[dgvH1.ColumnCount - 1].Value = totalPP.ToString("N2");
//                            //dgvP12.Rows[(r + 1)].Cells[dgvH1.ColumnCount - 1].Value = "100";
//                        }
//                        rP++;
//                        row = row + 2;
//                    }
//                    #endregion
//                    break;
//            }
        }
        private void m_verificarPorcentajeE(int i)
        {
            double cantidad = 0;
            double cantidadU = 0;
            double cantidadP = 0;
            double cantidadtU = 0;
            double cantidadtP = 0;
            double TotalColumnaU = 0;
            double TotalColumnaP = 0;
            int TotalIndexU=0;
            int TotalIndexP=1;
            switch(i)
            {
                case 1:
                    #region dgv1
                    for (int renglonVerificar = 1; renglonVerificar <= dgvP1A.Rows.Count - 1; renglonVerificar++)
                    {
                         cantidad = 0;
                         cantidadU = 0;
                         cantidadP = 0;
                         cantidadtU = 0;
                         cantidadtP = 0;
                         TotalColumnaU = 0;
                         TotalColumnaP = 0;
                        for(int columnaTotales=1;columnaTotales<=dgvP1A.ColumnCount-2;columnaTotales++)
                        {
                            TotalColumnaU += double.Parse(dgvP1A.Rows[TotalIndexU].Cells[columnaTotales].Value.ToString());
                            TotalColumnaP += double.Parse(dgvP1A.Rows[TotalIndexP].Cells[columnaTotales].Value.ToString());
                            dgvP1A.Rows[TotalIndexU].Cells[dgvP1A.ColumnCount-1].Value=TotalColumnaU.ToString("N0");
                            dgvP1A.Rows[TotalIndexP].Cells[dgvP1A.ColumnCount-1].Value = TotalColumnaP.ToString("N0");
                        }
                        for(int Reajustar=1;Reajustar<=dgvH1.ColumnCount-2;Reajustar++)
                        {
                            if(TotalColumnaP>=0&&(double.Parse(dgvP1A.Rows[TotalIndexU].Cells[Reajustar].Value.ToString())>=0))
                            {
                            cantidadU = ((double.Parse(dgvP1A.Rows[TotalIndexU].Cells[Reajustar].Value.ToString())) * TotalColumnaP) /100;
                            }
                            else{cantidadU=0;}
                            if(cantidadU>=0&&TotalColumnaU>=0)
                            {
                            cantidadP=(cantidadU/TotalColumnaU)*100;
                            }
                            else{cantidadP=0;}
                            dgvP1A.Rows[TotalIndexU].Cells[Reajustar].Value=cantidadU.ToString("N0");
                            dgvP1A.Rows[TotalIndexP].Cells[Reajustar].Value=cantidadP.ToString("N2");
                        }
                        renglonVerificar++;
                        TotalIndexU = TotalIndexU + 2;
                        TotalIndexP = TotalIndexP + 2;
                    }
                    #endregion
                        break;
            }
        }
        private bool comprobarCargar(int año, int mes, int i)
        {
            bool comprobar = true;
            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and anio=" + año + " and mes=" + mes + " " + querycargar[0];
            cmd = new MySqlCommand(q, Conn);
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

            double c1, c2;
            int un = 0;
            int por = 1;
            int indQ = 0;
            switch (g)
            {
                case 1:
                    #region cargar gridH
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='H'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());
                                //if(reader["unidad"].ToString()=="")
                                //{
                                //    c1 = 0;
                                //}
                                //if(reader["porcentaje"].ToString()=="")
                                //{
                                //    c2 = 0;
                                //}
                                dgvH1.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvH1.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        indQ++;
                        un = un + 2;
                        por = por + 2;
                        x++;
                    }
                    #endregion
                    #region cargar grid A
                    un = 0;
                    por = 1;
                    indQ = 0;
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='A'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());

                                dgvP1A.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvP1A.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        un = un + 2;
                        por = por + 2;
                        indQ++;
                        x++;
                    }
                    #endregion
                    #region cargar grid B
                    un = 0;
                    por = 1;
                    indQ = 0;
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='B'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());

                                dgvP1B.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvP1B.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        un = un + 2;
                        por = por + 2;
                        indQ++;
                        x++;
                    }
                    #endregion
                    break;
                case 2:
                    #region cargar gridH
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='H'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());
                                dgvH2.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvH2.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        if (indQ <= ((dgvH1.Rows.Count / 2) - 1))
                        {
                            indQ++;
                        }
                        un = un + 2;
                        por = por + 2;
                        x++;
                    }
                    #endregion
                    #region cargar grid A
                    un = 0;
                    por = 1;
                    indQ = 0;
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='A'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());

                                dgvP2A.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvP2A.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        un = un + 2;
                        por = por + 2;
                        indQ++;
                        x++;
                    }
                    #endregion
                    #region cargar grid B
                    un = 0;
                    por = 1;
                    indQ = 0;
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='B'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());

                                dgvP2B.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvP2B.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        un = un + 2;
                        por = por + 2;
                        indQ++;
                        x++;
                    }
                    #endregion
                    break;
                case 3:
                    #region cargar gridH
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='H'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());
                                dgvH3.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvH3.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        if (indQ <= ((dgvH1.Rows.Count / 2) - 1))
                        {
                            indQ++;
                        }
                        un = un + 2;
                        por = por + 2;
                        x++;
                    }
                    #endregion
                    #region cargar grid A
                    un = 0;
                    por = 1;
                    indQ = 0;
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='A'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());

                                dgvP3A.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvP3A.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        un = un + 2;
                        por = por + 2;
                        indQ++;
                        x++;
                    }
                    #endregion
                    #region cargar grid B
                    un = 0;
                    por = 1;
                    indQ = 0;
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='B'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());

                                dgvP3B.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvP3B.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        un = un + 2;
                        por = por + 2;
                        indQ++;
                        x++;
                    }
                    #endregion
                    break;
                case 4:
                    #region cargar gridH
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='H'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());
                                dgvH4.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvH4.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        if (indQ <= ((dgvH1.Rows.Count / 2) - 1))
                        {
                            indQ++;
                        }
                        un = un + 2;
                        por = por + 2;
                        x++;
                    }
                    #endregion
                    #region cargar grid A
                    un = 0;
                    por = 1;
                    indQ = 0;
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='A'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());

                                dgvP4A.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvP4A.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        un = un + 2;
                        por = por + 2;
                        indQ++;
                        x++;
                    }
                    #endregion
                    #region cargar grid B
                    un = 0;
                    por = 1;
                    indQ = 0;
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='B'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());

                                dgvP4B.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvP4B.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        un = un + 2;
                        por = por + 2;
                        indQ++;
                        x++;
                    }
                    #endregion
                    break;
                case 5:
                    #region cargar gridH
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='H'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());
                                dgvH5.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvH5.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        if (indQ <= ((dgvH1.Rows.Count / 2) - 1))
                        {
                            indQ++;
                        }
                        un = un + 2;
                        por = por + 2;
                        x++;
                    }
                    #endregion
                    #region cargar grid A
                    un = 0;
                    por = 1;
                    indQ = 0;
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='A'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());

                                dgvP5A.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvP5A.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        un = un + 2;
                        por = por + 2;
                        indQ++;
                        x++;
                    }
                    #endregion
                    #region cargar grid B
                    un = 0;
                    por = 1;
                    indQ = 0;
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='B'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());

                                dgvP5B.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvP5B.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        un = un + 2;
                        por = por + 2;
                        indQ++;
                        x++;
                    }
                    #endregion
                    break;
                case 6:
                    #region cargar gridH
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='H'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());
                                dgvH6.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvH6.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        if (indQ <= ((dgvH1.Rows.Count / 2) - 1))
                        {
                            indQ++;
                        }
                        un = un + 2;
                        por = por + 2;
                        x++;
                    }
                    #endregion
                    #region cargar grid A
                    un = 0;
                    por = 1;
                    indQ = 0;
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='A'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());

                                dgvP6A.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvP6A.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        un = un + 2;
                        por = por + 2;
                        indQ++;
                        x++;
                    }
                    #endregion
                    #region cargar grid B
                    un = 0;
                    por = 1;
                    indQ = 0;
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='B'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());

                                dgvP6B.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvP6B.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        un = un + 2;
                        por = por + 2;
                        indQ++;
                        x++;
                    }
                    #endregion
                    break;
                case 7:
                    #region cargar gridH
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='H'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());
                                dgvH7.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvH7.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        if (indQ <= ((dgvH1.Rows.Count / 2) - 1))
                        {
                            indQ++;
                        }
                        un = un + 2;
                        por = por + 2;
                        x++;
                    }
                    #endregion
                    #region cargar grid A
                    un = 0;
                    por = 1;
                    indQ = 0;
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='A'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());

                                dgvP7A.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvP7A.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        un = un + 2;
                        por = por + 2;
                        indQ++;
                        x++;
                    }
                    #endregion
                    #region cargar grid B
                    un = 0;
                    por = 1;
                    indQ = 0;
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='B'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());

                                dgvP7B.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvP7B.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        un = un + 2;
                        por = por + 2;
                        indQ++;
                        x++;
                    }
                    #endregion
                    break;
                case 8:
                    #region cargar gridH
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='H'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());
                                dgvH8.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvH8.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        if (indQ <= ((dgvH1.Rows.Count / 2) - 1))
                        {
                            indQ++;
                        }
                        un = un + 2;
                        por = por + 2;
                        x++;
                    }
                    #endregion
                    #region cargar grid A
                    un = 0;
                    por = 1;
                    indQ = 0;
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='A'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());

                                dgvP8A.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvP8A.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        un = un + 2;
                        por = por + 2;
                        indQ++;
                        x++;
                    }
                    #endregion
                    #region cargar grid B
                    un = 0;
                    por = 1;
                    indQ = 0;
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='B'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());

                                dgvP8B.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvP8B.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        un = un + 2;
                        por = por + 2;
                        indQ++;
                        x++;
                    }
                    #endregion
                    break;
                case 9:
                    #region cargar gridH
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='H'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());
                                dgvH9.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvH9.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        if (indQ <= ((dgvH1.Rows.Count / 2) - 1))
                        {
                            indQ++;
                        }
                        un = un + 2;
                        por = por + 2;
                        x++;
                    }
                    #endregion
                    #region cargar grid A
                    un = 0;
                    por = 1;
                    indQ = 0;
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='A'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());

                                dgvP9A.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvP9A.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        un = un + 2;
                        por = por + 2;
                        indQ++;
                        x++;
                    }
                    #endregion
                    #region cargar grid B
                    un = 0;
                    por = 1;
                    indQ = 0;
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='B'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());

                                dgvP9B.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvP9B.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        un = un + 2;
                        por = por + 2;
                        indQ++;
                        x++;
                    }
                    #endregion
                    break;
                case 10:
                    #region cargar gridH
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='H'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());
                                dgvH10.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvH10.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        if (indQ <= ((dgvH1.Rows.Count / 2) - 1))
                        {
                            indQ++;
                        }
                        un = un + 2;
                        por = por + 2;
                        x++;
                    }
                    #endregion
                    #region cargar grid A
                    un = 0;
                    por = 1;
                    indQ = 0;
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='A'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());

                                dgvP10A.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvP10A.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        un = un + 2;
                        por = por + 2;
                        indQ++;
                        x++;
                    }
                    #endregion
                    #region cargar grid B
                    un = 0;
                    por = 1;
                    indQ = 0;
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='B'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());

                                dgvP10B.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvP10B.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        un = un + 2;
                        por = por + 2;
                        indQ++;
                        x++;
                    }
                    #endregion
                    break;
                case 11:
                    #region cargar gridH
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='H'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());
                                dgvH11.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvH11.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        if (indQ <= ((dgvH1.Rows.Count / 2) - 1))
                        {
                            indQ++;
                        }
                        un = un + 2;
                        por = por + 2;
                        x++;
                    }
                    #endregion
                    #region cargar grid A
                    un = 0;
                    por = 1;
                    indQ = 0;
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='A'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());

                                dgvP11A.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvP11A.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        un = un + 2;
                        por = por + 2;
                        indQ++;
                        x++;
                    }
                    #endregion
                    #region cargar grid B
                    un = 0;
                    por = 1;
                    indQ = 0;
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='B'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());

                                dgvP11B.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvP11B.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        un = un + 2;
                        por = por + 2;
                        indQ++;
                        x++;
                    }
                    #endregion
                    break;
                case 12:
                    #region cargar gridH
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='H'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());
                                dgvH12.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvH12.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        if (indQ <= ((dgvH1.Rows.Count / 2) - 1))
                        {
                            indQ++;
                        }
                        un = un + 2;
                        por = por + 2;
                        x++;
                    }
                    #endregion
                    #region cargar grid A
                    un = 0;
                    por = 1;
                    indQ = 0;
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='A'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());

                                dgvP12A.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvP12A.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        un = un + 2;
                        por = por + 2;
                        indQ++;
                        x++;
                    }
                    #endregion
                    #region cargar grid B
                    un = 0;
                    por = 1;
                    indQ = 0;
                    for (int x = 0; x <= dgvH1.Rows.Count - 1; x++)
                    {
                        for (int column = 1; column <= dgvH1.ColumnCount - 2; column++)
                        {
                            string q = "SELECT * FROM cedula9 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " and medida='" + dgvH1.Columns[column].HeaderText.ToString() + "' and tipo_dgv='B'" + querycargar[indQ];
                            cmd = new MySqlCommand(q, Conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                c1 = double.Parse(reader["unidad"].ToString());
                                c2 = double.Parse(reader["porcentaje"].ToString());

                                dgvP12B.Rows[un].Cells[column].Value = c1.ToString("n0");
                                dgvP12B.Rows[por].Cells[column].Value = c2.ToString("N2");
                            }
                            reader.Close();
                        }
                        un = un + 2;
                        por = por + 2;
                        indQ++;
                        x++;
                    }
                    #endregion
                    break;
            }
            if (proyectar == false)
            {
                calcularTotales(g);
            }
        }
        private void m_propiedades_grid()
        {
            #region congelar columna descripcion
            dgvH1.Columns[0].Frozen = true;
            dgvH2.Columns[0].Frozen = true;
            dgvH3.Columns[0].Frozen = true;
            dgvH4.Columns[0].Frozen = true;
            dgvH5.Columns[0].Frozen = true;
            dgvH6.Columns[0].Frozen = true;
            dgvH7.Columns[0].Frozen = true;
            dgvH8.Columns[0].Frozen = true;
            dgvH9.Columns[0].Frozen = true;
            dgvH10.Columns[0].Frozen = true;
            dgvH11.Columns[0].Frozen = true;
            dgvH12.Columns[0].Frozen = true;
            ///////////////////////////////
            dgvP1A.Columns[0].Frozen = true;
            dgvP2A.Columns[0].Frozen = true;
            dgvP3A.Columns[0].Frozen = true;
            dgvP4A.Columns[0].Frozen = true;
            dgvP5A.Columns[0].Frozen = true;
            dgvP6A.Columns[0].Frozen = true;
            dgvP7A.Columns[0].Frozen = true;
            dgvP8A.Columns[0].Frozen = true;
            dgvP9A.Columns[0].Frozen = true;
            dgvP10A.Columns[0].Frozen = true;
            dgvP11A.Columns[0].Frozen = true;
            dgvP12A.Columns[0].Frozen = true;
            /////////////////////////////////
            dgvP1B.Columns[0].Frozen = true;
            dgvP2B.Columns[0].Frozen = true;
            dgvP3B.Columns[0].Frozen = true;
            dgvP4B.Columns[0].Frozen = true;
            dgvP5B.Columns[0].Frozen = true;
            dgvP6B.Columns[0].Frozen = true;
            dgvP7B.Columns[0].Frozen = true;
            dgvP8B.Columns[0].Frozen = true;
            dgvP9B.Columns[0].Frozen = true;
            dgvP10B.Columns[0].Frozen = true;
            dgvP11B.Columns[0].Frozen = true;
            dgvP12B.Columns[0].Frozen = true;
            #endregion
            dgvH1.AllowUserToOrderColumns = false;
            dgvH2.AllowUserToOrderColumns = false;
            dgvH3.AllowUserToOrderColumns = false;
            dgvH4.AllowUserToOrderColumns = false;
            dgvH5.AllowUserToOrderColumns = false;
            dgvH6.AllowUserToOrderColumns = false;
            dgvH7.AllowUserToOrderColumns = false;
            dgvH8.AllowUserToOrderColumns = false;
            dgvH9.AllowUserToOrderColumns = false;
            dgvH10.AllowUserToOrderColumns = false;
            dgvH11.AllowUserToOrderColumns = false;
            dgvH12.AllowUserToOrderColumns = false;

        }
        private void calcularTotales(int i)
        {
            int uni = 0;
            int poi = 1;
            double unidaH = 0;
            double porceH = 0;
            double unidaPA = 0;
            double porcePA = 0;
            double unidaPB = 0;
            double porcePB = 0;
            switch (i)
            {
                case 1:
                    #region mes 1
                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                    {
                        unidaH = 0;
                        porceH = 0;
                        unidaPA = 0;
                        porcePA = 0;
                        unidaPB = 0;
                        porcePB = 0;
                        for (int c = 1; c <= dgvH1.ColumnCount - 2; c++)
                        {
                            nulos(i, c);
                            unidaH += double.Parse(dgvH1.Rows[uni].Cells[c].Value.ToString());
                            porceH += double.Parse(dgvH1.Rows[poi].Cells[c].Value.ToString());
                            unidaPA += double.Parse(dgvP1A.Rows[uni].Cells[c].Value.ToString());
                            porcePA += double.Parse(dgvP1A.Rows[poi].Cells[c].Value.ToString());
                            unidaPB += double.Parse(dgvP1B.Rows[uni].Cells[c].Value.ToString());
                            porcePB += double.Parse(dgvP1B.Rows[poi].Cells[c].Value.ToString());
                        }
                        dgvH1.Rows[uni].Cells[dgvH1.ColumnCount - 1].Value = unidaH.ToString("N0");
                        dgvH1.Rows[poi].Cells[dgvH1.ColumnCount - 1].Value = porceH.ToString("N0");
                        dgvP1A.Rows[uni].Cells[dgvP1A.ColumnCount - 1].Value = unidaPA.ToString("N0");
                        dgvP1A.Rows[poi].Cells[dgvP1A.ColumnCount - 1].Value = porcePA.ToString("N0");
                        dgvP1B.Rows[uni].Cells[dgvP1B.ColumnCount - 1].Value = unidaPB.ToString("N0");
                        dgvP1B.Rows[poi].Cells[dgvP1B.ColumnCount - 1].Value = porcePB.ToString("N0");

                        uni = uni + 2;
                        poi = poi + 2;
                        r++;
                        /////////////

                    }
#endregion
                    break;
                case 2:
                    #region mes2
                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                    {
                        unidaH = 0;
                        porceH = 0;
                        unidaPA = 0;
                        porcePA = 0;
                        unidaPB = 0;
                        porcePB = 0;
                        for (int c = 1; c <= dgvH1.ColumnCount - 2; c++)
                        {
                            nulos(i, c);
                            unidaH += double.Parse(dgvH2.Rows[uni].Cells[c].Value.ToString());
                            porceH += double.Parse(dgvH2.Rows[poi].Cells[c].Value.ToString());
                            unidaPA += double.Parse(dgvP2A.Rows[uni].Cells[c].Value.ToString());
                            porcePA += double.Parse(dgvP2A.Rows[poi].Cells[c].Value.ToString());
                            unidaPB += double.Parse(dgvP2B.Rows[uni].Cells[c].Value.ToString());
                            porcePB += double.Parse(dgvP2B.Rows[poi].Cells[c].Value.ToString());
                        }
                        dgvH2.Rows[uni].Cells[dgvH1.ColumnCount - 1].Value = unidaH.ToString("N0");
                        dgvH2.Rows[poi].Cells[dgvH1.ColumnCount - 1].Value = porceH.ToString("N0");
                        dgvP2A.Rows[uni].Cells[dgvP1A.ColumnCount - 1].Value = unidaPA.ToString("N0");
                        dgvP2A.Rows[poi].Cells[dgvP1A.ColumnCount - 1].Value = porcePA.ToString("N0");
                        dgvP2B.Rows[uni].Cells[dgvP1B.ColumnCount - 1].Value = unidaPB.ToString("N0");
                        dgvP2B.Rows[poi].Cells[dgvP1B.ColumnCount - 1].Value = porcePB.ToString("N0");

                        uni = uni + 2;
                        poi = poi + 2;
                        r++;
                        /////////////

                    }
#endregion
                    break;
                case 3:
                    #region mes 3
                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                    {
                        unidaH = 0;
                        porceH = 0;
                        unidaPA = 0;
                        porcePA = 0;
                        unidaPB = 0;
                        porcePB = 0;
                        for (int c = 1; c <= dgvH1.ColumnCount - 2; c++)
                        {
                            nulos(i, c);
                            unidaH += double.Parse(dgvH3.Rows[uni].Cells[c].Value.ToString());
                            porceH += double.Parse(dgvH3.Rows[poi].Cells[c].Value.ToString());
                            unidaPA += double.Parse(dgvP3A.Rows[uni].Cells[c].Value.ToString());
                            porcePA += double.Parse(dgvP3A.Rows[poi].Cells[c].Value.ToString());
                            unidaPB += double.Parse(dgvP3B.Rows[uni].Cells[c].Value.ToString());
                            porcePB += double.Parse(dgvP3B.Rows[poi].Cells[c].Value.ToString());
                        }
                        dgvH3.Rows[uni].Cells[dgvH1.ColumnCount - 1].Value = unidaH.ToString("N0");
                        dgvH3.Rows[poi].Cells[dgvH1.ColumnCount - 1].Value = porceH.ToString("N0");
                        dgvP3A.Rows[uni].Cells[dgvP1A.ColumnCount - 1].Value = unidaPA.ToString("N0");
                        dgvP3A.Rows[poi].Cells[dgvP1A.ColumnCount - 1].Value = porcePA.ToString("N0");
                        dgvP3B.Rows[uni].Cells[dgvP1B.ColumnCount - 1].Value = unidaPB.ToString("N0");
                        dgvP3B.Rows[poi].Cells[dgvP1B.ColumnCount - 1].Value = porcePB.ToString("N0");

                        uni = uni + 2;
                        poi = poi + 2;
                        r++;
                        /////////////

                    }
#endregion
                    break;
                case 4:
                    #region mes 4
                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                    {
                        unidaH = 0;
                        porceH = 0;
                        unidaPA = 0;
                        porcePA = 0;
                        unidaPB = 0;
                        porcePB = 0;
                        for (int c = 1; c <= dgvH1.ColumnCount - 2; c++)
                        {
                            nulos(i, c);
                            unidaH += double.Parse(dgvH4.Rows[uni].Cells[c].Value.ToString());
                            porceH += double.Parse(dgvH4.Rows[poi].Cells[c].Value.ToString());
                            unidaPA += double.Parse(dgvP4A.Rows[uni].Cells[c].Value.ToString());
                            porcePA += double.Parse(dgvP4A.Rows[poi].Cells[c].Value.ToString());
                            unidaPB += double.Parse(dgvP4B.Rows[uni].Cells[c].Value.ToString());
                            porcePB += double.Parse(dgvP4B.Rows[poi].Cells[c].Value.ToString());
                        }
                        dgvH4.Rows[uni].Cells[dgvH1.ColumnCount - 1].Value = unidaH.ToString("N0");
                        dgvH4.Rows[poi].Cells[dgvH1.ColumnCount - 1].Value = porceH.ToString("N0");
                        dgvP4A.Rows[uni].Cells[dgvP1A.ColumnCount - 1].Value = unidaPA.ToString("N0");
                        dgvP4A.Rows[poi].Cells[dgvP1A.ColumnCount - 1].Value = porcePA.ToString("N0");
                        dgvP4B.Rows[uni].Cells[dgvP1B.ColumnCount - 1].Value = unidaPB.ToString("N0");
                        dgvP4B.Rows[poi].Cells[dgvP1B.ColumnCount - 1].Value = porcePB.ToString("N0");

                        uni = uni + 2;
                        poi = poi + 2;
                        r++;
                        /////////////

                    }
#endregion
                    break;
                case 5:
                    #region mes 5
                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                    {
                        unidaH = 0;
                        porceH = 0;
                        unidaPA = 0;
                        porcePA = 0;
                        unidaPB = 0;
                        porcePB = 0;
                        for (int c = 1; c <= dgvH1.ColumnCount - 2; c++)
                        {
                            nulos(i, c);
                            unidaH += double.Parse(dgvH5.Rows[uni].Cells[c].Value.ToString());
                            porceH += double.Parse(dgvH5.Rows[poi].Cells[c].Value.ToString());
                            unidaPA += double.Parse(dgvP5A.Rows[uni].Cells[c].Value.ToString());
                            porcePA += double.Parse(dgvP5A.Rows[poi].Cells[c].Value.ToString());
                        }
                        dgvH5.Rows[uni].Cells[dgvH1.ColumnCount - 1].Value = unidaH.ToString("N0");
                        dgvH5.Rows[poi].Cells[dgvH1.ColumnCount - 1].Value = porceH.ToString("N0");
                        dgvP5A.Rows[uni].Cells[dgvP1A.ColumnCount - 1].Value = unidaPA.ToString("N0");
                        dgvP5A.Rows[poi].Cells[dgvP1A.ColumnCount - 1].Value = porcePA.ToString("N0");
                        dgvP5B.Rows[uni].Cells[dgvP1B.ColumnCount - 1].Value = unidaPB.ToString("N0");
                        dgvP5B.Rows[poi].Cells[dgvP1B.ColumnCount - 1].Value = porcePB.ToString("N0");

                        uni = uni + 2;
                        poi = poi + 2;
                        r++;
                        /////////////

                    }
#endregion
                    break;
                case 6:
                    #region mes 6
                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                    {
                        unidaH = 0;
                        porceH = 0;
                        unidaPA = 0;
                        porcePA = 0;
                        unidaPB = 0;
                        porcePB = 0;
                        for (int c = 1; c <= dgvH1.ColumnCount - 2; c++)
                        {
                            nulos(i, c);
                            unidaH += double.Parse(dgvH6.Rows[uni].Cells[c].Value.ToString());
                            porceH += double.Parse(dgvH6.Rows[poi].Cells[c].Value.ToString());
                            unidaPA += double.Parse(dgvP6A.Rows[uni].Cells[c].Value.ToString());
                            porcePA += double.Parse(dgvP6A.Rows[poi].Cells[c].Value.ToString());
                            unidaPB += double.Parse(dgvP6B.Rows[uni].Cells[c].Value.ToString());
                            porcePB += double.Parse(dgvP6B.Rows[poi].Cells[c].Value.ToString());
                        }
                        dgvH6.Rows[uni].Cells[dgvH1.ColumnCount - 1].Value = unidaH.ToString("N0");
                        dgvH6.Rows[poi].Cells[dgvH1.ColumnCount - 1].Value = porceH.ToString("N0");
                        dgvP6A.Rows[uni].Cells[dgvP1A.ColumnCount - 1].Value = unidaPA.ToString("N0");
                        dgvP6A.Rows[poi].Cells[dgvP1A.ColumnCount - 1].Value = porcePA.ToString("N0");
                        dgvP6B.Rows[uni].Cells[dgvP1B.ColumnCount - 1].Value = unidaPB.ToString("N0");
                        dgvP6B.Rows[poi].Cells[dgvP1B.ColumnCount - 1].Value = porcePB.ToString("N0");

                        uni = uni + 2;
                        poi = poi + 2;
                        r++;
                        /////////////

                    }
#endregion
                    break;
                case 7:
                    #region mes 7
                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                    {
                        unidaH = 0;
                        porceH = 0;
                        unidaPA = 0;
                        porcePA = 0;
                        unidaPB = 0;
                        porcePB = 0;
                        for (int c = 1; c <= dgvH1.ColumnCount - 2; c++)
                        {
                            nulos(i, c);
                            unidaH += double.Parse(dgvH7.Rows[uni].Cells[c].Value.ToString());
                            porceH += double.Parse(dgvH7.Rows[poi].Cells[c].Value.ToString());
                            unidaPA += double.Parse(dgvP7A.Rows[uni].Cells[c].Value.ToString());
                            porcePA += double.Parse(dgvP7A.Rows[poi].Cells[c].Value.ToString());
                            unidaPB += double.Parse(dgvP7B.Rows[uni].Cells[c].Value.ToString());
                            porcePB += double.Parse(dgvP7B.Rows[poi].Cells[c].Value.ToString());
                        }
                        dgvH7.Rows[uni].Cells[dgvH1.ColumnCount - 1].Value = unidaH.ToString("N0");
                        dgvH7.Rows[poi].Cells[dgvH1.ColumnCount - 1].Value = porceH.ToString("N0");
                        dgvP7A.Rows[uni].Cells[dgvP1A.ColumnCount - 1].Value = unidaPA.ToString("N0");
                        dgvP7A.Rows[poi].Cells[dgvP1A.ColumnCount - 1].Value = porcePA.ToString("N0");
                        dgvP7B.Rows[uni].Cells[dgvP1B.ColumnCount - 1].Value = unidaPB.ToString("N0");
                        dgvP7B.Rows[poi].Cells[dgvP1B.ColumnCount - 1].Value = porcePB.ToString("N0");

                        uni = uni + 2;
                        poi = poi + 2;
                        r++;
                        /////////////

                    }
#endregion
                    break;
                case 8:
                    #region mes 8
                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                    {
                        unidaH = 0;
                        porceH = 0;
                        unidaPA = 0;
                        porcePA = 0;
                        unidaPB = 0;
                        porcePB = 0;
                        for (int c = 1; c <= dgvH1.ColumnCount - 2; c++)
                        {
                            nulos(i, c);
                            unidaH += double.Parse(dgvH8.Rows[uni].Cells[c].Value.ToString());
                            porceH += double.Parse(dgvH8.Rows[poi].Cells[c].Value.ToString());
                            unidaPA += double.Parse(dgvP8A.Rows[uni].Cells[c].Value.ToString());
                            porcePA += double.Parse(dgvP8A.Rows[poi].Cells[c].Value.ToString());
                            unidaPB += double.Parse(dgvP8B.Rows[uni].Cells[c].Value.ToString());
                            porcePB += double.Parse(dgvP8B.Rows[poi].Cells[c].Value.ToString());
                        }
                        dgvH8.Rows[uni].Cells[dgvH1.ColumnCount - 1].Value = unidaH.ToString("N0");
                        dgvH8.Rows[poi].Cells[dgvH1.ColumnCount - 1].Value = porceH.ToString("N0");
                        dgvP8A.Rows[uni].Cells[dgvP1A.ColumnCount - 1].Value = unidaPA.ToString("N0");
                        dgvP8A.Rows[poi].Cells[dgvP1A.ColumnCount - 1].Value = porcePA.ToString("N0");
                        dgvP8B.Rows[uni].Cells[dgvP1B.ColumnCount - 1].Value = unidaPB.ToString("N0");
                        dgvP8B.Rows[poi].Cells[dgvP1B.ColumnCount - 1].Value = porcePB.ToString("N0");

                        uni = uni + 2;
                        poi = poi + 2;
                        r++;
                        /////////////

                    }
#endregion
                    break;
                case 9:
                    #region mes 9
                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                    {
                        unidaH = 0;
                        porceH = 0;
                        unidaPA = 0;
                        porcePA = 0;
                        unidaPB = 0;
                        porcePB = 0;
                        for (int c = 1; c <= dgvH1.ColumnCount - 2; c++)
                        {
                            nulos(i, c);
                            unidaH += double.Parse(dgvH9.Rows[uni].Cells[c].Value.ToString());
                            porceH += double.Parse(dgvH9.Rows[poi].Cells[c].Value.ToString());
                            unidaPA += double.Parse(dgvP9A.Rows[uni].Cells[c].Value.ToString());
                            porcePA += double.Parse(dgvP9A.Rows[poi].Cells[c].Value.ToString());
                            unidaPB += double.Parse(dgvP9B.Rows[uni].Cells[c].Value.ToString());
                            porcePB += double.Parse(dgvP9B.Rows[poi].Cells[c].Value.ToString());
                        }
                        dgvH9.Rows[uni].Cells[dgvH1.ColumnCount - 1].Value = unidaH.ToString("N0");
                        dgvH9.Rows[poi].Cells[dgvH1.ColumnCount - 1].Value = porceH.ToString("N0");
                        dgvP9A.Rows[uni].Cells[dgvP1A.ColumnCount - 1].Value = unidaPA.ToString("N0");
                        dgvP9A.Rows[poi].Cells[dgvP1A.ColumnCount - 1].Value = porcePA.ToString("N0");
                        dgvP9B.Rows[uni].Cells[dgvP1A.ColumnCount - 1].Value = unidaPB.ToString("N0");
                        dgvP9B.Rows[poi].Cells[dgvP1A.ColumnCount - 1].Value = porcePB.ToString("N0");

                        uni = uni + 2;
                        poi = poi + 2;
                        r++;
                        /////////////

                    }
#endregion
                    break;
                case 10:
                    #region mes 10 
                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                    {
                        unidaH = 0;
                        porceH = 0;
                        unidaPA = 0;
                        porcePA = 0;
                        unidaPB = 0;
                        porcePB = 0;
                        for (int c = 1; c <= dgvH1.ColumnCount - 2; c++)
                        {
                            nulos(i, c);
                            unidaH += double.Parse(dgvH10.Rows[uni].Cells[c].Value.ToString());
                            porceH += double.Parse(dgvH10.Rows[poi].Cells[c].Value.ToString());
                            unidaPA += double.Parse(dgvP10A.Rows[uni].Cells[c].Value.ToString());
                            porcePA += double.Parse(dgvP10A.Rows[poi].Cells[c].Value.ToString());
                            unidaPB += double.Parse(dgvP10B.Rows[uni].Cells[c].Value.ToString());
                            porcePB += double.Parse(dgvP10B.Rows[poi].Cells[c].Value.ToString());
                        }
                        dgvH10.Rows[uni].Cells[dgvH1.ColumnCount - 1].Value = unidaH.ToString("N0");
                        dgvH10.Rows[poi].Cells[dgvH1.ColumnCount - 1].Value = porceH.ToString("N0");
                        dgvP10A.Rows[uni].Cells[dgvP1A.ColumnCount - 1].Value = unidaPA.ToString("N0");
                        dgvP10A.Rows[poi].Cells[dgvP1A.ColumnCount - 1].Value = porcePA.ToString("N0");
                        dgvP10B.Rows[uni].Cells[dgvP1B.ColumnCount - 1].Value = unidaPB.ToString("N0");
                        dgvP10B.Rows[poi].Cells[dgvP1B.ColumnCount - 1].Value = porcePB.ToString("N0");

                        uni = uni + 2;
                        poi = poi + 2;
                        r++;
                        /////////////

                    }
#endregion
                    break;
                case 11:
                    #region mes 11
                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                    {
                        unidaH = 0;
                        porceH = 0;
                        unidaPA = 0;
                        porcePA = 0;
                        unidaPB = 0;
                        porcePB = 0;
                        for (int c = 1; c <= dgvH1.ColumnCount - 2; c++)
                        {
                            nulos(i, c);
                            unidaH += double.Parse(dgvH11.Rows[uni].Cells[c].Value.ToString());
                            porceH += double.Parse(dgvH11.Rows[poi].Cells[c].Value.ToString());
                            unidaPA += double.Parse(dgvP11A.Rows[uni].Cells[c].Value.ToString());
                            porcePA += double.Parse(dgvP11A.Rows[poi].Cells[c].Value.ToString());
                            unidaPB += double.Parse(dgvP11B.Rows[uni].Cells[c].Value.ToString());
                            porcePB += double.Parse(dgvP11B.Rows[poi].Cells[c].Value.ToString());
                        }
                        dgvH11.Rows[uni].Cells[dgvH1.ColumnCount - 1].Value = unidaH.ToString("N0");
                        dgvH11.Rows[poi].Cells[dgvH1.ColumnCount - 1].Value = porceH.ToString("N0");
                        dgvP11A.Rows[uni].Cells[dgvP1A.ColumnCount - 1].Value = unidaPA.ToString("N0");
                        dgvP11A.Rows[poi].Cells[dgvP1A.ColumnCount - 1].Value = porcePA.ToString("N0");
                        dgvP11B.Rows[uni].Cells[dgvP1B.ColumnCount - 1].Value = unidaPB.ToString("N0");
                        dgvP11B.Rows[poi].Cells[dgvP1B.ColumnCount - 1].Value = porcePB.ToString("N0");

                        uni = uni + 2;
                        poi = poi + 2;
                        r++;
                        /////////////

                    }
#endregion
                    break;
                case 12:
                    #region mes 12
                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                    {
                        unidaH = 0;
                        porceH = 0;
                        unidaPA = 0;
                        porcePB = 0;
                        unidaPB = 0;
                        porcePB = 0;
                        for (int c = 1; c <= dgvH1.ColumnCount - 2; c++)
                        {
                            nulos(i, c);
                            unidaH += double.Parse(dgvH12.Rows[uni].Cells[c].Value.ToString());
                            porceH += double.Parse(dgvH12.Rows[poi].Cells[c].Value.ToString());
                            unidaPA += double.Parse(dgvP12A.Rows[uni].Cells[c].Value.ToString());
                            porcePA += double.Parse(dgvP12A.Rows[poi].Cells[c].Value.ToString());
                            unidaPB += double.Parse(dgvP12B.Rows[uni].Cells[c].Value.ToString());
                            porcePB += double.Parse(dgvP12B.Rows[poi].Cells[c].Value.ToString());
                        }
                        dgvH12.Rows[uni].Cells[dgvH1.ColumnCount - 1].Value = unidaH.ToString("N0");
                        dgvH12.Rows[poi].Cells[dgvH1.ColumnCount - 1].Value = porceH.ToString("N0");
                        dgvP12A.Rows[uni].Cells[dgvP1A.ColumnCount - 1].Value = unidaPA.ToString("N0");
                        dgvP12A.Rows[poi].Cells[dgvP1A.ColumnCount - 1].Value = porcePA.ToString("N0");
                        dgvP12B.Rows[uni].Cells[dgvP1B.ColumnCount - 1].Value = unidaPB.ToString("N0");
                        dgvP12B.Rows[poi].Cells[dgvP1B.ColumnCount - 1].Value = porcePB.ToString("N0");

                        uni = uni + 2;
                        poi = poi + 2;
                        r++;
                        /////////////

                    }
#endregion
                    break;

            }
        }
        private void dgvP1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //MessageBox.Show(dgvP1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            int dgv = 0;
            #region comprobar cual dgv se modifico
            if (tabcontrol.SelectedIndex == 0 && e.ColumnIndex >= 0 && dgvP1A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 1;
            }
            if (tabcontrol.SelectedIndex == 1 && e.ColumnIndex >= 0 && dgvP2A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 2;
            }
            if (tabcontrol.SelectedIndex == 2 && e.ColumnIndex >= 0 && dgvP3A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 3;
            }
            if (tabcontrol.SelectedIndex == 3 && e.ColumnIndex >= 0 && dgvP4A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 4;
            }
            if (tabcontrol.SelectedIndex == 4 && e.ColumnIndex >= 0 && dgvP5A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 5;
            }
            if (tabcontrol.SelectedIndex == 5 && e.ColumnIndex >= 0 && dgvP6A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 6;
            }
            if (tabcontrol.SelectedIndex == 6 && e.ColumnIndex >= 0 && dgvP7A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 7;
            }
            if (tabcontrol.SelectedIndex == 7 && e.ColumnIndex >= 0 && dgvP8A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 8;
            }
            if (tabcontrol.SelectedIndex == 8 && e.ColumnIndex >= 0 && dgvP9A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 9;
            }
            if (tabcontrol.SelectedIndex == 9 && e.ColumnIndex >= 0 && dgvP10A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 10;
            }
            if (tabcontrol.SelectedIndex == 10 && e.ColumnIndex >= 0 && dgvP11A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 11;
            }
            if (tabcontrol.SelectedIndex == 11 && e.ColumnIndex >= 0 && dgvP12A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 12;
            }
            #endregion
            switch (dgv)
            {
                case 1:
                    #region
                    if (dgvP1A.Rows[e.RowIndex].Cells[0].Value.ToString() == "PORCENTAJE")
                    {
                        porcentajeR = double.Parse(dgvP1A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    else
                    {
                        unidadesR = double.Parse(dgvP1A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    #endregion
                    break;
                case 2:
                    #region
                    if (dgvP2A.Rows[e.RowIndex].Cells[0].Value.ToString() == "PORCENTAJE")
                    {
                        porcentajeR = double.Parse(dgvP2A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    else
                    {
                        unidadesR = double.Parse(dgvP2A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    #endregion
                    break;
                case 3:
                    #region
                    if (dgvP3A.Rows[e.RowIndex].Cells[0].Value.ToString() == "PORCENTAJE")
                    {
                        porcentajeR = double.Parse(dgvP3A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    else
                    {
                        unidadesR = double.Parse(dgvP3A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    #endregion
                    break;
                case 4:
                    #region
                    if (dgvP4A.Rows[e.RowIndex].Cells[0].Value.ToString() == "PORCENTAJE")
                    {
                        porcentajeR = double.Parse(dgvP4A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    else
                    {
                        unidadesR = double.Parse(dgvP4A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    #endregion
                    break;
                case 5:
                    #region
                    if (dgvP5A.Rows[e.RowIndex].Cells[0].Value.ToString() == "PORCENTAJE")
                    {
                        porcentajeR = double.Parse(dgvP5A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    else
                    {
                        unidadesR = double.Parse(dgvP5A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    #endregion
                    break;
                case 6:
                    #region
                    if (dgvP6A.Rows[e.RowIndex].Cells[0].Value.ToString() == "PORCENTAJE")
                    {
                        porcentajeR = double.Parse(dgvP6A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    else
                    {
                        unidadesR = double.Parse(dgvP6A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    #endregion
                    break;
                case 7:
                    #region
                    if (dgvP7A.Rows[e.RowIndex].Cells[0].Value.ToString() == "PORCENTAJE")
                    {
                        porcentajeR = double.Parse(dgvP7A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    else
                    {
                        unidadesR = double.Parse(dgvP7A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    #endregion
                    break;
                case 8:
                    #region
                    if (dgvP8A.Rows[e.RowIndex].Cells[0].Value.ToString() == "PORCENTAJE")
                    {
                        porcentajeR = double.Parse(dgvP8A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    else
                    {
                        unidadesR = double.Parse(dgvP8A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    #endregion
                    break;
                case 9:
                    #region
                    if (dgvP9A.Rows[e.RowIndex].Cells[0].Value.ToString() == "PORCENTAJE")
                    {
                        porcentajeR = double.Parse(dgvP9A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    else
                    {
                        unidadesR = double.Parse(dgvP9A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    #endregion
                    break;
                case 10:
                    #region
                    if (dgvP10A.Rows[e.RowIndex].Cells[0].Value.ToString() == "PORCENTAJE")
                    {
                        porcentajeR = double.Parse(dgvP10A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    else
                    {
                        unidadesR = double.Parse(dgvP10A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    #endregion
                    break;
                case 11:
                    #region
                    if (dgvP11A.Rows[e.RowIndex].Cells[0].Value.ToString() == "PORCENTAJE")
                    {
                        porcentajeR = double.Parse(dgvP11A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    else
                    {
                        unidadesR = double.Parse(dgvP11A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    #endregion
                    break;
                case 12:
                    #region
                    if (dgvP12A.Rows[e.RowIndex].Cells[0].Value.ToString() == "PORCENTAJE")
                    {
                        porcentajeR = double.Parse(dgvP12A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    else
                    {
                        unidadesR = double.Parse(dgvP12A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    #endregion
                    break;
            }
            
        }
        private void dgvE1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int dgv = 0;
            double porcentajeM = 0;
            double porcentajeActual = 0;
            double sumaU = 0;
            double diferenciaP = 0;
            double diferenciaU = 0;
            double porcentajeDif = 0;
            double unidadesFinal = 0;
            double porcentajefinal = 0;
            double unidadM = 0;
            ////MessageBox.Show(dgvP1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

            DateTime fi = DateTime.Parse(f1.ToString());
            DateTime ff = DateTime.Parse(f2.ToString());
            #region comprobar cual dgv se modifico
            if (tabcontrol.SelectedIndex == 0 && e.ColumnIndex >= 0 && dgvP1A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 1;
            }
            if (tabcontrol.SelectedIndex == 1 && e.ColumnIndex >= 0 && dgvP2A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 2;
            }
            if (tabcontrol.SelectedIndex == 2 && e.ColumnIndex >= 0 && dgvP3A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 3;
            }
            if (tabcontrol.SelectedIndex == 3 && e.ColumnIndex >= 0 && dgvP4A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 4;
            }
            if (tabcontrol.SelectedIndex == 4 && e.ColumnIndex >= 0 && dgvP5A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 5;
            }
            if (tabcontrol.SelectedIndex == 5 && e.ColumnIndex >= 0 && dgvP6A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 6;
            }
            if (tabcontrol.SelectedIndex == 6 && e.ColumnIndex >= 0 && dgvP7A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 7;
            }
            if (tabcontrol.SelectedIndex == 7 && e.ColumnIndex >= 0 && dgvP8A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 8;
            }
            if (tabcontrol.SelectedIndex == 8 && e.ColumnIndex >= 0 && dgvP9A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 9;
            }
            if (tabcontrol.SelectedIndex == 9 && e.ColumnIndex >= 0 && dgvP10A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 10;
            }
            if (tabcontrol.SelectedIndex == 10 && e.ColumnIndex >= 0 && dgvP11A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 11;
            }
            if (tabcontrol.SelectedIndex == 11 && e.ColumnIndex >= 0 && dgvP12A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 12;
            }
            #endregion
            switch (dgv)
            {
                case 1:
                    #region dgv1

                    if (dgvP1A.Rows[e.RowIndex].Cells[0].Value.ToString() != "PORCENTAJE" && e.ColumnIndex >= 1 && e.ColumnIndex <= dgvP1A.ColumnCount - 1)
                    {
                        unidadM = double.Parse(dgvP1A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        porcentajefinal = unidadM / double.Parse(dgvP1A.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                        dgvP1A.Rows[(e.RowIndex + 1)].Cells[e.ColumnIndex].Value = porcentajefinal.ToString("N2");
                        diferenciaU = unidadM - unidadesR;
                        for (int x = 1; x <= dgvP1A.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP1A.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP1A.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP1A.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaU);
                                dgvP1A.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N0");
                                unidadesFinal = porcentajefinal / double.Parse(dgvP1A.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                                dgvP1A.Rows[(e.RowIndex + 1)].Cells[y].Value = unidadesFinal.ToString("N2");
                            }
                        }

                    }
                    else
                    {
                        porcentajeM = double.Parse(dgvP1A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        unidadesFinal = porcentajeM * double.Parse(dgvP1A.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                        dgvP1A.Rows[(e.RowIndex - 1)].Cells[e.ColumnIndex].Value = unidadesFinal.ToString("N0");
                        diferenciaP = porcentajeM - porcentajeR;
                        for (int x = 1; x <= dgvP1A.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP1A.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP1A.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP1A.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaP);
                                dgvP1A.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N2");
                                unidadesFinal = porcentajefinal * double.Parse(dgvP1A.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                                dgvP1A.Rows[(e.RowIndex - 1)].Cells[y].Value = unidadesFinal.ToString("N0");
                            }
                        }
                    }
                    #endregion
                    break;
                case 2:
                    #region dgv1

                    if (dgvP2A.Rows[e.RowIndex].Cells[0].Value.ToString() != "PORCENTAJE" && e.ColumnIndex >= 1 && e.ColumnIndex <= dgvP2A.ColumnCount - 1)
                    {
                        unidadM = double.Parse(dgvP2A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        porcentajefinal = unidadM / double.Parse(dgvP2A.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                        dgvP2A.Rows[(e.RowIndex + 1)].Cells[e.ColumnIndex].Value = porcentajefinal.ToString("N2");
                        diferenciaU = unidadM - unidadesR;
                        for (int x = 1; x <= dgvP2A.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP2A.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP2A.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP2A.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaU);
                                dgvP2A.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N0");
                                unidadesFinal = porcentajefinal / double.Parse(dgvP2A.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                                dgvP2A.Rows[(e.RowIndex + 1)].Cells[y].Value = unidadesFinal.ToString("N2");
                            }
                        }

                    }
                    else
                    {
                        porcentajeM = double.Parse(dgvP2A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        unidadesFinal = porcentajeM * double.Parse(dgvP2A.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                        dgvP2A.Rows[(e.RowIndex - 1)].Cells[e.ColumnIndex].Value = unidadesFinal.ToString("N0");
                        diferenciaP = porcentajeM - porcentajeR;
                        for (int x = 1; x <= dgvP2A.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP2A.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP2A.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP2A.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaP);
                                dgvP2A.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N2");
                                unidadesFinal = porcentajefinal * double.Parse(dgvP2A.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                                dgvP2A.Rows[(e.RowIndex - 1)].Cells[y].Value = unidadesFinal.ToString("N0");
                            }
                        }
                    }
                    #endregion
                    break;
                case 3:
                    #region dgv1

                    if (dgvP3A.Rows[e.RowIndex].Cells[0].Value.ToString() != "PORCENTAJE" && e.ColumnIndex >= 1 && e.ColumnIndex <= dgvP3A.ColumnCount - 1)
                    {
                        unidadM = double.Parse(dgvP3A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        porcentajefinal = unidadM / double.Parse(dgvP3A.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                        dgvP3A.Rows[(e.RowIndex + 1)].Cells[e.ColumnIndex].Value = porcentajefinal.ToString("N2");
                        diferenciaU = unidadM - unidadesR;
                        for (int x = 1; x <= dgvP3A.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP3A.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP3A.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP3A.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaU);
                                dgvP3A.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N0");
                                unidadesFinal = porcentajefinal / double.Parse(dgvP3A.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                                dgvP3A.Rows[(e.RowIndex + 1)].Cells[y].Value = unidadesFinal.ToString("N2");
                            }
                        }

                    }
                    else
                    {
                        porcentajeM = double.Parse(dgvP3A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        unidadesFinal = porcentajeM * double.Parse(dgvP3A.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                        dgvP3A.Rows[(e.RowIndex - 1)].Cells[e.ColumnIndex].Value = unidadesFinal.ToString("N0");
                        diferenciaP = porcentajeM - porcentajeR;
                        for (int x = 1; x <= dgvP3A.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP3A.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP3A.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP3A.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaP);
                                dgvP3A.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N2");
                                unidadesFinal = porcentajefinal * double.Parse(dgvP3A.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                                dgvP3A.Rows[(e.RowIndex - 1)].Cells[y].Value = unidadesFinal.ToString("N0");
                            }
                        }
                    }
                    #endregion
                    break;
                case 4:
                    #region dgv1

                    if (dgvP4A.Rows[e.RowIndex].Cells[0].Value.ToString() != "PORCENTAJE" && e.ColumnIndex >= 1 && e.ColumnIndex <= dgvP4A.ColumnCount - 1)
                    {
                        unidadM = double.Parse(dgvP4A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        porcentajefinal = unidadM / double.Parse(dgvP4A.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                        dgvP4A.Rows[(e.RowIndex + 1)].Cells[e.ColumnIndex].Value = porcentajefinal.ToString("N2");
                        diferenciaU = unidadM - unidadesR;
                        for (int x = 1; x <= dgvP4A.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP4A.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP4A.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP4A.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaU);
                                dgvP4A.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N0");
                                unidadesFinal = porcentajefinal / double.Parse(dgvP4A.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                                dgvP4A.Rows[(e.RowIndex + 1)].Cells[y].Value = unidadesFinal.ToString("N2");
                            }
                        }

                    }
                    else
                    {
                        porcentajeM = double.Parse(dgvP4A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        unidadesFinal = porcentajeM * double.Parse(dgvP4A.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                        dgvP4A.Rows[(e.RowIndex - 1)].Cells[e.ColumnIndex].Value = unidadesFinal.ToString("N0");
                        diferenciaP = porcentajeM - porcentajeR;
                        for (int x = 1; x <= dgvP4A.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP4A.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP4A.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP4A.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaP);
                                dgvP4A.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N2");
                                unidadesFinal = porcentajefinal * double.Parse(dgvP4A.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                                dgvP4A.Rows[(e.RowIndex - 1)].Cells[y].Value = unidadesFinal.ToString("N0");
                            }
                        }
                    }
                    #endregion
                    break;
                case 5:
                    #region dgv1

                    if (dgvP5A.Rows[e.RowIndex].Cells[0].Value.ToString() != "PORCENTAJE" && e.ColumnIndex >= 1 && e.ColumnIndex <= dgvP5A.ColumnCount - 1)
                    {
                        unidadM = double.Parse(dgvP5A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        porcentajefinal = unidadM / double.Parse(dgvP5A.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                        dgvP5A.Rows[(e.RowIndex + 1)].Cells[e.ColumnIndex].Value = porcentajefinal.ToString("N2");
                        diferenciaU = unidadM - unidadesR;
                        for (int x = 1; x <= dgvP5A.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP5A.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP5A.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP5A.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaU);
                                dgvP5A.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N0");
                                unidadesFinal = porcentajefinal / double.Parse(dgvP5A.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                                dgvP5A.Rows[(e.RowIndex + 1)].Cells[y].Value = unidadesFinal.ToString("N2");
                            }
                        }

                    }
                    else
                    {
                        porcentajeM = double.Parse(dgvP5A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        unidadesFinal = porcentajeM * double.Parse(dgvP5A.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                        dgvP5A.Rows[(e.RowIndex - 1)].Cells[e.ColumnIndex].Value = unidadesFinal.ToString("N0");
                        diferenciaP = porcentajeM - porcentajeR;
                        for (int x = 1; x <= dgvP5A.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP5A.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP5A.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP5A.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaP);
                                dgvP5A.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N2");
                                unidadesFinal = porcentajefinal * double.Parse(dgvP5A.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                                dgvP5A.Rows[(e.RowIndex - 1)].Cells[y].Value = unidadesFinal.ToString("N0");
                            }
                        }
                    }
                    #endregion
                    break;
                case 6:
                    #region dgv1

                    if (dgvP6A.Rows[e.RowIndex].Cells[0].Value.ToString() != "PORCENTAJE" && e.ColumnIndex >= 1 && e.ColumnIndex <= dgvP6A.ColumnCount - 1)
                    {
                        unidadM = double.Parse(dgvP6A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        porcentajefinal = unidadM / double.Parse(dgvP6A.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                        dgvP6A.Rows[(e.RowIndex + 1)].Cells[e.ColumnIndex].Value = porcentajefinal.ToString("N2");
                        diferenciaU = unidadM - unidadesR;
                        for (int x = 1; x <= dgvP6A.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP6A.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP6A.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP6A.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaU);
                                dgvP6A.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N0");
                                unidadesFinal = porcentajefinal / double.Parse(dgvP6A.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                                dgvP6A.Rows[(e.RowIndex + 1)].Cells[y].Value = unidadesFinal.ToString("N2");
                            }
                        }

                    }
                    else
                    {
                        porcentajeM = double.Parse(dgvP6A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        unidadesFinal = porcentajeM * double.Parse(dgvP6A.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                        dgvP6A.Rows[(e.RowIndex - 1)].Cells[e.ColumnIndex].Value = unidadesFinal.ToString("N0");
                        diferenciaP = porcentajeM - porcentajeR;
                        for (int x = 1; x <= dgvP6A.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP6A.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP6A.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP6A.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaP);
                                dgvP6A.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N2");
                                unidadesFinal = porcentajefinal * double.Parse(dgvP6A.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                                dgvP6A.Rows[(e.RowIndex - 1)].Cells[y].Value = unidadesFinal.ToString("N0");
                            }
                        }
                    }
                    #endregion
                    break;
                case 7:
                    #region dgv1

                    if (dgvP7A.Rows[e.RowIndex].Cells[0].Value.ToString() != "PORCENTAJE" && e.ColumnIndex >= 1 && e.ColumnIndex <= dgvP7A.ColumnCount - 1)
                    {
                        unidadM = double.Parse(dgvP7A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        porcentajefinal = unidadM / double.Parse(dgvP7A.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                        dgvP7A.Rows[(e.RowIndex + 1)].Cells[e.ColumnIndex].Value = porcentajefinal.ToString("N2");
                        diferenciaU = unidadM - unidadesR;
                        for (int x = 1; x <= dgvP7A.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP7A.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP7A.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP7A.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaU);
                                dgvP7A.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N0");
                                unidadesFinal = porcentajefinal / double.Parse(dgvP7A.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                                dgvP7A.Rows[(e.RowIndex + 1)].Cells[y].Value = unidadesFinal.ToString("N2");
                            }
                        }

                    }
                    else
                    {
                        porcentajeM = double.Parse(dgvP7A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        unidadesFinal = porcentajeM * double.Parse(dgvP7A.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                        dgvP7A.Rows[(e.RowIndex - 1)].Cells[e.ColumnIndex].Value = unidadesFinal.ToString("N0");
                        diferenciaP = porcentajeM - porcentajeR;
                        for (int x = 1; x <= dgvP7A.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP7A.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP7A.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP7A.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaP);
                                dgvP7A.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N2");
                                unidadesFinal = porcentajefinal * double.Parse(dgvP7A.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                                dgvP7A.Rows[(e.RowIndex - 1)].Cells[y].Value = unidadesFinal.ToString("N0");
                            }
                        }
                    }
                    #endregion
                    break;
                case 8:
                    #region dgv1

                    if (dgvP8A.Rows[e.RowIndex].Cells[0].Value.ToString() != "PORCENTAJE" && e.ColumnIndex >= 1 && e.ColumnIndex <= dgvP8A.ColumnCount - 1)
                    {
                        unidadM = double.Parse(dgvP8A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        porcentajefinal = unidadM / double.Parse(dgvP8A.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                        dgvP8A.Rows[(e.RowIndex + 1)].Cells[e.ColumnIndex].Value = porcentajefinal.ToString("N2");
                        diferenciaU = unidadM - unidadesR;
                        for (int x = 1; x <= dgvP8A.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP8A.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP8A.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP8A.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaU);
                                dgvP8A.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N0");
                                unidadesFinal = porcentajefinal / double.Parse(dgvP8A.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                                dgvP8A.Rows[(e.RowIndex + 1)].Cells[y].Value = unidadesFinal.ToString("N2");
                            }
                        }

                    }
                    else
                    {
                        porcentajeM = double.Parse(dgvP8A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        unidadesFinal = porcentajeM * double.Parse(dgvP8A.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                        dgvP8A.Rows[(e.RowIndex - 1)].Cells[e.ColumnIndex].Value = unidadesFinal.ToString("N0");
                        diferenciaP = porcentajeM - porcentajeR;
                        for (int x = 1; x <= dgvP8A.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP8A.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP8A.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP8A.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaP);
                                dgvP8A.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N2");
                                unidadesFinal = porcentajefinal * double.Parse(dgvP8A.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                                dgvP8A.Rows[(e.RowIndex - 1)].Cells[y].Value = unidadesFinal.ToString("N0");
                            }
                        }
                    }
                    #endregion
                    break;
                case 9:
                    #region dgv1

                    if (dgvP9A.Rows[e.RowIndex].Cells[0].Value.ToString() != "PORCENTAJE" && e.ColumnIndex >= 1 && e.ColumnIndex <= dgvP9A.ColumnCount - 1)
                    {
                        unidadM = double.Parse(dgvP9A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        porcentajefinal = unidadM / double.Parse(dgvP9A.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                        dgvP9A.Rows[(e.RowIndex + 1)].Cells[e.ColumnIndex].Value = porcentajefinal.ToString("N2");
                        diferenciaU = unidadM - unidadesR;
                        for (int x = 1; x <= dgvP9A.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP9A.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP9A.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP9A.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaU);
                                dgvP9A.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N0");
                                unidadesFinal = porcentajefinal / double.Parse(dgvP9A.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                                dgvP9A.Rows[(e.RowIndex + 1)].Cells[y].Value = unidadesFinal.ToString("N2");
                            }
                        }

                    }
                    else
                    {
                        porcentajeM = double.Parse(dgvP9A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        unidadesFinal = porcentajeM * double.Parse(dgvP9A.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                        dgvP9A.Rows[(e.RowIndex - 1)].Cells[e.ColumnIndex].Value = unidadesFinal.ToString("N0");
                        diferenciaP = porcentajeM - porcentajeR;
                        for (int x = 1; x <= dgvP9A.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP9A.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP9A.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP9A.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaP);
                                dgvP9A.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N2");
                                unidadesFinal = porcentajefinal * double.Parse(dgvP9A.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                                dgvP9A.Rows[(e.RowIndex - 1)].Cells[y].Value = unidadesFinal.ToString("N0");
                            }
                        }
                    }
                    #endregion
                    break;
                case 10:
                    #region dgv1

                    if (dgvP10A.Rows[e.RowIndex].Cells[0].Value.ToString() != "PORCENTAJE" && e.ColumnIndex >= 1 && e.ColumnIndex <= dgvP10A.ColumnCount - 1)
                    {
                        unidadM = double.Parse(dgvP10A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        porcentajefinal = unidadM / double.Parse(dgvP10A.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                        dgvP10A.Rows[(e.RowIndex + 1)].Cells[e.ColumnIndex].Value = porcentajefinal.ToString("N2");
                        diferenciaU = unidadM - unidadesR;
                        for (int x = 1; x <= dgvP10A.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP10A.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP10A.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP10A.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaU);
                                dgvP10A.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N0");
                                unidadesFinal = porcentajefinal / double.Parse(dgvP10A.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                                dgvP10A.Rows[(e.RowIndex + 1)].Cells[y].Value = unidadesFinal.ToString("N2");
                            }
                        }

                    }
                    else
                    {
                        porcentajeM = double.Parse(dgvP10A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        unidadesFinal = porcentajeM * double.Parse(dgvP10A.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                        dgvP10A.Rows[(e.RowIndex - 1)].Cells[e.ColumnIndex].Value = unidadesFinal.ToString("N0");
                        diferenciaP = porcentajeM - porcentajeR;
                        for (int x = 1; x <= dgvP10A.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP10A.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP10A.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP10A.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaP);
                                dgvP10A.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N2");
                                unidadesFinal = porcentajefinal * double.Parse(dgvP10A.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                                dgvP10A.Rows[(e.RowIndex - 1)].Cells[y].Value = unidadesFinal.ToString("N0");
                            }
                        }
                    }
                    #endregion
                    break;
                case 11:
                    #region dgv1

                    if (dgvP11A.Rows[e.RowIndex].Cells[0].Value.ToString() != "PORCENTAJE" && e.ColumnIndex >= 1 && e.ColumnIndex <= dgvP11A.ColumnCount - 1)
                    {
                        unidadM = double.Parse(dgvP11A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        porcentajefinal = unidadM / double.Parse(dgvP11A.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                        dgvP11A.Rows[(e.RowIndex + 1)].Cells[e.ColumnIndex].Value = porcentajefinal.ToString("N2");
                        diferenciaU = unidadM - unidadesR;
                        for (int x = 1; x <= dgvP11A.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP11A.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP11A.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP11A.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaU);
                                dgvP11A.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N0");
                                unidadesFinal = porcentajefinal / double.Parse(dgvP11A.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                                dgvP11A.Rows[(e.RowIndex + 1)].Cells[y].Value = unidadesFinal.ToString("N2");
                            }
                        }

                    }
                    else
                    {
                        porcentajeM = double.Parse(dgvP11A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        unidadesFinal = porcentajeM * double.Parse(dgvP11A.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                        dgvP11A.Rows[(e.RowIndex - 1)].Cells[e.ColumnIndex].Value = unidadesFinal.ToString("N0");
                        diferenciaP = porcentajeM - porcentajeR;
                        for (int x = 1; x <= dgvP11A.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP11A.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP11A.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP11A.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaP);
                                dgvP11A.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N2");
                                unidadesFinal = porcentajefinal * double.Parse(dgvP11A.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                                dgvP11A.Rows[(e.RowIndex - 1)].Cells[y].Value = unidadesFinal.ToString("N0");
                            }
                        }
                    }
                    #endregion
                    break;
                case 12:
                    #region dgv1

                    if (dgvP12A.Rows[e.RowIndex].Cells[0].Value.ToString() != "PORCENTAJE" && e.ColumnIndex >= 1 && e.ColumnIndex <= dgvP12A.ColumnCount - 1)
                    {
                        unidadM = double.Parse(dgvP12A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        porcentajefinal = unidadM / double.Parse(dgvP12A.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                        dgvP12A.Rows[(e.RowIndex + 1)].Cells[e.ColumnIndex].Value = porcentajefinal.ToString("N2");
                        diferenciaU = unidadM - unidadesR;
                        for (int x = 1; x <= dgvP12A.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP12A.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP12A.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP12A.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaU);
                                dgvP12A.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N0");
                                unidadesFinal = porcentajefinal / double.Parse(dgvP12A.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                                dgvP12A.Rows[(e.RowIndex + 1)].Cells[y].Value = unidadesFinal.ToString("N2");
                            }
                        }

                    }
                    else
                    {
                        porcentajeM = double.Parse(dgvP12A.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        unidadesFinal = porcentajeM * double.Parse(dgvP12A.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                        dgvP12A.Rows[(e.RowIndex - 1)].Cells[e.ColumnIndex].Value = unidadesFinal.ToString("N0");
                        diferenciaP = porcentajeM - porcentajeR;
                        for (int x = 1; x <= dgvP12A.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP12A.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP12A.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP12A.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaP);
                                dgvP12A.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N2");
                                unidadesFinal = porcentajefinal * double.Parse(dgvP12A.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                                dgvP12A.Rows[(e.RowIndex - 1)].Cells[y].Value = unidadesFinal.ToString("N0");
                            }
                        }
                    }
                    #endregion
                    break;
            }
            //calcularTotales(dgv);
        }
        /// <summary>
        /// ////////
        /// 
        /// 
        /// </summary>
        private void dgvP1_CellBeginEditB(object sender, DataGridViewCellCancelEventArgs e)
        {
            //MessageBox.Show(dgvP1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            int dgv = 0;
            #region comprobar cual dgv se modifico
            if (tabcontrol.SelectedIndex == 0 && e.ColumnIndex >= 0 && dgvP1B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 1;
            }
            if (tabcontrol.SelectedIndex == 1 && e.ColumnIndex >= 0 && dgvP2B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 2;
            }
            if (tabcontrol.SelectedIndex == 2 && e.ColumnIndex >= 0 && dgvP3B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 3;
            }
            if (tabcontrol.SelectedIndex == 3 && e.ColumnIndex >= 0 && dgvP4B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 4;
            }
            if (tabcontrol.SelectedIndex == 4 && e.ColumnIndex >= 0 && dgvP5B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 5;
            }
            if (tabcontrol.SelectedIndex == 5 && e.ColumnIndex >= 0 && dgvP6B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 6;
            }
            if (tabcontrol.SelectedIndex == 6 && e.ColumnIndex >= 0 && dgvP7B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 7;
            }
            if (tabcontrol.SelectedIndex == 7 && e.ColumnIndex >= 0 && dgvP8B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 8;
            }
            if (tabcontrol.SelectedIndex == 8 && e.ColumnIndex >= 0 && dgvP9B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 9;
            }
            if (tabcontrol.SelectedIndex == 9 && e.ColumnIndex >= 0 && dgvP10B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 10;
            }
            if (tabcontrol.SelectedIndex == 10 && e.ColumnIndex >= 0 && dgvP11B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 11;
            }
            if (tabcontrol.SelectedIndex == 11 && e.ColumnIndex >= 0 && dgvP12B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 12;
            }
            #endregion
            switch (dgv)
            {
                case 1:
                    #region
                    if (dgvP1B.Rows[e.RowIndex].Cells[0].Value.ToString() == "PORCENTAJE")
                    {
                        porcentajeR = double.Parse(dgvP1B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    else
                    {
                        unidadesR = double.Parse(dgvP1B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    #endregion
                    break;
                case 2:
                    #region
                    if (dgvP2B.Rows[e.RowIndex].Cells[0].Value.ToString() == "PORCENTAJE")
                    {
                        porcentajeR = double.Parse(dgvP2B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    else
                    {
                        unidadesR = double.Parse(dgvP2B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    #endregion
                    break;
                case 3:
                    #region
                    if (dgvP3B.Rows[e.RowIndex].Cells[0].Value.ToString() == "PORCENTAJE")
                    {
                        porcentajeR = double.Parse(dgvP3B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    else
                    {
                        unidadesR = double.Parse(dgvP3B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    #endregion
                    break;
                case 4:
                    #region
                    if (dgvP4B.Rows[e.RowIndex].Cells[0].Value.ToString() == "PORCENTAJE")
                    {
                        porcentajeR = double.Parse(dgvP4B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    else
                    {
                        unidadesR = double.Parse(dgvP4B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    #endregion
                    break;
                case 5:
                    #region
                    if (dgvP5B.Rows[e.RowIndex].Cells[0].Value.ToString() == "PORCENTAJE")
                    {
                        porcentajeR = double.Parse(dgvP5B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    else
                    {
                        unidadesR = double.Parse(dgvP5B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    #endregion
                    break;
                case 6:
                    #region
                    if (dgvP6B.Rows[e.RowIndex].Cells[0].Value.ToString() == "PORCENTAJE")
                    {
                        porcentajeR = double.Parse(dgvP6B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    else
                    {
                        unidadesR = double.Parse(dgvP6B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    #endregion
                    break;
                case 7:
                    #region
                    if (dgvP7B.Rows[e.RowIndex].Cells[0].Value.ToString() == "PORCENTAJE")
                    {
                        porcentajeR = double.Parse(dgvP7B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    else
                    {
                        unidadesR = double.Parse(dgvP7B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    #endregion
                    break;
                case 8:
                    #region
                    if (dgvP8B.Rows[e.RowIndex].Cells[0].Value.ToString() == "PORCENTAJE")
                    {
                        porcentajeR = double.Parse(dgvP8B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    else
                    {
                        unidadesR = double.Parse(dgvP8B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    #endregion
                    break;
                case 9:
                    #region
                    if (dgvP9B.Rows[e.RowIndex].Cells[0].Value.ToString() == "PORCENTAJE")
                    {
                        porcentajeR = double.Parse(dgvP9B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    else
                    {
                        unidadesR = double.Parse(dgvP9B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    #endregion
                    break;
                case 10:
                    #region
                    if (dgvP10B.Rows[e.RowIndex].Cells[0].Value.ToString() == "PORCENTAJE")
                    {
                        porcentajeR = double.Parse(dgvP10B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    else
                    {
                        unidadesR = double.Parse(dgvP10B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    #endregion
                    break;
                case 11:
                    #region
                    if (dgvP11B.Rows[e.RowIndex].Cells[0].Value.ToString() == "PORCENTAJE")
                    {
                        porcentajeR = double.Parse(dgvP11B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    else
                    {
                        unidadesR = double.Parse(dgvP11B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    #endregion
                    break;
                case 12:
                    #region
                    if (dgvP12B.Rows[e.RowIndex].Cells[0].Value.ToString() == "PORCENTAJE")
                    {
                        porcentajeR = double.Parse(dgvP12B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    else
                    {
                        unidadesR = double.Parse(dgvP12B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    #endregion
                    break;
            }

        }
        private void dgvE1_CellEndEditB(object sender, DataGridViewCellEventArgs e)
        {
            int dgv = 0;
            double porcentajeM = 0;
            double porcentajeActual = 0;
            double sumaU = 0;
            double diferenciaP = 0;
            double diferenciaU = 0;
            double porcentajeDif = 0;
            double unidadesFinal = 0;
            double porcentajefinal = 0;
            double unidadM = 0;
            ////MessageBox.Show(dgvP1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

            DateTime fi = DateTime.Parse(f1.ToString());
            DateTime ff = DateTime.Parse(f2.ToString());
            #region comprobar cual dgv se modifico
            if (tabcontrol.SelectedIndex == 0 && e.ColumnIndex >= 0 && dgvP1B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 1;
            }
            if (tabcontrol.SelectedIndex == 1 && e.ColumnIndex >= 0 && dgvP2B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 2;
            }
            if (tabcontrol.SelectedIndex == 2 && e.ColumnIndex >= 0 && dgvP3B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 3;
            }
            if (tabcontrol.SelectedIndex == 3 && e.ColumnIndex >= 0 && dgvP4B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 4;
            }
            if (tabcontrol.SelectedIndex == 4 && e.ColumnIndex >= 0 && dgvP5B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 5;
            }
            if (tabcontrol.SelectedIndex == 5 && e.ColumnIndex >= 0 && dgvP6B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 6;
            }
            if (tabcontrol.SelectedIndex == 6 && e.ColumnIndex >= 0 && dgvP7B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 7;
            }
            if (tabcontrol.SelectedIndex == 7 && e.ColumnIndex >= 0 && dgvP8B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 8;
            }
            if (tabcontrol.SelectedIndex == 8 && e.ColumnIndex >= 0 && dgvP9B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 9;
            }
            if (tabcontrol.SelectedIndex == 9 && e.ColumnIndex >= 0 && dgvP10B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 10;
            }
            if (tabcontrol.SelectedIndex == 10 && e.ColumnIndex >= 0 && dgvP11B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 11;
            }
            if (tabcontrol.SelectedIndex == 11 && e.ColumnIndex >= 0 && dgvP12B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dgv = 12;
            }
            #endregion
            switch (dgv)
            {
                case 1:
                    #region dgv1

                    if (dgvP1B.Rows[e.RowIndex].Cells[0].Value.ToString() != "PORCENTAJE" && e.ColumnIndex >= 1 && e.ColumnIndex <= dgvP1B.ColumnCount - 1)
                    {
                        unidadM = double.Parse(dgvP1B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        porcentajefinal = unidadM / double.Parse(dgvP1B.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                        dgvP1B.Rows[(e.RowIndex + 1)].Cells[e.ColumnIndex].Value = porcentajefinal.ToString("N2");
                        diferenciaU = unidadM - unidadesR;
                        for (int x = 1; x <= dgvP1B.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP1B.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP1B.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP1B.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaU);
                                dgvP1B.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N0");
                                unidadesFinal = porcentajefinal / double.Parse(dgvP1B.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                                dgvP1B.Rows[(e.RowIndex + 1)].Cells[y].Value = unidadesFinal.ToString("N2");
                            }
                        }

                    }
                    else
                    {
                        porcentajeM = double.Parse(dgvP1B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        unidadesFinal = porcentajeM * double.Parse(dgvP1B.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                        dgvP1B.Rows[(e.RowIndex - 1)].Cells[e.ColumnIndex].Value = unidadesFinal.ToString("N0");
                        diferenciaP = porcentajeM - porcentajeR;
                        for (int x = 1; x <= dgvP1B.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP1B.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP1B.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP1B.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaP);
                                dgvP1B.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N2");
                                unidadesFinal = porcentajefinal * double.Parse(dgvP1B.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                                dgvP1B.Rows[(e.RowIndex - 1)].Cells[y].Value = unidadesFinal.ToString("N0");
                            }
                        }
                    }
                    #endregion
                    break;
                case 2:
                    #region dgv1

                    if (dgvP2B.Rows[e.RowIndex].Cells[0].Value.ToString() != "PORCENTAJE" && e.ColumnIndex >= 1 && e.ColumnIndex <= dgvP2B.ColumnCount - 1)
                    {
                        unidadM = double.Parse(dgvP2B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        porcentajefinal = unidadM / double.Parse(dgvP2B.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                        dgvP2B.Rows[(e.RowIndex + 1)].Cells[e.ColumnIndex].Value = porcentajefinal.ToString("N2");
                        diferenciaU = unidadM - unidadesR;
                        for (int x = 1; x <= dgvP2B.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP2B.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP2B.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP2B.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaU);
                                dgvP2B.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N0");
                                unidadesFinal = porcentajefinal / double.Parse(dgvP2B.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                                dgvP2B.Rows[(e.RowIndex + 1)].Cells[y].Value = unidadesFinal.ToString("N2");
                            }
                        }

                    }
                    else
                    {
                        porcentajeM = double.Parse(dgvP2B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        unidadesFinal = porcentajeM * double.Parse(dgvP2B.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                        dgvP2B.Rows[(e.RowIndex - 1)].Cells[e.ColumnIndex].Value = unidadesFinal.ToString("N0");
                        diferenciaP = porcentajeM - porcentajeR;
                        for (int x = 1; x <= dgvP2B.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP2B.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP2B.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP2B.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaP);
                                dgvP2B.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N2");
                                unidadesFinal = porcentajefinal * double.Parse(dgvP2B.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                                dgvP2B.Rows[(e.RowIndex - 1)].Cells[y].Value = unidadesFinal.ToString("N0");
                            }
                        }
                    }
                    #endregion
                    break;
                case 3:
                    #region dgv1

                    if (dgvP3B.Rows[e.RowIndex].Cells[0].Value.ToString() != "PORCENTAJE" && e.ColumnIndex >= 1 && e.ColumnIndex <= dgvP3B.ColumnCount - 1)
                    {
                        unidadM = double.Parse(dgvP3B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        porcentajefinal = unidadM / double.Parse(dgvP3B.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                        dgvP3B.Rows[(e.RowIndex + 1)].Cells[e.ColumnIndex].Value = porcentajefinal.ToString("N2");
                        diferenciaU = unidadM - unidadesR;
                        for (int x = 1; x <= dgvP3B.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP3B.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP3B.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP3B.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaU);
                                dgvP3B.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N0");
                                unidadesFinal = porcentajefinal / double.Parse(dgvP3B.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                                dgvP3B.Rows[(e.RowIndex + 1)].Cells[y].Value = unidadesFinal.ToString("N2");
                            }
                        }

                    }
                    else
                    {
                        porcentajeM = double.Parse(dgvP3B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        unidadesFinal = porcentajeM * double.Parse(dgvP3B.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                        dgvP3B.Rows[(e.RowIndex - 1)].Cells[e.ColumnIndex].Value = unidadesFinal.ToString("N0");
                        diferenciaP = porcentajeM - porcentajeR;
                        for (int x = 1; x <= dgvP3B.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP3B.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP3B.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP3B.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaP);
                                dgvP3B.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N2");
                                unidadesFinal = porcentajefinal * double.Parse(dgvP3B.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                                dgvP3B.Rows[(e.RowIndex - 1)].Cells[y].Value = unidadesFinal.ToString("N0");
                            }
                        }
                    }
                    #endregion
                    break;
                case 4:
                    #region dgv1

                    if (dgvP4B.Rows[e.RowIndex].Cells[0].Value.ToString() != "PORCENTAJE" && e.ColumnIndex >= 1 && e.ColumnIndex <= dgvP4B.ColumnCount - 1)
                    {
                        unidadM = double.Parse(dgvP4B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        porcentajefinal = unidadM / double.Parse(dgvP4B.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                        dgvP4B.Rows[(e.RowIndex + 1)].Cells[e.ColumnIndex].Value = porcentajefinal.ToString("N2");
                        diferenciaU = unidadM - unidadesR;
                        for (int x = 1; x <= dgvP4B.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP4B.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP4B.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP4B.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaU);
                                dgvP4B.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N0");
                                unidadesFinal = porcentajefinal / double.Parse(dgvP4B.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                                dgvP4B.Rows[(e.RowIndex + 1)].Cells[y].Value = unidadesFinal.ToString("N2");
                            }
                        }

                    }
                    else
                    {
                        porcentajeM = double.Parse(dgvP4B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        unidadesFinal = porcentajeM * double.Parse(dgvP4B.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                        dgvP4B.Rows[(e.RowIndex - 1)].Cells[e.ColumnIndex].Value = unidadesFinal.ToString("N0");
                        diferenciaP = porcentajeM - porcentajeR;
                        for (int x = 1; x <= dgvP4B.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP4B.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP4B.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP4B.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaP);
                                dgvP4B.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N2");
                                unidadesFinal = porcentajefinal * double.Parse(dgvP4B.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                                dgvP4B.Rows[(e.RowIndex - 1)].Cells[y].Value = unidadesFinal.ToString("N0");
                            }
                        }
                    }
                    #endregion
                    break;
                case 5:
                    #region dgv1

                    if (dgvP5B.Rows[e.RowIndex].Cells[0].Value.ToString() != "PORCENTAJE" && e.ColumnIndex >= 1 && e.ColumnIndex <= dgvP5B.ColumnCount - 1)
                    {
                        unidadM = double.Parse(dgvP5B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        porcentajefinal = unidadM / double.Parse(dgvP5B.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                        dgvP5B.Rows[(e.RowIndex + 1)].Cells[e.ColumnIndex].Value = porcentajefinal.ToString("N2");
                        diferenciaU = unidadM - unidadesR;
                        for (int x = 1; x <= dgvP5B.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP5B.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP5B.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP5B.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaU);
                                dgvP5B.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N0");
                                unidadesFinal = porcentajefinal / double.Parse(dgvP5B.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                                dgvP5B.Rows[(e.RowIndex + 1)].Cells[y].Value = unidadesFinal.ToString("N2");
                            }
                        }

                    }
                    else
                    {
                        porcentajeM = double.Parse(dgvP5B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        unidadesFinal = porcentajeM * double.Parse(dgvP5B.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                        dgvP5B.Rows[(e.RowIndex - 1)].Cells[e.ColumnIndex].Value = unidadesFinal.ToString("N0");
                        diferenciaP = porcentajeM - porcentajeR;
                        for (int x = 1; x <= dgvP5B.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP5B.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP5B.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP5B.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaP);
                                dgvP5B.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N2");
                                unidadesFinal = porcentajefinal * double.Parse(dgvP5B.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                                dgvP5B.Rows[(e.RowIndex - 1)].Cells[y].Value = unidadesFinal.ToString("N0");
                            }
                        }
                    }
                    #endregion
                    break;
                case 6:
                    #region dgv1

                    if (dgvP6B.Rows[e.RowIndex].Cells[0].Value.ToString() != "PORCENTAJE" && e.ColumnIndex >= 1 && e.ColumnIndex <= dgvP6B.ColumnCount - 1)
                    {
                        unidadM = double.Parse(dgvP6B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        porcentajefinal = unidadM / double.Parse(dgvP6B.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                        dgvP6B.Rows[(e.RowIndex + 1)].Cells[e.ColumnIndex].Value = porcentajefinal.ToString("N2");
                        diferenciaU = unidadM - unidadesR;
                        for (int x = 1; x <= dgvP6B.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP6B.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP6B.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP6B.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaU);
                                dgvP6B.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N0");
                                unidadesFinal = porcentajefinal / double.Parse(dgvP6B.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                                dgvP6B.Rows[(e.RowIndex + 1)].Cells[y].Value = unidadesFinal.ToString("N2");
                            }
                        }

                    }
                    else
                    {
                        porcentajeM = double.Parse(dgvP6B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        unidadesFinal = porcentajeM * double.Parse(dgvP6B.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                        dgvP6B.Rows[(e.RowIndex - 1)].Cells[e.ColumnIndex].Value = unidadesFinal.ToString("N0");
                        diferenciaP = porcentajeM - porcentajeR;
                        for (int x = 1; x <= dgvP6B.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP6B.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP6B.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP6B.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaP);
                                dgvP6B.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N2");
                                unidadesFinal = porcentajefinal * double.Parse(dgvP6B.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                                dgvP6B.Rows[(e.RowIndex - 1)].Cells[y].Value = unidadesFinal.ToString("N0");
                            }
                        }
                    }
                    #endregion
                    break;
                case 7:
                    #region dgv1

                    if (dgvP7B.Rows[e.RowIndex].Cells[0].Value.ToString() != "PORCENTAJE" && e.ColumnIndex >= 1 && e.ColumnIndex <= dgvP7B.ColumnCount - 1)
                    {
                        unidadM = double.Parse(dgvP7B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        porcentajefinal = unidadM / double.Parse(dgvP7B.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                        dgvP7B.Rows[(e.RowIndex + 1)].Cells[e.ColumnIndex].Value = porcentajefinal.ToString("N2");
                        diferenciaU = unidadM - unidadesR;
                        for (int x = 1; x <= dgvP7B.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP7B.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP7B.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP7B.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaU);
                                dgvP7B.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N0");
                                unidadesFinal = porcentajefinal / double.Parse(dgvP7B.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                                dgvP7B.Rows[(e.RowIndex + 1)].Cells[y].Value = unidadesFinal.ToString("N2");
                            }
                        }

                    }
                    else
                    {
                        porcentajeM = double.Parse(dgvP7B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        unidadesFinal = porcentajeM * double.Parse(dgvP7B.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                        dgvP7B.Rows[(e.RowIndex - 1)].Cells[e.ColumnIndex].Value = unidadesFinal.ToString("N0");
                        diferenciaP = porcentajeM - porcentajeR;
                        for (int x = 1; x <= dgvP7B.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP7B.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP7B.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP7B.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaP);
                                dgvP7B.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N2");
                                unidadesFinal = porcentajefinal * double.Parse(dgvP7B.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                                dgvP7B.Rows[(e.RowIndex - 1)].Cells[y].Value = unidadesFinal.ToString("N0");
                            }
                        }
                    }
                    #endregion
                    break;
                case 8:
                    #region dgv1

                    if (dgvP8B.Rows[e.RowIndex].Cells[0].Value.ToString() != "PORCENTAJE" && e.ColumnIndex >= 1 && e.ColumnIndex <= dgvP8B.ColumnCount - 1)
                    {
                        unidadM = double.Parse(dgvP8B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        porcentajefinal = unidadM / double.Parse(dgvP8B.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                        dgvP8B.Rows[(e.RowIndex + 1)].Cells[e.ColumnIndex].Value = porcentajefinal.ToString("N2");
                        diferenciaU = unidadM - unidadesR;
                        for (int x = 1; x <= dgvP8B.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP8B.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP8B.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP8B.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaU);
                                dgvP8B.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N0");
                                unidadesFinal = porcentajefinal / double.Parse(dgvP8B.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                                dgvP8B.Rows[(e.RowIndex + 1)].Cells[y].Value = unidadesFinal.ToString("N2");
                            }
                        }

                    }
                    else
                    {
                        porcentajeM = double.Parse(dgvP8B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        unidadesFinal = porcentajeM * double.Parse(dgvP8B.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                        dgvP8B.Rows[(e.RowIndex - 1)].Cells[e.ColumnIndex].Value = unidadesFinal.ToString("N0");
                        diferenciaP = porcentajeM - porcentajeR;
                        for (int x = 1; x <= dgvP8B.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP8B.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP8B.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP8B.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaP);
                                dgvP8B.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N2");
                                unidadesFinal = porcentajefinal * double.Parse(dgvP8B.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                                dgvP8B.Rows[(e.RowIndex - 1)].Cells[y].Value = unidadesFinal.ToString("N0");
                            }
                        }
                    }
                    #endregion
                    break;
                case 9:
                    #region dgv1

                    if (dgvP9B.Rows[e.RowIndex].Cells[0].Value.ToString() != "PORCENTAJE" && e.ColumnIndex >= 1 && e.ColumnIndex <= dgvP9B.ColumnCount - 1)
                    {
                        unidadM = double.Parse(dgvP9B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        porcentajefinal = unidadM / double.Parse(dgvP9B.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                        dgvP9B.Rows[(e.RowIndex + 1)].Cells[e.ColumnIndex].Value = porcentajefinal.ToString("N2");
                        diferenciaU = unidadM - unidadesR;
                        for (int x = 1; x <= dgvP9B.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP9B.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP9B.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP9B.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaU);
                                dgvP9B.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N0");
                                unidadesFinal = porcentajefinal / double.Parse(dgvP9B.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                                dgvP9B.Rows[(e.RowIndex + 1)].Cells[y].Value = unidadesFinal.ToString("N2");
                            }
                        }

                    }
                    else
                    {
                        porcentajeM = double.Parse(dgvP9B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        unidadesFinal = porcentajeM * double.Parse(dgvP9B.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                        dgvP9B.Rows[(e.RowIndex - 1)].Cells[e.ColumnIndex].Value = unidadesFinal.ToString("N0");
                        diferenciaP = porcentajeM - porcentajeR;
                        for (int x = 1; x <= dgvP9B.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP9B.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP9B.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP9B.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaP);
                                dgvP9B.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N2");
                                unidadesFinal = porcentajefinal * double.Parse(dgvP9B.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                                dgvP9B.Rows[(e.RowIndex - 1)].Cells[y].Value = unidadesFinal.ToString("N0");
                            }
                        }
                    }
                    #endregion
                    break;
                case 10:
                    #region dgv1

                    if (dgvP10B.Rows[e.RowIndex].Cells[0].Value.ToString() != "PORCENTAJE" && e.ColumnIndex >= 1 && e.ColumnIndex <= dgvP10B.ColumnCount - 1)
                    {
                        unidadM = double.Parse(dgvP10B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        porcentajefinal = unidadM / double.Parse(dgvP10B.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                        dgvP10B.Rows[(e.RowIndex + 1)].Cells[e.ColumnIndex].Value = porcentajefinal.ToString("N2");
                        diferenciaU = unidadM - unidadesR;
                        for (int x = 1; x <= dgvP10B.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP10B.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP10B.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP10B.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaU);
                                dgvP10B.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N0");
                                unidadesFinal = porcentajefinal / double.Parse(dgvP10B.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                                dgvP10B.Rows[(e.RowIndex + 1)].Cells[y].Value = unidadesFinal.ToString("N2");
                            }
                        }

                    }
                    else
                    {
                        porcentajeM = double.Parse(dgvP10B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        unidadesFinal = porcentajeM * double.Parse(dgvP10B.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                        dgvP10B.Rows[(e.RowIndex - 1)].Cells[e.ColumnIndex].Value = unidadesFinal.ToString("N0");
                        diferenciaP = porcentajeM - porcentajeR;
                        for (int x = 1; x <= dgvP10B.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP10B.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP10B.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP10B.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaP);
                                dgvP10B.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N2");
                                unidadesFinal = porcentajefinal * double.Parse(dgvP10B.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                                dgvP10B.Rows[(e.RowIndex - 1)].Cells[y].Value = unidadesFinal.ToString("N0");
                            }
                        }
                    }
                    #endregion
                    break;
                case 11:
                    #region dgv1

                    if (dgvP11B.Rows[e.RowIndex].Cells[0].Value.ToString() != "PORCENTAJE" && e.ColumnIndex >= 1 && e.ColumnIndex <= dgvP11B.ColumnCount - 1)
                    {
                        unidadM = double.Parse(dgvP11B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        porcentajefinal = unidadM / double.Parse(dgvP11B.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                        dgvP11B.Rows[(e.RowIndex + 1)].Cells[e.ColumnIndex].Value = porcentajefinal.ToString("N2");
                        diferenciaU = unidadM - unidadesR;
                        for (int x = 1; x <= dgvP11B.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP11B.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP11B.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP11B.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaU);
                                dgvP11B.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N0");
                                unidadesFinal = porcentajefinal / double.Parse(dgvP11B.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                                dgvP11B.Rows[(e.RowIndex + 1)].Cells[y].Value = unidadesFinal.ToString("N2");
                            }
                        }

                    }
                    else
                    {
                        porcentajeM = double.Parse(dgvP11B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        unidadesFinal = porcentajeM * double.Parse(dgvP11B.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                        dgvP11B.Rows[(e.RowIndex - 1)].Cells[e.ColumnIndex].Value = unidadesFinal.ToString("N0");
                        diferenciaP = porcentajeM - porcentajeR;
                        for (int x = 1; x <= dgvP11B.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP11B.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP11B.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP11B.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaP);
                                dgvP11B.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N2");
                                unidadesFinal = porcentajefinal * double.Parse(dgvP11B.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                                dgvP11B.Rows[(e.RowIndex - 1)].Cells[y].Value = unidadesFinal.ToString("N0");
                            }
                        }
                    }
                    #endregion
                    break;
                case 12:
                    #region dgv1

                    if (dgvP12B.Rows[e.RowIndex].Cells[0].Value.ToString() != "PORCENTAJE" && e.ColumnIndex >= 1 && e.ColumnIndex <= dgvP12B.ColumnCount - 1)
                    {
                        unidadM = double.Parse(dgvP12B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        porcentajefinal = unidadM / double.Parse(dgvP12B.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                        dgvP12B.Rows[(e.RowIndex + 1)].Cells[e.ColumnIndex].Value = porcentajefinal.ToString("N2");
                        diferenciaU = unidadM - unidadesR;
                        for (int x = 1; x <= dgvP12B.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP12B.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP12B.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP12B.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaU);
                                dgvP12B.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N0");
                                unidadesFinal = porcentajefinal / double.Parse(dgvP12B.Rows[e.RowIndex].Cells[dgvH1.ColumnCount - 1].Value.ToString()) * 100;
                                dgvP12B.Rows[(e.RowIndex + 1)].Cells[y].Value = unidadesFinal.ToString("N2");
                            }
                        }

                    }
                    else
                    {
                        porcentajeM = double.Parse(dgvP12B.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        unidadesFinal = porcentajeM * double.Parse(dgvP12B.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                        dgvP12B.Rows[(e.RowIndex - 1)].Cells[e.ColumnIndex].Value = unidadesFinal.ToString("N0");
                        diferenciaP = porcentajeM - porcentajeR;
                        for (int x = 1; x <= dgvP12B.ColumnCount - 2; x++)
                        {
                            if (e.ColumnIndex != x)
                            {
                                sumaU += double.Parse(dgvP12B.Rows[e.RowIndex].Cells[x].Value.ToString());
                            }
                        }
                        for (int y = 1; y <= dgvP12B.ColumnCount - 2; y++)
                        {
                            if (e.ColumnIndex != y)
                            {
                                porcentajeActual = double.Parse(dgvP12B.Rows[e.RowIndex].Cells[y].Value.ToString());
                                porcentajeDif = porcentajeActual / sumaU;
                                porcentajefinal = porcentajeActual - (porcentajeDif * diferenciaP);
                                dgvP12B.Rows[e.RowIndex].Cells[y].Value = porcentajefinal.ToString("N2");
                                unidadesFinal = porcentajefinal * double.Parse(dgvP12B.Rows[(e.RowIndex - 1)].Cells[dgvH1.ColumnCount - 1].Value.ToString()) / 100;
                                dgvP12B.Rows[(e.RowIndex - 1)].Cells[y].Value = unidadesFinal.ToString("N0");
                            }
                        }
                    }
                    #endregion
                    break;
            }
            //calcularTotales(dgv);
        }
         public Cedula8(int selecc_sucursal, int selecc_division, int selecc_depto, int selecc_familia, int selecc_linea, int selecc_l1, int selecc_l2, int selecc_l3, int selecc_l4, int selecc_l5, int selecc_l6, string selecc_marca)
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
         private void toolStripMenuItem2_Click(object sender, EventArgs e)
         {
             Opciones op = new Opciones();
             this.Hide();
             op.ShowDialog();
             this.Close();
         }
         private void toolStripMenuItem3_Click(object sender, EventArgs e)
         {
             Log_in l = new Log_in();
             this.Hide();
             l.ShowDialog();
             this.Close();
         }
         private void m_ModelosUA(int mes,int año, int i)
         {
             double profundidad = 0;
             double unidades = 0;
            double totalPU = 0;
            año = año + 1;
            int x = 0;
            int row = 0;

            switch (i)
            {
                case 1:
                    #region Traer modelos
                    x = 0;
                    row = 1;
                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                    {
                        profundidad = 0;
                        unidades = 0;

                        string q = "Select profundidadA from cedula8 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
                        checaConexion();
                        cmd = new MySqlCommand(q, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["profundidadA"].ToString() == "")
                            {
                                profundidad = 0;
                            }
                            else
                            {
                                profundidad = double.Parse(reader["profundidadA"].ToString());
                            }
                        }
                        reader.Close();
                        for (int c = 1; c <= dgvP1A.Columns.Count - 2; c++)
                        {
                            if (profundidad >= 0)
                            {
                                unidades = (profundidad * double.Parse(dgvP1A.Rows[row].Cells[c].Value.ToString()))/100;
                            }
                            else { unidades = 0; }
                            dgvP1A.Rows[r].Cells[c].Value = unidades.ToString("n0");
                            totalPU += unidades;
                            dgvP1A.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("n0");
                        }
                        row = row + 2;
                        r++;
                        x++;
                    }
                    #endregion
                    break;
                case 2:
                    #region Traer modelos
                    x = 0;
                    row = 1;
                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                    {
                        profundidad = 0;
                        unidades = 0;

                        string q = "Select profundidadA from cedula8 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
                        checaConexion();
                        cmd = new MySqlCommand(q, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["profundidadA"].ToString() == "")
                            {
                                profundidad = 0;
                            }
                            else
                            {
                                profundidad = double.Parse(reader["profundidadA"].ToString());
                            }
                        }
                        reader.Close();
                        for (int c = 1; c <= dgvP2A.Columns.Count - 2; c++)
                        {
                            if (profundidad >= 0)
                            {
                                unidades = (profundidad * double.Parse(dgvP2A.Rows[row].Cells[c].Value.ToString()))/100;
                            }
                            else { unidades = 0; }
                            dgvP2A.Rows[r].Cells[c].Value = unidades.ToString("n0");
                            totalPU += unidades;
                            dgvP2A.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("n0");
                        }
                        row = row + 2;
                        r++;
                        x++;
                    }
                    #endregion
                    break;
                case 3:
                    #region Traer modelos
                    x = 0;
                    row = 1;
                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                    {
                        profundidad = 0;
                        unidades = 0;

                        string q = "Select profundidadA from cedula8 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
                        checaConexion();
                        cmd = new MySqlCommand(q, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["profundidadA"].ToString() == "")
                            {
                                profundidad = 0;
                            }
                            else
                            {
                                profundidad = double.Parse(reader["profundidadA"].ToString());
                            }
                        }
                        reader.Close();
                        for (int c = 1; c <= dgvP3A.Columns.Count - 2; c++)
                        {
                            if (profundidad >= 0)
                            {
                                unidades = (profundidad * double.Parse(dgvP3A.Rows[row].Cells[c].Value.ToString()))/100;
                            }
                            else { unidades = 0; }
                            dgvP3A.Rows[r].Cells[c].Value = unidades.ToString("n0");
                            totalPU += unidades;
                            dgvP3A.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("n0");
                        }
                        row = row + 2;
                        r++;
                        x++;
                    }
                    #endregion
                    break;
                case 4:
                    #region Traer modelos
                    x = 0;
                    row = 1;
                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                    {
                        profundidad = 0;
                        unidades = 0;

                        string q = "Select profundidadA from cedula8 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
                        checaConexion();
                        cmd = new MySqlCommand(q, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["profundidadA"].ToString() == "")
                            {
                                profundidad = 0;
                            }
                            else
                            {
                                profundidad = double.Parse(reader["profundidadA"].ToString());
                            }
                        }
                        reader.Close();
                        for (int c = 1; c <= dgvP4A.Columns.Count - 2; c++)
                        {
                            if (profundidad >= 0)
                            {
                                unidades = (profundidad * double.Parse(dgvP4A.Rows[row].Cells[c].Value.ToString()))/100;
                            }
                            else { unidades = 0; }
                            dgvP4A.Rows[r].Cells[c].Value = unidades.ToString("n0");
                            totalPU += unidades;
                            dgvP4A.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("n0");
                        }
                        row = row + 2;
                        r++;
                        x++;
                    }
                    #endregion
                    break;
                case 5:
                    #region Traer modelos
                    x = 0;
                    row = 1;
                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                    {
                        profundidad = 0;
                        unidades = 0;

                        string q = "Select profundidadA from cedula8 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
                        checaConexion();
                        cmd = new MySqlCommand(q, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["profundidadA"].ToString() == "")
                            {
                                profundidad = 0;
                            }
                            else
                            {
                                profundidad = double.Parse(reader["profundidadA"].ToString());
                            }
                        }
                        reader.Close();
                        for (int c = 1; c <= dgvP5A.Columns.Count - 2; c++)
                        {
                            if (profundidad >= 0)
                            {
                                unidades = (profundidad * double.Parse(dgvP5A.Rows[row].Cells[c].Value.ToString()))/100;
                            }
                            else { unidades = 0; }
                            dgvP5A.Rows[r].Cells[c].Value = unidades.ToString("n0");
                            totalPU += unidades;
                            dgvP5A.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("n0");
                        }
                        row = row + 2;
                        r++;
                        x++;
                    }
                    #endregion
                    break;
                case 6:
                    #region Traer modelos
                    x = 0;
                    row = 1;
                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                    {
                        profundidad = 0;
                        unidades = 0;

                        string q = "Select profundidadA from cedula8 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
                        checaConexion();
                        cmd = new MySqlCommand(q, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["profundidadA"].ToString() == "")
                            {
                                profundidad = 0;
                            }
                            else
                            {
                                profundidad = double.Parse(reader["profundidadA"].ToString());
                            }
                        }
                        reader.Close();
                        for (int c = 1; c <= dgvP6A.Columns.Count - 2; c++)
                        {
                            if (profundidad >= 0)
                            {
                                unidades = (profundidad * double.Parse(dgvP6A.Rows[row].Cells[c].Value.ToString()))/100;
                            }
                            else { unidades = 0; }
                            dgvP6A.Rows[r].Cells[c].Value = unidades.ToString("n0");
                            totalPU += unidades;
                            dgvP6A.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("n0");
                        }
                        row = row + 2;
                        r++;
                        x++;
                    }
                    #endregion
                    break;
                case 7:
                    #region Traer modelos
                    x = 0;
                    row = 1;
                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                    {
                        profundidad = 0;
                        unidades = 0;

                        string q = "Select profundidadA from cedula8 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
                        checaConexion();
                        cmd = new MySqlCommand(q, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["profundidadA"].ToString() == "")
                            {
                                profundidad = 0;
                            }
                            else
                            {
                                profundidad = double.Parse(reader["profundidadA"].ToString());
                            }
                        }
                        reader.Close();
                        for (int c = 1; c <= dgvP7A.Columns.Count - 2; c++)
                        {
                            if (profundidad >= 0)
                            {
                                unidades = (profundidad * double.Parse(dgvP7A.Rows[row].Cells[c].Value.ToString()))/100;
                            }
                            else { unidades = 0; }
                            dgvP7A.Rows[r].Cells[c].Value = unidades.ToString("n0");
                            totalPU += unidades;
                            dgvP7A.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("n0");
                        }
                        row = row + 2;
                        r++;
                        x++;
                    }
                    #endregion
                    break;
                case 8:
                    #region Traer modelos
                    x = 0;
                    row = 1;
                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                    {
                        profundidad = 0;
                        unidades = 0;

                        string q = "Select profundidadA from cedula8 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
                        cmd = new MySqlCommand(q, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["profundidadA"].ToString() == "")
                            {
                                profundidad = 0;
                            }
                            else
                            {
                                profundidad = double.Parse(reader["profundidadA"].ToString());
                            }
                        }
                        reader.Close();
                        for (int c = 1; c <= dgvP8A.Columns.Count - 2; c++)
                        {
                            if (profundidad >= 0)
                            {
                                unidades = (profundidad * double.Parse(dgvP8A.Rows[row].Cells[c].Value.ToString()))/100;
                            }
                            else { unidades = 0; }
                            dgvP8A.Rows[r].Cells[c].Value = unidades.ToString("n0");
                            totalPU += unidades;
                            dgvP8A.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("n0");
                        }
                        row = row + 2;
                        r++;
                        x++;
                    }
                    #endregion
                    break;
                case 9:
                    #region Traer modelos
                    x = 0;
                    row = 1;
                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                    {
                        profundidad = 0;
                        unidades = 0;

                        string q = "Select profundidadA from cedula8 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
                        cmd = new MySqlCommand(q, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["profundidadA"].ToString() == "")
                            {
                                profundidad = 0;
                            }
                            else
                            {
                                profundidad = double.Parse(reader["profundidadA"].ToString());
                            }
                        }
                        reader.Close();
                        for (int c = 1; c <= dgvP9A.Columns.Count - 2; c++)
                        {
                            if (profundidad >= 0)
                            {
                                unidades = (profundidad * double.Parse(dgvP9A.Rows[row].Cells[c].Value.ToString()))/100;
                            }
                            else { unidades = 0; }
                            dgvP9A.Rows[r].Cells[c].Value = unidades.ToString("n0");
                            totalPU += unidades;
                            dgvP9A.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("n0");
                        }
                        row = row + 2;
                        r++;
                        x++;
                    }
                    #endregion
                    break;
                case 10:
                    #region Traer modelos
                    x = 0;
                    row = 1;
                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                    {
                        profundidad = 0;
                        unidades = 0;

                        string q = "Select profundidadA from cedula8 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
                        cmd = new MySqlCommand(q, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["profundidadA"].ToString() == "")
                            {
                                profundidad = 0;
                            }
                            else
                            {
                                profundidad = double.Parse(reader["profundidadA"].ToString());
                            }
                        }
                        reader.Close();
                        for (int c = 1; c <= dgvP10A.Columns.Count - 2; c++)
                        {
                            if (profundidad >= 0)
                            {
                                unidades = (profundidad * double.Parse(dgvP10A.Rows[row].Cells[c].Value.ToString()))/100;
                            }
                            else { unidades = 0; }
                            dgvP10A.Rows[r].Cells[c].Value = unidades.ToString("n0");
                            totalPU += unidades;
                            dgvP10A.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("n0");
                        }
                        row = row + 2;
                        r++;
                        x++;
                    }
                    #endregion
                    break;
                case 11:
                    #region Traer modelos
                    x = 0;
                    row = 1;
                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                    {
                        profundidad = 0;
                        unidades = 0;

                        string q = "Select profundidadA from cedula8 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
                        cmd = new MySqlCommand(q, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["profundidadA"].ToString() == "")
                            {
                                profundidad = 0;
                            }
                            else
                            {
                                profundidad = double.Parse(reader["profundidadA"].ToString());
                            }
                        }
                        reader.Close();
                        for (int c = 1; c <= dgvP11A.Columns.Count - 2; c++)
                        {
                            if (profundidad >= 0)
                            {
                                unidades = (profundidad * double.Parse(dgvP11A.Rows[row].Cells[c].Value.ToString()))/100;
                            }
                            else { unidades = 0; }
                            dgvP11A.Rows[r].Cells[c].Value = unidades.ToString("n0");
                            totalPU += unidades;
                            dgvP11A.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("n0");
                        }
                        row = row + 2;
                        r++;
                        x++;
                    }
                    #endregion
                    break;
                case 12:
                    #region Traer modelos
                    x = 0;
                    row = 1;
                    for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                    {
                        profundidad = 0;
                        unidades = 0;

                        string q = "Select profundidadA from cedula8 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
                        cmd = new MySqlCommand(q, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["profundidadA"].ToString() == "")
                            {
                                profundidad = 0;
                            }
                            else
                            {
                                profundidad = double.Parse(reader["profundidadA"].ToString());
                            }
                        }
                        reader.Close();
                        for (int c = 1; c <= dgvP12A.Columns.Count - 2; c++)
                        {
                            if (profundidad >= 0)
                            {
                                unidades = (profundidad * double.Parse(dgvP12A.Rows[row].Cells[c].Value.ToString()))/100;
                            }
                            else { unidades = 0; }
                            dgvP12A.Rows[r].Cells[c].Value = unidades.ToString("n0");
                            totalPU += unidades;
                            dgvP12A.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("n0");
                        }
                        row = row + 2;
                        r++;
                        x++;
                    }
                    #endregion
                    break;
            }
         }
         private void m_ModelosUB(int mes, int año, int i)
         {
             double profundidad = 0;
             double unidades = 0;
             double totalPU = 0;
             año = año + 1;
             int x = 0;
             int row = 0;

             switch (i)
             {
                 case 1:
                     #region Traer modelos
                     x = 0;
                     row = 1;
                     for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                     {
                         profundidad = 0;
                         unidades = 0;

                         string q = "Select profundidadB from cedula8 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
                         checaConexion();
                         cmd = new MySqlCommand(q, Conn);
                         reader = cmd.ExecuteReader();
                         while (reader.Read())
                         {
                             if (reader["profundidadB"].ToString() == "")
                             {
                                 profundidad = 0;
                             }
                             else
                             {
                                 profundidad = double.Parse(reader["profundidadB"].ToString());
                             }
                         }
                         reader.Close();
                         for (int c = 1; c <= dgvP1B.Columns.Count - 2; c++)
                         {
                             if (profundidad >= 0)
                             {
                                 unidades = (profundidad * double.Parse(dgvP1B.Rows[row].Cells[c].Value.ToString())) / 100;
                             }
                             else { unidades = 0; }
                             dgvP1B.Rows[r].Cells[c].Value = unidades.ToString("N0");
                             totalPU += unidades;
                             dgvP1B.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("N0");
                         }
                         row = row + 2;
                         r++;
                         x++;
                     }
                     #endregion
                     break;
                 case 2:
                     #region Traer modelos
                     x = 0;
                     row = 1;
                     for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                     {
                         profundidad = 0;
                         unidades = 0;

                         string q = "Select profundidadB from cedula8 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
                         checaConexion();
                         cmd = new MySqlCommand(q, Conn);
                         reader = cmd.ExecuteReader();
                         while (reader.Read())
                         {
                             if (reader["profundidadB"].ToString() == "")
                             {
                                 profundidad = 0;
                             }
                             else
                             {
                                 profundidad = double.Parse(reader["profundidadB"].ToString());
                             }
                         }
                         reader.Close();
                         for (int c = 1; c <= dgvP2B.Columns.Count - 2; c++)
                         {
                             if (profundidad >= 0)
                             {
                                 unidades = (profundidad * double.Parse(dgvP2B.Rows[row].Cells[c].Value.ToString())) / 100;
                             }
                             else { unidades = 0; }
                             dgvP2B.Rows[r].Cells[c].Value = unidades.ToString("N0");
                             totalPU += unidades;
                             dgvP2B.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("N0");
                         }
                         row = row + 2;
                         r++;
                         x++;
                     }
                     #endregion
                     break;
                 case 3:
                     #region Traer modelos
                     x = 0;
                     row = 1;
                     for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                     {
                         profundidad = 0;
                         unidades = 0;

                         string q = "Select profundidadB from cedula8 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
                         checaConexion();
                         cmd = new MySqlCommand(q, Conn);
                         reader = cmd.ExecuteReader();
                         while (reader.Read())
                         {
                             if (reader["profundidadB"].ToString() == "")
                             {
                                 profundidad = 0;
                             }
                             else
                             {
                                 profundidad = double.Parse(reader["profundidadB"].ToString());
                             }
                         }
                         reader.Close();
                         for (int c = 1; c <= dgvP3B.Columns.Count - 2; c++)
                         {
                             if (profundidad >= 0)
                             {
                                 unidades = (profundidad * double.Parse(dgvP3B.Rows[row].Cells[c].Value.ToString())) / 100;
                             }
                             else { unidades = 0; }
                             dgvP3B.Rows[r].Cells[c].Value = unidades.ToString("N0");
                             totalPU += unidades;
                             dgvP3B.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("N0");
                         }
                         row = row + 2;
                         r++;
                         x++;
                     }
                     #endregion
                     break;
                 case 4:
                     #region Traer modelos
                     x = 0;
                     row = 1;
                     for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                     {
                         profundidad = 0;
                         unidades = 0;

                         string q = "Select profundidadB from cedula8 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
                         checaConexion();
                         cmd = new MySqlCommand(q, Conn);
                         reader = cmd.ExecuteReader();
                         while (reader.Read())
                         {
                             if (reader["profundidadB"].ToString() == "")
                             {
                                 profundidad = 0;
                             }
                             else
                             {
                                 profundidad = double.Parse(reader["profundidadB"].ToString());
                             }
                         }
                         reader.Close();
                         for (int c = 1; c <= dgvP4B.Columns.Count - 2; c++)
                         {
                             if (profundidad >= 0)
                             {
                                 unidades = (profundidad * double.Parse(dgvP4B.Rows[row].Cells[c].Value.ToString())) / 100;
                             }
                             else { unidades = 0; }
                             dgvP4B.Rows[r].Cells[c].Value = unidades.ToString("N0");
                             totalPU += unidades;
                             dgvP4B.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("N0");
                         }
                         row = row + 2;
                         r++;
                         x++;
                     }
                     #endregion
                     break;
                 case 5:
                     #region Traer modelos
                     x = 0;
                     row = 1;
                     for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                     {
                         profundidad = 0;
                         unidades = 0;

                         string q = "Select profundidadB from cedula8 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
                         checaConexion();
                         cmd = new MySqlCommand(q, Conn);
                         reader = cmd.ExecuteReader();
                         while (reader.Read())
                         {
                             if (reader["profundidadB"].ToString() == "")
                             {
                                 profundidad = 0;
                             }
                             else
                             {
                                 profundidad = double.Parse(reader["profundidadB"].ToString());
                             }
                         }
                         reader.Close();
                         for (int c = 1; c <= dgvP5B.Columns.Count - 2; c++)
                         {
                             if (profundidad >= 0)
                             {
                                 unidades = (profundidad * double.Parse(dgvP5B.Rows[row].Cells[c].Value.ToString())) / 100;
                             }
                             else { unidades = 0; }
                             dgvP5B.Rows[r].Cells[c].Value = unidades.ToString("N0");
                             totalPU += unidades;
                             dgvP5B.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("N0");
                         }
                         row = row + 2;
                         r++;
                         x++;
                     }
                     #endregion
                     break;
                 case 6:
                     #region Traer modelos
                     x = 0;
                     row = 1;
                     for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                     {
                         profundidad = 0;
                         unidades = 0;

                         string q = "Select profundidadB from cedula8 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
                         checaConexion();
                         cmd = new MySqlCommand(q, Conn);
                         reader = cmd.ExecuteReader();
                         while (reader.Read())
                         {
                             if (reader["profundidadB"].ToString() == "")
                             {
                                 profundidad = 0;
                             }
                             else
                             {
                                 profundidad = double.Parse(reader["profundidadB"].ToString());
                             }
                         }
                         reader.Close();
                         for (int c = 1; c <= dgvP6B.Columns.Count - 2; c++)
                         {
                             if (profundidad >= 0)
                             {
                                 unidades = (profundidad * double.Parse(dgvP6B.Rows[row].Cells[c].Value.ToString())) / 100;
                             }
                             else { unidades = 0; }
                             dgvP6B.Rows[r].Cells[c].Value = unidades.ToString("N0");
                             totalPU += unidades;
                             dgvP6B.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("N0");
                         }
                         row = row + 2;
                         r++;
                         x++;
                     }
                     #endregion
                     break;
                 case 7:
                     #region Traer modelos
                     x = 0;
                     row = 1;
                     for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                     {
                         profundidad = 0;
                         unidades = 0;

                         string q = "Select profundidadB from cedula8 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
                         checaConexion();
                         cmd = new MySqlCommand(q, Conn);
                         reader = cmd.ExecuteReader();
                         while (reader.Read())
                         {
                             if (reader["profundidadB"].ToString() == "")
                             {
                                 profundidad = 0;
                             }
                             else
                             {
                                 profundidad = double.Parse(reader["profundidadB"].ToString());
                             }
                         }
                         reader.Close();
                         for (int c = 1; c <= dgvP7B.Columns.Count - 2; c++)
                         {
                             if (profundidad >= 0)
                             {
                                 unidades = (profundidad * double.Parse(dgvP7B.Rows[row].Cells[c].Value.ToString())) / 100;
                             }
                             else { unidades = 0; }
                             dgvP7B.Rows[r].Cells[c].Value = unidades.ToString("N0");
                             totalPU += unidades;
                             dgvP7B.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("N0");
                         }
                         row = row + 2;
                         r++;
                         x++;
                     }
                     #endregion
                     break;
                 case 8:
                     #region Traer modelos
                     x = 0;
                     row = 1;
                     for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                     {
                         profundidad = 0;
                         unidades = 0;

                         string q = "Select profundidadB from cedula8 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
                         checaConexion();
                         cmd = new MySqlCommand(q, Conn);
                         reader = cmd.ExecuteReader();
                         while (reader.Read())
                         {
                             if (reader["profundidadB"].ToString() == "")
                             {
                                 profundidad = 0;
                             }
                             else
                             {
                                 profundidad = double.Parse(reader["profundidadB"].ToString());
                             }
                         }
                         reader.Close();
                         for (int c = 1; c <= dgvP8B.Columns.Count - 2; c++)
                         {
                             if (profundidad >= 0)
                             {
                                 unidades = (profundidad * double.Parse(dgvP8B.Rows[row].Cells[c].Value.ToString())) / 100;
                             }
                             else { unidades = 0; }
                             dgvP8B.Rows[r].Cells[c].Value = unidades.ToString("N0");
                             totalPU += unidades;
                             dgvP8B.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("N0");
                         }
                         row = row + 2;
                         r++;
                         x++;
                     }
                     #endregion
                     break;
                 case 9:
                     #region Traer modelos
                     x = 0;
                     row = 1;
                     for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                     {
                         profundidad = 0;
                         unidades = 0;

                         string q = "Select profundidadB from cedula8 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x];
                         checaConexion();
                         cmd = new MySqlCommand(q, Conn);
                         reader = cmd.ExecuteReader();
                         while (reader.Read())
                         {
                             if (reader["profundidadB"].ToString() == "")
                             {
                                 profundidad = 0;
                             }
                             else
                             {
                                 profundidad = double.Parse(reader["profundidadB"].ToString());
                             }
                         }
                         reader.Close();
                         for (int c = 1; c <= dgvP9B.Columns.Count - 2; c++)
                         {
                             if (profundidad >= 0)
                             {
                                 unidades = (profundidad * double.Parse(dgvP9B.Rows[row].Cells[c].Value.ToString())) / 100;
                             }
                             else { unidades = 0; }
                             dgvP9B.Rows[r].Cells[c].Value = unidades.ToString("N0");
                             totalPU += unidades;
                             dgvP9B.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("N0");
                         }
                         row = row + 2;
                         r++;
                         x++;
                     }
                     #endregion
                     break;
                 case 10:
                     #region Traer modelos
                     x = 0;
                     row = 1;
                     for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                     {
                         profundidad = 0;
                         unidades = 0;

                         string q = "Select profundidadB from cedula8 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x]; checaConexion();
                         cmd = new MySqlCommand(q, Conn);
                         reader = cmd.ExecuteReader();
                         while (reader.Read())
                         {
                             if (reader["profundidadB"].ToString() == "")
                             {
                                 profundidad = 0;
                             }
                             else
                             {
                                 profundidad = double.Parse(reader["profundidadB"].ToString());
                             }
                         }
                         reader.Close();
                         for (int c = 1; c <= dgvP10B.Columns.Count - 2; c++)
                         {
                             if (profundidad >= 0)
                             {
                                 unidades = (profundidad * double.Parse(dgvP10B.Rows[row].Cells[c].Value.ToString())) / 100;
                             }
                             else { unidades = 0; }
                             dgvP10B.Rows[r].Cells[c].Value = unidades.ToString("N0");
                             totalPU += unidades;
                             dgvP10B.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("N0");
                         }
                         row = row + 2;
                         r++;
                         x++;
                     }
                     #endregion
                     break;
                 case 11:
                     #region Traer modelos
                     x = 0;
                     row = 1;
                     for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                     {
                         profundidad = 0;
                         unidades = 0;

                         string q = "Select profundidadB from cedula8 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x]; checaConexion();
                         cmd = new MySqlCommand(q, Conn);
                         reader = cmd.ExecuteReader();
                         while (reader.Read())
                         {
                             if (reader["profundidadB"].ToString() == "")
                             {
                                 profundidad = 0;
                             }
                             else
                             {
                                 profundidad = double.Parse(reader["profundidadB"].ToString());
                             }
                         }
                         reader.Close();
                         for (int c = 1; c <= dgvP11B.Columns.Count - 2; c++)
                         {
                             if (profundidad >= 0)
                             {
                                 unidades = (profundidad * double.Parse(dgvP11B.Rows[row].Cells[c].Value.ToString())) / 100;
                             }
                             else { unidades = 0; }
                             dgvP11B.Rows[r].Cells[c].Value = unidades.ToString("N0");
                             totalPU += unidades;
                             dgvP11B.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("N0");
                         }
                         row = row + 2;
                         r++;
                         x++;
                     }
                     #endregion
                     break;
                 case 12:
                     #region Traer modelos
                     x = 0;
                     row = 1;
                     for (int r = 0; r <= dgvH1.Rows.Count - 1; r++)
                     {
                         profundidad = 0;
                         unidades = 0;

                         string q = "Select profundidadB from cedula8 where anio=" + año + " and mes=" + mes + " and  nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[x]; checaConexion();
                         cmd = new MySqlCommand(q, Conn);
                         reader = cmd.ExecuteReader();
                         while (reader.Read())
                         {
                             if (reader["profundidadB"].ToString() == "")
                             {
                                 profundidad = 0;
                             }
                             else
                             {
                                 profundidad = double.Parse(reader["profundidadB"].ToString());
                             }
                         }
                         reader.Close();
                         for (int c = 1; c <= dgvP12B.Columns.Count - 2; c++)
                         {
                             if (profundidad >= 0)
                             {
                                 unidades = (profundidad * double.Parse(dgvP12B.Rows[row].Cells[c].Value.ToString())) / 100;
                             }
                             else { unidades = 0; }
                             dgvP12B.Rows[r].Cells[c].Value = unidades.ToString("N0");
                             totalPU += unidades;
                             dgvP12B.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalPU.ToString("N0");
                         }
                         row = row + 2;
                         r++;
                         x++;
                     }
                     #endregion
                     break;
             }
         }
         private void btnRefresh_Click(object sender, EventArgs e)
         {
             m_CLEAR_DGVS();
             m_GENERARDGVS_Estructura();

             int i = 0;
             cmd = new MySqlCommand(query, Conn);
             reader = cmd.ExecuteReader();
             while (reader.Read())
             {
                 dgvH1.Refresh();
                 dgvH1.Rows.Add();
                 dgvH1.Rows[i].Cells[0].Value = reader["descrip"].ToString();
                 m_ADDROWS(reader["descrip"].ToString(), i);
                 dgvH1.Rows.Add();
                 i++;

                 dgvH1.Rows[i].Cells[0].Value = "PORCENTAJE";
                 m_ADDROWS("PORCENTAJE", i);
                 i++;

             }
             reader.Close();
             button1.Enabled = true;
             m_propiedades_grid();
             m_regleta();
             m_DIASMESESANOS_Refresh(CED1_fechaI, CED1_fechaF);
         }
         public void m_DIASMESESANOS_Refresh(string fecha_inicio, string fecha_final) /////////////////////////////se usa en todos 
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
                         try
                         {
                             m_TABS(fecha_inicio_mes, fecha_inicio_ano + 1);/////////////////////se usa en todos 
                            m_CalcularHistoricoU(i, fecha_inicio_mes, fecha_inicio_ano);
                            m_CalcularHistoricoP(i);
                            m_ModelosUA(fecha_inicio_mes, fecha_inicio_ano, i);
                            m_ModelosUB(fecha_inicio_mes, fecha_inicio_ano, i);

                            //m_calcularProyectadoU(i, fecha_inicio_mes, fecha_inicio_ano);
                            //m_REFRESH_DGVS(i);
                            //m_calcularProyectadoP(i);
                            m_REFRESH_DGVS(i);
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
                             m_TABS(fecha_inicio_mes, fecha_inicio_ano + 1);
                            
                            m_CalcularHistoricoU(i, fecha_inicio_mes, fecha_inicio_ano);
                            m_CalcularHistoricoP(i);
                            m_calcularProyectadoU(i, fecha_inicio_mes, fecha_inicio_ano);
                            m_REFRESH_DGVS(i);
                            m_calcularProyectadoP(i);
                            m_REFRESH_DGVS(i);
                             tabcontrol.SelectedIndex = tabcontrol.SelectedIndex + 1;
                         }
                         catch (Exception x)
                         { MessageBox.Show("Error con las fechas " + x); }
                 }
                 fecha_inicio_mes = 1;
             }
             #endregion

             tabcontrol.SelectedIndex = 0;

             ///////////////////////////////////


         }
         public void generar_cedula8Automatico(object sender, EventArgs e)
         {
             proyectar = true;

             cbSucursales_DropDown(sender, e);

             pbGenerar.Value = 0;
             if (cbSucursales.Items.Count != -1)
                 for (int ss = 0; ss < cbSucursales.Items.Count; ss++)
                 {

                     cbSucursales_DropDown(sender, e);
                     cbSucursales.SelectedIndex = ss;
                      
                     if (ss == 0)
                     {
                         m_DIASMESESANOS(CED1_fechaI, CED1_fechaF);

                         m_DIASMESESANOS_guardar(CED1_fechaI, CED1_fechaF);
                     }
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
                                  

                                 if (dd == 0)
                                 {
                                     m_DIASMESESANOS(CED1_fechaI, CED1_fechaF);

                                     m_DIASMESESANOS_guardar(CED1_fechaI, CED1_fechaF);
                                 }
                                 if (dd != 0)
                                 {

                                     //departamento

                                     cbDepto_DropDown(sender, e);
                                     if (cbDepto.Items.Count >= 2)
                                         for (int dp = 0; dp < cbDepto.Items.Count; dp++)
                                         {

                                             cbDepto_DropDown(sender, e);
                                             cbDepto.SelectedIndex = dp;
                                              

                                             if (dp == 0)
                                             {
                                                 m_DIASMESESANOS(CED1_fechaI, CED1_fechaF);

                                                 m_DIASMESESANOS_guardar(CED1_fechaI, CED1_fechaF);
                                             }
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
                                                          

                                                         if (fm == 0)
                                                         {
                                                             m_DIASMESESANOS(CED1_fechaI, CED1_fechaF);

                                                             m_DIASMESESANOS_guardar(CED1_fechaI, CED1_fechaF);
                                                         }
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
                                                                      

                                                                     if (ln == 0)
                                                                     {
                                                                         m_DIASMESESANOS(CED1_fechaI, CED1_fechaF);

                                                                         m_DIASMESESANOS_guardar(CED1_fechaI, CED1_fechaF);
                                                                     }
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

             proyectar = false;
             PanelCedulafinalizada.Visible = true;
         }
         public Cedula8(bool genera)
         {
             generarCedula8 = genera;
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
         private void ConsultaProyectado(int mes, int anio, int grid)
         {
             string fecha_inicio = anio.ToString() + "-" + mes.ToString("d2") + "-01";
             string fecha_final = anio.ToString() + "-" + (mes + 1).ToString("d2") + "-01";
             string ifnullnoSuc = ""; string selectNosuc = ""; string ifnull = ""; string groupbynosuc = ""; string whereQ = "";
             if (where != "")
             {
                 whereQ = "  " + where.Replace("e.", "V.");

             }
             else
             {
                 whereQ = "";
             }
             if (soloSuc == false)
             {
                 ifnull = "v." + groupby;
                 ifnullnoSuc = "V.iddivisiones,0";
                 selectNosuc = "";
                 groupbynosuc = "";
             }
             else
             {
                 ifnull = "V." + groupby;
                 ifnullnoSuc = "sub." + groupby + ", " + ifnull;
                 selectNosuc = "V." + groupby;
                 groupbynosuc = "GROUP BY v." + groupby;
             }
             string consulta = "";
             consulta = "SELECT ifnull(SUM(ctdneta),0) AS cantidad,ifnull(v.`medida`,0) AS medida , "+ifnull+" AS grupo FROM ventasbase AS v INNER JOIN fecha AS f ON v.idfecha=f.idfecha WHERE f.mes="+mes+" AND f.anio="+anio+" AND v.medida BETWEEN "+numeroMenor+" AND "+numeromayor+" "+whereLeft+" "+whereQ+" GROUP BY v.`medida` ORDER BY v.`medida` ASC ";
             cmd = new MySqlCommand(consulta, Conn);
             reader = cmd.ExecuteReader();
             while (reader.Read())
             {
                 for (int c = 1; c <= dgvH1.Columns.Count - 2; c++)
                 {
                     string MedidaColumna = dgvH1.Columns[c].HeaderText;
                     if(double.Parse(MedidaColumna)<=9.9)
                     {
                         MedidaColumna = "0"+MedidaColumna;
                     }
                     if (MedidaColumna.Contains(".5"))
                     {
                         MedidaColumna = MedidaColumna.Replace(".5", "-");
                     }
                     if (reader["medida"].ToString() == MedidaColumna)
                     {
                        if(total==true)
                        {
                            bool existe = false; int x = 1;
                            int  r = 0;
                            while (existe == false)
                            {
                                //llenar
                                if (idd.Contains(reader["grupo"].ToString()))
                                {
                                    if (reader["grupo"].ToString() == idd[x])
                                    {
                                        m_llenargrid(r, c, grid, reader["cantidad"].ToString(), 1);
                                        existe = true;
                                    }
                                }
                                else
                                {
                                    existe = true;
                                }
                                x++;
                                r = r + 2;
                            }
                        }
                         else
                        {
                            m_llenargrid(0, c, grid, reader["cantidad"].ToString(), 1);
                            c = dgvH1.ColumnCount;
                        }
                     }
                     nulos(grid,c);
                 }
             }
             reader.Close();
             #region suma
             //dgvH1.Rows[r].Cells[dgvH1.ColumnCount - 1].Value = totalHU;
             for(int r=0;r<=dgvH1.Rows.Count-1;r++)
             {
                 double val = 0;
                 for(int c=1;c<=dgvH1.ColumnCount-2;c++)
                 {
                     val+= double.Parse(m_leergrid(r,c,grid,1));
                 }
                 m_llenargrid(r,( dgvH1.ColumnCount - 1), grid, val.ToString(), 1);
             }
             #endregion
         }
         private void nulos(int grid, int columna)
         {
             for (int i = 0; i <= dgvH1.Rows.Count - 1; i++)
             {
                 switch (grid)
                 {
                     case 1:
                         #region grid1
                         if (dgvH1.Rows[i].Cells[columna].Value == null)
                         {
                                 dgvH1.Rows[i].Cells[columna].Value = "0";
                         }
                         #endregion
                         break;
                     case 2:
                         #region grid2
                         if (dgvH2.Rows[i].Cells[columna].Value == null)
                         {
                             dgvH2.Rows[i].Cells[columna].Value = "0";
                         }
                         #endregion
                         break;
                     case 3:
                         #region grid3
                         if (dgvH3.Rows[i].Cells[columna].Value == null)
                         {
                             dgvH3.Rows[i].Cells[columna].Value = "0";
                         }
                         #endregion
                         break;
                     case 4:
                         #region grid4
                         if (dgvH4.Rows[i].Cells[columna].Value == null)
                         {
                             dgvH4.Rows[i].Cells[columna].Value = "0";
                         }
                         #endregion
                         break;
                     case 5:
                         #region grid5
                         if (dgvH5.Rows[i].Cells[columna].Value == null)
                         {
                             dgvH5.Rows[i].Cells[columna].Value = "0";
                         }
                         #endregion
                         break;
                     case 6:
                         #region grid6
                         if (dgvH6.Rows[i].Cells[columna].Value == null)
                         {
                             dgvH6.Rows[i].Cells[columna].Value = "0";
                         }
                         #endregion
                         break;
                     case 7:
                         #region grid7
                         if (dgvH7.Rows[i].Cells[columna].Value == null)
                         {
                             dgvH7.Rows[i].Cells[columna].Value = "0";
                         }
                         #endregion
                         break;
                     case 8:
                         #region grid8
                         if (dgvH8.Rows[i].Cells[columna].Value == null)
                         {
                             dgvH8.Rows[i].Cells[columna].Value = "0";
                         }
                         #endregion
                         break;
                     case 9:
                         #region grid9
                         if (dgvH9.Rows[i].Cells[columna].Value == null)
                         {
                             dgvH9.Rows[i].Cells[columna].Value = "0";
                         }
                         #endregion
                         break;
                     case 10:
                         #region grid10
                         if (dgvH10.Rows[i].Cells[columna].Value == null)
                         {
                             dgvH10.Rows[i].Cells[columna].Value = "0";
                         }
                         #endregion
                         break;
                     case 11:
                         #region grid11
                         if (dgvH11.Rows[i].Cells[columna].Value == null)
                         {
                             dgvH11.Rows[i].Cells[columna].Value = "0";
                         }
                         #endregion
                         break;
                     case 12:
                         #region grid12
                         if (dgvH12.Rows[i].Cells[columna].Value == null)
                         {
                             dgvH12.Rows[i].Cells[columna].Value = "0";
                         }
                         #endregion
                         break;
                 }
             }
         }
         private void m_llenargrid(int renglon, int columna ,int grid,string val, int tipo)
         {
           switch(tipo)
           {
               case 1: 
                   switch(grid)
                   {
                       case 1:
                           dgvH1.Rows[renglon].Cells[columna].Value=val;
                           break;
                       case 2:
                           dgvH2.Rows[renglon].Cells[columna].Value = val;
                           break;
                       case 3:
                           dgvH3.Rows[renglon].Cells[columna].Value = val;
                           break;
                       case 4:
                           dgvH4.Rows[renglon].Cells[columna].Value = val;
                           break;
                       case 5:
                           dgvH5.Rows[renglon].Cells[columna].Value = val;
                           break;
                       case 6:
                           dgvH6.Rows[renglon].Cells[columna].Value = val;
                           break;
                       case 7:
                           dgvH7.Rows[renglon].Cells[columna].Value = val;
                           break;
                       case 8:
                           dgvH8.Rows[renglon].Cells[columna].Value = val;
                           break;
                       case 9:
                           dgvH9.Rows[renglon].Cells[columna].Value = val;
                           break;
                       case 10:
                           dgvH10.Rows[renglon].Cells[columna].Value = val;
                           break;
                       case 11:
                           dgvH11.Rows[renglon].Cells[columna].Value = val;
                           break;
                       case 12:
                           dgvH12.Rows[renglon].Cells[columna].Value = val;
                           break;
                   }
                   break;
               case 2:
                   break;
               case 3:
                   break;
           }
         }
         private string m_leergrid(int renglon, int columna, int grid, int tipo)
         {
             string val = "";
             switch (tipo)
             {
                 case 1:
                     switch (grid)
                     {
                         case 1:
                             if (dgvH1.Rows[renglon].Cells[columna].Value == null)
                             {
                                 val = "0";
                             }
                             else
                             {
                                 val = dgvH1.Rows[renglon].Cells[columna].Value.ToString();
                             }
                             break;
                         case 2:
                             if (dgvH2.Rows[renglon].Cells[columna].Value == null)
                             {
                                 val = "0";
                             }
                             else
                             {
                                 val = dgvH2.Rows[renglon].Cells[columna].Value.ToString();
                             }
                             break;
                         case 3:
                             val = dgvH3.Rows[renglon].Cells[columna].Value.ToString();
                             break;
                         case 4:
                             val = dgvH4.Rows[renglon].Cells[columna].Value.ToString();
                             break;
                         case 5:
                             val = dgvH5.Rows[renglon].Cells[columna].Value.ToString();
                             break;
                         case 6:
                             val = dgvH6.Rows[renglon].Cells[columna].Value.ToString();
                             break;
                         case 7:
                             val = dgvH7.Rows[renglon].Cells[columna].Value.ToString();
                             break;
                         case 8:
                             val = dgvH8.Rows[renglon].Cells[columna].Value.ToString();
                             break;
                         case 9:
                             val = dgvH9.Rows[renglon].Cells[columna].Value.ToString();
                             break;
                         case 10:
                             val = dgvH10.Rows[renglon].Cells[columna].Value.ToString();
                             break;
                         case 11:
                             val = dgvH11.Rows[renglon].Cells[columna].Value.ToString();
                             break;
                         case 12:
                             val = dgvH12.Rows[renglon].Cells[columna].Value.ToString();
                             break;
                     }
                     break;
                 case 2:
                     switch (grid)
                     {
                         case 1:
                             val = dgvH1.Rows[renglon].Cells[columna].Value.ToString();
                             break;
                         case 2:
                             val = dgvH2.Rows[renglon].Cells[columna].Value.ToString();
                             break;
                         case 3:
                             val = dgvH3.Rows[renglon].Cells[columna].Value.ToString();
                             break;
                     }
                     break;
                 case 3:
                     switch (grid)
                     {
                         case 1:
                             val = dgvH1.Rows[renglon].Cells[columna].Value.ToString();
                             break;
                         case 2:
                             val = dgvH2.Rows[renglon].Cells[columna].Value.ToString();
                             break;
                         case 3:
                             val = dgvH3.Rows[renglon].Cells[columna].Value.ToString();
                             break;
                     }
                     break;
             }
             return val;
         }
         private void nulos2(int grid, int columna)
         {
             for (int i = 0; i <= dgvP1A.Rows.Count - 1; i++)
             {
                 switch (grid)
                 {
                     case 1:
                         #region grid1
                         if (dgvP1A.Rows[i].Cells[columna].Value == null)
                         {
                             dgvP1A.Rows[i].Cells[columna].Value = "0";
                         }
                         #endregion
                         break;
                     case 2:
                         #region grid2
                         if (dgvP2A.Rows[i].Cells[columna].Value == null)
                         {
                             dgvP2A.Rows[i].Cells[columna].Value = "0";
                         }
                         #endregion
                         break;
                     case 3:
                         #region grid3
                         if (dgvP3A.Rows[i].Cells[columna].Value == null)
                         {
                             dgvP3A.Rows[i].Cells[columna].Value = "0";
                         }
                         #endregion
                         break;
                     case 4:
                         #region grid4
                         if (dgvP4A.Rows[i].Cells[columna].Value == null)
                         {
                             dgvP4A.Rows[i].Cells[columna].Value = "0";
                         }
                         #endregion
                         break;
                     case 5:
                         #region grid5
                         if (dgvP5A.Rows[i].Cells[columna].Value == null)
                         {
                             dgvP5A.Rows[i].Cells[columna].Value = "0";
                         }
                         #endregion
                         break;
                     case 6:
                         #region grid6
                         if (dgvP6A.Rows[i].Cells[columna].Value == null)
                         {
                             dgvP6A.Rows[i].Cells[columna].Value = "0";
                         }
                         #endregion
                         break;
                     case 7:
                         #region grid7
                         if (dgvP7A.Rows[i].Cells[columna].Value == null)
                         {
                             dgvP7A.Rows[i].Cells[columna].Value = "0";
                         }
                         #endregion
                         break;
                     case 8:
                         #region grid8
                         if (dgvP8A.Rows[i].Cells[columna].Value == null)
                         {
                             dgvP8A.Rows[i].Cells[columna].Value = "0";
                         }
                         #endregion
                         break;
                     case 9:
                         #region grid9
                         if (dgvP9A.Rows[i].Cells[columna].Value == null)
                         {
                             dgvP9A.Rows[i].Cells[columna].Value = "0";
                         }
                         #endregion
                         break;
                     case 10:
                         #region grid10
                         if (dgvP10A.Rows[i].Cells[columna].Value == null)
                         {
                             dgvP10A.Rows[i].Cells[columna].Value = "0";
                         }
                         #endregion
                         break;
                     case 11:
                         #region grid11
                         if (dgvP11A.Rows[i].Cells[columna].Value == null)
                         {
                             dgvP11A.Rows[i].Cells[columna].Value = "0";
                         }
                         #endregion
                         break;
                     case 12:
                         #region grid12
                         if (dgvP12A.Rows[i].Cells[columna].Value == null)
                         {
                             dgvP12A.Rows[i].Cells[columna].Value = "0";
                         }
                         #endregion
                         break;
                 }
             }
         }
    }
}
