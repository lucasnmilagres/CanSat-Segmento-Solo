namespace CanSat.Forms
{
    partial class Conexao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Conexao));
            this.imagemConexao = new System.Windows.Forms.PictureBox();
            this.cancelarBotao = new System.Windows.Forms.PictureBox();
            this.okBotao = new System.Windows.Forms.PictureBox();
            this.PC2Check = new System.Windows.Forms.RadioButton();
            this.PC1Check = new System.Windows.Forms.RadioButton();
            this.conexaoEncerrar = new System.Windows.Forms.PictureBox();
            this.conexaoMinimizar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imagemConexao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelarBotao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.okBotao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conexaoEncerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conexaoMinimizar)).BeginInit();
            this.SuspendLayout();
            // 
            // imagemConexao
            // 
            this.imagemConexao.BackColor = System.Drawing.Color.Transparent;
            this.imagemConexao.Location = new System.Drawing.Point(103, 95);
            this.imagemConexao.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.imagemConexao.Name = "imagemConexao";
            this.imagemConexao.Size = new System.Drawing.Size(166, 210);
            this.imagemConexao.TabIndex = 0;
            this.imagemConexao.TabStop = false;
            // 
            // cancelarBotao
            // 
            this.cancelarBotao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(59)))), ((int)(((byte)(76)))));
            this.cancelarBotao.BackgroundImage = global::CanSat.Properties.Resources.Botão_habilitado_Quit;
            this.cancelarBotao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cancelarBotao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelarBotao.Location = new System.Drawing.Point(379, 327);
            this.cancelarBotao.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cancelarBotao.Name = "cancelarBotao";
            this.cancelarBotao.Size = new System.Drawing.Size(58, 54);
            this.cancelarBotao.TabIndex = 4;
            this.cancelarBotao.TabStop = false;
            this.cancelarBotao.Click += new System.EventHandler(this.cancelarBotao_Click);
            // 
            // okBotao
            // 
            this.okBotao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(59)))), ((int)(((byte)(76)))));
            this.okBotao.BackgroundImage = global::CanSat.Properties.Resources.Botão_ok_habilitado_pequeno;
            this.okBotao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.okBotao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.okBotao.Location = new System.Drawing.Point(473, 327);
            this.okBotao.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.okBotao.Name = "okBotao";
            this.okBotao.Size = new System.Drawing.Size(58, 54);
            this.okBotao.TabIndex = 3;
            this.okBotao.TabStop = false;
            this.okBotao.Click += new System.EventHandler(this.okBotao_Click);
            // 
            // PC2Check
            // 
            this.PC2Check.BackColor = System.Drawing.Color.Transparent;
            this.PC2Check.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PC2Check.ForeColor = System.Drawing.Color.White;
            this.PC2Check.Location = new System.Drawing.Point(380, 178);
            this.PC2Check.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PC2Check.Name = "PC2Check";
            this.PC2Check.Size = new System.Drawing.Size(83, 18);
            this.PC2Check.TabIndex = 2;
            this.PC2Check.TabStop = true;
            this.PC2Check.Text = "PC2";
            this.PC2Check.UseVisualStyleBackColor = false;
            this.PC2Check.MouseEnter += new System.EventHandler(this.PC2Check_MouseEnter);
            // 
            // PC1Check
            // 
            this.PC1Check.BackColor = System.Drawing.Color.Transparent;
            this.PC1Check.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PC1Check.ForeColor = System.Drawing.Color.White;
            this.PC1Check.Location = new System.Drawing.Point(380, 152);
            this.PC1Check.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PC1Check.Name = "PC1Check";
            this.PC1Check.Size = new System.Drawing.Size(83, 21);
            this.PC1Check.TabIndex = 1;
            this.PC1Check.TabStop = true;
            this.PC1Check.Text = "PC1";
            this.PC1Check.UseVisualStyleBackColor = false;
            this.PC1Check.CheckedChanged += new System.EventHandler(this.PC1Check_CheckedChanged);
            this.PC1Check.MouseEnter += new System.EventHandler(this.PC1Check_MouseEnter);
            // 
            // conexaoEncerrar
            // 
            this.conexaoEncerrar.BackColor = System.Drawing.Color.Transparent;
            this.conexaoEncerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.conexaoEncerrar.Location = new System.Drawing.Point(534, 26);
            this.conexaoEncerrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.conexaoEncerrar.Name = "conexaoEncerrar";
            this.conexaoEncerrar.Size = new System.Drawing.Size(19, 18);
            this.conexaoEncerrar.TabIndex = 2;
            this.conexaoEncerrar.TabStop = false;
            this.conexaoEncerrar.Click += new System.EventHandler(this.conexaoEncerrar_Click);
            // 
            // conexaoMinimizar
            // 
            this.conexaoMinimizar.BackColor = System.Drawing.Color.Transparent;
            this.conexaoMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.conexaoMinimizar.Location = new System.Drawing.Point(502, 26);
            this.conexaoMinimizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.conexaoMinimizar.Name = "conexaoMinimizar";
            this.conexaoMinimizar.Size = new System.Drawing.Size(20, 18);
            this.conexaoMinimizar.TabIndex = 3;
            this.conexaoMinimizar.TabStop = false;
            this.conexaoMinimizar.Click += new System.EventHandler(this.conexaoMinimizar_Click);
            // 
            // Conexao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackgroundImage = global::CanSat.Properties.Resources.Janela_conexão;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(640, 400);
            this.Controls.Add(this.cancelarBotao);
            this.Controls.Add(this.conexaoMinimizar);
            this.Controls.Add(this.okBotao);
            this.Controls.Add(this.conexaoEncerrar);
            this.Controls.Add(this.PC2Check);
            this.Controls.Add(this.PC1Check);
            this.Controls.Add(this.imagemConexao);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Conexao";
            this.Text = "Conexao";
            this.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            ((System.ComponentModel.ISupportInitialize)(this.imagemConexao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelarBotao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.okBotao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conexaoEncerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conexaoMinimizar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imagemConexao;
        private System.Windows.Forms.PictureBox okBotao;
        private System.Windows.Forms.RadioButton PC2Check;
        private System.Windows.Forms.RadioButton PC1Check;
        private System.Windows.Forms.PictureBox conexaoEncerrar;
        private System.Windows.Forms.PictureBox conexaoMinimizar;
        private System.Windows.Forms.PictureBox cancelarBotao;
    }
}