using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanSat
{
    public partial class ConfirmarSaida : Form
    {
        #region Inicialização
        public ConfirmarSaida()
        {
            InterfaceGeral.formatarJanela(this);

            InitializeComponent();
        }
        #endregion

        #region Interface
        //Fecha a janela de confirmação de encerramento do programa
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Encerra o programa
        private void encerrarButton_Click(object sender, EventArgs e)
        {
            //Registrar no Log
            InterfaceGeral.registrarLog("Encerramento", "Programa de segmento solo Alpha - Cansat encerrado!");

            this.Owner.Close();
        }
        #endregion
    }
}
