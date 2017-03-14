using CanSat.Forms;
using System;
using System.Windows.Forms;

namespace CanSat.Dialogs
{
    public partial class Conectando : Form
    {
        #region Inicialização
        public Conectando()
        {
            InterfaceGeral.formatarJanela(this);

            InitializeComponent();
        }
        #endregion

        #region Interface
        //Incrementa os pontos no indicador de carregamento
        private void conectandoTimer_Tick(object sender, EventArgs e)
        {
            loading.Text += ".";

            //Se os pontos atingem o final da tela, o texto é resetado
            if (loading.Width >= (this.Width - 2 * loading.Location.X))
            {
                loading.Text = "";
                ((Conexao)this.Owner).conexaoFeedback();
                Close();
            }
        }
        #endregion
    }
}
