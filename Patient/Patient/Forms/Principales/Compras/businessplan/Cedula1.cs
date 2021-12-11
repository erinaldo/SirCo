using MySql.Data.MySqlClient;
using System;
using System.Globalization;
using System.Windows.Forms;
//using nmExcel = Microsoft.Office.Interop.Excel;

namespace business_plan
{
	public partial class Cedula1 : Form
	{
		#region variables conexion

		private MySqlCommand cmd;
		private string conexion = "SERVER=" + Properties.Settings.Default.server + "; DATABASE=dwh; user=" + Properties.Settings.Default.usuario + "; PASSWORD=" + Properties.Settings.Default.pass + ";";
		//private string conexion = "SERVER=localhost; DATABASE=dwh; user=root; PASSWORD= ;";
		private MySqlConnection Conn;
		private string query;
		private MySqlDataReader reader;
		#endregion variables conexion
		#region variables_globales
		double porcentajeA = 0;
		private string[] idd = new string[1000];
		private double importe = 0.00;
		private double porciento = 0.00;
		double Ventatotalimporte = 0;
		double pronosticopares = 0;
		DateTime FechaAF = DateTime.Now, FechaAI = DateTime.Now;
		#endregion variables_globales
		#region variables escenario
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
		string division = "", depto = "", fam = "", linea = "", subl1, subl2, subl3, subl4, subl5, subl6;
		string s="-1", d="-1", dd="-2", f="-1", l="-1", l1="-1", l2="-1", l3="-1", l4="-1", l5="-1", l6="-1", m="-1";
		bool total = true;
		string[] queryguardar = new string[1000];
		string[] querycargar = new string[1000];
		string queryunidadesAsignadas="  ";
		bool cargando = false;
		bool solototal = false;
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
		/////////////////////////////////////////////////
		//@est@
        int ticks = 0;
		int Aseleccion_sucursal = -1;
		int Aseleccion_division = -1;
		int Aseleccion_depto = -1;
		int Aseleccion_familia = -1;
		int Aseleccion_linea = -1;
		bool generando = false;
		//int Aseleccion_linea = -1;
		int Aseleccion_l1 = -1;
		int Aseleccion_l2 = -1;
		int Aseleccion_l3 = -1;
		int Aseleccion_l4 = -1;
		int Aseleccion_l5 = -1;
		int Aseleccion_l6 = -1;
		string Aseleccion_marca = "";
        string groupby = "";
        string where = "";
        string whereLeft = "";
        bool soloSuc = false;
		bool totalE = false;
		/////////////////////////////////////////////////////////////
		string[] estructura_recalcular=new string[13];
		string[] whereupdateD=new string[10000];
		string[] whereupdateUP = new string[10000];
		int pocision = 0;
		string[] idA=new string[1000];
        int posicionCombos = 0;
		#region combos
		private void Zapaterias_torreon(object sender, EventArgs e) // total empresa------
		{
            posicionCombos = 0;
            bloquearComponentes();
            desbloquearComponentes();
            soloSuc = false;
			dgvCed2.Refresh();
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
			checkBox1.Checked = false;
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
			solototal = true;
			querycargar[0] = " and ZapateriasTorreon=1";
			M_cargargrid(total);
		}
		private void cbSucursales_DropDown(object sender, EventArgs e)
		{
            limpiar_combosEstructura();
			#region reiniciar V
            bandera_sucursal = false;
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
            this.Invoke(new Action(() =>
               {
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
               }));
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
            idsucursalvarios = "and (V.IDSUCURSAL= '01' OR V.IDSUCURSAL='02' OR V.IDSUCURSAL='06' OR V.IDSUCURSAL='08')";
			int i = 1;
			query = "SELECT descrip,idsucursal from sucursal where visible='S'";
			checaConexion();
			cmd = new MySqlCommand(query, Conn);
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
                if(i==1)
                {
                    idsucursalvarios = "and (V.idsucursal= " + reader["idsucursal"].ToString();
                }
                else
                {
                    idsucursalvarios += " or V.idsucursal="+reader["idsucursal"].ToString();
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
            posicionCombos = 1;
            soloSuc = true;
			pocision = 1;
			bandera_sucursal = true;
			#region reiniciar valores
            this.Invoke(new Action(() =>
               {
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
               }));
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
				s = ","+idd[cbSucursales.SelectedIndex];
				querycargar[0] = "and idsucursal=" + idd[cbSucursales.SelectedIndex] + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'";
				queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "'" + querycargar[0];
				sucursalcargar = "and idsucursal=" + idd[cbSucursales.SelectedIndex] + "";
				totalE = false;
                groupby = "idsucursal";
                where = "";
                whereLeft = idsucursal;
			}
			else
			{
                where = "";
                groupby = " idsucursal";
                whereLeft = idsucursalvarios;
				queryunidadesAsignadas = "select * from cedula2 where nombre='"+Properties.Settings.Default.escenario+"' and ZapateriasTorreon=1";
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
				s = ",0";
				solototal = false;
				sucursalcargar = "and idsucursal=0";
				seleccion_sucursal = 0;
				totalE = true;
			}
			solototal = false;

			if (!valoresform)
				M_cargargrid(total);
			}));
		}
		private void cbDivision_DropDown(object sender, EventArgs e)
        {
            #region combosText
            cbDivisiones.Text = "";
            cbDepto.Text = "";
            cbFamilia.Text = "";
            cbLinea.Text = "";
            cbL1.Text = "";
            cbL2.Text = "";
            cbL3.Text = "";
            cbL4.Text = "";
            cbL5.Text = "";
            cbL6.Text = "";
            cbMarca.Text = "";
            #endregion
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
            posicionCombos = 2;
            soloSuc = false;
			pocision = 2;
			bandera_division = true;
			#region reiniciar valores
            this.Invoke(new Action(() =>
               {
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
               }));
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
			//@est@
			
			if (cbDivisiones.Text != "Total")
			{
				seleccion_division = Convert.ToInt32(idd[cbDivisiones.SelectedIndex]);

				iddivision = " e.iddivisiones=" + idd[cbDivisiones.SelectedIndex];
				total = false;
				string[] texto = cbDivisiones.Text.Split('=');
				lbDivision.Text = "Division=" + texto[0];
				query = "SELECT descrip,iddivisiones from estdivisiones where visiblebp='1' and iddivisiones=" + idd[cbDivisiones.SelectedIndex];
				wherequery[0] = idsucursalvarios + " " + iddivision;
				iddivisionesvarios = iddivision;
				division = "and iddivisiones=" + idd[cbDivisiones.SelectedIndex];
				queryguardar[0] =  s + "," + idd[cbDivisiones.SelectedIndex] + ",-1,-1,-1,-1,-1,-1,-1,-1,-1,'-1'";
				querycargar[0] = sucursalcargar + " and iddivisiones=" + idd[cbDivisiones.SelectedIndex] + " and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
				d = ","+idd[cbDivisiones.SelectedIndex];
				divisioncargar = "and iddivisiones=" + idd[cbDivisiones.SelectedIndex] + "";
				if(solocalzadoDropdown!=" ")
				{
					queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " and iddivisiones=-1";
				}
				else
				{
					queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
				}
				totalE = false;
                groupby = "iddivisiones";
                where = "  e.iddivisiones=1";
                whereLeft = idsucursalvarios;
			}
			else
			{
                groupby = "iddivisiones";
                where = "  e.iddivisiones=1";
                whereLeft = idsucursalvarios;
				queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar;
				iddivision = " ";
				iddivisionesvarios = " e.iddivisiones=1";
				division = " ";
				for (int i = 0; i <= cbDivisiones.Items.Count - 1; i++)
				{
					querycargar[i] = sucursalcargar + " and iddivisiones=" + idd[(i + 1)] + " and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
					iddivision = "and V.iddivisiones=" + idd[(i + 1)];
					wherequery[i] = idsucursalvarios + " " + iddivision;
					queryguardar[i] = s + "," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,-1,-1,-1,'-1'";
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
				totalE = true;
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
            #region combosText
            cbDepto.Text = "";
            cbFamilia.Text = "";
            cbLinea.Text = "";
            cbL1.Text = "";
            cbL2.Text = "";
            cbL3.Text = "";
            cbL4.Text = "";
            cbL5.Text = "";
            cbL6.Text = "";
            cbMarca.Text = "";
            #endregion
			this.Invoke(new Action(() =>
			{
            cbDepto.Items.Clear();
			cbDepto.Items.Add("Total");
			string[] texto = iddivision.Split('.');
			int i = 1;
			query = "SELECT descrip,iddepto from estdepartamento where visiblebp='1' and iddivisiones=1";
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

			}));
		 
		   
		}
		private void cbDepto_SelectedIndexChanged(object sender, EventArgs e)
		{
            posicionCombos = 3;
            soloSuc = false;
			pocision = 3;
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
			//@est@
		   
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

				iddepto = "and e.iddepto=" + idd[cbDepto.SelectedIndex];
				wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddepto;
				iddeptovarios = iddepto;
				total = false;
				string[] texto = cbDepto.Text.Split('=');
				lbdepartamento.Text = "Departamento=" + texto[0];
				query = "SELECT descrip,iddepto from estdepartamento where visiblebp='1' and iddepto=" + idd[cbDepto.SelectedIndex];
				depto = "and iddepto=" + idd[cbDepto.SelectedIndex];
				queryguardar[0] =  s + " " + d + "," + idd[cbDepto.SelectedIndex] + ",-1,-1,-1,-1,-1,-1,-1,-1,'-1'";
				dd = ","+idd[cbDepto.SelectedIndex];
				querycargar[0] = sucursalcargar + " " + divisioncargar + " and iddepto=" + idd[cbDepto.SelectedIndex] + " and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
				queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' "+querycargar[0];
				departamentocargar = "and iddepto=" + idd[cbDepto.SelectedIndex];
				totalE = false;
                groupby = "iddepto";
                where = "  e.iddivisiones=1 " + iddepto;
                whereLeft = idsucursalvarios;
			}
			else
			{
                groupby = "iddepto";
                where = " e.iddivisiones=1";
                whereLeft = idsucursalvarios;
				queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " and iddepto=-1";
				//iddeptovarios = " ";
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
							pocision = 13;

						}
				}
				total = true;
				query = "SELECT descrip,iddepto from estdepartamento where visiblebp='1'  and iddivisiones=1";
				lbdepartamento.Text = "Departamento=Total";
				depto = " ";
				dd = ",0";
				departamentocargar = "and iddepto=0";
				seleccion_depto = 0;
				totalE = true;
			}
			solototal = false;
			}));
			

			if (!valoresform)
				M_cargargrid(total);
		}
		private void cbFamilia_DropDown(object sender, EventArgs e)
		{
            #region combosText
            cbFamilia.Text = "";
            cbLinea.Text = "";
            cbL1.Text = "";
            cbL2.Text = "";
            cbL3.Text = "";
            cbL4.Text = "";
            cbL5.Text = "";
            cbL6.Text = "";
            cbMarca.Text = "";
            #endregion
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
			checaConexion();
		   if(cbSucursales.Text==""&&cbDivisiones.Text==""&&cbDepto.Text=="")
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
			
		}
		private void cbFamilia_SelectedIndexChanged(object sender, EventArgs e)
		{
            posicionCombos = 4;
            soloSuc = false;
			pocision = 4;
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

				idfamilia = "and e.idfamilia=" + idd[cbFamilia.SelectedIndex];
				idfamiliavarios = idfamilia;
				total = false;
				wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamilia;
				string[] texto = cbFamilia.Text.Split('=');
				lbfamilia.Text = "Familia=" + texto[0].ToString();
				query = "SELECT descrip,idfamilia from estfamilia where visiblebp='1' and idfamilia=" + idd[cbFamilia.SelectedIndex] + "";
				fam = "and idfamilia=" + idd[cbFamilia.SelectedIndex];
				queryguardar[0] =  s + " " + d + " " + dd + "," + idd[cbFamilia.SelectedIndex] + ",0,0,0,0,0,0,0,'0'";
				f = ","+idd[cbFamilia.SelectedIndex];
				querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " and idfamilia=" + idd[cbFamilia.SelectedIndex] + " and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
				queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' "+querycargar[0];
				familiacargar = "and idfamilia=" + idd[cbFamilia.SelectedIndex];
				totalE = false;
                groupby = "idfamilia";
                where = iddivisionesvarios + " " + iddeptovarios+" "+idfamilia;
                whereLeft = idsucursalvarios;
			}
			else
			{
                groupby = "idfamilia";
                where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios;
                whereLeft = idsucursalvarios;
				queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' "+sucursalcargar+" "+divisioncargar+" "+departamentocargar+" "+" and idfamilia=-1 and marca=-1";
				idfamiliavarios = " ";
				for (int i = 0; i <= cbFamilia.Items.Count - 1; i++)
				{
					idfamilia = "and V.idfamilia=" + idd[(i + 1)];
					wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamilia;
					queryguardar[i] =  s + " " + d + " " + dd + "," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,-1,'-1'";
					querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " and idfamilia=" + idd[(i + 1)] + " and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
					if(cbSucursales.Text==""&&cbDivisiones.Text==""&&cbDepto.Text=="")
					  {
						  wherequery[i] = idfamilia + " and iddivisiones=1";
						  queryguardar[i] = ",-1,-1,-1,"+idd[(i+1)]+",-1,-1,-1,-1,-1,-1,-1,'-1'";
						  querycargar[i] = "and idsucursal=-1 and iddivisiones=-1 and iddepto=-1 and idfamilia=" + idd[(i + 1)] + " and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
						  queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
					  }
				}
				total = true;
				query = "SELECT descrip,idfamilia from estfamilia where visiblebp='1' " + division + " " + depto;
				lbfamilia.Text = "Familia=Total";
				fam = " ";
				f = ",0";
				familiacargar = "and idfamilia=0";
				seleccion_familia = 0;
				totalE = true;
			}
			solototal = false;

			if (!valoresform)
				M_cargargrid(total);
		}
		private void cbLinea_DropDown(object sender, EventArgs e)
		{
            #region combosText
            cbLinea.Text = "";
            cbL1.Text = "";
            cbL2.Text = "";
            cbL3.Text = "";
            cbL4.Text = "";
            cbL5.Text = "";
            cbL6.Text = "";
            cbMarca.Text = "";
            #endregion
			#region reiniciar V
			linea = "";
			subl1 = "";
			subl2 = "";
			subl3 = "";
			subl4 = "";
			subl5 = "";
			subl6 = "";
			#endregion
			checaConexion();
			if (cbSucursales.Text == "" && cbDivisiones.Text == "" && cbDepto.Text == "" && cbFamilia.Text=="")
			{
				cbLinea.Items.Clear();
				cbLinea.Items.Add("Total");
				int i = 1;

				query = "SELECT descrip,idlinea from estlinea where visiblebp='1' and iddivisiones=1";
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
		else
			{
				cbLinea.Items.Clear();
				cbLinea.Items.Add("Total");
				int i = 1;

				query = "SELECT descrip,idlinea from estlinea as e where visiblebp='1' " + division + " " +iddeptovarios + " " +idfamiliavarios ;
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
				reader.Close();
                idlineavarios += ")";
			}
			
		}
		private void cbLinea_SelectedIndexChanged(object sender, EventArgs e)
		{
            posicionCombos = 5;
            soloSuc = false;
			pocision = 5;
			bandera_linea = true;
			//@est@

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
				idlinea = "and e.idlinea=" + idd[cbLinea.SelectedIndex];
				idlineavarios = idlinea;
				total = false;
				string[] texto = cbLinea.Text.Split('=');
				wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlinea;
				query = "SELECT descrip,idlinea from estlinea where visiblebp='1' and idlinea=" + idd[cbLinea.SelectedIndex] + "";
				linea = "and idlinea=" + idd[cbLinea.SelectedIndex];
				queryguardar[0] = s + " " + d + " " + dd + " " + f + "," + idd[cbLinea.SelectedIndex] + ",-1,-1,-1,-1,-1,-1,'-1'";
				l =","+idd[cbLinea.SelectedIndex];
				queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' "+querycargar[0];
				lineacargar = "and idlinea=" + idd[cbLinea.SelectedIndex];
				totalE = false;
                groupby = "idlinea";
                where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios+" "+idlinea;
                whereLeft = idsucursalvarios;
			}
			else
			{
                groupby = "idlinea";
                where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios+" "+idlineavarios;
                whereLeft = idsucursalvarios;
				queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' "+sucursalcargar+" "+divisioncargar+" "+departamentocargar+" "+familiacargar+" and idlinea=-1";
				for (int i = 0; i <= cbLinea.Items.Count - 1; i++)
				{
					querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " and idlinea=" + idd[(i + 1)] + " and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
					idlinea = "and V.idlinea=" + idd[(i + 1)];
					wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlinea;
					queryguardar[i] =  s + " " + d + " " + dd + " " + f + "," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,'-1'";
					query = "SELECT descrip,idlinea from estlinea where visiblebp='1' " + division + " " + depto + "" + " " + fam;

						  if (cbSucursales.Text == "" && cbDivisiones.Text == "" && cbDepto.Text == "" && cbFamilia.Text=="")
							{
								wherequery[i] = idlinea + " and iddivisiones=1";
								queryguardar[i] = ",-1,-1,-1,-1," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,'-1'";
								querycargar[i] = "and idsucursal=-1 and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=" + idd[(i + 1)] + " and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
								queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
								query = "SELECT descrip,idlinea from estlinea where visiblebp='1' and iddivisiones=1";
							}
				}
				total = true;
				linea = " ";
				l = ",0";
				lineacargar = "and idlinea=0";
				seleccion_linea = 0;
				totalE = true;
			}
			lblinea.Text = "Linea=" + cbLinea.Text;
			solototal = false;

			if (!valoresform)
				M_cargargrid(total);
		}
		private void cbL1_DropDown(object sender, EventArgs e)
		{
            #region combosText
            cbL1.Text = "";
            cbL2.Text = "";
            cbL3.Text = "";
            cbL4.Text = "";
            cbL5.Text = "";
            cbL6.Text = "";
            cbMarca.Text = "";
            #endregion
			#region reiniciar V

			subl1 = "";
			subl2 = "";
			subl3 = "";
			subl4 = "";
			subl5 = "";
			subl6 = "";
			#endregion
			checaConexion();
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
            if (cbL1.Items.Count == 1)
            {
                cbL1.Items.Clear();
            }
		}
		private void cbL1_SelectedIndexChanged(object sender, EventArgs e)
		{
            posicionCombos = 6;
            soloSuc = false;
			pocision = 6;
			bandera_l1 = true;
			//@est@
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
				idl1 = "and e.idl1=" + idd[cbL1.SelectedIndex];
				idl1varios = idl1;
				string[] texto = cbL1.Text.Split('=');
				total = false;
				lbl1.Text = "L1=" + texto[0].ToString();
				query = "SELECT descrip,idl1 from estl1 where visiblebp='1' and idl1=" + idd[cbL1.SelectedIndex];
				wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1;
				subl1 = "and idl1=" + idd[cbL1.SelectedIndex];
				queryguardar[0] =  s + " " + d + " " + dd + " " + f + " " + l + "," + idd[cbL1.SelectedIndex] + ",-1,-1,-1,-1,-1,'-1'";
				l1 = ","+idd[cbL1.SelectedIndex];
				queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' "+querycargar[0];
				l1cargar = "and idl1=" + idd[cbL1.SelectedIndex];
				totalE = false;
                groupby = "idl1";
                where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios+" "+idl1;
                whereLeft = idsucursalvarios;
			}
			else
			{
                groupby = "idl1";
                where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios;
                whereLeft = idsucursalvarios;
				queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' "+sucursalcargar+" "+divisioncargar+" "+departamentocargar+" "+familiacargar+" "+lineacargar+" and idl1=-1";
				idl1varios = " ";
				for (int i = 0; i <= cbL1.Items.Count - 1; i++)
				{
								query = "SELECT descrip,idl1 from estl1 where visiblebp='1' " + division + " " + depto + " " + fam + " " + linea;
					querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " and idl1=" + idd[(i + 1)] + " and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
					idl1 = "and V.idl1=" + idd[(i + 1)];
					wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1;
					queryguardar[i] =  s + " " + d + " " + dd + " " + f + " " + l + "," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,'-1'";
					 if (cbSucursales.Text == "" && cbDivisiones.Text == "" && cbDepto.Text == "" && cbFamilia.Text == "" && cbLinea.Text == "")
					 {
						 wherequery[i] = idl1 + " and iddivisiones=1";
						 queryguardar[i] = ",-1,-1,-1,-1,-1," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,'-1'";
						 querycargar[i] = "and idsucursal=-1 and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=" + idd[(i + 1)] + " and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
						 queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
						 query = "SELECT descrip,idl1 from estl1 where visiblebp='1' and iddivisiones=1";
					 }

				}
				subl1 = " ";
				lbl1.Text = "L1=Total";
				total = true;
				l1 = ",0";
				l1cargar = "and idl1=0";
				seleccion_l1 = 0;
				totalE = true;
			}
			lbl1.Text = "L1=" + cbL1.Text;
			solototal = false;

			if (!valoresform)
				M_cargargrid(total);
		}
		private void cbL2_DropDown(object sender, EventArgs e)
		{
            #region combosText
            cbL2.Text = "";
            cbL3.Text = "";
            cbL4.Text = "";
            cbL5.Text = "";
            cbL6.Text = "";
            cbMarca.Text = "";
            #endregion
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
			checaConexion();
			cmd = new MySqlCommand(query, Conn);
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
                if (i == 1)
                {
                    idl2varios = "and (e.idl2= " + reader["idl2"].ToString();
                }
                else
                {
                    idl2varios += " or e.idl2=" + reader["idl2"].ToString();
                }
				cbL2.Items.Add(reader["descrip"].ToString());
				idd[i] = reader["idl2"].ToString();
				i++;
			}
            idl2varios += ")";
			reader.Close();
            if (cbL2.Items.Count == 1)
            {
                cbL2.Items.Clear();
            }
		}
		private void cbL2_SelectedIndexChanged(object sender, EventArgs e)
		{
            posicionCombos = 7;
			pocision = 7;
			bandera_l2 = true;
			//@est@
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
				idl2 = "and e.idl2=" + idd[cbL2.SelectedIndex];
				idl2varios = idl2;
				total = false;
				query = "SELECT descrip,idl2 from estl2 where visiblebp='1' and idl2=" + idd[cbL2.SelectedIndex];
				wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2;
				subl2 = "and idl2=" + idd[cbL2.SelectedIndex];
				queryguardar[0] =  s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + "," + idd[cbL2.SelectedIndex] + ",-1,-1,-1,-1,'-1'";
				l2 = ","+idd[cbL2.SelectedIndex];
				queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' "+querycargar[0];
				l2cargar = "and idl2="+idd[cbL2.SelectedIndex];
				totalE = false;
                groupby = "idl2";
                where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios+" "+idl2varios;
                whereLeft = idsucursalvarios;
			}
			else
			{
                groupby = "idl2";
                where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios;
                whereLeft = idsucursalvarios;
				queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' "+sucursalcargar+" "+divisioncargar+" "+departamentocargar+" "+familiacargar+" "+lineacargar+" "+l1cargar+" and idl2=-1 and marca='-1'";
				subl2 = " ";
				for (int i = 0; i <= cbL2.Items.Count - 1; i++)
				{
					querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " and idl2=" + idd[(i+1)] + " and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
					idl2 = "and V.idl2=" + idd[(i + 1)];
					wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2;
					queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + "," + idd[(i + 1)] + ",-1,-1,-1,-1,'-1'";
				}
				l2 = ",0";
				total = true;
				query = "SELECT descrip,idl2 from estl2 where visiblebp='1' " + division + " " + depto + " " + fam + " " + linea + " " + subl1;
				l2cargar = "and idl2=0";
				seleccion_l2 = 0;
				totalE = true;
			}
			lbL2.Text = "L2=" + cbL2.Text;
			solototal = false;

			if (!valoresform)
				M_cargargrid(total);
		}
		private void cbL3_DropDown(object sender, EventArgs e)
		{
            #region combosText
            cbL3.Text = "";
            cbL4.Text = "";
            cbL5.Text = "";
            cbL6.Text = "";
            cbMarca.Text = "";
            #endregion
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
			checaConexion();
			cmd = new MySqlCommand(query, Conn);
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
                if (i == 1)
                {
                    idl3varios = "and (e.idl3= " + reader["idl3"].ToString();
                }
                else
                {
                    idl3varios += " or e.idl3=" + reader["idl3"].ToString();
                }
				cbL3.Items.Add(reader["descrip"].ToString());
				idd[i] = reader["idl3"].ToString();
				i++;
			}
            idl3varios += ")";
			reader.Close();
            if (cbL3.Items.Count == 1)
            {
                cbL3.Items.Clear();
            }
		}
		private void cbL3_SelectedIndexChanged(object sender, EventArgs e)
		{
            posicionCombos = 8;
			pocision = 8;
			bandera_l3 = true;
			//@est@
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

				l3cargar = "and idl3="+idd[cbL3.SelectedIndex];
				querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar+ " " + l2cargar + " and idl3="+idd[cbL3.SelectedIndex]+" and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
				idl3 = "and e.idl3=" + idd[cbL3.SelectedIndex];
				idl3varios = idl3;
				total = false;
				query = "SELECT descrip,idl3 from estl3 where visiblebp='1' and idl3=" + idd[cbL3.SelectedIndex];
				wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3;
				subl3 = "and idl3=" + idd[cbL3.SelectedIndex];
				queryguardar[0] =  s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + "," + idd[cbL3.SelectedIndex] + ",-1,-1,-1,'-1'";
				l3 = ","+idd[cbL3.SelectedIndex];
				queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' "+querycargar[0];
				totalE = false;
                groupby = "idl3";
                where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios+" "+idl3varios;
                whereLeft = idsucursalvarios;
			}
			else
			{
                groupby = "idl3";
                where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios;
                whereLeft = idsucursalvarios;
				queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' "+sucursalcargar+" "+divisioncargar+" "+departamentocargar+" "+familiacargar+" "+lineacargar+" "+l1cargar+" "+l2cargar+" and idl3=-1";
				subl3 = " ";
				for (int i = 0; i <= cbL3.Items.Count - 1; i++)
				{
					querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " and idl3=" + idd[(i+1)] + " and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
					idl3 = "and V.idl3=" + idd[(i + 1)];
					wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3;
					queryguardar[i] =  s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + "," + idd[(i + 1)] + ",-1,-1,-1,'-1'";
				}
				total = true;
				query = "SELECT descrip,idl3 from estl3 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2;
				l3 = ",0";
				l3cargar = "and idl3=0";
				seleccion_l3 = 0;
				totalE = true;
			}
			lbL3.Text = "L3=" + cbL3.Text;
			solototal = false;

			if (!valoresform)
				M_cargargrid(total);
		}
		private void cbL4_DropDown(object sender, EventArgs e)
		{
            #region combosText
            cbL4.Text = "";
            cbL5.Text = "";
            cbL6.Text = "";
            cbMarca.Text = "";
            #endregion
			#region reiniciar V

			subl4 = "";
			subl5 = "";
			subl6 = "";
			#endregion
			cbL4.Items.Clear();
			cbL4.Items.Add("Total");
			int i = 1;

			query = "SELECT descrip,idl4 from estl4 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2 + " " + subl3;
			checaConexion();
			cmd = new MySqlCommand(query, Conn);
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
                if (i == 1)
                {
                    idl4varios = "and (e.idl4= " + reader["idl4"].ToString();
                }
                else
                {
                    idl4varios += " or e.idl4=" + reader["idl4"].ToString();
                }
				cbL4.Items.Add(reader["descrip"].ToString());
				idd[i] = reader["idl4"].ToString();
				i++;
			}
            idl4varios += ")";
			reader.Close();
            if (cbL4.Items.Count == 1)
            {
                cbL4.Items.Clear();
            }
		}
		private void cbL4_SelectedIndexChanged(object sender, EventArgs e)
		{
            posicionCombos = 9;
			pocision = 9;
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
				idl4 = "and e.idl4=" + idd[cbL4.SelectedIndex];
				idl4varios = idl4;
				total = false;
				query = "SELECT descrip,idl4 from estl4 where visiblebp='1' and idl4=" + idd[cbL4.SelectedIndex];
				wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4;
				subl4 = "and idl4=" + idd[cbL4.SelectedIndex];
				queryguardar[0] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + "," + idd[cbL4.SelectedIndex] + ",-1,-1,'-1'";
				l4 = "," + idd[cbL4.SelectedIndex];
				queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
				l4cargar = "and idl4=" + idd[cbL4.SelectedIndex];
				totalE = false;
                groupby = "idl4";
                where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios+" "+idl4varios;
                whereLeft = idsucursalvarios;
			}
			else
			{
                groupby = "idl4";
                where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios;
                whereLeft = idsucursalvarios;
				queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " and idl4=-1";
				subl4 = " ";
				for (int i = 0; i <= cbL4.Items.Count - 1; i++)
				{
					querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " and idl4=" + idd[(i + 1)] + " and idl5=-1 and idl6=-1 and marca='-1'  ";
					idl4 = "and V.idl4=" + idd[(i + 1)];
					wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4;
					queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + "," + idd[(i + 1)] + ",-1,-1,'-1'";
				}
				total = true;
				query = "SELECT descrip,idl4 from estl4 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2 + " " + subl3;
				l4 = ",0";
				l4cargar = "and idl4=0";
				seleccion_l4 = 0;
				totalE = true;
			}
			lbL4.Text = "L4=" + cbL4.Text;
			solototal = false;
			if (!valoresform)
				M_cargargrid(total);
			
		}
		private void cbL5_DropDown(object sender, EventArgs e)
		{
            #region combosText
            cbL5.Text = "";
            cbL6.Text = "";
            cbMarca.Text = "";
            #endregion
			#region reiniciar V

			subl5 = "";
			subl6 = "";
			#endregion
			cbL5.Items.Clear();
			cbL5.Items.Add("Total");
			int i = 1;

			query = "SELECT descrip,idl5 from estl5 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2 + " " + subl3 + " " + subl4;
			checaConexion();
			cmd = new MySqlCommand(query, Conn);
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
                if (i == 1)
                {
                    idl5varios = "and (e.idl5= " + reader["idl5"].ToString();
                }
                else
                {
                    idl5varios += " or e.idl5=" + reader["idl5"].ToString();
                }
				cbL5.Items.Add(reader["descrip"].ToString());
				idd[i] = reader["idl5"].ToString();
				i++;
			}
            idl5varios += ")";
			reader.Close();
            if (cbL5.Items.Count == 1)
            {
                cbL5.Items.Clear();
            }
		}
		private void cbL5_SelectedIndexChanged(object sender, EventArgs e)
		{
            posicionCombos = 10;
			pocision = 10;
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

				querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " and idl5="+idd[cbL5.SelectedIndex]+" and idl6=-1 and marca='-1'  ";
				idl5 = "and e.idl5=" + idd[cbL5.SelectedIndex];
				idl5varios = idl5;
				total = false;
				query = "SELECT descrip,idl5 from estl5 where visiblebp='1' and idl5=" + idd[cbL5.SelectedIndex];
				wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5;
				subl5 = "and idl5=" + idd[cbL5.SelectedIndex];
				queryguardar[0] =  s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + " " + l4 + "," + idd[cbL5.SelectedIndex] + ",-1,'-1'";
				l5 = ","+idd[cbL5.SelectedIndex];
				queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
				l5cargar = "and idl5="+idd[cbL5.SelectedIndex];
				totalE = false;
                groupby = "idl5";
                where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios+" "+idl5varios;
                whereLeft = idsucursalvarios;
			}
			else
			{
                groupby = "idl5";
                where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios;
                whereLeft = idsucursalvarios;
				queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " "+l4cargar+" and idl5=-1";
				idl5varios = " ";
				subl5 = " ";
				for (int i = 0; i <= cbL5.Items.Count - 1; i++)
				{
					querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " and idl5=" + idd[(i+1)] + " and idl6=-1 and marca='-1'  ";
					idl5 = "and V.idl5=" + idd[(i + 1)];
					wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5;
					queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + " " + l4 + "," + idd[(i + 1)] + ",-1,'-1'";
				}
				total = true;
				query = "SELECT descrip,idl5 from estl5 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2 + " " + subl3 + " " + subl4;
				l5 = ",0";
				l5cargar = "and idl5=0";
				seleccion_l5 = 0;
				totalE = true;
			}
			solototal = false;
			lbL5.Text = "L5=" + cbL5.Text;
			if (!valoresform)
				M_cargargrid(total);
		}
		private void cbL6_DropDown(object sender, EventArgs e)
		{
            #region combosText
            cbL6.Text = "";
            cbMarca.Text = "";
            #endregion
			#region reiniciar V

			subl6 = "";
			#endregion
			cbL6.Items.Clear();
			cbL6.Items.Add("Total");
			int i = 1;
			query = "SELECT descrip,idl6 from estl6 where visiblebp='1'" + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2 + " " + subl3 + " " + subl4 + " " + subl5;
			checaConexion();
			cmd = new MySqlCommand(query, Conn);
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
                if (i == 1)
                {
                    idl6varios = "and (e.idl6= " + reader["idl6"].ToString();
                }
                else
                {
                    idl6varios += " or e.idl6=" + reader["idl6"].ToString();
                }
				cbL6.Items.Add(reader["descrip"].ToString());
				idd[i] = reader["idl6"].ToString();
				i++;
			}
			reader.Close();
            idl6varios += ")";
			if (cbL6.Items.Count == 1)
			{
				cbL6.Items.Clear();
			}
		}
		private void cbL6_SelectedIndexChanged(object sender, EventArgs e)
		{
            posicionCombos = 11;
			pocision = 11;
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

				querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " and idl6="+idd[cbL6.SelectedIndex]+" and marca='-1'  ";
				idl6 = "and e.idl6=" + idd[cbL6.SelectedIndex];
				idl6varios = idl6;
				total = false;
				query = "SELECT descrip,idl6 from estl6 where visiblebp='1' and idl6=" + idd[cbL6.SelectedIndex];
				wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6varios;
				subl6 = "and idl6=" + idd[cbL6.SelectedIndex];
				queryguardar[0] =  s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + " " + l4 + " " + l5 + "," + idd[cbL6.SelectedIndex] + ",'-1'";
				l6 = ","+idd[cbL6.SelectedIndex];
				queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
				l6cargar = "and idl6="+idd[cbL6.SelectedIndex];
				totalE = false;
                groupby = "idl6";
                where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios+" "+idl6varios;
                whereLeft = idsucursalvarios;
			}
			else
			{
                groupby = "idl6";
                where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl6varios;
                whereLeft = idsucursalvarios;
				//idl6varios = " ";
				queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " "+l5cargar+" and idl6=-1";
				subl6 = " ";
				idl6 = " ";
				for (int i = 0; i <= cbL6.Items.Count - 1; i++)
				{
					querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " and idl6=" + idd[(i+1)] + " and marca='-1'  ";
					idl6 = "and V.idl6=" + idd[(i + 1)];
					wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6;
					queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + " " + l4 + " " + l5 + "," + idd[(i + 1)] + ",'-1'";
				}
				total = true;
				query = "SELECT descrip,idl6 from estl6 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2 + " " + subl3 + " " + subl4 + " " + subl5;
				l6 = ",0";
				l6cargar = "and idl6=0";
				seleccion_l6 = 0;
				totalE = true;
			}
			solototal = false;
			lbL6.Text = "L6=" + cbL6.Text;
			if (!valoresform)
				M_cargargrid(total);
		}
		private void cbMarca_DropDown(object sender, EventArgs e)
		{
            #region combosText
            cbMarca.Text = "";
            #endregion
			checaConexion();
            this.Invoke(new Action(() =>
               {
                   if (bandera_sucursal==false && cbDivisiones.Text == "" && cbDepto.Text == "" && cbFamilia.Text == "" && cbLinea.Text == "" && cbL1.Text == "" && cbL2.Text == "" && cbL3.Text == "" && cbL4.Text == "" && cbL5.Text == "" && cbL6.Text == "" && cbMarca.Text == "")
                   {
                       marcavarios = "";
                       cbMarca.Items.Clear();
                       cbMarca.Items.Add("Total");
                       int i = 1;
                       query = "SELECT distinct m.descrip,m.marca from marca as m inner join estarticulo as e on e.marca=m.marca where visiblebp=1 and e.iddivisiones=1";
                       cmd = new MySqlCommand(query, Conn);
                       reader = cmd.ExecuteReader();
                       while (reader.Read())
                       {
                           if (i == 1)
                           {
                               marcavarios = "and (e.marca= '" + reader["marca"].ToString()+"'";
                           }
                           else
                           {
                               marcavarios += " or e.marca='" + reader["marca"].ToString()+"'";
                           }
                           cbMarca.Items.Add(reader["descrip"].ToString());
                           idd[i] = reader["marca"].ToString();
                           i++;
                       }
                       reader.Close();
                       total = true;
                   }
                   if (bandera_l6 == true && bandera_l5 == true)
                   {
                       marcavarios = "";
                       cbMarca.Items.Clear();
                       cbMarca.Items.Add("Total");
                       int i = 1;
                       query = "SELECT distinct m.descrip,m.marca from marca as m inner join estarticulo as e on e.marca=m.marca where visiblebp=1 and " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6varios;
                       cmd = new MySqlCommand(query, Conn);
                       reader = cmd.ExecuteReader();
                       while (reader.Read())
                       {
                           if (i == 1)
                           {
                               marcavarios = "and (e.marca='" + reader["marca"].ToString()+"'";
                           }
                           else
                           {
                               marcavarios += " or e.marca='" + reader["marca"].ToString()+"'";
                           }
                           cbMarca.Items.Add(reader["descrip"].ToString());
                           idd[i] = reader["marca"].ToString();
                           i++;
                       }
                       reader.Close();
                       total = true;
                   }
                   if (bandera_sucursal == true && bandera_division == true && bandera_depto == true && bandera_familia == false)
                   {
                       marcavarios = "";
                       cbMarca.Items.Clear();
                       cbMarca.Items.Add("Total");
                       int i = 1;
                       query = "SELECT distinct m.descrip,m.marca from marca as m inner join estarticulo as e on e.marca=m.marca where visiblebp=1 and e.iddivisiones=1 " + iddeptovarios;
                       cmd = new MySqlCommand(query, Conn);
                       reader = cmd.ExecuteReader();
                       while (reader.Read())
                       {
                           if (i == 1)
                           {
                               marcavarios = "and (e.marca='" + reader["marca"].ToString()+"'";
                           }
                           else
                           {
                               marcavarios += " or e.marca='" + reader["marca"].ToString()+"'";
                           }
                           cbMarca.Items.Add(reader["descrip"].ToString());
                           idd[i] = reader["marca"].ToString();
                           i++;
                       }
                       reader.Close();
                       total = true;
                   }
                   if (bandera_sucursal == true && bandera_division == true && bandera_depto == true && bandera_familia == true && bandera_linea == true && bandera_l1 == true && bandera_l2 == false)
                   {
                       marcavarios = "";
                       cbMarca.Items.Clear();
                       cbMarca.Items.Add("Total");
                       int i = 1;
                       query = "SELECT distinct m.descrip,m.marca from marca as m inner join estarticulo as e on e.marca=m.marca where visiblebp=1 and " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios;
                       cmd = new MySqlCommand(query, Conn);
                       reader = cmd.ExecuteReader();
                       while (reader.Read())
                       {
                           if (i == 1)
                           {
                               marcavarios = "and (e.marca='" + reader["marca"].ToString()+"'";
                           }
                           else
                           {
                               marcavarios += " or e.marca='" + reader["marca"].ToString()+"'";
                           }
                           cbMarca.Items.Add(reader["descrip"].ToString());
                           idd[i] = reader["marca"].ToString();
                           i++;
                       }
                       reader.Close();
                       total = true;
                   }
               }));
            marcavarios += ")";

		}
		private void cbMarca_SelectedIndexChanged(object sender, EventArgs e)
		{
            posicionCombos = 12;
			pocision = 13;
			marca = ",-1";
			bandera_marca = true;
			seleccion_marca = cbMarca.SelectedText;
			if (cbMarca.Text == "Total")
			{
                seleccion_marca = "0";
				for (int i = 0; i <= cbMarca.Items.Count - 1; i++)
				{
					marca = " and V.marca='" + idd[(i + 1)] + "'";
					if (bandera_l6 == true && bandera_l5 == true)
					{
						wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6varios + " " + marca;
						queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + " " + l4 + " " + l5 + " " + l6 + ",'" + idd[(i + 1)] + "'";
						querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " " + l6cargar + " and marca='" + idd[(i + 1)] + "'  ";
						queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " " + l6cargar + " and marca='-1'";
						pocision = 16;
                        groupby = "marca";
                        where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl6varios+" "+marcavarios;
                        whereLeft = idsucursalvarios;
					}
				  
					if (bandera_sucursal == true && bandera_division == true && bandera_depto == true && bandera_familia == false)
					 {
						 wherequery[i] = idsucursalvarios+" "+iddeptovarios + " and iddivisiones=1 " + marca;
						 queryguardar[i] = s + " " + d + " " + dd + ",-1,-1,-1,-1,-1,-1,-1,-1,'" + idd[(i + 1)] + "'";

						 querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='" + idd[(i + 1)] + "'  ";
						 queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and iddepto=" + seleccion_depto.ToString() + " and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and idfamilia=-1 and marca='-1'";
						 pocision = 14;
                         groupby = "marca";
                         where = iddivisionesvarios + " " + iddeptovarios+" "+ marcavarios;
                         whereLeft = idsucursalvarios;
					 }
					if (cbSucursales.Text == "" && cbDivisiones.Text == "" && cbDepto.Text == "" && cbFamilia.Text == "" && cbLinea.Text == "" && cbL1.Text == "" && cbL2.Text == "" && cbL3.Text == "" && cbL4.Text == "" && cbL5.Text == "" && cbL6.Text == "" )
					{
						wherequery[i] = marca + " and iddivisiones=1";
						queryguardar[i] = ",-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,'" + idd[(i + 1)] + "'";
						querycargar[i] = "and idsucursal=-1 and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='" + idd[(i + 1)] + "'  ";
						queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
						query = "SELECT distinct m.descrip,m.marca from marca as m inner join estarticulo as V on V.marca=m.marca where visiblebp=1 and v.iddivisiones=1";
                        groupby = "marca";
                        where = "  e.iddivisiones=1 " + marcavarios;
                        whereLeft = "";
					}
					if (bandera_sucursal == true && bandera_division == true && bandera_depto == true && bandera_familia == true && bandera_linea==true && bandera_l1==true && bandera_l2==false)
					{
						wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + marca;
						queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + ",-1,-1,-1,-1,-1, '" + idd[(i + 1)] + "'";
						querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='" + idd[(i + 1)] + "'  ";
						queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar +" and idl2=-1 and marca='-1'";
					   // query = "SELECT distinct m.descrip,m.marca from marca as m inner join estarticulo as V on V.marca=m.marca where visiblebp=1 and v.iddivisiones=1";
						pocision = 15;
                        groupby = "marca";
                        where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + marcavarios;
                        whereLeft = idsucursalvarios;
					}
		   
				}
				total = true;
				seleccion_marca = "0";
				totalE = true;
			}
			else
			{
				totalE = false;
				seleccion_marca = "0";
				query = query + " and M.marca='" + idd[cbMarca.SelectedIndex] + "'";
				marca = " and e.marca='" + idd[cbMarca.SelectedIndex] + "'";
				wherequery[0] = idsucursalvarios + " " + idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6varios + " " + marca;
				total = false;
				queryguardar[0] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + " " + l4 + " " + l5 + " " + l6 + ",'" + idd[cbMarca.SelectedIndex] + "'";
				querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " " + l6cargar + " and marca='"+idd[cbMarca.SelectedIndex]+"'  ";
				queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                marcavarios = marca;
				if (bandera_l6 == true && bandera_l5 == true)
				{
					wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6varios + " " + marca;
					queryguardar[0] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + " " + l4 + " " + l5 + " " + l6 + ",'" + idd[cbMarca.SelectedIndex] + "'";
					querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " " + l6cargar + " and marca='" + idd[cbMarca.SelectedIndex] + "'  ";
					queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " " + l6cargar + " and marca='-1'";
                    groupby = "marca";
                    where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl6varios + " " + marcavarios;
                    whereLeft = idsucursalvarios;
				}
				if (bandera_sucursal == true && bandera_division == true && bandera_depto == true && bandera_linea == false)
				{
					wherequery[0] = idsucursalvarios + " " + iddeptovarios + " and iddivisiones=1 " + marca;
					queryguardar[0] = s + " " + d + " " + dd + ",-1,-1,-1,-1,-1,-1,-1,-1,'" + idd[cbMarca.SelectedIndex] + "'";

					querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='" + idd[cbMarca.SelectedIndex] + "'  ";
					queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and iddepto=" + seleccion_depto.ToString() + " and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and idfamilia=-1 and marca='-1'";
                    groupby = "marca";
                    where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + marcavarios;
                    whereLeft = idsucursalvarios;
				}
				if (cbSucursales.Text == "" && cbDivisiones.Text == "" && cbDepto.Text == "" && cbFamilia.Text == "" && cbLinea.Text == "" && cbL1.Text == "" && cbL2.Text == "" && cbL3.Text == "" && cbL4.Text == "" && cbL5.Text == "" && cbL6.Text == "")
				{
					wherequery[0] = marca + " and iddivisiones=1";
					queryguardar[0] = ",-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,'" + idd[cbMarca.SelectedIndex] + "'";
					querycargar[0] = "and idsucursal=-1 and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='" + idd[cbMarca.SelectedIndex] + "'  ";
					queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' "+querycargar[cbMarca.SelectedIndex];
					query = "SELECT distinct m.descrip,m.marca from marca as m inner join estarticulo as V on V.marca=m.marca where visiblebp=1 and v.iddivisiones=1 and m.marca='"+idd[cbMarca.SelectedIndex]+"'";
                    groupby = "marca";
                    where = "  e.iddivisiones=1 " +  marcavarios;
                    whereLeft = "";
				}
				if (bandera_sucursal == true && bandera_division == true && bandera_depto == true && bandera_familia == true && bandera_linea == true && bandera_l1 == true && bandera_l2 == false)
				{
					wherequery[0] = marca + " and iddivisiones=1";
					queryguardar[0] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + ",-1,-1,-1,-1,-1, '" + idd[cbMarca.SelectedIndex] + "'";
					querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='" + idd[cbMarca.SelectedIndex] + "'  ";
					queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1  " +querycargar[0];
					query = "SELECT distinct m.descrip,m.marca from marca as m inner join estarticulo as V on V.marca=m.marca where visiblebp=1 and v.iddivisiones=1 and m.marca='"+idd[cbMarca.SelectedIndex]+"'";
                    groupby = "marca";
                    where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + marcavarios;
                    whereLeft = idsucursalvarios;
				}
				
			}
			solototal = false;
			lbMarca.Text = "Marca=" + cbMarca.Text;
			if (!valoresform)
				M_cargargrid(total);
			//solototal = true;
		}
		#endregion
		public Cedula1()
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
		private void Cedula1_Load(object sender, EventArgs e)
		{
			Control.CheckForIllegalCrossThreadCalls = false;
			M_pintarcolumnas();
			#region inicializar tb
			tbinflacion.Text = "0";
			tbpp.Text = "0";
			tbR.Text = "0";
			tbvti.Text = "0";
			#endregion
			m_ESCENARIO(Properties.Settings.Default.escenario);
			lbppuH.Text = M_promediobruto(FechaAI, FechaAF).ToString("C2");
			lbppuP.Text = lbppuH.Text;
			#region @est@
			///////////////////////////////
			//@est@
			
			//if(seleccion_sucursal != -1)
			//{
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
			//}
				

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
			#region si hay valores cedula anterior PABLO
			if (valoresform == true)
			{
				//m_DIASMESESANOS(CED1_fechaI, CED1_fechaF);
				M_cargargrid(total);
				valoresform = false;
			}
			#endregion
			this.Refresh();
			#endregion
            string q = "Select nombre from cedula1 where nombre='"+Properties.Settings.Default.escenario+"' ";
            cmd = new MySqlCommand(q, Conn);
            reader = cmd.ExecuteReader();
            bool x = reader.HasRows;
            reader.Close();
            if(x==false)
            {
                toolStripMenuItem1.PerformClick();
                desbloquearComponentes();

            }
            else
            {
                desbloquearComponentes();
                bloquearComponentes();
            }
            
		}
		#region botones menu
		

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
			if (bandera_sucursal == true)
			{
				Cedula3 c3 = new Cedula3();
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
		private void m_ESCENARIO(string escenario)
		{
			DateTime a = DateTime.Now, f = DateTime.Now;
			string ESC = "SELECT  fechainicialA, fechafinalA,fechainicial,fechafinal,solocalzado FROM escenarios WHERE nombre = '" + escenario + "' LIMIT 1";
			checaConexion();
			cmd = new MySqlCommand(ESC, Conn);
			cmd.CommandTimeout = 0;//pos solucion
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				a = DateTime.Parse(reader["fechainicial"].ToString());
				f = DateTime.Parse(reader["fechafinal"].ToString());
				FechaAI = DateTime.Parse(reader["fechainicialA"].ToString());
				FechaAF = DateTime.Parse(reader["fechafinalA"].ToString());
				label9.Text = "Escenario: " + escenario;
				label10.Text = "Fecha inicial " + a.ToString("yyyy-MM-dd");
				label11.Text = "Fecha final  " + f.ToString("yyyy-MM-dd");
				if(reader["solocalzado"].ToString()=="True")
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
            //queryunidadesAsignadas = cadenaQuery();
			this.Invoke(new Action(() =>
			{
			checkBox1.Checked = true;
			checkBox1.Checked = false;
			limpiarcomponentes();
			dgvCed2.Rows.Clear();
			dgvCed2.Rows.Add();
			dgvCed2.Rows[0].Cells[0].Value="Total";
			dgvM.Rows.Clear();
			dgvM.Rows.Add();
				dgvM.Rows[0].Cells[0].Value="Total";
			}));
			int i = 1;
			if (solototal == false)
			{
				checaConexion();
				cmd = new MySqlCommand(query, Conn);
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
                    this.Invoke(new Action(() =>
				    {
					dgvCed2.Refresh();
					dgvCed2.Rows.Add();
					dgvCed2.Rows[i].Cells[0].Value = reader["descrip"].ToString();
					dgvM.Rows.Add();
					dgvM.Rows[i].Cells[0].Value = reader["descrip"].ToString();
                    }));
					i++;
				}
				reader.Close();
			}
            if (generando == true)
            {
                comprobarCedulas();
            }
            else
            {

                bgwNormal.RunWorkerAsync();
            }
		}
		private double M_promediobruto(DateTime f1, DateTime f2)
		{
			double p = 0.0;
			string q = "SELECT SUM(impllenoregsiva+impllenopromsiva+impllenonormalsiva+impllenodesctosiva)/SUM(ctdregalo+ctdprom+ctdnormal+ctddescto+ctdcan) AS prom FROM VENTASBASE AS V INNER JOIN SUCURSAL AS S ON V.IDSUCURSAL = S.IDSUCURSAL INNER JOIN FECHA AS F ON F.IDFECHA = V.IDFECHA WHERE   F.FECHA BETWEEN '" + f1.ToString("yyyy-MM-dd") + "' AND '" + f2.ToString("yyyy-MM-dd") + "' "+solocalzadowhere;
			checaConexion();
			cmd = new MySqlCommand(q, Conn);
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				if (reader["prom"].ToString() == "")
				{
					p = 0.0;
				}
				else
				{
					p = double.Parse(reader["prom"].ToString());
				}
			}
			reader.Close();
			return p;
		}
		public void m_preciopromedioXtasa()
		{
			double tasa = 0;
			this.Invoke(new Action(() =>
			{
            if (tbinflacion.Text == null || tbinflacion.Text == "")
			{
				tasa = 1;
			}
			else
			{
				tasa = double.Parse(tbinflacion.Text);
				tasa = (tasa / 100) + 1;
			}
			}));
			double p = 0;
			int x = 0;
			if(solototal==true)
			{
				x = 0;
			}
			else
			{
				x = 1;
			}
			this.Invoke(new Action(() =>
			{
			this.Refresh();

			}));
			for (; x <= dgvCed2.Rows.Count - 1; x++)
			{
				this.Invoke(new Action(() =>
				{
                p = double.Parse(dgvCed2.Rows[x].Cells[8].Value.ToString(), NumberStyles.Currency) * tasa;
					dgvCed2.Rows[x].Cells[4].Value = p.ToString("C2");
				}));
					
				
			}
			
		}
		private void M_pintarcolumnas()
		{
			dgvCed2.Columns[0].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#00CC66");
			dgvCed2.Columns[1].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3399FF");
			dgvCed2.Columns[2].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3399FF");
			dgvCed2.Columns[3].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3399FF");
			dgvCed2.Columns[4].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#3399FF");
			//------------------------------------------------------------------------------------------------
			dgvCed2.Columns[5].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#00CC66");
			dgvCed2.Columns[6].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#00CC66");
			dgvCed2.Columns[7].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#00CC66");
			dgvCed2.Columns[8].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#00CC66");
		}
		private void btnSimular_Click(object sender, EventArgs e)
		{
			double TasaInt = 0;
			Cursor.Current = Cursors.WaitCursor;
			double PVunit = 0;
			double nInv = 0;
			double RinvD = 0;
			double PrP = 0;
			double VTI = 0;
			double DI = 0;
			try
			{
				
				//---------------------------------------------//
				if (solototal == true )
				{
					if (tbinflacion.Text == null || tbinflacion.Text == "")
					{
						TasaInt = 1;
					}
					else
					{
						TasaInt = double.Parse(tbinflacion.Text);
                        if (TasaInt != 0)
                        {
                            TasaInt = (TasaInt / 100) + 1;
                        }
                        else { TasaInt = 1; }
					}
					PVunit = double.Parse(lbppuP.Text, NumberStyles.Currency);
					double precioH = double.Parse(lbppuH.Text,NumberStyles.Currency);
					if (PVunit == precioH)
					{
						PVunit = PVunit * TasaInt;
						lbppuH.Text = PVunit.ToString("C2");
					}
					#region casos de operaciones
					if (tbpM.Text != "0")
					{
						nInv = double.Parse(tbpM.Text, NumberStyles.Currency);
						RinvD = double.Parse(tbR.Text, NumberStyles.Currency);
						TimeSpan dias = FechaAF.Subtract(FechaAI);
						int meses = 1 + (-1 * (FechaAI.Month - FechaAF.Month) + 12 * (FechaAI.Year - FechaAF.Year));
                        if (nInv != 0 || RinvD != 0)
                        {
                            PrP = (nInv * RinvD);
                        }
                        else { PrP = 0; }
                        if (PrP != 0)
                        {
                            VTI = (double.Parse(lbppuH.Text, NumberStyles.Currency) * PrP);
                        }
                        else { VTI = 0; }
                        if (RinvD != 0)
                        {
                            DI = double.Parse(dias.Days.ToString()) / RinvD;
                        }
                        else { DI = 0; }
						tbvti.Text = VTI.ToString("C2");
						lbdi.Text = DI.ToString("n1");
						tbpp.Text = PrP.ToString("n0");
						///////////////////////////////////////////
						dgvCed2.Rows[0].Cells[1].Value = 100;
						dgvCed2.Rows[0].Cells[2].Value = PrP.ToString("n0");
						dgvCed2.Rows[0].Cells[3].Value = VTI.ToString("C2");
					}
					else
					{
						VTI = double.Parse(tbvti.Text, NumberStyles.Currency);
						TimeSpan dias = FechaAF.Subtract(FechaAI);
						double meses = (-1 * (FechaAI.Month - FechaAF.Month) + 12 * (FechaAI.Year - FechaAF.Year));
						RinvD = double.Parse(tbR.Text, NumberStyles.Currency);
                        if (VTI != 0 && RinvD!=0)
                        {
                            nInv = (VTI / double.Parse(lbppuH.Text, NumberStyles.Currency)) / RinvD;
                        }
                        else { nInv = 0; }
						PrP = nInv * RinvD;
                        if (RinvD != 0)
                        {
                            DI = double.Parse(dias.Days.ToString()) / RinvD;
                        }
                        else { DI = 0; }
						lbdi.Text = DI.ToString("n1");
						tbpp.Text = PrP.ToString("n0");
                        if (PrP != 0 && RinvD != 0)
                        {
                            tbpM.Text = (PrP / RinvD).ToString("n0");
                        }
                        else { tbpM.Text = "0"; }
						dgvCed2.Rows[0].Cells[1].Value = 100;
						dgvCed2.Rows[0].Cells[2].Value = PrP.ToString("n0");
						dgvCed2.Rows[0].Cells[3].Value = VTI.ToString("C2");
					}
					#endregion
					lbvtii.Text = VTI.ToString();
					lbPPaux.Text = tbpp.Text;
					m_preciopromedioXtasa();
					Cursor.Current = Cursors.Default;
					dgvCed2.Enabled = true;
                    
                    guardarP();
				}
                MessageBox.Show("Guardado");
			}
			catch (Exception f)
			{
				MessageBox.Show("Error " + f.ToString());
			}
		}
		private void btnGuardar_Click(object sender, EventArgs e)
		{
			double precioPH = 0, precioPP = 0, inventario = 0, rotacion = 0, diasinv = 0, VTI = 0, inflacion = 0;
			if (solototal == true)
			{
				#region solo total
				#region comprobar existente
				string q = "Select nombre from cedula1 where nombre='" + Properties.Settings.Default.escenario + "'  and ZapateriasTorreon=1";
				bool c = true;
				checaConexion();
				cmd = new MySqlCommand(q, Conn);
				reader = cmd.ExecuteReader();
				if (reader.HasRows == true)
				{
					c = true;
				}
				else
				{
					c = false;
				}
				reader.Close();
				#endregion
				if (c == true)
				{
					#region cedula1
					if (solototal == true)
					{
						precioPH = double.Parse(lbppuH.Text, NumberStyles.Currency);
						precioPP = double.Parse(lbppuP.Text, NumberStyles.Currency);
						inventario = double.Parse(tbpp.Text, NumberStyles.Currency);
						rotacion = double.Parse(tbR.Text, NumberStyles.Currency);
						diasinv = double.Parse(lbdi.Text, NumberStyles.Currency);
						VTI = double.Parse(tbvti.Text, NumberStyles.Currency);
						inflacion = double.Parse(tbinflacion.Text, NumberStyles.Currency);
						string u = "UPDATE cedula1 set preciopromedioUP=" + precioPP.ToString() + ",preciopromedioUH=" + precioPH.ToString() + ",Inventariodeseado=" + inventario.ToString() + ",rotacion=" + rotacion.ToString() + ",DiasInv=" + diasinv.ToString() + ",VTI=" + VTI.ToString() + ",Inflacion=" + inflacion + " where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1 ";
						checaConexion();
						cmd = new MySqlCommand(u, Conn);
						cmd.ExecuteNonQuery();
					}
					#endregion
				}
				else
				{
					#region guardarcedula1
					precioPH = double.Parse(lbppuH.Text, NumberStyles.Currency);
					precioPP = double.Parse(lbppuP.Text, NumberStyles.Currency);
					inventario = double.Parse(tbpp.Text, NumberStyles.Currency);
					rotacion = double.Parse(tbR.Text, NumberStyles.Currency);
					diasinv = double.Parse(lbdi.Text, NumberStyles.Currency);
					VTI = double.Parse(tbvti.Text, NumberStyles.Currency);
					inflacion = double.Parse(tbinflacion.Text, NumberStyles.Currency);
					query = "INSERT INTO  cedula1 (nombre,Inventariodeseado,rotacion,preciopromedioUP,preciopromedioUH,DiasInv,VTI,Inflacion,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,ZapateriasTorreon) VALUES('" + Properties.Settings.Default.escenario + "'," + inventario.ToString() + "," + rotacion.ToString() + "," + precioPP.ToString() + "," + precioPH.ToString() + "," + diasinv.ToString() + "," + VTI.ToString() + ", " + inflacion.ToString() + " ,0,0,0,0,0,0,0,0,0,0,0,'0',1);";
					checaConexion();
					cmd = new MySqlCommand(query, Conn);
					cmd.ExecuteNonQuery();
					#endregion
				}
				#region comprobar existente
				q = "Select nombre from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
				c = true;
				checaConexion();
				cmd = new MySqlCommand(q, Conn);
				reader = cmd.ExecuteReader();
				if (reader.HasRows)
				{
					c = true;
				}
				else
				{
					c = false;
				}
				reader.Close();
				#endregion
				if (c == true)
				{
					double c1, c2, c3, c4, c5, c6, c7, c8;
					c1 = double.Parse(dgvCed2.Rows[0].Cells[1].Value.ToString(), NumberStyles.Currency);
					c2 = double.Parse(dgvCed2.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency);
					c3 = double.Parse(dgvCed2.Rows[0].Cells[3].Value.ToString(), NumberStyles.Currency);
					c4 = double.Parse(dgvCed2.Rows[0].Cells[4].Value.ToString(), NumberStyles.Currency);
					c5 = double.Parse(dgvCed2.Rows[0].Cells[5].Value.ToString(), NumberStyles.Currency);
					c6 = double.Parse(dgvCed2.Rows[0].Cells[6].Value.ToString(), NumberStyles.Currency);
					c7 = double.Parse(dgvCed2.Rows[0].Cells[7].Value.ToString(), NumberStyles.Currency);
					c8 = double.Parse(dgvCed2.Rows[0].Cells[8].Value.ToString(), NumberStyles.Currency);
					string u = "update cedula2 set porsentajeP=" + c1.ToString() + ",asignacionUP=" + c2.ToString() + ",asignacioniP=" + c3.ToString() + ",precioPromedioP=" + c4.ToString() + ",porsentajeH=" + c5.ToString() + ",asignacionUH=" + c6.ToString() + ",asignacionIH=" + c7.ToString() + ",precioPromedioH=" + c8.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
					checaConexion();
					cmd = new MySqlCommand(u, Conn);
					cmd.ExecuteNonQuery();
				}
				else
				{
					#region guardar cedula2
					double c1, c2, c3, c4, c5, c6, c7, c8;
					c1 = double.Parse(dgvCed2.Rows[0].Cells[1].Value.ToString(), NumberStyles.Currency);
					c2 = double.Parse(dgvCed2.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency);
					c3 = double.Parse(dgvCed2.Rows[0].Cells[3].Value.ToString(), NumberStyles.Currency);
					c4 = double.Parse(dgvCed2.Rows[0].Cells[4].Value.ToString(), NumberStyles.Currency);
					c5 = double.Parse(dgvCed2.Rows[0].Cells[5].Value.ToString(), NumberStyles.Currency);
					c6 = double.Parse(dgvCed2.Rows[0].Cells[6].Value.ToString(), NumberStyles.Currency);
					c7 = double.Parse(dgvCed2.Rows[0].Cells[7].Value.ToString(), NumberStyles.Currency);
					c8 = double.Parse(dgvCed2.Rows[0].Cells[8].Value.ToString(), NumberStyles.Currency);
					query = "INSERT INTO cedula2 (nombre,porSentajeP,asignacionUP,asignacionIP,precioPromedioP,porsentajeH,asignacionUH,asignacionIH,precioPromedioH,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,ZapateriasTorreon) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + " ,0,0,0,0,0,0,0,0,0,0,0,'0',1 )";
					checaConexion();
					cmd = new MySqlCommand(query, Conn);
					cmd.ExecuteNonQuery();
					#endregion
				}
				MessageBox.Show("Guardado");
				#endregion
			}
			else
			{
				#region comprobar existente
				string q = "Select nombre from cedula1 where nombre='" + Properties.Settings.Default.escenario + "'  and idsucursal=0 and iddivisiones=0 and iddepto=0 and idfamilia=0 and idlinea=0 and idl1=0 and idl2=0 and idl3=0 and idl4=0 and idl5=0 and idl6=0 and marca='0'";
				bool c = true;
				checaConexion();
				cmd = new MySqlCommand(q, Conn);
				reader = cmd.ExecuteReader();
				if (reader.HasRows == true)
				{
					c = true;
				}
				else
				{
					c = false;
				}
				reader.Close();
				#endregion
				if (c == true)
				{
					#region cedula1
					if (solototal == true)
					{
						precioPH = double.Parse(lbppuH.Text, NumberStyles.Currency);
						precioPP = double.Parse(lbppuP.Text, NumberStyles.Currency);
						inventario = double.Parse(tbpp.Text, NumberStyles.Currency);
						rotacion = double.Parse(tbR.Text, NumberStyles.Currency);
						diasinv = double.Parse(lbdi.Text, NumberStyles.Currency);
						VTI = double.Parse(tbvti.Text, NumberStyles.Currency);
						inflacion = double.Parse(tbinflacion.Text, NumberStyles.Currency);
						string u = "UPDATE cedula1 set preciopromedioUP=" + precioPP.ToString() + ",preciopromedioUH=" + precioPH.ToString() + ",Inventariodeseado=" + inventario.ToString() + ",rotacion=" + rotacion.ToString() + ",DiasInv=" + diasinv.ToString() + ",VTI=" + VTI.ToString() + ",Inflacion=" + inflacion + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=0 and iddivisiones=0 and iddepto=0 and idfamilia=0 and idlinea=0 and idl1=0 and idl2=0 and idl3=0 and idl4=0 and idl5=0 and idl6=0 and marca='0'  ";
						checaConexion();
						cmd = new MySqlCommand(u, Conn);
						cmd.ExecuteNonQuery();
					}
					else
					{
						//double imp = double.Parse(dgvCed2.Rows[0].Cells[3].Value.ToString(),NumberStyles.Currency);
						//#region actualizar anterior
						//cmd = new MySqlCommand(actualizar_anteriorI+dgvCed2.Rows[0].Cells[2].Value.ToString()+" "+actualizar_anteriorV+" "+imp.ToString()+" "+actualizar_where, Conn);
						//cmd.ExecuteNonQuery();
						//#endregion
					}
					#endregion
				}
				else
				{
					#region guardarcedula1
					precioPH = double.Parse(lbppuH.Text, NumberStyles.Currency);
					precioPP = double.Parse(lbppuP.Text, NumberStyles.Currency);
					inventario = double.Parse(tbpp.Text, NumberStyles.Currency);
					rotacion = double.Parse(tbR.Text, NumberStyles.Currency);
					diasinv = double.Parse(lbdi.Text, NumberStyles.Currency);
					VTI = double.Parse(tbvti.Text, NumberStyles.Currency);
					inflacion = double.Parse(tbinflacion.Text, NumberStyles.Currency);
					query = "INSERT INTO  cedula1 (nombre,Inventariodeseado,rotacion,preciopromedioUP,preciopromedioUH,DiasInv,VTI,Inflacion,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) VALUES('" + Properties.Settings.Default.escenario + "'," + inventario.ToString() + "," + rotacion.ToString() + "," + precioPP.ToString() + "," + precioPH.ToString() + "," + diasinv.ToString() + "," + VTI.ToString() + ", " + inflacion.ToString() + " ,0,0,0,0,0,0,0,0,0,0,0,'0' );";
					checaConexion();
					cmd = new MySqlCommand(query, Conn);
					cmd.ExecuteNonQuery();
					#endregion
				}
				for (int i = 1; i <= dgvCed2.Rows.Count - 1; i++)
				{
					#region comprobar existente
					q = "Select nombre from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(i-1)];
					c = true;
					checaConexion();
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					if (reader.HasRows)
					{
						c = true;
					}
					else
					{
						c = false;
					}
					reader.Close();
					#endregion
					if (c == true)
					{
						double c1, c2, c3, c4, c5, c6, c7, c8;
						c1 = double.Parse(dgvCed2.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
						c2 = double.Parse(dgvCed2.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
						c3 = double.Parse(dgvCed2.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
						c4 = double.Parse(dgvCed2.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
						c5 = double.Parse(dgvCed2.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
						c6 = double.Parse(dgvCed2.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
						c7 = double.Parse(dgvCed2.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
						c8 = double.Parse(dgvCed2.Rows[i].Cells[8].Value.ToString(), NumberStyles.Currency);
						string u = "update cedula2 set porsentajeP=" + c1.ToString() + ",asignacionUP=" + c2.ToString() + ",asignacioniP=" + c3.ToString() + ",precioPromedioP=" + c4.ToString() + ",porsentajeH=" + c5.ToString() + ",asignacionUH=" + c6.ToString() + ",asignacionIH=" + c7.ToString() + ",precioPromedioH=" + c8.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(i-1)];
						checaConexion();
						cmd = new MySqlCommand(u, Conn);
						cmd.ExecuteNonQuery();
					}
					else
					{
						#region guardar cedula2
						double c1, c2, c3, c4, c5, c6, c7, c8;
						c1 = double.Parse(dgvCed2.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
						c2 = double.Parse(dgvCed2.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
						c3 = double.Parse(dgvCed2.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
						c4 = double.Parse(dgvCed2.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
						c5 = double.Parse(dgvCed2.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
						c6 = double.Parse(dgvCed2.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
						c7 = double.Parse(dgvCed2.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
						c8 = double.Parse(dgvCed2.Rows[i].Cells[8].Value.ToString(), NumberStyles.Currency);
						query = "INSERT INTO cedula2 (nombre,porSentajeP,asignacionUP,asignacionIP,precioPromedioP,porsentajeH,asignacionUH,asignacionIH,precioPromedioH,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + " " + queryguardar[(i-1)] + ")";
						checaConexion();
						cmd = new MySqlCommand(query, Conn);
						cmd.ExecuteNonQuery();
						#endregion
					}
				}
				MessageBox.Show("Guardado");
			}
		}
		private void btnNuevo_Click(object sender, EventArgs e)
		{
			cbSucursales.DroppedDown = true;
		}
		private void menuPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Opciones op = new Opciones();
			this.Hide();
			op.ShowDialog();
			this.Close();
		} //--menu principal
		private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Log_in l = new Log_in();
			this.Hide();
			l.ShowDialog();
			this.Close();
		} //-- cerrar session
		private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		} //-- cerrar
		private void limpiarcomponentes()
		{
			tbinflacion.Clear();
			tbpp.Clear();
			tbR.Clear();
			tbvti.Clear();
			tbpM.Text = "0";
			lbvtii.Text = "";
			lbdi.Text = " ";
			lbPPaux.Text = "";
			tbinflacion.Text = "0";
			tbpp.Text = "0";
			tbR.Text = "0";
			tbvti.Text = "0";
		}
		private void m_RenglonTotal()
		{
            this.Invoke(new Action(() =>
               {
                   dgvCed2.Rows[0].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7FE2E");
               }));
			double c1=0, c2=0, c3=0, c4=0, c5=0, c6=0, c7=0, c8=0;
			int ceros = 0;
			if (solototal == true)
			{

			}
			else
			{

                this.Invoke(new Action(() =>
                {

				for (int i = 1; i <= dgvCed2.Rows.Count - 1; i++)
				{
					if (dgvCed2.Rows[i].Cells[1].Value != null && dgvCed2.Rows[i].Cells[1].Value.ToString() != " ")
					{
						c1 += double.Parse(dgvCed2.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
					}
					else
					{
						c1 = c1 + 0;
					}
					if (dgvCed2.Rows[i].Cells[2].Value != null && dgvCed2.Rows[i].Cells[2].Value.ToString() != " ")
					{
						c2 += double.Parse(dgvCed2.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
					}
					else
					{
						c2 = c2 + 0;
					}
					if (dgvCed2.Rows[i].Cells[3].Value != null && dgvCed2.Rows[i].Cells[3].Value.ToString() != " ")
					{
						c3 += double.Parse(dgvCed2.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
					}
					else
					{
						c3 = c3 + 0;
					}
					if (dgvCed2.Rows[i].Cells[4].Value != null && dgvCed2.Rows[i].Cells[4].Value.ToString() != " ")
					{
						c4 += double.Parse(dgvCed2.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
						if(dgvCed2.Rows[i].Cells[4].Value.ToString()=="$0.00")
						{
							ceros++;
						}
					}
					else
					{
						c4 = c4 + 0;
						ceros++;
					}
					if (dgvCed2.Rows[i].Cells[5].Value != null && dgvCed2.Rows[i].Cells[5].Value.ToString() != " ")
					{
						c5 += double.Parse(dgvCed2.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
					}
					else
					{
						c5 = c5 + 0;
					}
					if (dgvCed2.Rows[i].Cells[6].Value != null && dgvCed2.Rows[i].Cells[6].Value.ToString() != " ")
					{
						c6 += double.Parse(dgvCed2.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
					}
					else
					{
						c6 = c6 + 0;
					}
					if (dgvCed2.Rows[i].Cells[7].Value != null && dgvCed2.Rows[i].Cells[7].Value.ToString() != " ")
					{
						c7 += double.Parse(dgvCed2.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
					}
					else
					{
						c7 = c7 + 0;
					}
                    if (dgvCed2.Rows[i].Cells[8].Value != null && dgvCed2.Rows[i].Cells[8].Value.ToString() != "")
					{
						c8 += double.Parse(dgvCed2.Rows[i].Cells[8].Value.ToString(), NumberStyles.Currency);
					}
					else
					{
						c8 = c8 + 0;
					}
					dgvCed2.Rows[0].Cells[1].Value = c1.ToString();
					dgvCed2.Rows[0].Cells[2].Value = c2.ToString();
					dgvCed2.Rows[0].Cells[3].Value = c3.ToString("C2");
					dgvCed2.Rows[0].Cells[5].Value = c5.ToString();
					dgvCed2.Rows[0].Cells[6].Value = c6.ToString();
					dgvCed2.Rows[0].Cells[7].Value = c7.ToString("C2");
					dgvCed2.Refresh();
				}
				int dividir = (dgvCed2.Rows.Count - 1) - ceros;
				if (dividir >= 1)
				{
					dgvCed2.Rows[0].Cells[4].Value = (c4 / dividir).ToString("C2");
					dgvCed2.Rows[0].Cells[8].Value = (c8 / dividir).ToString("C2");
				}
				else
				{
					dgvCed2.Rows[0].Cells[4].Value = "0";
					dgvCed2.Rows[0].Cells[8].Value = "0";
				}
                }));

			}

		}
		 public Cedula1(bool band_sucursal, int selecc_sucursal, bool band_division, int selecc_division, bool band_depto, int selecc_depto, bool band_familia, int selecc_familia,bool band_linea, int selecc_linea, bool band_l1, int selecc_l1,bool band_l2, int selecc_l2, bool band_l3, int selecc_l3,bool band_l4, int selecc_l4, bool band_l5, int selecc_l5,bool band_l6, int selecc_l6, bool band_marca, string selecc_marca)
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

		 public Cedula1(int selecc_sucursal, int selecc_division, int selecc_depto, int selecc_familia, int selecc_linea, int selecc_l1, int selecc_l2, int selecc_l3, int selecc_l4, int selecc_l5, int selecc_l6, string selecc_marca)
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
         //private void m_drop_sucursales()
         //{
         //    #region reiniciar valores
         //    lbsucursal.Text = "Sucursal";
         //    lbDivision.Text = "Division";
         //    lbdepartamento.Text = "Departamento";
         //    lbfamilia.Text = "Familia";
         //    lblinea.Text = "Linea";
         //    lbl1.Text = "L1";
         //    lbL2.Text = "L2";
         //    lbL3.Text = "L3";
         //    lbL4.Text = "L4";
         //    lbL5.Text = "L5";
         //    lbL6.Text = "L6";
         //    lbMarca.Text = "Marca";
         //    idsucursal = " ";
         //    idsucursal = " ";
         //    iddivision = " ";
         //    iddepto = " ";
         //    idfamilia = " ";
         //    idlinea = " ";
         //    idl1 = " ";
         //    idl2 = " ";
         //    idl3 = " ";
         //    idl4 = " ";
         //    idl5 = " ";
         //    idl6 = " ";
         //    marca = " ";
         //    #endregion
         //    ////@est@
         //    int sucS = -1;

         //    cbSucursales.Items.Clear();
         //    cbSucursales.Items.Add("Total");
         //    int i = 1;
         //    query = "SELECT descrip,idsucursal from sucursal where visible='S'";
         //    cmd = new MySqlCommand(query, Conn);
         //    reader = cmd.ExecuteReader();
         //    while (reader.Read())
         //    {
         //        cbSucursales.Items.Add(reader["descrip"].ToString());
         //        idd[i] = reader["idsucursal"].ToString();

         //        ////@est@
         //        if (seleccion_sucursal == Convert.ToInt32(reader["idsucursal"]))
         //            sucS = i;

         //        i++;
         //    }
         //    reader.Close();
         //    /////////////////////////////////////////////////////////////////
         //    ////@est@

         //    if (i == 1)
         //        cbSucursales.Items.Clear();
         //    else
         //    {
         //        if (sucS != -1)
         //        {
         //            cbSucursales.SelectedIndex = sucS;

         //        }
         //        else
         //            cbSucursales.SelectedIndex = 0;

         //    }
         //    /////////////////////////////////////////////////////////////////

         //}
         //private void m_drop_division()
         //{
         //    ////@est@
         //    int divS = -1;

         //    int i = 1;

         //    cbDivisiones.Items.Clear();
         //    cbDivisiones.Items.Add("Total");
         //    //@est@
         //    /*if (solocalzadoDropdown == " and iddivisiones=1")
         //    {
         //        i = 0;
         //    }
         //    else
         //    {
         //        i = 1;
         //        cbDivisiones.Items.Add("Total");
         //    }*/
         //    query = "SELECT descrip,iddivisiones from estdivisiones where visiblebp='1' " + solocalzadoDropdown;
         //    cmd = new MySqlCommand(query, Conn);
         //    reader = cmd.ExecuteReader();
         //    while (reader.Read())
         //    {
         //        cbDivisiones.Items.Add(reader["descrip"].ToString());
         //        idd[i] = reader["iddivisiones"].ToString();

         //        ////@est@
         //        if (seleccion_division == Convert.ToInt32(reader["iddivisiones"]))
         //            divS = i;

         //        i++;
         //    }
         //    reader.Close();
         //    /////////////////////////////////////////////////////////////////
         //    ////@est@

         //    if (i == 1)
         //        cbDivisiones.Items.Clear();
         //    else
         //    {
         //        if (divS != -1)
         //        {
         //            cbDivisiones.SelectedIndex = divS;

         //        }
         //        else
         //            cbDivisiones.SelectedIndex = 0;

         //    }
         //    /////////////////////////////////////////////////////////////////
         //}
         //private void m_drop_depto()
         //{
         //    ////@est@
         //    int depS = -1;

         //    cbDepto.Items.Clear();
         //    cbDepto.Items.Add("Total");
         //    string[] texto = iddivision.Split('.');
         //    int i = 1;

         //    query = "SELECT descrip,iddepto from estdepartamento where visiblebp='1' " + division + "";
         //    cmd = new MySqlCommand(query, Conn);
         //    reader = cmd.ExecuteReader();
         //    while (reader.Read())
         //    {
         //        cbDepto.Items.Add(reader["descrip"].ToString());
         //        idd[i] = reader["iddepto"].ToString();

         //        ////@est@
         //        if (seleccion_depto == Convert.ToInt32(reader["iddepto"]))
         //            depS = i;

         //        i++;
         //    }
         //    reader.Close();
         //    /////////////////////////////////////////////////////////////////
         //    ////@est@

         //    if (i == 1)
         //        cbDepto.Items.Clear();
         //    else
         //    {
         //        if (depS != -1)
         //        {
         //            cbDepto.SelectedIndex = depS;

         //        }
         //        else
         //            cbDepto.SelectedIndex = 0;

         //    }
         //    /////////////////////////////////////////////////////////////////

         //}
         //private void m_drop_familia()
         //{
         //    ////@est@
         //    int famS = -1;

         //    cbFamilia.Items.Clear();
         //    cbFamilia.Items.Add("Total");
         //    int i = 1;

         //    query = "SELECT descrip,idfamilia from estfamilia where visiblebp='1' " + division + " " + depto + "";
         //    cmd = new MySqlCommand(query, Conn);
         //    reader = cmd.ExecuteReader();
         //    while (reader.Read())
         //    {
         //        cbFamilia.Items.Add(reader["descrip"].ToString());
         //        idd[i] = reader["idfamilia"].ToString();

         //        ////@est@
         //        if (seleccion_familia == Convert.ToInt32(reader["idfamilia"]))
         //            famS = i;

         //        i++;
         //    }
         //    reader.Close();
         //    /////////////////////////////////////////////////////////////////
         //    ////@est@

         //    if (i == 1)
         //        cbFamilia.Items.Clear();
         //    else
         //    {
         //        if (famS != -1)
         //        {
         //            cbFamilia.SelectedIndex = famS;

         //        }
         //        else
         //            cbFamilia.SelectedIndex = 0;

         //    }
         //    /////////////////////////////////////////////////////////////////

         //}
         //private void m_drop_linea()
         //{
         //    ////@est@
         //    int linS = -1;

         //    cbLinea.Items.Clear();
         //    cbLinea.Items.Add("Total");
         //    int i = 1;

         //    query = "SELECT descrip,idlinea from estlinea where visiblebp='1' " + division + " " + depto + "" + " " + fam;
         //    cmd = new MySqlCommand(query, Conn);
         //    reader = cmd.ExecuteReader();
         //    while (reader.Read())
         //    {
         //        cbLinea.Items.Add(reader["descrip"].ToString());
         //        idd[i] = reader["idlinea"].ToString();

         //        ////@est@
         //        if (seleccion_linea == Convert.ToInt32(reader["idlinea"]))
         //            linS = i;

         //        i++;
         //    }
         //    reader.Close();
         //    /////////////////////////////////////////////////////////////////
         //    ////@est@

         //    if (i == 1)
         //        cbLinea.Items.Clear();
         //    else
         //    {
         //        if (linS != -1)
         //        {
         //            cbLinea.SelectedIndex = linS;

         //        }
         //        else
         //            cbLinea.SelectedIndex = 0;

         //    }
         //    /////////////////////////////////////////////////////////////////

         //}
         //private void m_drop_l1()
         //{
         //    ////@est@
         //    int l1S = -1;

         //    cbL1.Items.Clear();
         //    cbL1.Items.Add("Total");
         //    int i = 1;

         //    query = "SELECT descrip,idl1 from estl1 where visiblebp='1'" + division + " " + depto + " " + fam + " " + linea;
         //    cmd = new MySqlCommand(query, Conn);
         //    reader = cmd.ExecuteReader();
         //    while (reader.Read())
         //    {
         //        cbL1.Items.Add(reader["descrip"].ToString());
         //        idd[i] = reader["idl1"].ToString();

         //        ////@est@
         //        if (seleccion_l1 == Convert.ToInt32(reader["idl1"]))
         //            l1S = i;

         //        i++;
         //    }
         //    reader.Close();
         //    /////////////////////////////////////////////////////////////////
         //    ////@est@

         //    if (i == 1)
         //        cbL1.Items.Clear();
         //    else
         //    {
         //        if (l1S != -1)
         //        {
         //            cbL1.SelectedIndex = l1S;

         //        }
         //        else
         //            cbL1.SelectedIndex = 0;

         //    }
         //    /////////////////////////////////////////////////////////////////
         //}
         //private void m_drop_l2()
         //{
         //    ////@est@
         //    int l2S = -1;
         //    cbL2.Items.Clear();
         //    cbL2.Items.Add("Total");
         //    int i = 1;

         //    query = "SELECT descrip,idl2 from estl2 where visiblebp='1' " + division + " " + depto + " " + fam + " " + linea + " " + subl1;
         //    cmd = new MySqlCommand(query, Conn);
         //    reader = cmd.ExecuteReader();
         //    while (reader.Read())
         //    {
         //        cbL2.Items.Add(reader["descrip"].ToString());
         //        idd[i] = reader["idl2"].ToString();
         //        ////@est@
         //        if (seleccion_l2 == Convert.ToInt32(reader["idl2"]))
         //            l2S = i;
         //        i++;
         //    }
         //    reader.Close();
         //    /////////////////////////////////////////////////////////////////
         //    ////@est@

         //    if (i == 1)
         //        cbL2.Items.Clear();
         //    else
         //    {
         //        if (l2S != -1)
         //        {
         //            cbL2.SelectedIndex = l2S;

         //        }
         //        else
         //            cbL2.SelectedIndex = 0;

         //    }
         //    /////////////////////////////////////////////////////////////////
         //}
         //private void m_drop_l3()
         //{
         //    ////@est@
         //    int l3S = -1;

         //    cbL3.Items.Clear();
         //    cbL3.Items.Add("Total");
         //    int i = 1;

         //    query = "SELECT descrip,idl3 from estl3 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2;
         //    cmd = new MySqlCommand(query, Conn);
         //    reader = cmd.ExecuteReader();
         //    while (reader.Read())
         //    {
         //        cbL3.Items.Add(reader["descrip"].ToString());
         //        idd[i] = reader["idl3"].ToString();
         //        ////@est@
         //        if (seleccion_l3 == Convert.ToInt32(reader["idl3"]))
         //            l3S = i;
         //        i++;
         //    }
         //    reader.Close();
         //    /////////////////////////////////////////////////////////////////
         //    ////@est@

         //    if (i == 1)
         //        cbL3.Items.Clear();
         //    else
         //    {
         //        if (l3S != -1)
         //        {
         //            cbL3.SelectedIndex = l3S;

         //        }
         //        else
         //            cbL3.SelectedIndex = 0;

         //    }
         //    /////////////////////////////////////////////////////////////////
         //}
         //private void m_drop_l4()
         //{
         //    ////@est@
         //    int l4S = -1;

         //    cbL4.Items.Clear();
         //    cbL4.Items.Add("Total");
         //    int i = 1;

         //    query = "SELECT descrip,idl4 from estl4 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2 + " " + subl3;
         //    cmd = new MySqlCommand(query, Conn);
         //    reader = cmd.ExecuteReader();
         //    while (reader.Read())
         //    {
         //        cbL4.Items.Add(reader["descrip"].ToString());
         //        idd[i] = reader["idl4"].ToString();
         //        ////@est@
         //        if (seleccion_l4 == Convert.ToInt32(reader["idl4"]))
         //            l4S = i;
         //        i++;
         //    }
         //    reader.Close();
         //    /////////////////////////////////////////////////////////////////
         //    ////@est@

         //    if (i == 1)
         //        cbL4.Items.Clear();
         //    else
         //    {
         //        if (l4S != -1)
         //        {
         //            cbL4.SelectedIndex = l4S;

         //        }
         //        else
         //            cbL4.SelectedIndex = 0;

         //    }
         //    /////////////////////////////////////////////////////////////////
         //}
         //private void m_drop_l5()
         //{
         //    ////@est@
         //    int l5S = -1;

         //    cbL5.Items.Clear();
         //    cbL5.Items.Add("Total");
         //    int i = 1;

         //    query = "SELECT descrip,idl5 from estl5 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2 + " " + subl3 + " " + subl4;
         //    cmd = new MySqlCommand(query, Conn);
         //    reader = cmd.ExecuteReader();
         //    while (reader.Read())
         //    {
         //        cbL5.Items.Add(reader["descrip"].ToString());
         //        idd[i] = reader["idl5"].ToString();
         //        ////@est@
         //        if (seleccion_l5 == Convert.ToInt32(reader["idl5"]))
         //            l5S = i;
         //        i++;
         //    }
         //    reader.Close();
         //    /////////////////////////////////////////////////////////////////
         //    ////@est@

         //    if (i == 1)
         //        cbL5.Items.Clear();
         //    else
         //    {
         //        if (l5S != -1)
         //        {
         //            cbL5.SelectedIndex = l5S;

         //        }
         //        else
         //            cbL5.SelectedIndex = 0;

         //    }
         //    /////////////////////////////////////////////////////////////////
         //}
         //private void m_drop_l6()
         //{
         //    ////@est@
         //    int l6S = -1;

         //    cbL6.Items.Clear();
         //    cbL6.Items.Add("Total");
         //    int i = 1;

         //    query = "SELECT descrip,idl6 from estl6 where visiblebp='1'" + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2 + " " + subl3 + " " + subl4 + " " + subl5;
         //    cmd = new MySqlCommand(query, Conn);
         //    reader = cmd.ExecuteReader();
         //    while (reader.Read())
         //    {
         //        cbL6.Items.Add(reader["descrip"].ToString());
         //        idd[i] = reader["idl6"].ToString();
         //        ////@est@
         //        if (seleccion_l6 == Convert.ToInt32(reader["idl6"]))
         //            l6S = i;
         //        i++;
         //    }
         //    reader.Close();
         //    /////////////////////////////////////////////////////////////////
         //    ////@est@

         //    if (i == 1)
         //        cbL6.Items.Clear();
         //    else
         //    {
         //        if (l6S != -1)
         //        {
         //            cbL6.SelectedIndex = l6S;

         //        }
         //        else
         //            cbL6.SelectedIndex = 0;

         //    }
         //    /////////////////////////////////////////////////////////////////
         //}
         //private void m_drop_marca()
         //{
         //    ////@est@
         //    int marcaS = -1;

         //    cbMarca.Items.Clear();
         //    cbMarca.Items.Add("Total");
         //    int i = 1;

         //    //query = "SELECT descrip,marca from marca where visiblebp=1";
         //    query = "SELECT distinct m.descrip,m.marca from marca as m inner join estarticulo as v on v.marca = m.marca where visiblebp =1 " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6varios;
         //    cmd = new MySqlCommand(query, Conn);
         //    reader = cmd.ExecuteReader();
         //    while (reader.Read())
         //    {
         //        cbMarca.Items.Add(reader["descrip"].ToString());
         //        idd[i] = reader["marca"].ToString();
         //        ////@est@
         //        if (seleccion_marca == reader["marca"].ToString())
         //            marcaS = i;

         //        i++;
         //    }
         //    reader.Close();
         //    /////////////////////////////////////////////////////////////////
         //    ////@est@

         //    if (i == 1)
         //        cbMarca.Items.Clear();
         //    else
         //    {
         //        if (marcaS != -1)
         //        {
         //            cbMarca.SelectedIndex = marcaS;

         //        }
         //        else
         //            cbMarca.SelectedIndex = 0;

         //    }
         //    /////////////////////////////////////////////////////////////////

         //}
		 #endregion
         #region metodos Drop
         private void m_drop_depto()
         {
             ////@est@
             int depS = -1;

             cbDepto.Items.Clear();
             cbDepto.Items.Add("Total");
             string[] texto = iddivision.Split('.');
             int i = 1;
             query = "SELECT descrip,iddepto from estdepartamento where visiblebp='1' and iddivisiones=1";
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

                 ////@est@
                 if (seleccion_depto == Convert.ToInt32(reader["iddepto"]))
                     depS = i;

                 i++;
             }
             reader.Close();
             iddeptovarios += ")";
             cbDepto.SelectedIndex = depS;
             cbDepto_index();
         }

         private void m_drop_division()
         {
             ////@est@
             int divS = -1;

             int i = 1;

             cbDivisiones.Items.Clear();
             cbDivisiones.Items.Add("Total");

             query = "SELECT descrip,iddivisiones from estdivisiones where visiblebp='1' and iddivisiones=1";
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
             cbDivisiones.SelectedIndex = divS;
             cbDivision_index();
         }

         private void m_drop_familia()
         {
             ////@est@
             int famS = -1;

             cbFamilia.Items.Clear();
             cbFamilia.Items.Add("Total");
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
             if (bandera_sucursal == false && bandera_division == false && bandera_depto == false)
             {
                 cbFamilia.Items.Clear();
                 cbFamilia.Items.Add("Total");
                 int i = 1;
                 query = "SELECT descrip,idfamilia from estfamilia where visiblebp='1'  and iddivisiones=1";
                 cmd = new MySqlCommand(query, Conn);
                 reader = cmd.ExecuteReader();
                 while (reader.Read())
                 {

                     cbFamilia.Items.Add(reader["descrip"].ToString());
                     idd[i] = reader["idfamilia"].ToString();
                     if (seleccion_familia == Convert.ToInt32(reader["idfamilia"]))
                     { famS = i; }

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
                     if (seleccion_familia == Convert.ToInt32(reader["idfamilia"]))
                     { famS = i; }
                     i++;
                 }
                 reader.Close();
                 idfamiliavarios += ")";
             }
             cbFamilia.SelectedIndex = famS;
             cbFamilia_index();
         }

         private void m_drop_l1()
         {
             int l1S = -1;
             #region reiniciar V

             subl1 = "";
             subl2 = "";
             subl3 = "";
             subl4 = "";
             subl5 = "";
             subl6 = "";
             #endregion
             if (bandera_sucursal == false && bandera_division == false && bandera_depto == false && bandera_familia == false && bandera_linea == false)
             {
                 cbL1.Items.Clear();
                 cbL1.Items.Add("Total");
                 int i = 1;

                 query = "SELECT descrip,idl1 from estl1 where visiblebp='1' and iddivisiones=1";
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
                     if (seleccion_l1 == Convert.ToInt32(reader["idl1"]))
                     { l1S = i; }
                     i++;
                 }
                 idl1varios += ")";
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
                     if (seleccion_l1 == Convert.ToInt32(reader["idl1"]))
                     { l1S = i; }
                     i++;
                 }
                 idl1varios += ")";
                 reader.Close();
             }
             cbL1.SelectedIndex = l1S;
             if (cbL1.Items.Count == 1)
             {
                 cbL1.Items.Clear();
             }
             cbL1_index();
         }

         private void m_drop_l2()
         {
             ////@est@
             int l2S = -1;
             int i = 1;
             query = "SELECT descrip,idl2 from estl2 where visiblebp='1' " + division + " " + depto + " " + fam + " " + linea + " " + subl1;
             cmd = new MySqlCommand(query, Conn);
             reader = cmd.ExecuteReader();
             while (reader.Read())
             {
                 if (i == 1)
                 {
                     idl2varios = "and (e.idl2= " + reader["idl2"].ToString();
                 }
                 else
                 {
                     idl2varios += " or e.idl2=" + reader["idl2"].ToString();
                 }
                 cbL2.Items.Add(reader["descrip"].ToString());
                 idd[i] = reader["idl2"].ToString();
                 if (seleccion_l2 == Convert.ToInt32(reader["idl2"]))
                 { l2S = i; }
                 i++;
             }
             idl2varios += ")";
             reader.Close();
             cbL2.SelectedIndex = l2S;
             if (cbL2.Items.Count == 1)
             {
                 cbL2.Items.Clear();
             }
             cbL2_index();
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
                 if (i == 1)
                 {
                     idl3varios = "and (e.idl3= " + reader["idl3"].ToString();
                 }
                 else
                 {
                     idl3varios += " or e.idl3=" + reader["idl3"].ToString();
                 }
                 cbL3.Items.Add(reader["descrip"].ToString());
                 idd[i] = reader["idl3"].ToString();
                 if (seleccion_l3 == Convert.ToInt32(reader["idl3"]))
                 { l3S = i; }
                 i++;
             }
             idl3varios += ")";
             reader.Close();
             cbL3.SelectedIndex = l3S;
             if (cbL3.Items.Count == 1)
             {
                 cbL3.Items.Clear();
             }
             cbL3_index();
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
                 if (i == 1)
                 {
                     idl4varios = "and (e.idl4= " + reader["idl4"].ToString();
                 }
                 else
                 {
                     idl4varios += " or e.idl4=" + reader["idl4"].ToString();
                 }
                 cbL4.Items.Add(reader["descrip"].ToString());
                 idd[i] = reader["idl4"].ToString();
                 if (seleccion_l4 == Convert.ToInt32(reader["idl4"]))
                 { l4S = i; }
                 i++;
             }
             reader.Close();
             idl4varios += ")";
             cbL4.SelectedIndex = l4S;
             if (cbL4.Items.Count == 1)
             {
                 cbL4.Items.Clear();
             }
             cbL4_index();
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
                 if (i == 1)
                 {
                     idl5varios = "and (e.idl5= " + reader["idl5"].ToString();
                 }
                 else
                 {
                     idl5varios += " or e.idl5=" + reader["idl5"].ToString();
                 }
                 cbL5.Items.Add(reader["descrip"].ToString());
                 idd[i] = reader["idl5"].ToString();
                 if (seleccion_l5 == Convert.ToInt32(reader["idl5"]))
                 { l5S = i; }
                 i++;
             }
             idl5varios += ")";
             reader.Close();
             cbL5.SelectedIndex = l5S;
             if (cbL5.Items.Count == 1)
             {
                 cbL5.Items.Clear();
             }
             cbL5_index();
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
                 if (i == 1)
                 {
                     idl6varios = "and (e.idl6= " + reader["idl6"].ToString();
                 }
                 else
                 {
                     idl6varios += " or e.idl6=" + reader["idl6"].ToString();
                 }
                 cbL6.Items.Add(reader["descrip"].ToString());
                 if (seleccion_l6 == Convert.ToInt32(reader["idl6"]))
                 { l6S = i; }
                 idd[i] = reader["idl6"].ToString();
                 i++;
             }

             reader.Close();
             idl6varios += ")";
             cbL6.SelectedIndex = l6S;
             if (cbL6.Items.Count == 1)
             {
                 cbL6.Items.Clear();
             }
             cbL6_index();
         }

         private void m_drop_linea()
         {
             ////@est@
             int linS = -1;
             #region reiniciar V
             linea = "";
             subl1 = "";
             subl2 = "";
             subl3 = "";
             subl4 = "";
             subl5 = "";
             subl6 = "";
             #endregion
             if (bandera_sucursal == false && bandera_division == false && bandera_depto == false && bandera_familia == false)
             {
                 cbLinea.Items.Clear();
                 cbLinea.Items.Add("Total");
                 int i = 1;

                 query = "SELECT descrip,idlinea from estlinea where visiblebp='1' and iddivisiones=1";
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
                     if (seleccion_linea == Convert.ToInt32(reader["idlinea"]))
                     { linS = i; }
                     i++;
                 }
                 reader.Close();
                 idlineavarios += ")";
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
                     if (seleccion_linea == Convert.ToInt32(reader["idlinea"]))
                     { linS = i; }
                     i++;
                 }
                 reader.Close();
                 idlineavarios += ")";
             }

             cbLinea.SelectedIndex = linS;
             cbLinea_index();
         }

         private void m_drop_marca()
         {
             ////@est@
             int marcaS = -1;
             if (bandera_sucursal == false && bandera_division == false && bandera_depto == false && bandera_familia == false && bandera_linea == false && bandera_l1 == false && bandera_l2 == false && bandera_l3 == false && bandera_l4 == false && bandera_l5 == false && bandera_l6 == false && bandera_marca == false)
             {
                 cbMarca.Items.Clear();
                 cbMarca.Items.Add("Total");
                 int i = 1;
                 query = "SELECT distinct m.descrip,m.marca from marca as m inner join estarticulo as e on e.marca=m.marca where visiblebp=1 and e.iddivisiones=1";
                 cmd = new MySqlCommand(query, Conn);
                 reader = cmd.ExecuteReader();
                 while (reader.Read())
                 {
                     if (i == 1)
                     {
                         marcavarios = "and (e.marca= '" + reader["marca"].ToString() + "'";
                     }
                     else
                     {
                         marcavarios += " or e.marca='" + reader["marca"].ToString() + "'";
                     }
                     cbMarca.Items.Add(reader["descrip"].ToString());
                     idd[i] = reader["marca"].ToString();
                     if (seleccion_marca == reader["marca"].ToString())
                     { marcaS = i; }
                     i++;
                 }
                 reader.Close();
                 total = true;
             }
             if (bandera_l5 == true && bandera_l6 == true)
             {
                 cbMarca.Items.Clear();
                 cbMarca.Items.Add("Total");
                 int i = 1;
                 query = "SELECT distinct m.descrip,m.marca from marca as m inner join estarticulo as e on e.marca=m.marca where visiblebp=1 and e.iddivisiones=1 " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6varios;
                 cmd = new MySqlCommand(query, Conn);
                 reader = cmd.ExecuteReader();
                 while (reader.Read())
                 {
                     if (i == 1)
                     {
                         marcavarios = "and (e.marca='" + reader["marca"].ToString() + "'";
                     }
                     else
                     {
                         marcavarios += " or e.marca='" + reader["marca"].ToString() + "'";
                     }
                     cbMarca.Items.Add(reader["descrip"].ToString());
                     idd[i] = reader["marca"].ToString();
                     if (seleccion_marca == reader["marca"].ToString())
                     { marcaS = i; }
                     i++;
                 }
                 reader.Close();
                 total = true;
             }
             if (bandera_sucursal == true && bandera_division == true && bandera_depto == true && bandera_linea == false)
             {
                 cbMarca.Items.Clear();
                 cbMarca.Items.Add("Total");
                 int i = 1;
                 query = "SELECT distinct m.descrip,m.marca from marca as m inner join estarticulo as e on e.marca=m.marca where visiblebp=1 and e.iddivisiones=1" + iddeptovarios;
                 cmd = new MySqlCommand(query, Conn);
                 reader = cmd.ExecuteReader();
                 while (reader.Read())
                 {
                     if (i == 1)
                     {
                         marcavarios = "and (e.marca='" + reader["marca"].ToString() + "'";
                     }
                     else
                     {
                         marcavarios += " or e.marca='" + reader["marca"].ToString() + "'";
                     }
                     cbMarca.Items.Add(reader["descrip"].ToString());
                     idd[i] = reader["marca"].ToString();
                     if (seleccion_marca == reader["marca"].ToString())
                     { marcaS = i; }
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
                 query = "SELECT distinct v.descrip,v.marca from marca as v inner join estarticulo as e on v.marca=e.marca where visiblebp=1 and e.iddivisiones=1 " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios;
                 cmd = new MySqlCommand(query, Conn);
                 reader = cmd.ExecuteReader();
                 while (reader.Read())
                 {
                     if (i == 1)
                     {
                         marcavarios = "and (e.marca='" + reader["marca"].ToString() + "'";
                     }
                     else
                     {
                         marcavarios += " or e.marca='" + reader["marca"].ToString() + "'";
                     }
                     cbMarca.Items.Add(reader["descrip"].ToString());
                     if (seleccion_marca == reader["marca"].ToString())
                     { marcaS = i; }
                     idd[i] = reader["marca"].ToString();
                     i++;
                 }
                 reader.Close();
                 total = true;
             }
             marcavarios += ")";
             if (seleccion_marca == "0") { marcaS = 0; }
             cbMarca.SelectedIndex = marcaS;
             cbMarca_index();
         }

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
                 if (seleccion_sucursal == Convert.ToInt32(reader["idsucursal"]))
                 { sucS = i; }
                 i++;
             }
             idsucursalvarios += ")";
             reader.Close();
             cbSucursales.SelectedIndex = sucS;
         }
         #region  selected index combos
         private void cbSucursales_index()
         {
             soloSuc = true;
             bandera_sucursal = true;
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
             if (seleccion_sucursal != 0)
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
                 totalE = false;
                 groupby = "idsucursal";
                 where = "";
                 whereLeft = idsucursal;
             }
             else
             {
                 where = "";
                 groupby = " idsucursal";
                 whereLeft = idsucursalvarios;
                 queryunidadesAsignadas = "select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
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
                 s = ",0";
                 solototal = false;
                 sucursalcargar = "and idsucursal=0";
                 seleccion_sucursal = 0;
                 totalE = true;
             }
             solototal = false;
         }
         private void cbDivision_index()
         {
             soloSuc = false;
             bandera_division = true;
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

             if (seleccion_division != 0)
             {
                 seleccion_division = Convert.ToInt32(idd[cbDivisiones.SelectedIndex]);

                 iddivision = " e.iddivisiones=" + idd[cbDivisiones.SelectedIndex];
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
                 totalE = false;
                 groupby = "iddivisiones";
                 where = "  e.iddivisiones=1";
                 whereLeft = idsucursalvarios;
             }
             else
             {
                 groupby = "iddivisiones";
                 where = "  e.iddivisiones=1";
                 whereLeft = idsucursalvarios;
                 queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar;
                 iddivision = " ";
                 iddivisionesvarios = " e.iddivisiones=1";
                 division = " ";
                 for (int i = 0; i <= cbDivisiones.Items.Count - 1; i++)
                 {
                     querycargar[i] = sucursalcargar + " and iddivisiones=" + idd[(i + 1)] + " and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                     iddivision = "and V.iddivisiones=" + idd[(i + 1)];
                     wherequery[i] = idsucursalvarios + " " + iddivision;
                     queryguardar[i] = s + "," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,-1,-1,-1,'-1'";
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
                 totalE = true;
             }
             solototal = false;
         }
         private void cbDepto_index()
         {
             soloSuc = false;
             bandera_depto = true;
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

             if (seleccion_depto != 0)
             {
                 seleccion_depto = Convert.ToInt32(idd[cbDepto.SelectedIndex]);

				iddepto = "and e.iddepto=" + idd[cbDepto.SelectedIndex];
				wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddepto;
				iddeptovarios = iddepto;
				total = false;
				string[] texto = cbDepto.Text.Split('=');
				lbdepartamento.Text = "Departamento=" + texto[0];
				query = "SELECT descrip,iddepto from estdepartamento where visiblebp='1' and iddepto=" + idd[cbDepto.SelectedIndex];
				depto = "and iddepto=" + idd[cbDepto.SelectedIndex];
				queryguardar[0] =  s + " " + d + "," + idd[cbDepto.SelectedIndex] + ",-1,-1,-1,-1,-1,-1,-1,-1,'-1'";
				dd = ","+idd[cbDepto.SelectedIndex];
				querycargar[0] = sucursalcargar + " " + divisioncargar + " and iddepto=" + idd[cbDepto.SelectedIndex] + " and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
				queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' "+querycargar[0];
				departamentocargar = "and iddepto=" + idd[cbDepto.SelectedIndex];
				totalE = false;
                groupby = "iddepto";
                where = "  e.iddivisiones=1 " + iddepto;
                whereLeft = idsucursalvarios;
			}
			else
			{
                groupby = "iddepto";
                where = " e.iddivisiones=1";
                whereLeft = idsucursalvarios;
				queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " and iddepto=-1";
				//iddeptovarios = " ";
				for (int i = 0; i <= cbDepto.Items.Count - 1; i++)
				{
					querycargar[i] = sucursalcargar + " " + divisioncargar + " and iddepto=" + idd[(i + 1)] + " and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
					iddepto = "and V.iddepto=" + idd[(i + 1)];
					wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + " " + iddepto;
					queryguardar[i] = s + " " + d + "," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,-1,-1,'-1'";
					if (bandera_sucursal==false&&bandera_division==false)
						{
							wherequery[i] = iddepto + " and iddivisiones=1";
							queryguardar[i] = ",-1,-1," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,-1,-1,'-1'";
							querycargar[i] = "and idsucursal=-1 and iddivisiones=-1 and iddepto=" + idd[(i + 1)] + " and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
							queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
							pocision = 13;

						}
				}
				total = true;
				query = "SELECT descrip,iddepto from estdepartamento where visiblebp='1'  and iddivisiones=1";
				lbdepartamento.Text = "Departamento=Total";
				depto = " ";
				dd = ",0";
				departamentocargar = "and iddepto=0";
				seleccion_depto = 0;
				totalE = true;
                 total = true;
                 lbdepartamento.Text = "Departamento=Total";
                 depto = " ";
                 dd = ",0";
                 departamentocargar = "and iddepto=0";
                 seleccion_depto = 0;
                 solototal = false;
             }
         }
         private void cbFamilia_index()
         {
             soloSuc = false;
             bandera_familia = true;
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

             if (seleccion_familia != 0)
             {
                 seleccion_familia = Convert.ToInt32(idd[cbFamilia.SelectedIndex]);

                 idfamilia = "and e.idfamilia=" + idd[cbFamilia.SelectedIndex];
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
                 totalE = false;
                 groupby = "idfamilia";
                 where = iddivisionesvarios + " " + iddeptovarios + " " + idfamilia;
                 whereLeft = idsucursalvarios;
             }
             else
             {
                 groupby = "idfamilia";
                 where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios;
                 whereLeft = idsucursalvarios;
                 queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + " and idfamilia=-1 and marca=-1";
                 idfamiliavarios = " ";
                 for (int i = 0; i <= cbFamilia.Items.Count - 1; i++)
                 {
                     idfamilia = "and V.idfamilia=" + idd[(i + 1)];
                     wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamilia;
                     queryguardar[i] = s + " " + d + " " + dd + "," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,-1,'-1'";
                     querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " and idfamilia=" + idd[(i + 1)] + " and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                     if (bandera_sucursal==false&&bandera_division==false&&bandera_depto==false)
                     {
                         wherequery[i] = idfamilia + " and iddivisiones=1";
                         queryguardar[i] = ",-1,-1,-1," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,-1,'-1'";
                         querycargar[i] = "and idsucursal=-1 and iddivisiones=-1 and iddepto=-1 and idfamilia=" + idd[(i + 1)] + " and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                         queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                     }
                 }
                 total = true;
                 query = "SELECT descrip,idfamilia from estfamilia where visiblebp='1' " + division + " " + depto;
                 lbfamilia.Text = "Familia=Total";
                 fam = " ";
                 f = ",0";
                 familiacargar = "and idfamilia=0";
                 seleccion_familia = 0;
                 totalE = true;
                 total = true;
                 lbfamilia.Text = "Familia=Total";
                 fam = " ";
                 f = ",0";
                 familiacargar = "and idfamilia=0";
                 seleccion_familia = 0;
             }
             solototal = false;
         }
         private void cbLinea_index()
         {
             soloSuc = false;
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
             #endregion

             if (seleccion_linea != 0)
             {
                 seleccion_linea = Convert.ToInt32(idd[cbLinea.SelectedIndex]);
                 querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " and idlinea=" + idd[cbLinea.SelectedIndex] + " and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                 idlinea = "and e.idlinea=" + idd[cbLinea.SelectedIndex];
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
                 totalE = false;
                 groupby = "idlinea";
                 where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlinea;
                 whereLeft = idsucursalvarios;
             }
             else
             {
                 groupby = "idlinea";
                 where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios;
                 whereLeft = idsucursalvarios;
                 queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " and idlinea=-1";
                 for (int i = 0; i <= cbLinea.Items.Count - 1; i++)
                 {
                     querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " and idlinea=" + idd[(i + 1)] + " and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                     idlinea = "and V.idlinea=" + idd[(i + 1)];
                     wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlinea;
                     queryguardar[i] = s + " " + d + " " + dd + " " + f + "," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,'-1'";
                     query = "SELECT descrip,idlinea from estlinea where visiblebp='1' " + division + " " + depto + "" + " " + fam;

                     if (bandera_sucursal == false && bandera_division == false && bandera_depto == false&&bandera_familia==false)
                     {
                         wherequery[i] = idlinea + " and iddivisiones=1";
                         queryguardar[i] = ",-1,-1,-1,-1," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,-1,'-1'";
                         querycargar[i] = "and idsucursal=-1 and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=" + idd[(i + 1)] + " and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                         queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                         query = "SELECT descrip,idlinea from estlinea where visiblebp='1' and iddivisiones=1";
                     }
                 }
                 total = true;
                 linea = " ";
                 l = ",0";
                 lineacargar = "and idlinea=0";
                 seleccion_linea = 0;
                 totalE = true;
             }
             lblinea.Text = "Linea=" + cbLinea.Text;
             solototal = false;
         }
         private void cbL1_index()
         {
             soloSuc = false;
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
             #endregion

             if (seleccion_l1 != 0)
             {
                 seleccion_l1 = Convert.ToInt32(idd[cbL1.SelectedIndex]);

                 querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " and idl1=" + idd[cbL1.SelectedIndex] + " and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                 idl1 = "and e.idl1=" + idd[cbL1.SelectedIndex];
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
                 totalE = false;
                 groupby = "idl1";
                 where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1;
                 whereLeft = idsucursalvarios;
             }
             else
             {
                 groupby = "idl1";
                 where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios;
                 whereLeft = idsucursalvarios;
                 queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " and idl1=-1";
                 idl1varios = " ";
                 for (int i = 0; i <= cbL1.Items.Count - 1; i++)
                 {
                     query = "SELECT descrip,idl1 from estl1 where visiblebp='1' " + division + " " + depto + " " + fam + " " + linea;
                     querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " and idl1=" + idd[(i + 1)] + " and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                     idl1 = "and V.idl1=" + idd[(i + 1)];
                     wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1;
                     queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + "," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,'-1'";
                     if (bandera_sucursal == false && bandera_division == false && bandera_depto == false && bandera_familia==false && bandera_linea==false)
                     {
                         wherequery[i] = idl1 + " and iddivisiones=1";
                         queryguardar[i] = ",-1,-1,-1,-1,-1," + idd[(i + 1)] + ",-1,-1,-1,-1,-1,'-1'";
                         querycargar[i] = "and idsucursal=-1 and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=" + idd[(i + 1)] + " and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                         queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                         query = "SELECT descrip,idl1 from estl1 where visiblebp='1' and iddivisiones=1";
                     }

                 }
                 subl1 = " ";
                 lbl1.Text = "L1=Total";
                 total = true;
                 l1 = ",0";
                 l1cargar = "and idl1=0";
                 seleccion_l1 = 0;
                 totalE = true;
             }
             lbl1.Text = "L1=" + cbL1.Text;
             solototal = false;
         }
         private void cbL2_index()
         {
             soloSuc = false;
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
             #endregion
             if (seleccion_l2 != 0)
             {
                 seleccion_l2 = Convert.ToInt32(idd[cbL2.SelectedIndex]);

                 querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " and idl2=" + idd[cbL2.SelectedIndex] + " and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                 idl2 = "and e.idl2=" + idd[cbL2.SelectedIndex];
                 idl2varios = idl2;
                 total = false;
                 query = "SELECT descrip,idl2 from estl2 where visiblebp='1' and idl2=" + idd[cbL2.SelectedIndex];
                 wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2;
                 subl2 = "and idl2=" + idd[cbL2.SelectedIndex];
                 queryguardar[0] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + "," + idd[cbL2.SelectedIndex] + ",-1,-1,-1,-1,'-1'";
                 l2 = "," + idd[cbL2.SelectedIndex];
                 queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                 l2cargar = "and idl2=" + idd[cbL2.SelectedIndex];
                 totalE = false;
                 groupby = "idl2";
                 where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios;
                 whereLeft = idsucursalvarios;
             }
             else
             {
                 groupby = "idl2";
                 where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios;
                 whereLeft = idsucursalvarios;
                 queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " and idl2=-1 and marca='-1'";
                 subl2 = " ";
                 for (int i = 0; i <= cbL2.Items.Count - 1; i++)
                 {
                     querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " and idl2=" + idd[(i + 1)] + " and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                     idl2 = "and V.idl2=" + idd[(i + 1)];
                     wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2;
                     queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + "," + idd[(i + 1)] + ",-1,-1,-1,-1,'-1'";
                 }
                 l2 = ",0";
                 total = true;
                 query = "SELECT descrip,idl2 from estl2 where visiblebp='1' " + division + " " + depto + " " + fam + " " + linea + " " + subl1;
                 l2cargar = "and idl2=0";
                 seleccion_l2 = 0;
                 totalE = true;
             }
             lbL2.Text = "L2=" + cbL2.Text;
             solototal = false;
         }
         private void cbL3_index()
         {
             soloSuc = false;
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
             #endregion
             if (seleccion_l3 != 0)
             {
                 seleccion_l3 = Convert.ToInt32(idd[cbL3.SelectedIndex]);

                 l3cargar = "and idl3=" + idd[cbL3.SelectedIndex];
                 querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " and idl3=" + idd[cbL3.SelectedIndex] + " and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                 idl3 = "and e.idl3=" + idd[cbL3.SelectedIndex];
                 idl3varios = idl3;
                 total = false;
                 query = "SELECT descrip,idl3 from estl3 where visiblebp='1' and idl3=" + idd[cbL3.SelectedIndex];
                 wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3;
                 subl3 = "and idl3=" + idd[cbL3.SelectedIndex];
                 queryguardar[0] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + "," + idd[cbL3.SelectedIndex] + ",-1,-1,-1,'-1'";
                 l3 = "," + idd[cbL3.SelectedIndex];
                 queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                 totalE = false;
                 groupby = "idl3";
                 where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios;
                 whereLeft = idsucursalvarios;
             }
             else
             {
                 groupby = "idl3";
                 where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios;
                 whereLeft = idsucursalvarios;
                 queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " and idl3=-1";
                 subl3 = " ";
                 for (int i = 0; i <= cbL3.Items.Count - 1; i++)
                 {
                     querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " and idl3=" + idd[(i + 1)] + " and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'  ";
                     idl3 = "and V.idl3=" + idd[(i + 1)];
                     wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3;
                     queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + "," + idd[(i + 1)] + ",-1,-1,-1,'-1'";
                 }
                 total = true;
                 query = "SELECT descrip,idl3 from estl3 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2;
                 l3 = ",0";
                 l3cargar = "and idl3=0";
                 seleccion_l3 = 0;
                 totalE = true;
             }
             lbL3.Text = "L3=" + cbL3.Text;
             solototal = false;
         }
         private void cbL4_index()
         {
             soloSuc = false;
             bandera_l4 = true;
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
             if (seleccion_l4 != 0)
             {
                 querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " and idl4=" + idd[cbL4.SelectedIndex] + " and idl5=-1 and idl6=-1 and marca='-1'  ";
                 idl4 = "and e.idl4=" + idd[cbL4.SelectedIndex];
                 idl4varios = idl4;
                 total = false;
                 query = "SELECT descrip,idl4 from estl4 where visiblebp='1' and idl4=" + idd[cbL4.SelectedIndex];
                 wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4;
                 subl4 = "and idl4=" + idd[cbL4.SelectedIndex];
                 queryguardar[0] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + "," + idd[cbL4.SelectedIndex] + ",-1,-1,'-1'";
                 l4 = "," + idd[cbL4.SelectedIndex];
                 queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                 l4cargar = "and idl4=" + idd[cbL4.SelectedIndex];
                 totalE = false;
                 groupby = "idl4";
                 where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios;
                 whereLeft = idsucursalvarios;
             }
             else
             {
                 groupby = "idl4";
                 where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios;
                 whereLeft = idsucursalvarios;
                 queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " and idl4=-1";
                 subl4 = " ";
                 for (int i = 0; i <= cbL4.Items.Count - 1; i++)
                 {
                     querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " and idl4=" + idd[(i + 1)] + " and idl5=-1 and idl6=-1 and marca='-1'  ";
                     idl4 = "and V.idl4=" + idd[(i + 1)];
                     wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4;
                     queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + "," + idd[(i + 1)] + ",-1,-1,'-1'";
                 }
                 total = true;
                 query = "SELECT descrip,idl4 from estl4 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2 + " " + subl3;
                 l4 = ",0";
                 l4cargar = "and idl4=0";
                 seleccion_l4 = 0;
                 totalE = true;
             }
             lbL4.Text = "L4=" + cbL4.Text;
             solototal = false;
         }
         private void cbL5_index()
         {
             soloSuc = false;
             bandera_l5 = true;
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
             if (seleccion_l5 != 0)
             {
                 seleccion_l5 = Convert.ToInt32(idd[cbL5.SelectedIndex]);

                 querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " and idl5=" + idd[cbL5.SelectedIndex] + " and idl6=-1 and marca='-1'  ";
                 idl5 = "and e.idl5=" + idd[cbL5.SelectedIndex];
                 idl5varios = idl5;
                 total = false;
                 query = "SELECT descrip,idl5 from estl5 where visiblebp='1' and idl5=" + idd[cbL5.SelectedIndex];
                 wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5;
                 subl5 = "and idl5=" + idd[cbL5.SelectedIndex];
                 queryguardar[0] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + " " + l4 + "," + idd[cbL5.SelectedIndex] + ",-1,'-1'";
                 l5 = "," + idd[cbL5.SelectedIndex];
                 queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                 l5cargar = "and idl5=" + idd[cbL5.SelectedIndex];
                 totalE = false;
                 groupby = "idl5";
                 where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios;
                 whereLeft = idsucursalvarios;
             }
             else
             {
                 groupby = "idl5";
                 where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios;
                 whereLeft = idsucursalvarios;
                 queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " and idl5=-1";
                 idl5varios = " ";
                 subl5 = " ";
                 for (int i = 0; i <= cbL5.Items.Count - 1; i++)
                 {
                     querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " and idl5=" + idd[(i + 1)] + " and idl6=-1 and marca='-1'  ";
                     idl5 = "and V.idl5=" + idd[(i + 1)];
                     wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5;
                     queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + " " + l4 + "," + idd[(i + 1)] + ",-1,'-1'";
                 }
                 total = true;
                 query = "SELECT descrip,idl5 from estl5 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2 + " " + subl3 + " " + subl4;
                 l5 = ",0";
                 l5cargar = "and idl5=0";
                 seleccion_l5 = 0;
                 totalE = true;
             }
             lbL5.Text = "L5=" + cbL5.Text;
             solototal = false;
         }
         private void cbL6_index()
         {
             soloSuc = false;
             bandera_l6 = true;
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

             if (seleccion_l6 != 0)
             {
                 seleccion_l6 = Convert.ToInt32(idd[cbL6.SelectedIndex]);

                 querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " and idl6=" + idd[cbL6.SelectedIndex] + " and marca='-1'  ";
                 idl6 = "and e.idl6=" + idd[cbL6.SelectedIndex];
                 idl6varios = idl6;
                 total = false;
                 query = "SELECT descrip,idl6 from estl6 where visiblebp='1' and idl6=" + idd[cbL6.SelectedIndex];
                 wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6varios;
                 subl6 = "and idl6=" + idd[cbL6.SelectedIndex];
                 queryguardar[0] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + " " + l4 + " " + l5 + "," + idd[cbL6.SelectedIndex] + ",'-1'";
                 l6 = "," + idd[cbL6.SelectedIndex];
                 queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                 l6cargar = "and idl6=" + idd[cbL6.SelectedIndex];
                 totalE = false;
                 groupby = "idl6";
                 where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl6varios;
                 whereLeft = idsucursalvarios;
             }
             else
             {
                 groupby = "idl6";
                 where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl6varios;
                 whereLeft = idsucursalvarios;
                 //idl6varios = " ";
                 queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " and idl6=-1";
                 subl6 = " ";
                 idl6 = " ";
                 for (int i = 0; i <= cbL6.Items.Count - 1; i++)
                 {
                     querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " and idl6=" + idd[(i + 1)] + " and marca='-1'  ";
                     idl6 = "and V.idl6=" + idd[(i + 1)];
                     wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6;
                     queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + " " + l4 + " " + l5 + "," + idd[(i + 1)] + ",'-1'";
                 }
                 total = true;
                 query = "SELECT descrip,idl6 from estl6 where visiblebp='1' " + division + " " + depto + "" + " " + fam + " " + linea + " " + subl1 + " " + subl2 + " " + subl3 + " " + subl4 + " " + subl5;
                 l6 = ",0";
                 l6cargar = "and idl6=0";
                 seleccion_l6 = 0;
                 totalE = true;
             }
             lbL6.Text = "L6=" + cbL6.Text;
             solototal = false;
         }
         private void cbMarca_index()
         {
             soloSuc = false;
             bandera_marca = true;
             seleccion_marca = cbMarca.SelectedText;
             if (seleccion_marca == "")
             {
                 seleccion_marca = "0";
                 for (int i = 0; i <= cbMarca.Items.Count - 1; i++)
                 {
                     marca = " and V.marca='" + idd[(i + 1)] + "'";
                     if (bandera_l6 == true && bandera_l5 == true)
                     {
                         wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6varios + " " + marca;
                         queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + " " + l4 + " " + l5 + " " + l6 + ",'" + idd[(i + 1)] + "'";
                         querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " " + l6cargar + " and marca='" + idd[(i + 1)] + "'  ";
                         queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " " + l6cargar + " and marca='-1'";
                         pocision = 16;
                         groupby = "marca";
                         where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl6varios + " " + marcavarios;
                         whereLeft = idsucursalvarios;
                     }

                     if (bandera_sucursal == true && bandera_division == true && bandera_depto == true && bandera_familia == false)
                     {
                         wherequery[i] = idsucursalvarios + " " + iddeptovarios + " and iddivisiones=1 " + marca;
                         queryguardar[i] = s + " " + d + " " + dd + ",-1,-1,-1,-1,-1,-1,-1,-1,'" + idd[(i + 1)] + "'";

                         querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='" + idd[(i + 1)] + "'  ";
                         queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and iddepto=" + seleccion_depto.ToString() + " and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and idfamilia=-1 and marca='-1'";
                         pocision = 14;
                         groupby = "marca";
                         where = iddivisionesvarios + " " + iddeptovarios + " " + marcavarios;
                         whereLeft = idsucursalvarios;
                     }
                     if (bandera_sucursal == false && bandera_division == false && bandera_depto == false && bandera_familia == false && bandera_linea == false && bandera_l1 == false && bandera_l2 == false && bandera_l3 == false && bandera_l4 == false && bandera_l5 == false && bandera_l6 == false)
                     {
                         wherequery[i] = marca + " and iddivisiones=1";
                         queryguardar[i] = ",-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,'" + idd[(i + 1)] + "'";
                         querycargar[i] = "and idsucursal=-1 and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='" + idd[(i + 1)] + "'  ";
                         queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                         query = "SELECT distinct m.descrip,m.marca from marca as m inner join estarticulo as V on V.marca=m.marca where visiblebp=1 and v.iddivisiones=1";
                         groupby = "marca";
                         where = "  e.iddivisiones=1 " + marcavarios;
                         whereLeft = "";
                     }
                     if (bandera_sucursal == true && bandera_division == true && bandera_depto == true && bandera_familia == true && bandera_linea == true && bandera_l1 == true && bandera_l2 == false)
                     {
                         wherequery[i] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + marca;
                         queryguardar[i] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + ",-1,-1,-1,-1,-1, '" + idd[(i + 1)] + "'";
                         querycargar[i] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='" + idd[(i + 1)] + "'  ";
                         queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " and idl2=-1 and marca='-1'";
                         // query = "SELECT distinct m.descrip,m.marca from marca as m inner join estarticulo as V on V.marca=m.marca where visiblebp=1 and v.iddivisiones=1";
                         pocision = 15;
                         groupby = "marca";
                         where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + marcavarios;
                         whereLeft = idsucursalvarios;
                     }

                 }
                 total = true;
                 seleccion_marca = "0";
                 totalE = true;
             }
             else
             {
                 totalE = false;
                 seleccion_marca = "0";
                 query = query + " and M.marca='" + idd[cbMarca.SelectedIndex] + "'";
                 marca = " and e.marca='" + idd[cbMarca.SelectedIndex] + "'";
                 wherequery[0] = idsucursalvarios + " " + idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6varios + " " + marca;
                 total = false;
                 queryguardar[0] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + " " + l4 + " " + l5 + " " + l6 + ",'" + idd[cbMarca.SelectedIndex] + "'";
                 querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " " + l6cargar + " and marca='" + idd[cbMarca.SelectedIndex] + "'  ";
                 queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                 marcavarios = marca;
                 if (bandera_l6 == true && bandera_l5 == true)
                 {
                     wherequery[0] = idsucursalvarios + " " + iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl5varios + " " + idl6varios + " " + marca;
                     queryguardar[0] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + " " + l2 + " " + l3 + " " + l4 + " " + l5 + " " + l6 + ",'" + idd[cbMarca.SelectedIndex] + "'";
                     querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " " + l6cargar + " and marca='" + idd[cbMarca.SelectedIndex] + "'  ";
                     queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " " + l2cargar + " " + l3cargar + " " + l4cargar + " " + l5cargar + " " + l6cargar + " and marca='-1'";
                     groupby = "marca";
                     where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + idl2varios + " " + idl3varios + " " + idl4varios + " " + idl6varios + " " + marcavarios;
                     whereLeft = idsucursalvarios;
                 }
                 if (bandera_sucursal == true && bandera_division == true && bandera_depto == true && bandera_linea == false)
                 {
                     wherequery[0] = idsucursalvarios + " " + iddeptovarios + " and iddivisiones=1 " + marca;
                     queryguardar[0] = s + " " + d + " " + dd + ",-1,-1,-1,-1,-1,-1,-1,-1,'" + idd[cbMarca.SelectedIndex] + "'";

                     querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='" + idd[cbMarca.SelectedIndex] + "'  ";
                     queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and iddepto=" + seleccion_depto.ToString() + " and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and idfamilia=-1 and marca='-1'";
                     groupby = "marca";
                     where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + marcavarios;
                     whereLeft = idsucursalvarios;
                 }
                 if (bandera_sucursal == false && bandera_division == false && bandera_depto == false && bandera_familia == false && bandera_linea == false && bandera_l1 == false && bandera_l2 == false && bandera_l3 == false && bandera_l4 == false && bandera_l5 == false && bandera_l6 == false)
                 {
                     wherequery[0] = marca + " and iddivisiones=1";
                     queryguardar[0] = ",-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,'" + idd[cbMarca.SelectedIndex] + "'";
                     querycargar[0] = "and idsucursal=-1 and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='" + idd[cbMarca.SelectedIndex] + "'  ";
                     queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[cbMarca.SelectedIndex];
                     query = "SELECT distinct m.descrip,m.marca from marca as m inner join estarticulo as V on V.marca=m.marca where visiblebp=1 and v.iddivisiones=1 and m.marca='" + idd[cbMarca.SelectedIndex] + "'";
                     groupby = "marca";
                     where = "  e.iddivisiones=1 " + marcavarios;
                     whereLeft = "";
                 }
                 if (bandera_sucursal == true && bandera_division == true && bandera_depto == true && bandera_familia == true && bandera_linea == true && bandera_l1 == true && bandera_l2 == false)
                 {
                     wherequery[0] = marca + " and iddivisiones=1";
                     queryguardar[0] = s + " " + d + " " + dd + " " + f + " " + l + " " + l1 + ",-1,-1,-1,-1,-1, '" + idd[cbMarca.SelectedIndex] + "'";
                     querycargar[0] = sucursalcargar + " " + divisioncargar + " " + departamentocargar + " " + familiacargar + " " + lineacargar + " " + l1cargar + " and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='" + idd[cbMarca.SelectedIndex] + "'  ";
                     queryunidadesAsignadas = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1  " + querycargar[0];
                     query = "SELECT distinct m.descrip,m.marca from marca as m inner join estarticulo as V on V.marca=m.marca where visiblebp=1 and v.iddivisiones=1 and m.marca='" + idd[cbMarca.SelectedIndex] + "'";
                     groupby = "marca";
                     where = iddivisionesvarios + " " + iddeptovarios + " " + idfamiliavarios + " " + idlineavarios + " " + idl1varios + " " + marcavarios;
                     whereLeft = idsucursalvarios;
                 }
             }
             lbMarca.Text = "Marca=" + cbMarca.Text;
             solototal = false;
         }

         #endregion
         #endregion
		 private void button2_Click(object sender, EventArgs e)
		 {
			 Cedula1 c1 = new Cedula1();
			 c1.Show();
			 this.Close();
		 }

		 private void checkBox1_CheckedChanged(object sender, EventArgs e)
		 {
			 if(checkBox1.Checked==true)
			 {
				 desbloquearComponentes();
			 }
			 else
			 {
				 bloquearComponentes();
			 }
		 }

		private void bloquearComponentes()
		 {
			 tbinflacion.Enabled = false;
			 tbpp.Enabled = false;
			 tbR.Enabled = false;
			 tbvti.Enabled = false;
			 btnSimular.Enabled = false;
			 tbpM.Enabled = false;
		 }
		private void desbloquearComponentes()
		{
			tbinflacion.Enabled = true;
			tbR.Enabled = true;
			tbvti.Enabled = true;
			btnSimular.Enabled = true;
			tbpM.Enabled = true;
		}

		private void keypressGlobal(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar)
						&& !char.IsDigit(e.KeyChar)&&e.KeyChar!='.')
				e.Handled = true;
			base.OnKeyPress(e);
		}

		private void dgvCed2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			e.Control.KeyPress += new KeyPressEventHandler(keypressGlobal);
		}

		/// <sumary>
		/// 0000000
		/// 00000
		/// 0000
		/// 000
		/// 00
		///     Metodos nuevos
		/// 00
		/// 0000
		/// 00000
		/// 0000000
		 /// 00000000
		/// </sumary>
		private void m_porcentajeH()
		{
			double imp = 0, unid = 0, por = 0;
			int x = 0,y=0;
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
			for (; x <= dgvCed2.Rows.Count - 1; x++)
			{
				this.Invoke(new Action(() =>
				{
                    if (dgvCed2.Rows[x].Cells[7].Value != null)
                    {
                        imp += double.Parse(dgvCed2.Rows[x].Cells[7].Value.ToString(), NumberStyles.Currency);
                    }
				}));
			}
			for (; y < dgvCed2.Rows.Count; y++)
			{
				this.Invoke(new Action(() =>
				{
                    if (dgvCed2.Rows[y].Cells[7].Value != null)
                    {
                        unid = double.Parse(dgvCed2.Rows[y].Cells[7].Value.ToString(), NumberStyles.Currency);
                    }
				}));
                if (unid == 0 || imp == 0)
                {

                    por = 0;
                    this.Invoke(new Action(() =>
                    {
                        if (dgvCed2.Rows[y].Cells[5].Value != null)
                        {
                            dgvCed2.Rows[y].Cells[5].Value = por.ToString("n2");
                        }
                        else
                        {
                            dgvCed2.Rows[y].Cells[5].Value = "0";
                        }
                    }));
                }
                else
                {
                    por = (unid / imp) * 100;
                    this.Invoke(new Action(() =>
                    {
                        if (dgvCed2.Rows[y].Cells[7].Value != null)
                        {
                            dgvCed2.Rows[y].Cells[5].Value = por.ToString("n2");
                        }
                        else
                        {
                            dgvCed2.Rows[y].Cells[5].Value = "0";
                        }
                    }));
                }
			}
		}
		private void comprobarCedulas()
		{
			bool comprobar=false;
			string q = "Select nombre from cedula1 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=0  and iddivisiones=0 and iddepto=0 and idfamilia=0 and idlinea=0 and idl1=0 and idl2=0 and idl3=0 and idl4=0 and idl5=0 and idl6=0 and marca='0'";
			checaConexion();
			cmd = new MySqlCommand(q, Conn);
			reader = cmd.ExecuteReader();
			if (reader.HasRows)
			{
				comprobar = true;
			}
			else
			{
				comprobar = false;
			}
			reader.Close();
			if(comprobar==true)
			{
				m_cargarCedula1();
                m_comprobarCedula2();	
			}
			else
			{
                if(solototal==true)
                {
                    consultaHistorico();
                    m_porcentajeH();
                    m_preciopromedioXtasa();
                }
                else
                {
                    MessageBox.Show("Ingresa los valores iniciales o regresa a un nivel superior");
                }
			}
		}
		private void m_cargarCedula1()
		{
			double c1, c2, c3, c4, c5, c6, c7, unidades = 0,c8;
			string q = "";
			if (solototal==true)
			{
				q = "Select * from cedula1 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=0 and iddivisiones=0 and iddepto=0 and idfamilia=0 and idlinea=0 and idl1=0 and idl2=0 and idl3=0 and idl4=0 and idl5=0 and idl6=0 and marca='0'";
				cmd = new MySqlCommand(q, Conn);
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					c1 = double.Parse(reader["preciopromedioUP"].ToString());
					c2 = double.Parse(reader["preciopromedioUH"].ToString());
					c3 = double.Parse(reader["Inventariodeseado"].ToString());
					c4 = double.Parse(reader["rotacion"].ToString());
					c5 = double.Parse(reader["DiasInv"].ToString());
					c6 = double.Parse(reader["VTI"].ToString());
					c7 = double.Parse(reader["Inflacion"].ToString());
					this.Invoke(new Action(() =>
					{
					lbppuP.Text = c1.ToString("C2");
					lbppuH.Text = c2.ToString("C2");
					tbpp.Text = c3.ToString("n0");
					tbR.Text = c4.ToString("n");
					lbdi.Text = c5.ToString("n0");
					tbvti.Text = c6.ToString("C2");
					tbinflacion.Text = c7.ToString("n");
					lbvtii.Text = c6.ToString("n2");
					c8 = c3 / c4;
					tbpM.Text = c8.ToString("n0");
					lbPPaux.Text = c3.ToString("n0");
					}));
					
				}
				reader.Close();
				cmd = new MySqlCommand("SELECT * from cedula2 where nombre='"+Properties.Settings.Default.escenario+"'  and ZapateriasTorreon=1", Conn);
				reader = cmd.ExecuteReader();
				//checaConexion();
				while (reader.Read())
				{
					unidades = double.Parse(reader["asignacionUP"].ToString());
				}
				reader.Close();
				this.Invoke(new Action(() =>
				{
				double PVunit = double.Parse(lbppuH.Text, NumberStyles.Currency);
				}));
			}
			else
			{
				#region cargarced1
				string s = "Select * from cedula1 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=0 and iddivisiones=0 and iddepto=0 and idfamilia=0 and idlinea=0 and idl1=0 and idl2=0 and idl3=0 and idl4=0 and idl5=0 and idl6=0 and marca='0'";
				checaConexion();
				cmd = new MySqlCommand(s, Conn);
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					c1 = double.Parse(reader["preciopromedioUP"].ToString());
					c2 = double.Parse(reader["preciopromedioUH"].ToString());
					c3 = double.Parse(reader["Inventariodeseado"].ToString());
					c4 = double.Parse(reader["rotacion"].ToString());
					c5 = double.Parse(reader["DiasInv"].ToString());
					c6 = double.Parse(reader["VTI"].ToString());
					c7 = double.Parse(reader["Inflacion"].ToString());
					this.Invoke(new Action(() =>
					{
                    lbppuP.Text = c1.ToString("C2");
					lbppuH.Text = c2.ToString("C2");
					tbpp.Text = c3.ToString("n0");
					tbR.Text = c4.ToString("n");
					lbdi.Text = c5.ToString("n2");
					tbvti.Text = c6.ToString("C2");
					tbinflacion.Text = c7.ToString("n");
					lbvtii.Text = c6.ToString("n2");
					lbPPaux.Text = c3.ToString("n0");
					}));
					
					
				}
				reader.Close();
				checaConexion();
				cmd = new MySqlCommand(queryunidadesAsignadas+" limit 1", Conn);
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					unidades = double.Parse(reader["asignacionUP"].ToString());
				}
				reader.Close();
				this.Invoke(new Action(() =>
				{
                double PVunit = double.Parse(lbppuH.Text, NumberStyles.Currency);
				tbpp.Text = unidades.ToString("n0");
                    
				tbvti.Text = (unidades * PVunit).ToString("C2");
				lbvtii.Text = (unidades * PVunit).ToString("C2");
                if (unidades != 0 && double.Parse(tbR.Text) != 0)
                {
                    c8 = unidades / double.Parse(tbR.Text);
                }
                else { c8 = 0; }
				tbpM.Text = c8.ToString("n0");
				lbPPaux.Text = tbpp.Text;
				  this.Refresh();
				}));
				
				#endregion
			}
		}
		private void m_comprobarCedula2()
		{
			int x = 0,i=0;
			string q = "";
			bool comprobar = false;
			cargando = true;
			double c1, c2, c3, c4, c5, c6, c7, c8;
			if (generando == true)
			{
                consultaHistorico();
                m_porcentajeH();
                m_preciopromedioXtasa();
                for (int comp = 0; comp < dgvCed2.RowCount; comp++)
                {
                    if (dgvCed2.Rows[comp].Cells[1].Value == null)
                    {
                        dgvCed2.Rows[comp].Cells[1].Value = dgvCed2.Rows[comp].Cells[5].Value;

                        celdaEndClick(comp);
                    }
                }
			}
			else
			{
			    if (solototal == true)
			    {
				    x = 0;
			    }
			    else
			    {
				    x = 1;
			    }
			for (; x <= dgvCed2.Rows.Count - 1; x++)
			{
				q = "Select nombre from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[i];
				checaConexion();
				cmd = new MySqlCommand(q, Conn);
				reader = cmd.ExecuteReader();
				if (reader.HasRows)
				{
					comprobar = true;
				}
				else
				{
					comprobar = false;
				}
				reader.Close();
				if(comprobar==true)
				{
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + " '" + querycargar[i] + "";
					checaConexion();
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						c1 = double.Parse(reader["porsentajeP"].ToString());
						c2 = double.Parse(reader["asignacionUP"].ToString());
						c3 = double.Parse(reader["asignacionIP"].ToString());
						c4 = double.Parse(reader["porsentajeH"].ToString());
						c5 = double.Parse(reader["asignacionUH"].ToString());
						c6 = double.Parse(reader["asignacionIH"].ToString());
						c7 = double.Parse(reader["precioPromedioP"].ToString());
						c8 = double.Parse(reader["precioPromedioH"].ToString());
						dgvCed2.Rows[x].Cells[1].Value = c1.ToString("n");
						dgvCed2.Rows[x].Cells[4].Value = c7.ToString("C2");
						dgvCed2.Rows[x].Cells[5].Value = c4.ToString("n");
						dgvCed2.Rows[x].Cells[6].Value = c5.ToString("n0");
						dgvCed2.Rows[x].Cells[7].Value = c6.ToString("C2");
						dgvCed2.Rows[x].Cells[8].Value = c8.ToString("C2");
						celdaEndClick(x);
					}
					reader.Close();
				   
				}
				i++;
			}
			if (comprobar != true)
			{
                consultaHistorico();
                m_porcentajeH();
                m_preciopromedioXtasa();
                for (int comp = 0; comp < dgvCed2.RowCount; comp++)
                {

                    if (dgvCed2.Rows[comp].Cells[1].Value == null)
                    {
                        dgvCed2.Rows[comp].Cells[1].Value = dgvCed2.Rows[comp].Cells[5].Value;

                        celdaEndClick(comp);
                    }
                }
			}
		}
		}
		private void btnRecalcular_Click(object sender, EventArgs e)
		{
			generando = true;
			if (bgw_Proyectar.IsBusy == false)
			{
				bgw_Proyectar.RunWorkerAsync();
			}
		}
		private void bgw_Proyectar_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
		   proyectar(sender, e);
		}
		private void guardarP()
		{
			double precioPH = 0, precioPP = 0, inventario = 0, rotacion = 0, diasinv = 0, VTI = 0, inflacion = 0;
			if (solototal == true)
			{
				#region solo total
				#region comprobar existente
				string q = "Select nombre from cedula1 where nombre='" + Properties.Settings.Default.escenario + "'  and ZapateriasTorreon=1";
				bool c = true;
				checaConexion();
				cmd = new MySqlCommand(q, Conn);
				reader = cmd.ExecuteReader();
				if (reader.HasRows == true)
				{
					c = true;
				}
				else
				{
					c = false;
				}
				reader.Close();
				#endregion
				if (c == true)
				{
					#region cedula1
					if (solototal == true)
					{
						precioPH = double.Parse(lbppuH.Text, NumberStyles.Currency);
						precioPP = double.Parse(lbppuP.Text, NumberStyles.Currency);
						inventario = double.Parse(tbpp.Text, NumberStyles.Currency);
						rotacion = double.Parse(tbR.Text, NumberStyles.Currency);
						diasinv = double.Parse(lbdi.Text, NumberStyles.Currency);
						VTI = double.Parse(tbvti.Text, NumberStyles.Currency);
						inflacion = double.Parse(tbinflacion.Text, NumberStyles.Currency);
						string u = "UPDATE cedula1 set preciopromedioUP=" + precioPP.ToString() + ",preciopromedioUH=" + precioPH.ToString() + ",Inventariodeseado=" + inventario.ToString() + ",rotacion=" + rotacion.ToString() + ",DiasInv=" + diasinv.ToString() + ",VTI=" + VTI.ToString() + ",Inflacion=" + inflacion + " where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1 ";
						checaConexion();
						cmd = new MySqlCommand(u, Conn);
						cmd.ExecuteNonQuery();
					}
					#endregion
				}
				else
				{
					#region guardarcedula1
					precioPH = double.Parse(lbppuH.Text, NumberStyles.Currency);
					precioPP = double.Parse(lbppuP.Text, NumberStyles.Currency);
					inventario = double.Parse(tbpp.Text, NumberStyles.Currency);
					rotacion = double.Parse(tbR.Text, NumberStyles.Currency);
					diasinv = double.Parse(lbdi.Text, NumberStyles.Currency);
					VTI = double.Parse(tbvti.Text, NumberStyles.Currency);
					inflacion = double.Parse(tbinflacion.Text, NumberStyles.Currency);
					query = "INSERT INTO  cedula1 (nombre,Inventariodeseado,rotacion,preciopromedioUP,preciopromedioUH,DiasInv,VTI,Inflacion,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,ZapateriasTorreon) VALUES('" + Properties.Settings.Default.escenario + "'," + inventario.ToString() + "," + rotacion.ToString() + "," + precioPP.ToString() + "," + precioPH.ToString() + "," + diasinv.ToString() + "," + VTI.ToString() + ", " + inflacion.ToString() + " ,0,0,0,0,0,0,0,0,0,0,0,'0',1);";
					checaConexion();
					cmd = new MySqlCommand(query, Conn);
					cmd.ExecuteNonQuery();
					#endregion
				}
				#region comprobar existente
				q = "Select nombre from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
				c = true;
				checaConexion();
				cmd = new MySqlCommand(q, Conn);
				reader = cmd.ExecuteReader();
				if (reader.HasRows)
				{
					c = true;
				}
				else
				{
					c = false;
				}
				reader.Close();
				#endregion
				if (c == true)
				{
					double c1, c2, c3, c4, c5, c6, c7, c8;
					c1 = double.Parse(dgvCed2.Rows[0].Cells[1].Value.ToString(), NumberStyles.Currency);
					c2 = double.Parse(dgvCed2.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency);
					c3 = double.Parse(dgvCed2.Rows[0].Cells[3].Value.ToString(), NumberStyles.Currency);
					c4 = double.Parse(dgvCed2.Rows[0].Cells[4].Value.ToString(), NumberStyles.Currency);
					c5 = double.Parse(dgvCed2.Rows[0].Cells[5].Value.ToString(), NumberStyles.Currency);
					c6 = double.Parse(dgvCed2.Rows[0].Cells[6].Value.ToString(), NumberStyles.Currency);
					c7 = double.Parse(dgvCed2.Rows[0].Cells[7].Value.ToString(), NumberStyles.Currency);
					c8 = double.Parse(dgvCed2.Rows[0].Cells[8].Value.ToString(), NumberStyles.Currency);
					string u = "update cedula2 set porsentajeP=" + c1.ToString() + ",asignacionUP=" + c2.ToString() + ",asignacioniP=" + c3.ToString() + ",precioPromedioP=" + c4.ToString() + ",porsentajeH=" + c5.ToString() + ",asignacionUH=" + c6.ToString() + ",asignacionIH=" + c7.ToString() + ",precioPromedioH=" + c8.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
					checaConexion();
					cmd = new MySqlCommand(u, Conn);
					cmd.ExecuteNonQuery();
				}
				else
				{
					#region guardar cedula2
					double c1, c2, c3, c4, c5, c6, c7, c8;
					c1 = double.Parse(dgvCed2.Rows[0].Cells[1].Value.ToString(), NumberStyles.Currency);
					c2 = double.Parse(dgvCed2.Rows[0].Cells[2].Value.ToString(), NumberStyles.Currency);
					c3 = double.Parse(dgvCed2.Rows[0].Cells[3].Value.ToString(), NumberStyles.Currency);
					c4 = double.Parse(dgvCed2.Rows[0].Cells[4].Value.ToString(), NumberStyles.Currency);
					c5 = double.Parse(dgvCed2.Rows[0].Cells[5].Value.ToString(), NumberStyles.Currency);
					c6 = double.Parse(dgvCed2.Rows[0].Cells[6].Value.ToString(), NumberStyles.Currency);
					c7 = double.Parse(dgvCed2.Rows[0].Cells[7].Value.ToString(), NumberStyles.Currency);
					c8 = double.Parse(dgvCed2.Rows[0].Cells[8].Value.ToString(), NumberStyles.Currency);
					query = "INSERT INTO cedula2 (nombre,porSentajeP,asignacionUP,asignacionIP,precioPromedioP,porsentajeH,asignacionUH,asignacionIH,precioPromedioH,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca,ZapateriasTorreon) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + " ,0,0,0,0,0,0,0,0,0,0,0,'0',1 )";
					checaConexion();
					cmd = new MySqlCommand(query, Conn);
					cmd.ExecuteNonQuery();
					#endregion
				}
				#endregion
			}
			else
			{
				#region comprobar existente
				string q = "Select nombre from cedula1 where nombre='" + Properties.Settings.Default.escenario + "'  and idsucursal=0 and iddivisiones=0 and iddepto=0 and idfamilia=0 and idlinea=0 and idl1=0 and idl2=0 and idl3=0 and idl4=0 and idl5=0 and idl6=0 and marca='0'";
				bool c = true;
				checaConexion();
				cmd = new MySqlCommand(q, Conn);
				reader = cmd.ExecuteReader();
				if (reader.HasRows == true)
				{
					c = true;
				}
				else
				{
					c = false;
				}
				reader.Close();
				#endregion
				if (c == true)
				{
					#region cedula1
					if (solototal == true)
					{
						precioPH = double.Parse(lbppuH.Text, NumberStyles.Currency);
						precioPP = double.Parse(lbppuP.Text, NumberStyles.Currency);
						inventario = double.Parse(tbpp.Text, NumberStyles.Currency);
						rotacion = double.Parse(tbR.Text, NumberStyles.Currency);
						diasinv = double.Parse(lbdi.Text, NumberStyles.Currency);
						VTI = double.Parse(tbvti.Text, NumberStyles.Currency);
						inflacion = double.Parse(tbinflacion.Text, NumberStyles.Currency);
						string u = "UPDATE cedula1 set preciopromedioUP=" + precioPP.ToString() + ",preciopromedioUH=" + precioPH.ToString() + ",Inventariodeseado=" + inventario.ToString() + ",rotacion=" + rotacion.ToString() + ",DiasInv=" + diasinv.ToString() + ",VTI=" + VTI.ToString() + ",Inflacion=" + inflacion + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=0 and iddivisiones=0 and iddepto=0 and idfamilia=0 and idlinea=0 and idl1=0 and idl2=0 and idl3=0 and idl4=0 and idl5=0 and idl6=0 and marca='0'  ";
						checaConexion();
						cmd = new MySqlCommand(u, Conn);
						cmd.ExecuteNonQuery();
					}
					else
					{
						//double imp = double.Parse(dgvCed2.Rows[0].Cells[3].Value.ToString(),NumberStyles.Currency);
						//#region actualizar anterior
						//cmd = new MySqlCommand(actualizar_anteriorI+dgvCed2.Rows[0].Cells[2].Value.ToString()+" "+actualizar_anteriorV+" "+imp.ToString()+" "+actualizar_where, Conn);
						//cmd.ExecuteNonQuery();
						//#endregion
					}
					#endregion
				}
				else
				{
					#region guardarcedula1
					precioPH = double.Parse(lbppuH.Text, NumberStyles.Currency);
					precioPP = double.Parse(lbppuP.Text, NumberStyles.Currency);
					inventario = double.Parse(tbpp.Text, NumberStyles.Currency);
					rotacion = double.Parse(tbR.Text, NumberStyles.Currency);
					diasinv = double.Parse(lbdi.Text, NumberStyles.Currency);
					VTI = double.Parse(tbvti.Text, NumberStyles.Currency);
					inflacion = double.Parse(tbinflacion.Text, NumberStyles.Currency);
					query = "INSERT INTO  cedula1 (nombre,Inventariodeseado,rotacion,preciopromedioUP,preciopromedioUH,DiasInv,VTI,Inflacion,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) VALUES('" + Properties.Settings.Default.escenario + "'," + inventario.ToString() + "," + rotacion.ToString() + "," + precioPP.ToString() + "," + precioPH.ToString() + "," + diasinv.ToString() + "," + VTI.ToString() + ", " + inflacion.ToString() + " ,0,0,0,0,0,0,0,0,0,0,0,'0' );";
					checaConexion();
					cmd = new MySqlCommand(query, Conn);
					cmd.ExecuteNonQuery();
					#endregion
				}
				for (int i = 1; i <= dgvCed2.Rows.Count - 1; i++)
				{
					#region comprobar existente
					q = "Select nombre from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(i - 1)];
					c = true;
					checaConexion();
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					if (reader.HasRows)
					{
						c = true;
					}
					else
					{
						c = false;
					}
					reader.Close();
					#endregion
					if (c == true)
					{
						double c1, c2, c3, c4, c5, c6, c7, c8;
						c1 = double.Parse(dgvCed2.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
						c2 = double.Parse(dgvCed2.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
						c3 = double.Parse(dgvCed2.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
						c4 = double.Parse(dgvCed2.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
						c5 = double.Parse(dgvCed2.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
						c6 = double.Parse(dgvCed2.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
						c7 = double.Parse(dgvCed2.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
						c8 = double.Parse(dgvCed2.Rows[i].Cells[8].Value.ToString(), NumberStyles.Currency);
						string u = "update cedula2 set porsentajeP=" + c1.ToString() + ",asignacionUP=" + c2.ToString() + ",asignacioniP=" + c3.ToString() + ",precioPromedioP=" + c4.ToString() + ",porsentajeH=" + c5.ToString() + ",asignacionUH=" + c6.ToString() + ",asignacionIH=" + c7.ToString() + ",precioPromedioH=" + c8.ToString() + " where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(i - 1)];
						checaConexion();
						cmd = new MySqlCommand(u, Conn);
						cmd.ExecuteNonQuery();
					}
					else
					{
						#region guardar cedula2
						double c1, c2, c3, c4, c5, c6, c7, c8;
						c1 = double.Parse(dgvCed2.Rows[i].Cells[1].Value.ToString(), NumberStyles.Currency);
						c2 = double.Parse(dgvCed2.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
						c3 = double.Parse(dgvCed2.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
						c4 = double.Parse(dgvCed2.Rows[i].Cells[4].Value.ToString(), NumberStyles.Currency);
						c5 = double.Parse(dgvCed2.Rows[i].Cells[5].Value.ToString(), NumberStyles.Currency);
						c6 = double.Parse(dgvCed2.Rows[i].Cells[6].Value.ToString(), NumberStyles.Currency);
						c7 = double.Parse(dgvCed2.Rows[i].Cells[7].Value.ToString(), NumberStyles.Currency);
						c8 = double.Parse(dgvCed2.Rows[i].Cells[8].Value.ToString(), NumberStyles.Currency);
						query = "INSERT INTO cedula2 (nombre,porSentajeP,asignacionUP,asignacionIP,precioPromedioP,porsentajeH,asignacionUH,asignacionIH,precioPromedioH,idsucursal,iddivisiones,iddepto,idfamilia,idlinea,idl1,idl2,idl3,idl4,idl5,idl6,marca) values ('" + Properties.Settings.Default.escenario + "'," + c1.ToString() + "," + c2.ToString() + "," + c3.ToString() + "," + c4.ToString() + "," + c5.ToString() + "," + c6.ToString() + "," + c7.ToString() + "," + c8.ToString() + " " + queryguardar[(i - 1)] + ")";
						checaConexion();
						cmd = new MySqlCommand(query, Conn);
						cmd.ExecuteNonQuery();
						#endregion
					}
				}
			}
		}
		private void celdaEndClick(int reng)
		{
			if (dgvCed2.Rows[reng].Cells[1].Value != null && dgvCed2.Rows[reng].Cells[1].Value.ToString() != "")
			{
				this.Invoke(new Action(() =>
				{
					pronosticopares = double.Parse(tbpp.Text, NumberStyles.Currency);
					Ventatotalimporte = double.Parse(tbvti.Text, NumberStyles.Currency);
					if (totalE == false)
					{
						porciento = 100;
					}
					else
					{
						porciento = double.Parse(dgvCed2.Rows[reng].Cells[1].Value.ToString());
					}
					importe = (porciento * pronosticopares) / 100;
					dgvCed2.Rows[reng].Cells[2].Value = importe.ToString("n0");
					importe = (porciento * Ventatotalimporte) / 100;
					dgvCed2.Rows[reng].Cells[3].Value = importe.ToString("C2");
				}));
			}
		}
		private void dgvCed2_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
		{
            if (solototal == false)
            {
                if (dgvCed2.Rows[e.RowIndex].Cells[e.ColumnIndex] == dgvCed2.Rows[e.RowIndex].Cells[1] && e.RowIndex >= 0)
                {
                    if (dgvCed2.Rows[e.RowIndex].Cells[1].Value != null)
                    {
                        double imp = 0;
                        double unidm = 0;
                        double unid = 0;
                        pronosticopares = double.Parse(lbPPaux.Text, NumberStyles.Currency);
                        Ventatotalimporte = double.Parse(lbvtii.Text, NumberStyles.Currency);
                        porciento = double.Parse(dgvCed2.Rows[e.RowIndex].Cells[1].Value.ToString());
                        importe = (porciento * pronosticopares) / 100;
                        dgvCed2.Rows[e.RowIndex].Cells[2].Value = importe.ToString("n0");
                        importe = (porciento * Ventatotalimporte) / 100;
                        dgvCed2.Rows[e.RowIndex].Cells[3].Value = importe.ToString("C2");

                        for (int i = 1; i <= dgvCed2.Rows.Count - 1; i++)
                        {
                            if (dgvCed2.Rows[i].Cells[3].Value != null)
                            {
                                imp += double.Parse(dgvCed2.Rows[i].Cells[3].Value.ToString(), NumberStyles.Currency);
                                unid += double.Parse(dgvCed2.Rows[i].Cells[2].Value.ToString(), NumberStyles.Currency);
                            }
                        }
                        unidm = double.Parse(dgvCed2.Rows[0].Cells[2].Value.ToString()) / double.Parse(tbR.Text);
                        tbpM.Text = unidm.ToString("n0");
                        imp = double.Parse(dgvCed2.Rows[0].Cells[3].Value.ToString(), NumberStyles.Currency);
                        tbvti.Text = imp.ToString("C2");
                        tbpp.Text = unid.ToString("n0");
                        m_RenglonTotal();
                    }
                }
            }
		}
		private void dgvCed2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
            if (solototal != true)
            {
                porcentajeA = double.Parse(dgvCed2.Rows[e.RowIndex].Cells[1].Value.ToString());
            }
		}
		private void recalculoU(int renglon)
		{
			string q = "";
			double unidadesAnterior = 0;
			double unidadesModificadas = 0;
			double importeAnterior = 0;
			double importeModificadas = 0;
			double factorU = 0;
			double factorI = 0;
			double diferenciaU = 0;
			double diferenciaI = 0;
            string qupdateU = "";
			switch(pocision)
			{
				case 1:
					#region modificar sucursales
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon-1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while(reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(),NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia arriba
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-"+diferenciaU+" , asignacionIP=asignacionIP-"+diferenciaI+" where nombre='"+Properties.Settings.Default.escenario+"' and ZapateriasTorreon=1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();                     
					/////////////////////////////////////
					qupdateU = "";
					qupdateU = "update cedula1 set Inventariodeseado=Inventariodeseado-"+diferenciaU+" ,VTI=VTI-"+diferenciaI+" where nombre='"+Properties.Settings.Default.escenario+"' ";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					#endregion
					#endregion
					break;
				case 2:
					#region modificar Divisiones
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia arriba
					///////////////////////////////////////   Total
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-"+diferenciaU+" , asignacionIP=asignacionIP-"+diferenciaI+" where nombre='"+Properties.Settings.Default.escenario+"' and ZapateriasTorreon=1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();                   
					/////////////////////////////////////// Total
					qupdateU = "";
					qupdateU = "update cedula1 set Inventariodeseado=Inventariodeseado-"+diferenciaU+" ,VTI=VTI-"+diferenciaI+" where nombre='"+Properties.Settings.Default.escenario+"' ";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////////  Sucursal
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal="+seleccion_sucursal.ToString()+" and iddivisiones=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();                    
					#endregion
					#endregion
					break;
				case 3:
					#region modificar Departamento
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia Arriba
					///////////////////////////////////////   Total
					qupdateU = "update cedula1 set Inventariodeseado=Inventariodeseado-" + diferenciaU + " ,VTI=VTI-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' ";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////////  Total
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////////  Sucursal
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Division
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones="+seleccion_division.ToString()+" and iddepto=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					#endregion
					#endregion
					break;
				case 4:
					#region modificar Familia
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia Arriba
					///////////////////////////////////////   Total
					qupdateU = "update cedula1 set Inventariodeseado=Inventariodeseado-" + diferenciaU + " ,VTI=VTI-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' ";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////////  Total
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////////  Sucursal
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Division
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Depto
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto="+seleccion_depto.ToString()+" and idfamilia=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					#endregion
					#endregion
					break;
				case 5:
					#region modificar Linea
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia Arriba
					///////////////////////////////////////   Total
					qupdateU = "update cedula1 set Inventariodeseado=Inventariodeseado-" + diferenciaU + " ,VTI=VTI-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' ";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////////  Total
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////////  Sucursal
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Division
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Depto
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					////////////////////////////////////// Familia
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia="+seleccion_familia.ToString()+" and idlinea=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					#endregion
					#endregion
					break;
				case 6:
					#region modificar Linea 1
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia Arriba
					///////////////////////////////////////   Total
					qupdateU = "update cedula1 set Inventariodeseado=Inventariodeseado-" + diferenciaU + " ,VTI=VTI-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' ";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////////  Total
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////////  Sucursal
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Division
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Depto
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					////////////////////////////////////// Familia
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Linea
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea="+seleccion_linea.ToString()+" and idl1=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					#endregion
					#endregion
					break;
				case 7:
					#region modificar Linea 2
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia Arriba
					///////////////////////////////////////   Total
					qupdateU = "update cedula1 set Inventariodeseado=Inventariodeseado-" + diferenciaU + " ,VTI=VTI-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' ";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////////  Total
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////////  Sucursal
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Division
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Depto
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					////////////////////////////////////// Familia
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Linea
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Linea1
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1="+seleccion_l1.ToString()+" and idl2=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					#endregion
					#endregion
					break;
				case 8:
					#region modificar Linea 3
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia Arriba
					///////////////////////////////////////   Total
					qupdateU = "update cedula1 set Inventariodeseado=Inventariodeseado-" + diferenciaU + " ,VTI=VTI-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' ";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////////  Total
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////////  Sucursal
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Division
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Depto
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					////////////////////////////////////// Familia
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Linea
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Linea1
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=" + seleccion_l1.ToString() + " and idl2=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					////////////////////////////////////// Linea2
					#endregion
					#endregion
					break;
				case 9:
					#region modificar Linea 4
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia Arriba
					///////////////////////////////////////   Total
					qupdateU = "update cedula1 set Inventariodeseado=Inventariodeseado-" + diferenciaU + " ,VTI=VTI-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' ";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////////  Total
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////////  Sucursal
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Division
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Depto
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					////////////////////////////////////// Familia
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Linea
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Linea1
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=" + seleccion_l1.ToString() + " and idl2=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					////////////////////////////////////// Linea2
					 qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=" + seleccion_l1.ToString() + " and idl2="+seleccion_l2.ToString()+" and idl3=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////// Linea 3
					#endregion
					#endregion
					break;
				case 10:
					#region modificar Linea 5
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia Arriba
					///////////////////////////////////////   Total
					qupdateU = "update cedula1 set Inventariodeseado=Inventariodeseado-" + diferenciaU + " ,VTI=VTI-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' ";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////////  Total
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////////  Sucursal
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Division
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Depto
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					////////////////////////////////////// Familia
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Linea
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Linea1
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=" + seleccion_l1.ToString() + " and idl2=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					////////////////////////////////////// Linea2
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=" + seleccion_l1.ToString() + " and idl2=" + seleccion_l2.ToString() + " and idl3=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////// Linea 3
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=" + seleccion_l1.ToString() + " and idl2=" + seleccion_l2.ToString() + " and idl3="+seleccion_l3.ToString()+" and idl4=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////// Linea 4
					#endregion
					#endregion
					break;
				case 11:
					#region modificar Linea 6
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia Arriba
					///////////////////////////////////////   Total
					qupdateU = "update cedula1 set Inventariodeseado=Inventariodeseado-" + diferenciaU + " ,VTI=VTI-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' ";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////////  Total
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////////  Sucursal
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Division
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Depto
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					////////////////////////////////////// Familia
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Linea
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Linea1
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=" + seleccion_l1.ToString() + " and idl2=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					////////////////////////////////////// Linea2
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=" + seleccion_l1.ToString() + " and idl2=" + seleccion_l2.ToString() + " and idl3=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////// Linea 3
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=" + seleccion_l1.ToString() + " and idl2=" + seleccion_l2.ToString() + " and idl3=" + seleccion_l3.ToString() + " and idl4=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////// Linea 4
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=" + seleccion_l1.ToString() + " and idl2=" + seleccion_l2.ToString() + " and idl3=" + seleccion_l3.ToString() + " and idl4=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////// Linea 5
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=" + seleccion_l1.ToString() + " and idl2=" + seleccion_l2.ToString() + " and idl3=" + seleccion_l3.ToString() + " and idl4="+seleccion_l4.ToString()+" and idl5=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////// Linea 6
					#endregion
					#endregion
					break;
				case 12:
					#region modificar marca
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia Arriba
					///////////////////////////////////////   Total
					qupdateU = "update cedula1 set Inventariodeseado=Inventariodeseado-" + diferenciaU + " ,VTI=VTI-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' ";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////////  Total
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////////  Sucursal
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Division
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Depto
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					////////////////////////////////////// Familia
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Linea
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Linea1
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=" + seleccion_l1.ToString() + " and idl2=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					////////////////////////////////////// Linea2
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=" + seleccion_l1.ToString() + " and idl2=" + seleccion_l2.ToString() + " and idl3=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////// Linea 3
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=" + seleccion_l1.ToString() + " and idl2=" + seleccion_l2.ToString() + " and idl3=" + seleccion_l3.ToString() + " and idl4=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////// Linea 4
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=" + seleccion_l1.ToString() + " and idl2=" + seleccion_l2.ToString() + " and idl3=" + seleccion_l3.ToString() + " and idl4=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////// Linea 5
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=" + seleccion_l1.ToString() + " and idl2=" + seleccion_l2.ToString() + " and idl3=" + seleccion_l3.ToString() + " and idl4=" + seleccion_l4.ToString() + " and idl5=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////// Linea 6
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=" + seleccion_l1.ToString() + " and idl2=" + seleccion_l2.ToString() + " and idl3=" + seleccion_l3.ToString() + " and idl4=" + seleccion_l4.ToString() + " and idl5="+seleccion_l5.ToString()+" and idl6=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					#endregion
					#endregion
					break;
				case 13:  //// Total Departamento
					#region modificar total Depto
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia Arriba
					///////////////////////////////////////   Total
					qupdateU = "update cedula1 set Inventariodeseado=Inventariodeseado-" + diferenciaU + " ,VTI=VTI-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' ";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////////  Total
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////////  Sucursal
					//qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + "and iddivisiones=-1";
					//cmd = new MySqlCommand(qupdateU, Conn);
					//cmd.ExecuteNonQuery();
					///////////////////////////////////////// Division
					//qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + "and iddivisiones="+seleccion_division.ToString()+" and iddepto=-1";
					//cmd = new MySqlCommand(qupdateU, Conn);
					//cmd.ExecuteNonQuery();
					#endregion
					#endregion
					break;
				case 14: /// modificar depto -- marca
					#region modificar depto Marca
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia Arriba
					///////////////////////////////////////   Total
					qupdateU = "update cedula1 set Inventariodeseado=Inventariodeseado-" + diferenciaU + " ,VTI=VTI-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' ";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////////  Total
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////////  Sucursal
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Division
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones="+seleccion_division.ToString()+" and iddepto=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Depto
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					#endregion
					#endregion
					break;
				case 15: /// modificar l1 -- marca
					#region modificar l1 marca
						#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia Arriba
					///////////////////////////////////////   Total
					qupdateU = "update cedula1 set Inventariodeseado=Inventariodeseado-" + diferenciaU + " ,VTI=VTI-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' ";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////////  Total
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////////  Sucursal
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Division
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Depto
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					////////////////////////////////////// Familia
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Linea
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea="+seleccion_linea.ToString()+" and idl1=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////// Linea1
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=" + seleccion_division.ToString() + " and iddepto=" + seleccion_depto.ToString() + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=" + seleccion_l1.ToString() + " and idl2=-1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					#endregion
					#endregion
					break;
				case 16: /// modificar total marca
					#region modificar total marca
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia Arriba
					///////////////////////////////////////   Total
					qupdateU = "update cedula1 set Inventariodeseado=Inventariodeseado-" + diferenciaU + " ,VTI=VTI-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' ";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					///////////////////////////////////////  Total
					qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
					cmd = new MySqlCommand(qupdateU, Conn);
					cmd.ExecuteNonQuery();
					/////////////////////////////////////////  Sucursal
					//qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + "and iddivisiones=-1";
					//cmd = new MySqlCommand(qupdateU, Conn);
					//cmd.ExecuteNonQuery();
					///////////////////////////////////////// Division
					//qupdateU = "update cedula2 set asignacionUP=asignacionUP-" + diferenciaU + " , asignacionIP=asignacionIP-" + diferenciaI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + "and iddivisiones="+seleccion_division.ToString()+" and iddepto=-1";
					//cmd = new MySqlCommand(qupdateU, Conn);
					//cmd.ExecuteNonQuery();
					#endregion
					#endregion 
					break;
			}
			//guardarP();
		}
		private void recalculoD(int renglon)
		{
			//string qupdateU = "";
			string qupdateD = "";
			string q = "";
			double unidadesAnterior = 0;
			double unidadesModificadas = 0;
			double importeAnterior = 0;
			double importeModificadas = 0;
			double factorU = 0;
			double factorI = 0;
			double diferenciaU = 0;
			double diferenciaI = 0;
			switch (pocision)
			{
				case 1:
					#region modificar sucursales
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia abajo
					qupdateD = "update  cedula2 set asignacionUP=asignacionUP/" + factorU + " , asignacionIP=asignacionIP/" + factorI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + idd[renglon].ToString() + " and iddivisiones<>-1";
					cmd = new MySqlCommand(qupdateD, Conn);
					cmd.ExecuteNonQuery();
					#endregion
					#endregion
					break;
				case 2:
					#region modificar Divisiones
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia abajo
					qupdateD = "update cedula2 SET asignacionUP=asignacionUP/" + factorU + " , asignacionIP=asignacionIP/" + factorI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal + " and iddivisiones=" + idd[renglon].ToString() + " and iddepto<>-1";
					cmd = new MySqlCommand(qupdateD, Conn);
					cmd.ExecuteNonQuery();
					#endregion
					#endregion
					break;
				case 3:
					#region modificar Departamento
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia abajo
					qupdateD = "update cedula2 set asignacionUP=asignacionUP/" + factorU + " , asignacionIP=asignacionIP/" + factorI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal + " and iddivisiones=" + seleccion_division + " and iddepto=" + idd[renglon] + " and idfamilia<>-1";
					cmd = new MySqlCommand(qupdateD, Conn);
					cmd.ExecuteNonQuery();
					#endregion
					#endregion
					break;
				case 4:
					#region modificar Familia
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia abajo
					qupdateD = "update cedula2 set asignacionUP=asignacionUP/" + factorU + " , asignacionIP=asignacionIP/" + factorI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal + " and iddivisiones=" + seleccion_division + " and iddepto=" + seleccion_depto + " and idfamilia=" + idd[renglon].ToString() + " and idlinea<>-1";
					cmd = new MySqlCommand(qupdateD, Conn);
					cmd.ExecuteNonQuery();
					#endregion
					#endregion
					break;
				case 5:
					#region modificar Linea
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia abajo
					qupdateD = "update cedula2 set asignacionUP=asignacionUP/" + factorU + " , asignacionIP=asignacionIP/" + factorI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal + " and iddivisiones=" + seleccion_division + " and iddepto=" + seleccion_depto + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + idd[renglon].ToString() + " and idl1<>-1";
					cmd = new MySqlCommand(qupdateD, Conn);
					cmd.ExecuteNonQuery();
					#endregion
					#endregion
					break;
				case 6:
					#region modificar Linea 1
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia abajo
					qupdateD = "update cedula2 set asignacionUP=asignacionUP/" + factorU + " , asignacionIP=asignacionIP/" + factorI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal + " and iddivisiones=" + seleccion_division + " and iddepto=" + seleccion_depto + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=" + idd[renglon].ToString() + " and idl2<>-1";
					cmd = new MySqlCommand(qupdateD, Conn);
					cmd.ExecuteNonQuery();
					#endregion
					#endregion
					break;
				case 7:
					#region modificar Linea 2
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia abajo
					qupdateD = "update cedula2 set asignacionUP=asignacionUP/" + factorU + " , asignacionIP=asignacionIP/" + factorI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal + " and iddivisiones=" + seleccion_division + " and iddepto=" + seleccion_depto + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=" + seleccion_l1.ToString() + " and idl2=" + idd[renglon].ToString() + " and idl3<>-1";
					cmd = new MySqlCommand(qupdateD, Conn);
					cmd.ExecuteNonQuery();
					#endregion
					#endregion
					break;
				case 8:
					#region modificar Linea 3
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia abajo
					qupdateD = "update cedula2 set asignacionUP=asignacionUP/" + factorU + " , asignacionIP=asignacionIP/" + factorI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal + " and iddivisiones=" + seleccion_division + " and iddepto=" + seleccion_depto + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=" + seleccion_l1.ToString() + " and idl2=" + idd[renglon].ToString() + " and idl3<>-1";
					cmd = new MySqlCommand(qupdateD, Conn);
					cmd.ExecuteNonQuery();
					#endregion
					#endregion
					break;
				case 9:
					#region modificar Linea 4
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia abajo
					qupdateD = "update cedula2 set asignacionUP=asignacionUP/" + factorU + " , asignacionIP=asignacionIP/" + factorI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal + " and iddivisiones=" + seleccion_division + " and iddepto=" + seleccion_depto + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=" + seleccion_l1.ToString() + " and idl2=" + seleccion_l2 + " and idl3=" + idd[renglon].ToString() + " and idl4<>-1";
					cmd = new MySqlCommand(qupdateD, Conn);
					cmd.ExecuteNonQuery();
					#endregion
					#endregion
					break;
				case 10:
					#region modificar Linea 5
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia abajo
					qupdateD = "update cedula2 set asignacionUP=asignacionUP/" + factorU + " , asignacionIP=asignacionIP/" + factorI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal + " and iddivisiones=" + seleccion_division + " and iddepto=" + seleccion_depto + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=" + seleccion_l1.ToString() + " and idl2=" + seleccion_l2 + " and idl3=" + seleccion_l3.ToString() + " and idl4=" + idd[renglon].ToString() + " and  idl5<>-1";
					cmd = new MySqlCommand(qupdateD, Conn);
					cmd.ExecuteNonQuery();
					#endregion
					#endregion
					break;
				case 11:
					#region modificar Linea 6
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia abajo
					qupdateD = "update cedula2 set asignacionUP=asignacionUP/" + factorU + " , asignacionIP=asignacionIP/" + factorI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal + " and iddivisiones=" + seleccion_division + " and iddepto=" + seleccion_depto + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=" + seleccion_l1.ToString() + " and idl2=" + seleccion_l2 + " and idl3=" + seleccion_l3.ToString() + " and idl4=" + seleccion_l4.ToString() + " and  idl5=" + idd[renglon].ToString() + " and idl6<>-1";
					cmd = new MySqlCommand(qupdateD, Conn);
					cmd.ExecuteNonQuery();
					#endregion
					#endregion
					break;
				case 12:
					#region modificar marca
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia abajo
					qupdateD = "update cedula2 set asignacionUP=asignacionUP/" + factorU + " , asignacionIP=asignacionIP/" + factorI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal + " and iddivisiones=" + seleccion_division + " and iddepto=" + seleccion_depto + " and idfamilia=" + seleccion_familia.ToString() + " and idlinea=" + seleccion_linea.ToString() + " and idl1=" + seleccion_l1.ToString() + " and idl2=" + seleccion_l2 + " and idl3=" + seleccion_l3.ToString() + " and idl4=" + seleccion_l4.ToString() + " and  idl5=" + seleccion_l5.ToString() + " and idl6=" + idd[renglon].ToString() + " and marca<>'-1'";
					cmd = new MySqlCommand(qupdateD, Conn);
					cmd.ExecuteNonQuery();
					#endregion
					#endregion
					break;
				case 13: ///////////////////////////// salto depto
					#region  modificar total depto
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia abajo
					qupdateD = "update cedula2 set asignacionUP=asignacionUP/" + factorU + " , asignacionIP=asignacionIP/" + factorI + " where nombre='" + Properties.Settings.Default.escenario + "' and iddepto=" + idd[renglon] + " and ZapateriasTorreon<>1";
					cmd = new MySqlCommand(qupdateD, Conn);
					cmd.ExecuteNonQuery();
					#endregion
					#endregion
					break;
				case 14: //////////////////////////// depto marca
					#region  modificar depto marca
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia abajo
					qupdateD = "update cedula2 set asignacionUP=asignacionUP/" + factorU + " , asignacionIP=asignacionIP/" + factorI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal + " and iddivisiones=" + seleccion_division + " and iddepto=" +seleccion_depto+" and idfamilia<>-1 and marca='"+idd[renglon]+"'";
					cmd = new MySqlCommand(qupdateD, Conn);
					cmd.ExecuteNonQuery();
					#endregion
					#endregion
					break;
				case 15: //////////////////////////// l1 marca
					#region  modificar l1 marca
					 #region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia abajo
					qupdateD = "update cedula2 set asignacionUP=asignacionUP/" + factorU + " , asignacionIP=asignacionIP/" + factorI + " where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal + " and iddivisiones=" + seleccion_division + " and iddepto=" +seleccion_depto+" and idfamilia="+seleccion_familia+" and idlinea="+seleccion_linea+" and idl1="+seleccion_l1+" and marca='"+idd[renglon]+"'";
					cmd = new MySqlCommand(qupdateD, Conn);
					cmd.ExecuteNonQuery();
					#endregion
					#endregion
					break;
				case 16: ///////////////////////////  total marca
					#region modificar total marca
					#region valorAnterior
					q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[(renglon - 1)];
					cmd = new MySqlCommand(q, Conn);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						unidadesAnterior = double.Parse(reader["asignacionUP"].ToString());
						importeAnterior = double.Parse(reader["asignacionIP"].ToString());
					}
					reader.Close();
					#endregion
					unidadesModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[2].Value.ToString());
					importeModificadas = double.Parse(dgvCed2.Rows[renglon].Cells[3].Value.ToString(), NumberStyles.Currency);
					if (unidadesAnterior >= 1)
					{
						factorU = unidadesAnterior / unidadesModificadas;
						diferenciaU = unidadesAnterior - unidadesModificadas;
						factorI = importeAnterior / importeModificadas;
						diferenciaI = importeAnterior - importeModificadas;
					}
					else
					{
						diferenciaU = 0;
						factorU = 1;
						factorI = 1;
						diferenciaI = 0;
					}
					#region modificar hacia abajo
					qupdateD = "update  cedula2 set asignacionUP=asignacionUP/" + factorU + " , asignacionIP=asignacionIP/" + factorI + " where nombre='" + Properties.Settings.Default.escenario + "' and marca='"+idd[renglon]+"' ";
					cmd = new MySqlCommand(qupdateD, Conn);
					cmd.ExecuteNonQuery();
					#endregion
					#endregion
					break;

			}
			//guardarP();
		}
		private void bgwNormal_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
            this.Invoke(new Action(() =>
            {
                waitingbar.Visible = true;
                waitingbar.StartWaiting();
            }));
			bloquearEstructura();
			if(bgw_Proyectar.IsBusy==false)
			{
				comprobarCedulas();
				m_RenglonTotal();
			}
		}
		private void bgwNormal_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			bgwNormal.Dispose();
			desbloquearEstructura();
            waitingbar.Visible = false;
            waitingbar.StopWaiting();
		}
		private void OnBgw_ProyectarRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			desbloquearEstructura();
            waitingbar.Visible = false;
            waitingbar.StopWaiting();
            timer1.Stop();
		}
		private void OnReajustarClick(object sender, EventArgs e)
		{
            if (solototal != true || dgvCed2.Rows.Count >= 2)
            {
                double porcentajeT = double.Parse(dgvCed2.Rows[0].Cells[1].Value.ToString());
                if (porcentajeT == 100)
                {
                    for (int x = 1; x <= dgvCed2.Rows.Count - 1; x++)
                    {
                        #region  sacar valor anterior
                        string q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + " '" + querycargar[(x - 1)] + "";
                        cmd = new MySqlCommand(q, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            porcentajeA = double.Parse(reader["porsentajeP"].ToString());
                        }
                        reader.Close();
                        #endregion
                        double porcentajeM = double.Parse(dgvCed2.Rows[x].Cells[1].Value.ToString());
                        if (porcentajeM != porcentajeA)
                        {
                            recalculoU(x);
                            recalculoD(x);
                        }
                    }
                    guardarP();
                }
                else
                {

                    for (int x = 1; x <= dgvCed2.Rows.Count - 1; x++)
                    {
                        double porcentaje = double.Parse(dgvCed2.Rows[x].Cells[1].Value.ToString());
                        porcentaje = (porcentaje / porcentajeT) * 100;
                        dgvCed2.Rows[x].Cells[1].Value = porcentaje.ToString("n2");
                        celdaEndClick(x);

                    }
                    m_RenglonTotal();
                    for (int x = 1; x <= dgvCed2.Rows.Count - 1; x++)
                    {
                        #region  sacar valor anterior
                        string q = "Select * from cedula2 where nombre='" + Properties.Settings.Default.escenario + " '" + querycargar[(x - 1)] + "";
                        cmd = new MySqlCommand(q, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            porcentajeA = double.Parse(reader["porsentajeP"].ToString());
                        }
                        reader.Close();
                        #endregion
                        double porcentajeM = double.Parse(dgvCed2.Rows[x].Cells[1].Value.ToString());
                        if (porcentajeM != porcentajeA)
                        {
                            recalculoU(x);
                            recalculoD(x);
                        }
                    }
                    guardarP();

                }
                MessageBox.Show("Listo");
            }
		}
		private void OnDuplicarSucursaltoolStripMenuItem2Click(object sender, EventArgs e)
		{
			bgw_replicarSuc.RunWorkerAsync();
		}
		private void OnBgw_replicarSucDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			ReplicarSucursalCed2 ob = new ReplicarSucursalCed2();
			ob.ShowDialog();
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
                    catch { }
				}
			}
		}
		private void proyectar(object sender, EventArgs e)
		{
            Application.DoEvents();
			bloquearEstructura();
			this.Invoke(new Action(() =>
			{
				pbGenerarCedulas.Value = 0;
			}));
			generando = true;
			if (generando == true)
			{
                this.Invoke(new Action(() =>
               {
                   cbSucursales_DropDown(sender, e);
               }));
				// arbol marcas
                 
				cbMarca_DropDown(sender, e);
              
				cbMarca.SelectedIndex = 0;
				guardarP();
				#region
				this.Invoke(new Action(() =>
				{
					cbSucursales_DropDown(sender, e);
				}));

				// arbol depto
				//this.Invoke(new Action(() =>
				//{
					cbDepto_DropDown(sender, e);
				   
						cbDepto.SelectedIndex = 0;
						guardarP();
					
					//this.Refresh();
			   // }));


				//sucursales
				this.Invoke(new Action(() =>
				{
					pbGenerarCedulas.Value = 1;
					cbSucursales_DropDown(sender, e);
				}));

				if (cbSucursales.Items.Count != -1)
					for (int ss = 0; ss < cbSucursales.Items.Count; ss++)
					{
						this.Invoke(new Action(() =>
						{
							cbSucursales_DropDown(sender, e);
							cbSucursales.SelectedIndex = ss;
							if (ss == 0)
							{
								guardarP();
							}
							this.Refresh();
						}));

						if (ss != 0)
						{
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
											guardarP();
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
																							guardarP();
																						}

																						this.Refresh();

																					}));

																					if (cl1 != 0&&cbL2.Items.Count>=1)
																					{
																						cbMarca_DropDown(sender, e);
																						if (cbMarca.Items.Count != -1)
																						{
																							cbMarca_DropDown(sender, e);
																							cbMarca.SelectedIndex = 0;
																							guardarP();
																						}
																						//l2
																						this.Invoke(new Action(() =>
																						{
																							cbL2_DropDown(sender, e);
																						}));
																						if (cbL2.Items.Count != -1 &&cbL2.Items.Count>=1)
																							for (int cl2 = 0; cl2 < cbL2.Items.Count; cl2++)
																							{
																								this.Invoke(new Action(() =>
																								{
																									cbL2_DropDown(sender, e);
																									cbL2.SelectedIndex = cl2;
																									if (cl2 == 0)
																									{
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
																									if (cbL3.Items.Count != -1 && cbL3.Items.Count>=2)
																										for (int cl3 = 0; cl3 < cbL3.Items.Count; cl3++)
																										{
																											this.Invoke(new Action(() =>
																											{
																												cbL3_DropDown(sender, e);
																												cbL3.SelectedIndex = cl3;
																												if (cl3 == 0)
																												{
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
																												if (cbL4.Items.Count != -1&&cbL4.Items.Count>=2)
																													for (int cl4 = 0; cl4 < cbL4.Items.Count; cl4++)
																													{
                                                                                                                        this.Invoke(new Action(() =>
                                                                                                                        {
                                                                                                                            cbL4_DropDown(sender, e);
                                                                                                                            cbL4.SelectedIndex = cl4;
                                                                                                                            if (cl4 == 0)
                                                                                                                            {
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
																															if (cbL5.Items.Count != -1&&cbL5.Items.Count>=2)
																																for (int cl5 = 0; cl5 < cbL5.Items.Count; cl5++)
																																{
																																	this.Invoke(new Action(() =>
																																	{
																																		cbL5_DropDown(sender, e);
																																		cbL5.SelectedIndex = cl5;
																																		if (cl5 == 0)
																																		{
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
							pbGenerarCedulas.Value = ((ss + 1) * (100 / cbSucursales.Items.Count));
						}

					}//suc
			  
				pbGenerarCedulas.Value = 9;
				this.Refresh();
				//////////////////////////////

				#endregion      
			}
			cbSucursales_DropDown(sender, e);
            cbSucursales.SelectedIndex = 0;
			generando = false;
            this.Invoke(new Action(() =>
               {
                   PanelCedulafinalizada.Visible = true;
               }));
			#region otras cedulas
            try
            {
                Cedula2 c2 = new Cedula2(true);
                c2.ShowDialog();
                //c2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //try
            //{
            //    Cedula3 c3 = new Cedula3(true);
            //    c3.Show();
            //    //c3.Close();
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //pbGenerarCedulas.Value = 5;
            //try
            //{
            //    Cedula7 c7 = new Cedula7(true);
            //    c7.Show();
            //    //c7.Close();
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
		   
            //pbGenerarCedulas.Value = 15;
            //try
            //{
            //    Cedula8 c8 = new Cedula8(true);
            //    c8.Show();
            //    //c8.Close();
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
#endregion
			MessageBox.Show("Finalizado");
            PanelCedulafinalizada.Visible = false;
		}
		private void OnBgw_reconectarDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			reconectarF r = new reconectarF();
			r.ShowDialog();
			while (Conn.State != System.Data.ConnectionState.Open)
			{
				try
				{
					Conn.Open();
				}
				catch
				{
					Conn.Close();
					Conn.Open();
				}				
			}
		}
		private void OnBgw_reconectarProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
		{
			reconectarF r = new reconectarF();
			r.ShowDialog();
			if(e.ProgressPercentage==0)
			{
				r.reintentos(e.ProgressPercentage);
			}
			else
			{
				r.reintentos(e.ProgressPercentage);
			}
		}
		private void bloquearEstructura()
		{
            this.Invoke(new Action(() =>
            {
                toolStripMenuItem1.Enabled = false;
			    cbSucursales.Enabled = false;
			    estructuraToolStripMenuItem.Enabled = false;
            }));
			
		}
		private void desbloquearEstructura()
		{
            this.Invoke(new Action(() =>
            {
                toolStripMenuItem1.Enabled = true;
			    cbSucursales.Enabled = true;
			    estructuraToolStripMenuItem.Enabled = true;
            }));
			
		}
        private void consultaHistorico()
        {
            int i = 1; string whereQ = "";
            double importe = 0, unidades = 0, preciop = 0;
            string ifnull = "";
            if(where!="")
            {
                if (where.Contains("e.iddivisiones=1"))
                {
                    whereQ = " Where  " + where;
                }
                else
                {
                    whereQ = " Where and iddivisiones=1 " + where;
                }
            }
            else
            {
                whereQ = "";
            }
            if(soloSuc==false)
            {
                ifnull = "e."+groupby;
            }
            else
            {
                ifnull = "''";
            }
            string consulta = "";
            if (solototal == true)
            {
                consulta = "SELECT IFNULL(SUM(sub.importe),0) AS importe, IFNULL(SUM(sub.unidades),0) AS unidades,IFNULL(SUM(sub.prom),0)  AS promedio FROM estarticulo e LEFT JOIN (SELECT idarticulo,SUM(impllenoregsiva+impllenopromsiva+impllenonormalsiva+impllenodesctosiva)/SUM(ctdregalo+ctdprom+ctdnormal+ctddescto+ctdcan) AS prom,SUM(impllenoregsiva+impllenopromsiva+impllenonormalsiva+impllenodesctosiva)AS importe,SUM(ctdregalo+ctdprom+ctdnormal+ctddescto+ctdcan) as unidades  FROM  ventasbase v INNER JOIN fecha f ON v.idfecha = f.idfecha  AND F.FECHA BETWEEN '" + FechaAI.ToString("yyyy-MM-dd") + "' AND '" + FechaAF.ToString("yyyy-MM-dd") + "'  inner JOIN sucursal AS s ON v.idsucursal=s.idsucursal  AND s.visible='S') AS sub ON e.idarticulo = sub.idarticulo where e.iddivisiones=1";
            }
            else
            {
                 consulta = "SELECT IFNULL(SUM(sub.importe),0) AS importe, IFNULL(SUM(sub.unidades),0) AS unidades,IFNULL(SUM(sub.prom),0)  AS promedio,IFNULL(sub." + groupby + "," + ifnull + ") AS grupo FROM estarticulo e LEFT JOIN (SELECT idarticulo,SUM(impllenoregsiva+impllenopromsiva+impllenonormalsiva+impllenodesctosiva)/SUM(ctdregalo+ctdprom+ctdnormal+ctddescto+ctdcan) AS prom,SUM(impllenoregsiva+impllenopromsiva+impllenonormalsiva+impllenodesctosiva)AS importe,SUM(ctdregalo+ctdprom+ctdnormal+ctddescto+ctdcan) as unidades ,v." + groupby + " FROM  ventasbase v INNER JOIN fecha f ON v.idfecha = f.idfecha  AND F.FECHA BETWEEN '" + FechaAI.ToString("yyyy-MM-dd") + "' AND '" + FechaAF.ToString("yyyy-MM-dd") + "'  inner JOIN sucursal AS s ON v.idsucursal=s.idsucursal  AND s.visible='S' " + whereLeft + " GROUP BY v." + groupby + ") AS sub ON e.idarticulo = sub.idarticulo " + whereQ + " GROUP BY grupo";
            }
            cmd = new MySqlCommand(consulta, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["promedio"].ToString() != "")
                {
                    preciop = double.Parse(reader["promedio"].ToString());
                }
                else
                {
                    preciop = 0;
                }
                if (reader["importe"].ToString() != "")
                {
                    importe = double.Parse(reader["importe"].ToString());
                }
                else
                {
                    importe = 0;
                }
                if (reader["unidades"].ToString() != "")
                {
                    unidades = double.Parse(reader["unidades"].ToString());
                }
                else
                {
                    unidades = 0;
                }
                if(solototal==true)
                {
                    this.Invoke(new Action(() =>
                    {
                        dgvCed2.Rows[0].Cells[6].Value = unidades.ToString("n0");
                        dgvCed2.Rows[0].Cells[7].Value = importe.ToString("C2");
                        dgvCed2.Rows[0].Cells[8].Value = preciop.ToString("C2");
                        dgvCed2.Rows[0].Cells[8].Value = preciop.ToString("C2");
                    }));
                }
                else
                {
                    bool falso=false;
                    int x = 1;
                    while(falso==false)
                    {
                        if (reader["grupo"].ToString() == "")
                        {
                            falso = true;
                        }
                        else
                        {
                            if (i <= dgvCed2.Rows.Count)
                            {
                                if (reader["grupo"].ToString() == idd[x])
                                {
                                    this.Invoke(new Action(() =>
                                    {
                                        dgvCed2.Rows[i].Cells[6].Value = unidades.ToString("n0");
                                        dgvCed2.Rows[i].Cells[7].Value = importe.ToString("C2");
                                        dgvCed2.Rows[i].Cells[8].Value = preciop.ToString("C2");
                                        dgvCed2.Rows[i].Cells[4].Value = preciop.ToString("C2");
                                    }));
                                    falso = true;
                                    i++;
                                }
                                else
                                {
                                    this.Invoke(new Action(() =>
                                    {
                                        dgvCed2.Rows[i].Cells[6].Value = "0";
                                        dgvCed2.Rows[i].Cells[7].Value = "$0";
                                        dgvCed2.Rows[i].Cells[8].Value = "$0";
                                        dgvCed2.Rows[i].Cells[4].Value = "$0";
                                    }));
                                }
                            }
                            else
                            {
                                falso = true;
                            }
                        }
                        x++;
                    }
                }
            }
            reader.Close();
            nulos();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ticks++;
            this.Invoke(new Action(() =>
            {
                waitingbar.TabIndex = ticks;
            }));
            if (ticks == 100)
            {
                this.Invoke(new Action(() =>
                {
                    timer1.Enabled = false;
                }));
                ticks = 0;
            }
        }
        private void Generartoolstrip_Click(object sender, EventArgs e)
        {
            string q = "Select nombre from cedula1 where nombre='" + Properties.Settings.Default.escenario + "' ";
            cmd = new MySqlCommand(q, Conn);
            reader = cmd.ExecuteReader();
            bool x = reader.HasRows;
            reader.Close();
            if (x == false)
            {
                toolStripMenuItem1.PerformClick();
            }
            else
            {
                this.Invoke(new Action(() =>
                {
                    timer1.Start();
                    waitingbar.StartWaiting();
                    waitingbar.Visible = true;
                }));
                generando = true;
                if (bgw_Proyectar.IsBusy == false)
                {
                    bgw_Proyectar.RunWorkerAsync();
                }
            }
        }
        private void nulos()
        {
            for(int i=1;i<=dgvCed2.Rows.Count-1;i++)
            {
                if(dgvCed2.Rows[i].Cells[8].Value==null)
                {
                    this.Invoke(new Action(() =>
                    {
                        dgvCed2.Rows[i].Cells[6].Value = "0";
                        dgvCed2.Rows[i].Cells[7].Value = "$0";
                        dgvCed2.Rows[i].Cells[8].Value = "$0";
                        dgvCed2.Rows[i].Cells[4].Value = "$0";
                    }));
                }
            }
        }
        private void limpiar_combosEstructura()
        {
            cbSucursales.Text = " ";
            cbDivisiones.Text = " ";
            cbDepto.Text = " ";
            cbFamilia.Text = " ";
            cbLinea.Text = " ";
            cbL1.Text = " ";
            cbL2.Text = " ";
            cbL3.Text = " ";
            cbL4.Text = " ";
            cbL5.Text = " ";
            cbL6.Text = " ";
            cbMarca.Text = " ";
            cbSucursales.SelectedText = "";
            cbDivisiones.SelectedText = "";
        }
        private string cadenaQuery()
        {
            string cadena = "";
            switch (posicionCombos)
           {
               case 1:
                   #region 
                   if (seleccion_sucursal==0)
                   {
                       cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                   }
                   else { cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0]; }
                   #endregion
                   break;
               case 2:
                   #region
                   if (seleccion_division==0)
                   {
                       if (bandera_sucursal == true)
                       {
                           if (seleccion_sucursal == 0)
                           {
                               cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                           }
                           else { cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and idsucursal=" + seleccion_sucursal.ToString() + " and iddivisiones=-1 and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'"; }
                       }
                       else
                       {
                           cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                       }
                   }
                   else { cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0]; }
                   #endregion
                   break;
               case 3:
                   #region
                   if (seleccion_depto==0)
                   {
                       cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "'";
                       if(bandera_division==true)
                       {
                           if(seleccion_division!=0)
                           {
                               cadena += " and iddivisiones=" + seleccion_division.ToString();
                           }
                       }
                       if (bandera_sucursal == true)
                       {
                           if (seleccion_sucursal == 0)
                           {
                               cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                           }
                           else { cadena += " and idsucursal=" + seleccion_sucursal.ToString() + " "; }
                       }
                       else
                       {
                           cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                       }
                       if (cadena.Contains("and ZapateriasTorreon=1") == true)
                       {
                           cadena += " and iddepto=0 and idfamilia=0 and idlinea=0 and idl1=0 and idl3=0 and idl4=0 and idl5=0 and idl6=0 and marca='0'";
                       }
                       else { cadena += " and iddepto=-1 and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1  and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'"; }
                   }
                   else
                   {
                       cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0]; 
                   }
                    #endregion
                   break;
               case 4:
                   #region
                   if(seleccion_familia==0)
                   {
                       cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' ";
                       if (bandera_depto == true)
                       {
                           if (seleccion_depto != 0)
                           {
                               cadena += " and iddepto=" + seleccion_depto.ToString(); ;
                           }
                       }
                       if (bandera_division == true)
                       {
                           if (seleccion_division != 0)
                           {
                               cadena += " and iddivisiones=" + seleccion_division.ToString();
                           }
                       }
                       if (bandera_sucursal == true)
                       {
                           if (seleccion_sucursal == 0)
                           {
                               cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                           }
                           else { cadena += " and idsucursal=" + seleccion_sucursal.ToString() + " "; }
                       }
                       else
                       {
                           cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                       }
                       if (cadena.Contains("and ZapateriasTorreon=1") == true)
                       {
                           cadena += " and iddepto=0 and idfamilia=0 and idlinea=0 and idl1=0 and idl3=0 and idl4=0 and idl5=0 and idl6=0 and marca='0'";
                       }
                       else { cadena += " and idfamilia=-1 and idlinea=-1 and idl1=-1 and idl2=-1  and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'"; }
                   }
                   else
                   {
                       cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                   }
                   #endregion
                   break;
               case 5:
                   #region
                   if (seleccion_linea == 0)
                   {
                       cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' ";
                       if(bandera_familia==true)
                       {
                           if(seleccion_familia!=0)
                           {
                               cadena += " and idfamilia=" + seleccion_familia.ToString();
                           }
                       }
                       if (bandera_depto == true)
                       {
                           if (seleccion_depto != 0)
                           {
                               cadena += " and iddepto=" + seleccion_depto.ToString(); ;
                           }
                       }
                       if (bandera_division == true)
                       {
                           if (seleccion_division != 0)
                           {
                               cadena += " and iddivisiones=" + seleccion_division.ToString();
                           }
                       }
                       if (bandera_sucursal == true)
                       {
                           if (seleccion_sucursal == 0)
                           {
                               cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                           }
                           else { cadena += " and idsucursal=" + seleccion_sucursal.ToString() + " "; }
                       }
                       else
                       {
                           cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                       }
                       if (cadena.Contains("and ZapateriasTorreon=1") == true)
                       {
                           cadena += " and iddepto=0 and idfamilia=0 and idlinea=0 and idl1=0 and idl3=0 and idl4=0 and idl5=0 and idl6=0 and marca='0'";
                       }
                       else { cadena += "  and idlinea=-1 and idl1=-1 and idl2=-1 and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'"; }
                   }
                   else
                   {
                       cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                   }
                   #endregion
                   break;
               case 6:
                   #region
                   if (seleccion_l1 == 0)
                   {
                       cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' ";
                       if(bandera_linea==true)
                       {
                           if(seleccion_linea!=0)
                           {
                               cadena += " and idlinea=" + seleccion_linea.ToString();
                           }
                       }
                       if (bandera_familia == true)
                       {
                           if (seleccion_familia != 0)
                           {
                               cadena += " and idfamilia=" + seleccion_familia.ToString();
                           }
                       }
                       if (bandera_depto == true)
                       {
                           if (seleccion_depto != 0)
                           {
                               cadena += " and iddepto=" + seleccion_depto.ToString(); ;
                           }
                       }
                       if (bandera_division == true)
                       {
                           if (seleccion_division != 0)
                           {
                               cadena += " and iddivisiones=" + seleccion_division.ToString();
                           }
                       }
                       if (bandera_sucursal == true)
                       {
                           if (seleccion_sucursal == 0)
                           {
                               cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                           }
                           else { cadena += " and idsucursal=" + seleccion_sucursal.ToString() + " "; }
                       }
                       else
                       {
                           cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                       }
                       if (cadena.Contains("and ZapateriasTorreon=1") == true)
                       {
                           cadena += " and iddepto=0 and idfamilia=0 and idlinea=0 and idl1=0 and idl3=0 and idl4=0 and idl5=0 and idl6=0 and marca='0'";
                       }
                       else { cadena += "  and idl1=-1 and idl2=-1  and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'"; }
                   }
                   else
                   {
                       cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                   }
                   #endregion
                   break;
               case 7:
                   #region
                   if (seleccion_l2 == 0)
                   {
                       cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' ";
                       if(bandera_l1==true)
                       {
                           if(seleccion_l1!=0)
                           {
                               cadena += " and idl1=" + seleccion_l1.ToString();
                           }
                       }
                       if (bandera_linea == true)
                       {
                           if (seleccion_linea != 0)
                           {
                               cadena += " and idlinea=" + seleccion_linea.ToString();
                           }
                       }
                       if (bandera_familia == true)
                       {
                           if (seleccion_familia != 0)
                           {
                               cadena += " and idfamilia=" + seleccion_familia.ToString();
                           }
                       }
                       if (bandera_depto == true)
                       {
                           if (seleccion_depto != 0)
                           {
                               cadena += " and iddepto=" + seleccion_depto.ToString(); ;
                           }
                       }
                       if (bandera_division == true)
                       {
                           if (seleccion_division != 0)
                           {
                               cadena += " and iddivisiones=" + seleccion_division.ToString();
                           }
                       }
                       if (bandera_sucursal == true)
                       {
                           if (seleccion_sucursal == 0)
                           {
                               cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                           }
                           else { cadena += " and idsucursal=" + seleccion_sucursal.ToString() + " "; }
                       }
                       else
                       {
                           cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                       }
                       if (cadena.Contains("and ZapateriasTorreon=1") == true)
                       {
                           cadena += " and iddepto=0 and idfamilia=0 and idlinea=0 and idl1=0 and idl3=0 and idl4=0 and idl5=0 and idl6=0 and marca='0'";
                       }
                       else { cadena += "  and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'"; }
                   }
                   else
                   {
                       cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                   }
                   #endregion
                   break;
               case 8:
                   #region
                   if (seleccion_l3 == 0)
                   {
                       cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' ";
                       if (bandera_l2 == true)
                       {
                           if (seleccion_l2 != 0)
                           {
                               cadena += " and idl2=" + seleccion_l2.ToString();
                           }
                       }
                       if (bandera_l1 == true)
                       {
                           if (seleccion_l1 != 0)
                           {
                               cadena += " and idl1=" + seleccion_l1.ToString();
                           }
                       }
                       if (bandera_linea == true)
                       {
                           if (seleccion_linea != 0)
                           {
                               cadena += " and idlinea=" + seleccion_linea.ToString();
                           }
                       }
                       if (bandera_familia == true)
                       {
                           if (seleccion_familia != 0)
                           {
                               cadena += " and idfamilia=" + seleccion_familia.ToString();
                           }
                       }
                       if (bandera_depto == true)
                       {
                           if (seleccion_depto != 0)
                           {
                               cadena += " and iddepto=" + seleccion_depto.ToString(); ;
                           }
                       }
                       if (bandera_division == true)
                       {
                           if (seleccion_division != 0)
                           {
                               cadena += " and iddivisiones=" + seleccion_division.ToString();
                           }
                       }
                       if (bandera_sucursal == true)
                       {
                           if (seleccion_sucursal == 0)
                           {
                               cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                           }
                           else { cadena += " and idsucursal=" + seleccion_sucursal.ToString() + " "; }
                       }
                       else
                       {
                           cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                       }
                       if (cadena.Contains("and ZapateriasTorreon=1") == true)
                       {
                           cadena += " and iddepto=0 and idfamilia=0 and idlinea=0 and idl1=0 and idl3=0 and idl4=0 and idl5=0 and idl6=0 and marca='0'";
                       }
                       else { cadena += "  and idl3=-1 and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'"; }
                   }
                   else
                   {
                       cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                   }
                   #endregion
                   break;
               case 9:
                   #region
                   if (seleccion_l4 == 0)
                   {
                       cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' ";
                       if (bandera_l3 == true)
                       {
                           if (seleccion_l3 != 0)
                           {
                               cadena += " and idl3=" + seleccion_l3.ToString();
                           }
                       }
                       if (bandera_l2 == true)
                       {
                           if (seleccion_l2 != 0)
                           {
                               cadena += " and idl2=" + seleccion_l2.ToString();
                           }
                       }
                       if (bandera_l1 == true)
                       {
                           if (seleccion_l1 != 0)
                           {
                               cadena += " and idl1=" + seleccion_l1.ToString();
                           }
                       }
                       if (bandera_linea == true)
                       {
                           if (seleccion_linea != 0)
                           {
                               cadena += " and idlinea=" + seleccion_linea.ToString();
                           }
                       }
                       if (bandera_familia == true)
                       {
                           if (seleccion_familia != 0)
                           {
                               cadena += " and idfamilia=" + seleccion_familia.ToString();
                           }
                       }
                       if (bandera_depto == true)
                       {
                           if (seleccion_depto != 0)
                           {
                               cadena += " and iddepto=" + seleccion_depto.ToString(); ;
                           }
                       }
                       if (bandera_division == true)
                       {
                           if (seleccion_division != 0)
                           {
                               cadena += " and iddivisiones=" + seleccion_division.ToString();
                           }
                       }
                       if (bandera_sucursal == true)
                       {
                           if (seleccion_sucursal == 0)
                           {
                               cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                           }
                           else { cadena += " and idsucursal=" + seleccion_sucursal.ToString() + " "; }
                       }
                       else
                       {
                           cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                       }
                       if (cadena.Contains("and ZapateriasTorreon=1") == true)
                       {
                           cadena += " and iddepto=0 and idfamilia=0 and idlinea=0 and idl1=0 and idl3=0 and idl4=0 and idl5=0 and idl6=0 and marca='0'";
                       }
                       else { cadena += "  and idl4=-1 and idl5=-1 and idl6=-1 and marca='-1'"; }
                   }
                   else
                   {
                       cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                   }
                   #endregion
                   break;
               case 10:
                   #region
                   if (seleccion_l5 == 0)
                   {
                       cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' ";
                       if (bandera_l4 == true)
                       {
                           if (seleccion_l4 != 0)
                           {
                               cadena += " and idl4=" + seleccion_l4.ToString();
                           }
                       }
                       if (bandera_l3 == true)
                       {
                           if (seleccion_l3 != 0)
                           {
                               cadena += " and idl3=" + seleccion_l3.ToString();
                           }
                       }
                       if (bandera_l2 == true)
                       {
                           if (seleccion_l2 != 0)
                           {
                               cadena += " and idl2=" + seleccion_l2.ToString();
                           }
                       }
                       if (bandera_l1 == true)
                       {
                           if (seleccion_l1 != 0)
                           {
                               cadena += " and idl1=" + seleccion_l1.ToString();
                           }
                       }
                       if (bandera_linea == true)
                       {
                           if (seleccion_linea != 0)
                           {
                               cadena += " and idlinea=" + seleccion_linea.ToString();
                           }
                       }
                       if (bandera_familia == true)
                       {
                           if (seleccion_familia != 0)
                           {
                               cadena += " and idfamilia=" + seleccion_familia.ToString();
                           }
                       }
                       if (bandera_depto == true)
                       {
                           if (seleccion_depto != 0)
                           {
                               cadena += " and iddepto=" + seleccion_depto.ToString(); ;
                           }
                       }
                       if (bandera_division == true)
                       {
                           if (seleccion_division != 0)
                           {
                               cadena += " and iddivisiones=" + seleccion_division.ToString();
                           }
                       }
                       if (bandera_sucursal == true)
                       {
                           if (seleccion_sucursal == 0)
                           {
                               cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                           }
                           else { cadena += " and idsucursal=" + seleccion_sucursal.ToString() + " "; }
                       }
                       else
                       {
                           cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                       }
                       if (cadena.Contains("and ZapateriasTorreon=1") == true)
                       {
                           cadena += " and iddepto=0 and idfamilia=0 and idlinea=0 and idl1=0 and idl3=0 and idl4=0 and idl5=0 and idl6=0 and marca='0'";
                       }
                       else { cadena += "  and idl5=-1 and idl6=-1 and marca='-1'"; }
                   }
                   else
                   {
                       cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                   }
                   #endregion
                   break;
               case 11:
                   #region
                   if (seleccion_l6 == 0)
                   {
                       cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' ";
                       if (bandera_l5 == true)
                       {
                           if (seleccion_l5 != 0)
                           {
                               cadena += " and idl5=" + seleccion_l5.ToString();
                           }
                       }
                       if (bandera_l4 == true)
                       {
                           if (seleccion_l4 != 0)
                           {
                               cadena += " and idl4=" + seleccion_l4.ToString();
                           }
                       }
                       if (bandera_l3 == true)
                       {
                           if (seleccion_l3 != 0)
                           {
                               cadena += " and idl3=" + seleccion_l3.ToString();
                           }
                       }
                       if (bandera_l2 == true)
                       {
                           if (seleccion_l2 != 0)
                           {
                               cadena += " and idl2=" + seleccion_l2.ToString();
                           }
                       }
                       if (bandera_l1 == true)
                       {
                           if (seleccion_l1 != 0)
                           {
                               cadena += " and idl1=" + seleccion_l1.ToString();
                           }
                       }
                       if (bandera_linea == true)
                       {
                           if (seleccion_linea != 0)
                           {
                               cadena += " and idlinea=" + seleccion_linea.ToString();
                           }
                       }
                       if (bandera_familia == true)
                       {
                           if (seleccion_familia != 0)
                           {
                               cadena += " and idfamilia=" + seleccion_familia.ToString();
                           }
                       }
                       if (bandera_depto == true)
                       {
                           if (seleccion_depto != 0)
                           {
                               cadena += " and iddepto=" + seleccion_depto.ToString(); ;
                           }
                       }
                       if (bandera_division == true)
                       {
                           if (seleccion_division != 0)
                           {
                               cadena += " and iddivisiones=" + seleccion_division.ToString();
                           }
                       }
                       if (bandera_sucursal == true)
                       {
                           if (seleccion_sucursal == 0)
                           {
                               cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                           }
                           else { cadena += " and idsucursal=" + seleccion_sucursal.ToString() + " "; }
                       }
                       else
                       {
                           cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                       }
                       if (cadena.Contains("and ZapateriasTorreon=1") == true)
                       {
                           cadena += " and iddepto=0 and idfamilia=0 and idlinea=0 and idl1=0 and idl3=0 and idl4=0 and idl5=0 and idl6=0 and marca='0'";
                       }
                       else { cadena += " and idl6=-1 and marca='-1'"; }
                   }
                   else
                   {
                       cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                   }
                   #endregion
                   break;
               case 12:
                   #region
                   if(seleccion_marca == "0")
                   {
                       cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' ";
                       if (bandera_l6 == true)
                       {
                           if (seleccion_l6 != 0)
                           {
                               cadena += " and idl6=" + seleccion_l6.ToString();
                           }
                       }
                       if (bandera_l5 == true)
                       {
                           if (seleccion_l5 != 0)
                           {
                               cadena += " and idl5=" + seleccion_l5.ToString();
                           }
                       }
                       if (bandera_l4 == true)
                       {
                           if (seleccion_l4 != 0)
                           {
                               cadena += " and idl4=" + seleccion_l4.ToString();
                           }
                       }
                       if (bandera_l3 == true)
                       {
                           if (seleccion_l3 != 0)
                           {
                               cadena += " and idl3=" + seleccion_l3.ToString();
                           }
                       }
                       if (bandera_l2 == true)
                       {
                           if (seleccion_l2 != 0)
                           {
                               cadena += " and idl2=" + seleccion_l2.ToString();
                           }
                       }
                       if (bandera_l1 == true)
                       {
                           if (seleccion_l1 != 0)
                           {
                               cadena += " and idl1=" + seleccion_l1.ToString();
                           }
                       }
                       if (bandera_linea == true)
                       {
                           if (seleccion_linea != 0)
                           {
                               cadena += " and idlinea=" + seleccion_linea.ToString();
                           }
                       }
                       if (bandera_familia == true)
                       {
                           if (seleccion_familia != 0)
                           {
                               cadena += " and idfamilia=" + seleccion_familia.ToString();
                           }
                       }
                       if (bandera_depto == true)
                       {
                           if (seleccion_depto != 0)
                           {
                               cadena += " and iddepto=" + seleccion_depto.ToString(); ;
                           }
                       }
                       if (bandera_division == true)
                       {
                           if (seleccion_division != 0)
                           {
                               cadena += " and iddivisiones=" + seleccion_division.ToString();
                           }
                       }
                       if (bandera_sucursal == true)
                       {
                           if (seleccion_sucursal == 0)
                           {
                               cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                           }
                           else { cadena += " and idsucursal=" + seleccion_sucursal.ToString() + " "; }
                       }
                       else
                       {
                           cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' and ZapateriasTorreon=1";
                       }
                       if (cadena.Contains("and ZapateriasTorreon=1") == true)
                       {
                           cadena += " and iddepto=0 and idfamilia=0 and idlinea=0 and idl1=0 and idl3=0 and idl4=0 and idl5=0 and idl6=0 and marca='0'";
                       }
                       else { cadena += "  and marca='-1'"; }
                   }
                   else
                   {
                       cadena = "SELECT asignacionUP from cedula2 where nombre='" + Properties.Settings.Default.escenario + "' " + querycargar[0];
                   }
                   #endregion
                   break;
           }
            return cadena;
        }
    }
}