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
    class Dados
    {
        readonly string _moedaUrl;
        public Cotacao Cotacao;
        public List<Ordem> ListaOrdens;

        public Dados(string moeda)
        {
            _moedaUrl = moeda;
        }

        public void Resumo()
        {
            String url = "https://www.mercadobitcoin.net/api/" + _moedaUrl + "/ticker/";
            var request = WebRequest.Create(url);
            request.ContentType = "application/json; charset=utf-8";
            var response = (HttpWebResponse)request.GetResponse();

            string text;

            using (var sr = new StreamReader(stream: response.GetResponseStream() ?? SemResposta("Resumo")))
            {
                text = sr.ReadToEnd();
            }

            Cotacao = new Cotacao(text);
            
        }

        public void Ordens()
        {
            String url = "https://www.mercadobitcoin.net/api/" + _moedaUrl + "/orderbook/";
            var request = WebRequest.Create(url);
            request.ContentType = "application/json; charset=utf-8";
            var response = (HttpWebResponse)request.GetResponse();

            string text;

            using (var sr = new StreamReader(stream: response.GetResponseStream() ?? SemResposta("Ordens")))
            {
                text = sr.ReadToEnd();
            }
            
            OrdensJson ordens = new OrdensJson(text);

        }

        private static Stream SemResposta(string erro)
        {
            throw new Exception("Erro ao realizar consulta: "+erro);
        }
    }
}
