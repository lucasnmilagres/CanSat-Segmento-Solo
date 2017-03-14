namespace CanSat.Dialogs
{
    partial class Conectando
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Conectando));
            this.loading = new System.Windows.Forms.Label();
            this.conectandoTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // loading
            // 
            this.loading.AutoSize = true;
            this.loading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(59)))), ((int)(((byte)(76)))));
            this.loading.ForeColor = System.Drawing.Color.White;
            this.loading.Location = new System.Drawing.Point(89, 264);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(0, 17);
            this.loading.TabIndex = 0;
            // 
            // conectandoTimer
            // 
            this.conectandoTimer.Enabled = true;
            this.conectandoTimer.Interval = 25;
            this.conectandoTimer.Tick += new System.EventHandler(this.conectandoTimer_Tick);
            // 
            // Conectando
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackgroundImage = global::CanSat.Properties.Resources.Conectando;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(600, 300);
            this.Controls.Add(this.loading);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Conectando";
            this.Text = "Conectando";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loading;
        private System.Windows.Forms.Timer conectandoTimer;
    }
}