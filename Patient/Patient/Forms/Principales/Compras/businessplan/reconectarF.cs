using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace business_plan
{
    public partial class reconectarF : Form
    {
        public reconectarF()
        {
            InitializeComponent();
        }
        //int ticks = 0;
        private void OnLabel1Click(object sender, EventArgs e)
        {

        }

        public void reintentos(int i)
        {
            lbintentos.Text = "Cantidad de intentos : "+i;
            lbintentos.Refresh();
        }

        private void OnTimer1Tick(object sender, EventArgs e)
        {
            //ticks++;
            //waitingBar.va = ticks;
            //if (ticks == 100)
            //{
            //    timer1.Enabled = false;
            //    ticks = 0;
            //}
        }
        public void esperar()
        {
            if (waitingBar.IsWaiting)
            {
                waitingBar.StopWaiting();
            }
            else
            {
                waitingBar.StartWaiting();
            }
        }
        private void OnReconectarFLoad(object sender, EventArgs e)
        {
            waitingBar.StartWaiting();
            //if (waitingBar.IsWaiting)
            //{
            //    waitingBar.StopWaiting();
            //}
            //else
            //{
            //    waitingBar.StartWaiting();
            //}
        }
    }
}
