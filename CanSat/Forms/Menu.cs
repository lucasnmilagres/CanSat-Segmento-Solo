using CanSat.Forms;
using System;
using System.IO;
using System.Windows.Forms;

namespace CanSat
{
    public partial class Menu : Form
    {
        #region Inicialização
        public Menu()
        {
            InterfaceGeral.formatarJanela(this);

            InitializeComponent();

            //Atualiza o código de execução do programa
            Properties.Settings.Default.numeroExecucao += 1;
            Properties.Settings.Default.Save();

            //Garante a existência da pasta de registros
            InterfaceGeral.Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\" + Properties.Resources.pastaLocal;
            if (!Directory.Exists(InterfaceGeral.Path))
                Directory.CreateDirectory(InterfaceGeral.Path);

            //Registrar no Log
            InterfaceGeral.registrarLog("Inicialização", "Programa de segmento solo Alpha-Cansat inicializado!");
        }
        #endregion

        #region Interface do Menu
        //Minimiza o menu
        private void menuMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Fecha o menu
        private void menuEncerrar_Click(object sender, EventArgs e)
        {
            ConfirmarSaida confirmarSaida = new ConfirmarSaida();
            this.AddOwnedForm(confirmarSaida);
            confirmarSaida.Show();
        }

        //Habilitar o botão de conexão
        private void habilitarConexao(bool armazenado)
        {
            //Habilitar o botão de conexão
            if (armazenado)
            {
                menuConectar.Enabled = true;
                menuConectar.Visible = true;
                menuConectar.Cursor = Cursors.Hand;
            }
            //Habilitar o botão de armazenamento
            else
            {
                menuArmazenar.Enabled = true;
                menuArmazenar.Visible = true;
                menuArmazenar.Cursor = Cursors.Hand;
            }
        }

        //Habilitar o botão de execução
        public void habilitarExecucao(int conectado)
        {
            //Habilitação do botão de execução
            if (conectado!=0)
            {
                menuExecutar.Enabled = true;
                menuExecutar.Visible = true;
                menuExecutar.Cursor = Cursors.Hand;
            }
            //Habilitação do botão de conexão
            else
            {
                menuConectar.Enabled = true;
                menuConectar.Visible = true;
                menuConectar.Cursor = Cursors.Hand;
            }
        }
        #endregion

        #region Eventos principais
        private void menuArmazenar_Click(object sender, EventArgs e)
        {
            //Desabilitação do botão de armazenamento
            menuArmazenar.Enabled = false;
            menuArmazenar.Visible = false;
            menuArmazenar.Cursor = Cursors.Default;

            //Exibe diálogo para seleção de pastas
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = false;
            dialog.Description = Properties.Resources.msgSelRemovivel;
            dialog.RootFolder= Environment.SpecialFolder.MyComputer;
            dialog.ShowDialog();

            //Exibe diálogo de erro para o caso de erro do usuário
            if ((dialog.SelectedPath == "") || (dialog.SelectedPath.Contains("C:")))
            {
                ErroRemovivel erroRemovivel = new ErroRemovivel();
                this.AddOwnedForm(erroRemovivel);
                erroRemovivel.Show();

                habilitarConexao(false);
            }
            else
            {
                //Executar o diálogo informativo
                InformativoArmazenamento informativoArmazenamento = new InformativoArmazenamento();
                this.AddOwnedForm(informativoArmazenamento);
                informativoArmazenamento.Show();

                //Registrar no Log
                string nomeArquivo = DateTime.Now + " - Cansat.txt";
                nomeArquivo=nomeArquivo.Replace("/", "-");
                nomeArquivo = nomeArquivo.Replace(":", ".");
                InterfaceGeral.registrarLog("Armazenamento", "Nome do arquivo: " + nomeArquivo);
                InterfaceGeral.registrarLog("Armazenamento", "Local: " + InterfaceGeral.Path);
                InterfaceGeral.registrarLog("Armazenamento", "Removível: " + dialog.SelectedPath);
                InterfaceGeral.registrarLog("Armazenamento", "Rede: "+Properties.Settings.Default.urlServidorLocal); //Falta descrever o local de armazenamento da rede

                //Armazenamento do endereço do PenDrive e do nome do arquivo
                Properties.Settings.Default.enderecoRemovivel = dialog.SelectedPath;
                Properties.Settings.Default.nomeArquivo = nomeArquivo;
                Properties.Settings.Default.Save();

                habilitarConexao(true);
            }
        }

        private void menuConectar_Click(object sender, EventArgs e)
        {
            //Desabilitação do botão de conexão
            menuConectar.Enabled = false;
            menuConectar.Visible = false;
            menuConectar.Cursor = Cursors.Default;

            //Chama o form de conexão
            Conexao conexao = new Conexao();
            this.AddOwnedForm(conexao);
            conexao.Show();
        }

        private void menuExecutar_Click(object sender, EventArgs e)
        {
            //Chama execução
            Program.Execucao();
            
            //Fecha o menu
            Close();
        }
        #endregion
    }
}
