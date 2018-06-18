using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MercadoBitcoin.Classes
{
    class Cotacao
    {
        public DateTime Data { get; set; }
        public float Venda { get; set; }
        public float Compra { get; set; }
        public float Ultima { get; set; }
        public float Maior { get; set; }
        public float Menor { get; set; }
        public float Volume { get; set; }
        
        public Cotacao(string json)
        {
            
            tickerJson cotAux = JsonConvert.DeserializeObject<tickerJson>(json);
            
            Venda = cotAux.ticker.sell;
            Compra = cotAux.ticker.buy;
            Ultima = cotAux.ticker.last;
            Maior = cotAux.ticker.high;
            Menor = cotAux.ticker.low;
            Volume = cotAux.ticker.vol;
            Data = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(cotAux.ticker.date);
        }
    }

    public class CotacaoJson
    {
        public float high { get; set; }
        public float low { get; set; }
        public float vol { get; set; }
        public float last { get; set; }
        public float buy { get; set; }
        public float sell { get; set; }
        public int date { get; set; }
    }

    public class tickerJson
    {
        public CotacaoJson ticker { get; set; }
    }
}
