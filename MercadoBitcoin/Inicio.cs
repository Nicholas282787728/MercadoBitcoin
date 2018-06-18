using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using MercadoBitcoin.Classes;

namespace MercadoBitcoin
{
    public partial class Inicio : Form
    {

        Thread t;
        int segundos;
        private float valor;

        public Inicio()
        {
            InitializeComponent();
            CarregaValores();

            vlrBTC.Text = null;
            vlrBCH.Text = null;
            vlrLTC.Text = null;
            vlrIOT.Text = null;
            vlrDSH.Text = null;
            vlrGNT.Text = null;
            vlrIOTUSD.Text = null;
            vlrDSHUSD.Text = null;
            vlrGNTUSD.Text = null;

            totalBTC.Text = null;
            totalBCH.Text = null;
            totalLTC.Text = null;
            totalIOT.Text = null;
            totalDSH.Text = null;
            totalGNT.Text = null;

            total.Text = null;
            lblUlt.Text = null;
        }

        private void GuardaVAlores()
        {
            string nomeArquivo = Directory.GetCurrentDirectory() + @"\parametros.txt";
            StreamWriter writer = new StreamWriter(nomeArquivo);

            writer.WriteLine(qtdeBTC.Text);
            writer.WriteLine(qtdeBCH.Text);
            writer.WriteLine(qtdeLTC.Text);
            writer.WriteLine(qtdeIOT.Text);
            writer.WriteLine(qtdeDSH.Text);
            writer.WriteLine(qtdeGNT.Text);
            writer.Close();
        }

        private void CarregaValores()
        {
            try
            {
                string[] lines = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\parametros.txt");
                try
                {
                    qtdeBTC.Text = lines[0];
                    qtdeBCH.Text = lines[1];
                    qtdeLTC.Text = lines[2];
                    qtdeIOT.Text = lines[3];
                    qtdeDSH.Text = lines[4];
                    qtdeGNT.Text = lines[5];
                }
                catch (Exception e)
                {
                    if (String.IsNullOrEmpty(qtdeBTC.Text)) { qtdeBTC.Text = "00,0000"; }
                    if (String.IsNullOrEmpty(qtdeBCH.Text)) { qtdeBCH.Text = "00,0000"; }
                    if (String.IsNullOrEmpty(qtdeLTC.Text)) { qtdeLTC.Text = "00,0000"; }
                    if (String.IsNullOrEmpty(qtdeIOT.Text)) { qtdeIOT.Text = "00,0000"; }
                    if (String.IsNullOrEmpty(qtdeDSH.Text)) { qtdeDSH.Text = "00,0000"; }
                }
                
            }
            catch (FileNotFoundException e)
            {
                if (String.IsNullOrEmpty(qtdeBTC.Text)) { qtdeBTC.Text = "00,0000"; }
                if (String.IsNullOrEmpty(qtdeBCH.Text)) { qtdeBCH.Text = "00,0000"; }
                if (String.IsNullOrEmpty(qtdeLTC.Text)) { qtdeLTC.Text = "00,0000"; }
                if (String.IsNullOrEmpty(qtdeIOT.Text)) { qtdeIOT.Text = "00,0000"; }
                if (String.IsNullOrEmpty(qtdeDSH.Text)) { qtdeDSH.Text = "00,0000"; }
                if (String.IsNullOrEmpty(qtdeGNT.Text)) { qtdeGNT.Text = "00,0000"; }
            }
           
        }

