using System;
using System.Drawing;
using System.Windows.Forms;

namespace CanSat
{
    public partial class SplashScreen : Form
    {
        #region Inicialização
        public SplashScreen()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }
        #endregion

        #region Splash Interface
        //Incrementa os pontos no indicador de carregamento
        private void splashTimer_Tick(object sender, EventArgs e)
        {
            splashLoading.Text += ".";

            //Se os pontos atingem o final da tela, o texto é resetado
            if (splashLoading.Width >= (this.Width - 2 * splashLoading.Location.X))
            {
                //Chama o menu
                Program.Menu();

                //Esconde o splash
                this.Hide();
                splashTimer.Stop();
            }
        }
        #endregion
    }
}
