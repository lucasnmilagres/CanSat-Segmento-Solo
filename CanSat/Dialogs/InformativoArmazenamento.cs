using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanSat
{
    public partial class InformativoArmazenamento : Form
    {
        #region Inicialização
        public InformativoArmazenamento()
        {
            InterfaceGeral.formatarJanela(this);

            InitializeComponent();
        }
        #endregion

        #region Interface
        //Falta inserir o "link" para mais informações

        //Encerra a janela de erro
        private void okBotao_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Minimizar a janela
        private void minimizarBotao_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion
    }
}
