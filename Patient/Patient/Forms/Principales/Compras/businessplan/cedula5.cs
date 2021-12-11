using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing;


namespace business_plan
{
    public partial class cedula5 : Form
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
        #region variables conexion

        private MySqlConnection Conn, ConnCipsis;
        private string query;
        private MySqlCommand cmd;
        private MySqlDataReader reader;
        private string conexion = "SERVER=" + Properties.Settings.Default.server + "; DATABASE=dwh; user=" + Properties.Settings.Default.usuario + "; PASSWORD=" + Properties.Settings.Default.pass + ";";
        private string conexion2 = "SERVER=" + Properties.Settings.Default.server + "; DATABASE=cipsis; user=" + Properties.Settings.Default.usuario + "; PASSWORD=" + Properties.Settings.Default.pass + ";";
        //private string conexion = "SERVER=localhost; DATABASE=cipsis; user=root; PASSWORD=;";
        //private string conexion = "SERVER=localhost; DATABASE=dwh; user=root; PASSWORD= ;";

        #endregion variables conexion
        #region variables escenario
        DateTime FechaAF = DateTime.Now, FechaAI = DateTime.Now;
        string[] idd = new string[10000];

        string CED1_fechaI = "";
        string CED1_fechaF = "";
        DateTime fech1 = DateTime.Now;
        DateTime fech2 = DateTime.Now;
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
        string queryunidadesAsignadas = " ";
        bool cargando = false;
        bool solototal = true;
        string solocalzadoDropdown = "";
        string dropdownmarca = "";
        string solocalzadowhere = " ";
        string sucursalcargar, divisioncargar, departamentocargar, familiacargar, lineacargar, l1cargar, l2cargar, l3cargar, l4cargar, l5cargar, l6cargar;
        int cantidadmes = 0;
        #endregion
        #region variables datos form PABLO
        //pablo 
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
        #region variables globales
        double[] utilidadPor = new double[1000];
        double[] utilidadImp = new double[1000];
        double[] utilidadFinanciamientoPor = new double[1000];
        double[] utilidadfinanciamientoImp = new double[1000];
        double inventario = 0;
        double[] utilidaddiasFin = new double[1000];
        double ZT = 0.0;
        double[] diasfin = new double[1000];
        double[] promediocosto = new double[1000];
        double[] costoXdiasfinanciados = new double[1000];
        double[] utilidadperdidaXfinanciamiento = new double[1000];
        double[] perdida = new double[12];
        double[] utilidad = new double[12];
        #endregion
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
            //@est@
            seleccion_sucursal = Convert.ToInt32(idd[cbSucursales.SelectedIndex]);

