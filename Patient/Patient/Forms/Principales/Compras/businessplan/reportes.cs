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
    public partial class reportes : Form
    {
        #region variables conexion

        private MySqlConnection Conn;
        //ConnCipsis;
        private string query;
        private MySqlCommand cmd;
        private MySqlDataReader reader;
        private string conexion = "SERVER=10.10.1.76; DATABASE=dwh; user=root; PASSWORD=zaptorre;";
        //private string conexion2 = "SERVER=10.10.1.76; DATABASE=cipsis; user=root; PASSWORD=zaptorre;";
        //private string conexion = "SERVER=localhost; DATABASE=cipsis; user=root; PASSWORD=;";
        //private string conexion = "SERVER=localhost; DATABASE=dwh; user=root; PASSWORD= ;";

        #endregion variables conexion
        public reportes()
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
        }

        private void cbescenarios_DropDown(object sender, EventArgs e)
        {
            #region cargar escenarios a cb escenario
            cbescenarios.Items.Clear();
            query = "SELECT DISTINCT nombre FROM escenarios";
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbescenarios.Items.Add(reader["nombre"].ToString());
            }
            reader.Close();
            #endregion
            #region cargar sucursales a cb sucursales
            //cbestructura.Items.Clear();
            //query = "SELECT DISTINCT nombre FROM escenariosmenu";
            //cmd = new MySqlCommand(query, Conn);
            //reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    cbescenarios.Items.Add(reader["nombre"].ToString());
            //}
            //reader.Close();
            #endregion
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnsimular_Click(object sender, EventArgs e)
        {
            #region cedula1
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT Categoria,NivID,RID,VTI,Pp,PrVpU,Vmp,Vmi,Vdp,Vdi,DI from cedula1 where nombre='"+cbescenarios.Text+"' and estructura='"+cbsucursal.Text+"' and estructura2='"+cbestructura.Text+"'", Conn);
            DataTable c1 = new DataTable();
            da.Fill(c1);
            dgvCed1.DataSource = c1;
            dgvCed1.Columns[0].HeaderText="Categoria";
            dgvCed1.Columns[1].HeaderText = "Nivel de inventario deseado";
            dgvCed1.Columns[2].HeaderText = "Rotacion de inventario deseada";
            dgvCed1.Columns[3].HeaderText = "Venta total importe";
            dgvCed1.Columns[4].HeaderText = "Pronostico de pares";
            dgvCed1.Columns[5].HeaderText = "Precio de venta promedio unitario";
            dgvCed1.Columns[6].HeaderText = "Venta mensual en pares";
            dgvCed1.Columns[7].HeaderText = "Venta mensual en importe";
            dgvCed1.Columns[8].HeaderText = "Venta diaria en pares";
            dgvCed1.Columns[9].HeaderText = "Venta diaria en importe";
            dgvCed1.Columns[10].HeaderText = "Dias de inventario";
            #endregion
            #region cedula2
            da = new MySqlDataAdapter("SELECT categoria,Pasignacion,AUnid,AImpo from cedula2 where nombre='" + cbescenarios.Text + "' and sucursal='" + lbsucursal.Text + "' and estructura='" + lbestructura.Text + "'", Conn);
            DataTable c2 = new DataTable();
            da.Fill(c2);
            dgvCed2.DataSource = c2;
            dgvCed2.Columns[0].HeaderText = "Categoria";
            dgvCed2.Columns[1].HeaderText = "% asignacion";
            dgvCed2.Columns[2].HeaderText = "Asignacion de unidades";
            dgvCed2.Columns[3].HeaderText = "Asignacion en importe";
            #endregion
            #region cedula3
            #region enero
            da = new MySqlDataAdapter("SELECT categoria,unidadessi,importessi,plazopago,unidadesrecibo,importerecibo,unidadesV,preciounitario,importeV,rebajapor,rebajasi,unidadesS,importes,rotacion,DI,coston FROM cedula3 WHERE mes=1 and nombre='"+cbescenarios.Text+"' and estructura='"+lbsucursal.Text+"' and estructura2='"+lbestructura.Text+"';", Conn);
            DataTable c3 = new DataTable();
            da.Fill(c3);
            dgvEnero.DataSource = c3;
            dgvEnero.Columns[0].HeaderText = "Categoria";
            dgvEnero.Columns[1].HeaderText = "Saldos iniciales unidades";
            dgvEnero.Columns[2].HeaderText = "Saldos iniciales importe";
            dgvEnero.Columns[3].HeaderText = "Saldos iniciales costo neto";
            dgvEnero.Columns[4].HeaderText = "Compras plazo de pago";
            dgvEnero.Columns[5].HeaderText = "Compras unidades recibo";
            dgvEnero.Columns[6].HeaderText = "Compras importe recibo";
            dgvEnero.Columns[7].HeaderText = "Ventas unidades vendidas";
            dgvEnero.Columns[8].HeaderText = "Ventas precio unitario";
            dgvEnero.Columns[9].HeaderText = "Ventas importe venta";
            dgvEnero.Columns[10].HeaderText = "Ventas % rebaja";
            dgvEnero.Columns[11].HeaderText = "Ventas importe rebaja";
            dgvEnero.Columns[10].HeaderText = "Saldos unidades";
            dgvEnero.Columns[10].HeaderText = "Saldos importe";
            dgvEnero.Columns[10].HeaderText = "Rotacion";
            dgvEnero.Columns[10].HeaderText = "Dias de inventario";
            #endregion
            #region febrero
            da = new MySqlDataAdapter("SELECT categoria,unidadessi,importessi,plazopago,unidadesrecibo,importerecibo,unidadesV,preciounitario,importeV,rebajapor,rebajasi,unidadesS,importes,rotacion,DI,coston FROM cedula3 WHERE mes=2 and nombre='" + cbescenarios.Text + "' and estructura='" + lbsucursal.Text + "' and estructura2='" + lbestructura.Text + "';", Conn);
            c3 = new DataTable();
            da.Fill(c3);
            dgvFebrero.DataSource = c3;
            dgvFebrero.Columns[0].HeaderText = "Categoria";
            dgvFebrero.Columns[1].HeaderText = "Saldos iniciales unidades";
            dgvFebrero.Columns[2].HeaderText = "Saldos iniciales importe";
            dgvFebrero.Columns[3].HeaderText = "Saldos iniciales costo neto";
            dgvFebrero.Columns[4].HeaderText = "Compras plazo de pago";
            dgvFebrero.Columns[5].HeaderText = "Compras unidades recibo";
            dgvFebrero.Columns[6].HeaderText = "Compras importe recibo";
            dgvFebrero.Columns[7].HeaderText = "Ventas unidades vendidas";
            dgvFebrero.Columns[8].HeaderText = "Ventas precio unitario";
            dgvFebrero.Columns[9].HeaderText = "Ventas importe venta";
            dgvFebrero.Columns[10].HeaderText = "Ventas % rebaja";
            dgvFebrero.Columns[11].HeaderText = "Ventas importe rebaja";
            dgvFebrero.Columns[10].HeaderText = "Saldos unidades";
            dgvFebrero.Columns[10].HeaderText = "Saldos importe";
            dgvFebrero.Columns[10].HeaderText = "Rotacion";
            dgvFebrero.Columns[10].HeaderText = "Dias de inventario";
            #endregion
            #region Marzo
            da = new MySqlDataAdapter("SELECT categoria,unidadessi,importessi,plazopago,unidadesrecibo,importerecibo,unidadesV,preciounitario,importeV,rebajapor,rebajasi,unidadesS,importes,rotacion,DI,coston FROM cedula3 WHERE mes=3 and nombre='" + cbescenarios.Text + "' and estructura='" + lbsucursal.Text + "' and estructura2='" + lbestructura.Text + "';", Conn);
            c3 = new DataTable();
            da.Fill(c3);
            dgvMarzo.DataSource = c3;
            dgvMarzo.Columns[0].HeaderText = "Categoria";
            dgvMarzo.Columns[1].HeaderText = "Saldos iniciales unidades";
            dgvMarzo.Columns[2].HeaderText = "Saldos iniciales importe";
            dgvMarzo.Columns[3].HeaderText = "Saldos iniciales costo neto";
            dgvMarzo.Columns[4].HeaderText = "Compras plazo de pago";
            dgvMarzo.Columns[5].HeaderText = "Compras unidades recibo";
            dgvMarzo.Columns[6].HeaderText = "Compras importe recibo";
            dgvMarzo.Columns[7].HeaderText = "Ventas unidades vendidas";
            dgvMarzo.Columns[8].HeaderText = "Ventas precio unitario";
            dgvMarzo.Columns[9].HeaderText = "Ventas importe venta";
            dgvMarzo.Columns[10].HeaderText = "Ventas % rebaja";
            dgvMarzo.Columns[11].HeaderText = "Ventas importe rebaja";
            dgvMarzo.Columns[10].HeaderText = "Saldos unidades";
            dgvMarzo.Columns[10].HeaderText = "Saldos importe";
            dgvMarzo.Columns[10].HeaderText = "Rotacion";
            dgvMarzo.Columns[10].HeaderText = "Dias de inventario";
            #endregion
            #region abril
            da = new MySqlDataAdapter("SELECT categoria,unidadessi,importessi,plazopago,unidadesrecibo,importerecibo,unidadesV,preciounitario,importeV,rebajapor,rebajasi,unidadesS,importes,rotacion,DI,coston FROM cedula3 WHERE mes=4 and nombre='" + cbescenarios.Text + "' and estructura='" + lbsucursal.Text + "' and estructura2='" + lbestructura.Text + "';", Conn);
            c3 = new DataTable();
            da.Fill(c3);
            dgvAbril.DataSource = c3;
            dgvAbril.Columns[0].HeaderText = "Categoria";
            dgvAbril.Columns[1].HeaderText = "Saldos iniciales unidades";
            dgvAbril.Columns[2].HeaderText = "Saldos iniciales importe";
            dgvAbril.Columns[3].HeaderText = "Saldos iniciales costo neto";
            dgvAbril.Columns[4].HeaderText = "Compras plazo de pago";
            dgvAbril.Columns[5].HeaderText = "Compras unidades recibo";
            dgvAbril.Columns[6].HeaderText = "Compras importe recibo";
            dgvAbril.Columns[7].HeaderText = "Ventas unidades vendidas";
            dgvAbril.Columns[8].HeaderText = "Ventas precio unitario";
            dgvAbril.Columns[9].HeaderText = "Ventas importe venta";
            dgvAbril.Columns[10].HeaderText = "Ventas % rebaja";
            dgvAbril.Columns[11].HeaderText = "Ventas importe rebaja";
            dgvAbril.Columns[10].HeaderText = "Saldos unidades";
            dgvAbril.Columns[10].HeaderText = "Saldos importe";
            dgvAbril.Columns[10].HeaderText = "Rotacion";
            dgvAbril.Columns[10].HeaderText = "Dias de inventario";
            #endregion
            #region mayo
            da = new MySqlDataAdapter("SELECT categoria,unidadessi,importessi,plazopago,unidadesrecibo,importerecibo,unidadesV,preciounitario,importeV,rebajapor,rebajasi,unidadesS,importes,rotacion,DI,coston FROM cedula3 WHERE mes=5 and nombre='" + cbescenarios.Text + "' and estructura='" + lbsucursal.Text + "' and estructura2='" + lbestructura.Text + "';", Conn);
            c3 = new DataTable();
            da.Fill(c3);
            dgvMayo.DataSource = c3;
            dgvMayo.Columns[0].HeaderText = "Categoria";
            dgvMayo.Columns[1].HeaderText = "Saldos iniciales unidades";
            dgvMayo.Columns[2].HeaderText = "Saldos iniciales importe";
            dgvMayo.Columns[3].HeaderText = "Saldos iniciales costo neto";
            dgvMayo.Columns[4].HeaderText = "Compras plazo de pago";
            dgvMayo.Columns[5].HeaderText = "Compras unidades recibo";
            dgvMayo.Columns[6].HeaderText = "Compras importe recibo";
            dgvMayo.Columns[7].HeaderText = "Ventas unidades vendidas";
            dgvMayo.Columns[8].HeaderText = "Ventas precio unitario";
            dgvMayo.Columns[9].HeaderText = "Ventas importe venta";
            dgvMayo.Columns[10].HeaderText = "Ventas % rebaja";
            dgvMayo.Columns[11].HeaderText = "Ventas importe rebaja";
            dgvMayo.Columns[10].HeaderText = "Saldos unidades";
            dgvMayo.Columns[10].HeaderText = "Saldos importe";
            dgvMayo.Columns[10].HeaderText = "Rotacion";
            dgvMayo.Columns[10].HeaderText = "Dias de inventario";
            #endregion
            #region Junio
            da = new MySqlDataAdapter("SELECT categoria,unidadessi,importessi,plazopago,unidadesrecibo,importerecibo,unidadesV,preciounitario,importeV,rebajapor,rebajasi,unidadesS,importes,rotacion,DI,coston FROM cedula3 WHERE mes=6 and nombre='" + cbescenarios.Text + "' and estructura='" + lbsucursal.Text + "' and estructura2='" + lbestructura.Text + "';", Conn);
            c3 = new DataTable();
            da.Fill(c3);
            dgvJunio.DataSource = c3;
            dgvJunio.Columns[0].HeaderText = "Categoria";
            dgvJunio.Columns[1].HeaderText = "Saldos iniciales unidades";
            dgvJunio.Columns[2].HeaderText = "Saldos iniciales importe";
            dgvJunio.Columns[3].HeaderText = "Saldos iniciales costo neto";
            dgvJunio.Columns[4].HeaderText = "Compras plazo de pago";
            dgvJunio.Columns[5].HeaderText = "Compras unidades recibo";
            dgvJunio.Columns[6].HeaderText = "Compras importe recibo";
            dgvJunio.Columns[7].HeaderText = "Ventas unidades vendidas";
            dgvJunio.Columns[8].HeaderText = "Ventas precio unitario";
            dgvJunio.Columns[9].HeaderText = "Ventas importe venta";
            dgvJunio.Columns[10].HeaderText = "Ventas % rebaja";
            dgvJunio.Columns[11].HeaderText = "Ventas importe rebaja";
            dgvJunio.Columns[10].HeaderText = "Saldos unidades";
            dgvJunio.Columns[10].HeaderText = "Saldos importe";
            dgvJunio.Columns[10].HeaderText = "Rotacion";
            dgvJunio.Columns[10].HeaderText = "Dias de inventario";
            #endregion
            #region Julio
            da = new MySqlDataAdapter("SELECT categoria,unidadessi,importessi,plazopago,unidadesrecibo,importerecibo,unidadesV,preciounitario,importeV,rebajapor,rebajasi,unidadesS,importes,rotacion,DI,coston FROM cedula3 WHERE mes=7 and nombre='" + cbescenarios.Text + "' and estructura='" + lbsucursal.Text + "' and estructura2='" + lbestructura.Text + "';", Conn);
            c3 = new DataTable();
            da.Fill(c3);
            dgvJulio.DataSource = c3;
            dgvJulio.Columns[0].HeaderText = "Categoria";
            dgvJulio.Columns[1].HeaderText = "Saldos iniciales unidades";
            dgvJulio.Columns[2].HeaderText = "Saldos iniciales importe";
            dgvJulio.Columns[3].HeaderText = "Saldos iniciales costo neto";
            dgvJulio.Columns[4].HeaderText = "Compras plazo de pago";
            dgvJulio.Columns[5].HeaderText = "Compras unidades recibo";
            dgvJulio.Columns[6].HeaderText = "Compras importe recibo";
            dgvJulio.Columns[7].HeaderText = "Ventas unidades vendidas";
            dgvJulio.Columns[8].HeaderText = "Ventas precio unitario";
            dgvJulio.Columns[9].HeaderText = "Ventas importe venta";
            dgvJulio.Columns[10].HeaderText = "Ventas % rebaja";
            dgvJulio.Columns[11].HeaderText = "Ventas importe rebaja";
            dgvJulio.Columns[10].HeaderText = "Saldos unidades";
            dgvJulio.Columns[10].HeaderText = "Saldos importe";
            dgvJulio.Columns[10].HeaderText = "Rotacion";
            dgvJulio.Columns[10].HeaderText = "Dias de inventario";
            #endregion
            #region agosto
            da = new MySqlDataAdapter("SELECT categoria,unidadessi,importessi,plazopago,unidadesrecibo,importerecibo,unidadesV,preciounitario,importeV,rebajapor,rebajasi,unidadesS,importes,rotacion,DI,coston FROM cedula3 WHERE mes=8 and nombre='" + cbescenarios.Text + "' and estructura='" + lbsucursal.Text + "' and estructura2='" + lbestructura.Text + "';", Conn);
            c3 = new DataTable();
            da.Fill(c3);
            dgvAgosto.DataSource = c3;
            dgvAgosto.Columns[0].HeaderText = "Categoria";
            dgvAgosto.Columns[1].HeaderText = "Saldos iniciales unidades";
            dgvAgosto.Columns[2].HeaderText = "Saldos iniciales importe";
            dgvAgosto.Columns[3].HeaderText = "Saldos iniciales costo neto";
            dgvAgosto.Columns[4].HeaderText = "Compras plazo de pago";
            dgvAgosto.Columns[5].HeaderText = "Compras unidades recibo";
            dgvAgosto.Columns[6].HeaderText = "Compras importe recibo";
            dgvAgosto.Columns[7].HeaderText = "Ventas unidades vendidas";
            dgvAgosto.Columns[8].HeaderText = "Ventas precio unitario";
            dgvAgosto.Columns[9].HeaderText = "Ventas importe venta";
            dgvAgosto.Columns[10].HeaderText = "Ventas % rebaja";
            dgvAgosto.Columns[11].HeaderText = "Ventas importe rebaja";
            dgvAgosto.Columns[10].HeaderText = "Saldos unidades";
            dgvAgosto.Columns[10].HeaderText = "Saldos importe";
            dgvAgosto.Columns[10].HeaderText = "Rotacion";
            dgvAgosto.Columns[10].HeaderText = "Dias de inventario";
            #endregion
            #region Septiembre
            da = new MySqlDataAdapter("SELECT categoria,unidadessi,importessi,plazopago,unidadesrecibo,importerecibo,unidadesV,preciounitario,importeV,rebajapor,rebajasi,unidadesS,importes,rotacion,DI,coston FROM cedula3 WHERE mes=9 and nombre='" + cbescenarios.Text + "' and estructura='" + lbsucursal.Text + "' and estructura2='" + lbestructura.Text + "';", Conn);
            c3 = new DataTable();
            da.Fill(c3);
            dgvSeptiembre.DataSource = c3;
            dgvSeptiembre.Columns[0].HeaderText = "Categoria";
            dgvSeptiembre.Columns[1].HeaderText = "Saldos iniciales unidades";
            dgvSeptiembre.Columns[2].HeaderText = "Saldos iniciales importe";
            dgvSeptiembre.Columns[3].HeaderText = "Saldos iniciales costo neto";
            dgvSeptiembre.Columns[4].HeaderText = "Compras plazo de pago";
            dgvSeptiembre.Columns[5].HeaderText = "Compras unidades recibo";
            dgvSeptiembre.Columns[6].HeaderText = "Compras importe recibo";
            dgvSeptiembre.Columns[7].HeaderText = "Ventas unidades vendidas";
            dgvSeptiembre.Columns[8].HeaderText = "Ventas precio unitario";
            dgvSeptiembre.Columns[9].HeaderText = "Ventas importe venta";
            dgvSeptiembre.Columns[10].HeaderText = "Ventas % rebaja";
            dgvSeptiembre.Columns[11].HeaderText = "Ventas importe rebaja";
            dgvSeptiembre.Columns[10].HeaderText = "Saldos unidades";
            dgvSeptiembre.Columns[10].HeaderText = "Saldos importe";
            dgvSeptiembre.Columns[10].HeaderText = "Rotacion";
            dgvSeptiembre.Columns[10].HeaderText = "Dias de inventario";
            #endregion
            #region octubre
            da = new MySqlDataAdapter("SELECT categoria,unidadessi,importessi,plazopago,unidadesrecibo,importerecibo,unidadesV,preciounitario,importeV,rebajapor,rebajasi,unidadesS,importes,rotacion,DI,coston FROM cedula3 WHERE mes=10 and nombre='" + cbescenarios.Text + "' and estructura='" + lbsucursal.Text + "' and estructura2='" + lbestructura.Text + "';", Conn);
            c3 = new DataTable();
            da.Fill(c3);
            dgvOctubre.DataSource = c3;
            dgvOctubre.Columns[0].HeaderText = "Categoria";
            dgvOctubre.Columns[1].HeaderText = "Saldos iniciales unidades";
            dgvOctubre.Columns[2].HeaderText = "Saldos iniciales importe";
            dgvOctubre.Columns[3].HeaderText = "Saldos iniciales costo neto";
            dgvOctubre.Columns[4].HeaderText = "Compras plazo de pago";
            dgvOctubre.Columns[5].HeaderText = "Compras unidades recibo";
            dgvOctubre.Columns[6].HeaderText = "Compras importe recibo";
            dgvOctubre.Columns[7].HeaderText = "Ventas unidades vendidas";
            dgvOctubre.Columns[8].HeaderText = "Ventas precio unitario";
            dgvOctubre.Columns[9].HeaderText = "Ventas importe venta";
            dgvOctubre.Columns[10].HeaderText = "Ventas % rebaja";
            dgvOctubre.Columns[11].HeaderText = "Ventas importe rebaja";
            dgvOctubre.Columns[10].HeaderText = "Saldos unidades";
            dgvOctubre.Columns[10].HeaderText = "Saldos importe";
            dgvOctubre.Columns[10].HeaderText = "Rotacion";
            dgvOctubre.Columns[10].HeaderText = "Dias de inventario";
            #endregion
            #region noviembre
            da = new MySqlDataAdapter("SELECT categoria,unidadessi,importessi,plazopago,unidadesrecibo,importerecibo,unidadesV,preciounitario,importeV,rebajapor,rebajasi,unidadesS,importes,rotacion,DI,coston FROM cedula3 WHERE mes=11 and nombre='" + cbescenarios.Text + "' and estructura='" + lbsucursal.Text + "' and estructura2='" + lbestructura.Text + "';", Conn);
            c3 = new DataTable();
            da.Fill(c3);
            dgvNoviembre.DataSource = c3;
            dgvNoviembre.Columns[0].HeaderText = "Categoria";
            dgvNoviembre.Columns[1].HeaderText = "Saldos iniciales unidades";
            dgvNoviembre.Columns[2].HeaderText = "Saldos iniciales importe";
            dgvNoviembre.Columns[3].HeaderText = "Saldos iniciales costo neto";
            dgvNoviembre.Columns[4].HeaderText = "Compras plazo de pago";
            dgvNoviembre.Columns[5].HeaderText = "Compras unidades recibo";
            dgvNoviembre.Columns[6].HeaderText = "Compras importe recibo";
            dgvNoviembre.Columns[7].HeaderText = "Ventas unidades vendidas";
            dgvNoviembre.Columns[8].HeaderText = "Ventas precio unitario";
            dgvNoviembre.Columns[9].HeaderText = "Ventas importe venta";
            dgvNoviembre.Columns[10].HeaderText = "Ventas % rebaja";
            dgvNoviembre.Columns[11].HeaderText = "Ventas importe rebaja";
            dgvNoviembre.Columns[10].HeaderText = "Saldos unidades";
            dgvNoviembre.Columns[10].HeaderText = "Saldos importe";
            dgvNoviembre.Columns[10].HeaderText = "Rotacion";
            dgvNoviembre.Columns[10].HeaderText = "Dias de inventario";
            #endregion
            #region diciembre
            da = new MySqlDataAdapter("SELECT categoria,unidadessi,importessi,plazopago,unidadesrecibo,importerecibo,unidadesV,preciounitario,importeV,rebajapor,rebajasi,unidadesS,importes,rotacion,DI,coston FROM cedula3 WHERE mes=12 and nombre='" + cbescenarios.Text + "' and estructura='" + lbsucursal.Text + "' and estructura2='" + lbestructura.Text + "';", Conn);
            c3 = new DataTable();
            da.Fill(c3);
            dgvDiciembre.DataSource = c3;
            dgvDiciembre.Columns[0].HeaderText = "Categoria";
            dgvDiciembre.Columns[1].HeaderText = "Saldos iniciales unidades";
            dgvDiciembre.Columns[2].HeaderText = "Saldos iniciales importe";
            dgvDiciembre.Columns[3].HeaderText = "Saldos iniciales costo neto";
            dgvDiciembre.Columns[4].HeaderText = "Compras plazo de pago";
            dgvDiciembre.Columns[5].HeaderText = "Compras unidades recibo";
            dgvDiciembre.Columns[6].HeaderText = "Compras importe recibo";
            dgvDiciembre.Columns[7].HeaderText = "Ventas unidades vendidas";
            dgvDiciembre.Columns[8].HeaderText = "Ventas precio unitario";
            dgvDiciembre.Columns[9].HeaderText = "Ventas importe venta";
            dgvDiciembre.Columns[10].HeaderText = "Ventas % rebaja";
            dgvDiciembre.Columns[11].HeaderText = "Ventas importe rebaja";
            dgvDiciembre.Columns[10].HeaderText = "Saldos unidades";
            dgvDiciembre.Columns[10].HeaderText = "Saldos importe";
            dgvDiciembre.Columns[10].HeaderText = "Rotacion";
            dgvDiciembre.Columns[10].HeaderText = "Dias de inventario";
            #endregion
            #endregion
            #region cedula 4
            #region enero
            da = new MySqlDataAdapter("SELECT categoria,margeniniPor,margeniniImp,rebajasPor,rebajasImp,margenfinPor,margenfinImp,dppPor,dppImp,utilidadPor,utilidadImp FROM cedula4 WHERE Escenario='"+cbescenarios.Text+"' AND estructura='"+lbsucursal.Text+"' AND estructura2='"+lbestructura.Text+"' AND mes=1", Conn);
            DataTable c4 = new DataTable();
            da.Fill(c4);
            dgvCed4.DataSource = c4;
            dgvCed4.Columns[0].HeaderText = "Categoria";
            dgvCed4.Columns[1].HeaderText = "Margen inicial %";
            dgvCed4.Columns[2].HeaderText = "Margen inicial importe";
            dgvCed4.Columns[3].HeaderText = "Rebajas %";
            dgvCed4.Columns[4].HeaderText = "Rebahas importe";
            dgvCed4.Columns[5].HeaderText = "Margen final %";
            dgvCed4.Columns[6].HeaderText = "Margen final importe";
            dgvCed4.Columns[7].HeaderText = "Dpp %";
            dgvCed4.Columns[8].HeaderText = "Dpp importe";
            dgvCed4.Columns[9].HeaderText = "Utilidad %";
            dgvCed4.Columns[10].HeaderText = "Utilidad importe";
            #endregion
            #region febrero
            da = new MySqlDataAdapter("SELECT categoria,margeniniPor,margeniniImp,rebajasPor,rebajasImp,margenfinPor,margenfinImp,dppPor,dppImp,utilidadPor,utilidadImp FROM cedula4 WHERE Escenario='" + cbescenarios.Text + "' AND estructura='" + lbsucursal.Text + "' AND estructura2='" + lbestructura.Text + "' AND mes=2", Conn);
            c4 = new DataTable();
            da.Fill(c4);
            dgvCed4_Febrero.DataSource = c4;
            dgvCed4_Febrero.Columns[0].HeaderText = "Categoria";
            dgvCed4_Febrero.Columns[1].HeaderText = "Margen inicial %";
            dgvCed4_Febrero.Columns[2].HeaderText = "Margen inicial importe";
            dgvCed4_Febrero.Columns[3].HeaderText = "Rebajas %";
            dgvCed4_Febrero.Columns[4].HeaderText = "Rebahas importe";
            dgvCed4_Febrero.Columns[5].HeaderText = "Margen final %";
            dgvCed4_Febrero.Columns[6].HeaderText = "Margen final importe";
            dgvCed4_Febrero.Columns[7].HeaderText = "Dpp %";
            dgvCed4_Febrero.Columns[8].HeaderText = "Dpp importe";
            dgvCed4_Febrero.Columns[9].HeaderText = "Utilidad %";
            dgvCed4_Febrero.Columns[10].HeaderText = "Utilidad importe";
            #endregion
            #region Marzo
            da = new MySqlDataAdapter("SELECT categoria,margeniniPor,margeniniImp,rebajasPor,rebajasImp,margenfinPor,margenfinImp,dppPor,dppImp,utilidadPor,utilidadImp FROM cedula4 WHERE Escenario='" + cbescenarios.Text + "' AND estructura='" + lbsucursal.Text + "' AND estructura2='" + lbestructura.Text + "' AND mes=3", Conn);
            c4 = new DataTable();
            da.Fill(c4);
            dgvCed4_Marzo.DataSource = c4;
            dgvCed4_Marzo.Columns[0].HeaderText = "Categoria";
            dgvCed4_Marzo.Columns[1].HeaderText = "Margen inicial %";
            dgvCed4_Febrero.Columns[2].HeaderText = "Margen inicial importe";
            dgvCed4_Marzo.Columns[3].HeaderText = "Rebajas %";
            dgvCed4_Marzo.Columns[4].HeaderText = "Rebahas importe";
            dgvCed4_Marzo.Columns[5].HeaderText = "Margen final %";
            dgvCed4_Marzo.Columns[6].HeaderText = "Margen final importe";
            dgvCed4_Marzo.Columns[7].HeaderText = "Dpp %";
            dgvCed4_Marzo.Columns[8].HeaderText = "Dpp importe";
            dgvCed4_Marzo.Columns[9].HeaderText = "Utilidad %";
            dgvCed4_Marzo.Columns[10].HeaderText = "Utilidad importe";
            #endregion
            #region Abril
            da = new MySqlDataAdapter("SELECT categoria,margeniniPor,margeniniImp,rebajasPor,rebajasImp,margenfinPor,margenfinImp,dppPor,dppImp,utilidadPor,utilidadImp FROM cedula4 WHERE Escenario='" + cbescenarios.Text + "' AND estructura='" + lbsucursal.Text + "' AND estructura2='" + lbestructura.Text + "' AND mes=4", Conn);
            c4 = new DataTable();
            da.Fill(c4);
            dgvCed4_Abril.DataSource = c4;
            dgvCed4_Abril.Columns[0].HeaderText = "Categoria";
            dgvCed4_Abril.Columns[1].HeaderText = "Margen inicial %";
            dgvCed4_Febrero.Columns[2].HeaderText = "Margen inicial importe";
            dgvCed4_Abril.Columns[3].HeaderText = "Rebajas %";
            dgvCed4_Abril.Columns[4].HeaderText = "Rebahas importe";
            dgvCed4_Abril.Columns[5].HeaderText = "Margen final %";
            dgvCed4_Abril.Columns[6].HeaderText = "Margen final importe";
            dgvCed4_Abril.Columns[7].HeaderText = "Dpp %";
            dgvCed4_Abril.Columns[8].HeaderText = "Dpp importe";
            dgvCed4_Abril.Columns[9].HeaderText = "Utilidad %";
            dgvCed4_Abril.Columns[10].HeaderText = "Utilidad importe";
            #endregion
            #region Mayo
            da = new MySqlDataAdapter("SELECT categoria,margeniniPor,margeniniImp,rebajasPor,rebajasImp,margenfinPor,margenfinImp,dppPor,dppImp,utilidadPor,utilidadImp FROM cedula4 WHERE Escenario='" + cbescenarios.Text + "' AND estructura='" + lbsucursal.Text + "' AND estructura2='" + lbestructura.Text + "' AND mes=5", Conn);
            c4 = new DataTable();
            da.Fill(c4);
            dgvCed4_Mayo.DataSource = c4;
            dgvCed4_Mayo.Columns[0].HeaderText = "Categoria";
            dgvCed4_Mayo.Columns[1].HeaderText = "Margen inicial %";
            dgvCed4_Mayo.Columns[2].HeaderText = "Margen inicial importe";
            dgvCed4_Mayo.Columns[3].HeaderText = "Rebajas %";
            dgvCed4_Mayo.Columns[4].HeaderText = "Rebahas importe";
            dgvCed4_Mayo.Columns[5].HeaderText = "Margen final %";
            dgvCed4_Mayo.Columns[6].HeaderText = "Margen final importe";
            dgvCed4_Mayo.Columns[7].HeaderText = "Dpp %";
            dgvCed4_Mayo.Columns[8].HeaderText = "Dpp importe";
            dgvCed4_Mayo.Columns[9].HeaderText = "Utilidad %";
            dgvCed4_Mayo.Columns[10].HeaderText = "Utilidad importe";
            #endregion
            #region junio
            da = new MySqlDataAdapter("SELECT categoria,margeniniPor,margeniniImp,rebajasPor,rebajasImp,margenfinPor,margenfinImp,dppPor,dppImp,utilidadPor,utilidadImp FROM cedula4 WHERE Escenario='" + cbescenarios.Text + "' AND estructura='" + lbsucursal.Text + "' AND estructura2='" + lbestructura.Text + "' AND mes=6", Conn);
            c4 = new DataTable();
            da.Fill(c4);
            dgvCed4_Junio.DataSource = c4;
            dgvCed4_Junio.Columns[0].HeaderText = "Categoria";
            dgvCed4_Junio.Columns[1].HeaderText = "Margen inicial %";
            dgvCed4_Junio.Columns[2].HeaderText = "Margen inicial importe";
            dgvCed4_Junio.Columns[3].HeaderText = "Rebajas %";
            dgvCed4_Junio.Columns[4].HeaderText = "Rebahas importe";
            dgvCed4_Junio.Columns[5].HeaderText = "Margen final %";
            dgvCed4_Junio.Columns[6].HeaderText = "Margen final importe";
            dgvCed4_Junio.Columns[7].HeaderText = "Dpp %";
            dgvCed4_Junio.Columns[8].HeaderText = "Dpp importe";
            dgvCed4_Junio.Columns[9].HeaderText = "Utilidad %";
            dgvCed4_Junio.Columns[10].HeaderText = "Utilidad importe";
            #endregion
            #region julio
            da = new MySqlDataAdapter("SELECT categoria,margeniniPor,margeniniImp,rebajasPor,rebajasImp,margenfinPor,margenfinImp,dppPor,dppImp,utilidadPor,utilidadImp FROM cedula4 WHERE Escenario='" + cbescenarios.Text + "' AND estructura='" + lbsucursal.Text + "' AND estructura2='" + lbestructura.Text + "' AND mes=7", Conn);
            c4 = new DataTable();
            da.Fill(c4);
            dgvCed4_Julio.DataSource = c4;
            dgvCed4_Julio.Columns[0].HeaderText = "Categoria";
            dgvCed4_Julio.Columns[1].HeaderText = "Margen inicial %";
            dgvCed4_Julio.Columns[2].HeaderText = "Margen inicial importe";
            dgvCed4_Julio.Columns[3].HeaderText = "Rebajas %";
            dgvCed4_Julio.Columns[4].HeaderText = "Rebahas importe";
            dgvCed4_Julio.Columns[5].HeaderText = "Margen final %";
            dgvCed4_Julio.Columns[6].HeaderText = "Margen final importe";
            dgvCed4_Julio.Columns[7].HeaderText = "Dpp %";
            dgvCed4_Julio.Columns[8].HeaderText = "Dpp importe";
            dgvCed4_Julio.Columns[9].HeaderText = "Utilidad %";
            dgvCed4_Julio.Columns[10].HeaderText = "Utilidad importe";
            #endregion
            #region Agosto
            da = new MySqlDataAdapter("SELECT categoria,margeniniPor,margeniniImp,rebajasPor,rebajasImp,margenfinPor,margenfinImp,dppPor,dppImp,utilidadPor,utilidadImp FROM cedula4 WHERE Escenario='" + cbescenarios.Text + "' AND estructura='" + lbsucursal.Text + "' AND estructura2='" + lbestructura.Text + "' AND mes=8", Conn);
            c4 = new DataTable();
            da.Fill(c4);
            dgvCed4_Agosto.DataSource = c4;
            dgvCed4_Agosto.Columns[0].HeaderText = "Categoria";
            dgvCed4_Agosto.Columns[1].HeaderText = "Margen inicial %";
            dgvCed4_Agosto.Columns[2].HeaderText = "Margen inicial importe";
            dgvCed4_Agosto.Columns[3].HeaderText = "Rebajas %";
            dgvCed4_Agosto.Columns[4].HeaderText = "Rebahas importe";
            dgvCed4_Agosto.Columns[5].HeaderText = "Margen final %";
            dgvCed4_Agosto.Columns[6].HeaderText = "Margen final importe";
            dgvCed4_Agosto.Columns[7].HeaderText = "Dpp %";
            dgvCed4_Agosto.Columns[8].HeaderText = "Dpp importe";
            dgvCed4_Agosto.Columns[9].HeaderText = "Utilidad %";
            dgvCed4_Agosto.Columns[10].HeaderText = "Utilidad importe";
            #endregion
            #region septiembre
            da = new MySqlDataAdapter("SELECT categoria,margeniniPor,margeniniImp,rebajasPor,rebajasImp,margenfinPor,margenfinImp,dppPor,dppImp,utilidadPor,utilidadImp FROM cedula4 WHERE Escenario='" + cbescenarios.Text + "' AND estructura='" + lbsucursal.Text + "' AND estructura2='" + lbestructura.Text + "' AND mes=9", Conn);
            c4 = new DataTable();
            da.Fill(c4);
            dgvCed4_Septiembre.DataSource = c4;
            dgvCed4_Septiembre.Columns[0].HeaderText = "Categoria";
            dgvCed4_Septiembre.Columns[1].HeaderText = "Margen inicial %";
            dgvCed4_Septiembre.Columns[2].HeaderText = "Margen inicial importe";
            dgvCed4_Septiembre.Columns[3].HeaderText = "Rebajas %";
            dgvCed4_Septiembre.Columns[4].HeaderText = "Rebahas importe";
            dgvCed4_Septiembre.Columns[5].HeaderText = "Margen final %";
            dgvCed4_Septiembre.Columns[6].HeaderText = "Margen final importe";
            dgvCed4_Septiembre.Columns[7].HeaderText = "Dpp %";
            dgvCed4_Septiembre.Columns[8].HeaderText = "Dpp importe";
            dgvCed4_Septiembre.Columns[9].HeaderText = "Utilidad %";
            dgvCed4_Septiembre.Columns[10].HeaderText = "Utilidad importe";
            #endregion
            #region octubre
            da = new MySqlDataAdapter("SELECT categoria,margeniniPor,margeniniImp,rebajasPor,rebajasImp,margenfinPor,margenfinImp,dppPor,dppImp,utilidadPor,utilidadImp FROM cedula4 WHERE Escenario='" + cbescenarios.Text + "' AND estructura='" + lbsucursal.Text + "' AND estructura2='" + lbestructura.Text + "' AND mes=10", Conn);
            c4 = new DataTable();
            da.Fill(c4);
            dgvCed4_Octubre.DataSource = c4;
            dgvCed4_Octubre.Columns[0].HeaderText = "Categoria";
            dgvCed4_Octubre.Columns[1].HeaderText = "Margen inicial %";
            dgvCed4_Octubre.Columns[2].HeaderText = "Margen inicial importe";
            dgvCed4_Octubre.Columns[3].HeaderText = "Rebajas %";
            dgvCed4_Octubre.Columns[4].HeaderText = "Rebahas importe";
            dgvCed4_Octubre.Columns[5].HeaderText = "Margen final %";
            dgvCed4_Octubre.Columns[6].HeaderText = "Margen final importe";
            dgvCed4_Octubre.Columns[7].HeaderText = "Dpp %";
            dgvCed4_Octubre.Columns[8].HeaderText = "Dpp importe";
            dgvCed4_Octubre.Columns[9].HeaderText = "Utilidad %";
            dgvCed4_Octubre.Columns[10].HeaderText = "Utilidad importe";
            #endregion
            #region Noviembre
            da = new MySqlDataAdapter("SELECT categoria,margeniniPor,margeniniImp,rebajasPor,rebajasImp,margenfinPor,margenfinImp,dppPor,dppImp,utilidadPor,utilidadImp FROM cedula4 WHERE Escenario='" + cbescenarios.Text + "' AND estructura='" + lbsucursal.Text + "' AND estructura2='" + lbestructura.Text + "' AND mes=11", Conn);
            c4 = new DataTable();
            da.Fill(c4);
            dgvCed4_Noviembre.DataSource = c4;
            dgvCed4_Noviembre.Columns[0].HeaderText = "Categoria";
            dgvCed4_Noviembre.Columns[1].HeaderText = "Margen inicial %";
            dgvCed4_Noviembre.Columns[2].HeaderText = "Margen inicial importe";
            dgvCed4_Noviembre.Columns[3].HeaderText = "Rebajas %";
            dgvCed4_Noviembre.Columns[4].HeaderText = "Rebahas importe";
            dgvCed4_Noviembre.Columns[5].HeaderText = "Margen final %";
            dgvCed4_Noviembre.Columns[6].HeaderText = "Margen final importe";
            dgvCed4_Noviembre.Columns[7].HeaderText = "Dpp %";
            dgvCed4_Noviembre.Columns[8].HeaderText = "Dpp importe";
            dgvCed4_Noviembre.Columns[9].HeaderText = "Utilidad %";
            dgvCed4_Noviembre.Columns[10].HeaderText = "Utilidad importe";
            #endregion
            #region diciembre
            da = new MySqlDataAdapter("SELECT categoria,margeniniPor,margeniniImp,rebajasPor,rebajasImp,margenfinPor,margenfinImp,dppPor,dppImp,utilidadPor,utilidadImp FROM cedula4 WHERE Escenario='" + cbescenarios.Text + "' AND estructura='" + lbsucursal.Text + "' AND estructura2='" + lbestructura.Text + "' AND mes=12", Conn);
            c4 = new DataTable();
            da.Fill(c4);
            dgvCed4_Diciembre.DataSource = c4;
            dgvCed4_Diciembre.Columns[0].HeaderText = "Categoria";
            dgvCed4_Diciembre.Columns[1].HeaderText = "Margen inicial %";
            dgvCed4_Diciembre.Columns[2].HeaderText = "Margen inicial importe";
            dgvCed4_Diciembre.Columns[3].HeaderText = "Rebajas %";
            dgvCed4_Diciembre.Columns[4].HeaderText = "Rebahas importe";
            dgvCed4_Diciembre.Columns[5].HeaderText = "Margen final %";
            dgvCed4_Diciembre.Columns[6].HeaderText = "Margen final importe";
            dgvCed4_Diciembre.Columns[7].HeaderText = "Dpp %";
            dgvCed4_Diciembre.Columns[8].HeaderText = "Dpp importe";
            dgvCed4_Diciembre.Columns[9].HeaderText = "Utilidad %";
            dgvCed4_Diciembre.Columns[10].HeaderText = "Utilidad importe";
            #endregion
            #endregion
            #region cedula5a
            da = new MySqlDataAdapter("SELECT categoria mes1,mes2,mes3,mes4,mes5,mes6,mes7,mes8,mes9,mes10,mes11,mes12,saldoAcumulado FROM cedula5a WHERE nombre='"+cbescenarios.Text+"' AND estructura='"+lbsucursal.Text+"' AND estructura2='"+lbestructura.Text+"'", Conn);
            DataTable c5 = new DataTable();
            da.Fill(c5);
            dgvced5.DataSource = c5;
            dgvced5.Columns[0].HeaderText = "Categoria";
            dgvced5.Columns[1].HeaderText = "Enero";
            dgvced5.Columns[2].HeaderText = "Febrero";
            dgvced5.Columns[3].HeaderText = "Marzo";
            dgvced5.Columns[4].HeaderText = "Abril";
            dgvced5.Columns[5].HeaderText = "Mayo";
            dgvced5.Columns[6].HeaderText = "Junio";
            dgvced5.Columns[7].HeaderText = "Julio";
            dgvced5.Columns[8].HeaderText = "Agosto";
            dgvced5.Columns[9].HeaderText = "Septiembre";
            dgvced5.Columns[10].HeaderText = "Octubre";
            dgvced5.Columns[10].HeaderText = "Noviembre";
            dgvced5.Columns[10].HeaderText = "Diciembre";
            #endregion
            #region cedula5b
            #region enero
            da = new MySqlDataAdapter("SELECT categoria,DPMA,rotacioncuentasxp,plazomediopagos,plazomediocobros,diasfin,diasfinimp,diasfinutil FROM cedula5b WHERE nombre='"+cbescenarios.Text+"' AND estructura='"+lbsucursal.Text+"' AND estructura2='"+lbestructura.Text+"' AND mes=1", Conn);
            DataTable c5b = new DataTable();
            da.Fill(c5);
            dgv5enero.DataSource = c5;
            dgv5enero.Columns[0].HeaderText = "Categoria";
            dgv5enero.Columns[1].HeaderText = "Dias que permanece mercancia en almacen";
            dgv5enero.Columns[2].HeaderText = "Rotacion de cuentas por pagar";
            dgv5enero.Columns[3].HeaderText = "Plazo medio de pagos";
            dgv5enero.Columns[4].HeaderText = "Dias financiados";
            dgv5enero.Columns[5].HeaderText = "Dias financiados importe";
            dgv5enero.Columns[6].HeaderText = "Dias financiados utilidad";
            #endregion
            #region febrero
            da = new MySqlDataAdapter("SELECT categoria,DPMA,rotacioncuentasxp,plazomediopagos,plazomediocobros,diasfin,diasfinimp,diasfinutil FROM cedula5b WHERE nombre='" + cbescenarios.Text + "' AND estructura='" + lbsucursal.Text + "' AND estructura2='" + lbestructura.Text + "' AND mes=2", Conn);
            c5b = new DataTable();
            da.Fill(c5);
            dgv5febrero.DataSource = c5;
            dgv5febrero.Columns[0].HeaderText = "Categoria";
            dgv5febrero.Columns[1].HeaderText = "Dias que permanece mercancia en almacen";
            dgv5febrero.Columns[2].HeaderText = "Rotacion de cuentas por pagar";
            dgv5febrero.Columns[3].HeaderText = "Plazo medio de pagos";
            dgv5febrero.Columns[4].HeaderText = "Dias financiados";
            dgv5febrero.Columns[5].HeaderText = "Dias financiados importe";
            dgv5febrero.Columns[6].HeaderText = "Dias financiados utilidad";
            #endregion
            #region marzo
            da = new MySqlDataAdapter("SELECT categoria,DPMA,rotacioncuentasxp,plazomediopagos,plazomediocobros,diasfin,diasfinimp,diasfinutil FROM cedula5b WHERE nombre='" + cbescenarios.Text + "' AND estructura='" + lbsucursal.Text + "' AND estructura2='" + lbestructura.Text + "' AND mes=3", Conn);
            c5b = new DataTable();
            da.Fill(c5);
            dgv5marzo.DataSource = c5;
            dgv5marzo.Columns[0].HeaderText = "Categoria";
            dgv5marzo.Columns[1].HeaderText = "Dias que permanece mercancia en almacen";
            dgv5marzo.Columns[2].HeaderText = "Rotacion de cuentas por pagar";
            dgv5marzo.Columns[3].HeaderText = "Plazo medio de pagos";
            dgv5marzo.Columns[4].HeaderText = "Dias financiados";
            dgv5marzo.Columns[5].HeaderText = "Dias financiados importe";
            dgv5marzo.Columns[6].HeaderText = "Dias financiados utilidad";
            #endregion
            #region abril
            da = new MySqlDataAdapter("SELECT categoria,DPMA,rotacioncuentasxp,plazomediopagos,plazomediocobros,diasfin,diasfinimp,diasfinutil FROM cedula5b WHERE nombre='" + cbescenarios.Text + "' AND estructura='" + lbsucursal.Text + "' AND estructura2='" + lbestructura.Text + "' AND mes=4", Conn);
            c5b = new DataTable();
            da.Fill(c5);
            dgv5abril.DataSource = c5;
            dgv5abril.Columns[0].HeaderText = "Categoria";
            dgv5abril.Columns[1].HeaderText = "Dias que permanece mercancia en almacen";
            dgv5abril.Columns[2].HeaderText = "Rotacion de cuentas por pagar";
            dgv5abril.Columns[3].HeaderText = "Plazo medio de pagos";
            dgv5abril.Columns[4].HeaderText = "Dias financiados";
            dgv5abril.Columns[5].HeaderText = "Dias financiados importe";
            dgv5abril.Columns[6].HeaderText = "Dias financiados utilidad";
            #endregion
            #region mayo
            da = new MySqlDataAdapter("SELECT categoria,DPMA,rotacioncuentasxp,plazomediopagos,plazomediocobros,diasfin,diasfinimp,diasfinutil FROM cedula5b WHERE nombre='" + cbescenarios.Text + "' AND estructura='" + lbsucursal.Text + "' AND estructura2='" + lbestructura.Text + "' AND mes=5", Conn);
            c5b = new DataTable();
            da.Fill(c5);
            dgv5mayo.DataSource = c5;
            dgv5mayo.Columns[0].HeaderText = "Categoria";
            dgv5mayo.Columns[1].HeaderText = "Dias que permanece mercancia en almacen";
            dgv5mayo.Columns[2].HeaderText = "Rotacion de cuentas por pagar";
            dgv5mayo.Columns[3].HeaderText = "Plazo medio de pagos";
            dgv5mayo.Columns[4].HeaderText = "Dias financiados";
            dgv5mayo.Columns[5].HeaderText = "Dias financiados importe";
            dgv5mayo.Columns[6].HeaderText = "Dias financiados utilidad";
            #endregion
            #region Junio
            da = new MySqlDataAdapter("SELECT categoria,DPMA,rotacioncuentasxp,plazomediopagos,plazomediocobros,diasfin,diasfinimp,diasfinutil FROM cedula5b WHERE nombre='" + cbescenarios.Text + "' AND estructura='" + lbsucursal.Text + "' AND estructura2='" + lbestructura.Text + "' AND mes=6", Conn);
            c5b = new DataTable();
            da.Fill(c5);
            dgv5junio.DataSource = c5;
            dgv5junio.Columns[0].HeaderText = "Categoria";
            dgv5junio.Columns[1].HeaderText = "Dias que permanece mercancia en almacen";
            dgv5junio.Columns[2].HeaderText = "Rotacion de cuentas por pagar";
            dgv5junio.Columns[3].HeaderText = "Plazo medio de pagos";
            dgv5junio.Columns[4].HeaderText = "Dias financiados";
            dgv5junio.Columns[5].HeaderText = "Dias financiados importe";
            dgv5junio.Columns[6].HeaderText = "Dias financiados utilidad";
            #endregion
            #region Julio
            da = new MySqlDataAdapter("SELECT categoria,DPMA,rotacioncuentasxp,plazomediopagos,plazomediocobros,diasfin,diasfinimp,diasfinutil FROM cedula5b WHERE nombre='" + cbescenarios.Text + "' AND estructura='" + lbsucursal.Text + "' AND estructura2='" + lbestructura.Text + "' AND mes=7", Conn);
            c5b = new DataTable();
            da.Fill(c5);
            dgv5julio.DataSource = c5;
            dgv5julio.Columns[0].HeaderText = "Categoria";
            dgv5julio.Columns[1].HeaderText = "Dias que permanece mercancia en almacen";
            dgv5julio.Columns[2].HeaderText = "Rotacion de cuentas por pagar";
            dgv5julio.Columns[3].HeaderText = "Plazo medio de pagos";
            dgv5julio.Columns[4].HeaderText = "Dias financiados";
            dgv5julio.Columns[5].HeaderText = "Dias financiados importe";
            dgv5julio.Columns[6].HeaderText = "Dias financiados utilidad";
            #endregion
            #region Agosto
            da = new MySqlDataAdapter("SELECT categoria,DPMA,rotacioncuentasxp,plazomediopagos,plazomediocobros,diasfin,diasfinimp,diasfinutil FROM cedula5b WHERE nombre='" + cbescenarios.Text + "' AND estructura='" + lbsucursal.Text + "' AND estructura2='" + lbestructura.Text + "' AND mes=8", Conn);
            c5b = new DataTable();
            da.Fill(c5);
            dgv5agosto.DataSource = c5;
            dgv5agosto.Columns[0].HeaderText = "Categoria";
            dgv5agosto.Columns[1].HeaderText = "Dias que permanece mercancia en almacen";
            dgv5agosto.Columns[2].HeaderText = "Rotacion de cuentas por pagar";
            dgv5agosto.Columns[3].HeaderText = "Plazo medio de pagos";
            dgv5agosto.Columns[4].HeaderText = "Dias financiados";
            dgv5agosto.Columns[5].HeaderText = "Dias financiados importe";
            dgv5agosto.Columns[6].HeaderText = "Dias financiados utilidad";
            #endregion
            #region septiembre
            da = new MySqlDataAdapter("SELECT categoria,DPMA,rotacioncuentasxp,plazomediopagos,plazomediocobros,diasfin,diasfinimp,diasfinutil FROM cedula5b WHERE nombre='" + cbescenarios.Text + "' AND estructura='" + lbsucursal.Text + "' AND estructura2='" + lbestructura.Text + "' AND mes=9", Conn);
            c5b = new DataTable();
            da.Fill(c5);
            dgv5septiembre.DataSource = c5;
            dgv5septiembre.Columns[0].HeaderText = "Categoria";
            dgv5septiembre.Columns[1].HeaderText = "Dias que permanece mercancia en almacen";
            dgv5septiembre.Columns[2].HeaderText = "Rotacion de cuentas por pagar";
            dgv5septiembre.Columns[3].HeaderText = "Plazo medio de pagos";
            dgv5septiembre.Columns[4].HeaderText = "Dias financiados";
            dgv5septiembre.Columns[5].HeaderText = "Dias financiados importe";
            dgv5septiembre.Columns[6].HeaderText = "Dias financiados utilidad";
            #endregion
            #region octubre
            da = new MySqlDataAdapter("SELECT categoria,DPMA,rotacioncuentasxp,plazomediopagos,plazomediocobros,diasfin,diasfinimp,diasfinutil FROM cedula5b WHERE nombre='" + cbescenarios.Text + "' AND estructura='" + lbsucursal.Text + "' AND estructura2='" + lbestructura.Text + "' AND mes=10", Conn);
            c5b = new DataTable();
            da.Fill(c5);
            dgv5octubre.DataSource = c5;
            dgv5octubre.Columns[0].HeaderText = "Categoria";
            dgv5octubre.Columns[1].HeaderText = "Dias que permanece mercancia en almacen";
            dgv5octubre.Columns[2].HeaderText = "Rotacion de cuentas por pagar";
            dgv5octubre.Columns[3].HeaderText = "Plazo medio de pagos";
            dgv5octubre.Columns[4].HeaderText = "Dias financiados";
            dgv5octubre.Columns[5].HeaderText = "Dias financiados importe";
            dgv5octubre.Columns[6].HeaderText = "Dias financiados utilidad";
            #endregion
            #region noviembre
            da = new MySqlDataAdapter("SELECT categoria,DPMA,rotacioncuentasxp,plazomediopagos,plazomediocobros,diasfin,diasfinimp,diasfinutil FROM cedula5b WHERE nombre='" + cbescenarios.Text + "' AND estructura='" + lbsucursal.Text + "' AND estructura2='" + lbestructura.Text + "' AND mes=11", Conn);
            c5b = new DataTable();
            da.Fill(c5);
            dgv5noviembre.DataSource = c5;
            dgv5noviembre.Columns[0].HeaderText = "Categoria";
            dgv5noviembre.Columns[1].HeaderText = "Dias que permanece mercancia en almacen";
            dgv5noviembre.Columns[2].HeaderText = "Rotacion de cuentas por pagar";
            dgv5noviembre.Columns[3].HeaderText = "Plazo medio de pagos";
            dgv5noviembre.Columns[4].HeaderText = "Dias financiados";
            dgv5noviembre.Columns[5].HeaderText = "Dias financiados importe";
            dgv5noviembre.Columns[6].HeaderText = "Dias financiados utilidad";
            #endregion
            #region diciembre
            da = new MySqlDataAdapter("SELECT categoria,DPMA,rotacioncuentasxp,plazomediopagos,plazomediocobros,diasfin,diasfinimp,diasfinutil FROM cedula5b WHERE nombre='" + cbescenarios.Text + "' AND estructura='" + lbsucursal.Text + "' AND estructura2='" + lbestructura.Text + "' AND mes=12", Conn);
            c5b = new DataTable();
            da.Fill(c5);
            dgv5diciembre.DataSource = c5;
            dgv5diciembre.Columns[0].HeaderText = "Categoria";
            dgv5diciembre.Columns[1].HeaderText = "Dias que permanece mercancia en almacen";
            dgv5diciembre.Columns[2].HeaderText = "Rotacion de cuentas por pagar";
            dgv5diciembre.Columns[3].HeaderText = "Plazo medio de pagos";
            dgv5diciembre.Columns[4].HeaderText = "Dias financiados";
            dgv5diciembre.Columns[5].HeaderText = "Dias financiados importe";
            dgv5diciembre.Columns[6].HeaderText = "Dias financiados utilidad";
            #endregion
            #endregion
            #region cedula6a
            #region enero
            da = new MySqlDataAdapter("SELECT estructura2,utilidadproductopor,utilidadproductoImp,utilidadfinanciamientopor,utilidadfinanciamientoImp,udiasfinanciados FROM cedula6a WHERE nombre='"+cbescenarios.Text+"' AND sucursal='"+lbsucursal.Text+"' AND estructura='"+lbestructura.Text+"' AND mes=1", Conn);
            DataTable c6a= new DataTable();
            da.Fill(c6a);
            dgv6aenero.DataSource = c6a;
            dgv6aenero.Columns[0].HeaderText = "Categoria";
            dgv6aenero.Columns[1].HeaderText = "Utilidad de producto %";
            dgv6aenero.Columns[2].HeaderText = "Utilidad de producto importe";
            dgv6aenero.Columns[3].HeaderText = "Utilidad de financiamiento %";
            dgv6aenero.Columns[4].HeaderText = "Utilidad de financiamiento importe";
            dgv6aenero.Columns[5].HeaderText = "Utilidad de dias financiados";
            #endregion
            #region febrero
            da = new MySqlDataAdapter("SELECT estructura2,utilidadproductopor,utilidadproductoImp,utilidadfinanciamientopor,utilidadfinanciamientoImp,udiasfinanciados FROM cedula6a WHERE nombre='" + cbescenarios.Text + "' AND sucursal='" + lbsucursal.Text + "' AND estructura='" + lbestructura.Text + "' AND mes=2", Conn);
            c6a = new DataTable();
            da.Fill(c6a);
            dgv6afebrero.DataSource = c6a;
            dgv6afebrero.Columns[0].HeaderText = "Categoria";
            dgv6afebrero.Columns[1].HeaderText = "Utilidad de producto %";
            dgv6afebrero.Columns[2].HeaderText = "Utilidad de producto importe";
            dgv6afebrero.Columns[3].HeaderText = "Utilidad de financiamiento %";
            dgv6afebrero.Columns[4].HeaderText = "Utilidad de financiamiento importe";
            dgv6afebrero.Columns[5].HeaderText = "Utilidad de dias financiados";
            #endregion
            #region marzo
            da = new MySqlDataAdapter("SELECT estructura2,utilidadproductopor,utilidadproductoImp,utilidadfinanciamientopor,utilidadfinanciamientoImp,udiasfinanciados FROM cedula6a WHERE nombre='" + cbescenarios.Text + "' AND sucursal='" + lbsucursal.Text + "' AND estructura='" + lbestructura.Text + "' AND mes=3", Conn);
            c6a = new DataTable();
            da.Fill(c6a);
            dgv6amarzo.DataSource = c6a;
            dgv6amarzo.Columns[0].HeaderText = "Categoria";
            dgv6amarzo.Columns[1].HeaderText = "Utilidad de producto %";
            dgv6amarzo.Columns[2].HeaderText = "Utilidad de producto importe";
            dgv6amarzo.Columns[3].HeaderText = "Utilidad de financiamiento %";
            dgv6amarzo.Columns[4].HeaderText = "Utilidad de financiamiento importe";
            dgv6amarzo.Columns[5].HeaderText = "Utilidad de dias financiados";
            #endregion
            #region abril
            da = new MySqlDataAdapter("SELECT estructura2,utilidadproductopor,utilidadproductoImp,utilidadfinanciamientopor,utilidadfinanciamientoImp,udiasfinanciados FROM cedula6a WHERE nombre='" + cbescenarios.Text + "' AND sucursal='" + lbsucursal.Text + "' AND estructura='" + lbestructura.Text + "' AND mes=4", Conn);
            c6a = new DataTable();
            da.Fill(c6a);
            dgv6aabril.DataSource = c6a;
            dgv6aabril.Columns[0].HeaderText = "Categoria";
            dgv6aabril.Columns[1].HeaderText = "Utilidad de producto %";
            dgv6aabril.Columns[2].HeaderText = "Utilidad de producto importe";
            dgv6aabril.Columns[3].HeaderText = "Utilidad de financiamiento %";
            dgv6aabril.Columns[4].HeaderText = "Utilidad de financiamiento importe";
            dgv6aabril.Columns[5].HeaderText = "Utilidad de dias financiados";
            #endregion
            #region mayo
            da = new MySqlDataAdapter("SELECT estructura2,utilidadproductopor,utilidadproductoImp,utilidadfinanciamientopor,utilidadfinanciamientoImp,udiasfinanciados FROM cedula6a WHERE nombre='" + cbescenarios.Text + "' AND sucursal='" + lbsucursal.Text + "' AND estructura='" + lbestructura.Text + "' AND mes=5", Conn);
            c6a = new DataTable();
            da.Fill(c6a);
            dgv6amayo.DataSource = c6a;
            dgv6amayo.Columns[0].HeaderText = "Categoria";
            dgv6amayo.Columns[1].HeaderText = "Utilidad de producto %";
            dgv6amayo.Columns[2].HeaderText = "Utilidad de producto importe";
            dgv6amayo.Columns[3].HeaderText = "Utilidad de financiamiento %";
            dgv6amayo.Columns[4].HeaderText = "Utilidad de financiamiento importe";
            dgv6amayo.Columns[5].HeaderText = "Utilidad de dias financiados";
            #endregion
            #region junio
            da = new MySqlDataAdapter("SELECT estructura2,utilidadproductopor,utilidadproductoImp,utilidadfinanciamientopor,utilidadfinanciamientoImp,udiasfinanciados FROM cedula6a WHERE nombre='" + cbescenarios.Text + "' AND sucursal='" + lbsucursal.Text + "' AND estructura='" + lbestructura.Text + "' AND mes=6", Conn);
            c6a = new DataTable();
            da.Fill(c6a);
            dgv6ajunio.DataSource = c6a;
            dgv6ajunio.Columns[0].HeaderText = "Categoria";
            dgv6ajunio.Columns[1].HeaderText = "Utilidad de producto %";
            dgv6ajunio.Columns[2].HeaderText = "Utilidad de producto importe";
            dgv6ajunio.Columns[3].HeaderText = "Utilidad de financiamiento %";
            dgv6ajunio.Columns[4].HeaderText = "Utilidad de financiamiento importe";
            dgv6ajunio.Columns[5].HeaderText = "Utilidad de dias financiados";
            #endregion
            #region julio
            da = new MySqlDataAdapter("SELECT estructura2,utilidadproductopor,utilidadproductoImp,utilidadfinanciamientopor,utilidadfinanciamientoImp,udiasfinanciados FROM cedula6a WHERE nombre='" + cbescenarios.Text + "' AND sucursal='" + lbsucursal.Text + "' AND estructura='" + lbestructura.Text + "' AND mes=7", Conn);
            c6a = new DataTable();
            da.Fill(c6a);
            dgv6ajulio.DataSource = c6a;
            dgv6ajulio.Columns[0].HeaderText = "Categoria";
            dgv6ajulio.Columns[1].HeaderText = "Utilidad de producto %";
            dgv6ajulio.Columns[2].HeaderText = "Utilidad de producto importe";
            dgv6ajulio.Columns[3].HeaderText = "Utilidad de financiamiento %";
            dgv6ajulio.Columns[4].HeaderText = "Utilidad de financiamiento importe";
            dgv6ajulio.Columns[5].HeaderText = "Utilidad de dias financiados";
            #endregion
            #region agosto
            da = new MySqlDataAdapter("SELECT estructura2,utilidadproductopor,utilidadproductoImp,utilidadfinanciamientopor,utilidadfinanciamientoImp,udiasfinanciados FROM cedula6a WHERE nombre='" + cbescenarios.Text + "' AND sucursal='" + lbsucursal.Text + "' AND estructura='" + lbestructura.Text + "' AND mes=8", Conn);
            c6a = new DataTable();
            da.Fill(c6a);
            dgv6aagosto.DataSource = c6a;
            dgv6aagosto.Columns[0].HeaderText = "Categoria";
            dgv6aagosto.Columns[1].HeaderText = "Utilidad de producto %";
            dgv6aagosto.Columns[2].HeaderText = "Utilidad de producto importe";
            dgv6aagosto.Columns[3].HeaderText = "Utilidad de financiamiento %";
            dgv6aagosto.Columns[4].HeaderText = "Utilidad de financiamiento importe";
            dgv6aagosto.Columns[5].HeaderText = "Utilidad de dias financiados";
            #endregion
            #region septiembre
            da = new MySqlDataAdapter("SELECT estructura2,utilidadproductopor,utilidadproductoImp,utilidadfinanciamientopor,utilidadfinanciamientoImp,udiasfinanciados FROM cedula6a WHERE nombre='" + cbescenarios.Text + "' AND sucursal='" + lbsucursal.Text + "' AND estructura='" + lbestructura.Text + "' AND mes=9", Conn);
            c6a = new DataTable();
            da.Fill(c6a);
            dgv6aseptiembre.DataSource = c6a;
            dgv6aseptiembre.Columns[0].HeaderText = "Categoria";
            dgv6aseptiembre.Columns[1].HeaderText = "Utilidad de producto %";
            dgv6aseptiembre.Columns[2].HeaderText = "Utilidad de producto importe";
            dgv6aseptiembre.Columns[3].HeaderText = "Utilidad de financiamiento %";
            dgv6aseptiembre.Columns[4].HeaderText = "Utilidad de financiamiento importe";
            dgv6aseptiembre.Columns[5].HeaderText = "Utilidad de dias financiados";
            #endregion
            #region octubre
            da = new MySqlDataAdapter("SELECT estructura2,utilidadproductopor,utilidadproductoImp,utilidadfinanciamientopor,utilidadfinanciamientoImp,udiasfinanciados FROM cedula6a WHERE nombre='" + cbescenarios.Text + "' AND sucursal='" + lbsucursal.Text + "' AND estructura='" + lbestructura.Text + "' AND mes=10", Conn);
            c6a = new DataTable();
            da.Fill(c6a);
            dgv6aoctubre.DataSource = c6a;
            dgv6aoctubre.Columns[0].HeaderText = "Categoria";
            dgv6aoctubre.Columns[1].HeaderText = "Utilidad de producto %";
            dgv6aoctubre.Columns[2].HeaderText = "Utilidad de producto importe";
            dgv6aoctubre.Columns[3].HeaderText = "Utilidad de financiamiento %";
            dgv6aoctubre.Columns[4].HeaderText = "Utilidad de financiamiento importe";
            dgv6aoctubre.Columns[5].HeaderText = "Utilidad de dias financiados";
            #endregion
            #region noviembre
            da = new MySqlDataAdapter("SELECT estructura2,utilidadproductopor,utilidadproductoImp,utilidadfinanciamientopor,utilidadfinanciamientoImp,udiasfinanciados FROM cedula6a WHERE nombre='" + cbescenarios.Text + "' AND sucursal='" + lbsucursal.Text + "' AND estructura='" + lbestructura.Text + "' AND mes=11", Conn);
            c6a = new DataTable();
            da.Fill(c6a);
            dgv6anoviembre.DataSource = c6a;
            dgv6anoviembre.Columns[0].HeaderText = "Categoria";
            dgv6anoviembre.Columns[1].HeaderText = "Utilidad de producto %";
            dgv6anoviembre.Columns[2].HeaderText = "Utilidad de producto importe";
            dgv6anoviembre.Columns[3].HeaderText = "Utilidad de financiamiento %";
            dgv6anoviembre.Columns[4].HeaderText = "Utilidad de financiamiento importe";
            dgv6anoviembre.Columns[5].HeaderText = "Utilidad de dias financiados";
            #endregion
            #region diciembre
            da = new MySqlDataAdapter("SELECT estructura2,utilidadproductopor,utilidadproductoImp,utilidadfinanciamientopor,utilidadfinanciamientoImp,udiasfinanciados FROM cedula6a WHERE nombre='" + cbescenarios.Text + "' AND sucursal='" + lbsucursal.Text + "' AND estructura='" + lbestructura.Text + "' AND mes=12", Conn);
            c6a = new DataTable();
            da.Fill(c6a);
            dgv6adiciembre.DataSource = c6a;
            dgv6adiciembre.Columns[0].HeaderText = "Categoria";
            dgv6adiciembre.Columns[1].HeaderText = "Utilidad de producto %";
            dgv6adiciembre.Columns[2].HeaderText = "Utilidad de producto importe";
            dgv6adiciembre.Columns[3].HeaderText = "Utilidad de financiamiento %";
            dgv6adiciembre.Columns[4].HeaderText = "Utilidad de financiamiento importe";
            dgv6adiciembre.Columns[5].HeaderText = "Utilidad de dias financiados";
            #endregion
            #endregion
            #region cedula6b
            #region enero
            da = new MySqlDataAdapter("SELECT categoria,costoxdiasfin,utilidadperdidaxfin,perdida,utilidad FROM cedula6b WHERE nombre='"+cbescenarios.Text+"' AND sucursal='"+lbsucursal.Text+"' AND estructura='"+lbestructura.Text+"' AND mes=1", Conn);
            DataTable c6b = new DataTable();
            da.Fill(c6b);
            dgvEnerob.DataSource = c6b;
            dgvEnerob.Columns[0].HeaderText = "Categoria";
            dgvEnerob.Columns[1].HeaderText = "Costo por dias financiados";
            dgvEnerob.Columns[2].HeaderText = "Utilidad/perdida por dias financiados";
            dgvEnerob.Columns[3].HeaderText = "Perdida";
            dgvEnerob.Columns[4].HeaderText = "Utilidad";
            #endregion
            #region febrero
            da = new MySqlDataAdapter("SELECT categoria,costoxdiasfin,utilidadperdidaxfin,perdida,utilidad FROM cedula6b WHERE nombre='" + cbescenarios.Text + "' AND sucursal='" + lbsucursal.Text + "' AND estructura='" + lbestructura.Text + "' AND mes=2", Conn);
            c6b = new DataTable();
            da.Fill(c6b);
            dgvFebrerob.DataSource = c6b;
            dgvFebrerob.Columns[0].HeaderText = "Categoria";
            dgvFebrerob.Columns[1].HeaderText = "Costo por dias financiados";
            dgvFebrerob.Columns[2].HeaderText = "Utilidad/perdida por dias financiados";
            dgvFebrerob.Columns[3].HeaderText = "Perdida";
            dgvFebrerob.Columns[4].HeaderText = "Utilidad";
            #endregion
            #region marzo
            da = new MySqlDataAdapter("SELECT categoria,costoxdiasfin,utilidadperdidaxfin,perdida,utilidad FROM cedula6b WHERE nombre='" + cbescenarios.Text + "' AND sucursal='" + lbsucursal.Text + "' AND estructura='" + lbestructura.Text + "' AND mes=3", Conn);
            c6b = new DataTable();
            da.Fill(c6b);
            dgvMarzob.DataSource = c6b;
            dgvMarzob.Columns[0].HeaderText = "Categoria";
            dgvMarzob.Columns[1].HeaderText = "Costo por dias financiados";
            dgvMarzob.Columns[2].HeaderText = "Utilidad/perdida por dias financiados";
            dgvMarzob.Columns[3].HeaderText = "Perdida";
            dgvMarzob.Columns[4].HeaderText = "Utilidad";
            #endregion
            #region abril
            da = new MySqlDataAdapter("SELECT categoria,costoxdiasfin,utilidadperdidaxfin,perdida,utilidad FROM cedula6b WHERE nombre='" + cbescenarios.Text + "' AND sucursal='" + lbsucursal.Text + "' AND estructura='" + lbestructura.Text + "' AND mes=4", Conn);
            c6b = new DataTable();
            da.Fill(c6b);
            dgvAbrilb.DataSource = c6b;
            dgvAbrilb.Columns[0].HeaderText = "Categoria";
            dgvAbrilb.Columns[1].HeaderText = "Costo por dias financiados";
            dgvAbrilb.Columns[2].HeaderText = "Utilidad/perdida por dias financiados";
            dgvAbrilb.Columns[3].HeaderText = "Perdida";
            dgvAbrilb.Columns[4].HeaderText = "Utilidad";
            #endregion
            #region mayo
            da = new MySqlDataAdapter("SELECT categoria,costoxdiasfin,utilidadperdidaxfin,perdida,utilidad FROM cedula6b WHERE nombre='" + cbescenarios.Text + "' AND sucursal='" + lbsucursal.Text + "' AND estructura='" + lbestructura.Text + "' AND mes=5", Conn);
            c6b = new DataTable();
            da.Fill(c6b);
            dgvMayob.DataSource = c6b;
            dgvMayob.Columns[0].HeaderText = "Categoria";
            dgvMayob.Columns[1].HeaderText = "Costo por dias financiados";
            dgvMayob.Columns[2].HeaderText = "Utilidad/perdida por dias financiados";
            dgvMayob.Columns[3].HeaderText = "Perdida";
            dgvMayob.Columns[4].HeaderText = "Utilidad";
            #endregion
            #region Junio
            da = new MySqlDataAdapter("SELECT categoria,costoxdiasfin,utilidadperdidaxfin,perdida,utilidad FROM cedula6b WHERE nombre='" + cbescenarios.Text + "' AND sucursal='" + lbsucursal.Text + "' AND estructura='" + lbestructura.Text + "' AND mes=6", Conn);
            c6b = new DataTable();
            da.Fill(c6b);
            dgvJuniob.DataSource = c6b;
            dgvJuniob.Columns[0].HeaderText = "Categoria";
            dgvJuniob.Columns[1].HeaderText = "Costo por dias financiados";
            dgvJuniob.Columns[2].HeaderText = "Utilidad/perdida por dias financiados";
            dgvJuniob.Columns[3].HeaderText = "Perdida";
            dgvJuniob.Columns[4].HeaderText = "Utilidad";
            #endregion
            #region julio
            da = new MySqlDataAdapter("SELECT categoria,costoxdiasfin,utilidadperdidaxfin,perdida,utilidad FROM cedula6b WHERE nombre='" + cbescenarios.Text + "' AND sucursal='" + lbsucursal.Text + "' AND estructura='" + lbestructura.Text + "' AND mes=7", Conn);
            c6b = new DataTable();
            da.Fill(c6b);
            dgvJuliob.DataSource = c6b;
            dgvJuliob.Columns[0].HeaderText = "Categoria";
            dgvJuliob.Columns[1].HeaderText = "Costo por dias financiados";
            dgvJuliob.Columns[2].HeaderText = "Utilidad/perdida por dias financiados";
            dgvJuliob.Columns[3].HeaderText = "Perdida";
            dgvJuliob.Columns[4].HeaderText = "Utilidad";
            #endregion
            #region agosto
            da = new MySqlDataAdapter("SELECT categoria,costoxdiasfin,utilidadperdidaxfin,perdida,utilidad FROM cedula6b WHERE nombre='" + cbescenarios.Text + "' AND sucursal='" + lbsucursal.Text + "' AND estructura='" + lbestructura.Text + "' AND mes=8", Conn);
            c6b = new DataTable();
            da.Fill(c6b);
            dgvAgostob.DataSource = c6b;
            dgvAgostob.Columns[0].HeaderText = "Categoria";
            dgvAgostob.Columns[1].HeaderText = "Costo por dias financiados";
            dgvAgostob.Columns[2].HeaderText = "Utilidad/perdida por dias financiados";
            dgvAgostob.Columns[3].HeaderText = "Perdida";
            dgvAgostob.Columns[4].HeaderText = "Utilidad";
            #endregion
            #region septiembre
            da = new MySqlDataAdapter("SELECT categoria,costoxdiasfin,utilidadperdidaxfin,perdida,utilidad FROM cedula6b WHERE nombre='" + cbescenarios.Text + "' AND sucursal='" + lbsucursal.Text + "' AND estructura='" + lbestructura.Text + "' AND mes=9", Conn);
            c6b = new DataTable();
            da.Fill(c6b);
            dgvSeptiembreb.DataSource = c6b;
            dgvSeptiembreb.Columns[0].HeaderText = "Categoria";
            dgvSeptiembreb.Columns[1].HeaderText = "Costo por dias financiados";
            dgvSeptiembreb.Columns[2].HeaderText = "Utilidad/perdida por dias financiados";
            dgvSeptiembreb.Columns[3].HeaderText = "Perdida";
            dgvSeptiembreb.Columns[4].HeaderText = "Utilidad";
            #endregion
            #region octubre
            da = new MySqlDataAdapter("SELECT categoria,costoxdiasfin,utilidadperdidaxfin,perdida,utilidad FROM cedula6b WHERE nombre='" + cbescenarios.Text + "' AND sucursal='" + lbsucursal.Text + "' AND estructura='" + lbestructura.Text + "' AND mes=10", Conn);
            c6b = new DataTable();
            da.Fill(c6b);
            dgvOctubreb.DataSource = c6b;
            dgvOctubreb.Columns[0].HeaderText = "Categoria";
            dgvOctubreb.Columns[1].HeaderText = "Costo por dias financiados";
            dgvOctubreb.Columns[2].HeaderText = "Utilidad/perdida por dias financiados";
            dgvOctubreb.Columns[3].HeaderText = "Perdida";
            dgvOctubreb.Columns[4].HeaderText = "Utilidad";
            #endregion
            #region noviembre
            da = new MySqlDataAdapter("SELECT categoria,costoxdiasfin,utilidadperdidaxfin,perdida,utilidad FROM cedula6b WHERE nombre='" + cbescenarios.Text + "' AND sucursal='" + lbsucursal.Text + "' AND estructura='" + lbestructura.Text + "' AND mes=11", Conn);
            c6b = new DataTable();
            da.Fill(c6b);
            dgvNoviembreb.DataSource = c6b;
            dgvNoviembreb.Columns[0].HeaderText = "Categoria";
            dgvNoviembreb.Columns[1].HeaderText = "Costo por dias financiados";
            dgvNoviembreb.Columns[2].HeaderText = "Utilidad/perdida por dias financiados";
            dgvNoviembreb.Columns[3].HeaderText = "Perdida";
            dgvNoviembreb.Columns[4].HeaderText = "Utilidad";
            #endregion
            #region diciembre
            da = new MySqlDataAdapter("SELECT categoria,costoxdiasfin,utilidadperdidaxfin,perdida,utilidad FROM cedula6b WHERE nombre='" + cbescenarios.Text + "' AND sucursal='" + lbsucursal.Text + "' AND estructura='" + lbestructura.Text + "' AND mes=12", Conn);
            c6b = new DataTable();
            da.Fill(c6b);
            dgvDiciembreb.DataSource = c6b;
            dgvDiciembreb.Columns[0].HeaderText = "Categoria";
            dgvDiciembreb.Columns[1].HeaderText = "Costo por dias financiados";
            dgvDiciembreb.Columns[2].HeaderText = "Utilidad/perdida por dias financiados";
            dgvDiciembreb.Columns[3].HeaderText = "Perdida";
            dgvDiciembreb.Columns[4].HeaderText = "Utilidad";
            #endregion
            #endregion
            #region cedula7
            #endregion
        }

        private void reportes_Load(object sender, EventArgs e)
        {

        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opciones o = new Opciones();
            o.Show();
            this.Close();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbescenarios_TextChanged(object sender, EventArgs e)
        {
            lbsucursal.Text = "";
            lbestructura.Text = "";
            query = "SELECT sucursal,estructura FROM escenarios where nombre='"+cbescenarios.Text+"'";
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lbsucursal.Text=reader["sucursal"].ToString();
                lbestructura.Text=reader["estructura"].ToString();
            }
            reader.Close();
        }
    }
}
