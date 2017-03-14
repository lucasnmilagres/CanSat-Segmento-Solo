namespace CanSat
{
    partial class ConfirmarSaida
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
            this.encerrarBotao = new System.Windows.Forms.PictureBox();
            this.cancelarBotao = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.encerrarBotao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelarBotao)).BeginInit();
            this.SuspendLayout();
            // 
            // encerrarBotao
            // 
            this.encerrarBotao.BackColor = System.Drawing.Color.Transparent;
            this.encerrarBotao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.encerrarBotao.Location = new System.Drawing.Point(160, 177);
            this.encerrarBotao.Name = "encerrarBotao";
            this.encerrarBotao.Size = new System.Drawing.Size(69, 67);
            this.encerrarBotao.TabIndex = 0;
            this.encerrarBotao.TabStop = false;
            this.encerrarBotao.Click += new System.EventHandler(this.encerrarButton_Click);
            // 
            // cancelarBotao
            // 
            this.cancelarBotao.BackColor = System.Drawing.Color.Transparent;
            this.cancelarBotao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelarBotao.Location = new System.Drawing.Point(370, 177);
            this.cancelarBotao.Name = "cancelarBotao";
            this.cancelarBotao.Size = new System.Drawing.Size(69, 67);
            this.cancelarBotao.TabIndex = 1;
            this.cancelarBotao.TabStop = false;
            this.cancelarBotao.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // ConfirmarSaida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackgroundImage = global::CanSat.Properties.Resources.Deseja_sair;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(600, 300);
            this.Controls.Add(this.cancelarBotao);
            this.Controls.Add(this.encerrarBotao);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfirmarSaida";
            this.Text = "ConfirmarSaida";
            ((System.ComponentModel.ISupportInitialize)(this.encerrarBotao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelarBotao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox encerrarBotao;
        private System.Windows.Forms.PictureBox cancelarBotao;
    }
}