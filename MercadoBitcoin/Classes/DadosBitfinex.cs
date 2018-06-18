using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercadoBitcoin.Classes
{
    class DadosBitfinex
    {
        readonly string _moedaUrl;
        public CotacaoBitfinex Cotacao;
        
        public DadosBitfinex(string moeda)
        {
            _moedaUrl = moeda;
        }

        public void Resumo()
        {
            String url = "https://api.bitfinex.com/v2/ticker/" + _moedaUrl;
            var request = WebRequest.Create(url);
            request.ContentType = "application/json; charset=utf-8";

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                string text;

                using (var sr = new StreamReader(stream: response.GetResponseStream() ?? SemResposta("Resumo")))
                {
                    text = sr.ReadToEnd();
                }

                Cotacao = new CotacaoBitfinex(text);
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na busca da cotação." + e.ToString());
            }
            

            
            
        }
        
        private static Stream SemResposta(string erro)
        {
            throw new Exception("Erro ao realizar consulta: "+erro);
        }
    }
}
