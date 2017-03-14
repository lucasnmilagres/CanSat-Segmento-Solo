using System;
using System.Windows.Forms;

namespace CanSat
{
    public partial class ErroRemovivel : Form
    {
        #region Inicialização
        public ErroRemovivel()
        {
            InterfaceGeral.formatarJanela(this);

            InitializeComponent();
        }
        #endregion

        #region Interface
        //Encerra a janela de erro
        private void okBotao_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
