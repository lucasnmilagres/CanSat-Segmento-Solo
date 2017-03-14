namespace CanSat
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.menuArmazenar = new System.Windows.Forms.PictureBox();
            this.menuConectar = new System.Windows.Forms.PictureBox();
            this.menuExecutar = new System.Windows.Forms.PictureBox();
            this.menuAjuda = new System.Windows.Forms.Label();
            this.menuEncerrar = new System.Windows.Forms.PictureBox();
            this.menuMinimizar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.menuArmazenar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuConectar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuExecutar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuEncerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuMinimizar)).BeginInit();
            this.SuspendLayout();
            // 
            // menuArmazenar
            // 
            this.menuArmazenar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(59)))), ((int)(((byte)(76)))));
            this.menuArmazenar.BackgroundImage = global::CanSat.Properties.Resources.Botão_menu_inicial_armazenamento_habilitado;
            this.menuArmazenar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuArmazenar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuArmazenar.Location = new System.Drawing.Point(97, 159);
            this.menuArmazenar.Name = "menuArmazenar";
            this.menuArmazenar.Size = new System.Drawing.Size(111, 104);
            this.menuArmazenar.TabIndex = 0;
            this.menuArmazenar.TabStop = false;
            this.menuArmazenar.Click += new System.EventHandler(this.menuArmazenar_Click);
            // 
            // menuConectar
            // 
            this.menuConectar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(59)))), ((int)(((byte)(76)))));
            this.menuConectar.BackgroundImage = global::CanSat.Properties.Resources.Botão_menu_inicial_conexão_habilitado;
            this.menuConectar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuConectar.Cursor = System.Windows.Forms.Cursors.Default;
            this.menuConectar.Enabled = false;
            this.menuConectar.Location = new System.Drawing.Point(26, 275);
            this.menuConectar.Name = "menuConectar";
            this.menuConectar.Size = new System.Drawing.Size(111, 104);
            this.menuConectar.TabIndex = 1;
            this.menuConectar.TabStop = false;
            this.menuConectar.Visible = false;
            this.menuConectar.Click += new System.EventHandler(this.menuConectar_Click);
            // 
            // menuExecutar
            // 
            this.menuExecutar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(59)))), ((int)(((byte)(76)))));
            this.menuExecutar.BackgroundImage = global::CanSat.Properties.Resources.Botão_menu_inicial_execução_habilitado;
            this.menuExecutar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuExecutar.Cursor = System.Windows.Forms.Cursors.Default;
            this.menuExecutar.Enabled = false;
            this.menuExecutar.Location = new System.Drawing.Point(165, 276);
            this.menuExecutar.Name = "menuExecutar";
            this.menuExecutar.Size = new System.Drawing.Size(111, 104);
            this.menuExecutar.TabIndex = 2;
            this.menuExecutar.TabStop = false;
            this.menuExecutar.Visible = false;
            this.menuExecutar.Click += new System.EventHandler(this.menuExecutar_Click);
            // 
            // menuAjuda
            // 
            this.menuAjuda.AutoSize = true;
            this.menuAjuda.BackColor = System.Drawing.Color.Transparent;
            this.menuAjuda.Font = new System.Drawing.Font("BankGothic Lt BT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuAjuda.ForeColor = System.Drawing.Color.White;
            this.menuAjuda.Location = new System.Drawing.Point(122, 417);
            this.menuAjuda.Name = "menuAjuda";
            this.menuAjuda.Size = new System.Drawing.Size(58, 14);
            this.menuAjuda.TabIndex = 3;
            this.menuAjuda.Text = "Ajuda";
            this.menuAjuda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuEncerrar
            // 
            this.menuEncerrar.BackColor = System.Drawing.Color.Transparent;
            this.menuEncerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuEncerrar.Location = new System.Drawing.Point(244, 36);
            this.menuEncerrar.Name = "menuEncerrar";
            this.menuEncerrar.Size = new System.Drawing.Size(20, 21);
            this.menuEncerrar.TabIndex = 4;
            this.menuEncerrar.TabStop = false;
            this.menuEncerrar.Click += new System.EventHandler(this.menuEncerrar_Click);
            // 
            // menuMinimizar
            // 
            this.menuMinimizar.BackColor = System.Drawing.Color.Transparent;
            this.menuMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuMinimizar.Location = new System.Drawing.Point(211, 36);
            this.menuMinimizar.Name = "menuMinimizar";
            this.menuMinimizar.Size = new System.Drawing.Size(20, 21);
            this.menuMinimizar.TabIndex = 5;
            this.menuMinimizar.TabStop = false;
            this.menuMinimizar.Click += new System.EventHandler(this.menuMinimizar_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackgroundImage = global::CanSat.Properties.Resources.Menu_Inicial;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(304, 446);
            this.Controls.Add(this.menuMinimizar);
            this.Controls.Add(this.menuEncerrar);
            this.Controls.Add(this.menuAjuda);
            this.Controls.Add(this.menuExecutar);
            this.Controls.Add(this.menuConectar);
            this.Controls.Add(this.menuArmazenar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu";
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.menuArmazenar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuConectar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuExecutar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuEncerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuMinimizar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox menuArmazenar;
        private System.Windows.Forms.PictureBox menuConectar;
        private System.Windows.Forms.PictureBox menuExecutar;
        private System.Windows.Forms.Label menuAjuda;
        private System.Windows.Forms.PictureBox menuEncerrar;
        private System.Windows.Forms.PictureBox menuMinimizar;
    }
}