using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace business_plan
{
    public partial class Menu : Form
    {
        #region variables conexion

        private MySqlConnection Conn;
        private string query;
        private MySqlCommand cmd;
        private MySqlDataReader reader;


        private string conexion = "SERVER=" + Properties.Settings.Default.server + "; DATABASE=dwh; user=" + Properties.Settings.Default.usuario + "; PASSWORD=" + Properties.Settings.Default.pass + ";";      //  private string conexion2 = "SERVER=10.10.1.76; DATABASE=cipsis; user=root; PASSWORD=zaptorre;";
        //private string conexion = "SERVER=localhost; DATABASE=cipsis; user=root; PASSWORD=;";
         // private string conexion = "SERVER=localhost; DATABASE=dwh; user=root; PASSWORD= ;";

        #endregion variables conexion
        #region variables globales
        string[] nombre=new string[1000];
        string[] escenario =new string[10000];
        string[] idsucursal = new string[10000];
        string[] iddivision = new string[10000];
        string[] iddepto = new string[100000];
        string[] idfamilia = new string[10000];
        string[] idlinea = new string[10000];
        string[] idl1 = new string[10000];
        string[] idl2 = new string[10000];
        string[] idl3 = new string[10000];
        string[] idl4 = new string[10000];
        string[] idl5 = new string[10000];
        string[] idl6 = new string[10000];
        string[] idmarca = new string[1000];
        string sucursal = "";
        string division = "";
        string departamento = "";
        string familia = "";
        string linea = "";
        string linea1 = "";
        string linea2 = "";
        string linea3 = "";
        string linea4 = "";
        string linea5 = "";
        string linea6 = "";
        string marca = "";
        #region variables drop
        string  depto = "", fam = "", subl1, subl2, subl3, subl4, subl5, subl6, mark;
        string[] index=new string[10000];
        string solocalzadoDropdown = "";
        #endregion
        #endregion
        #region variables datos form 
        //pablo 
        bool bandera_sucursal = false; int seleccion_sucursal = 0;
        bool bandera_division = false; int seleccion_division = 0;
        bool bandera_depto = false; int seleccion_depto = 0;
        bool bandera_familia = false; int seleccion_familia = 0;
        bool bandera_linea = false; int seleccion_linea = 0;
        bool bandera_l1 = false; int seleccion_l1 = 0;
        bool bandera_l2 = false; int seleccion_l2 = 0;
        bool bandera_l3 = false; int seleccion_l3 = 0;
        bool bandera_l4 = false; int seleccion_l4 = 0;
        bool bandera_l5 = false; int seleccion_l5 = 0;
        bool bandera_l6 = false; int seleccion_l6 = 0;
        bool bandera_marca = false; string seleccion_marca = "";
        bool valoresform = false;
        #endregion 


        public Menu()
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
                MessageBox.Show(ex.ErrorCode.ToString());
                //if (ex.ErrorCode == -2147467259)
                //{
                //    while(Conn.State!=System.Data.ConnectionState.Open)
                //    {
                //        try
                //        {
                //            Conn.Open();
                //        }
                //        catch (MySqlException exx)
                //        {

                //        }
                //    }
                //}
            }

            #endregion Abrir conexion dwh
        }
        private void checaConexion()
        {
            if (Conn.Ping()==false)
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

        private void Menu_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.escenario = "LOL";
            //Properties.Settings.Default.usuario = true;
            Properties.Settings.Default.Save();
            this.Refresh();
        }

        private void button1_Enter(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                string[] sucursal = comboBox1.Text.Split(',');
                Properties.Settings.Default.pass = sucursal[2];
                Properties.Settings.Default.server = sucursal[1];
                Properties.Settings.Default.Save();
                Cedula1 c1 = new Cedula1();
                c1.Show();
                this.Close();
            }
            else { MessageBox.Show("Selecciona un escenario"); comboBox1.DroppedDown = true; }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {

                //Cedula1 c1 = new Cedula1(seleccion_sucursal, -1, -1, -1, seleccion_linea, -1, -1, -1, -1, -1, -1, "");
                //Cedula1 c1 = new Cedula1(seleccion_sucursal, seleccion_division, seleccion_depto, seleccion_familia, seleccion_linea, seleccion_l1, seleccion_l2, seleccion_l3, seleccion_l4, seleccion_l5, seleccion_l6, seleccion_marca);
                
               // c1.Show(); this.Close();     
                Cedula1 c1 = new Cedula1();
                this.Hide();
                c1.ShowDialog();
                this.Close();
            }
            else { MessageBox.Show("Selecciona un escenario"); comboBox1.DroppedDown = true; }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                //string[] sucursal = comboBox1.Text.Split(',');
                //Properties.Settings.Default.estructura = sucursal[2];
                //Properties.Settings.Default.sucursal = sucursal[1];
                //Properties.Settings.Default.Save();
               // Cedula2 c2 = new Cedula2(seleccion_sucursal, seleccion_division, seleccion_depto, seleccion_familia, seleccion_linea, seleccion_l1, seleccion_l2, seleccion_l3, seleccion_l4, seleccion_l5, seleccion_l6, seleccion_marca);
              
               // Cedula2 c2 = new Cedula2(seleccion_sucursal, seleccion_division, seleccion_depto, seleccion_familia, seleccion_linea, seleccion_l1, seleccion_l2, seleccion_l3, seleccion_l4, seleccion_l5, seleccion_l6, seleccion_marca);
                Cedula2 c2 = new Cedula2();
                this.Hide();
                c2.ShowDialog();
                this.Close();
            }
            else { MessageBox.Show("Selecciona un escenario"); comboBox1.DroppedDown = true; }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {

                //Cedula3 c3 = new Cedula3(seleccion_sucursal, seleccion_division, seleccion_depto, seleccion_familia, seleccion_linea, seleccion_l1, seleccion_l2, seleccion_l3, seleccion_l4, seleccion_l5, seleccion_l6, seleccion_marca);
                Cedula3 c3 = new Cedula3();
                this.Hide();
                c3.ShowDialog();
                this.Close();
            }
            else { MessageBox.Show("Selecciona un escenario"); comboBox1.DroppedDown = true; }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                //Cedula4 c4 = new Cedula4(seleccion_sucursal, seleccion_division, seleccion_depto, seleccion_familia, seleccion_linea, seleccion_l1, seleccion_l2, seleccion_l3, seleccion_l4, seleccion_l5, seleccion_l6, seleccion_marca);
                cedula4 c4 = new cedula4();
                this.Hide();
                c4.ShowDialog();
                this.Close();

            }
            else { MessageBox.Show("Selecciona un escenario"); comboBox1.DroppedDown = true; }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                /*             
                cedula5 c5 = new cedula5(seleccion_sucursal, seleccion_division, seleccion_depto, seleccion_familia, seleccion_linea, seleccion_l1, seleccion_l2, seleccion_l3, seleccion_l4, seleccion_l5, seleccion_l6, seleccion_marca);
                c5.Show(); this.Close();
               */
                cedula5 c5 = new cedula5();
                this.Hide();
                c5.ShowDialog();
                this.Close();
            }
            else { MessageBox.Show("Selecciona un escenario"); comboBox1.DroppedDown = true; }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            richTextBox1.Text = ("Cedula 1") + System.Environment.NewLine;
            richTextBox1.Text += "Pronostico de ventas" + System.Environment.NewLine;
            richTextBox1.Text += "Captura de nivel de inventario" + System.Environment.NewLine;
            richTextBox1.Text += "Captura de rotacion" + System.Environment.NewLine;
            richTextBox1.Text += "Captura de precio de venta unitario" + System.Environment.NewLine;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                Cedula8 c8 = new Cedula8();
                this.Hide();
                c8.ShowDialog();
                this.Close(); 
            }
            else { MessageBox.Show("Selecciona un escenario"); comboBox1.DroppedDown = true; }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                Cedula7 c7 = new Cedula7();
                this.Hide();
                c7.ShowDialog();
                this.Close();
                /*
                Cedula7 c7 = new Cedula7(seleccion_sucursal, seleccion_division, seleccion_depto, seleccion_familia, seleccion_linea, seleccion_l1, seleccion_l2, seleccion_l3, seleccion_l4, seleccion_l5, seleccion_l6, seleccion_marca);
                c7.Show();this.Close();
                */
            }
            else { MessageBox.Show("Seleccciona un escenario"); comboBox1.DroppedDown = true; }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {

                cedula6 c6 = new cedula6();
                this.Hide();
                c6.ShowDialog();
                this.Close();
                //cedula6 c6 = new cedula6(seleccion_sucursal, seleccion_division, seleccion_depto, seleccion_familia, seleccion_linea, seleccion_l1, seleccion_l2, seleccion_l3, seleccion_l4, seleccion_l5, seleccion_l6, seleccion_marca);
           
                //c6.Show();this.Close();
                
            }
            else { MessageBox.Show("Selecciona un escenario"); comboBox1.DroppedDown = true; }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            //formarcadena();
            query = "SELECT distinct nombre from escenarios";
            checaConexion();
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["nombre"].ToString());
            }
            reader.Close();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Opciones o = new Opciones();
            this.Hide();
            o.ShowDialog();
            this.Close();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            //string[] sucursal = comboBox1.Text.Split(',');
            //Properties.Settings.Default.escenario = sucursal[0];
            Properties.Settings.Default.escenario = comboBox1.Text;
            Properties.Settings.Default.Save();
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
            Log_in log = new Log_in();
            this.Hide();
            log.ShowDialog();
            this.Close();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log_in log = new Log_in();
            this.Hide();
            log.ShowDialog();
            this.Close();
        }
        public void formarcadena()
        {
            int i = 0;
            query = "SELECT * from cedula2";
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //comboBox1.Items.Add(reader["nombre"].ToString());
                nombre[i] = reader["nombre"].ToString();
                idsucursal[i]=reader["idsucursal"].ToString();
                iddivision[i]=reader["iddivisiones"].ToString();
                iddepto[i]=reader["iddepto"].ToString();
                idfamilia[i]=reader["idfamilia"].ToString();
                idlinea[i]=reader["idlinea"].ToString();
                idl1[i]=reader["idl1"].ToString();
                idl2[i]=reader["idl2"].ToString();
                idl3[i]=reader["idl3"].ToString();
                idl4[i]=reader["idl4"].ToString();
                idl5[i]=reader["idl5"].ToString();
                idl6[i]=reader["idl6"].ToString();
                idmarca[i]=reader["marca"].ToString();
                i++;
            }
            reader.Close();
            for(int x=0;x<=i-1;x++)
            {
                #region sucursal
               
                
                    if (idsucursal[x] == "0")
                    {
                        sucursal = "Total";
                    }
                    else
                    {
                        query = "SELECT descrip from sucursal where idsucursal=" + idsucursal[x];
                        cmd = new MySqlCommand(query, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            sucursal = reader["descrip"].ToString();
                        }
                        reader.Close();
                    }
                
                #endregion
                #region division
                
                    if (iddivision[x] == "0")
                    {
                        division = "Total";
                    }
                    else
                    {
                        query = "SELECT descrip from estdivisiones where iddivisiones=" + iddivision[x];
                        cmd = new MySqlCommand(query, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            division = reader["descrip"].ToString();
                        }
                        reader.Close();
                    }
                

                #endregion
                #region departamento
                
                    if (iddepto[x] == "0")
                    {
                        departamento = "Total";
                    }
                    else
                    {
                        query = "SELECT descrip from estdepartamento where iddepto=" + iddepto[x];
                        cmd = new MySqlCommand(query, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            departamento = reader["descrip"].ToString();
                        }
                        reader.Close();
                    }
                
                #endregion
                #region familia
                
                
                    if (idfamilia[x] == "0")
                    {
                        familia = "Total";
                    }
                    else
                    {
                        query = "SELECT descrip from estfamilia where idfamilia=" + idfamilia[x];
                        cmd = new MySqlCommand(query, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            familia = reader["descrip"].ToString();
                        }
                        reader.Close();
                    }
                
                #endregion
                #region linea
               
                    if (idlinea[x] == "0")
                    {
                        linea = "Total";
                    }
                    else
                    {
                        query = "SELECT descrip from estlinea where idlinea=" + idlinea[x];
                        cmd = new MySqlCommand(query, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            linea = reader["descrip"].ToString();
                        }
                        reader.Close();
                    }
               
                #endregion
                #region l1
                
                    if (idl1[x] == "0")
                    {
                        linea1 = "Total";
                    }
                    else
                    {
                        query = "SELECT descrip from estl1 where idl1=" + idl1[x];
                        cmd = new MySqlCommand(query, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            linea1 = reader["descrip"].ToString();
                        }
                        reader.Close();
                    }
                
                #endregion
                #region l2
                
                    if (idl2[x] == "0")
                    {
                        linea2 = "Total";
                    }
                    else
                    {
                        query = "SELECT descrip from estl2 where idl2=" + idl2[x];
                        cmd = new MySqlCommand(query, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            linea2 = reader["descrip"].ToString();
                        }
                        reader.Close();
                    }
                
                #endregion
                #region l3
               
                    if (idl3[x] == "0")
                    {
                        linea3 = "Total";
                    }
                    else
                    {
                        query = "SELECT descrip from estl3 where idl3=" + idl3[x];
                        cmd = new MySqlCommand(query, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            linea3 = reader["descrip"].ToString();
                        }
                        reader.Close();
                    }
               
                #endregion
                #region l4
                  
                   if (idl4[x] == "0")
                    {
                        linea4 = "Total";
                    }
                    else
                    {
                        query = "SELECT descrip from estl4 where idl4=" + idl4[x];
                        cmd = new MySqlCommand(query, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            linea4 = reader["descrip"].ToString();
                        }
                        reader.Close();
                    }
                
                #endregion
                #region l5
               
                    if (idl5[x] == "0")
                    {
                        linea5 = "Total";
                    }
                    else
                    {
                        query = "SELECT descrip from estl5 where idl5=" + idl5[x];
                        cmd = new MySqlCommand(query, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            linea5 = reader["descrip"].ToString();
                        }
                        reader.Close();
                    }
               
                #endregion
                #region l6
                
                    if (idl6[x] == "0")
                    {
                        linea6 = "Total";
                    }
                    else
                    {
                        query = "SELECT descrip from estl6 where idl6=" + idl6[x];
                        cmd = new MySqlCommand(query, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            linea6 = reader["descrip"].ToString();
                        }
                        reader.Close();
                    }
               
                #endregion
                #region marca
                
                    if (idmarca[x] == "0")
                    {
                        marca = "Total";
                    }
                    else
                    {
                        query = "SELECT descrip from marca where marca='" + idmarca[x] + "'";
                        cmd = new MySqlCommand(query, Conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            marca = reader["descrip"].ToString();
                        }
                        reader.Close();
                    }
               
                #endregion

               escenario[x] = nombre[x] ;



               if (idsucursal[x] != "-1")
                   escenario[x] += " Sucursal:" + sucursal;

               if (iddivision[x] != "-1")
                  escenario[x] += " Division:" + division ;

               if (iddepto[x] != "-1")
                     escenario[x] += " Departamento:" + departamento;

               if (idfamilia[x] != "-1")
                     escenario[x] += " Familia:" + familia;

               if (idlinea[x] != "-1")
                     escenario[x] += " Linea:" + linea;

               if (idl1[x] != "-1")
                     escenario[x] += " Sublinea1:" + linea1;

               if (idl2[x] != "-1")
                     escenario[x]  += " Sublinea2:" + linea2 ;

               if (idl3[x] != "-1")
                     escenario[x] += " Sublinea3" + linea3;

               if (idl4[x] != "-1")
                     escenario[x]  += " Sublinea4:" + linea4 ;

               if (idl5[x] != "-1")
                     escenario[x]  += " Sublinea5" + linea5;

               if (idl6[x] != "-1")
                     escenario[x] += " Sublinea6" + linea6 ;

               if (idmarca[x] != "-1")
                    escenario[x] += " Marca:" + marca;

               comboBox1.Items.Add(escenario[x].ToString());
            }

        }

        #region metodos dropdown  
        private int m_drop_sucursales(string sucursal)
        {
            index.Initialize();
            index[0]="Total";
            int i = 1;
            int x = 0;
            query = "SELECT descrip,idsucursal from sucursal where visible='S'";
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                index[i]=(reader["descrip"].ToString());
                //idd[i] = reader["idsucursal"].ToString();
                if(sucursal==index[i])
                {
                    x = i;
                }
                i++;
            }
            reader.Close();
                return x;
        }
        private int m_drop_division(string division)
        {
            int i = 0;
            index[0] = "Total";
            int x = 0;
            //if (solocalzadoDropdown == " and iddivisiones=1")
            //{
            //    i = 0;
            //}
            //else
            //{
            //    i = 1;
            //    cbDivisiones.Items.Add("Total");
            //}
            //query = "SELECT descrip,iddivisiones from estdivisiones where visiblebp='1' " + solocalzadoDropdown;
            query = "SELECT descrip,iddivisiones from estdivisiones where visiblebp='1' ";
            cmd = new MySqlCommand(query, Conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                index[i] = (reader["descrip"].ToString());
                //idd[i] = reader["idsucursal"].ToString();
                if (division == index[i])
                {
                    x = i;
                }
                i++;
            }
            reader.Close();
            return x;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //@est@
            ///////////////////////////////////////////////////////////////
            int n = comboBox1.SelectedIndex;
           // MessageBox.Show("La Cedula Seleccionada Es :" + nombre[n]);
            seleccion_sucursal = Convert.ToInt32(idsucursal[n]);
            seleccion_division = Convert.ToInt32(iddivision[n]);
            seleccion_depto = Convert.ToInt32(iddepto[n]);
            seleccion_familia = Convert.ToInt32(idfamilia[n]);
            seleccion_linea = Convert.ToInt32(idlinea[n]);
            seleccion_l1 = Convert.ToInt32(idl1[n]);
            seleccion_l2 = Convert.ToInt32(idl2[n]);
            seleccion_l3 = Convert.ToInt32(idl3[n]);
            seleccion_l4 = Convert.ToInt32(idl4[n]);
            seleccion_l5 = Convert.ToInt32(idl5[n]);
            seleccion_l6 = Convert.ToInt32(idl6[n]);
            seleccion_marca = idmarca[n];
            /////////////////////////////////////////////////////
        }

        private void OnBwg_reconectarDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //reconectarF r = new reconectarF();
            //r.ShowDialog();
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
            this.Invoke(new Action(() =>
            {
                radWaitingBar1.Visible = false;
                radWaitingBar1.StopWaiting();
            }));
                
            //if(bwg_reconectar.CancellationPending==true)
            //{
            //    radWaitingBar1.StopWaiting();
            //    radWaitingBar1.Visible = false;
            //}
            //if(bwg_reconectar.IsBusy)
            //{
            //    bwg_reconectar.CancelAsync();
            //    r.Close();
            //}
            //else
            //{
            // r.ShowDialog();
            // r.esperar();
            //}
           
        }
        //private void m_drop_depto()
        //{
        //    int i = 0;
        //    index[0] = "Total";
        //    int x = 0;
        //    query = "SELECT descrip,iddepto from estdepartamento where visiblebp='1' " + division + "";
        //    cmd = new MySqlCommand(query, Conn);
        //    reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        cbDepto.Items.Add(reader["descrip"].ToString());
        //        idd[i] = reader["iddepto"].ToString();
        //        i++;
        //    }
        //    reader.Close();
        //}
        //private void m_drop_familia()
        //{
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
        //        i++;
        //    }
        //    reader.Close();
        //}
        //private void m_drop_linea()
        //{
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
        //        i++;
        //    }
        //    reader.Close();
        //}
        //private void m_drop_l1()
        //{
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
        //        i++;
        //    }
        //    reader.Close();
        //}
        //private void m_drop_l2()
        //{
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
        //        i++;
        //    }
        //    reader.Close();
        //}
        //private void m_drop_l3()
        //{
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
        //        i++;
        //    }
        //    reader.Close();
        //}
        //private void m_drop_l4()
        //{
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
        //        i++;
        //    }
        //    reader.Close();
        //}
        //private void m_drop_l5()
        //{
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
        //        i++;
        //    }
        //    reader.Close();
        //}
        //private void m_drop_marca()
        //{

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
        //        i++;
        //    }
        //    reader.Close();

        //}
        #endregion
    }
}