            if (cbSucursales.Text != "Total")
            {
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
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "'" + querycargar[0];
                sucursalcargar = "and idsucursal=" + idd[cbSucursales.SelectedIndex] + "";
            }
            else
            {
                queryunidadesAsignadas = "select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
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
                solototal = false;
                sucursalcargar = "and idsucursal=0";
                seleccion_sucursal = 0;
            }
            if (!valoresform)
                M_cargargrid(total);
        }
        private void cbDivision_DropDown(object sender, EventArgs e)
        {
            int i = 0;
            cbDivisiones.Items.Clear();
            if (solocalzadoDropdown == " and iddivisiones=1")
            {
                i = 0;
            }
            else
            {
                i = 1;
                cbDivisiones.Items.Add("Total");
            }
            query = "SELECT descrip,iddivisiones from estdivisiones where visiblebp='1' " + solocalzadoDropdown;
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
            //seleccion_division = -1;
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
            //@est@
            seleccion_division = Convert.ToInt32(idd[cbDivisiones.SelectedIndex]);

            if (cbDivisiones.Text != "Total")
            {
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
                if (solocalzadoDropdown != " ")
                {
                    queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " and iddivisiones=-1";
                }
                else
                {
                    queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                }
            }
            else
            {
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " and iddivisiones=0";
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
                query = "SELECT descrip,iddivisiones from estdivisiones where visiblebp='1'";
                d = "0";
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
            bandera_depto = true;
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
            //@est@
            seleccion_depto = Convert.ToInt32(idd[cbDepto.SelectedIndex]);

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
            dd = ",-1"; f = ",-1"; l = ",-1"; l1 = ",-1"; l2 = ",-1"; l3 = ",-1"; l4 = ",-1"; l5 = ",-1"; l6 = ",-1"; m = ",'-1'";

            #endregion
            if (cbDepto.Text != "Total")
            {
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
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                departamentocargar = "and iddepto=" + idd[cbDepto.SelectedIndex];
            }
            else
            {
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " and iddepto=-1";
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
            bandera_familia = true;
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
            //@est@
            seleccion_familia = Convert.ToInt32(idd[cbFamilia.SelectedIndex]);

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
            f = ",-1"; l = ",-1"; l1 = ",-1"; l2 = ",-1"; l3 = ",-1"; l4 = ",-1"; l5 = ",-1"; l6 = ",-1"; m = ",'-1'";
            #endregion
            if (cbFamilia.Text != "Total")
            {
                idfamilia = "and V.idfamilia=" + idd[cbFamilia.SelectedIndex];
                idfamiliavarios = idfamilia;
                total = false;
                wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamilia;
                string[] texto = cbFamilia.Text.Split('=');
                lbfamilia.Text = "Familia=" + texto[0].ToString();
                query = "SELECT descrip,idfamilia from estfamilia where visiblebp='1' and idfamilia=" + idd[cbFamilia.SelectedIndex] + "";
                fam = "and idfamilia=" + idd[cbFamilia.SelectedIndex];
                queryguardar[0] = "," + s + "," + d + "," + dd + "," + idd[cbFamilia.SelectedIndex] + ",0,0,0,0,0,0,0,'0'";
                f = idd[cbFamilia.SelectedIndex];
                querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " and idfamilia=" + idd[cbFamilia.SelectedIndex] + " and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                familiacargar = "and idfamilia=" + idd[cbFamilia.SelectedIndex];
            }
            else
            {
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + " and idfamilia=-1";
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
            bandera_linea = true;
            //@est@
            seleccion_linea = Convert.ToInt32(idd[cbLinea.SelectedIndex]);

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
            l = ",-1"; l1 = ",-1"; l2 = ",-1"; l3 = ",-1"; l4 = ",-1"; l5 = ",-1"; l6 = ",-1"; m = ",'-1'";
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
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                lineacargar = "and idlinea=" + idd[cbLinea.SelectedIndex];
            }
            else
            {
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " and idlinea=-1";
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
            bandera_l1 = true;
            //@est@
            seleccion_l1 = Convert.ToInt32(idd[cbL1.SelectedIndex]);
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
            l1 = ",-1"; l2 = ",-1"; l3 = ",-1"; l4 = ",-1"; l5 = ",-1"; l6 = ",-1"; m = ",'-1'";
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
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                l1cargar = "and idl1=" + idd[cbL1.SelectedIndex];
            }
            else
            {
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " and idl1=-1";
                idl1varios = " ";
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
                l1 = "0";
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
            bandera_l2 = true;
            //@est@
            seleccion_l2 = Convert.ToInt32(idd[cbL2.SelectedIndex]);
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
            l2 = ",-1"; l3 = ",-1"; l4 = ",-1"; l5 = ",-1"; l6 = ",-1"; m = ",'-1'";
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
                querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " and idl2=" + idd[cbL2.SelectedIndex] + " and idl3=0 and idl4=0 and idl5=0 and idl6=0 and marca='0'  ";
                idl2 = "and idl2=" + idd[cbL2.SelectedIndex];
                idl2varios = idl2;
                total = false;
                query = "SELECT descrip,idl2 from estl2 where visiblebp='1' and idl2=" + idd[cbL2.SelectedIndex];
                wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2;
                subl2 = "and idl2=" + idd[cbL2.SelectedIndex];
                queryguardar[0] = "," + s + "," + d + "," + dd + "," + f + "," + l + "," + l1 + "," + idd[cbL2.SelectedIndex] + ",-1,-1,-1,-1,'-1'";
                l2 = idd[cbL2.SelectedIndex];
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                l2cargar = "and idl2=" + idd[cbL2.SelectedIndex];
            }
            else
            {
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " and idl2=-1";
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
                total = true;
                query = "SELECT descrip,idl2 from estl2 where visiblebp='1' " + division + " " + depto + " " + fam + " " + linea + " " + subl1;
                l2cargar = "and idl2=0";
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
            bandera_l3 = true;
            //@est@
            seleccion_l3 = Convert.ToInt32(idd[cbL3.SelectedIndex]);
            #region banderas
            bandera_l4 = false;
            bandera_l5 = false;
            bandera_l6 = false;
            bandera_marca = false;
            seleccion_l4 = -1;
            seleccion_l5 = -1;
            seleccion_l6 = -1;
            seleccion_marca = "";
            l3 = ",-1"; l4 = ",-1"; l5 = ",-1"; l6 = ",-1"; m = ",'-1'";
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
                l3cargar = "and idl3=" + idd[cbL3.SelectedIndex];
                querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " and idl3=" + idd[cbL3.SelectedIndex] + " and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                idl3 = "and idl3=" + idd[cbL3.SelectedIndex];
                idl3varios = idl3;
                total = false;
                query = "SELECT descrip,idl3 from estl3 where visiblebp='1' and idl3=" + idd[cbL3.SelectedIndex];
                wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3;
                subl3 = "and idl3=" + idd[cbL3.SelectedIndex];
                queryguardar[0] = "," + s + "," + d + "," + dd + "," + f + "," + l + "," + l1 + "," + l2 + "," + idd[cbL3.SelectedIndex] + ",-1,-1,-1,'-1'";
                l3 = idd[cbL3.SelectedIndex];
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
            }
            else
            {
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " and idl3=-1";
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
            bandera_l4 = true;
            //@est@
            seleccion_l4 = Convert.ToInt32(idd[cbL4.SelectedIndex]);
            #region banderas
            bandera_l5 = false;
            bandera_l6 = false;
            bandera_marca = false;
            seleccion_l5 = -1;
            seleccion_l6 = -1;
            seleccion_marca = "";
            l4 = ",-1"; l5 = ",-1"; l6 = ",-1"; m = ",'-1'";
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
                querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " and idl4=" + idd[cbL4.SelectedIndex] + " and idl5=-1 and idl6=-1 and marca='-1'  ";
                idl4 = "and idl4=" + idd[cbL4.SelectedIndex];
                idl4varios = idl4;
                total = false;
                query = "SELECT descrip,idl4 from estl4 where visiblebp='1' and idl4=" + idd[cbL4.SelectedIndex];
                wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4;
                subl4 = "and idl4=" + idd[cbL4.SelectedIndex];
                queryguardar[0] = "," + s + "," + d + "," + dd + "," + f + "," + l + "," + l1 + "," + l2 + "," + l3 + "," + idd[cbL4.SelectedIndex] + ",-1,-1,'-1'";
                l4 = idd[cbL4.SelectedIndex];
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                l4cargar = "and idl4=" + idd[cbL4.SelectedIndex];
            }
            else
            {

                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " and idl4=-1";
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
            bandera_l5 = true;
            //@est@
            seleccion_l5 = Convert.ToInt32(idd[cbL5.SelectedIndex]);
            #region banderas
            bandera_l6 = false;
            bandera_marca = false;
            seleccion_l6 = -1;
            seleccion_marca = "";
            l5 = ",-1"; l6 = ",-1"; m = ",'-1'";
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
                querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " and idl5=" + idd[cbL5.SelectedIndex] + " and idl6=-1 and marca='-1'  ";
                idl5 = "and idl5=" + idd[cbL5.SelectedIndex];
                idl5varios = idl5;
                total = false;
                query = "SELECT descrip,idl5 from estl5 where visiblebp='1' and idl5=" + idd[cbL5.SelectedIndex];
                wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5;
                subl5 = "and idl5=" + idd[cbL5.SelectedIndex];
                queryguardar[0] = "," + s + "," + d + "," + dd + "," + f + "," + l + "," + l1 + "," + l2 + "," + l3 + "," + l4 + "," + idd[cbL5.SelectedIndex] + ",-1,'-1'";
                l5 = idd[cbL5.SelectedIndex];
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                l5cargar = "and idl5=" + idd[cbL5.SelectedIndex];
            }
            else
            {
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " and idl5=-1";
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
            bandera_l6 = true;
            //@est@
            seleccion_l6 = Convert.ToInt32(idd[cbL6.SelectedIndex]);
            #region banderas
            bandera_marca = false;
            seleccion_marca = "";
            l6 = ",-1";
            m = ",'-1'";
            #endregion
            #region reiniciar valores
            lbL6.Text = "L6";
            lbMarca.Text = "Marca";
            idl6 = " ";
            marca = " ";
            #endregion

            if (cbL6.Text != "Total")
            {
                querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " and idl6=" + idd[cbL6.SelectedIndex] + " and marca='-1'  ";
                idl6 = "and idl6=" + idd[cbL6.SelectedIndex];
                idl6varios = idl6;
                total = false;
                query = "SELECT descrip,idl6 from estl6 where visiblebp='1' and idl6=" + idd[cbL6.SelectedIndex];
                wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6;
                subl6 = "and idl6=" + idd[cbL6.SelectedIndex];
                queryguardar[0] = "," + s + "," + d + "," + dd + "," + f + "," + l + "," + l1 + "," + l2 + "," + l3 + "," + l4 + "," + l5 + "," + idd[cbL6.SelectedIndex] + ",'-1'";
                l6 = idd[cbL6.SelectedIndex];
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                l6cargar = "and idl6=" + idd[cbL6.SelectedIndex];
            }
            else
            {
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " and idl6=-1";
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
            marca = ",-1";
            bandera_marca = true;
            seleccion_marca = cbMarca.SelectedText;
            if (cbMarca.Text == "Total")
            {
                for (int i = 0; i <= cbMarca.Items.Count - 1; i++)
                {
                    marca = " and V.marca='" + idd[(i + 1)] + "'";
                    wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6 + " " + marca;
                    queryguardar[i] = "," + s + "," + d + "," + dd + "," + f + "," + l + "," + l1 + "," + l2 + "," + l3 + "," + l4 + "," + l5 + "," + l6 + ",'" + idd[(i + 1)] + "'";
                    querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " " + l6cargar + " and marca='" + idd[(i + 1)] + "'  ";
                }
                total = true;
                //queryunidadesAsignadas = "SELECT Inventariodeseado as asignacionUP from cedula1 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=0 and iddivisiones=0 and iddepto=0 and idfamilia=0 and idlinea=0 and idl1=0 and idl2=0 and idl3=0 and idl4=0 and idl5=0 and idl6=0 and marca='0'";
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " " + l6cargar + " and marca='-1'";
                seleccion_marca = "0";
            }
            else
            {

                query = query + " and M.marca='" + idd[cbMarca.SelectedIndex] + "'";
                marca = " and V.marca='" + idd[cbMarca.SelectedIndex] + "'";
                wherequery[0] = idsucursalvarios + " " + idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6 + " " + marca;
                total = false;
                queryguardar[0] = "," + s + "," + d + "," + dd + "," + f + "," + l + "," + l1 + "," + l2 + "," + l3 + "," + l4 + "," + l5 + "," + l6 + ",'" + idd[cbMarca.SelectedIndex] + "'";
                querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " " + l6cargar + " and marca='" + idd[cbMarca.SelectedIndex] + "'  ";
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
            }
            lbMarca.Text = "Marca=" + cbMarca.Text;
            if (!valoresform)
                M_cargargrid(total);
            //solototal = true;
        }
        #endregion
        public cedula5()
        {
            InitializeComponent();
            tabcontrol.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabcontrol.DrawItem += new DrawItemEventHandler(tabcontrol_DrawItem);
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
        #region botones menu
        private void button4_Click(object sender, EventArgs e)
        {
            if (bandera_sucursal == true)
            {

                Cedula1 c1 = new Cedula1(seleccion_sucursal, seleccion_division, seleccion_depto, seleccion_familia, seleccion_linea, seleccion_l1, seleccion_l2, seleccion_l3, seleccion_l4, seleccion_l5, seleccion_l6, seleccion_marca);
                c1.Show(); this.Close();
            }
            else
            {
                Cedula1 c1 = new Cedula1();
                c1.Show(); this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (bandera_sucursal == true)
            {

                Cedula2 c2 = new Cedula2(seleccion_sucursal, seleccion_division, seleccion_depto, seleccion_familia, seleccion_linea, seleccion_l1, seleccion_l2, seleccion_l3, seleccion_l4, seleccion_l5, seleccion_l6, seleccion_marca);
                c2.Show(); this.Close();
            }
            else
            {
                Cedula2 c2 = new Cedula2();
                c2.Show(); this.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        { 
            Cedula3 c3 = new Cedula3();
            c3.Show(); this.Close();
            }

        private void button7_Click(object sender, EventArgs e)
        { 
            cedula4 c4 = new cedula4();
            c4.Show(); this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (bandera_sucursal == true)
            {

                cedula6 c6 = new cedula6(seleccion_sucursal, seleccion_division, seleccion_depto, seleccion_familia, seleccion_linea, seleccion_l1, seleccion_l2, seleccion_l3, seleccion_l4, seleccion_l5, seleccion_l6, seleccion_marca);
                c6.Show(); this.Close();
            }
            else
            {
                cedula6 c6 = new cedula6();
                c6.Show();
                this.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (bandera_sucursal == true)
            {
                Cedula7 c7 = new Cedula7(bandera_sucursal, seleccion_sucursal, bandera_division, seleccion_division, bandera_depto, seleccion_depto, bandera_familia, seleccion_familia, bandera_linea, seleccion_linea, bandera_l1, seleccion_l1, bandera_l2, seleccion_l2, bandera_l3, seleccion_l3, bandera_l4, seleccion_l4, bandera_l5, seleccion_l5, bandera_l6, seleccion_l6, bandera_marca, seleccion_marca);
                c7.Show(); this.Close();
            }
            else
            {
                Cedula7 c7 = new Cedula7();
                c7.Show(); this.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        { 
            Cedula8 c8 = new Cedula8();
            c8.Show(); this.Close();
        }

        private void cedula5_Load(object sender, EventArgs e)
        {
            m_ESCENARIO(Properties.Settings.Default.escenario);
            this.Refresh();
            M_pintarcolumnas();
            m_cantidadXmes(CED1_fechaI, CED1_fechaF);
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
            ////////////////////////////////

            ////////////////////////////////

            this.Refresh();
            #region si hay valores cedula anterior PABLO
            if (valoresform == true)
            {
                M_cargargrid(total);
                m_DIASMESESANOS(CED1_fechaI, CED1_fechaF);
            }
            #endregion
            this.Refresh();
        }
        #endregion
        private void M_cargargrid(bool Total)
        {
            m_ESTRUCTURA();
            m_inventario_ced1();
        }
        private void m_ESCENARIO(string escenario)
        {
            DateTime a = DateTime.Now, f = DateTime.Now;
            string ESC = "SELECT * FROM escenarios WHERE nombre = '" + escenario + "' LIMIT 1";
            cmd = new MySqlCommand(ESC, Conn);
            cmd.CommandTimeout = 0;//pos solucion
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                fech1 = a = DateTime.Parse(reader["fechainicial"].ToString());
                fech2 = f = DateTime.Parse(reader["fechafinal"].ToString());
                //a = DateTime.Parse(reader["fechainicial"].ToString());
                //f = DateTime.Parse(reader["fechafinal"].ToString());
                //CED1_estruct = reader["sucursal"].ToString();
                //CED1_estruct2 = reader["estructura"].ToString();
                FechaAI = DateTime.Parse(reader["fechainicialA"].ToString());
                FechaAF = DateTime.Parse(reader["fechafinalA"].ToString());
                label9.Text = "Escenario: " + escenario;
                label10.Text = "Fecha inicial " + a.ToString("yyyy-MM-dd");
                label11.Text = "Fecha final  " + f.ToString("yyyy-MM-dd");
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
        public void m_ESTRUCTURA()
        {
            #region cargar estructura
            int i = 1;
            m_CLEAR_DGV();
            m_ADD_ROWS_DGV();
            m_PASS_VALUES_DGV("Total", 0);
            dgv1.Rows[0].Cells[0].Value = "Total";
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
                            if (comprobarCargar(fecha_inicio_ano, fecha_inicio_mes, i) == true)
                            {
                                cargar(fecha_inicio_mes, fecha_inicio_ano, i);
                            }
                            else
                            {
                                m_utilidad_ced4(fecha_inicio_ano, fecha_inicio_mes, i);
                                m_CALCULOS(i, fecha_inicio_mes, fecha_inicio_ano);
                            }
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
                            if (comprobarCargar(fecha_inicio_ano, fecha_inicio_mes, i) == true)
                            {
                                cargar(fecha_inicio_mes, fecha_inicio_ano, i);
                            }
                            else
                            {
                                m_utilidad_ced4(fecha_inicio_ano, fecha_inicio_mes, i);
                                m_CALCULOS(i, fecha_inicio_mes, fecha_inicio_ano);
                            }
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
            m_calcularRenglonTotal();
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
        private void m_LLENAR_DGV(int m, int renglon, int columna, string val)
        {
            //           dgvCed9.Rows[0].Cells[i].Value = val;
            //renglon++;
            switch (m)
            {
                case 1: dgv1.Rows[renglon].Cells[columna].Value = val;
                    break;
                case 2: dgv2.Rows[renglon].Cells[columna].Value = val;
                    break;
                case 3: dgv3.Rows[renglon].Cells[columna].Value = val;
                    break;
                case 4: dgv4.Rows[renglon].Cells[columna].Value = val;
                    break;
                case 5: dgv5.Rows[renglon].Cells[columna].Value = val;
                    break;
                case 6: dgv6.Rows[renglon].Cells[columna].Value = val;
                    break;
                case 7: dgv7.Rows[renglon].Cells[columna].Value = val;
                    break;
                case 8: dgv8.Rows[renglon].Cells[columna].Value = val;
                    break;
                case 9: dgv9.Rows[renglon].Cells[columna].Value = val;
                    break;
                case 10: dgv10.Rows[renglon].Cells[columna].Value = val;
                    break;
                case 11: dgv11.Rows[renglon].Cells[columna].Value = val;
                    break;
                case 12: dgv12.Rows[renglon].Cells[columna].Value = val;
                    break;
                //  case 13: dgvProf13.Rows[columna].Cells[1].Value = val; 
                //    break;

            }

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
                        for (int i = 1; i <= dgv1.Rows.Count - 1; i++)
                        {
                            if (dgv1.Rows[i].Cells[1].Value != null && dgv1.Rows[i].Cells[1].Value.ToString() != " ")
                            {
                                c1 += double.Parse(dgv1.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c1 = 0;
                            }
                            if (dgv1.Rows[i].Cells[2].Value != null && dgv1.Rows[i].Cells[2].Value.ToString() != " ")
                            {
                                c2 += double.Parse(dgv1.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c2 = 0;
                            }
                            if (dgv1.Rows[i].Cells[3].Value != null && dgv1.Rows[i].Cells[3].Value.ToString() != " ")
                            {
                                c3 += double.Parse(dgv1.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c3 = 0;
                            }
                            if (dgv1.Rows[i].Cells[4].Value != null && dgv1.Rows[i].Cells[4].Value.ToString() != " ")
                            {
                                c4 += double.Parse(dgv1.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c4 = 0;
                            }
                            if (dgv1.Rows[i].Cells[5].Value != null && dgv1.Rows[i].Cells[5].Value.ToString() != " ")
                            {
                                c5 += double.Parse(dgv1.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c5 = 0;
                            }
                            if (dgv1.Rows[i].Cells[6].Value != null && dgv1.Rows[i].Cells[6].Value.ToString() != " ")
                            {
                                c6 += double.Parse(dgv1.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c6 = 0;
                            }
                            if (dgv1.Rows[i].Cells[7].Value != null && dgv1.Rows[i].Cells[7].Value.ToString() != " ")
                            {
                                c7 += double.Parse(dgv1.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c7 = 0;
                            }

                            dgv1.Rows[0].Cells[1].Value = c1.ToString("n0");
                            dgv1.Rows[0].Cells[2].Value = c2.ToString("C2");
                            dgv1.Rows[0].Cells[3].Value = c3.ToString("n0");
                            dgv1.Rows[0].Cells[4].Value = c4.ToString("C2");
                            dgv1.Rows[0].Cells[5].Value = c5.ToString("n0");
                            dgv1.Rows[0].Cells[6].Value = c6.ToString("C2");
                            dgv1.Rows[0].Cells[7].Value = c7.ToString("C2");
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
                        for (int i = 1; i <= dgv2.Rows.Count - 1; i++)
                        {
                            if (dgv2.Rows[i].Cells[1].Value != null && dgv2.Rows[i].Cells[1].Value.ToString() != " ")
                            {
                                c1 += double.Parse(dgv2.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c1 = 0;
                            }
                            if (dgv2.Rows[i].Cells[2].Value != null && dgv2.Rows[i].Cells[2].Value.ToString() != " ")
                            {
                                c2 += double.Parse(dgv2.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c2 = 0;
                            }
                            if (dgv2.Rows[i].Cells[3].Value != null && dgv2.Rows[i].Cells[3].Value.ToString() != " ")
                            {
                                c3 += double.Parse(dgv2.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c3 = 0;
                            }
                            if (dgv2.Rows[i].Cells[4].Value != null && dgv2.Rows[i].Cells[4].Value.ToString() != " ")
                            {
                                c4 += double.Parse(dgv2.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c4 = 0;
                            }
                            if (dgv2.Rows[i].Cells[5].Value != null && dgv2.Rows[i].Cells[5].Value.ToString() != " ")
                            {
                                c5 += double.Parse(dgv2.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c5 = 0;
                            }
                            if (dgv2.Rows[i].Cells[6].Value != null && dgv2.Rows[i].Cells[6].Value.ToString() != " ")
                            {
                                c6 += double.Parse(dgv2.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c6 = 0;
                            }
                            if (dgv2.Rows[i].Cells[7].Value != null && dgv2.Rows[i].Cells[7].Value.ToString() != " ")
                            {
                                c7 += double.Parse(dgv2.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c7 = 0;
                            }

                            dgv2.Rows[0].Cells[1].Value = c1.ToString("n0");
                            dgv2.Rows[0].Cells[2].Value = c2.ToString("C2");
                            dgv2.Rows[0].Cells[3].Value = c3.ToString("n0");
                            dgv2.Rows[0].Cells[4].Value = c4.ToString("C2");
                            dgv2.Rows[0].Cells[5].Value = c5.ToString("n0");
                            dgv2.Rows[0].Cells[6].Value = c6.ToString("C2");
                            dgv2.Rows[0].Cells[7].Value = c7.ToString("C2");
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
                        for (int i = 1; i <= dgv3.Rows.Count - 1; i++)
                        {
                            if (dgv3.Rows[i].Cells[1].Value != null && dgv3.Rows[i].Cells[1].Value.ToString() != " ")
                            {
                                c1 += double.Parse(dgv3.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c1 = 0;
                            }
                            if (dgv3.Rows[i].Cells[2].Value != null && dgv3.Rows[i].Cells[2].Value.ToString() != " ")
                            {
                                c2 += double.Parse(dgv3.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c2 = 0;
                            }
                            if (dgv3.Rows[i].Cells[3].Value != null && dgv3.Rows[i].Cells[3].Value.ToString() != " ")
                            {
                                c3 += double.Parse(dgv3.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c3 = 0;
                            }
                            if (dgv3.Rows[i].Cells[4].Value != null && dgv3.Rows[i].Cells[4].Value.ToString() != " ")
                            {
                                c4 += double.Parse(dgv3.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c4 = 0;
                            }
                            if (dgv3.Rows[i].Cells[5].Value != null && dgv3.Rows[i].Cells[5].Value.ToString() != " ")
                            {
                                c5 += double.Parse(dgv3.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c5 = 0;
                            }
                            if (dgv3.Rows[i].Cells[6].Value != null && dgv3.Rows[i].Cells[6].Value.ToString() != " ")
                            {
                                c6 += double.Parse(dgv3.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c6 = 0;
                            }
                            if (dgv3.Rows[i].Cells[7].Value != null && dgv3.Rows[i].Cells[7].Value.ToString() != " ")
                            {
                                c7 += double.Parse(dgv3.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c7 = 0;
                            }

                            dgv3.Rows[0].Cells[1].Value = c1.ToString("n0");
                            dgv3.Rows[0].Cells[2].Value = c2.ToString("C2");
                            dgv3.Rows[0].Cells[3].Value = c3.ToString("n0");
                            dgv3.Rows[0].Cells[4].Value = c4.ToString("C2");
                            dgv3.Rows[0].Cells[5].Value = c5.ToString("n0");
                            dgv3.Rows[0].Cells[6].Value = c6.ToString("C2");
                            dgv3.Rows[0].Cells[7].Value = c7.ToString("C2");
                            dgv3.Refresh();
                        }
                        #endregion
                        break;
                    case 4:
                        #region renglontotal
                        c1 = 0;
                        c2 = 0;
                        c3 = 0;
                        c4 = 0;
                        c5 = 0;
                        c6 = 0;
                        c7 = 0;
                        for (int i = 1; i <= dgv4.Rows.Count - 1; i++)
                        {
                            if (dgv4.Rows[i].Cells[1].Value != null && dgv4.Rows[i].Cells[1].Value.ToString() != " ")
                            {
                                c1 += double.Parse(dgv4.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c1 = 0;
                            }
                            if (dgv4.Rows[i].Cells[2].Value != null && dgv4.Rows[i].Cells[2].Value.ToString() != " ")
                            {
                                c2 += double.Parse(dgv4.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c2 = 0;
                            }
                            if (dgv4.Rows[i].Cells[3].Value != null && dgv4.Rows[i].Cells[3].Value.ToString() != " ")
                            {
                                c3 += double.Parse(dgv4.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c3 = 0;
                            }
                            if (dgv4.Rows[i].Cells[4].Value != null && dgv4.Rows[i].Cells[4].Value.ToString() != " ")
                            {
                                c4 += double.Parse(dgv4.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c4 = 0;
                            }
                            if (dgv4.Rows[i].Cells[5].Value != null && dgv4.Rows[i].Cells[5].Value.ToString() != " ")
                            {
                                c5 += double.Parse(dgv4.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c5 = 0;
                            }
                            if (dgv4.Rows[i].Cells[6].Value != null && dgv4.Rows[i].Cells[6].Value.ToString() != " ")
                            {
                                c6 += double.Parse(dgv4.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c6 = 0;
                            }
                            if (dgv4.Rows[i].Cells[7].Value != null && dgv4.Rows[i].Cells[7].Value.ToString() != " ")
                            {
                                c7 += double.Parse(dgv4.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c7 = 0;
                            }

                            dgv4.Rows[0].Cells[1].Value = c1.ToString("n0");
                            dgv4.Rows[0].Cells[2].Value = c2.ToString("C2");
                            dgv4.Rows[0].Cells[3].Value = c3.ToString("n0");
                            dgv4.Rows[0].Cells[4].Value = c4.ToString("C2");
                            dgv4.Rows[0].Cells[5].Value = c5.ToString("n0");
                            dgv4.Rows[0].Cells[6].Value = c6.ToString("C2");
                            dgv4.Rows[0].Cells[7].Value = c7.ToString("C2");
                            dgv4.Refresh();
                        }
                        #endregion
                        break;
                    case 5:
                        #region renglontotal
                        c1 = 0;
                        c2 = 0;
                        c3 = 0;
                        c4 = 0;
                        c5 = 0;
                        c6 = 0;
                        c7 = 0;
                        for (int i = 1; i <= dgv5.Rows.Count - 1; i++)
                        {
                            if (dgv5.Rows[i].Cells[1].Value != null && dgv5.Rows[i].Cells[1].Value.ToString() != " ")
                            {
                                c1 += double.Parse(dgv5.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c1 = 0;
                            }
                            if (dgv5.Rows[i].Cells[2].Value != null && dgv5.Rows[i].Cells[2].Value.ToString() != " ")
                            {
                                c2 += double.Parse(dgv5.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c2 = 0;
                            }
                            if (dgv5.Rows[i].Cells[3].Value != null && dgv5.Rows[i].Cells[3].Value.ToString() != " ")
                            {
                                c3 += double.Parse(dgv5.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c3 = 0;
                            }
                            if (dgv5.Rows[i].Cells[4].Value != null && dgv5.Rows[i].Cells[4].Value.ToString() != " ")
                            {
                                c4 += double.Parse(dgv5.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c4 = 0;
                            }
                            if (dgv5.Rows[i].Cells[5].Value != null && dgv5.Rows[i].Cells[5].Value.ToString() != " ")
                            {
                                c5 += double.Parse(dgv5.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c5 = 0;
                            }
                            if (dgv5.Rows[i].Cells[6].Value != null && dgv5.Rows[i].Cells[6].Value.ToString() != " ")
                            {
                                c6 += double.Parse(dgv5.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c6 = 0;
                            }
                            if (dgv5.Rows[i].Cells[7].Value != null && dgv5.Rows[i].Cells[7].Value.ToString() != " ")
                            {
                                c7 += double.Parse(dgv5.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c7 = 0;
                            }

                            dgv5.Rows[0].Cells[1].Value = c1.ToString("n0");
                            dgv5.Rows[0].Cells[2].Value = c2.ToString("C2");
                            dgv5.Rows[0].Cells[3].Value = c3.ToString("n0");
                            dgv5.Rows[0].Cells[4].Value = c4.ToString("C2");
                            dgv5.Rows[0].Cells[5].Value = c5.ToString("n0");
                            dgv5.Rows[0].Cells[6].Value = c6.ToString("C2");
                            dgv5.Rows[0].Cells[7].Value = c7.ToString("C2");
                            dgv5.Refresh();
                        }
                        #endregion
                        break;
                    case 6:
                        #region renglontotal
                        c1 = 0;
                        c2 = 0;
                        c3 = 0;
                        c4 = 0;
                        c5 = 0;
                        c6 = 0;
                        c7 = 0;
                        for (int i = 1; i <= dgv6.Rows.Count - 1; i++)
                        {
                            if (dgv6.Rows[i].Cells[1].Value != null && dgv6.Rows[i].Cells[1].Value.ToString() != " ")
                            {
                                c1 += double.Parse(dgv6.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c1 = 0;
                            }
                            if (dgv6.Rows[i].Cells[2].Value != null && dgv6.Rows[i].Cells[2].Value.ToString() != " ")
                            {
                                c2 += double.Parse(dgv6.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c2 = 0;
                            }
                            if (dgv6.Rows[i].Cells[3].Value != null && dgv6.Rows[i].Cells[3].Value.ToString() != " ")
                            {
                                c3 += double.Parse(dgv6.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c3 = 0;
                            }
                            if (dgv6.Rows[i].Cells[4].Value != null && dgv6.Rows[i].Cells[4].Value.ToString() != " ")
                            {
                                c4 += double.Parse(dgv6.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c4 = 0;
                            }
                            if (dgv6.Rows[i].Cells[5].Value != null && dgv6.Rows[i].Cells[5].Value.ToString() != " ")
                            {
                                c5 += double.Parse(dgv6.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c5 = 0;
                            }
                            if (dgv6.Rows[i].Cells[6].Value != null && dgv6.Rows[i].Cells[6].Value.ToString() != " ")
                            {
                                c6 += double.Parse(dgv6.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c6 = 0;
                            }
                            if (dgv6.Rows[i].Cells[7].Value != null && dgv6.Rows[i].Cells[7].Value.ToString() != " ")
                            {
                                c7 += double.Parse(dgv6.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c7 = 0;
                            }

                            dgv6.Rows[0].Cells[1].Value = c1.ToString("n0");
                            dgv6.Rows[0].Cells[2].Value = c2.ToString("C2");
                            dgv6.Rows[0].Cells[3].Value = c3.ToString("n0");
                            dgv6.Rows[0].Cells[4].Value = c4.ToString("C2");
                            dgv6.Rows[0].Cells[5].Value = c5.ToString("n0");
                            dgv6.Rows[0].Cells[6].Value = c6.ToString("C2");
                            dgv6.Rows[0].Cells[7].Value = c7.ToString("C2");
                            dgv6.Refresh();
                        }
                        #endregion
                        break;
                    case 7:
                        #region renglontotal
                        c1 = 0;
                        c2 = 0;
                        c3 = 0;
                        c4 = 0;
                        c5 = 0;
                        c6 = 0;
                        c7 = 0;
                        for (int i = 1; i <= dgv7.Rows.Count - 1; i++)
                        {
                            if (dgv7.Rows[i].Cells[1].Value != null && dgv7.Rows[i].Cells[1].Value.ToString() != " ")
                            {
                                c1 += double.Parse(dgv7.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c1 = 0;
                            }
                            if (dgv7.Rows[i].Cells[2].Value != null && dgv7.Rows[i].Cells[2].Value.ToString() != " ")
                            {
                                c2 += double.Parse(dgv7.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c2 = 0;
                            }
                            if (dgv7.Rows[i].Cells[3].Value != null && dgv7.Rows[i].Cells[3].Value.ToString() != " ")
                            {
                                c3 += double.Parse(dgv7.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c3 = 0;
                            }
                            if (dgv7.Rows[i].Cells[4].Value != null && dgv7.Rows[i].Cells[4].Value.ToString() != " ")
                            {
                                c4 += double.Parse(dgv7.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c4 = 0;
                            }
                            if (dgv7.Rows[i].Cells[5].Value != null && dgv7.Rows[i].Cells[5].Value.ToString() != " ")
                            {
                                c5 += double.Parse(dgv7.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c5 = 0;
                            }
                            if (dgv7.Rows[i].Cells[6].Value != null && dgv7.Rows[i].Cells[6].Value.ToString() != " ")
                            {
                                c6 += double.Parse(dgv7.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c6 = 0;
                            }
                            if (dgv7.Rows[i].Cells[7].Value != null && dgv7.Rows[i].Cells[7].Value.ToString() != " ")
                            {
                                c7 += double.Parse(dgv7.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c7 = 0;
                            }

                            dgv7.Rows[0].Cells[1].Value = c1.ToString("n0");
                            dgv7.Rows[0].Cells[2].Value = c2.ToString("C2");
                            dgv7.Rows[0].Cells[3].Value = c3.ToString("n0");
                            dgv7.Rows[0].Cells[4].Value = c4.ToString("C2");
                            dgv7.Rows[0].Cells[5].Value = c5.ToString("n0");
                            dgv7.Rows[0].Cells[6].Value = c6.ToString("C2");
                            dgv7.Rows[0].Cells[7].Value = c7.ToString("C2");
                            dgv7.Refresh();
                        }
                        #endregion
                        break;
                    case 8:
                        #region renglontotal
                        c1 = 0;
                        c2 = 0;
                        c3 = 0;
                        c4 = 0;
                        c5 = 0;
                        c6 = 0;
                        c7 = 0;
                        for (int i = 1; i <= dgv8.Rows.Count - 1; i++)
                        {
                            if (dgv8.Rows[i].Cells[1].Value != null && dgv8.Rows[i].Cells[1].Value.ToString() != " ")
                            {
                                c1 += double.Parse(dgv8.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c1 = 0;
                            }
                            if (dgv8.Rows[i].Cells[2].Value != null && dgv8.Rows[i].Cells[2].Value.ToString() != " ")
                            {
                                c2 += double.Parse(dgv8.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c2 = 0;
                            }
                            if (dgv8.Rows[i].Cells[3].Value != null && dgv8.Rows[i].Cells[3].Value.ToString() != " ")
                            {
                                c3 += double.Parse(dgv8.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c3 = 0;
                            }
                            if (dgv8.Rows[i].Cells[4].Value != null && dgv8.Rows[i].Cells[4].Value.ToString() != " ")
                            {
                                c4 += double.Parse(dgv8.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c4 = 0;
                            }
                            if (dgv8.Rows[i].Cells[5].Value != null && dgv8.Rows[i].Cells[5].Value.ToString() != " ")
                            {
                                c5 += double.Parse(dgv8.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c5 = 0;
                            }
                            if (dgv8.Rows[i].Cells[6].Value != null && dgv8.Rows[i].Cells[6].Value.ToString() != " ")
                            {
                                c6 += double.Parse(dgv8.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c6 = 0;
                            }
                            if (dgv8.Rows[i].Cells[7].Value != null && dgv8.Rows[i].Cells[7].Value.ToString() != " ")
                            {
                                c7 += double.Parse(dgv8.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c7 = 0;
                            }

                            dgv8.Rows[0].Cells[1].Value = c1.ToString("n0");
                            dgv8.Rows[0].Cells[2].Value = c2.ToString("C2");
                            dgv8.Rows[0].Cells[3].Value = c3.ToString("n0");
                            dgv8.Rows[0].Cells[4].Value = c4.ToString("C2");
                            dgv8.Rows[0].Cells[5].Value = c5.ToString("n0");
                            dgv8.Rows[0].Cells[6].Value = c6.ToString("C2");
                            dgv8.Rows[0].Cells[7].Value = c7.ToString("C2");
                            dgv8.Refresh();
                        }
                        #endregion
                        break;
                    case 9:
                        #region renglontotal
                        c1 = 0;
                        c2 = 0;
                        c3 = 0;
                        c4 = 0;
                        c5 = 0;
                        c6 = 0;
                        c7 = 0;
                        for (int i = 1; i <= dgv9.Rows.Count - 1; i++)
                        {
                            if (dgv9.Rows[i].Cells[1].Value != null && dgv9.Rows[i].Cells[1].Value.ToString() != " ")
                            {
                                c1 += double.Parse(dgv9.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c1 = 0;
                            }
                            if (dgv9.Rows[i].Cells[2].Value != null && dgv9.Rows[i].Cells[2].Value.ToString() != " ")
                            {
                                c2 += double.Parse(dgv9.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c2 = 0;
                            }
                            if (dgv9.Rows[i].Cells[3].Value != null && dgv9.Rows[i].Cells[3].Value.ToString() != " ")
                            {
                                c3 += double.Parse(dgv9.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c3 = 0;
                            }
                            if (dgv9.Rows[i].Cells[4].Value != null && dgv9.Rows[i].Cells[4].Value.ToString() != " ")
                            {
                                c4 += double.Parse(dgv9.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c4 = 0;
                            }
                            if (dgv9.Rows[i].Cells[5].Value != null && dgv9.Rows[i].Cells[5].Value.ToString() != " ")
                            {
                                c5 += double.Parse(dgv9.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c5 = 0;
                            }
                            if (dgv9.Rows[i].Cells[6].Value != null && dgv9.Rows[i].Cells[6].Value.ToString() != " ")
                            {
                                c6 += double.Parse(dgv9.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c6 = 0;
                            }
                            if (dgv9.Rows[i].Cells[7].Value != null && dgv9.Rows[i].Cells[7].Value.ToString() != " ")
                            {
                                c7 += double.Parse(dgv9.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c7 = 0;
                            }

                            dgv9.Rows[0].Cells[1].Value = c1.ToString("n0");
                            dgv9.Rows[0].Cells[2].Value = c2.ToString("C2");
                            dgv9.Rows[0].Cells[3].Value = c3.ToString("n0");
                            dgv9.Rows[0].Cells[4].Value = c4.ToString("C2");
                            dgv9.Rows[0].Cells[5].Value = c5.ToString("n0");
                            dgv9.Rows[0].Cells[6].Value = c6.ToString("C2");
                            dgv9.Rows[0].Cells[7].Value = c7.ToString("C2");
                            dgv9.Refresh();
                        }
                        #endregion
                        break;
                    case 10:
                        #region renglontotal
                        c1 = 0;
                        c2 = 0;
                        c3 = 0;
                        c4 = 0;
                        c5 = 0;
                        c6 = 0;
                        c7 = 0;
                        for (int i = 1; i <= dgv10.Rows.Count - 1; i++)
                        {
                            if (dgv10.Rows[i].Cells[1].Value != null && dgv10.Rows[i].Cells[1].Value.ToString() != " ")
                            {
                                c1 += double.Parse(dgv10.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c1 = 0;
                            }
                            if (dgv10.Rows[i].Cells[2].Value != null && dgv10.Rows[i].Cells[2].Value.ToString() != " ")
                            {
                                c2 += double.Parse(dgv10.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c2 = 0;
                            }
                            if (dgv10.Rows[i].Cells[3].Value != null && dgv10.Rows[i].Cells[3].Value.ToString() != " ")
                            {
                                c3 += double.Parse(dgv10.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c3 = 0;
                            }
                            if (dgv10.Rows[i].Cells[4].Value != null && dgv10.Rows[i].Cells[4].Value.ToString() != " ")
                            {
                                c4 += double.Parse(dgv10.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c4 = 0;
                            }
                            if (dgv10.Rows[i].Cells[5].Value != null && dgv10.Rows[i].Cells[5].Value.ToString() != " ")
                            {
                                c5 += double.Parse(dgv10.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c5 = 0;
                            }
                            if (dgv10.Rows[i].Cells[6].Value != null && dgv10.Rows[i].Cells[6].Value.ToString() != " ")
                            {
                                c6 += double.Parse(dgv10.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c6 = 0;
                            }
                            if (dgv10.Rows[i].Cells[7].Value != null && dgv10.Rows[i].Cells[7].Value.ToString() != " ")
                            {
                                c7 += double.Parse(dgv10.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c7 = 0;
                            }

                            dgv10.Rows[0].Cells[1].Value = c1.ToString("n0");
                            dgv10.Rows[0].Cells[2].Value = c2.ToString("C2");
                            dgv10.Rows[0].Cells[3].Value = c3.ToString("n0");
                            dgv10.Rows[0].Cells[4].Value = c4.ToString("C2");
                            dgv10.Rows[0].Cells[5].Value = c5.ToString("n0");
                            dgv10.Rows[0].Cells[6].Value = c6.ToString("C2");
                            dgv10.Rows[0].Cells[7].Value = c7.ToString("C2");
                            dgv10.Refresh();
                        }
                        #endregion
                        break;
                    case 11:
                        #region renglontotal
                        c1 = 0;
                        c2 = 0;
                        c3 = 0;
                        c4 = 0;
                        c5 = 0;
                        c6 = 0;
                        c7 = 0;
                        for (int i = 1; i <= dgv11.Rows.Count - 1; i++)
                        {
                            if (dgv11.Rows[i].Cells[1].Value != null && dgv11.Rows[i].Cells[1].Value.ToString() != " ")
                            {
                                c1 += double.Parse(dgv11.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c1 = 0;
                            }
                            if (dgv11.Rows[i].Cells[2].Value != null && dgv11.Rows[i].Cells[2].Value.ToString() != " ")
                            {
                                c2 += double.Parse(dgv11.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c2 = 0;
                            }
                            if (dgv11.Rows[i].Cells[3].Value != null && dgv11.Rows[i].Cells[3].Value.ToString() != " ")
                            {
                                c3 += double.Parse(dgv11.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c3 = 0;
                            }
                            if (dgv11.Rows[i].Cells[4].Value != null && dgv11.Rows[i].Cells[4].Value.ToString() != " ")
                            {
                                c4 += double.Parse(dgv11.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c4 = 0;
                            }
                            if (dgv11.Rows[i].Cells[5].Value != null && dgv11.Rows[i].Cells[5].Value.ToString() != " ")
                            {
                                c5 += double.Parse(dgv11.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c5 = 0;
                            }
                            if (dgv11.Rows[i].Cells[6].Value != null && dgv11.Rows[i].Cells[6].Value.ToString() != " ")
                            {
                                c6 += double.Parse(dgv11.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c6 = 0;
                            }
                            if (dgv11.Rows[i].Cells[7].Value != null && dgv11.Rows[i].Cells[7].Value.ToString() != " ")
                            {
                                c7 += double.Parse(dgv11.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c7 = 0;
                            }

                            dgv11.Rows[0].Cells[1].Value = c1.ToString("n0");
                            dgv11.Rows[0].Cells[2].Value = c2.ToString("C2");
                            dgv11.Rows[0].Cells[3].Value = c3.ToString("n0");
                            dgv11.Rows[0].Cells[4].Value = c4.ToString("C2");
                            dgv11.Rows[0].Cells[5].Value = c5.ToString("n0");
                            dgv11.Rows[0].Cells[6].Value = c6.ToString("C2");
                            dgv11.Rows[0].Cells[7].Value = c7.ToString("C2");
                            dgv11.Refresh();
                        }
                        #endregion
                        break;
                    case 12:
                        #region renglontotal
                        c1 = 0;
                        c2 = 0;
                        c3 = 0;
                        c4 = 0;
                        c5 = 0;
                        c6 = 0;
                        c7 = 0;
                        for (int i = 1; i <= dgv12.Rows.Count - 1; i++)
                        {
                            if (dgv12.Rows[i].Cells[1].Value != null && dgv12.Rows[i].Cells[1].Value.ToString() != " ")
                            {
                                c1 += double.Parse(dgv12.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c1 = 0;
                            }
                            if (dgv12.Rows[i].Cells[2].Value != null && dgv12.Rows[i].Cells[2].Value.ToString() != " ")
                            {
                                c2 += double.Parse(dgv12.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c2 = 0;
                            }
                            if (dgv12.Rows[i].Cells[3].Value != null && dgv12.Rows[i].Cells[3].Value.ToString() != " ")
                            {
                                c3 += double.Parse(dgv12.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c3 = 0;
                            }
                            if (dgv12.Rows[i].Cells[4].Value != null && dgv12.Rows[i].Cells[4].Value.ToString() != " ")
                            {
                                c4 += double.Parse(dgv12.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c4 = 0;
                            }
                            if (dgv12.Rows[i].Cells[5].Value != null && dgv12.Rows[i].Cells[5].Value.ToString() != " ")
                            {
                                c5 += double.Parse(dgv12.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c5 = 0;
                            }
                            if (dgv12.Rows[i].Cells[6].Value != null && dgv12.Rows[i].Cells[6].Value.ToString() != " ")
                            {
                                c6 += double.Parse(dgv12.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c6 = 0;
                            }
                            if (dgv12.Rows[i].Cells[7].Value != null && dgv12.Rows[i].Cells[7].Value.ToString() != " ")
                            {
                                c7 += double.Parse(dgv12.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
                            }
                            else
                            {
                                c7 = 0;
                            }

                            dgv12.Rows[0].Cells[1].Value = c1.ToString("n0");
                            dgv12.Rows[0].Cells[2].Value = c2.ToString("C2");
                            dgv12.Rows[0].Cells[3].Value = c3.ToString("n0");
                            dgv12.Rows[0].Cells[4].Value = c4.ToString("C2");
                            dgv12.Rows[0].Cells[5].Value = c5.ToString("n0");
                            dgv12.Rows[0].Cells[6].Value = c6.ToString("C2");
                            dgv12.Rows[0].Cells[7].Value = c7.ToString("C2");
                            dgv12.Refresh();
                        }
                        #endregion
                        break;
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
        private bool comprobarCargar(int año, int mes, int i)
        {
            reader.Close();
            bool comprobar = true;
            string s = "SELECT * FROM cedula6 where nombre='" + Properties.Settings.Default.escenario + "' and anio=" + año + " and mes=" + mes + " " + querycargar[0];
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
                    for (int x = 1; x <= dgv1.Rows.Count - 1; x++)
                    {
                        string q = "SELECT * FROM cedula6 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[(x - 1)];
                        cmd = new MySqlCommand(q, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["Uproductopor"].ToString());
                            c2 = double.Parse(reader["UproductoImp"].ToString());
                            c3 = double.Parse(reader["UfinanciamientoPor"].ToString());
                            c4 = double.Parse(reader["UfinanciamientoImp"].ToString());
                            c5 = double.Parse(reader["UdiasFin"].ToString());
                            c6 = double.Parse(reader["costoXdiasfin"].ToString());
                            c7 = double.Parse(reader["PoU"].ToString());
                            dgv1.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv1.Rows[x].Cells[2].Value = c2.ToString("C2");
                            dgv1.Rows[x].Cells[3].Value = c3.ToString("C2");
                            dgv1.Rows[x].Cells[4].Value = c4.ToString("n0");
                            dgv1.Rows[x].Cells[5].Value = c5.ToString("n0");
                            dgv1.Rows[x].Cells[6].Value = c6.ToString("C2");
                            dgv1.Rows[x].Cells[7].Value = c7.ToString("n0");
                            if(c7<=0)
                            {
                                dgv1.Rows[x].Cells[7].Style.BackColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                dgv1.Rows[x].Cells[7].Style.BackColor = System.Drawing.Color.LawnGreen;
                            }
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 2:
                    #region cargar grid1
                    for (int x = 1; x <= dgv1.Rows.Count - 1; x++)
                    {
                        string q = "SELECT * FROM cedula6 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[(x - 1)];
                        cmd = new MySqlCommand(q, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["Uproductopor"].ToString());
                            c2 = double.Parse(reader["UproductoImp"].ToString());
                            c3 = double.Parse(reader["UfinanciamientoPor"].ToString());
                            c4 = double.Parse(reader["UfinanciamientoImp"].ToString());
                            c5 = double.Parse(reader["UdiasFin"].ToString());
                            c6 = double.Parse(reader["costoXdiasfin"].ToString());
                            c7 = double.Parse(reader["PoU"].ToString());
                            dgv2.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv2.Rows[x].Cells[2].Value = c2.ToString("C2");
                            dgv2.Rows[x].Cells[3].Value = c3.ToString("C2");
                            dgv2.Rows[x].Cells[4].Value = c4.ToString("n0");
                            dgv2.Rows[x].Cells[5].Value = c5.ToString("n0");
                            dgv2.Rows[x].Cells[6].Value = c6.ToString("C2");
                            dgv2.Rows[x].Cells[7].Value = c7.ToString("n0");
                            if (c7 <= 0)
                            {
                                dgv2.Rows[x].Cells[7].Style.BackColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                dgv2.Rows[x].Cells[7].Style.BackColor = System.Drawing.Color.LawnGreen;
                            }
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 3:
                    #region cargar grid1
                    for (int x = 1; x <= dgv1.Rows.Count - 1; x++)
                    {
                        string q = "SELECT * FROM cedula6 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[(x - 1)];
                        cmd = new MySqlCommand(q, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["Uproductopor"].ToString());
                            c2 = double.Parse(reader["UproductoImp"].ToString());
                            c3 = double.Parse(reader["UfinanciamientoPor"].ToString());
                            c4 = double.Parse(reader["UfinanciamientoImp"].ToString());
                            c5 = double.Parse(reader["UdiasFin"].ToString());
                            c6 = double.Parse(reader["costoXdiasfin"].ToString());
                            c7 = double.Parse(reader["PoU"].ToString());
                            dgv3.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv3.Rows[x].Cells[2].Value = c2.ToString("C2");
                            dgv3.Rows[x].Cells[3].Value = c3.ToString("C2");
                            dgv3.Rows[x].Cells[4].Value = c4.ToString("n0");
                            dgv3.Rows[x].Cells[5].Value = c5.ToString("n0");
                            dgv3.Rows[x].Cells[6].Value = c6.ToString("C2");
                            dgv3.Rows[x].Cells[7].Value = c7.ToString("n0");
                            if (c7 <= 0)
                            {
                                dgv3.Rows[x].Cells[7].Style.BackColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                dgv3.Rows[x].Cells[7].Style.BackColor = System.Drawing.Color.LawnGreen;
                            }
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 4:
                    #region cargar grid1
                    for (int x = 1; x <= dgv1.Rows.Count - 1; x++)
                    {
                        string q = "SELECT * FROM cedula6 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[(x - 1)];
                        cmd = new MySqlCommand(q, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["Uproductopor"].ToString());
                            c2 = double.Parse(reader["UproductoImp"].ToString());
                            c3 = double.Parse(reader["UfinanciamientoPor"].ToString());
                            c4 = double.Parse(reader["UfinanciamientoImp"].ToString());
                            c5 = double.Parse(reader["UdiasFin"].ToString());
                            c6 = double.Parse(reader["costoXdiasfin"].ToString());
                            c7 = double.Parse(reader["PoU"].ToString());
                            dgv4.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv4.Rows[x].Cells[2].Value = c2.ToString("C2");
                            dgv4.Rows[x].Cells[3].Value = c3.ToString("C2");
                            dgv4.Rows[x].Cells[4].Value = c4.ToString("n0");
                            dgv4.Rows[x].Cells[5].Value = c5.ToString("n0");
                            dgv4.Rows[x].Cells[6].Value = c6.ToString("C2");
                            dgv4.Rows[x].Cells[7].Value = c7.ToString("n0");
                            if (c7 <= 0)
                            {
                                dgv4.Rows[x].Cells[7].Style.BackColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                dgv4.Rows[x].Cells[7].Style.BackColor = System.Drawing.Color.LawnGreen;
                            }
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 5:
                    #region cargar grid1
                    for (int x = 1; x <= dgv1.Rows.Count - 1; x++)
                    {
                        string q = "SELECT * FROM cedula6 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[(x - 1)];
                        cmd = new MySqlCommand(q, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["Uproductopor"].ToString());
                            c2 = double.Parse(reader["UproductoImp"].ToString());
                            c3 = double.Parse(reader["UfinanciamientoPor"].ToString());
                            c4 = double.Parse(reader["UfinanciamientoImp"].ToString());
                            c5 = double.Parse(reader["UdiasFin"].ToString());
                            c6 = double.Parse(reader["costoXdiasfin"].ToString());
                            c7 = double.Parse(reader["PoU"].ToString());
                            dgv5.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv5.Rows[x].Cells[2].Value = c2.ToString("C2");
                            dgv5.Rows[x].Cells[3].Value = c3.ToString("C2");
                            dgv5.Rows[x].Cells[4].Value = c4.ToString("n0");
                            dgv5.Rows[x].Cells[5].Value = c5.ToString("n0");
                            dgv5.Rows[x].Cells[6].Value = c6.ToString("C2");
                            dgv5.Rows[x].Cells[7].Value = c7.ToString("n0");
                            if (c7 <= 0)
                            {
                                dgv5.Rows[x].Cells[7].Style.BackColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                dgv5.Rows[x].Cells[7].Style.BackColor = System.Drawing.Color.LawnGreen;
                            }
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 6:
                    #region cargar grid1
                    for (int x = 1; x <= dgv1.Rows.Count - 1; x++)
                    {
                        string q = "SELECT * FROM cedula6 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[(x - 1)];
                        cmd = new MySqlCommand(q, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["Uproductopor"].ToString());
                            c2 = double.Parse(reader["UproductoImp"].ToString());
                            c3 = double.Parse(reader["UfinanciamientoPor"].ToString());
                            c4 = double.Parse(reader["UfinanciamientoImp"].ToString());
                            c5 = double.Parse(reader["UdiasFin"].ToString());
                            c6 = double.Parse(reader["costoXdiasfin"].ToString());
                            c7 = double.Parse(reader["PoU"].ToString());
                            dgv6.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv6.Rows[x].Cells[2].Value = c2.ToString("C2");
                            dgv6.Rows[x].Cells[3].Value = c3.ToString("C2");
                            dgv6.Rows[x].Cells[4].Value = c4.ToString("n0");
                            dgv6.Rows[x].Cells[5].Value = c5.ToString("n0");
                            dgv6.Rows[x].Cells[6].Value = c6.ToString("C2");
                            dgv6.Rows[x].Cells[7].Value = c7.ToString("n0");
                            if (c7 <= 0)
                            {
                                dgv6.Rows[x].Cells[7].Style.BackColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                dgv6.Rows[x].Cells[7].Style.BackColor = System.Drawing.Color.LawnGreen;
                            }
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 7:
                    #region cargar grid1
                    for (int x = 1; x <= dgv1.Rows.Count - 1; x++)
                    {
                        string q = "SELECT * FROM cedula6 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[(x - 1)];
                        cmd = new MySqlCommand(q, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["Uproductopor"].ToString());
                            c2 = double.Parse(reader["UproductoImp"].ToString());
                            c3 = double.Parse(reader["UfinanciamientoPor"].ToString());
                            c4 = double.Parse(reader["UfinanciamientoImp"].ToString());
                            c5 = double.Parse(reader["UdiasFin"].ToString());
                            c6 = double.Parse(reader["costoXdiasfin"].ToString());
                            c7 = double.Parse(reader["PoU"].ToString());
                            dgv7.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv7.Rows[x].Cells[2].Value = c2.ToString("C2");
                            dgv7.Rows[x].Cells[3].Value = c3.ToString("C2");
                            dgv7.Rows[x].Cells[4].Value = c4.ToString("n0");
                            dgv7.Rows[x].Cells[5].Value = c5.ToString("n0");
                            dgv7.Rows[x].Cells[6].Value = c6.ToString("C2");
                            dgv7.Rows[x].Cells[7].Value = c7.ToString("n0");
                            if (c7 <= 0)
                            {
                                dgv7.Rows[x].Cells[7].Style.BackColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                dgv7.Rows[x].Cells[7].Style.BackColor = System.Drawing.Color.LawnGreen;
                            }
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 8:
                    #region cargar grid1
                    for (int x = 1; x <= dgv1.Rows.Count - 1; x++)
                    {
                        string q = "SELECT * FROM cedula6 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[(x - 1)];
                        cmd = new MySqlCommand(q, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["Uproductopor"].ToString());
                            c2 = double.Parse(reader["UproductoImp"].ToString());
                            c3 = double.Parse(reader["UfinanciamientoPor"].ToString());
                            c4 = double.Parse(reader["UfinanciamientoImp"].ToString());
                            c5 = double.Parse(reader["UdiasFin"].ToString());
                            c6 = double.Parse(reader["costoXdiasfin"].ToString());
                            c7 = double.Parse(reader["PoU"].ToString());
                            dgv8.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv8.Rows[x].Cells[2].Value = c2.ToString("C2");
                            dgv8.Rows[x].Cells[3].Value = c3.ToString("C2");
                            dgv8.Rows[x].Cells[4].Value = c4.ToString("n0");
                            dgv8.Rows[x].Cells[5].Value = c5.ToString("n0");
                            dgv8.Rows[x].Cells[6].Value = c6.ToString("C2");
                            dgv8.Rows[x].Cells[7].Value = c7.ToString("n0");
                            if (c7 <= 0)
                            {
                                dgv8.Rows[x].Cells[7].Style.BackColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                dgv8.Rows[x].Cells[7].Style.BackColor = System.Drawing.Color.LawnGreen;
                            }
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 9:
                    #region cargar grid1
                    for (int x = 1; x <= dgv1.Rows.Count - 1; x++)
                    {
                        string q = "SELECT * FROM cedula6 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[(x - 1)];
                        cmd = new MySqlCommand(q, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["Uproductopor"].ToString());
                            c2 = double.Parse(reader["UproductoImp"].ToString());
                            c3 = double.Parse(reader["UfinanciamientoPor"].ToString());
                            c4 = double.Parse(reader["UfinanciamientoImp"].ToString());
                            c5 = double.Parse(reader["UdiasFin"].ToString());
                            c6 = double.Parse(reader["costoXdiasfin"].ToString());
                            c7 = double.Parse(reader["PoU"].ToString());
                            dgv9.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv9.Rows[x].Cells[2].Value = c2.ToString("C2");
                            dgv9.Rows[x].Cells[3].Value = c3.ToString("C2");
                            dgv9.Rows[x].Cells[4].Value = c4.ToString("n0");
                            dgv9.Rows[x].Cells[5].Value = c5.ToString("n0");
                            dgv9.Rows[x].Cells[6].Value = c6.ToString("C2");
                            dgv9.Rows[x].Cells[7].Value = c7.ToString("n0");
                            if (c7 <= 0)
                            {
                                dgv9.Rows[x].Cells[7].Style.BackColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                dgv9.Rows[x].Cells[7].Style.BackColor = System.Drawing.Color.LawnGreen;
                            }
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 10:
                    #region cargar grid1
                    for (int x = 1; x <= dgv1.Rows.Count - 1; x++)
                    {
                        string q = "SELECT * FROM cedula6 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[(x - 1)];
                        cmd = new MySqlCommand(q, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["Uproductopor"].ToString());
                            c2 = double.Parse(reader["UproductoImp"].ToString());
                            c3 = double.Parse(reader["UfinanciamientoPor"].ToString());
                            c4 = double.Parse(reader["UfinanciamientoImp"].ToString());
                            c5 = double.Parse(reader["UdiasFin"].ToString());
                            c6 = double.Parse(reader["costoXdiasfin"].ToString());
                            c7 = double.Parse(reader["PoU"].ToString());
                            dgv10.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv10.Rows[x].Cells[2].Value = c2.ToString("C2");
                            dgv10.Rows[x].Cells[3].Value = c3.ToString("C2");
                            dgv10.Rows[x].Cells[4].Value = c4.ToString("n0");
                            dgv10.Rows[x].Cells[5].Value = c5.ToString("n0");
                            dgv10.Rows[x].Cells[6].Value = c6.ToString("C2");
                            dgv10.Rows[x].Cells[7].Value = c7.ToString("n0");
                            if (c7 <= 0)
                            {
                                dgv10.Rows[x].Cells[7].Style.BackColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                dgv10.Rows[x].Cells[7].Style.BackColor = System.Drawing.Color.LawnGreen;
                            }
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 11:
                    #region cargar grid1
                    for (int x = 1; x <= dgv1.Rows.Count - 1; x++)
                    {
                        string q = "SELECT * FROM cedula6 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[(x - 1)];
                        cmd = new MySqlCommand(q, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["Uproductopor"].ToString());
                            c2 = double.Parse(reader["UproductoImp"].ToString());
                            c3 = double.Parse(reader["UfinanciamientoPor"].ToString());
                            c4 = double.Parse(reader["UfinanciamientoImp"].ToString());
                            c5 = double.Parse(reader["UdiasFin"].ToString());
                            c6 = double.Parse(reader["costoXdiasfin"].ToString());
                            c7 = double.Parse(reader["PoU"].ToString());
                            dgv11.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv11.Rows[x].Cells[2].Value = c2.ToString("C2");
                            dgv11.Rows[x].Cells[3].Value = c3.ToString("C2");
                            dgv11.Rows[x].Cells[4].Value = c4.ToString("n0");
                            dgv11.Rows[x].Cells[5].Value = c5.ToString("n0");
                            dgv11.Rows[x].Cells[6].Value = c6.ToString("C2");
                            dgv11.Rows[x].Cells[7].Value = c7.ToString("n0");
                            if (c7 <= 0)
                            {
                                dgv11.Rows[x].Cells[7].Style.BackColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                dgv11.Rows[x].Cells[7].Style.BackColor = System.Drawing.Color.LawnGreen;
                            }
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
                case 12:
                    #region cargar grid1
                    for (int x = 1; x <= dgv1.Rows.Count - 1; x++)
                    {
                        string q = "SELECT * FROM cedula6 where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[(x - 1)];
                        cmd = new MySqlCommand(q, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            c1 = double.Parse(reader["Uproductopor"].ToString());
                            c2 = double.Parse(reader["UproductoImp"].ToString());
                            c3 = double.Parse(reader["UfinanciamientoPor"].ToString());
                            c4 = double.Parse(reader["UfinanciamientoImp"].ToString());
                            c5 = double.Parse(reader["UdiasFin"].ToString());
                            c6 = double.Parse(reader["costoXdiasfin"].ToString());
                            c7 = double.Parse(reader["PoU"].ToString());
                            dgv12.Rows[x].Cells[1].Value = c1.ToString("n0");
                            dgv12.Rows[x].Cells[2].Value = c2.ToString("C2");
                            dgv12.Rows[x].Cells[3].Value = c3.ToString("C2");
                            dgv12.Rows[x].Cells[4].Value = c4.ToString("n0");
                            dgv12.Rows[x].Cells[5].Value = c5.ToString("n0");
                            dgv12.Rows[x].Cells[6].Value = c6.ToString("C2");
                            dgv12.Rows[x].Cells[7].Value = c7.ToString("n0");
                            if (c7 <= 0)
                            {
                                dgv12.Rows[x].Cells[7].Style.BackColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                dgv12.Rows[x].Cells[7].Style.BackColor = System.Drawing.Color.LawnGreen;
                            }
                        }
                        reader.Close();
                    }
                    #endregion
                    break;
            }
        }
        private void m_CALCULOS(int grid, int c, int z)
        {
            double interes = 0;
            if (textBox1.Text == "")
            {
                interes = 1;
            }
            else
            {
                interes = double.Parse(textBox1.Text);
            }
            switch (grid)
            {
                case 1:
                    #region operaciones
                    for (int x = 0; x <= dgv1.Rows.Count - 2; x++)
                    {
                        if (utilidadPor[x] != 0)
                        {
                            utilidadFinanciamientoPor[x] = utilidadPor[x] * interes;
                        }
                        else
                        {
                            utilidadFinanciamientoPor[x] = 0;
                        }
                        if (utilidadImp[x] != 0)
                        {
                            utilidadfinanciamientoImp[x] = utilidadImp[x] * interes;
                        }
                        else
                        {
                            utilidadfinanciamientoImp[x] = 0;
                        }
                        if (utilidadfinanciamientoImp[x] != 0 && inventario != 0)
                        {
                            utilidaddiasFin[x] = utilidadfinanciamientoImp[x] / inventario;
                        }
                        else
                        {
                            utilidaddiasFin[x] = 0;
                        }
                        if (promediocosto[x] == 0 || diasfin[x] == 0)
                        {
                            costoXdiasfinanciados[x] = 0;
                            utilidadperdidaXfinanciamiento[x] = 0;
                        }
                        else
                        {
                            costoXdiasfinanciados[x] = promediocosto[x] * diasfin[x];
                            utilidadperdidaXfinanciamiento[x] = costoXdiasfinanciados[x] * ZT;
                        }
                        if ((costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x]) <= 0)
                        {
                            perdida[x] = costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x];
                            utilidad[x] = 0;
                            dgv1.Rows[(x + 1)].Cells[7].Style.BackColor = System.Drawing.Color.Red;
                            dgv1.Rows[(x + 1)].Cells[7].Value = perdida[x].ToString("C0");

                        }
                        else
                        {
                            perdida[x] = 0;
                            utilidad[x] = costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x];
                            dgv1.Rows[(x + 1)].Cells[7].Style.BackColor = System.Drawing.Color.LawnGreen;
                            dgv1.Rows[(x + 1)].Cells[7].Value = utilidad[x].ToString("C0");
                        }
                        #region dgv
                        dgv1.Rows[(x + 1)].Cells[1].Value = utilidadPor[x].ToString("n0");
                        dgv1.Rows[(x + 1)].Cells[2].Value = utilidadImp[x].ToString("C2");
                        dgv1.Rows[(x + 1)].Cells[3].Value = utilidadFinanciamientoPor[x].ToString("n0");
                        dgv1.Rows[(x + 1)].Cells[4].Value = utilidadfinanciamientoImp[x].ToString("C2");
                        dgv1.Rows[(x + 1)].Cells[5].Value = utilidaddiasFin[x].ToString("n0");
                        dgv1.Rows[(x + 1)].Cells[6].Value = costoXdiasfinanciados[x].ToString("C2");
                        //dgv1.Rows[(x + 1)].Cells[8].Value = utilidad[x].ToString("C0");
                        #endregion
                    }
                    #endregion
                    break;
                case 2:
                    #region operaciones
                    for (int x = 0; x <= dgv1.Rows.Count - 2; x++)
                    {
                        if (utilidadPor[x] != 0)
                        {
                            utilidadFinanciamientoPor[x] = utilidadPor[x] * interes;
                        }
                        else
                        {
                            utilidadFinanciamientoPor[x] = 0;
                        }
                        if (utilidadImp[x] != 0)
                        {
                            utilidadfinanciamientoImp[x] = utilidadImp[x] * interes;
                        }
                        else
                        {
                            utilidadfinanciamientoImp[x] = 0;
                        }
                        if (utilidadfinanciamientoImp[x] != 0 && inventario != 0)
                        {
                            utilidaddiasFin[x] = utilidadfinanciamientoImp[x] / inventario;
                        }
                        else
                        {
                            utilidaddiasFin[x] = 0;
                        }
                        if (promediocosto[x] == 0 || diasfin[x] == 0)
                        {
                            costoXdiasfinanciados[x] = 0;
                            utilidadperdidaXfinanciamiento[x] = 0;
                        }
                        else
                        {
                            costoXdiasfinanciados[x] = promediocosto[x] * diasfin[x];
                            utilidadperdidaXfinanciamiento[x] = costoXdiasfinanciados[x] * ZT;
                        }
                        if ((costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x]) <= 0)
                        {
                            perdida[x] = costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x];
                            utilidad[x] = 0;
                            dgv2.Rows[(x + 1)].Cells[7].Style.BackColor = System.Drawing.Color.Red;
                            dgv2.Rows[(x + 1)].Cells[7].Value = perdida[x].ToString("C0");

                        }
                        else
                        {
                            perdida[x] = 0;
                            utilidad[x] = costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x];
                            dgv2.Rows[(x + 1)].Cells[7].Style.BackColor = System.Drawing.Color.LawnGreen;
                            dgv2.Rows[(x + 1)].Cells[7].Value = utilidad[x].ToString("C0");
                        }
                        #region dgv
                        dgv2.Rows[(x + 1)].Cells[1].Value = utilidadPor[x].ToString("n0");
                        dgv2.Rows[(x + 1)].Cells[2].Value = utilidadImp[x].ToString("C2");
                        dgv2.Rows[(x + 1)].Cells[3].Value = utilidadFinanciamientoPor[x].ToString("n0");
                        dgv2.Rows[(x + 1)].Cells[4].Value = utilidadfinanciamientoImp[x].ToString("C2");
                        dgv2.Rows[(x + 1)].Cells[5].Value = utilidaddiasFin[x].ToString("n0");
                        dgv2.Rows[(x + 1)].Cells[6].Value = costoXdiasfinanciados[x].ToString("C2");
                        //dgv1.Rows[(x + 1)].Cells[8].Value = utilidad[x].ToString("C0");
                        #endregion
                    }
                    #endregion
                    break;
                case 3:
                    #region operaciones
                    for (int x = 0; x <= dgv1.Rows.Count - 2; x++)
                    {
                        if (utilidadPor[x] != 0)
                        {
                            utilidadFinanciamientoPor[x] = utilidadPor[x] * interes;
                        }
                        else
                        {
                            utilidadFinanciamientoPor[x] = 0;
                        }
                        if (utilidadImp[x] != 0)
                        {
                            utilidadfinanciamientoImp[x] = utilidadImp[x] * interes;
                        }
                        else
                        {
                            utilidadfinanciamientoImp[x] = 0;
                        }
                        if (utilidadfinanciamientoImp[x] != 0 && inventario != 0)
                        {
                            utilidaddiasFin[x] = utilidadfinanciamientoImp[x] / inventario;
                        }
                        else
                        {
                            utilidaddiasFin[x] = 0;
                        }
                        if (promediocosto[x] == 0 || diasfin[x] == 0)
                        {
                            costoXdiasfinanciados[x] = 0;
                            utilidadperdidaXfinanciamiento[x] = 0;
                        }
                        else
                        {
                            costoXdiasfinanciados[x] = promediocosto[x] * diasfin[x];
                            utilidadperdidaXfinanciamiento[x] = costoXdiasfinanciados[x] * ZT;
                        }
                        if ((costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x]) <= 0)
                        {
                            perdida[x] = costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x];
                            utilidad[x] = 0;
                            dgv3.Rows[(x + 1)].Cells[7].Style.BackColor = System.Drawing.Color.Red;
                            dgv3.Rows[(x + 1)].Cells[7].Value = perdida[x].ToString("C0");

                        }
                        else
                        {
                            perdida[x] = 0;
                            utilidad[x] = costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x];
                            dgv3.Rows[(x + 1)].Cells[7].Style.BackColor = System.Drawing.Color.LawnGreen;
                            dgv3.Rows[(x + 1)].Cells[7].Value = utilidad[x].ToString("C0");
                        }
                        #region dgv
                        dgv3.Rows[(x + 1)].Cells[1].Value = utilidadPor[x].ToString("n0");
                        dgv3.Rows[(x + 1)].Cells[2].Value = utilidadImp[x].ToString("C2");
                        dgv3.Rows[(x + 1)].Cells[3].Value = utilidadFinanciamientoPor[x].ToString("n0");
                        dgv3.Rows[(x + 1)].Cells[4].Value = utilidadfinanciamientoImp[x].ToString("C2");
                        dgv3.Rows[(x + 1)].Cells[5].Value = utilidaddiasFin[x].ToString("n0");
                        dgv3.Rows[(x + 1)].Cells[6].Value = costoXdiasfinanciados[x].ToString("C2");
                        //dgv3.Rows[(x + 1)].Cells[8].Value = utilidad[x].ToString("C0");
                        #endregion
                    }
                    #endregion
                    break;
                case 4:
                    #region operaciones
                    for (int x = 0; x <= dgv1.Rows.Count - 2; x++)
                    {
                        if (utilidadPor[x] != 0)
                        {
                            utilidadFinanciamientoPor[x] = utilidadPor[x] * interes;
                        }
                        else
                        {
                            utilidadFinanciamientoPor[x] = 0;
                        }
                        if (utilidadImp[x] != 0)
                        {
                            utilidadfinanciamientoImp[x] = utilidadImp[x] * interes;
                        }
                        else
                        {
                            utilidadfinanciamientoImp[x] = 0;
                        }
                        if (utilidadfinanciamientoImp[x] != 0 && inventario != 0)
                        {
                            utilidaddiasFin[x] = utilidadfinanciamientoImp[x] / inventario;
                        }
                        else
                        {
                            utilidaddiasFin[x] = 0;
                        }
                        if (promediocosto[x] == 0 || diasfin[x] == 0)
                        {
                            costoXdiasfinanciados[x] = 0;
                            utilidadperdidaXfinanciamiento[x] = 0;
                        }
                        else
                        {
                            costoXdiasfinanciados[x] = promediocosto[x] * diasfin[x];
                            utilidadperdidaXfinanciamiento[x] = costoXdiasfinanciados[x] * ZT;
                        }
                        if ((costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x]) <= 0)
                        {
                            perdida[x] = costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x];
                            utilidad[x] = 0;
                            dgv4.Rows[(x + 1)].Cells[7].Style.BackColor = System.Drawing.Color.Red;
                            dgv4.Rows[(x + 1)].Cells[7].Value = perdida[x].ToString("C0");

                        }
                        else
                        {
                            perdida[x] = 0;
                            utilidad[x] = costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x];
                            dgv4.Rows[(x + 1)].Cells[7].Style.BackColor = System.Drawing.Color.LawnGreen;
                            dgv4.Rows[(x + 1)].Cells[7].Value = utilidad[x].ToString("C0");
                        }
                        #region dgv
                        dgv4.Rows[(x + 1)].Cells[1].Value = utilidadPor[x].ToString("n0");
                        dgv4.Rows[(x + 1)].Cells[2].Value = utilidadImp[x].ToString("C2");
                        dgv4.Rows[(x + 1)].Cells[3].Value = utilidadFinanciamientoPor[x].ToString("n0");
                        dgv4.Rows[(x + 1)].Cells[4].Value = utilidadfinanciamientoImp[x].ToString("C2");
                        dgv4.Rows[(x + 1)].Cells[5].Value = utilidaddiasFin[x].ToString("n0");
                        dgv4.Rows[(x + 1)].Cells[6].Value = costoXdiasfinanciados[x].ToString("C2");
                        //dgv4.Rows[(x + 1)].Cells[8].Value = utilidad[x].ToString("C0");
                        #endregion
                    }
                    #endregion
                    break;
                case 5:
                    #region operaciones
                    for (int x = 0; x <= dgv1.Rows.Count - 2; x++)
                    {
                        if (utilidadPor[x] != 0)
                        {
                            utilidadFinanciamientoPor[x] = utilidadPor[x] * interes;
                        }
                        else
                        {
                            utilidadFinanciamientoPor[x] = 0;
                        }
                        if (utilidadImp[x] != 0)
                        {
                            utilidadfinanciamientoImp[x] = utilidadImp[x] * interes;
                        }
                        else
                        {
                            utilidadfinanciamientoImp[x] = 0;
                        }
                        if (utilidadfinanciamientoImp[x] != 0 && inventario != 0)
                        {
                            utilidaddiasFin[x] = utilidadfinanciamientoImp[x] / inventario;
                        }
                        else
                        {
                            utilidaddiasFin[x] = 0;
                        }
                        if (promediocosto[x] == 0 || diasfin[x] == 0)
                        {
                            costoXdiasfinanciados[x] = 0;
                            utilidadperdidaXfinanciamiento[x] = 0;
                        }
                        else
                        {
                            costoXdiasfinanciados[x] = promediocosto[x] * diasfin[x];
                            utilidadperdidaXfinanciamiento[x] = costoXdiasfinanciados[x] * ZT;
                        }
                        if ((costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x]) <= 0)
                        {
                            perdida[x] = costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x];
                            utilidad[x] = 0;
                            dgv5.Rows[(x + 1)].Cells[7].Style.BackColor = System.Drawing.Color.Red;
                            dgv5.Rows[(x + 1)].Cells[7].Value = perdida[x].ToString("C0");

                        }
                        else
                        {
                            perdida[x] = 0;
                            utilidad[x] = costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x];
                            dgv5.Rows[(x + 1)].Cells[7].Style.BackColor = System.Drawing.Color.LawnGreen;
                            dgv5.Rows[(x + 1)].Cells[7].Value = utilidad[x].ToString("C0");
                        }
                        #region dgv
                        dgv5.Rows[(x + 1)].Cells[1].Value = utilidadPor[x].ToString("n0");
                        dgv5.Rows[(x + 1)].Cells[2].Value = utilidadImp[x].ToString("C2");
                        dgv5.Rows[(x + 1)].Cells[3].Value = utilidadFinanciamientoPor[x].ToString("n0");
                        dgv5.Rows[(x + 1)].Cells[4].Value = utilidadfinanciamientoImp[x].ToString("C2");
                        dgv5.Rows[(x + 1)].Cells[5].Value = utilidaddiasFin[x].ToString("n0");
                        dgv5.Rows[(x + 1)].Cells[6].Value = costoXdiasfinanciados[x].ToString("C2");
                        //dgv5.Rows[(x + 1)].Cells[8].Value = utilidad[x].ToString("C0");
                        #endregion
                    }
                    #endregion
                    break;
                case 6:
                    #region operaciones
                    for (int x = 0; x <= dgv1.Rows.Count - 2; x++)
                    {
                        if (utilidadPor[x] != 0)
                        {
                            utilidadFinanciamientoPor[x] = utilidadPor[x] * interes;
                        }
                        else
                        {
                            utilidadFinanciamientoPor[x] = 0;
                        }
                        if (utilidadImp[x] != 0)
                        {
                            utilidadfinanciamientoImp[x] = utilidadImp[x] * interes;
                        }
                        else
                        {
                            utilidadfinanciamientoImp[x] = 0;
                        }
                        if (utilidadfinanciamientoImp[x] != 0 && inventario != 0)
                        {
                            utilidaddiasFin[x] = utilidadfinanciamientoImp[x] / inventario;
                        }
                        else
                        {
                            utilidaddiasFin[x] = 0;
                        }
                        if (promediocosto[x] == 0 || diasfin[x] == 0)
                        {
                            costoXdiasfinanciados[x] = 0;
                            utilidadperdidaXfinanciamiento[x] = 0;
                        }
                        else
                        {
                            costoXdiasfinanciados[x] = promediocosto[x] * diasfin[x];
                            utilidadperdidaXfinanciamiento[x] = costoXdiasfinanciados[x] * ZT;
                        }
                        if ((costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x]) <= 0)
                        {
                            perdida[x] = costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x];
                            utilidad[x] = 0;
                            dgv6.Rows[(x + 1)].Cells[7].Style.BackColor = System.Drawing.Color.Red;
                            dgv6.Rows[(x + 1)].Cells[7].Value = perdida[x].ToString("C0");

                        }
                        else
                        {
                            perdida[x] = 0;
                            utilidad[x] = costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x];
                            dgv6.Rows[(x + 1)].Cells[7].Style.BackColor = System.Drawing.Color.LawnGreen;
                            dgv6.Rows[(x + 1)].Cells[7].Value = utilidad[x].ToString("C0");
                        }
                        #region dgv
                        dgv6.Rows[(x + 1)].Cells[1].Value = utilidadPor[x].ToString("n0");
                        dgv6.Rows[(x + 1)].Cells[2].Value = utilidadImp[x].ToString("C2");
                        dgv6.Rows[(x + 1)].Cells[3].Value = utilidadFinanciamientoPor[x].ToString("n0");
                        dgv6.Rows[(x + 1)].Cells[4].Value = utilidadfinanciamientoImp[x].ToString("C2");
                        dgv6.Rows[(x + 1)].Cells[5].Value = utilidaddiasFin[x].ToString("n0");
                        dgv6.Rows[(x + 1)].Cells[6].Value = costoXdiasfinanciados[x].ToString("C2");
                        //dgv1.Rows[(x + 1)].Cells[8].Value = utilidad[x].ToString("C0");
                        #endregion
                    }
                    #endregion
                    break;
                case 7:
                    #region operaciones
                    for (int x = 0; x <= dgv1.Rows.Count - 2; x++)
                    {
                        if (utilidadPor[x] != 0)
                        {
                            utilidadFinanciamientoPor[x] = utilidadPor[x] * interes;
                        }
                        else
                        {
                            utilidadFinanciamientoPor[x] = 0;
                        }
                        if (utilidadImp[x] != 0)
                        {
                            utilidadfinanciamientoImp[x] = utilidadImp[x] * interes;
                        }
                        else
                        {
                            utilidadfinanciamientoImp[x] = 0;
                        }
                        if (utilidadfinanciamientoImp[x] != 0 && inventario != 0)
                        {
                            utilidaddiasFin[x] = utilidadfinanciamientoImp[x] / inventario;
                        }
                        else
                        {
                            utilidaddiasFin[x] = 0;
                        }
                        if (promediocosto[x] == 0 || diasfin[x] == 0)
                        {
                            costoXdiasfinanciados[x] = 0;
                            utilidadperdidaXfinanciamiento[x] = 0;
                        }
                        else
                        {
                            costoXdiasfinanciados[x] = promediocosto[x] * diasfin[x];
                            utilidadperdidaXfinanciamiento[x] = costoXdiasfinanciados[x] * ZT;
                        }
                        if ((costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x]) <= 0)
                        {
                            perdida[x] = costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x];
                            utilidad[x] = 0;
                            dgv7.Rows[(x + 1)].Cells[7].Style.BackColor = System.Drawing.Color.Red;
                            dgv7.Rows[(x + 1)].Cells[7].Value = perdida[x].ToString("C0");

                        }
                        else
                        {
                            perdida[x] = 0;
                            utilidad[x] = costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x];
                            dgv7.Rows[(x + 1)].Cells[7].Style.BackColor = System.Drawing.Color.LawnGreen;
                            dgv7.Rows[(x + 1)].Cells[7].Value = utilidad[x].ToString("C0");
                        }
                        #region dgv
                        dgv7.Rows[(x + 1)].Cells[1].Value = utilidadPor[x].ToString("n0");
                        dgv7.Rows[(x + 1)].Cells[2].Value = utilidadImp[x].ToString("C2");
                        dgv7.Rows[(x + 1)].Cells[3].Value = utilidadFinanciamientoPor[x].ToString("n0");
                        dgv7.Rows[(x + 1)].Cells[4].Value = utilidadfinanciamientoImp[x].ToString("C2");
                        dgv7.Rows[(x + 1)].Cells[5].Value = utilidaddiasFin[x].ToString("n0");
                        dgv7.Rows[(x + 1)].Cells[6].Value = costoXdiasfinanciados[x].ToString("C2");
                        //dgv7.Rows[(x + 1)].Cells[8].Value = utilidad[x].ToString("C0");
                        #endregion
                    }
                    #endregion
                    break;
                case 8:
                    #region operaciones
                    for (int x = 0; x <= dgv1.Rows.Count - 2; x++)
                    {
                        if (utilidadPor[x] != 0)
                        {
                            utilidadFinanciamientoPor[x] = utilidadPor[x] * interes;
                        }
                        else
                        {
                            utilidadFinanciamientoPor[x] = 0;
                        }
                        if (utilidadImp[x] != 0)
                        {
                            utilidadfinanciamientoImp[x] = utilidadImp[x] * interes;
                        }
                        else
                        {
                            utilidadfinanciamientoImp[x] = 0;
                        }
                        if (utilidadfinanciamientoImp[x] != 0 && inventario != 0)
                        {
                            utilidaddiasFin[x] = utilidadfinanciamientoImp[x] / inventario;
                        }
                        else
                        {
                            utilidaddiasFin[x] = 0;
                        }
                        if (promediocosto[x] == 0 || diasfin[x] == 0)
                        {
                            costoXdiasfinanciados[x] = 0;
                            utilidadperdidaXfinanciamiento[x] = 0;
                        }
                        else
                        {
                            costoXdiasfinanciados[x] = promediocosto[x] * diasfin[x];
                            utilidadperdidaXfinanciamiento[x] = costoXdiasfinanciados[x] * ZT;
                        }
                        if ((costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x]) <= 0)
                        {
                            perdida[x] = costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x];
                            utilidad[x] = 0;
                            dgv8.Rows[(x + 1)].Cells[7].Style.BackColor = System.Drawing.Color.Red;
                            dgv8.Rows[(x + 1)].Cells[7].Value = perdida[x].ToString("C0");

                        }
                        else
                        {
                            perdida[x] = 0;
                            utilidad[x] = costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x];
                            dgv8.Rows[(x + 1)].Cells[7].Style.BackColor = System.Drawing.Color.LawnGreen;
                            dgv8.Rows[(x + 1)].Cells[7].Value = utilidad[x].ToString("C0");
                        }
                        #region dgv
                        dgv8.Rows[(x + 1)].Cells[1].Value = utilidadPor[x].ToString("n0");
                        dgv8.Rows[(x + 1)].Cells[2].Value = utilidadImp[x].ToString("C2");
                        dgv8.Rows[(x + 1)].Cells[3].Value = utilidadFinanciamientoPor[x].ToString("n0");
                        dgv8.Rows[(x + 1)].Cells[4].Value = utilidadfinanciamientoImp[x].ToString("C2");
                        dgv8.Rows[(x + 1)].Cells[5].Value = utilidaddiasFin[x].ToString("n0");
                        dgv8.Rows[(x + 1)].Cells[6].Value = costoXdiasfinanciados[x].ToString("C2");
                        //dgv8.Rows[(x + 1)].Cells[8].Value = utilidad[x].ToString("C0");
                        #endregion
                    }
                    #endregion
                    break;
                case 9:
                    #region operaciones
                    for (int x = 0; x <= dgv1.Rows.Count - 2; x++)
                    {
                        if (utilidadPor[x] != 0)
                        {
                            utilidadFinanciamientoPor[x] = utilidadPor[x] * interes;
                        }
                        else
                        {
                            utilidadFinanciamientoPor[x] = 0;
                        }
                        if (utilidadImp[x] != 0)
                        {
                            utilidadfinanciamientoImp[x] = utilidadImp[x] * interes;
                        }
                        else
                        {
                            utilidadfinanciamientoImp[x] = 0;
                        }
                        if (utilidadfinanciamientoImp[x] != 0 && inventario != 0)
                        {
                            utilidaddiasFin[x] = utilidadfinanciamientoImp[x] / inventario;
                        }
                        else
                        {
                            utilidaddiasFin[x] = 0;
                        }
                        if (promediocosto[x] == 0 || diasfin[x] == 0)
                        {
                            costoXdiasfinanciados[x] = 0;
                            utilidadperdidaXfinanciamiento[x] = 0;
                        }
                        else
                        {
                            costoXdiasfinanciados[x] = promediocosto[x] * diasfin[x];
                            utilidadperdidaXfinanciamiento[x] = costoXdiasfinanciados[x] * ZT;
                        }
                        if ((costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x]) <= 0)
                        {
                            perdida[x] = costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x];
                            utilidad[x] = 0;
                            dgv9.Rows[(x + 1)].Cells[7].Style.BackColor = System.Drawing.Color.Red;
                            dgv9.Rows[(x + 1)].Cells[7].Value = perdida[x].ToString("C0");

                        }
                        else
                        {
                            perdida[x] = 0;
                            utilidad[x] = costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x];
                            dgv9.Rows[(x + 1)].Cells[7].Style.BackColor = System.Drawing.Color.LawnGreen;
                            dgv9.Rows[(x + 1)].Cells[7].Value = utilidad[x].ToString("C0");
                        }
                        #region dgv
                        dgv9.Rows[(x + 1)].Cells[1].Value = utilidadPor[x].ToString("n0");
                        dgv9.Rows[(x + 1)].Cells[2].Value = utilidadImp[x].ToString("C2");
                        dgv9.Rows[(x + 1)].Cells[3].Value = utilidadFinanciamientoPor[x].ToString("n0");
                        dgv9.Rows[(x + 1)].Cells[4].Value = utilidadfinanciamientoImp[x].ToString("C2");
                        dgv9.Rows[(x + 1)].Cells[5].Value = utilidaddiasFin[x].ToString("n0");
                        dgv9.Rows[(x + 1)].Cells[6].Value = costoXdiasfinanciados[x].ToString("C2");
                        //dgv9.Rows[(x + 1)].Cells[8].Value = utilidad[x].ToString("C0");
                        #endregion
                    }
                    #endregion
                    break;
                case 10:
                    #region operaciones
                    for (int x = 0; x <= dgv1.Rows.Count - 2; x++)
                    {
                        if (utilidadPor[x] != 0)
                        {
                            utilidadFinanciamientoPor[x] = utilidadPor[x] * interes;
                        }
                        else
                        {
                            utilidadFinanciamientoPor[x] = 0;
                        }
                        if (utilidadImp[x] != 0)
                        {
                            utilidadfinanciamientoImp[x] = utilidadImp[x] * interes;
                        }
                        else
                        {
                            utilidadfinanciamientoImp[x] = 0;
                        }
                        if (utilidadfinanciamientoImp[x] != 0 && inventario != 0)
                        {
                            utilidaddiasFin[x] = utilidadfinanciamientoImp[x] / inventario;
                        }
                        else
                        {
                            utilidaddiasFin[x] = 0;
                        }
                        if (promediocosto[x] == 0 || diasfin[x] == 0)
                        {
                            costoXdiasfinanciados[x] = 0;
                            utilidadperdidaXfinanciamiento[x] = 0;
                        }
                        else
                        {
                            costoXdiasfinanciados[x] = promediocosto[x] * diasfin[x];
                            utilidadperdidaXfinanciamiento[x] = costoXdiasfinanciados[x] * ZT;
                        }
                        if ((costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x]) <= 0)
                        {
                            perdida[x] = costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x];
                            utilidad[x] = 0;
                            dgv10.Rows[(x + 1)].Cells[7].Style.BackColor = System.Drawing.Color.Red;
                            dgv10.Rows[(x + 1)].Cells[7].Value = perdida[x].ToString("C0");

                        }
                        else
                        {
                            perdida[x] = 0;
                            utilidad[x] = costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x];
                            dgv10.Rows[(x + 1)].Cells[7].Style.BackColor = System.Drawing.Color.LawnGreen;
                            dgv10.Rows[(x + 1)].Cells[7].Value = utilidad[x].ToString("C0");
                        }
                        #region dgv
                        dgv10.Rows[(x + 1)].Cells[1].Value = utilidadPor[x].ToString("n0");
                        dgv10.Rows[(x + 1)].Cells[2].Value = utilidadImp[x].ToString("C2");
                        dgv10.Rows[(x + 1)].Cells[3].Value = utilidadFinanciamientoPor[x].ToString("n0");
                        dgv10.Rows[(x + 1)].Cells[4].Value = utilidadfinanciamientoImp[x].ToString("C2");
                        dgv10.Rows[(x + 1)].Cells[5].Value = utilidaddiasFin[x].ToString("n0");
                        dgv10.Rows[(x + 1)].Cells[6].Value = costoXdiasfinanciados[x].ToString("C2");
                        //dgv10.Rows[(x + 1)].Cells[8].Value = utilidad[x].ToString("C0");
                        #endregion
                    }
                    #endregion
                    break;
                case 11:
                    #region operaciones
                    for (int x = 0; x <= dgv1.Rows.Count - 2; x++)
                    {
                        if (utilidadPor[x] != 0)
                        {
                            utilidadFinanciamientoPor[x] = utilidadPor[x] * interes;
                        }
                        else
                        {
                            utilidadFinanciamientoPor[x] = 0;
                        }
                        if (utilidadImp[x] != 0)
                        {
                            utilidadfinanciamientoImp[x] = utilidadImp[x] * interes;
                        }
                        else
                        {
                            utilidadfinanciamientoImp[x] = 0;
                        }
                        if (utilidadfinanciamientoImp[x] != 0 && inventario != 0)
                        {
                            utilidaddiasFin[x] = utilidadfinanciamientoImp[x] / inventario;
                        }
                        else
                        {
                            utilidaddiasFin[x] = 0;
                        }
                        if (promediocosto[x] == 0 || diasfin[x] == 0)
                        {
                            costoXdiasfinanciados[x] = 0;
                            utilidadperdidaXfinanciamiento[x] = 0;
                        }
                        else
                        {
                            costoXdiasfinanciados[x] = promediocosto[x] * diasfin[x];
                            utilidadperdidaXfinanciamiento[x] = costoXdiasfinanciados[x] * ZT;
                        }
                        if ((costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x]) <= 0)
                        {
                            perdida[x] = costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x];
                            utilidad[x] = 0;
                            dgv11.Rows[(x + 1)].Cells[7].Style.BackColor = System.Drawing.Color.Red;
                            dgv11.Rows[(x + 1)].Cells[7].Value = perdida[x].ToString("C0");

                        }
                        else
                        {
                            perdida[x] = 0;
                            utilidad[x] = costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x];
                            dgv11.Rows[(x + 1)].Cells[7].Style.BackColor = System.Drawing.Color.LawnGreen;
                            dgv11.Rows[(x + 1)].Cells[7].Value = utilidad[x].ToString("C0");
                        }
                        #region dgv
                        dgv11.Rows[(x + 1)].Cells[1].Value = utilidadPor[x].ToString("n0");
                        dgv11.Rows[(x + 1)].Cells[2].Value = utilidadImp[x].ToString("C2");
                        dgv11.Rows[(x + 1)].Cells[3].Value = utilidadFinanciamientoPor[x].ToString("n0");
                        dgv11.Rows[(x + 1)].Cells[4].Value = utilidadfinanciamientoImp[x].ToString("C2");
                        dgv11.Rows[(x + 1)].Cells[5].Value = utilidaddiasFin[x].ToString("n0");
                        dgv11.Rows[(x + 1)].Cells[6].Value = costoXdiasfinanciados[x].ToString("C2");
                        //dgv11.Rows[(x + 1)].Cells[8].Value = utilidad[x].ToString("C0");
                        #endregion
                    }
                    #endregion
                    break;
                case 12:
                    #region operaciones
                    for (int x = 0; x <= dgv1.Rows.Count - 2; x++)
                    {
                        if (utilidadPor[x] != 0)
                        {
                            utilidadFinanciamientoPor[x] = utilidadPor[x] * interes;
                        }
                        else
                        {
                            utilidadFinanciamientoPor[x] = 0;
                        }
                        if (utilidadImp[x] != 0)
                        {
                            utilidadfinanciamientoImp[x] = utilidadImp[x] * interes;
                        }
                        else
                        {
                            utilidadfinanciamientoImp[x] = 0;
                        }
                        if (utilidadfinanciamientoImp[x] != 0 && inventario != 0)
                        {
                            utilidaddiasFin[x] = utilidadfinanciamientoImp[x] / inventario;
                        }
                        else
                        {
                            utilidaddiasFin[x] = 0;
                        }
                        if (promediocosto[x] == 0 || diasfin[x] == 0)
                        {
                            costoXdiasfinanciados[x] = 0;
                            utilidadperdidaXfinanciamiento[x] = 0;
                        }
                        else
                        {
                            costoXdiasfinanciados[x] = promediocosto[x] * diasfin[x];
                            utilidadperdidaXfinanciamiento[x] = costoXdiasfinanciados[x] * ZT;
                        }
                        if ((costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x]) <= 0)
                        {
                            perdida[x] = costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x];
                            utilidad[x] = 0;
                            dgv12.Rows[(x+1)].Cells[7].Style.BackColor = System.Drawing.Color.Red;
                            dgv12.Rows[(x + 1)].Cells[7].Value = perdida[x].ToString("C0");

                        }
                        else
                        {
                            perdida[x] = 0;
                            utilidad[x] = costoXdiasfinanciados[x] - utilidadperdidaXfinanciamiento[x];
                            dgv12.Rows[(x + 1)].Cells[7].Style.BackColor = System.Drawing.Color.LawnGreen;
                            dgv12.Rows[(x + 1)].Cells[7].Value = utilidad[x].ToString("C0");
                        }
                        #region dgv
                        dgv12.Rows[(x + 1)].Cells[1].Value = utilidadPor[x].ToString("n0");
                        dgv12.Rows[(x + 1)].Cells[2].Value = utilidadImp[x].ToString("C2");
                        dgv12.Rows[(x + 1)].Cells[3].Value = utilidadFinanciamientoPor[x].ToString("n0");
                        dgv12.Rows[(x + 1)].Cells[4].Value = utilidadfinanciamientoImp[x].ToString("C2");
                        dgv12.Rows[(x + 1)].Cells[5].Value = utilidaddiasFin[x].ToString("n0");
                        dgv12.Rows[(x + 1)].Cells[6].Value = costoXdiasfinanciados[x].ToString("C2");
                        //dgv12.Rows[(x + 1)].Cells[8].Value = utilidad[x].ToString("C0");
                        #endregion
                    }
                    #endregion
                    break;
            }
        }
        private void m_utilidad_ced4(int año, int mes, int i)
        {
            for (int x = 0; x <= dgv1.Rows.Count - 2; x++)
            {
                query = "SELECT utilidadPor , utilidadImp FROM cedula4 WHERE Escenario='" + Properties.Settings.Default.escenario + "' AND mes=" + mes.ToString();
                cmd = new MySqlCommand(query, Conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    utilidadImp[x] = double.Parse(reader["utilidadImp"].ToString());
                    utilidadPor[x] = double.Parse(reader["utilidadPor"].ToString());
                }
                reader.Close();
            }
        }
        private void m_inventario_ced1()
        {
            query = "SELECT Inventariodeseado FROM cedula1 WHERE nombre='" + Properties.Settings.Default.escenario + "' ;";
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                inventario = double.Parse(reader["Inventariodeseado"].ToString());
            }
            reader.Close();
        }
        private void btnSimular_Click(object sender, EventArgs e)
        {
            m_DIASMESESANOS(CED1_fechaI, CED1_fechaF);
        }
        private void m_promedioaCosto(int año, int mes, int i)
        {
            for (int x = 0; x <= dgv1.Rows.Count - 2; x++)
            {
                string s = "SELECT ((SUM(costomargenneto))/(SUM(ctdneta))) AS prom FROM VENTASBASE AS V INNER JOIN SUCURSAL AS S ON V.IDSUCURSAL = S.IDSUCURSAL INNER JOIN FECHA AS F ON F.IDFECHA = V.IDFECHA WHERE  F.fecha betwen '" + FechaAI.ToString("yyyy-MM-dd") + "' and '" + FechaAF.ToString("yyyy-MM-dd") + "' and f.mes='" + mes + "' and f.anio='" + año + "' " + wherequery[x];
                cmd = new MySqlCommand(s, Conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["prom"].ToString() != "")
                    {
                        promediocosto[x] = double.Parse(reader["prom"].ToString());
                    }
                    else
                    {
                        promediocosto[x] = 0;
                    }
                }
                reader.Close();
            }
        }
        private void m_DiasFin()
        {
            for (int x = 0; x <= dgv1.Rows.Count - 2; x++)
            {
                string s = "SELECT diasfin FROM cedula5b WHERE nombre='" + Properties.Settings.Default.escenario + "'  and mes=" + (x + 1) + ";";
                cmd = new MySqlCommand(s, Conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["diasfin"].ToString() != "")
                    {
                        diasfin[x] = double.Parse(reader["diasfin"].ToString());
                    }
                    else
                    {
                        diasfin[x] = 0;
                    }
                }
                reader.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
                string s = "SELECT * FROM cedula6 where nombre='" + Properties.Settings.Default.escenario + "' and anio=" + año + " and mes=" + mes + " " + querycargar[(x - 1)];
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
                    string s = "insert into cedula6 (nombre,UproductoPor,Uproductoimp,UfinanciamientoPor,UfinanciamientoImp,UdiasFin,costoXdiasfin,PoU,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[(renglon - 1)] + ")";
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
                    s = "insert into cedula6 (nombre,UproductoPor,Uproductoimp,UfinanciamientoPor,UfinanciamientoImp,UdiasFin,costoXdiasfin,PoU,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[(renglon - 1)] + ")";
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
                    s = "insert into cedula6 (nombre,UproductoPor,Uproductoimp,UfinanciamientoPor,UfinanciamientoImp,UdiasFin,costoXdiasfin,PoU,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[(renglon - 1)] + ")";
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
                    s = "insert into cedula6 (nombre,UproductoPor,Uproductoimp,UfinanciamientoPor,UfinanciamientoImp,UdiasFin,costoXdiasfin,PoU,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[(renglon - 1)] + ")";
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
                    s = "insert into cedula6 (nombre,UproductoPor,Uproductoimp,UfinanciamientoPor,UfinanciamientoImp,UdiasFin,costoXdiasfin,PoU,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[(renglon - 1)] + ")";
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
                    s = "insert into cedula6 (nombre,UproductoPor,Uproductoimp,UfinanciamientoPor,UfinanciamientoImp,UdiasFin,costoXdiasfin,PoU,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[(renglon - 1)] + ")";
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
                    s = "insert into cedula6 (nombre,UproductoPor,Uproductoimp,UfinanciamientoPor,UfinanciamientoImp,UdiasFin,costoXdiasfin,PoU,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[(renglon - 1)] + ")";
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
                    s = "insert into cedula6 (nombre,UproductoPor,Uproductoimp,UfinanciamientoPor,UfinanciamientoImp,UdiasFin,costoXdiasfin,PoU,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[(renglon - 1)] + ")";
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
                    s = "insert into cedula6 (nombre,UproductoPor,Uproductoimp,UfinanciamientoPor,UfinanciamientoImp,UdiasFin,costoXdiasfin,PoU,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[(renglon - 1)] + ")";
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
                    s = "insert into cedula6 (nombre,UproductoPor,Uproductoimp,UfinanciamientoPor,UfinanciamientoImp,UdiasFin,costoXdiasfin,PoU,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[(renglon - 1)] + ")";
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
                    s = "insert into cedula6 (nombre,UproductoPor,Uproductoimp,UfinanciamientoPor,UfinanciamientoImp,UdiasFin,costoXdiasfin,PoU,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[(renglon - 1)] + ")";
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
                    s = "insert into cedula6 (nombre,UproductoPor,Uproductoimp,UfinanciamientoPor,UfinanciamientoImp,UdiasFin,costoXdiasfin,PoU,mes,anio,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + mes.ToString() + "," + año.ToString() + " " + queryguardar[(renglon - 1)] + ")";
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
                    string q = "update cedula6  set UproductoPor=" + c1.ToString() + ",Uproductoimp=" + c2.ToString() + ",UfinanciamientoPor=" + c3.ToString() + ",UfinanciamientoImp=" + c4.ToString() + ",UdiasFin=" + c5.ToString() + ",costoXdiasfin=" + c6.ToString() + ",PoU=" + c7.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[(renglon - 1)];
                    cmd = new MySqlCommand(q, Conn);
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
                    q = "update cedula6  set UproductoPor=" + c1.ToString() + ",Uproductoimp=" + c2.ToString() + ",UfinanciamientoPor=" + c3.ToString() + ",UfinanciamientoImp=" + c4.ToString() + ",UdiasFin=" + c5.ToString() + ",costoXdiasfin=" + c6.ToString() + ",PoU=" + c7.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[(renglon - 1)];
                    cmd = new MySqlCommand(q, Conn);
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
                    q = "update cedula6  set UproductoPor=" + c1.ToString() + ",Uproductoimp=" + c2.ToString() + ",UfinanciamientoPor=" + c3.ToString() + ",UfinanciamientoImp=" + c4.ToString() + ",UdiasFin=" + c5.ToString() + ",costoXdiasfin=" + c6.ToString() + ",PoU=" + c7.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[(renglon - 1)];
                    cmd = new MySqlCommand(q, Conn);
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
                    q = "update cedula6  set UproductoPor=" + c1.ToString() + ",Uproductoimp=" + c2.ToString() + ",UfinanciamientoPor=" + c3.ToString() + ",UfinanciamientoImp=" + c4.ToString() + ",UdiasFin=" + c5.ToString() + ",costoXdiasfin=" + c6.ToString() + ",PoU=" + c7.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[(renglon - 1)];
                    cmd = new MySqlCommand(q, Conn);
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
                    q = "update cedula6  set UproductoPor=" + c1.ToString() + ",Uproductoimp=" + c2.ToString() + ",UfinanciamientoPor=" + c3.ToString() + ",UfinanciamientoImp=" + c4.ToString() + ",UdiasFin=" + c5.ToString() + ",costoXdiasfin=" + c6.ToString() + ",PoU=" + c7.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[(renglon - 1)];
                    cmd = new MySqlCommand(q, Conn);
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
                    q = "update cedula6  set UproductoPor=" + c1.ToString() + ",Uproductoimp=" + c2.ToString() + ",UfinanciamientoPor=" + c3.ToString() + ",UfinanciamientoImp=" + c4.ToString() + ",UdiasFin=" + c5.ToString() + ",costoXdiasfin=" + c6.ToString() + ",PoU=" + c7.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[(renglon - 1)];
                    cmd = new MySqlCommand(q, Conn);
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
                    q = "update cedula6  set UproductoPor=" + c1.ToString() + ",Uproductoimp=" + c2.ToString() + ",UfinanciamientoPor=" + c3.ToString() + ",UfinanciamientoImp=" + c4.ToString() + ",UdiasFin=" + c5.ToString() + ",costoXdiasfin=" + c6.ToString() + ",PoU=" + c7.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[(renglon - 1)];
                    cmd = new MySqlCommand(q, Conn);
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
                    q = "update cedula6  set UproductoPor=" + c1.ToString() + ",Uproductoimp=" + c2.ToString() + ",UfinanciamientoPor=" + c3.ToString() + ",UfinanciamientoImp=" + c4.ToString() + ",UdiasFin=" + c5.ToString() + ",costoXdiasfin=" + c6.ToString() + ",PoU=" + c7.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[(renglon - 1)];
                    cmd = new MySqlCommand(q, Conn);
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
                    q = "update cedula6  set UproductoPor=" + c1.ToString() + ",Uproductoimp=" + c2.ToString() + ",UfinanciamientoPor=" + c3.ToString() + ",UfinanciamientoImp=" + c4.ToString() + ",UdiasFin=" + c5.ToString() + ",costoXdiasfin=" + c6.ToString() + ",PoU=" + c7.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[(renglon - 1)];
                    cmd = new MySqlCommand(q, Conn);
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
                    q = "update cedula6  set UproductoPor=" + c1.ToString() + ",Uproductoimp=" + c2.ToString() + ",UfinanciamientoPor=" + c3.ToString() + ",UfinanciamientoImp=" + c4.ToString() + ",UdiasFin=" + c5.ToString() + ",costoXdiasfin=" + c6.ToString() + ",PoU=" + c7.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[(renglon - 1)];
                    cmd = new MySqlCommand(q, Conn);
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
                    q = "update cedula6  set UproductoPor=" + c1.ToString() + ",Uproductoimp=" + c2.ToString() + ",UfinanciamientoPor=" + c3.ToString() + ",UfinanciamientoImp=" + c4.ToString() + ",UdiasFin=" + c5.ToString() + ",costoXdiasfin=" + c6.ToString() + ",PoU=" + c7.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[(renglon - 1)];
                    cmd = new MySqlCommand(q, Conn);
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
                    q = "update cedula6  set UproductoPor=" + c1.ToString() + ",Uproductoimp=" + c2.ToString() + ",UfinanciamientoPor=" + c3.ToString() + ",UfinanciamientoImp=" + c4.ToString() + ",UdiasFin=" + c5.ToString() + ",costoXdiasfin=" + c6.ToString() + ",PoU=" + c7.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and mes=" + mes.ToString() + " and anio=" + año.ToString() + " " + querycargar[(renglon - 1)];
                    cmd = new MySqlCommand(q, Conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                    break;
            }
        }

        #region metodos dropdown  PABLO
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

         public cedula5(int selecc_sucursal, int selecc_division, int selecc_depto, int selecc_familia,
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

         private void pictureBox4_Click(object sender, EventArgs e)
         {

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

         private void toolStripComboBox1_Click(object sender, EventArgs e)
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
             m_CLEAR_DGV();
             m_ADD_ROWS_DGV();
             m_PASS_VALUES_DGV("Total", 0);
             dgv1.Rows[0].Cells[0].Value = "Total";
             m_inventario_ced1();
             m_DIASMESESANOST(CED1_fechaI, CED1_fechaF);

         }
         public void m_DIASMESESANOST(string fecha_inicio, string fecha_final) /////////////////////////////se usa en todos 
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
                             if (comprobarCargar(fecha_inicio_ano, fecha_inicio_mes, i) == true)
                             {
                                 cargar(fecha_inicio_mes, fecha_inicio_ano, i);
                             }
                             else
                             {
                                 m_utilidad_ced4T(fecha_inicio_ano, fecha_inicio_mes, i);
                                 m_CALCULOS(i, fecha_inicio_mes, fecha_inicio_ano);
                             }
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
                             if (comprobarCargar(fecha_inicio_ano, fecha_inicio_mes, i) == true)
                             {
                                 cargar(fecha_inicio_mes, fecha_inicio_ano, i);
                             }
                             else
                             {
                                 m_utilidad_ced4T(fecha_inicio_ano, fecha_inicio_mes, i);
                                 m_CALCULOS(i, fecha_inicio_mes, fecha_inicio_ano);
                             }
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
         private void m_utilidad_ced4T(int año, int mes, int i)
         {
             
                 query = "SELECT utilidadPor , utilidadImp FROM cedula4 WHERE Escenario='" + Properties.Settings.Default.escenario + "' AND mes=" + mes.ToString() + " and ZapateriasTorreon=1";
                 cmd = new MySqlCommand(query, Conn);
                 reader = cmd.ExecuteReader();
                 while (reader.Read())
                 {
                     utilidadImp[0] = double.Parse(reader["utilidadImp"].ToString());
                     utilidadPor[0] = double.Parse(reader["utilidadPor"].ToString());
                 }
                 reader.Close();
         }

         private void button11_Click(object sender, EventArgs e)
         {

         }


    }
}