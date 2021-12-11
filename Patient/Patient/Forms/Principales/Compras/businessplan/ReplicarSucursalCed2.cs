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
    public partial class ReplicarSucursalCed2 : Form
    {
        #region variables conexion

        private MySqlCommand cmd;
        private string conexion = "SERVER=" + Properties.Settings.Default.server + "; DATABASE=dwh; user=" + Properties.Settings.Default.usuario + "; PASSWORD=" + Properties.Settings.Default.pass + ";";
        //private string conexion = "SERVER=localhost; DATABASE=dwh; user=root; PASSWORD= ;";
        private MySqlConnection Conn;
        private string query;
        private MySqlDataReader reader;
        #endregion variables conexion
        #region variables escenario
        string[] idd=new string[1000];
        //string CED1_estruct = "";
        //string CED1_estruct2 = "";
        //string CED1_fechaI = "";
        //string CED1_fechaF = "";
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
        //string marcavarios = " ";
        //string divisiones = " ";
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
        string s = "-1", d = "-1", dd = "-2", f = "-1", l = "-1", l1 = "-1", l2 = "-1", l3 = "-1", l4 = "-1", l5 = "-1", l6 = "-1", m = "-1";
        bool total = true;
        string[] queryguardar = new string[1000];
        string[] querycargar = new string[1000];
        string queryunidadesAsignadas = " ";
        //bool cargando = false;
        bool solototal = true;
        string solocalzadoDropdown = "";
       // string dropdownmarca = "";
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
        //string sucPredet = "";
        //string sucCopia = "";
        string[] iddsuc1=new string[1000];
        string[] iddsuc2 = new string[1000];
        string[] cargarS1 = new string[1000];
        string[] cargarS2 = new string[1000];
        bool copiando = false;
        public ReplicarSucursalCed2()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
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
            m_ESCENARIO(Properties.Settings.Default.escenario);
        }
        #region combos
        private void cbSucursales_DropDown(object sender, EventArgs e)
        {
            #region reiniciar V
            division = "";
            depto = "";
            fam = "";
            linea = "";
            subl1 = "";
            subl2 = "";
            subl3 = "";
            subl4 = "";
            subl5 = "";
            subl6 = "";
            #endregion
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
            this.Invoke(new Action(() =>
            {
                cbSucursales.Text = "";
                cbSucursales.Items.Clear();
                cbSucursales.Items.Add("Total");
            }));

            int i = 1;
            query = "SELECT descrip,idsucursal from sucursal where visible='S'";
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                this.Invoke(new Action(() =>
                {
                    cbSucursales.Items.Add(reader["descrip"].ToString());

                }));
                idd[i] = reader["idsucursal"].ToString();
                i++;
            }
            reader.Close();
        }
        private void cbSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            bandera_sucursal = true;
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
            //@est@
            this.Invoke(new Action(() =>
            {


                if (cbSucursales.Text != "Total")
                {
                    seleccion_sucursal = Convert.ToInt32(idd[cbSucursales.SelectedIndex]);

                    total = false;
                    string[] texto = cbSucursales.Text.Split('=');
                    lbsucursal.Text = "Sucursal=" + texto[0];
                    idsucursal = " and V.idsucursal=" + idd[cbSucursales.SelectedIndex];
                    wherequery[0] = "and V.idsucursal=" + idd[cbSucursales.SelectedIndex] + " " + solocalzadowhere;
                    query = "SELECT descrip,idsucursal from sucursal where visible='S' and idsucursal=" + idd[cbSucursales.SelectedIndex] + "";
                    queryguardar[0] = "," + idd[cbSucursales.SelectedIndex] + ",-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,'-1'";
                    idsucursalvarios = "and V.idsucursal=" + idd[cbSucursales.SelectedIndex];
                    s = "," + idd[cbSucursales.SelectedIndex];
                    querycargar[0] = "and idsucursal=" + idd[cbSucursales.SelectedIndex] + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'";
                    queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "'" + querycargar[0];
                    sucursalcargar = "and idsucursal=" + idd[cbSucursales.SelectedIndex] + "";
                    cargarS1[0] = " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'";
                    cargarS2[0] = cargarS1[0];

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
                        cargarS1[i] = " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                        cargarS2[i] = cargarS1[i];
                    }
                    lbsucursal.Text = "Sucursal=Total";
                    query = "SELECT descrip,idsucursal from sucursal where visible='S'";
                    total = true;
                    s = ",0";
                    solototal = false;
                    sucursalcargar = "and idsucursal=0";
                    seleccion_sucursal = 0;

                }
                solototal = false;

                if (!valoresform)
                    M_cargargrid(total);
            }));
        }
        private void cbDivision_DropDown(object sender, EventArgs e)
        {
            #region reiniciar V
            division = "";
            depto = "";
            fam = "";
            linea = "";
            subl1 = "";
            subl2 = "";
            subl3 = "";
            subl4 = "";
            subl5 = "";
            subl6 = "";
            #endregion
            int i = 0;
            cbDivisiones.Items.Clear();
            cbDivisiones.Text = "";
            i = 1;
            cbDivisiones.Items.Add("Total");
            query = "SELECT descrip,iddivisiones from estdivisiones where visiblebp='1' and iddivisiones=1";
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
            d = ",-1"; dd = ",-1"; f = ",-1"; l = ",-1"; l1 = ",-1"; l2 = ",-1"; l3 = ",-1"; l4 = ",-1"; l5 = ",-1"; l6 = ",-1"; m = ",'-1'";
            #endregion
            if (cbDivisiones.Text != "Total")
            {
                seleccion_division = Convert.ToInt32(idd[cbDivisiones.SelectedIndex]);

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
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar;
                iddivision = " ";
                iddivisionesvarios = " ";
                division = " ";
                for (int i = 0; i <= cbDivisiones.Items.Count - 1; i++)
                {
                    querycargar[i] = sucursalcargar + " and iddivisiones=" + idd[(i + 1)] + " and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                    iddivision = "and V.iddivisiones=" + idd[(i + 1)];
                    wherequery[i] = idsucursalvarios + " " + iddivision;
                    queryguardar[i] = s + "," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,-1,-1,-1,'-1'";
                    cargarS1[i] = " and iddivisiones=" + idd[(i + 1)] + " and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                    cargarS2[i] = cargarS1[i];
                }
                lbDivision.Text = "Division=Total";
                total = true;
                d = ",0";
                divisioncargar = "and iddivisiones=0";
                seleccion_division = 0;
                if (solocalzadoDropdown != " and iddivisiones=1")
                {
                    query = "SELECT descrip,iddivisiones from estdivisiones where visiblebp='1'";

                }
                else
                {
                    query = "SELECT descrip,iddivisiones from estdivisiones where visiblebp='1' and iddivisiones=1";

                }

            }
            solototal = false;

            if (!valoresform)
                M_cargargrid(total);
        }
        private void cbDepto_DropDown(object sender, EventArgs e)
        {
            #region reiniciar V
            depto = "";
            fam = "";
            linea = "";
            subl1 = "";
            subl2 = "";
            subl3 = "";
            subl4 = "";
            subl5 = "";
            subl6 = "";
            #endregion


            this.Invoke(new Action(() =>
            {
                cbDepto.Items.Clear();
                cbDepto.Items.Add("Total");
                string[] texto = iddivision.Split('.');
                int i = 1;
                query = "SELECT descrip,iddepto from estdepartamento where visiblebp='1' and iddivisiones=1";
                cmd = new MySqlCommand(query, Conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbDepto.Items.Add(reader["descrip"].ToString());
                    idd[i] = reader["iddepto"].ToString();
                    i++;
                }
                reader.Close();
            }));


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
            dd = ",-1"; f = ",-1"; l = ",-1"; l1 = ",-1"; l2 = ",-1"; l3 = ",-1"; l4 = ",-1"; l5 = ",-1"; l6 = ",-1"; m = ",'-1'";
            #endregion

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
            this.Invoke(new Action(() =>
            {
                if (cbDepto.Text != "Total")
                {
                    seleccion_depto = Convert.ToInt32(idd[cbDepto.SelectedIndex]);

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
                        queryguardar[i] = s + " " + d + "," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,-1,-1,'-1'";
                        if (cbSucursales.Text == "" && cbDivisiones.Text == "")
                        {
                            wherequery[i] = iddepto + " and iddivisiones=1";
                            queryguardar[i] = ",-1,-1," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,-1,-1,'-1'";
                            querycargar[i] = "and idsucursal=-1 and iddivisiones=-1 and iddepto=" + idd[(i + 1)] + " and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                            queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                        }
                        cargarS1[i]=" and iddepto=" + idd[(i + 1)] + " and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                        cargarS2[i] = cargarS1[i];
                    }
                    total = true;
                    query = "SELECT descrip,iddepto from estdepartamento where visiblebp='1'  and iddivisiones=1";
                    lbdepartamento.Text = "Departamento=Total";
                    depto = " ";
                    dd = ",0";
                    departamentocargar = "and iddepto=0";
                    seleccion_depto = 0;
                }
                solototal = false;
            }));


            if (!valoresform)
                M_cargargrid(total);
        }
        private void cbFamilia_DropDown(object sender, EventArgs e)
        {
            #region reiniciar V
            fam = "";
            linea = "";
            subl1 = "";
            subl2 = "";
            subl3 = "";
            subl4 = "";
            subl5 = "";
            subl6 = "";
            #endregion
            if (cbSucursales.Text == "" && cbDivisiones.Text == "" && cbDepto.Text == "")
            {
                cbFamilia.Items.Clear();
                cbFamilia.Items.Add("Total");
                int i = 1;
                query = "SELECT descrip,idfamilia from estfamilia where visiblebp='1' ";
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
            else
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
            f = ",-1"; l = ",-1"; l1 = ",-1"; l2 = ",-1"; l3 = ",-1"; l4 = ",-1"; l5 = ",-1"; l6 = ",-1"; m = ",'-1'";
            #endregion
            //@est@

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
            if (cbFamilia.Text != "Total")
            {
                seleccion_familia = Convert.ToInt32(idd[cbFamilia.SelectedIndex]);

                idfamilia = "and V.idfamilia=" + idd[cbFamilia.SelectedIndex];
                idfamiliavarios = idfamilia;
                total = false;
                wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamilia;
                string[] texto = cbFamilia.Text.Split('=');
                lbfamilia.Text = "Familia=" + texto[0].ToString();
                query = "SELECT descrip,idfamilia from estfamilia where visiblebp='1' and idfamilia=" + idd[cbFamilia.SelectedIndex] + "";
                fam = "and idfamilia=" + idd[cbFamilia.SelectedIndex];
                queryguardar[0] = s + " " + d + " " + dd + "," + idd[cbFamilia.SelectedIndex] + ",0,0,0,0,0,0,0,'0'";
                f = "," + idd[cbFamilia.SelectedIndex];
                querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " and idfamilia=" + idd[cbFamilia.SelectedIndex] + " and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                familiacargar = "and idfamilia=" + idd[cbFamilia.SelectedIndex];

            }
            else
            {
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + " and idfamilia=-1 and marca=-1";
                idfamiliavarios = " ";
                for (int i = 0; i <= cbFamilia.Items.Count - 1; i++)
                {
                    idfamilia = "and V.idfamilia=" + idd[(i + 1)];
                    wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamilia;
                    queryguardar[i] = s + " " + d + " " + dd + "," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,-1,'-1'";
                    querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " and idfamilia=" + idd[(i + 1)] + " and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                    if (cbSucursales.Text == "" && cbDivisiones.Text == "" && cbDepto.Text == "")
                    {
                        wherequery[i] = idfamilia + " and iddivisiones=1";
                        queryguardar[i] = ",-1,-1,-1," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,-1,'-1'";
                        querycargar[i] = "and idsucursal=-1 and iddivisiones=-1 and iddepto=-1 and idfamilia=" + idd[(i + 1)] + " and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                        queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                    }
                    cargarS1[i] = departamentocargar + " and idfamilia=" + idd[(i + 1)] + " and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                    cargarS2[i] = cargarS1[i];
                }
                total = true;
                query = "SELECT descrip,idfamilia from estfamilia where visiblebp='1' " + division + " " + depto;
                lbfamilia.Text = "Familia=Total";
                fam = " ";
                f = ",0";
                familiacargar = "and idfamilia=0";
                seleccion_familia = 0;
            }
            solototal = false;

            if (!valoresform)
                M_cargargrid(total);
        }
        private void cbLinea_DropDown(object sender, EventArgs e)
        {
            #region reiniciar V
            linea = "";
            subl1 = "";
            subl2 = "";
            subl3 = "";
            subl4 = "";
            subl5 = "";
            subl6 = "";
            #endregion
            if (cbSucursales.Text == "" && cbDivisiones.Text == "" && cbDepto.Text == "" && cbFamilia.Text == "")
            {
                cbLinea.Items.Clear();
                cbLinea.Items.Add("Total");
                int i = 1;

                query = "SELECT descrip,idlinea from estlinea where visiblebp='1' and iddivisiones=1";
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
            else
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

        }
        private void cbLinea_SelectedIndexChanged(object sender, EventArgs e)
        {
            bandera_linea = true;
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
            l = ",-1"; l1 = ",-1"; l2 = ",-1"; l3 = ",-1"; l4 = ",-1"; l5 = ",-1"; l6 = ",-1"; m = ",'-1'";
            #endregion
            if (cbLinea.Text != "Total")
            {
                seleccion_linea = Convert.ToInt32(idd[cbLinea.SelectedIndex]);

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
                    queryguardar[i] = s + " " + d + " " + dd + " " + f + "," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,'-1'";
                    query = "SELECT descrip,idlinea from estlinea where visiblebp='1' " + division + " " + depto + "" + " " + fam;

                    if (cbSucursales.Text == "" && cbDivisiones.Text == "" && cbDepto.Text == "" && cbFamilia.Text == "")
                    {
                        wherequery[i] = idlinea + " and iddivisiones=1";
                        queryguardar[i] = ",-1,-1,-1,-1," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,'-1'";
                        querycargar[i] = "and idsucursal=-1 and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=" + idd[(i + 1)] + " and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                        queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                        query = "SELECT descrip,idlinea from estlinea where visiblebp='1' and iddivisiones=1";
                    }
                    cargarS1[i] = departamentocargar + " " + familiacargar + " and idlinea=" + idd[(i + 1)] + " and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                    cargarS2[i] = cargarS1[i];
                }
                total = true;
                linea = " ";
                l = ",0";
                lineacargar = "and idlinea=0";
                seleccion_linea = 0;
            }
            lblinea.Text = "Linea=" + cbLinea.Text;
            solototal = false;

            if (!valoresform)
                M_cargargrid(total);
        }
        private void cbL1_DropDown(object sender, EventArgs e)
        {
            #region reiniciar V

            subl1 = "";
            subl2 = "";
            subl3 = "";
            subl4 = "";
            subl5 = "";
            subl6 = "";
            #endregion
            if (cbSucursales.Text == "" && cbDivisiones.Text == "" && cbDepto.Text == "" && cbFamilia.Text == "" && cbLinea.Text == "")
            {
                cbL1.Items.Clear();
                cbL1.Items.Add("Total");
                int i = 1;

                query = "SELECT descrip,idl1 from estl1 where visiblebp='1' and iddivisiones=1";
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
            else
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
        }
        private void cbL1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bandera_l1 = true;
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
            l1 = ",-1"; l2 = ",-1"; l3 = ",-1"; l4 = ",-1"; l5 = ",-1"; l6 = ",-1"; m = ",'-1'";
            #region reiniciar V

            subl1 = "";
            subl2 = "";
            subl3 = "";
            subl4 = "";
            subl5 = "";
            subl6 = "";
            #endregion
            #endregion
            if (cbL1.Text != "Total")
            {
                seleccion_l1 = Convert.ToInt32(idd[cbL1.SelectedIndex]);

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
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                l1cargar = "and idl1=" + idd[cbL1.SelectedIndex];

            }
            else
            {
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " and idl1=-1";
                idl1varios = " ";
                for (int i = 0; i <= cbL1.Items.Count - 1; i++)
                {
                    query = "SELECT descrip,idl1 from estl1 where visiblebp='1' " + division + " " + depto + " " + fam + " " + linea;
                    querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " and idl1=" + idd[(i + 1)] + " and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                    idl1 = "and V.idl1=" + idd[(i + 1)];
                    wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1;
                    queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + "," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,'-1'";
                    if (cbSucursales.Text == "" && cbDivisiones.Text == "" && cbDepto.Text == "" && cbFamilia.Text == "" && cbLinea.Text == "")
                    {
                        wherequery[i] = idl1 + " and iddivisiones=1";
                        queryguardar[i] = ",-1,-1,-1,-1,-1," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,'-1'";
                        querycargar[i] = "and idsucursal=-1 and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=" + idd[(i + 1)] + " and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                        queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                        query = "SELECT descrip,idl1 from estl1 where visiblebp='1' and iddivisiones=1";
                    }
                    cargarS1[i] = departamentocargar + " " + familiacargar + " " + lineacargar + " and idl1=" + idd[(i + 1)] + " and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                    cargarS2[i] = cargarS1[i];

                }
                subl1 = " ";
                lbl1.Text = "L1=Total";
                total = true;
                l1 = ",0";
                l1cargar = "and idl1=0";
                seleccion_l1 = 0;
            }
            lbl1.Text = "L1=" + cbL1.Text;
            solototal = false;

            if (!valoresform)
                M_cargargrid(total);
        }
        private void cbL2_DropDown(object sender, EventArgs e)
        {
            #region reiniciar V

            subl2 = "";
            subl3 = "";
            subl4 = "";
            subl5 = "";
            subl6 = "";
            #endregion
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
            l2 = ",-1"; l3 = ",-1"; l4 = ",-1"; l5 = ",-1"; l6 = ",-1"; m = ",'-1'";

            #endregion
            if (cbL2.Text != "Total")
            {
                seleccion_l2 = Convert.ToInt32(idd[cbL2.SelectedIndex]);

                querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " and idl2=" + idd[cbL2.SelectedIndex] + " and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                idl2 = "and idl2=" + idd[cbL2.SelectedIndex];
                idl2varios = idl2;
                total = false;
                query = "SELECT descrip,idl2 from estl2 where visiblebp='1' and idl2=" + idd[cbL2.SelectedIndex];
                wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2;
                subl2 = "and idl2=" + idd[cbL2.SelectedIndex];
                queryguardar[0] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + "," + idd[cbL2.SelectedIndex] + ",-1,-1,-1,-1,'-1'";
                l2 = "," + idd[cbL2.SelectedIndex];
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                l2cargar = "and idl2=" + idd[cbL2.SelectedIndex];

            }
            else
            {
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " and idl2=-1 and marca='-1'";
                idl2varios = " ";
                subl2 = " ";
                for (int i = 0; i <= cbL2.Items.Count - 1; i++)
                {
                    querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " and idl2=" + idd[(i + 1)] + " and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                    idl2 = "and V.idl2=" + idd[(i + 1)];
                    wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2;
                    queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + "," + idd[(i + 1)] + ",-1,-1,-1,-1,'-1'";
                    cargarS1[i] = departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " and idl2=" + idd[(i + 1)] + " and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                    cargarS2[i] = cargarS1[i];
                }
                l2 = ",0";
                total = true;
                query = "SELECT descrip,idl2 from estl2 where visiblebp='1' " + division + " " + depto + " " + fam + " " + linea + " " + subl1;
                l2cargar = "and idl2=0";
                seleccion_l2 = 0;
            }
            lbL2.Text = "L2=" + cbL2.Text;
            solototal = false;

            if (!valoresform)
                M_cargargrid(total);
        }
        private void cbL3_DropDown(object sender, EventArgs e)
        {
            #region reiniciar V

            subl3 = "";
            subl4 = "";
            subl5 = "";
            subl6 = "";
            #endregion
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
            l3 = ",-1"; l4 = ",-1"; l5 = ",-1"; l6 = ",-1"; m = ",'-1'";
            #endregion
            if (cbL3.Text != "Total")
            {
                seleccion_l3 = Convert.ToInt32(idd[cbL3.SelectedIndex]);

                l3cargar = "and idl3=" + idd[cbL3.SelectedIndex];
                querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " and idl3=" + idd[cbL3.SelectedIndex] + " and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                idl3 = "and idl3=" + idd[cbL3.SelectedIndex];
                idl3varios = idl3;
                total = false;
                query = "SELECT descrip,idl3 from estl3 where visiblebp='1' and idl3=" + idd[cbL3.SelectedIndex];
                wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3;
                subl3 = "and idl3=" + idd[cbL3.SelectedIndex];
                queryguardar[0] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + "," + idd[cbL3.SelectedIndex] + ",-1,-1,-1,'-1'";
                l3 = "," + idd[cbL3.SelectedIndex];
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
                    queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + "," + idd[(i + 1)] + ",-1,-1,-1,'-1'";
                    cargarS1[i] = querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " and idl3=" + idd[(i + 1)] + " and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                    cargarS2[i] = cargarS1[i];
                }
                total = true;
                query = "SELECT descrip,idl3 from estl3 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2;
                l3 = ",0";
                l3cargar = "and idl3=0";
                seleccion_l3 = 0;
            }
            lbL3.Text = "L3=" + cbL3.Text;
            solototal = false;

            if (!valoresform)
                M_cargargrid(total);
        }
        private void cbL4_DropDown(object sender, EventArgs e)
        {
            #region reiniciar V

            subl4 = "";
            subl5 = "";
            subl6 = "";
            #endregion
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
            l4 = ",-1"; l5 = ",-1"; l6 = ",-1"; m = ",'-1'";
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
                queryguardar[0] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + "," + idd[cbL4.SelectedIndex] + ",-1,-1,'-1'";
                l4 = "," + idd[cbL4.SelectedIndex];
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
                    queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + "," + idd[(i + 1)] + ",-1,-1,'-1'";
                    cargarS1[i] = departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " and idl4=" + idd[(i + 1)] + " and idl5=-1 and idl6=-1 and marca='-1'  ";
                    cargarS2[i] = cargarS1[i];
                }
                total = true;
                query = "SELECT descrip,idl4 from estl4 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2 + " " + subl3;
                l4 = ",0";
                l4cargar = "and idl4=0";
                seleccion_l4 = 0;
            }
            lbL4.Text = "L4=" + cbL4.Text;
            solototal = false;
            if (!valoresform)
                M_cargargrid(total);

        }
        private void cbL5_DropDown(object sender, EventArgs e)
        {
            #region reiniciar V

            subl5 = "";
            subl6 = "";
            #endregion
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
            l5 = ",-1"; l6 = ",-1"; m = ",'-1'";
            #endregion
            if (cbL5.Text != "Total")
            {
                seleccion_l5 = Convert.ToInt32(idd[cbL5.SelectedIndex]);

                querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " and idl5=" + idd[cbL5.SelectedIndex] + " and idl6=-1 and marca='-1'  ";
                idl5 = "and idl5=" + idd[cbL5.SelectedIndex];
                idl5varios = idl5;
                total = false;
                query = "SELECT descrip,idl5 from estl5 where visiblebp='1' and idl5=" + idd[cbL5.SelectedIndex];
                wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5;
                subl5 = "and idl5=" + idd[cbL5.SelectedIndex];
                queryguardar[0] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + " " + l4 + "," + idd[cbL5.SelectedIndex] + ",-1,'-1'";
                l5 = "," + idd[cbL5.SelectedIndex];
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
                    queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + " " + l4 + "," + idd[(i + 1)] + ",-1,'-1'";
                    cargarS1[i] = departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " and idl5=" + idd[(i + 1)] + " and idl6=-1 and marca='-1'  ";
                    cargarS2[i] = cargarS1[i];
                }
                total = true;
                query = "SELECT descrip,idl5 from estl5 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2 + " " + subl3 + " " + subl4;
                l5 = ",0";
                l5cargar = "and idl5=0";
                seleccion_l5 = 0;
            }
            solototal = false;
            lbL5.Text = "L5=" + cbL5.Text;
            if (!valoresform)
                M_cargargrid(total);
        }
        private void cbL6_DropDown(object sender, EventArgs e)
        {
            #region reiniciar V

            subl6 = "";
            #endregion
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
            if (cbL6.Items.Count == 1)
            {
                cbL6.Items.Clear();
            }
        }
        private void cbL6_SelectedIndexChanged(object sender, EventArgs e)
        {
            bandera_l6 = true;
            //@est@
            #region banderas
            bandera_marca = false;
            seleccion_marca = "";
            #endregion
            #region reiniciar valores
            lbL6.Text = "L6";
            lbMarca.Text = "Marca";
            idl6 = " ";
            marca = " ";
            l6 = ",-1";
            m = ",'-1'";
            #endregion

            if (cbL6.Text != "Total")
            {
                seleccion_l6 = Convert.ToInt32(idd[cbL6.SelectedIndex]);

                querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " and idl6=" + idd[cbL6.SelectedIndex] + " and marca='-1'  ";
                idl6 = "and idl6=" + idd[cbL6.SelectedIndex];
                idl6varios = idl6;
                total = false;
                query = "SELECT descrip,idl6 from estl6 where visiblebp='1' and idl6=" + idd[cbL6.SelectedIndex];
                wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6varios;
                subl6 = "and idl6=" + idd[cbL6.SelectedIndex];
                queryguardar[0] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + " " + l4 + " " + l5 + "," + idd[cbL6.SelectedIndex] + ",'-1'";
                l6 = "," + idd[cbL6.SelectedIndex];
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                l6cargar = "and idl6=" + idd[cbL6.SelectedIndex];

            }
            else
            {
                idl6varios = " ";
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " and idl6=-1";
                subl6 = " ";
                idl6 = " ";
                for (int i = 0; i <= cbL6.Items.Count - 1; i++)
                {
                    querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " and idl6=" + idd[(i + 1)] + " and marca='-1'  ";
                    idl6 = "and V.idl6=" + idd[(i + 1)];
                    wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6;
                    queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + " " + l4 + " " + l5 + "," + idd[(i + 1)] + ",'-1'";
                    cargarS1[i] = departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " and idl6=" + idd[(i + 1)] + " and marca='-1'  ";
                    cargarS2[i] = cargarS1[i];
                }
                total = true;
                query = "SELECT descrip,idl6 from estl6 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2 + " " + subl3 + " " + subl4 + " " + subl5;
                l6 = ",0";
                l6cargar = "and idl6=0";
                seleccion_l6 = 0;
            }
            solototal = false;
            lbL6.Text = "L6=" + cbL6.Text;
            if (!valoresform)
                M_cargargrid(total);
        }
        private void cbMarca_DropDown(object sender, EventArgs e)
        {
            if (cbSucursales.Text == "" && cbDivisiones.Text == "" && cbDepto.Text == "" && cbFamilia.Text == "" && cbLinea.Text == "" && cbL1.Text == "" && cbL2.Text == "" && cbL3.Text == "" && cbL4.Text == "" && cbL5.Text == "" && cbL6.Text == "" && cbMarca.Text == "")
            {
                cbMarca.Items.Clear();
                cbMarca.Items.Add("Total");
                int i = 1;
                query = "SELECT distinct m.descrip,m.marca from marca as m inner join estarticulo as V on V.marca=m.marca where visiblebp=1 and v.iddivisiones=1";
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
            if (bandera_l6 == true && bandera_l5 == true)
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
            if (bandera_sucursal == true && bandera_division == true && bandera_depto == true && bandera_familia == false)
            {
                cbMarca.Items.Clear();
                cbMarca.Items.Add("Total");
                int i = 1;
                query = "SELECT distinct m.descrip,m.marca from marca as m inner join estarticulo as V on V.marca=m.marca where visiblebp=1 " + iddivisionesvarios + " " + iddeptovarios;
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
            if (bandera_sucursal == true && bandera_division == true && bandera_depto == true && bandera_familia == true && bandera_linea == true && bandera_l1 == true && bandera_l2 == false)
            {
                cbMarca.Items.Clear();
                cbMarca.Items.Add("Total");
                int i = 1;
                query = "SELECT distinct m.descrip,m.marca from marca as m inner join estarticulo as V on V.marca=m.marca where visiblebp=1 " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios;
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
                    if (bandera_l6 == true && bandera_l5 == true)
                    {
                        wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6varios + " " + marca;
                        queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + " " + l4 + " " + l5 + " " + l6 + ",'" + idd[(i + 1)] + "'";
                        querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " " + l6cargar + " and marca='" + idd[(i + 1)] + "'  ";
                        queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " " + l6cargar + " and marca='-1'";
                        cargarS1[i] = departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " " + l6cargar + " and marca='" + idd[(i + 1)] + "'  ";
                        cargarS2[i] = cargarS1[i];
                    }

                    if (bandera_sucursal == true && bandera_division == true && bandera_depto == true && bandera_familia == false)
                    {
                        wherequery[i] = idsucursalvarios + " " + iddeptovarios + " and iddivisiones=1 " + marca;
                        queryguardar[i] = s + " " + d + " " + dd + ",-1,-1,-1,-1,-1,-1,-1,-1,'" + idd[(i + 1)] + "'";

                        querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='" + idd[(i + 1)] + "'  ";
                        queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and iddepto=" + seleccion_depto.ToString() + " and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and idfamilia=-1 and marca='-1'";
                        cargarS1[i] = departamentocargar + " and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='" + idd[(i + 1)] + "'  ";
                        cargarS2[i] = cargarS1[i];
                    }
                    if (cbSucursales.Text == "" && cbDivisiones.Text == "" && cbDepto.Text == "" && cbFamilia.Text == "" && cbLinea.Text == "" && cbL1.Text == "" && cbL2.Text == "" && cbL3.Text == "" && cbL4.Text == "" && cbL5.Text == "" && cbL6.Text == "")
                    {
                        wherequery[i] = marca + " and iddivisiones=1";
                        queryguardar[i] = ",-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,'" + idd[(i + 1)] + "'";
                        querycargar[i] = "and idsucursal=-1 and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='" + idd[(i + 1)] + "'  ";
                        queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                        query = "SELECT distinct m.descrip,m.marca from marca as m inner join estarticulo as V on V.marca=m.marca where visiblebp=1 and v.iddivisiones=1";
                    }
                    if (bandera_sucursal == true && bandera_division == true && bandera_depto == true && bandera_familia == true && bandera_linea == true && bandera_l1 == true && bandera_l2 == false)
                    {
                        wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + marca;
                        queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + ",-1,-1,-1,-1,-1, '" + idd[(i + 1)] + "'";
                        querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='" + idd[(i + 1)] + "'  ";
                        queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " and idl2=-1 and marca='-1'";
                        // query = "SELECT distinct m.descrip,m.marca from marca as m inner join estarticulo as V on V.marca=m.marca where visiblebp=1 and v.iddivisiones=1";
                        cargarS1[i] = departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='" + idd[(i + 1)] + "'  ";
                        cargarS2[i] = cargarS1[i];
                    }

                }
                total = true;
                seleccion_marca = "0";
            }
            else
            {
                seleccion_marca = "0";
                query = query + " and M.marca='" + idd[cbMarca.SelectedIndex] + "'";
                marca = " and V.marca='" + idd[cbMarca.SelectedIndex] + "'";
                wherequery[0] = idsucursalvarios + " " + idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6varios + " " + marca;
                total = false;
                queryguardar[0] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + " " + l4 + " " + l5 + " " + l6 + ",'" + idd[cbMarca.SelectedIndex] + "'";
                querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " " + l6cargar + " and marca='" + idd[cbMarca.SelectedIndex] + "'  ";
                queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                if (bandera_l6 == true && bandera_l5 == true)
                {
                    wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6varios + " " + marca;
                    queryguardar[0] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + " " + l4 + " " + l5 + " " + l6 + ",'" + idd[cbMarca.SelectedIndex] + "'";
                    querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " " + l6cargar + " and marca='" + idd[cbMarca.SelectedIndex] + "'  ";
                    queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " " + l6cargar + " and marca='-1'";
                }
                if (bandera_sucursal == true && bandera_division == true && bandera_depto == true && bandera_linea == false)
                {
                    wherequery[0] = idsucursalvarios + " " + iddeptovarios + " and iddivisiones=1 " + marca;
                    queryguardar[0] = s + " " + d + " " + dd + ",-1,-1,-1,-1,-1,-1,-1,-1,'" + idd[cbMarca.SelectedIndex] + "'";

                    querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='" + idd[cbMarca.SelectedIndex] + "'  ";
                    queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and iddepto=" + seleccion_depto.ToString() + " and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and idfamilia=-1 and marca='-1'";
                }
                if (cbSucursales.Text == "" && cbDivisiones.Text == "" && cbDepto.Text == "" && cbFamilia.Text == "" && cbLinea.Text == "" && cbL1.Text == "" && cbL2.Text == "" && cbL3.Text == "" && cbL4.Text == "" && cbL5.Text == "" && cbL6.Text == "")
                {
                    wherequery[0] = marca + " and iddivisiones=1";
                    queryguardar[0] = ",-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,'" + idd[cbMarca.SelectedIndex] + "'";
                    querycargar[0] = "and idsucursal=-1 and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='" + idd[cbMarca.SelectedIndex] + "'  ";
                    queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[cbMarca.SelectedIndex];
                    query = "SELECT distinct m.descrip,m.marca from marca as m inner join estarticulo as V on V.marca=m.marca where visiblebp=1 and v.iddivisiones=1 and m.marca='" + idd[cbMarca.SelectedIndex] + "'";
                }
                if (bandera_sucursal == true && bandera_division == true && bandera_depto == true && bandera_familia == true && bandera_linea == true && bandera_l1 == true && bandera_l2 == false)
                {
                    wherequery[0] = marca + " and iddivisiones=1";
                    queryguardar[0] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + ",-1,-1,-1,-1,-1, '" + idd[cbMarca.SelectedIndex] + "'";
                    querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='" + idd[cbMarca.SelectedIndex] + "'  ";
                    queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1  " + querycargar[0];
                    query = "SELECT distinct m.descrip,m.marca from marca as m inner join estarticulo as V on V.marca=m.marca where visiblebp=1 and v.iddivisiones=1 and m.marca='" + idd[cbMarca.SelectedIndex] + "'";
                }

            }
            solototal = false;
            lbMarca.Text = "Marca=" + cbMarca.Text;
            if (!valoresform)
                M_cargargrid(total);
            //solototal = true;
        }
        #endregion

        private void M_cargargrid(bool Total)
        {
            this.Invoke(new Action(() =>
            {
                dgv.Rows.Clear();

            }));
            int i = 0;

            if (solototal == true)
            {
            }
            else
            {
                this.Invoke(new Action(() =>
                {
                    cmd = new MySqlCommand(query, Conn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        dgv.Refresh();
                        dgv.Rows.Add();
                        dgv.Rows[i].Cells[0].Value = reader["descrip"].ToString();
                        i++;
                    }
                    dgv.Refresh();
                    reader.Close();
                }));

            }
            if(copiando==false)
            {
                porcentajeSuc1();
            }
        }
        private void m_ESCENARIO(string escenario)
        {
            DateTime a = DateTime.Now, f = DateTime.Now;
            //string ESC = "SELECT sucursal, estructura, fechainicialA, fechafinalA,fechainicial,fechafinal FROM escenarios WHERE nombre = '" + escenario + "' LIMIT 1";
            string ESC = "SELECT  fechainicialA, fechafinalA,fechainicial,fechafinal,solocalzado FROM escenarios WHERE nombre = '" + escenario + "' LIMIT 1";
            cmd = new MySqlCommand(ESC, Conn);
            cmd.CommandTimeout = 0;//pos solucion
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                a = DateTime.Parse(reader["fechainicial"].ToString());
                f = DateTime.Parse(reader["fechafinal"].ToString());
                //CED1_estruct = reader["sucursal"].ToString();
                //CED1_estruct2 = reader["estructura"].ToString();
                //FechaAI = DateTime.Parse(reader["fechainicialA"].ToString());
                //FechaAF = DateTime.Parse(reader["fechafinalA"].ToString());
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
       
        private void OnCopiarClick(object sender, EventArgs e)
        {
            if (cbsucursalPredeterminada.Text != "")
            {
                if (cbSucursalAcopiar.Text != "" || checkBox1.Checked == true)
                {
                    var result = MessageBox.Show("Deseas continuar?", " ",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        bgwGenerar.RunWorkerAsync();
                    }
                }
            }
        }

        private void OnCbsucursalPredeterminadaDropDown(object sender, EventArgs e)
        {
            cbsucursalPredeterminada.Items.Clear();
            cbSucursalAcopiar.Items.Clear();
            cbSucursalAcopiar.Text = "";
            int i = 1;
            query = "SELECT descrip,idsucursal from sucursal where visible='S'";
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            iddsuc1[0] = "0";
            while (reader.Read())
            {
                this.Invoke(new Action(() =>
                {
                    cbsucursalPredeterminada.Items.Add(reader["descrip"].ToString());
                }));
                iddsuc1[i]=reader["idsucursal"].ToString();
                //idd[i] = reader["idsucursal"].ToString();
                i++;
            }
            reader.Close();
        }
        private void OnCbsucursalPredeterminadaSelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void OnCbSucursalAcopiarDropDown(object sender, EventArgs e)
        {
            cbSucursalAcopiar.Items.Clear();
            int i = 1;
            
            query = "SELECT descrip,idsucursal from sucursal where visible='S'";
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                this.Invoke(new Action(() =>
                {
                    if (cbsucursalPredeterminada.Text != reader["descrip"].ToString())
                    {
                        cbSucursalAcopiar.Items.Add(reader["descrip"].ToString());
                    }
                    iddsuc2[i] = reader["idsucursal"].ToString();
                }));
                i++;
            }
            reader.Close();
        }

        private void OnCheckBox1CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                cbSucursalAcopiar.Enabled = false;
            }
            else
            {
                cbSucursalAcopiar.Enabled = true;
            }
        }

        private void porcentajeSuc1()
        {
            int x = 0, i = 0;
            double c1, c2, c3, c4, c5, c6, c7, c8;
            
            for (; x <= dgv.Rows.Count - 1; x++)
            {
                string q = "";
                q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + " ' " + cargarS1[i] + " and idsucursal=" + iddsuc1[(cbsucursalPredeterminada.SelectedIndex+1)]+" limit 1";
                cmd = new MySqlCommand(q, Conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    c1 = double.Parse(reader["porsentajeP"].ToString());
                    //c4 = double.Parse(reader["porsentajeH"].ToString());
                    dgv.Rows[x].Cells[1].Value = c1.ToString("n");
                    //dgv.Rows[x].Cells[2].Value = c4.ToString("n");
                }
                reader.Close();
                q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + " ' " + cargarS2[i] + " and idsucursal=" + iddsuc2[(cbSucursalAcopiar.SelectedIndex + 2)]+" limit 1";
                cmd = new MySqlCommand(q, Conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    c1 = double.Parse(reader["porsentajeP"].ToString());
                    // c4 = double.Parse(reader["porsentajeH"].ToString());
                    dgv.Rows[x].Cells[2].Value = c1.ToString("n");
                    //dgv.Rows[x].Cells[2].Value = c4.ToString("n");
                }
                reader.Close();
                i++;
            }
        }

        private void OnCbSucursalAcopiarSelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void copiarPorcentaje(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            #region
            //sucursales
            this.Invoke(new Action(() =>
            {
                cbSucursales_DropDown(sender, e);
            }));

            int cantidadSuc =0;
            if (checkBox1.Checked == true)
            {
                OnCbSucursalAcopiarDropDown(sender, e);
                cantidadSuc = cbSucursalAcopiar.Items.Count;
            }
            else
            {
                cantidadSuc = 1;
            }
            if (cbSucursales.Items.Count != -1)
                for (int ss = 0; ss < cantidadSuc; ss++)
                {
                    this.Invoke(new Action(() =>
                    {
                        cbSucursales_DropDown(sender, e);
                        cbSucursales.SelectedIndex = 1;
                        if (checkBox1.Checked == true)
                        {
                            OnCbSucursalAcopiarDropDown(sender, e);
                            cbSucursalAcopiar.SelectedIndex = ss;
                        }
                        //if (ss == 0)
                        //{
                            porcentajeSuc1();
                            //guardarP();
                        //}
                        this.Refresh();
                    }));

                        //divisiones         
                        this.Invoke(new Action(() =>
                        {
                            cbDivision_DropDown(sender, e);

                        }));
                        if (cbDivisiones.Items.Count != -1)
                            for (int dd = 0; dd < cbDivisiones.Items.Count; dd++)
                            {
                                this.Invoke(new Action(() =>
                                {
                                    cbDivision_DropDown(sender, e);
                                    cbDivisiones.SelectedIndex = dd;
                                    this.Refresh();
                                    if (dd == 0)
                                    {
                                        porcentajeSuc1();
                                        //guardarP();
                                    }
                                }));


                                if (dd != 0)
                                {

                                    //departamento     
                                    this.Invoke(new Action(() =>
                                    {
                                        cbDepto_DropDown(sender, e);

                                    }));
                                    if (cbDepto.Items.Count != -1)
                                        for (int dp = 0; dp < cbDepto.Items.Count; dp++)
                                        {
                                            this.Invoke(new Action(() =>
                                            {
                                                cbDepto_DropDown(sender, e);
                                                cbDepto.SelectedIndex = dp;
                                                if (dp == 0)
                                                {
                                                    porcentajeSuc1();
                                                    guardarP();
                                                }
                                                this.Refresh();
                                            }));

                                            if (dp != 0)
                                            {
                                                this.Invoke(new Action(() =>
                                                {
                                                    cbMarca_DropDown(sender, e);
                                                    cbMarca.SelectedIndex = 0;
                                                    porcentajeSuc1();
                                                    guardarP();
                                                }));

                                                //familia       
                                                this.Invoke(new Action(() =>
                                                {
                                                    cbFamilia_DropDown(sender, e);

                                                }));
                                                if (cbFamilia.Items.Count != -1)
                                                    for (int fm = 0; fm < cbFamilia.Items.Count; fm++)
                                                    {
                                                        this.Invoke(new Action(() =>
                                                        {
                                                            cbFamilia_DropDown(sender, e);
                                                            cbFamilia.SelectedIndex = fm;
                                                            if (fm == 0)
                                                            {
                                                                porcentajeSuc1();
                                                                guardarP();
                                                            }
                                                            this.Refresh();
                                                        }));

                                                        if (fm != 0)
                                                        {
                                                            //linea      
                                                            this.Invoke(new Action(() =>
                                                            {
                                                                cbLinea_DropDown(sender, e);

                                                            }));
                                                            if (cbLinea.Items.Count != -1)
                                                                for (int ln = 0; ln < cbLinea.Items.Count; ln++)
                                                                {
                                                                    this.Invoke(new Action(() =>
                                                                    {
                                                                        cbLinea_DropDown(sender, e);
                                                                        cbLinea.SelectedIndex = ln;
                                                                        if (ln == 0)
                                                                        {
                                                                            porcentajeSuc1();
                                                                            guardarP();
                                                                        }
                                                                        this.Refresh();
                                                                    }));

                                                                    if (ln != 0)
                                                                    {
                                                                        //l1          
                                                                        this.Invoke(new Action(() =>
                                                                        {
                                                                            cbL1_DropDown(sender, e);

                                                                        }));
                                                                        if (cbL1.Items.Count != -1)
                                                                            for (int cl1 = 0; cl1 < cbL1.Items.Count; cl1++)
                                                                            {
                                                                                this.Invoke(new Action(() =>
                                                                                {
                                                                                    cbL1_DropDown(sender, e);
                                                                                    cbL1.SelectedIndex = cl1;
                                                                                    if (cl1 == 0)
                                                                                    {
                                                                                        porcentajeSuc1();
                                                                                        guardarP();
                                                                                    }

                                                                                    this.Refresh();

                                                                                }));

                                                                                if (cl1 != 0)
                                                                                {
                                                                                    cbMarca_DropDown(sender, e);
                                                                                    if (cbMarca.Items.Count != -1)
                                                                                    {
                                                                                        cbMarca_DropDown(sender, e);
                                                                                        cbMarca.SelectedIndex = 0;
                                                                                        porcentajeSuc1();
                                                                                        guardarP();
                                                                                    }
                                                                                    //l2
                                                                                    this.Invoke(new Action(() =>
                                                                                    {
                                                                                        cbL2_DropDown(sender, e);

                                                                                    }));
                                                                                    if (cbL2.Items.Count != -1)
                                                                                        for (int cl2 = 0; cl2 < cbL2.Items.Count; cl2++)
                                                                                        {
                                                                                            this.Invoke(new Action(() =>
                                                                                            {
                                                                                                cbL2_DropDown(sender, e);
                                                                                                cbL2.SelectedIndex = cl2;
                                                                                                if (cl2 == 0)
                                                                                                {
                                                                                                    porcentajeSuc1();
                                                                                                    guardarP();
                                                                                                }
                                                                                                this.Refresh();

                                                                                            }));

                                                                                            if (cl2 != 0)
                                                                                            {
                                                                                                //l3
                                                                                                this.Invoke(new Action(() =>
                                                                                                {
                                                                                                    cbL3_DropDown(sender, e);

                                                                                                }));
                                                                                                if (cbL3.Items.Count != -1)
                                                                                                    for (int cl3 = 0; cl3 < cbL3.Items.Count; cl3++)
                                                                                                    {
                                                                                                        this.Invoke(new Action(() =>
                                                                                                        {
                                                                                                            cbL3_DropDown(sender, e);
                                                                                                            cbL3.SelectedIndex = cl3;
                                                                                                            if (cl3 == 0)
                                                                                                            {
                                                                                                                porcentajeSuc1();
                                                                                                                guardarP();
                                                                                                            }
                                                                                                            this.Refresh();
                                                                                                        }));

                                                                                                        if (cl3 != 0)
                                                                                                        {
                                                                                                            //l4
                                                                                                            this.Invoke(new Action(() =>
                                                                                                            {
                                                                                                                cbL4_DropDown(sender, e);

                                                                                                            }));
                                                                                                            if (cbL4.Items.Count != -1)
                                                                                                                for (int cl4 = 0; cl4 < cbL4.Items.Count; cl4++)
                                                                                                                {
                                                                                                                    this.Invoke(new Action(() =>
                                                                                                                    {
                                                                                                                        cbL4_DropDown(sender, e);
                                                                                                                        cbL4.SelectedIndex = cl4;
                                                                                                                        if (cl4 == 0)
                                                                                                                        {
                                                                                                                            porcentajeSuc1();
                                                                                                                            guardarP();
                                                                                                                        }
                                                                                                                        this.Refresh();
                                                                                                                    }));

                                                                                                                    if (cl4 != 0)
                                                                                                                    {
                                                                                                                        //l5
                                                                                                                        this.Invoke(new Action(() =>
                                                                                                                        {
                                                                                                                            cbL5_DropDown(sender, e);

                                                                                                                        }));
                                                                                                                        if (cbL5.Items.Count != -1)
                                                                                                                            for (int cl5 = 0; cl5 < cbL5.Items.Count; cl5++)
                                                                                                                            {
                                                                                                                                this.Invoke(new Action(() =>
                                                                                                                                {
                                                                                                                                    cbL5_DropDown(sender, e);
                                                                                                                                    cbL5.SelectedIndex = cl5;
                                                                                                                                    if (cl5 == 0)
                                                                                                                                    {
                                                                                                                                        porcentajeSuc1();
                                                                                                                                        guardarP();
                                                                                                                                    }
                                                                                                                                    this.Refresh();
                                                                                                                                }));

                                                                                                                                if (cl5 != 0)
                                                                                                                                {
                                                                                                                                    //l6
                                                                                                                                    this.Invoke(new Action(() =>
                                                                                                                                    {
                                                                                                                                        cbL6_DropDown(sender, e);

                                                                                                                                    }));
                                                                                                                                    if (cbL6.Items.Count != -1)
                                                                                                                                        for (int cl6 = 0; cl6 < cbL6.Items.Count; cl6++)
                                                                                                                                        {
                                                                                                                                            this.Invoke(new Action(() =>
                                                                                                                                            {
                                                                                                                                                cbL6_DropDown(sender, e);
                                                                                                                                                cbL6.SelectedIndex = cl6;
                                                                                                                                                if (cl6 == 0)
                                                                                                                                                {
                                                                                                                                                    porcentajeSuc1();
                                                                                                                                                    guardarP();
                                                                                                                                                }
                                                                                                                                                this.Refresh();
                                                                                                                                            }));

                                                                                                                                            if (cl6 != 0)
                                                                                                                                            {
                                                                                                                                                //marca
                                                                                                                                                this.Invoke(new Action(() =>
                                                                                                                                                {
                                                                                                                                                    cbMarca_DropDown(sender, e);
                                                                                                                                                }));

                                                                                                                                                //if (cbMarca.Items.Count != -1)
                                                                                                                                                //    for (int clm = 0; clm < 1; clm++)
                                                                                                                                                //    {
                                                                                                                                                this.Invoke(new Action(() =>
                                                                                                                                                {
                                                                                                                                                    cbMarca_DropDown(sender, e);
                                                                                                                                                    cbMarca.SelectedIndex = 0;
                                                                                                                                                    porcentajeSuc1();
                                                                                                                                                    guardarP();
                                                                                                                                                }));

                                                                                                                                                //} //marca
                                                                                                                                            }
                                                                                                                                        } //l6
                                                                                                                                }
                                                                                                                            }//l5
                                                                                                                    }
                                                                                                                }//l4
                                                                                                        }
                                                                                                    }//l3
                                                                                            }
                                                                                        }//l2
                                                                                }
                                                                            }//l1
                                                                    }
                                                                }//linea
                                                        }
                                                    }//familia
                                            }
                                        }//dep
                                }
                            }//div             

                }//suc
           
            //////////////////////////////

            #endregion
            UseWaitCursor = false;
            MessageBox.Show("Finalizado");
            //copiando = false;
        }
        private void guardarP()
        {
            for (int x = 0; x <= dgv.Rows.Count-1;x++)
            {
                if (dgv.Rows[x].Cells[1].Value!=null && dgv.Rows[x].Cells[2].Value!=null)
                {
                    double porcentaje1 = double.Parse(dgv.Rows[x].Cells[1].Value.ToString());
                    //double porcentaje2 = double.Parse(dgv.Rows[x].Cells[2].Value.ToString());
                    /////////////////////////////////////////////////////////////////////////
                    string q = "update cedula2 set porsentajeP="+porcentaje1+" where nombre='" + Properties.Settings.Default.escenario + " ' " + cargarS2[x] + " and idsucursal=" + iddsuc2[(cbSucursalAcopiar.SelectedIndex + 2)]+" limit 1";
                    cmd = new MySqlCommand(q, Conn);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void OnBgwGenerarDoWork(object sender, DoWorkEventArgs e)
        {
            copiando = true;
            copiarPorcentaje(sender, e);
        }
    }
}
