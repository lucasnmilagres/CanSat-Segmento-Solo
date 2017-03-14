using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanSat
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplashScreen());
        }

        //Roda o splash
        public static void Splash()
        {
            SplashScreen splash = new SplashScreen();
            splash.Show();
        }

        //Roda o menu
        public static void Menu()
        {
            Menu menu = new Menu();
            menu.Show();
        }

        //Roda a janela de execução
        public static void Execucao()
        {
            Execucao execucao = new Execucao();
            execucao.Show();
        }
    }
}
