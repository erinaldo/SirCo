namespace business_plan
{
    partial class reconectarF
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.waitingBar = new Telerik.WinControls.UI.RadWaitingBar();
            this.lbintentos = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.waitingBar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reconectando por favor espere";
            this.label1.Click += new System.EventHandler(this.OnLabel1Click);
            // 
            // waitingBar
            // 
            this.waitingBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.waitingBar.Location = new System.Drawing.Point(0, 97);
            this.waitingBar.Name = "waitingBar";
            this.waitingBar.Size = new System.Drawing.Size(323, 24);
            this.waitingBar.TabIndex = 2;
            // 
            // lbintentos
            // 
            this.lbintentos.AutoSize = true;
            this.lbintentos.Location = new System.Drawing.Point(89, 52);
            this.lbintentos.Name = "lbintentos";
            this.lbintentos.Size = new System.Drawing.Size(110, 13);
            this.lbintentos.TabIndex = 3;
            this.lbintentos.Text = "Cantidad de intentos :";
            this.lbintentos.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.OnTimer1Tick);
            // 
            // reconectarF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 121);
            this.Controls.Add(this.lbintentos);
            this.Controls.Add(this.waitingBar);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "reconectarF";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.OnReconectarFLoad);
            ((System.ComponentModel.ISupportInitialize)(this.waitingBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadWaitingBar waitingBar;
        private System.Windows.Forms.Label lbintentos;
        private System.Windows.Forms.Timer timer1;
    }
}