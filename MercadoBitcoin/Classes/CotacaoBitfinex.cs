using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MercadoBitcoin.Classes
{
    class CotacaoBitfinex
    {
        public float Bid { get; set; }
        public float BidSize { get; set; }
        public float Ask { get; set; }
        public float AskSize { get; set; }
        public float DaiyChange { get; set; }
        public float DaiyChangePerc { get; set; }
        public float LastPrice { get; set; }
        public float Volume { get; set; }
        public float High { get; set; }
        public float Low { get; set; }

        public CotacaoBitfinex(string json)
        {
            List<float> cotacao = JsonConvert.DeserializeObject<List<float>>(json);

            Bid = cotacao[0];
            BidSize = cotacao[1];
            Ask = cotacao[2];
            AskSize = cotacao[3];
            DaiyChange = cotacao[4];
            DaiyChangePerc = cotacao[5];
            LastPrice = cotacao[6];
            Volume = cotacao[7];
            High = cotacao[8];
            Low = cotacao[9];
        }
    }

    public class CotacaoIotaJson
    {
        
        
    }

    public class tickerIotaJson
    {
        public CotacaoJson ticker { get; set; }
    }
}
