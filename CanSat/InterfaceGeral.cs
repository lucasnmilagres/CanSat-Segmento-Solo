using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CanSat
{
    abstract class InterfaceGeral
    {
        private static string path;

        public static string Path
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
            }
        }

        //Formatação padrão básica da janela
        public static void formatarJanela(Form form)
        {
            //Tornar o background da janela invisível
            form.TransparencyKey = Color.MidnightBlue;

            //Centraliza a tela
            form.StartPosition = FormStartPosition.CenterScreen;
        }

        //Registra as ocorrências do software no Log
        public static void registrarLog(string grupo, string msg)
        {
            string linha = "CEXEC" + Properties.Settings.Default.numeroExecucao.ToString("00000") + " - " + DateTime.Now + " - " + grupo + " - " + msg;

            StreamWriter log = new StreamWriter(Path + @"\"+Properties.Resources.logFile, true);
            log.WriteLine(linha);
            log.Close();
        }

        //Verifica as dimensões do retângulo do gráfico
        public static RectangleF ChartAreaClientRectangle(Chart chart, ChartArea CA)
        {
            RectangleF CAR = CA.Position.ToRectangleF();
            float pw = chart.ClientSize.Width / 100f;
            float ph = chart.ClientSize.Height / 100f;
            return new RectangleF(pw * CAR.X, ph * CAR.Y, pw * CAR.Width, ph * CAR.Height);
        }
    }
}
