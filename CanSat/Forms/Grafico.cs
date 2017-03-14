using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CanSat.Forms
{
    public partial class Grafico : Form
    {
        Point MouseLocation;
        string eixoX, eixoY;

        //Inicializa o gráfico
        public Grafico(int index, Series serie)
        {
            //Coloca a janela em modo fullscreen
            this.WindowState = FormWindowState.Maximized;

            InitializeComponent();

            //Formata o gráfico
            formatar(index);

            //Relaciona o gráfico da janela com aquele ao qual ele corresponde
            chart1.Series[0] = serie;
            chart1.ChartAreas[0].Name = serie.ChartArea;
        }

        #region Layout
        private void formatar(int index)
        {
            //Configura o título do gráfico
            pictureBox3.BackgroundImage=(Image)Properties.Resources.ResourceManager.GetObject(Properties.Settings.Default.prefixoImgGrafico + index.ToString());

            //Configura os nomes dos eixos
            eixoX=Properties.Resources.ResourceManager.GetObject(Properties.Settings.Default.prefixoXGrafico + index.ToString()).ToString();
            chart1.ChartAreas[0].AxisX.Title = eixoX;
            eixoY = Properties.Resources.ResourceManager.GetObject(Properties.Settings.Default.prefixoYGrafico + index.ToString()).ToString();
            chart1.ChartAreas[0].AxisY.Title = eixoY;
        }
        #endregion

        #region Interface
        //Faz o crosshair seguir o cursor
        private void MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);

            chart1.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
            chart1.ChartAreas[0].CursorY.SetCursorPixelPosition(mousePoint, true);
        }

        //Exibe a informação acerca do ponto clicado
        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            toolTip1.Show(eixoX+ ": " + chart1.ChartAreas[0].CursorX.Position + "\n"+eixoY+": " + chart1.ChartAreas[0].CursorY.Position, chart1);
        }

        //Esconde o cursor
        private void chart1_MouseEnter(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Hide();
        }

        //Mostra o cursor
        private void chart1_MouseLeave(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Show();
        }

        //Encerra a janela
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Minimiza a janela
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Grafico_FormClosing(object sender, FormClosingEventArgs e)
        {
            chart1.Series.Clear();
        }
        #endregion
    }
}