        private void PegaCotacao( out float cotBTC
                                , out float cotIOT
                                , out float cotIOTUSD
                                , out float cotDSH
                                , out float cotDSHUSD
                                , out float cotBCH
                                , out float cotLTC
                                , out float cotGNT
                                , out float cotGNTUSD)
        {
            Moeda moeda;
            cotBTC = 0;
            cotIOT = 0;
            cotIOTUSD = 0;
            cotDSH = 0;
            cotDSHUSD = 0;
            cotBCH = 0;
            cotLTC = 0;
            cotGNT = 0;
            cotGNTUSD = 0;

            moeda = new Moeda(Moeda.Tipo.Bitcoin);
            moeda.Dados.Resumo();
            cotBTC = moeda.Dados.Cotacao.Ultima;
            
            //Conversao IOT pra reais.
            //Pega primeiro a cotação em IOT-> BTC e dps multiplica pela BTC -> R$
            moeda = new Moeda(Moeda.Tipo.IotBtc);
            moeda.DadosBitfinex.Resumo();
            cotIOT = cotBTC * moeda.DadosBitfinex.Cotacao.LastPrice;
            
            //Pega conversao IOT pra USD direta para mostrar em tela
            moeda = new Moeda(Moeda.Tipo.IotUsd);
            moeda.DadosBitfinex.Resumo();
            cotIOTUSD = moeda.DadosBitfinex.Cotacao.LastPrice;
            
            //Conversao DHS pra reais.
            //Pega primeiro a cotação em DSH-> BTC e dps multiplica pela BTC -> R$
            moeda = new Moeda(Moeda.Tipo.DshBtc);
            moeda.DadosBitfinex.Resumo();
            cotDSH = cotBTC * moeda.DadosBitfinex.Cotacao.LastPrice;
            
            //Pega conversao DSH pra USD direta para mostrar em tela
            moeda = new Moeda(Moeda.Tipo.DshUsd);
            moeda.DadosBitfinex.Resumo();
            cotDSHUSD = moeda.DadosBitfinex.Cotacao.LastPrice;

            //Conversao GNT pra reais.
            //Pega primeiro a cotação em GNT-> BTC e dps multiplica pela BTC -> R$
            moeda = new Moeda(Moeda.Tipo.GntBtc);
            moeda.DadosBitfinex.Resumo();
            cotGNT = cotBTC * moeda.DadosBitfinex.Cotacao.LastPrice;

            //Pega conversao GNT pra USD direta para mostrar em tela
            moeda = new Moeda(Moeda.Tipo.GntUsd);
            moeda.DadosBitfinex.Resumo();
            cotGNTUSD = moeda.DadosBitfinex.Cotacao.LastPrice;

            moeda = new Moeda(Moeda.Tipo.BitcoinCash);
            moeda.Dados.Resumo();
            cotBCH = moeda.Dados.Cotacao.Ultima;
            
            moeda = new Moeda(Moeda.Tipo.Litecoin);
            moeda.Dados.Resumo();
            cotLTC = moeda.Dados.Cotacao.Ultima;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float cotBTC;
            float cotIOT;
            float cotIOTUSD;
            float cotDSH;
            float cotDSHUSD;
            float cotBCH;
            float cotLTC;
            float cotGNT;
            float cotGNTUSD;

            PegaCotacao(out cotBTC, out cotIOT, out cotIOTUSD, out cotDSH, out cotDSHUSD, out cotBCH, out cotLTC, out cotGNT, out cotGNTUSD);

            vlrBTC.Text = cotBTC.ToString();
            vlrIOT.Text = cotIOT.ToString();
            vlrIOTUSD.Text = cotIOTUSD.ToString();
            vlrDSH.Text = cotDSH.ToString();
            vlrDSHUSD.Text = cotDSHUSD.ToString();
            vlrBCH.Text = cotBCH.ToString();
            vlrLTC.Text = cotLTC.ToString();
            vlrGNT.Text = cotGNT.ToString();
            vlrGNTUSD.Text = cotGNTUSD.ToString();

            totalBTC.Text = (float.Parse(qtdeBTC.Text) * float.Parse(vlrBTC.Text)).ToString();
            totalBCH.Text = (float.Parse(qtdeBCH.Text) * float.Parse(vlrBCH.Text)).ToString();
            totalLTC.Text = (float.Parse(qtdeLTC.Text) * float.Parse(vlrLTC.Text)).ToString();
            totalIOT.Text = (float.Parse(qtdeIOT.Text) * float.Parse(vlrIOT.Text)).ToString();
            totalDSH.Text = (float.Parse(qtdeDSH.Text) * float.Parse(vlrDSH.Text)).ToString();
            totalGNT.Text = (float.Parse(qtdeGNT.Text) * float.Parse(vlrGNT.Text)).ToString();

            total.Text = (float.Parse(totalBTC.Text) +
                          float.Parse(totalBCH.Text) +
                          float.Parse(totalLTC.Text) +
                          float.Parse(totalIOT.Text) +
                          float.Parse(totalDSH.Text) +
                          float.Parse(totalGNT.Text)).ToString();

            lblUlt.Text = DateTime.Now.ToString();

        }
        
        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            Sai();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abre();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sai();
            Application.Exit();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Abre();
        }

        private void Inicio_Move(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            Abre();
        }

        private void Abre()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (t != null)
            {
                if (t.IsAlive)
                {
                    t.Abort();
                    button2.Text = "Iniciar";
                    return;
                }
            }
            

            try
            {
                segundos = int.Parse(tempo.Text);
            }
            catch (Exception exception)
            {
                segundos = 5;
                tempo.Text = "5";
            }

            Thread t2 = new Thread(Automatico);
            t = t2;
            t.Start();
            button2.Text = "Parar";

        }

        private void Automatico()
        {
            float cotBTC = 0;
            float cotIOT = 0;
            float cotIOTUSD = 0;
            float cotDSH = 0;
            float cotDSHUSD = 0;
            float cotBCH = 0;
            float cotLTC = 0;

            while (true)
            {
                float antCotBTC = 0;
                float antCotIOT = 0;
                float antCotIOTUSD = 0;
                float antCotDSH = 0;
                float antCotDSHUSD = 0;
                float antCotBCH = 0;
                float antCotLTC = 0;
                float cotGNT;
                float cotGNTUSD;

                try
                {
                    PegaCotacao(out cotBTC, out cotIOT, out cotIOTUSD, out cotDSH, out cotDSHUSD, out cotBCH, out cotLTC, out cotGNT, out cotGNTUSD);

                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro na busca da cotação");
                    button2.PerformClick();
                }

                notifyIcon1.ShowBalloonTip(100, "Ric4", "  BTC   = " + (float.Parse(qtdeBTC.Text) * cotBTC).ToString() + "\n" +
                                                        "  BCH  = " + (float.Parse(qtdeBCH.Text) * cotBCH).ToString() + "\n" +
                                                        "  LTC   = " + (float.Parse(qtdeLTC.Text) * cotLTC).ToString() + "\n" +
                                                        "  IOT    = " + (float.Parse(qtdeIOT.Text) * cotIOT).ToString() + "\n" +
                                                        "  DSH   = " + (float.Parse(qtdeDSH.Text) * cotDSH).ToString() + "\n" +
                                                        "TOTAL = " + ((float.Parse(qtdeBTC.Text) * cotBTC) +
                                                                      (float.Parse(qtdeBCH.Text) * cotBCH) +
                                                                      (float.Parse(qtdeLTC.Text) * cotLTC) +
                                                                      (float.Parse(qtdeIOT.Text) * cotIOT) +
                                                                      (float.Parse(qtdeDSH.Text) * cotDSH)).ToString() + "\n" +
                                                         "", ToolTipIcon.None);

                Thread.Sleep(segundos * 1000);
            }
            
        }

        private void Sai()
        {
            try
            {
                if (t.IsAlive)
                {
                    t.Abort();
                    button2.Text = "Iniciar";
                    return;
                }

                
            }
            catch (Exception e)
            {
            }

            GuardaVAlores();


        }
    }
}
