namespace CanSat
{
    partial class InformativoArmazenamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformativoArmazenamento));
            this.okBotao = new System.Windows.Forms.PictureBox();
            this.encerrarBotao = new System.Windows.Forms.PictureBox();
            this.minimizarBotao = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.okBotao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.encerrarBotao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizarBotao)).BeginInit();
            this.SuspendLayout();
            // 
            // okBotao
            // 
            this.okBotao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(59)))), ((int)(((byte)(76)))));
            this.okBotao.BackgroundImage = global::CanSat.Properties.Resources.Botão_ok_habilitado_grande;
            this.okBotao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.okBotao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.okBotao.Location = new System.Drawing.Point(459, 311);
            this.okBotao.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.okBotao.Name = "okBotao";
            this.okBotao.Size = new System.Drawing.Size(63, 66);
            this.okBotao.TabIndex = 0;
            this.okBotao.TabStop = false;
            this.okBotao.Click += new System.EventHandler(this.okBotao_Click);
            // 
            // encerrarBotao
            // 
            this.encerrarBotao.BackColor = System.Drawing.Color.Transparent;
            this.encerrarBotao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.encerrarBotao.Location = new System.Drawing.Point(501, 28);
            this.encerrarBotao.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.encerrarBotao.Name = "encerrarBotao";
            this.encerrarBotao.Size = new System.Drawing.Size(17, 19);
            this.encerrarBotao.TabIndex = 1;
            this.encerrarBotao.TabStop = false;
            this.encerrarBotao.Click += new System.EventHandler(this.okBotao_Click);
            // 
            // minimizarBotao
            // 
            this.minimizarBotao.BackColor = System.Drawing.Color.Transparent;
            this.minimizarBotao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimizarBotao.Location = new System.Drawing.Point(472, 28);
            this.minimizarBotao.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.minimizarBotao.Name = "minimizarBotao";
            this.minimizarBotao.Size = new System.Drawing.Size(17, 19);
            this.minimizarBotao.TabIndex = 2;
            this.minimizarBotao.TabStop = false;
            this.minimizarBotao.Click += new System.EventHandler(this.minimizarBotao_Click);
            // 
            // InformativoArmazenamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackgroundImage = global::CanSat.Properties.Resources.Janela_armazenamento;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(602, 409);
            this.Controls.Add(this.minimizarBotao);
            this.Controls.Add(this.encerrarBotao);
            this.Controls.Add(this.okBotao);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "InformativoArmazenamento";
            this.Text = "Informativo Armazenamento";
            ((System.ComponentModel.ISupportInitialize)(this.okBotao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.encerrarBotao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizarBotao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox okBotao;
        private System.Windows.Forms.PictureBox encerrarBotao;
        private System.Windows.Forms.PictureBox minimizarBotao;
    }
}