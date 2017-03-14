namespace CanSat.Dialogs
{
    partial class ErroConexao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErroConexao));
            this.okBotao = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.okBotao)).BeginInit();
            this.SuspendLayout();
            // 
            // okBotao
            // 
            this.okBotao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(59)))), ((int)(((byte)(76)))));
            this.okBotao.BackgroundImage = global::CanSat.Properties.Resources.Botão_ok_habilitado_pequeno;
            this.okBotao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.okBotao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.okBotao.Location = new System.Drawing.Point(435, 204);
            this.okBotao.Name = "okBotao";
            this.okBotao.Size = new System.Drawing.Size(74, 68);
            this.okBotao.TabIndex = 0;
            this.okBotao.TabStop = false;
            this.okBotao.Click += new System.EventHandler(this.okBotao_Click);
            // 
            // ErroConexao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackgroundImage = global::CanSat.Properties.Resources.Erro_ao_conectar;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(603, 302);
            this.Controls.Add(this.okBotao);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ErroConexao";
            this.Text = "ErroConexao";
            ((System.ComponentModel.ISupportInitialize)(this.okBotao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox okBotao;
    }
}