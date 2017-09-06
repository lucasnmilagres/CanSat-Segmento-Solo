﻿using CanSat.Dialogs;
using System;

namespace CanSat
{
    abstract class Conexao
    {
        #region Variáveis Globais
        int conexao = 0;
        Menu menu;
        #endregion

        #region Inicialização
        public Conexao(Menu _menu)
        {
            menu = _menu;
            okBotao_Click();
        }
        #endregion

        #region Eventos Principais
        private void okBotao_Click()
        {
            //Chamada da janela de espera de conexão
            Conectando conectando = new Conectando();
            menu.AddOwnedForm(conectando);
            menu.Enabled = false;
            conectando.Show();

            #region Conexão
            //Conexão Serial
            conexao = Processamento.InicializarSerial();
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
            menu.habilitarExecucao(conexao);
        }

        private void cancelarBotao_Click(object sender, EventArgs e)
        {
            menu.habilitarExecucao(0);
        }
        #endregion
    }
}
