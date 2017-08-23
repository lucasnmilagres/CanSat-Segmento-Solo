using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CanSat
{
    abstract class Processamento
    {
        #region Variáveis Globais
        private static double maxAltitude;
        private static double minAltitude;
        private static Dictionary<string, double> mapaDados;
        private static DataSet dataSet1;
        private static DataTable dataTable1;
        private static RichTextBox logTexto;
        private static TextBox[] homeTextos;
        private static SerialPort serialPort;
        private static Execucao execucao;
        #endregion

        static public void Inicializar(RichTextBox _logTexto, TextBox[] _homeTextos, Execucao _execucao)
        {
            //Atribui o form de execução a uma cópia local
            execucao = _execucao;

            #region Serial
            //Mapa de dados
            mapaDados = new Dictionary<string, double>(14);

            //Adiciona os dados que serão controlados
            mapaDados.Add("luminosidade", 0);
            mapaDados.Add("tempExterna", 0);
            mapaDados.Add("tempInterna", 0);
            mapaDados.Add("pressao", 0);
            mapaDados.Add("aceleracao", 0);
            mapaDados.Add("longitude", 0);
            mapaDados.Add("latitude", 0);
            mapaDados.Add("altitude", 0);
            mapaDados.Add("tempo_hora", 0);
            mapaDados.Add("tempo_minuto", 0);
            mapaDados.Add("tempo_segundo", 0);
            mapaDados.Add("velocidade", 0);
            mapaDados.Add("tempo_inicial", DateTime.UtcNow.Hour * 3600 + DateTime.UtcNow.Minute * 60 + DateTime.UtcNow.Second);

            serialPort.DataReceived += SerialPort_DataReceived;
            serialPort.DiscardInBuffer();
            #endregion

            #region Home
            homeTextos = _homeTextos;
            #endregion

            #region Log
            logTexto = _logTexto;
            readLogFile();
            #endregion

            #region DataSet
            //Inicializa o dataset
            dataSet1 = new DataSet();

            //Inicializa o datatable
            dataTable1 = new DataTable("DadosGrafico");
            dataTable1.Columns.Add("tempo", typeof(double));
            dataTable1.Columns.Add("altitude", typeof(double));
            dataTable1.Columns.Add("luminosidade", typeof(double));
            dataTable1.Columns.Add("tempExterna", typeof(double));
            dataTable1.Columns.Add("pressao", typeof(double));
            dataTable1.Columns.Add("aceleracao", typeof(double));
            dataTable1.Columns.Add("distancia", typeof(double));
            dataTable1.Columns.Add("velocidade", typeof(double));

            //Inclui a tabela no dataset
            dataSet1.Tables.Add(dataTable1);
            #endregion

            #region Gráficos
            //Atribui o Dataset como data source dos gráficos
            execucao.chart1.DataSource = dataSet1;

            //Adiciona um ponto inicial na origem do gráfico, por questão estética
            dataTable1.Rows.Add(0, 0, 0, 0, 0, 0, 0, 0);

            //Relaciona as colunas do gráfico e os eixos das séries
            execucao.chart1.Series[0].XValueMember ="tempo";
            execucao.chart1.Series[0].YValueMembers = "distancia";

            execucao.chart1.Series[1].XValueMember = "tempo";
            execucao.chart1.Series[1].YValueMembers = "velocidade";

            execucao.chart1.Series[2].XValueMember = "tempo";
            execucao.chart1.Series[2].YValueMembers = "aceleracao";

            execucao.chart1.Series[3].XValueMember = "tempo";
            execucao.chart1.Series[3].YValueMembers = "pressao";

            execucao.chart1.Series[4].XValueMember = "altitude";
            execucao.chart1.Series[4].YValueMembers = "pressao";

            execucao.chart1.Series[5].XValueMember = "tempo";
            execucao.chart1.Series[5].YValueMembers = "tempExterna";

            execucao.chart1.Series[6].XValueMember = "altitude";
            execucao.chart1.Series[6].YValueMembers = "tempExterna";

            execucao.chart1.Series[7].XValueMember = "tempo";
            execucao.chart1.Series[7].YValueMembers = "luminosidade";

            execucao.chart1.Series[8].XValueMember = "altitude";
            execucao.chart1.Series[8].YValueMembers = "altitude";
            #endregion

            #region Mapa
            RodarMapa();
            #endregion
        }

        #region Funções para Serial
        //Configura a porta serial
        public static int InicializarSerial()
        {
            //Configuração Serial
            serialPort = new SerialPort();
            serialPort.BaudRate = 115200;

            int resultado = OpenSerial();

            return resultado;
        }

        //Abre a porta serial
        public static int OpenSerial()
        {
            //Pesquisa da porta do dispositivo
            for (int porta = 0; porta <= 20; porta++)
            {
                try
                {
                    //Tenta conectar à uma porta
                    serialPort.PortName = "COM" + porta.ToString();
                    serialPort.Open();

                    #region Verificação do dispositivo
                    //Verifica se o dispositivo conectado é a antena
                    if (serialPort.IsOpen)
                    {
                        //Envia dado para o dispositivo
                        serialPort.WriteLine(Properties.Settings.Default.msgSendSerial);

                        //Aguarda 0,1seg pela resposta
                        Thread.Sleep(100);

                        //Recebe resposta do dispositivo
                        string msg = serialPort.ReadExisting(); //Falta verificar se o tempo de resposta é hábil

                        //Confirmação de que o dispositivo é a antena
                        if (msg == Properties.Settings.Default.msgRcvSerial)
                        {
                            InterfaceGeral.registrarLog("Conexao", Properties.Resources.logConexaoSerial);
                            return 1;
                        }
                        else
                        {
                            //Registra que a conexão à porta especificada ocasionou erro
                            InterfaceGeral.registrarLog("Conexao", Properties.Resources.erroPortaSerial + serialPort.PortName);

                            //Fecha a porta serial aberta
                            serialPort.Close();
                        }
                    }
                    #endregion
                }
                catch
                {
                    //Registra que a conexão à porta especificada ocasionou erro
                    InterfaceGeral.registrarLog("Conexao", Properties.Resources.erroPortaSerial + serialPort.PortName);
                }
            }

            return 0;
        }

        //Evento de recebimento de dados da serial
        private static void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Inicia o thread de tratamento
            if (serialPort.BytesToRead >= 240)
            {
                //Desabilita o evento de recepção enquanto processa
                serialPort.DataReceived -= SerialPort_DataReceived;

                Thread tratarDadosSerial = new Thread(() => TratarDadosSerial());
                tratarDadosSerial.Start();
                tratarDadosSerial.Join();
            }
        }
       
        //Tretamento de dados da serial
        private static void TratarDadosSerial()
        {
            try
            {
                //Lê os dados disponíveis
                int linha_size = serialPort.BytesToRead;
                byte[] linha = new byte[linha_size];
                serialPort.Read(linha, 0, linha_size - 1);

                #region Cortar a informação
                int numLinhas = linha.Length / Properties.Settings.Default.bytesInformacao;
                int numColunas = Properties.Settings.Default.bytesInformacao;
                byte[][] matriz = new byte[numLinhas][];

                //Inicializa as linhas da matriz
                for(int contador=0; contador<numLinhas; contador++)
                {
                    matriz[contador] = new byte[numColunas];
                }

                int i = 0;
                for (int contador = 0; contador <= (linha.Length-Properties.Settings.Default.bytesInformacao); contador++)
                {
                    if ((linha[contador] == Convert.ToInt32("11111111", 2)) && (linha[contador+1] == Convert.ToInt32("11111111", 2)))
                    {
                        for (int j = 0; (j < numColunas)&&((contador+j)<linha_size); j++)
                        {
                            matriz[i][j] = linha[contador+j];
                        }

                        i++;
                    }
                }
                #endregion

                #region Verificação da consistência dos dados
                int linhasPreenchidas = numLinhas;
                for(i=0;i<numLinhas;i++)
                {
                    //Verifica se ao menos numLinhas-1 está preenchido
                    for (int j=0; j<=1 ;j++)
                    {
                        if (matriz[i][j] != Convert.ToInt32("11111111", 2))
                            linhasPreenchidas--;
                    }

                    //Verifica a paridade (ímpar)
                    int bitsUm = 0;
                    for(int j=0; j<(numColunas-1);j++)
                    {
                        var bitsArray = new BitArray(new byte[] { matriz[i][j] });
                        for(int bit=0; bit<bitsArray.Length;bit++)
                        {
                            if(bitsArray[bit]==true)
                                bitsUm++;
                        }
                    }
                    if(((bitsUm%2==0)&&(matriz[i][numColunas-1]==0))||((bitsUm % 2 != 0) && (matriz[i][numColunas - 1] != 0)))
                    {
                        //Altera o primeiro byte do array que está corrompido para 0, para descartá-lo
                        registrarLog("Tratamento de dados", "Pacote de dados corrompido. Paridade inadequada.");
                        matriz[i][0] = 0;
                    }
                }

                if (linhasPreenchidas < (numLinhas - 1))
                {
                    registrarLog("Tratamento de dados", "Pacote de dados corrompido. Menos que uma linha.");
                    serialPort.DataReceived += SerialPort_DataReceived;
                    return;
                }
                #endregion

                #region Plotar dados
                int pacotesPlotados = 0;
                for(i=0; i<numLinhas;i++)
                {
                    //Verificar validade
                    if(matriz[i][0]==Convert.ToInt32("11111111",2))
                    {
                        //Mapear dados
                        mapaDados["luminosidade"] = BitConverter.ToInt16(matriz[i], 2)*Properties.Settings.Default.resLuminosidade;
                        mapaDados["tempExterna"] = (char)matriz[i][4] * Properties.Settings.Default.resTempExt;
                        mapaDados["tempInterna"] = (char)matriz[i][5] * Properties.Settings.Default.resTempInt;
                        mapaDados["pressao"] = (char)matriz[i][6] * Properties.Settings.Default.resPressao;
                        mapaDados["aceleracao"] = BitConverter.ToInt16(matriz[i], 7) * Properties.Settings.Default.resAceleracao;
                        mapaDados["longitude"] = -BitConverter.ToInt16(matriz[i], 9) *Properties.Settings.Default.resLongitude+ Properties.Settings.Default.origemLongitude;
                        mapaDados["latitude"] = -BitConverter.ToInt16(matriz[i], 11) * Properties.Settings.Default.resLatitude+Properties.Settings.Default.origemLatitude;
                        mapaDados["altitude"] = BitConverter.ToInt16(matriz[i], 13) * Properties.Settings.Default.resAltitude;
                        mapaDados["tempo_hora"] = (char)matriz[i][15] * Properties.Settings.Default.resTempoH;
                        mapaDados["tempo_minuto"] = (char)matriz[i][16] * Properties.Settings.Default.resTempoM;
                        mapaDados["tempo_segundo"] = (char)matriz[i][17] * Properties.Settings.Default.resTempoS;
                        mapaDados["velocidade"] = (char)matriz[i][18] * Properties.Settings.Default.resVelocidade;

                        //Identificação dos limites da altitude
                        if (mapaDados["altitude"] > maxAltitude)
                            maxAltitude = mapaDados["altitude"];
                        else if (mapaDados["altitude"] < minAltitude)
                            minAltitude = mapaDados["altitude"];

                        //Plotar pontos na tabela
                        plotarPontos();                      
                        pacotesPlotados++;

                        //Registrar nos arquivos
                        plotarFile();
                    }
                }
                #endregion

                #region Atualizar interface
                updateHome();
                updateMiniaturas();
                #endregion                

                #region Registrar Log
                registrarLog("Tratamento de dados", pacotesPlotados.ToString() + " pacotes adicionados com sucesso.");
                #endregion
            }
            catch (Exception e)
            {
                registrarLog("Tratamento de dados", e.Message);
            }

            //Habilita o evento de recepção após o processamento
            serialPort.DataReceived += SerialPort_DataReceived;
        }
        #endregion

        #region Funções para Home
        //Atualiza os valores instantâneos exibidos na tela de home
        private static void updateHome()
        {
            homeTextos[0].Invoke(new Action(()=>homeTextos[0].Text = mapaDados["luminosidade"].ToString()));
            homeTextos[1].Invoke(new Action(() => homeTextos[1].Text = mapaDados["latitude"].ToString()));
            homeTextos[2].Invoke(new Action(() => homeTextos[2].Text = mapaDados["longitude"].ToString()));
            homeTextos[3].Invoke(new Action(() => homeTextos[3].Text = mapaDados["pressao"].ToString()));
            homeTextos[4].Invoke(new Action(() => homeTextos[4].Text = mapaDados["tempExterna"].ToString()));
            homeTextos[5].Invoke(new Action(() => homeTextos[5].Text = mapaDados["tempInterna"].ToString()));
            homeTextos[6].Invoke(new Action(() => homeTextos[6].Text = mapaDados["velocidade"].ToString())); 
        }
        #endregion

        #region Funções para Log
        static public void readLogFile()
        {
            //Abre arquivo Log.txt
            StreamReader log = new StreamReader(InterfaceGeral.Path + @"\" + Properties.Resources.logFile);

            //Lê o arquivo Log.txt e seleciona apenas os dados referentes a execução atual
            string texto = "";
            while(!log.EndOfStream)
            {
                string linha = log.ReadLine();
                if (linha.Contains("CEXEC" + Properties.Settings.Default.numeroExecucao.ToString("00000")))
                    texto += linha.Replace("CEXEC" + Properties.Settings.Default.numeroExecucao.ToString("00000") + " - ", "")+"\n";
            }

            //Fecha o arquivo Log.txt
            log.Close();

            //Imprime os dados na janela de Log
            logTexto.Text = texto;
        }

        //Registra as ocorrências do software no Log
        public static void registrarLog(string grupo, string msg)
        {
            string linha = "CEXEC" + Properties.Settings.Default.numeroExecucao.ToString("00000") + " - " + DateTime.Now + " - " + grupo + " - " + msg;

            //Registra no arquivo local de log
            try
            {
                StreamWriter log = new StreamWriter(InterfaceGeral.Path + @"\" + Properties.Resources.logFile, true);
                log.WriteLine(linha);
                log.Close();
            }
            catch { }

            //Insere o registro no painel de log da execução
            string texto="";
            execucao.logTexto.BeginInvoke(new MethodInvoker(delegate { texto = execucao.logTexto.Text; }));
            linha = linha.Replace("CEXEC" + Properties.Settings.Default.numeroExecucao.ToString("00000") + " - ", "") + "\n";
            texto += linha;
            execucao.logTexto.Invoke(new Action(() => execucao.logTexto.Text = texto));
        }
        #endregion

        #region Funções para DataSet
        //Plota os novos pontos na tabela
        static public void plotarPontos()
        {
            int tempo = (int)(mapaDados["tempo_hora"] * 3600 + mapaDados["tempo_minuto"] * 60 + mapaDados["tempo_segundo"] - mapaDados["tempo_inicial"]);
            double distancia = 6371 * Math.Acos(Math.Cos(Math.PI * (90 - mapaDados["longitude"]) / 180) * Math.Cos((90 - Properties.Settings.Default.origemLongitude) * Math.PI / 180) + Math.Sin((90 - mapaDados["longitude"]) * Math.PI / 180) * Math.Sin((90 - Properties.Settings.Default.origemLongitude) * Math.PI / 180) * Math.Cos((Properties.Settings.Default.origemLatitude - mapaDados["latitude"]) * Math.PI / 180));

            dataTable1.Rows.Add(tempo, mapaDados["altitude"], mapaDados["luminosidade"], mapaDados["tempExterna"], mapaDados["pressao"], mapaDados["aceleracao"], distancia, mapaDados["velocidade"]);
        }
        #endregion

        #region Funções para Gráficos
        //Atualiza as miniaturas dos gráficos para a correta exibição dos dados
        static public void updateMiniaturas()
        {
            //DataBind do gráfico
            execucao.chart1.Invoke(new Action(() => execucao.chart1.DataBind()));
            
            //Ajuste dos eixos
            for (int i=0; i<9; i++)
            {
                execucao.chart1.Invoke(new Action(() => execucao.chart1.ChartAreas[i].RecalculateAxesScale()));
            }
        }
        #endregion

        #region Funções para Mapa
        static public void RodarMapa()
        {
     //       Process.Start(Properties.Resources.localChrome, Properties.Resources.enderecoMapa+"?CEXEC=CEXEC"+Properties.Settings.Default.numeroExecucao.ToString("00000"));
        }
        #endregion

        #region Funções para arquivos
        //Registra os dados nos locais especificados
        private static void plotarFile()
        {
            //Adaptação dos dados para registro em arquivo e database
            string linha_file="";
            string linha_database = "";
            foreach(KeyValuePair<string,double> parValor in mapaDados)
            {
                linha_file += parValor.Value.ToString() + ";";
                linha_database += parValor.Key + "=" + parValor.Value.ToString() + "&";
            }
            linha_database += "codigoExecucao=CEXEC" + Properties.Settings.Default.numeroExecucao.ToString("00000");

            //Salvar em arquivo local
            try
            {
                StreamWriter local = new StreamWriter(InterfaceGeral.Path + @"\" + Properties.Settings.Default.nomeArquivo, true);
                local.WriteLine(linha_file);
                local.Close();

             //   registrarLog("Registro de dados", "Registrado em arquivo local com êxito.");
            }
            catch (Exception e)
            {
                registrarLog("Registro de dados", "Erro no registro em arquivo local. "+e.Message);
            }

            //Salvar em arquivo removível
            try
            {
                StreamWriter removivel = new StreamWriter(Properties.Settings.Default.enderecoRemovivel + @"\" + Properties.Settings.Default.nomeArquivo, true);
                removivel.WriteLine(linha_file);
                removivel.Close();

                registrarLog("Registro de dados", "Registrado em arquivo removível com êxito.");
            }
            catch (Exception e)
            {
                registrarLog("Registro de dados", "Erro no registro em arquivo removível. "+e.Message);
            }
        }

        //Envia a requisição de comunicação para o database
        private static string SendRequest(string url)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    return client.DownloadString(url);
                }
            }
            catch 
            {
                return null;
            }
        }
        #endregion

        #region Funções para teste de desenvolvimento
        public static void Teste(Point localizacao)
        {
            #region Preencher o Mapa de dados
            mapaDados["luminosidade"] = localizacao.X;
            mapaDados["tempExterna"] = localizacao.X;
            mapaDados["tempInterna"] = localizacao.X;
            mapaDados["pressao"] = localizacao.X;
            mapaDados["aceleracao"] = localizacao.X;
            mapaDados["longitude"] = localizacao.X;
            mapaDados["latitude"] = localizacao.X;
            mapaDados["altitude"] = localizacao.Y;
            mapaDados["tempo_hora"] = DateTime.UtcNow.Hour;
            mapaDados["tempo_minuto"] = DateTime.UtcNow.Minute;
            mapaDados["tempo_segundo"] = DateTime.UtcNow.Second;
            mapaDados["velocidade"] = localizacao.X;
            #endregion

            updateHome();
            //plotarPontos();
            updateMiniaturas();
            plotarFile();
        }
        #endregion
    }
}
