using CanSat.Dialogs;
using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace CanSat.Forms
{
    public partial class Conexao : Form
    {
        #region Variáveis Globais
        ToolTip dica;
        int conexao = 0;
        #endregion

        #region Inicialização
        public Conexao()
        {
            InterfaceGeral.formatarJanela(this);

            InitializeComponent();

            //Inicialização do objeto "dica"
            dica = new ToolTip();
        }
        #endregion

        #region Interface
        //Minimiza a janela
        private void conexaoMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Fecha a janela
        private void conexaoEncerrar_Click(object sender, EventArgs e)
        {
            ((Menu)this.Owner).habilitarExecucao(0);

            Close();
        }

        //Exibe a dica para a conexão do tipo PC1
        private void PC1Check_MouseEnter(object sender, EventArgs e)
        {
            dica.Show(Properties.Resources.dicaPC1, PC1Check, new Point(25, 50),10000);
        }

        //Exibe a dica para a conexão do tipo PC2
        private void PC2Check_MouseEnter(object sender, EventArgs e)
        {
            dica.Show(Properties.Resources.dicaPC2, PC2Check, new Point(25, 50), 10000);
        }

        //Esconde a dica
        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            dica.Hide(this);
        }

        //Altera a imagem para a correspondente a seleção
        private void PC1Check_CheckedChanged(object sender, EventArgs e)
        {
            if (PC1Check.Checked)
                //Adicionar mudança para a imagem de conexão serial
                ;
            else
                //Adicionar mudança para a imagem de conexão wifi
                ;
        }
        #endregion

        #region Eventos Principais
        private void okBotao_Click(object sender, EventArgs e)
        {
            //Chamada da janela de espera de conexão
            Conectando conectando = new Conectando();
            AddOwnedForm(conectando);
            Enabled = false;
            conectando.Show();

            #region Conexão
            if (PC1Check.Checked)
            {
                //Conexão Serial
                conexao = Processamento.OpenSerial();
            }
            else if(PC2Check.Checked)
            {
                //Falta adicionar o procedimento de conexão wifi

                InterfaceGeral.registrarLog("Conexao", Properties.Resources.logConexaoWifi);
                conexao = 2;
            }
            #endregion
        }

        //Registro de resposta e feedback para usuário
        public void conexaoFeedback()
        {
            if (conexao == 0)
            {
                //Registro no Log
                InterfaceGeral.registrarLog("Conexao", Properties.Resources.logConexaoFalha);

                //Chamada da janela de erro de conexão
                ErroConexao erroConexao = new ErroConexao();
                erroConexao.Show();
            }
            else
            {
                //Chamada da janela de sucesso de conexão
                SucessoConexao sucessoConexao = new SucessoConexao();
                sucessoConexao.Show();
            }

            //Devolve o status de conexão para o menu e fecha a janela de conexão
            Properties.Settings.Default.conexao = conexao;
            Properties.Settings.Default.Save();
            ((Menu)this.Owner).habilitarExecucao(conexao);
            Close();
        }

        private void cancelarBotao_Click(object sender, EventArgs e)
        {
            ((Menu)this.Owner).habilitarExecucao(0);

            Close();
        }
        #endregion
    }
}
