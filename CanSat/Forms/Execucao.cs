using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CanSat
{
    public partial class Execucao : Form
    {
        #region Variáveis Globais
        object[,] janelas;
        Image[] imagens_botoes_desabilitados;
        Thread processamentoThread;
        #endregion

        #region Inicialização
        public Execucao()
        {
            InterfaceGeral.formatarJanela(this);

            InitializeComponent();

            //Inclusão das janelas na array
            janelas = new object[4,2];
            janelas[0, 0] = homeBotao;
            janelas[1, 0] = graficosBotao;
            janelas[2, 0] = mapaBotao;
            janelas[3, 0] = logBotao;
            janelas[0, 1] = home;
            janelas[1, 1] = graficos;
            janelas[2, 1] = mapa;
            janelas[3, 1] = log;

            //Inclusão das imagens dos botões desabilitados na array
            imagens_botoes_desabilitados = new Image[4];
            imagens_botoes_desabilitados[0] = Properties.Resources.Botão_home_desabilitado;
            imagens_botoes_desabilitados[1] = Properties.Resources.Botão_gráfico_desabilitado;
            imagens_botoes_desabilitados[2] = Properties.Resources.Botão_mapa_desabilitado;
            imagens_botoes_desabilitados[3] = Properties.Resources.Botão_log_desabilitado;

            //Inclusão dos campos de texto do home em uma array
            TextBox[] homeTextos= new TextBox[7];
            homeTextos[0] = textBox1;
            homeTextos[1] = textBox2;
            homeTextos[2] = textBox3;
            homeTextos[3] = textBox4;
            homeTextos[4] = textBox5;
            homeTextos[5] = textBox6;
            homeTextos[6] = textBox7;

            //Cria o Thread que processas os dados
            processamentoThread = new Thread(()=> {Processamento.Inicializar(logTexto, chart1.Series, homeTextos, chart1.ChartAreas, chart1);});
            processamentoThread.Start();
        }
        #endregion

        #region Interface
        
        #region Geral
        //Minimiza a janela
        private void execucaoMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Fecha a janela
        private void execucaoEncerrar_Click(object sender, EventArgs e)
        {
            ConfirmarSaida confirmarSaida = new ConfirmarSaida();
            this.AddOwnedForm(confirmarSaida);
            confirmarSaida.Show();
        }

        //Troca as páginas e os botões que estão ativados
        private void trocarPaginas(object sender)
        {
            for (int i = 0; i < 4; i++)
            {
                //Se o botão em questão for o que houver enviado o evento
                if (Equals(janelas[i, 0], sender))
                {
                    //Configuração do botão
                    ((PictureBox)janelas[i, 0]).Enabled = false;
                    ((PictureBox)janelas[i, 0]).BackgroundImage =imagens_botoes_desabilitados[i];

                    //Configuração da janela
                    ((Panel)janelas[i, 1]).Visible = true;
                }
                else
                {
                    //Configuração do botão
                    ((PictureBox)janelas[i, 0]).Enabled = true;
                    ((PictureBox)janelas[i, 0]).BackgroundImage = null;

                    //Configuração da janela
                    ((Panel)janelas[i, 1]).Visible = false;
                }
            }
        }

        #region eventos de trocas de pages
        private void homeBotao_Click(object sender, EventArgs e)
        {
            trocarPaginas(sender);
        }

        private void graficosBotao_Click(object sender, EventArgs e)
        {
            trocarPaginas(sender);
        }

        private void mapaBotao_Click(object sender, EventArgs e)
        {
            trocarPaginas(sender);
        }

        private void logBotao_Click(object sender, EventArgs e)
        {
            trocarPaginas(sender);
        }
        #endregion
        #endregion

        #region Log
        //Rola a janela para o final
        private void logTexto_TextChanged(object sender, EventArgs e)
        {
            logTexto.SelectionStart = logTexto.Text.Length;
            logTexto.ScrollToCaret();
        }
        #endregion

        #endregion

        #region Eventos de Interação
        #region Gráfico
        //Clique duplo em regiões do gráfico
        private void chart1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (ChartArea ca in chart1.ChartAreas)
            {
                if(InterfaceGeral.ChartAreaClientRectangle(chart1, ca).Contains(e.Location))
                {
                    int index = chart1.ChartAreas.IndexOf(ca);
                    Forms.Grafico grafico_fullscreen = new Forms.Grafico(index, chart1.Series[index]);
                    grafico_fullscreen.Show();
                }
            }
        }
        #endregion

        #region Mapa
        //Clique em "Rodar Mapa"
        private void rodar_mapa_Click(object sender, EventArgs e)
        {
            //Cria o Thread que roda o mapa
            Thread rodarMapa = new Thread(() => Processamento.RodarMapa());
            rodarMapa.Start();
        }
        #endregion
        #endregion
    }
}
